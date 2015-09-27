using FBE2.MaXolution.Fertigungsplanung.Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBE2.MaXolution.Fertigungsplanung.Model
{
    class Ersteller
    {
        #region Constructor
        public Ersteller()
        {

        }

        public Ersteller(long Id)
        {
            getErsteller(Id);
        }
        #endregion

        #region Functions
        private void getErsteller(long Id)
        {
            Ersteller_Id = Id;

            Datenbank db = new Datenbank();
            DataTable dt = new DataTable();
            dt = db.ExecuteQuery("SELECT * FROM H_Benutzer WHERE Ersteller_Id = " + Id.ToString());

            foreach (DataRow dr in dt.Rows)
            {
                foreach (DataColumn dc in dt.Columns)
                {
                    var cellContent = dr[dc];
                    switch (dc.ColumnName)
                    {
                        case "Nachname":
                            Nachname = cellContent.ToString();
                            break;
                        case "Vorname":
                            Vorname = cellContent.ToString();
                            break;
                        case "eMail":
                            eMail = cellContent.ToString();
                            break;
                        case "Personalnummer":
                            Personalnummer = (cellContent.ToString() != string.Empty) ? long.Parse(cellContent.ToString()) : 0;
                            break;
                        case "Windowskennung":
                            Windowskennung = cellContent.ToString();
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        public string getFullName()
        {
            if (Nachname != string.Empty & Vorname != string.Empty)
            {
                return Nachname + ", " + Vorname;
            }
            else if (Nachname != string.Empty & Vorname == string.Empty)
            {
                return Nachname;
            }
            return string.Empty;
        }
        #endregion

        #region Properties
        public long Ersteller_Id { get; set; }
        public string Nachname { get; set; }
        public string Vorname { get; set; }
        public string eMail { get; set; }
        public long Personalnummer { get; set; }
        public string Windowskennung { get; set; }
        #endregion
    }
}
