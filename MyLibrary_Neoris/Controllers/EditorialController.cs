using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MiLibrary.Domain.Dto.EditorialDto;
using MiLibrary.Domain.Services.Interface;
using MyLibrary.Domain.Dto;
using MyLibrary_Neoris.Handlers;
using System;
using System.Linq;
using System.Threading.Tasks;
using static Common.Utils.Constant.Const;

namespace MyLibrary_Neoris.Controllers
{
    [Authorize]
    [TypeFilter(typeof(CustomExceptionHandler))]
    public class EditorialController : Controller
    {
        #region Attributes
        private readonly IEditorialServices _editorialServices;
        #endregion

        #region Builder
        public EditorialController(IEditorialServices editorialServices)
        {
            _editorialServices = editorialServices;
        }
        #endregion
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> GetAllEditorial()
        {
            var user = HttpContext.User;
            string token = user.Claims.FirstOrDefault(x => x.Type == TypeClaims.Token).Value;
            ResponseDto response = await _editorialServices.GetAllEditorial(token);
            return Ok(response);

        }
        [HttpPost]
        public async Task<IActionResult> InsertEditorial(InsertEditorialDto dates)
        {
            var user = HttpContext.User;
            string token = user.Claims.FirstOrDefault(x => x.Type == TypeClaims.Token).Value;

            ResponseDto response = await _editorialServices.InsertEditorialAsync(dates, token);
            return Ok(response);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateEditorial(EditorialDto dates)
        {
            var user = HttpContext.User;
            string token = user.Claims.FirstOrDefault(x => x.Type == TypeClaims.Token).Value;

            ResponseDto response = await _editorialServices.UpdateEditorialAsync(dates, token);
            return Ok(response);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteEditorial(int idEditorial)
        {
            var user = HttpContext.User;
            string token = user.Claims.FirstOrDefault(x => x.Type == TypeClaims.Token).Value;

            ResponseDto response = await _editorialServices.DeleteEditorialAsync(token, Convert.ToString(idEditorial));
            return Ok(response);
        }
    }
}
