using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace webTasarimProje
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void btnKayit_Click(object sender, EventArgs e)
        {
            Response.Redirect("register.aspx");
        }

        protected void btnGiris_Click(object sender, EventArgs e)
        {
            Response.Redirect("login.aspx");
        }
    }
}