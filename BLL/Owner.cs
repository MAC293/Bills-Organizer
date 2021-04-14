using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class Owner
    {
        private String _ID;
        private String _Name;
        private String _Password;
        private String _DisplayName;

        public Owner()
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




    }
}
