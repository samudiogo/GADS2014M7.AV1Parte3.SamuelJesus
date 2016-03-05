using System.IO;

namespace GADS2014M7.AV1Parte3.Domain.Services
{
    public class FileService
    {
        public static void LogData(string path, string data)
        {
            using (var sw = File.AppendText(path))
            {
                sw.WriteLine(data);
            }
        }
    }
}