using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace congNghePhanMem.common
{
    public class eployeeProject
    {
        public string Name { get; set; }
        public string Position { get; set; }
        public string Department { get; set; }
        public string ProjectName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}