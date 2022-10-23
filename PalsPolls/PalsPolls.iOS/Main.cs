using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;
using System.Data.SqlClient;

namespace PalsPolls.iOS
{
    public class Application
    {
        // This is the main entry point of the application.
        static void Main(string[] args)
        {
            // if you want to use a different Application Delegate class from "AppDelegate"
            // you can specify it here.
            UIApplication.Main(args, null, typeof(AppDelegate));

        }
        //public Guid ClientConnectionId { get; }
        //public System.Data.SqlClient.SqlConnection Connection { get; }
        //public SqlConnection ();

        /*private static void OpenSqlConnection()
        {
            string connectionString = GetConnectionString();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                Console.WriteLine("ServerVersion: {0}", connection.ServerVersion);
                Console.WriteLine("State: {0}", connection.State);
            }
        }

        static private string GetConnectionString()
        {
            // To avoid storing the connection string in your code,
            // you can retrieve it from a configuration file, using the
            // System.Configuration.ConfigurationManager.ConnectionStrings property
            return "Data Source=(local);Initial Catalog=AdventureWorks;"
                + "Integrated Security=SSPI;";
        }*/

    }
}

