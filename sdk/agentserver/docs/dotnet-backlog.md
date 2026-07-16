# .NET agentserver backlog (design enhancements)

**Purpose.** This is the standalone backlog of **.NET-side** design enhancements for the
agentserver task / streaming / resilience primitives that are larger than a bug fix and need a
proper design pass before implementation. Each item captures the problem, why the current
behavior is insufficient, and the shape of the enhancement — but is intentionally *not*
implemented yet.

> These are **.NET** work items (unlike `python-side-action-items.md`, which tracks Python
> follow-ups). Items here are deferred by design decision, not defects in shipped behavior.

---

## NET-BL-1 — Queued streaming turn: emit an early response id before the in-flight turn drains

- **Context.** A `POST /responses` with `stream:true` that is *queued* behind an already-active
  turn (follow-up / steering turn carrying `previous_response_id`, or a general background-queued
  turn) now correctly returns an SSE stream (`text/event-stream`) instead of a JSON `queued`
  envelope — see the fix in `ResponseEndpointHandler.CreateResponseAsync` (streaming branch no
  longer short-circuits on `run.IsQueued`; commit `deb13f0f701`). This restored parity with
  Python, whose streaming path (`_orchestrator.py` `_live_stream` → `_relay_resilient_stream`)
  also relays the wire stream regardless of queued state.
- **Problem.** While the previously-in-progress turn is still running, the queued streaming
  connection stays open emitting **only** `: keep-alive` comment frames (via `SseKeepAliveSession`)
  until the in-flight turn winds down and the queued turn actually starts. The **first semantic
  event** the client sees is the handler's `response.created` — which is *deferred until the turn
  drains*. Consequences when the in-flight turn is long-running:
  1. The client does **not** yet have the queued turn's `response.id` (it only arrives with the
     deferred `response.created`).
  2. If the SSE connection drops during the wait, the client has **no id to reconnect with** — it
     cannot `GET /responses/{id}?stream=true` to resume, because it never learned the id.
  3. The client cannot distinguish "connected, waiting in queue" from "hung / dead connection"
     beyond keep-alive heuristics.
- **Why this needs a design pass (not a quick fix).** Emitting a real event before the turn runs
  touches the **task primitive** and the streaming contract, not just the endpoint dispatch:
  - The orchestrator today validates that a handler-authored `response.created` must be
    **non-terminal** and is the handler's first event (`ResponseOrchestrator.cs` ~L382-400). An
    early framework-emitted event must not collide with, duplicate, or pre-empt the handler's own
    `response.created` once the turn starts.
  - `ResponseEventStream.EmitQueued()` exists as a *handler-authoring helper* but the framework
    dispatch/orchestrator never calls it. Wiring an automatic early emission means deciding the
    event shape (a `response.queued` / `response.enqueued` with status `queued`, vs. an early
    `response.created` with the id and a queued status) and reconciling it with the OpenAI
    Responses SSE event taxonomy and with Python (which currently emits *no* early event either —
    so this would be a **deliberate divergence to raise as a spec change / cross-repo item**, not
    a silent .NET-only behavior).
  - The task primitive would need to surface the allocated response id + a "queued/accepted"
    checkpoint at enqueue time (before the resilient turn body runs) so both the streaming relay
    and a reconnecting `GET ...?stream=true` can observe it, and so replay after a crash still
    yields a coherent event order.
- **Proposed direction (to be designed).**
  1. At enqueue time, have the task primitive publish an **early wire event** carrying the
     `response.id` and an explicit non-terminal `queued`/`accepted` status to the per-response
     stream, *before* the in-flight turn drains — so the streaming relay forwards it immediately
     and the client learns the id up front.
  2. Ensure this early event is **idempotent with replay** and does not conflict with the
     handler's subsequent `response.created` (define ordering: early `queued` → later
     `response.created` → … ; or fold the id into a first `response.created` with `status:queued`
     that the handler's non-terminal created then supersedes).
  3. Make the same early event observable via `GET /responses/{id}?stream=true` replay so a
     reconnecting client sees a consistent prefix.
  4. Coordinate the contract with Python (raise a matching item in `python-side-action-items.md`
     once the .NET design is settled) and update `specs/002-responses-resilience/spec.md`
     (FR-050) so both stacks converge on the enhanced behavior rather than diverging.
- **Severity.** Medium — not a correctness bug in the fixed path (SSE is now returned and the turn
  does stream once it drains), but a resilience/UX gap for long in-flight turns where a
  disconnected client is stranded without a reconnect id.
- **Status.** Backlog — design not started. Fixed prerequisite (SSE-not-JSON on queued streaming)
  shipped in `deb13f0f701` on branch `001-tasks-streaming-primitives`.
