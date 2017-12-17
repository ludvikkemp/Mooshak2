using Mooshak2.Models.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Mooshak2.Models
{
	public class UserViewModel
	{
		[Key]
		[Display(Name = "User Name")]
		public string UserName { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		[Display(Name = "Lockout End Date Utc")]
		public DateTime? LockoutEndDateUtc { get; set; }
		public int AccessFailedCount { get; set; }
		public string PhoneNumber { get; set; }
		public IEnumerable Roles { get; set; }
		public int CourseID { get; set; }
		public string CourseName { get; set; }

	}
	public class UserRolesViewModels
	{
		[Key]
		[Display(Name = "Role Name")]
		public string RoleName { get; set; }
	}
	public class UserRoleViewModel
	{
		[Key]
		[Display(Name = "User Name")]
		public string UserName { get; set; }
		[Display(Name = "Role Name")]
		public string RoleName { get; set; }
	}
	public class RoleViewModel
	{
		[Key]
		public string Id { get; set; }
		[Display(Name = "Role Name")]
		public string RoleName { get; set; }
	}
	public class UserAndRolesViewModel
	{
		[Key]
		[Display(Name = "User Name")]
		public string UserName { get; set; }
		public List<UserRoleViewModel> colUserRoleDTO { get; set; }

	}
	
}