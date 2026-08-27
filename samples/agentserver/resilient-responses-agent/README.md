---
page_type: sample
languages:
- csharp
products:
- azure
- azure-ai-foundry
name: Resilient responses research agent sample for .NET
description: A long-running, crash-recoverable, steerable research agent hosted with the Azure.AI.AgentServer.Responses library for .NET.
---

# Resilient responses research agent sample

This sample hosts a long-running research agent with the
**`Azure.AI.AgentServer.Responses`** library and demonstrates the resilient
multi-turn task primitive over the Responses protocol: a durable, crash-recoverable,
steerable response that streams progress to the consumer over server-sent events
(SSE). It is a .NET port of the Python `resilient-responses-agent-demo`.

## What it demonstrates

1. **Long-running responses** run past the platform's sandbox-eviction window. The
   underlying resilient task's lease keep-alive cycle (PATCH every ~30 s of the 60 s
   lease) keeps the sandbox warm with zero client-side keepalive ingress.
2. **Crash recovery.** When the container dies, the platform restarts it and the
   resilient response resumes with `context.IsRecovery == true`. Recovery uses the
   one-`OutputItem`-per-subcall pattern: the persisted response *is* the watermark —
   the handler seeds its stream from `context.PersistedResponse`, resumes at
   `stream.Response.Output.Count`, and re-emits `response.in_progress` as the
   client-visible reset (the duplicate `response.created` is suppressed by the
   framework).
3. **Steering.** POSTing a follow-up turn with `previous_response_id` pointing at
   the running response queues the input; the agent winds down at the next phase
   boundary and re-enters with `context.IsSteeredTurn == true`.
4. **Operator cancel.** `POST /responses/{id}/cancel` forces the response to
   `status="cancelled"` regardless of what the handler emits.

## What the agent does

The agent runs up to 15 research phases of 4 chained sub-calls each
(research → critique → refine → synthesize), with intra-phase and inter-phase
cooldowns so a run spans past the sandbox-eviction window. Each sub-call is one
`OutputItem` with its own `yield stream.Checkpoint()`, so the persisted response is
a per-sub-call watermark: a crash recovers at the next unfinished sub-call (at most
one wasted sub-call).

`Program.cs` holds the host setup, the `DemoConfig` knobs, a lazily-resolved
upstream model client, and the `ResilientResearchHandler` with the checkpointed
15×4 loop. `TaskTrace.cs` holds an optional diagnostic raw `POST /tasks` trace.

### DEMO_MODE routes (credential-free)

When `DEMO_MODE=1`, these inputs exercise the framework without any model call:

| Input prefix | Behavior |
|---|---|
| `crash` / `kill` / `💥` | `Environment.Exit(137)` shortly after returning — simulates a container crash. |
| `__ECHO_INPUT__ <text>` | Completes with `INPUT_LEN=… INPUT_SHA256=…` of the input. |
| `__ECHO_CRASH__ <text>` | Echoes + `Checkpoint()`s a `PRECRASH_SHA256`, self-crashes, then on recovery re-echoes `RECOVERED_SHA256` (proves byte-identical durable recovery). |
| `__FAIL__ <text>` | Terminal `response.failed` with `error.code=server_error` (no crash). |
| `__TASKTRACE__` | Diagnostic A/B raw `POST /tasks` trace (see `TaskTrace.cs`). |

## Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download) or later
- An Azure AI Foundry project endpoint and a deployed model (for the research path;
  the credential-free DEMO_MODE routes run without one)
- (Optional) Azure CLI signed in (`az login`) for `DefaultAzureCredential`

The preview `Azure.AI.AgentServer.*` packages are not yet on nuget.org; the included
[`nuget.config`](https://github.com/Azure/azure-sdk-for-net/blob/main/samples/agentserver/resilient-responses-agent/nuget.config) restores them from the public Azure SDK dev feed.

## Run it locally

Start the host with the credential-free demo routes enabled:

```dotnetcli
DEMO_MODE=1 dotnet run
```

This starts the host on `http://localhost:8088`. In another terminal, drive it with
`curl`:

```bash
# Prove byte-identical durable recovery across a crash (no model call).
curl -N -X POST http://localhost:8088/responses \
  -H "Content-Type: application/json" \
  -d '{"input":"__ECHO_CRASH__ hello world","stream":true,"store":true,"background":true}'

# Reattach to a response's stream (replace {id}; skip events already seen).
curl -N "http://localhost:8088/responses/{id}?stream=true&starting_after=0"

# Cancel a response.
curl -X POST http://localhost:8088/responses/{id}/cancel
```

To run the real multi-phase research path, set a Foundry endpoint (and sign in for
`DefaultAzureCredential`):

```bash
export FOUNDRY_PROJECT_ENDPOINT="https://<your-foundry-project>.services.ai.azure.com/..."
export AZURE_AI_MODEL_DEPLOYMENT_NAME="gpt-5.4-nano"
dotnet run
```

## Configuration

All knobs are environment variables read at startup:

| Var | Default | Description |
|---|---|---|
| `FOUNDRY_PROJECT_ENDPOINT` | unset | Foundry project endpoint for the upstream model. Required for the research path. |
| `AZURE_AI_MODEL_DEPLOYMENT_NAME` | `gpt-5.4-nano` | Responses-API model deployment name. |
| `NUM_PHASES` | `15` | Research phases per run. |
| `CALLS_PER_PHASE` | `4` | Chained sub-calls per phase. |
| `TARGET_OUTPUT_TOKENS` | `1500` | `MaxOutputTokenCount` per sub-call. |
| `INTRA_PHASE_COOLDOWN_SEC` | `10` | Sleep between sub-calls. |
| `INTER_PHASE_COOLDOWN_SEC` | `20` | Sleep between phases. |
| `DEMO_MODE` | unset | Enables the `crash` / `__ECHO_*` / `__FAIL__` / `__TASKTRACE__` sentinels. Leave off in production. |

`Azure.AI.AgentServer.Core` auto-selects the hosted task provider when the platform
sets `FOUNDRY_HOSTING_ENVIRONMENT`, and the file-backed local provider otherwise —
no opt-in variable required.
