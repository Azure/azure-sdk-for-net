# Sample 1: Getting Started — Load Optimization Options

This sample shows how to load agent optimization options using the priority waterfall.

## Prerequisites

```dotnetcli
dotnet add package Azure.AI.AgentServer.Optimization --prerelease
```

## Load options with defaults

The loader resolves configuration from the highest-priority available source:
resolver API → inline JSON → local candidate directory → local baseline directory.

```C# Snippet:Optimization_ReadMe_Load
OptimizationOptions options = await OptimizationOptionsLoader.LoadAsync();

if (options is not null)
{
    Console.WriteLine($"Source: {options.Source}");
    Console.WriteLine($"Instructions: {options.Instructions}");
    Console.WriteLine($"Model: {options.Model}");
}
```

## Load options with a custom token provider

When the resolver API requires authentication, provide an `AuthenticationTokenProvider`:

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

## Use loaded options to configure an agent

Once loaded, use the options to configure your agent's system prompt, model, and tools:

```C# Snippet:Optimization_Sample1_UseOptions
OptimizationOptions options = await OptimizationOptionsLoader.LoadAsync();

string instructions = options?.Instructions ?? "You are a helpful assistant.";
string model = options?.Model ?? "gpt-4o-mini";

Console.WriteLine($"Using model: {model}");
Console.WriteLine($"Instructions length: {instructions.Length} chars");
```

## Full end-to-end samples

For complete runnable applications that deploy to Azure AI Foundry and run optimization:

- [Procedural sample](https://github.com/Azure/azure-sdk-for-net/tree/main/samples/agentserver/travel-agent-optimization-procedural) — calls `LoadAsync()` directly
- [DI sample](https://github.com/Azure/azure-sdk-for-net/tree/main/samples/agentserver/travel-agent-optimization-di) — integrates with `IConfiguration`
