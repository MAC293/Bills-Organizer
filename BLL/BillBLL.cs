using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;

namespace BLL
{
    [Serializable]
    public class BillBLL
    {
        private int _Number;
        private String _DateIssue;
        private String _ExpiringDate;
        private int _TotalPay;
        private String _Status;
        private Byte[] _Document;
        private String _Folder;

        private String _IsDocument;
        //private List<BillBLL> _Bills;

        public BillBLL()
        {
            //Bills = new List<BillBLL>();
        }

        public int Number
        {
            get { return _Number; }
            set { _Number = value; }
        }

        public String DateIssue
        {
            get { return _DateIssue; }
            set { _DateIssue = value; }
        }

        public String ExpiringDate
        {
            get { return _ExpiringDate; }
            set { _ExpiringDate = value; }
        }

        public int TotalPay
        {
            get { return _TotalPay; }
            set { _TotalPay = value; }
        }

        public String Status
        {
            get { return _Status; }
            set { _Status = value; }
        }

        public Byte[] Document
        {
            get { return _Document; }
            set { _Document = value; }
        }

        public String Folder
        {
            get { return _Folder; }
            set { _Folder = value; }
        }

        public String IsDocument
        {
            get { return _IsDocument; }
            set { _IsDocument = value; }
        }

        public Boolean BillsExistence(String folderID)
        {
            try
            {
                using (DBEntities context = new DBEntities())
                {
                    var billDAL = context.Bill.FirstOrDefault(bill => bill.Folder == folderID);

                    if (billDAL != null)
                    {
                        return true;
                    }

                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception: " + ex);
            }

            return false;
        }

        public void RetrieveBills(String folderID, List<BillBLL> bills)
        {
            try
            {
                using (DBEntities context = new DBEntities())
                {
                    //MessageBox.Show("FolderID, Bill BLL(1):" + folderID);

                    var billDAL = context.Bill.Select((bill =>
                        new
                        {
                            bill.Number, bill.DateIssue, bill.ExpiringDate, bill.TotalPay, bill.Status,
                            bill.Folder
                        })).ToList();


                    for (int i = 0; i < billDAL.Count(); i++)
                    {
                        if (billDAL.ElementAt(i).Folder.Trim().Equals(folderID.Trim()))
                        {
                            //MessageBox.Show(billDAL.ElementAt(i).Folder);

                            var billBLL = new BillBLL();

                            billBLL.Number = billDAL.ElementAt(i).Number;
                            billBLL.DateIssue = DateToStr(billDAL.ElementAt(i).DateIssue);
                            billBLL.ExpiringDate = DateToStr(billDAL.ElementAt(i).ExpiringDate);
                            billBLL.TotalPay = billDAL.ElementAt(i).TotalPay;
                            billBLL.Status = BoolToString(billDAL.ElementAt(i).Status);
                            billBLL.IsDocument = CheckImage(billBLL.Number);
                            //billBLL.Document = billDAL.ElementAt(i).Image;
                            billBLL.Folder = billDAL.ElementAt(i).Folder;

                            //MessageBox.Show("RetrieveBills, BLL " + billBLL.Number.ToString());

                            bills.Add(billBLL);
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public String CheckImage(int number)
        {
            try
            {
                using (DBEntities context = new DBEntities())
                {
                    var billDAL = context.Bill.FirstOrDefault(bill => bill.Number == number);

                    if (billDAL != null)
                    {
                        if (billDAL.Image != null)
                        {
                            return "There's a bill";
                        }

                        return "There's no bill";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception: " + ex);
            }

            return String.Empty;
        }


        public Boolean Create(String folderID)
        {
            using (DBEntities context = new DBEntities())
            {
                var billDAL = context.Bill.FirstOrDefault(bill => bill.Number == Number);

                if (billDAL == null)
                {
                    billDAL = new Bill();

                    billDAL.Number = Number;
                    billDAL.DateIssue = StrToDate(DateIssue);
                    billDAL.ExpiringDate = StrToDate(ExpiringDate);
                    billDAL.TotalPay = TotalPay;
                    billDAL.Status = StringToBool();
                    billDAL.Image = Document;
                    billDAL.Folder = Folder;

                    context.Bill.AddObject(billDAL);

                    context.SaveChanges();

                    return true;
                }
                else
                {
                    MessageBox.Show("This Bill already exists!");
                }

                return false;
            }
        }

        public Boolean StringToBool()
        {
            bool outputStatus = Status.Equals("Paid");

            return outputStatus;
        }

        public String BoolToString(Boolean inStatus)
        {
            String outStatus = "Unpaid";

            if (inStatus == true)
            {
                outStatus = "Paid";
            }

            return outStatus;
        }

        public int BillsQuatity(String folderID)
        {
            int quantity = 0;

            try
            {
                using (DBEntities context = new DBEntities())
                {
                    var billDAL = context.Bill.Select((bill =>
                        new {bill.Folder})).ToList();


                    for (int i = 0; i < billDAL.Count(); i++)
                    {
                        if (billDAL.ElementAt(i).Folder.Trim().Equals(folderID.Trim()))
                        {
                            quantity++;
                        }
                    }

                    MessageBox.Show("BillsQuatity, BLL: " + quantity);
                    return quantity;
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Exception (A, BLL): " + ex);
            }

            return 0;
        }

        public Boolean Update()
        {
            try
            {
                using (DBEntities context = new DBEntities())
                {
                    var billDAL = context.Bill.FirstOrDefault(bill => bill.Number == Number);


                    if (billDAL != null)
                    {
                        billDAL.DateIssue = StrToDate(DateIssue);
                        ;
                        billDAL.ExpiringDate = StrToDate(ExpiringDate);
                        billDAL.TotalPay = TotalPay;
                        billDAL.Status = StringToBool();
                        billDAL.Image = Document;
                        billDAL.Folder = Folder;

                        context.SaveChanges();

                        return true;
                    }

                    return false;
                }
            }
            catch (DataException ex)
            {
                MessageBox.Show("DataException: " + ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show("InvalidOperationException: " + ex.Message);
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show("NullReferenceException: " + ex.Message);
            }

            return false;
        }

        public Boolean Delete()
        {
            try
            {
                using (DBEntities context = new DBEntities())
                {
                    var billDAL = context.Bill.FirstOrDefault(bill => bill.Number == Number);

                    context.DeleteObject(billDAL);

                    context.SaveChanges();

                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception: " + ex.Message);

                return false;
            }
        }

        public DateTime StrToDate(String date)
        {
            var datDateIssue = DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            return datDateIssue;
        }

        public String DateToStr(DateTime date)
        {
            return date.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
        }
    }
}