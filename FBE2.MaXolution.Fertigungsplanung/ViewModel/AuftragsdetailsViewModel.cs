using FBE2.MaXolution.Fertigungsplanung.Framework;
using FBE2.MaXolution.Fertigungsplanung.Model;
using Microsoft.Practices.Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FBE2.MaXolution.Fertigungsplanung.ViewModel
{
    class AuftragsdetailsViewModel : BaseViewModel
    {
        public AuftragsdetailsViewModel()
        {
        }

        private Auftrag _Auftrag = null;
        public Auftrag Auftrag
        {
            get
            {
                return _Auftrag;
            }
            set
            {
                _Auftrag = value;
                OnPropertyChanged("Auftrag");
            }
        }

        public void LoadData_Start(Auftrag Auftrag){
            this.Auftrag = Auftrag;
        }

       
    }
}
