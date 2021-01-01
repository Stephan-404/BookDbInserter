using System;
using System.Collections.Generic;

#nullable disable

namespace BookDbLib
{
    public partial class Place
    {
        public Place()
        {
            Books = new HashSet<Book>();
        }

        public int PlaceId { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }

        public virtual ICollection<Book> Books { get; set; }


        public override string ToString()
        {
            return $"{Address}{Country}";
        }
    }
}
