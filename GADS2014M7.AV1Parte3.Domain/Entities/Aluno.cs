using System;
using System.Text;

namespace GADS2014M7.AV1Parte3.Domain.Data
{
    public partial class Aluno
    {
        public Aluno()
        {
            AlunoId = Guid.NewGuid();
        }

        /// <summary>
        /// Método que retorna uma string formatada do objeto Aluno. 
        /// Método escrito em formato "Expression-bodied function"
        /// </summary>
        /// <returns>string formatada do objeto Aluno</returns>
        public override string ToString() => $"Matricula: {Matricula} | Nome: {Nome} | Status: {(Status ? "1 - Ativo" : "0 - Inativo")}";


        /// <summary>
        /// Método que retorna uma string formatada do objeto Aluno.
        /// </summary>
        /// <param name="format">Informe o formato (identação) da string,
        ///  sendo "N" para NewLine ou em branco para InLine</param>
        /// <returns>string formatada do objeto Aluno</returns>
        public string ToString(string format)
        {
            if (!format.Equals("N")) return ToString();

            var sb = new StringBuilder();
            sb.AppendLine("Aluno:\n======");
            sb.AppendLine($"Nome : {Nome} \nMatricula: {Matricula}\n");
            sb.AppendLine($"Status: {(Status ? "1 - Ativo" : "0 - Inativo")}");

            return sb.ToString();
        }

    }
}