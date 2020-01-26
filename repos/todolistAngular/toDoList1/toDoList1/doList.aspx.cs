using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace toDoList1
{
    public partial class doList : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            

        }

        protected void add_Click(object sender, EventArgs e)
        {
            Response.Redirect("add.aspx");
        }

    }
}
