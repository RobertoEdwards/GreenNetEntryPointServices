using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBInterface {

    public class Utils {
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
