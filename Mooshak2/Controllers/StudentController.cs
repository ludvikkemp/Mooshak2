using Microsoft.AspNet.Identity;
using Mooshak2.Models;
using Mooshak2.Models.Entities;
using Mooshak2.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mooshak2.Controllers
{
    public class StudentController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
		private ApplicationUserManager _userManager;


		// *** SUBMISSIONS *** ///

		// GET: /Student/SubmitSolution
		[Authorize(Roles = "Student")]
		#region public ActionResult SubmitSolution()
		public ActionResult SubmitSolution()
        {
            var milestones = _db.Milestones.ToList();
            
            List<MilestoneViewModel> models = new List<MilestoneViewModel>();
            
            foreach(var milestone in milestones)
            {
                MilestoneViewModel newModel = new MilestoneViewModel();

                newModel.ID = milestone.ID;
                newModel.Percentage = milestone.Percentage;
                newModel.Title = milestone.Title;
                newModel.AssignmentDescriptionFileName = _db.Assignments.Where(x => x.ID == milestone.AssignmentID).Select(x => x.DescriptionFileName).SingleOrDefault();

                models.Add(newModel);
            }

            return View(models);
        }
		#endregion

		// POST: /Student/SubmitSolution
		[Authorize(Roles = "Student")]
        [HttpPost]  
		#region public ActionResult SubmitSolution(SubmissionViewModel model)
		public ActionResult SubmitSolution(SubmissionViewModel model)
        {
			var userID = User.Identity.GetUserId(); 

            Submission newSubmission = new Submission();

            newSubmission.MilestoneID = model.MilestoneID;

            HttpPostedFileBase file = model.SubmissionFile;
            var filename = Path.GetFileName(file.FileName);
            var path = Path.Combine(Server.MapPath("~/Content/Submissions"), filename);

            if (file.ContentLength > 0 && file != null)
            {
                newSubmission.SubmissionPath = path;
                newSubmission.SubmissionFileName = filename;
				newSubmission.UserID = userID;
                
                file.SaveAs(path);
            }

            var workingFolder = Server.MapPath("~/Content/Submissions");
            string exeFileName="";
            string exeFilePath = "";
            if (filename.EndsWith(".cpp"))
            {
                exeFileName = filename.Replace(".cpp", ".exe");
                exeFilePath = workingFolder + "\\" + exeFileName;
            }
            
            
            var compilerFolder = "C:\\Program Files (x86)\\Microsoft Visual Studio 14.0\\VC\\bin\\";
            var milestoneInput = _db.Milestones.Where(x => model.MilestoneID == x.ID).Select(x => x.MilestoneInput1).SingleOrDefault();

            Process compiler = new Process();
            compiler.StartInfo.FileName = "cmd.exe";
            compiler.StartInfo.WorkingDirectory = workingFolder;
            compiler.StartInfo.RedirectStandardInput = true;
            compiler.StartInfo.RedirectStandardOutput = true;
            compiler.StartInfo.UseShellExecute = false;

            compiler.Start();
            compiler.StandardInput.WriteLine("\"" + compilerFolder + "vcvars32.bat" + "\"");
            compiler.StandardInput.WriteLine("cl.exe /nologo /EHsc " + filename);
            compiler.StandardInput.WriteLine("exit");
            string output = compiler.StandardOutput.ReadToEnd();
            compiler.WaitForExit();
            compiler.Close();

            if (System.IO.File.Exists(exeFilePath))
            {
                var processInfoExe = new ProcessStartInfo(exeFilePath, "");
                processInfoExe.UseShellExecute = false;
                processInfoExe.RedirectStandardInput = true;
                processInfoExe.RedirectStandardOutput = true;
                processInfoExe.RedirectStandardError = true;
                processInfoExe.CreateNoWindow = true;
                using (var processExe = new Process())
                {
                    processExe.StartInfo = processInfoExe;
                    processExe.Start();
                    processExe.StandardInput.WriteLine(milestoneInput);

                    string lines = "";
                    while (!processExe.StandardOutput.EndOfStream)
                    {
                        lines = lines + processExe.StandardOutput.ReadLine();
                        //lines.add(processExe.StandardOutput.ReadLine());
                    }
                    newSubmission.Output = lines;
                    newSubmission.Compiled = true;
                    processExe.StandardInput.Close();
                }
            }
            else
            {
                newSubmission.Compiled = false;
            }
            _db.Submissions.Add(newSubmission);
            _db.SaveChanges();
            return Redirect("~/Student/YourSubmissions");
        }
		#endregion


		// GET: /Student/YourSubmission
		[Authorize(Roles = "Student")]
		#region public ActionResult YourSubmissions()
		public ActionResult YourSubmissions()
        {
            var userId = User.Identity.GetUserId();
            List<Submission> studentsSubmissions = _db.Submissions.Where(x => x.UserID == userId).ToList();
            //Try excception
            List<SubmissionViewModel> models = new List<SubmissionViewModel>();

            foreach(var submission in studentsSubmissions)
            {
                SubmissionViewModel nextSubmission = new SubmissionViewModel();

                nextSubmission.MilestoneID = submission.MilestoneID;
                nextSubmission.MilestoneTitle = _db.Milestones.Where(x => x.ID == nextSubmission.MilestoneID).Select(x => x.Title).SingleOrDefault();
                nextSubmission.SubmissionFileName = submission.SubmissionFileName;
                nextSubmission.Output = submission.Output;

                string expectedOutput = _db.Milestones.Where(x => x.ID == nextSubmission.MilestoneID).Select(x => x.MilestoneOutput1).SingleOrDefault();

                if (submission.Compiled == false)
                {
                    nextSubmission.Status = "Compile Error";
                }
                else
                {
                    if (submission.Output == expectedOutput)
                    {
                        nextSubmission.Status = "Accepted";
                    }
                    else
                    {
                        nextSubmission.Status = "Incorrect Output";
                    }
                }

                models.Add(nextSubmission);
            }

            return View(models);
        }
		#endregion
	}
}