using System;
using System.Windows.Forms;
using BLL;

namespace UI
{
    public partial class LogIn : System.Web.UI.Page
    {
        private OwnerBLL newOwner = new OwnerBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
            //    Checking();
            //}
        }

        protected void btnLogIn_Click(object sender, EventArgs e)
        {

            OwnerBLL loginOwner = new OwnerBLL();

            loginOwner.Name = txtUsernameSI.Text;
            loginOwner.Password = txtPasswordSI.Text;

            if (loginOwner.LogIn())
            {
                loginOwner.SendDisplayName(loginOwner.Name, loginOwner.Password);
                Session["DisplayName"] = loginOwner.DisplayName;

                int sendID = loginOwner.SendID(loginOwner.Name, loginOwner.Password);
                Session["OwnerID"] = sendID;
                Response.Redirect("/Folder.aspx", false);
            }
            else
            {
                MessageBox.Show("Check username or password!");
            }
        }

        protected void lbSignUp_Click(object sender, EventArgs e)
        {
            if (txtUsernameSU.Text != null || txtPasswordSU.Text != null || txtDisplayNameSU.Text != null)
            {
                txtUsernameSU.Text = "";
                txtPasswordSU.Text = "";
                txtDisplayNameSU.Text = "";
            }

            ClientScript.RegisterStartupScript(GetType(), "ModalScript",
                "$(function(){ $('#newUser').modal('show'); });", true);
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            OwnerBLL newOwner = new OwnerBLL();

            newOwner.Name = txtUsernameSU.Text;
            newOwner.Password = txtPasswordSU.Text;
            newOwner.DisplayName = txtDisplayNameSU.Text;

            newOwner.Create();
        }
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