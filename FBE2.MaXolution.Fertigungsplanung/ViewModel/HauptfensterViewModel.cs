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
using Microsoft.Practices.ServiceLocation;
using GalaSoft.MvvmLight.Ioc;

namespace FBE2.MaXolution.Fertigungsplanung.ViewModel
{
    class HauptfensterViewModel : BaseViewModel
    {
        private FrameNavigationService navi;

        public HauptfensterViewModel()
        {
            Einstellungen Einstellung = new Einstellungen();
            Einstellung.getEinstellungen();

            var appTheme = ThemeManager.GetAppTheme(Einstellung.Theme);
            var accent = ThemeManager.GetAccent(Einstellung.AccentColor);
            ThemeManager.ChangeAppStyle(Application.Current, accent, appTheme);


            FlyoutIsOpen = true;
            AddViews();
            AddNavigationUris();
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
        public DelegateCommand<string> OpenView{ get; set; }
        public ObservableCollection<UserControl> Views = new ObservableCollection<UserControl>();
        
        private void OpenView_Execute(string ViewName)
        {
            if (Views.Any(p => p.Name == ViewName))
            {
                UserControl View = Views.First(p => p.Name == ViewName);
                ActiveView = View;
                FlyoutIsOpen = false;
            }
            navi.NavigateTo(ViewName);
        }

        private bool OpenView_CanExecute(string ViewName)
        {
            //if (Views.Any(p => p.Name == ViewName))
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
            return true;
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

        private void AddNavigationUris()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            navi = new FrameNavigationService();

            navi.Configure("Auftragsliste", new Uri("../View/AuftragslisteView.xaml", UriKind.Relative));
            navi.Configure("Auftragsdetails", new Uri("../View/AuftragsdetailsView.xaml", UriKind.Relative));
            navi.Configure("Einstellungen", new Uri("../View/EinstellungenView.xaml", UriKind.Relative));

            //SimpleIoc.Default.Register<AuftragsdetailsViewModel>();
            //SimpleIoc.Default.Register<AuftragslisteView>();
            //SimpleIoc.Default.Register<EinstellungenViewModel>(); 

        }
        #endregion
    }
}
