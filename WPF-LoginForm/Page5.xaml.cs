using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace WPF_LoginForm
{
    /// <summary>
    /// Interaction logic for Page5.xaml
    /// </summary>
    public partial class Page5 : Page
    {
        private DataTable originalDataTable;
        private DataTable currentDataTable;

        SqlConnection con = new SqlConnection(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=hospitalDB;Integrated Security=True ");

        public Page5()
        {
            InitializeComponent();
            LoadGrid();
            originalDataTable = LoadDataFromDatabase();
            currentDataTable = originalDataTable.Copy();
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

        private DataTable LoadDataFromDatabase()
        {
            SqlCommand cmd = new SqlCommand("select * from Pation_Table", con);
            DataTable dataTable = new DataTable();
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dataTable.Load(sdr);
            con.Close();
            return dataTable;
        }

        private void SaveChangesToDatabase()
        {
            // Save changes from currentDataTable back to the database
            using (SqlCommand cmd = new SqlCommand("DELETE FROM Pation_Table", con))
            {
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                using (SqlBulkCopy bulkCopy = new SqlBulkCopy(con))
                {
                    bulkCopy.DestinationTableName = "Pation_Table";
                    con.Open();
                    bulkCopy.WriteToServer(currentDataTable);
                    con.Close();
                }
            }
        }
        private void back_button(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("Page1.xaml", UriKind.Relative));
        }
        private void UndoChanges()
        {
            // Simply copy the originalDataTable back to the currentDataTable
            currentDataTable = originalDataTable.Copy();

            // Refresh your UI controls
            datagrid.ItemsSource = currentDataTable.DefaultView;
        }

        private void deletebtn(object sender, RoutedEventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from Pation_Table where Pation_Id = " + search_txt.Text + " ", con);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record has been deleted", "deleted", MessageBoxButton.OK, MessageBoxImage.Information);
                con.Close();
                search_txt.Clear();
                LoadGrid();
                con.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }

            LoadGrid();
        }

        private void undobtn(object sender, RoutedEventArgs e)
        {
            // Undo changes
            UndoChanges();
            MessageBox.Show("Changes undone!");
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            // Save changes to the database
            SaveChangesToDatabase();
            MessageBox.Show("Changes saved successfully!");
        }
    }
}
