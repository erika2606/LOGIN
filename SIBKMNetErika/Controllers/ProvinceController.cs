using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SIBKMNetErika.Context;
using SIBKMNetErika.Models;
using SIBKMNetErika.Repositories.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIBKMNetErika.Controllers
{
    public class ProvinceController : Controller
    {
        ProvinceRepository ProvinceRepository;
        public ProvinceController(ProvinceRepository ProvinceRepository)
        {
            this.ProvinceRepository = ProvinceRepository;
        }
        public IActionResult Index()
        {
            string role = HttpContext.Session.GetString("Role");
            if (role.Equals("Admin"))
            {
                var data= ProvinceRepository.Get();
                return View(data);
            }
            return RedirectToAction("Unauthorized", "ErrorPage");

        }
        public IActionResult Details(int id)
        {
            var data = ProvinceRepository.Get(id);
            return View(data);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Province province)
        {
            if (ModelState.IsValid)
            {
                var result = ProvinceRepository.Post(province);
                if (result > 0)
                    return RedirectToAction("Index");
            }
            return View();
        }
        // Edit
        // GET
        public IActionResult Update(int id)
        {
            return View();
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, Province province)
        {
            if (ModelState.IsValid)
            {
                var result = ProvinceRepository.Put(id, province);
                if (result > 0)
                    return RedirectToAction("Index");
            }
            return View();
        }
        // Hapus
        // GET
        public IActionResult Delete(Province province)
        {
            if (ModelState.IsValid)
            {
                var result = ProvinceRepository.Delete(province);
                if (result > 0)
                    return RedirectToAction("Index");
            }
            return View();
        }
    }
}

