using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;
using WPF_LoginForm.View;

namespace WPF_LoginForm
{
    /// <summary>
    /// Interaction logic for Page6.xaml
    /// </summary>
    public partial class Page6 : Page
    {
        public Page6()
        {
            InitializeComponent();
        }

        public void clearData()
        {
            txtname.Clear();
            txtemail.Clear();
            txtusername.Clear();
            txtpassword.Clear();
            txtrepassword.Clear();

        }

        SqlConnection con = new SqlConnection(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=hospitalDB;Integrated Security=True ");
        public bool isValid()
        {
            if (txtname.Text == string.Empty)
            {
                MessageBox.Show("Enter Patient Name", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (txtemail.Text == string.Empty)
            {
                MessageBox.Show("Enter Patient Name", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (txtusername.Text == string.Empty)
            {
                MessageBox.Show("Enter Patient Name", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (txtpassword.Text == string.Empty)
            {
                MessageBox.Show("Enter Patient Name", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (txtrepassword.Text == string.Empty)
            {
                MessageBox.Show("Enter Patient Name", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (txtpassword.Text != txtrepassword.Text)
            {
                MessageBox.Show("Passwords do not match", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;

        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (isValid())
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO Admin_Table (Admin_Name, Admin_Email, Admin_Username, Admin_Password, Admin_Regi_nu) VALUES (@Admin_Name, @Admin_Email, @Admin_Username, @Admin_Password, @Admin_Regi_nu)", con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@Admin_Name", txtname.Text);
                    
                    cmd.Parameters.AddWithValue("@Admin_Email", txtemail.Text);
                    cmd.Parameters.AddWithValue("@Admin_Username", txtusername.Text);
                    cmd.Parameters.AddWithValue("@Admin_Password", txtpassword.Text);
           
                    cmd.Parameters.AddWithValue("@Admin_Regi_nu", "1");
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
            
                    MessageBox.Show("Successfully Registered", "Saved", MessageBoxButton.OK, MessageBoxImage.Information);
                    clearData();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnclearall(object sender, RoutedEventArgs e)
        {

            clearData();



        }

        private void backbtn(object sender, RoutedEventArgs e)
        {

            



        }
        private void back_button(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("Page7.xaml", UriKind.Relative));
        }


    }
}
