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
        private List<BillBLL> _Fees;
        private BillBLL _Bill;
        //private Boolean _IsChanged;
        private String _FolderID;

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

        public String FolderID
        {
            get { return _FolderID; }
            set { _FolderID = value; }
        }


        //public Boolean IsChanged
        //{
        //    get { return _IsChanged; }
        //    set { _IsChanged = value; }
        //}
        protected void Page_Load(object sender, EventArgs e)
        {
            lblFolderName.Text = (String)Session["FolderName"];

            if (!IsPostBack)
            {
                //String folderID = (String)Session["FolderID"];
                FolderID = (String)Session["FolderID"];
                //MessageBox.Show(FolderID);

                //Bill = new BillBLL();
                //ViewState["Bill"] = Bill;

                Fees = new List<BillBLL>();
                ViewState["Fees"] = Fees;

                Bill = new BillBLL();
                //ViewState["Bill"] = Bill;

                if (Bill.BillsExistence(FolderID))
                {
                    //MessageBox.Show("Bill.BillsExistence is TRUE"); 
                    //for (int i = 0; i < Bill.BillsQuatity(FolderID); i++)
                    //{
                    //    ViewState["BillsQty"] = i++;
                    //    Fees.Add(Bill.RetrieveBills(FolderID));
                    //    i = (int)ViewState["BillsQty"];
                    //    MessageBox.Show("i, UI " + i);

                    //}

                    Bill.RetrieveBills(FolderID, Fees);


                    if (Fees != null)
                    {
                        if (Fees.Count > 0)
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
            else
            {
                Fees = (List<BillBLL>) ViewState["Fees"];

                FolderID = (String)Session["FolderID"];

                //if (Fees == null)
                //{
                //    Fees = new List<BillBLL>();
                //}
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
                        //Bill = new BillBLL();
                        BillBLL newBill = new BillBLL();

                        //if (Bill.Bills != null)
                        //{
                        //    MessageBox.Show("Bill.Bills != null");
                        //}

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
                            //status = "True";

                            //Boolean paid = Boolean.Parse(status);
                            //Bill.Status = paid;

                            //ViewState["ddlStatusInsert"] = ddlStatus.SelectedValue;
                            //IsChanged = false;
                            //ViewState["IsChanged"] = IsChanged;

                            newBill.Status = "Paid";
                            

                        }
                        else if (status == "Unpaid")
                        {
                            //status = "False";

                            //Boolean unpaid = Boolean.Parse(status);
                            //Bill.Status = unpaid;

                            //ViewState["ddlStatusInsert"] = ddlStatus.SelectedValue;
                            //IsChanged = false;
                            //ViewState["IsChanged"] = IsChanged;

                            newBill.Status = "Unpaid";
                        }

                        newBill.Document = new Byte[0];

                        newBill.Folder = FolderID;

                        

                        if (Fees != null)
                        {
                            Fees.Add(newBill);
                            newBill.Create(FolderID);
                        }

                        FillGridView();
                        
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
            //grvFees.DataSource = Bill.Bills;
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