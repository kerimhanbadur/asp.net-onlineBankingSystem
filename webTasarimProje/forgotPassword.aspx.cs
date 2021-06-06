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
    public partial class forgotPassword : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-F494DKQ;Initial Catalog=webTasarimProje;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework");
        SqlCommand com; SqlDataReader dr;
        protected void Page_Load(object sender, EventArgs e)
        {
            login lg = new login();
            string s = lg.kimlikAktar;
            txtKimlik.Text = s;
        }

        protected void btnSifreYenile_Click(object sender, EventArgs e)
        {
            login lg = new login();
            string s = lg.fpAktar;
            if(txtSifre.Text.ToString().Trim() == "" || txtSifreOnay.Text.ToString().Trim() == "" || txtMailOnay.Text.ToString().Trim() == "")
            {
                Response.Write("<script>alert('Şifre Yenileme İşlemi İçin Tüm Alanlar Eksiksiz Doldurulmalıdır.')</script>");
            }
            else if(txtSifre.Text.ToString().Trim() != txtSifreOnay.Text.ToString().Trim())
            {
                Response.Write("<script>alert('Girilen İki Şifrenin de Aynı Olduğunu Kontrol Edin.')</script>");
            }
            else if (txtMailOnay.Text.ToString().Trim() != s)
            {
                Response.Write("<script>alert('Girilen Mail Onay Kodu Hatalı, Lütfen Kontrol Edin.')</script>");
            }
            else
            {
                string query = "update kayit_table set sifre = '" + txtSifre.Text + "' where tcKimlikNo = '" + txtKimlik.Text + "'";
                com = new SqlCommand(query, con);
                con.Open();
                com.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Şifre Güncelleme İşlemi Tamamlandı, Giriş Sayfasına Yönlendiriliyorsunuz.'); window.location = 'login.aspx'</script>");
            }
        }
    }
}