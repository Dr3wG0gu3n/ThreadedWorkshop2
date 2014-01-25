﻿namespace Second_GUI_Project
{
    partial class frmProductManager
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
            this.txbAddWithoutRelation = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnAddWithRelation = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txbProductName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txbSupplierName = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txbAddWithoutRelation);
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.btnAddWithRelation);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 168);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(360, 74);
            this.panel1.TabIndex = 1;
            // 
            // txbAddWithoutRelation
            // 
            this.txbAddWithoutRelation.Location = new System.Drawing.Point(182, 10);
            this.txbAddWithoutRelation.Name = "txbAddWithoutRelation";
            this.txbAddWithoutRelation.Size = new System.Drawing.Size(166, 23);
            this.txbAddWithoutRelation.TabIndex = 1;
            this.txbAddWithoutRelation.Text = "&Add without Relation";
            this.txbAddWithoutRelation.UseVisualStyleBackColor = true;
            this.txbAddWithoutRelation.Click += new System.EventHandler(this.txbAddWithoutRelation_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(139, 39);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "&Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(38, 39);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnAddWithRelation
            // 
            this.btnAddWithRelation.Location = new System.Drawing.Point(12, 10);
            this.btnAddWithRelation.Name = "btnAddWithRelation";
            this.btnAddWithRelation.Size = new System.Drawing.Size(164, 23);
            this.btnAddWithRelation.TabIndex = 0;
            this.btnAddWithRelation.Text = "Add with &Relation to Supplier";
            this.btnAddWithRelation.UseVisualStyleBackColor = true;
            this.btnAddWithRelation.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(235, 39);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Supplier :";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txbProductName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(20, 55);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(328, 93);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Product Info";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // txbProductName
            // 
            this.txbProductName.Location = new System.Drawing.Point(108, 37);
            this.txbProductName.Name = "txbProductName";
            this.txbProductName.Size = new System.Drawing.Size(192, 20);
            this.txbProductName.TabIndex = 0;
            this.txbProductName.TextChanged += new System.EventHandler(this.txbProductName_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Product Name:";
            // 
            // txbSupplierName
            // 
            this.txbSupplierName.Location = new System.Drawing.Point(101, 18);
            this.txbSupplierName.Name = "txbSupplierName";
            this.txbSupplierName.ReadOnly = true;
            this.txbSupplierName.Size = new System.Drawing.Size(247, 20);
            this.txbSupplierName.TabIndex = 3;
            this.txbSupplierName.TabStop = false;
            this.txbSupplierName.TextChanged += new System.EventHandler(this.txbSupplierName_TextChanged);
            // 
            // frmProductManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 242);
            this.Controls.Add(this.txbSupplierName);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Name = "frmProductManager";
            this.Text = "Product Manager";
            this.Load += new System.EventHandler(this.frmProductManager_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnAddWithRelation;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txbProductName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txbSupplierName;
        private System.Windows.Forms.Button txbAddWithoutRelation;
    }
}