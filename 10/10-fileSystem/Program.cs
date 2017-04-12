using System;
using System.IO;
using static System.Console;
using static System.IO.Directory;

namespace _10_1
{
    class Program
    {
        static void Main(string[] args)
        {
            // define a directory path
            // string dir = @"C:\Code\Ch10_Example"; // Windows
            string dir = @"/Users/mick/Documents/dotnet/dotnetTut/10/10-1/Ch10_Example/"; // macOS
            // check if it exists
            WriteLine($"Does {dir} exist? {Exists(dir)}");
            // create a directory
            CreateDirectory(dir);
            WriteLine($"Does {dir} exist? {Exists(dir)}");
            // delete a directory
            Delete(dir);
            WriteLine($"Does {dir} exist? {Exists(dir)}");


            // string textFile = @"C:\Code\Ch10.txt"; // Windows
            // string backupFile = @"C:\Code\Ch10.bak"; // Windows
            string textFile = @"/Users/mick/Documents/dotnet/dotnetTut/10/10-1/Ch10.txt"; // macOS
            string backupFile = @"/Users/mick/Documents/dotnet/dotnetTut/10/10-1/Ch10.bak"; // macOS
            // check if a file exists
            WriteLine($"Does {textFile} exist? {File.Exists(textFile)}");
            // create a new text file and write a line to it
            StreamWriter textWriter = File.CreateText(textFile);
            textWriter.WriteLine("Hello, C#!");
            textWriter.Dispose();
            WriteLine($"Does {textFile} exist? {File.Exists(textFile)}");
            // copy a file and overwrite if it already exists
            File.Copy(textFile, backupFile, true);
            WriteLine($"Does {backupFile} exist? {File.Exists(backupFile)}");
            // delete a file
            File.Delete(textFile);
            WriteLine($"Does {textFile} exist? {File.Exists(textFile)}");
            // read from a text file
            StreamReader textReader = File.OpenText(backupFile);
            WriteLine(textReader.ReadToEnd());
            textReader.Dispose();

            WriteLine($"File Name: {Path.GetFileName(textFile)}");
            WriteLine($"File Name without Extension: {Path.GetFileNameWithoutExtension(textFile)}");
            WriteLine($"File Extension: {Path.GetExtension(textFile)}");
            WriteLine($"Random File Name: {Path.GetRandomFileName()}");
            WriteLine($"Temporary File Name: {Path.GetTempFileName()}");

            var info = new FileInfo(backupFile);
            WriteLine($"{backupFile} contains {info.Length} bytes.");
            WriteLine($"{backupFile} was last accessed {info.LastAccessTime}.");
            WriteLine($"{backupFile} has readonly set to {info.IsReadOnly}.");
    
        }
    }
}
