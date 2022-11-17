using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;


namespace sample.Controller
{
    class ticketsManagment
    {
        OleDbConnection connection;
        OleDbCommand command;
        OleDbDataAdapter dataAdapter;
        DataTable bufferTable;

        public ticketsManagment(string con)
        {
            connection = new OleDbConnection(con);
            bufferTable = new DataTable();
        }

        public DataTable UpdateTickets()
        {
            connection.Open();
            dataAdapter = new OleDbDataAdapter("SELECT * FROM Tickets", connection);
            bufferTable.Clear();
            dataAdapter.Fill(bufferTable);
            connection.Close();
            return bufferTable;
        }

        public void AddTicket(int Quantity, int price, string Article)
        {
            connection.Open();

            command = new OleDbCommand($"INSERT INTO Tickets(Quantity, price, Article) VALUES(@Quantity, @price, @Article)", connection);
            command.Parameters.AddWithValue("Quantity", Quantity);
            command.Parameters.AddWithValue("price", price);
            command.Parameters.AddWithValue("Article", Article);
            command.ExecuteNonQuery();
            connection.Close();

        }

        public void Remove(int ID)
        {
            connection.Open();
            command = new OleDbCommand($"DELETE FROM Tickets WHERE ID = {ID}", connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

    }
}
