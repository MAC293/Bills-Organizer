using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using BLL;

namespace UI
{
    public partial class Folder : System.Web.UI.Page
    {
        private FolderBLL folders = new FolderBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
          int id = (int) Session["OwnerID"];
          folders.Create(id);

        }

        protected void ibtnCable_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Bill.aspx");
        }
    }
}