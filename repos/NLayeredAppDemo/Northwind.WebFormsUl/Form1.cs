using Northwind.Business.Abstract;
using Northwind.Business.Concrete;
using Northwind.DataAccess.Abstract;
using Northwind.DataAccess.Concrete.EntityFramework;
using Northwind.DataAccess.Concrete.NHibernate;
using Northwind.Entities.Concrete;
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
            _categoryService = new CategoryManager(new EfCategoryDal());
        }
        IProductService _productService;
        ICategoryService _categoryService;
        void LoadProduct()
        {
            dgwProduct.DataSource = _productService.GetAll();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //buradan business'a erislir.ProductDal yasak.


            //ProductManager productManager = new ProductManager(new NhProductDal());//ProductManager bizden bir IProductDal istiyor ona hem EfProductDal hem de NhProductDal verebliriz.
            //farkli katmandan newleme  yapmamaliyiz.O yuzden IProductService tipinde tanimliyoruz.
            LoadProduct();
            LoadCategory();
            LoadCategoryId();
        }

        private void LoadCategory()
        {
            cbxCategory.DataSource = _categoryService.GetAll();
            cbxCategory.DisplayMember = "CategoryName";//görünen category adı olmali
            cbxCategory.ValueMember = "CategoryId";//sectigimizde ise ıd sindeki degerleri getirmeli
        }
        private void LoadCategoryId()
        {
            cbxCategoryId.DataSource = _categoryService.GetAll();
            cbxCategoryId.DisplayMember = "CategoryName";
            cbxCategoryId.ValueMember = "CategoryId";
            cbxCategoryIdUpdate.DataSource = _categoryService.GetAll();
            cbxCategoryIdUpdate.DisplayMember = "CategoryName";
            cbxCategoryIdUpdate.ValueMember = "CategoryId";
        }

        private void cbxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dgwProduct.DataSource = _productService.GetProductsByCategory(Convert.ToInt32(cbxCategory.SelectedValue));


            }
            catch
            {


            }
        }

        private void tbxProductName_TextChanged(object sender, EventArgs e)
        {
            string key = tbxProductName.Text;
            if (string.IsNullOrEmpty(key))
            {
                LoadProduct();
            }
            else
            {
                dgwProduct.DataSource = _productService.GetProductsByProductName(key);
            }

        }

        private void btnAddaProduct_Click(object sender, EventArgs e)
        {
            try
            {
                _productService.Add(new Product
                {
                    ProductName = tbxProductName2.Text,
                    CategoryId = Convert.ToInt32(cbxCategoryId.SelectedValue),
                    UnitPrice = Convert.ToDecimal(tbxUnitPrice.Text),
                    UnitsInStock = Convert.ToInt16(tbxUnitsInStock.Text),
                    QuantityPerUnit = tbxQuantityPerUnit.Text
                });

                MessageBox.Show("Product Added");
                LoadProduct();
            }
            catch (Exception exception)
            {

                MessageBox.Show(exception.Message);
            }
           

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                _productService.Update(new Product
                {
                    ProductId = Convert.ToInt32(dgwProduct.CurrentRow.Cells[0].Value),
                    ProductName = tbxProductName2Update.Text,
                    CategoryId = Convert.ToInt32(cbxCategoryIdUpdate.SelectedValue),
                    UnitPrice = Convert.ToDecimal(tbxUnitPriceUpdate.Text),
                    UnitsInStock = Convert.ToInt16(tbxUnitsInStockUpdate.Text),
                    QuantityPerUnit = tbxQuantityPerUnitUpdate.Text

                });
                MessageBox.Show("Product Updated");
                LoadProduct();

            }
            catch (Exception exception)
            {

                MessageBox.Show(exception.Message);
            }
            
        }

        private void dgwProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            tbxProductName2Update.Text = dgwProduct.CurrentRow.Cells[1].Value.ToString();
            cbxCategoryIdUpdate.SelectedValue = dgwProduct.CurrentRow.Cells[2].Value;
            tbxUnitPriceUpdate.Text = dgwProduct.CurrentRow.Cells[3].Value.ToString();
            tbxUnitsInStockUpdate.Text = dgwProduct.CurrentRow.Cells[4].Value.ToString();
            tbxQuantityPerUnitUpdate.Text = dgwProduct.CurrentRow.Cells[5].Value.ToString();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgwProduct.CurrentRow != null)
            {
                try
                {
                    _productService.Delete(new Product
                    {
                        ProductId = Convert.ToInt32(dgwProduct.CurrentRow.Cells[0].Value)
                    });
                    MessageBox.Show("Product Deleted");
                    LoadProduct();

                }
                catch (Exception exception)
                {

                    MessageBox.Show(exception.Message);
                }

            }

        }
    }
}
