# Azure.AI.AgentServer.Optimization client library for .NET

Client for resolving optimization configurations for Azure AI Hosted Agents. It uses the Foundry Optimization resolver API when a candidate ID is available and falls back to inline JSON from `OPTIMIZATION_CONFIG` when the API cannot provide a configuration.

Set `OPTIMIZATION_CANDIDATE_ID` to identify the candidate to resolve. Set `OPTIMIZATION_CONFIG` to provide an inline JSON fallback.

## Getting started

### Install the package

```dotnetcli
dotnet add package Azure.AI.AgentServer.Optimization --prerelease
```

### Prerequisites

- An [Azure subscription](https://azure.microsoft.com/free/dotnet/)
- An endpoint for your Azure AI Foundry project
- A `TokenCredential` for authenticating to the project

## Key concepts

### AgentOptimizationClient

The client resolves a candidate's deployment configuration. Construct it with your project endpoint and a `TokenCredential`, then call `ResolveOptions` or `ResolveOptionsAsync` with a candidate ID.

### CandidateDeployConfig

The resolved configuration includes the optimized `Instructions`, `Model`, and optional `Temperature`. If the resolver API cannot provide a configuration, the client can deserialize `OPTIMIZATION_CONFIG` as a fallback.

## Examples

### Resolve options

```C# Snippet:Optimization_ReadMe_Load
AgentOptimizationClient client = new(new Uri("https://my-project.services.ai.azure.com/api/projects/my-project"), new StubCredential());
string? candidateId = Environment.GetEnvironmentVariable("OPTIMIZATION_CANDIDATE_ID");
CandidateDeployConfig? options = await client.ResolveOptionsAsync(candidateId);

if (options is not null)
{
    Console.WriteLine($"Instructions: {options.Instructions}");
    Console.WriteLine($"Model: {options.Model}");
}
```

The snippets use a test-only `StubCredential` so they can be compiled without
accessing Azure. Replace it with a `TokenCredential` configured for your Foundry project,
such as `DefaultAzureCredential` from the `Azure.Identity` package.

### Resolve options for a candidate

```C# Snippet:Optimization_ReadMe_LoadWithCandidateId
string? candidateId = Environment.GetEnvironmentVariable("OPTIMIZATION_CANDIDATE_ID");
AgentOptimizationClient client = new(new Uri("https://my-project.services.ai.azure.com/api/projects/my-project"), new StubCredential());
CandidateDeployConfig? options = await client.ResolveOptionsAsync(candidateId);
```

## Troubleshooting

When troubleshooting configuration resolution, verify `OPTIMIZATION_CANDIDATE_ID` and
`OPTIMIZATION_CONFIG`. If the client falls back to inline JSON after an API failure, inspect
the returned `Response<CandidateDeployConfig>` for the failed response status and headers.

## Contributing

This project welcomes contributions and suggestions. See [CONTRIBUTING.md](https://github.com/Azure/azure-sdk-for-net/blob/main/CONTRIBUTING.md) for details.
