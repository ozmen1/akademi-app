using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BtkAkademi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BtkAkademi.Controllers
{
    public class CourseController : Controller
    {
        public IActionResult Index()
        {
            var model = Repository.Applications;
            return View(model);
        }
        public IActionResult Apply()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken] //tarayıcıdaki anti-theft doğrulama mekanizması
        public IActionResult Apply([FromForm] Candidate model) //modelin formdan geldiğini dikte ettik
        {
            if(Repository.Applications.Any(c => c.Email.Equals(model.Email)))
            {
                ModelState.AddModelError("", "There is already application for you.");
            }
            
            if(ModelState.IsValid)
            {
            Repository.Add(model);
            //return Redirect("/");
            return View("Feedback", model);
            }
            
            return View();
        }
    }
}