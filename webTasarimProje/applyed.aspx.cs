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
    public partial class applyed : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-F494DKQ;Initial Catalog=webTasarimProje;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework");
        SqlCommand com; SqlDataReader dr;

        static int tekrar;
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
            string query = "select * from basvuru_table where hesapNo = '" + id + "'";
            com = new SqlCommand(query, con);
            con.Open();
            dr = com.ExecuteReader();
            if (dr.Read())
            {
                lblBasvuruNo.Text = dr["id"].ToString();
                lblHesapNo.Text = dr["hesapNo"].ToString();
                lblCalisma.Text = dr["calismaDurumu"].ToString();
                lblGelir.Text = dr["gelirBilgisi"].ToString();
                lblSonuc.Text = dr["basvuruDurumu"].ToString();
            }
            else
            {
                Response.Write("<script>alert('Beklenmeyen Bir Hata Meydana Geldi.')</script>");
            }
            dr = null;
            con.Close();
            if (lblSonuc.Text.ToString().Equals("Onaylandı"))
            {
                btnIptal.Enabled = false;
                Response.Write("<script>alert('Onaylanmış Bir Adet Kart Başvurunuz Bulunmaktadır, Başvurunuzu ve Kart Bilgilerinizi Aşağıdan Görüntüleyebilirsiniz.')</script>");
                kartBilgileri.Visible = true; lblKartUyari.Visible = true;
                string query2 = "select * from kart_table where hesapNo = '" + id + "'";
                com = new SqlCommand(query2, con);
                con.Open();
                dr = com.ExecuteReader();
                if (dr.Read())
                {
                    lblBagliHesap.Text = id;
                    lblKartNo.Text = dr["kartNo"].ToString();
                    lblSkAy.Text = dr["skAy"].ToString();
                    lblSkYil.Text = dr["skYil"].ToString();
                    lblCvv.Text = dr["cvv"].ToString();
                    lblBakiye.Text = dr["bakiye"].ToString();
                }
                else
                {
                    Response.Write("<script>alert('Beklenmeyen Bir Hata Meydana Geldi.')</script>");
                }
                dr = null;
                con.Close();

            }
            else if(lblSonuc.Text.ToString().Equals("Onaylanmadı"))
            {
                if (tekrar < 1)
                {
                    btnIptal.Enabled = true;
                    Response.Write("<script>alert('Onaylanmamış Bir Adet Kart Başvurunuz Bulunmaktadır, Başvurunuzu İptal Edip Yeni Başvuru Oluşturabilirsiniz.')</script>");
                    tekrar += 1;
                }
            }
        }

        protected void btnIptal_Click(object sender, EventArgs e)
        {
            loggedIn lgI = new loggedIn();
            string id = lgI.idAktar;
            string query = "delete from basvuru_table where hesapNo = '" + id + "'";
            com = new SqlCommand(query, con);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
            lblBasvuruNo.Text = "";
            lblHesapNo.Text = "";
            lblCalisma.Text = "";
            lblGelir.Text = "";
            lblSonuc.Text = "";
            Response.Write("<script>alert('Başvurunuz İptal Edilmiştir, Dilerseniz Yeni Başvuru Yapabilirsiniz.'); window.location = 'apply.aspx'</script>");
        }
    }
}