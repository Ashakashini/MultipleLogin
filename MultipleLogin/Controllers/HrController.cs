using Microsoft.AspNetCore.Mvc;
using MultipleLogin.DAL;

namespace MultipleLogin.Controllers
{
    public class HrController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult HrRegisteration()
        {
             return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult HrRegisteration(HrRegisterationModel model)
        {
            return View();
        }
    }
}
