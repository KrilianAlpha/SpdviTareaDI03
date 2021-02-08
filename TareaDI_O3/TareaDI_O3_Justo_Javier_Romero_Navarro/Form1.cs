using ControllerEntry;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TareaDI_O3_Justo_Javier_Romero_Navarro
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int product = rnd.Next(1, 128);
            randomEntry1.ProductModelID = product;
        }

        private void textBox1_MouseHover(object sender, EventArgs e)
        {
            /*toolTip1.SetToolTip(textBox1, "Edit this Camp And then Click on the search Button to search a Product by it's Product ID");*/
        }

        private void randomEntry1_ProId(object sender, EventArgs e)
        {
            textBox1.Text = randomEntry1.ProductId.ToString();
        }

        /*private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "S")
            {
                randomEntry1.SizePro = textBox2.Text;
                textBox2.Text = "";
            }else if (textBox2.Text == "M")
            {
                randomEntry1.SizePro = textBox2.Text;
                textBox2.Text = "";
            }
            else if (textBox2.Text == "L")
            {
                randomEntry1.SizePro = textBox2.Text;
                textBox2.Text = "";
            }
            else if (textBox2.Text == "XL")
            {
                randomEntry1.SizePro = textBox2.Text;
                textBox2.Text = "";
            }
            else if (int.TryParse(textBox2.Text, out int yeah) == false)
            {
                textBox2.Text = "Try with S,M,L,XL or 38~70";
            }
            else if (int.Parse(textBox2.Text) >= 38 || int.Parse(textBox2.Text) <= 70)
            {
                randomEntry1.SizePro = textBox2.Text;
                textBox2.Text = "";
            }
        }*/
    }
}
