# Parity: .NET `resilient-responses-agent-demo` vs Python

This document records the behavior-by-behavior parity of the .NET port against the
Python source of truth:
`azure-sdk-for-python@feature/agentserver-durable-agent-demo`
`sdk/agentserver/azure-ai-agentserver-responses/samples/resilient-responses-agent-demo`.

## Handler behavior (Program.cs ⇔ main.py)

| Behavior | Python (`main.py`) | .NET (`Program.cs`) | Parity |
|---|---|---|---|
| Crash trigger (once) | `not context.is_recovery and topic in {crash,kill,💥}` → `os._exit(137)` after 300 ms; emit `created` + `mark_failed` | `!context.IsRecovery && CrashInputs.Contains(...)` → `Task.Run` `Environment.Exit(137)` after 300 ms; `EmitCreated` + `EmitFailed(ServerError, …)` | ✅ |
| `__ECHO_INPUT__` | echo `INPUT_LEN`/`INPUT_SHA256`, complete | same | ✅ |
| `__ECHO_CRASH__` fresh | echo `PRECRASH_*`, `checkpoint()`, sleep 1 s, `os._exit(137)` | echo `PRECRASH_*`, `Checkpoint()`, `Task.Delay(1000)`, `Environment.Exit(137)` | ✅ |
| `__ECHO_CRASH__` recovery | seed from `persisted_response`, echo `RECOVERED_*`, complete | seed from `PersistedResponse`, echo `RECOVERED_*`, complete | ✅ |
| `__FAIL__` | terminal `response.failed` `error.code=server_error`, no crash | `EmitFailed(ServerError, "Demo-mode clean failure route.")` | ✅ |
| `__TASKTRACE__` | A/B raw `POST /tasks` trace | `TaskTrace.cs` (raw `HttpClient` POST, .NET Core wire schema) | ✅ (wire body language-specific) |
| Recovery seeding | `stream = ResponseEventStream(response=persisted_response)`; resume at `len(stream.response.output)` | `new ResponseEventStream(context, PersistedResponse)`; resume at `stream.Response.Output.Count` | ✅ |
| `created` dedup on recovery | `emit_created()` (framework dedups) | `EmitCreated()` (framework dedups) | ✅ verified: first resumed event is `response.in_progress`, not `created` |
| Pre-entry shutdown | `if context.shutdown.is_set(): await exit_for_recovery()` | `if context.IsShutdownRequested: await ExitForRecoveryAsync(ct)` | ✅ |
| Pre-entry cancel + steering | `if cancel: if pending_input_count>0: emit_completed(); return` | `if ct.Cancelled: if PendingInputCount>0: EmitCompleted(); yield break` | ✅ |
| `in_progress` reset | `emit_in_progress()` after pre-entry | `EmitInProgress()` after pre-entry | ✅ |
| Subcall chaining | previous subcall text fed into next; reset at subIdx 0 | `ItemText(stream.Response.Output[step-1])`; reset at subIdx 0 | ✅ |
| One OutputItem + checkpoint per subcall | `add_output_item` … `checkpoint()` | `AddOutputItemMessage` … `Checkpoint()` | ✅ |
| Mid-subcall shutdown (before close) | `if shutdown: await exit_for_recovery()` before closing item | same, before `EmitTextDone/EmitDone` | ✅ |
| Mid-subcall cancel (no watermark advance) | `if cancel: break` (don't checkpoint) | `if ct.Cancelled: break` (don't checkpoint) | ✅ |
| Cooldown intra/inter | `_cooldown`: shutdown→recover, cancel→return, sleep in 0.5 s slices | `CooldownAsync`: identical | ✅ |
| Subcall streaming early-stop | `_stream_subcall` breaks on cancel/shutdown (not tied to handler token) | `StreamSubcallAsync` with `CancellationToken.None`, checks cancel/shutdown per delta | ✅ |
| Terminal completion | `emit_completed()` | `EmitCompleted()` | ✅ |
| Config knobs | `NUM_PHASES`, `CALLS_PER_PHASE`, `TARGET_OUTPUT_TOKENS`, `INTRA/INTER_PHASE_COOLDOWN_SEC`, `DEMO_MODE` | identical env names in `DemoConfig` | ✅ |

## Intentional divergences (language / platform)

| Concern | Python | .NET | Why |
|---|---|---|---|
| Preview package delivery | wheel drop `sdk/agentserver/wheels/` | NuGet package drop `sdk/agentserver/packages/` (+ `nuget.config` local feed) | Same concept, ecosystem-native. Keeps the sample portable to other repos with no `ProjectReference`. |
| Local backend selection | `AGENTSERVER_TASKS_BACKEND=local` | `FOUNDRY_HOSTING_ENVIRONMENT` unset (`FoundryEnvironment.IsHosted == false`) | .NET SDK is env-driven via `FoundryEnvironment`; there is no `AGENTSERVER_TASKS_BACKEND`. |
| Per-item internal metadata | `message.internal_metadata["phase"/"subcall"]` | `stream.InternalMetadata["phase"/"subcall"]` (stream-level) | .NET has no per-item metadata builder surface. Observability-only; stripped on egress either way. |
| Deployed agent name | `resilient-responses-agent-demo` | `resilient-responses-agent-demo-dotnet` | Avoids a name collision when both deploy to the same Foundry project. |
| Deploy manifest shape | `agent.yaml` + `agent.manifest.yaml` (Python azd) | inline `azure.yaml` (C# `microsoft.foundry` provider, per the canonical C# HelloWorld template) | Matches the authoritative C# hosted-agent template. |
| Model | `gpt-4.1-mini` (README) / `gpt-5.4-nano` (battery) | `gpt-5.4-nano` throughout | Matches the target Canada Central project + the Python battery. |
| Port binding | `PORT` env | `PORT` env (via `FoundryEnvironment`) | ✅ same. |

## Verified locally (credential-free)

The credential-free `echo` crash→recover flow was executed end-to-end on this port:

```
route=echo
pre_crash_sha256  = 94a1060a09f32a5ede187f36bce1d6dc8bb7c9cad4a448028c1230fdf64590e1
recovered_sha256  = 94a1060a09f32a5ede187f36bce1d6dc8bb7c9cad4a448028c1230fdf64590e1
sha_match         = true
first_resumed_event = response.in_progress   # created suppressed on recovery ✓
terminal_event    = response.completed (2 output items)
RECOVERED_IDENTICAL = true
```

Real process crash (`rc=137`) → restart → startup recovery scan reclaimed the
in-progress task → re-invoked the handler with `IsRecovery` → seeded from the
persisted response → re-echoed a byte-identical SHA → completed. `__ECHO_INPUT__`
and `__FAIL__` routes were also verified.

## Verified against the live hosted agent (Foundry, Canada Central)

Deployed as `resilient-responses-agent-demo-dotnet` and driven by `battery/`:

- **Full battery `run_suite.py all` → 16/16 PASS** (T1–T16: reconnect, steering,
  poll, sync, crash-recovery T3/T5/T8/T15, cancel T6, oversized T13/T14, mark-failed
  T16). This exercises the entire externally-visible resilient-task + streaming
  contract end-to-end on the hosted platform.
- **`verify_crash.py` → RESTART PROVEN + RECOVERY PROVEN: true.** A resilient
  streaming run is streamed to `items_done ≥ 1`, the lease-holding process is
  hard-killed with `os._exit(137)`, and the run is subsequently observed
  `completed` — proving a different worker reclaimed the lease and resumed.
- **`verify_crash_steer.py` → RESTART PROVEN + RECOVERY PROVEN: true.** Same, but the
  crash is injected via a *steered* `crash` turn onto the live resilient task, proving
  steering + crash-recovery compose.

### Battery cadence (deployed `agent.yaml`)

The deployed research handler's run length is env-driven (`NUM_PHASES`,
`INTRA/INTER_PHASE_COOLDOWN_SEC`, `TARGET_OUTPUT_TOKENS`). The battery's
"wait-for-terminal" lanes use a fixed `TERMINAL_TIMEOUT_S=240`, so run length must
fit inside it:

- **`NUM_PHASES=3`, cooldowns `1s`** (the committed default) → full run ≈ 45–60s →
  reliable **16/16**. This is the regression-gate cadence.
- **`NUM_PHASES=15`, cooldowns `30s`** → run ≈ 300s → exceeds the 240s battery ceiling
  on the wait-lanes (they *time out*, not fail — the SDK is correct). Use this only for
  a manual long-running showcase, not the gate.

This is a **shared** tuning concern: Python's demo uses the identical handler config
and identical battery ceiling, so it faces the same trade-off. Not a .NET divergence.

## Observability parity (recovery logging)

Python's `TaskManager` logs an operator-facing startup marker and a reclaim marker
(`tasks/_manager.py`). .NET now matches these (Core `TaskTelemetry`):

| Event | Python | .NET (`TaskTelemetry`) |
|---|---|---|
| Startup, per process boot | `TaskManager starting (owner=…, instance=worker-<pid>-<hex>-<epoch>, hosted=…)` | EventId 11 `TaskManagerStarting` — same message + stable lease instance-id |
| Stale-task reclaim | `Reclaimed stale task <id> …` | EventId 12 `StaleTaskReclaimed` — `Reclaimed stale task {TaskId} (generation will increment).` |

The instance-id is stable per process boot and changes across a cross-process restart,
so a restart surfaces as a **new** worker generation in the logs — the signal the crash
verifier greps to prove a restart.

## Known tooling limitations (verifiers, not SDK)

- **`azd ai agent monitor` log capture is unreliable across a nanny restart.** It
  re-attaches to the *pre-crash* log buffer and does not reliably follow the new
  container's stdout, so the post-restart `TaskManagerStarting` line is captured only
  intermittently. The verifiers therefore **do not** depend on it: recovery is proven
  *deterministically* by "confirmed hard crash + pre-crash progress + `completed`
  terminal" (the only mechanism that completes a killed streaming run is cross-process
  recovery). Log markers remain as supplementary evidence. **Action item (Python):** the
  Python verifiers use the same log-scrape heuristic and would benefit from the same
  deterministic proof + GET-terminal fallback ported back.
- **`crash.json` `sandbox_dropped: false` is EXPECTED on both languages.** The crash
  handler emits a clean `response.created` + `response.failed` and returns *before* the
  delayed `os._exit(137)`, so the SSE stream closes cleanly rather than being severed
  mid-frame. Python's crash handler is byte-equivalent. Not a divergence.
- **Stream-replay TTL is a platform property.** An early-completed run's replayable
  stream is expired by the Foundry backend after its TTL (`"…stream TTL has expired"`).
  The verifiers fall back to a non-streaming GET (no TTL constraint) to read the
  authoritative terminal status. Identical for .NET and Python agents.

Local credential-free routes (`__ECHO_INPUT__`, `__FAIL__`, `__ECHO_CRASH__`) remain
the fast, offline resilience check; the hosted battery above is the full-contract proof.
