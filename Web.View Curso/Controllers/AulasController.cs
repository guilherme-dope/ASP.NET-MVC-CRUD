using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Curso.Model;
using Curso.Model.Repositories;
using Curso.Model.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Web.View_Curso.Controllers
{
    public class AulasController : Controller
    {
        // GET: AulasController
        public ActionResult Index()
        {
            RepositoryAula oRepository= new RepositoryAula();
            List<Aula> oLista = oRepository.SelecionarTodos();
            return View(oLista);
        }

        // GET: AulasController/Details/5
        public ActionResult Details(int id)
        {
            RepositoryAula oRepository = new RepositoryAula();
            Aula oAula = oRepository.SelecionaId(id);
            return View(oAula);
        }

        // GET: AulasController/Create
        public ActionResult Create()
        {
            Aula oAula = new Aula();
            return View(oAula);
        }

        // POST: AulasController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Aula oAula)
        {
            RepositoryAula oRepository = new RepositoryAula();
            oRepository.Incluir(oAula);
            return View("Index", oRepository.SelecionarTodos());
        }

        // GET: AulasController/Edit/5
        public ActionResult Edit(int id)
        {
            RepositoryAula oRepository = new RepositoryAula();
            Aula oAula = oRepository.SelecionaId(id);
            return View(oAula);
        }

        // POST: AulasController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Aula oAula)
        {
            
                RepositoryAula oRepository = new RepositoryAula();
                oRepository.Alterar(oAula);
                return View(oAula);
           
        }

        // GET: AulasController/Delete/5
        public ActionResult Delete(int id)
        {
            RepositoryAula oRepository = new RepositoryAula();
            oRepository.Excluir(id);
            return View();
        }

        // POST: AulasController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
