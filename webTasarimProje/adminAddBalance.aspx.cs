using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace webTasarimProje
{
    public partial class adminBakiye : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-F494DKQ;Initial Catalog=webTasarimProje;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework");
        SqlCommand com; SqlDataReader dr;

        static int tutar; static string hesapNo;
        protected void Page_Load(object sender, EventArgs e)
        {
            dataSetTableAdapters.bakiye_ekle_tableTableAdapter dt = new dataSetTableAdapters.bakiye_ekle_tableTableAdapter();
            Repeater1.DataSource = dt.balanceSet();
            Repeater1.DataBind();
        }

        protected void Repeater1_ItemCommand(object sender, RepeaterCommandEventArgs e)
        {
            
            if (e.CommandName == "Onayla")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                string query = "select * from bakiye_ekle_table where id = '" + id + "'";
                com = new SqlCommand(query, con);
                con.Open();
                dr = com.ExecuteReader();
                if (dr.Read())
                {
                    tutar = Convert.ToInt32(dr["tutar"].ToString()) - 5;
                    hesapNo = dr["hesapNo"].ToString();
                }
                else
                {
                    Response.Write("<script>alert('Beklenmeyen Bir Hata Meydana Geldi.')</script>");
                }
                dr = null;
                con.Close();
                string query2 = "update kayit_table set bakiye = bakiye + '" + tutar + "' where id = '" + hesapNo + "'";
                com = new SqlCommand(query2, con);
                con.Open();
                com.Parameters.AddWithValue("@bakiye", tutar);
                com.ExecuteNonQuery();
                con.Close();
                string query3 = "delete from bakiye_ekle_table where id = '" + id + "'";
                com = new SqlCommand(query3, con);
                con.Open();
                com.ExecuteNonQuery();
                con.Close();
                string query4 = "insert into bakiye_onay_table (durum) values (@durum)"; string s = "Tamamlandı";
                com = new SqlCommand(query4, con);
                con.Open();
                com.Parameters.AddWithValue("@durum", s);
                com.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('"+id+" Numaralı İşlem Onaylandı.'); window.location = 'adminAddBalance.aspx'</script>");
            }
            else
            {
                int id = Convert.ToInt32(e.CommandArgument);
                string query = "delete from bakiye_ekle_table where id = '" + id + "'";
                com = new SqlCommand(query, con);
                con.Open();
                com.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('" + id + " Numaralı İşlem İptal Edildi.'); window.location = 'adminAddBalance.aspx'</script>");
            }
        }
    }
}