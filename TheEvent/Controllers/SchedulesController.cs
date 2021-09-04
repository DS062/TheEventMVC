using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TheEvent.Data;
using TheEvent.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System;

namespace TheEvent.Controllers
{
        public class SchedulesController : Controller
        {
            private readonly TheEventContext _context;

            public SchedulesController(TheEventContext context)
            {
                _context = context;
            }

            // GET: Schedules
            public async Task<IActionResult> Index()
            {
                
                    return View(await _context.Schedules.ToListAsync());
            }

        
            // GET: Schedules/Details/5
            public async Task<IActionResult> Details(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var Schedules = await _context.Schedules
                    .FirstOrDefaultAsync(m => m.Id == id);
                if (Schedules == null)
                {
                    return NotFound();
                }

                return View(Schedules);
            }

            // GET: Schedules/Create
            public IActionResult Create()
            {
                return View();
            }

            // POST: Schedules/Create
            // To protect from overposting attacks, enable the specific properties you want to bind to, for 
            // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Create([Bind("Id,Name,Schedule,Price")] Schedules Schedules)
            {
                if (ModelState.IsValid)
                {
                    _context.Add(Schedules);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(Schedules);
            }

            // GET: Schedules/Edit/5
            public async Task<IActionResult> Edit(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var Schedules = await _context.Schedules.FindAsync(id);
                if (Schedules == null)
                {
                    return NotFound();
                }
                return View(Schedules);
            }

            // POST: Schedules/Edit/5
            // To protect from overposting attacks, enable the specific properties you want to bind to, for 
            // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Schedule,Price")] Schedules Schedules)
            {
                if (id != Schedules.Id)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(Schedules);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!SchedulesExists(Schedules.Id))
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
                return View(Schedules);
            }

            // GET: Schedules/Delete/5
            public async Task<IActionResult> Delete(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var Schedules = await _context.Schedules
                    .FirstOrDefaultAsync(m => m.Id == id);
                if (Schedules == null)
                {
                    return NotFound();
                }

                return View(Schedules);
            }

            // POST: Schedules/Delete/5
            [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> DeleteConfirmed(int id)
            {
                var Schedules = await _context.Schedules.FindAsync(id);
                _context.Schedules.Remove(Schedules);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            private bool SchedulesExists(int id)
            {
                return _context.Schedules.Any(e => e.Id == id);
            }
        }
    }