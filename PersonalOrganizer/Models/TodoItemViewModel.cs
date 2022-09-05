using System;
using System.Collections.Generic;

namespace Models
{
	public class TodoItemViewModel
	{
		public int TodoItemId { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public bool IsDone { get; set; }
	}
}