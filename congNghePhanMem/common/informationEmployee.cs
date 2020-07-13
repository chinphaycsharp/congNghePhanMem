using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace congNghePhanMem.common
{
    [Serializable]
    public class informationEmployee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime Birthday { get; set; }
        public double Salary { get; set; }
        public string Position { get; set; }
        public string Department { get; set; }
    }
}