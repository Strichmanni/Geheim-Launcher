using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GeheimLauncher
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Geheim-Launcher started...");

            // Pfad zum Installationsverzeichnis
            string installDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles), "GeheimLauncher");

            // Erstellen des Installationsverzeichnisses, falls es nicht existiert
            if (!Directory.Exists(installDirectory))
            {
                Directory.CreateDirectory(installDirectory);
            }

            // GitHub Repository URL
            string repoUrl = "https://api.github.com/repos/Strichmanni/files-ext/contents";
            List<RepositoryFile> repositoryFiles = await DownloadRepositoryFiles(repoUrl);

            // Herunterladen und Installieren der Anwendungen
            await DownloadAndInstallApps(repositoryFiles, installDirectory);

            // Anzeigen der installierten Apps
            Console.WriteLine("Installed Apps:");
            foreach (var file in repositoryFiles)
            {
                Console.WriteLine($"{file.Name} - {file.LocalPath}");
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        static async Task<List<RepositoryFile>> DownloadRepositoryFiles(string repoUrl)
        {
            List<RepositoryFile> files = new List<RepositoryFile>();

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("User-Agent", "Geheim-Launcher");

                try
                {
                    // Abrufen der Dateiliste aus dem GitHub-Repository
                    HttpResponseMessage response = await client.GetAsync(repoUrl);
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();
                    JArray jsonFiles = JArray.Parse(responseBody);

                    // Extrahieren und Hinzufügen der Dateien zur Liste
                    foreach (var file in jsonFiles)
                    {
                        string name = file["name"].ToString();
                        string downloadUrl = file["download_url"].ToString();
                        files.Add(new RepositoryFile { Name = name, DownloadUrl = downloadUrl });
                    }
                }
                catch (HttpRequestException ex)
                {
                    Console.WriteLine($"Error retrieving repository files: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }

            return files;
        }

        static async Task DownloadAndInstallApps(List<RepositoryFile> files, string installDirectory)
        {
            using (HttpClient client = new HttpClient())
            {
                foreach (var file in files)
                {
                    string savePath = Path.Combine(installDirectory, file.Name);

                    try
                    {
                        Console.WriteLine($"Downloading {file.Name}...");
                        using (var response = await client.GetAsync(file.DownloadUrl))
                        using (var fileStream = new FileStream(savePath, FileMode.Create, FileAccess.Write, FileShare.None))
                        {
                            await response.Content.CopyToAsync(fileStream);
                        }

                        file.LocalPath = savePath;
                        Console.WriteLine($"Installed {file.Name} successfully.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error downloading/installing {file.Name}: {ex.Message}");
                    }
                }
            }
        }
    }

    public class RepositoryFile
    {
        public string Name { get; set; }
        public string DownloadUrl { get; set; }
        public string LocalPath { get; set; }
    }
}
