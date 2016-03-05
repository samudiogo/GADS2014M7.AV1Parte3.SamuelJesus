using System;
using System.IO;
using System.Xml;
using GADS2014M7.AV1Parte3.Domain.Data;

namespace GADS2014M7.AV1Parte3.Domain.Services
{
    public class XmlServiceBase
    {

        public XmlDocument LoadlXmlDocument(string path)
        {

            if (!File.Exists(@path))
                throw new FileNotFoundException("Não foi possível encontrar o arquivo");

            //XmlDocument carrega o arquivo vindo do Path
            var xml = new XmlDocument();
            xml.Load(path);
            return xml;
        }

        public void RenameXmlFile(string path, string newFileName)
        {
            if (!File.Exists(path)) throw new FileNotFoundException("Arquivo não encontrado");

            File.Move(path, newFileName);
        }

        public void ImportDataFromXml(XmlDocument document, string logPath)
        {
            //percore o documento xml e gera uma lista de elementos "aluno"
            var xnList = document.GetElementsByTagName("Aluno");

            if (xnList.Count == 0)
                throw new NullReferenceException($"Não há itens \"Aluno\" na lista, verifique se o arquivo \"{document.LocalName}\" está correto.");

            //retorna uma lista de Alunos Convertida de XmlNode para Aluno usando uma expressão LINQ

            var dbService = new DbService();

            foreach (XmlNode node in xnList)
            {
                var aluno = new Aluno
                {
                    Matricula = Convert.ToInt32(node["Matricula"]?.InnerText),
                    Nome = $"{node["Nome"]?.InnerText} {node["Sobrenome"]?.InnerText}",
                    Status = Convert.ToBoolean(node["StatusAluno"]?.InnerText == "1")
                };

                var dbMsg = dbService.AdicionaAluno(aluno);

                Console.WriteLine($"{aluno.ToString("N")}\n{dbMsg}");
                FileService.LogData(logPath, $"{aluno} - {dbMsg}");

                var curso = new Curso
                {
                    CodigoCurso = node["CodigoCurso"]?.InnerText,
                    Nome = node["Nome"]?.InnerText
                };

                dbMsg = dbService.AdicionaCurso(curso);

                Console.WriteLine($"{curso.ToString("N")}\n{dbMsg}");

                FileService.LogData(logPath, $"{curso} - {dbMsg}");
            }

        }
    }
}