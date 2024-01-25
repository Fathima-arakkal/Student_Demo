using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Student_Demo.Context;
using Student_Demo.Models;
using Microsoft.EntityFrameworkCore;

public class StudentsController : Controller
{
    private readonly ApplicationDbContext _context;

    public StudentsController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: Students
    public async Task<IActionResult> Index()
    {
        var students = await _context.Students.Include(s => s.Department).ToListAsync();
        return View(students);
    }

    // GET: Students/Details/5
    public async Task<IActionResult> Details(Guid? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var student = await _context.Students
            .Include(s => s.Department)
            .FirstOrDefaultAsync(m => m.StudentId == id);

        if (student == null)
        {
            return NotFound();
        }

        return View(student);
    }

    // GET: Students/Create
    public IActionResult Create()
    {
        var departments = _context.Departments.ToList();
        ViewBag.DepartmentId = new SelectList(departments, "DepartmentId", "DepartmentId");
        return PartialView("_Create", new Student
        {
            Name = "",
            Age = 0,
            Gender = Gender.Male, // Assuming you have a Gender enum
            Division = 0,
            DepartmentId = Guid.Empty,
            Department = new Department
            {
                Name = "",
                Location = new Location
                {
                    Name = "",
                    Students = new List<Student>()
                },
                Students = new List<Student>()
            }
        });
    }

    // POST: Students/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("StudentId,Name,Age,Gender,Division,DepartmentId")] Student student)
    {
        
            student.StudentId = Guid.NewGuid();
            _context.Add(student);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        

        ViewData["DepartmentId"] = new SelectList(_context.Departments, "DepartmentId", "DepartmentId", student.DepartmentId);
        return PartialView("_Create", student);
    }


    // GET: Students/Edit/5
    public async Task<IActionResult> Edit(Guid? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var student = await _context.Students.FindAsync(id);
        if (student == null)
        {
            return NotFound();
        }

        ViewData["DepartmentId"] = new SelectList(_context.Departments, "DepartmentId", "DepartmentId", student.DepartmentId);
        return View(student);
    }

    // POST: Students/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Guid id, [Bind("StudentId,Name,Age,Gender,Division,DepartmentId")] Student student)
    {
        if (id != student.StudentId)
        {
            return NotFound();
        }

        try
        {
            _context.Update(student);
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!StudentExists(student.StudentId))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }
        return RedirectToAction(nameof(Index));


        ViewData["DepartmentId"] = new SelectList(_context.Departments, "DepartmentId", "DepartmentId", student.DepartmentId);
        return View(student);
    }

    // GET: Students/Delete/5
    public async Task<IActionResult> Delete(Guid? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var student = await _context.Students
            .Include(s => s.Department)
            .FirstOrDefaultAsync(m => m.StudentId == id);

        if (student == null)
        {
            return NotFound();
        }

        return View(student);
    }

    // POST: Students/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(Guid id)
    {
        var student = await _context.Students.FindAsync(id);
        if (student != null)
        {
            _context.Students.Remove(student);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }


    private bool StudentExists(Guid id)
    {
        return _context.Students.Any(e => e.StudentId == id);
    }
}
