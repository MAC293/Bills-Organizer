﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using BLL;

namespace UI
{
    public partial class Bill : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                String folderID = (String)Session["FolderID"];
                MessageBox.Show(folderID);
            }

        }

        protected void grvBills_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }
    }
}