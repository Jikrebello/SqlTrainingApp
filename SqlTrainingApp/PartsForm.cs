using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SqlTrainingApp
{
    public partial class PartsForm : Form
    {
        private readonly string connectionString = @"Data Source = localHost; Initial Catalog = Database Fundamentals 98-364; Integrated Security = true;";
        public PartsForm()
        {
            InitializeComponent();
        }

        void DisplayList()
        {
            listviewMain.Items.Clear();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Open the connection to the SQL database
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(@"SELECT [Part Number] ,[Catergory], [Description] , [Quantity] , [Cost Price], [Sell Price] FROM Parts", connection))
                    {
                        //Set the command type to text
                        command.CommandType = CommandType.Text;

                        //Open the data reader and fill in each item in the column from the returned SQL command
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            string[] items = { reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString(), reader[5].ToString() };

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
            txtCategory.Text = "";
            txtDescription.Text = "";
            txtQuantity.Text = "";
            txtCostPrice.Text = "";
            txtSellPrice.Text = "";
        }

        private void PartsForm_Load(object sender, EventArgs e)
        {
            DisplayList();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    //Open up the SQL connection to the database
                    connection.Open();

                    // Get the procedure
                    using (SqlCommand command = new SqlCommand(@"prCreatePart", connection))
                    {
                        // Sets the command type to a stored procedure
                        command.CommandType = CommandType.StoredProcedure;

                        // setting Catergory for the procedure
                        SqlParameter sqlParameter1 = new SqlParameter(@"@Catergory", SqlDbType.VarChar)
                        {
                            Value = txtCategory.Text
                        };

                        // Description
                        SqlParameter sqlParameter2 = new SqlParameter(@"@Description", SqlDbType.VarChar)
                        {
                            Value = txtDescription.Text
                        };

                        //Quantity
                        SqlParameter sqlParameter3 = new SqlParameter(@"@Quantity", SqlDbType.Int)
                        {
                            Value = txtQuantity.Text
                        };

                        //Cost value
                        SqlParameter sqlParameter4 = new SqlParameter(@"@CostPrice", SqlDbType.Money)
                        {
                            Value = txtCostPrice.Text
                        };

                        // Sell value
                        SqlParameter sqlParameter5 = new SqlParameter(@"@SellPrice", SqlDbType.Money)
                        {
                            Value = txtSellPrice.Text
                        };

                        //Adds the parameters to the command
                        command.Parameters.Add(sqlParameter1);
                        command.Parameters.Add(sqlParameter2);
                        command.Parameters.Add(sqlParameter3);
                        command.Parameters.Add(sqlParameter4);
                        command.Parameters.Add(sqlParameter5);

                        // Execute the command (non query doesn't return a value)
                        command.ExecuteNonQuery();
                    }

                    //Close the connection
                    connection.Close();
                }

                // Clear the text boxes
                ClearTextBoxes();
            }
            catch (Exception ex)
            {

                lblError.Text = ex.Message;
            }

            DisplayList();
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (listviewMain.SelectedItems.Count > 0)
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        // Open the connection
                        connection.Open();

                        // Get the procedure
                        using (SqlCommand command = new SqlCommand(@"prDeletePart", connection))
                        {
                            // Set the command type to stored procedure
                            command.CommandType = CommandType.StoredProcedure;

                            // Capture the parameters on the procedure
                            SqlParameter sqlParameter1 = new SqlParameter(@"@PartNumber", SqlDbType.Int);

                            sqlParameter1.Value = Convert.ToInt32(listviewMain.SelectedItems[0].Text);
                            command.Parameters.Add(sqlParameter1);

                            // execute the stored procedure
                            command.ExecuteNonQuery();
                        }

                        // Close the connection
                        connection.Close();
                    }
                }
                catch (Exception ex)
                {
                    lblError.Text = ex.Message;
                }

                DisplayList();
            }

        }

        private void txt_Update_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    // Open the connection to the SQL database
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(@"prUpdatePart", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        //category
                        SqlParameter sqlParameter1 = new SqlParameter(@"@Catergory", SqlDbType.VarChar)
                        {
                            Value = txtCategory.Text
                        };

                        //description
                        SqlParameter sqlParameter2 = new SqlParameter(@"@Description", SqlDbType.VarChar)
                        {
                            Value = txtDescription.Text
                        };

                        //quantity
                        SqlParameter sqlParameter3 = new SqlParameter(@"@Quantity", SqlDbType.VarChar)
                        {
                            Value = txtQuantity.Text
                        };

                        //cost price
                        SqlParameter sqlParameter4 = new SqlParameter(@"@CostPrice", SqlDbType.VarChar)
                        {
                            Value = txtCostPrice.Text
                        };

                        //sell price
                        SqlParameter sqlParameter5 = new SqlParameter(@"@SellPrice", SqlDbType.VarChar)
                        {
                            Value = txtSellPrice.Text
                        };

                        //parts number
                        SqlParameter sqlParameter6 = new SqlParameter(@"PartNumber", SqlDbType.Int)
                        {
                            Value = Convert.ToInt32(listviewMain.SelectedItems[0].Text)
                        };

                        command.Parameters.Add(sqlParameter1);
                        command.Parameters.Add(sqlParameter2);
                        command.Parameters.Add(sqlParameter3);
                        command.Parameters.Add(sqlParameter4);
                        command.Parameters.Add(sqlParameter5);
                        command.Parameters.Add(sqlParameter6);

                        command.ExecuteNonQuery();
                    }

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
            DisplayList();
        }

        private void btn_GoToCustomers_Click(object sender, EventArgs e)
        {
            CustomerForm customerForm = new CustomerForm();
            customerForm.ShowDialog();
        }
    }
}
