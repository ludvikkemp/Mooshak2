using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mooshak2.Models.ViewModels
{
	public class MilestoneViewModel
	{
		public int ID { get; set; }
		public int AssignmentID { get; set; }
        [Required(ErrorMessage = "Title is required!")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Percentage is required!")]
        public double Percentage { get; set; }
		public double Grade { get; set; }
        public int SubmissionLimit { get; set; }
        [Required(ErrorMessage = "Input is required!")]
        public string MilestoneInput1 { get; set; }
        [Required(ErrorMessage = "Expected output is required!")]
        public string MilestoneOutput1 { get; set; }
        public string AssignmentDescriptionFileName { get; set; }
    }
}