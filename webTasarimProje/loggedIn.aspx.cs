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
    public partial class loggedIn : System.Web.UI.Page
    {

        private static string id;
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-F494DKQ;Initial Catalog=webTasarimProje;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            login lg = new login();
            string s = lg.kimlikAktar;
            string query = "select * from kayit_table where tcKimlikNo = '" + s + "'";
            SqlCommand com = new SqlCommand(query, con);
            con.Open();
            SqlDataReader dr = com.ExecuteReader();
            if (dr.Read())
            {
                string welcome = dr["ad"].ToString() + " " + dr["soyad"].ToString();
                lblWelcome.Text = welcome;
                id = dr["id"].ToString();
                txtKimlik.Text = dr["tcKimlikNo"].ToString();
                txtId.Text = dr["id"].ToString();
                txtAd.Text = dr["ad"].ToString();
                txtSoyad.Text = dr["soyad"].ToString();
                txtPosta.Text = dr["ePosta"].ToString();
                txtSifre.Attributes.Add("value", dr["sifre"].ToString());
            }
            else
            {
                Response.Write("<script>alert('Beklenmeyen Bir Hata Meydana Geldi.')</script>");
            }
            con.Close();
        }

        protected void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (txtAd.Text.ToString().Trim() == "" || txtSoyad.Text.ToString().Trim() == "" || txtPosta.Text.ToString().Trim() == "" || txtSifre.Text.ToString().Trim() == "")
            {
                Response.Write("<script>alert('Güncelleme İşlemi İçin Tüm Bilgiler Eksiksiz Doldurulmalıdır.')</script>");
            }
            else
            {

                string query = "update kayit_table set sifre = '" + txtSifre.Text + "' where tcKimlikNo = '" + txtKimlik.Text + "'";
                SqlCommand com = new SqlCommand(query, con);
                con.Open();
                com.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Güncelleme İşlemi Tamamlanmıştır.')</script>");
                string newQuery = "select * from kayit_table where tcKimlikNo = '" + txtKimlik.Text + "'";
                com = new SqlCommand(newQuery, con);
                con.Open();
                SqlDataReader dr = com.ExecuteReader();
                if (dr.Read())
                {
                    string welcome = dr["ad"].ToString() + " " + dr["soyad"].ToString();
                    lblWelcome.Text = welcome;
                    txtSifre.Attributes.Add("value", dr["sifre"].ToString());
                }
                else
                {
                    Response.Write("<script>alert('Beklenmeyen Bir Hata Meydana Geldi.')</script>");
                }
                con.Close();
            }
        }
        public string idAktar
        {
            get { return id; }
            set { id = value; }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Write("<script>alert('Güvenli Çıkış İşlemi Başarılı.'); window.location = 'index.aspx';</script>");
        }
    }
}