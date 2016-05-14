using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoBase.Model
{
    public class Book: Entity
    {
        private string nameRED;
        public virtual string NameRED
        {
            get { return nameRED; }
            set { nameRED = value; }
        }
        private string tel;
        public virtual string Tel
        {
            get { return tel; }
            set { tel = value; }
        }
        private string indexBase;
        public virtual string IndexBase
        {
            get { return indexBase; }
            set { indexBase = value; }
        }
        private string jornal;
        public virtual string Jornal
        {
            get { return jornal; }
            set { jornal = value; }
        }
    }
}
