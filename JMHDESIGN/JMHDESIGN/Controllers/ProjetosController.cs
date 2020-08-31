using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JMHDESIGN.Data;
using JMHDESIGN.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace JMHDESIGN.Controllers
{

    [AllowAnonymous]
    public class ProjetosController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _Usermanager;
        private readonly IWebHostEnvironment _caminho;


        public ProjetosController(ApplicationDbContext context, UserManager<IdentityUser> Usermanager, IWebHostEnvironment caminho)
        {
            _context = context;
            _Usermanager = Usermanager;
            _caminho = caminho;


        }

        // GET: Projetos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Funcionarios.ToListAsync());
        }

        // GET: Projetos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projetos = await _context.Funcionarios
                .FirstOrDefaultAsync(m => m.IDproj == id);
            if (projetos == null)
            {
                return NotFound();
            }

            return View(projetos);
        }

        // GET: Projetos/Create

        [Authorize(Roles = "funcionario")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Projetos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "funcionario")]
        public async Task<IActionResult> Create([Bind("IDproj,Nome,Descricao,Categoria,Data,Fotografia,Ficheiro")] Projetos projetos, IFormFile imagem, IFormFile ficheiro)
        {
            var criador = _context.Projetos.FirstOrDefault(f => f.UserNameId == _Usermanager.GetUserId(User));
            string caminhoImagem = "";
            string caminhoFicheiro = "";
            bool existeImagem = false;
            if (imagem == null)
            {
                projetos.Fotografia = "default.jpg";

            } else
            {
                if (imagem.ContentType == "image/jpeg" || imagem.ContentType == "image/png")
                {
                    // cria o um novo id unico para nome da imagem
                    Guid g;
                    g = Guid.NewGuid();

                    string extensao = Path.GetExtension(imagem.FileName).ToLower();
                    string nome = g.ToString() + extensao;

                    caminhoImagem = Path.Combine(_caminho.WebRootPath, "Imagens\\", nome);
                    projetos.Fotografia = nome;

                    extensao = Path.GetExtension(ficheiro.FileName).ToLower();
                    nome = g.ToString() + extensao;

                    caminhoFicheiro = Path.Combine(_caminho.WebRootPath, "Ficheiros\\", nome);
                    projetos.Ficheiro = nome;

                    existeImagem = true;
                }
                else
                {
                    projetos.Fotografia = "default.jpg";
                }

            }

            if (ModelState.IsValid)
            {
                _context.Add(projetos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(projetos);
        }

        // GET: Projetos/Edit/5

        [Authorize(Roles = "funcionario")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projetos = await _context.Funcionarios.FindAsync(id);
            if (projetos == null)
            {
                return NotFound();
            }
            return View(projetos);
        }

        // POST: Projetos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "funcionario")]

        public async Task<IActionResult> Edit(int id, [Bind("IDproj,Nome,Descricao,Categoria,Data,Fotografia,Ficheiro")] Projetos projetos)
        {
            if (id != projetos.IDproj)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(projetos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjetosExists(projetos.IDproj))
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
            return View(projetos);
        }

        // GET: Projetos/Delete/5

        [Authorize(Roles = "funcionario")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projetos = await _context.Funcionarios
                .FirstOrDefaultAsync(m => m.IDproj == id);
            if (projetos == null)
            {
                return NotFound();
            }

            return View(projetos);
        }

        // POST: Projetos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "funcionario")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var projetos = await _context.Funcionarios.FindAsync(id);
            _context.Funcionarios.Remove(projetos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjetosExists(int id)
        {
            return _context.Funcionarios.Any(e => e.IDproj == id);
        }
    }
}
