using identity_jwt.Interfaces;
using identity_jwt.Models;
using identity_jwt.Models.DTOs;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace identity_jwt.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IJwtService _jwtService;
        private readonly IConfiguration _configuration;

        public AccountRepository(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration, IJwtService jwtService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _jwtService = jwtService;
        }
        public async Task<ResponseDTO> RegisterAccount(RegisterDTO registerdto)
        {
            var isRegistered = await _userManager.FindByEmailAsync(registerdto.Email);
            if (isRegistered is not null)
                return new ResponseDTO(false, "User is already registered");

            AppUser appUser = new AppUser()
            {
                SecurityStamp = Guid.NewGuid().ToString(),
                FirstName = registerdto.FirstName,
                LastName = registerdto.LastName
            };

            var isUserResult = await _userManager.CreateAsync(appUser, registerdto.Password);
            if (!isUserResult.Succeeded)
            {
                var errors = isUserResult.Errors.Select(x => x.Code + ": " + x.Description).ToList();
                return new ResponseDTO(false, $"Unable to create user, please see details:\n{string.Join("\n", errors)}");
            }

            string role = "New User";

            if (!await _roleManager.RoleExistsAsync(role))
                await _roleManager.CreateAsync(new IdentityRole(role));

            await _userManager.AddToRoleAsync(appUser, role);
            return new ResponseDTO(true, "User has been created successfully");
            ;
        }

        public async Task<ResponseDTO> LoginAccount(LoginDTO logindto)
        {
            var user = await _userManager.FindByEmailAsync(logindto.Email);

            if (user == null)
                return new ResponseDTO(false, "Invalid username");

            if (!await _userManager.CheckPasswordAsync(user, logindto.Password))
                return new ResponseDTO(false, "Invalid password");

            // Retrieve roles assigned
            var userRoles = await _userManager.GetRolesAsync(user);

            var authClaims = new List<Claim>
            {
               new Claim(ClaimTypes.Name, user.UserName), // username
               new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()), // unique id
            };

            foreach (var userRole in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, userRole)); // role(s)
            }

            string token = await _jwtService.GenerateToken(authClaims); // pass to payload and generate token

            return new ResponseDTO(true, token);
        }

    }
}
