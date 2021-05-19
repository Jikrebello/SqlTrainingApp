using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SqlTrainingApp
{
    public partial class CustomerForm : Form
    {
        // Global variables
        private readonly string connectionString = @"Data Source = localHost; Initial Catalog = Database Fundamentals 98-364; Integrated Security = true;";
        SqlConnection sqlConnection;

        // Constructor
        public CustomerForm()
        {
            InitializeComponent();
        }

        //Display methods
        void DisplayList()
        {
            listviewMain.Items.Clear();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Open the connection to the SQL database
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(@"SELECT [CustomerID] ,[FirstName], [LastName] ,[Phone Number] , [Email Address] FROM Customers", connection))
                    {
                        //Set the command type to text
                        command.CommandType = CommandType.Text;

                        //Open the data reader and fill in each item in the column from the returned SQL command
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            string[] items = {  reader[0].ToString(),reader[1].ToString(),reader[2].ToString(),reader[3].ToString(),reader[4].ToString()};

                            listviewMain.Items.Add(new ListViewItem(items));
                        }
                    }

                    // Close the connection
                    connection.Close();

                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }

        }

        void ClearTextBoxes()
        {
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtPhoneNumber.Text = "";
            txtEmailAddress.Text = "";
        }

        // Form methods
        private void Form1_Load(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            DisplayList();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            // Get the procedure
            using (SqlCommand command = new SqlCommand(@"prCreateCustomer", sqlConnection))
            {
                // Sets the command type to a stored procedure
                command.CommandType = CommandType.StoredProcedure;
            
                // setting the first name for the procedure
                SqlParameter sqlParameter1 = new SqlParameter(@"@FirstName", SqlDbType.VarChar)
                {
                    Value = txtFirstName.Text
                };
            
                // Last name
                SqlParameter sqlParameter2 = new SqlParameter(@"@LastName", SqlDbType.VarChar)
                {
                    //Direction = ParameterDirection.Output 
                    Value= txtLastName.Text
                };
            
                //Phone number
                SqlParameter sqlParameter3 = new SqlParameter(@"@PhoneNumber", SqlDbType.VarChar)
                {
                    Value = txtPhoneNumber.Text
                };
            
                //Email address
                SqlParameter sqlParameter4 = new SqlParameter(@"@EmailAddress", SqlDbType.VarChar)
                {
                    Value = txtEmailAddress.Text
                };
            
                //Adds the parameters to the command
                command.Parameters.Add(sqlParameter1);
                command.Parameters.Add(sqlParameter2);
                command.Parameters.Add(sqlParameter3);
                command.Parameters.Add(sqlParameter4);
            
                // Execute the command (non query doesn't return a value)
                command.ExecuteNonQuery();
            }
            
            // Clear the text boxes
            ClearTextBoxes();
            DisplayList();
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (listviewMain.SelectedItems.Count > 0)
            {
                // Get the procedure
                using (SqlCommand command = new SqlCommand(@"prDeleteCustomer", sqlConnection))
                {
                    // Set the command type to stored procedure
                    command.CommandType = CommandType.StoredProcedure;

                    // Capture the parameters on the procedure
                    SqlParameter sqlParameter = new SqlParameter(@"@CustomerID", SqlDbType.Int)
                    {
                        Value = Convert.ToInt32(listviewMain.SelectedItems[0].Text)
                    };

                    command.Parameters.Add(sqlParameter);
                
                    // execute the stored procedure
                    command.ExecuteNonQuery();
                }
            }
            DisplayList();
        }
            
        private void txt_Update_Click(object sender, EventArgs e)
        {

            using (SqlCommand command = new SqlCommand(@"prUpdateCustomer", sqlConnection))
            {
                command.CommandType = CommandType.StoredProcedure;
            
                //First Name
                SqlParameter sqlParameter1 = new SqlParameter(@"@FirstName", SqlDbType.VarChar)
                {
                    Value = txtFirstName.Text
                };
            
                //Last Name
                SqlParameter sqlParameter2 = new SqlParameter(@"@LastName", SqlDbType.VarChar)
                {
                    Value = txtLastName.Text
                };
            
                //Phone Number
                SqlParameter sqlParameter3 = new SqlParameter(@"@PhoneNumber", SqlDbType.VarChar)
                {
                    Value = txtPhoneNumber.Text
                };
            
                //Email Address
                SqlParameter sqlParameter4 = new SqlParameter(@"@EmailAddress", SqlDbType.VarChar)
                {
                    Value = txtEmailAddress.Text
                };
            
                //Customer ID
                SqlParameter sqlParameter5 = new SqlParameter(@"@CustomerID", SqlDbType.Int)
                {
                    Value = Convert.ToInt32(listviewMain.SelectedItems[0].Text)
                };
            
                command.Parameters.Add(sqlParameter1);
                command.Parameters.Add(sqlParameter2);
                command.Parameters.Add(sqlParameter3);
                command.Parameters.Add(sqlParameter4);
                command.Parameters.Add(sqlParameter5);
            
                command.ExecuteNonQuery();
            }
            DisplayList();
            ClearTextBoxes();
        }

        private void btn_GoToParts_Click(object sender, EventArgs e)
        {
            PartsForm partsForm = new PartsForm();
            partsForm.ShowDialog();
        }

        private void btn_GoToInvoices_Click(object sender, EventArgs e)
        {
            InvoiceForm invoiceForm = new InvoiceForm();
            invoiceForm.ShowDialog();
        }
    }
}
