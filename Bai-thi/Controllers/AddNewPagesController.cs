using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Bai_thi.Entities;

namespace Bai_thi.Controllers
{
    public class AddNewPagesController : Controller
    {
        private readonly ThiDotNetContext _context;

        public AddNewPagesController(ThiDotNetContext context)
        {
            _context = context;
        }

        // GET: AddNewPages
        public async Task<IActionResult> Index()
        {
            var thiDotNetContext = _context.AddNewPages.Include(a => a.ClassRoom).Include(a => a.Faculties).Include(a => a.Subjects);
            return View(await thiDotNetContext.ToListAsync());
        }

        // GET: AddNewPages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AddNewPages == null)
            {
                return NotFound();
            }

            var addNewPage = await _context.AddNewPages
                .Include(a => a.ClassRoom)
                .Include(a => a.Faculties)
                .Include(a => a.Subjects)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (addNewPage == null)
            {
                return NotFound();
            }

            return View(addNewPage);
        }

        // GET: AddNewPages/Create
        public IActionResult Create()
        {
            ViewData["ClassRoomId"] = new SelectList(_context.ClassRooms, "Id", "Id");
            ViewData["FacultiesId"] = new SelectList(_context.Faculties, "Id", "Id");
            ViewData["SubjectsId"] = new SelectList(_context.Subjects, "Id", "Id");
            return View();
        }

        // POST: AddNewPages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,StartTime,ExamDate,ExamDuration,ClassRoomId,SubjectsId,FacultiesId,Status")] AddNewPage addNewPage)
        {
            if (ModelState.IsValid)
            {
                _context.Add(addNewPage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClassRoomId"] = new SelectList(_context.ClassRooms, "Id", "Id", addNewPage.ClassRoomId);
            ViewData["FacultiesId"] = new SelectList(_context.Faculties, "Id", "Id", addNewPage.FacultiesId);
            ViewData["SubjectsId"] = new SelectList(_context.Subjects, "Id", "Id", addNewPage.SubjectsId);
            return View(addNewPage);
        }

        // GET: AddNewPages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AddNewPages == null)
            {
                return NotFound();
            }

            var addNewPage = await _context.AddNewPages.FindAsync(id);
            if (addNewPage == null)
            {
                return NotFound();
            }
            ViewData["ClassRoomId"] = new SelectList(_context.ClassRooms, "Id", "Id", addNewPage.ClassRoomId);
            ViewData["FacultiesId"] = new SelectList(_context.Faculties, "Id", "Id", addNewPage.FacultiesId);
            ViewData["SubjectsId"] = new SelectList(_context.Subjects, "Id", "Id", addNewPage.SubjectsId);
            return View(addNewPage);
        }

        // POST: AddNewPages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,StartTime,ExamDate,ExamDuration,ClassRoomId,SubjectsId,FacultiesId,Status")] AddNewPage addNewPage)
        {
            if (id != addNewPage.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(addNewPage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AddNewPageExists(addNewPage.Id))
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
            ViewData["ClassRoomId"] = new SelectList(_context.ClassRooms, "Id", "Id", addNewPage.ClassRoomId);
            ViewData["FacultiesId"] = new SelectList(_context.Faculties, "Id", "Id", addNewPage.FacultiesId);
            ViewData["SubjectsId"] = new SelectList(_context.Subjects, "Id", "Id", addNewPage.SubjectsId);
            return View(addNewPage);
        }

        // GET: AddNewPages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AddNewPages == null)
            {
                return NotFound();
            }

            var addNewPage = await _context.AddNewPages
                .Include(a => a.ClassRoom)
                .Include(a => a.Faculties)
                .Include(a => a.Subjects)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (addNewPage == null)
            {
                return NotFound();
            }

            return View(addNewPage);
        }

        // POST: AddNewPages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AddNewPages == null)
            {
                return Problem("Entity set 'ThiDotNetContext.AddNewPages'  is null.");
            }
            var addNewPage = await _context.AddNewPages.FindAsync(id);
            if (addNewPage != null)
            {
                _context.AddNewPages.Remove(addNewPage);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AddNewPageExists(int id)
        {
          return (_context.AddNewPages?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
