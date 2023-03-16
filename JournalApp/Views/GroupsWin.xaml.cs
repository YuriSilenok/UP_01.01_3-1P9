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

            using(var db = new Entities())
            {
                Session.CurrentUser.Jurnal.ToList().ForEach(j => groups.Items.Add(j.Group1));
            }
        }

        private void filterTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // очищаем листбокс
            groups.Items.Clear();
            // заполняем листбокс группами, которые подходят по условию
            using (var db = new Entities())
            {
                Session.CurrentUser.Jurnal.ToList().ForEach(j => 
                {
                    if (j.Group1.Code.Contains(filterTextBox.Text))
                        groups.Items.Add(j.Group1);
                });
            }
        }

        private void groups_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Session.CurrentGroup = groups.SelectedItem as Group;
            GroupWin groupWindow = new GroupWin();
            Hide();
            groupWindow.ShowDialog();
            Show();
        }
    }
}
 