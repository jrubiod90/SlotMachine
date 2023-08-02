using slotMachine.Entities;
using slotMachine.Services;

namespace slotMachine.UnitTests
{
    public class SymbolServiceTests
    {
        static readonly Symbol[] AllSymbols = new Symbol[]
        {           
            new Symbol("A", 0.45m, 0.4m),
            new Symbol("B", 0.35m, 0.6m),
            new Symbol("P", 0.15m, 0.8m),
            new Symbol("*", 0.05m, 0)
        };

        //NOTE: This test could fail by probability but just need to rerun the test to see if it all ok.
        [Fact]
        public void GetRandomSymbol_ShouldReturnSymbolBasedOnProbability()
        {
            // Arrange
            var symbolsService = new SymbolsService();
            Symbols.SetAllSymbols(AllSymbols);

            // Act
            var results = new List<Symbol>();
            for (int i = 0; i < 1000; i++) // Simulate getting 1000 random symbols
            {
                results.Add(symbolsService.GetRandomSymbol());
            }

            // Assert
            // Count occurrences of each symbol
            var symbolOccurrences = new Dictionary<string, int>();
            foreach (var symbol in Symbols.AllSymbols)
            {
                symbolOccurrences[symbol.Name] = results.Count(s => s.Name == symbol.Name);
            }

            // Assert the probabilities (allowing some margin of error)
            Assert.InRange(symbolOccurrences["A"], 420, 480); // 1000 * 0.45 = 450, allow some deviation (±30)
            Assert.InRange(symbolOccurrences["B"], 320, 380); // 1000 * 0.35 = 350, allow some deviation (±30)
            Assert.InRange(symbolOccurrences["P"], 130, 170); // 1000 * 0.15 = 150, allow some deviation (±20)
            Assert.InRange(symbolOccurrences["*"], 30, 70);   // 1000 * 0.05 = 50, allow some deviation (±20)
        }
    }
}
