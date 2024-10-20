using System;
using System.Data;
using System.Data.SqlClient;

namespace temp3disconnected
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\TANMAY\source\repos\temp3disconnected\App_Data\Database1.mdf;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlDataAdapter ad = new SqlDataAdapter("select * from stud",con);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlDataAdapter ad = new SqlDataAdapter("select * from stud",con);
            SqlCommandBuilder cb = new SqlCommandBuilder(ad);
            cb.GetInsertCommand();
            DataTable dt = new DataTable("stud");
            ad.Fill(dt);
            DataRow dr = dt.NewRow();
            dr["roll"] = Convert.ToInt32(TextBox1.Text);
            dr["name"] = TextBox2.Text;
            dr["address"] = TextBox3.Text;
            dt.Rows.Add(dr);
            ad.Update(dt);
            Label1.Text = "Inserted!!!!";
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            SqlDataAdapter ad = new SqlDataAdapter("select * from stud", con);
            SqlCommandBuilder cb = new SqlCommandBuilder(ad);
            cb.GetInsertCommand();
            DataTable dt = new DataTable("stud");
            ad.Fill(dt);
            DataRow[] dr = dt.Select("roll=" + Convert.ToInt32(TextBox1.Text));
            dr[0].Delete();
            ad.Update(dt);
            Label1.Text = "Deleted!!!!";
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
    }
}