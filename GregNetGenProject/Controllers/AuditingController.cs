using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GregNetGenProject.Areas.Identity.Data;
using GregNetGenProject.Models;
//using AspNetCore;
using GregNetGenProject.Areas.Identity.Pages.Account;
using Microsoft.AspNetCore.Authorization;

namespace GregNetGenProject.Controllers
{
    public class AuditingController : Controller
    {
        private readonly GregNetGenProjectDBContext _context;

        public AuditingController(GregNetGenProjectDBContext context)
        {
            _context = context;
        }

        //This is to authorize users /policies and stuff are created
        //in the program.cs file and login.cshtml.cs file
        [Authorize(Roles = "Admin, Reporter")]
        // GET: Auditing
        public async Task<IActionResult> Index(string searchString)
        {
            ViewData["CurrentFilter"] = searchString;

            var students = from s in _context.AuditingModel
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                students = students.Where(s => s.EmailAddress.Contains(searchString));
            }


            return View(await _context.AuditingModel.ToListAsync());
        }

        //I put it on all the Gets so that unauthorized people cannot access any of the pages
        [Authorize(Roles = "Admin, Reporter")]
        // GET: Auditing/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AuditingModel == null)
            {
                return NotFound();
            }

            var auditingModel = await _context.AuditingModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (auditingModel == null)
            {
                return NotFound();
            }

            return View(auditingModel);
        }

        [Authorize(Roles = "Admin, Reporter")]
        // GET: Auditing/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Auditing/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EmailAddress,DateTime,Description")] AuditingModel auditingModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(auditingModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(auditingModel);
        }

        [Authorize(Roles = "Admin, Reporter")]
        // GET: Auditing/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AuditingModel == null)
            {
                return NotFound();
            }

            var auditingModel = await _context.AuditingModel.FindAsync(id);
            if (auditingModel == null)
            {
                return NotFound();
            }
            return View(auditingModel);
        }

        // POST: Auditing/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EmailAddress,DateTime,Description")] AuditingModel auditingModel)
        {
            if (id != auditingModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(auditingModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AuditingModelExists(auditingModel.Id))
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
            return View(auditingModel);
        }

        [Authorize(Roles = "Admin, Reporter")]
        // GET: Auditing/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AuditingModel == null)
            {
                return NotFound();
            }

            var auditingModel = await _context.AuditingModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (auditingModel == null)
            {
                return NotFound();
            }

            return View(auditingModel);
        }

        // POST: Auditing/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AuditingModel == null)
            {
                return Problem("Entity set 'GregNetGenProjectDBContext.AuditingModel'  is null.");
            }
            var auditingModel = await _context.AuditingModel.FindAsync(id);
            if (auditingModel != null)
            {
                _context.AuditingModel.Remove(auditingModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AuditingModelExists(int id)
        {
          return _context.AuditingModel.Any(e => e.Id == id);
        }





        //------------------------------------------------------------------------------//
        //Trying to add a register aduit log

        /*
        private readonly RegisterModel _audit = null;

        public AuditingController(RegisterModel audit)
        {
            _audit = audit;
        }

        [HttpPost]
        public IActionResult AddAudit(AuditingModel auditingModel)
        {
            int id = _audit.AddRegisterAuditLog(auditingModel);
            if (id > 0 )
            {
                return RedirectToAction(nameof(Create));
            }
            return View();
        }*/
    }
}
//-------------------------------ooo000 END OF FILE 000ooo-------------------------------//