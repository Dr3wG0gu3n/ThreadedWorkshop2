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
using Group2_ThreadedProject_WindowsForm;

namespace Second_GUI_Project
{
    public partial class frmTravelExperts : Form
    {
        bool _isUpdate = false;
        int _supplierId; // the supplierId()
        frmMain main;

        public frmTravelExperts()
        {
            InitializeComponent();
        }

        public frmTravelExperts(bool isupdate, int id)
        {
            InitializeComponent();                               //set the boolean 
            _isUpdate = isupdate;
            _supplierId = id;
        }

        private void frmTravelExperts_Load(object sender, EventArgs e)
        {
            try
            {
                main = (frmMain)this.MdiParent;             //on load set the mdi parent property 
                UpdateSupplierList();           //when the form loads get the suppliers using the method below
                txtSearch.SelectAll();
                txtSearch.Focus();
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
                if (cboSuppliers.SelectedIndex >= 0)
                {
                    Supplier sup = (Supplier)cboSuppliers.SelectedItem;     //Get the supplier
                    dgvProducts.DataSource = ProductDB.GetAllProducts(sup.Id);  //use the ID Property to get the related product
                    txtSearch.Text = sup.Id.ToString();                         //here I'll add the supplier Id to the textbox to display
                }
                else
                    dgvProducts.DataSource = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.Message);
            }

        }

        private void btnClose_Click(object sender, EventArgs e)             //confirm the close and then close form
        {
            DialogResult result = MessageBox.Show("Are You Sure you Want to Close the Supplier Manager?",
                    "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
                this.Close();
        }

        private void btnAddSupplier_Click(object sender, EventArgs e)
        {
            try
            {
                main.ChangeMessageLabel("Loading Add Supplier Form ...");
                frmNewSupplier newSupplier = new frmNewSupplier();
                newSupplier.ShowDialog();
                UpdateSupplierList();
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
                frmNewSupplier frmEdit = new frmNewSupplier(true, SupplierDB.GetSupplierById(Convert.ToInt32(txtSearch.Text)));
                
                main.ChangeMessageLabel("Edit Supplier Form is Loading");
                frmEdit.ShowDialog();
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
                main.ChangeMessageLabel("Product Manager Form is Loading ...");
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

       
        private void ClearContent()
        {
            cboSuppliers.SelectedIndex = -1;
            //dgvProducts.DataSource = null;
        }

        //event method when Search button is pressed
        private void btnSearch_Click(object sender, EventArgs e)
        {   
            //check the validation of input for search
            if (Validator.IsPresent(txtSearch) && Validator.IsNumeric(txtSearch))
            {
                try
                {
                    //get the supplier's id
                    int searchId = Convert.ToInt32(txtSearch.Text);
                    //search in the datebase to find the particular supplier
                    Supplier sup = SupplierDB.GetSupplierById(searchId);
                    //MessageBox.Show(sup.Name,"show the record");
                    //there is no supplier is found in this id
                    if (sup == null)
                    {
                        MessageBox.Show("There is no such supplier, please choose from combo box or reenter an new one","No record is found");
                        txtSearch.SelectAll();
                        ClearContent();

                    }
                    else
                    {                        
                        //find the right one and highlight in the combo box
                        cboSuppliers.SelectedIndex = cboSuppliers.FindStringExact(sup.Name);        //Andrew will fix this sometime this weekend
                    }
                }
                catch (Exception ex)
                {
                    main.ChangeMessageLabel("Error is Occuring ...");
                    MessageBox.Show(ex.InnerException.Message);
                }
            }
        }

        private void frmTravelExperts_FormClosing(object sender, FormClosingEventArgs e)
        {
            main.ChangeMessageLabel("Supplier Manager is Closing ...");
        }

    }
}
