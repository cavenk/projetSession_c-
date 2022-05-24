using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace KathiresuCaven_ProjetSession.Models
{
    public partial class Itemoption
    {
        public Itemoption()
        {
            Answer = new HashSet<Answer>();
        }

        public int OptionId { get; set; }
        public string Text { get; set; }
        public ulong IsRight { get; set; }
        public int? QuestionId { get; set; }

        public virtual Question Question { get; set; }
        public virtual ICollection<Answer> Answer { get; set; }
    }
}
