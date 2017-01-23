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
        Yad2Entities _db;
        public MainWindow()
        {
            InitializeComponent();
            _db = new Yad2Entities();
            List<string> cat = new List<string>();
            var items = (from u in _db.Categories select new { u.Type });
            foreach (var u in items)
                cat.Add(u.Type);
            List<string> loc = new List<string>();
            var items1 = (from u in _db.Locations select new { u.Area });
            foreach (var u in items1)
                loc.Add(u.Area);
            Categories.ItemsSource = cat;
            Locations.ItemsSource = loc;
        }

        private void existingUser(object sender, RoutedEventArgs e)
        {
            existingUser ExistingUser = new existingUser(this);
            ExistingUser.Show();
        }

        private void newUser(object sender, RoutedEventArgs e)
        {
            newUser NewUser = new newUser(this);
            NewUser.Show();
        }

        private void Search(object sender, RoutedEventArgs e)
        {
            if (HelloUser.Text == "Hello Guest") //אם לא מחובר יעני
                MessageBox.Show("Please Login or Register first");
            else
            { 
                if(Locations.SelectedItem!=null && Categories.SelectedItem!=null)
                {

                    string loc = Locations.SelectedItem.ToString();
                    string cat = Categories.SelectedItem.ToString();

                    var adds = (from u in _db.Adds
                                where u.LocationArea == loc && u.CategoryType == cat
                                 select new
                                 {
                                     u.About,
                                     u.DatePublished,
                                     u.EventDate,
                                 });
                    if (adds.Count() > 0)
                    {
                        Window win = new Window();
                        win.Background = Brushes.SandyBrown;
                        //win.Height = 250.00;
                        win.Width = 350.00;
                        ListBox libx = new ListBox();
                        libx.Background = Brushes.Lavender;
                        libx.Foreground = Brushes.DimGray;
                        foreach (var item in adds)
                        {
                            libx.Items.Add(string.Format("Category:{0} \nLocation:{1} \nDate Published:{2} \nEvent Date:{3} \nAbout:{4}", cat, loc, item.DatePublished, item.EventDate, item.About));
                        }
                        Grid gr = new Grid();
                        gr.Children.Add(libx);
                        win.Content = gr;
                        win.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Sorry!!! but there is no adds matching your search :(");
                    }
                }
                else
                {
                    MessageBox.Show("Please select Location And Category first");
                }
            }
        }
    }
}
