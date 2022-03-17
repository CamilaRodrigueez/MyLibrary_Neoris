using Common.Utils.RestServices.Interface;
using Microsoft.Extensions.Configuration;
using MiLibrary.Domain.Dto.EditorialDto;
using MyLibrary.Domain.Dto;
using MyLibrary.Domain.Dto.Books;
using MyLibrary.Domain.Services.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Domain.Services
{
    public class BooksServices : IBooksServices
    {
        #region Attribute
        private readonly IRestService _restService;
        private readonly IConfiguration _config;
        #endregion

        #region Builder
        public BooksServices(IRestService restService, IConfiguration config)
        {
            _restService = restService;
            _config = config;

        }
        #endregion
        #region Methods
        public async Task<ResponseDto> GetAllBooks(string token)
        {

            string urlBase = _config.GetSection("ApiMyLibrary").GetSection("UrlBase").Value;
            string controller = _config.GetSection("ApiMyLibrary").GetSection("ControlerBooks").Value;
            string method = _config.GetSection("ApiMyLibrary").GetSection("MethodGetAllBooks").Value;


            Dictionary<string, string> parameters = new Dictionary<string, string>();
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Token", token);

            ResponseDto response = await _restService.GetRestServiceAsync<ResponseDto>(urlBase, controller, method, parameters, headers);
            if (response.IsSuccess)
                response.Result = JsonConvert.DeserializeObject<List<ConsultBooksDto>>(response.Result.ToString());

            return response;
         
        }
        public async Task<ResponseDto> GetAllTypeState(string token)
        {

            string urlBase = _config.GetSection("ApiMyLibrary").GetSection("UrlBase").Value;
            string controller = _config.GetSection("ApiMyLibrary").GetSection("ControlerBooks").Value;
            string method = _config.GetSection("ApiMyLibrary").GetSection("MethodGetAllTypeState").Value;


            Dictionary<string, string> parameters = new Dictionary<string, string>();
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Token", token);

            ResponseDto response = await _restService.GetRestServiceAsync<ResponseDto>(urlBase, controller, method, parameters, headers);
            if (response.IsSuccess)
                response.Result = JsonConvert.DeserializeObject<List<TypeStateDto>>(response.Result.ToString());

            return response;

        }
        public async Task<ResponseDto> InsertBooksAsync(InsertBooksDto data, string token)
        {
            string urlBase = _config.GetSection("ApiMyLibrary").GetSection("UrlBase").Value;
            string controller = _config.GetSection("ApiMyLibrary").GetSection("ControlerBooks").Value;
            string method = _config.GetSection("ApiMyLibrary").GetSection("MethodInsertBooks").Value;

            InsertBooksDto parameters = new InsertBooksDto()
            {
                Title = data.Title,
                Gender = data.Gender,
                Pages = data.Pages,
                Synopsis = data.Synopsis,
                IdEditorial = data.IdEditorial,
                IdTypeState = data.IdTypeState,
                IdAuthor = data.IdAuthor,
            };

            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Token", token);

            ResponseDto resultToken = await _restService.PostRestServiceAsync<ResponseDto>(urlBase, controller, method, parameters, headers);

            return resultToken;
        }
        public async Task<ResponseDto> UpdateBooksAsync(BooksDto data, string token)
        {
            string urlBase = _config.GetSection("ApiMyLibrary").GetSection("UrlBase").Value;
            string controller = _config.GetSection("ApiMyLibrary").GetSection("ControlerBooks").Value;
            string method = _config.GetSection("ApiMyLibrary").GetSection("MethodUpdateBooks").Value;

            BooksDto parameters = new BooksDto()
            {   
                Id = data.Id, 
                Title = data.Title,
                Gender = data.Gender,
                Pages = data.Pages,
                Synopsis=data.Synopsis,
                IdEditorial = data.IdEditorial,
                IdTypeState = data.IdTypeState,
                IdAuthor=data.IdAuthor,
                
            };

            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Token", token);

            ResponseDto resultToken = await _restService.PutRestServiceAsync<ResponseDto>(urlBase, controller, method, parameters, headers);

            return resultToken;
        }
        public async Task<ResponseDto> DeleteBooksAsync(string token, string idBook)
        {
            string urlBase = _config.GetSection("ApiMyLibrary").GetSection("UrlBase").Value;
            string controller = _config.GetSection("ApiMyLibrary").GetSection("ControlerBooks").Value;
            string method = _config.GetSection("ApiMyLibrary").GetSection("MethodDeleteBooks").Value;
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("id", idBook);
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Token", token);

            ResponseDto resultToken = await _restService.DeleteRestServiceAsync<ResponseDto>(urlBase, controller, method, parameters, headers);

            return resultToken;
        }
        #endregion
    }
}
