using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class Folder
    {
        private String _ID;
        private String _Name;
        private String _Owner;

        public Folder()
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

        public String Owner
        {
            get { return _Owner; }
            set { _Owner = value; }
        }



    }
}
