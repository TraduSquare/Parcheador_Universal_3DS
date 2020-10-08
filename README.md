# TraduSquare Patcher

Generic patcher for fan-translations. It provides a cross-platform library and a
base UI.

## Platforms

Games from the following platforms are supported:

- Nintendo 3DS

## Build

Requirements:

- .NET Core 3.1 SDK

Steps:

```sh
# Run these command only the first time to get the build tools
dotnet tool restore
dotnet cake --bootstrap

# Build, test and stage artifacts
dotnet cake

# Just for building and testing
dotnet cake --target=BuildTest
```
