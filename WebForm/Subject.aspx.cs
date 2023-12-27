using System;
using System.Data.SqlClient;
using System.Web.UI;

namespace WebForm
{
    public partial class Subject : System.Web.UI.Page
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

                string query = "INSERT INTO Subject (SubjectName) VALUES (@SubjectName)";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@SubjectName", TxtSubName.Text);

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
