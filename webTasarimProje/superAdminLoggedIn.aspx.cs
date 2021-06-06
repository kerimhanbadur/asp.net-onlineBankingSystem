using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace webTasarimProje
{
    public partial class superAdminLoggedIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Write("<script>alert('Güvenli Çıkış İşlemi Başarılı.'); window.location = 'index.aspx';</script>");
        }
    }
}