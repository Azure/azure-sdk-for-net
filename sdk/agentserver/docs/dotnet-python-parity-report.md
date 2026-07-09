# .NET ⇄ Python Task & Streaming Parity Report

**Status:** Current state — two upstream (Python-stricter-than-spec) action items plus one
completed SOT-spec correction; **no open .NET-side gaps** (all previously-deferred hosted
items closed: `Foundry-Features` header now sent; base path and tag-query match Python and
the corrected spec).

This report captures the **current** parity state between the .NET port of the task &
streaming primitives (`Azure.AI.AgentServer.Core` / `Azure.AI.AgentServer.Invocations`)
and the Python library on branch `feature/agentserver-durable-tasks`, verified against the
latest Python source and the shared SOT spec.

Reference sources:

- **SOT spec:** `azure-ai-agentserver-core/docs/task-and-streaming-spec.md`
- **Task API contract:** `foundry-task-storage-protocol-spec.md`
- **Python impl:** `azure-ai-agentserver-core/.../tasks/*.py`, `.../streaming/*.py`
- **Python samples:** `azure-ai-agentserver-invocations/samples/`

---

## 1. Open upstream (Python / spec) action items

Two low-severity items where **Python is stricter than the SOT spec**, plus one **completed
SOT-spec correction** (the spec's hosted-transport wire shape was wrong; .NET and Python were
reconciled to the live-backend contract):

- **File-backed replay — mid-file terminal.** Spec C-STR-FBR-6 says a `__terminal__`
  sentinel that is not the final line **MUST be ignored**. .NET ignores it and keeps
  loading; Python raises on any mid-file terminal or on records after a terminal.
  Recommend relaxing Python to the spec (ignore-unless-final) or tightening the spec to
  match Python — the two should agree.
- **File-backed replay — serializer/deserializer pairing.** Spec C-STR-FBR-3 requires a
  custom serializer and deserializer to be supplied **both-or-neither**. .NET validates
  and throws on a half-configured pair; Python silently defaults a missing side to JSON.
  Recommend Python add the same both-or-neither guard.
- **[RESOLVED — spec corrected] Hosted store base path & tag-filter shape.** The SOT protocol
  spec §4/§7.5 previously specified `{FOUNDRY_PROJECT_ENDPOINT}/storage/tasks` and repeatable
  `tag=key:value` filters. Python's task-storage client — which runs against the live Foundry
  backend — instead uses `{FOUNDRY_PROJECT_ENDPOINT}/tasks` (no `/storage` segment) and
  `tag.{key}={value}` filters. The live backend is the true wire contract, so the SOT spec was
  the defect: §4 (base URL + "Appends `/tasks`"), §6 relative-path note, §7.5 tag param, and
  the §11 URL-masking guidance have been corrected to match Python. .NET now emits the same
  base path and `tag.{key}={value}` shape — .NET and Python agree, no code action outstanding.

Everything previously filed has been implemented on the Python side (its "spec 037" batch)
and reconciled in the SOT spec (§15 retry preset table + hard-cap rules, and the spec-038
task-record schema cleanup). .NET and Python otherwise agree on every item that was
previously divergent, for the local-provider scope:

- Retry hard caps (`max_attempts` 1–10, `max_delay` ≤ 1 h) — both raise on violation.
- Retry preset values unified across .NET, Python, and the SOT §15 normative table
  (`exponential_backoff` 3/1s/60s/2.0/jitter; `fixed_delay` 3/5s; `linear_backoff` 5/1s/60s).
- Invalid-config fail-fast: negative delays, `max_attempts < 1`, `backoff_coefficient < 1.0`,
  negative timeout, whitespace-only task names, and caller-supplied `input_id` charset/length
  are all rejected on both sides.
- Task `name` is a **required** identity anchor (no `__qualname__` fallback on Python).
- Per-turn timeout defaults to **1 day** and 1 day is a **hard ceiling** (larger/negative
  rejected). Per-turn-vs-task-lifetime framing (30-day sliding TTL) clarified in both guides.
- Per-attachment value cap is **10 MiB** on both sides and in the spec.
- File-backed replay terminal sentinel is `{"__terminal__": true}` (spec C-STR-FBR-5 shape)
  on both sides.
- Stream-id → filename hardening is identical: `[A-Za-z0-9._-]` verbatim, otherwise SHA-256
  `h_<64-lowercase-hex>` (reserved shape rehashed).
- `use_file_backed_replay` ergonomic defaults match: storage dir `<state-root>/streams`,
  TTL 10 minutes, JSON serialization by default.
- Python `resilient_research` sample's unreachable claimed-410 branch removed; stale
  timeout-watchdog "known gap" spec note removed.

---

## 2. Intentional design divergences (informational — no change requested)

Documented .NET choices that differ from Python but are **not** parity bugs. Divergences
are kept only where there is a **solid stated reason**; anything that turned out to be an
accidental gap has been fixed (see §3).

### Steering-signal mechanism

- **Python** signals steering via an `asyncio.Event` (the handler's `await` completes
  naturally). **.NET** signals via a `CancellationToken` (the `await` throws
  `OperationCanceledException`), so .NET handlers catch the bare nudge (or poll
  `PendingInputCount`). Documented in the .NET steering/streaming guides. Idiomatic
  projection of the same concept.

### Other divergences (leave as-is)

| .NET behavior | Python behavior | Note |
|---------------|-----------------|------|
| `<id>.lock` sidecar file | POSIX `flock` on the `.jsonl` | Cross-runtime writer-lock interop; the two runtimes never co-write one stream file. |
| Requires both/neither custom serializer+deserializer | Independent | .NET stricter. |
| Throws on empty stream id | Allows | .NET stricter/safer. |
| JSON rehydrates as `JsonNode` (typed overload round-trips a CLR type) | Rehydrates as `dict`/`list` | Default-JSON rehydrate shape; use the typed overload. |
| Recovery scan does **not** run orphan steering-attachment cleanup | `_steering_cleanup_orphan_attachments` deletes `_steering_input_*` attachments unreferenced by `pending_inputs` before each reclaim | Both runtimes write the steering-append attachment **and** the queue update in one atomic PATCH, so an orphan can never arise in the happy path — the cleanup is dead-code defense-in-depth. Omitting it on .NET avoids an extra pre-reclaim PATCH (recovery latency + a second etag-412 failure surface) for no correctness gain. Revisit only if steering writes ever become non-atomic or records can be externally mutated. |

---

## 3. Areas audited clean (parity-OK)

- **Fast recovery (hosted parity)** — the two Python fast-recovery mechanisms are matched:
  - `GetActiveRunAsync` consults the store and **inline-reclaims** a stale `in_progress`
    run (`TryReclaimStaleFromStoreAsync`) instead of waiting the 300 s background scan. The
    reclaim predicate (`owner` empty **or** `owner == us`) is an exact match for Python's
    `_lease_is_dead(active_locally=False)`, so a restarted single-sandbox process (same
    agent+session owner) reclaims its own interrupted `in_progress` records immediately.
  - **Graceful shutdown force-expires leases.** On host `StopAsync`, the durability service
    calls `TaskEngine.ShutdownAsync(grace)`: it signals the shutdown cause, waits up to the
    grace window (`ShutdownGrace` = 25 s, Python `shutdown_grace_seconds`) for in-flight
    turns to checkpoint, then **force-expires** (`lease_duration_seconds = 0`) any straggler
    lease and stops that turn's renewal loop before cancelling the handler — the same
    force-expire-then-cancel-renewal ordering as Python's `TaskManager.shutdown()` — so a
    restarted process reclaims immediately rather than waiting the lease TTL. Records stay
    `in_progress`. Force-expiry always runs even if the host shutdown-timeout token has
    already fired (the release write uses `CancellationToken.None`). Queued steering inputs
    that promote during the grace window behave exactly as Python (both promote and rely on
    the manager-level force-expiry + cancellation to wind the chain down).
- **Default identity** — default agent/session names are `unknown-agent` / `local` on both
  sides (used when not in a hosted Foundry environment).
- **Constants** — lease TTL 60 s, renewal `max(1, lease/2)` = 30 s, renewal-fail 3, recovery
  scan 300 s, steering cap 9, function-input 200 KiB, steering-input 20 KiB, attachment value
  10 MiB / count 20, payload 1 MiB, error 64 KiB, source 4 KiB, jitter band 0.75–1.25, lease
  bounds 10–3600 s, list page 20/100, etag budget 5, retry hard caps 10 attempts / 1 h delay.
- **Task-record schema** — matches the spec-038 wire format: no `_`-prefixed bucket keys,
  `source.hosting_environment` stamped from `FOUNDRY_HOSTING_ENVIRONMENT`, and
  `payload.schema_version = "1"`. The pre-schema legacy gate is applied **only on the
  scan/periodic recovery path** (`ScanAndRecoverAsync`, Python `_recover_stale_tasks`) — the
  inline-reclaim path (`TryReclaimStaleFromStoreAsync`, Python `get_active_run`) does **not**
  re-gate, matching Python exactly (the scan always runs first and deletes any pre-schema
  record before an inline reclaim could observe it). The gate is a key-presence check matching
  Python's `schema_version in payload`. `source.server_version`
  follows the spec §21 format `<sdk>/<version> (<runtime>/<version>)` on both sides (the value
  is per-runtime by design — .NET emits `Azure.AI.AgentServer.Core/<ver> (dotnet/<ver>)`).
- **`input_id` semantics** — matches Python's contract exactly. When the caller omits
  `input_id`, `context.input_id` defaults to the **`task_id`** for both one-shot and
  multi-turn (never a fabricated `input-<guid>`). The persisted `payload.last_input_id` is
  advanced **only when the caller explicitly supplies `input_id`** (Python
  `_build_framework_extras`), across fresh-create, suspended-resume, and steering-append; an
  omitted id leaves the previously persisted value intact via shallow-merge. On recovery,
  `context.input_id` is rehydrated from `last_input_id` defaulting to `task_id`. An active
  multi-turn chain never start-time-attaches on an `input_id` match — a concurrent start
  queues as the next steered turn (steerable) or raises `TaskConflictException`
  (non-steerable), exactly as Python routes an active chain.
- **Hosted transport** — the .NET `HostedTaskStore` speaks the same wire shape as Python's
  live-backend task-storage client: base path `{FOUNDRY_PROJECT_ENDPOINT}/tasks` (no `/storage`
  segment), tag filters as `tag.{key}={value}` params, lease parameters as query params
  (spec §7.1/§7.3), and the `Foundry-Features: Routines=V1Preview` opt-in header on every request
  (Python parity — the header opts into the same server-side Routines preview behavior). The SOT
  protocol spec §4/§7.5 previously specified `/storage/tasks` and `tag=key:value`; those were spec
  defects (the live backend is the true contract) and have been corrected — see §1. .NET and
  Python now agree on the full hosted wire shape.
- **Canonical record serialization** — canonical JSON (sorted keys, explicit-null
  lease/timestamps, CPython-faithful number formatting) is byte-comparable across runtimes for
  equivalent field values; the only fields that intentionally differ per runtime are the
  provenance strings (`source.server_version` and, in hosted mode, `hosting_environment`).
- **Public surface** — the .NET DI/builder/options/interface shape (`IEventStreamRegistry`,
  `EventStreamOptions`, `AddEventStreams`, `IResilientTaskBuilder`, `ITaskInvoker`,
  `RunOptions`, `TaskRegistrationOptions`, `TaskStatus`, `TaskException`) is the idiomatic
  .NET projection of Python's decorators/kwargs.

## 4. Test-coverage parity (public surface)

A fresh cross-language audit of the Python test suite (`tests/tasks/`, `tests/streaming/`, and
the invocations `tests/e2e/` live/subprocess tests) against the .NET suite confirms the .NET
side holistically covers the documented public surface (tasks-guide.md + streaming-guide.md):

- **Lifecycle / recovery / retry / cancellation / steering / timeout / metadata / attachments /
  ETag CAS / lease arithmetic / hosted wire format / canonical serialization** — each Python
  scenario area maps to one or more .NET tests under `tests/Tasks/**` and `tests/Streaming/**`.
- **Streaming primitives** — Broadcast, Replay (+TTL, cursor, GONE transition), and
  FileBacked (persist-before-fanout, JSONL/terminal, rehydrate ACTIVE/CLOSED/GONE, single-writer
  lock, compaction, path-traversal hardening, crash-resume-from-cursor) all have .NET parity.
- **Sample e2e** — every documented sample (incl. Sample 8 Resilient Research task⇄stream bridge
  with SSE `?last_event_id=` resume, and Sample 9 steerable multi-turn) has an in-process E2E
  test; live sample flows are `[LiveOnly]` (excluded from CI, runnable with user creds).

Gaps closed by this audit (small, previously-untested public behaviors):

- `AttachmentPromoter` per-task 20-attachment cap (and existing-key re-promote not counting) —
  `tests/Tasks/Serialization/AttachmentTests.cs`.
- `TaskMetadata` named-namespace mutual isolation (no cross-namespace or default⇄named leakage) —
  `tests/Tasks/MetadataPersistenceTests.cs`.
- `EventStreamRegistry.DeleteAsync` no-op on unknown id + idempotent repeat-delete + empty-id
  guard — `tests/Streaming/EventStreamRegistryTests.cs`.

Note: Python does NOT assert the hosted base-path/tag wire shape at the transport-test level
(its `test_hosted_provider_transport.py` only pins policy order + headers + verbatim cursor).
.NET is *stricter* here — `tests/Tasks/Conformance/HostedWireFormatTests.cs` explicitly pins the
`{endpoint}/tasks` path, `tag.{key}={value}` filter, lease query params, and the `Foundry-Features`
header on every request — which is what surfaced the SOT-spec defect corrected in §1.

### Invocations-package test parity

The durable-tasks Python feature adds exactly five NEW files under
`azure-ai-agentserver-invocations/tests/`: `test_resilient_samples_structure.py` (top-level) and
the `e2e/` directory (`_crash_harness.py`, `test_resilient_copilot_live.py`,
`test_resilient_multiturn.py`, `test_resilient_research_live.py`). Mapping to .NET:

- **`test_resilient_research_live.py`** (POST SSE monotonic + contiguous sequence, GET
  `?last_event_id=N` skips ≤N, SIGKILL-mid-run + restart → post-crash cursor strictly `>` pre-crash
  with no gaps) — covered by `SampleEndToEndTests.ResilientResearch_*` (monotonic/contiguous/cursor
  resume/404) plus, for the crash invariant, the deterministic primitive-level
  `Streaming/FileBackedReplayEventStreamTests.CrashMidStreamRehydratesAndResumesFromNextCursor`
  (dispose = simulated crash → new registry rehydrates → resumes at next cursor with no gap). The
  Python subprocess-SIGKILL harness (`_crash_harness.py`) is a Python-runtime integration mechanism;
  the durability *invariant* it proves is covered deterministically on .NET.
- **`test_resilient_multiturn.py`** (two-turn history accumulate, **"done" clears history**,
  **default namespace records invocation status + output**) — history-accumulate and the new
  **"done"-clears-history / turn-reset** flow are covered by `SampleEndToEndTests.ResilientMultiturn_*`
  (incl. `ResilientMultiturn_DoneMessage_TerminatesAndClearsSessionHistory`). Default-namespace
  status/output persistence is not re-asserted at the Invocations HTTP layer (the sample writes it to
  `ctx.Metadata` but does not surface it in the response body, and `ITaskStore` is cross-assembly
  `internal`); the underlying metadata-persistence mechanic — including default⇄named isolation — is
  validated at the Core layer by `tests/Tasks/MetadataPersistenceTests.cs`.
- **`test_resilient_copilot_live.py`** — exercises the GitHub Copilot Agents SDK integration sample,
  which is Python-ecosystem-specific (gated/skipped when the dependency is absent). .NET has no
  equivalent third-party-integration sample; the primitive behaviors it demonstrates (SSE
  `text_delta`, `session_idle`, snapshot polling, dedup) are covered by the .NET streaming/task tests
  and the Sample 8/9 E2E tests.
- **`test_resilient_samples_structure.py`** — a structural gate over the Python `samples/` directory
  layout (Python-packaging-specific). N/A to .NET, which ships samples as markdown guides with
  snippet-sourced `.cs` and per-sample E2E tests.
