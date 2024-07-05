using System;
using System.Windows.Forms;

namespace GeheimLauncher
{
    public partial class MainForm : Form
    {
        private Panel panelSidebar;
        private Button buttonHome;
        private Button buttonInstallations;
        private Button buttonAddons;

        public MainForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.panelSidebar = new Panel();
            this.buttonHome = new Button();
            this.buttonInstallations = new Button();
            this.buttonAddons = new Button();
            this.SuspendLayout();
            // 
            // panelSidebar
            // 
            this.panelSidebar.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panelSidebar.Dock = DockStyle.Left;
            this.panelSidebar.Width = 200;
            this.panelSidebar.AutoScroll = true;

            // 
            // buttonHome
            // 
            this.buttonHome.Location = new System.Drawing.Point(10, 10);
            this.buttonHome.Text = "Home";
            this.buttonHome.Click += new EventHandler(this.buttonHome_Click);

            // 
            // buttonInstallations
            // 
            this.buttonInstallations.Location = new System.Drawing.Point(10, 50);
            this.buttonInstallations.Text = "Installationen";
            this.buttonInstallations.Click += new EventHandler(this.buttonInstallations_Click);

            // 
            // buttonAddons
            // 
            this.buttonAddons.Location = new System.Drawing.Point(10, 90);
            this.buttonAddons.Text = "Addons";
            this.buttonAddons.Click += new EventHandler(this.buttonAddons_Click);

            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelSidebar);
            this.Controls.Add(this.buttonHome);
            this.Controls.Add(this.buttonInstallations);
            this.Controls.Add(this.buttonAddons);
            this.Name = "MainForm";
            this.Text = "Geheim Launcher";
            this.ResumeLayout(false);
        }

        private void buttonHome_Click(object sender, EventArgs e)
        {
            OpenForm(new HomeForm());
        }

        private void buttonInstallations_Click(object sender, EventArgs e)
        {
            OpenForm(new InstallationForm());
        }

        private void buttonAddons_Click(object sender, EventArgs e)
        {
            OpenForm(new AddonsForm());
        }

        private void OpenForm(Form form)
        {
            panelSidebar.Controls.Clear();
            form.TopLevel = false;
            form.AutoScroll = true;
            form.Dock = DockStyle.Fill;
            panelSidebar.Controls.Add(form);
            form.Show();
        }

        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
