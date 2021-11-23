using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using BLL;
using Label = System.Web.UI.WebControls.Label;
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
                Fees = (List<BillBLL>)ViewState["Fees"];

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

                        //DateIssue (-)
                        //DateTime
                        //String strDateIssue = ((TextBox)grvFees.FooterRow.FindControl("txtDateIssueInsert")).Text;
                        //var datDateIssue = DateTime.ParseExact(strDateIssue, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        //newBill.DateIssue = new DateTime(datDateIssue.Day + datDateIssue.Month + datDateIssue.Year).Date;
                        //String
                        String strDateIssue = ((TextBox)grvFees.FooterRow.FindControl("txtDateIssueInsert")).Text;
                        newBill.DateIssue = strDateIssue;
                        //MessageBox.Show("DateIssue, UI: " + strDateIssue);


                        //ExpiringDate (-)
                        //DateTime
                        //String strExpiringDate = ((TextBox)grvFees.FooterRow.FindControl("txtExpiringDateInsert")).Text;
                        //var datExpiringDate = DateTime.ParseExact(strExpiringDate, "dd/MM/yyyy", CultureInfo.InstalledUICulture);
                        //newBill.ExpiringDate = datExpiringDate.Date;
                        //String
                        String strExpiringDate = ((TextBox)grvFees.FooterRow.FindControl("txtExpiringDateInsert")).Text;
                        newBill.ExpiringDate = strExpiringDate;
                        //MessageBox.Show("ExpiringDate, UI: " + strExpiringDate);


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
                            if (newBill.Create(FolderID))
                            {
                                Fees.Add(newBill);

                                FillGridView();
                            }
                            else
                            {
                                DisplayEmptyGridView();
                            }
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
            else if (e.CommandName == "btnUpdate")
            {
                try
                {
                    //MessageBox.Show("Update");

                    BillBLL updateBill = new BillBLL();

                    String strNumber = ((TextBox)grvFees.Rows[grvFees.EditIndex].FindControl("txtNumberUpdate")).Text;
                    int intNumber = int.Parse(strNumber);
                    updateBill.Number = intNumber;

                    var rowIndex = Convert.ToInt32(e.CommandArgument);

                    String strDateIssue = ((TextBox)grvFees.Rows[grvFees.EditIndex].FindControl("txtDateIssueUpdate")).Text;
                    updateBill.DateIssue = strDateIssue;
                    Fees[rowIndex].DateIssue = strDateIssue;

                    String strExpiringDate = ((TextBox)grvFees.Rows[grvFees.EditIndex].FindControl("txtExpiringDateUpdate")).Text;
                    updateBill.ExpiringDate = strExpiringDate;
                    Fees[rowIndex].ExpiringDate = strExpiringDate;


                    String strTotalPay = ((TextBox)grvFees.Rows[grvFees.EditIndex].FindControl("txtTotalPayUpdate")).Text;
                    int intTotalPay = int.Parse(strTotalPay);
                    updateBill.TotalPay = intTotalPay;
                    Fees[rowIndex].TotalPay = intTotalPay;

                    var ddlStatus = (DropDownList)grvFees.Rows[grvFees.EditIndex].FindControl("ddlStatusUpdate");
                    updateBill.Status = ddlStatus.SelectedValue;
                    Fees[rowIndex].Status = ddlStatus.SelectedValue;

                    updateBill.Document = new Byte[0];

                    updateBill.Folder = FolderID;

                    updateBill.Update();

                    grvFees.EditIndex = -1;

                    FillGridView();


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
            else if (e.CommandName == "btnDelete")
            {
                BillBLL deleteBill = new BillBLL();

                var index = Convert.ToInt32(e.CommandArgument);

                String strNumber = ((Label)grvFees.Rows[index].FindControl("lblNumberDelete")).Text;
                int intNumber = int.Parse(strNumber);

                deleteBill.Number = intNumber;

                Fees.RemoveAt(index);

                deleteBill.Delete();

                FillGridView();

                if (Fees.Count == 0)
                {
                    DisplayEmptyGridView();
                }



            }
            else if (e.CommandName == "btnEdit")
            {
                int rowIndex = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex;
                grvFees.EditIndex = rowIndex;

                FillGridView();
            }
            else if (e.CommandName == "btnCancel")
            {
                grvFees.EditIndex = -1;

                FillGridView();
            }
            else if (e.CommandName == "btnView")
            {
                //MessageBox.Show("View");
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