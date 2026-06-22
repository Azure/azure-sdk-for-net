---
page_type: sample
languages:
- csharp
products:
- azure
- azure-ai-services
urlFragment: agentserver-optimization-procedural
name: Optimization-ready Hosted Agent (Procedural)
description: A Foundry-hosted travel agent using Azure.AI.AgentServer.Optimization to load optimized instructions via the procedural OptimizationOptionsLoader.LoadAsync() API.
---

# TravelAgent sample — Procedural

A minimal but realistic Foundry [hosted agent][foundry-hosted] built with the
[Microsoft Agent Framework][maf]. It plans budget-friendly trips, calling three
tools (`SearchFlights`, `GetHotelPrices`, `GetRandomDestination`) and returning
a structured itinerary.

This sample uses `OptimizationOptionsLoader.LoadAsync()` directly (procedural
style). For a DI/`IConfiguration` approach, see the
[travel-agent-optimization-di](https://github.com/Azure/azure-sdk-for-net/tree/main/samples/agentserver/travel-agent-optimization-di) sample.

This sample is deployable and optimizable end-to-end:

## File map

### Application code

| File | Role |
|---|---|
| `Program.cs` | ASP.NET host. Loads `OptimizationOptions` (from a local `.agent_configs/<candidate>/` directory selected by `OPTIMIZATION_CANDIDATE_ID`), wires up an Agent Framework `ChatClientAgent` with the loaded instructions + tools, and exposes the `/responses` endpoint via `TravelHandler`. |
| `TravelTools.cs` | The three tools the agent can call. Static methods decorated as Agent Framework tools — pure deterministic stubs, easy to swap for real APIs. |
| `TravelHandler.cs` | Maps incoming `/responses` requests to the agent and shapes the output. |
| `Azure.AI.AgentServer.Optimization.Samples.csproj` | Multi-targets `net8.0` and `net10.0`. |

### Agent definition

| File | Role |
|---|---|
| `agent.yaml` | Hosted-agent manifest describing the protocol (`responses`) and the environment variables the running container expects. Used by tooling that deploys hosted agents declaratively. |
| `.agent_configs/baseline/instructions.md` | The system prompt the agent starts with. Optimization candidates derive from this. |
| `.agent_configs/baseline/metadata.yaml` | Declares which `tools.json` / `skills/` files belong to the baseline config. (Note: the field is `tools_file`, plural.) |
| `.agent_configs/baseline/tools.json` | Tool schema list the optimizer can reason about when proposing tool-set variations. |
| `.agent_configs/baseline/skills/*/SKILL.md` | Optional "skills" the optimizer can compose into candidates (`budget-checker`, `date-formatter`). |
| `.agent_configs/.gitignore` | Whitelists only `baseline/` — any `cand_<id>/` directories produced by `azd ai agent optimize apply` are local artifacts and stay out of source control so anyone running the sample sees genuine improvements over the baseline. |

### Container / deployment

| File | Role |
|---|---|
| `Dockerfile` | Runtime-only image (base `mcr.microsoft.com/dotnet/aspnet:10.0`) — expects a pre-built `./publish/` and copies `.agent_configs/` alongside it. Listens on port 8088. |
| `.dockerignore` | Trims the build context (excludes `bin/`, `obj/`, `.azure/`, etc.). |
| `azure.yaml` | `azd` manifest. Declares the service (key must match `agent.name` in `eval.yaml`) and hooks `azd up`/`azd deploy` to `scripts/deploy-foundry-agent.ps1`. |
| `scripts/deploy-foundry-agent.ps1` | Five-step deploy: `dotnet publish` → `az acr build` → resolve digest → GET current agent version (to preserve env / CPU / memory) → POST a new version. All targets come from env vars (no hard-coded subscription / RG / agent name). |

### Optimization

| File | Role |
|---|---|
| `eval.yaml` | Optimization spec consumed by `azd ai agent optimize`: agent name (must match `azure.yaml` service key), eval dataset, evaluator, eval model, and the optimization (reasoning) model. |
| `datasets/smoke-core/smoke-core_dg.jsonl` | Travel-planning prompts used to score candidates. |
| `evaluators/smoke-core/rubric_dimensions.json` | Seven weighted rubric dimensions (budget compliance, alternative suggestions, time-zone accuracy, etc.) used to grade each response. |

## Run locally

```pwsh
$env:AZURE_AI_OPENAI_ENDPOINT       = 'https://<account>.openai.azure.com/'
$env:AZURE_AI_MODEL_DEPLOYMENT_NAME = 'gpt-4o-mini'
dotnet run -f net10.0
```

Then `POST http://localhost:8088/responses` with `{ "input": [{ "role": "user", "content": "Plan a 3-day budget trip from Seattle to Tokyo." }] }`.

## Deploy to Foundry

Configure your environment once, then `azd up`:

```pwsh
azd env set AZURE_AI_OPENAI_ENDPOINT       https://<account>.openai.azure.com/
azd env set AZURE_AI_MODEL_DEPLOYMENT_NAME gpt-4o-mini
azd env set AZURE_ACR_NAME                 <your-acr>
azd env set FOUNDRY_ENDPOINT               https://<resource>.services.ai.azure.com
azd env set FOUNDRY_PROJECT                <foundry-project>
azd env set FOUNDRY_AGENT                  travel-agent-sample

azd up
```

## Optimize

```pwsh
azd ai agent optimize --config eval.yaml
azd ai agent optimize apply --candidate cand_<id>
./scripts/deploy-foundry-agent.ps1   # rebuild + push the image with the new candidate baked in
```

Then set these env vars on the deployed agent to start serving the optimized
config via the resolver API (Priority 1):

```
OPTIMIZATION_JOB_ID=<optimization-job-id>
OPTIMIZATION_CANDIDATE_ID=cand_<id>
OPTIMIZATION_RESOLVE_ENDPOINT=<foundry-project-endpoint>
```

Alternatively, if you used `azd ai agent optimize apply --candidate`, the config
is baked into `.agent_configs/cand_<id>/` and only `OPTIMIZATION_CANDIDATE_ID`
needs to be set (the loader uses the local directory, Priority 3).

> ⚠️ The `azd ai agent optimize` CLI uses the `azure.yaml services.<name>` key
> to find the baseline config dir on disk. **The service key MUST equal
> `agent.name` in `eval.yaml`.** If they diverge you'll get
> `instruction is required for optimization`. Both ship as `travel-agent-sample`.

See the [DI sample](https://github.com/Azure/azure-sdk-for-net/tree/main/samples/agentserver/travel-agent-optimization-di) for `IConfiguration` integration.

[foundry-hosted]: https://learn.microsoft.com/azure/ai-foundry/agents/concepts/hosted-agents
[maf]: https://learn.microsoft.com/dotnet/ai/microsoft-agent-framework
