using identity_jwt.Models.DTOs;

namespace identity_jwt.Interfaces
{
    public interface IAccountRepository
    {
        public Task<ResponseDTO> RegisterAccount(RegisterDTO registerdto);
        public Task<ResponseDTO> LoginAccount(LoginDTO logindto);
    }
}
