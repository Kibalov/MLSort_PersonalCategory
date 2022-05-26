using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

namespace CourseWork5
{
    class ImageFolderButton : Button
    {
        public string ImageFolderPath { get; protected set; }
        public Button remove_butt { get; protected set; }
        bool Clicked = false;

        public ImageFolderButton(int x, int y, string folder)
        {
            this.Size = new Size(100, 40);
            this.Location = new Point(x, y);
            this.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
            this.Enabled = false;

            ImageFolderPath = folder;
            this.Text = "";
            this.Text = ImageFolderPath.Substring(ImageFolderPath.LastIndexOf("\\")+1);
            this.Click += button_click;

            remove_butt = new Button
            {
                Size = new Size(40, 40),
                Location = new Point(x + 110, y),
                Anchor = (AnchorStyles.Bottom | AnchorStyles.Left),
                Text = "-"
            };
            remove_butt.Click += button_click;
        }
        public bool ClickCheck()
        {
            return Clicked;
        }
        public void button_unclick()
        {
            Clicked = false;
        }
        private void button_click(object sender, EventArgs e)
        {
            Clicked = true;
        }
        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ResumeLayout(false);
        }
    }
}
