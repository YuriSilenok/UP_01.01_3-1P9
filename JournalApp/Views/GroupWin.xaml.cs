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
using JournalApp.Models;
using JournalApp.ViewModels;

namespace JournalApp.Views
{
    /// <summary>
    /// Логика взаимодействия для GroupWindow.xaml
    /// </summary>
    public partial class GroupWin : Window
    {
        public GroupWin()
        {
            InitializeComponent();
        }

        private void disciplines_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Session.CurrentDiscipline = disciplines.SelectedItem as Discipline;
            JurnalWindow jurnalWindow = new JurnalWindow();
            Hide();
            jurnalWindow.ShowDialog();
            Show();
        }

        private void students_Loaded(object sender, RoutedEventArgs e)
        {
            (sender as ListBox).DataContext = new StudentsViewModel();
        }

        private void disciplines_Loaded(object sender, RoutedEventArgs e)
        {
            (sender as ListBox).DataContext = new DisciplineViewModel();
        }
    }
}
