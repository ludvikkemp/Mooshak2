using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mooshak2.Models.ViewModels
{
    public class SubmissionViewModel
    {
        public int ID { get; set; }
        public int MilestoneID { get; set; }
        public string MilestoneTitle { get; set; }
        public string UserID { get; set; }
        public string UserName { get; set; }
        [Required(ErrorMessage = "Submission file is required!")]
        public HttpPostedFileBase SubmissionFile { get; set; }
        public string SubmissionFileName { get; set; }
        public string SubmissionPath { get; set; }
        public string Input { set; get; }
        public string Output { set; get; }
        public string Status { set; get; }
    }
}