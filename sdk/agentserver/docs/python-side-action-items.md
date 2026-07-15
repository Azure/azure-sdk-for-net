# Python-side action items (driven from the .NET port)

**Purpose.** This is the single, standalone backlog of follow-ups that belong on the
**Python** `azure-sdk-for-python` agentserver libraries, surfaced while porting the task /
streaming / resilience primitives to .NET. The .NET ⇄ Python *parity reports* that these items
were originally embedded in have been retired (the .NET port has converged and those reports are
no longer maintained); this document preserves only the **actionable Python-side follow-ups** so
they can drive fixes on the Python side.

**Scope.** Every item below is a **Python** change (or a Python-side test/verifier addition).
None of them requires or implies a .NET change — the .NET behavior is the intended target state,
and where the two differ Python is the side that drifts from the spec or from the single-
source-of-truth design. Items are grouped by the Python package they land in.

> **Nothing here is a .NET gap.** These are captured so the Python team has a concrete worklist.
> Reference commits for the Python source line numbers: branch
> `feature/agentserver-durable-tasks` / responses branch `feature/agentserver-responses-spec016`
> (line numbers are approximate — treat them as anchors, not exact offsets).
>
> **Last verified against Python `2026-07-14`** (`feature/agentserver-responses-spec016`
> @ `7f03ecd`, `feature/agentserver-durable-agent-demo` @ `7c36e104`). Four items that were
> confirmed **already fixed** on the Python side at that point have been dropped from the open
> list and moved to *Already reconciled* below.

---

## `azure-ai-agentserver-core` — task & streaming primitives

### PY-1 — File-backed replay: ignore a non-final `__terminal__` sentinel (align to spec)

- **Spec:** C-STR-FBR-6 — a `__terminal__` sentinel that is **not** the final line **MUST be
  ignored**; loading continues.
- **Python today:** raises on any mid-file terminal, or on any record that appears after a
  terminal.
- **.NET (target):** ignores the mid-file sentinel and keeps loading, per spec.
- **Action:** relax the Python file-backed replay loader to ignore-unless-final (or, if the
  stricter behavior is deliberate, tighten spec C-STR-FBR-6 to match Python — but the two must
  agree). Low severity.

### PY-2 — File-backed replay: enforce the both-or-neither serializer/deserializer guard

- **Spec:** C-STR-FBR-3 — a custom serializer and deserializer must be supplied
  **both-or-neither**.
- **Python today:** silently defaults a missing side to JSON when only one of the pair is
  configured.
- **.NET (target):** validates and throws on a half-configured pair.
- **Action:** add the same both-or-neither guard to Python so a half-configured pair fails fast.
  Low severity.

### PY-3 — Multi-turn `input_id` is not auto-generated per turn (source diverges from spec + doc + .NET)

- **Spec (SOT):** the task/streaming spec's identity rule is *"`input_id` defaults to `task_id`
  for one-shot; **per-turn auto-generated GUID for multi-turn unless supplied**"* — each turn of a
  chain gets its own unique input id.
- **Observation:** `azure-ai-agentserver-core/docs/tasks-guide.md` already documents this — multi-turn
  `input_id` as **"per turn; the framework generates a GUID per turn unless the caller supplies
  one"**, and the worked chain sample prints `input_id: "<turn-1-guid>"` / `"<turn-2-guid>"` for
  turns that do **not** pass `input_id=`. But **no such per-turn GUID generation exists in the
  Python source**: the only `uuid` mint is the **one-shot `task_id`** fallback
  (`tasks/_decorator.py::run`/`start`), and `input_id` defaults to `task_id` when omitted
  (`tasks/_context.py` `self.input_id = input_id if input_id is not None else task_id`; same in
  `tasks/_run.py`). So an omitted multi-turn `input_id` resolves to the (fixed) chain `task_id`,
  identical across turns — contradicting both the spec and the Python guide.
- **.NET (now aligned to spec):** `TaskEngine` generates a unique per-turn id for multi-turn when
  the caller omits `RunOptions.InputId` (`inputId = inputIdSupplied ? options.InputId : (multiTurn
  ? GenerateId("input") : taskId)`), always advances/persists the chain head (`last_input_id`) for
  multi-turn so it survives crash recovery, and exposes the assigned id via `TaskRun.InputId` /
  `TaskContext.InputId`. One-shot still defaults `input_id` to `task_id` (1:1).
- **Action:** implement per-turn `input_id` generation in the Python multi-turn path
  (`MultiTurnTask.run`/`start` → `_lifecycle_start`) so an omitted multi-turn `input_id` is a fresh
  unique id per turn, is persisted as `last_input_id` (advancing the chain head every turn, survives
  recovery), and is surfaced on the turn's context/handle — matching the spec, the Python guide, and
  the .NET port. One-shot behavior (`input_id` defaults to `task_id`) is unchanged. Behavior gap
  (source lags the spec + its own docs); the .NET side is already correct.

---

## `azure-ai-agentserver-responses` — resilience layer

### PY-4 — Fix the phantom `sample_17` docstring reference

- **Observation:** several Python resilience samples reference a "`sample_17` for
  Claude" that does **not** exist at the pinned commit (the sample directory jumps 16 → 18).
  The dangling reference appears in more than samples 19/20: it is present in
  `azure-ai-agentserver-responses/samples/sample_18_resilient_copilot.py`,
  `sample_19_resilient_streaming.py`, and `sample_20_resilient_steering.py`, and in the
  test helper `azure-ai-agentserver-responses/tests/e2e/test_resilient_sample_e2e.py`.
- **Action:** remove/adjust **every** `sample_17` reference across those files (samples 18/19/20
  and the e2e test helper), or add the missing sample. .NET
  intentionally does **not** fabricate a `Sample17_*` port to match a non-existent source. Prose
  fix only.

---

## Resilient demo verifiers (Python samples)

### PY-5 — Port the deterministic crash-recovery proof + GET-terminal fallback to the Python verifiers

- **Observation:** the Python resilient-agent demo verifiers (e.g.
  `resilient-responses-agent-demo/battery/verify_crash.py`) still prove restart/recovery
  primarily by **scraping** `azd ai agent monitor` server logs (`worker-*` instance counts,
  `reclaim`/`recovered` markers). That log capture is unreliable across a nanny restart — it
  re-attaches to the pre-crash log buffer and does not reliably follow the new container's
  stdout. The .NET verifiers instead prove recovery **deterministically** — "confirmed hard
  crash + pre-crash progress + `completed` terminal" — and fall back to a non-streaming GET (no
  stream-TTL constraint) to read the authoritative terminal status; log markers are supplementary
  evidence only.
  - **Path note:** this verifier lives in the resilient-responses demo tree (the demo branch used
    for `/tmp/py-demo`, `azure-ai-agentserver-responses/samples/resilient-responses-agent-demo/`),
    **not** in the authoritative `azure-ai-agentserver-*` package tree used elsewhere in this doc.
- **Action:** port the deterministic proof + GET-terminal fallback into the Python verifiers so
  they no longer depend on the flaky log scrape as the primary restart proof.

### PY-6 — Pin `agent_session_id` in the responses demo client + battery (session-affinity / crash-target fix)

- **Observation:** the Python **responses** resilient demo
  (`azure-ai-agentserver-responses/samples/resilient-responses-agent-demo`, the direct
  ancestor of the .NET port) never pins `agent_session_id`, so **each POST lands on a
  different sandbox**. `agent_session_id` is a top-level create-response body property and
  *one session id == one sandbox/container*; without it, a `crash` request kills an
  **unrelated** sandbox, not the one running the in-flight response — the run completes
  normally and looks "recovered." Confirmed in the clone `/tmp/py-demo` @ `7c36e104` in all
  three places:
  - `battery/run_suite.py` — `body()` (~L79) has no `agent_session_id`; `fire_crash()`
    (~L260) posts a bare `crash` with a **false** docstring claiming "Hosted agents run a
    single sandbox, so this reliably kills the sandbox running the in-flight resilient
    task"; callers T13/T14 (~L538, ~L648) are unpinned.
  - `battery/verify_crash.py` — the crash POST (~L94) is unpinned, and the proof reads
    `crash.get("session_id")` (~L140), a key `fire_crash()` never returns (it returns
    `crash_session`), so it is always `None` → mis-routing is invisible and never asserted.
  - `demo-client.sh` — `cmd_crash()` (~L355/L362) posts a bare `crash` body with **0**
    occurrences of `agent_session_id`; start/steer/crash each hit a different sandbox.
- **Note — the two Python demos differ:** the **invocations** demo
  (`azure-ai-agentserver-invocations/samples/resilient-agent-demo`) is already correct — it
  mints `SESSION_ID="demo-$(uuidgen)"` and appends `&agent_session_id=${SESSION_ID}` as a
  **query param** on every POST `/invocations` (the invocations protocol carries it as a
  query param, not a body field). Only the **responses** demo has the gap.
- **.NET (target, done):** the .NET responses demo now pins the session end-to-end:
  `demo-client.sh` mints `demo-<uuid>` (with a `python3 -c 'import uuid'` fallback since
  `uuidgen` is not always installed), sets `agent_session_id` in the **body** of
  start/steer/crash, persists it in `.demo-session` for cross-terminal reuse, and confirms
  affinity from the echoed `x-agent-session-id` response header. The battery
  (`run_suite.py`/`verify_crash.py`) threads the run's session id into `fire_crash()`, adds
  a `crash_hit_target` assertion (crash_session == run session) as a **required** part of the
  recovery proof, corrects the false docstring, and fixes the `session_id`→`crash_session`
  latent-key bug. Verified live: `crash_hit_target=True`, two distinct worker instances
  across the crash, `reclaimed_stale_task` + `recovered_task_active` + `terminal=completed`.
  Reference commits (.NET, branch `001-tasks-streaming-primitives`): demo-client fix
  `fa78c744b81`; battery hardening `0d5081dc0e3`.
- **Action:** port the same pinning to the Python **responses** demo — (1) add
  `agent_session_id` to `body()` and send it on start/steer/crash; (2) pin `fire_crash()` to
  the run's session and correct its docstring; (3) make `verify_crash.py` (and T13/T14)
  require `crash_hit_target` and read `crash_session`; (4) pin `demo-client.sh cmd_crash`
  (and start/steer) to a persisted `demo-<uuid>` session. The `verify_crash_steer.py`
  (steer-`crash` via `previous_response_id`) and `__ECHO_CRASH__` self-crash proofs are
  already sound and need no change. Full file/line detail + live evidence:
  see `python-responses-battery-session-affinity-findings.md` in this session's artifacts.

---

### PY-7 — Responses `demo-client.sh` interactive crash can't target the in-flight run across terminals

- **Observation:** `agent_session_id` pinning (PY-6) is necessary but **not sufficient** for the
  *interactive* `demo-client.sh` flow, where `start` streams in one terminal and `crash` runs as a
  **separate process in another terminal**. Pinning makes the crash hit the right *sandbox*, but the
  script must first hand the live response id between processes, and that plumbing is broken:
  1. `cmd_start` only persists `RESPONSE_ID` to `.demo-session` **when the stream ends**, so a
     concurrent `crash` sees no active id and reports "No active response" — it never targets the
     run that is actually streaming.
  2. The `stream_sse` sidecar temp files use **fixed names** shared by all concurrent invocations in
     the same directory, so the second terminal's command `rm`/overwrites the streaming `start`'s id
     file, yielding "Failed to dispatch (no response.id captured)".
  These bugs are invisible to the battery (`fire_crash` runs in-process and reads the session id from
  the response header directly — no file handoff), which is exactly why PY-6's battery verification
  passed while the interactive demo still failed for users. **Likely present in the Python responses
  demo-client.sh** too (same shape as the pre-fix .NET script).
- **Also:** do **not** implement the interactive crash as a `previous_response_id` steer. A steered
  "crash" is delivered as a follow-up turn that only runs **after** the current turn finishes, so it
  never interrupts the in-flight run (confirmed on .NET). The reliable crash is a **bare** streaming
  `POST /responses` `input="crash"` pinned via `agent_session_id` only — it hits the crash sentinel
  in the live process and `exit(137)`s it, dropping the in-flight stream so the lease is reclaimed
  and the run recovers.
- **.NET (target, done):** the renderer publishes the live id to a shared `.demo-session.active` the
  instant it is captured and `load_session` falls back to it; sidecars are PID-private (`.$$`); and
  `cmd_crash` fires a bare same-session streaming crash (no `previous_response_id`). Verified live:
  crash fired mid phase 1 → in-flight stream dropped → server logged `CRASH triggered` on the same
  task chain → same response recovered post-restart to `status=completed` (12 items). Reference
  commit (.NET, branch `001-tasks-streaming-primitives`): `4d8ed30b29e`.
- **Action:** if the Python responses `demo-client.sh` is meant to be run interactively across
  terminals, port the same three fixes — (1) publish the in-flight id to a shared active-id file
  mid-stream and read it back on `crash`; (2) make the SSE sidecar temp files process-private; (3)
  ensure the interactive `crash` is a bare `agent_session_id`-pinned crash, not a
  `previous_response_id` steer.

---

## Already reconciled (no action — recorded for context)

The following were previously open and have since been implemented on Python (its "spec 037"
batch) and reconciled in the SOT spec (§15 retry preset table + hard-cap rules; the spec-038
task-record schema cleanup). Kept here only so the history is not lost:

- Retry hard caps (`max_attempts` 1–10, `max_delay` ≤ 1 h) — both raise on violation.
- Retry preset values unified across .NET, Python and SOT §15
  (`exponential_backoff` 3/1s/60s/2.0/jitter; `fixed_delay` 3/5s; `linear_backoff` 5/1s/60s).
- Invalid-config fail-fast (negative delays, `max_attempts < 1`, `backoff_coefficient < 1.0`,
  negative timeout, whitespace-only task names, `input_id` charset/length) on both sides.
- Task `name` is a required identity anchor (no `__qualname__` fallback on Python).
- Per-turn timeout defaults to 1 day and 1 day is a hard ceiling; per-attachment value cap 10 MiB.
- **[Spec corrected]** Hosted store base path `{FOUNDRY_PROJECT_ENDPOINT}/tasks` (no `/storage`
  segment) and `tag.{key}={value}` filters — the SOT spec was the defect and was corrected to
  match Python's live-backend client; .NET already emits the corrected shape.

### Verified fixed on Python side (removed from the open list `2026-07-14`)

These were open Python-side items in earlier revisions of this document and are now confirmed
resolved on `feature/agentserver-responses-spec016` @ `7f03ecd` (and the demo branch
@ `7c36e104`):

- **`payload.turn_started_at` timestamp form.** Python now serializes it via
  `datetime.now(timezone.utc).isoformat()` (`+00:00` form) — matching every other Python
  task-record timestamp **and** the .NET port; the read path still tolerates legacy `…Z` records
  (`azure/ai/agentserver/core/tasks/_manager.py::_utc_now_iso` / `_parse_turn_started_at`).
- **`metadata:_responses` folded into task input (Spec 039 R1).** The `_responses` framework
  metadata namespace has been **removed**; `response_id` / `background` / `disposition` are now
  sourced directly from the durable task **input** (`ResilientResponseInput`, persisted at
  `.start()`), the single source of truth — "matching the .NET port"
  (`responses/hosting/_resilient_orchestrator.py`).
- **Steering `pending_input_count` assertion on active turns.** Python now has
  `tests/tasks/test_steering.py::test_same_process_enqueue_count_visible_at_cancel`, which asserts
  `pending_input_count >= 1` at the steering-cancel boundary on a running turn (SOT §13 ordering
  invariant).
- **Deterministic hosted lifecycle/recovery contract tests.** Python added a full
  `tests/e2e/resilience_contract/` suite — deterministic (in-process, `httpx`-driven) row×path
  coverage (`test_row_{1..11}_path_{a,b,c}`, keep-alive, metadata-survives-recovery, streaming
  recovery continuity, etc.) plus a `CONTRACT_COVERAGE.md` completeness meta-test — mirroring the
  intended split of deterministic hosted-wire tests + credential-gated live recovery tests.
