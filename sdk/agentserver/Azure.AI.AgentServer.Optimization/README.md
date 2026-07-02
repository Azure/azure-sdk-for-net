# Azure.AI.AgentServer.Optimization client library for .NET

Config loader for optimization-ready Azure AI Hosted Agents. Resolves optimized agent configurations from multiple sources using a priority waterfall:

1. **Resolver API** — `OPTIMIZATION_CANDIDATE_ID` + `OPTIMIZATION_RESOLVE_ENDPOINT`
2. **Inline JSON** — `OPTIMIZATION_CONFIG` environment variable
3. **Local candidate directory** — `OPTIMIZATION_CANDIDATE_ID` set and `OPTIMIZATION_LOCAL_DIR/<candidate_id>/` exists on disk
4. **Local baseline directory** — `OPTIMIZATION_LOCAL_DIR/baseline/` exists on disk
5. Returns `null` when no source matches.

## Getting started

### Install the package

```dotnetcli
dotnet add package Azure.AI.AgentServer.Optimization --prerelease
```

### Prerequisites

- An [Azure subscription](https://azure.microsoft.com/free/dotnet/)

## Key concepts

### OptimizationOptionsLoader

The main entry point. Call `Load()` or `LoadAsync()` to resolve an `OptimizationOptions` from the highest-priority available source.

### OptimizationOptions

A mutable, binder-friendly options object containing:
- `Instructions` — optimized system prompt
- `Model` — model deployment name
- `Temperature` — sampling temperature
- `Skills` — list of learned skills
- `ToolDefinitions` — tool definitions in OpenAI function-calling format

### OptimizationSkill

Represents a single learned skill with `Name`, `Description`, and `Body`.

## Examples

### Load options with defaults

```C# Snippet:Optimization_ReadMe_Load
OptimizationOptions options = await OptimizationOptionsLoader.LoadAsync();

if (options is not null)
{
    Console.WriteLine($"Source: {options.Source}");
    Console.WriteLine($"Instructions: {options.Instructions}");
    Console.WriteLine($"Model: {options.Model}");
}
```

### Load options with a custom token provider

```C# Snippet:Optimization_ReadMe_LoadWithTokenProvider
LoadOptions loadOptions = new LoadOptions
{
    TokenProvider = new MyTokenProvider(),
};

OptimizationOptions options = await OptimizationOptionsLoader.LoadAsync(loadOptions);
```

Where `MyTokenProvider` is your `AuthenticationTokenProvider` implementation:

```C# Snippet:Optimization_ReadMe_TokenProvider
private sealed class MyTokenProvider : AuthenticationTokenProvider
{
    public override GetTokenOptions CreateTokenOptions(IReadOnlyDictionary<string, object> properties) => new(properties);

    public override AuthenticationToken GetToken(GetTokenOptions options, CancellationToken cancellationToken) =>
        throw new NotImplementedException();

    public override ValueTask<AuthenticationToken> GetTokenAsync(GetTokenOptions options, CancellationToken cancellationToken) =>
        throw new NotImplementedException();
}
```

## Troubleshooting

When troubleshooting configuration resolution, set the environment variables for the source that you intend to use and inspect the `Source` property on the returned `OptimizationOptions` to confirm which source was selected.

## Contributing

This project welcomes contributions and suggestions. See [CONTRIBUTING.md](https://github.com/Azure/azure-sdk-for-net/blob/main/CONTRIBUTING.md) for details.
