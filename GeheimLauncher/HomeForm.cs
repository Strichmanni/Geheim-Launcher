using System;
using System.Windows.Forms;

namespace GeheimLauncher
{
    public partial class HomeForm : Form
    {
        public HomeForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // HomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 400);
            this.Name = "HomeForm";
            this.Text = "Home";
            this.ResumeLayout(false);
        }
    }
}
