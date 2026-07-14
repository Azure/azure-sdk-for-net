# Resilient Responses — Normative Contract (.NET)

This is the **normative** conformance contract for the resilient background
responses feature in `Azure.AI.AgentServer.Responses`. It is the .NET companion
to the Python `resilience-contract.md` and mirrors its clause set 1:1. Where the
developer guide
([`resilient-responses-developer-guide.md`](resilient-responses-developer-guide.md))
explains *how* to build a resilient handler, this document specifies *what the
framework guarantees* — the exact observable behaviour a conformance test may
rely on, per row, per termination path, per stream/poll mode.

Every normative clause below maps to a .NET conformance test in
[`../tests/e2e/resilience_contract/CONTRACT_COVERAGE.md`](../tests/e2e/resilience_contract/CONTRACT_COVERAGE.md)
(the coverage matrix). The completeness meta-test
`ContractCoverageCompletenessTests` (T059/T080) fails CI if any row×path cell in
that matrix is left uncovered **or** declares no assertion depth. Treat any
divergence between this document and the shipped behaviour as a bug in one or
the other — do not weaken a test to make it pass (see
[`ResilienceConformanceAssertionIntegrityTests`](../tests/Protocol/ResilienceConformanceAssertionIntegrityTests.cs)
and [`ConformanceDeltaGuardTests`](../tests/Protocol/ConformanceDeltaGuardTests.cs)).

## Composition model (how the guarantees are produced)

The Responses layer **composes** the Core task/streaming primitives; it does
**not** re-implement recovery, steering, or stream replay. A resilient
background response runs *inside* a Core task via `ITaskInvoker`:

- **One-shot** (`responses_resilient_one_shot`, a Core `@task`) — a
  non-conversational resilient background turn. Auto-deleted on terminal exit.
- **Multi-turn** (`responses_resilient_multi_turn`, a Core `@multi_turn_task`,
  `steerable` iff `SteerableConversations`) — a conversational chain. Suspends
  between turns; each turn is one input to the same task.

The Core task subsystem is engaged for **every stored (`store=true`) response** —
foreground or background, streaming or non-streaming — so an interrupted turn is
always task-tracked and reclaimed by the next-lifetime recovery scan (matching the
Python resilience contract; the disposition — re-invoke vs mark-failed — is chosen
per row, see below). Only ephemeral (`store=false`, Row 4) responses run inline
without a task. In a local (non-hosted) sandbox the task store is file-backed.
There is no bespoke Responses-side recovery service, conversation arbitrator, or
stream stack: the Responses layer owns only (a) **dispatch selection** and (b) the
**Core-exception → HTTP-error mapping**.

### Dispatch selection (`ResponseEndpointHandler` / `ResponseResilienceDispatch`)

The primitive is picked by one decision site:

```
multi-turn  iff  conversation_id != null  OR  SteerableConversations
one-shot    otherwise
```

`previous_response_id` **alone does not** select multi-turn — a chained turn
without a `conversation_id` and without `SteerableConversations` still routes to
the one-shot task (its chain identity is derived, see
[§Conversation chain identity](#conversation-chain-identity)).

## Row classification

`ResponseResilienceDispatch.ClassifyRow` / `DecideDisposition` is the single
classifier, matching the Python truth table:

```
ClassifyRow(store, background, resilientBackground):
    if !store:                    row 4
    elif !background:             row 3
    elif resilientBackground:     row 1
    else:                         row 2

DecideDisposition:
    background && resilientBackground && store  →  re-invoke
    otherwise                                    →  mark-failed
```

| Row | `store` | `background` | `ResilientBackground` | Disposition on interruption |
|-----|---------|--------------|-----------------------|-----------------------------|
| 1 | true | true | true | **re-invoke** (`IsRecovery = true`) |
| 2 | true | true | false | **mark-failed** (`server_error`) |
| 3 | true | false | n/a | **mark-failed** (`server_error`) |
| 4 | false | n/a | n/a | no persisted state; no next-lifetime action |

## Termination paths

Every row is specified across three termination paths:

- **Path A — natural terminal**: the handler reaches a terminal event within the
  process lifetime.
- **Path B — graceful shutdown**: shutdown grace is exhausted, or the handler
  calls `ExitForRecoveryAsync()`; an in-process marker fires.
- **Path C — crash (SIGKILL / Path-B failure)**: the next process lifetime's
  recovery scan fires.

## Per-cell assertion depth

The matrix's **Dimension** column is the normative *assertion-depth* declaration
for each cell. A conformance test for a cell MUST assert to at least the declared
depth. `ContractCoverageCompletenessTests` (T080) enforces that every `covered`
row declares a non-empty depth. The depth vocabulary:

| Depth token | The test must assert… |
|-------------|-----------------------|
| `response.status` | the terminal `status` field (`completed` / `failed` / `cancelled` / `incomplete` / `queued`). |
| `response.error` | the `error.code` (and, where specified, `error.type`, `error.param`, and `shutdown_reason` additional info). |
| `event sequence` | the ordered set / presence of SSE event types across the (possibly multi-lifetime) stream. |
| `seq monotonicity` | `sequence_number` is strictly increasing and contiguous across lifetimes; the recovered reset's seq strictly exceeds the pre-crash max. |
| `event content` | the payload carried by a specific event (e.g. the recovered `response.in_progress` reset carries the corrected output). |
| `response.output content` | the final `response.output` items are correct (right count, right per-phase text, no loss/dup across recovery). |
| `metadata` | a `ConversationChainMetadata` / internal-metadata guarantee (durability, namespace isolation, `_`-rejection, persist-but-strip). |
| `chain id` | the derived `conversation_chain_id` shape/stability. |
| `payload schema` | the persisted recovery payload's field set / types / casing / round-trip. |
| `dispatch` | the row classification / disposition / primitive selection. |
| `recovery drop` | the pre-dispatch recovery-drop precondition (see below). |
| `composition guard` | a startup / request-time fail-loud guard. |
| `meta` | a meta-property (e.g. GET returns 404; no recovery entry created). |

A cell may declare more than one depth (`;`-separated). The test named in that
row must reach **every** declared depth.

## Signal-type and stream-mode coverage

Row 1 and Row 11 cells must be exercised in **both** stream modes:

- **stream=false (poll)** — the client GETs the terminal response; depth is
  `response.status` + `response.output content`.
- **stream=true (SSE)** — the client consumes/replays the event stream; depth
  adds `event sequence`, `seq monotonicity`, and (on recovery) `event content`.

The interruption **signal type** must be distinguished where it changes the
outcome:

| Signal | `ClientCancelled` | `IsShutdownRequested` | Steering pressure | Outcome |
|--------|-------------------|-----------------------|-------------------|---------|
| Client cancel | true | — | — | `cancelled`; no terminal emitted by handler. |
| Graceful shutdown | — | true | — | Row 1: defer (`ExitForRecoveryAsync`) → re-invoke; Row 2/3: `failed` (`shutdown_reason = grace_exhausted`). |
| Crash (SIGKILL) | — | — | — | Row 1: next-lifetime re-invoke (`shutdown_reason = crash_recovery`); Row 2/3: `failed`. |
| Steering pressure | false | false | queue non-empty | superseded turn emits `completed` with partial content; superseder sees `IsSteeredTurn = true`. |

## Normative clauses

### 1. Persisted recovery payload (`payload schema`)

The persisted recovery payload has **exactly nine** fields: `response_id`,
`disposition`, `request`, `agent_reference`, `agent_session_id`, `user_id_key`,
`call_id`, `client_headers`, `query_parameters`. Everything else
(`store`/`background`/`stream`/`model`/`previous_response_id`/`conversation_id`/
`input_items`/history item ids) is **re-derived** on recovery and MUST NOT be
persisted. Client headers and query parameters are preserved **verbatim** (never
dropped to `{}`). Deserialization is **fail-closed**: a missing/malformed/
wrong-type required field fails deterministically *before* dispatch (never a
partial re-invoke). A missing `disposition` defaults to `re-invoke` (backward
compat).

### 2. Recovered-input parity (`event content`)

On a recovered re-invocation the handler observes the **same** `request`,
`ClientHeaders`, `QueryParameters`, and `GetInputItemsAsync()` it saw on fresh
entry — nothing dropped or altered. The only differences are `IsRecovery == true`
and the entry-only `PersistedResponse` snapshot.

### 3. Row 1 — re-invoke (`response.status`; `response.output content`)

- **Path A**: handler reaches terminal within grace → `completed`.
- **Path B**: grace exhausted / `ExitForRecoveryAsync()` → stays `in_progress`;
  next lifetime re-invokes with `IsRecovery = true`.
- **Path C**: crash → next lifetime re-invokes with `IsRecovery = true`.
- **Path C + SSE keep-alive**: keep-alive comments MUST NOT prevent task creation
  or recovery; the recovered response.output is correct.

### 4. Rows 2 / 3 — mark-failed (`response.status`; `response.error`)

- **Row 2 (A/B/C)**: non-resilient background → `failed`, `error.code =
  server_error`. A recovery task entry **is** created with the **mark-failed**
  disposition; the next-lifetime scan marks the response `failed` **without
  re-invoking** the handler, then clears the entry (only Row 1 re-invokes).
- **Row 3 (A/B/C)**: foreground (`store=true`, `background=false`) → `failed`,
  `error.code = server_error`. Also task-tracked with the **mark-failed**
  disposition (same recovery-scan behavior as Row 2).
- `shutdown_reason` additional info: `grace_exhausted` (Path B) or
  `crash_recovery` (Path C).

### 5. Row 4 — ephemeral (`response.status`; `meta`)

`store=false` → returned inline; GET returns **404**; no persisted state and no
next-lifetime action.

### 6. Row 11 — developer checkpoints (`event content`; `response.output content`; `metadata`)

Row 11 is Row 1 with `stream.Checkpoint()` at phase boundaries.

| Cutpoint | Guarantee |
|----------|-----------|
| C1 (after a successful checkpoint) | recovery resumes at the **next** phase. |
| C3 (before any checkpoint) | the un-checkpointed phase **re-runs** from scratch. |
| C4 (post-terminal checkpoint) | **silently dropped** (no-op after terminal). |
| C5 (checkpoint store failure) | **swallowed**; recovery sees the prior snapshot; tagged as a platform error, never a torn snapshot. |

Checkpoint writes are a **no-op** unless the response is resilient background
(Row 1), and are **idempotent** (byte-compared — an unchanged snapshot skips the
write). `ResponseCheckpointEvent` is an internal control signal and is **never**
forwarded to the SSE wire.

### 7. Streaming reconnect sub-contract (`event sequence`; `seq monotonicity`; `event content`)

`GET /responses/{id}?stream=true&starting_after={cursor}`:

- `starting_after` uses **strict `>`** semantics (only `sequence_number > cursor`).
  Absent → `-1` → replay from the beginning.
- `response.created` is emitted **exactly once** across all lifetimes (suppressed
  at the provider write when the stream already has events).
- A recovered handler emits `response.in_progress` (not `response.created`) as its
  **first** event; that reset carries the corrected `response.output` seeded from
  `PersistedResponse`, with `sequence_number` strictly greater than the pre-crash
  maximum.
- An `output_item.added` at a previously-used `output_index` on recovery triggers
  **replacement** semantics (not a new slot).
- Events are appended to the resilient stream **before** the wire flush, so a
  reconnecting client can replay history it never received live.

### 8. Steering sub-contract (`response.status`; `response.error`; `metadata`)

With `SteerableConversations = true`:

- A new POST for an in-progress chain is **queued** (envelope `status = queued`);
  the running turn observes `PendingInputCount > 0`.
- The drain re-entry (the superseding turn) sees `IsSteeredTurn = true`; the
  superseded turn is NOT a recovery entry.
- **Fork** (a `previous_response_id` that is not the most recent turn) → HTTP
  **409** `conversation_fork_not_supported` (`type = conflict`,
  `param = previous_response_id`). Triggered by the Core last-input-id
  precondition failure.
- **Overlap / queue-full** (a concurrent non-steerable turn, or a full steering
  queue) → HTTP **409** `conversation_locked` (`type = conflict`). Triggered by
  the Core task-conflict.

> `conversation_id` chains extend sequentially even with
> `SteerableConversations = false`; only **concurrent overlap** returns 409
> `conversation_locked`. The option only controls whether mid-turn inputs are
> queued (steerable) vs rejected (non-steerable).

### 9. Recovery-drop precondition (pre-dispatch) (`recovery drop`)

Before a recovered turn is dispatched, the recovery layer checks whether the
response still exists in the store:

- **Definitive not-found** → the recovery entry is **dropped**: the handler is
  NOT re-invoked and a subsequent GET returns 404. (A response deleted or never
  durably created must not be resurrected.)
- **Transient store error** (the store is momentarily unavailable, not a
  definitive miss) → the entry is **NOT dropped**: recovery proceeds (with
  `PersistedResponse == null` if the snapshot could not be read). A transient
  blip must never cause silent data loss of an in-flight resilient turn.

This precondition is evaluated **before** dispatch selection so a dropped entry
never reaches `ITaskInvoker`.

### 10. Conversation chain identity (`chain id`)

`ResponseContext.ConversationChainId` is a **derived, stable** identifier: every
turn of the same conversation resolves to the same value, and it is constant
across all attempts of a turn (fresh, recovered, multiply-recovered). Derivation
anchors to the conversation root: a `conversation_id` pins the chain
(`cchain_…`); otherwise the head of a `previous_response_id` chain pins it
(`rchain_…`); a first turn with neither falls back to its own `response_id`
verbatim. The digest is cross-language stable with Python.

### 11. Metadata (`metadata`)

`ConversationChainMetadata` is a callable/named-namespace facade over the Core
task metadata checkpoint store. Persistence is **explicit** — call
`FlushAsync()` before any side effect whose durability must survive a crash.
Namespaces are isolated (each tracks dirty state independently). Namespace names
and keys beginning with `_` are **rejected** (reserved for framework-internal
namespaces such as `_responses`). On the base (non-resilient) context,
`FlushAsync()` is a no-op.

**Internal metadata (persist-but-strip)**: `internal_metadata` (item-level) and
`_internal_metadata` (response-level, inside `metadata`) are persisted (survive
crashes) but **stripped at every egress** and never reach the client wire. If
stripping `_internal_metadata` empties `metadata`, `metadata` normalizes to
`null`.

### 12. Fail-loud composition (`composition guard`; `response.error`)

Resilience never silently downgrades:

- **Startup**: `ResilientBackground = true` with a non-persistent (in-memory)
  store → the host **refuses to start** with an actionable error naming the
  offending store and the three remedies (supply a persistent store, omit the
  store, or set `ResilientBackground = false`).
- **Request-time, non-stream**: a resilient-start failure → HTTP **500** with
  `x-platform-error-source: platform` and `x-platform-error-detail:
  {Type}: {message}`.
- **Request-time, stream (pre-stream)**: a start failure before the stream opens
  → HTTP **500** + `x-platform-error-source: platform`. A failure *after*
  `response.created` surfaces as a `response.failed` SSE event with
  `error.code = server_error`.
- **Error source header** values: `user` (400 validation), `platform` (tagged
  platform error, 500), `upstream` (unhandled handler exception, 500). Storage
  errors (checkpoint / create / update) are tagged as platform errors.

## Sample-path conformance

The published resilient samples are themselves part of the contract surface. The
E2E parity tests
([`ResilienceSampleParityEndToEndTests`](../tests/e2e/resilience_contract/ResilienceSampleParityEndToEndTests.cs))
drive the documented flow of each required sample through the real Core-composed
engine and assert its observable contract:

| Sample | Flow | Observable contract asserted |
|--------|------|------------------------------|
| 19 — resilient streaming | background + stream, 3 phases with checkpoints | monotonic contiguous event stream; one `response.created`; `completed` with one output item per phase |
| 20 — resilient steering | steerable multi-turn | a concurrent turn enqueues (`queued`) then drains as a steered re-entry (`IsSteeredTurn`) |
| 22 — resilient multi-turn | serial conversation chain | per-turn state accumulates across turns via durable chain metadata + history |

See [`resilience-sample-parity.md`](resilience-sample-parity.md) for the full
Python↔.NET sample mapping and the explicit omission rationale for Python
samples 18/21 and the non-existent `sample_17`.
