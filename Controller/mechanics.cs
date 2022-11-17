using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;


namespace sample.Controller
{

    class mechanics
    {
        OleDbConnection connection;
        OleDbCommand command;
        OleDbDataAdapter dataAdapter;
        DataTable bufferTable;

        public mechanics(string con)
        {
            connection = new OleDbConnection(con);
            bufferTable = new DataTable();
        }

        public DataTable UpdateMechanics()
        {
            connection.Open();
            dataAdapter = new OleDbDataAdapter("SELECT * FROM onBoardMechanic", connection);
            bufferTable.Clear();
            dataAdapter.Fill(bufferTable);
            connection.Close();
            return bufferTable;
        }

        public void AddMechanic(string SecondName, string NameOf, string Patronimyc, int workExperience)
        {
            connection.Open();

            command = new OleDbCommand($"INSERT INTO onBoardMechanic(SecondName, NameOf, Patronimyc, workExperience) VALUES(@SecondName, @NameOf, @Patronimyc, @workExperience)", connection);
            command.Parameters.AddWithValue("SecondName", SecondName);
            command.Parameters.AddWithValue("NameOf", NameOf);
            command.Parameters.AddWithValue("Patronimyc", Patronimyc);
            command.Parameters.AddWithValue("workExperience", workExperience);
            command.ExecuteNonQuery();
            connection.Close();

        }

        public void Remove(int ID)
        {
            connection.Open();
            command = new OleDbCommand($"DELETE FROM onBoardMechanic WHERE ID = {ID}", connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
    
}
