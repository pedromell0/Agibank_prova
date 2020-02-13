using System;
using System.IO;
using System.Security.Permissions;
using System.Text;
using Domain.Entities;

namespace AGIBANK_Desafio
{
    public class Program
    {

        private static string HOMEPATH;

        static void Main(string[] args)
        {
            HOMEPATH = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            Run();
        }

        //[PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        private static void Run()
        {
            // Create a new FileSystemWatcher and set its properties.
            using (FileSystemWatcher watcher = new FileSystemWatcher())
            {
                watcher.Path = string.Concat(HOMEPATH, @"\data\in");

                // Watch for changes in LastAccess and LastWrite times, and
                // the renaming of files or directories.
                watcher.NotifyFilter = NotifyFilters.LastAccess
                                     | NotifyFilters.LastWrite
                                     | NotifyFilters.FileName
                                     | NotifyFilters.DirectoryName;

                // Only watch text files.
                watcher.Filter = "*.txt";

                // Add event handlers.
                watcher.Changed += OnChanged;
                watcher.Created += OnChanged;
                watcher.Deleted += OnDeleted;
                watcher.Renamed += OnRenamed;

                // Begin watching.
                watcher.EnableRaisingEvents = true;

                // Wait for the user to quit the program.
                Console.WriteLine("Press 'q' to quit the sample.");
                while (Console.Read() != 'q') ;
            }
        }

        private static void OnChanged(object source, FileSystemEventArgs file)
        {
            SaleLot saleLot = new SaleLot(file.Name, file.FullPath);
            
            const Int32 BufferSize = 128;
            using (var fileStream = new FileStream(saleLot.FilePath,FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize))
                {
                    String line;
                    while ((line = streamReader.ReadLine()) != null) {
                        saleLot.HandleFileLine(line);                        
                    };
                }
            }

            string path = string.Concat(HOMEPATH, @"\data\out\", file.Name);

            // Delete file if exists
            if (File.Exists(path))
            {
                File.Delete(path);
            }

            // Create a file to write to.
            using (StreamWriter sw = File.CreateText(path))
            {
                sw.WriteLine($"Quantidade de clientes no arquivo de entrada: {saleLot.Clients.Count} ");
                sw.WriteLine($"Quantidade de vendedores no arquivo de entrada: {saleLot.Salesmans.Count}");
                sw.WriteLine($"ID da venda mais cara: {saleLot.GetMostExpensiveSaleId()}");
                sw.WriteLine($"O pior vendedor: {saleLot.GetWhorstSalesman()} ");
                if(saleLot.Errors.Count > 0)
                {
                    sw.WriteLine($"\n Erros: \n {saleLot.GetErrors()}");
                }
            }
        }

        private static void OnDeleted(object source, FileSystemEventArgs e) =>
            // Delete outer file.
            File.Delete(string.Concat(HOMEPATH, @"\data\out\", e.Name));

        private static void OnRenamed(object source, RenamedEventArgs e) =>
            // Specify what is done when a file is renamed.
            Console.WriteLine($"File: {e.OldFullPath} renamed to {e.FullPath}");
    }
}
