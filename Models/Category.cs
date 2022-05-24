using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace KathiresuCaven_ProjetSession.Models
{
    public partial class Category
    {
        public Category()
        {
            Question = new HashSet<Question>();
        }

        public int CategoryId { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Question> Question { get; set; }
    }
}
