using System;
using System.Collections.Generic;
using System.Globalization;
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

                    Folder water = new Folder();
                    water.ID = "WTR" + owner;
                    water.Name = "Water";
                    water.Owner = owner;

                    Folder gas = new Folder();
                    gas.ID = "GS" + owner;
                    gas.Name = "Gas";
                    gas.Owner = owner;

                    Folder cable = new Folder();
                    cable.ID = "CBE" + owner;
                    cable.Name = "Cable";
                    cable.Owner = owner;

                    Folder electricity = new Folder();
                    electricity.ID = "ETY" + owner;
                    electricity.Name = "Electricity";
                    electricity.Owner = owner;

                    Folder mobilePhone = new Folder();
                    mobilePhone.ID = "MP" + owner;
                    mobilePhone.Name = "Mobile Phone";
                    mobilePhone.Owner = owner;

                    context.Folder.AddObject(water);
                    context.Folder.AddObject(gas);
                    context.Folder.AddObject(cable);
                    context.Folder.AddObject(electricity);
                    context.Folder.AddObject(mobilePhone);

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

        //public int FolderOWner(int user)
        //{
        //    int folderOwner = 0;

        //    try
        //    {
        //        using (DBEntities context = new DBEntities())
        //        {
        //            var folderDAL = context.Folder.FirstOrDefault(folder => folder.Owner == user);

        //            if (folderDAL != null)
        //            {
        //                folderOwner = user;
        //            }
                    
        //            return folderOwner;
        //        }

        //    }
        //    catch (Exception ex)
        //    {

        //        MessageBox.Show("Exception: " + ex);
        //    }

        //    return 0;
        //}

        public String FolderID(String folderName, int folderOwner)
        {
            String id = String.Empty;

            try
            {
                using (DBEntities context = new DBEntities())
                {
                    var folderDAL = context.Folder.FirstOrDefault(folder => folder.Name == folderName && 
                                                                            folder.Owner == folderOwner);

                    if (folderDAL != null)
                    {
                        switch (folderName)
                        {
                            case "Cable":
                                id = "CBE" + folderOwner;
                                break;

                            case "Water":
                                id = "WTR" + folderOwner;
                                break;

                            case "Gas":
                                id = "GS" + folderOwner;
                                break;

                            case "Electricity":
                                id = "ETY" + folderOwner;
                                break;

                            case "Mobile Phone":
                                id = "MP" + folderOwner;
                                break;
                        }

                        return id;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception: " + ex);

            }

            return String.Empty;
        }




    }
}
