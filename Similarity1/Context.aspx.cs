using Similarity1.Entitiy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Similarity1
{
    public partial class Context : System.Web.UI.Page
    {
        My_Entitiy model = new My_Entitiy();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["ID"]))
            {
                int id = Convert.ToInt32(Request.QueryString["ID"]);
                HOMEWORK fill = model.HOMEWORK.SingleOrDefault(x => x.ID == id);
                lblHeader.Text = fill.TITLE;
                lblContext.Text = fill.CONTEXT;
            }
            
        }
    }
}