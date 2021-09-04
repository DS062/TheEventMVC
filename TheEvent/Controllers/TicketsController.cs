using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TheEvent.Data;
using TheEvent.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace TheEvent.Controllers
{
        public class TicketsController : Controller
        {
            private readonly TheEventContext _context;

            public TicketsController(TheEventContext context)
            {
                _context = context;
            }

        // GET: Tickets
        public async Task<IActionResult> Index()
            {
               return View(await _context.Tickets.ToListAsync());               
            }

        // GET: Tickets/Details/5
        public async Task<IActionResult> Details(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var Tickets = await _context.Tickets
                    .FirstOrDefaultAsync(m => m.Id == id);
                if (Tickets == null)
                {
                    return NotFound();
                }

                return View(Tickets);
            }
        public IActionResult NameNotFound()
        {
            return View();
        }
        
        // GET: Tickets/Create
        public IActionResult Create()
            {
            var Schedules = _context.Schedules.ToList();
            if (Schedules.Count > 0)
            {
                Schedules.Insert(0, new Schedules { Id = 0, Name = "Select Schedules" });
                ViewBag.ListSchedules = Schedules;
                return View();
            }
            else
            {
                return RedirectToAction(nameof(NameNotFound));
            }
            }



        // POST: Tickets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Create([Bind("Id,Name,Age,Address,NumberOfTicket,ScheduleId")] Tickets Tickets)
            {
                if (ModelState.IsValid)
                {
                    _context.Add(Tickets);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(Tickets);
            }

        // GET: Tickets/Edit/5
        public async Task<IActionResult> Edit(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var Tickets = await _context.Tickets.FindAsync(id);
                if (Tickets == null)
                {
                    return NotFound();
                }
                return View(Tickets);
            }

        // POST: Tickets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Age,Address,NumberOfTicket,ScheduleId")] Tickets Tickets)
            {
                if (id != Tickets.Id)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(Tickets);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!TicketsExists(Tickets.Id))
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
                return View(Tickets);
            }

        // GET: Tickets/Delete/5
        public async Task<IActionResult> Delete(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var Tickets = await _context.Tickets
                    .FirstOrDefaultAsync(m => m.Id == id);
                if (Tickets == null)
                {
                    return NotFound();
                }

                return View(Tickets);
            }

        // POST: Tickets/Delete/5
        [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> DeleteConfirmed(int id)
            {
                var Tickets = await _context.Tickets.FindAsync(id);
                _context.Tickets.Remove(Tickets);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            private bool TicketsExists(int id)
            {
                return _context.Tickets.Any(e => e.Id == id);
            }
        }
    }
