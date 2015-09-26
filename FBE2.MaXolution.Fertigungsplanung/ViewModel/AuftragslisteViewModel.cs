using FBE2.MaXolution.Fertigungsplanung.Framework;
using FBE2.MaXolution.Fertigungsplanung.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBE2.MaXolution.Fertigungsplanung.ViewModel
{
    class AuftragslisteViewModel : BaseViewModel
    {
        public AuftragslisteViewModel()
        {
            _Auftragsliste.Add(new Auftrag(2));
        }

        private ObservableCollection<Auftrag> _Auftragsliste = new ObservableCollection<Auftrag>();

        public ObservableCollection<Auftrag> Auftragsliste
        {
            get { return _Auftragsliste; }
        }
    }
}
