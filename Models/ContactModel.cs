using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace skh.Models
{
	public class ContactModel
	{
		[Key]
		public int Id { get; set; }
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        public string Email { get; set; }
		[DisplayName("Full Name")]
		public string Name { get; set; }
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Please enter a valid 10-digit phone number.")]
        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; }
		public string Message { get; set; }

	}

}