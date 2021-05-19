using System;
using System.Data;
using System.Windows.Forms;
using System.Collections;
using System.Data.SqlClient;

namespace SqlTrainingApp
{
    public partial class AddInvoiceForm : Form
    {
        // Global variables
        private readonly string connectionString = @"Data Source = localHost; Initial Catalog = Database Fundamentals 98-364; Integrated Security = true;";
        private SqlConnection sqlConnection;

        // Constructor
        public AddInvoiceForm( )
        {
            InitializeComponent();
        }

        // Display Methods
        void DisplayComboBoxes()
        {
            ArrayList OurCustomers = new ArrayList();
            ArrayList OurParts = new ArrayList();

            // Display Customers in the combo box
            using (SqlCommand command1 = new SqlCommand(@"SELECT CustomerID, FirstName FROM Customers", sqlConnection))
            {
                command1.CommandType = CommandType.Text;
                SqlDataReader reader = command1.ExecuteReader();

                while (reader.Read())
                {
                    OurCustomers.Add(new Customer(Convert.ToInt32(reader[0]), reader[1].ToString()));
                }
                reader.Close();

                comboCustomer.DataSource = OurCustomers; // Set the data source of the combobox to the array list
                comboCustomer.DisplayMember = "Name"; // Set the value shown in the combobox to name in customer class
                comboCustomer.ValueMember = "ID"; // Set the actual value of the combobox to the id in the customer class

            }

            // Display the parts in the combo box
            using (SqlCommand command2 = new SqlCommand(@"SELECT [Part Number], Description FROM Parts", sqlConnection))
            {
                command2.CommandType = CommandType.Text;
                SqlDataReader reader = command2.ExecuteReader();

                while (reader.Read())
                {
                    OurParts.Add(new Parts(Convert.ToInt32(reader[0]), reader[1].ToString()));
                }
                reader.Close();

                comboParts.DataSource = OurParts; // Set the data source of the combobox to the array list
                comboParts.DisplayMember = "PartDescription"; // Set the value shown in the combobox to name in customer class
                comboParts.ValueMember = "ID"; // Set the actual value of the combobox to the id in the customer class

            }
        }

        // Form Methods
        private void AddInvoiceForm_Load(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            DisplayComboBoxes();
        }

        private void BTN_AddLine_Click(object sender, EventArgs e)
        {
            string[] items = { comboParts.DisplayMember.ToString(), txtQuantity.Text, txtPrice.Text};

            listView1.Items.Add(new ListViewItem(items));

            txtQuantity.Text = "";
            txtPrice.Text = "";
        }

        private void BTN_DeleteLine_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                for (int i = 0; i < listView1.Items.Count; i++)
                {
                    if (listView1.Items[i].Selected)
                    {
                        listView1.Items[i].Remove();
                        i--;
                    }
                }
            }
        }

        private void BTN_SaveInvoice_Click(object sender, EventArgs e)
        {
            int invoiceNumber = 0;
            using (SqlCommand command1 = new SqlCommand(@"prCreateInvoice", sqlConnection))
            {

                command1.CommandType = CommandType.StoredProcedure;

                SqlParameter sqlParameter1 = new SqlParameter(@"@CustomerID", SqlDbType.Int) { Value = comboCustomer.SelectedValue };
                SqlParameter sqlParameter2 = new SqlParameter(@"@InvoiceDate", SqlDbType.DateTime) { Value = dateTimePicker1.Value };
                SqlParameter sqlParameter3 = new SqlParameter(@"@InvoiceNumber", SqlDbType.Int) { Direction = ParameterDirection.Output };

                command1.Parameters.Add(sqlParameter1);
                command1.Parameters.Add(sqlParameter2);
                command1.Parameters.Add(sqlParameter3);

                command1.ExecuteNonQuery();
                invoiceNumber = Convert.ToInt32(sqlParameter3.Value);
            }

            foreach (ListViewItem lvi in listView1.Items)
            {
                using (SqlCommand command2 = new SqlCommand(@"prCreateInvoiceLine", sqlConnection))
                {
                    command2.CommandType = CommandType.StoredProcedure;

                    SqlParameter sqlParameter1 = new SqlParameter(@"@InvoiceNumber", SqlDbType.Int) { Value = invoiceNumber };
                    SqlParameter sqlParameter2 = new SqlParameter(@"@PartsNumber", SqlDbType.Int) { Value = Convert.ToInt32(lvi.SubItems[0].Text) };
                    SqlParameter sqlParameter3 = new SqlParameter(@"@Quantity", SqlDbType.Int) { Value = Convert.ToInt32(lvi.SubItems[1].Text) };
                    SqlParameter sqlParameter4 = new SqlParameter(@"@TotalSale", SqlDbType.Int) { Value = Convert.ToInt32(lvi.SubItems[2].Text) };

                    command2.Parameters.Add(sqlParameter1); 
                    command2.Parameters.Add(sqlParameter2);
                    command2.Parameters.Add(sqlParameter3);
                    command2.Parameters.Add(sqlParameter4);

                    command2.ExecuteNonQuery();
                }
            }

            txtQuantity.Text = "";
            txtPrice.Text = "";
        }


    }
}
