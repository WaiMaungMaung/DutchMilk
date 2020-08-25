using DutchMilk.Data;
using DutchMilk.Models;
using DutchMilk.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Linq;

namespace DutchMilk.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMailService _mailService;
        private readonly IDutchRepository _repository;
        

        public HomeController(ILogger<HomeController> logger,IMailService mailService ,IDutchRepository repository )
        {
            _logger = logger;
            _mailService = mailService;
           _repository = repository;
            
        }

        public IActionResult Index()
        {
            
            return View();
        }

        public IActionResult Privacy()
        {
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
                _mailService.SendMessage("mgwaimaungmaung@gmail.com", model.Subject, $"From:{model.Email}Subjcet:{model.Subject} MEssage :{model.Message}");
                ViewBag.UserMessage = "Message Sent";
                ModelState.Clear();
            }
            
            return View();
        }

        public IActionResult Shop()
        {
            var results = _repository.GetAllProducts();
                return View(results.ToList());

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
