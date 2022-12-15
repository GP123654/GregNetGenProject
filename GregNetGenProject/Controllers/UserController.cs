using GregNetGenProject.Core.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GregNetGenProject.Controllers
{
    public class UserController : Controller
    {
        //
        private readonly IUnitOfWork _unitOfWork;

        //
        public UserController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //------------------------------------------------------------------------------//
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            var users = _unitOfWork.User.GetUsers();
            return View(users);
        }

        //------------------------------------------------------------------------------//
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IActionResult Edit()
        {
            return View();
        }
    }
}
//-------------------------------ooo000 END OF FILE 000ooo-------------------------------//