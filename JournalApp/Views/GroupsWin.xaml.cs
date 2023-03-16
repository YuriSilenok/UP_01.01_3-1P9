using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using JournalApp.Models;
using JournalApp.ViewModels;


namespace JournalApp.Views
{
    /// <summary>
    /// Логика взаимодействия для Log.xaml
    /// </summary>
    public partial class GroupsWin : Window
    {
        public GroupsWin()
        {
            InitializeComponent();
        }

        private void groups_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Session.CurrentGroup = groups.SelectedItem as Group;
            GroupWin groupWindow = new GroupWin();
            Close();
            groupWindow.ShowDialog();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = new GroupsViewModel();
        }
    }
}
 