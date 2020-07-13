namespace congNghePhanMem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("congnghephanmem.register")]
    public partial class register
    {
        public int Id { get; set; }

        [StringLength(45)]
        [Required(ErrorMessage ="Bạn chưa nhập trường này")]
        public string name { get; set; }

        [StringLength(45)]
        [Required(ErrorMessage = "Bạn chưa nhập trường này")]
        public string userName { get; set; }

        [StringLength(45)]
        [Required(ErrorMessage = "Bạn chưa nhập trường này")]
        public string email { get; set; }

        [StringLength(45)]
        [Required(ErrorMessage = "Bạn chưa nhập trường này")]
        public string passWord { get; set; }

        [StringLength(45)]
        [Required(ErrorMessage = "Bạn chưa nhập trường này")]
        public string phone { get; set; }

        [StringLength(45)]
        [Required(ErrorMessage = "Bạn chưa nhập trường này")]
        public string address { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập trường này")]
        public int? permision { get; set; }

        [Column(TypeName = "bit")]
        [Required(ErrorMessage = "Bạn chưa nhập trường này")]
        public bool? status { get; set; }

        [StringLength(45)]
        [Required(ErrorMessage = "Bạn chưa nhập trường này")]
        public string position { get; set; }

        [StringLength(45)]
        [Required(ErrorMessage = "Bạn chưa nhập trường này")]
        public string department { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập trường này")]
        public int? salary { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập trường này")]
        public int? numProject { get; set; }
        [Required(ErrorMessage = "Bạn chưa nhập trường này")]
        public int? gender { get; set; }

        [StringLength(45)]
        [Required(ErrorMessage = "Bạn chưa nhập trường này")]
        public string birthday { get; set; }
    }
}
