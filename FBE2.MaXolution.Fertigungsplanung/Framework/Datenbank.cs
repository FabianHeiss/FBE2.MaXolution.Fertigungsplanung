using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FBE2.MaXolution.Fertigungsplanung.Framework
{
    class Datenbank
    {
        public Datenbank()
        {
        }

        //private string _connectionString = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=C:\\Users\\DEHEIFAB\\Documents\\Visual Studio 2013\\Projects\\FBE2.MaXolution.Fertigungsplanung\\FBE2.MaXolution.Fertigungsplanung\\Resources\\FBE.MaXolution.Fertigungsplanung.Datenbank.mdb";
        private string _connectionString = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=C:\\Users\\Fabian\\Documents\\Visual Studio 2013\\Projects\\FBE2.MaXolution.Fertigungsplanung\\FBE2.MaXolution.Fertigungsplanung\\Resources\\FBE.MaXolution.Fertigungsplanung.Datenbank.mdb";

        public DataTable ExecuteQuery(string sqlString)
        {
            OleDbConnection connection = new OleDbConnection(_connectionString);
            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand(sqlString, connection);

                OleDbDataAdapter Adapter = new OleDbDataAdapter(command);
                DataTable dt = new DataTable();
                Adapter.Fill(dt);

                return dt;
            }
            catch (Exception e)
            {
                MessageBox.Show("Es ist ein Fehler beim Verarbeiten des Befehls " + e.Source + "\r\n " + e.Message, "Datenbank.cs << ExecuteQuery", MessageBoxButton.OK);
                return null;
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
