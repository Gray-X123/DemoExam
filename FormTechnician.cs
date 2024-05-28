using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace Test
{
    public partial class FormTechnician : Form
    {
        public FormTechnician()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
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

        private void FormTechnician_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button_Refresh_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Program.connectionString))
                {
                    DataTable dt = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter($"select * from {comboBox1.Text}", connection);
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                    dataGridView1.AllowUserToAddRows = false;
                    dataGridView1.AllowUserToDeleteRows = false;
                    dataGridView1.Columns[0].ReadOnly = true;
                    dataGridView1.Columns[1].ReadOnly = true;
                    dataGridView1.Columns[2].ReadOnly = true;
                    dataGridView1.Columns[4].ReadOnly = true;
                }
            }
            catch (Exception ex) { MessageBox.Show("Error Refresh\n" + ex.Message); }
        }
    }
}
