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
    public partial class adminCoin : System.Web.UI.Page
    {

        static int totalRow;

        SqlConnection con = new SqlConnection("Data Source=DESKTOP-F494DKQ;Initial Catalog=webTasarimProje;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework");
        SqlCommand com; SqlDataReader dr;
        protected void Page_Load(object sender, EventArgs e)
        {
            dataSetTableAdapters.coin_tableTableAdapter dt = new dataSetTableAdapters.coin_tableTableAdapter();
            Repeater1.DataSource = dt.coinSet();
            Repeater1.DataBind();

            string query = "select count(*) from coin_table";
            com = new SqlCommand(query, con);
            con.Open();
            totalRow = Convert.ToInt32(com.ExecuteScalar());
            con.Close();
            txtId.Text = (totalRow + 1).ToString();
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            string query = "insert into coin_table (id, coinAdi, coinFiyati) values (@id, @coinAdi, @coinFiyati)";
            com = new SqlCommand(query, con);
            con.Open();
            com.Parameters.AddWithValue("@id", txtId.Text);
            com.Parameters.AddWithValue("@coinAdi", txtCoinAdi.Text);
            com.Parameters.AddWithValue("@coinFiyati", txtCoinFiyati.Text);
            com.ExecuteNonQuery();
            con.Close();
            Response.Write("<script>alert('"+txtCoinAdi.Text+" İSİMLİ COIN BANKA COIN BORSAMIZA EKLENMİŞTİR.'); window.location = 'adminCoin.aspx'</script>");
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Sil")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                string query = "delete from coin_table where id = '" + id + "'";
                com = new SqlCommand(query, con);
                con.Open();
                com.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('" + id + " ID NUMARALI COIN BANKA BORSASINDAN KALDIRILMITIR.'); window.location = 'adminCoin.aspx'</script>");
            }
        }
    }
}