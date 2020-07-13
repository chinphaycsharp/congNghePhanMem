namespace congNghePhanMem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("congnghephanmem.check")]
    public partial class check
    {
        public int Id { get; set; }

        public int? idRegister { get; set; }

        public DateTime? dateCheck { get; set; }

        public int? numCheck { get; set; }
    }
}
