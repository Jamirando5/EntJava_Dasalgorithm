using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using MyWebApplication.Models.EntityManager;
using MyWebApplication.Models.ViewModel;
using MyWebApplication.Security;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

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

        public ActionResult samplesearch()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
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

        [HttpPost]
        public ActionResult CreateList(VerListModel list)
        {
            if (ModelState.IsValid)
            {
                VerListManager um = new VerListManager();
                um.AddList(list);
                // FormsAuthentication.SetAuthCookie(user.FirstName, false);
                return RedirectToAction("Profile", "Vervoyage");
            }
            return View();
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] VerListModel listData)
        {
            VerListManager um = new VerListManager();
            um.UpdateList(listData);
            return RedirectToAction("Profile", "Vervoyage");
        }

        [HttpPost]
        public ActionResult LogIn(VerUserLoginModel ulm)
        {
            if (ModelState.IsValid)
            {
                VerUserManager um = new VerUserManager();

                if (string.IsNullOrEmpty(ulm.Password))
                {
                    ModelState.AddModelError("", "The user login or password provided is incorrect.");
                }
                else
                {
                    if (um.GetUserPassword(ulm.Email).Equals(ulm.Password))
                    {
                        var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Name, ulm.Email)
                        };

                        var userIdentity = new ClaimsIdentity(claims, "login");

                        ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);

                        // Sign in the user using Cookie Authentication
                        HttpContext.SignInAsync(principal);

                        // Redirect to the desired action (e.g., "VerUsers")
                        return RedirectToAction("VerUsers");
                    }
                    else
                    {
                        ModelState.AddModelError("", "The password provided is incorrect.");
                    }
                }
            }

            // If authentication fails or ModelState is invalid, redisplay the login form
            return View();
        }
    }
}
