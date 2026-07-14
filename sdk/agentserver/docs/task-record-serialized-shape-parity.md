# Task-Record Serialized-Shape Parity: .NET ⇄ Python

**Scope:** the *exact serialized shape of the task record* that the Task primitive persists
(the `object: "task"` document written to the store), compared between the .NET port
(`Azure.AI.AgentServer.Core`) and the Python library (`azure-ai-agentserver-core`).

**Method — real, not hand-written.** Every JSON block below was produced by running the
*actual* implementations against their local file-backed stores and reading the resulting
on-disk file, so the shapes are authoritative:

- **.NET** — a `TaskEngine` over `LocalTaskStore` (temp dir), driven through the public
  `ResilientTaskBuilder` / `ITaskInvoker` surface; the file at
  `<root>/<agent>/<session>/<task>.json` was read back verbatim.
- **Python** — a `TaskManager` over `LocalFileTaskProvider` (temp dir), driven through the
  `@task` / `@multi_turn_task` decorators; the file at
  `<root>/<agent>/<session>/<task>.json` was read back verbatim.

The persisted record type is **.NET `TaskRecord`** (`Tasks/Serialization/TaskRecord.cs`,
`ToJson`/`FromJson`) and **Python `TaskInfo`** (`tasks/_models.py`, `to_dict`/`from_dict`).
`TaskRun` on .NET is only the in-memory awaitable handle and is *not* what is stored.

---

## 1. Representative JSON — full records

Three representative persisted states are shown. One-shot **completed** records are **not**
shown because they are **ephemeral in both implementations** — a completed `@task` (one-shot)
record is deleted from the store after completion (verified: the store directory is empty
after `RunAsync`/`.run(...)` returns on both sides). The durable, on-disk states are
**fresh `in_progress`** (mid-run) and **`suspended`** (between multi-turn turns).

### 1a. Fresh `in_progress`, no `input_id`

**.NET**

```json
{
  "object": "task",
  "id": "task-plain-1",
  "agent_name": "research-agent",
  "session_id": "sess-1",
  "status": "in_progress",
  "payload": {
    "input": "hi",
    "metadata": {},
    "turn_started_at": "2026-07-14T16:35:51.2489045+00:00",
    "schema_version": "1"
  },
  "title": "plain:task-pla",
  "lease": {
    "owner": "research-agent|session:sess-1",
    "instance_id": "worker-1659078-7c45e3ee-1784046951",
    "generation": 0,
    "expires_at": "2026-07-14T16:36:51.2627242+00:00",
    "expiry_count": 0,
    "heartbeat_at": "2026-07-14T16:35:51.2529141+00:00"
  },
  "tags": { "task_name": "plain" },
  "source": {
    "type": "agentserver.task",
    "name": "plain",
    "server_version": "Azure.AI.AgentServer.Core/1.0.0-alpha... (dotnet/10.0)",
    "hosting_environment": ""
  },
  "created_at": "2026-07-14T16:35:51.2529141+00:00",
  "updated_at": "2026-07-14T16:35:51.2529141+00:00",
  "started_at": "2026-07-14T16:35:51.2529141+00:00",
  "completed_at": null,
  "etag": "local-6d0d5d802446f438"
}
```

> On-disk note: .NET writes the `+` in the offset as the JSON escape `\u002B`
> (`JsonNode.ToJsonString`); it is shown unescaped above for readability. Both forms parse
> to the identical string.

**Python**

```json
{
  "object": "task",
  "id": "task-plain-1",
  "agent_name": "research-agent",
  "session_id": "sess-1",
  "status": "in_progress",
  "title": "plain:task-pla",
  "lease": {
    "owner": "research-agent|session:sess-1",
    "instance_id": "worker-1659217-7aa24d1b-1784046978",
    "generation": 0,
    "expires_at": "2026-07-14T16:37:18.133124+00:00",
    "expiry_count": 0,
    "heartbeat_at": "2026-07-14T16:36:18.133035+00:00"
  },
  "payload": {
    "input": { "topic": "hi" },
    "metadata": {},
    "turn_started_at": "2026-07-14T16:36:18.132977Z",
    "schema_version": "1"
  },
  "tags": { "task_name": "research" },
  "source": {
    "type": "agentserver.task",
    "name": "plain",
    "server_version": "azure-ai-agentserver-core/2.0.0b7 (python/3.12)",
    "hosting_environment": ""
  },
  "etag": "local-b9910f1e29c110d8",
  "created_at": "2026-07-14T16:36:18.133035+00:00",
  "updated_at": "2026-07-14T16:36:18.133035+00:00",
  "started_at": "2026-07-14T16:36:18.133035+00:00",
  "completed_at": null
}
```

.NET and Python agree here on **`title`** (`plain:task-pla`) and **`payload.metadata`**
(both seed `{}` at create). The only differences visible in this record are cosmetic:
**`turn_started_at`** timestamp format (`…+00:00` vs `…Z`, see T1) and **key ordering** (C2).

### 1b. Fresh `in_progress`, metadata written, `input_id` supplied

**.NET**

```json
{
  "object": "task",
  "id": "task-mt-1",
  "agent_name": "research-agent",
  "session_id": "sess-1",
  "status": "in_progress",
  "payload": {
    "input": "fusion",
    "metadata": { "phase": "collecting" },
    "turn_started_at": "2026-07-14T16:33:42.2367810+00:00",
    "schema_version": "1",
    "last_input_id": "input-1"
  },
  "title": "research:task-mt-",
  "lease": { "owner": "research-agent|session:sess-1", "instance_id": "worker-…",
             "generation": 0, "expires_at": "…+00:00", "expiry_count": 0,
             "heartbeat_at": "…+00:00" },
  "tags": { "task_name": "research" },
  "source": { "type": "agentserver.task", "name": "research",
              "server_version": "Azure.AI.AgentServer.Core/1.0.0-alpha… (dotnet/9.0)",
              "hosting_environment": "" },
  "created_at": "…+00:00", "updated_at": "…+00:00", "started_at": "…+00:00",
  "completed_at": null,
  "etag": "local-b62e84621f8844a6"
}
```

**Python**

```json
{
  "object": "task",
  "id": "task-mt-1",
  "agent_name": "research-agent",
  "session_id": "sess-1",
  "status": "in_progress",
  "title": "research:task-mt-",
  "lease": { "owner": "research-agent|session:sess-1", "instance_id": "worker-…",
             "generation": 0, "expires_at": "…+00:00", "expiry_count": 0,
             "heartbeat_at": "…+00:00" },
  "payload": {
    "input": { "topic": "fusion" },
    "metadata": { "phase": "collecting" },
    "turn_started_at": "2026-07-14T16:34:26.803224Z",
    "schema_version": "1",
    "last_input_id": "input-1"
  },
  "tags": { "task_name": "research" },
  "source": { "type": "agentserver.task", "name": "research",
              "server_version": "azure-ai-agentserver-core/2.0.0b7 (python/3.12)",
              "hosting_environment": "" },
  "etag": "local-7edc1dc883ae89a5",
  "created_at": "…+00:00", "updated_at": "…+00:00", "started_at": "…+00:00",
  "completed_at": null
}
```

### 1c. `suspended` (multi-turn, between turns) — clean run

**.NET**

```json
{
  "object": "task",
  "id": "task-mt-1",
  "agent_name": "research-agent",
  "session_id": "sess-1",
  "status": "suspended",
  "payload": {
    "input": null,
    "turn_started_at": "2026-07-14T16:33:42.2367810+00:00",
    "schema_version": "1",
    "last_input_id": "input-1",
    "metadata": { "phase": "collecting" },
    "retry_attempt": null
  },
  "title": "research:task-mt-",
  "lease": null,
  "tags": { "task_name": "research" },
  "source": { "type": "agentserver.task", "name": "research",
              "server_version": "Azure.AI.AgentServer.Core/1.0.0-alpha… (dotnet/9.0)",
              "hosting_environment": "" },
  "suspension_reason": "run_completion",
  "created_at": "…+00:00", "updated_at": "…+00:00", "started_at": "…+00:00",
  "completed_at": null,
  "etag": "local-bad38d6bbbae985f"
}
```

**Python**

```json
{
  "object": "task",
  "id": "task-mt-1",
  "agent_name": "research-agent",
  "session_id": "sess-1",
  "status": "suspended",
  "title": "research:task-mt-",
  "lease": null,
  "payload": {
    "input": null,
    "metadata": { "phase": "collecting" },
    "turn_started_at": "2026-07-14T16:36:44.244323Z",
    "schema_version": "1",
    "last_input_id": "input-1",
    "retry_attempt": null
  },
  "tags": { "task_name": "research" },
  "suspension_reason": "run_completion",
  "source": { "type": "agentserver.task", "name": "research",
              "server_version": "azure-ai-agentserver-core/2.0.0b7 (python/3.12)",
              "hosting_environment": "" },
  "etag": "local-099e7b49c0b7ad5b",
  "created_at": "…+00:00", "updated_at": "…+00:00", "started_at": "…+00:00",
  "completed_at": null
}
```

---

## 2. Field-by-field parity table

| Field | .NET | Python | Parity |
|---|---|---|---|
| `object` | `"task"` | `"task"` | ✅ |
| `id` | task id | task id | ✅ |
| `agent_name` / `session_id` | same | same | ✅ |
| `status` | `pending`/`in_progress`/`suspended`/`completed`/`failed` (`done`→`completed` alias) | same | ✅ |
| `title` | `Options.Title` or **`"{name}:{taskId[..8]}"`** | `Options.title` or **`f"{name}:{task_id[:8]}"`** | ✅ |
| `lease` | present (obj) while owned; explicit `null` when released | same | ✅ |
| `lease.owner` | `"<agent>\|session:<sess>"` | same | ✅ |
| `lease.instance_id` | `worker-<pid>-<hex8>-<unixSeconds>` | same | ✅ |
| `lease.generation` / `expiry_count` | int | int | ✅ |
| `lease.expires_at` / `heartbeat_at` | `o` (7-digit `+00:00`) | `isoformat()` (6-digit `+00:00`) | ⚠️ **T2** |
| `payload.input` | passthrough; `null` at suspension | passthrough; `null` at suspension | ✅ |
| `payload.metadata` | **always seeded `{}` at create** | **always seeded `{}` at create** | ✅ |
| `payload.turn_started_at` | `…fffffff+00:00` (7-digit, offset) | `…ffffffZ` (6-digit, **Z**) | ⚠️ **T1** |
| `payload.schema_version` | `"1"` | `"1"` | ✅ |
| `payload.last_input_id` | only when `input_id` supplied | only when `input_id` supplied | ✅ |
| `payload.retry_attempt` | `null` at suspension; absent fresh | `null` at suspension; absent fresh | ✅ |
| `payload.steering` | **written only when the chain was ever steered** | **written only when the chain was ever steered** | ✅ |
| `payload.steering.*` sub-keys | `pending_inputs`/`next_input_seq`/`cancel_requested`/`drain_in_progress`/`active_input` | same names | ✅ (when present) |
| `tags.task_name` | task name | task name | ✅ |
| `source.type` | `"agentserver.task"` | `"agentserver.task"` | ✅ |
| `source.name` | task name | task name | ✅ |
| `source.server_version` | `<pkg>/<ver> (dotnet/<ver>)` | `<pkg>/<ver> (python/<ver>)` | ✅ (same grammar) |
| `source.hosting_environment` | `FOUNDRY_HOSTING_ENVIRONMENT` or `""` | same | ✅ |
| `suspension_reason` | present on suspended (`run_completion`, …) | present on suspended (`run_completion`, …) | ✅ |
| `created_at`/`updated_at`/`started_at` | `o` (7-digit `+00:00`) | `isoformat()` (6-digit `+00:00`) | ⚠️ **T2** |
| `completed_at` | `null` until terminal | `null` until terminal | ✅ |
| `etag` | `local-<hash>` (opaque, impl-local) | `local-<hash>` (opaque, impl-local) | ✅ (opaque) |
| **key order in file** | insertion order (differs) | insertion order (differs) | ➖ **C2** cosmetic |
| one-shot completed record | deleted (ephemeral) | deleted (ephemeral) | ✅ |

---

## 3. Remaining divergences

The task-record shape is at parity on every functionally-meaningful field (`title`, `payload.metadata`,
`payload.steering`, input/lease/source/status all match). The only remaining differences are in
timestamp formatting and other cosmetic, parse-equivalent details:

| ID | Divergence | Impact | Owner / disposition |
|---|---|---|---|
| **T1** | `payload.turn_started_at` format: .NET `…fffffff+00:00`; Python `…ffffffZ`. Python is also internally inconsistent (`turn_started_at` uses `Z`, all other Python timestamps use `+00:00`) | Opaque ISO-8601 strings; both parse to the same instant | **Python-side cleanup** — make `turn_started_at` use the same `+00:00` form as the other Python timestamps. Not a .NET change. |
| **T2** | Fractional-second precision on all timestamps: .NET 7 digits, Python 6 digits (both `+00:00`) | Cosmetic; both parse to the same instant | **Low priority.** Normalize both to a fixed precision only if exact byte-equality of timestamps is ever required. |
| **C1** | On-disk `+` escaping: .NET `JsonNode.ToJsonString` emits `\u002B`; Python emits literal `+` | Local-file cosmetic only | **No action.** Both are valid JSON and parse identically; the hosted wire uses the canonical (alphabetically-sorted) form validated by `CrossLanguageByteCompatTests`. |
| **C2** | Key ordering within the file differs (insertion order) | Cosmetic | **No action.** `FromJson`/`from_dict` are order-independent; the etag/hosted canonical form sorts keys. |
| **C3** | Empty-collection presence: .NET omits empty `tags`/`attachments`; Python emits if not `None` | Edge-case only (`tags` always carries `task_name`, so non-empty in practice) | **No action** for `tags`. For `attachments`, align only if an empty-attachments record must be byte-identical. |

**Parity is locked by tests.** The matching behaviors are guarded by
`SchemaVersionAndSourceTests` (title default `"{name}:{taskId[..8]}"` with explicit `Options.Title`
winning; `payload.metadata` seeded `{}` at create for both one-shot and multi-turn) and
`SteeringPromotionTests` (steering block written only when the chain was ever steered — omitted for
a never-steered chain, preserved with drain markers cleared and `next_input_seq` intact for an
ever-steered chain).

**Cross-language recovery is safe.** A .NET reader ingesting a Python record and a Python reader
ingesting a .NET record both deserialize without loss: each side's parser treats present-empty and
absent identically for `metadata`/`steering`, and both seed `metadata` at create and write `steering`
only when the chain was ever steered.

---

## 4. Confirmed byte-compatible surface

The **hosted** wire (what is sent to / recovered from the Foundry Task API) is serialized
through the canonical, alphabetically-sorted form. This is covered by
`Azure.AI.AgentServer.Core/tests/.../CrossLanguageByteCompatTests` against the golden
`fixtures/task_record.canonical.json`, and cross-language *recovery* (reading a
Python-written record on .NET and vice-versa) is covered by
`tests/Tasks/Conformance/CrossLanguageRecoveryTests`. The remaining divergences (T1/T2/C1–C3
above) are all in the **local file** projection and/or in cosmetic formatting; none of them break
the canonical hosted contract or cross-language recovery.

---

# Part 2 — How the Responses protocol stores things *on the task*

When a response runs as a **resilient background** response, the Responses layer drives the
same Task primitive audited above. This part documents **exactly what the Responses layer
writes onto that task record**, compared .NET ⇄ Python.

**Scope clarification.** The Responses layer persists to *two* stores:

1. The **Task record** — the durable `object:"task"` document (Part 1's shape). This is what
   "stores things *on the task*" refers to and is audited here.
2. The **Response snapshot** (`ResponseObject`: `id`/`status`/`output`/`usage`/`error`/…) —
   written to a **separate response store** via `CreateResponseAsync`/`UpdateResponseAsync`,
   **not** onto the task record. That snapshot is out of scope for a "task record" audit and
   is only referenced here for completeness.

The Responses layer writes **two things onto the task**:

- **`payload.input`** — the typed recovery boundary (.NET `ResponseRecoveryPayload` ⇄ Python
  `ResilientResponseInput`). One producer / one consumer on each side.
- **A framework metadata namespace** (`_responses`) — Python only (see divergence **R1**).

## 2.1 `payload.input` — the recovery boundary (full JSON)

Both sides emit the **same 9 top-level keys, in the same order**:
`response_id`, `disposition`, `request`, `agent_reference`, `agent_session_id`,
`user_id_key`, `call_id`, `client_headers`, `query_parameters`.
`request` is the full serialized `CreateResponse`; the re-derivable fields
(`store`/`stream`/`background`/`model`/`previous_response_id`/conversation id/input items) are
**not** duplicated as top-level keys — they are recomputed from `request` on recovery.

### With `agent_reference` + identity — byte-identical

**.NET**

```json
{
  "response_id": "caresp_abc123",
  "disposition": "re-invoke",
  "request": { "model": "gpt-5.4-nano", "background": true, "store": true, "stream": true },
  "agent_reference": { "type": "agent_reference", "name": "research-agent", "version": "1" },
  "agent_session_id": "sess-1",
  "user_id_key": "user-key-xyz",
  "call_id": "call-789",
  "client_headers": { "x-ms-foundry-feature": "resilient" },
  "query_parameters": { "stream": "true" }
}
```

**Python**

```json
{
  "response_id": "caresp_abc123",
  "disposition": "re-invoke",
  "request": {
    "model": "gpt-5.4-nano", "background": true, "store": true, "stream": true,
    "input": [ { "type": "message", "role": "user",
                 "content": [ { "type": "input_text", "text": "Summarize fusion energy." } ] } ],
    "metadata": { "user_tag": "demo" }
  },
  "agent_reference": { "type": "agent_reference", "name": "research-agent", "version": "1" },
  "agent_session_id": "sess-1",
  "user_id_key": "user-key-xyz",
  "call_id": "call-789",
  "client_headers": { "x-ms-foundry-feature": "resilient" },
  "query_parameters": { "stream": "true" }
}
```

> The `request` content differs above **only because the two harnesses supplied different
> `CreateResponse` inputs** (the Python harness set `input`/`metadata`, the .NET one did not).
> `request` is the full generated-model serialization of `CreateResponse` on both sides; there
> is no schema divergence in `request` itself. The `agent_reference` object shape matches
> byte-for-byte (`type: "agent_reference"`, `name`, `version`).

### Absent `agent_reference` + identity — byte-identical

**.NET**

```json
{
  "response_id": "caresp_abc123",
  "disposition": "re-invoke",
  "request": { "model": "gpt-5.4-nano", "background": true, "store": true, "stream": true },
  "agent_reference": {},
  "agent_session_id": null,
  "user_id_key": null,
  "call_id": null,
  "client_headers": {},
  "query_parameters": {}
}
```

**Python**

```json
{
  "response_id": "caresp_abc123",
  "disposition": "re-invoke",
  "request": { "... same CreateResponse ..." : "..." },
  "agent_reference": {},
  "agent_session_id": null,
  "user_id_key": null,
  "call_id": null,
  "client_headers": {},
  "query_parameters": {}
}
```

Absent `agent_reference` serializes as an empty object `{}` on **both** sides (matching Python's
`_normalize_agent_reference(None) → {}`); the .NET read path maps an empty object back to `null`
in memory, so the round trip is lossless. All other absent optionals also agree
(`agent_session_id`/`user_id_key`/`call_id` → `null`;
`client_headers`/`query_parameters` → `{}`).

## 2.2 The `_responses` framework metadata namespace — Python only (R1)

Python additionally stamps a framework-internal metadata namespace named **`_responses`**,
which the Task primitive persists under the task payload key **`payload["metadata:_responses"]`**.
It holds exactly three keys (`_resilient_orchestrator.py` lines 615/620/974):

```json
"metadata:_responses": {
  "response_id": "caresp_abc123",
  "background": true,
  "disposition": "re-invoke"
}
```

Python **duplicates** `response_id`/`disposition` (already present in `payload.input`) into
this resiliently-flushed namespace so the recovery scanner can read the disposition cheaply
and so it is durable *before* the task body runs (`_read_disposition(responses_ns)`).

**.NET does not create this namespace at all.** It reads `disposition` / `response_id` /
`background` directly from the durable task **input** (`ResponseRecoveryPayload`), which is
written atomically when the task is created (`.StartAsync`). So a .NET resilient-response task
record has **no `payload["metadata:_responses"]` bucket**.

## 2.3 Field-by-field parity table (Responses-on-task)

| What | .NET | Python | Parity |
|---|---|---|---|
| `payload.input` top-level keys | 9 keys (see list) | 9 keys (identical names + order) | ✅ |
| `payload.input.request` | full `CreateResponse` serialization | full `CreateResponse` serialization | ✅ |
| re-derived fields (`store`/`stream`/`background`/`model`/`previous_response_id`/conversation/input items) | **not** top-level | **not** top-level | ✅ |
| `agent_reference` present | `{type,name,version}` | `{type,name,version}` | ✅ |
| `agent_reference` **absent** | `{}` | `{}` | ✅ |
| `agent_session_id`/`user_id_key`/`call_id` absent | `null` | `null` | ✅ |
| `client_headers`/`query_parameters` absent | `{}` | `{}` | ✅ |
| `disposition` values | `re-invoke` / `mark-failed` | `re-invoke` / `mark-failed` | ✅ |
| `payload["metadata:_responses"]` bucket | **absent** (source of truth = task input) | present: `{response_id, background, disposition}` | ⚠️ **R1** (Python-side action item — see §2.5) |
| Response snapshot (`ResponseObject`) | separate response store | separate response store | ✅ (not on task record) |

## 2.4 Remaining divergence (Responses-on-task)

The Responses recovery boundary (`payload.input`) is at full schema **and** shape parity: the same
9 keys, in the same order, with the same `request` and `agent_reference` shapes — including the
absent-`agent_reference` case, which serializes as `{}` on both sides (guarded by
`RecoveryPayloadParityProtocolTests.AbsentAgentReference_RoundTripsToNull`). The only structural
difference in what lands *on the task* is Python's extra `_responses` metadata mirror:

| ID | Divergence | Impact | Owner / disposition |
|---|---|---|---|
| **R1** | Python stores an extra `payload["metadata:_responses"]` bucket (`response_id`/`background`/`disposition`); .NET stores nothing there and reads those values from the task input | Shape divergence. Benign **within a single-language deployment**: .NET is self-consistent (writes+reads the input). Only a hypothetical *mixed-language* recovery of the *same* in-flight task would matter — a .NET-written task recovered by Python would find no `_responses` namespace and default `disposition` to `re-invoke`, which for a `mark-failed` task would be wrong. Mixed-language recovery of one task is not a real deployment scenario. | **Python-side action item** — deliberately **no .NET change**. Research (see §2.5) confirms the three values can move to task input on Python too, folding them into a single source of truth (matching .NET). |

## 2.5 R1 research conclusion — can the `_responses` metadata move to task input on Python?

**Question (from review):** For `payload["metadata:_responses"]` (`response_id`, `background`,
`disposition`), does Python genuinely *need* these as task **metadata**, or could they be
captured as task **input** on the Python side too — the way .NET already does?

**Answer: they can move to task input on Python. There is no genuine technical constraint —
the metadata namespace is a legacy design choice.** Evidence from the Python source
(`azure-ai-agentserver-responses/.../hosting/_resilient_orchestrator.py`):

1. **Write-once, never mutated.** All three keys are written exactly once on first entry, each
   guarded by `if key not in ns:` (`_RESP_RESPONSE_ID`/`_RESP_BACKGROUND` at ~L615/620,
   `_RESP_DISPOSITION` at ~L974). None is ever updated after creation — identical lifecycle to
   an immutable task input.
2. **Already fully derivable from the task input at every read site.** Every reader constructs
   `ResilientResponseInput.from_task_input(params)` and has `resilient.response_id`,
   `resilient.disposition`, and `background = bool(getattr(request, "background", False))` in
   hand. The metadata reads are redundant with values already present in the input.
3. **`response_id`** in metadata is used **only for logging**.
4. **`background`** read is a backward-compat fallback that is purely derivable from
   `request.background`.
5. **The Python spec itself discourages parallel mode-flag metadata.** Spec §5.3 states mode
   flags like `background` should **not** be stored as parallel metadata (drift risk) — the
   `_responses` mirror predates/contradicts that guidance.
6. **Zero external consumers.** The only readers are `_resilient_orchestrator.py` plus two test
   files; nothing outside the Responses layer depends on the namespace.

The single rationale cited in the Python comments is an ordering guarantee ("disposition MUST be
flushed resiliently before the body's first `await`"). **Task input satisfies that strictly
better:** input is persisted at task *creation*, i.e. before the handler body runs at all —
strictly earlier than the first-entry metadata write. So moving these to input preserves (and
tightens) the ordering guarantee.

**Recommendation:** file a Python-side follow-up to capture `response_id`/`background`/
`disposition` in the resilient task **input** (as .NET does) and drop the `metadata:_responses`
namespace. This removes R1 entirely and aligns both languages on a single source of truth. No
.NET change is required (or made) for R1.

