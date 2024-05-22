using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Test
{
    public partial class FormAuthorization : Form
    {
        public FormAuthorization()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            textBox2.UseSystemPasswordChar = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(Program.connectionString))
            {
                string sqlQuery = $"select [Role] from workers where [Login] = @login and [Password] = @password";
                SqlCommand command = new SqlCommand(sqlQuery, connection);

                command.Parameters.Add(new SqlParameter("@login", textBox1.Text));
                command.Parameters.Add(new SqlParameter("@password", textBox2.Text));

                connection.Open();

                switch (command.ExecuteScalar())
                {
                    case "Заведующий":
                        FormDirector formDirector = new FormDirector();
                        formDirector.Show();
                        break;
                    case "Техник":
                        FormTechnician formTechnician = new FormTechnician();
                        formTechnician.Show();
                        break;
                    case "Организатор":
                        FormOrganizer formOrganizer = new FormOrganizer();
                        formOrganizer.Show();
                        break;
                    default:
                        MessageBox.Show("Аккаунта не существует");
                        return;
                }
                Hide();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}