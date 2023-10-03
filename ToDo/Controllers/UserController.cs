using Microsoft.AspNetCore.Mvc;
using ToDo.Models;

namespace ToDo.Controllers
{
    public class UserController : Controller
    {
        ToDoEntity context  = new ToDoEntity();
        public IActionResult Index()
        {
            return View("Index");
        }

        public IActionResult Registration(User user)
        {
            if (user.Name != null && user.Email != null && user.Password != null)
            {
                context.Users.Add(user);
                context.SaveChanges();
                return RedirectToAction("Login");
            }
            return View("Registration");
        }


        public IActionResult Login(string email , string password)
        {
            var user  = context.Users.FirstOrDefault(x =>  x.Email == email && x.Password == password);
            if (user != null) 
            {
                HttpContext.Session.SetInt32("UserId", user.Id);
                return RedirectToAction("Home");
            }
            return View("Login");
        }
        public IActionResult Home()
        {
            int? userId = HttpContext.Session.GetInt32("UserId");
            if (userId.HasValue)
            {
                var tasks = context.Tasks.Where(x => x.UserId == userId).ToList();
                ViewBag.Tasks = tasks;
                return View("Home");

            }
            else
            {
                return RedirectToAction("Login");
            }

        }
        
        
      

        

        


    }
}
