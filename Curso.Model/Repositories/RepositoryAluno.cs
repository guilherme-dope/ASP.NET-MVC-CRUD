using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Curso.Model.Models;

namespace Curso.Model.Repositories
{
    public class RepositoryAluno : IDisposable
    {
        private bool RecebeuContexto = false;
        private FaculContext odb;
        public RepositoryAluno()
        {
            odb = new FaculContext();
        }
        public RepositoryAluno(FaculContext _odb)
        {
            odb = _odb;
            RecebeuContexto = true;
        }
        public void Incluir(Aluno oAluno)
        {
            odb.Entry(oAluno).State = EntityState.Added;
            odb.SaveChanges();

        }
        public void Alterar(Aluno oAluno)
        {
            odb.Aluno.Attach(oAluno);
            odb.Entry(oAluno).State = EntityState.Modified;
            odb.SaveChanges();

        }
        public void Excluir(Aluno oAluno)
        {
            odb.Entry(oAluno).State = EntityState.Deleted;
            odb.SaveChanges();
        }
        public void Excluir(int CodigoCurso)
        {
            Aluno oAluno = (from P in odb.Aluno where P.CodigoCurso == CodigoCurso select P).FirstOrDefault();
            odb.Entry(oAluno).State = EntityState.Deleted;
            odb.SaveChanges();
        }
        public Aluno Seleciona(int CodigoCurso)
        {
            return odb.Aluno.Find(CodigoCurso);
        }
        public Aluno SelecionaId(int CodigoCurso)
        {
            return (from P in odb.Aluno where P.CodigoCurso == CodigoCurso select P).FirstOrDefault();
        }
        public Aluno SelecionaSemContexto(int CodigoCurso)
        {
            return (from p in odb.Aluno where p.CodigoCurso == CodigoCurso select p).AsNoTracking().FirstOrDefault();
        }
        public List<Aluno> SelecionarTodos()
        {
            return odb.Aluno.ToList();
        }
        public List<Aluno> SelecionarTodosSemContexto()
        {
            return (from p in odb.Aluno select p).AsNoTracking().ToList();
        }
        public void Dispose()
        {
            if (!RecebeuContexto)
            {
                odb.Dispose();
            }
        }
    }
}

