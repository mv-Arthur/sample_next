using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;


namespace sample.Controller
{
    class orderManager
    {
        OleDbConnection connection;
        OleDbCommand command;
        OleDbDataAdapter dataAdapter;
        DataTable bufferTable;

        public orderManager(string con)
        {
            connection = new OleDbConnection(con);
            bufferTable = new DataTable();
        }

        public DataTable UpdateOrder()
        {
            connection.Open();
            dataAdapter = new OleDbDataAdapter("SELECT * FROM orderTable", connection);
            bufferTable.Clear();
            dataAdapter.Fill(bufferTable);
            connection.Close();
            return bufferTable;
        }

        public void AddOrder(int OrderDate, int Quantity, int Price)
        {
            connection.Open();

            command = new OleDbCommand($"INSERT INTO orderTable(OrderDate, Quantity, Price) VALUES(@OrderDate, @Quantity, @Price)", connection);
            command.Parameters.AddWithValue("OrderDate", OrderDate);
            command.Parameters.AddWithValue("Quantity", Quantity);
            command.Parameters.AddWithValue("Price", Price);
            command.ExecuteNonQuery();
            connection.Close();

        }

        public void Remove(int ID)
        {
            connection.Open();
            command = new OleDbCommand($"DELETE FROM orderTable WHERE ID = {ID}", connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

    }
}
