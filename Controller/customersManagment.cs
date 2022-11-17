using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;


namespace sample.Controller
{
    class customersManagment
    {
        OleDbConnection connection;
        OleDbCommand command;
        OleDbDataAdapter dataAdapter;
        DataTable bufferTable;

        public customersManagment(string con)
        {
            connection = new OleDbConnection(con);
            bufferTable = new DataTable();
        }

        public DataTable UpdateCustomers()
        {
            connection.Open();
            dataAdapter = new OleDbDataAdapter("SELECT * FROM customers", connection);
            bufferTable.Clear();
            dataAdapter.Fill(bufferTable);
            connection.Close();
            return bufferTable;
        }

        public void AddCustomer(string ArticleOfOrder, int PhoneNumber, string SecondName, string NameOf,string Patronimic)
        {
            connection.Open();

            command = new OleDbCommand($"INSERT INTO customers(ArticleOfOrder, PhoneNumber, SecondName, NameOf, Patronimic) VALUES(@ArticleOfOrder, @PhoneNumber, @SecondNamw, @NameOf, @Patronimic)", connection);
            command.Parameters.AddWithValue("ArticleOfOrder", ArticleOfOrder);
            command.Parameters.AddWithValue("PhoneNumber", PhoneNumber);
            command.Parameters.AddWithValue("SecondName", SecondName);
            command.Parameters.AddWithValue("NameOf", NameOf);
            command.Parameters.AddWithValue("Patronimic", Patronimic);
            command.ExecuteNonQuery();
            connection.Close();

        }
        public void Remove(int ID)
        {
            connection.Open();
            command = new OleDbCommand($"DELETE FROM customers WHERE ID = {ID}", connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}
