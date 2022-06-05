using Application.Services.Settings;

namespace Infrastructure.Persistence.Database.Seeders;

public interface ISeeder
{
    public void Seed(ApplicationDbContext dbContext, IApplicationSettingsProvider settingsProvider);
}