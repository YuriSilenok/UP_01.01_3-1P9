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
    public class DisciplineViewModel : DependencyObject
    {

        public ICollectionView Items
        {
            get { return (ICollectionView)GetValue(ItemsProperty); }
            set { SetValue(ItemsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Items.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ItemsProperty =
            DependencyProperty.Register("Items", typeof(ICollectionView), typeof(DisciplineViewModel), new PropertyMetadata(null));

        public DisciplineViewModel()
        {
            List<Discipline> disciplines = new List<Discipline>();
            Session.CurrentGroup.Jurnal
                    .Where(j => j.Group1 == Session.CurrentGroup)
                    .ToList().ForEach(j => disciplines.Add(j.Discipline1));
            Items = CollectionViewSource.GetDefaultView(disciplines);
        }


    }
}
