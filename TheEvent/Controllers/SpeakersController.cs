using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TheEvent.Data;
using TheEvent.Models;
using System.Linq;
using System.Threading.Tasks;

namespace TheEvent.Controllers
{
    namespace TheEvent.Controllers
    {
        public class SpeakersController : Controller
        {
            private readonly TheEventContext _context;

            public SpeakersController(TheEventContext context)
            {
                _context = context;
            }

            // GET: Speakers
            public async Task<IActionResult> Index()
            {
                return View(await _context.Speakers.ToListAsync());
            }

            // GET: Speakers/Details/5
            public async Task<IActionResult> Details(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var Speakers = await _context.Speakers
                    .FirstOrDefaultAsync(m => m.Id == id);
                if (Speakers == null)
                {
                    return NotFound();
                }

                return View(Speakers);
            }

            public IActionResult Display()
            {
                return View();
            }

            // GET: Speakers/Create
            public IActionResult Create()
            {
                return View();
            }
            
            // POST: Speakers/Create
            // To protect from overposting attacks, enable the specific properties you want to bind to, for 
            // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Create([Bind("Id,Name,Gender,Language")] Speakers Speakers)
            {
                if (ModelState.IsValid)
                {
                    _context.Add(Speakers);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Display));
                }
                return View(Speakers);
            }

            // GET: Speakers/Edit/5
            public async Task<IActionResult> Edit(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var Speakers = await _context.Speakers.FindAsync(id);
                if (Speakers == null)
                {
                    return NotFound();
                }
                return View(Speakers);
            }

            // POST: Speakers/Edit/5
            // To protect from overposting attacks, enable the specific properties you want to bind to, for 
            // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Gender,Language")] Speakers Speakers)
            {
                if (id != Speakers.Id)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(Speakers);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!SpeakersExists(Speakers.Id))
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
                return View(Speakers);
            }

            // GET: Speakers/Delete/5
            public async Task<IActionResult> Delete(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var Speakers = await _context.Speakers
                    .FirstOrDefaultAsync(m => m.Id == id);
                if (Speakers == null)
                {
                    return NotFound();
                }

                return View(Speakers);
            }

            // POST: Speakers/Delete/5
            [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> DeleteConfirmed(int id)
            {
                var Speakers = await _context.Speakers.FindAsync(id);
                _context.Speakers.Remove(Speakers);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            private bool SpeakersExists(int id)
            {
                return _context.Speakers.Any(e => e.Id == id);
            }
        }
    }
}
