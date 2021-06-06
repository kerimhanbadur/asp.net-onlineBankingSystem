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
    public partial class addBalance : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-F494DKQ;Initial Catalog=webTasarimProje;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework");
        SqlCommand com; SqlDataReader dr;
        protected void Page_Load(object sender, EventArgs e)
        {
            loggedIn lgI = new loggedIn();
            string id = lgI.idAktar;
            string welcomeQuery = "select * from kayit_table where id = '" + id + "'";
            com = new SqlCommand(welcomeQuery, con);
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
            con.Close();
        }

        protected void btnOnay_Click(object sender, EventArgs e)
        {
            if(txtTutar.Text.ToString().Trim() == "" || Convert.ToInt32(txtTutar.Text) < 10)
            {
                Response.Write("<script>alert('Minimum Tutar 10TL Olmalıdır, Lütfen Kontrol Edin.')</script>");
            }
            else
            {
                loggedIn lgI = new loggedIn();
                string id = lgI.idAktar;
                string query = "insert into bakiye_ekle_table (hesapNo, tutar, kazanc) values (@hesapNo, @tutar, @kazanc)";
                com = new SqlCommand(query, con);
                con.Open();
                com.Parameters.AddWithValue("@hesapNo", id);
                com.Parameters.AddWithValue("@tutar", txtTutar.Text);
                com.Parameters.AddWithValue("@kazanc", txtKazanc.Text);
                com.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('İşlem Tamamlanmıştır, Bir Üst Sayfaya Yönlendiriliyorsunuz.'); window.location = 'transfer.aspx'</script>");
            }
        }

        protected void txtTutar_TextChanged(object sender, EventArgs e)
        {
            int s = Convert.ToInt32(txtTutar.Text) - Convert.ToInt32(txtKazanc.Text);
            txtNet.Text = s.ToString();
        }

        protected void cB_CheckedChanged(object sender, EventArgs e)
        {
            if (cB.Checked == true)
            {
                btnOnay.Enabled = true;
            }
            else btnOnay.Enabled = false;
        }
    }
}