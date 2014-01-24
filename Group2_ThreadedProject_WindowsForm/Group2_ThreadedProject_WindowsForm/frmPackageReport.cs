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
    public partial class frmPackageReport : Form
    {
        public frmPackageReport()
        {
            InitializeComponent();
        }

        private void frmPackageReport_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dsPackages.Packages' table. You can move, or remove it, as needed.
            this.PackagesTableAdapter.Fill(this.dsPackages.Packages);

            this.reportViewer1.RefreshReport();
        }
    }
}
