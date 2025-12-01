using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.SqlServer.Server;

namespace SimpleCRUD
{
    public class ClubRegistrationQuery
    {

        private SqlConnection sqlConnection;
        private SqlCommand sqlCommand;
        private SqlDataAdapter sqlAdapter;
        private SqlDataReader sqlReader;

        public DataTable dataTable;
        public BindingSource bindingSource;
        private string connectionString = @"Server=(LocalDB)\MSSQLLocalDB;Integrated Security=True;AttachDbFilename=C:\Users\oncepido.257554\source\repos\07_Laboratory_Exercise_1\SimpleCRUD\mydb.mdf;";
        public string _FirstName, MiddleName, _LastName, _Gender, _Program, _Age;

        public void DisplayList()
        {
            string ViewClubMembers = "SELECT * FROM dbo.ClubMembers";

            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            SqlDataAdapter sqlAdapter = new SqlDataAdapter(ViewClubMembers, sqlConnection);

            dataTable = new DataTable();
            sqlAdapter.Fill(dataTable);

            if (bindingSource == null)
                bindingSource = new BindingSource();

            bindingSource.DataSource = dataTable;

        }

        public bool RegisterStudent(int ID, long StudentID, string FirstName, string MiddleName, string LastName, int Age, string Gender, string Program)
        {
            sqlCommand = new SqlCommand("INSERT INTO dbo.ClubMembers VALUES (@ID, @StudentID, @FirstName, @MiddleName, @LastName, @Age, @Gender, @Program)", sqlConnection); 
            sqlCommand.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
            sqlCommand.Parameters.Add("@RegistrationID", SqlDbType.BigInt).Value = StudentID;
            sqlCommand.Parameters.Add("@StudentID", SqlDbType.VarChar).Value = StudentID;
            sqlCommand.Parameters.Add("@FirstName", SqlDbType.VarChar).Value = FirstName;
            sqlCommand.Parameters.Add("@MiddleName", SqlDbType.VarChar).Value = MiddleName;
            sqlCommand.Parameters.Add("@LastName", SqlDbType.VarChar).Value = LastName;
            sqlCommand.Parameters.Add("@Age", SqlDbType.Int).Value = Age;
            sqlCommand.Parameters.Add("@Gender", SqlDbType.VarChar).Value = Gender;
            sqlCommand.Parameters.Add("@Program", SqlDbType.VarChar).Value = Program;

            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();

            return true;
        }

    }
}
