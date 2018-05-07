using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;

namespace DatabaseInterface {
    public class Project {

        private int id { get; set; }        // TODO: non-zero/null = update
        private string name { get; set; }
        private string street { get; set; }
        private int customer_id { get; set; }
        private string street_number { get; set; }
        private string city { get; set; }
        private string state { get; set; }
        private string zip_code { get; set; }

        public Boolean Insert(Project project) {
            SqlConnection myConnection = SQLServerInterface.myConnection;
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

            return true;
        }
    }
}
