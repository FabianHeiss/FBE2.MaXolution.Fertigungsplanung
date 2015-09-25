using FBE2.MaXolution.Fertigungsplanung.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.Commands;
using FBE2.MaXolution.Fertigungsplanung.View;
using MahApps.Metro.Controls;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace FBE2.MaXolution.Fertigungsplanung.ViewModel
{
    class HauptfensterViewModel : BaseViewModel
    {
        public HauptfensterViewModel()
        {
            this.AddViews();
            this.ActiveView = new AuftragslisteView();
        }

        #region ViewControl
        private DelegateCommand<string> OpenView{ get; set; }
        private ObservableCollection<UserControl> Views = new ObservableCollection<UserControl>();
        
        private void OpenView_Execute(string ViewName)
        {
            if (Views.Any(p => p.Name == ViewName))
            {
                UserControl View = Views.First(p => p.Name == ViewName);
                ActiveView = View;
            }
        }

        private bool OpenView_CanExecute(string ViewName)
        {
            if (Views.Any(p => p.Name == ViewName))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private UserControl _ActiveView;
        public UserControl ActiveView
        {
            get { return _ActiveView; }
            set
            {
                if (_ActiveView == value)
                    return;

                _ActiveView = value;
                OnPropertyChanged("ActiveView");

            }
        }

        private void AddViews()
        {
            // Views hinzufügen
            // Views.Add(new ViewName());
            Views.Add(new AuftragslisteView());
        }
        #endregion
    }
}
