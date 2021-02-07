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
            textBox1.Text = product.ToString();
            randomEntry1.ProductModelID = product;
        }
    }
}
