using BlogV1.Data;
using BlogV1.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BlogV1.Services
{
    internal static class AdminAccount
    {
        public const string Name = "Burhan";
        public const string Role = "Admin";
        public const string Password = "Password1.";
        public const string Email = "burhan@burhan.com";
    }

    public interface ISeedService
    {
        Task SeedDataAsync();
    }

    public class SeedService : ISeedService
    {
        private readonly ApplicationDbContext _context;
        private readonly IUserStore<ApplicationUser> _userStore;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public SeedService(ApplicationDbContext context, IUserStore<ApplicationUser> userStore, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userStore = userStore;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task MigrateDatabaseAsync()
        {
#if DEBUG
            if ((await _context.Database.GetPendingMigrationsAsync()).Any())
            {
                await _context.Database.MigrateAsync();
            }
#endif
        }

        public async Task SeedDataAsync()
        {

            await MigrateDatabaseAsync();

            if (await _roleManager.FindByNameAsync(AdminAccount.Role) is null)
            {
                var adminRole = new IdentityRole(AdminAccount.Role);
                var result = await _roleManager.CreateAsync(adminRole);

                if (!result.Succeeded)
                {
                    var errorString = result.Errors.Select(e => e.Description);
                    throw new Exception(string.Join(Environment.NewLine, errorString));
                }
            }

            var adminUser = await _userManager.FindByEmailAsync(AdminAccount.Email);
            if (adminUser is null)
            {
                adminUser = new ApplicationUser { FullName = AdminAccount.Name };
                await _userStore.SetUserNameAsync(adminUser, AdminAccount.Email, CancellationToken.None);

                var emailStore = (IUserEmailStore<ApplicationUser>)_userStore;
                await emailStore.SetEmailAsync(adminUser, AdminAccount.Email, CancellationToken.None);

                var result = await _userManager.CreateAsync(adminUser, AdminAccount.Password);

                if (!result.Succeeded)
                {
                    var errorString = result.Errors.Select(e => e.Description);
                    throw new Exception(string.Join(Environment.NewLine, errorString));
                }
            }

            if (!await _context.Categories.AsNoTracking().AnyAsync())
            {
                await _context.Categories.AddRangeAsync(Category.GetSeedCategories());
                await _context.SaveChangesAsync();
            }


        }
    }
}
