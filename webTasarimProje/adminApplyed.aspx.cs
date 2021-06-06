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
    public partial class adminApplyed : System.Web.UI.Page
    {

        SqlConnection con = new SqlConnection("Data Source=DESKTOP-F494DKQ;Initial Catalog=webTasarimProje;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework");
        SqlCommand com; SqlDataReader dr;

        static string hesapNo, basvuruDurumu, basvuruId; static int bakiye;

        private bool checking(string cardNo)
        {
            bool check = false;
            string checkStr = "select * from kart_table where kartNo = '" + cardNo + "'";
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

        protected void Page_Load(object sender, EventArgs e)
        {
            dataSetTableAdapters.basvuru_tableTableAdapter dt = new dataSetTableAdapters.basvuru_tableTableAdapter();
            Repeater1.DataSource = dt.appyledSet();
            Repeater1.DataBind();

        }

        protected void Repeater1_ItemCommand(object sender, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Onayla")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                long min = 1234567890123456;
                long max = 9876543210987654;
                Random random = new Random();
                long cardNumber = random.Next() % (max - min) + min + random.Next() % (max - min) + min + random.Next() % (max - min);
                int sktAy = random.Next(1, 13);
                int sktYil = random.Next(2025, 2036);
                int cvv = random.Next(123, 987);
                if(checking(cardNumber.ToString()) == false)
                {
                    string hesapNoQuery = "select * from basvuru_table where id = '" + id + "'";
                    com = new SqlCommand(hesapNoQuery, con);
                    con.Open();
                    dr = com.ExecuteReader();
                    if (dr.Read())
                    {
                        hesapNo = dr["hesapNo"].ToString();
                        bakiye = Convert.ToInt32(dr["gelirBilgisi"]) / 2;
                    }
                    else
                    {
                        Response.Write("<script>alert('Beklenmeyen Bir Hata Meydana Geldi.')</script>");
                    }
                    dr = null;
                    con.Close();
                    string durumQuery = "select * from basvuru_table where id = '" + id + "'";
                    com = new SqlCommand(durumQuery, con);
                    con.Open();
                    dr = com.ExecuteReader();
                    if (dr.Read())
                    {
                        if(dr["basvuruDurumu"].ToString() == "Onaylandı")
                        {
                            Response.Write("<script>alert('Onaylanmış Bir Başvuru Yeniden Onay İşlemine Tabi Tutulamaz, Sadece Kart İptal İşlemi Yapılabilir.')</script>");
                        }
                        else if (dr["basvuruDurumu"].ToString() == "Onaylanmadı")
                        {
                            Response.Write("<script>alert('Onaylanmamış Bir Başvuru Yeniden Onay İşlemine Tabi Tutulamaz. Sadece Kart İptal İşlemi Yapılabilir.')</script>");
                        }
                        else
                        {
                            dr = null;
                            con.Close();
                            string s = "Onaylandı";
                            string query = "update basvuru_table set basvuruDurumu = '" + s + "' where hesapNo = '" + hesapNo + "'";
                            com = new SqlCommand(query, con);
                            con.Open();
                            com.ExecuteNonQuery();
                            con.Close();
                            string query2 = "insert into kart_table (hesapNo, kartNo, skAy, skYil, cvv, bakiye) values (@hesapNo, @kartNo, @skAy, @skYil, @cvv, @bakiye)";
                            com = new SqlCommand(query2, con);
                            con.Open();
                            com.Parameters.AddWithValue("@hesapNo", hesapNo);
                            com.Parameters.AddWithValue("@kartNo", cardNumber);
                            com.Parameters.AddWithValue("@skAy", sktAy);
                            com.Parameters.AddWithValue("@skYil", sktYil);
                            com.Parameters.AddWithValue("@cvv", cvv);
                            com.Parameters.AddWithValue("@bakiye", bakiye);
                            com.ExecuteNonQuery();
                            con.Close();
                            Response.Write("<script>alert('" + id + " Numaralı Kart Başvurusu Onaylanmıştır.'); window.location = 'adminApplyed.aspx'</script>");
                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('Beklenmeyen Bir Hata Meydana Geldi.')</script>");
                    }
                    dr = null;
                    con.Close();
                }
            }
            else if (e.CommandName == "Onaylama")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                string hesapNoQuery = "select * from basvuru_table where id = '" + id + "'";
                com = new SqlCommand(hesapNoQuery, con);
                con.Open();
                dr = com.ExecuteReader();
                if (dr.Read())
                {
                    hesapNo = dr["hesapNo"].ToString();
                    if (dr["basvuruDurumu"].ToString() == "Onaylandı")
                    {
                        Response.Write("<script>alert('Onaylanmış Bir Başvuru Yeniden Onay İşlemine Tabi Tutulamaz, Sadece Kart İptal İşlemi Yapılabilir.')</script>");
                    }
                    else if(dr["basvuruDurumu"].ToString() == "Onaylanmadı")
                    {
                        Response.Write("<script>alert('Önceden Red Edilmiş Bir Başvuru Yeniden Onay İşlemine Tabi Tutulamaz.')</script>");
                    }
                    else
                    {
                        dr = null;
                        con.Close();
                        string s = "Onaylanmadı";
                        string query = "update basvuru_table set basvuruDurumu = '" + s + "' where hesapNo = '" + hesapNo + "'";
                        com = new SqlCommand(query, con);
                        con.Open();
                        com.ExecuteNonQuery();
                        con.Close();
                        Response.Write("<script>alert('" + id + " Numaralı Kart Başvurusu Reddedilmiştir.'); window.location = 'adminApplyed.aspx'</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('Beklenmeyen Bir Hata Meydana Geldi.')</script>");
                }
                dr = null;
                con.Close();
            }
            else
            {
                int id = Convert.ToInt32(e.CommandArgument);
                string hesapNoQuery = "select * from basvuru_table where id = '" + id + "'";
                com = new SqlCommand(hesapNoQuery, con);
                con.Open();
                dr = com.ExecuteReader();
                if (dr.Read())
                {
                    hesapNo = dr["hesapNo"].ToString();
                    if (dr["basvuruDurumu"].ToString() == "Onaylandı")
                    {
                        dr = null;
                        con.Close();
                        string query = "delete from kart_table where hesapNo = '" + hesapNo + "'";
                        com = new SqlCommand(query, con);
                        con.Open();
                        com.ExecuteNonQuery();
                        con.Close();
                        string query2 = "delete from basvuru_table where id = '" + id + "'";
                        com = new SqlCommand(query2, con);
                        con.Open();
                        com.ExecuteNonQuery();
                        con.Close();
                        Response.Write("<script>alert('" + id + " ID Numaralı Kart İptal Edildi.'); window.location = 'adminApplyed.aspx'</script>");
                    }
                    else if (dr["basvuruDurumu"].ToString() == "Onaylanmadı")
                    {
                        Response.Write("<script>alert('Onay İşleminden Red Almış Bir Başvuru Yalnızca Başvuru Sahipi Tarafından İptal Edilebilir.')</script>");
                    }
                    else
                    {
                        Response.Write("<script>alert('Henüz Onay İşlemi Görmemiş Bir Başvuruyu İptal Edemezsiniz. Yalnızca Onaylanmış Başvurularda Kart İptal İşlemi Yapılmaktadır.')</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('Beklenmeyen Bir Hata Meydana Geldi.')</script>");
                }
            }
        }

    }
}