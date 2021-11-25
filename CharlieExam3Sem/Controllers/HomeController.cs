using CharlieExam3Sem.Data;
using CharlieExam3Sem.FileTools;
using CharlieExam3Sem.Models;
using CharlieExam3Sem.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using System.Net;

namespace CharlieExam3Sem.Controllers
{
	
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		private readonly ApplicationDbContext _context;

		///Udviklet af: Martin Nørholm, Janus B. Reedtz og Frederik M. Nielsen
		public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
		{
			_context = context;
			_logger = logger;
		}
		///Udviklet af: Martin Nørholm, Janus B. Reedtz og Frederik M. Nielsen
		public IActionResult Index()
		{
			return View();
		}
		///Udviklet af: Martin Nørholm, Janus B. Reedtz og Frederik M. Nielsen
		public IActionResult AccessDenied()
		{
			return View();
		}
		///Udviklet af: Martin Nørholm, Janus B. Reedtz og Frederik M. Nielsen
		[Authorize]
		public IActionResult FileHandling()
		{
			return View();
		}

		///Udviklet af: Martin Nørholm
		[Authorize]
		public IActionResult FileSavedOk()
		{
			SaveRunners saveRunners = new SaveRunners(_context);
			return View();
		}
		///Udviklet af: Martin Nørholm
		[Authorize]
		public async Task<IActionResult> FileUploadedOk()
		{
			UploadRunners incomingRunners = new UploadRunners();
			List<Runner> runners = incomingRunners.Runners;
			foreach (Runner r in runners)
			{
				if (RunnerExists(r.ID))
				{
					continue;
				}
				else
				{
					_context.Runners.Add(new Runner()
					{
						FirstName = r.FirstName,
						LastName = r.LastName,
						Address = r.Address,
						AssignCaptain = r.AssignCaptain,
						EmailAddress = r.EmailAddress,
						BirthDate = r.BirthDate,
						MemberSince = r.MemberSince,
						PhoneNumber = r.PhoneNumber,
						RunnerNumber = r.RunnerNumber,
						ZipCode = r.ZipCode
					}
					);					
				}
			}
			await _context.SaveChangesAsync();

			return RedirectToAction("RunnerList","Runners");
		}

		///Udviklet af: Martin Nørholm, Janus B. Reedtz og Frederik M. Nielsen
		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}

		///Udviklet af: Martin Nørholm, Janus B. Reedtz og Frederik M. Nielsen
		private bool RunnerExists(int id)
		{
			return _context.Runners.Any(e => e.ID == id);
		}
	}
}
