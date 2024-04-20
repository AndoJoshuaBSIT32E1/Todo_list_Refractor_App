using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Todo_list_Refractor_App.Data;
using Todo_list_Refractor_App.Models;

namespace Todo_list_Refractor_App.Controllers
{
    public class TodolistAppsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TodolistAppsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TodolistApps
        public async Task<IActionResult> Index()
        {
            return View(await _context.Todolist.ToListAsync());
        }

        // GET: TodolistApps/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var todolistApp = await _context.Todolist
                .FirstOrDefaultAsync(m => m.Id == id);
            if (todolistApp == null)
            {
                return NotFound();
            }

            return View(todolistApp);
        }

        // GET: TodolistApps/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TodolistApps/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,TableReady,Description")] TodolistApp todolistApp)
        {
            if (ModelState.IsValid)
            {
                _context.Add(todolistApp);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(todolistApp);
        }

        // GET: TodolistApps/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var todolistApp = await _context.Todolist.FindAsync(id);
            if (todolistApp == null)
            {
                return NotFound();
            }
            return View(todolistApp);
        }

        // POST: TodolistApps/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,TableReady,Description")] TodolistApp todolistApp)
        {
            if (id != todolistApp.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(todolistApp);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TodolistAppExists(todolistApp.Id))
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
            return View(todolistApp);
        }

        // GET: TodolistApps/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var todolistApp = await _context.Todolist
                .FirstOrDefaultAsync(m => m.Id == id);
            if (todolistApp == null)
            {
                return NotFound();
            }

            return View(todolistApp);
        }

        // POST: TodolistApps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var todolistApp = await _context.Todolist.FindAsync(id);
            if (todolistApp != null)
            {
                _context.Todolist.Remove(todolistApp);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TodolistAppExists(int id)
        {
            return _context.Todolist.Any(e => e.Id == id);
        }
    }
}
