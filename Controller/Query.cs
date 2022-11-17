using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;

namespace sample.Controller
{
    class Query
    {
        OleDbConnection connection;
        OleDbCommand command;
        OleDbDataAdapter dataAdapter;
        DataTable bufferTable;

        public Query(string Conn)
        {
            connection = new OleDbConnection(Conn);
            bufferTable = new DataTable();

        }

        public DataTable UpdatePerson()
        {
            connection.Open();
            dataAdapter = new OleDbDataAdapter("SELECT * FROM Aircraft", connection);
            bufferTable.Clear();
            dataAdapter.Fill(bufferTable);
            connection.Close();
            return bufferTable;
        }

        public void Add(string aircraftName,string clas, int numberOfSeats)
        {
            connection.Open();
            command = new OleDbCommand($"INSERT INTO aircraft(aircraftName, clas, numberOfSeats) VALUES(@aircraftName, @clas, @numberOfSeats)", connection); //may be debugging
            command.Parameters.AddWithValue("aircraftName", aircraftName);
            command.Parameters.AddWithValue("clas", clas);
            command.Parameters.AddWithValue("numberOfSeats", numberOfSeats);
            command.ExecuteNonQuery();
            connection.Close();
        }
        public void Delete(int ID)
        {
            connection.Open();
            command = new OleDbCommand($"DELETE FROM aircraft WHERE ID = {ID}", connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        

    }
}
