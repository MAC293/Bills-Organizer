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
    public partial class Bills : System.Web.UI.Page
    {
        private List<BillBLL> _Fees;
        private BillBLL _Bill;

        public List<BillBLL> Fees
        {
            get { return _Fees; }
            set { _Fees = value; }
        }

        public BillBLL Bill
        {
            get { return _Bill; }
            set { _Bill = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            lblFolderName.Text = (String)Session["FolderName"];
            Bill = new BillBLL();

            if (!IsPostBack)
            {
                String folderID = (String)Session["FolderID"];

                if (Bill.BillsExistence(folderID))
                {
                    FillGridView(folderID);
                }
                else
                {
                    MessageBox.Show("You have no bills to show");
                    DisplayEmptyGridView();
                }
            }

        }

        protected void grvFees_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void FillGridView(String folderID)
        {
            Bill.RetrieveBills(folderID);
            Fees = Bill.Bills;
            grvFees.DataSource = Fees;
            grvFees.DataBind();
        }

        protected void DisplayEmptyGridView()
        {
            grvFees.DataSource = new object[] { null };
            grvFees.DataBind();
        }
    }
}