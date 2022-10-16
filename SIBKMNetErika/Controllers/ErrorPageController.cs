using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIBKMNetErika.Controllers
{
    public class ErrorPageController : Controller
    {
        public IActionResult Unautorized()
        {
            return View();
        }
    }
}
