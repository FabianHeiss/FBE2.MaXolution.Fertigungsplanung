using FBE2.MaXolution.Fertigungsplanung.Framework;
using FBE2.MaXolution.Fertigungsplanung.Model;
using Microsoft.Practices.Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBE2.MaXolution.Fertigungsplanung.ViewModel
{
    class AuftragslisteViewModel : BaseViewModel
    {
        public AuftragslisteViewModel()
        {
            GetData = new DelegateCommand<string>(GetData_Execute);
        }

        private ObservableCollection<Auftrag> _Auftragsliste;

        public ObservableCollection<Auftrag> Auftragsliste
        {
            get { return _Auftragsliste; }
            set
            {
                _Auftragsliste = value;
                OnPropertyChanged("Auftragsliste");
            }
        }

        public void LoadData_Start(){
            Datenbank db = new Datenbank();
            DataTable dt = new DataTable();
            dt = db.ExecuteQuery("SELECT Auftrag_Id FROM S_Auftrag WHERE Fertigungsstatus_Id <> 7 and Auftragsnummer Not Like 'BGK%' ORDER BY Liefertermin");

            ObservableCollection<Auftrag> Aufträge = new ObservableCollection<Auftrag>();

            foreach (DataRow dr in dt.Rows)
            {
                Aufträge.Add(new Auftrag(long.Parse(dr[0].ToString()),true));
            }

            Auftragsliste = Aufträge;
        }

        private void LoadData(string sqlString)
        {
            Datenbank db = new Datenbank();
            DataTable dt = new DataTable();
            dt = db.ExecuteQuery(sqlString);

            ObservableCollection<Auftrag> Aufträge = new ObservableCollection<Auftrag>();

            Console.WriteLine("Start: " + DateTime.Now);
            foreach (DataRow dr in dt.Rows)
            {
                Console.WriteLine("Eintrag hinzufügen start: " + DateTime.Now);
                Aufträge.Add(new Auftrag(long.Parse(dr[0].ToString()),true));
                Console.WriteLine("intrag hinzufügen ende: " + DateTime.Now);
            }
            Console.WriteLine("Ende: " + DateTime.Now);

            Auftragsliste = Aufträge;
        }

        public DelegateCommand<string> GetData {get; set;}

        private void GetData_Execute(string Liste){
            switch (Liste)
            {
                case "Offene Aufträge":
                    LoadData("SELECT Auftrag_Id FROM S_Auftrag WHERE Fertigungsstatus_Id <> 7 and Auftragsnummer Not Like 'BGK%' ORDER BY Liefertermin ");
                    break;
                case "Offene Begleitkarten":
                    // ToDo: Begleitkarten-Fertigungsstatus
                    LoadData("SELECT Auftrag_Id FROM S_Auftrag WHERE Auftragsnummer Like 'BGK%' ORDER BY Liefertermin");
                    break;
                case "Versendete Aufträge":
                    // ToDo: Bearbeiten
                    LoadData("SELECT Auftrag_Id FROM S_Auftrag ORDER BY Liefertermin WHERE Fertigungsstatus_Id <> 7 and Auftragsnummer Not Like 'BGK*'");
                    break;
                case "Erledigte Begleitgarten":
                    // ToDo: Bearbeiten
                    LoadData("SELECT Auftrag_Id FROM S_Auftrag ORDER BY Liefertermin WHERE Fertigungsstatus_Id <> 7 and Auftragsnummer Not Like 'BGK*'");
                    break;
                case "Gelöschte Aufträge":
                    // ToDo: Bearbeiten
                    LoadData("SELECT Auftrag_Id FROM S_Auftrag ORDER BY Liefertermin WHERE Fertigungsstatus_Id <> 7 and Auftragsnummer Not Like 'BGK*'");
                    break;
                default:
                    break;
            }
        }
    }
}
