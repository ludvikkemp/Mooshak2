using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mooshak2.Models.Entities
{
	public class Assignment
	{
		public int ID { get; set; }
		public int CourseID { get; set; }
		public string Title { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime DueDate { get; set; }
        public string Languages { get; set; }
		public int GroupSize { get; set; }
        public string DescriptionPath { get; set; }
        public string DescriptionFileName { get; set; }


	}
}