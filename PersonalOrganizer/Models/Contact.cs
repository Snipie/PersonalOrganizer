using System;
using System.Collections.Generic;

namespace Models
{
	public class Contact
	{
		public int ContactId { get; set; }
		public string? Name { get; set; }
		public string? Phone { get; set; }
		public string? Email { get; set; }
		public bool HasWhatsAppAccount { get; set; }
		public bool HasTelegramAccount { get; set; }
		public string? Notes { get; set; }

		public override string ToString()
		{
			return $"ID: {this.ContactId}\n Name: {this.Name}\n Phone: {this.Phone}\n Email: {this.Email}\n HasWhatsAppAccount?: {this.HasWhatsAppAccount}\n HasTelegramAccount?: {this.HasTelegramAccount}\n Notes: {this.Notes}\n";
		}

		public static Contact FromViewModel(ContactViewModel model)
		{
			return new Contact() {
				ContactId = model.ContactId,
				Name = model.Name,
				Phone = model.Phone,
				Email = model.Email,
				HasWhatsAppAccount = model.HasWhatsAppAccount,
				HasTelegramAccount = model.HasTelegramAccount,
				Notes = model.Notes
			};
		}
	}
}