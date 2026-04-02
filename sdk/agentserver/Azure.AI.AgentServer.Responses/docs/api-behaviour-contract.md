# API Behaviour Contract

> **Canonical reference** for the Azure AI Responses API behavioural rules, endpoint matrices, SSE event contract, and error shapes. This document is the single source of truth for how the API **must** behave — all specs, tests, and implementations should conform to it.

---

## Table of Contents

- [API Defaults](#api-defaults)
- [Constraint Dependencies](#constraint-dependencies)
- [Endpoints](#endpoints)
  - [POST /responses (Create)](#endpoint-1--post-responses-create)
  - [GET /responses/{id} (JSON)](#endpoint-2--get-responsesid-json)
  - [GET /responses/{id} (SSE Replay)](#endpoint-3--get-responsesid-sse-replay)
  - [POST /responses/{id}/cancel](#endpoint-4--post-responsesidcancel)
  - [DELETE /responses/{id}](#endpoint-5--delete-responsesid)
  - [GET /responses/{id}/input_items](#endpoint-6--get-responsesidinput_items)
- [Cancellation Scenario Matrix](#cancellation-scenario-matrix)
- [Response Status Lifecycle](#response-status-lifecycle)
- [SSE Event Contract](#sse-event-contract)
- [Error Shapes](#error-shapes)
- [Behavioural Rules Index](#behavioural-rules-index)
- [Token Usage Reporting](#token-usage-reporting-rule-b33)
- [Event Stream Replay Availability](#event-stream-replay-availability-rule-b35)
- [SSE Response Headers](#sse-response-headers)
- [Distributed Tracing](#distributed-tracing)

---

## API Defaults

| Parameter | Default | Notes |
|---|---|---|
| `store` | `true` | Controls server-side persistence of the response |
| `background` | `false` | When true, POST returns immediately; processing runs asynchronously |
| `stream` | `false` | When true, POST returns SSE event stream instead of JSON |

---

## Constraint Dependencies

The following constraints form directed dependency chains. Violations are rejected at creation time (HTTP 400).

| Constraint | Rule |
|---|---|
| `background=true` → requires `store=true` | B13 |
| `cancel` → requires `background=true` → requires `store=true` | B1, B13 |
| `GET /responses/{id}` (JSON) → requires `store=true`; non-background only after completion | B14, B16 |
| `GET /responses/{id}` (SSE replay) → requires `background=true` AND `store=true` AND `stream=true` at creation. Non-background returns 400 (not 404). | B2, B14 |

Summary chain: **Cancel → Background → Store; GET (JSON) → Store (+ non-background: after completion only); SSE replay → Background + Store + stream=true**

**Note:** `conversation`/`conversation_id` can be used with `store=false`. The server reads conversation history but does not persist the response (GET returns 404).

**Corollary**: Cancel on a `store=false` response is not possible — cancel requires `background=true` (B1) which requires `store=true` (B13). If attempted by ID, the response was never persisted, so the server returns HTTP 404.

---

## Endpoints

### Endpoint 1 — `POST /responses` (Create)

#### Full `store × background × stream` Matrix

| # | store | background | stream | HTTP | Content-Type | Behaviour | Label |
|---|---|---|---|---|---|---|---|
| C1 | true | false | false | 200 | `application/json` | Blocks until processing completes. Returns completed `Response` JSON. Retrievable via GET after completion. | **Synchronous, stored** |
| C2 | true | false | true | 200 | `text/event-stream` | Blocks; streams SSE events until processing completes. Terminal event ends the stream. Retrievable via JSON GET after completion. SSE replay via GET returns HTTP 400 (see B2). | **Synchronous streaming, stored** |
| C3 | true | true | false | 200 | `application/json` | Returns immediately with `status: "queued"` or `"in_progress"`. Processing runs in background. Poll via GET (JSON). | **Background poll, stored** |
| C4 | true | true | true | 200 | `text/event-stream` | Returns immediately; streams SSE events as they are emitted. Supports SSE replay via GET. Cancellable. | **Background streaming, stored** |
| C5 | false | false | false | 200 | `application/json` | Blocks until processing completes. Returns completed `Response` JSON. NOT retrievable via GET afterward. | **Synchronous, ephemeral** |
| C6 | false | false | true | 200 | `text/event-stream` | Blocks; streams SSE events until processing completes. NOT retrievable via GET. No SSE replay. | **Synchronous streaming, ephemeral** |
| C7 | false | true | false | **400** | `application/json` | Rejected: `background=true` requires `store=true`. *(Rule B13)* | **Invalid** |
| C8 | false | true | true | **400** | `application/json` | Rejected: `background=true` requires `store=true`. *(Rule B13)* | **Invalid** |

#### Request Body Validation

| Condition | HTTP | Error | Notes |
|---|---|---|---|
| Empty body | 400 | `error.type: "invalid_request_error"` | — |
| Invalid JSON (syntax error) | 400 | `error.type: "invalid_request_error"` | — |
| Missing `model` field | 200 | — | Optional. Resolved: `request.model → server default → ""` |
| Wrong field type (e.g., `stream: "invalid"`) | 400 | `error.type: "invalid_request_error"` | Descriptive message |
| Unknown fields (e.g., `"foo": "bar"`) | 200 | — | Ignored for forward compatibility |

#### Metadata Constraints

- Maximum **16** key-value pairs per response.
- Keys: maximum **64** characters.
- Values: maximum **512** characters.

---

### Endpoint 2 — `GET /responses/{id}` (JSON)

Returns the current `Response` object as JSON. Available for stored responses. Background responses are immediately available; non-background responses become available after completion.

#### Preconditions

- Response must have been created with `store=true` (default). If `store=false`, the response is not persisted → HTTP 404. *(Rule B14)*
- If `background=false`, the response is only available via JSON GET after processing completes. During in-flight processing (synchronous POST still blocking or SSE stream still active), JSON GET returns HTTP 404. SSE replay always returns HTTP 400 for non-background responses (see B2). *(Rule B16)*
- No requirement on `stream` creation flag — JSON GET works for all stored responses (background or completed non-background). *(Rule B5)*

#### Behaviour Matrix

| Response Status | HTTP | Body | Notes |
|---|---|---|---|
| `queued` | 200 | `Response` JSON with `status: "queued"` | Background response not yet started |
| `in_progress` | 200 | `Response` JSON with `status: "in_progress"` | Background response processing; partial output may be present |
| `completed` | 200 | `Response` JSON with `status: "completed"` | `completed_at` is non-null; output preserved |
| `failed` | 200 | `Response` JSON with `status: "failed"` | `error` field is non-null |
| `incomplete` | 200 | `Response` JSON with `status: "incomplete"` | Processing was intentionally terminated early (e.g., max output tokens reached) |
| `cancelled` | 200 | `Response` JSON with `status: "cancelled"` | Output cleared (0 items) |
| (not found) | 404 | Error envelope: `{ "error": { "type": "invalid_request_error" } }` | Unknown ID, `store=false`, or non-background in-flight |

#### Key Observations

- JSON GET returns HTTP 200 with the current snapshot for any **stored** response that is accessible (background, or completed non-background), regardless of `stream` flag or current status. *(Rule B5)*
- Non-background responses are **not available during in-flight processing** (GET returns 404). After completion, they become retrievable if `store=true`. *(Rule B16)*
- `completed_at` is non-null **only** when `status` is `"completed"`. All other statuses have `completed_at: null`. *(Rule B6)*

---

### Endpoint 3 — `GET /responses/{id}` (SSE Replay)

Replays the full SSE event sequence for a completed (or in-progress) background streaming response. Triggered by the `?stream=true` query parameter.

#### Preconditions

- Response must have been created with `store=true`. *(Rule B14)*
- Response must have been created with `background=true`. Non-background responses return HTTP 400 (not 404) when SSE replay is attempted, even if the response is stored and completed. *(Rule B2)*
- Response must have been created with `stream=true`. *(Rule B2)*

All three conditions must be met; otherwise, the server rejects the request.

#### Behaviour Matrix

| Creation Flags | Stored? | HTTP | Result | Rule |
|---|---|---|---|---|
| `background=true, stream=true` | Yes | 200 | SSE replay of all events (or from `starting_after` cursor) | — |
| `background=true, stream=false` | Yes | **400** | Cannot stream — response was not created with `stream=true` | B2 |
| `background=false, stream=true` | Yes | **400** | `"This response cannot be streamed because it was not created with background=true."` (`param: "stream"`) | B2 |
| `background=false, stream=false` | Yes | **400** | Cannot stream — response was created without `stream=true` and without `background=true` (API may prioritize one error over the other) | B2 |
| Any | No (`store=false`) | **404** | Response not persisted | B14 |

#### `starting_after` (Stream Resume)

- Query parameter `starting_after=N` replays only events with `sequence_number > N`. *(Rule B4)*
- If `N` ≥ max sequence number, the server returns HTTP 200 with an empty SSE stream (0 events).
- Sequence numbers are 0-based, monotonically increasing integers. *(Rule B9)*
- Each SSE event is available for replay for a minimum of 10 minutes from when it was emitted (per-event TTL). Early events in long-running responses may expire before the response completes. JSON GET is unaffected by replay buffer eviction. *(Rule B35)*

---

### Endpoint 4 — `POST /responses/{id}/cancel`

Cancels a background response that is still in-progress or queued.

#### Preconditions

- Response must have been created with `background=true`. *(Rule B1)*
  - Since `background=true` requires `store=true` (B13), cancel implicitly requires `store=true`.
- Non-background responses cannot be cancelled via this endpoint. The client should instead terminate the HTTP connection, which triggers cancellation automatically. *(Rules B1, B17)*

#### Behaviour Matrix

| Current Status | background | HTTP | Response Body | Rule |
|---|---|---|---|---|
| `in_progress` | true | **200** | `Response` JSON with `status: "cancelled"`, 0 output items | B7, B11 |
| `queued` | true | **200** | `Response` JSON with `status: "cancelled"`, 0 output items | B7, B11 |
| `cancelled` | true | **200** | Same `Response` JSON (idempotent, no change) | B3 |
| `completed` | true | **400** | Error: `type: "invalid_request_error"`, `message: "Cannot cancel a completed response."` | B12 |
| `failed` | true | **400** | Error: `type: "invalid_request_error"`, `message: "Cannot cancel a failed response."` | B12 |
| `incomplete` | true | **400** | Error: `type: "invalid_request_error"` (terminal status — cancel rejected; exact message unverified) | B12 |
| Any (finished) | false | **400** | Error: `type: "invalid_request_error"`, `message: "Cannot cancel a synchronous response."` (background check first) | B1, B12 |
| Any (in-flight) | false | **404** | Response not yet stored — non-background in-flight responses are not findable | B16 |
| (not found) | — | **404** | Error envelope: `{ "error": { "type": "invalid_request_error" } }` | — |

#### Cancel Winddown Behaviour *(Rule B11)*

When a cancel is successfully processed (HTTP 200):

1. The response `status` transitions to `"cancelled"`.
2. All output items are cleared — `output[]` becomes empty (0 items).
3. If SSE streaming was active, the stream terminates with a `response.failed` event containing `status: "cancelled"`. For non-streaming responses, the status transitions directly to `cancelled` with no SSE events.
4. The terminal outcome is always `status: "cancelled"` — cancellation cannot result in `"completed"`, `"failed"`, or `"incomplete"`.
5. The cancellation may take up to **10 seconds** to finalize (observable as a delay before the terminal SSE event appears on an active stream).

#### Idempotency *(Rule B3)*

- Cancelling an already-cancelled response returns HTTP 200 with the same `Response` body — no state change.
- This does **NOT** apply to `completed` responses. Cancelling a completed response returns HTTP 400.

#### Concurrent Operations

- Concurrent cancel + GET on the same response is safe. Cancel is idempotent (B3), and GET is a read-only snapshot (B5).
- No ordering guarantees between concurrent cancel and GET — the GET may return the pre-cancel or post-cancel state.

#### Connection Termination Cancellation *(Rule B17)*

For non-background (`background=false`) responses, the **only** way to cancel is by terminating the HTTP connection:

1. The client closes/aborts the HTTP connection (e.g., TCP RST, browser abort, or client-side cancellation).
2. The response transitions to `status: "cancelled"` following the same cancellation rules as B11.

This applies to **both** modes:
- **Non-streaming** (`stream=false`): Client disconnects while the synchronous POST is blocking.
- **Streaming** (`stream=true`): Client disconnects the SSE stream mid-flight.

If `store=true`, the cancelled non-background response becomes retrievable once the cancellation completes. If `store=false`, the cancelled response is not retrievable (GET returns 404).

#### Background Connection Resilience *(Rule B18)*

For background (`background=true`) responses, connection termination has **no effect** on the response:

- The response processing continues regardless of client disconnection.
- The response lifecycle is fully decoupled from the HTTP connection.
- The response remains retrievable via `GET /responses/{id}`.
- To cancel, the client must use the explicit `POST /responses/{id}/cancel` endpoint (B1).

This is the fundamental distinction of background mode: the response outlives the connection.

| Mode | Connection Terminated | Processing Effect | Cancel Method |
|---|---|---|---|
| `background=false` | Cancellation triggered (B11 rules apply) | Stops | Connection termination (B17) |
| `background=true` | No effect | Continues | `POST /cancel` endpoint (B1) |

---

### Endpoint 5 — `DELETE /responses/{id}`

Deletes a stored response by ID. The response is no longer retrievable via GET after deletion. *(Rule FR-024)*

#### Preconditions

- Response must have been created with `store=true` (default). If `store=false`, the response is not persisted → HTTP 404.
- Response must not be currently in-flight (non-background). In-flight non-background responses are not findable → HTTP 404.

#### Behaviour Matrix

| Condition | HTTP | Body | Notes |
|---|---|---|---|
| Stored, completed/failed/incomplete/cancelled | **200** | `{ "id": "...", "object": "response.deleted", "deleted": true }` | Response removed from storage |
| Stored, background in-progress/queued | **400** | Error: `type: "invalid_request_error"`, `message: "Cannot delete an in-flight response."` | Must cancel or wait for completion first |
| Not found (unknown ID, `store=false`, non-bg in-flight) | **404** | Error envelope: `{ "error": { "type": "invalid_request_error" } }` | — |

#### Post-Deletion Behaviour

- `GET /responses/{id}` → HTTP 400 with message indicating the response has been deleted.
- `GET /responses/{id}/input_items` → HTTP 400 with message indicating the response has been deleted.
- `POST /responses/{id}/cancel` → HTTP 404 (response no longer found).
- Deletion is permanent and irreversible.

---

### Endpoint 6 — `GET /responses/{id}/input_items`

Returns the input items associated with a stored response as a paginated list. *(Rule FR-025)*

#### Preconditions

- Response must exist and be stored (`store=true`). Non-existent responses → HTTP 404.
- Response must not have been deleted. Deleted responses → HTTP 400.

#### Query Parameters

| Parameter | Type | Default | Constraints | Description |
|---|---|---|---|---|
| `limit` | integer | `20` | 1–100 | Maximum number of items to return per page |
| `order` | string | `"desc"` | `"asc"` or `"desc"` | Sort order by item position |
| `after` | string | — | Valid item ID | Cursor for forward pagination (return items after this ID) |
| `before` | string | — | Valid item ID | Cursor for backward pagination (return items before this ID) |

#### Response Shape

```json
{
  "object": "list",
  "data": [ /* output item objects */ ],
  "first_id": "msg_001",
  "last_id": "msg_003",
  "has_more": false
}
```

The response is a paginated list containing:
- `data`: Array of output item objects (messages, tool calls, etc.) in the requested order.
- `first_id` / `last_id`: IDs of the first and last items in the current page.
- `has_more`: Boolean indicating whether additional pages exist beyond the current result.

#### Behaviour Matrix

| Condition | HTTP | Body | Notes |
|---|---|---|---|
| Stored response with items | **200** | Paginated list JSON | Items returned in requested order |
| Stored response with no items | **200** | Paginated list with empty `data[]` | `has_more: false` |
| Invalid `limit` (< 1 or > 100) | **400** | Error: `type: "invalid_request_error"` | — |
| Deleted response | **400** | Error: `type: "invalid_request_error"` | Response has been deleted |
| Not found | **404** | Error envelope: `{ "error": { "type": "invalid_request_error" } }` | Unknown ID or `store=false` |

#### Input Item Auto-Persistence

Input items are automatically resolved and persisted by the library during response creation:
- **Non-background mode**: Items are resolved and stored when the response reaches a terminal state.
- **Background mode**: Items are resolved and stored at `response.created` time, before processing completes.
- Items include both the current request's inline input and history items resolved from `previous_response_id` or conversation context.

---

## Cancellation Scenario Matrix

Complete matrix of cancel behaviour across all `background × stream × timing` combinations:

| Scenario | background | stream | Cancel When | Cancel HTTP | Cancel Status / Error | Final GET Status | SSE Terminal Event | Output Preserved? |
|---|---|---|---|---|---|---|---|---|
| **S1** | true | false | queued (immediate) | 200 | `status: cancelled` | cancelled | N/A | No (0 items) |
| **S2** | true | false | after completed | 400 | `type: invalid_request_error`, `"Cannot cancel a completed response."` | completed | N/A | Yes |
| **S3** | true | true | after stream completes | 400 | `type: invalid_request_error`, `"Cannot cancel a completed response."` | completed | `response.completed` | Yes |
| **S3b** | true | true | immediate (~0.3s) | 200 | `status: cancelled` | cancelled | `response.failed` | No (0 items) |
| **S4** | false | false | after sync POST returns | 400 | `type: invalid_request_error`, `"Cannot cancel a synchronous response."` | completed | N/A | Yes |
| **S5** | false | true | after stream completes | 400 | `type: invalid_request_error`, `"Cannot cancel a synchronous response."` | completed | `response.completed` | Yes |
| **S6** | true | true | mid-stream (after deltas) | 200 | `status: cancelled` | cancelled | **`response.failed`** | No (0 items) |
| **S7** | false | false | during sync POST (in-flight) | **404** | Response not found (not yet stored) | N/A (in-flight) | N/A | N/A (in-flight) |

**Key patterns**:
- Cancel succeeds (HTTP 200) **only** for `background=true` responses that are `in_progress` or `queued`: **S1**, **S3b**, **S6**.
- Non-background in-flight responses return 404 — not findable until completion (**S7**). After completion, non-background responses reject cancel with HTTP 400 (**S4**, **S5**).
- Already-completed background responses **also** reject cancel (HTTP 400): **S2**, **S3**.
- Successful cancel clears output and (if streaming) terminates with `response.failed`.

---

## Response Status Lifecycle

### Valid Statuses *(Rule B6)*

| Status | Terminal? | `completed_at` | `error` | `output[]` |
|---|---|---|---|---|
| `queued` | No | null | null | empty |
| `in_progress` | No | null | null | partial (may have items) |
| `completed` | Yes | non-null (Unix timestamp) | null | preserved (may be empty — zero-output completion is valid) |
| `failed` | Yes | null | non-null (`ResponseError`) | may be partial |
| `incomplete` | Yes | null | null | may be partial |
| `cancelled` | Yes | null | null | **empty (0 items)** |

> **Note (B6 amendment)**: A `completed` response with `output: []` (zero output items) is valid. A response may complete successfully without producing any output items.

### Valid Transitions

```
queued → in_progress → completed
                     → failed
                     → incomplete
                     → cancelled (via cancel endpoint or connection termination)
       → cancelled    (via cancel endpoint while queued, e.g. S1)
```

No backward transitions are permitted (e.g., `completed` → `in_progress` is invalid).

---

## SSE Event Contract

*(Rules B8, B9, B37)*

### Event Ordering

Every SSE stream follows this structure:

```
response.created          (sequence_number: 0, status: queued | in_progress)
[response.queued]          (optional — background mode)
response.in_progress
  ... lifecycle events ...  (output_item.added, content_part.added, output_text.delta, etc.)
terminal event            (response.completed | response.failed | response.incomplete)
```

**Pre-creation errors**: If an error occurs before `response.created` (e.g., validation failure during SSE stream setup), an `error` SSE event is emitted instead of the normal event sequence. This `error` event is a standalone terminal event — no `response.created` precedes it.

```
error                      (standalone — no response.created)
```

### Sequence Numbers

- Every event has a `sequence_number` field — a 0-based, monotonically increasing integer.
- The first event (`response.created`) has `sequence_number: 0`.
- Stream resume via `starting_after=N` replays events with `sequence_number > N`.

### Terminal Events

| Outcome | Terminal SSE Event | Response Status |
|---|---|---|
| Normal completion | `response.completed` | `completed` |
| Server-side failure | `response.failed` | `failed` |
| Intentional early termination | `response.incomplete` | `incomplete` |
| Cancel triggered | `response.failed` | `cancelled` |
| Pre-creation error | `error` | N/A (no response created) |

Note: Cancelled responses emit `response.failed` as the terminal SSE event, but the `Response` object inside the event has `status: "cancelled"`.

#### Terminal Event Guarantees

Every response lifecycle produces exactly one terminal event. Clients can rely on these guarantees:

1. **Exactly one terminal event**: No response ends without a terminal event; no response produces more than one.
2. **Cancellation always wins**: If cancellation is triggered while processing is still in progress, the outcome is always `status: "cancelled"` with 0 output items — regardless of what processing had produced at that moment. (If the response already completed before cancellation, the cancel is rejected per B12.)
3. **`response.incomplete` is always intentional**: This status reflects a deliberate decision (e.g., max output tokens reached), never an error condition.
4. **Errors produce `response.failed`**: Any error during processing results in `response.failed` with `status: "failed"`.

### `error` SSE Event

The `error` event is a special SSE event type used for errors that occur **before response creation** (e.g., request validation failures during streaming). It contains the standard error envelope shape (`message`, `type`, `param`, `code`).

**Post-creation `error`**: If an error occurs *after* `response.created` has already been sent, it produces a `response.failed` terminal event with a properly populated `error` field and `status: "failed"`. Clients always see `response.failed` as the terminal event for errors that occur after response creation — never a raw `error` event.

### Response Replacement Semantics *(Rule B37)*

Each `response.*` event (`response.created`, `response.queued`, `response.in_progress`, `response.completed`, `response.failed`, `response.incomplete`) defines the **authoritative state** of the `Response` at that point. The `Response` embedded in the event is the single source of truth — it fully determines what `GET /responses/{id}` returns.

**What clients observe**:

1. **The terminal event determines the final output**: The `output` array in the terminal `response.*` event is the definitive output list. If the terminal event has an empty `output` array, the final response has zero output items — regardless of any `output_item.added` events emitted earlier in the stream.

2. **Empty output on completion is valid**: A `response.completed` with `output: []` is a valid response (see B6 amendment).

3. **`agent_reference` is guaranteed**: The `agent_reference` field from the request is always present on the response and all output items (see B21).

4. **Terminal events always have matching status**: A `response.completed` event always has `status: "completed"`, `response.failed` always has `status: "failed"`, etc.

---

## Error Shapes

### HTTP Error Envelope

All HTTP error responses follow the standard error envelope:

```json
{
  "error": {
    "message": "<human-readable description>",
    "type": "<error_category>",
    "param": "<field_name or null>",
    "code": "<specific_error_code or null>"
  }
}
```

### `ResponseError` (on the Response Object)

The `error` field on a `Response` JSON object (when `status: "failed"`) uses a **different shape** from the HTTP error envelope:

| Context | Shape | Fields | Where |
|---|---|---|---|
| **HTTP error response** | Error envelope | `{ error: { message, type, param, code } }` | HTTP 4xx/5xx response body |
| **Response object `error` field** | `ResponseError` | `{ code, message }` | Inside a `Response` JSON when `status: "failed"` |

The `ResponseError` has only `code` and `message` — no `type` or `param`. Example: `{ "code": "server_error", "message": "An internal error occurred." }`.

### Known Error Types and Codes

| `error.type` | `error.code` | HTTP | When |
|---|---|---|---|
| `invalid_request_error` | `null` | 400 | Most bad request cases: malformed request, cancel rejections, invalid streaming request |
| `invalid_request_error` | `unsupported_parameter` | 400 | `store=false` + `background=true` (param: `"background"`) |
| `invalid_request_error` | `missing_required_parameter` | 400 | Missing required field (e.g., param: `"model"`) |
| `invalid_request_error` | `null` | 404 | Unknown response ID, `store=false` response lookup, non-background in-flight |
| `server_error` | `null` | 500 | Unhandled server exception |
| *(no body)* | *(no body)* | 499 | Client disconnected before response completed (non-streaming). Logged by connection logger only; no response body is sent |

### Known Error Messages (Cancel)

All cancel rejections use `error.type: "invalid_request_error"`.

| Message | HTTP | Condition |
|---|---|---|
| `"Cannot cancel a synchronous response."` | 400 | Cancel on any `background=false` response (checked first, regardless of status) |
| `"Cannot cancel a completed response."` | 400 | Cancel on `background=true`, `status: completed` response |
| `"Cannot cancel a failed response."` | 400 | Cancel on `status: failed` response |
| `"Response with id '...' not found."` | 404 | Cancel on `store=false` response, or non-background in-flight response (not yet stored) |

---

## SSE Transport Rules

### Terminal SSE Events *(Rule B26)*

A terminal event is the **last event** in an SSE stream. Exactly one terminal event is emitted per response lifecycle. There is **no `[DONE]` sentinel** — the terminal event itself signals stream completion.

| Terminal Event | When | Response Status |
|---|---|---|
| `response.completed` | Normal completion | `completed` |
| `response.failed` | Server-side failure, cancellation, or error | `failed` or `cancelled` |
| `response.incomplete` | Intentional early termination (e.g., max output tokens) | `incomplete` |
| `error` | Pre-creation error (validation, malformed request) — standalone, no `response.created` precedes it | N/A (no response created) |

### SSE Wire Format *(Rule B27)*

Each SSE event is written as:

```
event: {event_type}\n
data: {json_payload}\n
\n
```

Where `{event_type}` is the event's `type` field (e.g., `response.created`, `output_text.delta`) and `{json_payload}` is the full JSON-serialized event with `sequence_number` injected. No `id:` line is emitted. The `sequence_number` field in the JSON payload serves as the resumption cursor (see B4).

### SSE Keep-Alive *(Rule B28)*

During SSE streaming, the server can send periodic keep-alive comments to prevent proxy/load-balancer timeouts:

- Format: `: keep-alive\n\n` (SSE comment — clients conforming to the SSE spec ignore it)
- **Default: disabled** (no keep-alive comments sent)
- **Opt-in**: Configurable by the server operator

---

## Validation

### Request Payload Validation *(Rule B29)*

Incoming `POST /responses` request payloads are validated against the API schema **before processing**. Validation covers field type constraints, enum value constraints, required fields, and recursive validation of nested objects (tools, reasoning config, prompt, text config, etc.).

**On failure**: HTTP 400 with multi-error `details[]` array:

```json
{
  "error": {
    "type": "invalid_request_error",
    "code": null,
    "message": "Validation failed with N errors: ...",
    "param": "$.first_error_path",
    "details": [
      {
        "type": "invalid_request_error",
        "code": "invalid_value",
        "message": "Expected type 'boolean' but got 'string'.",
        "param": "$.stream"
      }
    ]
  }
}
```

Each detail entry has `type: "invalid_request_error"`, `code: "invalid_value"`, `param: "$.field_path"`, and a human-readable `message`.

### Response Validation *(Rule B30)*

Response output is validated before emission. If invalid output is detected (e.g., a text message with 0 content parts), it is treated as an error:

- **Non-streaming**: HTTP 500 with `"An internal error occurred."` (`type: "server_error"`)
- **Streaming**: response transitions to `failed`, emits `response.failed` terminal SSE event

Full validation error details are **logged but never exposed** to the API caller.

---

## Required Response Fields *(Rule B31)*

Every `Response` object contains these required fields:

| Field | Type | Description |
|---|---|---|
| `id` | string | Response identifier (format: `resp_*`) |
| `object` | string | Always `"response"` |
| `created_at` | integer | Unix timestamp of creation |
| `status` | string | One of the six valid statuses (B6) |
| `output` | array | Output items (may be empty) |
| `model` | string | Resolved model name (B22) |

Terminal status invariants are defined in B6.

---

## Token Usage Reporting *(Rule B33)*

Terminal events (`response.completed`, `response.failed`, `response.incomplete`) can include an optional `usage` field containing token consumption data.

The `usage` object has the following fields:

| Field | Type | Description |
|-------|------|-------------|
| `input_tokens` | long | Number of input tokens consumed |
| `output_tokens` | long | Number of output tokens generated |
| `total_tokens` | long | Sum of input and output tokens |
| `input_tokens_details` | object? | Breakdown of input token types (optional) |
| `output_tokens_details` | object? | Breakdown of output token types (optional) |

If no usage data is available, the `usage` field is omitted from both the terminal SSE event payload and the stored `Response` object (accessible via GET).

---

## Event Stream Replay Availability *(Rule B35)*

Each SSE event is available for replay for a **minimum of 10 minutes from when it was emitted**. The TTL is per-event, not per-response — early events in a long-running response may expire before the response reaches a terminal status. Implementations **must** retain each event for at least this duration to provide clients a reasonable window to reconnect and resume via `starting_after`.

After an event's TTL expires, the server **may** evict it from the replay buffer. Once all events are evicted:

| Resource | Availability |
|---|---|
| JSON GET (`GET /responses/{id}`) | Still available — response data is independent of the replay buffer |
| SSE replay (`GET /responses/{id}?stream=true`) | Partial or no replay — evicted events are not replayable |

Implementations may extend the per-event replay window beyond the 10-minute minimum. The default `InMemoryResponsesProvider` uses a configurable `EventStreamTtl` (default: 10 minutes).

> **Note:** This is the minimum guarantee for event stream replay buffers only. Response data (envelopes, items, history) has no mandated eviction — retention policy is an implementation concern.

---

## SSE Response Headers

All SSE streaming responses (`POST /responses` with `stream=true`, and `GET /responses/{id}?stream=true` replay) include the following HTTP response headers:

| Header | Value | Notes |
|---|---|---|
| `Content-Type` | `text/event-stream; charset=utf-8` | Includes `charset=utf-8` parameter for explicit encoding declaration. Previously `text/event-stream` without charset. |
| `Connection` | `keep-alive` | Signals long-lived connection to reverse proxies (nginx, Azure Front Door, etc.). Prevents premature connection teardown. |
| `Cache-Control` | `no-cache` | Prevents caching of the event stream by intermediaries. |
| `X-Accel-Buffering` | `no` | Disables nginx response buffering, ensuring SSE events are forwarded immediately. |

These headers ensure correct behaviour across reverse proxies, load balancers, and CDNs that may otherwise buffer or terminate long-lived SSE connections.

---

## Distributed Tracing

The library emits OpenTelemetry-compatible `Activity` spans for `POST /responses` requests, tagged with [GenAI semantic conventions](https://opentelemetry.io/docs/specs/semconv/gen-ai/) and additional library-specific attributes.

### Activity Display Name

The activity display name follows the pattern: `invoke_agent {model}`, where `{model}` is the resolved model name from the request (see B22).

### GenAI Parity Tags

These tags align with the OpenTelemetry GenAI semantic conventions:

| Tag | Value | Description |
|---|---|---|
| `gen_ai.response.id` | Response ID (`caresp_*`) | The library-generated response identifier |
| `gen_ai.agent.name` | Agent name from request | The agent name, if provided via `agent_reference` |
| `gen_ai.agent.id` | `{name}:{version}` or `""` | Composite agent identifier combining name and version from `agent_reference`. Empty string when agent is null |
| `gen_ai.provider.name` | `"AzureAI Hosted Agents"` | Fixed provider identifier per protocol spec |
| `service.name` | `"azure.ai.agentserver"` | Service name for trace grouping per protocol spec |

### Additional OTEL Tags

| Tag | Value | Description |
|---|---|---|
| `gen_ai.operation.name` | `"invoke_agent"` | Fixed operation name for agent invocation |
| `gen_ai.request.model` | Resolved model name | Model from the request (B22 resolution) |
| `gen_ai.conversation.id` | Conversation ID | The conversation identifier, if present on the request |
| `gen_ai.agent.version` | Agent version | Agent version from `agent_reference`, if provided |

### Namespaced Tags

| Tag | Value | Description |
|---|---|---|
| `azure.ai.agentserver.responses.response_id` | Response ID | Always set |
| `azure.ai.agentserver.responses.conversation_id` | Conversation ID or `""` | Always set |
| `azure.ai.agentserver.responses.streaming` | `true` / `false` (boolean) | Always set |
| `microsoft.foundry.project.id` | Foundry project ARM resource ID | Always set |

### Request ID Propagation

The `X-Request-Id` HTTP request header, if present, is propagated as the `azure.ai.agentserver.x-request-id` baggage item on the activity. The value is **truncated to 256 characters** to prevent tag value overflow.

### Baggage Items

The library sets the following baggage items on the activity, making them available to downstream telemetry processors and child activities:

| Baggage Key | Value | Description |
|---|---|---|
| `azure.ai.agentserver.response_id` | Response ID | Always set |
| `azure.ai.agentserver.conversation_id` | Conversation ID or `""` | Always set |
| `azure.ai.agentserver.streaming` | `"True"` / `"False"` (PascalCase) | Always set |
| `azure.ai.agentserver.x-request-id` | `X-Request-Id` header value (truncated to 256 chars) | When header is present |

Handlers can read these baggage items from `Activity.Current` for use in downstream tracing or logging.

---

## Behavioural Rules Index

Quick-reference index of all rules:

| # | Rule | One-Liner |
|---|---|---|
| B1 | Cancel requires background | Only `background=true` responses are cancellable via the API |
| B2 | SSE replay requires stream+background | GET with `?stream=true` needs both flags at creation. Non-background returns 400 (not 404) with message about `background=true` |
| B3 | Cancel is idempotent | Re-cancelling a cancelled response returns 200, no state change |
| B4 | Stream resume via `starting_after` | SSE replay skips events with `sequence_number ≤ N` |
| B5 | JSON GET returns current snapshot | Stored responses: returns snapshot regardless of stream flag or status. Non-background: after completion only |
| B6 | Six valid statuses | `queued`, `in_progress`, `completed`, `failed`, `incomplete`, `cancelled` |
| B7 | Cancelled status is "cancelled" | Not "completed" or "failed" |
| B8 | SSE event ordering | `response.created` → [`response.queued` (optional)] → `response.in_progress` → lifecycle → terminal. Initial status is `queued` or `in_progress`. Pre-creation errors use standalone `error` event; post-creation errors are converted to `response.failed` |
| B9 | Sequence numbers | 0-based, monotonically increasing |
| B10 | Background non-streaming | Returns immediately with `queued` or `in_progress`, poll via GET |
| B11 | Cancel winddown | 10s grace period, output cleared, terminal event is `response.failed` with `cancelled` status |
| B12 | Cancel rejection errors | All cancel rejections return `error.type: "invalid_request_error"` with specific messages |
| B13 | Background requires store | `background=true` + `store=false` → HTTP 400 |
| B14 | GET requires store | `store=false` responses are not retrievable |
| B15 | ~~Conversation requires store~~ | Removed — `conversation` + `store=false` is accepted (reads history, doesn't write it) |
| B16 | Non-background in-flight 404 | JSON GET during in-flight returns 404; retrievable after completion if stored. SSE replay → 400 (see B2) |
| B17 | Connection termination cancels non-background | Disconnecting from `POST /responses` cancels the in-flight response when `background=false` (both streaming and non-streaming). Does NOT apply when `background=true` (see B18) |
| B18 | Connection termination does NOT cancel background | Disconnecting has no effect on `background=true` responses; use `/cancel` endpoint |
| B19 | Server identity header | All responses include `x-platform-server: {hosting}/{version} ({language}/{runtime}); {protocol}/{version} ({language}/{runtime})`. Composable via `; ` append. Identity is managed by the shared `ServerUserAgentMiddleware` in the Core package; each protocol registers its segment with the `ServerUserAgentRegistry` during route mapping |
| B20 | Response ID auto-stamp | Output items include a `response_id` field matching the current response ID |
| B21 | Agent reference auto-stamp | `agent_reference` from the request is present on the response and all output items |
| B22 | Model is optional | `model` can be omitted from the request. Resolution: `request.model → default_model → ""`. The resolved model is propagated to the `Response.model` field |
| B23 | Snapshot semantics | SSE events embed immutable point-in-time snapshots of the `Response` at emission time. GET returns a snapshot of the current state. Replay events reflect emission-time state, not current state |
| B24 | Shutdown signal | Host shutdown causes in-flight responses to transition to `failed` |
| B25 | ~~Pluggable provider~~ | Moved to [Library Behavioural Specification](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/library-behaviour-spec.md#persistence-contract) |
| B26 | Terminal SSE events | Exactly one terminal event per lifecycle: `response.completed`, `response.failed`, `response.incomplete`, or standalone `error` (pre-creation). No `[DONE]` sentinel |
| B27 | SSE wire format | Each event: `event: {type}\ndata: {json}\n\n`. No `id:` line. `sequence_number` in JSON payload |
| B28 | SSE keep-alive | Periodic `: keep-alive\n\n` comments, disabled by default. Opt-in via server configuration |
| B29 | Request payload validation | Requests validated against API schema before processing. Invalid → 400 with `details[]` array. Each detail: `type: "invalid_request_error"`, `code: "invalid_value"`, `param: "$.field"` |
| B30 | Response validation | Invalid response output → 500 `"server_error"` (non-streaming) or `response.failed` (streaming). Details logged, never exposed |
| B31 | Required response fields | Every `Response` has `id`, `object`, `created_at`, `status`, `output[]`, `model`. Terminal status invariants per B6 |
| B32 | Terminal event guarantee | Every response lifecycle produces exactly one terminal event. If processing ends without one, the API returns `response.failed` |
| B33 | Token usage | Terminal events include optional `usage` object with input/output/total token counts |
| B34 | ~~Distributed tracing~~ | Moved to [Library Behavioural Specification](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/library-behaviour-spec.md#observability-requirements) |
| B35 | Event stream replay availability | Each SSE event retained for a minimum of 10 minutes from emission (per-event TTL). JSON GET unaffected by replay buffer eviction |
| B36 | ~~Response persistence timing~~ | Moved to [Library Behavioural Specification](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/library-behaviour-spec.md#persistence-contract) |
| B37 | Response state in SSE events | Each `response.*` event defines the authoritative `Response` state. `agent_reference` from the request is guaranteed on every response. Terminal events always have matching `status`. The terminal event's `output` array is the definitive output list |
