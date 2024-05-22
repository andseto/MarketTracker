using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Window
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void LoginPageRegisterButton_Click(object sender, RoutedEventArgs e)
        {
            RegisterPage registerPage = new RegisterPage();
            registerPage.Show();
            Close();
        }

        private void LoginPageLoginButton_Click(object sender, RoutedEventArgs e)
        {
            if (txtUsernameLG.Text == "" &&  txtPasswordLG.Text == "")
            {
                MessageBox.Show("Enter the username and password");
            }
            else if (txtUsernameLG.Text == "")
            {
                MessageBox.Show("Enter the username");
            }
            else if (txtPasswordLG.Text == "")
            {
                MessageBox.Show("Enter the password");
            }
            else
            {
                try
                {
                    SqlConnection con = new SqlConnection("Data Source=ANDREW-PC\\SQLEXPRESS;Initial Catalog=LRMarketTracker;Integrated Security=True;TrustServerCertificate=True");
                    SqlCommand cmd = new SqlCommand("select * from tbl_LoginMarketTrader where username = @username and password = @password", con);
                    cmd.Parameters.AddWithValue("@username", txtUsernameLG.Text);
                    cmd.Parameters.AddWithValue("@password", txtPasswordLG.Text);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();

                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        MainWindow dashboard = new MainWindow();
                        dashboard.Show();
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("login failed");
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
