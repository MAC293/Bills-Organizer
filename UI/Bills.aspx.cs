using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using BLL;
using TextBox = System.Web.UI.WebControls.TextBox;
using View = System.Web.UI.WebControls.View;

namespace UI
{
    public partial class Bills : System.Web.UI.Page
    {
        //private List<BillBLL> _Fees;
        private BillBLL _Bill;
        private Boolean _IsChanged;

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

        public Boolean IsChanged
        {
            get { return _IsChanged; }
            set { _IsChanged = value; }
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
            if (e.CommandName == "btnAdd")
            {
                try
                {
                    if (Page.IsValid)
                    {
                        BillBLL newBill = new BillBLL();

                        //Number
                        String strNumber = ((TextBox)grvFees.FooterRow.FindControl("txtNumberInsert")).Text;
                        int intNumber = int.Parse(strNumber);
                        newBill.Number = intNumber;

                        //DateIssue
                        String strDateIssue = ((TextBox)grvFees.FooterRow.FindControl("txtDateIssueInsert")).Text;
                        DateTime datDateIssue = DateTime.Parse(strDateIssue);
                        newBill.DateIssue = datDateIssue;

                        //ExpiringDate
                        String strExpiringDate = ((TextBox)grvFees.FooterRow.FindControl("txtExpiringDateInsert")).Text;
                        DateTime datExpiringDate = DateTime.Parse(strExpiringDate);
                        newBill.ExpiringDate = datExpiringDate;

                        //TotalPay
                        String strTotalPay = ((TextBox)grvFees.FooterRow.FindControl("txtTotalPayInsert")).Text;
                        int intTotalPay = int.Parse(strTotalPay);
                        newBill.TotalPay = intTotalPay;

                        //Status
                        var ddlStatus = ((DropDownList)grvFees.FooterRow.FindControl("ddlStatusInsert"));
                        String status = ddlStatus.SelectedItem.Text;//ddlStatus.SelectedValue;

                        if (status == "Paid")
                        {
                            status = "True";

                            Boolean paid = Boolean.Parse(status);
                            newBill.Status = paid;

                            ViewState["ddlStatusInsert"] = ddlStatus.SelectedValue;
                            IsChanged = false;
                            ViewState["IsChanged"] = IsChanged;

                        }
                        else if (status == "Unpaid")
                        {
                            status = "False";

                            Boolean unpaid = Boolean.Parse(status);
                            newBill.Status = unpaid;

                            ViewState["ddlStatusInsert"] = ddlStatus.SelectedValue;
                            IsChanged = false;
                            ViewState["IsChanged"] = IsChanged;
                        }
                    }
                }
                catch (NullReferenceException ex)
                {
                    MessageBox.Show("NullReferenceException: " + ex.Message);
                }
                catch (FormatException ex)
                {
                    MessageBox.Show("FormatException: " + ex.Message);
                }
            }
        }

        //protected Boolean Status(String combobox)
        //{

        //}

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