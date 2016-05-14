using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoBase.Model
{
    public class Article : Entity
    {
        private string author;
        public virtual string Author
        {
            get { return author; }
            set { author = value; }
        }
        private string email;
        public virtual string Email
        {
            get { return email; }
            set { email = value; }
        }
        private string temaArticle;
        public virtual string TemaArticle
        {
            get { return temaArticle; }
            set { temaArticle = value; }
        }
        
        private Book IdBook;
        public virtual Book idBook
        {
            get { return IdBook; }
            set { IdBook = value; }
        }

    }
}
