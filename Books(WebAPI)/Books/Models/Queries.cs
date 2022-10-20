using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Books.Models
{
    public partial class Queries
    {
        public Queries()
        {
            Answers = new HashSet<Answers>();
        }

        public int QueryId { get; set; }
        public string Query { get; set; }
        public string Date { get; set; }
        public int? UserId { get; set; }
        public string Fullname { get; set; }
        public string ProfileImage { get; set; }

        public virtual Users User { get; set; }
        public virtual ICollection<Answers> Answers { get; set; }
    }
}
