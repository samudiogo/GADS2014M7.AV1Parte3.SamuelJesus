using System;
using static System.Console;
using GADS2014M7.AV1Parte3.Domain.Services;

namespace GADS2014M7.AV1Parte3.Presentation.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            const string defaultPath = @"ExportaAlunos-Samuel.Jesus.xml";


            Clear();//limpa o console de qualquer outro texto...
            WriteLine("Trabalho de C# - GADS2014T3M 7º Ciclo - .NET II - Prof Paulo Maurício");
            WriteLine("========================================================================");
            WriteLine("Digite caminho do arquivo OU deixe em branco para abrir o arquivo default e aperte a tecla ENTER:");
            var userPath = ReadLine();
            //se o usuário não digitar o arquivo, ele usa o padrão
            var path = string.IsNullOrWhiteSpace(userPath) ? defaultPath : @userPath;
            WriteLine($"Importando os dados do arquivo \"{path}\"...");

            try
            {
                ;
                //carrega o xml
                var service = new XmlServiceBase();

                var xmldoc = service.LoadlXmlDocument(path);
                var newFilename = $"ExportaAlunos-Samuel.Jesus-{DateTime.Now.ToString("yyyyMMdd-Hms")}";

                var logpathTxt = $"{newFilename}-Log.txt";

                service.ImportDataFromXml(xmldoc, @logpathTxt);
        
                service.RenameXmlFile(path, newFilename);


                //imprimo o novo nome do arquivo XML:
                WriteLine($"\n\nArquivo importado e renomeado: \"{newFilename}.xml\"\n\n");

                //crio uma instancia de Aluno e chamo o método para gravar o arquivo txt
                //new Aluno(path).GravaAlunosTxt(alunos);

            }
            catch (Exception e)
            {
                WriteLine(e.Message);
            }
            finally
            {
                Write("\nObrigado por usar nosso programa!\nPress any key to continue . . .\n");
                ReadKey();
            }

        }
    }
}
