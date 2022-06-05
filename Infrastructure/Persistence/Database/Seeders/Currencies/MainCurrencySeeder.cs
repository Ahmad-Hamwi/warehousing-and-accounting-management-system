using Application.Services.Settings;
using Infrastructure.Persistence.Database.Models;

namespace Infrastructure.Persistence.Database.Seeders.Currencies;

public class MainCurrencySeeder : ISeeder
{
    public void Seed(ApplicationDbContext dbContext, IApplicationSettingsProvider settingsProvider)
    {
        var settings = settingsProvider.Get();

        var mainCurrency = dbContext.Currencies
            .FirstOrDefault(account => account.Id == settings.DefaultCurrencyId);
        
        if (mainCurrency != null)
        {
            return;
        }
        
        using (var transaction = dbContext.Database.BeginTransaction())
        {
            var entry = dbContext.Currencies.Add(new CurrencyDb()
            {
                Name = "Main Sales",
                Symbol = "SYP",
                Factor = 1
            });

            dbContext.SaveChanges();

            settings.DefaultCurrencyId = entry.Entity.Id;
            
            settingsProvider.Configure(settings);
            
            transaction.Commit();
        }
    }
}