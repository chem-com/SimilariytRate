using Similarity1.Entitiy;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Similarity1
{
    public partial class index : System.Web.UI.Page
    {
        My_Entitiy model = new My_Entitiy();
        protected void Page_Load(object sender, EventArgs e)
        {
            FillList();
        }
        public void FillList()
        {
            List<HOMEWORK> list = model.HOMEWORK.ToList();
            rptList.DataSource = list;
            rptList.DataBind();
        }
    }
}