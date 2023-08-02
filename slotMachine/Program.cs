using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using slotMachine.Entities;
using slotMachine.Interfaces;
using slotMachine.Services;

/// <summary>
/// Represents the entry point and configuration for the slot machine console application.
/// </summary>
public class Program
{
    /// <summary>
    /// Read all symbols from configuration to get easily way to add symbols to users.
    /// </summary>
    /// <returns>All symbols in the configuration file.</returns>
    private static IEnumerable<Symbol> ReadSymbolsFromConfiguration(IConfiguration configuration)
    {
        var symbolConfigs = configuration.GetSection("SlotMachineSettings:Symbols").Get<List<Symbol>>();
        var symbols = new List<Symbol>();
        foreach (var symbolConfig in symbolConfigs)
        {
            symbols.Add(new Symbol(symbolConfig.Name, symbolConfig.Probability, symbolConfig.Coefficient));
        }
        return symbols;
    }
    /// <summary>
    /// Configures the dependency injection container and configuration for the application.
    /// </summary>
    /// <returns>The configured service provider and configuration.</returns>
    private static IHostBuilder CreateDefaultBuilder()
    {
        return Host.CreateDefaultBuilder()
            .ConfigureAppConfiguration(app =>
            {
                app.SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: false);
            })
            .ConfigureServices((hostContext, services) =>
            {
                IConfiguration configuration = hostContext.Configuration;

                // Read symbols from configuration and pass to the Symbols class
                IEnumerable<Symbol> symbols = ReadSymbolsFromConfiguration(configuration);
                Symbols.SetAllSymbols(symbols);

                services.AddSingleton<IGameLogicService, GameLogicService>()
                        .AddSingleton<IDisplayService, DisplayService>()
                        .AddSingleton<IMonetaryService, MonetaryService>()
                        .AddSingleton<ISymbolsService, SymbolsService>()
                        .AddSingleton<ISlotMachineGame, SlotMachineGame>()
                        .AddSingleton<IInputService, InputService>();
            });

    }

    /// <summary>
    /// Represents the entry point of the console application.
    /// </summary>
    /// <param name="args">Command-line arguments.</param>
    static void Main(string[] args)
    {

        var builder = CreateDefaultBuilder().Build();

        using IServiceScope serviceScope = builder.Services.CreateScope();
        IServiceProvider provider = serviceScope.ServiceProvider;

        var slotMachineGame = provider.GetRequiredService<ISlotMachineGame>();
        slotMachineGame.StartGame();
    }
}
