using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace university.Controllers
{
    public class StudentsController : Controller
    {
        private readonly MvcStudentContext _context;

        public StudentsController(MvcStudentContext context)
        {
            _context = context;
        }

        // GET: Students
        public async Task<IActionResult> Index()
        {
            return View(await _context.StudentModel.ToListAsync());
        }

        // GET: Students/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentModel = await _context.StudentModel
                .FirstOrDefaultAsync(m => m.ID == id);
            if (studentModel == null)
            {
                return NotFound();
            }

            return View(studentModel);
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,FirstName,Surname,TelephoneNo,email,countryOfOrigin")] StudentModel studentModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studentModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(studentModel);
        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentModel = await _context.StudentModel.FindAsync(id);
            if (studentModel == null)
            {
                return NotFound();
            }
            return View(studentModel);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,FirstName,Surname,TelephoneNo,email,countryOfOrigin")] StudentModel studentModel)
        {
            if (id != studentModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studentModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentModelExists(studentModel.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(studentModel);
        }

        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentModel = await _context.StudentModel
                .FirstOrDefaultAsync(m => m.ID == id);
            if (studentModel == null)
            {
                return NotFound();
            }

            return View(studentModel);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var studentModel = await _context.StudentModel.FindAsync(id);
            _context.StudentModel.Remove(studentModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentModelExists(int id)
        {
            return _context.StudentModel.Any(e => e.ID == id);
        }
    }
}
