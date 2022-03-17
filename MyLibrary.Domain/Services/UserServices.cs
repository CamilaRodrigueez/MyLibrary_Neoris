using Common.Utils.Exceptions;
using Common.Utils.RestServices.Interface;
using Common.Utils.Utils;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MyLibrary.Domain.Dto;
using MyLibrary.Domain.Services.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static Common.Utils.Constant.Const;
using static Common.Utils.Enums.Enums;

namespace MyLibrary.Domain.Services
{
    public class UserServices: IUserServices
    {
        #region Attribute
        private readonly IRestService _restService;
        private readonly IConfiguration _config;
        #endregion

        #region Builder
        public UserServices(IRestService restService, IConfiguration config)
        {
            _restService = restService;
            _config = config;
        }
        #endregion




        #region authentication
        public async Task<ResponseDto> Login(UserDto user)
        {

            string urlBase = _config.GetSection("ApiMyLibrary").GetSection("UrlBase").Value;
            string controller = _config.GetSection("ApiMyLibrary").GetSection("ControlerAuthentication").Value;
            string method = _config.GetSection("ApiMyLibrary").GetSection("MethodLogin").Value;

            LoginDto parameters = new LoginDto()
            {
                Password = user.Password,
                UserName = user.UserName,
            };
            Dictionary<string, string> headers = new Dictionary<string, string>();
            ResponseDto resultToken = await _restService.PostRestServiceAsync<ResponseDto>(urlBase, controller, method, parameters, headers);

            return resultToken;

        }
        #endregion

        #region Methods Crud
        public async Task<ResponseDto> GetAllUsers(string token)
        {
            string urlBase = _config.GetSection("ApiMyLibrary").GetSection("UrlBase").Value;
            string controller = _config.GetSection("ApiMyLibrary").GetSection("ControlerUsers").Value;
            string method = _config.GetSection("ApiMyLibrary").GetSection("MethodGetAllUsers").Value;


            Dictionary<string, string> parameters = new Dictionary<string, string>();
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Token", token);

            ResponseDto response = await _restService.GetRestServiceAsync<ResponseDto>(urlBase, controller, method, parameters, headers);
            if (response.IsSuccess)
                response.Result = JsonConvert.DeserializeObject<List<UserDto>>(response.Result.ToString());

            return response;
        }


        public async Task<ResponseDto> Register(RegisterDto data)
        {
            string urlBase = _config.GetSection("ApiMyLibrary").GetSection("UrlBase").Value;
            string controller = _config.GetSection("ApiMyLibrary").GetSection("ControlerAuthentication").Value;
            string method = _config.GetSection("ApiMyLibrary").GetSection("MethodRegister").Value;

            RegisterDto parameters = new RegisterDto()
            {
                Name = data.Name,
                LastName = data.LastName,
                UserName = data.UserName,
                Password = data.Password,
                ConfirmPassword = data.ConfirmPassword,
                
            };
            Dictionary<string, string> headers = new Dictionary<string, string>();
            ResponseDto resultToken = await _restService.PostRestServiceAsync<ResponseDto>(urlBase, controller, method, parameters, headers);

            return resultToken;

        }
        #endregion
    }
}
