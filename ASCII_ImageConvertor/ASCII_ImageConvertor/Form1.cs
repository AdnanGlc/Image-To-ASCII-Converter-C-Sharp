using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASCII_ImageConvertor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            string FilePath = openFileDialog1.FileName;
            pictureBox1.Image = Image.FromFile(FilePath);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string Palet=comboBox1.Text;
            if(Palet=="")
            {
                MessageBox.Show("Chose ASCII palet");
                return;
            }
            Bitmap Picture = (Bitmap)pictureBox1.Image.Clone();
            int width = Picture.Width, height = Picture.Height;

            string Palet2 = "";
            for (int i = 0; i < Palet.Length; i++)
                for (int j = 0; j <= 256 / Palet.Length; j++)
                    if (radioButton1.Checked) Palet2 += Palet[i];
                    else Palet2 = Palet[i] + Palet2;
            System.Console.Write(Palet2);
            Color Shade;
            string ASCIIimage = "";

            groupBox2.Visible = true;
            int Counter=0;
            progressBar1.Maximum = height;
            for(int i=0;i<height;i++)
            {
                for(int j=0;j<width;j++)
                {
                    Shade = Picture.GetPixel(j, i);
                    ASCIIimage += Palet2[(Shade.R + Shade.G + Shade.B) / 3];
                }
                ASCIIimage += '\n';
                progressBar1.Value = Counter++;
            }
            richTextBox1.Text = ASCIIimage;
            groupBox2.Visible = false;
        }
    }
}
