# Tennis Kata

A full tennis match simulator built in C# following Test Driven 
Development (TDD) principles. Models game scoring, set scoring 
and full match scoring for a best-of-three match.

## How to build

dotnet build

## How to run the tests

dotnet test

## Rules implemented

### Game
- Points: Love, Fifteen, Thirty, Forty
- Symmetrical scores: Love-All, Fifteen-All, Thirty-All
- At 40-40: Deuce
- After Deuce: Advantage [Player], then win or back to Deuce
- Win condition: 4+ points and leading by 2

### Set
- First to 6 games, winning by 2
- At 5-5: play continues until one player leads by 2
- At 6-6: tiebreak
- Win condition: 6+ games and leading by 2, or tiebreak won

### Tiebreak
- Points counted as integers: 0, 1, 2, 3...
- First to 7 points, winning by 2
- At 6-6: play continues until one player leads by 2

### Match
- Best of three sets (first to 2 sets wins)
- Score displayed as full set scores: e.g. "6-3, 4-6, 7-6"

## Project structure

```
tennis_kata/
├── TennisKata.Logic/        # All game logic
│   ├── Player.cs            # Holds a player's name
│   ├── IGame.cs             # Shared interface for Game and TiebreakGame
│   ├── Game.cs              # Single game scoring (Love/Fifteen/Thirty/Forty)
│   ├── TiebreakGame.cs      # Tiebreak scoring (numeric points)
│   ├── Set.cs               # Set scoring, manages current game
│   └── Match.cs             # Match scoring, manages current set
└── TennisKata.Tests/        # xUnit test suite
    ├── GameTests.cs         # 15 tests
    ├── TiebreakGameTests.cs # 8 tests
    ├── SetTests.cs          # 10 tests
    └── MatchTests.cs        # 10 tests
```

## Design decisions

**Two-part development**
The project started as the original tennis kata, just the Game 
class with full TDD. Once that was complete I extended it to sets 
and matches.

**IGame interface**
When building Set I needed it to hold either a Game or a 
TiebreakGame without caring which. This made the IGame interface 
necessary. It was not planned upfront but emerged from a real 
design problem.

**TDD commit structure**
Each behavior was driven by a failing test committed before its 
implementation. The git history follows a strict 
test → feat → refactor cycle throughout.
