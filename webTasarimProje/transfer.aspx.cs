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
    public partial class transfer : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-F494DKQ;Initial Catalog=webTasarimProje;Integrated Security=True");
        SqlCommand com;

        static string nereye, tutar;

        private bool checking(string id)
        {
            bool check = false;
            string query = "select * from kayit_table where id = '" + id + "'";
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
            login lg = new login();
            string s = lg.kimlikAktar;
            string query = "select * from kayit_table where tcKimlikNo = '" + s + "'";
            com = new SqlCommand(query, con);
            con.Open();
            SqlDataReader dr = com.ExecuteReader();
            if (dr.Read())
            {
                string welcome = dr["ad"].ToString() + " " + dr["soyad"].ToString();
                lblWelcome.Text = welcome;
                txtBakiye.Text = dr["bakiye"].ToString();
            }
            else
            {
                Response.Write("<script>alert('Beklenmeyen Bir Hata Meydana Geldi.')</script>");
            }
            con.Close();
        }

        protected void lbBakiye_Click(object sender, EventArgs e)
        {
            Response.Write("<script>alert('Bakiye Ekleme Sayfasına Yönlendiriliyorsunuz.'); window.location = 'addBalance.aspx'</script>");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            login lg = new login(); loggedIn lgI = new loggedIn();
            string s = lg.kimlikAktar; string i = lgI.idAktar;
            if(txtHesapNo.Text.ToString().Trim() == "" || txtTutar.Text.ToString().Trim() == "")
            {
                Response.Write("<script>alert('Hesap No ve Tutar Alanı Boş Bırakılamaz.')</script>");
            }
            else
            {
                if (i == txtHesapNo.Text)
                {
                    Response.Write("<script>alert('Kendi Hesabınıza Para Transferi Yapamazsınız, Lütfen Transfer Yapılacak Olan Hesap Numarasını Kontrol Edin.')</script>");
                }
                else if (Convert.ToInt32(txtTutar.Text) < 10)
                {
                    Response.Write("<script>alert('Transfer Tutarı Minimum 10TL Olmalıdır.')</script>");
                }
                else if (txtTutar.Text.ToString().Trim() == "" || txtHesapNo.Text.ToString().Trim() == "")
                {
                    Response.Write("<script>alert('Lütfen Gerekli Alanları Doldurun.')</script>");
                }
                else if (checking(txtHesapNo.Text.ToString()) == false && Convert.ToInt32(txtBakiye.Text) < Convert.ToInt32(txtTutar.Text))
                {
                    lblHesapUyari.Visible = true;
                    lblBakiyeUyari.Visible = true;
                    Response.Write("<script>alert('Bu İşlem İçin Hesap Bakiyeniz Yetersizdir, Bakiye Ekleme Yaptıktan Sonra Tekrar Deneyin.')</script>");
                }
                else if (checking(txtHesapNo.Text.ToString()) == true && Convert.ToInt32(txtBakiye.Text) < Convert.ToInt32(txtTutar.Text))
                {
                    lblHesapUyari.Visible = false;
                    lblBakiyeUyari.Visible = true;
                    Response.Write("<script>alert('Bu İşlem İçin Hesap Bakiyeniz Yetersizdir, Bakiye Ekleme Yaptıktan Sonra Tekrar Deneyin.')</script>");
                }
                else if ((checking(txtHesapNo.Text.ToString()) == false) && Convert.ToInt32(txtBakiye.Text) >= Convert.ToInt32(txtTutar.Text))
                {
                    lblHesapUyari.Visible = true;
                    lblBakiyeUyari.Visible = false;
                }
                else
                {
                    lblBakiyeUyari.Visible = false;
                    lblHesapUyari.Visible = false;
                    string query = "update kayit_table set bakiye = bakiye + '" + (Convert.ToInt32(txtTutar.Text) - 5) + "'  where id ='" + txtHesapNo.Text + "'";
                    com = new SqlCommand(query, con);
                    con.Open();
                    com.ExecuteNonQuery();
                    con.Close();
                    string query2 = "update kayit_table set bakiye = bakiye - '" + (Convert.ToInt32(txtTutar.Text)) + "' where tcKimlikNo = '" + s + "'";
                    com = new SqlCommand(query2, con);
                    con.Open();
                    com.ExecuteNonQuery();
                    con.Close();
                    string query3 = "select * from kayit_table where tcKimlikNo = '" + s + "'";
                    com = new SqlCommand(query3, con);
                    con.Open();
                    SqlDataReader dr = com.ExecuteReader();
                    if (dr.Read())
                    {
                        string welcome = dr["ad"].ToString() + " " + dr["soyad"].ToString();
                        lblWelcome.Text = welcome;
                        txtBakiye.Text = dr["bakiye"].ToString();
                        nereye = txtHesapNo.Text;
                        tutar = txtTutar.Text;
                        txtHesapNo.Text = "";
                        txtTutar.Text = "";
                    }
                    else
                    {
                        Response.Write("<script>alert('Beklenmeyen Bir Hata Meydana Geldi.')</script>");
                    }
                    con.Close();
                    string query4 = "insert into transfer_table (nereden, nereye, tutar, tarih, kazanc) values (@nereden, @nereye, @tutar, @tarih, @kazanc)";
                    com = new SqlCommand(query4, con);
                    con.Open();
                    com.Parameters.AddWithValue("@nereden", i);
                    com.Parameters.AddWithValue("@nereye", nereye);
                    com.Parameters.AddWithValue("@tutar", tutar);
                    com.Parameters.AddWithValue("@tarih", DateTime.Now);
                    com.Parameters.AddWithValue("@kazanc", txtUcret.Text);
                    com.ExecuteNonQuery();
                    con.Close();
                    Response.Write("<script>alert('Transfer İşlemi Tamamlanmıştır.')</script>");
                }
            }
        }
    }
}