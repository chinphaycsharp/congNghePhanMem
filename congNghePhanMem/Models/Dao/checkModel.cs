using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace congNghePhanMem.Models.Dao
{
    public class checkModel
    {
        public int id { get; set; }
        public int idRegister { get; set; }
        public DateTime dateCheck { get; set; }
        public int numCheck { get; set; }
    }
}