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
namespace Slaydy
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.timer1.Interval = 1000;
            this.timer1.Enabled = true;
            this.timer1.Stop();
            this.folderBrowserDialog1.Description = "Виберіть, будь-ласка, каталог з файлами типу .jpg (фотографії).";
            this.folderBrowserDialog1.ShowNewFolderButton = false;
            this.folderBrowserDialog1.RootFolder = Environment.SpecialFolder.MyComputer;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            DirectoryInfo d = new DirectoryInfo(folderBrowserDialog1.SelectedPath);
            int i;
            i = Convert.ToInt16(label2.Text);
            FileInfo[] fis = d.GetFiles("*.jpg");
            if (fis.GetLength(0) == 0) 
            {
                MessageBox.Show("Виберіть, будь-ласка, інший каталог. У цьому немає .jpg-файлів");
                return;
            }
            if (i > fis.GetLength(0))
            {
                i = 0;
                label2.Text = i.ToString();
            }
            pictureBox1.ImageLocation = fis[1].DirectoryName + "\\" + fis[i].Name;
                pictureBox1.Load();
                button2.Visible = true;
            }
       

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.button1.Text == "Старт")
            {
                this.button1.Text = "Стоп";
                this.timer1.Start();
                button2.Visible = false;
            }
            else
            {
                this.button1.Text = "Старт";
                this.timer1.Stop();
                button2.Visible = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.label1.Text = Convert.ToString(System.DateTime.Now);
            int i;
            i = Convert.ToUInt16(label2.Text);
            i++;
            label2.Text = i.ToString();
            DirectoryInfo d = new DirectoryInfo(folderBrowserDialog1.SelectedPath);
            FileInfo[] fis = d.GetFiles("*.jpg");
            if (i >= fis.GetLength(0))
            {
                i = 0; label2.Text = i.ToString();
            }
            {
                pictureBox1.ImageLocation = fis[i].DirectoryName + "\\" + fis[i].Name;
                pictureBox1.Load();

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

        
 

    