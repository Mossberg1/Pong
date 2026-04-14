# Pong

A classic Pong game implementation in C# using MonoGame.

## Project Structure

- **Core/** - Game logic library containing:
  - `Ball.cs` - Ball physics and behavior
  - `Paddle.cs` - Paddle mechanics
  - `PlayingField.cs` - Game field boundaries and position
  - `CollisionManager.cs` - Collision detection
  - `PaddlePosition.cs` - Paddle position enum

- **Pong/** - Main game project with:
  - `Game1.cs` - MonoGame game class
  - `Program.cs` - Application entry point
  - `Content/` - Game assets (fonts, graphics)

## Building

This is a .NET 9 project that can be built using Visual Studio or the .NET CLI:

```
dotnet build
```

## Run

To run the game:

```
dotnet run --project Pong/Pong.csproj
```

## Requirements

- .NET 9
- MonoGame Framework