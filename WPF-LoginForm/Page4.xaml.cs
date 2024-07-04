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
    /// Interaction logic for Page4.xaml
    /// </summary>
    public partial class Page4 : Page
    {
        public Page4()
        {
            InitializeComponent();
            LoadGrid();
        }
        SqlConnection con = new SqlConnection(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=hospitalDB;Integrated Security=True ");

        public void clearData()
        {
            txtPationname.Clear();
            txtPationage.Clear();
            txtguardianTP.Clear();
            txtWardnumber.Clear();
            txtReason.Clear();
            txtOther.Clear();
            txtId.Clear();

        }
        public void LoadGrid()
        {
            SqlCommand cmd = new SqlCommand("select * from Pation_Table", con);
            DataTable dt = new DataTable();
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            datagrid.ItemsSource = dt.DefaultView;
        }
        

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            con.Open();
            // Assuming 'con' is your SqlConnection object

            // Start building the query
            string query = "UPDATE Pation_Table SET ";

            // Check each field and add it to the query only if it has a non-null value
            if (!string.IsNullOrEmpty(txtPationname.Text))
                query += "Pation_Name = '" + txtPationname.Text + "', ";

            if (!string.IsNullOrEmpty(txtPationage.Text))
                query += "Pation_Age = '" + txtPationage.Text + "', ";

            if (!string.IsNullOrEmpty(txtguardianTP.Text))
                query += "Guardian_TP = '" + txtguardianTP.Text + "', ";

            if (!string.IsNullOrEmpty(txtWardnumber.Text))
                query += "Reason = '" + txtWardnumber.Text + "', ";

            if (!string.IsNullOrEmpty(txtReason.Text))
                query += "Ward = '" + txtReason.Text + "', ";

            if (!string.IsNullOrEmpty(txtOther.Text))
                query += "other = '" + txtOther.Text + "', ";

            // Remove the trailing comma
            query = query.TrimEnd(',', ' ');

            // Add the WHERE clause
            query += " WHERE Pation_Id = '" + txtId.Text + "'";

            // Create SqlCommand object with the dynamic query
            SqlCommand cmd = new SqlCommand(query, con);

            // Execute the query
            cmd.ExecuteNonQuery();

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record has been updated successfully", "Updated", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
                clearData();
                LoadGrid();
            }
        }
        private void back_button(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("Page1.xaml", UriKind.Relative));
        }
        private void btnclearall(object sender, RoutedEventArgs e)
        {
            clearData();

        }
    }
}
