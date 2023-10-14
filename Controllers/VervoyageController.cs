using Microsoft.AspNetCore.Mvc;
using MyWebApplication.Models.EntityManager;
using MyWebApplication.Models.ViewModel;

namespace MyWebApplication.Controllers
{
    public class VervoyageController : Controller
    {
        public ActionResult Register()
        {
            return View();
        }

        public ActionResult VerUsers()
        {
            VerUserManager um = new VerUserManager();
            VerUsersModel user = um.GetAllUsers();

            return View(user);
        }

        [HttpPost]
        public ActionResult Register(VerUserModel user)
        {
            if (ModelState.IsValid)
            {
                VerUserManager um = new VerUserManager();
                um.VerUserAccount(user);
                // FormsAuthentication.SetAuthCookie(user.FirstName, false);
                return RedirectToAction("", "Home");
            }
            return View();
        }


    }
}

