using System;
using System.Windows.Forms;

namespace GeheimLauncher
{
    public partial class AddonsForm : Form
    {
        public AddonsForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // AddonsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 400);
            this.Name = "AddonsForm";
            this.Text = "Addons";
            this.ResumeLayout(false);
        }
    }
}
