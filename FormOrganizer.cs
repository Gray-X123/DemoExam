using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace Test
{
    public partial class FormOrganizer : Form
    {
        public FormOrganizer()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void FormOrganizer_Load(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Program.connectionString))
                {
                    DataTable dt = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter("select * from orders", connection);
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                    dataGridView1.Columns[3].ReadOnly = true;
                }
            }
            catch (Exception ex) { MessageBox.Show("Error Refresh\n" + ex.Message); }
        }

        private void button_Exit_Click(object sender, EventArgs e)
        {
            FormAuthorization form = new FormAuthorization();
            form.Show();
            Hide();
        }

        private void FormOrganizer_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Program.connectionString))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter("select * from orders", connection);
                    SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
                    adapter.Update((DataTable)dataGridView1.DataSource);
                }
            }
            catch (Exception ex) { MessageBox.Show("Error Save\n" + ex.Message); }
        }
    }
}
