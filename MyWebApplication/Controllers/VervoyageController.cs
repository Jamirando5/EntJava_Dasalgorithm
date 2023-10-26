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

        public ActionResult samplesearch()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Profile()
        {
            VerListManager um = new VerListManager();
            VerListsModel list = um.GetAllLists();

            return View(list);
        }

        public ActionResult CreateList()
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
                return RedirectToAction("Profile","Vervoyage");
        }

    }
}

