using System;
using System.Windows.Forms;

namespace GeheimLauncher
{
    public partial class InstallationForm : Form
    {
        public InstallationForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // InstallationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 400);
            this.Name = "InstallationForm";
            this.Text = "Installationen";
            this.ResumeLayout(false);
        }
    }
}
