using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using kicweb.Models.Member;
using kicweb.Services;

namespace kicweb.Controllers
{
	[Route("[controller]")]
	public class Member : Controller
	{
		private readonly ILogger<Member> _logger;

		private readonly IUserService _userService;

		public Member(ILogger<Member> logger, IUserService userService)
		{
			_logger = logger;
			_userService = userService;
		}

		public IActionResult Index()
		{
			return View();
		}

		[HttpGet]
		public IActionResult Register()
		{
			RegisterViewModel rvm = new RegisterViewModel()
			{
				LegalName = "",
				EmailAddress = "",
				FetName = "",
				UserName = "",
				Password = "",
				Password2 = ""
			};

			return View(rvm);
		}

		[HttpPost]
		public IActionResult Register(RegisterViewModel rvmUpdated)
		{
			if (rvmUpdated.Password != rvmUpdated.Password2)
			{
				ViewBag.ErrorMessage = "Passwords do not match.";
				rvmUpdated.Password = "";
				rvmUpdated.Password2 = "";
				return View(rvmUpdated);
			}

			User newUser = _userService.CreateUser(rvmUpdated);

			return View("~/Views/Member/RegisterSuccess.cshtml", newUser);
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View("Error!");
		}
	}
}