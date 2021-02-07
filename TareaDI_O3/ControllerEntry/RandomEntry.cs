using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControllerEntry
{
    public partial class RandomEntry : UserControl
    {
        public int ProductModelID
        {
            get => int.Parse(label1.Text);
            set => label1.Text = value.ToString();
        }
        
        public RandomEntry()
        {
            InitializeComponent();
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(pictureBox1, "Click to display another product");
        }

        private void Random()
        {
            Random rnd = new Random();
            int product = rnd.Next(1, 128);
            label1.Text = product.ToString();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Random();
        }

        private void label1_TextChanged(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            var productModel = DataAccess.GetProductModel(int.Parse(label1.Text));
            if (productModel == null)
            {
                Random();
            } else
            {
                label2.Text = productModel.Name;
                MemoryStream ms = new MemoryStream(productModel.LargePhoto);
                Image largePhoto = Image.FromStream(ms);
                pictureBox1.Image = largePhoto;

                productModel.List = DataAccess.GetProducts(int.Parse(label1.Text));
                label3.Text = productModel.List.Min(product => product.price.ToString());
                foreach (Product product in productModel.List)
                {
                    if (product.Size == null)
                    {
                    /*pos no se*/
                    } else
                    {
                        Button sizeBtn = new Button();
                        sizeBtn.Text = product.Size;
                        sizeBtn.Name = product.ProductId.ToString();
                        flowLayoutPanel1.Controls.Add(sizeBtn);
                    }
                }
            }
        }
    }
}
