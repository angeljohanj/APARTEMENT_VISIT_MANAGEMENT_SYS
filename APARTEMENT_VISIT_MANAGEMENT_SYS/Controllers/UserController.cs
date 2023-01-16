using Microsoft.AspNetCore.Mvc;
using APARTEMENT_VISIT_MANAGEMENT_SYS.Data;
using System.Data.SqlClient;
using System.Data;
using APARTEMENT_VISIT_MANAGEMENT_SYS.Models;

namespace APARTEMENT_VISIT_MANAGEMENT_SYS.Controllers
{
    public class UserController : Controller
    {
        private UserData _userData = new UserData();
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(UserModel oUser)
        {
            var user = _userData.Validate(oUser.Email, oUser.UserPassword);
            if (user != null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }
    }
}
