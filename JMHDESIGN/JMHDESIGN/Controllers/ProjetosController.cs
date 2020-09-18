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
        [Authorize(Roles = "funcionario, cliente")] 
        public async Task<IActionResult> Index()
        {
            if (User.IsInRole("funcionario"))
            {
                return View(await _context.Projetos.Include(p => p.Cliente).ToListAsync());
            }


            var cliente = _context.Projetos.Include(p => p.Cliente).Where(c => c.Cliente.UserNameId == _Usermanager.GetUserId(User));
            return View(await cliente.ToListAsync());

        }

        // GET: Projetos/Details/5
        /// <summary>
        /// Mostra os detalhes de um projeto, tais como:
        /// o nome do projeto, a descrição, a categoria, a data de entrega, a fotografia e o ficheiro.
        /// </summary>
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projeto = await _context.Projetos
                                         .Include(p => p.Cliente)
                                         .FirstOrDefaultAsync(m => m.IDproj == id);
            if (projeto == null)
            {
                return NotFound();
            }

            return View(projeto);
        }

        // GET: Projetos/Create
        /// <summary>
        /// Cria um projeto com os seguintes campos diponiveis:
        /// nome do projeto, descrição, categoria, data de entrega, fotografia e ficheiro.
        /// </summary>

        [Authorize(Roles = "funcionario")]
        public IActionResult Create()
        {
            ViewData["ClienteFK"] = new SelectList(_context.Clientes, "IDcliente", "Nome");
            return View();
        }

        // POST: Projetos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [DisableRequestSizeLimit]
        [Authorize(Roles = "funcionario")]
        public async Task<IActionResult> Create([Bind("IDproj,Nome,Descricao,Categoria,Data,Fotografia,Ficheiro,ClienteFK")] Projetos projeto, IFormFile imagem, IFormFile documento)
        {
            //  var criador = _context.Projetos.FirstOrDefault(f => f. == _Usermanager.GetUserId(User));

            string caminhoImagem = "";
            bool existeImagem = false;
            string caminhoFicheiro = "";
            bool existeFicheiro = false;

            // cria um novo id unico para nome do ficheiro e da fotografia
            Guid g;
            g = Guid.NewGuid();

            // processar a FOTOGRAFIA
            if (imagem == null)
            {
                projeto.Fotografia = "default.jpg";
            }
            else
            {
                if (imagem.ContentType == "image/jpeg" || imagem.ContentType == "image/png")
                {
                    string extensao = Path.GetExtension(imagem.FileName).ToLower();
                    string nome = g.ToString() + extensao;

                    caminhoImagem = Path.Combine(_caminho.WebRootPath, "img\\", nome);
                    projeto.Fotografia = nome;

                    existeImagem = true;
                }
                else
                {
                    projeto.Fotografia = "default.jpg";
                }
            }

            // processar o FICHEIRO
            if (documento == null)
            {
                projeto.Ficheiro = "";
            }
            else
            {
                if (documento.ContentType == "application/pdf") // pq só se pretende PDFs
                {
                    string extensao = Path.GetExtension(documento.FileName).ToLower();
                    string nome = g.ToString() + extensao;

                    caminhoFicheiro = Path.Combine(_caminho.WebRootPath, "Ficheiros\\", nome);
                    projeto.Ficheiro = nome;

                    existeFicheiro = true;
                }
                else
                {
                    projeto.Ficheiro = "";
                }
            }

            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(projeto);
                    await _context.SaveChangesAsync();

                    // guardar os ficheiros (imagem + ficheiro)
                    if (existeFicheiro)
                    {
                        using var stream = new FileStream(caminhoFicheiro, FileMode.Create);
                        await documento.CopyToAsync(stream);
                    }
                    if (existeImagem)
                    {
                        using var stream = new FileStream(caminhoImagem, FileMode.Create);
                        await imagem.CopyToAsync(stream);
                    }
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception)
            {
                // falta decidir o q deve ser feito se existir um erro...
                throw;
            }

            ViewData["ClienteFK"] = new SelectList(_context.Clientes, "IDcliente", "Nome", projeto.ClienteFK);
            return View(projeto);
        }



        // GET: Projetos/Edit/5
        /// <summary>
        /// Edita um projeto com os seguintes campos disponiveis:
        /// nome do projeto, descrição, categoria, data de entrega, fotografia e ficheiro.
        /// </summary>

        [Authorize(Roles = "funcionario")] // apenas o funcionário pode editar os dados de um projeto
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projetos = await _context.Projetos.Include(p=>p.Cliente)
                                         .FirstOrDefaultAsync (p=>p.IDproj==id);
            if (projetos == null)
            {
                return NotFound();
            }

            ViewData["ClienteFK"] = new SelectList(_context.Clientes, "IDcliente", "Nome");

            return View(projetos);
        }


        // POST: Projetos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [DisableRequestSizeLimit]
        [Authorize(Roles = "funcionario")] // apenas o funcionário pode editar os dados de um projeto

        public async Task<IActionResult> Edit(int id, [Bind("IDproj,Nome,Descricao,Categoria,Data,Fotografia,Ficheiro,ClienteFK")] Projetos projeto, IFormFile imagem, IFormFile documento)
        {
            if (id != projeto.IDproj)
            {
                return NotFound();
            }

            var projetoVelho = await _context.Projetos.FindAsync(id);

            // se existe uma nova imagem, troca-se a imagem 'velha' pela 'nova'
            // o mesmo para o documento

            string caminhoImagem = "";
            bool existeImagem = false;
            string caminhoFicheiro = "";
            bool existeFicheiro = false;

            // cria um novo id unico para nome do ficheiro e da fotografia
            Guid g;
            g = Guid.NewGuid();

            // processar a FOTOGRAFIA
            if (imagem == null && "default.jpg" == projetoVelho.Fotografia)
            {
                    projeto.Fotografia = "default.jpg";
            }
            else
            {
                if (imagem != null && imagem.FileName != projetoVelho.Fotografia) {
                    if (imagem.ContentType == "image/jpeg" || imagem.ContentType == "image/png")
                    {
                        string extensao = Path.GetExtension(imagem.FileName).ToLower();
                        string nome = g.ToString() + extensao;

                        caminhoImagem = Path.Combine(_caminho.WebRootPath, "img\\", nome);
                        projeto.Fotografia = nome;

                        existeImagem = true;
                    }
                    else
                    {
                        projeto.Fotografia = "default.jpg";
                    }
                }
                else
                {
                    projeto.Fotografia = projetoVelho.Fotografia;
                }

            }

            // processar o FICHEIRO
            if (documento == null && "" == projetoVelho.Ficheiro)
            {
                    projeto.Ficheiro = "";
            }
            else
            {
                if (documento != null && documento.FileName != projetoVelho.Ficheiro)
                {
                    if (documento.ContentType == "application/pdf") // pq só se pretende PDFs
                    {
                        string extensao = Path.GetExtension(documento.FileName).ToLower();
                        string nome = g.ToString() + extensao;

                        caminhoFicheiro = Path.Combine(_caminho.WebRootPath, "Ficheiros\\", nome);
                        projeto.Ficheiro = nome;

                        existeFicheiro = true;
                    }
                    else
                    {
                        projeto.Ficheiro = "";
                    }
                }
                
                else
                {
                    projeto.Ficheiro = projetoVelho.Ficheiro;
                }
            }
                try
                {
                

            if (ModelState.IsValid)
            {
                    _context.Entry(projetoVelho).State = EntityState.Detached;
                    _context.Update(projeto);
                    await _context.SaveChangesAsync();

                    // guardar os ficheiros (imagem + ficheiro)
                    if (existeFicheiro)
                    {

                        // se, caso não for inserido um ficheiro no projeto o campo fica vazio
                        if (projeto.Ficheiro != "")
                        {

                            var ficheiro = Path.Combine(_caminho.WebRootPath, "Ficheiros\\", projetoVelho.Ficheiro);

                            // caso exista um ficheiro, esse ficheiro é inserido pelo funcionário
                            if (System.IO.File.Exists(ficheiro))
                                System.IO.File.Delete(ficheiro);
                        }

                        using var stream = new FileStream(caminhoFicheiro, FileMode.Create);
                        await documento.CopyToAsync(stream);
                    }
                    if (existeImagem)
                    {

                        // se, caso não for inserida uma fotografia no projeto, insere uma fotografia por defeito
                        if (projeto.Fotografia != "default.jpg")
                        {
                            var fotografia = Path.Combine(_caminho.WebRootPath, "img\\", projetoVelho.Fotografia);

                            // caso exista uma fotografia, essa fotografia é inserida pelo funcionário
                            if (System.IO.File.Exists(fotografia))
                                System.IO.File.Delete(fotografia);
                        }

                            using var stream = new FileStream(caminhoImagem, FileMode.Create);
                        await imagem.CopyToAsync(stream);
                    }

                    return RedirectToAction(nameof(Index));
            }

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjetosExists(projeto.IDproj))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return View(projeto);
        }

        // GET: Projetos/Delete/5
        /// <summary>
        /// Elimina um projeto.
        /// </summary>

        [Authorize(Roles = "funcionario")] // apenas o funcionário pode eliminar os dados de um projeto
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projetos = await _context.Projetos
                .FirstOrDefaultAsync(m => m.IDproj  == id);
            if (projetos == null)
            {
                return NotFound();
            }

            return View(projetos);
        }

        // POST: Projetos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "funcionario")] // apenas o funcionário pode eliminar os dados de um projeto
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var projetos = await _context.Projetos.FindAsync(id);


            // se, caso não for inserida uma fotografia no projeto, insere uma fotografia por defeito
            if (projetos.Fotografia != null && projetos.Fotografia != "default.jpg")
            {
                var fotografia = Path.Combine(_caminho.WebRootPath, "img\\", projetos.Fotografia);

                // caso exista uma fotografia, essa fotografia é inserida pelo funcionário
                if (System.IO.File.Exists(fotografia))
                    System.IO.File.Delete(fotografia);
            }

            // se, caso não for inserido um ficheiro no projeto o campo fica vazio
            if (projetos.Ficheiro != null && projetos.Ficheiro != "")
            {

                var ficheiro = Path.Combine(_caminho.WebRootPath, "Ficheiros\\", projetos.Ficheiro);

                // caso exista um ficheiro, esse ficheiro é inserido pelo funcionário
                if (System.IO.File.Exists(ficheiro))
                    System.IO.File.Delete(ficheiro);
            }

            _context.Projetos.Remove(projetos);
            await _context.SaveChangesAsync();

           
            return RedirectToAction(nameof(Index));
        }

        private bool ProjetosExists(int id)
        {
            return _context.Projetos.Any(e => e.IDproj == id);
        }
    }
}
