using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyLibrary.Domain.Dto;
using MyLibrary.Domain.Dto.Books;
using MyLibrary.Domain.Services.Interface;
using MyLibrary_Neoris.Handlers;
using System;
using System.Linq;
using System.Threading.Tasks;
using static Common.Utils.Constant.Const;

namespace MyLibrary_Neoris.Controllers
{
    [Authorize]
    [TypeFilter(typeof(CustomExceptionHandler))]
    public class BooksController : Controller
    {
        #region Attributes
        private readonly IBooksServices _booksServices;
        #endregion
        #region Builder
        public BooksController(IBooksServices booksServices)
        {
            _booksServices = booksServices;
        }
        #endregion
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            var user = HttpContext.User;
            string token = user.Claims.FirstOrDefault(x => x.Type == TypeClaims.Token).Value;
            ResponseDto response = await _booksServices.GetAllBooks(token);
            return Ok(response);

        }
        [HttpGet]
        public async Task<IActionResult> GetAllTypeState()
        {
            var user = HttpContext.User;
            string token = user.Claims.FirstOrDefault(x => x.Type == TypeClaims.Token).Value;
            ResponseDto response = await _booksServices.GetAllTypeState(token);
            return Ok(response);

        }
        [HttpPost]
        public async Task<IActionResult> InsertBooks(InsertBooksDto dates)
        {
            var user = HttpContext.User;
            string token = user.Claims.FirstOrDefault(x => x.Type == TypeClaims.Token).Value;

            ResponseDto response = await _booksServices.InsertBooksAsync(dates, token);
            return Ok(response);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateBooks(BooksDto dates)
        {
            var user = HttpContext.User;
            string token = user.Claims.FirstOrDefault(x => x.Type == TypeClaims.Token).Value;

            ResponseDto response = await _booksServices.UpdateBooksAsync(dates, token);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBooks(int idBook)
        {
            var user = HttpContext.User;
            string token = user.Claims.FirstOrDefault(x => x.Type == TypeClaims.Token).Value;

            ResponseDto response = await _booksServices.DeleteBooksAsync(token, Convert.ToString(idBook));
            return Ok(response);
        }
    }
}
