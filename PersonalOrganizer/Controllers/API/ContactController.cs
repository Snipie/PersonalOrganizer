using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Models;
using DAL;

namespace PersonalOrganizer.Controllers.API;

[Route("api/[controller]")]
[ApiController]
public class ContactController : Controller
{
	private readonly ILogger<ContactController> _logger;
	
	public ContactController(ILogger<ContactController> logger)
	{
		_logger = logger;
	}

	[HttpGet]
	public ActionResult<IEnumerable<string>> Get()
	{
		PersonalOrganizerContext db = new PersonalOrganizerContext();
		List<Contact> contacts = db.Contacts.ToList();

		return Json(contacts);
	}

	[HttpGet("{id}")]
	public ActionResult<string> Get(int id)
	{
		PersonalOrganizerContext db = new PersonalOrganizerContext();
		Contact c = db.Contacts.Find(id);
		if(c == null)
			return NotFound();

		return Json(c);
	}

	[HttpPost]
	public ActionResult Create([FromBody] Contact model)
	{
		PersonalOrganizerContext db = new PersonalOrganizerContext();
		db.Contacts.Add(model);
		db.SaveChanges();

		return Ok();
	}

	[HttpPut("{id}")]
	public ActionResult Edit(int id, [FromBody] Contact model)
	{
		PersonalOrganizerContext db = new PersonalOrganizerContext();
		Contact c = db.Contacts.Find(id);
		if(c == null)
			return NotFound();

		c.Name = model.Name;
		c.Email = model.Email;
		c.Phone = model.Phone;
		c.HasWhatsAppAccount = model.HasWhatsAppAccount;
		c.HasTelegramAccount = model.HasTelegramAccount;
		c.Notes = model.Notes;
		db.Contacts.Update(c);
		db.SaveChanges();

		return Ok();
	}

	[HttpDelete("{id}")]
	public ActionResult Delete(int id)
	{
		PersonalOrganizerContext db = new PersonalOrganizerContext();
		Contact c = db.Contacts.Find(id);
		if(c == null)
			return NotFound();

		db.Contacts.Remove(c);
		
		db.SaveChanges();

		return Ok();
	}
}