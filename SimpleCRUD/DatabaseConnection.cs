using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCRUD
{
    public static class DatabaseConnection
    {
        public static string ConnectionString { get; set; } = @"Server=(LocalDB)\MSSQLLocalDB;Integrated Security=True;AttachDbFilename=C:\Users\espinola.253086\source\repos\SimpleCRUD\SimpleCRUD\mydb.mdf;";

    }
}
