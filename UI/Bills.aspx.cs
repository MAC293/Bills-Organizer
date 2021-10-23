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
        //private List<BillBLL> _Fees;
        private BillBLL _Bill;

        //public List<BillBLL> Fees
        //{
        //    get { return _Fees; }
        //    set { _Fees = value; }
        //}


        public BillBLL Bill
        {
            get { return _Bill; }
            set { _Bill = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            lblFolderName.Text = (String)Session["FolderName"];

            if (!IsPostBack)
            {
                String folderID = (String)Session["FolderID"];
                //MessageBox.Show(folderID);

                Bill = new BillBLL();
                //Bill.Bills = new List<BillBLL>();

                if (Bill.BillsExistence(folderID))
                {
                    //MessageBox.Show("Bill.BillsExistence is TRUE"); 
                    Bill.RetrieveBills(folderID);

                    if (Bill.Bills != null)
                    {
                        if (Bill.Bills.Count > 0)
                        {
                            FillGridView();
                        }
                    }


                }
                else
                {
                    DisplayEmptyGridView();
                }

            }

        }

        protected void grvFees_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void FillGridView()
        {
            grvFees.DataSource = Bill.Bills;
            grvFees.DataBind();
        }

        protected void DisplayEmptyGridView()
        {
            grvFees.DataSource = new object[] { null };
            grvFees.DataBind();
        }
    }
}