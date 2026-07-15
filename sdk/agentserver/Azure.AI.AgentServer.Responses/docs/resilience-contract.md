# Resilience Contract — Conformance Specification (.NET)

**Status**: Authoritative conformance contract for the resilience behaviour of
`Azure.AI.AgentServer.Responses`. This document defines the per-row × per-path
guarantees that the resilience-contract conformance suite enforces. It is the
.NET companion to the Python `resilience-contract.md` and mirrors its normative
clause set except where this .NET package intentionally diverges. Where the
[`resilient-responses-developer-guide.md`](resilient-responses-developer-guide.md)
explains *why* and *how* resilience works, this document states the precise,
testable promises for dispatch, recovery, streaming, checkpoints, steering, and
composition.

**Normative ownership (single edit point).** This document is the **single
normative source** for the .NET dispatch matrix and its per-cell dispositions,
the streaming sub-contract, the recovered-entry precondition, and the
handler/framework obligations. Companion guides may summarize these clauses for
readability, but the normative edit for any of them is made **here**; on
conflict, this contract is authoritative for `Azure.AI.AgentServer.Responses`.

**Audience**: Framework maintainers, handler authors, SDK reviewers, and
conformance-test authors.

This document defines:

- The **flags and server option** that select a resilience behaviour.
- The **termination lifecycle** — the three paths a server lifetime can take
  when a request is in flight.
- The **matrix** — for each flag combination, what the framework promises on
  each termination path.
- The **developer checkpoint-write contract** (Row 11) — the
  `stream.Checkpoint()` write point and its recovery semantics.
- The **streaming sub-contract** layered on top when `stream=true`.
- The **composition rules** (which flag combinations require which providers).
- The **test discipline** the conformance suite follows.

---

## How to read this document

1. Handler authors asking "what happens if the server dies?" read **The
   matrix**, then their row's **Per-row contract**, then **Handler obligations**.
2. Maintainers changing anything near resilience read the whole document and
   keep every row × applicable-path behaviour intact (see **Test discipline**).

The terms `MUST`, `MUST NOT`, `SHOULD`, and `MAY` follow RFC 2119.

---

## Concepts

### Request flags

Three boolean flags on the request select the resilience shape:

- **`store`** *(request body, default `true`)* — whether the response and its
  events are persisted to the configured response store.
- **`background`** *(request body, default `false`)* — whether the request
  returns immediately with an `in_progress` response that clients poll or
  stream-reconnect to observe.
- **`stream`** *(request body, default `false`)* — whether the response is
  delivered as SSE events on the original connection. It is independent of the
  resilience row; see the **Streaming sub-contract**.

### Server option

- **`ResilientBackground`** *(server option, default `false`)* — whether the
  framework engages full crash-recovery for `background=true, store=true`
  requests. When `true`, the supporting providers MUST be present (see
  **Composition rules**); the server fails loud otherwise.

### Composition model

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
always task-tracked and reclaimed by the next-lifetime recovery scan. The
disposition — re-invoke vs mark-failed — is chosen per row. Only ephemeral
(`store=false`, Row 4) responses run inline without a task. In a local
(non-hosted) sandbox the task store is file-backed. There is no bespoke
Responses-side recovery service, conversation arbitrator, or stream stack: the
Responses layer owns only (a) **dispatch selection** and (b) the
**Core-exception → HTTP-error mapping**.

### Dispatch selection and row classification (`ResponseEndpointHandler` / `ResponseResilienceDispatch`)

The primitive is picked by one decision site:

```
multi-turn  iff  conversation_id != null  OR  SteerableConversations
one-shot    otherwise
```

`previous_response_id` **alone does not** select multi-turn — a chained turn
without a `conversation_id` and without `SteerableConversations` still routes to
the one-shot task (its chain identity is derived, see
[Conversation chain identity](#r6--conversation-chain-identity-chain-id)).

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

### Termination paths

Every in-flight request faces one of three paths from the moment the process
receives a termination signal (or crashes). The matrix specifies a contract per
path.

- **Path A — graceful shutdown, handler reaches terminal within grace.** New
  requests are refused; in-flight handlers continue; the handler reaches a
  terminal state before grace expires. The happy path; identical across rows.
- **Path B — graceful shutdown, grace exhausted with handler still running.**
  The framework signals shutdown and cancels the in-flight execution tokens, then
  waits for handlers to unwind cooperatively. A handler that unwinds (observes
  cancellation and exits) triggers the row's in-process action, responding to
  waiting clients in this lifetime where a response is still observable. If a
  handler does **not** unwind before the host's shutdown timeout, the process
  exits with the turn still in flight and **Path C** applies on the next lifetime.
- **Path C — crash, or a graceful shutdown whose Path-B action did not run**
  (SIGKILL, OOM, power loss, a hang during the shutdown loop). On the next
  process lifetime the framework scans persisted state and applies the row's
  restart contract. Path C is the complete fallback for Path B.

A single termination event is handled by exactly one path.

### Resilient record

Every accepted `store=true` request is registered with the underlying resilient
Core task primitive at acceptance time. The registration carries the response id,
the row's Path-C disposition (`re-invoke` for Row 1, `mark-failed` for Rows 2
and 3), and the persisted recovery payload described in **R1**. `store=false`
requests have no resilient record; Path C does not apply.

### Recovered entry

On a recovered re-invocation (Row 1 Path B post-restart, or Path C) the handler
observes `IsRecovery == true`. Its cross-turn checkpoint store is
`ConversationChainMetadata`; its single-turn, per-response watermark surface is
`internal_metadata`. The handler seeds its resumption from the entry-only
`PersistedResponse` snapshot (the last resiliently persisted snapshot; see
Row 11).

**Recovery precondition (persisted response required).** The framework
re-invokes the handler only if the response still exists in the response store.
If the response is **definitively absent** on recovery (a typed not-found from
the store), the framework MUST drop the resilient execution: no re-invocation,
no `response.*` stream events, no terminal write, and the task is settled so the
recovery scan does not re-select it. This applies to **both `stream=false` and
`stream=true`** resilient background recovery — the gate runs before the
stream-vs-non-stream dispatch. A transient/ambiguous store error is NOT a
definitive absence and MUST NOT trigger a drop.

**Recovered-input parity (recovery == fresh entry).** A recovered handler MUST
observe the **identical request-scoped inputs** it would on fresh entry:
`request`, `ClientHeaders`, `QueryParameters`, and `GetInputItemsAsync()`
(resolved and unresolved) are equal to their fresh-entry values. The only
handler-visible differences on recovery are `IsRecovery == true` and the
entry-only `PersistedResponse` snapshot — never dropped or altered
inputs/metadata.

---

## The matrix

The matrix is the per-row × per-path contract. Rows 1–4 are keyed on the three
flags (`store`, `background`, `ResilientBackground`); `stream` is intentionally
NOT a row key (the contract is mode-flag agnostic with respect to `stream`, and
the streaming sub-contract specifies how it is delivered). Row 11 is a
**checkpoint-write extension of Row 1** — it has Row 1's flags and adds the
developer `stream.Checkpoint()` write point; its cutpoints are detailed in its
per-row contract.

| Row | `store` | `background` | `ResilientBackground` | Path A (within-grace) | Path B (grace exhausted) | Path C (crash / Path-B failure) |
|----:|---------|--------------|-----------------------|-----------------------|--------------------------|---------------------------------|
| 1 | `true` | `true` | `true` | natural terminal | hand the in-flight handler to Core recovery; runtime exits; next lifetime re-invokes the handler with `IsRecovery = true` | next lifetime re-invokes the handler with `IsRecovery = true` |
| 2 | `true` | `true` | `false` | natural terminal | mark response `failed` (`error.code = server_error`) in-process before exit; respond to waiting clients | next lifetime marks response `failed` (`error.code = server_error`) without re-invoking the handler |
| 3 | `true` | `false` | any | natural terminal | mark response `failed` (`error.code = server_error`) in-process before exit; respond to waiting clients | next lifetime marks response `failed` (`error.code = server_error`) without re-invoking the handler |
| 4 | `false` | `false` | any | natural terminal / inline result | no persisted state; original inline connection may close | no recovery applies (no persisted state) |
| 11 | `true` | `true` | `true` | all phases checkpoint + complete; final `response.output` reflects every phase | handler at a checkpoint boundary calls `ExitForRecoveryAsync()`; recovery resumes from the last checkpointed snapshot | crash at a checkpoint boundary; recovery resumes from the last checkpointed snapshot |

Read every cell as a MUST for the framework. Path A is identical across Rows
1–4 because no framework intervention is needed.

> **Pre-matrix rejection.** `background=true` with `store=false` is **rejected
> before the matrix** — the endpoint returns HTTP **400** (`code =
> unsupported_parameter`, `param = background`) because a background response
> cannot be observed later without persistence. That is why Row 4's `background`
> column is `false`, not `any`.

---

## Per-row contracts

### Row 1 — Full recovery (`store=true, background=true, ResilientBackground=true`)

**Path A.** Handler completes within grace. Standard happy path; the response
reaches `completed`.

**Path B.** Grace expires with the handler still running, or the handler calls
`ExitForRecoveryAsync()`. The framework MUST hand the in-flight handler to Core
recovery (NOT mark it `failed`) and exit; the response stays `in_progress`, and
the next lifetime re-invokes the handler with `IsRecovery = true`.

**Path C.** SIGKILL or a Path-B action that did not complete. On the next
lifetime the framework finds the resilient record and re-invokes the handler
with `IsRecovery = true`.

**Recovered handler entry contract** (Path B post-restart and Path C):

- `IsRecovery == true`.
- `ConversationChainMetadata` carries any cross-turn checkpoint state the handler
  flushed in a prior lifetime.
- The framework does not impose a watermark schema. The handler chooses what it
  stores and how it resumes.
- For streaming, the recovered handler emits a `response.in_progress` reset
  event as its first client-visible event (see **Streaming sub-contract**).
- Graceful-shutdown recovery is requested with the single uniform primitive
  `ExitForRecoveryAsync()`, which works in every supported handler shape.
- **Path C + SSE keep-alive**: keep-alive comments MUST NOT prevent task
  creation or recovery; the recovered `response.output` is correct.

### Row 2 — Marked failed (`store=true, background=true, ResilientBackground=false`)

A stored, observable response without crash recovery.

**Path A.** Handler completes within grace. Standard.

**Path B.** The in-process shutdown loop MUST mark the response `failed`
(`error.code = server_error`), persist the terminal observation, and respond to
waiting clients in this lifetime. `shutdown_reason` additional info is
`grace_exhausted`.

**Path C.** On the next lifetime the framework finds the resilient record
(disposition `mark-failed`) and marks the response `failed`
(`error.code = server_error`) **without re-invoking** the handler, then clears
the entry. `shutdown_reason` additional info is `crash_recovery`.

### Row 3 — Marked failed, foreground (`store=true, background=false`, any `ResilientBackground`)

A stored response observable over the original (foreground) HTTP connection.
`ResilientBackground` is a free axis — foreground responses do not benefit from
resilient handler recovery because the client connection is gone. Path A/B/C
have the same shape as Row 2; all failure markers use `error.code =
server_error`, are task-tracked with the **mark-failed** disposition, and never
re-invoke the handler.

### Row 4 — Ephemeral (`store=false`, `background=false`, any `ResilientBackground`)

In-memory-only, no persistence, no recovery. (`background=true` with `store=false`
is rejected before this row — see the pre-matrix rejection note above.)

**Path A.** Handler completes within grace. Standard inline result.

**Path B.** No persisted state exists. The original HTTP connection may already
be closing, and there is no next-lifetime action to schedule.

**Path C.** No persisted state, so no next-lifetime action applies. A subsequent
GET returns **404**.

> **Not every `store=false` turn runs purely inline.** A `store=false` turn that
> participates in a conversation or steerable arbitration (a non-streaming
> conversational turn) can still be routed through the Core task subsystem to
> serialize turns on the chain. That routing provides ordering/steering
> arbitration only — it does **not** add persistence or Path-C recovery, so the
> ephemeral contract above still holds.

### Row 11 — Developer checkpoint write (extension of Row 1)

Row 11 covers the `stream.Checkpoint()` write point used by the
**one-output-item-per-phase** resilient pattern. A handler emits one output item
per logical phase and checkpoints at each phase boundary; the checkpoint
persists a snapshot whose `output` holds exactly the phases completed so far. On
recovery the handler seeds the stream from `PersistedResponse` so the
already-checkpointed phases' items are present in `response.output`, then
resumes at the next phase. This makes the recovery resume-point directly
observable in the recovered `response.output`.

`stream.Checkpoint()` is gated to resilient background responses
(`ResilientBackground=true` + `store=true` + `background=true`) and is a no-op
otherwise. Checkpoint writes are **idempotent** (byte-compared — an unchanged
snapshot skips the write). `ResponseCheckpointEvent` is an internal control
signal and is **never** forwarded to the SSE wire.

**Cutpoints** (the failure boundaries the contract guarantees, expressed in the
one-item-per-phase model):

| Cutpoint | Guarantee |
|----------|-----------|
| C1 (after a successful checkpoint) | recovery resumes at the **next** phase. |
| C3 (before any checkpoint) | the un-checkpointed phase **re-runs** from scratch. |
| C4 (post-terminal checkpoint) | **silently dropped** (no-op after terminal). |
| C5 (checkpoint store failure) | **swallowed**; recovery sees the prior snapshot; tagged as a platform error, never a torn snapshot. |

**Path A.** All phases checkpoint and the handler reaches a natural terminal;
the final `response.output` reflects every phase produced by the fresh entry.

**Path B.** The handler is parked at a checkpoint cutpoint when grace is
exhausted; it observes shutdown, calls `ExitForRecoveryAsync()`, and the
framework leaves the response `in_progress`. On restart the handler resumes from
the checkpointed snapshot. The deferral MUST NOT overwrite the last checkpoint
snapshot with a pre-terminal record.

**Path C.** Crash at a checkpoint cutpoint; on restart recovery resumes from the
last checkpointed snapshot.

**Contract-surface depth.** Row 11 conformance tests assert the recovered
`response.output` *content* using per-lifetime-identifiable markers so the
resume-point — and the absence of loss or duplication — is directly visible, not
just terminal `status`.

---

## Assertion depth and signal coverage

Each normative clause carries an *assertion-depth* expectation: a conformance
test for a clause MUST assert to at least the depth described below.

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
| `recovery drop` | the pre-dispatch recovery-drop precondition. |
| `composition guard` | a startup / request-time fail-loud guard. |
| `meta` | a meta-property (e.g. GET returns 404; no recovery entry created). |

A cell may declare more than one depth (`;`-separated). The test named in that
row must reach **every** declared depth.

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

---

## Normative invariants

### R1 — Persisted recovery payload (`payload schema`)

The persisted recovery payload has **exactly nine top-level** fields:
`response_id`, `disposition`, `request`, `agent_reference`, `agent_session_id`,
`user_id_key`, `call_id`, `client_headers`, `query_parameters`. Fields such as
`store`/`background`/`stream`/`model`/`previous_response_id`/`conversation_id`/
`input_items`/history item ids are **not persisted as separate top-level payload
fields** — they are re-derived on recovery from the persisted `request` (which is
stored verbatim as the `request` field above). Client headers and query
parameters are preserved **verbatim** (never
dropped to `{}`). Deserialization is **fail-closed**: a missing/malformed/
wrong-type required field fails deterministically *before* dispatch (never a
partial re-invoke). A missing `disposition` defaults to `re-invoke` (backward
compat).

### R2 — Recovered-input parity (`event content`)

On a recovered re-invocation the handler observes the **same** `request`,
`ClientHeaders`, `QueryParameters`, and `GetInputItemsAsync()` it saw on fresh
entry — nothing dropped or altered. The only differences are `IsRecovery == true`
and the entry-only `PersistedResponse` snapshot.

### R3 — Streaming reconnect sub-contract (`event sequence`; `seq monotonicity`; `event content`)

`GET /responses/{id}?stream=true&starting_after={cursor}`:

- `starting_after` uses **strict `>`** semantics (only `sequence_number > cursor`).
  Absent → `-1` → replay from the beginning.
- `response.created` is emitted **exactly once** across all lifetimes (suppressed
  at the provider write when the stream already has events).
- A recovered handler emits `response.in_progress` (not `response.created`) as its
  **first client-visible** event; that reset carries the corrected
  `response.output` seeded from `PersistedResponse`, with `sequence_number`
  strictly greater than the pre-crash maximum.
- An `output_item.added` at a previously-used `output_index` on recovery triggers
  **replacement** semantics (not a new slot).
- Events are appended to the resilient stream **before** the wire flush, so a
  reconnecting client can replay history it never received live.

**Client-side rule.** A streaming client MUST reset its accumulator on every
`response.in_progress` event after the first.

### R4 — Steering sub-contract (`response.status`; `response.error`; `metadata`)

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

### R5 — Recovery-drop precondition (pre-dispatch) (`recovery drop`)

Before a recovered turn is dispatched, the recovery layer checks whether the
response still exists in the store:

- **Definitive not-found** → the recovery entry is **dropped**: the handler is
  NOT re-invoked and a subsequent GET returns 404. (A response deleted or never
  durably created must not be resurrected.)
- **Transient store error** (the store is momentarily unavailable, not a
  definitive miss) → the entry is **NOT dropped** and the handler is **NOT**
  re-invoked with a null snapshot: the recovery layer defers the turn (exits the
  Core task for a later recovery and rethrows) so the next recovery scan retries
  once the durable record can be read. A transient blip must never cause silent
  data loss of an in-flight resilient turn, and must never dispatch the handler
  against an unread snapshot.

This precondition is evaluated **before** dispatch selection so a dropped entry
never reaches `ITaskInvoker`.

### R6 — Conversation chain identity (`chain id`)

`ResponseContext.ConversationChainId` is a **derived, stable** identifier: every
turn of the same conversation resolves to the same value, and it is constant
across all attempts of a turn (fresh, recovered, multiply-recovered). Derivation
anchors to the conversation root: a `conversation_id` pins the chain
(`cchain_…`); otherwise the head of a `previous_response_id` chain pins it
(`rchain_…`); a first turn with neither falls back to its own `response_id`
verbatim. The digest is cross-language stable with Python.

### R7 — Metadata (`metadata`)

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

### R8 — Fail-loud composition (`composition guard`; `response.error`)

Resilience never silently downgrades:

- **Startup**: `ResilientBackground = true` with a non-persistent (in-memory)
  store → the host **refuses to start** with an actionable error naming the
  offending store and the two remedies (register a durable/persistent
  `ResponsesProvider`, or set `ResilientBackground = false`).
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

---

## Composition rules

The framework MUST validate at startup and fail loud if a required provider is
absent; it MUST NOT silently downgrade to a weaker row.

| Server config | Required providers | If missing |
|---|---|---|
| `ResilientBackground = true` | persistent response/task storage; resilient stream storage for streamed resilient responses | startup error naming the offending store and remedies |
| `store=true` requests accepted (any row) | response store | startup or request-time platform error |
| `stream=true` requests accepted (any row) | streaming-capable transport configuration | startup or request-time platform error |

The same "fail loud, never silently downgrade" rule applies at **request time**.
When `ResilientBackground` is in effect and the resilient task cannot be started,
the framework MUST fail the request rather than silently running the handler on a
non-durable, connection-scoped task.

---

## Handler obligations

- For resilient graceful shutdown, call `ExitForRecoveryAsync()` to leave the
  response `in_progress` for next-lifetime recovery.
- For the checkpoint pattern (Row 11), call `stream.Checkpoint()` at safe phase
  boundaries and, on recovery, resume from `PersistedResponse`.
- For at-most-once side effects across recovery, write a dedup marker to
  `ConversationChainMetadata` and call `FlushAsync()` before the side effect.

---

## Framework obligations

- Deliver every row × applicable-path cell above as a MUST.
- Persist the checkpoint snapshot resiliently on success; on a swallowed provider
  failure, preserve the prior snapshot (C5).
- On recovery deferral (`ExitForRecoveryAsync()`), preserve the last checkpoint
  snapshot — do NOT overwrite it with a pre-terminal record (Row 11 Path B).
- Append `response.created` to the resilient stream only when the stream is
  empty — never re-append it on a recovered entry.
- Drop recovery when the response was never resiliently created — on a definitive
  store not-found, do not re-invoke the handler; settle the task.
- Strip `internal_metadata` (item-level and the response-level reserved key) from
  every client egress; never persist client-injected internal metadata.
- Classify rows and choose dispositions only through
  `ResponseResilienceDispatch.ClassifyRow` / `DecideDisposition`.

---

## Test discipline

The matrix is the contract, enforced by the behavioural conformance suite.

1. **One behavioural module per (row × path).** Each module drives the contract
   end-to-end through a real HTTP client.
2. **Real signals only.** Path A uses graceful shutdown with a long grace; Path B
   uses graceful shutdown with a deliberately short grace; Path C uses process
   crash and restart. No mocking, no synthetic-crash shortcuts, no fabricated
   recovery state.
3. **`stream` is parametrized.** Every applicable row/path runs both
   `stream=false` and `stream=true`.
4. **Contract-surface depth.** Per-cell tests assert on event content,
   `response.output`, sequence numbers, metadata, or error details as
   applicable, not just terminal status. Row 11 uses per-lifetime markers.

For Row 11, the real-crash cutpoints **C1** and **C3** are exercised end-to-end
under Path B (graceful `ExitForRecoveryAsync()`) and Path C (crash); **C4** and
**C5** are unit-tested as checkpoint edge cases.

---

## Sample-path conformance

The published resilient samples are themselves part of the contract surface.
They drive the documented flow of each required sample through the real
Core-composed engine and assert its observable contract:

| Sample | Flow | Observable contract asserted |
|--------|------|------------------------------|
| 19 — resilient streaming | background + stream, 3 phases with checkpoints | monotonic contiguous event stream; one `response.created`; `completed` with one output item per phase |
| 20 — resilient steering | steerable multi-turn | a concurrent turn enqueues (`queued`) then drains as a steered re-entry (`IsSteeredTurn`) |
| 22 — resilient multi-turn | serial conversation chain | per-turn state accumulates across turns via durable chain metadata + history |

The published resilient samples 19 / 20 / 22 are ported 1:1 from the Python
resilience samples. Python samples 18 (Copilot) and 21 (LangGraph) are
intentionally not ported, and there is no `sample_17` to mirror (the Python
sample directory jumps 16 → 18).

---

## See also

- [`resilient-responses-developer-guide.md`](resilient-responses-developer-guide.md)
- [`handler-implementation-guide.md`](handler-implementation-guide.md)
- [`../samples/Sample19_ResilientStreaming.md`](../samples/Sample19_ResilientStreaming.md)
- [`../samples/Sample20_ResilientSteering.md`](../samples/Sample20_ResilientSteering.md)
- [`../samples/Sample22_ResilientMultiTurn.md`](../samples/Sample22_ResilientMultiTurn.md)
