using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;

namespace webTasarimProje
{
    public partial class login : System.Web.UI.Page
    {
        static int controller, fPController;
        private static string tckno;
        private static string fPNo;

        public void sendMail(int confirmCode, string targetMail)
        {
            try{
                MailMessage msg = new MailMessage();
                msg.From = new MailAddress("info.kerimhanbadur.com@gmail.com");
                msg.To.Add(new MailAddress(targetMail));
                msg.Subject = "ABB BANK | GİRİŞ ONAYI";
                msg.Body = "ABB BANK GİRİŞ DOĞRULAMA KODUNUZ : " + confirmCode + " BU KOD İLE ABB BANKA GÜVENLİ BİR ŞEKİLDE GİRİŞ YAPABİLİRSİNİZ.";

                SmtpClient mySmtpClient = new SmtpClient();
                NetworkCredential myCredential = new NetworkCredential("info.kerimhanbadur.com@gmail.com", "siFr3..#");

                mySmtpClient.Host = "smtp.gmail.com";
                mySmtpClient.Port = 587;
                mySmtpClient.EnableSsl = true;
                mySmtpClient.UseDefaultCredentials = false;
                mySmtpClient.Credentials = myCredential;
                mySmtpClient.Send(msg);
                msg.Dispose();
            }
            catch (Exception ex)
            {
                // bla bla bla
            }
        }

        public void sendSifre(int confirmCode, string targetMail)
        {
            try
            {
                MailMessage msg = new MailMessage();
                msg.From = new MailAddress("info.kerimhanbadur.com@gmail.com");
                msg.To.Add(new MailAddress(targetMail));
                msg.Subject = "ABB BANK | ŞİFREMİ UNUTTUM";
                msg.Body = "ABB BANK ŞİFRE YENİLEME SAYFASINDA KULLANACAĞINIZ KOD : " + fPController + " BU KOD İLE ŞİFRE YENİLEME SAYFASINA GÜVENLİ BİR ŞEKİLDE GİRİŞ YAPABİLİRSİNİZ";

                SmtpClient mySmtpClient = new SmtpClient();
                NetworkCredential myCredential = new NetworkCredential("info.kerimhanbadur.com@gmail.com", "siFr3..#");

                mySmtpClient.Host = "smtp.gmail.com";
                mySmtpClient.Port = 587;
                mySmtpClient.EnableSsl = true;
                mySmtpClient.UseDefaultCredentials = false;
                mySmtpClient.Credentials = myCredential;
                mySmtpClient.Send(msg);
                msg.Dispose();
            }
            catch (Exception ex)
            {
                // bla bla bla
            }
        }

        SqlConnection con = new SqlConnection("Data Source=DESKTOP-F494DKQ;Initial Catalog=webTasarimProje;Integrated Security=True");
        SqlCommand com; SqlDataReader dr;

        protected void btnGiris_Click(object sender, EventArgs e)
        {
            if(txtKimlik.Text.ToString().Trim() == "" || txtSifre.Text.ToString().Trim() == "")
            {
                Response.Write("<script>alert('Bir veya Birden Fazla Alana Boş, Lütfen Kontrol Edin.')</script>");
            }
            else
            {
                string login = "select * from kayit_table where tcKimlikNo = '" + txtKimlik.Text + "' and sifre = '" + txtSifre.Text + "'";
                com = new SqlCommand(login, con);
                con.Open();
                dr = com.ExecuteReader();
                if (dr.Read())
                {
                    Random rnd = new Random();
                    int pass = rnd.Next(123456, 987654); controller = pass;
                    tckno = dr["tcKimlikNo"].ToString();
                    string mail = dr["ePosta"].ToString();
                    sendMail(pass, mail);
                    lblBankGiris.Visible = false;
                    lblKimlik.Visible = false;
                    lblSifre.Visible = false;
                    txtKimlik.Visible = false;
                    txtSifre.Visible = false;
                    btnGiris.Visible = false;
                    linkBtnSifre.Visible = false;
                    cB.Visible = false;
                    lblBankGirisOnay.Visible = true;
                    lblUyari.Visible = true;
                    txtMail.Visible = true;
                    btnOnay.Visible = true;
                }
                else
                {
                    string s = txtSifre.Text;
                    txtSifre.Attributes.Add("value", s);
                    Response.Write("<script>alert('TC Kimlik No veya Şifre Hatalı, Lütfen Kontrol Edin.')</script>");
                }
                con.Close(); dr = null;
            }
        }

        protected void btnOnay_Click(object sender, EventArgs e)
        {
            if(txtMail.Text.ToString().Trim() == "")
            {
                Response.Write("<script>alert('Onay Kodu Kısmı Boş Bırakılamaz.')</script>");
            }
            else
            {
                if (Convert.ToInt32(txtMail.Text.ToString()) == controller)
                {
                    Response.Redirect("loggedin.aspx");
                }
                else
                {
                    Response.Write("<script>alert('Onay Kodu Hatalı Girildi.')</script>");
                }
            }
        }

        public string kimlikAktar
        {
            get { return tckno; }
            set { tckno = value; }
        }


        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            if (txtKimlik.Text.ToString().Trim() == "")
            {
                Response.Write("<script>alert('Şifre Bağlantısı Gönderilebilmesi İçin TC Kimlik Numarası Girilmelidir.')</script>");
            }
            else
            {
                string login = "select * from kayit_table where tcKimlikNo = '" + txtKimlik.Text + "'";
                com = new SqlCommand(login, con);
                con.Open();
                dr = com.ExecuteReader();
                if (dr.Read())
                {
                    Random rnd = new Random();
                    int pass = rnd.Next(123456, 987654); fPController = pass; fPNo = fPController.ToString();
                    tckno = dr["tcKimlikNo"].ToString();
                    string mail = dr["ePosta"].ToString();
                    sendSifre(pass, mail);
                    Response.Write("<script>alert('Şifre Yenileme İşlemi İçin Mail Gönderilmiştir, Şifre Yenileme Sayfasına Yönlendiriliyorsunuz.'); window.location = 'forgotPassword.aspx'</script>");
                }
                else
                {
                    Response.Write("<script>alert('Hatalı TC Kimlik Numarası')</script>");
                }
            }
        }

        protected void cB_CheckedChanged(object sender, EventArgs e)
        {
            string s = txtSifre.Text;
            if (cB.Checked)
            {
                txtSifre.TextMode = TextBoxMode.SingleLine;
            }
            else
            {
                txtSifre.TextMode = TextBoxMode.Password;
                txtSifre.Attributes.Add("value", s);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Write("<script>alert('Anasayfaya Yönlendiriliyorsunuz.'); window.location = 'index.aspx';</script>");
        }

        public string fpAktar
        {
            get { return fPNo; }
            set { fPNo = value; }
        }

    }
}