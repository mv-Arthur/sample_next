using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;


namespace sample.Controller
{
    class pilotManager
    {
        OleDbConnection connection;
        OleDbCommand command;
        OleDbDataAdapter dataAdapter;
        DataTable bufferTable;

        public pilotManager(string con)
        {
            connection = new OleDbConnection(con);
            bufferTable = new DataTable();
        }

        public DataTable UpdatePilot()
        {
            connection.Open();
            dataAdapter = new OleDbDataAdapter("SELECT * FROM pilot", connection);
            bufferTable.Clear();
            dataAdapter.Fill(bufferTable);
            connection.Close();
            return bufferTable;
        }

        public void AddPilot(string SecondName, string NameOf, string Patronimic, string clas, string nameOfAircraft,string JobTitle)
        {
            connection.Open();

            command = new OleDbCommand($"INSERT INTO pilot(SecondName, NameOf, Patronimic, clas, nameOfAircraft, JobTitle) VALUES(@SecondName, @NameOf, @Patronimic, @class, @nameOfAircraft, @JobTitle)", connection);
            command.Parameters.AddWithValue("SecondName", SecondName);
            command.Parameters.AddWithValue("NameOf", NameOf);
            command.Parameters.AddWithValue("Patronimic", Patronimic);
            command.Parameters.AddWithValue("clas", clas);
            command.Parameters.AddWithValue("nameOfAircraft", nameOfAircraft);
            command.Parameters.AddWithValue("JobTitle", JobTitle);
            command.ExecuteNonQuery();
            connection.Close();

        }
        public void Remove(int ID)
        {
            connection.Open();
            command = new OleDbCommand($"DELETE FROM pilot WHERE ID = {ID}", connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}
