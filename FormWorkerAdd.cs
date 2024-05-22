using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Test
{
    public partial class FormWorkerAdd : Form
    {
        public FormWorkerAdd()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;

            comboBox1.Items.Add("Заведующий");
            comboBox1.Items.Add("Техник");
            comboBox1.Items.Add("Организатор");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Program.connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("insert into workers values (@name, @role, @login, @password, @dissamble)", connection);
                    command.Parameters.Add(new SqlParameter("name", textBox1.Text));
                    command.Parameters.Add(new SqlParameter("role",comboBox1.Text));
                    command.Parameters.Add(new SqlParameter("login", textBox2.Text));
                    command.Parameters.Add(new SqlParameter("password", textBox3.Text));
                    command.Parameters.Add(new SqlParameter("dissamble", (object)0));
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex) { MessageBox.Show("Error Add\n" + ex.Message); }
        }
    }
}
