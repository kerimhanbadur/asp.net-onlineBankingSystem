using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;

namespace webTasarimProje
{
    public partial class coin : System.Web.UI.Page
    {

        static string coinName, coinFiyat;

        SqlConnection con = new SqlConnection("Data Source=DESKTOP-F494DKQ;Initial Catalog=webTasarimProje;Integrated Security=True");
        SqlCommand com; SqlDataReader dr;

        protected void Page_Load(object sender, EventArgs e)
        {
            login lg = new login();
            string s = lg.kimlikAktar;
            string query = "select * from kayit_table where tcKimlikNo = '" + s + "'";
            com = new SqlCommand(query, con);
            con.Open();
            dr = com.ExecuteReader();
            if (dr.Read())
            {
                string welcome = dr["ad"].ToString() + " " + dr["soyad"].ToString();
                lblWelcome.Text = welcome;
            }
            else
            {
                Response.Write("<script>alert('Beklenmeyen Bir Hata Meydana Geldi.')</script>");
            }
            dr = null;
            con.Close();

            dataSetTableAdapters.coin_tableTableAdapter dt = new dataSetTableAdapters.coin_tableTableAdapter();
            Repeater1.DataSource = dt.coinSet();
            Repeater1.DataBind();

            //dataSetTableAdapters.coin_hesap_tableTableAdapter dtt = new dataSetTableAdapters.coin_hesap_tableTableAdapter();
            //Repeater2.DataSource = dtt.coinAccSet();
            //Repeater2.DataBind();
        }
    }
}