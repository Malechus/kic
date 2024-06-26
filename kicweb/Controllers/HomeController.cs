﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using kicweb.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using kicweb.Services;
using System.Net;
using MailKit.Security;
using MailKit.Net.Smtp;
using MimeKit;
using System.Text;
using KiCData;
using KiCData.Models;
using KiCWeb.Models;
using KiCWeb.Services;
using Org.BouncyCastle.Crypto.Fpe;

namespace KiCWeb.Controllers;

public class HomeController : Controller
{
	private readonly IKiCLogger _logger;
	private readonly IHttpContextAccessor _contextAccessor;
	private readonly ICookieService _cookieService;
	private readonly IEmailService _emailService;
	private readonly IConfigurationRoot _configurationRoot;

	public HomeController(IKiCLogger logger, IHttpContextAccessor httpContextAccessor, ICookieService cookieService, IEmailService emailService, IConfigurationRoot configurationRoot)
	{
		_logger = logger;
		_contextAccessor = httpContextAccessor;
		_cookieService = cookieService;
		_emailService = emailService;
		_configurationRoot = configurationRoot;
	}

	[HttpGet]
	public IActionResult Index()
	{
		IndexViewModel ivm = new IndexViewModel()
		{
			Consent = true
		};

		if (!_cookieService.AgeGateCookieAccepted(_contextAccessor.HttpContext.Request))
		{
			//ivm.Consent = false;
			ViewBag.AgeGateCookieAccepted = false;
		}
		else { ViewBag.AgeGateCookieAccepted = true; }
        return View(ivm);
	}

	[HttpPost]
	public IActionResult Index(IndexViewModel ivmUpdated)
	{
		if (ivmUpdated.Consent == true)
		{
			ViewBag.AgeGateCookieAccepted = true;
			CookieOptions cookieOptions = _cookieService.AgeGateCookieFactory();
			_contextAccessor.HttpContext.Response.Cookies.Append("Age_Gate", "true", cookieOptions);
			return View();
		}
		else
		{
			ViewBag.AgeGateCookieAccepted = false;
			return View();
		}
	}

	public IActionResult Privacy()
	{
        if (!_cookieService.AgeGateCookieAccepted(_contextAccessor.HttpContext.Request))
        {
            return Redirect("Index");
        }
        return View();
	}

	public IActionResult Club425()
	{
        if (!_cookieService.AgeGateCookieAccepted(_contextAccessor.HttpContext.Request))
        {
            return Redirect("Index");
        }
        return View();
	}

	public IActionResult About()
	{
        if (!_cookieService.AgeGateCookieAccepted(_contextAccessor.HttpContext.Request))
        {
            return Redirect("Index");
        }
        return View();
	}

	public IActionResult Events()
	{
        if (!_cookieService.AgeGateCookieAccepted(_contextAccessor.HttpContext.Request))
        {
            return Redirect("Index");
        }
        return View("/Views/Shared/UnderConstruction.cshtml");
	}

	public IActionResult Purchase()
	{
        if (!_cookieService.AgeGateCookieAccepted(_contextAccessor.HttpContext.Request))
        {
            return Redirect("Index");
        }
        return View("/Views/Shared/UnderConstruction.cshtml");
	}

	[HttpGet]
	public IActionResult Presenters()
	{
        if (!_cookieService.AgeGateCookieAccepted(_contextAccessor.HttpContext.Request))
        {
            return Redirect("Index");
        }
		ViewBag.Error = null;
		Presentation presentation = new Presentation() { Presenter = new Presenter() };
		return View(presentation);
	}

	[HttpPost]
	public IActionResult Presenters(Presentation presUpdated)
	{
		if (!ModelState.IsValid)
		{
			ViewBag.Error = "There was a validation issue.";
			return Redirect("Presenters");
		}

		FormMessage formMessage = _emailService.FormSubmissionEmailFactory("Presenters");
		if(formMessage is null)
		{
			//log error here

			return Redirect("Error");
		}

        formMessage.HtmlBuilder.Append("<p>This is an automated email message sent through kicevents.com. A new presentation sign up has occurred.</p>" +
            "<br />" +
            "<br />" +
            "<br /><b>FetName: </b>" + presUpdated.Presenter.FetName +
            "<br /><b>Business Name: </b>" + presUpdated.Presenter.PublicName +
            "<br /><b>Email: </b>" + presUpdated.Presenter.EmailAddress +
            "<br /><b>Presenter Details: </b>" + presUpdated.Presenter.Bio +
			"<br /><b>Presentation Name: </b>" + presUpdated.Name +
            "<br /><b>Presentation Description: </b>" + presUpdated.Description +
            "<br /><b>Presentation Topic: </b>" + presUpdated.Type +
            "<br />" +
            "<br />" +
            "Please take any necessary action from here. If you encounter issues with this email, or you believe it has been sent in error, please reply to it."
        );

        try
        {
            _emailService.SendEmail(formMessage);
        }
        catch (Exception ex)
        {
            _logger.Log(ex, _contextAccessor.HttpContext.Request);
            return Redirect("Error");
        }

        return Redirect("Success");
    }

	[HttpGet]
	public IActionResult Vendors()
	{
        if (!_cookieService.AgeGateCookieAccepted(_contextAccessor.HttpContext.Request))
        {
            return Redirect("Index");
        }
		ViewBag.Error = null;
		Vendor vendor = new Vendor() { LastAttended = null };
		return View(vendor);
	}

	[HttpPost]
	public IActionResult Vendors(Vendor venUpdated)
	{
		if (!ModelState.IsValid)
		{
			ViewBag.Error = "There was a validation issue.";
			return View("Vendors");
		}

		FormMessage formMessage = _emailService.FormSubmissionEmailFactory("Vendors");
		if(formMessage == null)
		{
			//log exception here

			return Redirect("Error");
		}

		formMessage.HtmlBuilder.Append("<p>This is an automated email message sent through kicevents.com. A new vendor sign up has occurred.</p>" +
            "<br />" +
            "<br />" +
            "<br /><b>FetName: </b>" + venUpdated.FetName +
			"<br /><b>Business Name: </b>" + venUpdated.PublicName +
            "<br /><b>Email: </b>" + venUpdated.EmailAddress +
            "<br /><b>Details: </b>" + venUpdated.Bio +
            "<br />" +
            "<br />" +
            "Please take any necessary action from here. If you encounter issues with this email, or you believe it has been sent in error, please reply to it."
        );

		try
		{
			_emailService.SendEmail(formMessage);
        }
        catch (Exception ex)
        {
            _logger.Log(ex, _contextAccessor.HttpContext.Request);
            return Redirect("Error");
        }

        return Redirect("Success");
    }

	[HttpGet]
	public IActionResult Volunteers()
	{
        if (!_cookieService.AgeGateCookieAccepted(_contextAccessor.HttpContext.Request))
        {
            return Redirect("Index");
        }
		ViewBag.Error = null;
		Volunteer volunteer = new Volunteer();

        return View(volunteer);
    }

	[HttpPost]
	public IActionResult Volunteers(Volunteer volUpdated)
	{
		if(!ModelState.IsValid)
		{
			ViewBag.Error = "There was a validation issue.";
			return View("Volunteers");
		}

		FormMessage message = _emailService.FormSubmissionEmailFactory("Volunteers");
		if (message == null)
		{
			//log exception here

			return Redirect("Error");
		}

		message.HtmlBuilder.Append("<p>This is an automated email message sent through kicevents.com. A new volunteer sign up has occurred.</p>" +
			"<br />" +
			"<br />" +
            "<br /><b>Name: </b>" + volUpdated.LegalName +
            "<br /><b>Fet Name: </b>" + volUpdated.FetName +
			"<br /><b>Club ID: </b>" + volUpdated.ClubId +
            "<br /><b>Email: </b>" + volUpdated.Email +
            "<br /><b>Phone: </b>" + volUpdated.PhoneNumber +
            "<br /><b>Details: </b>" + volUpdated.Details +
            "<br />" +
            "<br />" +
			"Please take any necessary action from here. If you encounter issues with this email, or you believe it has been sent in error, please reply to it."
        );

		try
		{
            _emailService.SendEmail(message);
        }
		catch (Exception ex)
		{
			_logger.Log(ex, _contextAccessor.HttpContext.Request);
			return Redirect("Error");
		}

		return Redirect("Success");
	}

	[HttpGet]
	public IActionResult Contact()
	{
        if (!_cookieService.AgeGateCookieAccepted(_contextAccessor.HttpContext.Request))
        {
            return Redirect("Index");
        }
        ViewBag.Error = null;
		Feedback feedback = new Feedback();

		return View(feedback);
    }

	[HttpPost]
	public IActionResult Contact(Feedback feedbackUpdated)
	{
		if (!ModelState.IsValid)
		{
			ViewBag.Error = "There was a validation issue.";
			return View("Contact");
		}

        FormMessage message = _emailService.FormSubmissionEmailFactory("Admin");
        if (message == null)
        {
            //log exception here

            return Redirect("Error");
        }

        message.HtmlBuilder.Append("<p>This is an automated email message sent through kicevents.com. A new feedback submission has occurred.</p>" +
            "<br />" +
            "<br />" +
            "<br /><b>Details: </b>" + feedbackUpdated.Text +
            "<br />" +
            "<br />" +
            "Please take any necessary action from here. If you encounter issues with this email, or you believe it has been sent in error, please reply to it."
        );

        try
        {
            _emailService.SendEmail(message);
        }
        catch (Exception ex)
        {
            _logger.Log(ex, _contextAccessor.HttpContext.Request);
            return Redirect("Error");
        }

        return Redirect("Success");
    }

	public IActionResult Success()
	{
		return View();
	}

	[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
	public IActionResult Error()
	{
		return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
	}
}
