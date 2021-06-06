using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Runtime.InteropServices;
using System.Data;
using System.Data.SqlClient;

namespace webTasarimProje
{
    public partial class superAdminLogIn : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-F494DKQ;Initial Catalog=webTasarimProje;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework");
        SqlCommand com; SqlDataReader dr;

        private string GetIP()
        {
            string strHostName = "";
            strHostName = System.Net.Dns.GetHostName();

            IPHostEntry ipEntry = System.Net.Dns.GetHostEntry(strHostName);

            IPAddress[] addr = ipEntry.AddressList;

            return addr[addr.Length - 1].ToString();

        }


        [DllImport("Iphlpapi.dll")]
        private static extern int SendARP(Int32 dest, Int32 host, ref Int64 mac, ref Int32 length);

        [DllImport("Ws2_32.dll")]
        private static extern Int32 inet_addr(string ip);

        private static string GetClientMAC(string strClientIP)
        {
            string mac_dest = "";
            try
            {
                Int32 ldest = inet_addr(strClientIP);
                Int32 lhost = inet_addr("");
                Int64 macinfo = new Int64();
                Int32 len = 6;
                int res = SendARP(ldest, 0, ref macinfo, ref len);
                string mac_src = macinfo.ToString("X");

                while (mac_src.Length < 12)
                {
                    mac_src = mac_src.Insert(0, "0");
                }

                for (int i = 0; i < 11; i++)
                {
                    if (0 == (i % 2))
                    {
                        if (i == 10)
                        {
                            mac_dest = mac_dest.Insert(0, mac_src.Substring(i, 2));
                        }
                        else
                        {
                            mac_dest = "-" + mac_dest.Insert(0, mac_src.Substring(i, 2));
                        }
                    }
                }
            }
            catch (Exception err)
            {
                throw new Exception("Lỗi " + err.Message);
            }
            return mac_dest;
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (txtId.Text.ToString().Trim() == "" || txtPw.Text.ToString().Trim() == "")
            {
                Response.Write("<script>alert('ID ve PW Alanı Doldurulmalıdır.')</script>");

            }
            else
            {
                string mac = GetClientMAC(GetIP());
                string query = "select * from super_admin_table where macAdresi = '" + mac + "'";
                com = new SqlCommand(query, con);
                con.Open();
                dr = com.ExecuteReader();
                if (dr.Read())
                {
                    if (txtId.Text.Equals(dr["kullaniciAdi"].ToString()))
                    {
                        if (txtPw.Text.Equals(dr["sifre"].ToString()))
                        {
                            Response.Write("<script>alert('Giriş Başarılı, superAdmin Sayfasına Yönlendiriliyorsunuz.'); window.location = 'superAdminLoggedIn.aspx'</script>");
                        }
                        else
                        {
                            string parola = txtPw.Text;
                            txtPw.TextMode = TextBoxMode.Password;
                            txtPw.Attributes.Add("value", parola);
                            Response.Write("<script>alert('PW Hatalı Girildi.')</script>");
                        }
                    }
                    else
                    {
                        string parola = txtPw.Text;
                        txtPw.TextMode = TextBoxMode.Password;
                        txtPw.Attributes.Add("value", parola);
                        txtId.Text = "";
                        Response.Write("<script>alert('ID Hatalı Girildi.')</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('Giriş Yetkiniz Bulunmamaktadır')</script>");
                }
                con.Close();
            }
        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox1.Checked == false)
            {
                string parola = txtPw.Text;
                txtPw.TextMode = TextBoxMode.Password;
                txtPw.Attributes.Add("value", parola);

            }
            else
            {
                txtPw.TextMode = TextBoxMode.SingleLine;
            }
        }
    }
}