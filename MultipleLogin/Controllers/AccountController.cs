using Microsoft.AspNetCore.Identity;

using Microsoft.AspNetCore.Mvc;
using MultipleLogin.DAL.Models; // Make sure this matches your actual namespace
using System.Linq;
using System.Threading.Tasks;

namespace MultipleLogin.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public AccountController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Login() => View();

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid) 
            {
                return View(model);
            }
                

            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user != null)
            {
                
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
              
                if (result.Succeeded)
                {
                    var roles = await _userManager.GetRolesAsync(user);

                    // Redirect based on role
                    var redirectAction = roles switch
                    {
                        var r when r.Contains("Admin") => "AdminDashboard",
                        var r when r.Contains("HR") => "HrDashboard",
                        var r when r.Contains("Employee") => "EmployeeDashboard",
                        _ => null
                    };

                    if (redirectAction != null)
                        return RedirectToAction("AdminDashboard","Home");
                }
            }

            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
