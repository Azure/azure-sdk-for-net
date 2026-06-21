# Sample 1: Getting Started — DI Integration

This sample shows how to integrate agent optimization options with `IConfiguration` and dependency injection.

## Prerequisites

```dotnetcli
dotnet add package Azure.AI.AgentServer.Optimization.Configuration --prerelease
```

## Single-agent DI

Register the source, bind the `Agent` section into `IOptions<OptimizationOptions>`, and consume it like any other options class.

```C# Snippet:Configuration_ReadMe_SingleAgent
IConfiguration configuration = new ConfigurationBuilder()
    .AddOptimizationConfigSource()
    .Build();

IServiceCollection services = new ServiceCollection();
services.AddSingleton(configuration);
services.Configure<OptimizationOptions>(opts =>
    configuration.GetSection("Agent").Bind(opts));

using ServiceProvider provider = services.BuildServiceProvider();
OptimizationOptions options = provider.GetRequiredService<IOptions<OptimizationOptions>>().Value;

Console.WriteLine($"Source: {options.Source}");
Console.WriteLine($"Model: {options.Model}");
Console.WriteLine($"Instructions: {options.Instructions}");
```

## Multi-agent DI

Multiple agents in one host: each source uses an agent key, lookups read per-agent env vars, and named options keep them isolated.

```C# Snippet:Configuration_ReadMe_MultiAgent
IConfiguration configuration = new ConfigurationBuilder()
    .AddOptimizationConfigSource("triage-agent")
    .AddOptimizationConfigSource("billing-agent")
    .Build();

IServiceCollection services = new ServiceCollection();
services.AddSingleton(configuration);

// Named-options registrations — one per agent key.
services.Configure<OptimizationOptions>("triage-agent", opts =>
    configuration.GetSection("Agents:triage-agent").Bind(opts));
services.Configure<OptimizationOptions>("billing-agent", opts =>
    configuration.GetSection("Agents:billing-agent").Bind(opts));

using ServiceProvider provider = services.BuildServiceProvider();
IOptionsSnapshot<OptimizationOptions> snapshot =
    provider.CreateScope().ServiceProvider
        .GetRequiredService<IOptionsSnapshot<OptimizationOptions>>();

OptimizationOptions triage = snapshot.Get("triage-agent");
OptimizationOptions billing = snapshot.Get("billing-agent");
```

## Configure auth, timeouts, and fail-fast

Override defaults via a configuration callback. Combine `StrictMode` + `FailOnEmpty` for a true fail-fast startup contract.

```C# Snippet:Configuration_ReadMe_ConfigureOptions
IConfiguration configuration = new ConfigurationBuilder()
    .AddOptimizationConfigSource(options =>
    {
        // Authenticate the resolver API call. Use either Credential
        // (preferred — any Azure.Core TokenCredential, e.g.
        // DefaultAzureCredential) or TokenProvider (an
        // AuthenticationTokenProvider for System.ClientModel consumers).
        options.Credential = ResolveMyCredential();

        options.ResolverTimeout = TimeSpan.FromSeconds(10);
        options.StrictMode = true;    // rethrow resolver/parse errors
        options.FailOnEmpty = true;   // throw when no source matches
    })
    .Build();
```

## Bind without DI

If you already have an `IConfiguration` but no `IServiceCollection`, skip the registration step entirely and bind to a POCO directly.

```C# Snippet:Configuration_ReadMe_WithoutDI
// No DI container — just build IConfiguration and bind to a POCO.
IConfiguration configuration = new ConfigurationBuilder()
    .AddOptimizationConfigSource()
    .Build();

OptimizationOptions options = configuration.GetOptimizationOptions();

if (options.Source is not null)
{
    Console.WriteLine($"Loaded from: {options.Source}");
}
```

## Full end-to-end samples

For complete runnable applications:

- [DI TravelAgent](https://github.com/Azure/azure-sdk-for-net/tree/main/samples/agentserver/travel-agent-optimization-di) — uses `AddOptimizationConfigSource()` with `IConfiguration`
- [Procedural TravelAgent](https://github.com/Azure/azure-sdk-for-net/tree/main/samples/agentserver/travel-agent-optimization-procedural) — calls `LoadAsync()` directly
