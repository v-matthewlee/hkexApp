using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SoftwareLicense.Models;

namespace SoftwareLicense.Controllers
{
    public class MatchingTablesController : Controller
    {
        private readonly HKEX_InventoryContext _context;

        public MatchingTablesController(HKEX_InventoryContext context)
        {
            _context = context;
        }

        // GET: MatchingTables
        public async Task<IActionResult> Index()
        {
            return View(await _context.MatchingTable.ToListAsync());
        }

        // GET: MatchingTables/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var matchingTable = await _context.MatchingTable
                .FirstOrDefaultAsync(m => m.Id == id);
            if (matchingTable == null)
            {
                return NotFound();
            }

            return View(matchingTable);
        }

        // GET: MatchingTables/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MatchingTables/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SoftwareName,LicenseName,Id")] MatchingTable matchingTable)
        {
            if (ModelState.IsValid)
            {
                _context.Add(matchingTable);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(matchingTable);
        }

        // GET: MatchingTables/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var matchingTable = await _context.MatchingTable.FindAsync(id);
            if (matchingTable == null)
            {
                return NotFound();
            }
            return View(matchingTable);
        }

        // POST: MatchingTables/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SoftwareName,LicenseName,Id")] MatchingTable matchingTable)
        {
            if (id != matchingTable.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(matchingTable);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MatchingTableExists(matchingTable.Id))
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
            return View(matchingTable);
        }

        // GET: MatchingTables/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var matchingTable = await _context.MatchingTable
                .FirstOrDefaultAsync(m => m.Id == id);
            if (matchingTable == null)
            {
                return NotFound();
            }

            return View(matchingTable);
        }

        // POST: MatchingTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var matchingTable = await _context.MatchingTable.FindAsync(id);
            _context.MatchingTable.Remove(matchingTable);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MatchingTableExists(int id)
        {
            return _context.MatchingTable.Any(e => e.Id == id);
        }
    }
}
