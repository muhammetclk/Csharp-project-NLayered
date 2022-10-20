using Northwind.Business.Abstract;
using Northwind.Business.Concrete;
using Northwind.DataAccess.Abstract;
using Northwind.DataAccess.Concrete.EntityFramework;
using Northwind.DataAccess.Concrete.NHibernate;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Northwind.WebFormsUl
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //burayi ilerde düzelticez.
            _productService = new ProductManager(new EfProductDal());
        }
        IProductService _productService;

        private void Form1_Load(object sender, EventArgs e)
        {
            //buradan business'a erislir.ProductDal yasak.


            //ProductManager productManager = new ProductManager(new NhProductDal());//ProductManager bizden bir IProductDal istiyor ona hem EfProductDal hem de NhProductDal verebliriz.
            //farkli katmandan newleme  yapmamaliyiz.O yuzden IProductService tipinde tanimliyoruz.
            

            dgwProduct.DataSource = _productService.GetAll();
        }
    }
}
