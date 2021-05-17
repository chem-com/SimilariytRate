using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Similarity1.Entitiy;
namespace Similarity1
{
    public partial class Login : System.Web.UI.Page
    {

        My_Entitiy model = new My_Entitiy();
        protected void Page_Load(object sender, EventArgs e)
        {



        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            int? id = 0;
            if (!string.IsNullOrEmpty(txtName.Text) & !string.IsNullOrEmpty(txtPassword.Text))
            {
                Users kontrol = model.Users.Where(x => x.Name == txtName.Text & x.Password == txtPassword.Text).ToList().First();
                if (kontrol != null) // Aynı kullanıcı adı şifre varsa login olmasın
                {
                    BaseClass.OnlineUserId = kontrol.ID;
                    Response.Redirect("NewText.aspx");
                }

            }
        }
    }
}