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
    public partial class frmPackageManager : Form
    {

        frmMain main;

        public frmPackageManager()
        {
            InitializeComponent();
        }

        private void frmPackageManager_Load(object sender, EventArgs e)
        {
             main = (frmMain)this.MdiParent;
        }

        private void frmPackageManager_FormClosing(object sender, FormClosingEventArgs e)
        {
            main.ChangeMessageLabel("Package Manager Form is Closing ...");
        }

    }
}
