using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace congNghePhanMem.common
{
    public class createProject
    {
        [Required(ErrorMessage ="Bạn chưa nhập trường này !")]
        public DateTime dateWork { get; set; }
        [Required(ErrorMessage = "Bạn chưa nhập trường này !")]
        public DateTime dateEnd { get; set; }
        [Required(ErrorMessage = "Bạn chưa nhập trường này !")]
        public string nameLeader { get; set; }
        [Required(ErrorMessage = "Bạn chưa nhập trường này !")]
        public string nameProject { get; set; }
        [Required(ErrorMessage = "Bạn chưa nhập trường này !")]
        public List<int> dsNv { get; set; }
    }

    public class updateProject
    {
        public int Id { get; set; }
        public DateTime? dateWork { get; set; }
        public DateTime? dateEnd { get; set; }
        public string nameLeader { get; set; }
        public string nameProject { get; set; }
        public string numjoin { get; set; }
        public List<int> dsNv { get; set; }
    }
}