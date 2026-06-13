# Azure.AI.AgentServer.Optimization.Configuration client library for .NET

A `Microsoft.Extensions.Configuration` source for optimization-ready Azure AI Hosted Agents. Wraps [`OptimizationOptionsLoader`][loader] so the same 4-priority resolution waterfall — resolver API, inline JSON, local candidate directory, local baseline directory — flows into the standard `IConfiguration` tree and is bindable like any other settings:

1. **Resolver API** — `OPTIMIZATION_CANDIDATE_ID` + `OPTIMIZATION_RESOLVE_ENDPOINT` → HTTP GET
2. **Inline JSON** — `OPTIMIZATION_CONFIG` environment variable
3. **Local candidate directory** — `OPTIMIZATION_CANDIDATE_ID` set and `OPTIMIZATION_LOCAL_DIR/<candidate_id>/` exists on disk
4. **Local baseline directory** — `OPTIMIZATION_LOCAL_DIR/baseline/` exists on disk
5. Returns nothing when no source matches.

Single-agent hosts project values into the `Agent` section. Multi-agent hosts project per-agent values into `Agents:<agentKey>` and use per-agent suffixed env vars (`OPTIMIZATION_<VAR>__<CANONICAL_KEY>`).

## Getting started

### Install the package

```dotnetcli
dotnet add package Azure.AI.AgentServer.Optimization.Configuration --prerelease
```

### Prerequisites

- An [Azure subscription](https://azure.microsoft.com/free/dotnet/)

## Key concepts

### AgentConfigurationSource

The `IConfigurationSource` registered by `AddOptimizationConfigSource`. On each `IConfiguration` reload it invokes the underlying loader and flattens the resolved `OptimizationOptions` into the configuration dictionary.

### AgentConfigurationOptions

Knobs for the source: `AgentKey`, `SectionName`, `Credential`, `TokenProvider`, `ResolverTimeout`, `StrictMode`, `FailOnEmpty`, and `FallbackToUnsuffixedEnvVars`.

### OptimizationOptions

The bound POCO (re-exported from `Azure.AI.AgentServer.Optimization`). Contains `Instructions`, `Model`, `Temperature`, `Skills`, `ToolDefinitions`, plus a diagnostic `Source` property indicating which priority won.

## Examples

### Single-agent DI

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

### Multi-agent DI

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

### Configure the source (auth, timeouts, fail-fast)

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

### Bind without DI

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

### Skip `IConfiguration` entirely

When you do not have (or want) a configuration pipeline at all — console apps, AWS Lambda, isolated worker functions — call the underlying loader directly. The waterfall behavior is identical; you just lose `IConfiguration` reload semantics.

```C# Snippet:Configuration_ReadMe_DirectLoader
// Skip Microsoft.Extensions.Configuration entirely and call the loader
// directly. Useful for console apps, AWS Lambdas, or anywhere you do
// not have an IConfiguration pipeline.
OptimizationOptions options = OptimizationOptionsLoader.Load();

if (options is not null)
{
    Console.WriteLine($"Source: {options.Source}");
}
```

## Troubleshooting

The bound `OptimizationOptions.Source` property reports which priority resolved the configuration (`ResolverApi`, `InlineJson`, `LocalCandidateDirectory`, `LocalBaselineDirectory`, or unset). Enable `StrictMode` to surface resolver failures and JSON parse errors as exceptions instead of silently falling through to the next priority; combine with `FailOnEmpty` to throw on app startup when nothing matched.

## Contributing

This project welcomes contributions and suggestions. See [CONTRIBUTING.md](https://github.com/Azure/azure-sdk-for-net/blob/main/CONTRIBUTING.md) for details.

[loader]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/agentserver/Azure.AI.AgentServer.Optimization
