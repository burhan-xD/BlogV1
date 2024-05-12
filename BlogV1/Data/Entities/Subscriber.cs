using System.ComponentModel.DataAnnotations;

namespace BlogV1.Data.Entities
{
	public class Subscriber
	{
		public long Id { get; set; }

		[EmailAddress, MaxLength(150)]
		public required string Email { get; set; }

		[MaxLength(25)]
		public required string Name { get; set; }
		public DateTime SubscribedOn { get; set; }
	}
}