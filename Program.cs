using System;
using System.Windows.Forms;

namespace Test
{
    internal static class Program
    {
        public static string connectionString = "Server = DESKTOP-P952G38\\SQLEXPRESS; Database = botan; Trusted_Connection = true;";

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormAuthorization());
        }
    }
}
