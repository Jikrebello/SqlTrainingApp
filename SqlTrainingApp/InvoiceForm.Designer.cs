
namespace SqlTrainingApp
{
    partial class InvoiceForm
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
            this.btn_GoToCustomers = new System.Windows.Forms.Button();
            this.lblError = new System.Windows.Forms.Label();
            this.listviewMain = new System.Windows.Forms.ListView();
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.BTN_GoToParts = new System.Windows.Forms.Button();
            this.BTN_GoToAddInvoice = new System.Windows.Forms.Button();
            this.comboCustomer = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_GoToCustomers
            // 
            this.btn_GoToCustomers.Location = new System.Drawing.Point(15, 280);
            this.btn_GoToCustomers.Name = "btn_GoToCustomers";
            this.btn_GoToCustomers.Size = new System.Drawing.Size(140, 27);
            this.btn_GoToCustomers.TabIndex = 39;
            this.btn_GoToCustomers.Text = "Go to Customers";
            this.btn_GoToCustomers.UseVisualStyleBackColor = true;
            this.btn_GoToCustomers.Click += new System.EventHandler(this.btn_GoToCustomers_Click);
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Location = new System.Drawing.Point(277, 226);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(0, 17);
            this.lblError.TabIndex = 44;
            // 
            // listviewMain
            // 
            this.listviewMain.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader11,
            this.columnHeader12,
            this.columnHeader1});
            this.listviewMain.FullRowSelect = true;
            this.listviewMain.HideSelection = false;
            this.listviewMain.Location = new System.Drawing.Point(15, 12);
            this.listviewMain.Name = "listviewMain";
            this.listviewMain.Size = new System.Drawing.Size(648, 177);
            this.listviewMain.TabIndex = 38;
            this.listviewMain.UseCompatibleStateImageBehavior = false;
            this.listviewMain.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Invoice #";
            this.columnHeader7.Width = 72;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Invoice Date";
            this.columnHeader8.Width = 100;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "First Name";
            this.columnHeader9.Width = 100;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Last Name";
            this.columnHeader10.Width = 100;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "Description";
            this.columnHeader11.Width = 100;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "Quantity";
            this.columnHeader12.Width = 71;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Total";
            this.columnHeader1.Width = 100;
            // 
            // BTN_GoToParts
            // 
            this.BTN_GoToParts.Location = new System.Drawing.Point(161, 280);
            this.BTN_GoToParts.Name = "BTN_GoToParts";
            this.BTN_GoToParts.Size = new System.Drawing.Size(140, 27);
            this.BTN_GoToParts.TabIndex = 50;
            this.BTN_GoToParts.Text = "Go to Parts";
            this.BTN_GoToParts.UseVisualStyleBackColor = true;
            this.BTN_GoToParts.Click += new System.EventHandler(this.BTN_GoToParts_Click);
            // 
            // BTN_GoToAddInvoice
            // 
            this.BTN_GoToAddInvoice.Location = new System.Drawing.Point(523, 195);
            this.BTN_GoToAddInvoice.Name = "BTN_GoToAddInvoice";
            this.BTN_GoToAddInvoice.Size = new System.Drawing.Size(140, 27);
            this.BTN_GoToAddInvoice.TabIndex = 51;
            this.BTN_GoToAddInvoice.Text = "Add Invoice";
            this.BTN_GoToAddInvoice.UseVisualStyleBackColor = true;
            this.BTN_GoToAddInvoice.Click += new System.EventHandler(this.BTN_GoToAddInvoice_Click);
            // 
            // comboCustomer
            // 
            this.comboCustomer.FormattingEnabled = true;
            this.comboCustomer.Location = new System.Drawing.Point(86, 197);
            this.comboCustomer.Name = "comboCustomer";
            this.comboCustomer.Size = new System.Drawing.Size(121, 24);
            this.comboCustomer.TabIndex = 52;
            this.comboCustomer.SelectedIndexChanged += new System.EventHandler(this.comboCustomer_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 201);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 17);
            this.label1.TabIndex = 53;
            this.label1.Text = "Customer:";
            // 
            // InvoiceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(681, 332);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboCustomer);
            this.Controls.Add(this.BTN_GoToAddInvoice);
            this.Controls.Add(this.BTN_GoToParts);
            this.Controls.Add(this.btn_GoToCustomers);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.listviewMain);
            this.Name = "InvoiceForm";
            this.Text = "Invoices";
            this.Load += new System.EventHandler(this.Invoices_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_GoToCustomers;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.ListView listviewMain;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.Button BTN_GoToParts;
        private System.Windows.Forms.Button BTN_GoToAddInvoice;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ComboBox comboCustomer;
        private System.Windows.Forms.Label label1;
    }
}