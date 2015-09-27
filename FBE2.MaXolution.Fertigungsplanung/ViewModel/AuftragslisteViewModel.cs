using FBE2.MaXolution.Fertigungsplanung.Framework;
using FBE2.MaXolution.Fertigungsplanung.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBE2.MaXolution.Fertigungsplanung.ViewModel
{
    class AuftragslisteViewModel : BaseViewModel
    {
        public AuftragslisteViewModel()
        {
            Datenbank db = new Datenbank();
            DataTable dt = new DataTable();
            dt = db.ExecuteQuery("SELECT Auftrag_Id FROM S_Auftrag ORDER BY Liefertermin");

            foreach (DataRow dr in dt.Rows)
            {
                _Auftragsliste.Add(new Auftrag(long.Parse(dr[0].ToString())));
            }
            
        }

        private ObservableCollection<Auftrag> _Auftragsliste = new ObservableCollection<Auftrag>();

        public ObservableCollection<Auftrag> Auftragsliste
        {
            get { return _Auftragsliste; }
        }
    }
}
