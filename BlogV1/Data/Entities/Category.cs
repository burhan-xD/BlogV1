using System.ComponentModel.DataAnnotations;

namespace BlogV1.Data.Entities
{
	public class Category
	{
        public int Id { get; set; }

        [MaxLength(50)]
        public required string Name { get; set; }

		[MaxLength(75)]
		public string? Slug { get; set; }
        public bool ShowOnNavbar { get; set; }

        public static Category[] GetSeedCategories()
        {
            return
                [
                    new Category { Name = "C#", Slug = "c-sharp", ShowOnNavbar = true },
                    new Category { Name = "ASP.NET Core", Slug = "asp-net-core", ShowOnNavbar = true },
                    new Category { Name = "Blazor", Slug = "blazor", ShowOnNavbar = true },
                    new Category { Name = "SQL Server", Slug = "sql-server", ShowOnNavbar = true },
                    new Category { Name = "Entity Framework Core", Slug = "ef-core", ShowOnNavbar = true },
                    new Category { Name = "Angular", Slug = "angular", ShowOnNavbar = false },
                    new Category { Name = "React", Slug = "react", ShowOnNavbar = false },
                    new Category { Name = "Vue", Slug = "vue", ShowOnNavbar = false },
                    new Category { Name = "Javascript", Slug = "javascript", ShowOnNavbar = false },
                    new Category { Name = "HTML", Slug = "html", ShowOnNavbar = false },
                    new Category { Name = "CSS", Slug = "css", ShowOnNavbar = false },
                    new Category { Name = "Bootstrap", Slug = "bootstrap", ShowOnNavbar = true },
                    new Category { Name = "MVC", Slug = "mvc", ShowOnNavbar = true }
                ];
        }
    }
}
