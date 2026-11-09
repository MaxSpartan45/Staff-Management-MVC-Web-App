using EHA_Assessment.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace EHA_Assessment.Controllers
{
    public class AccessController : Controller
    {
        private readonly SystemAdmin AdminCredentials = new()
        {
            // Sample credentials
            Username = "admin",
            Password = "12345"
        };

        //GET: Access/Login
        [HttpGet]
        public IActionResult Login()
        {
            // Redirect if user is already authenticated
            if (HttpContext.Session.GetString("Username") != null)
            {
                return RedirectToAction("Privacy", "Home");
            }

            return View();
        }

        //POST: Access/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(SystemAdmin model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // Check if username and password are provided
            if (string.IsNullOrWhiteSpace(model.Username) || string.IsNullOrWhiteSpace(model.Password))
            {
                ModelState.AddModelError("", "Username and password required.");
                return View(model);
            }

            // Check if the provided credentials match the admin credentials
            if (model.Username == AdminCredentials.Username && model.Password == AdminCredentials.Password)
            {
                // Store authentication state in session
                HttpContext.Session.SetString("Username", model.Username);

                return RedirectToAction("Index", "Staff");
            }

            ModelState.AddModelError("", "Incorrect username or password.");
            return View(model);
        }

        // GET: /Access/Logout
        [HttpGet]
        public IActionResult Logout()
        {
            // Remove the administrator's session.
            HttpContext.Session.Clear();

            return RedirectToAction("Login", "Access");
        }
    }
}