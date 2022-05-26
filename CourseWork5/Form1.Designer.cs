
namespace CourseWork5
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.начатьРучнуюСортировкуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.остановитьРучнуюСортировкуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.начатьСортировкуПриПомощиИИToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.помощьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.инструкцияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.указатьСортировочнуюПапкуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button2 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.начатьРучнуюСортировкуToolStripMenuItem,
            this.остановитьРучнуюСортировкуToolStripMenuItem,
            this.начатьСортировкуПриПомощиИИToolStripMenuItem});
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(95, 20);
            this.toolStripMenuItem2.Text = "Инструменты";
            // 
            // начатьРучнуюСортировкуToolStripMenuItem
            // 
            this.начатьРучнуюСортировкуToolStripMenuItem.Name = "начатьРучнуюСортировкуToolStripMenuItem";
            this.начатьРучнуюСортировкуToolStripMenuItem.Size = new System.Drawing.Size(276, 22);
            this.начатьРучнуюСортировкуToolStripMenuItem.Text = "Начать ручную сортировку";
            this.начатьРучнуюСортировкуToolStripMenuItem.Click += new System.EventHandler(this.начатьРучнуюСортировкуToolStripMenuItem_Click);
            // 
            // остановитьРучнуюСортировкуToolStripMenuItem
            // 
            this.остановитьРучнуюСортировкуToolStripMenuItem.Enabled = false;
            this.остановитьРучнуюСортировкуToolStripMenuItem.Name = "остановитьРучнуюСортировкуToolStripMenuItem";
            this.остановитьРучнуюСортировкуToolStripMenuItem.Size = new System.Drawing.Size(276, 22);
            this.остановитьРучнуюСортировкуToolStripMenuItem.Text = "Остановить ручную сортировку";
            this.остановитьРучнуюСортировкуToolStripMenuItem.Click += new System.EventHandler(this.остановитьРучнуюСортировкуToolStripMenuItem_Click);
            // 
            // начатьСортировкуПриПомощиИИToolStripMenuItem
            // 
            this.начатьСортировкуПриПомощиИИToolStripMenuItem.Name = "начатьСортировкуПриПомощиИИToolStripMenuItem";
            this.начатьСортировкуПриПомощиИИToolStripMenuItem.Size = new System.Drawing.Size(276, 22);
            this.начатьСортировкуПриПомощиИИToolStripMenuItem.Text = "Начать сортировку при помощи ИИ";
            this.начатьСортировкуПриПомощиИИToolStripMenuItem.Click += new System.EventHandler(this.начатьСортировкуПриПомощиИИToolStripMenuItem_Click);
            // 
            // помощьToolStripMenuItem
            // 
            this.помощьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.инструкцияToolStripMenuItem,
            this.оПрограммеToolStripMenuItem});
            this.помощьToolStripMenuItem.Name = "помощьToolStripMenuItem";
            this.помощьToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.помощьToolStripMenuItem.Text = "Помощь";
            // 
            // инструкцияToolStripMenuItem
            // 
            this.инструкцияToolStripMenuItem.Name = "инструкцияToolStripMenuItem";
            this.инструкцияToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.инструкцияToolStripMenuItem.Text = "Инструкция";
            this.инструкцияToolStripMenuItem.Click += new System.EventHandler(this.инструкцияToolStripMenuItem_Click);
            // 
            // оПрограммеToolStripMenuItem
            // 
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.оПрограммеToolStripMenuItem.Text = "О программе";
            this.оПрограммеToolStripMenuItem.Click += new System.EventHandler(this.оПрограммеToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.toolStripMenuItem2,
            this.помощьToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(784, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.указатьСортировочнуюПапкуToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // указатьСортировочнуюПапкуToolStripMenuItem
            // 
            this.указатьСортировочнуюПапкуToolStripMenuItem.Name = "указатьСортировочнуюПапкуToolStripMenuItem";
            this.указатьСортировочнуюПапкуToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.указатьСортировочнуюПапкуToolStripMenuItem.Text = "Указать сортируемую папку";
            this.указатьСортировочнуюПапкуToolStripMenuItem.Click += new System.EventHandler(this.указатьСортировочнуюПапкуToolStripMenuItem_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(12, 430);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(150, 40);
            this.button1.TabIndex = 1;
            this.button1.Text = "Добавить папку";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.AddSortFolder);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pictureBox1.Location = new System.Drawing.Point(168, 27);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(604, 443);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(12, 27);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(150, 40);
            this.button2.TabIndex = 1;
            this.button2.Text = "Пропустить изображение";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.SkipImageButtonClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 482);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "Form1";
            this.Text = "Image sorter";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem помощьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem инструкцияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem указатьСортировочнуюПапкуToolStripMenuItem;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ToolStripMenuItem начатьРучнуюСортировкуToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem остановитьРучнуюСортировкуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem начатьСортировкуПриПомощиИИToolStripMenuItem;
        private System.Windows.Forms.Button button2;
    }
}

