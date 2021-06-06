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
    public partial class register : System.Web.UI.Page
    {

        SqlConnection con = new SqlConnection("Data Source=DESKTOP-F494DKQ;Initial Catalog=webTasarimProje;Integrated Security=True");
        SqlCommand com; SqlDataReader dr;

        static string hesapNo; static int totalRow;
        private bool checking(string tc)
        {
            bool check = false;
            string checkStr = "select * from kayit_table where tcKimlikNo = '" + txtKimlik.Text + "'";
            com = new SqlCommand(checkStr, con);
            con.Open();
            dr = com.ExecuteReader();
            if (dr.HasRows)
            {
                check = true;
            }
            con.Close();
            dr = null;
            return check;
        }

        private bool checkingMail(string mail)
        {
            bool check = false;
            string checkStr = "select * from kayit_table where ePosta = '" + txtPosta.Text + "'";
            com = new SqlCommand(checkStr, con);
            con.Open();
            dr = com.ExecuteReader();
            if (dr.HasRows)
            {
                check = true;
            }
            con.Close();
            dr = null;
            return check;
        }

        private bool tcKontrol(string tc)
        {
            bool returnvalue = false;
            if (tc.Length == 11)
            {
                Int64 ATCNO, BTCNO, TcNo;
                long C1, C2, C3, C4, C5, C6, C7, C8, C9, Q1, Q2;

                TcNo = Int64.Parse(tc);

                ATCNO = TcNo / 100;
                BTCNO = TcNo / 100;

                C1 = ATCNO % 10; ATCNO = ATCNO / 10;
                C2 = ATCNO % 10; ATCNO = ATCNO / 10;
                C3 = ATCNO % 10; ATCNO = ATCNO / 10;
                C4 = ATCNO % 10; ATCNO = ATCNO / 10;
                C5 = ATCNO % 10; ATCNO = ATCNO / 10;
                C6 = ATCNO % 10; ATCNO = ATCNO / 10;
                C7 = ATCNO % 10; ATCNO = ATCNO / 10;
                C8 = ATCNO % 10; ATCNO = ATCNO / 10;
                C9 = ATCNO % 10; ATCNO = ATCNO / 10;
                Q1 = ((10 - ((((C1 + C3 + C5 + C7 + C9) * 3) + (C2 + C4 + C6 + C8)) % 10)) % 10);
                Q2 = ((10 - (((((C2 + C4 + C6 + C8) + Q1) * 3) + (C1 + C3 + C5 + C7 + C9)) % 10)) % 10);

                returnvalue = ((BTCNO * 100) + (Q1 * 10) + Q2 == TcNo);
            }
            return returnvalue;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (txtKimlik.Text.ToString().Trim() == "" || txtAd.Text.ToString().Trim() == "" || txtSoyad.Text.ToString().Trim() == "" || txtPosta.Text.ToString().Trim() == "" || txtSifre.Text.ToString().Trim() == "" || txtSifreKontrol.Text.ToString().Trim() == "")
            {
                Response.Write("<script>alert('Bir veya Birden Fazla Alana Boş, Lütfen Kontrol Edin.')</script>");
                string pass = txtSifre.Text; string pass2 = txtSifreKontrol.Text;
                txtSifre.Attributes.Add("value", pass);
                txtSifreKontrol.Attributes.Add("value", pass2);
                pass = null; pass2 = null;
            }
            else if (checking(txtKimlik.Text))
            {
                Response.Write("<script>alert('Girilen TC Kimlik Numaralı Kullanıcı Zaten Kayıtlı.')</script>");
                txtKimlik.Text = "";
                string pass = txtSifre.Text; string pass2 = txtSifreKontrol.Text;
                txtSifre.Attributes.Add("value", pass);
                txtSifreKontrol.Attributes.Add("value", pass2);
                pass = null; pass2 = null;
            }
            else if (tcKontrol(txtKimlik.Text) == false)
            {
                Response.Write("<script>alert('Girilen TC Kimlik Numarası Gereçli Değil.')</script>");
                txtKimlik.Text = "";
                string pass = txtSifre.Text; string pass2 = txtSifre.Text;
                txtSifre.Attributes.Add("value", pass);
                txtSifreKontrol.Attributes.Add("value", pass2);
                pass = null; pass2 = null;
            }
            else if (checkingMail(txtPosta.Text))
            {
                Response.Write("<script>alert('Girilen e-Posta Bankamıza Önceden Kayıtlı. Dilerseniz Şifremi Unuttum Seçeneği İle Şifrenizi Yenileyebilirsiniz.')</script>");
                txtPosta.Text = "";
                string pass = txtSifre.Text; string pass2 = txtSifreKontrol.Text;
                txtSifre.Attributes.Add("value", pass);
                txtSifreKontrol.Attributes.Add("value", pass2);
                pass = null; pass2 = null;
            }
            else if (txtSifre.Text != txtSifreKontrol.Text)
            {
                string kimlik = txtKimlik.Text;
                string ad = txtAd.Text;
                string soyad = txtSoyad.Text;
                string posta = txtPosta.Text;
                string pass = txtSifre.Text;
                string pass2 = txtSifreKontrol.Text;
                Response.Write("<script>alert('Şifreler Uyuşmuyor.')</script>");
                txtKimlik.Text = kimlik;
                txtAd.Text = ad;
                txtSoyad.Text = soyad;
                txtPosta.Text = posta;
                txtSifre.Attributes.Add("value", pass);
                txtSifreKontrol.Attributes.Add("value", pass2);
                pass = null; pass2 = null;
            }
            else
            {
                string insertion = "insert into kayit_table (tcKimlikNo, ad, soyad, ePosta, sifre) values (@tcKimlikNo, @ad, @soyad, @ePosta, @sifre)";
                com = new SqlCommand(insertion, con);
                con.Open();
                com.Parameters.AddWithValue("@tcKimlikNo", txtKimlik.Text);
                com.Parameters.AddWithValue("@ad", txtAd.Text);
                com.Parameters.AddWithValue("@soyad", txtSoyad.Text);
                com.Parameters.AddWithValue("@ePosta", txtPosta.Text);
                com.Parameters.AddWithValue("@sifre", txtSifre.Text);
                com.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Kayıt İşlemi Tamamlanmıştır, Ana Menüye Yönlendiriliyorsunuz.'); window.location = 'index.aspx'</script>");
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Write("<script>alert('Anasayfaya Yönlendiriliyorsunuz.'); window.location = 'index.aspx';</script>");
        }
    }
}