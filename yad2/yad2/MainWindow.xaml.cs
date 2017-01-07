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

namespace yad2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void existingUser(object sender, RoutedEventArgs e)
        {
            existingUser ExistingUser = new existingUser();
            ExistingUser.Show();
        }

        private void newUser(object sender, RoutedEventArgs e)
        {
            newUser NewUser = new newUser();
            NewUser.Show();
        }

        private void continueWatching(object sender, RoutedEventArgs e)
        {

        }
    }
}
