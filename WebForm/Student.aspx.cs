using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebForm
{
    public partial class Student : System.Web.UI.Page
    {
        string connectionString = "server=LAPTOP-HURDBM1G;database=School01Db;trusted_connection=true;";

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            LblMsg.Visible = false;
        }

        private SqlConnection GetSqlConnection()
        {
            return new SqlConnection(connectionString);
        }

        protected void BtnRgstr_Click(object sender, EventArgs e)
        {
            LblMsg.Visible = true;

            using (SqlConnection con = GetSqlConnection())
            {
                con.Open();

                string query = "INSERT INTO Student (FirstName, LastName, DateOfBirth, Gender, ClassId) " +
                               "VALUES (@fn, @ln, @dob, @gen, @classId)";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@fn", TxtStdFName.Text);
                cmd.Parameters.AddWithValue("@ln", TxtStdLName.Text);
                cmd.Parameters.AddWithValue("@dob", TxtStdCal.SelectedDate); 
                cmd.Parameters.AddWithValue("@gen", TxtStdGen.Text);
                cmd.Parameters.AddWithValue("@classId", int.Parse(TxtClsId.Text)); 
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




