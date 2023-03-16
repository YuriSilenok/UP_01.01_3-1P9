using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JournalApp.Models;


namespace JournalApp
{
    public class Session
    {

        public static Entities Entities { get; }

        public static User CurrentUser { get; set; }
        public static Group CurrentGroup { get; set; }
        public static Discipline CurrentDiscipline { get; set; }
        public static Jurnal CurrentJurnal { get; set; }

        static Session()
        {
            Entities = new Entities();
        }
    }
}
