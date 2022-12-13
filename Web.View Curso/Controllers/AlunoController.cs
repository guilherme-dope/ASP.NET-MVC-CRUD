using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Curso.Model;
using Curso.Model.Repositories;
using Curso.Model.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Web.View_Curso.Controllers
{
    public class AlunoController : Controller
    {
        // GET: AlunoController
        public ActionResult Index()
        {
            RepositoryAluno oRepository = new RepositoryAluno();
            List<Aluno> oLista = oRepository.SelecionarTodos();
            return View(oLista);
        }

        // GET: AlunoController/Details/5
        public ActionResult Details(int CodigoCurso)
        {
            RepositoryAluno oRepository = new RepositoryAluno();
            Aluno oAluno = oRepository.SelecionaId(CodigoCurso);
            return View(oAluno);
        }

        // GET: AlunoController/Create
        public ActionResult Create()
        {
            Aluno oAluno = new Aluno();
            return View(oAluno);
        }

        // POST: AlunoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Aluno oAluno)
        {
            RepositoryAluno oRepository = new RepositoryAluno();
            oRepository.Incluir(oAluno);
            return View("Index", oRepository.SelecionarTodos());
        }

        // GET: AlunoController/Edit/5
        public ActionResult Edit(int CodigoCurso)
        {
            RepositoryAluno oRepository = new RepositoryAluno();
            Aluno oAluno = oRepository.SelecionaId(CodigoCurso);
            return View(oAluno);
        }

        // POST: AlunoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Aluno oAluno)
        {

            RepositoryAluno oRepository = new RepositoryAluno();
            oRepository.Alterar(oAluno);
            return View(oAluno);

        }

        // GET: AlunoController/Delete/5
        public ActionResult Delete(int CodigoCurso)
        {
            RepositoryAluno oRepository = new RepositoryAluno();
            oRepository.Excluir(CodigoCurso);
            return View();
        }

        // POST: AlunoController/Delete/5
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
