using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class BillBLL
    {
        private int _Number;
        private DateTime _DateIssue;
        private DateTime _ExpiringDate;
        private int _TotalPay;
        private Boolean _Status;
        private Byte[] _Document;
        private int _Folder;

        public BillBLL()
        {
            
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

        public int Folder
        {
            get { return _Folder; }
            set { _Folder = value; }
        }








    }
}
