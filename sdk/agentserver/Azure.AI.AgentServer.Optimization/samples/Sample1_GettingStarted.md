# Sample 1: Getting Started — Resolve Optimization Config

This sample shows how to resolve an agent's optimization configuration using
`AgentOptimizationClient.ResolveOptions`.

## Prerequisites

```dotnetcli
dotnet add package Azure.AI.AgentServer.Optimization --prerelease
```

Set the environment variable that identifies the candidate to resolve:

```bash
export OPTIMIZATION_CANDIDATE_ID="<your-candidate-id>"
```

## Resolve config with the client

The client calls the optimization API with an env-var fallback
(`OPTIMIZATION_CONFIG` inline JSON) when the API is unreachable:

```C# Snippet:Optimization_ReadMe_Load
using Azure.AI.AgentServer.Optimization;
using Azure.Identity;

var client = new AgentOptimizationClient(
    new Uri("https://my-project.services.ai.azure.com/api/projects/my-project"),
    new DefaultAzureCredential());

string candidateId = Environment.GetEnvironmentVariable("OPTIMIZATION_CANDIDATE_ID");
CandidateDeployConfig? config = client.ResolveOptions(candidateId);

if (config is not null)
{
    Console.WriteLine($"Model: {config.Model}");
    Console.WriteLine($"Instructions: {config.Instructions}");
    Console.WriteLine($"Temperature: {config.Temperature}");
}
```

## Resolve config via IConfiguration (DI integration)

Instead of calling the client directly, you can plug in the optimization
source so the resolved config participates in the standard configuration
pipeline:

```C# Snippet:Optimization_ReadMe_IConfiguration
using Azure.AI.AgentServer.Optimization;
using Microsoft.Extensions.Configuration;

IConfiguration configuration = new ConfigurationBuilder()
    .AddOptimizationConfigSource("AgentOptimization")
    .Build();

CandidateDeployConfig? config = configuration.GetOptimizationConfig();
Console.WriteLine($"Model: {config?.Model}");
```

`"AgentOptimization"` is the configuration section that
`AgentOptimizationClientSettings` is bound from (endpoint, credential, options).
The resolved `CandidateDeployConfig` is projected into the default
`AgentOptimization` section so you can read it with `GetOptimizationConfig()`.

## Use resolved config to build an agent

Once resolved, use the config to set your agent's system prompt and model:

```C# Snippet:Optimization_Sample1_UseConfig
CandidateDeployConfig? config = client.ResolveOptions(candidateId);

string instructions = config?.Instructions ?? "You are a helpful assistant.";
string model = config?.Model ?? "gpt-4o-mini";

Console.WriteLine($"Using model: {model}");
Console.WriteLine($"Instructions length: {instructions.Length} chars");
```

## Full end-to-end samples

For complete runnable applications that deploy to Azure AI Foundry and run optimization:

- [Procedural sample](https://github.com/Azure/azure-sdk-for-net/tree/main/samples/agentserver/travel-agent-optimization-procedural) — calls `ResolveOptionsAsync()` directly
- [DI sample](https://github.com/Azure/azure-sdk-for-net/tree/main/samples/agentserver/travel-agent-optimization-di) — integrates with `IConfiguration`
