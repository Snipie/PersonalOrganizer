using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Models;
using DAL;

namespace PersonalOrganizer.Controllers.API;

[Route("api/[controller]")]
[ApiController]
public class TodoItemController : Controller
{
	private readonly ILogger<TodoItemController> _logger;
	
	public TodoItemController(ILogger<TodoItemController> logger)
	{
		_logger = logger;
	}

	[HttpGet]
	public ActionResult<IEnumerable<string>> Get()
	{
		PersonalOrganizerContext db = new PersonalOrganizerContext();
		List<TodoItem> todoItems = db.TodoItems.ToList();

		db.Dispose();

		return Json(todoItems);
	}

	[HttpGet("{id}")]
	public ActionResult<string> Get(int id)
	{
		PersonalOrganizerContext db = new PersonalOrganizerContext();
		TodoItem item = db.TodoItems.Find(id);

		if(item == null)
			return NotFound();

		db.Dispose();

		return Json(item);
	}

	[HttpPost]
	public ActionResult Create([FromBody] TodoItem model)
	{
		PersonalOrganizerContext db = new PersonalOrganizerContext();
		db.TodoItems.Add(model);
		db.SaveChanges();

		db.Dispose();

		return Ok();
	}

	[HttpPut("{id}")]
	public ActionResult Edit(int id, [FromBody] TodoItem model)
	{
		PersonalOrganizerContext db = new PersonalOrganizerContext();
		TodoItem todoItem = db.TodoItems.Find(id);
		if(todoItem == null)
			return NotFound();

		todoItem.Title = model.Title;
		todoItem.Description = model.Description;
		todoItem.IsDone = model.IsDone;

		db.TodoItems.Update(todoItem);
		db.SaveChanges();

		db.Dispose();

		return Ok();
	}

	[HttpDelete("{id}")]
	public ActionResult Delete(int id)
	{
		PersonalOrganizerContext db = new PersonalOrganizerContext();
		TodoItem todoItem = db.TodoItems.Find(id);

		if(todoItem == null)
			return NotFound();

		db.TodoItems.Remove(todoItem);
		db.SaveChanges();

		db.Dispose();

		return Ok();
	}
}