using System;
using System.Collections.Generic;
using System.Data;
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
        private DateTime _DateIssue;
        private DateTime _ExpiringDate;
        private int _TotalPay;
        //private Boolean _Status;
        private String _Status;
        private Byte[] _Document;
        private String _Folder;
        private List<BillBLL> _Bills;

        public BillBLL()
        {
            Bills = new List<BillBLL>();
        }

        public int Number
        {
            get { return _Number; }
            set { _Number = value; }
        }

        public DateTime DateIssue
        {
            get { return _DateIssue; }
            set { _DateIssue = value; }
        }

        public DateTime ExpiringDate
        {
            get { return _ExpiringDate; }
            set { _ExpiringDate = value; }
        }

        public int TotalPay
        {
            get { return _TotalPay; }
            set { _TotalPay = value; }
        }

        //public Boolean Status
        //{
        //    get { return _Status; }
        //    set { _Status = value; }
        //}

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

        public List<BillBLL> Bills
        {
            get { return _Bills; }
            set { _Bills = value; }
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

        public void RetrieveBills(String folderID)
        {
            try
            {
                using (DBEntities context = new DBEntities())
                {
                    //MessageBox.Show("FolderID, Bill BLL(1):" + folderID);

                    var billDAL = context.Bill.Select((bill =>
                        new { bill.Number, bill.DateIssue, bill.ExpiringDate, bill.TotalPay, bill.Status, bill.Image, bill.Folder })).ToList();


                    for (int i = 0; i < billDAL.Count(); i++)
                    {
                        if (billDAL.ElementAt(i).Folder.Trim().Equals(folderID.Trim()))
                        {
                            //MessageBox.Show(billDAL.ElementAt(i).Folder);

                            var billBLL = new BillBLL();

                            billBLL.Number = billDAL.ElementAt(i).Number;
                            billBLL.DateIssue = billDAL.ElementAt(i).DateIssue;
                            billBLL.ExpiringDate = billDAL.ElementAt(i).ExpiringDate;
                            billBLL.TotalPay = billDAL.ElementAt(i).TotalPay;
                            //billBLL.Status = billDAL.ElementAt(i).Status;
                            billBLL.Document = billDAL.ElementAt(i).Image;
                            billBLL.Folder = billDAL.ElementAt(i).Folder;

                            Bills.Add(billBLL);

                        }
                    }
                }

            }

            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

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
                    billDAL.DateIssue = DateIssue;
                    billDAL.ExpiringDate = ExpiringDate;
                    billDAL.TotalPay = TotalPay;
                    //billDAL.Status = Status;
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

        public Boolean Update()
        {
            try
            {
                using (DBEntities context = new DBEntities())
                {
                    var billDAL = context.Bill.FirstOrDefault(bill => bill.Number == Number);


                    if (billDAL != null)
                    {
                        billDAL.Number = Number;
                        billDAL.DateIssue = DateIssue;
                        billDAL.ExpiringDate = ExpiringDate;
                        billDAL.TotalPay = TotalPay;
                        //billDAL.Status = Status;
                        billDAL.Image = Document;
                        billDAL.Folder = Folder;

                        context.SaveChanges();
                    }

                    return true;
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

    }
}
