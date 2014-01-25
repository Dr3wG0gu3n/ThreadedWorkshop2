/*
 *A Product Manager Form designed by Group 2 for managing 
 *Product objects in the database
 */

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
        Product prod;

        public frmProductManager()
        {
            InitializeComponent();
        }

        public frmProductManager(int supplierId)            //overloaded the constructor
        {
            InitializeComponent();
            _supplierId = supplierId;
        }

        //created another overloaded constructor if its an update
        public frmProductManager(bool isupdate, int productId, int supplierId)
        {
            InitializeComponent();
            _isUpdate = isupdate;
            _productId = productId;
            _supplierId = supplierId;
        }

        //the cancel button event
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are You Sure you Want to Close/Cancel?",
                    "Confirm Close", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
                this.Close();
        }

        //form load event
        private void frmProductManager_Load(object sender, EventArgs e)
        {
            if(!_isUpdate)
            {
                ddlSearch.DataSource = SupplierDB.GetAllSuppliers();
                ddlSearch.DisplayMember = "Name";
                ddlSearch.ValueMember = "Id";   
            }
            txbSupplierName.Text = SupplierDB.GetSupplierById(_supplierId).Name;        //the supplier displayed
            if (_isUpdate)                                                              //if it's an update
            {
                txbProductName.Text = ProductDB.GetProduct(_productId).ProdName;        //set the Product name field to edit
            }  
        }

        //the add button event
        private void btnAdd_Click(object sender, EventArgs e)                           
        {
            txbProductName.Enabled = true;

            try
            {
                if (Validator.IsPresent(txbProductName) && Validator.IsAlphabetical(txbProductName))    //validate the fields
                {
                    int newProdId = ProductDB.AddProduct(new Product { ProdName = txbProductName.Text });   //get the newly generated product id

                    bool result = Product_SupplierDB.InsertProduct_Supplier(newProdId, _supplierId);        //use the Id to insert to Product_Suppliers Table
                                                                                                            //and get the result
                    if (result)                                                                             //test the result displaying correct message
                    {                                       
                        MessageBox.Show("Product Successfully Added with Relation \nto the Supplier", "Success");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Product Was not Added", "Failure");
                    }
                }
                else
                {                                                                       //if validation fails
                    MessageBox.Show("Please Input a Proper Name");
                    txbProductName.SelectAll();
                    txbProductName.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.Message);                             //catch and display any error
            }
        }

        //save button event
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (_isUpdate)
                {
                    if (Validator.IsPresent(txbProductName))
                    {
                        Product prod = ProductDB.GetProduct(_productId);    //get the product to update
                        prod.ProdName = txbProductName.Text;

                        bool result = ProductDB.UpdateProduct(prod);        //do the update and check the result
                        if (result)
                        {
                            MessageBox.Show("Update was Successful");       //displaying proper message
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Update was Not Successful", "Error");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Problem with the Name Field");
                        txbProductName.SelectAll();
                        txbProductName.Focus();
                    }
                }
                
                else
                {                                                      //if validation fails
                    MessageBox.Show("Problem with the Name Field");
                    txbProductName.SelectAll();
                    txbProductName.Focus();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.Message);             //catch any errors
            }

        }

        //the delete event 
        private void btnDelete_Click(object sender, EventArgs e)
        {
            Product prod = ProductDB.GetProduct(_productId);                //get the objects to work with
            Supplier sup = SupplierDB.GetSupplierById(_supplierId);

            try
            {
                DialogResult result = MessageBox.Show("Are You Sure you Want to Delete?", //make sure with the user
                   "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes) //if yes
                {
                    bool answer = Product_SupplierDB.DeleteProduct_Supplier(_productId, _supplierId); //get the result of the test
                    if (answer)                             //right now it only deletes the relationship between products and suppliers
                    {                                       // as many suppliers supply the same products
                        MessageBox.Show("This Product : " + prod.ProdName + " \nIs No Longer Associated with : " + sup.Name);
                        this.Close();
                    }
                    else
                        MessageBox.Show("There was a Problem", "Error");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.Message);             //catch and display any errors
            }
        }

        //if you want to add a product with no relationship into the database
        private void txbAddWithoutRelation_Click(object sender, EventArgs e)
        {
            txbProductName.Enabled = true;
            try
            {
                if (Validator.IsPresent(txbProductName))    //validate the field
                {
                    int newProdId = ProductDB.AddProduct(new Product { ProdName = txbProductName.Text });   //get the newly generated product id

                    //and get the result displaying appropriate message
                    if (newProdId > 0)                                                                             //test the result displaying correct message
                    {
                        MessageBox.Show("Product Successfully Added WITHOUT Relation /nto Supplier", "Success");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Product Was not Added", "Failure");
                    }
                }
                else
                {                                                                       //if validation fails
                    MessageBox.Show("Please Input a Proper Name");
                    txbProductName.SelectAll();
                    txbProductName.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.Message);                             //catch and display any error
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            txbProductName.Enabled = true;
        }

        private void ddlSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            Supplier sup = (Supplier)ddlSearch.SelectedItem;            //get the supplier to work with
            txbSupplierName.Text = sup.Name;
        }
    }
}
