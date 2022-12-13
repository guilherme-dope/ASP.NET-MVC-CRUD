using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Curso.Model.Models;

namespace Curso.Model.Repositories
{
    public class RepositoryAula : IDisposable
    {
        private bool RecebeuContexto = false;
        private FaculContext odb;
        public RepositoryAula()
        {
            odb = new FaculContext();
        }
        public RepositoryAula(FaculContext _odb)
        {
            odb = _odb;
            RecebeuContexto = true;
        }
        public void Incluir(Aula oAula)
        {
            odb.Entry(oAula).State = EntityState.Added;
            odb.SaveChanges();

        }
        public void Alterar(Aula oAula)
        {
            odb.Aula.Attach(oAula);
            odb.Entry(oAula).State = EntityState.Modified;
            odb.SaveChanges();

        }
        public void Excluir(Aula oAula)
        {
            odb.Entry(oAula).State = EntityState.Deleted;
            odb.SaveChanges();
        }
        public void Excluir(int Codigo)
        {
            Aula oAula = (from P in odb.Aula where P.Codigo == Codigo select P).FirstOrDefault();
            odb.Entry(oAula).State = EntityState.Deleted;
            odb.SaveChanges();
        }
        public Aula Seleciona(int Codigo)
        {
            return odb.Aula.Find(Codigo);
        }
        public Aula SelecionaId(int Codigo)
        {
            return (from P in odb.Aula where P.Codigo == Codigo select P).FirstOrDefault();
        }
        public Aula SelecionaSemContexto(int Codigo)
        {
            return (from p in odb.Aula where p.Codigo == Codigo select p).AsNoTracking().FirstOrDefault();
        }
        public List<Aula> SelecionarTodos()
        {
            return odb.Aula.ToList();
        }
        public List<Aula> SelecionarTodosSemContexto()
        {
            return (from p in odb.Aula select p).AsNoTracking().ToList();
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

