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
    public partial class Page3 : Page
    {
        public Page3()
        {
            InitializeComponent();
            LoadGrid1();
            LoadGrid2();

        }
        public void clearData()
        {
            

        }
        SqlConnection con = new SqlConnection(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=hospitalDB;Integrated Security=True ");


        public void LoadGrid1()
        {
            SqlCommand cmd = new SqlCommand("select * from Pation_Table", con);
            DataTable dt = new DataTable();
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            datagrid.ItemsSource = dt.DefaultView;
        }
        public void LoadGrid2()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Pation_Table ORDER BY Pation_Id DESC", con);
            DataTable dt = new DataTable();
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            datagrid.ItemsSource = dt.DefaultView;
        }
        public void LoadGrid3()
        {
            ComboBoxItem selectedItem = (ComboBoxItem)groupByComboBox.SelectedItem;
            string associatedVariable = selectedItem?.Tag as string;

            if (associatedVariable != null)
            {
                string query = "SELECT * FROM Pation_Table WHERE ";

                switch (associatedVariable)
                {
                    case "Variable1ForGender":
                        query += "Pation_gender = @SearchValue";
                        break;
                    case "Variable1ForAge":
                        query += "Pation_Age = @SearchValue";
                        break;
                    case "Variable2ForWardNumber":
                        query += "Ward = @SearchValue";
                        break;
                    case "Variable3ForReason":
                        query += "Reason = @SearchValue";
                        break;
                }

                SqlCommand cmd = new SqlCommand(query, con);

                // Add a parameter to avoid SQL injection
                cmd.Parameters.AddWithValue("@SearchValue", search_txt.Text);

                DataTable dt = new DataTable();
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                dt.Load(sdr);
                con.Close();

                datagrid.ItemsSource = dt.DefaultView;
            }
        }
        public void LoadGrid4()
        {
            ComboBoxItem selectedItem = (ComboBoxItem)groupByComboBox2.SelectedItem;
            string associatedVariable = selectedItem?.Tag as string;

            if (associatedVariable != null)
            {
                string query = "SELECT * FROM Pation_Table WHERE ";

                switch (associatedVariable)
                {
                    case "Variable1ForId":
                        query += "Pation_Id = @SearchValue1";
                        break;
                    case "VariableForName1":
                        query += "Pation_Name = @SearchValue1";
                        break;
                        
                }

                SqlCommand cmd = new SqlCommand(query, con);

                // Add a parameter to avoid SQL injection
                cmd.Parameters.AddWithValue("@SearchValue1", search_txt2.Text);

                DataTable dt = new DataTable();
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                dt.Load(sdr);
                con.Close();

                datagrid.ItemsSource = dt.DefaultView;
            }
        }



        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            LoadGrid1();
        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            LoadGrid2();
        }
        private void Group(object sender, RoutedEventArgs e)
        {
            LoadGrid3();
        }
        private void Clear(object sender, RoutedEventArgs e)
        {
            LoadGrid1();
            search_txt.Clear();
            groupByComboBox.SelectedIndex = -1;

        }
        private void Search(object sender, RoutedEventArgs e)
        {
            LoadGrid4();
         
        }
        private void Clear1(object sender, RoutedEventArgs e)
        {
            LoadGrid1();
            search_txt2.Clear();
            
            groupByComboBox2.SelectedIndex = -1;
        }
        private void back_button(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("Page1.xaml", UriKind.Relative));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void groupByComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
