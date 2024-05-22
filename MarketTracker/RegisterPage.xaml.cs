using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MarketTracker
{
    /// <summary>
    /// Interaction logic for RegisterPage.xaml
    /// </summary>
    public partial class RegisterPage : Window
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        private void RegisterPageRegisterButton_Click(object sender, RoutedEventArgs e)
        {
            if (txtUsernameRG.Text == "" && txtPasswordRG.Text == "")
            {
                MessageBox.Show("Enter the username or password");
            }
            else if (txtUsernameRG.Text == "")
            {
                MessageBox.Show("Enter the username");
            }
            else if (txtPasswordRG.Text == "")
            {
                MessageBox.Show("Enter the password");
            }
            else
            {
                try
                {
                    SqlConnection con = new SqlConnection("Data Source=ANDREW-PC\\SQLEXPRESS;Initial Catalog=LRMarketTracker;Integrated Security=True;TrustServerCertificate=True");
                    con.Open();
                    string add_data = "INSERT INTO [dbo].[tbl_LoginMarketTrader] VALUES(@username, @password)";
                    SqlCommand cmd = new SqlCommand(add_data, con);
                    cmd.Parameters.AddWithValue("@username", txtUsernameRG.Text);
                    cmd.Parameters.AddWithValue("@password", txtPasswordRG.Text);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    con.Close();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Registration Completed");
                        LoginPage loginPage = new LoginPage();
                        loginPage.Show();
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Registration Failed");
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("" + ex);
                }
            }
        }
    }
}
