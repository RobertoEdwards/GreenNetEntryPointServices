using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;

[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]

public class Service : System.Web.Services.WebService {
    private string documentPath = System.Web.Hosting.HostingEnvironment.MapPath("~/ApplicationImages/");

    public Service() {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public Boolean Login(String username, String password) {
        return DBInterface.Utils.Login(username, password);
    }

    [WebMethod]
    public String GetProject(String projectID) {
        return DBInterface.Utils.GetProject(projectID);
    }

    [WebMethod]
    public string PutFile(string data) {
        Convert.FromBase64String(data.ToString());
        return "PutFile " + "succesful";
    }

    [WebMethod]
    public string GetUser(string username) {
        return "GetUser " + username + " succesful";
    }

    [WebMethod]
    public bool TestSaveDocument(string docname) {
        Byte[] contents = GetDocument(docname);
        SaveDocument(contents, docname);

        return true;
    }

    [WebMethod]
    public bool SaveCustomer(string setString) {
        return DBInterface.Customer.SaveCustomer(setString);
    }

    [WebMethod]
    public bool UpdateCustomer(string setString, string customer_id) {
        return DBInterface.Customer.UpdateCustomer(setString, customer_id);
    }

    [WebMethod]
    public String SaveApplicationData(String setString, String name) {
        // build sql from parameters
        String sqlString = "UPDATE " + name;
        String[] setters = setString.Split(',');
        for (int i = 0; i < setters.Count(); i++) {
            sqlString += setters[i];
            if (i < setters.Count() - 1) {
                sqlString += " ";
            }
        }
        return sqlString;
    }

    [WebMethod]
    public bool SaveDocument(Byte[] docbinaryarray, string docname) {
        string strdocPath = documentPath + docname;
        FileStream objfilestream = new FileStream(strdocPath, FileMode.Create, FileAccess.ReadWrite);
        objfilestream.Write(docbinaryarray, 0, docbinaryarray.Length);
        objfilestream.Close();

        return true;
    }

    [WebMethod]
    public int GetDocumentLen(string docname) {
        string strdocPath = documentPath + docname;

        FileStream objfilestream = new FileStream(strdocPath, FileMode.Open, FileAccess.Read);
        int len = (int)objfilestream.Length;
        objfilestream.Close();

        return len;
    }


    [WebMethod]
    public Byte[] GetDocument(string docname) {
        string strdocPath = documentPath + docname;

        FileStream objfilestream = new FileStream(strdocPath, FileMode.Open, FileAccess.Read);
        int len = (int)objfilestream.Length;
        Byte[] documentcontents = new Byte[len];
        objfilestream.Read(documentcontents, 0, len);
        objfilestream.Close();

        return documentcontents;
    }
    [WebMethod]
    public string UploadFile(Byte[] f, string fileName) {
        // the byte array argument contains the content of the file
        // the string argument contains the name and extension
        // of the file passed in the byte array
        try {
            // instance a memory stream and pass the
            // byte array to its constructor
            System.IO.MemoryStream ms = new MemoryStream(f);

            // instance a filestream pointing to the
            // storage folder, use the original file name
            // to name the resulting file
            string path = System.Web.Hosting.HostingEnvironment.MapPath("~/output/");
            FileStream fs = new FileStream(System.Web.Hosting.HostingEnvironment.MapPath("~/output/") + fileName, FileMode.Create);

            // write the memory stream containing the original
            // file as a byte array to the filestream
            ms.WriteTo(fs);

            // clean up
            ms.Close();
            fs.Close();
            fs.Dispose();

            // return OK if we made it this far
            return "OK";
        } catch (Exception ex) {
            // return the error message if the operation fails
            return ex.Message.ToString();
        }
    }
}