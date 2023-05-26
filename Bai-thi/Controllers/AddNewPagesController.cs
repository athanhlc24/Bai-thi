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

      

        // GET: AddNewPages/Create
        public IActionResult Create()
        {
            ViewData["ClassRoomId"] = new SelectList(_context.ClassRooms, "Id", "Id");
            ViewData["FacultiesId"] = new SelectList(_context.Faculties, "Id", "Id");
            ViewData["SubjectsId"] = new SelectList(_context.Subjects, "Id", "Id");
            return View();
        }

        // POST: AddNewPages/Create
      
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
    }
}
