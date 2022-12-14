using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GregNetGenProject.Controllers
{
    public class RoleController : Controller
    {
        [Authorize(Policy = "EmployeeOnly")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
