using System;
using System.Data.SqlClient;
using System.Web.UI;

namespace WebForm
{
    public partial class Class : System.Web.UI.Page
    {
        string connectionString = "server=LAPTOP-HURDBM1G;database=School01Db;trusted_connection=true;";

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            LblMsg.Visible = false;
        }

        protected void BtnRgstr_Click(object sender, EventArgs e)
        {
            LblMsg.Visible = true;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                string query = "INSERT INTO Class (ClassName, ClassTeacher, SubjectID) VALUES (@cn, @ct, @sid)";
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@cn", TxtClssName.Text); 
                cmd.Parameters.AddWithValue("@ct", TxtClssTchr.Text); 
                cmd.Parameters.AddWithValue("@sid", int.Parse(TxtSbjId.Text)); 

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    LblMsg.Text = "Registration Done!!!<br/>";
                }
                else
                {
                    LblMsg.Text = "Registration failed!";
                }
            }
        }
    }
}
