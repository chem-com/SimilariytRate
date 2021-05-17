using Similarity1.Entitiy;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Similarity1
{
    public partial class NewText : System.Web.UI.Page
    {

        My_Entitiy model = new My_Entitiy();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtHeader.Text) & txtHeader.MaxLength <= 250 & !string.IsNullOrEmpty(txtContext.Text))
            {
                HOMEWORK ent = new HOMEWORK();
                ent.TITLE = txtHeader.Text;
                ent.CONTEXT = txtContext.Text;
                ent.USERID = BaseClass.OnlineUserId;
                ent.ISSCAN = true;

                using (My_Entitiy context = new My_Entitiy())
                {
                    var addedEntity = context.Entry(ent);
                    addedEntity.State = EntityState.Added;
                    context.SaveChanges();
                }
                Response.Redirect("index.aspx");
            }

        }
    }
}