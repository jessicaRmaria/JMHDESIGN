﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JMHDESIGN.Data;
using JMHDESIGN.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

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

            if (User.IsInRole("funcionario"))
            {
                var applicationDbContext = _context.Formularios.Include(f => f.Cliente);
                return View(await applicationDbContext.ToListAsync());
            }


            var cliente = _context.Formularios.Include(f => f.Cliente).Where(c => c.Cliente.UserNameId == _userManager.GetUserId(User));
            return View(await cliente.ToListAsync());
        }

        // GET: Formularios/Details/5
        /// <summary>
        /// Mostra os detalhes de um formulário, tais como:
        /// o nome do cliente, o assunto, a descrição e a data do dia submetido.
        /// </summary>
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
        /// <summary>
        /// Cria um formulário com os seguintes campos diponiveis:
        /// nome do cliente, assunto, descrição e a data.
        /// </summary>
        public IActionResult Create()
        { 
            return View();
        }

        // POST: Formularios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IDform,Assunto,Data,Descricao,ClienteFK")] Formularios formularios)
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
        /// <summary>
        /// Edita um formulário com os seguintes campos disponiveis:
        /// nome do cliente, assunto, descrição e a data.
        /// </summary>
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formularios = await _context.Formularios.FindAsync(id);
            if (formularios == null)
            {
                return NotFound();
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
        /// <summary>
        /// Elimina um formulário.
        /// </summary>
        [Authorize(Roles = "funcionario")] // apenas o funcionário pode eliminar formulário
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
        [Authorize(Roles = "funcionario")] // apenas o funcionário pode eliminar formulários
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
