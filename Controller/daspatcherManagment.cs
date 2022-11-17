using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;


namespace sample.Controller
{
    class dispatcherManagment
    {
        OleDbConnection connection;
        OleDbCommand command;
        OleDbDataAdapter dataAdapter;
        DataTable bufferTable;

        public dispatcherManagment(string con)
        {
            connection = new OleDbConnection(con);
            bufferTable = new DataTable();
        }

        public DataTable Updatedispatcher()
        {
            connection.Open();
            dataAdapter = new OleDbDataAdapter("SELECT * FROM dispatcher", connection);
            bufferTable.Clear();
            dataAdapter.Fill(bufferTable);
            connection.Close();
            return bufferTable;
        }

        public void AddDispatcher(string SecondName, string NameOf, string Patronimic)
        {
            connection.Open();

            command = new OleDbCommand($"INSERT INTO dispatcher(SecondName, NameOf, Patronimic) VALUES(@SecondName, @NameOf, @Patronimic)", connection);
            command.Parameters.AddWithValue("SecondName", SecondName);
            command.Parameters.AddWithValue("NameOf", NameOf);
            command.Parameters.AddWithValue("Patronimic", Patronimic);
            command.ExecuteNonQuery();
            connection.Close();

        }
        public void Remove(int ID)
        {
            connection.Open();
            command = new OleDbCommand($"DELETE FROM dispatcher WHERE ID = {ID}", connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}