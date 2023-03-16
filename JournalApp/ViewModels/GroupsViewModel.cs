using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using JournalApp.Models;


namespace JournalApp.ViewModels
{
    public class GroupsViewModel : DependencyObject
    {


        public string FilterText
        {
            get { return (string)GetValue(FilterTextProperty); }
            set { SetValue(FilterTextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for FilterText.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FilterTextProperty =
            DependencyProperty.Register("FilterText", typeof(string), typeof(GroupsViewModel), new PropertyMetadata("", TextFilterChanged));

        private static void TextFilterChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            GroupsViewModel groupsViewModel = d as GroupsViewModel;
            if (groupsViewModel != null)
            {
                groupsViewModel.Items.Filter = null;
                groupsViewModel.Items.Filter = groupsViewModel.FilterGroup;
            }
        }

        public ICollectionView Items
        {
            get { return (ICollectionView)GetValue(ItemsProperty); }
            set { SetValue(ItemsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Items.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ItemsProperty =
            DependencyProperty.Register("Items", typeof(ICollectionView), typeof(GroupsViewModel), new PropertyMetadata(null));

        public GroupsViewModel()
        {
            List<Group> groups = new List<Group>();
            Session.CurrentUser.Jurnal.ToList().ForEach(j => groups.Add(j.Group1));
            Items = CollectionViewSource.GetDefaultView(groups);
            Items.Filter = FilterGroup;
        }

        private bool FilterGroup(object obj)
        {
            Group group = obj as Group;
            return group == null || string.IsNullOrWhiteSpace(FilterText) || group.Code.Contains(FilterText);
        }
    }
}
