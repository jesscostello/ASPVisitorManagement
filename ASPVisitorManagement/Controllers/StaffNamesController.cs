using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASPVisitorManagement.Data;
using ASPVisitorManagement.Models;

namespace ASPVisitorManagement.Controllers
{
    public class StaffNamesController : Controller
    {
        private readonly VisitorDbContext _context;

        // Dependency injection
        public StaffNamesController(VisitorDbContext context)
        {
            _context = context;
        }

        // GET: StaffNames
        public async Task<IActionResult> Index()
        {
            var StaffNamesMethod = _context.StaffNames.Where(s => s.Name == "Gary Dix").OrderByDescending(s => s.VisitorCount).ToListAsync();

            var StaffNamesQuery = 
                (from s in _context.StaffNames
                where s.Name == "Gary Dix"
                orderby s.VisitorCount descending 
                select s).ToListAsync();

            var shortest = _context.StaffNames.Min(s => s.Name.Length);
            
            //var staff = await _context.StaffNames.ToListAsync();
            int counter = 0;
            //foreach (var eachperson in staff)
            //{
            //    if (eachperson.Id == 1)
            //    {
            //        eachperson.Name += " not our staff";
            //    }

            //    counter++;
            //}

            ViewBag.StaffTitle = "All Staff";
            ViewBag.StaffCount = counter;
            //return View(staff);

            //return View(await StaffNamesMethod);
            return View(await StaffNamesQuery);

            // same as...
            //ViewBag.StaffTitle = "All Staff";
            //return View(await _context.StaffNames.ToListAsync());
        }

        // GET: StaffNames/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staffNames = await _context.StaffNames
                .FirstOrDefaultAsync(m => m.Id == id);
            if (staffNames == null)
            {
                return NotFound();
            }

            return View(staffNames);
        }

        // GET: StaffNames/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StaffNames/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Department,VisitorCount")] StaffNames staffNames)
        {
            if (ModelState.IsValid)
            {
                _context.Add(staffNames);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(staffNames);
        }

        // GET: StaffNames/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staffNames = await _context.StaffNames.FindAsync(id);
            if (staffNames == null)
            {
                return NotFound();
            }
            return View(staffNames);
        }

        // POST: StaffNames/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Department,VisitorCount")] StaffNames staffNames)
        {
            if (id != staffNames.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(staffNames);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StaffNamesExists(staffNames.Id))
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
            return View(staffNames);
        }

        // GET: StaffNames/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staffNames = await _context.StaffNames
                .FirstOrDefaultAsync(m => m.Id == id);
            if (staffNames == null)
            {
                return NotFound();
            }

            return View(staffNames);
        }

        // POST: StaffNames/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var staffNames = await _context.StaffNames.FindAsync(id);
            _context.StaffNames.Remove(staffNames);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StaffNamesExists(int id)
        {
            return _context.StaffNames.Any(e => e.Id == id);
        }
    }
}
