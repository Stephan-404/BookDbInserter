using System;
using System.Collections.Generic;

#nullable disable

namespace BookDbLib
{
    public partial class Book
    {
        public long Isbn { get; set; }
        public string Titel { get; set; }
        public int AuthorId { get; set; }
        public int? VerlagId { get; set; }
        public int Pages { get; set; }
        public string PurchaseDate { get; set; }
        public decimal Price { get; set; }
        public int Rating { get; set; }
        public int OwnerId { get; set; }
        public int PlaceId { get; set; }
        public int LanguageId { get; set; }
        public decimal? Weight { get; set; }
        public decimal? Width { get; set; }
        public decimal? Lenght { get; set; }
        public decimal? Height { get; set; }

        public virtual Author Author { get; set; }
        public virtual Language Language { get; set; }
        public virtual Owner Owner { get; set; }
        public virtual Place Place { get; set; }
        public virtual PublishingCompany Verlag { get; set; }


        public override string ToString()
        {
            return $"{Isbn}   {Titel} {Author} {Verlag} {Pages} {PurchaseDate} {Price} {Rating} {Owner }{Place} |{Language}|  {Weight}kg  {Width}x{Lenght}x{Height}";
        }
    }
}
