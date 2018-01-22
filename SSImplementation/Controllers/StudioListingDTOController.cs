using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SSImplementation.Data;
using SSImplementation.Models;

namespace SSImplementation.Controllers
{
    public class StudioListingDTOController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudioListingDTOController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: StudioListingDTO
        public async Task<IActionResult> Index()
        {
            return View(await _context.StudioListings.ToListAsync());
        }

        // GET: StudioListingDTO/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studioListingDTO = await _context.StudioListings
                .SingleOrDefaultAsync(m => m.ID == id);
            if (studioListingDTO == null)
            {
                return NotFound();
            }

            return View(studioListingDTO);
        }

        // GET: StudioListingDTO/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StudioListingDTO/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Type,isAvailable,Address,ListingDescription,State,City,numberOfRooms,pictureOfRoom,StudioName,PricePerHour,CancellationFee,StudioRules")] StudioListingDTO studioListingDTO)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studioListingDTO);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(studioListingDTO);
        }

        // GET: StudioListingDTO/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studioListingDTO = await _context.StudioListings.SingleOrDefaultAsync(m => m.ID == id);
            if (studioListingDTO == null)
            {
                return NotFound();
            }
            return View(studioListingDTO);
        }

        // POST: StudioListingDTO/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Type,isAvailable,Address,ListingDescription,State,City,numberOfRooms,pictureOfRoom,StudioName,PricePerHour,CancellationFee,StudioRules")] StudioListingDTO studioListingDTO)
        {
            if (id != studioListingDTO.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studioListingDTO);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudioListingDTOExists(studioListingDTO.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(studioListingDTO);
        }

        // GET: StudioListingDTO/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studioListingDTO = await _context.StudioListings
                .SingleOrDefaultAsync(m => m.ID == id);
            if (studioListingDTO == null)
            {
                return NotFound();
            }

            return View(studioListingDTO);
        }

        // POST: StudioListingDTO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var studioListingDTO = await _context.StudioListings.SingleOrDefaultAsync(m => m.ID == id);
            _context.StudioListings.Remove(studioListingDTO);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool StudioListingDTOExists(int id)
        {
            return _context.StudioListings.Any(e => e.ID == id);
        }
    }
}
