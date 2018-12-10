using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Policy;

namespace ConsoleUI
{
    class Program
    {
        private static string rootPath = @"C:\Teste";
        static void Main(string[] args)
        {

            ListandoDiretorios(rootPath);
            ListandoArquivos(rootPath);
            VerificandoDiretorios(rootPath);
            CopiandoMovendoArquivos(rootPath);
            Console.ReadLine();
        }

        public static void ListandoDiretorios(string rootPath)
        {
            #region Listando Diretórios
            string[] dirs = Directory.GetDirectories(rootPath, "*", SearchOption.AllDirectories);

            foreach (var dir in dirs)
            {
                Console.WriteLine(dir);
            }
            #endregion
        }

        public static void ListandoArquivos(string rootPath)
        {
            #region Listando Arquivos

            var files = Directory.GetFiles(rootPath, "*", SearchOption.AllDirectories);
            foreach (var file in files)
            {
                Console.WriteLine(file);
                Console.WriteLine(Path.GetFileName(file));
                Console.WriteLine(Path.GetFileNameWithoutExtension(file));
                Console.WriteLine(Path.GetFullPath(file));
                Console.WriteLine(Path.GetDirectoryName(file));
                var info = new FileInfo(file);
                Console.WriteLine($"{Path.GetFileName(file)}: {info.Length} bytes");
            }

            #endregion
        }

        public static void VerificandoDiretorios(string rootPath)
        {

            #region Verificando Diretórios
            string newPath = @"C:\Teste2";
            bool directoryExists = Directory.Exists(@"C:\Teste2");

            if (directoryExists)
            {
                Console.WriteLine("The Directory exists");
            }
            else
            {
                Console.WriteLine("The Directory does not exists");
                Directory.CreateDirectory(newPath);
            }

            #endregion
        }

        public static void CopiandoMovendoArquivos(string rootPath)
        {
            #region Copiando/movendo Arquivos
            
            string[] files = Directory.GetFiles(rootPath);
            string destinationFolder = @"C:\TesteDestination";

            //Copiando arquivos
            foreach (var file in files)
            {
                File.Copy(file, $"{destinationFolder}{Path.GetFileName(file)}", true);
            }

            // Copiando arquvios 2
            for (int i = 0; i < files.Length; i++)
            {
                File.Copy(files[i], $"{destinationFolder}{i}.txt", true);
            }

            ///Movendo arquivos
            foreach (var file in files)
            {
                File.Move(file, $"{destinationFolder}{Path.GetFileName(file)}");
            }

            #endregion
            
        }

    }


}
