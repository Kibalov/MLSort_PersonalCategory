using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace CourseWork5
{
    public partial class ImagesDisplayForm : Form
    {
        List<ImgBox> imgBoxes;
        string Output;
        int ImageMove = 0;
        public ImagesDisplayForm(IEnumerable<ImagePrediction> imagePredictionData, string Output)
        {
            InitializeComponent();
            this.Output = Output;
            imgBoxes = new List<ImgBox>();
            foreach (ImagePrediction prediction in imagePredictionData)
            {
                ImgBox imgBox = new ImgBox(prediction.PredictedLabelValue, prediction.ImagePath, Output);
                imgBoxes.Add(imgBox);
                Controls.Add(imgBox);
                Controls.Add(imgBox.Label1);
            }
            LocateImgBoxes();
        }

        private void LocateImgBoxes()
        {
            bool Border = false;
            for (int i = 0; i < 100; i++)
            {
                for (int j = 0; j < Width / 120; j++) 
                {
                    if ((i)*(Width/120)+j < imgBoxes.Count)
                    {
                        imgBoxes[(i) * (Width / 120) + j].Location = new Point(j * 120 + 20, i * 120 + 20 - ImageMove * 120);
                        imgBoxes[(i) * (Width / 120) + j].Label1.Location = new Point(j * 120 + 20, i * 120 + 120 - ImageMove * 120);
                    }
                    else
                    {
                        Border = true;
                        break;
                    }

                    if ((Height / 120) * (Width / 120) - imgBoxes.Count < 0)
                        vScrollBar1.Maximum = imgBoxes.Count / (Width / 120) - Height / 120;
                    else
                        vScrollBar1.Maximum = 0;
                }
                if (Border)
                    break;
            }

        }

        private void ImagesDisplay_Resize(object sender, EventArgs e)
        {
            LocateImgBoxes();
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            ImageMove = vScrollBar1.Value;
            LocateImgBoxes();
        }

        private void FinalSortImages_Click(object sender, EventArgs e)
        {
            Directory.CreateDirectory(Path.Combine(Output, "Неотсортированные"));
            foreach(ImgBox imgBox in imgBoxes)
            {
                if (!imgBox.Clicked_return())
                {
                    try
                    {
                        imgBox.Image.Save(Path.Combine(imgBox.imgpath, imgBox.ImgName));
                    }
                    catch { }
                }
                else
                {
                    try
                    {
                        imgBox.Image.Save(Path.Combine(Output, "Неотсортированные", imgBox.ImgName));
                    }
                    catch { }
                }
            }
            MessageBox.Show("Успешно!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }
    }
}
