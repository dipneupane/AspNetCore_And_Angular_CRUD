using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUD_Angular_and_AspNetCore.Entity
{
	[Table("student")]
	public class StudentEntity
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public string FirstName { get; set; }

		[Required]
		public string LastName { get; set; }

		[Required]
		public string City { get; set; }

		[Required]
		[DataType(DataType.EmailAddress)]
		[EmailAddress(ErrorMessage = "Invalid Email Address")]
		public string Email { get; set; }

		[Required]
		[DataType(DataType.PhoneNumber)]
		[RegularExpression(@"^\(?([0-9]{3})\)?[-.●]?([0-9]{3})[-.●]?([0-9]{4})$", ErrorMessage = "Invalid Phone Number")]
		public string PhoneNumber { get; set; }

		[Required]
		public DateTime EnrolledDate { get; set; }
	}
}
