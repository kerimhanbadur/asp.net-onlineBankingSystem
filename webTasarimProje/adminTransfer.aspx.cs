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
    public partial class adminTransfer : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            dataSetTableAdapters.transfer_tableTableAdapter dt = new dataSetTableAdapters.transfer_tableTableAdapter();
            Repeater1.DataSource = dt.transferSet();
            Repeater1.DataBind();
        }
    }
}