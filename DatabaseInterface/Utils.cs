using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace DatabaseInterface {

    public class Utils {
        public static Hashtable createTestProject() {
            Hashtable projectData = new Hashtable();

            projectData.Add("id", "1");
            projectData.Add("name", "test project");
            projectData.Add("street", "test street");
            projectData.Add("customer_id", "1");
            projectData.Add("street_number", "999");
            projectData.Add("city", "San Diego");
            projectData.Add("state", "CA");
            projectData.Add("zip_code", "92999");
            return projectData;
        }

        public static Boolean InsertFromFieldList(String tableName, Hashtable projectData) {

            if (projectData == null || projectData.Keys.Count <= 0) return false;
            String sql = "INSERT INTO " + tableName + " NAMES (";
            foreach (string key in projectData.Keys) {
                sql += "\"" + key + "\",";
            }

            sql.Remove(sql.Length - 1);
            sql += ") VALUES {";
            foreach (string key in projectData.Keys) {
                sql += "\"" + projectData[key].ToString() + "\",";
            }            
            sql.Remove(sql.Length - 1);
            sql += ")";

            string id = projectData["id"].ToString();
            string name = projectData["name"].ToString();
            string street = projectData["street"].ToString();
            string customer_id = projectData["customer_id"].ToString();
            string street_number = projectData["street_number"].ToString();
            string city = projectData["city"].ToString();
            string state = projectData["state"].ToString();
            string zip_code = projectData["zip_code"].ToString();
            //SQLServerInterface.Utils.I
            return true;

        }

        public static Boolean Login(String username, String password) {
            SQLServerInterface.this_works();
            /****
            String sqlString = "SELECT * FROM GreennetUsers WHERE username='" + username + "' AND Password='" + password + "'";
            String result = SQLServerInterface.ExecuteQuery(sqlString);
            if (result == null) return false;
            if (result.Length <= 0) return false;
            *****/
            return true;
        }

        public static String GetProject(String projectID) {
            String sqlString = "SELECT Project_id, Job_number, Work_type FROM Project WHERE Project_id = '" + projectID + "'";
            String result = SQLServerInterface.ExecuteQuery(sqlString);
            return result;
        }

        public static String GetHVACData(String projectID) {
            String sqlString = "SELECT Project_id, Job_number, Work_type FROM Project WHERE Project_id = '" + projectID + "'";
            String result = SQLServerInterface.ExecuteQuery(sqlString);
            return result;
        }

        public static String GetSolarData(String projectID) {
            String sqlString = "SELECT Project_id, Job_number, Work_type FROM Project WHERE Project_id = '" + projectID + "'";
            String result = SQLServerInterface.ExecuteQuery(sqlString);
            return result;
        }
    }
}
