using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mooshak2.Models.ViewModels
{
	public class CourseViewModel
	{
		public int ID { get; set; }
        [Required(ErrorMessage = "Title is required!")]
        public string Name { get; set; }

	}
}