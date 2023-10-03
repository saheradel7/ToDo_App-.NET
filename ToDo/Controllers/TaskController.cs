using Microsoft.AspNetCore.Mvc;
using ToDo.Models;

namespace ToDo.Controllers
{

    public class TaskController : Controller
    {
        ToDoEntity context = new ToDoEntity();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreatTask(string TaskText)
        {
            int userId = HttpContext.Session.GetInt32("UserId").Value;

            if (TaskText != null)
            {
                ToDo.Models.Task task = new ToDo.Models.Task();
                task.UserId = userId;
                task.TaskText = TaskText;
                context.Tasks.Add(task);
                context.SaveChanges();
                return RedirectToAction("Home", "User");
            }
            return View("CreatTask");
        }








        [HttpPost]
        public IActionResult DeleteTask(int taskId)
        {
            var task = context.Tasks.Find(taskId);
            if (task != null)
            {
                context.Tasks.Remove(task);
                context.SaveChanges();
                return Json(new { success = true });
            }

            return View("home");
        }



    }
}
