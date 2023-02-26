using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using StaffManagement.Models;
using StaffManagement.ViewModel;
using System.Diagnostics;

namespace StaffManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IStaffRepository _staffRepository;

        public HomeController(
            IStaffRepository staffRepository,
            IWebHostEnvironment webHostEnvironment
            )
        {
            _webHostEnvironment = webHostEnvironment;
            _staffRepository = staffRepository;
        }

        public ViewResult Details(int? id)
        {
            HomeDetailsViewModel viewModel = new HomeDetailsViewModel()
            {
                Staff = _staffRepository.Get(id?? 1)
            };
            return View(viewModel);
        }

        public ViewResult Index()
        {
            HomeIndexViewModel homeIndexViewModel = new HomeIndexViewModel()
            {
                Staffs = _staffRepository.GetAll()
            };
            return View(homeIndexViewModel);
        }

        public ViewResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Create(HomeCreateViewModel staff)
        {
            if(ModelState.IsValid)
            {
                string uniqueFileName = string.Empty;
                if(staff.Photo != null)
                {
                    string uploadFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + staff.Photo.FileName;
                    string imageFilePath = Path.Combine(uploadFolder, uniqueFileName);
                    staff.Photo.CopyTo(new FileStream(imageFilePath,FileMode.Create));
                }

                Staff newStaff = new Staff()
                {
                    Name = staff.Name,
                    Department = staff.Department,
                    PhotoFilePath = uniqueFileName,
                };
                newStaff = _staffRepository.Create(newStaff);
                return RedirectToAction("Details", new { id = newStaff.Id });
            }
            return View();
        }
    }
}