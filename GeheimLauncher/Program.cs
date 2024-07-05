using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Terminal.Gui;

namespace GeheimLauncher
{
    class Program
    {
        static void Main(string[] args)
        {
            Application.Init();

            // Erstellen und anzeigen des Hauptfensters
            var mainWindow = new MainWindow();
            Application.Top.Add(mainWindow);

            Application.Run();
        }
    }

    public class MainWindow : Window
    {
        private ListView installedAppsListView;
        private MenuBar menu;

        public MainWindow() : base("Geheim-Launcher")
        {
            // Erstellen des Menüs
            menu = new MenuBar(new MenuBarItem[]
            {
                new MenuBarItem("_Menu", new MenuItem[]
                {
                    new MenuItem("_Home", "View installed applications"),
                    new MenuItem("_Installations", "Install new applications"),
                    new MenuItem("_Addons", "Manage addons"),
                    new MenuItem("_Quit", "", () => Application.RequestStop())
                })
            });
            Add(menu);

            // Erstellen der Liste für installierte Apps
            installedAppsListView = new ListView(new List<string> 
            {
                "GeheimDevKit.exe - C:\\Program Files\\GeheimDevKit",
                "GeheimStudios.exe - C:\\Program Files\\GeheimStudios",
                "InfinityEngine.exe - C:\\Program Files\\InfinityEngine",
                "GeheimCodeSDK - C:\\Program Files\\GeheimCodeSDK",
                "Gstream.exe - C:\\Program Files\\Gstream"
            });
            installedAppsListView.Width = Dim.Fill();
            installedAppsListView.Height = Dim.Fill() - 1;
            installedAppsListView.SelectedItemChanged += OnAppSelected;
            Add(installedAppsListView);
        }

        private void OnAppSelected(ListViewItemEventArgs args)
        {
            var selectedApp = installedAppsListView.SelectedItem.ToString();
            string appName = selectedApp.Split('-')[0].Trim();
            string appPath = selectedApp.Split('-')[1].Trim();

            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = Path.Combine(appPath, $"{appName}.exe"),
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.ErrorQuery("Error", $"Failed to start {appName}: {ex.Message}", "OK");
            }
        }
    }
}
