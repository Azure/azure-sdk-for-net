# Azure.AI.AgentServer.Optimization client library for .NET

Resolves optimized agent configurations from the optimization API, with an
`OPTIMIZATION_CONFIG` environment variable fallback.

## Getting started

### Install the package

```dotnetcli
dotnet add package Azure.AI.AgentServer.Optimization --prerelease
```

### Prerequisites

- An [Azure subscription](https://azure.microsoft.com/free/dotnet/)

## Key concepts

### AgentOptimizationClient

Call `ResolveOptions` or `ResolveOptionsAsync` with a candidate ID to resolve a
`CandidateDeployConfig`. The config includes instructions, model, and temperature.

## Examples

### Resolve a candidate

The following example assumes a `TokenCredential` named `credential` (for example,
an `Azure.Identity.DefaultAzureCredential`) and a project endpoint.

```C# Snippet:Optimization_ReadMe_Load
AgentOptimizationClient client = new(new Uri("https://my-project.services.ai.azure.com/api/projects/my-project"), credential);
string? candidateId = Environment.GetEnvironmentVariable("OPTIMIZATION_CANDIDATE_ID");
CandidateDeployConfig? options = await client.ResolveOptionsAsync(candidateId);

if (options is not null)
{
    Console.WriteLine($"Instructions: {options.Instructions}");
    Console.WriteLine($"Model: {options.Model}");
}
```

## Troubleshooting

Check the project endpoint, credential, candidate ID, and `OPTIMIZATION_CONFIG`
when troubleshooting configuration resolution.

## Contributing

This project welcomes contributions and suggestions. See [CONTRIBUTING.md](https://github.com/Azure/azure-sdk-for-net/blob/main/CONTRIBUTING.md) for details.
