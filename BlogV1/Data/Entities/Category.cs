using System.ComponentModel.DataAnnotations;

namespace BlogV1.Data.Entities
{
	public class Category
	{
        public int Id { get; set; }

        [MaxLength(50)]
        public required string Name { get; set; }
        public string? Slug { get; set; }
        public bool ShowOnNavbar { get; set; }
    }
}
