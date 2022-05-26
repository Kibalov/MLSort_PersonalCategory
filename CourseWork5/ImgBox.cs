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
    public class ImgBox : PictureBox
    {
        public Label Label1 = new Label();
        public string imgpath { get; protected set; }
        bool Clicked = false;
        public string ImgName { get; protected set; }
        public ImgBox(string imgpath, string imgname, string Output)
        {
            ImgName = imgname;
            this.imgpath = imgpath;
            this.Size = new Size(100, 100);
            this.SizeMode = PictureBoxSizeMode.Zoom;
            this.Image = new Bitmap(Path.Combine(Output, ImgName));
            string tex = imgpath.Substring(imgpath.LastIndexOf("\\")+1);
            Label1.Text = tex;
            Label1.MaximumSize = new Size(100, 30);
            Click += Clicka;
        }
        private void Clicka(object sender, EventArgs e)
        {
            Clicked = !Clicked;
            if (Clicked)
                Label1.ForeColor = Color.Red;
            else
                Label1.ForeColor = Color.Black;
        }
        public bool Clicked_return()
        {
            return Clicked;
        }
    }
}
