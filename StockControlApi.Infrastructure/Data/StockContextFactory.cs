using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using StockControlApi.Infrastructure.Data;

namespace StockControlApi.Infrastructure.Data;

public class StockContextFactory : IDesignTimeDbContextFactory<StockContext>
{
    public StockContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<StockContext>();
        optionsBuilder.UseSqlServer(
            "Server=localhost,1433;Database=StockControl;User Id=sa;Password=MssqlServer19@;TrustServerCertificate=True;",
            sqlOptions => sqlOptions.EnableRetryOnFailure(
            maxRetryCount: 5,              // Número máximo de tentativas
            maxRetryDelay: TimeSpan.FromSeconds(30), // Intervalo entre tentativas
            errorNumbersToAdd: null)       // Lista opcional de erros adicionais
        );

        return new StockContext(optionsBuilder.Options);
    }
}