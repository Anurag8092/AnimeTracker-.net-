using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Books.Models
{
    public partial class Answers
    {
        public Answers()
        {
            Comments = new HashSet<Comments>();
        }

        public int AnswerId { get; set; }
        public int? QueryId { get; set; }
        public string Answer { get; set; }
        public string Date { get; set; }
        public int? UserId { get; set; }

        public virtual Queries Query { get; set; }
        public virtual Users User { get; set; }
        public virtual ICollection<Comments> Comments { get; set; }
    }
}
