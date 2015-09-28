using FBE2.MaXolution.Fertigungsplanung.Model;
using MahApps.Metro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace FBE2.MaXolution.Fertigungsplanung.ViewModel
{
    class EinstellungenViewModel
    {
        public EinstellungenViewModel()
        {
            this.AccentColors = ThemeManager.Accents
                                            .Select(a => new AccentColorMenuData() { Name = a.Name, ColorBrush = a.Resources["AccentColorBrush"] as Brush })
                                            .ToList();

            // create metro theme color menu items for the demo
            this.AppThemes = ThemeManager.AppThemes
                                           .Select(a => new AppThemeMenuData() { Name = a.Name, BorderColorBrush = a.Resources["BlackColorBrush"] as Brush, ColorBrush = a.Resources["WhiteColorBrush"] as Brush })
                                           .ToList();

            if (ActiveColor == null){

            }
        }

        public List<AccentColorMenuData> AccentColors { get; set; }
        public List<AppThemeMenuData> AppThemes { get; set; }

        public AccentColorMenuData ActiveColor
        {
            get { return AccentColors.First(p => p.Name == ThemeManager.DetectAppStyle(Application.Current).Item2.Name); }
            set
            {
                var theme = ThemeManager.DetectAppStyle(Application.Current);
                var accent = ThemeManager.GetAccent(value.Name);
                ThemeManager.ChangeAppStyle(Application.Current, accent, theme.Item1);
                Einstellungen Einstellung = new Einstellungen();
                Einstellung.getEinstellungen();
                Einstellung.AccentColor = value.Name;
                Einstellung.saveEinstellungen();
            }
        }

        public AppThemeMenuData ActiveTheme
        {
            get { return AppThemes.First(p => p.Name == ThemeManager.DetectAppStyle(Application.Current).Item1.Name); }
            set
            {
                var theme = ThemeManager.DetectAppStyle(Application.Current);
                var appTheme = ThemeManager.GetAppTheme(value.Name);
                ThemeManager.ChangeAppStyle(Application.Current, theme.Item2, appTheme);
                Einstellungen Einstellung = new Einstellungen();
                Einstellung.getEinstellungen();
                Einstellung.Theme = value.Name;
                Einstellung.saveEinstellungen();
            }
        }
    }

    public class AccentColorMenuData
    {
        public string Name { get; set; }
        public Brush BorderColorBrush { get; set; }
        public Brush ColorBrush { get; set; }
    }

    public class AppThemeMenuData : AccentColorMenuData
    {
    }
}
