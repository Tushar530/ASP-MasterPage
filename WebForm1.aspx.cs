using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASP_SEARCH_MASTERPAGE
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }

        protected void btn_Search_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn1"].ConnectionString);


            SqlDataReader dr;
            SqlCommand cmd = new SqlCommand("[Tushar].[USP_ValidateEmail_Tushar_158230]", cn);


            cmd.CommandType = System.Data.CommandType.StoredProcedure;



            cmd.Parameters.AddWithValue("@Email", txt_Email.Text);

            cn.Open();

            try

            {

                dr = cmd.ExecuteReader();
               
                    if (dr.HasRows)

                    {


                    dr.Read();
                   

                        string id = dr[3].ToString();

                        Session["user"] = id;

                        string Name = dr[0].ToString();

                        Session["user1"] = Name;

                        string Location = dr[1].ToString();

                        Session["user2"] = Location;

                        string Phone = dr[2].ToString();

                        Session["user3"] = Phone;

                        Response.Redirect("WebForm2.aspx");

                    }



                    else

                        lbl_message.Text = "Invalid User";

                }
            

            catch (Exception ex)

            {

                lbl_message.Text = ex.Message.ToString();

            }

            finally

            {

                cn.Close();

            }

        }
    }
}
