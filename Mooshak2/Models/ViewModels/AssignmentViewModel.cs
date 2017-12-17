using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mooshak2.Models.ViewModels
{
	public class AssignmentViewModel
	{
		public int ID { get; set; }
		public int CourseID { get; set; }
        [Required(ErrorMessage = "Title is required!")]
		public string Title { get; set; }
        [Required(ErrorMessage = "Close time is required!")]
        public DateTime DueDate { get; set; }
        [Required(ErrorMessage = "Open time is required!")]
        public DateTime Startdate { get; set; }
        public string Languages { get; set; }
        public int GroupSize { get; set; }
		public string CourseName { get; set; }
        [Required(ErrorMessage = "Milestone title is required!")]
        public string MilestoneTitle { get; set; }
        [Required(ErrorMessage = "Percentage is required!")]
        public double MilestonePercentage { get; set; }
        public int MilestoneSubmissionLimit { get; set; }
        [Required(ErrorMessage = "Input is required!")]
        public string MilestoneInput1 { get; set; }
        [Required(ErrorMessage = "Expected output is required!")]
        public string MilestoneOutput1 { get; set; }
        public List<string> MilestonesTitles { get; set; }
		public List<double> MilestonesPercentages { get; set; }
		public HttpPostedFileBase DescriptionFile { get; set; }
	}
}

