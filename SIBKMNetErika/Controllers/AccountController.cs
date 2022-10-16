using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SIBKMNetErika.Repositories.Data;
using SIBKMNetErika.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIBKMNetErika.Controllers
{
    public class AccountController : Controller
    {
        AccountRepository accountRepository;

        public AccountController(AccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }

        public IActionResult Login()
        {
            return View();
        }
        // Register
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(Register register)
        {
            var data = accountRepository.Register(register);
            if (data > 0)
            {
                return RedirectToAction("Login", "Account");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Login(Login login)
        {
            if (ModelState.IsValid)
            {
                //statement mengambil data dari database sesuai dengan email dan password
                //return Id employee, FullName, Email, Role -> Masukkan ke ViewModels
                var data = accountRepository.Login(login);

                if (data != null)
                {
                    //inisialisasi nilai pada session
                    HttpContext.Session.SetString("Role", data.Role);
                    return RedirectToAction("Index", "Province");
                }
                return RedirectToAction("Unauthorized", "ErrorPage");
            }
            return View();
        }
        // Change Password
        // Forgot Password
    }
}
