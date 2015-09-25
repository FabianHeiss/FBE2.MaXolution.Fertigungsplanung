using System;
using System.Collections.Generic;
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
        private void getAuftrag(long Id)
        {
            // ToDo: Parameter mit Werten füllen
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


        // Begleitkarten-Felder


        #endregion
    }
}
