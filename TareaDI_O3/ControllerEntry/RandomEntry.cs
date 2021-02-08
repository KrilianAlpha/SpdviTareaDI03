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
        public event EventHandler<EventArgs> ProId;

        private void ClickProductEventArg(object sender, EventArgs e)
        {
            
            ProductId = int.Parse(((Button)sender).Name);
            ProId?.Invoke(this, EventArgs.Empty);
        }
        private int _ProductModelID;
        public int ProductModelID
        {
            get { return _ProductModelID; }
            set => label1.Text = value.ToString();
        }
        private int _ProductId;
        public int ProductId
        {
            get { return _ProductId; }
            set { _ProductId = value; }
        }
        private string _SizePro;
        public string SizePro
        {
            get { return _SizePro; }
            set => label9.Text = value; 
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
            Product theone = new Product();
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
                var products = productModel.List.GroupBy(x => x.Size).Select(x => x.First()).ToList();

                int minimum = int.MaxValue;
                foreach (Product product in products)
                {
                    
                    if (product.Size == null)
                    {
                        theone = product;
                    }
                    else
                    {
                        if (product.Size == "XL")
                        {
                            Console.WriteLine("XL Reached");
                        }
                        else if (product.Size == "L")
                        {
                            theone = product;
                        } 
                        else if (product.Size == "M")
                        {
                            theone = product;
                        }
                        else if (product.Size == "S")
                        {
                            theone = product;
                        }
                        else
                        {
                            int num = int.Parse(product.Size);
                            if (num < minimum)
                            {
                                minimum = num;
                                theone = product;
                            }
                        }
                        Button sizeBtn = new Button();
                        sizeBtn.Text = product.Size;
                        sizeBtn.Name = product.ProductId.ToString();
                        sizeBtn.Click += ClickProductEventArg;
                        flowLayoutPanel1.Controls.Add(sizeBtn);
                    }
                }
                label3.Text = theone.Listprice.ToString();
                label8.Text = theone.ProductId.ToString();
            }
        }
    }
}
