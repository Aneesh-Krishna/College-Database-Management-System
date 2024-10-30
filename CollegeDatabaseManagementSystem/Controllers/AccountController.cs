using Microsoft.AspNetCore.Mvc;

namespace CollegeDatabaseManagementSystem.Controllers
{
    public class AccountController : Controller
    {
        // Action to handle access denied redirection
        [Route("Account/AccessDenied")]
        public IActionResult AccessDenied()
        {
            TempData["ErrorMessage"] = "You're unauthorized to access this page.";

            if(!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
