using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Books.Models
{
    public partial class Book
    {
        public Book()
        {
            ReadingStatus = new HashSet<ReadingStatus>();
        }

        public int BookId { get; set; }
        public string BookName { get; set; }
        public string AuthorName { get; set; }
        public string Description { get; set; }
        public decimal? Rating { get; set; }
        public string BookImage { get; set; }
        public string Genre { get; set; }

        public virtual ICollection<ReadingStatus> ReadingStatus { get; set; }
    }
}
