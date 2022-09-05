using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Models;
using DAL;

namespace PersonalOrganizer.Controllers;

public class TodoItemController : Controller
{
	private readonly ILogger<TodoItemController> _logger;
	
	public TodoItemController(ILogger<TodoItemController> logger)
	{
		_logger = logger;
	}

	public IActionResult Index()
	{
		PersonalOrganizerContext db = new PersonalOrganizerContext();
		List<TodoItem> todoItems = db.TodoItems.ToList();

		return View(todoItems);
	}

	[HttpGet]
	public IActionResult Create()
	{
		return View();
	}

	[HttpPost]
	public IActionResult Create(TodoItem model)
	{
		PersonalOrganizerContext db = new PersonalOrganizerContext();
		db.TodoItems.Add(model);
		db.SaveChanges();

		return View();
	}

	[HttpGet]
	public IActionResult Edit(int id)
	{
		PersonalOrganizerContext db = new PersonalOrganizerContext();
		TodoItem todoItem = db.TodoItems.Find(id);
		return View(todoItem);
	}

	[HttpPost]
	public IActionResult Edit(TodoItem model)
	{
		PersonalOrganizerContext db = new PersonalOrganizerContext();
		TodoItem todoItem = db.TodoItems.Find(model.TodoItemId);

		todoItem.Title = model.Title;
		todoItem.Description = model.Description;
		todoItem.IsDone = model.IsDone;

		db.TodoItems.Update(todoItem);
		db.SaveChanges();

		return View();
	}

	[HttpPost]
	public IActionResult Delete(int id)
	{
		PersonalOrganizerContext db = new PersonalOrganizerContext();
		db.TodoItems.Remove(db.TodoItems.Find(id));
		db.SaveChanges();
		db.Dispose();

		return View("Index");
	}
}