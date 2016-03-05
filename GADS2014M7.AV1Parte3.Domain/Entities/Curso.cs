using System;
using System.Text;

namespace GADS2014M7.AV1Parte3.Domain.Data
{
    public partial class Curso
    {
        public Curso()
        {
            CursoId = Guid.NewGuid();
        }

        /// <summary>
        /// Método que retorna uma string formatada do objeto Curso. 
        /// Método escrito em formato "Expression-bodied function"
        /// </summary>
        /// <returns>string formatada do objeto Curso</returns>
        public override string ToString() => $"Codigo: {CodigoCurso} | Nome: {Nome} ";


        /// <summary>
        /// Método que retorna uma string formatada do objeto Curso.
        /// </summary>
        /// <param name="format">Informe o formato (identação) da string,
        ///  sendo "N" para NewLine ou em branco para InLine</param>
        /// <returns>string formatada do objeto Curso</returns>
        public string ToString(string format)
        {
            if (!format.Equals("N")) return ToString();

            var sb = new StringBuilder();
            sb.AppendLine("Curso:\n======");
            sb.AppendLine($"Codigo: {CodigoCurso}\nNome: {Nome}\n");

            return sb.ToString();
        }
    }
}