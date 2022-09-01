using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Models;

namespace DAL
{
	public class PersonalOrganizerContext : DbContext
	{
		public DbSet<Contact> Contacts { get; set; }
		public DbSet<TodoItem> TodoItems { get; set; }

		public string DbPath { get; }

		public PersonalOrganizerContext()
		{
			//var folder = Environment.SpecialFolders.LocalApplicationData;
			//var path = Environment.GetFolderPath(folder);
			//DbPath = System.IO.Path.Join(path, "personal_organizer.db");
			DbPath = "./personal_organizer.db";
		}

		protected override void OnConfiguring(DbContextOptionsBuilder options)
			=> options.UseSqlite($"Data Source={DbPath}");
	}
}