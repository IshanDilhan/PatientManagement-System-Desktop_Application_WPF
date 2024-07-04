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


namespace WPF_LoginForm.View
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        public LoginView()
        {
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }



private void btnMinimize_Click(object sender, RoutedEventArgs e)
    {
        WindowState = WindowState.Minimized;
    }

    private void btnfullscrean(object sender, RoutedEventArgs e)
    {
        // Toggle full screen mode
        if (WindowState == WindowState.Maximized)
        {
            WindowStyle = WindowStyle.SingleBorderWindow;
            WindowState = WindowState.Normal;
        }
        else
        {
            WindowStyle = WindowStyle.None;
            WindowState = WindowState.Maximized;
        }
    }

    private void btnClose_Click(object sender, RoutedEventArgs e)
    {
        Application.Current.Shutdown();
    }


    private void registeradminbtn(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new Page6();
        }
        private bool ValidateCredentials(string enteredUsername, string enteredPassword)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=hospitalDB;Integrated Security=True"))
                {
                    con.Open();

                    using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Admin_Table WHERE Admin_Username = @Username AND Admin_Password = @Password", con))
                    {
                        cmd.Parameters.AddWithValue("@Username", enteredUsername);
                        cmd.Parameters.AddWithValue("@Password", enteredPassword);

                        int count = (int)cmd.ExecuteScalar();

                        return count > 0;
                    }
                }
            }
            catch (SqlException ex)
            {
                // Log the exception details instead of displaying them to the user
                // Log.Error("Database error", ex);
                MessageBox.Show("An error occurred during login. Please try again later.");
                return false;
            }
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string enteredUsername = txtUsername.Text;
            string enteredPassword = txtpass.Password;

            if (ValidateCredentials(enteredUsername, enteredPassword))
            {
                // Navigate to Page1 if credentials are valid
                MainFrame.Content = new Page1();
                txtUsername.Clear();
                txtpass.Clear();
            }
            else
            {
                MessageBox.Show("Invalid username or password");

                // Clear username and password fields
                txtUsername.Clear();
                txtpass.Clear();
            }
        }

        private void MainFrame_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {

        }
    }
}