using MyLibrary.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Domain.Services.Interface
{
    public interface IUserServices
    {
        #region Auth
        Task<ResponseDto> Login(UserDto user);
        Task<ResponseDto> Register(RegisterDto data);
        #endregion
        #region Methods Crud
        Task<ResponseDto> GetAllUsers(string token);
        
        #endregion
    }
}
