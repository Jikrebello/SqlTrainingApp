using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Collections;

namespace SqlTrainingApp
{
    public partial class InvoiceForm : Form
    {
        private readonly string connectionString = @"Data Source = localHost; Initial Catalog = Database Fundamentals 98-364; Integrated Security = true;";
        private SqlConnection sqlConnection;


        // Constructor
        public InvoiceForm()
        {
            InitializeComponent();
        }

        // Custom Methods
        void DisplayList()
        {
            // Refreshs the list view
            listviewMain.Items.Clear();
            
            // Display all invoices in the listview.
            string sqlCommand = "SELECT * FROM vInvoices";
            
            // If the user selects a specific customer, then the selectedindex is greater than 0
            if (comboCustomer.SelectedIndex > 0)
            {
                // only show the invoices for that customer through its selected value.
                if (Convert.ToInt32(comboCustomer.SelectedValue.ToString()) > 0)
                {
                    sqlCommand = sqlCommand + " WHERE CustomerID = " + comboCustomer.SelectedValue.ToString();
                }
            }
            
            // Populate the listview off what is being selected.
            using (SqlCommand command = new SqlCommand(sqlCommand, sqlConnection))
            {
                //Set the command type to text
                command.CommandType = CommandType.Text;
            
                //Open the data reader and fill in each item in the column from the returned SQL command
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string[] items = { reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString(), reader[5].ToString(), reader[6].ToString() };
            
                    listviewMain.Items.Add(new ListViewItem(items));
                }
                // Close the reader
                reader.Close();
            
            }
        }

        // Form Methods
        private void Invoices_Load(object sender, EventArgs e)
        {
            // Opens the sql connection
            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            // Creates an array for showing the customers in the combobox
            ArrayList OurCustomers = new ArrayList();
            OurCustomers.Add(new Customer(0, "All")); //with an index at 0, it will display all invoices

            // Display Customers in the combo box
            using (SqlCommand command = new SqlCommand(@"SELECT CustomerID, FirstName FROM Customers", sqlConnection))
            {
                command.CommandType = CommandType.Text;
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    OurCustomers.Add(new Customer(Convert.ToInt32(reader[0]), reader[1].ToString()));
                }
                reader.Close();

                comboCustomer.DataSource = OurCustomers; // Set the data source of the combobox to the array list
                comboCustomer.DisplayMember = "Name"; // Set the value shown in the combobox to name in customer class
                comboCustomer.ValueMember = "ID";  // Set the actual value of the combobox to the id in the customer class

            }
            DisplayList();
        }
        private void btn_GoToCustomers_Click(object sender, EventArgs e)
        {
            CustomerForm customerForm = new CustomerForm();
            customerForm.ShowDialog();
        }
        private void BTN_GoToParts_Click(object sender, EventArgs e)
        {
            PartsForm partsForm = new PartsForm();
            partsForm.ShowDialog();
        }
        private void BTN_GoToAddInvoice_Click(object sender, EventArgs e)
        {
            AddInvoiceForm addInvoiceForm = new AddInvoiceForm();
            addInvoiceForm.ShowDialog();
        }
        private void comboCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayList();
        }
    }
}
