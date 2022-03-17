using Common.Utils.RestServices.Interface;
using Microsoft.Extensions.Configuration;
using MiLibrary.Domain.Dto.Authors;
using MiLibrary.Domain.Services.Interface;
using MyLibrary.Domain.Dto;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiLibrary.Domain.Services
{
    
    public class AuthorsServices : IAuthorsServices
    {
       
        #region Attribute
        private readonly IRestService _restService;
        private readonly IConfiguration _config;
        #endregion

        #region Builder
        public AuthorsServices( IRestService restService, IConfiguration config)
        {
            _restService = restService;
            _config = config;
            
        }
        #endregion

        #region Methods
        public async Task<ResponseDto> GetAllAuthors(string token)
        {

            string urlBase = _config.GetSection("ApiMyLibrary").GetSection("UrlBase").Value;
            string controller = _config.GetSection("ApiMyLibrary").GetSection("ControlerAuthors").Value;
            string method = _config.GetSection("ApiMyLibrary").GetSection("MethodGetAllAuthors").Value;


            Dictionary<string, string> parameters = new Dictionary<string, string>();
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Token", token);

            ResponseDto response = await _restService.GetRestServiceAsync<ResponseDto>(urlBase, controller, method, parameters, headers);
            if (response.IsSuccess)
                response.Result = JsonConvert.DeserializeObject<List<ConsultAuthorsDto>>(response.Result.ToString());

            return response;

        }

        public async Task<ResponseDto> InsertAuthorAsync(InsertAuthorsDto data, string token)
        {
            string urlBase = _config.GetSection("ApiMyLibrary").GetSection("UrlBase").Value;
            string controller = _config.GetSection("ApiMyLibrary").GetSection("ControlerAuthors").Value;
            string method = _config.GetSection("ApiMyLibrary").GetSection("MethodInsertAuthor").Value;

            InsertAuthorsDto parameters = new InsertAuthorsDto()
            {
               Name = data.Name,
               LastName = data.LastName,
            };

            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Token", token);

            ResponseDto resultToken = await _restService.PostRestServiceAsync<ResponseDto>(urlBase, controller, method, parameters, headers);

            return resultToken;

        }
        public async Task<ResponseDto> UpdateAuthorAsync(AuthorsDto data, string token)
        {
            string urlBase = _config.GetSection("ApiMyLibrary").GetSection("UrlBase").Value;
            string controller = _config.GetSection("ApiMyLibrary").GetSection("ControlerAuthors").Value;
            string method = _config.GetSection("ApiMyLibrary").GetSection("MethodUpdateAuthor").Value;

            AuthorsDto parameters = new AuthorsDto()
            {  
                Id = data.Id, 
                Name = data.Name,
                LastName = data.LastName,
            };

            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Token", token);

            ResponseDto resultToken = await _restService.PutRestServiceAsync<ResponseDto>(urlBase, controller, method, parameters, headers);

            return resultToken;
        }

        public async Task<ResponseDto> DeleteAuthorAsync(string token, string id)
        {
            string urlBase = _config.GetSection("ApiMyLibrary").GetSection("UrlBase").Value;
            string controller = _config.GetSection("ApiMyLibrary").GetSection("ControlerAuthors").Value;
            string method = _config.GetSection("ApiMyLibrary").GetSection("MethodDeleteAuthor").Value;
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("id", id);
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Token", token);
           
            ResponseDto resultToken = await _restService.DeleteRestServiceAsync<ResponseDto>(urlBase, controller, method, parameters, headers);

            return resultToken;
           
        }
        #endregion
    }
}
