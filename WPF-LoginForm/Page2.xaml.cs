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


namespace WPF_LoginForm
{
    /// <summary>
    /// Interaction logic for Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {
        public Page2()
        {
            InitializeComponent();
            LoadGrid();
              
        }
        public void clearData()
        {
            txtPationname.Clear();
            txtPationage.Clear();
            txtguardianTP.Clear();
            txtWardnumber.Clear();
            txtReason.Clear();
            txtOther.Clear();

        }
        SqlConnection con = new SqlConnection(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=hospitalDB;Integrated Security=True ");
        

        public void LoadGrid()
        {
            SqlCommand cmd = new SqlCommand("select * from Pation_Table",con);
            DataTable dt= new DataTable();
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            datagrid.ItemsSource = dt.DefaultView;
        }
        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (sender is CheckBox checkBox)
            {
                // Access the CheckBox properties or perform actions
                if (checkBox == maleCheckBox)
                {
                    // Do something when Male CheckBox is checked
                }
                else if (checkBox == femaleCheckBox)
                {
                    // Do something when Female CheckBox is checked
                }
            }
        }


        public bool isValid()
        {
            if (string.IsNullOrEmpty(txtPationname.Text))
            {
                ShowErrorMessage("Enter Patient Name");
                return false;
            }
            if (string.IsNullOrEmpty(txtPationage.Text))
            {
                ShowErrorMessage("Enter Patient Age");
                return false;
            }
            if (string.IsNullOrEmpty(txtguardianTP.Text))
            {
                ShowErrorMessage("Enter Guardian Telephone");
                return false;
            }
            if (string.IsNullOrEmpty(txtWardnumber.Text))
            {
                ShowErrorMessage("Enter Ward Number");
                return false;
            }
            if (string.IsNullOrEmpty(txtReason.Text))
            {
                ShowErrorMessage("Enter Reason");
                return false;
            }
            if (string.IsNullOrEmpty(txtOther.Text))
            {
                ShowErrorMessage("Enter Other Details");
                return false;
            }
            if (!(maleCheckBox.IsChecked == true || femaleCheckBox.IsChecked == true))
            {
                ShowErrorMessage("Select at least one gender");
                return false;
            }

            return true;
        }

        private void ShowErrorMessage(string message)
        {
            MessageBox.Show(message, "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (isValid())
                {
                    string gender = (maleCheckBox.IsChecked == true) ? "Male" : "Female";

                    SqlCommand cmd = new SqlCommand("INSERT INTO Pation_Table VALUES (@Pation_Name, @Pation_Age, @Pation_gender, @Guardian_TP, @Reason, @Ward, @other, @Admin_Regi_nu)", con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@Pation_Name", txtPationname.Text);
                    cmd.Parameters.AddWithValue("@Pation_Age", txtPationage.Text);
                    cmd.Parameters.AddWithValue("@Pation_gender", gender); // Update this line
                    cmd.Parameters.AddWithValue("@Guardian_TP", txtguardianTP.Text);
                    cmd.Parameters.AddWithValue("@Reason", txtReason.Text);
                    cmd.Parameters.AddWithValue("@Ward", txtWardnumber.Text);
                    cmd.Parameters.AddWithValue("@other", txtOther.Text);
                    cmd.Parameters.AddWithValue("@Admin_Regi_nu", "4");
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    LoadGrid();
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
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void back_button(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("Page1.xaml", UriKind.Relative));
        }

        private void maleCheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void femaleCheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}
