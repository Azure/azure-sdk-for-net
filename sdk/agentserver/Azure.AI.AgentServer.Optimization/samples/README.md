---
page_type: sample
languages:
- csharp
products:
- azure
- ai
name: Azure.AI.AgentServer.Optimization samples for .NET
description: End-to-end Foundry-hosted Travel Agent that loads its optimized instructions, model, and tool descriptions from the optimization config waterfall.
---

# Azure.AI.AgentServer.Optimization Samples

One end-to-end **Travel Agent** sample showing how to ship a [Microsoft Agent
Framework][maf] `AIAgent` as a [Foundry-hosted agent][foundry-hosted] whose
**instructions, model, and tool descriptions come from the optimization config
waterfall** rather than being hard-coded.

This sample calls `OptimizationOptionsLoader.LoadAsync()` directly (procedural style).
For the DI / `IConfiguration` approach, see the
[Configuration package sample](../Azure.AI.AgentServer.Optimization.Configuration/samples/TravelAgent/).

## What's here

| Sample | Description |
|---|---|
| [`TravelAgent/`](TravelAgent/) | A runnable Foundry-hosted agent that serves the **Responses** protocol on `POST /responses`. The optimized `Instructions` / `Model` / `ToolDefinitions` are loaded by [`OptimizationOptionsLoader.LoadAsync()`][loader] at startup; the agent itself is a [Microsoft Agent Framework `AIAgent`][maf-aiagent] built from `AzureOpenAIClient.GetChatClient(...).AsIChatClient().AsAIAgent(...)`. Three real C# tools (`SearchFlights`, `GetHotelPrices`, `GetRandomDestination`) are registered via `AIFunctionFactory.Create` and match the names + parameter shapes declared in [`.agent_configs/baseline/tools.json`](TravelAgent/.agent_configs/baseline/tools.json). |

## The mental model

The agent is built **once at startup** from values that live in the optimization
config, not in source. That means a successful `azd ai agent optimize apply
--candidate <id>` rolls out new instructions and tool descriptions by changing
`OPTIMIZATION_CANDIDATE_ID` — no container rebuild and no code change.

```text
┌──────────────────────────┐    Priority 1: resolver API
│ OptimizationOptionsLoader│    Priority 2: OPTIMIZATION_CONFIG env var (inline JSON)
│   .LoadAsync()           │ →  Priority 3: OPTIMIZATION_LOCAL_DIR/<candidate_id>/
└──────────────────────────┘    Priority 4: OPTIMIZATION_LOCAL_DIR/baseline/
                                            │
                                            ▼
                                  OptimizationOptions { Instructions, Model, Skills, ToolDefinitions }
                                            │
                                            ▼
   AzureOpenAIClient                        │
        .GetChatClient(options.Model)       │
        .AsIChatClient()                    │
        .AsAIAgent(                         │
            name: "TravelPlanAgent",        │
            instructions: options.ComposeInstructions(),  ◄────┘
            tools: [ SearchFlights, GetHotelPrices, GetRandomDestination ])
                                            │
                                            ▼
   ResponsesServer.Run<TravelHandler>(...)  // serves POST /responses
```

The handler resolves the `AIAgent` (registered as a DI singleton) per request,
calls `agent.RunAsync(messages, session, ...)`, and streams the assistant text
back as a `TextResponse`.

## Run it locally

```pwsh
cd samples/TravelAgent

# Sign in for the DefaultAzureCredential path.
az login

# Point the agent at your Azure OpenAI account + deployment.
$env:AZURE_AI_OPENAI_ENDPOINT       = "https://<your-account>.openai.azure.com/"
$env:AZURE_AI_MODEL_DEPLOYMENT_NAME = "gpt-4o-mini"

# Use the bundled baseline config (.agent_configs/baseline/).
$env:OPTIMIZATION_LOCAL_DIR = ".agent_configs"

dotnet run
# In another shell:
curl -X POST http://localhost:5000/responses `
     -H 'Content-Type: application/json' `
     -d '{"input":[{"role":"user","content":"Find me flights from SEA to LAX on 2026-07-04"}]}'
```

To exercise an optimized candidate locally, copy a candidate directory into
`.agent_configs/<candidate_id>/` and set `OPTIMIZATION_CANDIDATE_ID` — the
loader prefers the candidate directory over `baseline/`.

## Deploy to Foundry

The sample is ready to deploy as a Foundry hosted agent with `azd`. The
following files cooperate:

| File | Role |
|---|---|
| [`TravelAgent/agent.yaml`](TravelAgent/agent.yaml) | Foundry hosted-agent manifest (env vars, scaling, protocol). |
| [`TravelAgent/azure.yaml`](TravelAgent/azure.yaml) | azd project descriptor that wires the post-deploy hook. |
| [`TravelAgent/Dockerfile`](TravelAgent/Dockerfile) | Runtime image. Expects `dotnet publish` output in `./publish/` (the deploy script produces it). |
| [`TravelAgent/.dockerignore`](TravelAgent/.dockerignore) | Keeps the ACR build context small. |
| [`TravelAgent/scripts/deploy-foundry-agent.ps1`](TravelAgent/scripts/deploy-foundry-agent.ps1) | Publishes, builds + pushes to ACR, and POSTs a new agent version pointing at the new image. |

Set the required env vars before running `azd up`:

```pwsh
azd env set AZURE_AI_OPENAI_ENDPOINT       https://<account>.openai.azure.com/
azd env set AZURE_AI_MODEL_DEPLOYMENT_NAME gpt-4o-mini
azd env set AZURE_ACR_NAME                 <your-acr>
azd env set FOUNDRY_ENDPOINT               https://<resource>.services.ai.azure.com
azd env set FOUNDRY_PROJECT                <foundry-project>
azd env set FOUNDRY_AGENT                  travel-agent-sample

azd up
```

After the agent is deployed and you've run an optimization job, apply a
candidate without rebuilding the container:

```pwsh
azd ai agent optimize apply --candidate cand_<id>
```

## Evaluate with Foundry Agent Optimization

The sample bundles a ready-to-run optimization eval config:

| File | Role |
|---|---|
| [`TravelAgent/eval.yaml`](TravelAgent/eval.yaml) | Eval definition: dataset, evaluators, eval model, max samples. |
| [`TravelAgent/datasets/smoke-core/`](TravelAgent/datasets/smoke-core/) | Travel-planning prompts in JSONL. |
| [`TravelAgent/evaluators/smoke-core/rubric_dimensions.json`](TravelAgent/evaluators/smoke-core/rubric_dimensions.json) | Weighted rubric (budget compliance, alternative suggestions, time-zone accuracy, etc.). |

Run the optimizer once the agent is deployed:

```pwsh
cd samples/TravelAgent
azd ai agent optimize --config eval.yaml
```

Each generated candidate appears under `.agent_configs/cand_<id>/` locally
(git-ignored, since results are user-specific — the sample ships only the
`baseline/` config so anyone running the optimizer sees fresh improvements
against the same starting point). The optimizer prints the winning
candidate's ID at the end. To serve it from the deployed agent, **rebuild +
push the image** (the candidate folder is baked into the container by the
Dockerfile) and then POST a new agent version with
`OPTIMIZATION_CANDIDATE_ID=cand_<id>` in its environment variables:

```pwsh
azd ai agent optimize apply --candidate cand_<id>   # writes the cand folder locally
./scripts/deploy-foundry-agent.ps1                   # rebuild + push image
# Then PATCH the agent's environment to point at the new candidate
# (see scripts/deploy-foundry-agent.ps1 for the API surface)
```

### Caveats validated against the live service

- The optimize CLI uses `azure.yaml`'s `services.<name>` to locate the baseline
  config dir on disk. **The service key MUST match `agent.name` in `eval.yaml`**
  (and the actual deployed agent name in the project), or you'll get
  `instruction is required for optimization`. The bundled `azure.yaml` does this
  correctly by using `travel-agent-sample` for both.
- `options.optimization_model` is **required**; the value must be the name of a
  model deployment that exists in your Foundry account (e.g. a `gpt-5.4`
  deployment). You can also override on the CLI with `--optimize-model <name>`.

## Using `Azure.AI.AgentServer.Optimization.Configuration` (DI integration)

This sample calls `OptimizationOptionsLoader.LoadAsync()` directly at startup —
the simplest path, no `Microsoft.Extensions.*` plumbing required. If you'd
rather bind options through `IConfiguration` so you get
`IOptionsMonitor<OptimizationOptions>` and reload semantics, see the
[Configuration package sample](../Azure.AI.AgentServer.Optimization.Configuration/samples/TravelAgent/).

[maf]: https://learn.microsoft.com/dotnet/ai/microsoft-agent-framework
[maf-aiagent]: https://learn.microsoft.com/dotnet/api/microsoft.agents.ai.aiagent
[foundry-hosted]: https://learn.microsoft.com/azure/ai-foundry/agents/concepts/hosted-agents
[loader]: ../src/OptimizationOptionsLoader.cs
