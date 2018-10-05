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
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)

            {

                lbl_Mess.Text = Session["user"].ToString();

                txt_Email.Text = Session["user"].ToString();

                txt_name.Text = Session["user1"].ToString();

                txt_Location.Text = Session["user2"].ToString();

                txt_phone.Text = Session["user3"].ToString();



            }
        }

        protected void btn_update_Click(object sender, EventArgs e)
        {

            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn1"].ConnectionString);

            SqlCommand cmd = new SqlCommand("[Tushar].[USP_UpdateCustomer_TusharRAM]", cn);

            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Email", txt_Email.Text);

            cmd.Parameters.AddWithValue("@CustomerName", txt_name.Text);

            cmd.Parameters.AddWithValue("@Location", txt_Location.Text);

            cmd.Parameters.AddWithValue("@PhoneNo", txt_phone.Text);







            cn.Open();



            cmd.ExecuteNonQuery();







            try



            {



                lbl_Mess.Text = "Successfully Updated";



            }



            catch (Exception ex)



            {



                lbl_Mess.Text = ex.Message.ToString();



            }







            finally



            {



                cn.Close();



            }
        }
    }
}