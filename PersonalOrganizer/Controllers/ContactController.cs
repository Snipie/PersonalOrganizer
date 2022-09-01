using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PersonalOrganizer.Models;
using PersonalOrganizer.DAL;

namespace PersonalOrganizer.Controllers;

public class ContactController : Controller
{
	private readonly ILogger<ContactController> _logger;
	
	public ContactController(ILogger<ContactController> logger)
	{
		_logger = logger;
	}

	public IActionResult Index()
	{
		DbContext db = new PersonalOrganizerContext();
		List<Contact> contacts = db.Contacts.ToList();

		return View(contacts);
	}

	[HttpGet]
	public IActionResult Create()
	{
		return View();
	}

	[HttpPost]
	public IActionResult Create(ContactViewModel model)
	{
		DbContext db = new PersonalOrganizerContext();
		db.Contacts.Add(Contact.FromViewModel(model));
		db.SaveChanges();

		return View();
	}

	[HttpGet]
	public IActionResult Edit()
	{
		return View();
	}

	[HttpPost]
	public IActionResult Edit(ContactViewModel model)
	{
		Contact c = db.Contacts.Find(model.ContactId);
		// Modify properties
		// c = Contact.FromViewModel(model);
		db.Contacts.Update(c);
		db.SaveChanges();

		return View();
	}

	[HttpGet]
	public IActionResult Delete()
	{
		return View();
	}

	[HttpPost]
	public IActionResult Delete(int id)
	{
		PersonalOrganizerContext db = new PersonalOrganizerContext();
		db.Contacts.Remove(db.Contacts.Find(id));
		db.SaveChanges();
		
		return View();
	}
}