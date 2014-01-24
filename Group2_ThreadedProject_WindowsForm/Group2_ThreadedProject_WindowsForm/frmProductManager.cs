using Group2_ThreadedProject_WindowsForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TravelExperts;
using TravelExperts.EntityDomainLibrary;

namespace Second_GUI_Project
{
    public partial class frmProductManager : Form
    {

        private bool _isUpdate = false;            // a boolean to indicate if we are updating or adding  
        int _productId;
        int _supplierId;
        frmMain main;
        //frmTravelExperts supManager;

        public frmProductManager()
        {
            InitializeComponent();
        }

        public frmProductManager(int supplierId)
        {
            InitializeComponent();
            _supplierId = supplierId;
        }

        public frmProductManager(bool isupdate, int productId, int supplierId)
        {
            InitializeComponent();
            _isUpdate = isupdate;
            _productId = productId;
            _supplierId = supplierId;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are You Sure you Want to Close the Product Manager?",
                    "Confirm Close", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
                this.Close();
        }

        private void frmProductManager_Load(object sender, EventArgs e)
        {
            //supManager = (frmTravelExperts)this.MdiParent;

            //main = (frmMain)supManager.MdiParent;

            //main.ChangeMessageLabel("what the heck is going on ");

            txbSupplierName.Text = SupplierDB.GetSupplierById(_supplierId).Name;
            if (_isUpdate)
            {
                txbProductName.Text = ProductDB.GetProduct(_productId).ProdName;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                int newProdId = ProductDB.AddProduct(new Product { ProdName = txbProductName.Text });

                bool result = Product_SupplierDB.InsertProduct_Supplier(newProdId, _supplierId);

                if (result)
                {
                    MessageBox.Show("Product Successfully Added", "Success");
                    //main.ChangeMessageLabel("Product Added to Supplier");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Product Was not Added", "Failure");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (Validator.IsPresent(txbProductName))
                {
                    Product prod = ProductDB.GetProduct(_productId);
                    prod.ProdName = txbProductName.Text;

                    bool result = ProductDB.UpdateProduct(prod);
                    if (result)
                    {
                        MessageBox.Show("Update was Successful");
                        main.ChangeMessageLabel("Updated Product");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Update was Not Successful", "Error");
                        main.ChangeMessageLabel("Error");
                    }
                }
                else
                {
                    MessageBox.Show("Problem with the Name Field");
                    main.ChangeMessageLabel("See Name Field");
                    txbProductName.SelectAll();
                    txbProductName.Focus();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.Message);
            }

        }

        //the delete event , we only delete the relationship between suppliers and a product
        private void btnDelete_Click(object sender, EventArgs e)
        {
            Product prod = ProductDB.GetProduct(_productId);
            Supplier sup = SupplierDB.GetSupplierById(_supplierId);

            try
            {
                DialogResult result = MessageBox.Show("Are You Sure you Want to Delete?",
                   "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    bool answer = Product_SupplierDB.DeleteProduct_Supplier(_productId, _supplierId); //if successful on delete let user know
                    if (answer)
                    {
                        MessageBox.Show("This Product : " + prod.ProdName + " \nIs No Longer Associated with : " + sup.Name);
                        this.Close();
                    }
                    else
                        MessageBox.Show("There was a Problem", "Error");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.Message);
            }
        }
    }
}
