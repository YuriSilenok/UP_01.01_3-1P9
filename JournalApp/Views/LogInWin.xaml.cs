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
using JournalApp.Models;
using JournalApp.ViewModels;

namespace JournalApp.Views
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xam
    /// </summary>
    public partial class LogInWin : Window
    {
        public LogInWin()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            User user = (DataContext as MainViewModel).Autorization(login_TextBox.Text, password_PasswordBox.Password);
            if (user != null)
            {
                Hide();
                GroupsWin log = new GroupsWin();
                log.ShowDialog();
                Show();
            }
            else
                MessageBox.Show("Неверный логин или пароль");
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = new MainViewModel();
        }
    }
}
