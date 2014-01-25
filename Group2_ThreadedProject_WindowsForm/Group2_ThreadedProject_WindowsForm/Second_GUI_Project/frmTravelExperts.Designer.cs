namespace Second_GUI_Project
{
    partial class frmTravelExperts
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnEditProduct = new System.Windows.Forms.Button();
            this.btnAddProduct = new System.Windows.Forms.Button();
            this.btnEditSupplier = new System.Windows.Forms.Button();
            this.btnAddSupplier = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.cboSuppliers = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvProducts = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.btnEditProduct);
            this.panel1.Controls.Add(this.btnAddProduct);
            this.panel1.Controls.Add(this.btnEditSupplier);
            this.panel1.Controls.Add(this.btnAddSupplier);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 213);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(425, 45);
            this.panel1.TabIndex = 0;
            // 
            // btnEditProduct
            // 
            this.btnEditProduct.Location = new System.Drawing.Point(254, 8);
            this.btnEditProduct.Name = "btnEditProduct";
            this.btnEditProduct.Size = new System.Drawing.Size(75, 23);
            this.btnEditProduct.TabIndex = 3;
            this.btnEditProduct.Text = "Edit Product";
            this.btnEditProduct.UseVisualStyleBackColor = true;
            this.btnEditProduct.Click += new System.EventHandler(this.btnEditProduct_Click);
            // 
            // btnAddProduct
            // 
            this.btnAddProduct.Location = new System.Drawing.Point(173, 8);
            this.btnAddProduct.Name = "btnAddProduct";
            this.btnAddProduct.Size = new System.Drawing.Size(75, 23);
            this.btnAddProduct.TabIndex = 2;
            this.btnAddProduct.Text = "Add Product";
            this.btnAddProduct.UseVisualStyleBackColor = true;
            this.btnAddProduct.Click += new System.EventHandler(this.btnAddProduct_Click);
            // 
            // btnEditSupplier
            // 
            this.btnEditSupplier.Location = new System.Drawing.Point(92, 8);
            this.btnEditSupplier.Name = "btnEditSupplier";
            this.btnEditSupplier.Size = new System.Drawing.Size(75, 23);
            this.btnEditSupplier.TabIndex = 1;
            this.btnEditSupplier.Text = "Edit Supplier";
            this.btnEditSupplier.UseVisualStyleBackColor = true;
            this.btnEditSupplier.Click += new System.EventHandler(this.btnEditSupplier_Click);
            // 
            // btnAddSupplier
            // 
            this.btnAddSupplier.Location = new System.Drawing.Point(11, 8);
            this.btnAddSupplier.Name = "btnAddSupplier";
            this.btnAddSupplier.Size = new System.Drawing.Size(75, 23);
            this.btnAddSupplier.TabIndex = 0;
            this.btnAddSupplier.Text = "Add Supplier";
            this.btnAddSupplier.UseVisualStyleBackColor = true;
            this.btnAddSupplier.Click += new System.EventHandler(this.btnAddSupplier_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(335, 8);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // cboSuppliers
            // 
            this.cboSuppliers.FormattingEnabled = true;
            this.cboSuppliers.Location = new System.Drawing.Point(111, 21);
            this.cboSuppliers.Name = "cboSuppliers";
            this.cboSuppliers.Size = new System.Drawing.Size(220, 21);
            this.cboSuppliers.TabIndex = 2;
            this.cboSuppliers.SelectedIndexChanged += new System.EventHandler(this.cboSuppliers_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Suppliers";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvProducts);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 61);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(425, 152);
            this.panel2.TabIndex = 4;
            // 
            // dgvProducts
            // 
            this.dgvProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProducts.Location = new System.Drawing.Point(0, 0);
            this.dgvProducts.Name = "dgvProducts";
            this.dgvProducts.Size = new System.Drawing.Size(425, 152);
            this.dgvProducts.TabIndex = 0;
            this.dgvProducts.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProducts_CellContentClick);
            // 
            // frmTravelExperts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 258);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboSuppliers);
            this.Controls.Add(this.panel1);
            this.Name = "frmTravelExperts";
            this.Text = "Travel Experts Management Form";
            this.Load += new System.EventHandler(this.frmTravelExperts_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cboSuppliers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvProducts;
        private System.Windows.Forms.Button btnEditProduct;
        private System.Windows.Forms.Button btnAddProduct;
        private System.Windows.Forms.Button btnEditSupplier;
        private System.Windows.Forms.Button btnAddSupplier;
    }
}

