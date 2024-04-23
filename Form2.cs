using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using System;

namespace Test
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void button3_Click(object sender, EventArgs e) // Изменения в БД смотря на dataGridView
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(Program.connectionString))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter($"select * from {comboBox1.Text}", connection))
                {
                    using (SqlCommandBuilder builder = new SqlCommandBuilder(adapter))
                    {
                        try
                        {
                            adapter.Update((DataTable)dataGridView1.DataSource);
                            MessageBox.Show("Update Access");
                        }
                        catch (Exception ex) { MessageBox.Show("Error Save\n" + ex.Message); }
                    }
                }
            }
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e) // Закрыть приложение
        {
            Application.Exit();
        }

        // Роли
        public void Admin() // Администратор
        {
            comboBox1.Items.Add("workers");
            comboBox1.Items.Add("orders");
            comboBox1.Items.Add("cahnges");
        }

        public void Sealer() // Повар
        {
            comboBox1.Items.Add("orders");
        }

        public void Client() // Официант
        {
            comboBox1.Items.Add("orders");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            string queryString = $"select * from {comboBox1.Text}";
            using (SqlConnection connection = new SqlConnection(Program.connectionString))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(queryString, connection))
                {
                    try
                    {
                        adapter.Fill(dt);
                    }
                    catch (Exception ex) { MessageBox.Show("Error Select\n" + ex.Message); }
                }
            }

            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].ReadOnly = true;
        }
    }
}