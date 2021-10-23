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
            int id = (int)Session["OwnerID"];

            if (!IsPostBack)
            {
                if (!folders.CheckUser(id))
                {
                    folders.Create(id);
                }
            }

            //MessageBox.Show("OwnerID, Folder: "+id);

        }

        protected void ibtnCable_Click(object sender, ImageClickEventArgs e)
        {
            String folderID = folders.FolderID("Cable", (int)Session["OwnerID"]);

            //MessageBox.Show("OwnerID, Folder, Cable Clicked: " + (int)Session["OwnerID"]);
            //MessageBox.Show("FolderID, Folder, Cable Clicked: " + folderID);
            //MessageBox.Show("Session[FolderID], Cable Clicked, Folder: " + folderID);

            Session["FolderID"] = folderID;
            //MessageBox.Show("Session[FolderID], Cable Clicked, Folder: " + (String)Session["FolderID"]);
            Session["FolderName"] = "Cable";

            Response.Redirect("Bills.aspx");
        }

        protected void ibtnElectricity_Click(object sender, ImageClickEventArgs e)
        {
            String folderID = folders.FolderID("Electricity", (int)Session["OwnerID"]);

            Session["FolderID"] = folderID;
            Session["FolderName"] = "Electricity";

            Response.Redirect("Bills.aspx");
        }

        protected void ibtnGas_Click(object sender, ImageClickEventArgs e)
        {
            String folderID = folders.FolderID("Gas", (int)Session["OwnerID"]);

            Session["FolderID"] = folderID;
            Session["FolderName"] = "Gas";

            Response.Redirect("Bills.aspx");
        }

        protected void ibtnMobilePhone_Click(object sender, ImageClickEventArgs e)
        {
            String folderID = folders.FolderID("Mobile Phone", (int)Session["OwnerID"]);

            Session["FolderID"] = folderID;
            Session["FolderName"] = "Mobile Phone";

            Response.Redirect("Bills.aspx");
        }

        protected void ibtnWater_Click(object sender, ImageClickEventArgs e)
        {
            String folderID = folders.FolderID("Water", (int)Session["OwnerID"]);

            Session["FolderID"] = folderID;
            Session["FolderName"] = "Water";

            Response.Redirect("Bills.aspx");
        }
    }
}