using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MiLibrary.Domain.Dto.Authors;
using MiLibrary.Domain.Services.Interface;
using MyLibrary.Domain.Dto;
using MyLibrary_Neoris.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Common.Utils.Constant.Const;

namespace MyLibrary_Neoris.Controllers
{
    [Authorize]
    [TypeFilter(typeof(CustomExceptionHandler))]
    public class AuthorsController : Controller
    {
        #region Attributes
        private readonly IAuthorsServices _authorsServices;
        #endregion

        #region Builder
        public AuthorsController(IAuthorsServices authorsServices)
        {
            _authorsServices = authorsServices;
        }
        #endregion
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAuthors()
        {
            var user = HttpContext.User;
            string token =user.Claims.FirstOrDefault(x => x.Type == TypeClaims.Token).Value;
            ResponseDto response = await _authorsServices.GetAllAuthors(token);
            return Ok(response);

        }
        [HttpPost]
        public async Task<IActionResult> InsertAuthor(InsertAuthorsDto dates)
        {
            var user = HttpContext.User;
            string token = user.Claims.FirstOrDefault(x => x.Type == TypeClaims.Token).Value;

            ResponseDto response = await _authorsServices.InsertAuthorAsync(dates,token);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAuthor(AuthorsDto dates)
        {
            var user = HttpContext.User;
            string token = user.Claims.FirstOrDefault(x => x.Type == TypeClaims.Token).Value;

            ResponseDto response = await _authorsServices.UpdateAuthorAsync(dates, token);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAuthor(int idAuthor)
        {
            var user = HttpContext.User;
            string token = user.Claims.FirstOrDefault(x => x.Type == TypeClaims.Token).Value;

            ResponseDto response = await _authorsServices.DeleteAuthorAsync(token, Convert.ToString(idAuthor));
            return Ok(response);
        }
    }
}
