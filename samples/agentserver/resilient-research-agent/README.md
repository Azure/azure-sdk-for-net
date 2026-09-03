---
page_type: sample
languages:
- csharp
products:
- azure
- azure-ai-foundry
name: Resilient research agent (Invocations) sample for .NET
description: A long-running, crash-recoverable, steerable research agent hosted with the Azure.AI.AgentServer.Invocations library for .NET.
---

# Resilient research agent sample

This sample hosts a long-running research agent with the
**`Azure.AI.AgentServer.Invocations`** library and demonstrates the resilient-task
primitive: a durable, crash-recoverable, steerable task that streams progress to the
consumer over server-sent events (SSE). It is a .NET port of the Python
`azure-ai-agentserver-invocations` resilient research sample.

## What it demonstrates

1. **Long-running tasks** run past the platform's sandbox-eviction window. The
   framework's lease-renewal cycle (`PATCH .../tasks/{id}`, every ~30 s of the 60 s
   lease) keeps the sandbox warm with zero client-side keepalive ingress.
2. **Crash recovery.** When the container dies, the platform restarts it and the
   resilient task auto-resumes from its last checkpoint: the handler re-enters with
   `EntryMode == Recovered`, reads the persisted phase watermark, and resumes at the
   next unfinished sub-call. A `recovered` SSE event carries `completed_phases` to
   any reconnecting client.
3. **Steering.** POSTing a new turn on the running session queues the input and
   signals a cooperative cancel; the running turn winds down at the next phase
   boundary and re-enters with the queued input as a fresh turn.
4. **Operator cancel.** `POST /invocations/{id}/cancel` cooperatively winds down the
   active run and suspends with a clean watermark.

## What the agent does

The agent runs up to 15 research phases of 4 chained sub-calls each
(research → critique → refine → synthesize), streaming every token over SSE. The
handler checkpoints phase/sub-call watermarks to `context.Metadata` and flushes
after each sub-call, so a crash mid-phase recovers at the next unfinished sub-call.

`ResilientResearchHandler.cs` holds the invocations protocol (POST/GET/cancel) plus
the durable producer (`RunResearchAsync`). `Program.cs` holds the host setup, the
`DemoConfig` knobs, and a lazily-resolved upstream model client — either a real
Foundry Responses client or a synthetic-token fake model for offline runs.

### Event schema

The producer emits a flat event schema: `run_start`, `recovered`, `phase_start`,
`subcall_start`, `token`, `subcall_end`, `phase_end`, `cooldown`, `winding_down`,
`run_complete`, `run_failed`. Each event carries a monotonic `sequence_number` (the
SSE `id:` and reconnect cursor) plus `server_time_utc` / `server_uptime_sec`.

## Endpoints

| Route | Behavior |
|---|---|
| `POST /invocations` | Fire-and-forget dispatch of a research turn (or a steering input on an in-flight run). `TaskId = sessionId`, `InputId = invocationId`. Returns `202 Accepted` with `{status, invocation_id, session_id}`. |
| `GET /invocations/{id}?last_event_id=N` | SSE stream of the active run. Re-attaches to the existing stream after cursor `N`; never starts a run. `404` if the id was never seen; `event: gone` if the stream was destroyed (TTL). |
| `POST /invocations/{id}/cancel` | Operator cancel of the active run for this session. Returns `202` `{status:cancelled}` (or `404 not_found` if no active run). |

## Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download) or later
- (Optional) An Azure AI Foundry project endpoint and a deployed model, to run
  against a real upstream model instead of the offline synthetic-token model
- (Optional) Azure CLI signed in (`az login`) for `DefaultAzureCredential`

The preview `Azure.AI.AgentServer.*` packages are not yet on nuget.org; the included
[`nuget.config`](https://github.com/Azure/azure-sdk-for-net/blob/main/samples/agentserver/resilient-research-agent/nuget.config) restores them from the public Azure SDK dev feed.

## Run it locally

The agent runs fully offline with a file-backed task store and a synthetic-token
model — no Azure resources or credentials required:

```dotnetcli
dotnet run
```

This starts the host on `http://localhost:8088`. In another terminal, drive it with
`curl`:

```bash
# Start a research turn (the response headers carry the session and invocation ids).
curl -i -X POST http://localhost:8088/invocations \
  -H "Content-Type: application/json" \
  -d '{"message":"the history of resilient distributed systems"}'

# Stream the active run (replace {id} with the invocation id from the POST response).
curl -N "http://localhost:8088/invocations/{id}?last_event_id=0"

# Cancel the active run.
curl -X POST http://localhost:8088/invocations/{id}/cancel
```

To simulate a crash and watch recovery, set `DEMO_MODE=1` and POST
`{"message":"crash"}`: the process exits, and on the next start the resilient task
resumes from its last checkpoint. Reattach with the `GET` stream to observe the
`recovered` event.

To use a real upstream model instead of the offline fake, set
`FOUNDRY_PROJECT_ENDPOINT` (and sign in for `DefaultAzureCredential`):

```bash
export FOUNDRY_PROJECT_ENDPOINT="https://<your-foundry-project>.services.ai.azure.com/..."
export AZURE_AI_MODEL_DEPLOYMENT_NAME="gpt-5.4-nano"
dotnet run
```

## Configuration

All knobs are environment variables read at startup:

| Var | Default | Description |
|---|---|---|
| `FOUNDRY_PROJECT_ENDPOINT` | unset | Foundry project endpoint for the upstream model. When unset, the agent uses the offline synthetic-token model. |
| `AZURE_AI_MODEL_DEPLOYMENT_NAME` | `gpt-5.4-nano` | Responses-API model deployment name. |
| `USE_FAKE_MODEL` | unset | Force the synthetic-token model even when an endpoint is set. |
| `NUM_PHASES` | `15` | Research phases per run. |
| `CALLS_PER_PHASE` | `4` | Chained sub-calls per phase. |
| `TARGET_OUTPUT_TOKENS` | `1500` | Max tokens per sub-call. |
| `INTRA_PHASE_COOLDOWN_SEC` | `10` | Sleep between sub-calls. |
| `INTER_PHASE_COOLDOWN_SEC` | `20` | Sleep between phases. |
| `DEMO_MODE` | unset | Enables the `crash` message sentinel and demo routes. Leave off in production. |
| `AGENTSERVER_STATE_ROOT` | `~/.agentserver` | Root for the file-backed tasks/streams store when running off-platform. |

`Azure.AI.AgentServer.Core` auto-selects the hosted task provider when the platform
sets `FOUNDRY_HOSTING_ENVIRONMENT`, and the file-backed local provider otherwise —
no opt-in variable required.
