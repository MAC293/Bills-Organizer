using System;
using System.Windows.Forms;
using BLL;

namespace UI
{
    public partial class LogIn : System.Web.UI.Page
    {
        private Owner newOwner = new Owner();
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
            //    Checking();
            //}
        }

        protected void btnLogIn_Click(object sender, EventArgs e)
        {

        }

        //public void Checking()
        //{
        //    if (newOwner.Connecting())
        //    {
        //        MessageBox.Show("Connected");
        //    }
        //    else
        //    {
        //        MessageBox.Show("Couldn't Connect");
        //    }
        //}



    }
}