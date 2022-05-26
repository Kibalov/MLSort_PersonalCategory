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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string Output;
        List<ImageFolderButton> imageFolderButtons = new List<ImageFolderButton>();
        ImagePaths imagepaths;
        int PicCounter = 0;

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InformationForm information = new InformationForm();
            information.ShowDialog();
        }

        private void указатьСортировочнуюПапкуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                Output = folderBrowserDialog1.SelectedPath;
            }

        }

        private void AddSortFolder(object sender, EventArgs e)
        {
            if (imageFolderButtons.Count+1 < (this.Height - 150) / 50)
            {
                DialogResult result = folderBrowserDialog1.ShowDialog();
                if (result == DialogResult.OK)
                {
                    bool check = true;
                    ImageFolderButton imageFolderButton= new ImageFolderButton(button1.Location.X, button1.Location.Y, folderBrowserDialog1.SelectedPath);
                    for (int i = 0; i < imageFolderButtons.Count; i++)
                        if (imageFolderButtons[i].ImageFolderPath == imageFolderButton.ImageFolderPath)
                            check = false;

                    if (check)
                    {
                        imageFolderButton.Click += MoveImageClick;
                        imageFolderButton.remove_butt.Click += RemoveButton;
                        imageFolderButtons.Add(imageFolderButton);
                        RelocateButtons();
                        this.Controls.Add(imageFolderButton);
                        this.Controls.Add(imageFolderButton.remove_butt);
                    }
                    else
                        MessageBox.Show("Папка с таким именем уже есть!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Недостаточно места для новой кнопки!\nУдалите уже существующие или увеличьте окно.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        
        public void MoveImageClick(object sender, EventArgs e)
        {
            foreach (ImageFolderButton imbutt in imageFolderButtons.ToArray())
                if (imbutt.ClickCheck())
                {
                    string name = imagepaths.images[PicCounter].Substring(imagepaths.images[PicCounter].LastIndexOf("\\") + 1);
                    pictureBox1.Image.Save(Path.Combine(imbutt.ImageFolderPath, name));
                    imbutt.button_unclick();
                }
            PicCounter++;
            setimage();
        }

        public void RemoveButton(object sender, EventArgs e)
        {
            foreach (ImageFolderButton imbutt in imageFolderButtons.ToArray())
                if (imbutt.ClickCheck())
                {
                    this.Controls.Remove(imbutt);
                    this.Controls.Remove(imbutt.remove_butt);
                    imageFolderButtons.Remove(imbutt);
                    RelocateButtons();
                }
        }

        private void RelocateButtons()
        {
            for (int i = 0; i < imageFolderButtons.Count; i++)
            {
                imageFolderButtons[i].Location = new Point(12, Height - 90 - 50 * (i));
                imageFolderButtons[i].remove_butt.Location = new Point(110 + 12, Height - 90 - 50 * (i));
            }
            button1.Location = new Point(12, Height - 92 - 50 * (imageFolderButtons.Count));
        }

        private void начатьРучнуюСортировкуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Output != null)
            {
                if (imageFolderButtons.Count > 0)
                {
                    imagepaths = new ImagePaths(Output);

                    if (imagepaths.images.Length == 0)
                    {
                        MessageBox.Show("В сортируемой папке изображения не найдены!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        setimage();
                        for (int i = 0; i < imageFolderButtons.Count; i++)
                        {
                            imageFolderButtons[i].Enabled = true;
                            imageFolderButtons[i].remove_butt.Enabled = false;
                        }
                        остановитьРучнуюСортировкуToolStripMenuItem.Enabled = true;
                        начатьРучнуюСортировкуToolStripMenuItem.Enabled = false;
                        начатьСортировкуПриПомощиИИToolStripMenuItem.Enabled = false;
                        указатьСортировочнуюПапкуToolStripMenuItem.Enabled = false;
                        button2.Enabled = true;
                    }
                }
                else
                    MessageBox.Show("Дожна присутствовать хотя бы одна выгрузочная папка!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Сортируемая папка указана не верно!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void остановитьРучнуюСортировкуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            начатьРучнуюСортировкуToolStripMenuItem.Enabled = true;
            остановитьРучнуюСортировкуToolStripMenuItem.Enabled = false;
            начатьСортировкуПриПомощиИИToolStripMenuItem.Enabled = true;
            указатьСортировочнуюПапкуToolStripMenuItem.Enabled = true;
            button2.Enabled = false;
            for (int i = 0; i < imageFolderButtons.Count; i++)
            {
                imageFolderButtons[i].Enabled = false;
                imageFolderButtons[i].remove_butt.Enabled = true;
            }
            PicCounter = 0;
            pictureBox1.Image = null;

            //var result = MessageBox.Show("Желаете ли удалить уже отсортированные изображения из сортируемо папки?", "Решение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //if (result == DialogResult.Yes)
            //{
            //    for (int i = 0; i < PicCounter; i++)
            //    {
            //        File.Delete(imagepaths.images[i]);
            //    }
                    
            //}
        }

        private void setimage()
        {
            pictureBox1.Image = null;
            if (PicCounter < imagepaths.images.Length)
                pictureBox1.Image = new Bitmap(imagepaths.images[PicCounter]);
            else
            {
                начатьРучнуюСортировкуToolStripMenuItem.Enabled = true;
                остановитьРучнуюСортировкуToolStripMenuItem.Enabled = false;
                button2.Enabled = false;
                for (int i = 0; i < imageFolderButtons.Count; i++)
                    imageFolderButtons[i].Enabled = false;
                PicCounter = 0;
                MessageBox.Show("Изображения закончились!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void начатьСортировкуПриПомощиИИToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Output != null)
            {
                if (imageFolderButtons.Count > 0)
                {
                    imagepaths = new ImagePaths(Output);

                    if (imagepaths.images.Length == 0)
                    {
                        MessageBox.Show("В сортируемой папке изображения не найдены!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        bool check = true;
                        string[] paths = new string[imageFolderButtons.Count];
                        for (int i = 0; i < imageFolderButtons.Count; i++)
                        {
                            paths[i] = imageFolderButtons[i].ImageFolderPath;
                            ImagePaths imagepathscheck = new ImagePaths(paths[i]);
                            if (imagepathscheck.images.Length < 0)
                            {
                                MessageBox.Show("В папке \""+paths[i]+ "\" отсутствуют изображения для обучения!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                check = false;
                                break;
                            }

                        }
                        if (check)
                        {
                            MLsorter mLsorter = new MLsorter(Output, paths);
                        }

                    }
                }
                else
                    MessageBox.Show("Дожна присутствовать хотя бы одна выгрузочная (для обучения) папка!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Сортируемая папка указана не верно!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void SkipImageButtonClick(object sender, EventArgs e)
        {
            Directory.CreateDirectory(Path.Combine(Output, "Неотсортированные"));
            pictureBox1.Image.Save(Path.Combine(Output, "Неотсортированные", imagepaths.images[PicCounter].Substring(imagepaths.images[PicCounter].LastIndexOf("\\") + 1)));
            imagepaths.images[PicCounter] = null;
            PicCounter++;
            setimage();
        }

        private void инструкцияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InstructionForm instructionForm = new InstructionForm();
            instructionForm.ShowDialog();
        }
    }
}
