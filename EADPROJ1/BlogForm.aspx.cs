using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class BlogForm : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string title = titleTextBox.Text;
        Console.WriteLine(title);
        string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
        SqlConnection myConn = new SqlConnection(DBConnect);

        string query = "INSERT INTO [Blog](Title) VALUES(@Title)";

        SqlCommand cmd = new SqlCommand(query, myConn);
        cmd.Parameters.Add("@Title", System.Data.SqlDbType.NVarChar).Value = title;

        myConn.Open();

        try
        {
            cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine("Caught exception: " + ex.Message);
        }

        myConn.Close();
    }
}