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
using System.Windows.Media.Animation;

namespace appforsign
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Context db;
        public MainWindow()
        {
            InitializeComponent();
            db=new Context();
            DoubleAnimation anime = new DoubleAnimation();
            anime.From = 0;
            anime.To = 450;
            anime.Duration=TimeSpan.FromSeconds(4);
            signup.BeginAnimation(Button.WidthProperty,anime);
           
        }

        private void SignUp_Click(object sender, RoutedEventArgs e)
        {
            string login = username.Text.Trim();
            string password1 = pass1.Password.Trim();
            string password2 = pass2.Password.Trim();
            string adress = email.Text.Trim().ToLower();

            if (login.Length < 5)
            {
                username.ToolTip = "the incorrect field is entered";
                username.Background = Brushes.Red; username.Foreground = Brushes.White;
            }
            else if (password1.Length < 5)

            {
                pass1.ToolTip = "the incorrect field is entered";
                pass1.Background = Brushes.Red; pass1.Foreground = Brushes.White;
            }
            else if (password1 != password2)

            {
                pass2.ToolTip = "the incorrect field is entered";
                pass2.Background = Brushes.Red; pass2.Foreground = Brushes.White;
            }
            else if (adress.Length < 5 || !adress.Contains("@") || !adress.Contains("."))

            {
                email.ToolTip = "the incorrect field is entered";
                email.Background = Brushes.Red; email.Foreground = Brushes.White;
            }
            else
            {
                username.ToolTip = "";
                username.Background = Brushes.Transparent;
                pass1.ToolTip = "";
                pass1.Background = Brushes.Transparent;
                pass2.ToolTip = "";
                pass2.Background = Brushes.Transparent;
                email.ToolTip = "";
                email.Background = Brushes.Transparent;
                MessageBox.Show("Sign up is complete");

                User user = new User(login,password1,adress);
                db.Users.Add(user);
                db.SaveChanges();
                LogIn logIn = new LogIn();
                logIn.Show();
                Hide();
            }

        }

        private void logIn_Click(object sender, RoutedEventArgs e)
        {
            LogIn logIn = new LogIn();
            logIn.Show();
            Hide();
        }
    }
}
