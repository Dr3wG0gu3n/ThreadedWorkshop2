/*************************************************************
 * Author: Yu Wen Ruan & Chris
 * Task: CMPP248 C#--Thread Project
 * Date: Jan 23, 2014
 * 
 * Form: frmPackageManager
 * Add, Edit, Delete and Save packages
 * 
 * *************************************************************/
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
using DatabaseConnectionLayer;

namespace Group2_ThreadedProject_WindowsForm
{
    public partial class frmPackageManager : Form
    {
        private bool _isUpdate=false;
        private List<Products_Suppliers> listProducts = new List<Products_Suppliers>();
        private List<Products_Suppliers> listSelectedProducts = new List<Products_Suppliers>();

        public frmPackageManager()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ResetContent();
            txbPackageId.SelectAll();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPackageManager_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'travelExpertsDataSet.Products' table. You can move, or remove it, as needed.
            this.productsTableAdapter.Fill(this.travelExpertsDataSet.Products);
            
            ////change state of button and text box to
            ControlSwitch(txbPackageId, false);
            ControlSwitch(btnAdd, false);

            txbPackageId.Focus();
            txbPackageId.SelectAll();
        }

        //method to switch button state
        private void ControlSwitch(Control ctl,bool bState)
        {
            //change state of  Eidt and Delte buttons 
            if (ctl is Button)
            {
                btnEdit.Enabled = bState;
                btnDelete.Enabled = bState;
                
            }
            else if (ctl is TextBox)
            {
                //change state of text boxes
                txbPackageId.Enabled = !bState;
                txbPackageName.Enabled = bState;
                txtAgtCommission.Enabled = bState;
                txtBasePrice.Enabled = bState;
                txtDescription.Enabled = bState;

                btnAddP.Enabled = bState;
                btnMoveP.Enabled = bState;
                
            }
            else
            {   //chage the state of datetime picker
                dtpEndDate.Enabled = bState;
                dtpStartDate.Enabled = bState;
            }
        }

        //event method when search button is pressed
        private void btnSearch_Click(object sender, EventArgs e)
        {
            ResetContent();
            //check the validation of search package id text box
            if (Validator.IsPresent(txbPackageId) && Validator.IsNumeric(txbPackageId))
            {
                if (Convert.ToInt32(txbPackageId.Text) < 0)
                {
                    MessageBox.Show("Only positive number can be as package Id", "Input error");
                    txbPackageId.SelectAll();
                    txbPackageId.Focus();
                }
                else
                {
                    //search the package from search
                    Package pack = new Package();
                    int packId = Convert.ToInt32(txbPackageId.Text);
                    pack = PackageDB.GetPackage(packId);
                    if (pack != null)
                    {
                        ShowPackageInfor(pack);
                        List<Product> listProducts = new List<Product>();
                        //get all products associate with packageId
                        listSelectedProducts = Packages_Products_SuppliersDB.GetPkgProducts(packId);
                        if (listSelectedProducts != null)
                        {
                            //show the products list in list box
                            ShowProductNameList(listSelectedProducts, lsbProducts);
                        }

                        //change edit and delete to enable
                        ControlSwitch(btnEdit, true);
                    }
                    else
                    {
                        MessageBox.Show("No record is found!","No Record");
                        txbPackageId.SelectAll();
                        txbPackageId.Focus();
                    }
                }
            }
        }

        //method to show detail information to each text box or datetime picker control
        private void ShowPackageInfor(Package pack)
        {
            txbPackageName.Text = pack.PkgName;
            dtpStartDate.Text = pack.PkgStartDate.ToString();
            dtpEndDate.Text = pack.PkgEndDate.ToString();
            txtBasePrice.Text = pack.PkgBasePrice.ToString("c");
            txtAgtCommission.Text = pack.PkgAgencyCommission.ToString("c");
            txtDescription.Text = pack.PkgDesc;
        }

        //show product supplier list in the list box
        private void ShowProductList(List<Products_Suppliers> lps, ListBox lsb)
        {
            lsb.Items.Clear();      //reset listbox
         
            for (int i = 0; i < lps.Count; i++)
            {
                string supName;
                string str;

                supName = SupplierDB.GetSupplierById(lps[i].SupplierId).Name;
                str = lps[i].ProductSupplierId.ToString() + "   " +
                    supName;
                lsb.Items.Add(str);
            }

        }

        private void ShowProductNameList(List<Products_Suppliers> lps, ListBox lsb)
        {
            lsb.Items.Clear();      //reset listbox

            for (int i = 0; i < lps.Count; i++)
            {
                string supName,prodName;
                string str;

                supName = SupplierDB.GetSupplierById(lps[i].SupplierId).Name;
                prodName = ProductDB.GetProduct(lps[i].ProductId).ProdName;
                str = lps[i].ProductSupplierId.ToString() + "   " +
                    supName + "   " + prodName;
                lsb.Items.Add(str);
            }

        }


        //event to add new package
        private void btnAdd_Click(object sender, EventArgs e)
        {
            ControlSwitch(txbPackageName,true);
            ResetContent(); //reset controls content of this form
        }

        //method to reset all controls
        private void ResetContent()
        {
            txbPackageName.Text = "";
            txtAgtCommission.Text = "";
            txtBasePrice.Text = "";
            txtDescription.Text = "";
            dtpEndDate.Text = DateTime.Now.ToString();
            dtpStartDate.Text = DateTime.Now.ToString();
            lsbProducts.Items.Clear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            double basePrice, commPrice;
            if (txbPackageName.Enabled == true)
            {
                try
                {
                    Package package = new Package();
                    //check validation
                    if (Validator.IsPresent(txbPackageName) && Validator.IsAlphabetical(txbPackageName) &&
                        Validator.IsPresent(txtBasePrice) && Validator.IsPresent(txtDescription))
                    {
                        basePrice = Double.Parse(txtBasePrice.Text, System.Globalization.NumberStyles.Currency);
                        //set not null column to package
                        package.PkgName = txbPackageName.Text;
                        package.PkgBasePrice = basePrice;
                        package.PkgDesc = txtDescription.Text;

                        bool bDate = true;
                        ////not update have to check date range
                        
                        if (Validator.IsPresent(dtpStartDate) && Validator.IsPresent(dtpEndDate))
                        {
                            DateTime start = Convert.ToDateTime(dtpStartDate.Text);
                            DateTime end = Convert.ToDateTime(dtpEndDate.Text);
                            if (Validator.AppropriateDate(start, end))
                            {
                                //get the right start and end date
                                package.PkgStartDate = Convert.ToDateTime(dtpStartDate.Text);
                                package.PkgEndDate = Convert.ToDateTime(dtpEndDate.Text);

                            }
                            else
                            {
                                bDate = false;
                                //set to default date as today
                                package.PkgStartDate = DateTime.Now;
                                package.PkgEndDate = DateTime.Now;
                                dtpStartDate.Text = DateTime.Now.ToString();
                                dtpEndDate.Text = DateTime.Now.ToString();
                                dtpStartDate.Focus();   //package start and end are wrong, re-choose date
                            }
                        }
                        //}
                        //check the validation of commission
                        bool bComm = true;
                        if (Validator.IsPresent(txtAgtCommission))
                        {
                            commPrice = Double.Parse(txtAgtCommission.Text, System.Globalization.NumberStyles.Currency);
                            if (Validator.CheckCommission(basePrice, commPrice))
                            {
                                package.PkgAgencyCommission = commPrice;
                            }
                            else
                            {
                                bComm = false;
                                package.PkgAgencyCommission = 0;
                                //reset commission for agent
                                txtAgtCommission.SelectAll();
                                txtAgtCommission.Focus();
                            }

                        }
                        //commission input is not wrong and date is not wrong
                        if (bDate && bComm)
                        {
                            //if edit button is pressed
                            if (_isUpdate)
                            {
                                package.PackageId = Convert.ToInt32(txbPackageId.Text);
                                if (PackageDB.UpdatePackage(package))
                                {
                                    Packages_Products_SuppliersDB.DeletePkgProduct(package.PackageId);
                                    for (int i = 0; i < listSelectedProducts.Count; i++)
                                    {
                                        Packages_Products_SuppliersDB.InsertPkgProduct(package.PackageId, listSelectedProducts[i].ProductSupplierId);
                                    }
                                }
                            }
                            else
                            //only insert new record
                            {
                                PackageDB.AddPackage(package);
                                int pId = PackageDB.GetMaxPackageId();
                                for (int i=0; i<listSelectedProducts.Count;i++)
                                {
                                    Packages_Products_SuppliersDB.InsertPkgProduct(pId, listSelectedProducts[i].ProductSupplierId);
                                }
                            }
                            //reset control to readonly mode
                            ControlSwitch(txbPackageId, false);
                            txbPackageId.SelectAll();
                            txbPackageId.Focus();
                        }

                    }
                    else
                    {
                        MessageBox.Show("Package name and base price and description are required.", "Please input data");
                        txbPackageName.SelectAll();
                        txbPackageName.Focus();
                    }

                }
                catch (Exception ex)
                {
                    throw (ex);
                }
            }
            else
            {
                MessageBox.Show("You do not have to save, no change make","No change made");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            _isUpdate = true;
            ControlSwitch(txbPackageName, true);
        }
 
        //show all Product_SupplierId with SupplierName in the left list box
        private void cmbProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            lsbAllProducts.Items.Clear();
            listProducts.Clear();
            
            int pId=(int)cmbProducts.SelectedValue;
            listProducts=Product_SupplierDB.GetAllProductSuppliers(pId);

            if (listProducts!=null)
            {
                ShowProductList(listProducts, lsbAllProducts);
            }
        }

        private void btnAddP_Click(object sender, EventArgs e)
        {
            bool bExist=false;
            //check list box in the left has selected item
            if (lsbAllProducts.SelectedIndex != -1)
            {
                int ind=lsbAllProducts.SelectedIndex;
                Products_Suppliers ps = new Products_Suppliers();
                ps = listProducts[ind];
                //compare this product supplier with selected product supplier list
                //make sure it is not be duplicated
                for (int i = 0; i < listSelectedProducts.Count;i++ )
                {
                    if (ps.ProductSupplierId==listSelectedProducts[i].ProductSupplierId)
                    {
                        bExist = true;
                    }
                }
                //cannot add into existing select product supplier list
                if (bExist)
                {
                    MessageBox.Show("Product is already exist in this package","Duplicate product");
                }
                else
                {
                    //add into selected product supplier list
                    listSelectedProducts.Add(ps);
                    //show in the right list box 
                    ShowProductNameList(listSelectedProducts, lsbProducts);
                }
            }
            else
            {
                MessageBox.Show("You have to choose one product to add into package!","Error");
            }
        }

        //event method to move product from the package
        private void btnMoveP_Click(object sender, EventArgs e)
        {
            //select one item from them the right list box
            if (lsbProducts.SelectedIndex != -1)
            {
                int ind = lsbProducts.SelectedIndex;
                //move the select item from the list of product supplier
                listSelectedProducts.RemoveAt(ind);
                //show in the right list box
                ShowProductNameList(listSelectedProducts, lsbProducts);
            }
            else
            {
                MessageBox.Show("You have to choose one product to move out of this package!", "Error");
            }
        }

        //event method to delete package from package table
        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you really want to Delete?", "Confirm Delete", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {

                if (Validator.IsPresent(txbPackageId) && Validator.IsInt32(txbPackageId))
                {
                    if (Convert.ToInt32(txbPackageId.Text) < 0)
                    {
                        MessageBox.Show("Positive number is required", "Error entry");
                        txbPackageId.SelectAll();
                        txbPackageId.Focus();
                    }
                    else
                    {
                        int pId = Convert.ToInt32(txbPackageId.Text);

                        if (Packages_Products_SuppliersDB.DeletePkgProduct(pId))
                        {
                            if (PackageDB.DeletePackageById(pId))
                            {
                                MessageBox.Show("Package Deleted successfully", "Delete Record");
                                ResetContent();
                                ControlSwitch(txbPackageId, false);
                                ControlSwitch(btnAdd, false);
                                txbPackageId.Text = "";
                            }
                            else
                            {
                                MessageBox.Show("Package cannot be deleted ", "Delete Record Fail");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Record cannot be deleted ", "Delete Record Fail");
                        }
                    }
                }
            }
        }
    }
}
