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

        public Boolean LogIn()
        {
            try
            {
                using (DBEntities context = new DBEntities())
                {

                    var ownerLogInDAL = context.Owner.FirstOrDefault(owner => owner.Name == Name
                                                                              && owner.Password == Password);
                    //MessageBox.Show(ownerLogInDAL.Name);
                    //MessageBox.Show(ownerLogInDAL.Password);

                    if (ownerLogInDAL != null && PasswordComparison(Password.Trim(), ownerLogInDAL.Password.Trim()) &&
                        UsernameComparison(Name.Trim(), ownerLogInDAL.Name.Trim()))
                    {
                        if (ownerLogInDAL != null)
                        {
                            context.SaveChanges();

                            return true;
                        }
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

        public void SendDisplayName(String dName, String dPassword)
        {
            try
            {
                using (DBEntities context = new DBEntities())
                {
                    var ownerLogInDAL = context.Owner.FirstOrDefault(owner => owner.Name == dName
                                                                              && owner.Password == dPassword);

                    if (ownerLogInDAL != null)
                    {
                        DisplayName = ownerLogInDAL.DisplayName;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception: " + ex);
            }
        }

        public int SendID(String dName, String dPassword)
        {
            int id = 0;

            try
            {
                using (DBEntities context = new DBEntities())
                {
                    var ownerLogInDAL = context.Owner.FirstOrDefault(owner => owner.Name == dName
                                                                              && owner.Password == dPassword);

                    if (ownerLogInDAL != null)
                    {
                        id = ownerLogInDAL.ID;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception: " + ex);
            }

            return id;
        }


        private Boolean UsernameComparison(String input, String source)
        {
            if (String.Equals(input, source, StringComparison.CurrentCulture))
            {
                return true;
            }

            return false;
        }

        private Boolean PasswordComparison(String input, String source)
        {
            if (String.Equals(input, source, StringComparison.CurrentCulture))
            {
                return true;
            }

            return false;
        }
    }
}