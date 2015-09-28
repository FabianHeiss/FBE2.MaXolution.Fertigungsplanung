using FBE2.MaXolution.Fertigungsplanung.Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBE2.MaXolution.Fertigungsplanung.Model
{
    class Geraet
    {
        #region Konstruktor
        // Konstruktor für einen neuen Auftrag
        public Geraet()
        {
        }

        // Konstruktor für einen schon bestehenden Auftrag
        public Geraet(long Id)
        {
            getGerät(Id);
        }
        #endregion

        #region Funktionen
        // Auftrag aus Datenbank holen und Klassenparameter mit Daten füllen
        public void getGerät(long Id)
        {
            this.Gerät_Id = Id;
            // ToDo: Parameter mit Werten füllen
            Datenbank db = new Datenbank();
            DataTable dt = new DataTable();
            dt = db.ExecuteQuery("SELECT * FROM H_Gerät WHERE Gerät_Id = " + Id.ToString());

            foreach (DataRow dr in dt.Rows)
            {
                foreach (DataColumn dc in dt.Columns){
                    var cellContent = dr[dc];
                    switch (dc.ColumnName)
                    {
                        case "Sachnummer":
                            Sachnummer = cellContent.ToString();
                            break;
                        case "Bezeichnung":
                            Bezeichnung = cellContent.ToString();
                            break;
                        case "Version":
                            Version = cellContent.ToString();
                            break;
                        case "Fertigungszeit":
                            Fertigungszeit = (cellContent.ToString() != string.Empty) ? float.Parse(cellContent.ToString()) : 0;
                            break;
                        case "Fertigungszeit_Gesamt":
                            Fertigungszeit_Gesamt = (cellContent.ToString() != string.Empty) ? float.Parse(cellContent.ToString()) : 0;
                            break;
                        case "AAWMontage":
                            AAWMontage = (cellContent.ToString() != string.Empty) ? long.Parse(cellContent.ToString()) : 0;
                            break;
                        case "AAWPrüfung":
                            AAWPrüfung = (cellContent.ToString() != string.Empty) ? long.Parse(cellContent.ToString()) : 0;
                            break;
                        case "AAWKomplettierung":
                            AAWKomplettierung = (cellContent.ToString() != string.Empty) ? long.Parse(cellContent.ToString()) : 0;
                            break;
                        case "Dokumentation":
                            Dokumentation = cellContent.ToString();
                            break;
                        case "Sonderfreigabe":
                            Sonderfreigabe = (cellContent.ToString() != string.Empty) ? bool.Parse(cellContent.ToString()) : false;
                            break;
                        case "Gewicht":
                            Gewicht = (cellContent.ToString() != string.Empty) ? float.Parse(cellContent.ToString()) : 0;
                            break;
                        case "StückzahlProVerpackungseinheit":
                            StückzahlProVerpackungseinheit = (cellContent.ToString() != string.Empty) ? int.Parse(cellContent.ToString()) : 0;
                            break;
                        case "Versand_Komplettierung":
                            Versand_Komplettierung = (cellContent.ToString() != string.Empty) ? bool.Parse(cellContent.ToString()) : false;
                            break;
                        case "Versand_Versand":
                            Versand_Versand = (cellContent.ToString() != string.Empty) ? bool.Parse(cellContent.ToString()) : false;
                            break;
                        case "ErprobtMitBGK":
                            ErprobtMitBGK = cellContent.ToString();
                            break;
                        case "MontageProTag":
                            MontageProTag = (cellContent.ToString() != string.Empty) ? int.Parse(cellContent.ToString()) : 0;
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        // Auftrag in Datenbank speichern / updaten
        private void saveGerät_Execute()
        {
            if (saveGerät_CanExecute() == true)
            {
                // ToDo: Auftrag in Datenbank speichern / updaten
            }
        }

        // Überprüfen ob der Auftrag gespeichert werden kann (ob alle erforderlichen Felder vorhanden sind)
        private bool saveGerät_CanExecute()
        {
            // ToDo: Parameter überprüfen
            return false;
        }
        #endregion

        #region Klassenparameter
        // Allgemeine Felder
        public long Gerät_Id { get; set; }
        public string Sachnummer { get; set; }
        public string Bezeichnung { get; set; }
        public string Version { get; set; }
        public string Bemerkung { get; set; }
        public float Fertigungszeit { get; set; }
        public float Fertigungszeit_Gesamt { get; set; }
        public long AAWMontage { get; set; }
        public long AAWPrüfung { get; set; }
        public long AAWKomplettierung { get; set; }
        public string Dokumentation { get; set; }
        public bool Sonderfreigabe { get; set; }
        public float Gewicht { get; set; }
        public int StückzahlProVerpackungseinheit { get; set; }
        public bool Versand_Komplettierung { get; set; }
        public bool Versand_Versand { get; set; }
        public string ErprobtMitBGK { get; set; }
        public int MontageProTag { get; set; }
        #endregion
    }
}
