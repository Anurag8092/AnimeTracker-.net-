using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Books.Models
{
    public partial class Comments
    {
        public int CommentId { get; set; }
        public int? AnswerId { get; set; }
        public string Comment { get; set; }
        public string Date { get; set; }
        public int? UserId { get; set; }

        public virtual Answers Answer { get; set; }
        public virtual Users User { get; set; }
    }
}
