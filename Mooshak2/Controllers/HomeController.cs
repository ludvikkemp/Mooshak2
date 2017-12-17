using System.Web.Mvc;

namespace Mooshak2.Controllers
{
	public class HomeController : Controller
	{
		[Authorize(Roles = "Administrator, Student, Teacher")]
		public ActionResult Index()
		{
			return View();
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}
	}
}