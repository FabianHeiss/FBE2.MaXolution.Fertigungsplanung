using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;

namespace FBE2.MaXolution.Fertigungsplanung.Model
{
    public class Einstellungen
    {
        public Einstellungen()
        {
        }

        public string Theme { get; set; }
        public string AccentColor { get; set; }

        private string xmlFile = "Einstellungen.xml";

        public void getEinstellungen()
        {
            // ToDo: Einstellungen aus XML-Datei holen
            XMLWriter xml = new XMLWriter();
            Einstellungen Einstellung = xml.Read(GetApplicationsPath() + "/" + xmlFile, this);
            AccentColor = Einstellung.AccentColor;
            Theme = Einstellung.Theme;
        }

        public void saveEinstellungen()
        {
            XMLWriter xml = new XMLWriter();
            xml.Write(GetApplicationsPath() + "/" + xmlFile, this);
        }

        public static string GetApplicationsPath()
        {
            FileInfo fi = new FileInfo(Assembly.GetEntryAssembly().Location);
            return fi.DirectoryName;
        }
    }
}
