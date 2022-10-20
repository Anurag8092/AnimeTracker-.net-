using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Books.Models
{
    public partial class ReadingStatus
    {
        public int StatusId { get; set; }
        public int? UserId { get; set; }
        public int? BookId { get; set; }
        public string Status { get; set; }
        public int? Rating { get; set; }

        public virtual Book Book { get; set; }
        public virtual Users User { get; set; }
    }
}
