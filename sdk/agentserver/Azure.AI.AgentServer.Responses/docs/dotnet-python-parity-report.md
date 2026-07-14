# .NET ↔ Python Resilience Parity Report

**Feature**: `002-responses-resilience` (Resilient responses for .NET)
**Python source of truth**: `Azure/azure-sdk-for-python` branch
`feature/agentserver-responses-spec016` @ `3df89fec8d5d6ff072889a2cf9dd1723c019976a`,
package `sdk/agentserver/azure-ai-agentserver-responses`.
**.NET target**: `Azure.AI.AgentServer.Responses`.

This is the living gap-analysis document (tasks GAP1–GAP4). It records
current-state parity by area, each finding with severity + evidence, resolution
status, and a dedicated **Python-side action items** section for intentional
divergences or upstream observations.

> **Convergence status: CONVERGED (GAP1–GAP4 complete).** A fresh-mind
> gap-analysis pass (Opus 4.8) and multiple independent adversarial rubber-duck
> passes (GPT-5.5, a different model family) agree on zero open .NET-side gaps.
> Every remaining divergence below is either justified with rationale or captured
> as a tracked Python-side action item. Full non-Live suite at convergence:
> **2109 pass / 0 fail**. See "GAP3 convergence loop" for the finding-by-finding
> adjudication.

## Legend

- ✅ **Parity** — implemented in .NET, verified by green tests, matches Python.
- 🟡 **Partial** — protocol primitive implemented + tested; deep-pipeline wiring
  pending (tracked by task ID).
- ⏳ **Pending** — requires the crash-recovery orchestration layer / multi-process
  harness (tracked by task ID).

> **Status (current):** the CC-RE migration composed the Responses layer on the Core
> `001` durable task/streaming primitives, and the CR-FINAL findings are resolved. All
> areas below are ✅; no 🟡/⏳ cells remain.

## Current-state parity by area

### Recovery payload schema — ✅ Parity

- 9-field fail-closed serializer `ResponseRecoveryPayload` matches the Python
  `ResilientResponseInput` schema field-for-field (names, casing, nullability).
  - Evidence: `src/Internal/Resilience/ResponseRecoveryPayload.cs`;
    `tests/Protocol/RecoveryPayloadParityProtocolTests.cs` (6 tests),
    `tests/Protocol/RecoveryPayloadFailClosedTests.cs` (11 tests) — all green.
- Persisted vs re-derived boundary matches Python exactly (re-derived fields are
  asserted absent).
- Fail-closed on malformed/missing/wrong-type input (deterministic
  `RecoveryPayloadFormatException` before any dispatch), JSON-safety round-trip on
  serialize.

### Dispatch matrix — ✅ Parity

- `ResponseResilienceDispatch.ClassifyRow` / `DecideDisposition` /
  `IsResilientBackground` match Python `classify_row` / `decide_disposition`
  across the full `(store, background, resilient_background)` truth table.
  - Evidence: `src/Internal/Resilience/ResponseResilienceDispatch.cs`;
    `tests/Unit/ResponseResilienceDispatchTests.cs` (18 cases) — green.
- **Primitive selection (`_pick_primitive`) parity (GAP2 Finding 1 + GAP3 Finding D):** the
  Core task subsystem is composed for **every** host (local and hosted), matching
  Python's always-on task primitive composition. `multiTurnAvailable` is always true,
  so ANY `conversation_id` (or `SteerableConversations=true`) routes through the Core
  multi-turn task regardless of
  `ResilientBackground`/`SteerableConversations` **and regardless of `background`**
  (Finding D) — for **non-streaming** turns. A concurrent overlap on a chain
  therefore returns 409 `conversation_locked` even with **default options** and even
  for a **foreground** turn (Spec US5 scenario 4 / FR-051, FR-052); a foreground fork
  (`previous_response_id` not the chain head) returns 409
  `conversation_fork_not_supported`. A foreground multi-turn caller blocks until the
  task turn is terminal and receives the FINAL persisted response inline. A stored
  non-streaming background response (Row 2) is task-tracked so the next-lifetime
  crash-recovery scan marks it `failed` (`code=server_error`, disposition=mark-failed;
  FR-012/FR-013).
  - Evidence: `src/Internal/ResponseEndpointHandler.cs` (gate ~L255-257, foreground
    non-streaming resilient branch in the final `else`);
    `src/Hosting/ResponsesServerServiceCollectionExtensions.cs` (DI ~L178-204);
    `tests/e2e/resilience_contract/TestSteerableConversationContractTests.cs`
    (`ConcurrentTurn_DefaultOptions_MapsToConversationLocked409`,
    `ForegroundConcurrentTurn_DefaultOptions_MapsToConversationLocked409`,
    `ForegroundForkTurn_DefaultOptions_MapsToConversationForkNotSupported409`,
    `RealComposition_ForegroundConcurrentTurn_OneSucceedsOtherLocked`,
    `StoredBackgroundTurn_DefaultOptions_RoutesToOneShotTaskWithMarkFailedDisposition`)
    — green.
  - **Foreground STREAMING multi-turn — ✅ resolved (this session).**
    Foreground *streaming* conversation/steerable turns now route through the Core
    multi-turn task like every other `store=true` turn, so they receive
    `conversation_locked` / `conversation_fork_not_supported` arbitration identically
    to the non-streaming path. The prior deadlock was resolved by **relaying the wire
    stream immediately** (subscribing to the per-response registry stream) instead of
    awaiting `execution.ResponseCreatedSignal` before emitting SSE `200` headers — the
    task body writes `response.created` (and all subsequent events) to the wire stream
    as they arrive, matching Python `_live_stream`. The spec-B8 standalone-SSE-`error`
    semantics are preserved: a pre-created failure (Phase-1 persistence failure or a
    handler that throws before `response.created`) is recorded on the execution
    (`PreCreatedRelayFailure`) and re-thrown by the relay so `SseResult` writes a
    standalone `error` event with full fidelity (e.g. `storage_error`), NOT an HTTP 500.
    A foreground-streaming client disconnect cancels the shared execution CTS (the task
    body links it), terminating the turn as cancelled — parity with the pre-task inline
    behavior (T067). Evidence: `NonBgStreaming_Disconnect_ResultsInCancelled`,
    `HandlerThrowsBeforeAnyEvents_StillEmitsResponseFailedEvent`,
    `Streaming_HandlerThrowsResponseValidation_BeforeCreated_EmitsErrorEvent`,
    `PersistenceFailureTests` (8/8) — all green.
  - **All `store=true` rows are now task-wrapped — ✅ resolved (this session).**
    Matching the Python authoritative contract (responses-resilience-spec §6: EVERY
    `store=true` request runs the handler inside a Core resilient task — foreground OR
    background, streaming OR non-streaming, one-shot OR multi-turn; only `store=false`
    runs inline), the .NET endpoint gate now routes foreground non-streaming, foreground
    streaming, background non-streaming, and background streaming `store=true` turns
    through the resilient task. Row 2 background-streaming and Row 3 foreground turns are
    therefore task-tracked, so the next-lifetime recovery scan observes and marks-failed a
    crashed turn (Path C) exactly as Python does. The wire-stream vs `result.Events`
    asymmetry (created published before persistence; terminal published before the Phase-2
    rewrite) was corrected so the wire stream (registry replay + resilient relay) observes
    the SAME corrected sequence as the yield path — `response.created` is published AFTER
    successful persistence, and the terminal is published by `CreateStreamingAsync` AFTER
    its Phase-2 persistence step (so a terminal persist failure surfaces `response.failed`,
    not `response.completed`, on the wire stream too). Evidence:
    `PersistenceFailureTests` Phase1 (standalone `storage_error`) / Phase2
    (`response.failed`) — green.
  - **Scoped-out (single-process-recovery-model limitation only):**
    A real process SIGKILL mid-turn (Path C) cannot be reproduced in the single-process
    in-memory test host, so the actual post-crash recovery-scan re-entry is exercised by
    the Core task-store conformance tests rather than an end-to-end Responses SIGKILL
    harness. The Responses turns are now task-tracked (the prerequisite), and their
    Path-B in-process mark-failed behavior IS implemented and tested
    (`TestRow2Row3Row4PathTests.cs`). See the Python-side action items table.
- **Malformed cursor (GAP2 Finding 2):** a present-but-non-integer
  `starting_after` query parameter now returns HTTP 400 `invalid_request`
  (`param=starting_after`) instead of silently full-replaying.
  - Evidence: `src/Internal/ResponseEndpointHandler.cs` (parse guard ~L704);
    `tests/Endpoints/ReconnectResponsesEndpointTests.cs`
    (`Reconnect_MalformedStartingAfter_Returns400`) — green.

### Conversation chain identity — ✅ Parity

- `ConversationChainIdDerivation.Derive` matches Python `derive_conversation_chain_id`
  (Spec 038): three per-case shapes (`cchain_`/`rchain_`/verbatim), deterministic
  32-char scope digest, 18-char partition key with deterministic fallback.
  - Evidence: `src/Internal/Resilience/ConversationChainIdDerivation.cs`;
    `tests/Protocol/ConversationChainIdentityTests.cs` (8 tests) — green, including
    **cross-language digest parity** (scope/partition values computed from the
    Python algorithm and asserted equal).
- Wired into the live context: `ResponseContextImpl.ConversationChainId` now
  returns a real derived id (previously the base default). No regression across the
  full 2026-test non-live suite.

### Conversation chain metadata — ✅ Parity (facade)

- `ConversationChainMetadata` named-namespace facade with explicit `FlushAsync`,
  `_`-reserved name/key rejection, defensive snapshot, base no-op flush.
  - Evidence: `src/ConversationChainMetadata.cs`;
    `tests/Unit/ConversationChainMetadataTests.cs` (11 tests) — green.
- Durable-backed flush — ✅ **Resolved (CC-RE + CR8)**. `DurableConversationChainMetadata`
  (`src/Internal/Resilience/DurableConversationChainMetadata.cs`) backs the facade with the
  Core `TaskMetadata` checkpoint store; `FlushAsync` persists the snapshot into the durable
  task record. Wired by `ResponsesResilientTaskHandler.BuildContext()` (multi-turn) and the
  one-shot reuse branch (`AttachDurableConversationChainMetadata`). Per-instance default
  facade (no shared static) prevents cross-conversation bleed.
  - Evidence: `tests/Unit/ConversationChainMetadataTests.cs`
    (`EachContext_HasIsolatedMetadata_NoCrossContextBleed`);
    `tests/e2e/resilience_contract/TestConversationChainMetadataDurabilityTests.cs`
    (`FlushedChainMetadata_IsDurable_AndVisibleToNextTurn`) — green.

### Internal metadata (persist-but-strip) — ✅ Parity (egress helper)

- `InternalMetadataEgress.Strip` matches Python `strip_internal_metadata`:
  item-level `internal_metadata` removed recursively; response-level
  `_internal_metadata` removed from `metadata`; emptied `metadata` normalized to
  `null`; non-object roots returned unchanged.
  - Evidence: `src/Internal/Resilience/InternalMetadataEgress.cs`;
    `tests/Protocol/InternalMetadataContractTests.cs` (8 tests) — green.
- Egress wiring — ✅ **Resolved**. `InternalMetadataEgress.Strip` is invoked at every
  client-facing site: SSE (`src/Internal/SseWriter.cs`), JSON responses
  (`src/Internal/Resilience/ClientPayloadSanitizer.cs`, `ResponseEndpointHandler.cs`),
  and output-item conversion (`src/Internal/ItemConversion.cs`); ingress strip on the
  request node (`ResponseEndpointHandler.cs`).
- Persist side — ✅ **Resolved (CR-FINAL Issue 1)**. `ResponseEventStream.InternalMetadata`
  is a write-through map that folds the accumulated internal map into the response snapshot
  under `metadata["_internal_metadata"]` (JSON-serialized string, matching the string-valued
  `Metadata` model), so it is persisted with the response (durable, readable on recovery via
  `context.PersistedResponse`) and stripped on every egress path — Python's persist-but-strip
  contract.
  - Evidence: `tests/Unit/ResponseEventStreamInternalMetadataTests.cs` (10 tests: fold,
    accumulate, user-metadata isolation, survives `Snapshot()`, recovery-ctor hydration,
    `FileResponsesProvider` round-trip, egress strip, mocking-ctor fallback);
    `tests/Protocol/InternalMetadataContractTests.cs` — green.

### Terminal overlay (failed / cancelled) — ✅ Parity (verified vs Python HEAD `2c52b22`)

Python `feature/agentserver-responses-spec016` HEAD (`2c52b22`, "preserve
handler-owned fields on framework-built terminals") converged all terminal
construction onto overlay helpers (`apply_failed_terminal` / `apply_cancelled_terminal`
/ `resolve_*`): the handler owns the response object; the framework may only set
`status`, attach `error` on failed, or clear `output` on cancel — never discard
handler-owned fields (`agent_reference`, `model`, `metadata`, `output`, …).

- **failed** — status + error overlaid onto the durable snapshot; `output` **preserved**
  ("may be partial"); `completed_at` null. .NET `ResponseMutations.SetFailed` mutates the
  live snapshot in place (inherently an overlay).
- **cancelled** — status set, `output` cleared to `[]`, `error`/`completed_at` null.
  .NET `ResponseMutations.SetCancelled` matches.
- **Divergence found & FIXED** (this pass): the next-lifetime **mark-failed** recovery
  path (`ResponsesResilientTaskHandler.cs`) previously called `persisted.Output.Clear()`
  before `SetFailed`, discarding partial output that Python's `_overlay_failed_terminal`
  (spec §7.2/§7.3) preserves. `Output.Clear()` removed; failed now keeps accumulated output.
  - Evidence: `tests/e2e/resilience_contract/TestRow2PathCCrashFailedTests.cs` →
    `Row2PathC_MarkFailed_PreservesAccumulatedOutput` (green; would fail pre-fix).
- **Absent-snapshot case**: Python synthesizes a bare-bones failed terminal (carrying
  `agent_reference`/`model` from task input) and `create`s it. .NET instead **drops** the
  recovery when the durable record is definitively absent (no client ever received the
  response id, so nothing can read it) — a pre-existing, documented .NET design decision
  (`ResponsesResilientTaskHandler.cs` recovery precondition), not a regression.

### Recent-Python-change survey (concern #1) — ✅ all at parity

Verified against Python HEAD `2c52b22` (fresh clone). Every surveyed recent behavior
is present in .NET:

| Behavior | .NET verdict | Evidence |
|----------|--------------|----------|
| `conversation_chain_id` format (`cchain_`/`rchain_`/raw, stable partition) | ✅ HAVE | `ConversationChainIdDerivation.cs:62/69/73` |
| `ResponseAcceptor` hook (queued-202 shaping) | ✅ HAVE | `ResponsesServerOptions.cs:71`; `ResponseEndpointHandler.cs:678-695` |
| First turn on steerable chain routes multi-turn | ✅ HAVE | `ResponseEndpointHandler.cs:225-232` |
| `internal_metadata` stripped on **ingress** (not just egress) | ✅ HAVE | `ResponseEndpointHandler.cs:113-116` |
| Core `RetryPolicy` fail-fast caps + 1-day timeout default/ceiling | ✅ HAVE (Core) | `RetryPolicy.cs:54-93`; `TaskEngineConstants.cs:42-62` |
| Core task `schema_version:"1"`, unprefixed reserved keys | ✅ HAVE (Core) | `TaskWireKeys.cs:58/63`; `TaskEngine.cs:172/295` |

### Public developer surface — ✅ Parity

- `ResponsesServerOptions.ResilientBackground` / `SteerableConversations`
  (independent options) match Python.
- `ResponseContext` recovery/steering surface (`IsRecovery`, `PersistedResponse`,
  `ConversationChainId`, `ConversationChainMetadata`, `IsSteeredTurn`,
  `PendingInputCount`, `ClientCancelled`, `ExitForRecoveryAsync`) matches the
  Python `ResponseContext` additions, with safe virtual defaults for
  test-constructed contexts (Constitution Principle VIII).

### Documentation — ✅ Parity

- `docs/resilient-responses-developer-guide.md` mirrors the Python
  tasks/streaming resilience developer guide.
- `docs/resilience-sample-parity.md` records the 1:1 sample mapping and omissions.
- `samples/Sample19_ResilientStreaming.md`, `Sample20_ResilientSteering.md`,
  `Sample22_ResilientMultiTurn.md` port the required Python samples.

### Deep crash-recovery orchestration — ✅ Parity (composed on Core `001` primitives)

The Responses layer now **composes** the Core `001` durable task + event-stream
primitives (`AddResilientTasks`, `ITaskInvoker`, `@task`/`@multi_turn_task(steerable:)`,
`TaskContext<T>`, `TaskMetadata`, `IEventStreamRegistry`) rather than reimplementing
recovery/leasing/steering — mirroring Python. The bespoke `ResponseRecoveryService`,
`ResponseRecoveryRegistrar`, and `ConversationArbitrator` were **removed** (the CC-RE
migration); `ResponseRecoveryPayload` is retained only as the `TInput` JSON serializer.
The following areas are implemented and covered; every row×path cell is `covered` in
`tests/e2e/resilience_contract/CONTRACT_COVERAGE.md` (enforced by the
`ContractCoverageCompletenessTests` meta-test).

| Area | Status | Evidence |
|------|--------|----------|
| Row 1/2/3/4 × Path A/B/C crash/shutdown recovery | ✅ | `tests/e2e/resilience_contract/TestRow*Tests.cs`, `CrashRecoveryE2ETestBase` (drives the real Core `TaskDurabilityService` cold-start scan) |
| Checkpoint cutpoints C1/C3/C4/C5 (Row 11) | ✅ | `TestRow11CheckpointCutpointTests.cs`, `ResponseEventStreamCheckpointTests` |
| Streaming reconnect (`starting_after`), single `created`, reset seeding | ✅ | `TestRow1StreamingReconnectTests.cs`, `TestRow1StreamingRecoveryParityTests.cs` (Core `IEventStreamRegistry`) |
| Recovery drop precondition (definitive vs transient) | ✅ | `TestRecoveryDropPreconditionTests.cs` |
| Steering arbitration (queue, fork/lock 409, drain) | ✅ | `TestSteerableConversationContractTests.cs` (Core steerable multi-turn + steering queue) |
| Fail-loud composition (startup + request-time platform errors) | ✅ | `ResilienceStartupValidationTests.cs`, `ResilientStartFailureProtocolTests.cs`, `HostedResilienceFailureTests.cs` |
| Recovery scan / re-invoke pipeline | ✅ | Core `TaskDurabilityService` (composed via `AddResilientTasks`); `ResponsesResilientTaskHandler` task body |

**Architectural note.** The Responses orchestration runs INSIDE a Core
`@task`/`@multi_turn_task`: Core's task engine owns crash recovery (its
`TaskDurabilityService` cold-start scan), leasing, and steering — exactly as Python
composes these primitives. `FileResponsesProvider` remains the durable response-envelope
store (distinct from the Core task store). Multi-process SIGKILL/SIGTERM is not exercised
in this single-sandbox environment; the equivalent hard-crash driver
(`CrashRecoveryE2ETestBase`: leave an `in_progress` record without a terminal event, then
start a fresh host over the same state dirs so the Core scan reclaims/re-invokes) provides
deterministic in-process coverage. See tasks T003/T004 for the rationale.

## GAP3 rubber-duck adjudication — findings F1–F5

The GAP3 fresh-mind pass raised five findings. Each was adjudicated below. **F1, F2 and F5
are resolved in code** (F1 as of this session — all `store=true` rows are now task-wrapped);
**F3, F4 are documented, intentional divergences / tracked action items** (they are not silent).
All resolutions preserve the 2110-pass / 0-fail non-Live baseline.

### F1 — Path-C crash recovery now task-tracked for ALL `store=true` rows — ✅ Resolved (this session)

Previously two sub-rows (Row 2 background-streaming, Row 3 foreground) ran **inline** and so a
real process crash (Path C) in those rows was not reclaimed by the next-lifetime recovery scan.
**Both are now routed through a Core resilient task**, matching the Python authoritative contract
(responses-resilience-spec §6: EVERY `store=true` request runs the handler inside a Core resilient
task; only `store=false` runs inline). The B8 tension that previously blocked this was resolved
without regressing the spec-B8 semantics:

- **Row 2-streaming (store=true, background=true) and foreground streaming:** routed through the
  task, but the endpoint **relays the per-response wire stream immediately** (subscribes to the
  registry stream) instead of awaiting `ResponseCreatedSignal` before emitting SSE `200` headers.
  The task body writes `response.created` and all subsequent events to the wire stream as they
  arrive (parity with Python `_live_stream`), so the `200`-headers-then-standalone-`error` shape is
  preserved. A **pre-created failure** (Phase-1 persistence failure or a handler that throws before
  `response.created`) is recorded on the execution (`PreCreatedRelayFailure`) and re-thrown by the
  relay so `SseResult` writes a standalone `error` event with full fidelity (e.g. `storage_error`) —
  NOT an HTTP `500`. The **Phase-2** terminal is published to the wire stream by
  `CreateStreamingAsync` AFTER its persistence-rewrite step, so a terminal persist failure surfaces
  `response.failed` (not `response.completed`) on the wire stream too. Enforced by
  `tests/Protocol/PersistenceFailureTests.cs` (Phase1 standalone `storage_error` / Phase2
  `response.failed`, 8/8 green).
- **Row 3 foreground (store=true, background=false):** routed through the one-shot (or multi-turn)
  task; the foreground caller blocks until the task turn is terminal and receives the FINAL response
  inline. A foreground client disconnect cancels the shared execution CTS (the task body links it),
  terminating the turn as cancelled + ephemeral — parity with the pre-task inline behavior
  (`C1_Disconnect_Then_GET_ReturnsCancelled`, `NonBgNoStream_ClientDisconnect_GET_Returns404`).
  A terminal persistence failure re-raises the ORIGINAL storage exception (not a generic `500`),
  matching Python `run_sync` §6.2.

All `TODO(parity)` anchors in `src/Internal/ResponseEndpointHandler.cs` for these rows are removed.
The only remaining Path-C limitation is environmental: a real SIGKILL cannot be reproduced in the
single-process in-memory test host, so the post-crash recovery-scan re-entry is exercised by the
Core task-store conformance tests rather than an end-to-end Responses SIGKILL harness.

### F2 — `ExitForRecoveryAsync` must be non-swallowable and reject store=false — ✅ Resolved

Python's `ResponseContext.exit_for_recovery()` returns `NoReturn` — it **never** no-ops. It
raises `ResponseExitForRecovery(BaseException)` (deliberately **not** `Exception`, so a broad
`except Exception` in a handler cannot swallow it) and raises `RuntimeError` when called on a
`store=false` response (no durable state to recover). spec.md (~L794-796) requires (a) a
deferral signal that cannot be effectively swallowed by a broad `catch`, and (b) a
`RuntimeException` when called on a `store=false` response.

Resolved in `src/Internal/ResponseContextImpl.cs::ExitForRecoveryAsync`:

- **store=false → throw.** Calling it on a `store=false` response now throws
  `InvalidOperationException` (".NET `RuntimeException` parity", spec req b) instead of the prior
  silent no-op. The orchestrator surfaces it as a `response.failed` / server_error (handler
  detail is sanitized to the generic message on the wire, per the .NET failure taxonomy).
- **Non-swallowable deferral.** For the resilient-background case, an internal
  `ResponseContextImpl.DeferralRequested` flag is set **before** `throw new ResponseExitForRecovery()`.
  The orchestrator (`ResponseOrchestrator.ObserveSwallowedDeferral`) inspects this flag on a normal
  handler return, so even if a handler wraps the call in `try/catch (Exception) {}` the **final
  durable outcome is still deferred** (in_progress, recovery entry retained, no
  terminal/pre-terminal overwrite) — identical to the caught-signal path (FR-036).
- **store=true non-resilient (Row 2/3 non-resilient, e.g. foreground default store) → unchanged
  no-op**, consistent with the documented Row-3 scope-out and
  `ExitForRecovery_NonBackground_IsNoOp_AndCompletes` / `ExitForRecovery_Foreground_IsNoOp_Completes`.
- Evidence: `tests/Resilience/ExitForRecoveryDeferralTests.cs`
  (`ExitForRecovery_StoreFalse_Throws`,
  `ExitForRecovery_ResilientBackground_HandlerSwallowsSignal_StillDefers`,
  `ExitForRecovery_ResilientBackground_DefersWithoutTerminalOrOverwrite`);
  `tests/Protocol/ExitForRecoveryProtocolTests.cs` — green.

### F3 — Shutdown-grace handler-cancellation timing — 🟡 Intentional, tracked divergence

`.NET` fires handler cancellation **immediately** on shutdown, whereas Python does **not** fire
the cancellation signal during the shutdown grace period. This is the already-tracked
**`CR5-F2-SHUTDOWN-GRACE`** divergence and is intentional. Note that the GAP3 rubber-duck
pass **misattributed FR-025** to this: FR-025 concerns **recovery-time cancel-cause
pre-setting** (which .NET does correctly), **not** the shutdown grace period. The divergence is
therefore purely the grace-period cancellation timing, not an FR-025 gap.

### F4 — `ConversationChainMetadata` value type `string` vs Python `Any` — ✅ Accepted (justified idiom)

`ConversationChainMetadata` values are typed `string` in .NET vs Python's
`MutableMapping[str, Any]`. **This is acceptable and faithful:** the wire-level
`ResponseObject.metadata` and the persisted `_internal_metadata` both fold into an
OpenAI-standard **string-valued** map, so string-typed values are consistent with the
durable/wire contract; handlers store richer watermarks by JSON-encoding to a string.
**FR-023** ("MUST NOT impose a watermark schema") is satisfied — no key or structure is
dictated; only the value **type** is `string`. This is an accepted, justified .NET type-safety
idiom, **not** a schema imposition. Changing it would be a **public-API change** requiring
Principle-III re-review, which is not justified.

### F5 — Malformed `starting_after` error code — ✅ Resolved (test-locked)

`src/Internal/ApiErrorFactory.cs::InvalidRequest` emits `code = code ?? "invalid_request_error"`
(both `type` and `code` default to `invalid_request_error`); the reconnect endpoint's
malformed-`starting_after` `400` uses this default. Python's `_parse_starting_after` returns a
`400` with code `invalid_request`. Rather than diverge one path's code from the rest of the .NET
`400` taxonomy (all .NET `400`s use `invalid_request_error` consistently), the decision is: **do
not change production code**; instead the existing test
`tests/Endpoints/ReconnectResponsesEndpointTests.cs::Reconnect_MalformedStartingAfter_Returns400`
was **strengthened** to assert the emitted `error.type` **and** `error.code` both equal
`"invalid_request_error"` (in addition to `param=starting_after`), locking in the actual .NET
taxonomy so future drift is caught. — green.

## Python-side action items

| # | Observation | Proposed action |
|---|-------------|-----------------|
| P1 | Python samples 19/20 docstrings reference a "`sample_17` for Claude" that does not exist at the pinned commit (dir jumps 16 → 18). | Track as a Python prose fix (remove/adjust the `sample_17` reference or add the sample). .NET intentionally does **not** fabricate a `Sample17_*` port (see `docs/resilience-sample-parity.md`). No .NET divergence. |
| ~~P2~~ ✅ RESOLVED (this session) | (F1) Row 3 (foreground+store) and Row 2 (background+streaming) crash-recovery (Path C) were not task-tracked in .NET. | **Resolved:** all `store=true` rows are now routed through a Core resilient task (matching Python responses-resilience-spec §6). The B8 tension was resolved by relaying the wire stream immediately (no `ResponseCreatedSignal` await) and re-throwing a recorded `PreCreatedRelayFailure` from the relay so a Phase-1 failure stays a standalone SSE `error` (not HTTP 500), and by publishing the Phase-2 terminal from `CreateStreamingAsync` post-rewrite so a terminal persist failure stays `response.failed` (not `response.completed`). `TODO(parity)` anchors removed. Only environmental limitation remains: a real SIGKILL is unverifiable in the single-process test host (covered by Core task-store conformance tests). |
| P3 | (F3) `CR5-F2-SHUTDOWN-GRACE`: .NET fires handler cancellation immediately on shutdown; Python does not fire the cancellation signal during the shutdown grace period. | Intentional, tracked divergence. FR-025 (recovery-time cancel-cause pre-setting) is **not** implicated — .NET implements it correctly; this is purely a shutdown-grace cancellation-timing choice. Revisit only if a grace-aware cancellation policy is adopted. |
| P4 | (F4) `ConversationChainMetadata` values are `string` in .NET vs Python `MutableMapping[str, Any]`. | Accepted, justified .NET type-safety idiom. The wire/persisted metadata maps are OpenAI-standard string-valued; FR-023 (no imposed watermark schema) is satisfied — only the value type is `string`, and handlers JSON-encode richer watermarks. Changing it is a public-API change requiring Principle-III re-review; not justified. No .NET divergence in contract. |
| ~~P5~~ ✅ RESOLVED (this session) | (Finding D step 3) Foreground **streaming** conversation/steerable turns ran inline in .NET and did NOT get `conversation_locked` / `conversation_fork_not_supported` arbitration. | **Resolved:** foreground streaming conversation/steerable turns now route through the Core multi-turn task like every other `store=true` turn (same fix as P2 — immediate wire-stream relay + `PreCreatedRelayFailure` surfacing), so they get full arbitration identically to the non-streaming path. Foreground-streaming disconnect cancels the shared execution CTS → cancelled (T067). Evidence: `NonBgStreaming_Disconnect_ResultsInCancelled`, `HandlerThrowsBeforeAnyEvents_StillEmitsResponseFailedEvent`, `Streaming_HandlerThrowsResponseValidation_BeforeCreated_EmitsErrorEvent`, `PersistenceFailureTests` — green. |

_No .NET-correct-Python-wrong divergences identified in the primitive layer:
recovery payload, dispatch, chain-id, metadata, and internal-metadata strip all
match Python semantics exactly. Remaining work is conformance-test explicitness,
not behavioral parity regressions._

## Hosted parity audit loop (2026-07-14)

This loop re-audited hosted deployment behavior against Python branch
`feature/agentserver-responses-spec016` and closed one real hosted gap.

- **Resolved gap (code fixed): hosted resilient-task bypass on .NET.**
  - **Before:** `.NET` gated task composition and request routing on `!IsHosted`,
    so hosted `store=true` turns could bypass `ITaskInvoker.StartAsync`.
  - **After:** `AddResponsesServer()` composes `AddResilientTasks()` in **both**
    local and hosted environments (hosted uses `DefaultAzureCredential` +
    hosted task store), and `ResponseEndpointHandler` routes `store=true`
    turns through resilient tasks in hosted as well.
  - **Files:** `ResponsesServerServiceCollectionExtensions.cs`,
    `ResponseEndpointHandler.cs`, `ResponsesServerEndpointRouteBuilderExtensions.cs`,
    `HostedResilienceFailureTests.cs`,
    `ResilientStartFailureProtocolTests.cs`.
  - **Verification:** new hosted-path test
    `HostedBackground_StartFailure_UsesTaskInvokerPath` + updated hosted
    composition tests; full non-live suite green (**2114 pass / 0 fail**, net10).

- **Conformance audit deltas (test-quality follow-up, not runtime parity regressions):**
  0. **Resolved (2026-07-14): recovery lease reclaim intent parity in Core.**
     - `TaskEngine.TryReclaimStaleFromStoreAsync` now uses
       `LeaseService.ReclaimAsync(...)` (write intent = `Reclaim`) instead of
       `AcquireAsync(...)` (write intent = `Acquire`), matching Python's
       crash-recovery semantics: a 412 on reclaim is treated as definitive
       race-loss/abandon instead of a retryable heartbeat-style conflict.
     - **File:** `Azure.AI.AgentServer.Core/src/Tasks/Engine/TaskEngine.cs`
     - **Verification:** recovery-focused suite + full Core non-live suite green
       (`434 pass / 0 fail`, net10).
  1. **Resolved (2026-07-14): explicit Row 2 Path A and Row 3 Path A natural-completion contract tests.**
     - Added `TestRow2Row3Row4PathTests.Row2PathA_BackgroundCompletesNaturally_Completed_NoRecoveryEntry`
       and `Row3PathA_ForegroundCompletesNaturally_Completed_NoRecoveryEntry` — a handler that
       reaches its terminal within grace produces `completed` and writes **no** next-lifetime
       recovery entry. Row 3 Path C is intentionally not duplicated: at the recovery-scan level
       it collapses onto Row 2 Path C (`DispositionMarkFailed`, mark-failed-without-reinvoke),
       already covered by `TestRow2PathCCrashFailedTests`.
     - **Verification:** `TestRow2Row3Row4PathTests` green (`6 pass / 0 fail`, net10).
  2. **Resolved (2026-07-14): steering tests now assert live `PendingInputCount` and superseded-turn re-entry.**
     - `TestSteerableConversationContractTests.RealComposition_ConcurrentSteeredTurn_EnqueuesThenDrains`
       captures the live active-turn context, asserts `PendingInputCount >= 1` after a concurrent
       turn enqueues (poll-based to absorb the enqueue→count-visible race), and asserts the drained
       turn re-enters with `IsSteeredTurn = true`.
     - **Verification:** full Responses non-live suite green (`2114 pass / 0 fail`, net10).
  3. **Resolved (2026-07-14): streaming recovery ordering + monotonicity assertions strengthened.**
     - `StreamingRecoveryContractTests` now asserts a single `response.created`, contiguous +
       monotonic sequence numbers across lifetimes, the in-progress reset payload, AND explicit
       lifecycle ordering (`response.created` precedes `response.in_progress` precedes
       `response.completed`).
     - **Verification:** `StreamingRecoveryContractTests` green (net10).
  4. **Resolved (already covered): `x-platform-error-detail` assertions.**
     - Covered by `AssertPlatformErrorDetail` in `ResilientStartFailureProtocolTests`.
  5. Keep hosted wire/runtime contract checks split as:
     - deterministic hosted-wire tests (already present in Core), and
     - live hosted end-to-end recovery tests (credential-gated).

- **Python-side action items from this loop:**
  - Add an explicit steering test asserting `pending_input_count > 0` on active turns.
  - Expand hosted lifecycle/recovery contract tests beyond live/skipped paths.

## Convergence status

- Primitive + surface + docs/samples layer: **fresh-mind reviewed, parity
  confirmed, green**.
- Deep-orchestration layer: **✅ composed on Core `001` primitives, green** — the
  CC-RE migration landed (bespoke recovery/leasing/steering removed), and the
  CR-FINAL holistic review findings (Issue 1 internal-metadata persist, Issue 3
  dead-method comment, Issue 4 fail-loud task-invoker desync) are resolved with
  tests.
- Dispatch/primitive-selection layer: **✅ Python `_pick_primitive` parity, green**
  — GAP2 Finding 1 (always-on local task subsystem; default-options
  `conversation_locked`; Row 2 non-streaming mark-failed recovery) and Finding 2
  (`starting_after` 400) resolved; two Path-C-only rows tracked as P2. Test-state
  isolation fixture added (`tests/TestStateRootFixture.cs`). Full non-Live suite:
  **2099 pass / 0 fail**.
- GAP3 rubber-duck adjudication: **complete**. Five findings adjudicated — **F2**
  (non-swallowable `ExitForRecoveryAsync` + store=false `InvalidOperationException`) and
  **F5** (malformed `starting_after` taxonomy test-locked) are **resolved in code**; **F1**
  (two Path-C-only sub-rows), **F3** (`CR5-F2-SHUTDOWN-GRACE` grace-period cancellation
  timing; FR-025 explicitly **not** implicated), and **F4** (`ConversationChainMetadata`
  `string` value type) are **documented, intentional divergences / tracked action items**
  (P2–P4 above), not silent gaps. No new .NET-side gap re-opens GAP2. Full non-Live suite
  remains **2099 pass / 0 fail**.

### GAP3 convergence loop — re-review findings (A–D) + store=false foreground fix

Two further adversarial re-reviews (fresh-mind, different model family) drove the loop
to convergence. All fixes landed green-or-revert; the full non-Live suite ended at
**2109 pass / 0 fail**.

- **A — namespace `FlushAsync()` isolation — ✅ resolved.** `ConversationChainMetadata.FlushAsync()`
  now flushes only the default namespace and `ConversationChainMetadataNamespace.FlushAsync()`
  flushes only its own namespace (via `FlushNamespaceAsync(name)`), matching Python's
  per-namespace `flush()`. Test: `DurableConversationChainMetadataFlushIsolationTests`.
- **B — `shutdown_reason` emission — ✅ resolved.** Path-B Row 2/3 grace-exhausted terminal
  failures now carry `error.additionalInfo.shutdown_reason = grace_exhausted`; Path-C crash
  recovery carries `crash_recovery`, matching Python. Wired via `ResponseMutations.SetFailed(...)`
  + `EmitTerminalFailureAsync(shutdownReason)`.
- **C — `ExitForRecovery` swallow-then-terminal hole — ✅ resolved.** A deferral signal that is
  swallowed by broad `catch` is now observed both post-iteration AND at the top of the event
  loop (`DeferralRequested` guard in `ProcessEventsAsync`), so a subsequent terminal event
  cannot mask the requested recovery. Tests: `ExitForRecoveryDeferralTests`.
- **D — foreground multi-turn arbitration — ✅ resolved (non-streaming); foreground STREAMING
  tracked P5.** Foreground non-streaming conversation/steerable turns now route through the
  Core multi-turn task so FR-051/FR-052 arbitration (`conversation_locked` /
  `conversation_fork_not_supported`) applies generally, not only to background. Foreground
  streaming remains inline (P5 above — B8/deadlock tension).
- **store=false foreground regression (final High) — ✅ resolved.** Because
  `SteerableConversations=true` makes `pickMultiTurn` true for every request, a foreground
  non-streaming **store=false** turn began routing through the multi-turn task (Finding D). The
  foreground branch unconditionally called `GetAsync(responseId)`, which deliberately 404s for
  `store=false` (B14), failing the POST. Fixed: the foreground multi-turn branch returns the
  in-memory terminal snapshot (`execution.Response.Snapshot()`) for `store=false` instead of
  fetching by id; the task handler reuses the endpoint's pre-created `ResponseExecution`, so the
  snapshot is populated. Test:
  `TestSteerableConversationContractTests.ForegroundSteerable_StoreFalse_ReturnsEphemeralResponse_NotRetrievable`
  (200 + `completed`, then GET → 404 confirming ephemeral B14 semantics). Full non-Live suite:
  **2109 pass / 0 fail**.
