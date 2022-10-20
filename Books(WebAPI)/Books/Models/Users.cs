using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Books.Models
{
    public partial class Users
    {
        public Users()
        {
            Answers = new HashSet<Answers>();
            Comments = new HashSet<Comments>();
            Queries = new HashSet<Queries>();
            ReadingStatus = new HashSet<ReadingStatus>();
        }

        public int UserId { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool? IsAdmin { get; set; }
        public string ProfileImage { get; set; }

        public virtual ICollection<Answers> Answers { get; set; }
        public virtual ICollection<Comments> Comments { get; set; }
        public virtual ICollection<Queries> Queries { get; set; }
        public virtual ICollection<ReadingStatus> ReadingStatus { get; set; }
    }
}
