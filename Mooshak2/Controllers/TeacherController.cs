using Mooshak2.Models;
using Mooshak2.Models.Entities;
using Mooshak2.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Mooshak2.Controllers
{
    public class TeacherController : Controller
    {
		private ApplicationDbContext _db = new ApplicationDbContext();
		private ApplicationUserManager _userManager;
		private ApplicationRoleManager _roleManager;


		// *** INDEX *** //


		// GET: /Teacher/Index/
		[Authorize(Roles = "Teacher")]
		#region public ActionResult Index()
		public ActionResult Index()
        {
            return View();
        }
		#endregion


		// *** ASSIGNMENTS *** //


		// GET: /Teacher/Assignments/
		[Authorize(Roles = "Teacher")]
		#region public ActionResult Assignments()
		public ActionResult Assignments()
		{
			List<AssignmentViewModel> theList = new List<AssignmentViewModel>();
			var result = _db.Assignments.ToList();

			foreach (var item in result)
			{
				AssignmentViewModel assignmentViewModel = new AssignmentViewModel();

				assignmentViewModel.ID = item.ID;
				assignmentViewModel.Title = item.Title;
				assignmentViewModel.CourseID = item.CourseID;
				assignmentViewModel.DueDate = item.DueDate;

				assignmentViewModel.CourseName = _db.Courses
														.Where(x => x.ID == item.CourseID)
														.Select(x => x.Name).SingleOrDefault();
				
				assignmentViewModel.MilestonesTitles = _db.Milestones.Where(X => X.AssignmentID == item.ID)
														.Select(x => x.Title).ToList();

				assignmentViewModel.MilestonesPercentages = _db.Milestones.Where(x => x.AssignmentID == item.ID)
														.Select(x => x.Percentage).ToList();
				
				theList.Add(assignmentViewModel);
			}
			return View(theList);
		}
		#endregion

		// GET: /Teacher/CreateAssignments/
		[Authorize(Roles = "Teacher")]
		#region public ActionResult CreateAssignments()
		public ActionResult CreateAssignments()
		{
			List<CourseViewModel> listOfCourses = new List<CourseViewModel>();
			var result = _db.Courses.ToList();

			foreach (var item in result)
			{
				CourseViewModel course = new CourseViewModel();

				course.ID = item.ID;
				course.Name = item.Name;

				listOfCourses.Add(course);
			}
			return View(listOfCourses);
		}
		#endregion

		// POST: /Teacher/CreateAssignments/
		[HttpPost]
		[Authorize(Roles = "Teacher")]
		#region public ActionResult CreateAssignments(AssignmentViewModel model)
		public ActionResult CreateAssignments(AssignmentViewModel model)
		{
			if (ModelState.IsValid)
			{
				int dataCount = _db.Assignments
									.Where(x => x.CourseID == model
									.CourseID && x.Title == model.Title)
									.Count();

				if (dataCount == 0)
				{
					var assignment = new Assignment();

					assignment.CourseID = model.CourseID;
					assignment.Title = model.Title;
					assignment.DueDate = model.DueDate;
					assignment.StartDate = model.Startdate;
					assignment.Languages = model.Languages;
					assignment.GroupSize = model.GroupSize;

                    HttpPostedFileBase file = model.DescriptionFile;

                    if (file != null && file.ContentLength > 0)
                    {
                        var filename = Path.GetFileName(file.FileName);
                        var path = Path.Combine(Server.MapPath("~/Content/Descriptions"), filename);
                        assignment.DescriptionPath = path;
                        assignment.DescriptionFileName = filename;
                        file.SaveAs(path);
                    }
                    
					_db.Assignments.Add(assignment);
					_db.SaveChanges();

					var milestone = new Milestone();

					milestone.Title = model.MilestoneTitle;
					milestone.AssignmentID = assignment.ID;
					milestone.Percentage = model.MilestonePercentage;
                    milestone.MilestoneInput1 = model.MilestoneInput1;
                    milestone.MilestoneOutput1 = model.MilestoneOutput1;
                    milestone.SubmissionLimit = model.MilestoneSubmissionLimit;

					_db.Milestones.Add(milestone);
					_db.SaveChanges();
				}
				else
				{
					return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
				}
			}
			return Redirect("~/Teacher/Assignments");	
		}
		#endregion

		// GET: /Teacher/AddMilestone
		[Authorize(Roles = "Teacher")]
		#region public ActionResult AddMilestone(int assignmentID)
		public ActionResult AddMilestone(int assignmentID)
        {
            AssignmentViewModel model = new AssignmentViewModel();
            model.ID = assignmentID;
            return View(model);
        }
		#endregion

		// POST: /Teacher/AddMilestone
		[Authorize(Roles = "Teacher")]
        [HttpPost]
		#region public ActionResult AddMilestone(MilestoneViewModel model)
		public ActionResult AddMilestone(MilestoneViewModel model)
        {
            Milestone newMilestone = new Milestone();

            newMilestone.AssignmentID = model.AssignmentID;
            newMilestone.Percentage = model.Percentage;
            newMilestone.Title = model.Title;
            newMilestone.MilestoneInput1 = model.MilestoneInput1;
            newMilestone.MilestoneOutput1 = model.MilestoneOutput1;
            newMilestone.SubmissionLimit = model.SubmissionLimit;

            _db.Milestones.Add(newMilestone);
            _db.SaveChanges();

            return Redirect("~/Teacher/Assignments");
        }
		#endregion

		// GET: /Teacher/DeleteAssignment/
		[Authorize(Roles = "Teacher")]
		#region public ActionResult DeleteAssignment(int assignmentID)
		public ActionResult DeleteMilestone(int milestoneID, int assignmentID)
		{
			Milestone milestone = _db.Milestones
									.Where(x => x.ID == milestoneID)
									.SingleOrDefault();

			_db.Milestones.Remove(milestone);
			_db.SaveChanges();

			int milestoneCount = _db.Milestones
									.Where(x => x.AssignmentID == assignmentID)
									.Count();

			if (milestoneCount == 0)
			{
				Assignment assignment = _db.Assignments.Where(x => x.ID == assignmentID).SingleOrDefault();

				_db.Assignments.Remove(assignment);
				_db.SaveChanges();
			}
			
			return Redirect("~/Teacher/Assignments");
		}
		#endregion


		// *** MILESTONES *** //

		// GET: /Teacher/ViewMilestones/
		[Authorize(Roles = "Teacher")]
		#region public ActionResult DeleteMilestones(int assignmentID)
		public ActionResult ViewMilestones(int assignmentID)
		{
			List<MilestoneViewModel> milestones = new List<MilestoneViewModel>();

			var results = _db.Milestones
							.Where(x => x.AssignmentID == assignmentID)
							.ToList();

			foreach (var item in results)
			{
				MilestoneViewModel model = new MilestoneViewModel();

				model.ID = item.ID;
				model.AssignmentID = assignmentID;
				model.Title = item.Title;
				model.Percentage = item.Percentage;
				model.Grade = item.Grade;
                model.SubmissionLimit = item.SubmissionLimit;
                model.MilestoneInput1 = item.MilestoneInput1;
                model.MilestoneOutput1 = item.MilestoneOutput1;

				milestones.Add(model);
			}

			return View(milestones);
		}
		#endregion


		// *** SUBMISSIONS *** //


		[Authorize(Roles = "Teacher")]
		#region public ActionResult Submissions()
		public ActionResult Submissions()
		{
            var submissions = _db.Submissions.ToList();

            List<SubmissionViewModel> models = new List<SubmissionViewModel>();

            foreach(var submission in submissions)
            {
                SubmissionViewModel nextSubmission = new SubmissionViewModel();

                nextSubmission.MilestoneID = submission.MilestoneID;
                nextSubmission.MilestoneTitle = _db.Milestones.Where(x => x.ID == nextSubmission.MilestoneID).Select(x => x.Title).SingleOrDefault();
                nextSubmission.UserID = submission.UserID;
                nextSubmission.UserName = _db.Users.Where(x => x.Id == nextSubmission.UserID).Select(x => x.UserName).SingleOrDefault();
                nextSubmission.SubmissionFileName = submission.SubmissionFileName;
                nextSubmission.SubmissionPath = submission.SubmissionPath;
                

                models.Add(nextSubmission);
            }

            return View(models);
		}
		#endregion


		// *** SERVICES *** ///


		// Get Course By Title Helper
		#region private AssignmentViewModel getCourseByTitle(string title)
		private AssignmentViewModel getAssignmentByTitle(string title)
		{
			AssignmentViewModel assignment = new AssignmentViewModel();
			var result = _db.Assignments.Where(x => x.Title == title).SingleOrDefault();

			if (result != null)
			{
				assignment.ID = result.ID;
				assignment.Title = result.Title;
				assignment.DueDate = result.DueDate;
				assignment.CourseID = result.CourseID;
			}
			return assignment;
		}
		#endregion

		// Delete Assignment Helper
		#region private void DeleteAssignment(AssignmentViewModel assignmentViewModel)
		private void DeleteAssignment(AssignmentViewModel assignmentViewModel)
		{
			Assignment assignment = _db.Assignments
				.Where(x => x.Title == assignmentViewModel.Title)
				.SingleOrDefault();

			if (assignment != null)
			{
				_db.Assignments.Remove(assignment);
				_db.SaveChanges();
			}
		}
		#endregion

	}
}