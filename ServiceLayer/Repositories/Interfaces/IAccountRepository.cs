using ServiceLayer.DTOs.UserDTO;
using ServiceLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Repositories.Interfaces
{
    public interface IAccountRepository
    {
        public Task<ResponseDto> LoginAsync(LoginDto login);
        public Task<ResponseDto> GetRefreshToken(string email);
        public Task<ResponseDto> RegisterAsync(RegisterDto register);
        public Task<ResponseDto> DeleteAccountAsync(LoginDto dto);
        public Task<ResponseDto> ChangePassword(PasswordSettingDto password);
        public Task<ResponseDto> UpdateProfile(UserDto user, string currentEmail);
        public Task<ResponseDto> ResetPassword(ResetPasswordDto dto);
    }
}
