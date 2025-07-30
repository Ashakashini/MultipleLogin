
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using MultipleLogin.DAL;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
namespace MultipleLogin.Controllers
{


    public class EmployeeController : Controller
    {
        private readonly EntityMultipleLoginDbContext _context;

        public EmployeeController(EntityMultipleLoginDbContext context)
        {
            _context = context;
        }
        public IActionResult LeaveApply()
        {
            var employeeList = _context.Employees
                .Select(e => new SelectListItem
                {
                    Value = e.Id.ToString(),
                    Text = e.FirstName + " " + e.LastName
                }).ToList();

            ViewBag.EmployeeList = employeeList;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult LeaveApply(LeaveApplyModel model)
        {
            if (ModelState.IsValid)
            {
                // Save to database (or any storage)
                // Example: _context.Leaves.Add(model); _context.SaveChanges();

                ViewBag.Message = "Leave request submitted successfully.";
                return RedirectToAction("LeaveList"); // or confirmation view
            }
            var employeeList = _context.Employees
        .Select(e => new SelectListItem
        {
            Value = e.Id.ToString(),
            Text = e.FirstName + " " + e.LastName
        }).ToList();

            ViewBag.EmployeeList = employeeList;

            return View(model);

           
        }

        public IActionResult LeaveList()
        {
            // Example: var leaves = _context.Leaves.ToList();
            return View(/*leaves*/);
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult EmployeeRegisteration1()
        {
            var completedSteps = new List<int>();
            var json = TempData["CompletedSteps"] as string;
            completedSteps = string.IsNullOrEmpty(json) ? new List<int>() : JsonSerializer.Deserialize<List<int>>(json);
            TempData.Keep("CompletedSteps");
            ViewBag.CompletedSteps = completedSteps;
            TempData.Keep("CompletedSteps");
            ViewBag.CompletedSteps = completedSteps;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EmployeeRegisteration1(EmployeeRegisterationModel model)
        {
            if (ModelState.IsValid)
            {
                var json = TempData["CompletedSteps"] as string;
                var completedSteps = string.IsNullOrEmpty(json)
                    ? new List<int>()
                    : JsonSerializer.Deserialize<List<int>>(json);

                if (!completedSteps.Contains(1)) completedSteps.Add(1);

                TempData["CompletedSteps"] = JsonSerializer.Serialize(completedSteps);
                TempData.Keep("CompletedSteps");

                return RedirectToAction("EmployeeRegisteration2");
            }
            foreach (var key in ModelState.Keys)
            {
                var state = ModelState[key];
                foreach (var error in state.Errors)
                {
                    Console.WriteLine($"Validation error in '{key}': {error.ErrorMessage}");
                }
            }


            return View(model);
        }



        public IActionResult EmployeeRegisteration2()
        {
            //List<int> completedSteps = new List<int>();

            //if (TempData["CompletedSteps"] != null)
            //{
            //    completedSteps = JsonConvert.DeserializeObject<List<int>>(TempData["CompletedSteps"].ToString());
            //    ViewBag.CompletedSteps = completedSteps;
            //}

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EmployeeRegisteration2(EmployeeRegisterationModel model)
        {
            if (ModelState.IsValid)
            {
                var json = TempData["CompletedSteps"] as string;
                var completedSteps = string.IsNullOrEmpty(json) ? new List<int>() : JsonSerializer.Deserialize<List<int>>(json);

                if (!completedSteps.Contains(2)) completedSteps.Add(2);
                TempData["CompletedSteps"] = JsonSerializer.Serialize(completedSteps);
                TempData["Step2Success"] = "Step 2 completed successfully! Redirecting to Step 3...";

                return RedirectToAction("EmployeeRegisteration3");
            }

            return View(model);
        }





        public IActionResult EmployeeRegisteration3()
        {
            var json = TempData["CompletedSteps"] as string;
            var completedSteps = string.IsNullOrEmpty(json)
                ? new List<int>()
                : JsonSerializer.Deserialize<List<int>>(json);

            if (!completedSteps.Contains(3)) completedSteps.Add(3);

            TempData["CompletedSteps"] = JsonSerializer.Serialize(completedSteps);
            TempData.Keep("CompletedSteps");
            ViewBag.CompletedSteps = completedSteps;

            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EmployeeRegisteration3(EmployeeRegisterationModel model)
        {
            if (ModelState.IsValid)
            {
                // Ensure 'wwwroot/uploads' exists
                string uploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads");
                if (!Directory.Exists(uploadFolder))
                    Directory.CreateDirectory(uploadFolder);

                
                if (model.Avathar != null)
                {
                    var fileName = Path.GetFileName(model.Avathar.FileName);
                    var filePath = Path.Combine(uploadFolder, fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await model.Avathar.CopyToAsync(stream);
                    }
                    model.AvatarFileName = fileName;
                }

                
                if (model.Resume != null)
                {
                    var fileName = Path.GetFileName(model.Resume.FileName);
                    var filePath = Path.Combine(uploadFolder, fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await model.Resume.CopyToAsync(stream);
                    }
                    model.ResumeFileName = fileName;
                }

                
                if (model.EducationalCertificate != null)
                {
                    var fileName = Path.GetFileName(model.EducationalCertificate.FileName);
                    var filePath = Path.Combine(uploadFolder, fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await model.EducationalCertificate.CopyToAsync(stream);
                    }
                    model.EducationalCertificateFileName = fileName;
                }

                
                if (model.IDProof != null)
                {
                    var fileName = Path.GetFileName(model.IDProof.FileName);
                    var filePath = Path.Combine(uploadFolder, fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await model.IDProof.CopyToAsync(stream);
                    }
                    model.IDProofFileName = fileName;
                }

                
                try
                {
                    _context.Employees.Add(model);
                    await _context.SaveChangesAsync();

                    TempData["Success"] = "Registration complete!";
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("DB Save Error: " + ex.Message);
                    ModelState.AddModelError("", "An error occurred while saving. Please try again.");
                }
            }

            
            foreach (var key in ModelState.Keys)
            {
                foreach (var error in ModelState[key].Errors)
                {
                    Console.WriteLine($"Validation error on {key}: {error.ErrorMessage}");
                }
            }

            return View(model);
        }


        public IActionResult LeaveStats()
        {
            var stats = new
            {
                Daily = new { Applied = 12, Approved = 8, Rejected = 2, Pending = 2 },
                Weekly = new { Applied = 45, Approved = 35, Rejected = 5, Pending = 5 },
                Monthly = new { Applied = 100, Approved = 90, Rejected = 10, Pending = 5 }
            };

            return View(stats);
        }
    }
}

