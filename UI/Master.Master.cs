﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace UI
{
    public partial class Master : System.Web.UI.MasterPage
    {
        private String _DisplayName;

        public String DisplayName
        {
            get { return _DisplayName; }
            set { _DisplayName = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            DisplayName = (String) Session["DisplayName"];
            lblDisplayName.Text = DisplayName;
        }

        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Close");
            Session.Abandon();
            Response.Redirect("/LogIn.aspx", false);
        }
    }
}