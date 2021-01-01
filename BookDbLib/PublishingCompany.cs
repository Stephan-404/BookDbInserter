using System;
using System.Collections.Generic;

#nullable disable

namespace BookDbLib
{
    public partial class PublishingCompany
    {
        public PublishingCompany()
        {
            Books = new HashSet<Book>();
        }

        public int CompanyId { get; set; }
        public string CompanyName { get; set; }

        public virtual ICollection<Book> Books { get; set; }


        public override string ToString()
        {
            return CompanyName;
        }
    }
}
