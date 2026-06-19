# TravelAgent sample (DI / IConfiguration)

A minimal but realistic Foundry [hosted agent][foundry-hosted] built with the
[Microsoft Agent Framework][maf] — identical to the
[procedural sample](../../Azure.AI.AgentServer.Optimization/samples/TravelAgent/)
except it loads optimization config through `IConfiguration` DI integration.

## Key difference

This sample uses
[`Azure.AI.AgentServer.Optimization.Configuration`](../../README.md)
to wire optimization options through the standard ASP.NET configuration pipeline:

```csharp
// Register the optimization config source on the host builder
builder.Configuration.AddOptimizationConfigSource();

// Read the bound options — same OptimizationOptions type, populated by IConfiguration
OptimizationOptions config = builder.Configuration.GetOptimizationOptions();
```

Compare with the [procedural sample](../../Azure.AI.AgentServer.Optimization/samples/TravelAgent/Program.cs),
which calls `OptimizationOptionsLoader.LoadAsync()` directly.

## When to use which

| Approach | Use when |
|---|---|
| **This sample** (`AddOptimizationConfigSource`) | You have an ASP.NET host, want config layering with `appsettings.json` / env vars, or need `IOptionsMonitor<OptimizationOptions>` for reload semantics. |
| **Procedural sample** (`LoadAsync()`) | Console apps, scripts, or anywhere you want explicit control without DI plumbing. |

## Run locally

```pwsh
cd samples/TravelAgent

az login

$env:AZURE_AI_OPENAI_ENDPOINT       = "https://<your-account>.openai.azure.com/"
$env:AZURE_AI_MODEL_DEPLOYMENT_NAME = "gpt-4o-mini"
$env:OPTIMIZATION_LOCAL_DIR          = ".agent_configs"

dotnet run
```

Then `POST http://localhost:8088/responses` with
`{ "input": [{ "role": "user", "content": "Plan a 3-day budget trip from Seattle to Tokyo." }] }`.

## Deploy & optimize

Deployment and optimization workflows are identical to the procedural sample —
see its [README](../../Azure.AI.AgentServer.Optimization/samples/TravelAgent/README.md)
for `azd up`, `azd ai agent optimize`, and the full file map.

[foundry-hosted]: https://learn.microsoft.com/azure/ai-foundry/agents/concepts/hosted-agents
[maf]: https://learn.microsoft.com/dotnet/ai/microsoft-agent-framework
