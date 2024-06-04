using System.Security.Claims;

namespace identity_jwt.Interfaces
{
    public interface IJwtService
    {
        Task<string> GenerateToken(IEnumerable<Claim> claims);
    }
}
