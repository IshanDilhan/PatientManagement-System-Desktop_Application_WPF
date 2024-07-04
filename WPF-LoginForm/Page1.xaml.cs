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

namespace WPF_LoginForm
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        public Page1()
        {
            InitializeComponent();
        }

        private void toregiformbtn(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new Page2();
        }

        private void deletebtn(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new Page5();
        }

        private void toviewbtn(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new Page3();
        }
        private void toupdatebtn(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new Page4();
        }

        private void MainFrame_Navigated(object sender, NavigationEventArgs e)
        {

        }
        private void back_button(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("Page7.xaml", UriKind.Relative));
        }
    }
}
