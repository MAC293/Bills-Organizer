using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Configuration;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Windows.Forms;
using BLL;
using System.Threading;
using System.Threading.Tasks;
using Label = System.Web.UI.WebControls.Label;
using TextBox = System.Web.UI.WebControls.TextBox;
using View = System.Web.UI.WebControls.View;

namespace UI
{
    public partial class Bills : System.Web.UI.Page
    {
        private List<BillBLL> _Fees;
        private BillBLL _Bill;
        private String _FolderID;
        private Byte[] _Document;

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

        public Byte[] Document
        {
            get { return _Document; }
            set { _Document = value; }
        }

        //public Boolean IsChanged
        //{
        //    get { return _IsChanged; }
        //    set { _IsChanged = value; }
        //}
        protected void Page_Load(object sender, EventArgs e)
        {
            lblFolderName.Text = (String) Session["FolderName"];

            if (!IsPostBack)
            {
                //String folderID = (String)Session["FolderID"];
                FolderID = (String) Session["FolderID"];
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

                FolderID = (String) Session["FolderID"];

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

                        //Number
                        String strNumber = ((TextBox) grvFees.FooterRow.FindControl("txtNumberInsert")).Text;
                        int intNumber = int.Parse(strNumber);
                        newBill.Number = intNumber;

                        //DateIssue
                        String strDateIssue = ((TextBox) grvFees.FooterRow.FindControl("txtDateIssueInsert")).Text;
                        newBill.DateIssue = strDateIssue;

                        //ExpiringDate
                        String strExpiringDate =
                            ((TextBox) grvFees.FooterRow.FindControl("txtExpiringDateInsert")).Text;
                        newBill.ExpiringDate = strExpiringDate;

                        //TotalPay
                        String strTotalPay = ((TextBox) grvFees.FooterRow.FindControl("txtTotalPayInsert")).Text;
                        int intTotalPay = int.Parse(strTotalPay);
                        newBill.TotalPay = intTotalPay;

                        //Status
                        var ddlStatus = ((DropDownList) grvFees.FooterRow.FindControl("ddlStatusInsert"));
                        String status = ddlStatus.SelectedItem.Text; //ddlStatus.SelectedValue;

                        if (status == "Paid")
                        {
                            newBill.Status = "Paid";
                        }
                        else if (status == "Unpaid")
                        {
                            newBill.Status = "Unpaid";
                        }

                        Document = (Byte[]) ViewState["Document"];

                        if (Document == null)
                        {
                            //newBill.Document = new Byte[0];
                            newBill.Document = null;
                            newBill.IsDocument = "There's no bill";
                        }
                        else
                        {
                            newBill.Document = Document;
                            newBill.IsDocument = "There's a bill";
                        }

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

                    String strNumber = ((TextBox) grvFees.Rows[grvFees.EditIndex].FindControl("txtNumberUpdate")).Text;
                    int intNumber = int.Parse(strNumber);
                    updateBill.Number = intNumber;

                    var rowIndex = Convert.ToInt32(e.CommandArgument);

                    String strDateIssue = ((TextBox) grvFees.Rows[grvFees.EditIndex].FindControl("txtDateIssueUpdate"))
                        .Text;
                    updateBill.DateIssue = strDateIssue;
                    Fees[rowIndex].DateIssue = strDateIssue;

                    String strExpiringDate =
                        ((TextBox) grvFees.Rows[grvFees.EditIndex].FindControl("txtExpiringDateUpdate")).Text;
                    updateBill.ExpiringDate = strExpiringDate;
                    Fees[rowIndex].ExpiringDate = strExpiringDate;


                    String strTotalPay = ((TextBox) grvFees.Rows[grvFees.EditIndex].FindControl("txtTotalPayUpdate"))
                        .Text;
                    int intTotalPay = int.Parse(strTotalPay);
                    updateBill.TotalPay = intTotalPay;
                    Fees[rowIndex].TotalPay = intTotalPay;

                    var ddlStatus = (DropDownList) grvFees.Rows[grvFees.EditIndex].FindControl("ddlStatusUpdate");
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

                String strNumber = ((Label) grvFees.Rows[index].FindControl("lblNumberDelete")).Text;
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
                int rowIndex = ((GridViewRow) ((LinkButton) e.CommandSource).NamingContainer).RowIndex;
                grvFees.EditIndex = rowIndex;

                FillGridView();

                UnchangedStatus(rowIndex);
            }
            else if (e.CommandName == "btnCancel")
            {
                grvFees.EditIndex = -1;

                FillGridView();
            }
            else if (e.CommandName == "btnView")
            {
                //UnchangedStatus(e);
                //MessageBox.Show(index.ToString());
            }
            else if (e.CommandName == "btnUpload")
            {
                Thread t = new Thread((ThreadStart) (() =>
                {
                    OpenFileDialog openedFile = new OpenFileDialog();

                    openedFile.Filter = "Image Format(*.jpg; *.png;)|*.jpg; *.png;";
                    openedFile.Title = "Select your bill";

                    if (openedFile.ShowDialog() != DialogResult.OK)
                    {
                        return;
                    }
                    else
                    {
                        //var strDocument = ((TextBox) grvFees.FooterRow.FindControl("txtBillInsert"));
                        //strDocument.Text = openedFile.FileName;

                        byte[] buffer = File.ReadAllBytes(openedFile.FileName);
                        Document = buffer;
                        ViewState["Document"] = Document;
                    }
                }));

                t.SetApartmentState(ApartmentState.STA);
                t.Start();
                t.Join();
            }
            else if (e.CommandName == "btnUploadUpdate")
            {
                Thread t = new Thread((ThreadStart) (() =>
                {
                    OpenFileDialog openedFile = new OpenFileDialog();

                    openedFile.Filter = "Image Format(*.jpg; *.png;)|*.jpg; *.png;";
                    openedFile.Title = "Select a new bill to replace with";

                    if (openedFile.ShowDialog() != DialogResult.OK)
                    {
                        return;
                    }
                    else
                    {
                    }
                }));

                t.SetApartmentState(ApartmentState.STA);
                t.Start();
                t.Join();
            }
        }

        protected void UnchangedStatus(int e)
        {
            var index = Convert.ToInt32(e);

            //MessageBox.Show(index.ToString());

            var billNumber = ((TextBox) grvFees.Rows[index].FindControl("txtNumberUpdate"));

            //MessageBox.Show(strStatus.Text);

            int number = Int32.Parse(billNumber.Text);

            String status = Helper.RetrieveStatus(number);

            var ddl = ((DropDownList) grvFees.Rows[index].FindControl("ddlStatusUpdate"));

            if (status == "Paid" && ddl.SelectedValue == "Unpaid")
            {
                ddl.SelectedValue = status;
            }
        }

        protected void FillGridView()
        {
            //grvFees.DataSource = Bill.Bills;
            grvFees.DataSource = Fees;
            grvFees.DataBind();
        }

        protected void DisplayEmptyGridView()
        {
            grvFees.DataSource = new object[] {null};
            grvFees.DataBind();
        }
    }
}