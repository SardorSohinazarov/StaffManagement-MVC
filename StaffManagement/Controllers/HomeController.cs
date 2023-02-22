using Microsoft.AspNetCore.Mvc;
using StaffManagement.Models;
using StaffManagement.ViewModel;
using System.Diagnostics;

namespace StaffManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IStaffRepository _staffRepository;

        public HomeController(
            ILogger<HomeController> logger,
            IStaffRepository staffRepository
            )
        {
            _logger = logger;
            _staffRepository = staffRepository;
        }

        public IActionResult Details(int? id)
        {
            HomeDetailsViewModel viewModel = new HomeDetailsViewModel()
            {
                Staff = _staffRepository.Get(id?? 1)
            };
            return View(viewModel);
        }

        public IActionResult Index()
        {
            HomeIndexViewModel homeIndexViewModel = new HomeIndexViewModel()
            {
                Staffs = _staffRepository.GetAll()
            };
            return View(homeIndexViewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        
        public IActionResult Sardor()
        {
            var staff1 = new Staff()
            {
                Id = 1,
                Name = "Sardor",
                Department = "Developer"
            };

            ViewBag.staff1 = staff1;    

            HomeDetailsViewModel viewModel = new HomeDetailsViewModel()
            {
                Staff = staff1,
                Title = "Staff Details"
            };

            return View(viewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}