using System.Linq;
using GADS2014M7.AV1Parte3.Domain.Data;

namespace GADS2014M7.AV1Parte3.Domain.Services
{
    public class DbService
    {
        private static readonly AV1Parte3ContextDb DbCtx = new AV1Parte3ContextDb();

        public virtual string AdicionaAluno(Aluno aluno)
        {
            if (GetByAlunoMatricula(aluno.Matricula) != null)
                return "Ação: Aluno já existente.";

            DbCtx.Alunos.Add(aluno);
            DbCtx.SaveChanges();
            return "Ação: Aluno inserido.";
        }

        public virtual Aluno GetByAlunoMatricula(int matricula)
        {
            return DbCtx.Alunos.FirstOrDefault(a => a.Matricula == matricula);
        }

        public virtual string AdicionaCurso(Curso curso)
        {
            if (GetCursoByCodigo(curso.CodigoCurso) != null)
                return "Ação: Curso já existente.";

            DbCtx.Cursos.Add(curso);
            DbCtx.SaveChanges();
            return "Ação: Curso inserido.";
        }

        public virtual Curso GetCursoByCodigo(string codigo)
        {
            return DbCtx.Cursos.FirstOrDefault(c => c.CodigoCurso.Equals(codigo));
        }

    }
}