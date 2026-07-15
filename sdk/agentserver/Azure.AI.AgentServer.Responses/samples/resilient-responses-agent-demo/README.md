# Resilient Responses Research Agent — Demo (.NET)

> **▶ Run it locally (no Azure needed):** the verified kit in
> **[`local/`](local/README.md)** exercises a real
> stream → crash → recover → verify flow file-backed on your machine with **no
> credentials and no model** (`cd local && ./setup.sh && ./run.sh`).
> **Deploy it (hosted):** `azd up` this sample to drive it against a hosted
> Foundry deployment — resilient stream → reconnect → recover against the hosted
> task API.

A long-running research agent hosted on the Azure AI Hosted Agent platform via
the **`Azure.AI.AgentServer.Responses`** package. It demonstrates four platform
capabilities:

1. **Long-running responses run uninterrupted past the platform's
   sandbox-eviction window.** The underlying resilient multi-turn task's lease
   keep-alive cycle (PATCH every ~30 s, half the 60 s lease) refreshes the
   platform's sandbox idle-reclaim timer. A run spans several minutes with **zero
   client-side keepalive ingress** and the sandbox stays warm.

2. **Recovery from container crashes.** When the container dies (intentional
   crash or OOM), the platform's nanny worker restarts it within ~1 min **without
   any new client ingress**. The resilient response resumes with
   `context.IsRecovery == true`. Recovery uses the **one-`OutputItem`-per-subcall**
   pattern: the persisted response *is* the watermark — the handler seeds its
   stream from `context.PersistedResponse` and resumes at
   `stream.Response.Output.Count`, re-emitting `response.in_progress` as the
   client-visible reset (the duplicate `response.created` is suppressed by the
   framework — a reconnecting client never sees `created` twice).

3. **Steering.** POSTing a follow-up turn (with `previous_response_id` pointing at
   the still-running response) queues the input as a steering input. The agent
   observes `cancellationToken.IsCancellationRequested && context.PendingInputCount > 0`,
   winds down at the next phase boundary, and re-enters with
   `context.IsSteeredTurn == true` carrying the new input.

4. **Operator cancel.** `POST /responses/{id}/cancel` fires the cancellation
   signal + stamps `context.ClientCancelled`; the framework forces the response to
   `status="cancelled"` regardless of what the handler emits.

## What the agent does

A faithful port of the Python `resilient-responses-agent-demo`: **15 research
phases × 4 chained subcalls each** (research → critique → refine → synthesize, via
a real `gpt-5.4-nano` call), with intra-phase and inter-phase cooldowns so a run
spans well past the sandbox-eviction window. Each subcall is **one `OutputItem`**
with its own `yield stream.Checkpoint()`, so the persisted response is a
per-subcall watermark: a crash recovers at the next un-finished subcall (the
actively-streaming item was never closed, so it never entered the snapshot and is
re-run cleanly — at most one wasted subcall).

`Program.cs` is ~460 lines: the one-liner host setup, the `DemoConfig` knobs, a
lazily-resolved upstream model client, and the `ResilientResearchHandler` with the
15×4 checkpointed loop plus credential-free DEMO_MODE routes.

### DEMO_MODE routes (credential-free)

When `DEMO_MODE=1`, these inputs exercise the framework **without any model call**:

| Input prefix | Behavior |
|---|---|
| `crash` / `kill` / `💥` | `Environment.Exit(137)` shortly after returning — simulates a container crash. |
| `__ECHO_INPUT__ <text>` | Completes with `INPUT_LEN=… INPUT_SHA256=…` of the input. |
| `__ECHO_CRASH__ <text>` | Echoes + `Checkpoint()`s a `PRECRASH_SHA256`, self-crashes, then on recovery re-echoes `RECOVERED_SHA256` (proves byte-identical durable recovery). |
| `__FAIL__ <text>` | Terminal `response.failed` with `error.code=server_error` (no crash). |
| `__TASKTRACE__` | Diagnostic A/B raw `POST /tasks` trace (see `TaskTrace.cs`). |

## Packaging — the NuGet "package drop"

The `Azure.AI.AgentServer.{Core,Responses}` resilient + steerable surface is in
**preview** and not yet on NuGet.org. This sample consumes it from a **checked-in
package drop** — the .NET analog of the Python demo's wheel drop:

- Central drop: [`sdk/agentserver/packages/`](../../../packages) holds
  `Azure.AI.AgentServer.Core.1.0.0-beta.27.nupkg` and
  `Azure.AI.AgentServer.Responses.1.0.0-beta.7.nupkg` plus a
  [`README.md`](../../../packages/README.md) and `build-packages.sh` (maintainer refresh).
- This sample's [`build.sh`](build.sh) stages that drop into a per-sample
  `src/resilient-responses-agent-demo/packages/` (gitignored), and the project's
  [`nuget.config`](src/resilient-responses-agent-demo/nuget.config) resolves the
  preview packages from that local feed (everything else from nuget.org).

This makes the sample **portable**: copy it to any repo, drop the two `.nupkg`
files next to it, and it restores without a `ProjectReference` into this repo.

## Deploy

```bash
# 1. Stage the checked-in package drop into the docker build context.
./build.sh

# 2. Login + deploy.
azd auth login
azd up
```

`azd up` provisions infra (a `gpt-5.4-nano` deployment), remote-builds the
container (the Dockerfile `dotnet restore`s from the staged drop), ships it, and
prints the responses endpoint.

> **Distinct agent name.** This sample deploys as
> **`resilient-responses-agent-demo-dotnet`** so it does **not** collide with the
> Python `resilient-responses-agent-demo` when both target the same Foundry
> project. (The sample *directory* keeps the shared name.)

## demo-client.sh — command reference

Point it at your deployment with `ENDPOINT=…` (printed by `azd up`), or edit the
default near the top of the script.

| Command | What it does |
|---|---|
| `./demo-client.sh start "<topic>"` | `POST /responses` with `{stream:true, store:true, background:true}` + the topic, then attaches to the SSE stream. Writes `response_id` to `.demo-session`. |
| `./demo-client.sh stream` | Reattaches via `GET /responses/{id}?stream=true&starting_after=N`, skipping events already seen. |
| `./demo-client.sh steer "<topic>"` | POSTs a new response with `previous_response_id` pointing at the active one — queued as a steering input; the agent winds down and re-enters with the new topic. |
| `./demo-client.sh cancel` | `POST /responses/{id}/cancel` — the response transitions to `status=cancelled`. |
| `./demo-client.sh crash` | POSTs `{"input":"crash"}` — the agent (`DEMO_MODE=1`) calls `Environment.Exit(137)`; the nanny worker restarts it; `stream` after picks up the recovered run. |
| `./demo-client.sh delete` | `DELETE /responses/{id}`. |
| `./demo-client.sh status` | Local session state + the server's current snapshot. |
| `./demo-client.sh logs` | Tails container logs via `azd ai agent monitor --follow`. |
| `./demo-client.sh reset` | Clears `.demo-session`. |

## Local iteration

The **[`local/`](local/README.md)** kit runs this agent fully on your machine with
a file-backed state store (no hosted task API):

```bash
cd local
./setup.sh          # stages the drop + dotnet build -c Release
./run.sh            # credential-free crash -> recover -> verify (echo route)
# DEMO_ROUTE=research ./run.sh   # real multi-phase research (needs az login + a model)
```

## Battery (hosted conformance suite)

[`battery/`](battery) holds the language-agnostic HTTP conformance drivers ported
from the Python demo (`run_suite.py` T1–T16, `verify_crash.py`,
`verify_crash_steer.py`). They default to `AGENT=resilient-responses-agent-demo-dotnet`
and `MODEL=gpt-5.4-nano`, and drive a **deployed** agent (need `azd` + Azure creds).

## Configuration

All knobs are env vars read at startup (see [`.env.example`](src/resilient-responses-agent-demo/.env.example)).
Hosted defaults are set in [`azure.yaml`](azure.yaml); local defaults favor fast iteration.

| Var | Default | Description |
|---|---|---|
| `FOUNDRY_PROJECT_ENDPOINT` | (platform-injected) | Foundry project endpoint for the upstream `gpt-5.4-nano` calls. Set manually only for the local research path. |
| `AZURE_AI_MODEL_DEPLOYMENT_NAME` | `gpt-5.4-nano` | Responses-API model deployment name. |
| `NUM_PHASES` | `15` | Research phases per run. |
| `CALLS_PER_PHASE` | `4` | Chained subcalls per phase. |
| `TARGET_OUTPUT_TOKENS` | `1500` local / `150` hosted | `MaxOutputTokenCount` per subcall. |
| `INTRA_PHASE_COOLDOWN_SEC` | `10` local / `3` hosted | Sleep between subcalls. |
| `INTER_PHASE_COOLDOWN_SEC` | `20` local / `3` hosted | Sleep between phases. |
| `DEMO_MODE` | unset (`1` in the demo image) | Enables the `crash` / `__ECHO_*` / `__FAIL__` / `__TASKTRACE__` sentinels. Leave off in production. |

## Parity with the Python demo

This demo is ported from the Python `resilient-responses-agent-demo`. Notable
intentional divergences:

- **Packaging:** NuGet package drop (this doc) vs Python wheels — same concept.
- **Local backend selection:** `.NET` uses `FOUNDRY_HOSTING_ENVIRONMENT` unset;
  Python uses `AGENTSERVER_TASKS_BACKEND=local`.
- **Per-item metadata:** Python sets `message.internal_metadata`; .NET has no
  per-item metadata builder, so phase/subcall tags go on stream-level
  `stream.InternalMetadata` (observability-only).
