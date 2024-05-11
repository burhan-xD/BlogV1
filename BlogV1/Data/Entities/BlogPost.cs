using System.ComponentModel.DataAnnotations;

namespace BlogV1.Data.Entities
{
	public class BlogPost
    {
		public int Id { get; set; }

		[MaxLength(100)]
		public required string Title { get; set; }

		[MaxLength(125)]
		public string? Slug { get; set; }

		[MaxLength(100)]
		public required string Image { get; set; }

		[MaxLength(500)]
		public required string Introduction { get; set; }

		public required string Content { get; set; }

		public int CategoryId { get; set; }

		public string? UserId { get; set; }

		public bool IsPublished { get; set; }

		public int ViewCount { get; set; }
		public bool IsFeatured { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime? PublishedAt { get; set; }

		public virtual Category Category { get; set; }
		public virtual ApplicationUser User { get; set; }

	}
}
