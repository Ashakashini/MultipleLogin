using Microsoft.AspNetCore.Mvc;
using MultipleLogin.DAL;

public class EmployeeController : Controller
{
    private readonly EntityMultipleLoginDbContext _context;

    public EmployeeController(EntityMultipleLoginDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult EmployeeRegistration()
    {
        return View();
    }

    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> EmployeeRegistration(EmployeeRegisterationModel model)
    {
        if (ModelState.IsValid)
        {
            // Save avatar
            if (model.Avathar != null)
            {
                var avatarFileName = Guid.NewGuid().ToString() + Path.GetExtension(model.Avathar.FileName);
                var avatarPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads", avatarFileName);

                using (var stream = new FileStream(avatarPath, FileMode.Create))
                {
                    await model.Avathar.CopyToAsync(stream);
                }

                model.AvatarPath = avatarFileName;
            }

            // Save resume
            if (model.Resume != null)
            {
                var resumeFileName = Guid.NewGuid().ToString() + Path.GetExtension(model.Resume.FileName);
                var resumePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads", resumeFileName);

                using (var stream = new FileStream(resumePath, FileMode.Create))
                {
                    await model.Resume.CopyToAsync(stream);
                }

                model.ResumePath = resumeFileName;
            }

            // Save educational certificate
            if (model.EducationalCertificate != null)
            {
                var certFileName = Guid.NewGuid().ToString() + Path.GetExtension(model.EducationalCertificate.FileName);
                var certPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads", certFileName);

                using (var stream = new FileStream(certPath, FileMode.Create))
                {
                    await model.EducationalCertificate.CopyToAsync(stream);
                }

                model.EducationalCertificatePath = certFileName;
            }

            // Save ID proof
            if (model.IDProof != null)
            {
                var idFileName = Guid.NewGuid().ToString() + Path.GetExtension(model.IDProof.FileName);
                var idPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads", idFileName);

                using (var stream = new FileStream(idPath, FileMode.Create))
                {
                    await model.IDProof.CopyToAsync(stream);
                }

                model.IDProofPath = idFileName;
            }

            // Save to DB
            _context.Employees.Add(model);
            await _context.SaveChangesAsync();

            TempData["Success"] = "Registration successful!";
            return RedirectToAction("SuccessPage");
        }

        return View(model);
    }


    [HttpGet]
    public IActionResult EmployeeRegisterFinal()
    {
        return View();
    }
    public IActionResult SuccessPage()
    {
        return View();
    }
    public IActionResult ViewEmployees()
    {
        var employees = _context.Employees.ToList() ;
        return View(employees);
    }
}