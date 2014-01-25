/*
 * The Travel Experts Form designed by group 2 Andrew, Vishnu, Chris, and Yu Wen
 * for group workshop 2
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
using TravelExperts.EntityDomainLibrary;
using TravelExperts;

namespace Second_GUI_Project
{
    public partial class frmTravelExperts : Form
    {
        public frmTravelExperts()
        {
            InitializeComponent();
        }

        private void frmTravelExperts_Load(object sender, EventArgs e)
        {
            try
            {
                UpdateSupplierList();           //when the form loads get the suppliers using the method below
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.Message);
            }
        
        }

        //A simple method to update the Supplier Combobox
        private void UpdateSupplierList()
        {
            cboSuppliers.DataSource = SupplierDB.GetAllSuppliers();
            cboSuppliers.DisplayMember = "Name";
            cboSuppliers.ValueMember = "Id";
        }

        private void cboSuppliers_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Supplier sup = (Supplier)cboSuppliers.SelectedItem;     //Get the supplier
                dgvProducts.DataSource = ProductDB.GetAllProducts(sup.Id);  //use the ID Property to get the related product
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.Message);
            }

        }

        private void btnClose_Click(object sender, EventArgs e)             //confirm the close and then close form
        {
            DialogResult result = MessageBox.Show("Are You Sure you Want to Exit The Program?",
                    "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
                this.Close();
        }

        private void btnAddSupplier_Click(object sender, EventArgs e)
        {
            try
            {                
                frmSupplierManager supManager = new frmSupplierManager();  //create a new SupplierManager Form
                supManager.ShowDialog();                                    //Bring to Focus
                UpdateSupplierList();                                       //once the form is disposed, update the display
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.Message);                //catch any exceptions which may have been thrown
            }
        }

        private void btnEditSupplier_Click(object sender, EventArgs e)      
        {
            try
            {
                Supplier sup = (Supplier)cboSuppliers.SelectedItem;         //create the SupplierManager Form but pass in a Supplier id
                frmSupplierManager supManager = new frmSupplierManager(true, sup.Id);
                supManager.ShowDialog();                                    //Bring to focus and then update the combobox for suppliers
                UpdateSupplierList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.Message);
            }
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            try
            {
                Supplier sup = (Supplier)cboSuppliers.SelectedItem;     //Get the supplier
                frmProductManager prodManager = new frmProductManager(sup.Id);  //call the Supplier Manager form
                prodManager.ShowDialog();                                       //passing in Supplier to work with
                dgvProducts.DataSource = ProductDB.GetAllProducts(sup.Id);  //update the display
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.Message);
            }
        }

        private void btnEditProduct_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvProducts.SelectedRows.Count <= 0)            //this is kinda buggy, user must highlight first column
                {                                                   // maybe have an item selected by default?
                    MessageBox.Show("You Must Pick a Product to Update");
                    return;
                }
                DataGridViewRow row = this.dgvProducts.SelectedRows[0];
               
                Product prod = (Product)row.DataBoundItem;              //get the product object from the databounditem property
                
                Supplier sup = (Supplier)cboSuppliers.SelectedItem;     //Get the supplier

                frmProductManager prodManager = new frmProductManager(true, prod.ProductId, sup.Id);    //create the form passing in 
                prodManager.ShowDialog();                                                               //both ids to work with

                dgvProducts.DataSource = ProductDB.GetAllProducts(sup.Id);  //update the display

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.Message);                 //catch any errors which may have been thrown
            }

        }

        private void dgvProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
