# Parity: .NET `resilient-agent-demo` vs Python

This document records the behavior-by-behavior parity of the .NET port against the
Python source of truth:
`azure-sdk-for-python@feature/agentserver-durable-agent-demo`
`sdk/agentserver/azure-ai-agentserver-invocations/samples/resilient-agent-demo`.

## Handler / protocol (ResilientResearchHandler.cs ⇔ app.py + agent.py)

| Behavior | Python | .NET | Parity |
|---|---|---|---|
| `POST /invocations` dispatch | `deep_research.start(task_id=session_id, input={invocation_id,...})`, return 202 | `invoker.StartAsync("research", …, RunOptions{TaskId=sessionId, InputId=invocationId})`, return 202 | ✅ |
| `task_id == session_id` | one `@multi_turn_task` chain per session | `TaskId = context.SessionId` | ✅ |
| Stream id = per-turn `invocation_id` | `streams.get_or_create(ctx.input["invocation_id"])` | `registry.GetOrCreateAsync(invId)` where `invId == context.InvocationId` | ✅ |
| Reserve stream before task start | yes (avoid GET 404 race) | `registry.GetOrCreateAsync(invId)` before `StartAsync` | ✅ |
| Steering on active session | same `task_id` → framework enqueues as steering input | same `TaskId` → engine enqueues as steering | ✅ |
| Crash trigger | `not recovery and message in {crash,kill,💥}` → `os._exit(137)` after delay; no task started | `DemoMode && topic in {crash,kill,💥}` → `Environment.Exit(137)` after 300 ms; no task started | ✅ |
| `GET /invocations/{id}?last_event_id=N` | `(await streams.get(id)).subscribe(after=N)` → SSE; 404 if unseen; 410 if TTL-destroyed | `registry.GetAsync(id).Subscribe(after)` → SSE; `404 not_found` if unseen; `event: gone` if destroyed | ✅ (410 → `event: gone` frame) |
| `POST /invocations/{id}/cancel` | `get_active_run(task_id, invocation_id).cancel()` | `invoker.GetActiveRunAsync("research", taskId, invocationId).CancelAsync()` | ✅ |
| Cursor field | `sequence_number` (SSE `id:` + reconnect cursor) | `SequenceNumber` (same) | ✅ |
| Resume seq on recovery | `stream.last_cursor()` rehydrates counter | `stream.GetLastCursorAsync()` | ✅ |
| Event schema | `run_start / recovered / phase_start / subcall_start / token / subcall_end / phase_end / cooldown / winding_down / run_complete / run_failed` | identical flat schema (`ResearchEvent`) | ✅ |
| Per-event server clock | `server_time_utc`, `server_uptime_sec` | same | ✅ |
| Checkpoint per sub-call | `ctx.metadata` watermark + `flush()` after each subcall | `context.Metadata` watermarks + `FlushAsync()` after each subcall | ✅ |
| Watermarks | `completed_phases`, `in_progress_phase`, `completed_subcalls` | same three keys | ✅ |
| Recovery resume point | next un-finished sub-call | next un-finished sub-call | ✅ |
| Steering wind-down | `winding_down cause=steering` at next phase boundary, then re-enter fresh | `winding_down cause=steering`, wipe watermarks, re-enter at phase 1 | ✅ (see divergence #1) |
| Steered re-entry starts fresh | `_finish_turn` wipes `completed_phases`/`in_progress_phase`/`completed_subcalls` | `FinishTurnAsync` removes the three keys **+ explicit `FlushAsync(None)`** | ✅ |
| Operator cancel wind-down | `winding_down cause=operator_cancel`, suspend | same, then `FinishTurnAsync` wipes watermarks; task suspended | ✅ |
| Cooldown events | `cooldown` at start of intra/inter pause | `cooldown` (same) | ✅ |
| Config knobs | `NUM_PHASES`, `CALLS_PER_PHASE`, `TARGET_OUTPUT_TOKENS`, `INTRA/INTER_PHASE_COOLDOWN_SEC`, `DEMO_MODE` | identical env names in `DemoConfig` | ✅ |

## Session / sandbox routing

The platform routes by **session (= sandbox)** on POST and by **invocation id** on
GET/cancel:

| Concern | Python | .NET | Parity |
|---|---|---|---|
| POST session id | optional `agent_session_id` query param; else platform allocates + returns in headers | `SessionIdResolver`: `agent_session_id` query → `FOUNDRY_AGENT_SESSION_ID` env → generated UUID | ✅ |
| GET/cancel session | **not** supplied by caller; platform routes by invocation id to the owning sandbox | inside the sandbox, session resolves from `FOUNDRY_AGENT_SESSION_ID`; the platform proxy already delivered the request to the right container | ✅ |

## Intentional divergences (language / platform)

| # | Concern | Python | .NET | Why |
|---|---|---|---|---|
| 1 | Steering cancel model | **cooperative** — sets `ctx.cancel`, checked at phase/cooldown boundaries; a mid-await `CancelledError` propagates *without* emitting `winding_down` (`except Exception` doesn't catch `BaseException`) | **hard-cancel** ct — the fake/real model `yield break`s on ct; the subcall's `FlushAsync(ct)` throws `OperationCanceledException`, caught → `WindDownAsync` emits `winding_down` even mid-phase, then always runs `FinishTurnAsync` | .NET ct is a hard cancel. The .NET path emits `winding_down` on **every** steer/cancel (arguably better observability than Python's mid-await silent propagation) and **always** wipes watermarks so a steered re-entry restarts at phase 1. |
| 2 | Wind-down frame close | relies on framework auto-flush on suspend | emits terminal `winding_down` with `close:true` (routes through `CancellationToken.None`), wrapped in try/catch so `FinishTurnAsync` always runs | On a cancelled ct, emitting with `close:false` would `throw` at `ReplayEventStream.EmitAsync` and skip the watermark wipe. `close:true` atomically emits-and-closes via a fresh token. See "steering-resilience fix" below. |
| 3 | Preview package delivery | wheel drop `sdk/agentserver/wheels/` | NuGet package drop `sdk/agentserver/packages/` (+ `nuget.config` local feed) | Same concept, ecosystem-native. Keeps the sample portable to other repos with no `ProjectReference`. |
| 4 | Local backend selection | `AGENTSERVER_TASKS_BACKEND=local` | `FOUNDRY_HOSTING_ENVIRONMENT` unset (`FoundryEnvironment.IsHosted == false`) | .NET SDK is env-driven via `FoundryEnvironment`; there is no `AGENTSERVER_TASKS_BACKEND`. |
| 5 | Offline model | local kit needs `az login` + a real model | ships a **synthetic-token fake model** (`USE_FAKE_MODEL=1`, or auto when `FOUNDRY_PROJECT_ENDPOINT` unset) | Lets the full run/crash/recover/steer/cancel flow run **credential-free** locally + in CI. |
| 6 | Deployed agent name | `resilient-research-agent` | `resilient-research-agent-dotnet` | Avoids a name collision when both deploy to the same Foundry project. |
| 7 | Deploy manifest shape | `agent.yaml` + Python azd | inline `azure.yaml` (C# `microsoft.foundry` provider, per the canonical C# HelloWorld template) | Matches the authoritative C# hosted-agent template. |
| 8 | Model | `gpt-4o` | `gpt-5.4-nano` | Matches the target Canada Central project + the Python battery. |

## The steering-resilience fix (root cause + resolution)

On the steer/cancel wind-down path, the handler's `ct` is already cancelled
(steering nudges the running turn by cancelling its handler token). The demo's
`emit` closure maps `close ? CancellationToken.None : ct`, and
`ReplayEventStream.EmitAsync` calls `cancellationToken.ThrowIfCancellationRequested()`
on its first line. So emitting `winding_down` with `close:false` threw
`OperationCanceledException`, which bypassed `FinishTurnAsync` (the watermark wipe),
leaving `completed_phases` stale → a steered re-entry resumed **mid-plan** instead
of at phase 1.

**Fix:** emit the terminal `winding_down` frame with `close:true` (→ `None` token +
atomic emit-and-close; `CloseAsync` is idempotent) inside a try/catch that **always**
runs `FinishTurnAsync`. The OCE catch path also now reads the *current*
`completed_phases` watermark (not the stale entry-time local) so `winding_down`
reports an accurate `completed=<n>/<total>`.

## Verified locally (credential-free)

Local verification runs against `http://localhost:8088` with the synthetic-token
model, so it needs no Azure credentials.

- **Crash → recover** (`local/run.sh`, `recovery_demo.py`): a run streams, crashes
  (`Environment.Exit(137)`), restarts against the same `AGENTSERVER_STATE_ROOT`, the
  startup recovery scan reclaims the in-progress task, re-enters with
  `EntryMode == Recovered`, and completes the full `NUM_PHASES` plan. Result:
  `RECOVERED_FULL_PLAN: true`.
- **Steering**: after the fix, a steered new-topic turn emits
  `winding_down cause=steering completed=<n>/<total>`, starts the steered topic
  fresh at **phase 1**, completes all phases, and leaves final metadata `{}`.
- **Operator cancel** (with hosted-equivalent session pinning — see below): returns
  `{status:cancelled}`, emits `winding_down cause=operator_cancel completed=<n>`,
  task ends `suspended` with metadata wiped to `{}`.

### Local cancel/steer session pinning (simulating the platform proxy)

Locally there is **no platform proxy** to route GET/cancel by invocation id to the
owning sandbox. Instead, `POST` resolves the session from the `agent_session_id`
query param, and `GET`/`cancel` resolve it from `FOUNDRY_AGENT_SESSION_ID` (or a
random UUID if unset). To exercise cancel/steer locally you therefore **pin**
`FOUNDRY_AGENT_SESSION_ID` on the server and make the POST use that same session id
(`local/serve.sh` / `recovery_demo.py` do this). In hosted mode this is a non-issue:
the platform pins `FOUNDRY_AGENT_SESSION_ID` per sandbox and routes cancel by
invocation id to the right container. This is **not** a divergence — it's a
local-testing artifact of the missing proxy, identical in spirit to the Python
kit's `FOUNDRY_AGENT_SESSION_ID` pinning.

## Verified against the live hosted agent

The full resilience battery was run end-to-end against the **deployed** hosted agent
(`resilient-research-agent-dotnet`) in the Canada Central Foundry project, driving the
Invocations protocol over HTTPS with an Entra bearer token. All scenarios pass on the
committed configuration:

| Scenario | Assertion | Result |
| --- | --- | --- |
| **T1 run → complete** | `run_start → phase_start → token… → run_complete` | ✅ PASS |
| **T2 crash → recover** | after `phase_end(1)`, `POST {"message":"crash"}` → `Environment.Exit(137)`; the platform nanny restarts the container (~1 min) with no new ingress; the resilient task auto-resumes: `run_start → recovered → phase_start(2)` (skips the completed phase) → `run_complete`, with a gap-free, dup-free sequence counter across the crash boundary | ✅ PASS |
| **T3 steer** | mid-run `POST` of a new topic on the same `agent_session_id` winds the original turn down with `winding_down cause=steering`, then the steered turn starts fresh at **phase 1** on the new topic and completes | ✅ PASS |
| **T4 operator cancel** | `POST /invocations/{id}/cancel` → `{status:cancelled}` and the stream emits `winding_down cause=operator_cancel` | ✅ PASS |

The `recovered` event fires only when at least one phase completed before the crash
(`EntryMode == Recovered && completed_phases > 0`) — identical to the Python guard
(`entry_mode == "recovered" and completed > 0`). A crash mid-phase-1 recovers just the
same (gap-free resume + `run_complete`) but emits no discrete `recovered` marker, by
design.

### Deploying and auth

Deploy with `azd up` (first time) / `azd deploy` (updates) after `./build.sh` stages the
package drop into the Docker context. Where the interactive `azd auth login` device-code
flow is blocked by org policy, azd can reuse an existing Azure CLI session instead:

```bash
az login                                  # once, interactively
azd config set auth.useAzCliAuth true     # make azd reuse the az CLI token
export AZURE_CONFIG_DIR="$HOME/.azure"
az account set --subscription <sub-id>
azd up                                    # or: azd deploy
```

The hosted battery authenticates the same way — `az account get-access-token --resource
https://ai.azure.com` for the bearer token, plus the `Foundry-Features: HostedAgents=V1Preview`
header. The Python demo is the proven hosted reference; the .NET port matches it
behavior-for-behavior per the tables above and this live run.
