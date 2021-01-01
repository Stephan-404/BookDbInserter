using System;
using System.Collections.Generic;

#nullable disable

namespace BookDbLib
{
    public partial class Language
    {
        public Language()
        {
            Books = new HashSet<Book>();
        }

        public int LanguageId { get; set; }
        public string LanguageName { get; set; }

        public virtual ICollection<Book> Books { get; set; }
        public override string ToString()
        {
            return LanguageName;
        }
    }
}
