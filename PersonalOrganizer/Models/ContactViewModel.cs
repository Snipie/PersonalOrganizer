namespace Models;

public class ContactViewModel
{
	public int ContactId { get; set; }
	public string Name { get; set; }
	public string Phone { get; set; }
	public string Email { get; set; }
	public bool HasWhatsAppAccount { get; set; }
	public bool HasTelegramAccount { get; set; }
	public string Notes { get; set; }
}