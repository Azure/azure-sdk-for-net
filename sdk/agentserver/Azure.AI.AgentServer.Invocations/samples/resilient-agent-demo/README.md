# Resilient Research Agent — Demo (.NET)

> **▶ Run it locally (no Azure needed):** the verified kit in
> **[`local/`](local/README.md)** drives a real
> stream → crash → recover → verify flow file-backed on your machine with **no
> credentials and no model** (`cd local && ./setup.sh && ./run.sh`). The demo
> ships a synthetic-token model so the full run / crash / recover / steer / cancel
> flow works offline.
> **Deploy it (hosted):** `./build.sh && azd up` this sample to drive it against a
> hosted Foundry deployment — resilient run → reconnect → recover → steer → cancel
> against the hosted task API.

A long-running research agent hosted on the Azure AI Hosted Agent platform via the
**`Azure.AI.AgentServer.Invocations`** package. It is a faithful .NET port of the
Python `azure-ai-agentserver-invocations` `resilient-agent-demo` and demonstrates
the same four platform capabilities of the Hosted Agent + resilient-task primitive:

1. **Long-running tasks run uninterrupted past the platform's sandbox-eviction
   window.** The framework's `PATCH .../tasks/{id}` lease-renewal cycle (every
   ~30 s, half of the 60 s lease) signals activity through the task-storage API,
   which refreshes the platform's sandbox idle-reclaim timer. A run spans several
   minutes with **zero client-side keepalive ingress** and the sandbox stays warm.

2. **Recovery from container crashes.** When the container dies (intentional crash
   or OOM), the platform's nanny worker restarts it within ~1 min **without any new
   client ingress**. The resilient task auto-resumes from its last checkpoint: the
   handler re-enters with `EntryMode == Recovered`, reads the persisted phase
   watermark, and resumes at the next un-finished sub-call. A `recovered` SSE event
   carries `completed_phases` to any (re)connecting client.

3. **Steering.** POSTing a new turn on the still-running session queues the input
   and signals a cooperative cancel. The running turn observes
   `cancellationToken.IsCancellationRequested` / `context.PendingInputCount > 0`,
   emits `winding_down cause=steering` at the next phase boundary, wipes its
   watermarks, and the framework re-enters with the queued input as a **fresh** turn
   (starting at phase 1 on the new topic).

4. **Operator cancel.** `POST /invocations/{id}/cancel` fires the cancellation
   signal on the active run; the handler winds down cooperatively
   (`winding_down cause=operator_cancel`) and suspends with a clean watermark.

## What the agent does

A faithful port of the Python `resilient-agent-demo`: up to **15 research phases × 4
chained sub-calls each** (research → critique → refine → synthesize), streaming
every token to the consumer over SSE. The handler checkpoints phase/sub-call
watermarks to `context.Metadata` and flushes **after each sub-call** — so a crash
mid-phase recovers at the next un-finished sub-call (worst case: the one that was
actively streaming is replayed). Between sub-calls and between phases the agent
sleeps for `INTRA_PHASE_COOLDOWN_SEC` / `INTER_PHASE_COOLDOWN_SEC` and emits a
`cooldown` event so the terminal shows a low-key "cooling down…" line instead of
going silent.

> **Cadence.** The committed [`agent.yaml`](src/resilient-research-agent/agent.yaml)
> ships a fast **battery-gate** cadence (3 phases, 1s cooldowns) so crash/steer/cancel
> runs reach a terminal state in under a minute — this is what the hosted resilience
> battery exercises. For the **long-running showcase** (a single run that outlives the
> platform's ~15-min sandbox-eviction window purely via lease keep-alive, matching the
> Python demo's committed cadence), override to `NUM_PHASES=15`,
> `INTRA_PHASE_COOLDOWN_SEC=30`, `INTER_PHASE_COOLDOWN_SEC=30`,
> `TARGET_OUTPUT_TOKENS=1500` and drive it with `demo-client.sh`.

`ResilientResearchHandler.cs` holds the invocations protocol (POST/GET/cancel) plus
the durable producer (`RunResearchAsync`); `Program.cs` holds the one-liner host
setup, the `DemoConfig` knobs, and a lazily-resolved upstream model client (real
Foundry Responses client, or a **synthetic-token fake model** for offline runs).

### Event schema (identical to Python)

The producer emits the same flat event schema as the Python `deep_research` task:
`run_start`, `recovered`, `phase_start`, `subcall_start`, `token`, `subcall_end`,
`phase_end`, `cooldown`, `winding_down`, `run_complete`, `run_failed`. Each event
carries a monotonic `sequence_number` (the SSE `id:` and reconnect cursor) plus
`server_time_utc` / `server_uptime_sec`.

### DEMO_MODE crash sentinel (credential-free)

When `DEMO_MODE=1`, a `POST /invocations {"message": "crash"}` (or `kill` / `💥`)
makes the process `Environment.Exit(137)` shortly after returning `202` — simulating
a container crash — **without** starting a task, so an already-running task is the
one that recovers on restart. Leave `DEMO_MODE` off in production.

## Session & sandbox model

A **session** identifies a **sandbox** (the container instance your agent runs in).
The platform routes requests to the right sandbox for you:

- **`POST /invocations`** — if you **don't** supply a session id, the platform
  allocates one and returns the **session id and invocation id in the response
  headers**. You **can** supply your own session id via the `agent_session_id`
  query parameter (the SDK's `SessionIdResolver` prioritizes it). Reusing the same
  session id on a follow-up POST routes back to the same sandbox — that's how a
  steering turn reaches the still-running task.
- **`GET /invocations/{id}` and `POST /invocations/{id}/cancel`** — you do **not**
  pass a session id. You pass the **invocation id**, and the platform ensures you
  land on the same session/sandbox that owns that invocation.

Inside the container the framework reads the pinned session id from
`FOUNDRY_AGENT_SESSION_ID` (`FoundryEnvironment.SessionId`); the handler uses it as
the durable `TaskId` (one resilient task per session) and the invocation id as the
per-turn `InputId`. Locally (where there is no platform proxy) the session id is
synthesized so the same one-task-per-session model can be exercised offline.

## Endpoints

| Route | Behavior |
|---|---|
| `POST /invocations` | Fire-and-forget dispatch of a research turn (or a steering input on an in-flight run). `TaskId = sessionId`, `InputId = invocationId`. Returns `202 Accepted` with `{status, invocation_id, session_id}`. |
| `GET /invocations/{id}?last_event_id=N` | SSE stream of the active run. Re-attaches to the **existing** stream after cursor `N`; never starts a run. `404` if the id was never seen; `event: gone` if the stream was destroyed (TTL). |
| `POST /invocations/{id}/cancel` | Operator cancel of the active run for this session. Returns `202` `{status:cancelled}` (or `404 not_found` if no active run). |

## Packaging — the NuGet "package drop"

The `Azure.AI.AgentServer.{Core,Invocations}` resilient + steerable surface is in
**preview** and not yet on NuGet.org. This sample consumes it from a **checked-in
package drop** — the .NET analog of the Python demo's wheel drop:

- Central drop: [`sdk/agentserver/packages/`](../../../packages) holds the preview
  `Azure.AI.AgentServer.Core` and `Azure.AI.AgentServer.Invocations` `.nupkg` files
  plus a [`README.md`](../../../packages/README.md) and `build-packages.sh`
  (maintainer refresh).
- This sample's [`build.sh`](build.sh) stages that drop into a per-sample
  `src/resilient-research-agent/packages/` (gitignored), and the project's
  [`nuget.config`](src/resilient-research-agent/nuget.config) resolves the preview
  packages from that local feed (everything else from nuget.org).

This makes the sample **portable**: copy it to any repo, drop the `.nupkg` files
next to it, and it restores without a `ProjectReference` into this repo.

## Deploy

```bash
# 1. Stage the checked-in package drop into the docker build context.
./build.sh

# 2. Login + deploy.
azd auth login
azd up
```

> **If `azd auth login` is blocked** (e.g. org policy disables the device-code flow),
> point azd at your existing Azure CLI session instead:
>
> ```bash
> az login                                  # once, interactively
> azd config set auth.useAzCliAuth true     # azd reuses the az CLI token
> export AZURE_CONFIG_DIR="$HOME/.azure"
> az account set --subscription <sub-id>
> azd up                                    # or: azd deploy for updates
> ```

`azd up` provisions infra (a `gpt-5.4-nano` deployment), remote-builds the
container (the Dockerfile `dotnet restore`s from the staged drop), ships it, and
prints the invocations endpoint.

> **Distinct agent name.** This sample deploys as
> **`resilient-research-agent-dotnet`** so it does **not** collide with the Python
> `resilient-research-agent` when both target the same Foundry project. (The sample
> *directory* keeps the shared name.)

## demo-client.sh — command reference

Point it at your deployment with `ENDPOINT=…` (printed by `azd up`), or edit the
default near the top of the script. Each command operates on a single session
tracked locally in `.demo-session`.

| Command | What it does |
|---|---|
| `./demo-client.sh start "<topic>"` | Allocates a new session id, `POST /invocations` with the topic, then attaches to the SSE stream. |
| `./demo-client.sh stream` | Reattaches via `GET /invocations/{id}?last_event_id=N`, skipping events already seen. |
| `./demo-client.sh steer "<topic>"` | Reuses the session and POSTs a new turn — queued as a steering input; the agent winds down at the next phase boundary and re-enters on the new topic. |
| `./demo-client.sh cancel` | `POST /invocations/{id}/cancel` — the run winds down (`winding_down cause=operator_cancel`) and suspends. |
| `./demo-client.sh crash` | POSTs `{"message":"crash"}` — the agent (`DEMO_MODE=1`) `Environment.Exit(137)`s; the nanny worker restarts it; `stream` after picks up the recovered run. |
| `./demo-client.sh status` | Local session state (`SESSION_ID`, `INV_ID`, `LAST_EVENT_ID`). |
| `./demo-client.sh logs` | Tails container logs via `azd ai agent monitor --follow`. |
| `./demo-client.sh reset` | Clears `.demo-session`. |

## Local iteration

The **[`local/`](local/README.md)** kit runs this agent fully on your machine with
a file-backed state store (no hosted task API) and a synthetic-token model (no
credentials):

```bash
cd local
./setup.sh          # stages the drop + dotnet build -c Release
./run.sh            # credential-free run -> crash -> recover -> verify
```

## Configuration

All knobs are env vars read at startup (see
[`.env.example`](src/resilient-research-agent/.env.example)). Hosted defaults are set
in [`agent.yaml`](src/resilient-research-agent/agent.yaml); local defaults favor fast
iteration.

| Var | Default (hosted) | Description |
|---|---|---|
| `FOUNDRY_PROJECT_ENDPOINT` | (platform-injected) | Foundry project endpoint for the upstream `gpt-5.4-nano` calls. When unset (and `USE_FAKE_MODEL != 1` is not forced), the agent uses the **synthetic-token fake model** so it runs offline. |
| `AZURE_AI_MODEL_DEPLOYMENT_NAME` | `gpt-5.4-nano` | Responses-API model deployment name. |
| `USE_FAKE_MODEL` | unset | Force the synthetic-token model even when an endpoint is set (used by the local kit + CI). |
| `NUM_PHASES` | `3` (agent.yaml) / `15` code-default | Research phases per run. The committed `agent.yaml` uses a fast **battery-gate** cadence so a full run reaches a terminal state in well under a minute; raise to `15` for the long-running showcase (see [What the agent does](#what-the-agent-does)). |
| `CALLS_PER_PHASE` | `4` | Chained sub-calls per phase. |
| `TARGET_OUTPUT_TOKENS` | `150` (agent.yaml) / `1500` code-default | Max tokens per sub-call. |
| `INTRA_PHASE_COOLDOWN_SEC` | `1` (agent.yaml) / `10` code-default | Sleep between sub-calls. |
| `INTER_PHASE_COOLDOWN_SEC` | `1` (agent.yaml) / `20` code-default | Sleep between phases. |
| `DEMO_MODE` | `1` (set in the demo Dockerfile) | Enables the `crash` message sentinel + demo routes. Leave off in production. |
| `AGENTSERVER_STATE_ROOT` | (local only) | Root for the file-backed tasks/streams store when running off-platform. |

> **Local vs hosted backend selection.** `Azure.AI.AgentServer.Core` auto-selects
> the `HostedTaskProvider` when the platform sets `FOUNDRY_HOSTING_ENVIRONMENT` and
> the file-backed `LocalFileTaskProvider` otherwise — no opt-in env var required.
> (Unlike the Python demo, .NET does **not** use an `AGENTSERVER_TASKS_BACKEND`
> variable.)

## Parity with the Python demo

This demo is ported from the Python `resilient-agent-demo`. Notable intentional
divergences: NuGet package drop vs wheels; `FOUNDRY_HOSTING_ENVIRONMENT`-driven
backend selection vs `AGENTSERVER_TASKS_BACKEND`; the offline synthetic-token
model; and the deployed agent name `resilient-research-agent-dotnet`.
