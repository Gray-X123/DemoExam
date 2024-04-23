using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) // Авторизация
        {
            using (SqlConnection connection = new SqlConnection(Program.connectionString))
            {
                string sqlQuery = $"select role from workers where [Login] = '{textBox1.Text}' and [Password] = '{textBox2.Text}'";
                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    connection.Open();
                    Form2 form = new Form2();
                    switch (command.ExecuteScalar())
                    {
                        case "Администратор":
                            form.Admin();
                            break;
                        case "Продавец":
                            form.Sealer();
                            break;
                        case "Клиент":
                            form.Client();
                            break;
                        default:
                            MessageBox.Show("Аккаунта не существует");
                            return;
                    }
                    Hide();
                    form.Show();
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e) // Закрыть приложение
        {
            Application.Exit();
        }
    }
}