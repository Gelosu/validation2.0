using Microsoft.VisualBasic.Devices;
using MySql.Data.MySqlClient;
using System.Data;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace VALIDATION2
{
    public partial class Form2 : Form
    {
        private string connectionString = "server=localhost;database=validationfile;uid=root;pwd=12345;";
        private FileSystemWatcher fileWatcher;

        public Form2()
        {
            InitializeComponent();
            comboBox1.Text = "Select Course";
            InitializeFileWatcher();
            Loadcourse();
        }

        private void InitializeFileWatcher()
        {
            fileWatcher = new FileSystemWatcher();
            fileWatcher.Path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "RECORDS");
            fileWatcher.Filter = "*.csv";
            fileWatcher.NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.Size;
            fileWatcher.Changed += OnChanged;
            fileWatcher.Created += OnChanged;
            fileWatcher.Deleted += OnChanged;
            fileWatcher.EnableRaisingEvents = true;
        }

        private void OnChanged(object sender, FileSystemEventArgs e)
        {
            Invoke(new Action(() =>
            {
                LoadTableNames();
                if (comboBox1.SelectedItem != null)
                {
                    string tableName = comboBox1.SelectedItem.ToString();
                    LoadTableData(tableName);
                }
            }));
        }

        private void LoadTableNames()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    DataTable tables = connection.GetSchema("Tables");

                    comboBox1.Items.Clear();
                    foreach (DataRow row in tables.Rows)
                    {
                        string tableName = row[2].ToString();
                        if (tableName != "credentials" && tableName != "course" && tableName!="logs")
                        {
                            comboBox1.Items.Add(tableName);
                        }

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to load table names. Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            ApplyFilters();

        }
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void dataGridView1_CellContentClick(object sender, EventArgs e)
        {

        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tableName = comboBox1.SelectedItem.ToString();
            LoadTableData(tableName);

        }

        private void facultyFilters()
        {
            {
                if (loadedTable == null) return;

                DataView view = loadedTable.DefaultView;
                StringBuilder filter = new StringBuilder();

                if (!string.IsNullOrWhiteSpace(textBox1.Text))
                {

                    filter.Append($"(QRCODE LIKE '%{textBox1.Text}%' OR NAME LIKE '%{textBox1.Text}%'  OR UID LIKE '%{textBox1.Text}%')");
                }


               comboBox2.Enabled= false;
           

                view.RowFilter = filter.ToString();
                dataGridView1.DataSource = view;
            }
        }
        private void ApplyFilters()
        {
            {   
                if (loadedTable == null) return;
                comboBox2.Enabled = true;

                DataView view = loadedTable.DefaultView;
                StringBuilder filter = new StringBuilder();

                if (!string.IsNullOrWhiteSpace(textBox1.Text))
                {   
                   
                    filter.Append($"(QRCODE LIKE '%{textBox1.Text}%' OR TUPCID LIKE '%{textBox1.Text}%'  OR UID LIKE '%{textBox1.Text}%' OR STATUS LIKE '%{textBox1.Text}%')");
                }


                if (comboBox2.SelectedItem != "Select Course")
                {
                    if (filter.Length > 0)
                    {
                        filter.Append(" AND ");
                    }
                    filter.Append($"QRCODE LIKE'%{comboBox2.SelectedItem}%'");
                }

                
                if (checkBox1.Checked) 
                {
                    filter.Append("STATUS = VALIDATED");
                }
                if (checkBox2.Checked) 
                {
                    filter.Append("STATUS = NOT VALIDATED'");
                }


                view.RowFilter = filter.ToString();
                dataGridView1.DataSource = view;
            }
        }


        private DataTable loadedTable;
        private string tableName;

        private void LoadTableData(string tableName)
        {
            this.tableName = tableName;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = $"SELECT * FROM {tableName}";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    
                    DataRow[] filteredRows = table.Select("QRCODE IS NOT NULL AND QRCODE <> ''");
                    DataTable filteredTable = table.Clone(); 
                    foreach (DataRow row in filteredRows)
                    {
                        filteredTable.ImportRow(row);
                    }

                    loadedTable = filteredTable;

                    if (tableName == "faculty")
                    {
                        facultyFilters();
                    }
                    else
                    {
                        ApplyFilters();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to load table data. Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



        private DataTable FilterDataTable(DataTable dataTable, int columnIndex)
        {
            DataTable filteredTable = dataTable.Clone();
            foreach (DataRow row in dataTable.Rows)
            {
                if (!string.IsNullOrWhiteSpace(row[columnIndex]?.ToString()))
                {
                    filteredTable.ImportRow(row);
                }
            }
            return filteredTable;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            LoadTableNames();
            Loadcourse();
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    string fileName = Path.GetFileNameWithoutExtension(filePath);
                    string tableName = GenerateValidTableName(fileName);
                    DataTable csvData = GetDataTableFromCSV(filePath);
                    CreateDatabaseTable(tableName, csvData);
                    InsertDataIntoDatabaseTable(tableName, csvData);


                    LoadTableNames();
                    if (comboBox1.Items.Contains(tableName))
                    {
                        comboBox1.SelectedItem = tableName;
                        LoadTableData(tableName);
                    }
                }
            }
        }

        private string GenerateValidTableName(string input)
        {
            return Regex.Replace(input, "[^a-zA-Z0-9_]", "_");
        }

        private void CreateDatabaseTable(string tableName, DataTable table)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string createTableQuery = $"CREATE TABLE IF NOT EXISTS {tableName} (" +
                                              "QRCODE VARCHAR(255), " +
                                              "TUPCID VARCHAR(255), " +
                                              "UID VARCHAR(255), " +
                                              "STATUS VARCHAR(255), " +
                                              "DATETIME DATETIME)";

                    using (MySqlCommand cmd = new MySqlCommand(createTableQuery, connection))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to create table. Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void InsertDataIntoDatabaseTable(string tableName, DataTable table)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    foreach (DataRow row in table.Rows)
                    {
                        if(tableName != "faculty")
                        {
                            string qrcode = row[0].ToString();
                        string tupcid = row[1].ToString();
                        string uid = row[2].ToString();

                        
                            string checkQuery = $"SELECT COUNT(*) FROM {tableName} WHERE QRCODE = @QRCODE AND TUPCID = @TUPCID AND UID = @UID";
                            using (MySqlCommand checkCmd = new MySqlCommand(checkQuery, connection))
                            {
                                checkCmd.Parameters.AddWithValue("@QRCODE", qrcode);
                                checkCmd.Parameters.AddWithValue("@TUPCID", tupcid);
                                checkCmd.Parameters.AddWithValue("@UID", uid);
                                int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                                if (count > 0)
                                {
                                    string updateQuery = $"UPDATE {tableName} SET STATUS = 'VALIDATED', DATETIME = NOW() WHERE QRCODE = @QRCODE AND TUPCID = @TUPCID AND UID = @UID";
                                    using (MySqlCommand updateCmd = new MySqlCommand(updateQuery, connection))
                                    {
                                        updateCmd.Parameters.AddWithValue("@QRCODE", qrcode);
                                        updateCmd.Parameters.AddWithValue("@TUPCID", tupcid);
                                        updateCmd.Parameters.AddWithValue("@UID", uid);
                                        updateCmd.ExecuteNonQuery();
                                    }
                                }
                                else
                                {
                                    string insertQuery = $"INSERT INTO {tableName} (QRCODE, TUPCID, UID, STATUS, DATETIME) " +
                                                         "VALUES (@QRCODE, @TUPCID, @UID, 'NOT VALIDATED', NULL)";
                                    using (MySqlCommand insertCmd = new MySqlCommand(insertQuery, connection))
                                    {
                                        insertCmd.Parameters.AddWithValue("@QRCODE", qrcode);
                                        insertCmd.Parameters.AddWithValue("@TUPCID", tupcid);
                                        insertCmd.Parameters.AddWithValue("@UID", uid);
                                        insertCmd.ExecuteNonQuery();
                                    }
                                }
                            }
                        }
                        else
                        {

                            string name = row[3].ToString();

                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to insert/update data. Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }


                private DataTable GetDataTableFromCSV(string filePath)
        {
            DataTable dt = new DataTable();
            using (StreamReader sr = new StreamReader(filePath))
            {
                string[] headers = sr.ReadLine().Split(',');
                foreach (string header in headers)
                {
                    dt.Columns.Add(header);
                }
                while (!sr.EndOfStream)
                {
                    string[] rows = sr.ReadLine().Split(',');
                    DataRow dr = dt.NewRow();
                    for (int i = 0; i < headers.Length; i++)
                    {
                        dr[i] = rows[i];
                    }
                    dt.Rows.Add(dr);
                }
            }
            return dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string course = comboBox2.SelectedItem.ToString();
            ApplyFilters();

        }
        private void Loadcourse()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT COURSE FROM course";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    comboBox2.Items.Clear();
                    comboBox2.Items.Add("Select Course");
                    while (reader.Read())
                    {
                        string course = reader["COURSE"].ToString();
                        
                        comboBox2.Items.Add(course);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to load course data. Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            refresh();
        }
        private void refresh()
        {
            if (comboBox1.SelectedItem != null)
            {
                string tableName = comboBox1.SelectedItem.ToString();
                LoadTableData(tableName);
                comboBox2.SelectedIndex = 0;
                textBox1.Text = "";

            }
            else
            {
                MessageBox.Show("Please select a table from ComboBox1 to reload.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
             if (tableName != "faculty")
            {
                ApplyFilters();

            }
            else
            {
                facultyFilters();
            }
        }

    }
}
