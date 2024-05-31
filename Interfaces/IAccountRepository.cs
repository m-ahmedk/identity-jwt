using identity_jwt.DTOs;

namespace identity_jwt.Interfaces
{
    public interface IAccountRepository
    {
        public Task<(int, string)> RegisterAccount(RegisterDTO registerdto);
        public Task<(int, string)> LoginAccount(LoginDTO logindto);
    }
}
