using FBE2.MaXolution.Fertigungsplanung.Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        #endregion

        #region Funktionen
        // Auftrag aus Datenbank holen und Klassenparameter mit Daten füllen
        public void getAuftrag(long Id)
        {
            // ToDo: Parameter mit Werten füllen
            Datenbank db = new Datenbank();
            DataTable dt = new DataTable();
            dt = db.ExecuteQuery("SELECT * FROM S_Auftrag WHERE Auftrag_Id = " + Id.ToString());

            foreach (DataRow dr in dt.Rows)
            {
                foreach (DataColumn dc in dt.Columns){
                    var cellContent = dr[dc];
                    switch (dc.ColumnName)
                    {
                        case "Auftragsnummer":
                            Auftragsnummer = cellContent.ToString();
                            break;
                        case "Gerät_Id":
                            Gerät_Id = (long)(int)cellContent;
                            break;
                        case "Fertigungsstatus_Id":
                            Fertigungsstatus_Id = (long)(int)cellContent;
                            break;
                        default:
                            break;
                    }
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

        #region Klassenparameter
        // Allgemeine Felder
        public long Auftrag_Id { get; set; }
        public string Auftragsnummer { get; set; }
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
        public long Fertigungsstatus_Id { get; set; }
        public Fertigungsstatus Fertigungsstatus { get; set; }

        // Begleitkarten-Felder


        #endregion
    }
}
