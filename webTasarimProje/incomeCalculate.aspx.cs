using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using WebChart;

namespace webTasarimProje
{
    public partial class incomeCalculate : System.Web.UI.Page
    {

        SqlConnection con = new SqlConnection("Data Source=DESKTOP-F494DKQ;Initial Catalog=webTasarimProje;Integrated Security=True");
        SqlCommand com; SqlDataReader dr; static string gelirBakiye, gelirTransfer;
        protected void Page_Load(object sender, EventArgs e)
        {
            string query = "select count(*) from bakiye_onay_table";
            com = new SqlCommand(query, con);
            con.Open();
            int totalRow = Convert.ToInt32(com.ExecuteScalar()); gelirBakiye = totalRow.ToString();
            con.Close();
            lblBalanceCount.Text = totalRow.ToString();
            lblBalanceIncome.Text = (totalRow * 5).ToString() + " TL";
            string query2 = "select count(*) from transfer_table";
            com = new SqlCommand(query2, con);
            con.Open();
            int totalRow2 = Convert.ToInt32(com.ExecuteScalar()); gelirTransfer = totalRow2.ToString();
            con.Close();
            lblTransferCount.Text = totalRow2.ToString();
            lblTransferIncome.Text = (totalRow2 * 5).ToString() + " TL";
            lblTotal.Text = ((totalRow * 5) + (totalRow2 * 5)).ToString() + " TL";

            PieChart chart = new PieChart();
            chart.Data.Add(new ChartPoint("Bakiye Ekleme İşlemi Gelirleri", totalRow * 5));
            chart.Data.Add(new ChartPoint("Transfer İşlemi Gelirleri", totalRow2 * 5));
            chart.Data.Add(new ChartPoint("Kart Kullanım Ücretleri", 5));
            chart.Data.Add(new ChartPoint("Kullanım Vergi Ücretleri", 5));

            ChartControl1.Charts.Add(chart);
            ChartControl1.RedrawChart();
        }
    }
}