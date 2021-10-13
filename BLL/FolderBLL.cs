using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;

namespace BLL
{
    public class FolderBLL
    {
        private String _ID;
        private String _Name;
        private int _Owner;

        public FolderBLL()
        {
            
        }

        public String ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        public String Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        public int Owner
        {
            get { return _Owner; }
            set { _Owner = value; }
        }

        public Boolean Create(int owner)
        {
            try
            {
                using (DBEntities context = new DBEntities())
                {
                    if (!CheckUser(owner))
                    {
                        
                    }


                    FolderBLL water = new FolderBLL();
                    water.ID = "WTR0";
                    water.Name = "Water";

                    FolderBLL gas = new FolderBLL();
                    gas.ID = "GS1";
                    gas.Name = "Gas";

                    FolderBLL cable = new FolderBLL();
                    cable.ID = "CBE2";
                    cable.Name = "Cable";

                    FolderBLL electricity = new FolderBLL();
                    electricity.ID = "ETY3";
                    electricity.Name = "Electricity";

                    FolderBLL mobilePhone = new FolderBLL();
                    mobilePhone.ID = "MP4";
                    mobilePhone.Name = "Mobile Phone";



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

        public Boolean CheckUser(int user)
        {
            try
            {
                using (DBEntities context = new DBEntities())
                {
                    var folderDAL = context.Folder.FirstOrDefault(folder => folder.Owner == user);

                    if (folderDAL != null)
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



    }
}
