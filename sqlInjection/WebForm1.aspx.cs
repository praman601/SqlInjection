using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace sqlInjection
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection("Data Source=PRADEEP\\SQLEXPRESS;Initial Catalog=product;Integrated Security=true"))
            {
                string cmd= "spGetProductsByName";
                    
                SqlCommand cm = new SqlCommand(cmd, con);
                cm.CommandType = System.Data.CommandType.StoredProcedure;
                cm.Parameters.AddWithValue("@ProductName", TextBox1.Text + "%");
                con.Open();
                GridView1.DataSource = cm.ExecuteReader();
                GridView1.DataBind();

            }
        }

        
    }
}