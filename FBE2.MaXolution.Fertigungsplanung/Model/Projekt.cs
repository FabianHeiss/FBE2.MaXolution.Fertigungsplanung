using FBE2.MaXolution.Fertigungsplanung.Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBE2.MaXolution.Fertigungsplanung.Model
{
    public class Projekt
    {
        #region Constructor
        public Projekt()
        {

        }

        public Projekt(long Id)
        {
            getProjekt(Id);
        }
        #endregion

        #region Functions
        private void getProjekt(long Id){
            Projekt_Id = Id;

            Datenbank db = new Datenbank();
            DataTable dt = new DataTable();
            dt = db.ExecuteQuery("SELECT * FROM H_Projekte WHERE Projekt_Id = " + Id.ToString());

            foreach (DataRow dr in dt.Rows)
            {
                foreach (DataColumn dc in dt.Columns)
                {
                    var cellContent = dr[dc];
                    switch (dc.ColumnName)
                    {
                        case "Projektnummer":
                            Projektnummer = (cellContent.ToString() != string.Empty) ? long.Parse(cellContent.ToString()) : 0;
                            break;
                        case "Projektbezeichnung":
                            Bezeichnung = cellContent.ToString();
                            break;
                        case "Kunde":
                            Kunde = cellContent.ToString();
                            break;
                        case "OEM":
                            OEM = cellContent.ToString();
                            break;
                        case "Vertriebsweg":
                            Vertriebsweg = cellContent.ToString();
                            break;
                        case "Kennung":
                            Kennung = cellContent.ToString();
                            break;
                        default:
                            break;
                    }
                }
            }
        }
        #endregion

        #region Properties
        public long Projekt_Id { get; set; }
        public long Projektnummer { get; set; }
        public string Bezeichnung { get; set; }
        public string Kunde { get; set; }
        public string OEM { get; set; }
        public string Vertriebsweg { get; set; }
        public string Kennung { get; set; }
        #endregion
    }
}
