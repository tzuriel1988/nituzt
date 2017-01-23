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
using System.Windows.Shapes;

namespace yad2
{
    /// <summary>
    /// Interaction logic for existingUser.xaml
    /// </summary>
    public partial class existingUser : Window
    {
        MainWindow window;
        Yad2Entities _db;
        public existingUser(MainWindow win)
        {
            InitializeComponent();
            window = win;
            _db = new Yad2Entities();
        }

        private void LogIn(object sender, RoutedEventArgs e)
        {
            var users = (from u in _db.Users
                         where u.Email == mail.Text
                         select new
                         {
                             u.Password,
                             u.FirstName,
                             u.LastName
                         });
            if (users.Count() == 0)
                MessageBox.Show("E-Mail does not exist in the system");
            else
            {
                foreach (var u in users)
                {
                    if (u.Password.Trim() == password.Password)
                    {
                        MessageBox.Show("Welcome " + u.FirstName.Trim() + " " + u.LastName.Trim());
                        window.HelloUser.Text = "Hello " + u.FirstName.Trim() + " " + u.LastName.Trim();
                        Close();
                    }
                    else
                        MessageBox.Show("Wrong password");
                }
            }
            
        }
    }
}
