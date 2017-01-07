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
using System.Net.Mail;

namespace yad2
{
    /// <summary>
    /// Interaction logic for newUser.xaml
    /// </summary>
    public partial class newUser : Window
    {
       
        public newUser()
        {
            InitializeComponent();
           
        }



       

        private void Female_Checked(object sender, RoutedEventArgs e)
        {
            Male.IsChecked = false;

        }
        private void Male_Checked(object sender, RoutedEventArgs e)
        {
            Female.IsChecked = false;
        }

        private string realpass = "";
        private void textBox10_TextChanged(object sender, TextChangedEventArgs e)
        {
          //  realpass = textBox10.Text;
          //  for (int i = 0; i < realpass.Length; i++)
          //      textBox10.Text += "*";
        }


        private void Register(object sender, RoutedEventArgs e)
        {

            if (firstName.Text == "" || lastName.Text == "")
                MessageBox.Show("Please enter your name");
            else if(Age.Text=="")
                MessageBox.Show("Please enter your age");
            else if(Convert.ToInt32(Age.Text)<0 || Convert.ToInt32(Age.Text)>121 )
                MessageBox.Show("invalied age (must be between 0 and 120)");
            else if(Male.IsChecked==false&& Female.IsChecked==false)
                MessageBox.Show("Please select a gender");
            else if(email.Text=="")
                MessageBox.Show("Please enter your email");
            else if (pass.Password == "" || pass2.Password == "")
                MessageBox.Show("Please enter your password and password validation");
            else if (pass.Password != pass2.Password)
                MessageBox.Show("the validation does not match the password");

            sendMail(email.Text);






                
        }

        
        private void sendMail(string userMail)
        {
            MailMessage mail = new MailMessage("partnermatcheryad2@gmail.com", userMail);
            SmtpClient client = new SmtpClient();
            client.Port = 25;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Host = "smtp.gmail.com";
            client.Credentials = new System.Net.NetworkCredential("partnermatcheryad2@gmail.com", "olla123456");
            client.EnableSsl = true;

            mail.Subject = "Registration for PartnerMatcher";
            mail.Body = "Welcome to PartnerMatcher, We're glad to have you aboard";
            client.Send(mail);

        }

        private void Cencel(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void age_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1))
                e.Handled = true;
        }

    }
}
