namespace congNghePhanMem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("congnghephanmem.departcode")]
    public partial class departcode
    {
        public int Id { get; set; }

        [StringLength(45)]
        [Required(ErrorMessage = "Bạn chưa nhập trường này")]
        public string nameDepartment { get; set; }

        [StringLength(45)]
        [Required(ErrorMessage = "Bạn chưa nhập trường này")]
        public string nameEmployee { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập trường này")]
        public int? IdInformation { get; set; }

        [StringLength(20)]
        [Required(ErrorMessage = "Bạn chưa nhập trường này")]
        public string phone { get; set; }

        [StringLength(45)]
        [Required(ErrorMessage = "Bạn chưa nhập trường này")]
        public string position { get; set; }

        [StringLength(45)]
        [Required(ErrorMessage = "Bạn chưa nhập trường này")]
        public string userName { get; set; }
    }
}
