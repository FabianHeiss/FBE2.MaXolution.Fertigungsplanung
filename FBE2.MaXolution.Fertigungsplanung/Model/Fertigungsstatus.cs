using FBE2.MaXolution.Fertigungsplanung.Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace FBE2.MaXolution.Fertigungsplanung.Model
{
    public class Fertigungsstatus
    {
        #region Constructor
        public Fertigungsstatus()
        {

        }

        public Fertigungsstatus(long Id)
        {
            getFertigungsstatus(Id);
        }
        #endregion

        #region Functions
        private void getFertigungsstatus(long Id)
        {
            Fertigungsstatus_Id = Id;

            Datenbank db = new Datenbank();
            DataTable dt = new DataTable();
            dt = db.ExecuteQuery("SELECT * FROM H_Fertigungsstatus WHERE Fertigungsstatus_Id = " + Id.ToString());

            foreach (DataRow dr in dt.Rows)
            {
                foreach (DataColumn dc in dt.Columns)
                {
                    var cellContent = dr[dc];
                    switch (dc.ColumnName)
                    {
                        case "Fertigungsstatus":
                            strFertigungsstatus = cellContent.ToString();
                            setBackground();
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        public void setBackground()
        {
            Point p1 = new Point(0,0);
            Point p2 = new Point(1.5,1);
            switch (strFertigungsstatus)
            {
                case "Planung":
                    Background = new LinearGradientBrush(Colors.Orange,Colors.Transparent,p1,p2);
                    break;
                case "Montage":
                    Background = new LinearGradientBrush(Colors.MediumTurquoise,Colors.Transparent,p1,p2);
                    break;
                case "Prüfbereit":
                    Background = new LinearGradientBrush(Colors.Orchid,Colors.Transparent,p1,p2);
                    break;
                case "Prüfung":
                    Background = new LinearGradientBrush(Colors.DeepSkyBlue,Colors.Transparent,p1,p2);
                    break;
                case "Komplettierung":
                    Background = new LinearGradientBrush(Colors.LightSkyBlue,Colors.Transparent,p1,p2);
                    break;
                case "Versendet":
                    Background = new LinearGradientBrush(Colors.GreenYellow,Colors.Transparent,p1,p2);
                    break;
                default:
                    Background = new LinearGradientBrush(Colors.White,Colors.Transparent,p1,p2);
                    break;
            }
        }
        #endregion

        #region Properties
        public long Fertigungsstatus_Id { get; set; }
        public string strFertigungsstatus { get; set; }
        public Brush Background { get; set; }
        #endregion
    }
}
