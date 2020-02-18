using DutchTreat.Data;
using DutchTreat.Services;
using DutchTreat.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DutchTreat.Controllers
{
    public class AppController: Controller
    {
        private readonly IMailService mailService;
        private readonly IDutchRepository repoistory;

        public AppController(IMailService mailService, IDutchRepository repoistory)
        {
            this.mailService = mailService;
            this.repoistory = repoistory;
        }

        public IActionResult Index()
        {
            var results = repoistory.GetAllProducts();
            return View();
        }

        [HttpGet("contact")]
        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost("contact")]
        public IActionResult Contact(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                //send email
                mailService.SendMessage("e.keane10@gmail.com", model.Subject, $"From: {model.Name} - {model.Email}, Message: {model.Message}");
                ViewBag.UserMessage = "Mail Sent";
                ModelState.Clear();
            }
            else
            {
                //show errors
            }

            return View();
        }

        public IActionResult About()
        {
            ViewBag.Title = "About";
            return View();
        }

        public IActionResult Shop()
        {
            var results = repoistory.GetAllProducts();

            return View(results.ToList());
        }

    }
}
