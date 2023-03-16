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
    public class StudentsViewModel : DependencyObject
    {

        public ICollectionView Items
        {
            get { return (ICollectionView)GetValue(ItemsProperty); }
            set { SetValue(ItemsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Students.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ItemsProperty =
            DependencyProperty.Register("Items", typeof(ICollectionView), typeof(StudentsViewModel), new PropertyMetadata(null));

        public StudentsViewModel()
        {
            List<Student> students = new List<Student>();
            Session.CurrentGroup.Student.ToList().ForEach(s => students.Add(s));
            Items = CollectionViewSource.GetDefaultView(students);
        }
    }
}
