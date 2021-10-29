﻿using System;
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

                Bill = new BillBLL();
                ViewState["Bills"] = Bill.Bills;
                //ViewState["Bill"] = Bill;

                if (Bill.BillsExistence(FolderID))
                {
                    //MessageBox.Show("Bill.BillsExistence is TRUE"); 
                    Bill.RetrieveBills(FolderID);

                    

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
            else
            {
                Bill.Bills = (List<BillBLL>)ViewState["Bills"];
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
                        Bill = new BillBLL();

                        //if (Bill.Bills != null)
                        //{
                        //    MessageBox.Show("Bill.Bills != null");
                        //}

                        //Number
                        String strNumber = ((TextBox)grvFees.FooterRow.FindControl("txtNumberInsert")).Text;
                        int intNumber = int.Parse(strNumber);
                        Bill.Number = intNumber;

                        //DateIssue
                        String strDateIssue = ((TextBox)grvFees.FooterRow.FindControl("txtDateIssueInsert")).Text;
                        DateTime datDateIssue = DateTime.Parse(strDateIssue);
                        Bill.DateIssue = datDateIssue;

                        //ExpiringDate
                        String strExpiringDate = ((TextBox)grvFees.FooterRow.FindControl("txtExpiringDateInsert")).Text;
                        DateTime datExpiringDate = DateTime.Parse(strExpiringDate);
                        Bill.ExpiringDate = datExpiringDate;

                        //TotalPay
                        String strTotalPay = ((TextBox)grvFees.FooterRow.FindControl("txtTotalPayInsert")).Text;
                        int intTotalPay = int.Parse(strTotalPay);
                        Bill.TotalPay = intTotalPay;

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

                            Bill.Status = "Paid";

                        }
                        else if (status == "Unpaid")
                        {
                            //status = "False";

                            //Boolean unpaid = Boolean.Parse(status);
                            //Bill.Status = unpaid;

                            //ViewState["ddlStatusInsert"] = ddlStatus.SelectedValue;
                            //IsChanged = false;
                            //ViewState["IsChanged"] = IsChanged;

                            Bill.Status = "Unpaid";
                        }

                        Bill.Document = new Byte[0];

                        FolderID = (String)Session["FolderID"];



                        if (Bill.Bills != null)
                        {
                            Bill.Bills.Add(Bill);
                        }

                        ViewState["Bills"] = Bill.Bills;


                        if (Bill.Bills.Count > 0)
                        {
                            FillGridView();
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
            //grvFees.DataSource = Bill.Bills;
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