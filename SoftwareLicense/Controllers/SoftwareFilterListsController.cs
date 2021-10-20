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
    public class SoftwareFilterListsController : Controller
    {
        private readonly HKEX_InventoryContext _context;

        public SoftwareFilterListsController(HKEX_InventoryContext context)
        {
            _context = context;
        }

        // GET: SoftwareFilterLists
        public async Task<IActionResult> Index()
        {
            return View(await _context.SoftwareFilterList.ToListAsync());
        }

        // GET: SoftwareFilterLists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var softwareFilterList = await _context.SoftwareFilterList
                .FirstOrDefaultAsync(m => m.Id == id);
            if (softwareFilterList == null)
            {
                return NotFound();
            }

            return View(softwareFilterList);
        }

        // GET: SoftwareFilterLists/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SoftwareFilterLists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SoftwareType,SoftwareName,Id")] SoftwareFilterList softwareFilterList)
        {
            if (ModelState.IsValid)
            {
                _context.Add(softwareFilterList);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(softwareFilterList);
        }

        // GET: SoftwareFilterLists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var softwareFilterList = await _context.SoftwareFilterList.FindAsync(id);
            if (softwareFilterList == null)
            {
                return NotFound();
            }
            return View(softwareFilterList);
        }

        // POST: SoftwareFilterLists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SoftwareType,SoftwareName,Id")] SoftwareFilterList softwareFilterList)
        {
            if (id != softwareFilterList.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(softwareFilterList);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SoftwareFilterListExists(softwareFilterList.Id))
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
            return View(softwareFilterList);
        }

        // GET: SoftwareFilterLists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var softwareFilterList = await _context.SoftwareFilterList
                .FirstOrDefaultAsync(m => m.Id == id);
            if (softwareFilterList == null)
            {
                return NotFound();
            }

            return View(softwareFilterList);
        }

        // POST: SoftwareFilterLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var softwareFilterList = await _context.SoftwareFilterList.FindAsync(id);
            _context.SoftwareFilterList.Remove(softwareFilterList);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SoftwareFilterListExists(int id)
        {
            return _context.SoftwareFilterList.Any(e => e.Id == id);
        }
    }
}
