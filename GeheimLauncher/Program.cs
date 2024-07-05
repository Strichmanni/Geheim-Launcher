using System;
using System.Diagnostics;
using System.IO;

namespace GeheimLauncher
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Geheim-Launcher gestartet...");

            string programFiles = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
            string programFilesX86 = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86);

            LaunchProgramsInDirectory(programFiles);
            LaunchProgramsInDirectory(programFilesX86);

            Console.WriteLine("Drücken Sie eine beliebige Taste, um zu beenden...");
            Console.ReadKey();
        }

        static void LaunchProgramsInDirectory(string directory)
        {
            if (Directory.Exists(directory))
            {
                string[] directories = Directory.GetDirectories(directory);
                foreach (string dir in directories)
                {
                    string exePath = Path.Combine(dir, Path.GetFileName(dir) + ".exe");
                    if (File.Exists(exePath))
                    {
                        try
                        {
                            Process.Start(exePath);
                            Console.WriteLine($"Gestartet: {exePath}");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Fehler beim Starten von {exePath}: {ex.Message}");
                        }
                    }
                }
            }
        }
    }
}
