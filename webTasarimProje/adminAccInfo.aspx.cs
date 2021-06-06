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
    public partial class adminAccInfo : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-F494DKQ;Initial Catalog=webTasarimProje;Integrated Security=True");
        SqlCommand com; SqlDataReader dr;

        private bool checking(int id)
        {
            bool check = false;
            string checkStr = "select * from admin_table where id = '" + id + "'";
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
            dataSetTableAdapters.admin_tableTableAdapter dt = new dataSetTableAdapters.admin_tableTableAdapter();
            Repeater1.DataSource = dt.adminAccSet();
            Repeater1.DataBind();

            Random rnd = new Random();

            int i = rnd.Next(200);
            if(checking(i) == false)
            {
                txtId.Text = i.ToString();
            }

        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            if(txtKullaniciAdi.Text.ToString().Trim() == "" || txtSifre.Text.ToString().Trim() == "")
            {
                Response.Write("<script>alert('Kullanıcı Adı ve Şifre Alanı Boş Bırakılamaz.')</script>");
            }
            else
            {
                if(txtMacAdresi.Text.ToString().Trim() == "")
                {
                    Response.Write("<script>alert('Mac Adresi Boş Bırakılamaz.')</script>");
                }
                else
                {
                    string query = "insert into admin_table (id, kullaniciAdi, sifre, macAdresi) values (@id, @kullaniciAdi, @sifre, @macAdresi)";
                    com = new SqlCommand(query, con);
                    con.Open();
                    com.Parameters.AddWithValue("@id", txtId.Text);
                    com.Parameters.AddWithValue("@kullaniciAdi", txtKullaniciAdi.Text);
                    com.Parameters.AddWithValue("@sifre", txtSifre.Text);
                    com.Parameters.AddWithValue("@macAdresi", txtMacAdresi.Text);
                    com.ExecuteNonQuery();
                    con.Close();
                    Response.Write("<script>alert('Admin Ekleme İşlemi Başarılı.'); window.location = 'adminAccInfo.aspx'; </script>");
                }
            }
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if(e.CommandName == "Sil")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                string query = "delete from admin_table where id = '" + id + "'";
                com = new SqlCommand(query, con);
                con.Open();
                com.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('" + id + " ID Numaralı Admin Banka Kayıtlarından Silinmiştir.'); window.location = 'adminAccInfo.aspx'</script>");
            }
        }
    }
}