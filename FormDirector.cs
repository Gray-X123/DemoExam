using System.Windows.Forms;
using System.Data;
using System;
using System.Data.SqlClient;

namespace Test
{
    public partial class FormDirector : Form
    {
        public FormDirector()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;

            comboBox1.Items.Add("workers");
            comboBox1.Items.Add("[changes]");
            comboBox1.Items.Add("orders");
        }

        private void button_Exit_Click(object sender, System.EventArgs e) // Выход из аккаунта
        {
            FormAuthorization form = new FormAuthorization();
            form.Show();
            Hide();
        }

        private void button_Save_Click(object sender, System.EventArgs e) // Сохранение изменений в БД
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Program.connectionString))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter($"select * from {comboBox1.Text}", connection);
                    SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
                    adapter.Update((DataTable)dataGridView1.DataSource);
                }
            }
            catch (Exception ex) { MessageBox.Show("Error Save\n" + ex.Message); }
        }

        private void button_Refresh_Click(object sender, EventArgs e) // Обновить dataGridView
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Program.connectionString))
                {
                    DataTable dt = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter($"select * from {comboBox1.Text}", connection);
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                    CheckTable();
                    dataGridView1.Columns[0].ReadOnly = true;
                }
            }
            catch (Exception ex) { MessageBox.Show("Error Refresh\n" + ex.Message); }
        }

        private void CheckTable () // Для того, чтобы регистрация пользователей происходила в отдельном окне
        {
            dataGridView1.AllowUserToAddRows = true;
            if (comboBox1.Text == "workers")
                dataGridView1.AllowUserToAddRows = false;
        }

        private void button_WorkersAdd_Click(object sender, EventArgs e) // Открыть окно для регистрации пользователя
        {
            FormWorkerAdd worker = new FormWorkerAdd();
            worker.Show();
        }
    }
}
