using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GregNetGenProject.Controllers
{
    public class RoleController : Controller
    {
        //[Authorize()]
        public IActionResult Index()
        {
            return View();
        }
    }
}
