using Microsoft.AspNetCore.Mvc;
using Task_MVC.Data;
using Task_MVC.Models;

namespace Task_MVC.Controllers
{
    public class UsersController : Controller
    {
        private readonly ApplicationDbContext context;

        public UsersController(ApplicationDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

		public IActionResult Register()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Register(User user)
		{
            
			context.Users.Add(user);
			context.SaveChanges();
			return RedirectToAction(nameof(LogIn));

		}

		public IActionResult LogIn()
		{
			return View();
		}
		[HttpPost]
		public IActionResult LogIn(User user)
		{
			var checkUser = context.Users.Where(x => x.UserName == user.UserName && x.Password == user.Password);
            if (user != null)
            {
                if (user.IsActive)
                {
                    return RedirectToAction("Dashboard");
                }
                else
                {
                    ViewBag.Message = "Account is inactive.";
                }
            }
            else
            {
                ViewBag.Message = "Invalid credentials.";
            }
            return View(user);
        }
		

        public IActionResult InactiveUsers()
        {
            var inactiveUsers =context.Users.Where(u => !u.IsActive).ToList();
            return View(inactiveUsers);
        }

        public IActionResult ActivateUser(int id)
        {
            var user = context.Users.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                user.IsActive = true;
            }
            return RedirectToAction("InactiveUsers");
        }




    }
}
