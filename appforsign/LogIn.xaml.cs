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

namespace appforsign
{
    /// <summary>
    /// Логика взаимодействия для LogIn.xaml
    /// </summary>
    public partial class LogIn : Window
    {
        public LogIn()
        {
            InitializeComponent();
        }

        private void LogIn_Click(object sender, RoutedEventArgs e)
        {
            string login = username.Text.Trim();
            string password1 = pass1.Password.Trim();

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
            else 
            {
                username.ToolTip = "";
                username.Background = Brushes.Transparent;
                pass1.ToolTip = "";
                pass1.Background = Brushes.Transparent;

                User authUser = null;
                using (Context db = new Context()) {
                    authUser = db.Users.Where(b => b.Login == login && b.Password == password1).FirstOrDefault();}
                if (authUser != null)
                {
                    MessageBox.Show("Successful authorization");
                    UserPageWindow userpagewindow=new UserPageWindow(); 
                   userpagewindow.Show();
                    Hide();
                }
                else
                {
                    MessageBox.Show("Error");
                }
                
            }
        }

        private void signup_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Hide();
        }
    }
}
