using FBE2.MaXolution.Fertigungsplanung.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FBE2.MaXolution.Fertigungsplanung.View
{
    /// <summary>
    /// Interaktionslogik für AuftragslisteView.xaml
    /// </summary>
    public partial class AuftragslisteView : UserControl
    {
        public AuftragslisteView()
        {
            InitializeComponent();
        }

        private void Auftragsliste_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            AuftragslisteViewModel vm = (AuftragslisteViewModel)DataContext;
            vm.LoadData_Start();
        }
    }
}
