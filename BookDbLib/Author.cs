﻿using System;
using System.Collections.Generic;

#nullable disable

namespace BookDbLib
{
    public partial class Author
    {
        public Author()
        {
            Books = new HashSet<Book>();
        }

        public int AuthorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<Book> Books { get; set; }
        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }

        

    }
}
