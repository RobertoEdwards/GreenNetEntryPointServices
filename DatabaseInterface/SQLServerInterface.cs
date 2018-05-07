
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

using System.Data;

public class SQLServerInterface {
    // Data Source=ROBERTOEDWAB10B\RCGSQLEXPRESS;Integrated Security=False;User ID=sa;Password=********;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False

    public static SqlConnection myConnection = new SqlConnection("user id=sa;" +
                                   "password=quality1;" +
                                   "server=ROBERTOEDWAB10B\\RCGEXPRESS;" +
                                   "Trusted_Connection=yes;" +
                                   "database=EntryPointDB; " +
                                   "connection timeout=30");

    public static void this_works() {
        
        try {
            myConnection.Open();
        } catch (Exception e) {
            Console.WriteLine(e.ToString());
        }
        //SqlCommand myCommand = new SqlCommand("SELECT * FROM [User]", myConnection);
        //myCommand.ExecuteNonQuery();

        try {
            SqlDataReader myReader = null;
            SqlCommand myCommand = new SqlCommand("select * from [User]",
                                                        myConnection);
            myReader = myCommand.ExecuteReader();
            StringBuilder sb = new StringBuilder();
            string result = "";
            while (myReader.Read()) {
                for (int i = 0; i < myReader.FieldCount; i++) {
                    result += myReader[i].ToString();
                }
            }
        } catch (Exception e) {
            Console.WriteLine(e.ToString());
        }
        myConnection.Close();
    }

    public static void test_sql()
    {

        string queryString = "select * from [Users]";

        //ROBERTOEDWAB10B\RCGSQLEXPRESS
        //Server = myServerName\myInstanceName; Database = myDataBase; User Id = myUsername;
        //Password = myPassword;

        //string connectionString = "Server=.\PDATA_SQLEXPRESS;Database=;User Id=sa;Password=2BeChanged!;";
        string connectionString = "Server=ROBERTOEDWAB10B\\RCGSQLEXPRESS;User ID=sa;Password=quality1";
        string c = "Data Source=ROBERTOEDWAB10B\\RCGSQLEXPRESS;Initial Catalog=EnalasysDB;User ID=sa;Password=quality1";
        connectionString = c;
        try {
            using (SqlConnection connection = new SqlConnection(connectionString)) {
                SqlCommand command = new SqlCommand(queryString, connection);
                //command.Parameters.AddWithValue("@tPatSName", "Your-Parm-Value");
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                try {
                    while (reader.Read()) {
                        Console.WriteLine(String.Format("{0}, {1}",
                            reader["tPatCulIntPatIDPk"], reader["tPatSFirstname"]));// etc
                    }
                } finally {
                    // Always call Close when done reading.
                    reader.Close();
                }
            }
        } catch (Exception e) {
            int i = 0;
        }
    }

    //static string enalasysDBHost = "enalasysdb.cjbdx26ruyw8.us-west-2.rds.amazonaws.com";
    static string enalasysDBHost = "aarl56wkfz9pcs.cjbdx26ruyw8.us-west-2.rds.amazonaws.com";
    static string sqlConnectionString = "enalasysdb.cjbdx26ruyw8.us-west-2.rds.amazonaws.com";
    //static string sqlConnectionString = "enalasysdb.cjbdx26ruyw8.us-west-2.rds.amazonaws.com";
    static SqlConnection dbConnection = null;

    private static void OpenSql() {
        try {
            dbConnection = GetConnection();
            dbConnection.Open();
        } catch (Exception e) {
            throw new Exception("error" + e.Message.ToString());
        }
    }

    private static SqlConnection GetConnection() {
        string connectionString = "Server = " + enalasysDBHost + ";Database = enalasysdb;User ID = roberto; Password=quality1; port=3306";
        //string connectionString = enalasysDBHost + ";Database = GreenNetDB;User ID = EnalasysDB; Password=Quality1; port=3306";
        //string connectionString = string.Format("Server = {0};port={4};Database = {1}; User ID = {2}; Password = {3};", host, database, id, pwd, "3306");
        SqlConnection dbConnection = new SqlConnection(connectionString);
        return dbConnection;
    }

    public static string ExecuteQuery(string sqlString) {
        dbConnection = GetConnection();
        dbConnection.Open();

        SqlCommand cmd = new SqlCommand(sqlString, dbConnection);
        SqlDataReader rdr = cmd.ExecuteReader();

        if (rdr.HasRows == false) return null;

        StringBuilder sb = new StringBuilder();

        int columns = rdr.FieldCount;
        //return debugMsg;
        while (rdr.Read()) {
            for (int i = 0; i < columns; i++) {
                String colName = rdr.GetName(i);
                String colValue = rdr.GetValue(i).ToString();
                sb.Append(colName + "=" + colValue) ;

                if (i < columns - 1) {
                    sb.Append(",");
                }
            }
        }
        dbConnection.Close();
        String result = sb.ToString();

        return result;
    }

    public static string GetUser(string user) {
        string query = "SELECT * FROM  Users";
        return ExecuteQuery(query);
    }

    public static string GetApplication(string applicationID) {
        return "";
    }
}
