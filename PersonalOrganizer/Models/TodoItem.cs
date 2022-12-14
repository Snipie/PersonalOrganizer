using System;
using System.Collections.Generic;

namespace Models
{
	public class TodoItem
	{
		public int TodoItemId { get; set; }
		public string? Title { get; set; }
		public string? Description { get; set; }
		public bool IsDone { get; set; }

		public override string ToString()
		{
			return $"ID: {this.TodoItemId}\n Title: {this.Title}\n Description: {this.Description}\n IsDone: {this.IsDone}";
		}

		public static TodoItem FromViewMode(TodoItemViewModel model)
		{
			return new TodoItem {
				TodoItemId = model.TodoItemId,
				Title = model.Title,
				Description = model.Description,
				IsDone = model.IsDone
			};
		}
	}
}