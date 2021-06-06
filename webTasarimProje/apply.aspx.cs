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
    public partial class apply : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-F494DKQ;Initial Catalog=webTasarimProje;Integrated Security=True");
        SqlCommand com;

        private bool checking(string id)
        {
            bool check = false;
            string query = "select * from basvuru_table where hesapNo = '" + id + "'";
            com = new SqlCommand(query, con);
            con.Open();
            SqlDataReader dr = com.ExecuteReader();
            if (dr.HasRows)
            {
                check = true;
            }
            con.Close();
            dr = null;
            return check;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            loggedIn lgI = new loggedIn();
            string s = lgI.idAktar;
            txtHesapNo.Text = s;
            string query = "select * from kayit_table where id = '" + s + "'";
            com = new SqlCommand(query, con);
            con.Open();
            SqlDataReader dr = com.ExecuteReader();
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            loggedIn lgI = new loggedIn();
            string s = lgI.idAktar;
            if (txtCalisma.Visible == true && txtCalisma.Text.ToString().Trim() == "" || txtGelir.Text.ToString().Trim() == "")
            {
                Response.Write("<script>alert('Lütfen Başvuru İçin Gerekli Alanları Doldurunuz.')</script>");
            }
            else
            {
                if (checking(s) == false)
                {
                    string query = "insert into basvuru_table (hesapNo, calismaDurumu, gelirBilgisi, basvuruDurumu) values (@hesapNo, @calismaDurumu, @gelirBilgisi, @basvuruDurumu)";
                    com = new SqlCommand(query, con);
                    con.Open();
                    com.Parameters.AddWithValue("@hesapNo", txtHesapNo.Text);
                    if (cB.Checked == true)
                    {
                        com.Parameters.AddWithValue("@calismaDurumu", txtCalisma.Text);
                    }
                    else
                    {
                        com.Parameters.AddWithValue("@calismaDurumu", ddCalisma.SelectedItem.ToString());
                    }
                    com.Parameters.AddWithValue("@gelirBilgisi", txtGelir.Text);
                    com.Parameters.AddWithValue("@basvuruDurumu", "Başvuru Alındı");
                    com.ExecuteNonQuery();
                    con.Close();
                    Response.Write("<script>alert('Başvurunuz Alınmıştır, Gerekli Kontroller Yapılıp Tarafınıza Dönüş Sağlanacaktır.')</script>");
                }
                else
                {
                    Response.Write("<script>alert('Başvurunuz Bulunmaktadır, Başvurularım Sayfasına Yönlendiriliyorsunuz.'); window.location = 'applyed.aspx'</script>");
                }
            }
        }

        protected void cB_CheckedChanged(object sender, EventArgs e)
        {
            if(cB.Checked == true)
            {
                txtCalisma.Visible = true;
            }
            else
            {
                txtCalisma.Visible = false;
            }
        }
    }
}