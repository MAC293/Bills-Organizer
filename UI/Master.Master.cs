using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
    }
}