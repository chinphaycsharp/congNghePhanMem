namespace congNghePhanMem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("congnghephanmem.employee_account")]
    public partial class employee_account
    {
        public int Id { get; set; }

        public int? idDepartcode { get; set; }

        public int? idRegister { get; set; }
    }
}
