using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JMHDESIGN.Data;
using JMHDESIGN.Models;
using Microsoft.AspNetCore.Identity;

namespace JMHDESIGN.Controllers
{
    public class FormulariosController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public FormulariosController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Formularios
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Formularios.Include(f => f.Cliente);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Formularios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formularios = await _context.Formularios
                .Include(f => f.Cliente)
                .FirstOrDefaultAsync(m => m.IDform == id);
            if (formularios == null)
            {
                return NotFound();
            }

            return View(formularios);
        }

        // GET: Formularios/Create
        public IActionResult Create()
        {
            
            return View();
        }

        // POST: Formularios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IDform,Assunto,Data,Descricao")] Formularios formularios)
        {

            
            if (ModelState.IsValid)
            {
                var Cliente = _context.Clientes.FirstOrDefault(m => m.UserNameId == _userManager.GetUserId(User));
                formularios.ClienteFK = Cliente.IDcliente;
                _context.Add(formularios);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
           
            return View(formularios);
        }

        // GET: Formularios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formularios = await _context.Formularios.FindAsync(id);
            if (formularios == null)
            {
                return NotFound(); //mudar
            }
           
            return View(formularios);
        }

        // POST: Formularios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IDform,Assunto,Data,Descricao,ClienteFK")] Formularios formularios)
        {
            if (id != formularios.IDform)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(formularios);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FormulariosExists(formularios.IDform))
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
            
            return View(formularios);
        }

        // GET: Formularios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formularios = await _context.Formularios
                .Include(f => f.Cliente)
                .FirstOrDefaultAsync(m => m.IDform == id);
            if (formularios == null)
            {
                return NotFound();
            }

            return View(formularios);
        }

        // POST: Formularios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var formularios = await _context.Formularios.FindAsync(id);
            _context.Formularios.Remove(formularios);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FormulariosExists(int id)
        {
            return _context.Formularios.Any(e => e.IDform == id);
        }
    }
}
