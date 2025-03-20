using Microsoft.EntityFrameworkCore;
using StockControlApi.Infrastructure.Data;

namespace StockControlApi.Infrastructure.Data.Extensions;

public static class StockContextExtensions
{
    public static void EnsureDatabaseMigrated(this StockContext context)
    {
        const int maxRetries = 5;
        const int delaySeconds = 10;

        for (int attempt = 1; attempt <= maxRetries; attempt++)
        {
            try
            {
                if (context.Database.GetPendingMigrations().Any())
                {
                    context.Database.Migrate();
                }
                return; // Se a migração for bem-sucedida, sai do loop
            }
            catch (Exception ex)
            {
                if (attempt == maxRetries)
                {
                    throw new Exception("Failed to apply database migrations after multiple attempts.", ex);
                }

                // Log the attempt (você pode usar um logger aqui)
                Console.WriteLine($"Attempt {attempt} failed: {ex.Message}. Retrying in {delaySeconds} seconds...");
                Thread.Sleep(delaySeconds * 1000);
            }
        }
    }
}