using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;

namespace BLL
{
    public static class Helper
    {
        public static String RetrieveStatus(int billNumber)
        {
            try
            {
                using (DBEntities context = new DBEntities())
                {
                    var billDAL = context.Bill.FirstOrDefault(bill => bill.Number == billNumber);


                    if (billDAL != null && billDAL.Status == true)
                    {
                        return "Paid";
                    }
                    else if (billDAL != null && billDAL.Status == false)
                    {
                        return "Unpaid";
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return String.Empty;
        }
    }
}