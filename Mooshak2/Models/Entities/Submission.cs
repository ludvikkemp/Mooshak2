using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mooshak2.Models.Entities
{
    public class Submission
    {
        public int ID { get; set; }
        public int MilestoneID { get; set; }
        public string UserID { get; set; }
        public string SubmissionFileName { get; set; }
        public string SubmissionPath { get; set; }
        public string Input { set; get; }
        public string Output { set; get; }
        public bool Compiled { set; get; }
    }

}