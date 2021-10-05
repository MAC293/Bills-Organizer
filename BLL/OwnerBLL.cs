using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;

namespace BLL
{
    public class OwnerBLL
    {
        private int _ID;
        private String _Name;
        private String _Password;
        private String _DisplayName;

        public OwnerBLL()
        {

        }

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        public String Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        public String Password
        {
            get { return _Password; }
            set { _Password = value; }
        }

        public String DisplayName
        {
            get { return _DisplayName; }
            set { _DisplayName = value; }
        }


        public Boolean Create()
        {
            try
            {
                using (DBEntities context = new DBEntities())
                {
                    Owner newOwner = new Owner();

                    if (IsEmpty())
                    {
                        newOwner.ID = 1;
                    }
                    else
                    {
                        newOwner.ID = LastOwner() + 1;
                    }

                    newOwner.Name = Name;
                    newOwner.Password = Password;
                    newOwner.DisplayName = DisplayName;

                    context.Owner.AddObject(newOwner);

                    context.SaveChanges();

                    return true;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Exception: " + ex.Message);
            }

            return false;
        }

        public Boolean IsEmpty()
        {
            try
            {
                using (DBEntities context = new DBEntities())
                {
                    //if (context.Detalles.Any()
                    if (!context.Owner.Any())
                    {
                        return true;
                    }
                }

            }

            catch (Exception ex)
            {

                MessageBox.Show("Exception: " + ex.InnerException);
            }

            return false;
        }

        public int LastOwner()
        {
            int last = 0;

            try
            {
                using (DBEntities context = new DBEntities())
                {
                    last = context.Owner.Max(latest => latest.ID);
                }
            }

            catch (Exception ex)
            {

                MessageBox.Show("Exception_ " + ex.Message);
            }

            return last;
        }

        //public Boolean Connecting()
        //{
        //    try
        //    {
        //        using (DBEntities context = new DBEntities())
        //        {

        //            var ownerDAL = context.Owner.FirstOrDefault(owner => owner.ID == "");

        //            if (ownerDAL == null)
        //            {
        //                ownerDAL = new DAL.Owner();

        //                ownerDAL.ID = "Test";
        //                ownerDAL.Name = "Test";
        //                ownerDAL.Password = "Test";
        //                ownerDAL.DisplayName = "Test";

        //                context.Owner.AddObject(ownerDAL);

        //                context.SaveChanges();
        //            }

        //            if (ownerDAL.ID == "Test")
        //            {
        //                return true;
        //            }

        //            return false;

        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        MessageBox.Show("Exception: " + ex.InnerException);
        //    }

        //    return false;
        //}




    }
}
