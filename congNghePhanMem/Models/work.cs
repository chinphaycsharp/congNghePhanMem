namespace congNghePhanMem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("congnghephanmem.work")]
    public partial class work
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập trường này")]
        public DateTime? dateWork { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập trường này")]
        public DateTime? dateFinsinh { get; set; }

        [StringLength(45)]
        [Required(ErrorMessage = "Bạn chưa nhập trường này")]
        public string Leader { get; set; }

        [StringLength(45)]
        [Required(ErrorMessage = "Bạn chưa nhập trường này")]
        public string numJoin { get; set; }

        [StringLength(45)]
        [Required(ErrorMessage = "Bạn chưa nhập trường này")]
        public string nameProject { get; set; }
    }
}
