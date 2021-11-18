using CharlieExam3Sem.Data;
using CharlieExam3Sem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CharlieExam3Sem.Controllers
{
	public class RunnersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RunnersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Runners
        [Authorize]
        public async Task<IActionResult> RunnerList()
        {
            return View(await _context.Runners.ToListAsync());
        }

        [Authorize]
        // GET: Runners/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Runners/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,FirstName,LastName,BirthDate,Address,ZipCode,PhoneNumber,AssignCaptain,EmailAddress,RunnerNumber,MemberSince")] Runner runner)
        {
            if (ModelState.IsValid)
            {
                _context.Add(runner);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(RunnerList));
            }
            return View(runner);
        }

        // GET: Runners/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var runner = await _context.Runners.FindAsync(id);
            if (runner == null)
            {
                return NotFound();
            }
            return View(runner);
        }

        // POST: Runners/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FirstName,LastName,BirthDate,Address,ZipCode,PhoneNumber,AssignCaptain,EmailAddress,RunnerNumber,ID,MemberSince")] Runner runner)
        {
            if (id != runner.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(runner);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RunnerExists(runner.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(RunnerList));
            }
            return View(runner);
        }

        // GET: Runners/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var runner = await _context.Runners
                .FirstOrDefaultAsync(m => m.ID == id);
            if (runner == null)
            {
                return NotFound();
            }

            return View(runner);
        }

        // POST: Runners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var runner = await _context.Runners.FindAsync(id);
            _context.Runners.Remove(runner);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(RunnerList));
        }

        private bool RunnerExists(int id)
        {
            return _context.Runners.Any(e => e.ID == id);
        }
    }
}
