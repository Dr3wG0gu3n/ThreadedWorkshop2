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

namespace Group2_ThreadedProject_WindowsForm
{
    public partial class frmNewSupplier : Form
    {
        //boolean variable and a Supplier Object to work with
        Supplier supplier;
        bool _isupdate = false;

        public frmNewSupplier()
        {
            InitializeComponent();
        }
        
        //this constructor is used if an update is occurring, we pass in the boolean (as true), 
        //and pass in the supplier object to work with , then set the fields
        public frmNewSupplier(bool isupdate, Supplier sup)   
        {
            InitializeComponent();

            _isupdate = isupdate;
            supplier = sup;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you really want to Cancel?", "Confirm Cancel", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
                
        }

        //the save button event where we validate and then dpending on the boolean isupdate variable
        //we either add a new Supplier or just update an existing one
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Validator.IsPresent(txbName) && Validator.IsAlphabetical(txbName))          //gotta fix this method as it's causing an error
            {                                                                               //with some special characters
                if (_isupdate)
                {
                    SupplierDB.UpdateSupplier(supplier.Id, txbName.Text);   //here pass the supplier Id and the new Name from the textbox
                    MessageBox.Show("Supplier Updated Successful");         //again provide user feedback
                    this.Close();                                           //close
                }
                else
                {
                    //the database doesn't have a auto increment implemented so this method returns next available Id.
                    int newId = SupplierDB.GetNextSupplierId();                     
                    SupplierDB.AddSupplier(new Supplier { Id = newId, Name = txbName.Text });       //Use in line instantiation to add supplier
                    MessageBox.Show("Supplier Added Successful");                                   //Provide user feedback
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Name must be Correct");
                txbName.SelectAll();
                txbName.Focus();
            }
        }

        private void frmNewSupplier_Load(object sender, EventArgs e)
        {
            if (!_isupdate)
            {
                btnDelete.Enabled = false;          //if we are adding a new Supplier the delete button will be disabled
            }
            else
            {
                txbId.Text = supplier.Id.ToString();    //if it's an update set the fields to appropriate textboxes
                txbName.Text = supplier.Name;
            }
        }

        //the delete button event, confirming with user first
        private void btnDelete_Click(object sender, EventArgs e)
        {           
            DialogResult result = MessageBox.Show("Do you really want to Delete?", "Confirm Delete", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                if (SupplierDB.DeleteSupplier(new Supplier { Id = Convert.ToInt32(txbId.Text), Name = txbName.Text }))
                {
                    MessageBox.Show("Supplier Deleted Successfully");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("There is a problem in database!", "Error");
                }
            }
           

        } 

    }
}
