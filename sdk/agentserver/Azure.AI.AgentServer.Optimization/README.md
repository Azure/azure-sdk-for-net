# Azure.AI.AgentServer.Optimization client library for .NET

Config loader for optimization-ready Azure AI Hosted Agents. Resolves optimized agent configurations from multiple sources using a priority waterfall:

1. **Inline JSON** — `OPTIMIZATION_CONFIG` environment variable
2. **Remote API** — `OPTIMIZATION_CANDIDATE_ID` + `OPTIMIZATION_RESOLVE_ENDPOINT`
3. **Local directory** — `OPTIMIZATION_LOCAL_DIR` (defaults to `.agent_configs/`)
4. **None** — returns `null` if no config source is found

## Getting started

### Install the package

```dotnetcli
dotnet add package Azure.AI.AgentServer.Optimization --prerelease
```

### Prerequisites

- An [Azure subscription](https://azure.microsoft.com/free/dotnet/)
- .NET 8.0 or later

## Key concepts

### OptimizationConfigLoader

The main entry point. Call `LoadConfig()` or `LoadConfigAsync()` to resolve an `OptimizationConfig` from the highest-priority available source.

### OptimizationConfig

An immutable config object containing:
- `Instructions` — optimized system prompt
- `Model` — model deployment name
- `Temperature` — sampling temperature
- `Skills` — list of learned skills
- `ToolDefinitions` — tool definitions in OpenAI function-calling format

### OptimizationSkill

Represents a single learned skill with `Name`, `Description`, and `Body`.

## Examples

### Load config with defaults

```csharp
using Azure.AI.AgentServer.Optimization;

OptimizationConfig? config = await OptimizationConfigLoader.LoadConfigAsync();

if (config is not null)
{
    Console.WriteLine($"Source: {config.Source}");
    Console.WriteLine($"Instructions: {config.Instructions}");
    Console.WriteLine($"Model: {config.Model}");
}
```

### Load config with custom credential

```csharp
using Azure.Identity;
using Azure.AI.AgentServer.Optimization;

var options = new ConfigLoaderOptions
{
    Credential = new DefaultAzureCredential(),
    ConfigDirectory = "/path/to/configs",
};

OptimizationConfig? config = await OptimizationConfigLoader.LoadConfigAsync(options);
```

## Troubleshooting

Set the relevant environment variables for your intended source and check which source was resolved via the `Source` property on the returned config.

## Contributing

This project welcomes contributions and suggestions. See [CONTRIBUTING.md](https://github.com/Azure/azure-sdk-for-net/blob/main/CONTRIBUTING.md) for details.
