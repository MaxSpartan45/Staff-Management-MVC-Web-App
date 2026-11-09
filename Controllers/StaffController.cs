using EHA_Assessment.Models;
using Microsoft.AspNetCore.Mvc;

namespace EHA_Assessment.Controllers
{
    public class StaffController : Controller
    {
        private StaffService _staffService;

        public StaffController(StaffService staffService)
        {
            _staffService = staffService;
        }

        // GET: Staff/Index (Display All)
        [HttpGet]
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("Username") == null)
            {
                return RedirectToAction("Login", "Access");
            }

            // Retrieve all staff members from the service
            List<StaffMember>? result = _staffService.RetrieveAllStaffMembers();

            return View(result);
        }


        // GET Staff/Search
        [HttpGet]
        public IActionResult Search()
        {
            if (HttpContext.Session.GetString("Username") == null)
            {
                return RedirectToAction("Login", "Access");
            }

            return View();
        }

        // POST: Staff/Search (Display Specific)
        [HttpPost]
        public IActionResult Search(int staffId)
        {
            if (HttpContext.Session.GetString("Username") == null)
            {
                return RedirectToAction("Login", "Access");
            }

            // Retrieve the staff member based on the provided StaffId
            StaffMember? member = _staffService.RetrieveStaffMember(staffId);

            // If the member is not found, add a model error and return the view with the model
            if (member == null)
            {
                ModelState.AddModelError("", "Invalid staff ID.");
                return View(member);
            }

            return View(member);
        }


        // GET: Staff/Create
        [HttpGet]
        public IActionResult Create()
        {
            if (HttpContext.Session.GetString("Username") == null)
            {
                return RedirectToAction("Login", "Access");
            }

            return View();
        }

        // POST: Staff/Create
        [HttpPost]
        public IActionResult Create(StaffMember model)
        {
            if (HttpContext.Session.GetString("Username") == null)
            {
                return RedirectToAction("Login", "Access");
            }

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Please fill in all fields.");
                return View(model);
            }

            // Add the new staff member using the service
            _staffService.AddStaffMember(model.FullName, model.Email, model.Position, model.Unit);

            return RedirectToAction("Index", "Staff");
        }


        // GET: Staff/Edit
        [HttpGet]
        public IActionResult Edit(int staffId)
        {
            if (HttpContext.Session.GetString("Username") == null)
            {
                return RedirectToAction("Login", "Access");
            }

            // Retrieve the staff member based on the provided StaffId
            StaffMember? member = _staffService.RetrieveStaffMember(staffId);

            return View(member);
        }

        // POST: Staff/Edit
        [HttpPost]
        public IActionResult Edit(int staffId, string fullName, string email, string position, string unit)
        {
            if (HttpContext.Session.GetString("Username") == null)
            {
                return RedirectToAction("Login", "Access");
            }

            // Update the staff member using the service
            bool isUpdated = _staffService.UpdateStaffMember(staffId, fullName, email, position, unit);

            // If the update was not successful, return the view with a model error
            if (!isUpdated)
            {
                ModelState.AddModelError("", "Staff member not found.");
                return View(_staffService.RetrieveStaffMember(staffId));
            }

            return View("Index", _staffService.RetrieveAllStaffMembers());
        }


        // POST: Staff/Delete
        [HttpPost]
        public IActionResult Delete(int staffId)
        {
            if (HttpContext.Session.GetString("Username") == null)
            {
                return RedirectToAction("Login", "Access");
            }

            // Delete the staff member using the service
            bool isDeleted = _staffService.DeleteStaffMember(staffId);

            // If the deletion was not successful, return the view with a model error
            if (!isDeleted)
            {
                ModelState.AddModelError("", "Failed to delete staff member.");
                return View("Search", _staffService.RetrieveStaffMember(staffId));
            }

            return View("Index", _staffService.RetrieveAllStaffMembers());
        }


    }
}