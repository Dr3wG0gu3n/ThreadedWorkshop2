/*The Main form for Group 2's threaded project.
 * It ws Designed By Andrew Goguen with help from
 * the Rest of the group
 * this Form is the Main GUI for the Travel Agents
 * maintaining Suppliers, Products, Packages tables
 * It call the appropriate form passing in the required objects
 * as needed.
 */

using Second_GUI_Project;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Group2_ThreadedProject_WindowsForm
{
    public partial class frmMain : Form
    {
        //I'm going to declare some Form level variables to control my child forms
        frmTravelExperts supManager;
        frmProductManager prodManager;
        frmPackageManager packageManager;

        public frmMain()
        {
            InitializeComponent();
            ChangeMessageLabel("Program is Loading");
        }
 
        //A simple method to change the Message Label providing User Feedback
        public void ChangeMessageLabel(string text)
        {
            uxTimer.Stop();
            lblStatusMessage.Text = text;
            uxTimer.Start();
        }

        //Reset the Message to the default value
        private void uxTimer_Tick(object sender, EventArgs e)
        {
            lblStatusMessage.Text = "Ready...";
        }

        //the Exit button event, confirm with the user that they really want to exit, if yes close the application
        private void btnExitToolStripMenu_Click(object sender, EventArgs e)
        {
            ChangeMessageLabel("Confirm Application Exit?");
            DialogResult result = MessageBox.Show("Do You really want to Quit the Application? \n\n\tSave Your Data!!", "Confirm Quit", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
                Application.Exit();
        }

        //bring up a About Dialog to show information about the Program and the Team who built it
        private void btnAboutDialog_Click(object sender, EventArgs e)
        {
            AboutBox1 aboutBox = new AboutBox1();
            aboutBox.ShowDialog();
        }

        private void btnAddSupplierToolStripMenu_Click(object sender, EventArgs e)
        {
            if (supManager == null || supManager.IsDisposed)
            {
                supManager = new frmTravelExperts();               //create the SupplierManager(used to be called frmTravelExperts) form
                supManager.MdiParent = this;                                        //set the parent property to this form
            }
            ChangeMessageLabel("Supplier Management Form is Loading...");       //change the statusstrip message label
            supManager.Show();                                      //bring the called form to the front and in focus
            supManager.BringToFront();
            
        }

        private void btnEditSupplierToolStripMenu_Click(object sender, EventArgs e)
        {
            if (prodManager == null || prodManager.IsDisposed)
            {
                prodManager = new frmProductManager();            //create the ProdManager Form
                prodManager.MdiParent = this;                                       //set the MDIParent property to this form and same steps as above
            }            
            ChangeMessageLabel("Product Manager Form is Loading ....");         
            prodManager.Show();
            prodManager.BringToFront();                              
        }

        private void btnackagesToolStrip_Click(object sender, EventArgs e)  //create the Package manager form and use same steps as above
        {
            if (packageManager == null || packageManager.IsDisposed)
            {
                packageManager = new frmPackageManager();
                packageManager.MdiParent = this;
            }
            ChangeMessageLabel("Package Manager Form is Loading....");
            packageManager.Show();
            packageManager.BringToFront();
        }

        //simple event to enable and show toolbar if its disabled, or the other way round depending on its state
        private void toolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tsToolStip.Enabled == false)
            {
                tsToolStip.Enabled = true;
                tsToolStip.Visible = true;
            }
            else
            {
                tsToolStip.Enabled = false;
                tsToolStip.Visible = false;
            }
        }

        //change the orientation of the windows  depending on the preferences of the user
        private void horizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void verticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void cascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        //call the report form for the packages
        private void packageReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPackageReport packReport = new frmPackageReport();
            packReport.ShowDialog();
        }

    }

}
