using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SSImplementation.Data;
using SSImplementation.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace SSImplementation.Controllers
{
    public class ProfilesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private UserManager<ApplicationUser> _userManager;
        private IHostingEnvironment _environment;

        public ProfilesController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, IHostingEnvironment environment)
        {
            _context = context;
            _userManager = userManager;
            _environment = environment;
        }

        // GET: Profiles
        public async Task<IActionResult> Index()
        {
            return View(await _context.Profiles.ToListAsync());
        }

        // GET: Profiles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profile = await _context.Profiles
                .SingleOrDefaultAsync(m => m.ID == id);
            if (profile == null)
            {
                return NotFound();
            }

            return View(profile);
        }

        // GET: Profiles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Profiles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,DisplayName,FirstName,LastName,Gender,DateofBirth,Email,PhoneNumber,Address,State,ZipCode,City,ProfilePicture,Bio,ProfilePictureFile")] Profile profile, IFormFile ProfilePictureFile)
        {
            ApplicationUser currentUser = await _userManager.GetUserAsync(User);
            string uploadPath = Path.Combine(_environment.WebRootPath, "ProfilePictures");
            Directory.CreateDirectory(Path.Combine(uploadPath, currentUser.Id));
            string filename = Path.GetFileName(ProfilePictureFile.FileName);
            using (FileStream fs = new FileStream(Path.Combine(uploadPath, currentUser.Id, filename), FileMode.Create))
            {
                await ProfilePictureFile.CopyToAsync(fs);
            }
            profile.ProfilePicture = filename;
            if (ModelState.IsValid)
            {
             
                _context.Add(profile);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Dashboard");
            }
            return View(profile);
        }

        // GET: Profiles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ApplicationUser currentUser = await _userManager.GetUserAsync(User);
            if (id == null)
            {
                return NotFound();
            }

            var profile = await _context.Profiles.SingleOrDefaultAsync(m => m.ID == currentUser.ProfileID);
            if (profile == null)
            {
                return NotFound();
            }
            return View(profile);
        }

        // POST: Profiles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,DisplayName,FirstName,LastName,Gender,DateofBirth,Email,PhoneNumber,Address,State,ZipCode,City,ProfilePicture,Bio")] Profile profile)
        {
            if (id != profile.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(profile);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProfileExists(profile.ID))
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
            return View(profile);
        }

        // GET: Profiles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profile = await _context.Profiles
                .SingleOrDefaultAsync(m => m.ID == id);
            if (profile == null)
            {
                return NotFound();
            }

            return View(profile);
        }

        // POST: Profiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var profile = await _context.Profiles.SingleOrDefaultAsync(m => m.ID == id);
            _context.Profiles.Remove(profile);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ProfileExists(int id)
        {
            return _context.Profiles.Any(e => e.ID == id);
        }
    }
}
