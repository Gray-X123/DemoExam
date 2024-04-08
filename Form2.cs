using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using System;

namespace Test
{
    public partial class Form2 : Form
    {
        readonly string connectionString = "Server = DESKTOP-P952G38; Database = db; Trusted_Connection = true;";

        public Form2()
        {
            InitializeComponent();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void button3_Click(object sender, EventArgs e) // Изменения в БД смотря на dataGridView
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
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

        private void comboBox1_SelectedIndexChanged(object sender, System.EventArgs e) // Вывод данных
        {
            DataTable dt = new DataTable();
            string queryString = $"select * from {comboBox1.Text}";
            using (SqlConnection connection = new SqlConnection(connectionString))
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

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e) // Запрещает ввод в comboBox с клавиатуры
        {
            e.Handled = true;
        }

        // Роли
        public void Admin() // Администратор
        {
            comboBox1.Items.Add("workers");
            comboBox1.Items.Add("table_1");
            comboBox1.Items.Add("table_2");
        }

        public void Sealer() // Продавец
        {
            comboBox1.Items.Add("table_1");
            comboBox1.Items.Add("table_2");
        }

        public void Client() // Клиент
        {
            comboBox1.Items.Add("table_2");
        }
    }
}
