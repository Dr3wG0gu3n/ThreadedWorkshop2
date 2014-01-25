/*
 *A supplier Manager Form to Manage Supplier objects
 *designed by group 2 for workshop 2 
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
    public partial class frmSupplierManager : Form
    {
        private bool _isUpdate = false;            // a boolean to indicate if we are updating or adding  
        int _supplierId;                           // the supplierId
        Supplier sup;                              //a supplier object to use

        public frmSupplierManager()
        {
            InitializeComponent();
        }

        public frmSupplierManager(bool isupdate, int supplierId) //overload the constructor
        {
            InitializeComponent();                               //set the boolean 
            _isUpdate = isupdate;
            _supplierId = supplierId;
        }

        private void frmSupplierManager_Load(object sender, EventArgs e)
        {
            if (_isUpdate)                          //if its an update set the fields with the values
            {
                sup = SupplierDB.GetSupplierById(_supplierId);
                tbxId.Text = sup.Id.ToString();
                tbxName.Text = sup.Name;
            }
        }

        //the cancel button making sure the user really wants to close/cancel the form
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are You Sure you Want to Close/Cancel?",
                    "Confirm Close", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
                this.Close();
        }

        //The save button event
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (Validator.IsPresent(tbxName))
                {
                    if (!(_isUpdate))                       //if it isn't an update
                    {                                       //create a user, add to the database and obtain the result
                        bool result = SupplierDB.AddSupplier(new Supplier { Id = SupplierDB.GetNextSupplierId(), Name = tbxName.Text });
                        if (result)                                     //test the result displaying the proper message
                        {
                            MessageBox.Show("A new Supplier was Added");
                            this.Close();
                        }
                        else
                            MessageBox.Show("There was a Problem");
                    }
                    else
                    {                                       //if it is an update call the update supplier method displaying success or not
                        bool result = SupplierDB.UpdateSupplier(Convert.ToInt32(tbxId.Text), tbxName.Text);
                        if (result)
                        {
                            MessageBox.Show("The Supplier was Updated Successfully");
                            this.Close();
                        }
                        else
                            MessageBox.Show("There was a Problem Updating the Supplier");
                    }
                }
                else
                {
                    MessageBox.Show("A Proper Name is Required");
                    tbxName.SelectAll();
                    tbxName.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.Message);                 //catch and display any errors
            }

        }

        //The add button event
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                int newSupplierId = SupplierDB.GetNextSupplierId();
                if (Validator.IsPresent(tbxName))                                                   //validate the Name textbox
                {
                    string properName = Validator.FormatedName(tbxName.Text);                       //format the name 
                    bool result = SupplierDB.AddSupplier(new Supplier { Id = newSupplierId, Name = properName }); //add a supplier and
                    if (result)                                                                                     //get the result
                    {                                                                                               //displaying proper message
                        MessageBox.Show("Supplier Successfully Added", "Success");                                  //back to user
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Please Input a Name");
                    tbxName.SelectAll();                                               //if validation failed set the focus for the user
                    tbxName.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.Message);             //catch and display any errors
            }
            
        }

        //The delete button event
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Are You Sure you Want to Delete?",       //make sure we want to delete
                    "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)                                         //if yes then proceed
                {
                    sup.Id = Convert.ToInt32(tbxId.Text);                               

                    bool answer = SupplierDB.DeleteSupplier(sup);                       //get the result of the delete method
                    if (answer)                                                         //and display the correct user feedback
                    {
                        MessageBox.Show("Supplier was Successfully Deleted");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Supplier was Not Deleted", "Error");
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.InnerException.Message);                             //catch any errors which occurred
            }

        }
    }
}
