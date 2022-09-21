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
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace SSImplementation.Controllers
{
    public class ProfilesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private UserManager<ApplicationUser> _userManager;
        private IHostingEnvironment _environment;

        public ProfilesController(ApplicationDbContext context, 
            UserManager<ApplicationUser> userManager, IHostingEnvironment environment)
        {
            _context = context;
            _userManager = userManager;
            _environment = environment;
        }

        // GET: Profiles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            ApplicationUser currentUser = await _userManager.GetUserAsync(User);
            var profile = await _context.Profiles
                .SingleOrDefaultAsync(m => m.ID == currentUser.ProfileID);
            return View(profile);
        }

        

        // GET: Profiles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ApplicationUser currentUser = await _userManager.GetUserAsync(User);
            var profile = await _context.Profiles
                .SingleOrDefaultAsync(m => m.ID == currentUser.ProfileID);
            return View(profile);
        }

        // POST: Profiles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, 
            [Bind("ID,DisplayName,FirstName,LastName,Gender,Email,PhoneNumber," +
            "DateofBirth,Address,State,ZipCode,City,ProfilePicture,Bio," +
            "ProfilePictureFile")] Profile profile, IFormFile ProfilePictureFile)
        {
            ApplicationUser currentUser = await _userManager.GetUserAsync(User);
            if (ModelState.IsValid)
            {

                if (ProfilePictureFile != null)
                {
                    string uploadpath = Path.Combine(_environment.WebRootPath, "ProfilePictures");
                    Directory.CreateDirectory(Path.Combine(uploadpath, currentUser.Id.ToString()));
                    string filename = Path.GetFileName(ProfilePictureFile.FileName);
                    using (FileStream fs = new FileStream(Path.Combine(uploadpath, currentUser.Id.ToString(), filename), FileMode.Create))
                    {
                        await ProfilePictureFile.CopyToAsync(fs);
                    }
                    profile.ProfilePicture = filename;
                }
                _context.Update(profile);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Dashboard");
            }
            return View(profile);
        }

        
    }
}
