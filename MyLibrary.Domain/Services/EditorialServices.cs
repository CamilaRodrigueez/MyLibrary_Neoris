using Common.Utils.RestServices.Interface;
using Microsoft.Extensions.Configuration;
using MiLibrary.Domain.Dto.EditorialDto;
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
    public class EditorialServices : IEditorialServices
    {
        #region Attribute
        private readonly IRestService _restService;
        private readonly IConfiguration _config;
        #endregion

        #region Builder
        public EditorialServices(IRestService restService, IConfiguration config)
        {
            _restService = restService;
            _config = config;

        }
        #endregion
        #region Methods
        public async Task<ResponseDto> GetAllEditorial(string token)
        {

            string urlBase = _config.GetSection("ApiMyLibrary").GetSection("UrlBase").Value;
            string controller = _config.GetSection("ApiMyLibrary").GetSection("ControlerEditorial").Value;
            string method = _config.GetSection("ApiMyLibrary").GetSection("MethodGetAllEditorial").Value;


            Dictionary<string, string> parameters = new Dictionary<string, string>();
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Token", token);

            ResponseDto response = await _restService.GetRestServiceAsync<ResponseDto>(urlBase, controller, method, parameters, headers);
            if (response.IsSuccess)
                response.Result = JsonConvert.DeserializeObject<List<ConsultEditorialDto>>(response.Result.ToString());

            return response;

        }
        public async Task<ResponseDto> InsertEditorialAsync(InsertEditorialDto data, string token)
        {
            string urlBase = _config.GetSection("ApiMyLibrary").GetSection("UrlBase").Value;
            string controller = _config.GetSection("ApiMyLibrary").GetSection("ControlerEditorial").Value;
            string method = _config.GetSection("ApiMyLibrary").GetSection("MethodInsertEditorial").Value;

            InsertEditorialDto parameters = new InsertEditorialDto()
            {
                Name = data.Name,
                Direction = data.Direction,
            };

            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Token", token);

            ResponseDto resultToken = await _restService.PostRestServiceAsync<ResponseDto>(urlBase, controller, method, parameters, headers);

            return resultToken;
        }
        public async Task<ResponseDto> UpdateEditorialAsync(EditorialDto data, string token)
        {
            string urlBase = _config.GetSection("ApiMyLibrary").GetSection("UrlBase").Value;
            string controller = _config.GetSection("ApiMyLibrary").GetSection("ControlerEditorial").Value;
            string method = _config.GetSection("ApiMyLibrary").GetSection("MethodUpdateEditorial").Value;

            EditorialDto parameters = new EditorialDto()
            {
                Id = data.Id,
                Name = data.Name,
                Direction = data.Direction,
            };

            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Token", token);

            ResponseDto resultToken = await _restService.PutRestServiceAsync<ResponseDto>(urlBase, controller, method, parameters, headers);

            return resultToken;
        }
        public async Task<ResponseDto> DeleteEditorialAsync(string token, string id)
        {
            string urlBase = _config.GetSection("ApiMyLibrary").GetSection("UrlBase").Value;
            string controller = _config.GetSection("ApiMyLibrary").GetSection("ControlerEditorial").Value;
            string method = _config.GetSection("ApiMyLibrary").GetSection("MethodDeleteEditorial").Value;
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("id",id);
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Token", token);

            ResponseDto resultToken = await _restService.DeleteRestServiceAsync<ResponseDto>(urlBase, controller, method, parameters, headers);

            return resultToken;

        }

        #endregion

    } 
}
