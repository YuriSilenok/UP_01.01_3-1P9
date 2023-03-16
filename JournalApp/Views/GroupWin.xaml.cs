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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            disciplines.Items.Clear();
            using (var db = new Entities())
            {
                Session.CurrentGroup.Jurnal
                    .Where(j => j.Group1 == Session.CurrentGroup)
                    .ToList().ForEach(j => disciplines.Items.Add(j.Discipline1));
                Session.CurrentGroup.Student.ToList().ForEach(s => students.Items.Add(s));
            }
        }

        private void disciplines_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Session.CurrentDiscipline = disciplines.SelectedItem as Discipline;
            JurnalWindow jurnalWindow = new JurnalWindow();
            Hide();
            jurnalWindow.ShowDialog();
            Show();
        }
    }
}
