# Slot Machine 

This is a .NET console application for a simple slot machine game. The slot machine has configurable symbols with 
probability of appearance and win coefficient for each symbol, and it allows players to play by betting money and spinning the reels. This symbols are configurables in appsettings.json file with the following way:

{
  "SlotMachineSettings": {
    "Symbols": [
      {
        "Name": "A",
        "Probability": 0.45,
        "Coefficient": 0.4
      },
      {
        "Name": "B",
        "Probability": 0.35,
        "Coefficient": 0.6
      },
      {
        "Name": "P",
        "Probability": 0.15,
        "Coefficient": 0.8
      },
      {
        "Name": "*",
        "Probability": 0.05,
        "Coefficient": 0
      }
    ]
  }
}

This project have unitTests too. There is some tests that they are open to probability to pass (these tests check if spin the reel works properly). If this tests fails, please rerun it and it will pass correctly.

## Getting Started

Just Ctrl+F5 to build and execute the game.

### Prerequisites

- .NET SDK (Version 7.0) [Download .NET](https://dotnet.microsoft.com/download)

### Author

Jorge Rubio Díez
jrubiod90@gmail.com
