using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace VALIDATION2
{
    public partial class Form3 : Form
    {
        public event EventHandler Form3Closed;
        private string connectionString = "server=localhost;database=validationfile;uid=root;pwd=12345;";
        public Form3()
        {
            InitializeComponent();
            this.FormClosed += Form3_FormClosed;
        }
        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form3Closed?.Invoke(this, EventArgs.Empty); 
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string newTableName = SanitizeTableName(textBox1.Text); 

            if (!string.IsNullOrEmpty(newTableName))
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();

                        
                        if (DoesTableExist(connection, newTableName))
                        {
                            MessageBox.Show("Table already exists. Please create another name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        
                        string lastTableName = GetLastTableName(connection);

                       
                        CreateNewTable(lastTableName, newTableName, connection);
                        CopyDataAndUpdateStatus(lastTableName, newTableName, connection);

                        MessageBox.Show("New table created and data copied successfully.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Failed to create table or copy data. Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid table name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string SanitizeTableName(string tableName)
        {
            return Regex.Replace(tableName, "[^a-zA-Z0-9_]", "_");
        }

        private bool DoesTableExist(MySqlConnection connection, string tableName)
        {
            string query = $"SELECT COUNT(*) FROM information_schema.tables WHERE table_schema = 'validationfile' AND table_name = '{tableName}'";
            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                return Convert.ToInt32(command.ExecuteScalar()) > 0;
            }
        }

        private string GetLastTableName(MySqlConnection connection)
        {
            string query = "SELECT TABLE_NAME FROM information_schema.tables WHERE TABLE_SCHEMA = 'validationfile' ORDER BY CREATE_TIME DESC LIMIT 1";
            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                object result = command.ExecuteScalar();
                return result?.ToString();
            }
        }

        private void CreateNewTable(string sourceTableName, string newTableName, MySqlConnection connection)
        {
            string query = $"CREATE TABLE `{newTableName}` LIKE `{sourceTableName}`";
            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.ExecuteNonQuery();
            }
        }

        private void CopyDataAndUpdateStatus(string sourceTableName, string destinationTableName, MySqlConnection connection)
        {
            string query = $"INSERT INTO `{destinationTableName}` (QRCODE, TUPCID, UID, STATUS, DATETIME) SELECT QRCODE, TUPCID, UID, 'NOT VALIDATED', NULL FROM `{sourceTableName}`";
            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.ExecuteNonQuery();
            }
        }
    }
}
