using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace congNghePhanMem.common
{
    [Serializable]
    public static class staffCheck
    {
        public static int id { get; set; }
        public static int idRegister { get; set; }
        public static DateTime dateCheck { get; set; }
        public static int numCheck { get; set; }
    }

    public class updateStaff
    {
        public int Id { get; set; }
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Ban chua dien truong nay !")]
        public string Name { get; set; }
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Ban chua dien truong nay !")]
        public string Email { get; set; }
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Ban chua dien truong nay !")]
        public string Password { get; set; }
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Ban chua dien truong nay !")]
        public string Phone { get; set; }
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Ban chua dien truong nay !")]
        public string Address { get; set; }
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Ban chua dien truong nay !")]
        public int? Gender { get; set; }
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Ban chua dien truong nay !")]
        public string Birthday { get; set; }
    }
}