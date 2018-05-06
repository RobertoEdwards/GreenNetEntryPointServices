using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DBInterface
{
    public class Customer {
        static public bool SaveCustomer(string setString) {
            // setString format: colname=value, colname=value ...
            String[] tokens = setString.Split(',');
            String sql = "insert into customer(project_id, phone, email, street, city, state, zip, country) values (1, 555-1212, me@me.com, 111 Main Street, San Diego, CA, 92128, USA)";
            sql = null;
            foreach (String s in tokens) {
                //Do your stuff here
                if (sql != null) {
                    sql += ",";
                } else {
                    sql = "INSERT INTO customer (";
                }
                String[] expr = s.Split('=');
                String var = expr[0];
                String val = "\"" + expr[1] + "\"";

                //if (haveSet) {
                sql += " " + var;
            }
            sql += " ) VALUES (";

            Boolean isSet = false;
            foreach (String s in tokens) {

                String[] expr = s.Split('=');
                String var = expr[0];
                String val = "\"" + expr[1] + "\"";


                if (isSet) {
                    sql += ",";
                }
                sql += " " + val;
                isSet = true;
            }
            sql += ")";
            if (sql != null) {
                SQLServerInterface.ExecuteQuery(sql);
            }
            return true;
        }

        static public bool UpdateCustomer(string setString, string customer_id) {
            // setString format: colname=value, colname=value ...
            String[] tokens = setString.Split(',');
            String sql = "insert into customer(project_id, phone, email, street, city, state, zip, country) values (1, 555-1212, me@me.com, 111 Main Street, San Diego, CA, 92128, USA)";
            sql = null;
            bool haveSet = false;
            foreach (String s in tokens) {
                //Do your stuff here
                if (sql != null) {
                    sql += ",";
                } else {
                    sql = "UPDATE customer ";
                }
                String[] expr = s.Split('=');
                String var = expr[0];
                String val = "\"" + expr[1] + "\"";

                if (haveSet) {
                    sql += " " + var + " = " + val;
                } else {
                    sql += "SET " + " " + var + " = " + val;
                }

                haveSet = true;
            }
            if (sql != null) {
                sql += " WHERE customer_id = \"" + customer_id + "\"";
                SQLServerInterface.ExecuteQuery(sql);
            }
            return true;
        }
    }
}
