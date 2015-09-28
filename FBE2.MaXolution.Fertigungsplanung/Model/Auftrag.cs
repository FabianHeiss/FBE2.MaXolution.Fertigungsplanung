using FBE2.MaXolution.Fertigungsplanung.Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Media;

namespace FBE2.MaXolution.Fertigungsplanung.Model
{
    class Auftrag
    {
        #region Konstruktor
        // Konstruktor für einen neuen Auftrag
        public Auftrag()
        {
        }

        // Konstruktor für einen schon bestehenden Auftrag
        public Auftrag(long Id)
        {
            getAuftrag(Id);
        }

        public Auftrag(long Id, bool Auftragsliste)
        {
            getAuftrag(Id, Auftragsliste);
        }
        #endregion

        #region Funktionen
        // Auftrag aus Datenbank holen und Klassenparameter mit Daten füllen
        private void getAuftrag(long Id, bool Auftragsliste = false)
        {
            Console.WriteLine("Auftrag anlegen start:" + DateTime.Now.ToString("hh.mm.ss.ffffff"));
            // ToDo: Parameter mit Werten füllen
            Datenbank db = new Datenbank();
            DataTable dt = new DataTable();
            if (Auftragsliste == true)
            {
                dt = db.ExecuteQuery("SELECT Auftrag_Id, Auftragsnummer, Gerät_Id, Anzahl, Auftraggeber, Projekt_Id, Wunschtermin, Liefertermin, Fertigungsstatus_Id, Fertigungsauftrag, Vertriebsart_Id FROM S_Auftrag WHERE Auftrag_Id = " + Id.ToString());
            }
            else {
                dt = db.ExecuteQuery("SELECT * FROM S_Auftrag WHERE Auftrag_Id = " + Id.ToString());
            }
            Console.WriteLine("Auftrag zuweisen start:" + DateTime.Now.ToString("hh.mm.ss.ffffff"));
            foreach (DataRow dr in dt.Rows)
            {
                foreach (DataColumn dc in dt.Columns){
                    var cellContent = dr[dc];
                    switch (dc.ColumnName)
                    {
                        case "Auftragsnummer":
                            Auftragsnummer = cellContent.ToString();
                            break;
                        case "Auftraggeber":
                            Auftraggeber = cellContent.ToString();
                            break;
                        case "Projekt_Id":
                            Projekt_Id = (cellContent.ToString() != string.Empty) ? long.Parse(cellContent.ToString()) : 0;
                            break;
                        case "Gerät_Id":
                            Gerät_Id = (cellContent.ToString() != string.Empty) ? long.Parse(cellContent.ToString()) : 0;
                            break;
                        case "Anzahl":
                            Anzahl = (cellContent.ToString() != string.Empty) ? int.Parse(cellContent.ToString()) : 0;
                            break;
                        case "Wunschtermin":
                            Wunschtermin = (cellContent.ToString() != string.Empty) ? long.Parse(cellContent.ToString()) : 0;
                            break;
                        case "Liefertermin":
                            Liefertermin = (cellContent.ToString() != string.Empty) ? long.Parse(cellContent.ToString()) : 0;
                            setLieferterminBackground();
                            break;
                        case "Komponentenliefertermin":
                            if (cellContent.ToString() != string.Empty)
                            {
                                Komponentenliefertermin = DateTime.Parse(cellContent.ToString());
                            }
                            break;
                        case "Fertigungsstatus_Id":
                            Fertigungsstatus_Id = (cellContent.ToString() != string.Empty) ? long.Parse(cellContent.ToString()) : 0;
                            break;
                        case "Fertigungsauftrag":
                            Fertigungsauftrag = cellContent.ToString();
                            break;
                        case "Maßnahme":
                            Maßnahme = cellContent.ToString();
                            break;
                        case "Ersteller_Id":
                            Ersteller_Id = (cellContent.ToString() != string.Empty) ? long.Parse(cellContent.ToString()) : 0;
                            break;
                        case "Erstelldatum":
                            if (cellContent.ToString() != string.Empty)
                            {
                                Erstelldatum = DateTime.Parse(cellContent.ToString());
                            }
                            break;
                        case "Versanddatum":
                            if (cellContent.ToString() != string.Empty)
                            {
                                Versanddatum = DateTime.Parse(cellContent.ToString());
                            }
                            break;
                        case "Vertriebsart_Id":
                            Vertriebsart_Id = (cellContent.ToString() != string.Empty) ? long.Parse(cellContent.ToString()) : 0;
                            break;
                        default:
                            break;
                    }
                }
            }
            Console.WriteLine("Auftrag zuweisen ende:" + DateTime.Now.ToString("hh.mm.ss.ffffff"));
            Console.WriteLine("Auftrag anlegen ende:" + DateTime.Now.ToString("hh.mm.ss.ffffff"));
        }

        private void setLieferterminBackground()
        {
            CultureInfo ciCurr = CultureInfo.CurrentCulture;
            int weekNum = ciCurr.Calendar.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
            int year = DateTime.Now.Year;

            Point p1 = new Point(-0.5, 0);
            Point p2 = new Point(1, 1);
            if (Liefertermin.ToString().Length == 6)
            {
                if (Liefertermin < int.Parse(year.ToString() + weekNum.ToString()))
                {
                    LieferterminBackground = new LinearGradientBrush(Colors.Transparent, Colors.Firebrick, p1, p2);
                }
                else if (Liefertermin == int.Parse(year.ToString() + weekNum.ToString()))
                {
                    LieferterminBackground = new LinearGradientBrush(Colors.Transparent, Colors.SkyBlue, p1, p2);
                }
                else
                {
                    LieferterminBackground = null;
                }
            }
        }

        // Auftrag in Datenbank speichern / updaten
        private void saveAuftrag_Execute()
        {
            if (saveAuftrag_CanExecute() == true) {
                // ToDo: Auftrag in Datenbank speichern / updaten
            }
        }

        // Überprüfen ob der Auftrag gespeichert werden kann (ob alle erforderlichen Felder vorhanden sind)
        private bool saveAuftrag_CanExecute()
        {
            // ToDo: Parameter überprüfen
            return false;
        }
        #endregion

        #region Properties
        // Allgemeine Felder
        public long Auftrag_Id { get; set; }
        public string Auftragsnummer { get; set; }
        public string Auftraggeber { get; set; }
        public long Projekt_Id
        {
            get
            {
                return Projekt.Projekt_Id;
            }
            set
            {
                Projekt = new Projekt(value);
            }
        }
        public Projekt Projekt { get; set; }
        public long Gerät_Id {
            get
            {
                return Gerät.Gerät_Id;
            }
            set
            {
                Gerät = new Geraet(value);
            }
        }
        public Geraet Gerät { get; set; }
        public int Anzahl { get; set; }
        public long Wunschtermin { get; set; }
        public string WunschterminFormat
        {
            get
            {
                return (Wunschtermin != 0 & Wunschtermin.ToString().Length == 6) ? Wunschtermin.ToString().Substring(0, 4) + " / KW" + Wunschtermin.ToString().Substring(4, 2) : "---";
            }
        }
        public long Liefertermin { get; set; }
        public string LieferterminFormat
        {
            get
            {
                return (Liefertermin != 0 & Liefertermin.ToString().Length == 6) ? Liefertermin.ToString().Substring(0, 4) + " / KW" + Liefertermin.ToString().Substring(4, 2) : "---";
            }
        }
        public Brush LieferterminBackground { get; set; }
        public DateTime Komponentenliefertermin { get; set; }
        public long Fertigungsstatus_Id
        {
            get
            {
                return Fertigungsstatus.Fertigungsstatus_Id;
            }
            set
            {
                Fertigungsstatus = new Fertigungsstatus(value);
            }
        }
        public Fertigungsstatus Fertigungsstatus { get; set; }
        public string Fertigungsauftrag { get; set; }
        public string Maßnahme { get; set; }
        public long Ersteller_Id
        {
            get
            {
                return Ersteller.Ersteller_Id;
            }
            set
            {
                Ersteller = new Ersteller(value);
            }
        }
        public Ersteller Ersteller { get; set; }
        public DateTime Erstelldatum { get; set; }
        public DateTime Versanddatum { get; set; }
        public long Vertriebsart_Id
        {
            get
            {
                return Vertriebsart.Vertriebsart_Id;
            }
            set
            {
                Vertriebsart = new Vertriebsart(value);
            }
        }
        public Vertriebsart Vertriebsart { get; set; }

        public bool chkFAUF { get; set; }
        public bool chkMaterialverfügbarkeit { get; set; }
        public bool chkKomponentenbereitstellung { get; set; }
        public bool chkMaterialbereitstellung_FAUF { get; set; }
        public bool chkMontageinsel_rüsten { get; set; }
        public bool chkUnterlagen_vorbereitet { get; set; }
        public bool chkMontagebeginn { get; set; }
        public bool chkMontageende { get; set; }
        public bool chkPrüfungsbeginn { get; set; }
        public bool chkPrüfungsende { get; set; }
        public bool chkKomplettierung { get; set; }
        public bool chkVersand { get; set; }

        // Begleitkarten-Felder
        public bool chkMaterialbereitstellungEntwicklung_QSET { get; set; }
        public bool chkUnterlagenVorhanden { get; set; }
        public bool chkGeraetUebergeben_QSET { get; set; }
        public bool chkErgebnisprotokollVerfasst { get; set; }
        public bool chkAenderungenEingetragen_BGKTool { get; set; }
        public bool chkMontageanleitungGeschrieben { get; set; }
        public bool chkAenderungenEingepflegt { get; set; }
        public DateTime datAenderungenEingepflegt { get; set; }

        #endregion
    }
}
