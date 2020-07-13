using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace congNghePhanMem.common
{
    [Serializable]
    public class userLogin
    {
        public int userID { get; set; }
        public string userName { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string positon { get; set; }
        public string address { get; set; }
        public string department { get; set; }
        public int? salary { get; set; }
        public int? numProject { get; set; }
        public string birthday { get; set; }
        public int? gender { get; set; }
    }

    public class userSelected
    {
        public int Id { get; set; }
        public string name { get; set; }
        public bool Selected { get; set; }
    }
}