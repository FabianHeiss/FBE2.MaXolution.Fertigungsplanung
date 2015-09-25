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
using System.Windows.Input;
using MahApps.Metro;
using System.Windows;
using FBE2.MaXolution.Fertigungsplanung.Model;

namespace FBE2.MaXolution.Fertigungsplanung.ViewModel
{
    class HauptfensterViewModel : BaseViewModel
    {
        public HauptfensterViewModel()
        {
            Einstellungen Einstellung = new Einstellungen();
            Einstellung.getEinstellungen();

            var appTheme = ThemeManager.GetAppTheme(Einstellung.Theme);
            var accent = ThemeManager.GetAccent(Einstellung.AccentColor);
            ThemeManager.ChangeAppStyle(Application.Current, accent, appTheme);


            FlyoutIsOpen = true;
            AddViews();
            //this.ActiveView = new AuftragslisteView();

            OpenView = new DelegateCommand<string>(OpenView_Execute, OpenView_CanExecute);
            ToggleFlyout = new DelegateCommand(ToggleFlyout_Execute);
        }

        #region FlyOut (Menu)
        private bool _FlyoutIsOpen;
        public bool FlyoutIsOpen
        {
            get
            {
                return _FlyoutIsOpen;
            }
            set
            {
                _FlyoutIsOpen = value;
                OnPropertyChanged("FlyoutIsOpen");
            }
        }

        public ICommand ToggleFlyout { get; set; }
        private void ToggleFlyout_Execute(){
            FlyoutIsOpen = !FlyoutIsOpen;
        }
        #endregion

        #region ViewControl
        public ICommand OpenView{ get; set; }
        private ObservableCollection<UserControl> Views = new ObservableCollection<UserControl>();
        
        private void OpenView_Execute(string ViewName)
        {
            if (Views.Any(p => p.Name == ViewName))
            {
                UserControl View = Views.First(p => p.Name == ViewName);
                ActiveView = View;
                FlyoutIsOpen = false;
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
            // Name-Tag im UserControl muss gesetzt sein!!!
            Views.Add(new AuftragslisteView());
            Views.Add(new EinstellungenView());
        }
        #endregion
    }
}
