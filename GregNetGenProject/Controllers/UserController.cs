using GregNetGenProject.Areas.Identity.Data;
using GregNetGenProject.Core.Repositories;
using GregNetGenProject.Core.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

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


        /*
        private readonly GregNetGenProjectDBContext _context;

        public UserController(GregNetGenProjectDBContext context)
        {
            _context = context;
        }*/

        [Authorize(Roles = "Admin")]
        //------------------------------------------------------------------------------//
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()//string searchString)
        {
            var users = _unitOfWork.User.GetUsers();

            /*
            ViewData["CurrentFilter"] = searchString;

            var searchUsers = from s in _context.Users
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                searchUsers = searchUsers.Where(s => s.EmailAddress.Contains(searchString) || s.FirstName.Contains(searchString));
            }*/


            return View(users);
        }

        [Authorize(Roles = "Admin")]
        //------------------------------------------------------------------------------//
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IActionResult Edit(string id)
        {
            var user = _unitOfWork.User.GetUser(id);
            var roles = _unitOfWork.Role.GetRoles();

            var vm = new EditUserViewModel
            {
                User = user,
                Roles = roles
            };

            return View(vm);
        }
    }
}
//-------------------------------ooo000 END OF FILE 000ooo-------------------------------//