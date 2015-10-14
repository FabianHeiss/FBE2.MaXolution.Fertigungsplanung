using FBE2.MaXolution.Fertigungsplanung.Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBE2.MaXolution.Fertigungsplanung.Model
{
    public class Vertriebsart
    {
        #region Constructor
        public Vertriebsart()
        {

        }

        public Vertriebsart(long Id)
        {
            getVertriebsart(Id);
        }
        #endregion

        #region Functions
        private void getVertriebsart(long Id)
        {
            Vertriebsart_Id = Id;

            Datenbank db = new Datenbank();
            DataTable dt = new DataTable();
            dt = db.ExecuteQuery("SELECT * FROM H_Vertriebsart WHERE Vertriebsart_Id = " + Id.ToString());

            foreach (DataRow dr in dt.Rows)
            {
                foreach (DataColumn dc in dt.Columns)
                {
                    var cellContent = dr[dc];
                    switch (dc.ColumnName)
                    {
                        case "Vertriebsart":
                            strVertriebsart = cellContent.ToString();
                            break;
                        default:
                            break;
                    }
                }
            }
        }
        #endregion

        #region Properties
        public long Vertriebsart_Id { get; set; }
        public string strVertriebsart { get; set; }
        #endregion
    }
}
