using System;
using System.Data.SqlClient;
namespace PalsPolls.iOS
{
    public class SqlConnection
    {
        //Represents a connection to a SQL Server database. This class cannot be inherited.
        //public sealed class SqlConnection : System.Data.Common.DbConnection, ICloneable, IDisposable

        /* CONSTRUCTORS
         * SqlConnection() - Initializes a new instance of the SqlConnection class.
         * SqlConnection(String) - Initializes a new instance of the SqlConnection class when given a string that contains the connection string.
         * SqlConnection(String, SqlCredential) - Initializes a new instance of the SqlConnection class given a connection string, that does not use Integrated Security = true and a SqlCredential object that contains the user ID and password.
         */

        /* PROPERTIES
         * ConnectionString - empty string ("")
         * ConnectionTimeout - 15
         * Database - empty string ("")
         * DataSource - empty string ("")
         * public Guid ClientConnectionId { get; } -The connection ID of the most recent connection attempt, regardless of whether the attempt succeeded or failed.
         * public override string ConnectionString { get; set; } - Gets or sets the string used to open a SQL Server database.
         * public override int ConnectionTimeout { get; } - Gets the time to wait (in seconds) while trying to establish a connection before terminating the attempt and generating an error.
         * public System.Data.SqlClient.SqlCredential Credentials { get; set; } - SqlCredential provides a more secure way to specify the password for a login attempt using SQL Server Authentication.
         * public override string Database { get; } - Gets the name of the current database or the database to be used after a connection is opened.
         * [System.ComponentModel.Browsable(true)]
            public override string DataSource { get; } - Gets the name of the instance of SQL Server to which to connect.
         * public bool FireInfoMessageEventOnUserErrors { get; set; } - Gets or sets the FireInfoMessageEventOnUserErrors property.
         * public int PacketSize { get; } - Gets the size (in bytes) of network packets used to communicate with an instance of SQL Server.
         * [System.ComponentModel.Browsable(false)]
            public override string ServerVersion { get; } - Gets a string that contains the version of the instance of SQL Server to which the client is connected.
         * [System.ComponentModel.Browsable(false)]
            public override System.Data.ConnectionState State { get; } - Indicates the state of the SqlConnection during the most recent network operation performed on the connection.
         * public bool StatisticsEnabled { get; set; } - When set to true, enables statistics gathering for the current connection.
         * public string WorkstationId { get; } - Gets a string that identifies the database client.
         */

        /* METHODS
         * BEGINTRANSACTION
         * BeginTransaction() - Starts a database transaction.
         * BeginTransaction(IsolationLevel) - Starts a database transaction with the specified isolation level.
         * BeginTransaction(String) - Starts a database transaction with the specified transaction name.
         * BeginTransaction(IsolationLevel, String) - Starts a database transaction with the specified isolation level and transaction name.
         * 
         * CHANGES
         * public override void ChangeDatabase (string database); - Changes the current database for an open SqlConnection.
         * public static void ChangePassword (string connectionString, string newPassword); - Changes the SQL Server password for the user indicated in the connection string to the supplied new password.
         * 
         * public static void ClearAllPools (); - Empties the connection pool.
         * public static void ClearPool (System.Data.SqlClient.SqlConnection connection); - Empties the connection pool associated with the specified connection.
         * 
         * public override void Close (); - Closes the connection to the database. This is the preferred method of closing any open connection.
         * 
         * public System.Data.SqlClient.SqlCommand CreateCommand (); - Creates and returns a SqlCommand object associated with the SqlConnection.
         * 
         * GETSCHEMA
         * public override System.Data.DataTable GetSchema (); - Returns schema information for the data source of this SqlConnection. For more information about scheme, see SQL Server Schema Collections.
         * public override System.Data.DataTable GetSchema(String) - Returns schema information for the data source of this SqlConnection using the specified string for the schema name.
         * public override System.Data.DataTable GetSchema(String, String[]) - Returns schema information for the data source of this SqlConnection using the specified string for the schema name and the specified string array for the restriction values.
         * 
         * public override void Open (); - Opens a database connection with the property settings specified by the ConnectionString.
         * 
         * public void ResetStatistics (); - If statistics gathering is enabled, all values are reset to zero.
         * 
         * public System.Collections.IDictionary RetrieveStatistics (); - Returns a name value pair collection of statistics at the point in time the method is called.
         */

        /*EVENTS
         * public event System.Data.SqlClient.SqlInfoMessageEventHandler InfoMessage; - Occurs when SQL Server returns a warning or informational message.
         */

        /*EXPLICIT INTERFACE IMPLEMENTATIONS
         * object ICloneable.Clone (); - Creates a new object that is a copy of the current instance.
         * This member is an explicit interface member implementation. It can be used only when the SqlConnection instance is cast to an ICloneable interface.
         */

        /* ENCRYCTION
         * public enum SqlConnectionColumnEncryptionSetting - Specifies that Always Encrypted functionality is enabled in a connection. Note that these settings cannot be used to bypass encryption and gain access to plaintext data. For details, see Always Encrypted (Database Engine).
         * Disabled - Specifies the connection does not use Always Encrypted. Should be used if no queries sent over the connection access encrypted columns.
         * Enabled - Enables Always Encrypted functionality for the connection. Query parameters that correspond to encrypted columns will be transparently encrypted and query results from encrypted columns will be transparently decrypted.
         */

        /*The following example creates a SqlCommand and a SqlConnection. 
         * The SqlConnection is opened and set as the Connection for the SqlCommand. 
         * The example then calls ExecuteNonQuery. 
         * To accomplish this, the ExecuteNonQuery is passed a connection string and a query string that is a Transact-SQL INSERT statement. 
         * The connection is closed automatically when the code exits the using block.
        *
        private static void CreateCommand(string queryString, string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }
        *
         */

        /*
         * The following example creates and opens a SqlConnection.
        * 
        private static void OpenSqlConnection()
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
        }
        *
         */


        /* 
         * [System.Serializable]
         * public enum ApplicationIntent - Specifies a value for ApplicationIntent. Possible values are ReadWrite and ReadOnly.

         * Public delegate void OnChangeEventHandler(object sender, SqlNotificationEventArgs e); - Handles the OnChange event that is fired when a notification is received for any of the commands associated with a SqlDependency object.
         
         * public enum SortOrder - Specifies how rows of data are sorted.
         
         * public enum SqlAuthenticationMethod - Describes the different SQL authentication methods that can be used by a client connecting to Azure SQL Database.
         * For details, see Connecting to SQL Database By Using Azure Active Directory Authentication.        
        
         * [System.Serializable]
         * public sealed class SqlClientPermission : System.Data.Common.DBDataPermission - Enables the .NET Framework Data Provider for SQL Server to help make sure that a user has a security level sufficient to access a data source.

         * CanCreateDataSourceEnumerator - Gets a value that indicates whether a SqlDataSourceEnumerator can be created.
         
         * CreateConnection()- Returns a strongly typed DbConnection instance.
         */


        public SqlConnection()
        {
        }
    }
}

