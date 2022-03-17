using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyLibrary.Domain.Dto;
using MyLibrary.Domain.Services.Interface;
using MyLibrary_Neoris.Handlers;
using System.Linq;
using System.Threading.Tasks;
using static Common.Utils.Constant.Const;

namespace MyLibrary_Neoris.Controllers
{
    [Authorize]
    [TypeFilter(typeof(CustomExceptionHandler))]
    public class UserController : Controller
    {
        #region Attribute
        private readonly IUserServices _userServices;
        //private readonly IRolServices _rolServices;
        #endregion

        #region Builder
        public UserController(IUserServices userServices)
        {
            _userServices = userServices;
            //_rolServices = rolServices;
        }
        #endregion
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var user = HttpContext.User;
            string token = user.Claims.FirstOrDefault(x => x.Type == TypeClaims.Token).Value;
            ResponseDto response = await _userServices.GetAllUsers(token);
            return Ok(response);

        }
    }
}
