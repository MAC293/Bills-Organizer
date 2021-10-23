using System;
using System.Collections.Generic;
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
        private Boolean _Status;
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

        public Boolean Status
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
                        //MessageBox.Show("Folder: "+billDAL.ElementAt(i).Folder+" Position: "+i);
                        //MessageBox.Show("FolderID, Bill BLL(2): " + folderID);

                        String folder = billDAL.ElementAt(i).Folder;

                        //MessageBox.Show("String folder = billDAL.ElementAt(i).Folder " +billDAL.ElementAt(i).Folder);

                        //if (folder.Trim().Equals(folderID.Trim()))
                        //{
                        if (billDAL.ElementAt(i).Folder.Trim().Equals(folderID.Trim()))
                        {
                            //MessageBox.Show(billDAL.ElementAt(i).Folder);

                            var billBLL = new BillBLL();

                            billBLL.Number = billDAL.ElementAt(i).Number;
                            billBLL.DateIssue = billDAL.ElementAt(i).DateIssue;
                            billBLL.ExpiringDate = billDAL.ElementAt(i).ExpiringDate;
                            billBLL.TotalPay = billDAL.ElementAt(i).TotalPay;
                            billBLL.Status = billDAL.ElementAt(i).Status;
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

        public Boolean RetrieveBills_2(String folderID)
        {
            try
            {
                using (DBEntities context = new DBEntities())
                {
                    //MessageBox.Show("FolderID, Bill BLL "+folderID);

                    var billDAL = context.Bill.Select((bill =>
                        new
                            {   bill.Number,
                                bill.DateIssue,
                                bill.ExpiringDate,
                                bill.TotalPay,
                                bill.Status,
                                bill.Image,
                                bill.Folder }
                        )).ToList();


                    foreach (var fee in billDAL)
                    {
                        if (fee.Folder == folderID)
                        {
                            var billBLL = new BillBLL();

                            billBLL.Number = fee.Number;
                            billBLL.DateIssue = fee.DateIssue;
                            billBLL.ExpiringDate = fee.ExpiringDate;
                            billBLL.TotalPay = fee.TotalPay;
                            billBLL.Status = fee.Status;
                            billBLL.Document = fee.Image;
                            billBLL.Folder = fee.Folder;

                            Bills.Add(billBLL);
                        }
                    }

                }

            }

            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            return true;
        }

    }
}
