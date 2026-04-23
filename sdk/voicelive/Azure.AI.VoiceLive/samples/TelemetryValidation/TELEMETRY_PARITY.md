# VoiceLive Telemetry — C# / Python Parity Reference

This document is the single source of truth for achieving parity between the C# and Python VoiceLive telemetry implementations.

---

## 0. Key Classes & Constants

### C# (this SDK)

| Class | File | Role |
|---|---|---|
| `VoiceLiveTracer` | `src/Telemetry/VoiceLiveTracer.cs` | All span creation and enrichment; `ActivitySource("Azure.AI.VoiceLive", "1.1.0")` |
| `VoiceLiveTelemetryAttributeKeys` | `src/Telemetry/VoiceLiveTelemetryAttributeKeys.cs` | All wire-value string constants (single source of truth for attribute names) |
| `VoiceLiveSession` (send path) | `src/Customizations/VoiceLiveSession.cs` | `SendCommandAsync` dispatches to tracer |
| `VoiceLiveSession` (recv path) | `src/Customizations/VoiceLiveSession.Updates.cs` | `InstrumentRecvEvent` → switch → tracer |
| `VoiceLiveSession` (lifecycle) | `src/Customizations/VoiceLiveSession.Protocol.cs` | `ConnectAsync` / `CloseAsync` own connect span start/end |

ActivitySource name: **`"Azure.AI.VoiceLive"`**, version **`"1.1.0"`**

### Python (reference implementation)

| Class | Role |
|---|---|
| `VoiceLiveInstrumentor` | Registers the OTel instrumentor; activation via `AZURE_EXPERIMENTAL_ENABLE_GENAI_TRACING=true` |
| `_VoiceLiveConnectionManager` | Manages the connect span lifetime, session-level counters, and back-fills |
| `VoiceLiveConnection` | Per-message send/recv span creation and enrichment |

Content recording activation: `OTEL_INSTRUMENTATION_GENAI_CAPTURE_MESSAGE_CONTENT=true` (both Python and C#)

---

## 1. Span Hierarchy (design doc rule)

```
connect  (root, session lifetime, ActivityKind.Client)
  ├─ send {event_type}     (child, short-lived, one per outgoing command)
  ├─ recv {event_type}     (child, short-lived, one per incoming message)
  └─ close                 (child, session teardown)
```

- All child spans use **explicit parent context** so concurrent send/recv loops are correctly parented.
- Send/recv spans appear interleaved in export order — this is **expected** (full-duplex WebSocket).

---

## 2. Actual C# Trace (from `csharp_traces.json`, 2026-04-21)

The trace below is from a live run. Annotations `[GAP]` call out missing attributes vs. Python/design-doc.

### connect
```json
{
  "name": "connect",
  "kind": "SpanKind.CLIENT",
  "parent_id": null,
  "attributes": {
    "az.namespace": "Microsoft.CognitiveServices",
    "gen_ai.provider.name": "microsoft.foundry",
    "gen_ai.system": "az.ai.voicelive",
    "gen_ai.operation.name": "connect",
    "server.address": "emilyjiji-ai.services.ai.azure.com",
    "server.port": 443,
    "gen_ai.request.model": "gpt-4o",
    "gen_ai.voice.session_id": "sess_7CS7imo8BVxS0joBbZWdED"
    // [GAP Ph2] gen_ai.request.temperature     — from session.update send (session.temperature)
    // [GAP Ph2] gen_ai.system_instructions      — from session.update send (session.instructions); wire value uses UNDERSCORE
    // [GAP Ph2] gen_ai.request.tools            — from session.update send (session.tools)
    // [GAP Ph2] gen_ai.voice.input_audio_format  — from session.update send (session.input_audio_format)
    // [GAP Ph2] gen_ai.voice.output_audio_format — from session.update send (session.output_audio_format)
    // [GAP Ph2] gen_ai.voice.input_sample_rate   — from session.update send (session.input_audio_sample_rate)
    // [GAP Ph2] gen_ai.agent.name                — from AgentSessionConfig.agent_name at connect time (not recv)
    // [GAP Ph2] gen_ai.agent.id                  — from session.agent.id in recv session.created/updated (if present)
    // [GAP Ph2] gen_ai.agent.thread_id           — from session.agent.thread_id in recv session.created/updated (if present)
    // [GAP Ph2] gen_ai.agent.version             — from AgentSessionConfig.agent_version at connect time (if present)
    // [GAP Ph2] gen_ai.agent.project_name        — from AgentSessionConfig.project_name at connect time (if present)
    // [GAP Ph1] gen_ai.conversation.id           — back-filled from response.done ✓ (now fixed)
    // [GAP Ph3] gen_ai.voice.turn_count          — flushed on close (wrong trigger currently)
    // [GAP Ph3] gen_ai.voice.first_token_latency_ms — also flushed to connect span at close (currently only on recv span for first audio delta; Python emits on BOTH)
  },
  "events": []  // [GAP Ph2] gen_ai.system.instructions event missing; event name uses DOTS; content = [{"role":"system","content":"..."}]; CONDITIONAL: only when content recording ON and instructions set
}
```

### send session.update
```json
{
  "name": "send session.update",
  "attributes": {
    "gen_ai.voice.event_type": "session.update",
    "gen_ai.voice.message_size": 142,
    "gen_ai.system_instructions": "You are a helpful assistant."  // [GAP Ph2] belongs on CONNECT span, not here; wire value = gen_ai.system_instructions (underscore)
    // [GAP Ph2] gen_ai.request.temperature should also go on connect span, not here
  },
  "events": [
    { "name": "gen_ai.input.messages", "attributes": { "gen_ai.event.content": "..." } }
    // [GAP Ph2] gen_ai.system.instructions span event (content = [{"role":"system","content":"..."}]) should be on CONNECT span (not send span)
  ]
}
```

### recv session.created
```json
{
  "name": "recv session.created",
  "attributes": {
    "gen_ai.voice.session_id": "sess_7CS7imo8BVxS0joBbZWdED",
    "gen_ai.response.model": "gpt-4o-2024-11-20",   // [GAP Ph2] parity gap: Python uses gen_ai.request.model here, not gen_ai.response.model
    "gen_ai.voice.input_audio_format": "pcm16",      // [GAP Ph2] audio formats should NOT be on recv spans; Python puts them only on connect span
    "gen_ai.voice.output_audio_format": "pcm16"      // [GAP Ph2] same — remove from here, set on connect span only
    // [GAP Ph2] gen_ai.agent.name / gen_ai.agent.project_name go on CONNECT span (not here) when session.agent is set
  }
}
```

### send conversation.item.create
```json
{
  "name": "send conversation.item.create",
  "attributes": {
    "gen_ai.voice.session_id": "sess_7CS7imo8BVxS0joBbZWdED",
    "gen_ai.voice.event_type": "conversation.item.create"
    // [GAP Ph1] gen_ai.voice.previous_item_id — from event.previous_item_id ✓ (now fixed)
    // [GAP Ph1] gen_ai.voice.call_id          — from event.item.call_id (MCP tool calls) ✓ (now fixed)
    // [GAP Ph1] gen_ai.conversation.id        — when known ✓ (now fixed)
  }
}
```

### recv conversation.item.created
```json
{
  "name": "recv conversation.item.created",
  "attributes": {
    "gen_ai.voice.session_id": "sess_7CS7imo8BVxS0joBbZWdED",
    "gen_ai.voice.item_id": "item_63Y4zPhcSQFMjgdnNYhAEt"
    // [GAP Ph1] gen_ai.voice.call_id     — from item.call_id (MCP items) ✓ (now fixed)
    // [GAP Ph1] gen_ai.conversation.id   — when known ✓ (now fixed)
  }
}
```

### recv response.created
```json
{
  "name": "recv response.created",
  "attributes": {
    "gen_ai.voice.session_id": "sess_7CS7imo8BVxS0joBbZWdED",
    "gen_ai.voice.event_type": "response.created"
    // [GAP Ph1] gen_ai.response.id — from response.id field ✓ (now fixed via ExtractRecvIds)
    // [GAP Ph1] gen_ai.conversation.id — also available here from response.conversation_id ✓
    // [GAP Ph3] this event type wasn't in the switch — now it is (fixed)
  }
}
```

### recv response.output_item.added / response.output_item.done
```json
{
  "name": "recv response.output_item.added",
  "attributes": {
    "gen_ai.voice.item_id": "msg_4D6P2fXVZfO0UdQmA551wU",
    "gen_ai.voice.output_index": 0
    // [GAP Ph1] gen_ai.response.id    — from response_id ✓ (now fixed via ExtractRecvIds)
    // [GAP Ph1] gen_ai.conversation.id — when known ✓ (now fixed)
  }
}
```

### recv response.done
```json
{
  "name": "recv response.done",
  "attributes": {
    "gen_ai.voice.session_id": "sess_7CS7imo8BVxS0joBbZWdED",
    "gen_ai.response.id": "resp_7JuOiguD2LFhsxWWnDHsOl",
    "gen_ai.response.finish_reasons": "completed",
    "gen_ai.usage.input_tokens": 0,
    "gen_ai.usage.output_tokens": 9
    // [GAP Ph1] gen_ai.conversation.id — from response.conversation_id ✓ (now fixed)
    // [GAP Ph3] turn_count increment — currently on speech_started (wrong); should be here
    // [GAP Ph4] gen_ai.event.content should be structured {"messages":[...]} not raw JSON
  }
}
```

---

## 3. Expected Python-Style Trace (reconstructed from `_voicelive_instrumentor.py`)

Key differences from C# current output:

### connect (Python)
```json
{
  "name": "connect",
  "attributes": {
    "az.namespace": "Microsoft.CognitiveServices",
    "gen_ai.provider.name": "microsoft.foundry",
    "gen_ai.system": "az.ai.voicelive",
    "gen_ai.operation.name": "connect",
    "server.address": "...",
    "server.port": 443,
    "gen_ai.request.model": "gpt-4o",
    "gen_ai.voice.session_id": "sess_...",
    "gen_ai.conversation.id": "conv_...",           // back-filled from response.done (or response.created, or AgentSessionConfig)
    "gen_ai.request.temperature": 0.8,              // CONDITIONAL: only if session.update explicitly sets temperature
    "gen_ai.system_instructions": "You are...",     // CONDITIONAL: only if session.update sets instructions; wire value uses UNDERSCORE
    "gen_ai.voice.input_audio_format": "pcm16",     // from session.update send OR session.created recv; connect span ONLY (not on recv spans)
    "gen_ai.voice.output_audio_format": "pcm16",    // same
    "gen_ai.voice.input_sample_rate": 24000,        // CONDITIONAL: only if session.update sets input_audio_sample_rate
    "gen_ai.agent.name": "agentv2",                 // from AgentSessionConfig.agent_name at connect (agent sessions only)
    "gen_ai.agent.version": "1.0",                  // from AgentSessionConfig.agent_version at connect (if present; agent sessions only)
    "gen_ai.agent.project_name": "myproject",       // from AgentSessionConfig.project_name at connect (if present; agent sessions only)
    "gen_ai.agent.id": "agent_abc123",              // back-filled from session.agent.agent_id in recv session.created/updated (if present)
    "gen_ai.agent.thread_id": "thread_xyz",         // back-filled from session.agent.thread_id in recv session.created/updated (if present)
    "gen_ai.request.max_output_tokens": 4096,       // CONDITIONAL: from session.update max_response_output_tokens (if set)
    "gen_ai.voice.turn_count": 1,                   // flushed on close
    "gen_ai.voice.interruption_count": 0,
    "gen_ai.voice.audio_bytes_sent": 0,
    "gen_ai.voice.audio_bytes_received": 0,
    "gen_ai.voice.first_token_latency_ms": 523.4    // flushed to connect span at close; ALSO emitted on recv span for first audio delta
  },
  "events": [
    // gen_ai.system.instructions event: CONTENT RECORDING CONDITIONAL (OTEL_INSTRUMENTATION_GENAI_CAPTURE_MESSAGE_CONTENT=true)
    // AND only emitted when session.update includes instructions
    // fc_telemetry.log showed events:[] because content recording was OFF during that capture
    {
      "name": "gen_ai.system.instructions",     // event name uses DOTS; different from gen_ai.system_instructions attribute
      "attributes": {
        "gen_ai.provider.name": "microsoft.foundry",  // ⚠ event uses gen_ai.provider.name (NOT gen_ai.system)
        "gen_ai.event.content": "[{\"role\": \"system\", \"content\": \"You are a helpful assistant.\"}]"
        // content is a JSON ARRAY, not a raw string
      }
    }
  ]
}
```

### send session.update (Python)
```json
{
  "name": "send session.update",
  "attributes": {
    // standard attrs — NO system_instructions here (goes on connect span)
    // NO temperature here (goes on connect span)
    "gen_ai.voice.event_type": "session.update",
    "gen_ai.voice.message_size": 142
  },
  "events": [
    { "name": "gen_ai.input.messages", "attributes": { "gen_ai.event.content": "..." } }
  ]
}
```

### recv session.created (Python)
```json
{
  "name": "recv session.created",
  "attributes": {
    "gen_ai.voice.session_id": "sess_...",
    "gen_ai.request.model": "gpt-4o-2024-11-20"  // Python uses gen_ai.REQUEST.model (not gen_ai.response.model)
    // NO audio format attributes here — they go on the connect span only
  }
}
```

### recv response.done (Python)
```json
{
  "name": "recv response.done",
  "attributes": {
    "gen_ai.response.id": "resp_...",
    "gen_ai.conversation.id": "conv_...",     // from response.conversation_id
    "gen_ai.response.finish_reasons": "completed",
    "gen_ai.usage.input_tokens": 0,
    "gen_ai.usage.output_tokens": 9
  },
  "events": [
    {
      "name": "gen_ai.output.messages",
      "attributes": {
        "gen_ai.event.content": "{\"messages\": [...]}"  // structured, NOT raw JSON
      }
    }
  ]
}
```

---

## 4. Gap Analysis Table

| Span | Attribute / Behavior | Status | Phase |
|---|---|---|---|
| connect | `gen_ai.conversation.id` back-fill | ✅ Fixed (Ph1) | 1 |
| connect | `gen_ai.request.temperature` — exists on send span, needs to move to `_connectActivity` | ❌ Wrong span | 2 |
| connect | `gen_ai.system_instructions` — exists on send span when content recording ON; needs to move to connect + remove content recording guard on attribute (keep guard on event only) | ❌ Wrong span + wrong guard | 2 |
| connect | `gen_ai.request.tools` — exists on send span when content recording ON; needs to move to connect + remove content recording guard | ❌ Wrong span + wrong guard | 2 |
| connect | `gen_ai.request.max_output_tokens` — exists on send span, needs to move to `_connectActivity` | ❌ Wrong span | 2 |
| connect | `gen_ai.voice.input_audio_format` — not in EnrichSendSessionUpdate yet; on recv span only | ❌ Missing from send path; wrong location on recv | 2 |
| connect | `gen_ai.voice.output_audio_format` — not in EnrichSendSessionUpdate yet; on recv span only | ❌ Missing from send path; wrong location on recv | 2 |
| connect | `gen_ai.voice.input_sample_rate` — not in EnrichSendSessionUpdate yet; on recv span only | ❌ Missing from send path; wrong location on recv | 2 |
| connect | `gen_ai.voice.output_sample_rate` — on recv span only (EnrichRecvSessionEvent line 385) | ❌ Wrong location | 2 |
| connect | `gen_ai.agent.name` from URL query param `agent-name` | ✅ Done (StartConnectActivity) | — |
| connect | `gen_ai.agent.version` from URL query param `agent-version` | ✅ Done (StartConnectActivity) | — |
| connect | `gen_ai.agent.project_name` from URL query param `agent-project-name` | ✅ Done (StartConnectActivity) | — |
| connect | `gen_ai.agent.id` back-filled from session.agent.agent_id in recv session.created/updated | ❌ Missing | 2 |
| connect | `gen_ai.agent.thread_id` back-filled from session.agent.thread_id in recv session.created/updated | ❌ Missing | 2 |
| connect | `gen_ai.request.max_output_tokens` from session.update max_response_output_tokens | ❌ Missing | 2 |
| connect | `gen_ai.system.instructions` span event (event attrs: gen_ai.provider.name + gen_ai.event.content; content-recording conditional) | ❌ Missing | 2 |
| connect | `gen_ai.voice.turn_count` correct trigger | ❌ Wrong (speech_started) | 3 |
| connect | `gen_ai.voice.first_token_latency_ms` flushed at close | ❌ Not yet on connect span (only on recv span) | 3 |
| recv response.audio.delta | `gen_ai.voice.first_token_latency_ms` on first delta recv span | ✅ Done (Ph1) | 1 |
| recv session.created | has both `gen_ai.request.model` (from StartRecvActivity) AND `gen_ai.response.model` (from EnrichRecvSessionEvent) — remove `gen_ai.response.model` | ❌ Extra attr | 2 |
| recv session.created | audio format attrs (input/output format + both sample rates) should be removed; set on connect only | ❌ Wrong location | 2 |
| send/recv | `gen_ai.conversation.id` propagated | ✅ Fixed (Ph1) | 1 |
| send session.update | `gen_ai.system_instructions` attr on SEND span (should be CONNECT) | ❌ Wrong location | 2 |
| send response.cancel | `gen_ai.response.id` from response_id | ✅ Fixed (Ph1) | 1 |
| send conversation.item.create | `previous_item_id`, `call_id`, approval fields | ✅ Fixed (Ph1) | 1 |
| recv (all) | `ExtractRecvIds` — response_id, call_id, previous_item_id, output_index | ✅ Fixed (Ph1) | 1 |
| recv item-bearing | nested `item.id`, `item.call_id`, MCP fields | ✅ Fixed (Ph1) | 1 |
| recv response.done | `gen_ai.conversation.id` from response.conversation_id | ✅ Fixed (Ph1) | 1 |
| recv response.done | turn_count increment | ❌ Wrong trigger | 3 |
| recv response.done | structured `gen_ai.event.content` | ❌ Raw JSON only | 4 |
| recv response.created | in switch (span existed but no enrichment) | ❌ Not in switch | 3 |
| recv response.text.done | structured `{"text": ...}` content | ❌ Raw JSON only | 4 |
| recv response.audio_transcript.done | structured `{"transcript": ...}` content | ❌ Raw JSON only | 4 |
| recv response.content_part.done | structured `{"text":.., "transcript":..}` content | ❌ Raw JSON only | 4 |
| recv response.output_item.done | structured `{"messages": [...]}` content | ❌ Raw JSON only | 4 |
| recv error | `gen_ai.voice.error` span event | ❌ Missing | 4 |
| recv rate_limits.updated | `gen_ai.voice.rate_limits.updated` span event | ❌ Missing | 4 |
| close | span wraps WebSocket.CloseAsync | ✅ Done | P1-1 |

---

## 5. Phases & Checklist

### Phase 1 — ID Tracking & Propagation ✅ COMPLETE

- [x] `_conversationId` field + `SetConversationId()` helper (back-fills connect span) — `ExtractRecvIds_ConversationId_BackfillsToConnectSpan`
- [x] `gen_ai.conversation.id` on send/recv spans when known — `ExtractRecvIds_ConversationId_BackfillsToConnectSpan`
- [x] `ExtractRecvIds()` — all recv events: top-level response_id, call_id, previous_item_id, output_index; nested response.id + response.conversation_id; item.* for 4 item-bearing events — `ExtractRecvIds_SetsTopLevelIdsOnActivity`, `ExtractRecvIds_ConversationItemCreated_SetsPreviousItemIdAndItemId`, `ExtractRecvIds_OutputItemAddedWithApproval_SetsApprovalAttributes`
- [x] `ExtractSendIds()` — response.cancel (response_id); conversation.item.create (item.call_id, approval fields, previous_item_id) — `ExtractSendIds_ResponseCancel_SetsResponseId`, `ExtractSendIds_ConversationItemCreate_SetsCallIdAndPreviousItemId`, `ExtractSendIds_ConversationItemCreate_SetsApprovalAttributes`
- [x] Wired in `InstrumentRecvEvent` and `SendCommandAsync` — `SendCommandAsync_SessionUpdate_CreatesSpan`
- [x] Close span (`StartCloseActivity`) added to both `CloseAsync` and `DisposeAsyncCore` — `CloseActivity_IsParentedToConnectActivity`

---

### Phase 2 — Connect Span Attributes ✅ COMPLETE

> Python (`_VoiceLiveConnectionManager`): `_extract_session_config_from_send` sets config attrs on **connect span**, not send span.
> Python: `_extract_agent_config_from_session` extracts `agent.name` / `agent.project_name` onto **connect span** (not `agent.id` or `agent.thread_id`).
> Wire value for system instructions attribute: `gen_ai.system_instructions` (UNDERSCORE — not `gen_ai.system.message`).
> Span event name for system instructions: `gen_ai.system.instructions` (DOTS — different from the attribute).
> System instructions event content: JSON array `[{"role": "system", "content": "..."}]`, not a raw string.
> Temperature, tools, and system_instructions are **conditional**: only set on connect span when session.update explicitly includes them.
> `gen_ai.system.instructions` span event is **content-recording conditional** (`OTEL_INSTRUMENTATION_GENAI_CAPTURE_MESSAGE_CONTENT=true`).
> Audio formats go on **connect span only** — NOT on recv session.created/updated spans.
> Python recv session.created uses `gen_ai.request.model` (not `gen_ai.response.model`).

**`VoiceLiveTracer.cs`:**
- [x] `EnrichSendSessionUpdate`: copy temperature onto `_connectActivity` as `gen_ai.request.temperature` — **only if field present in session.update** — `EnrichSendSessionUpdate_SetsTemperatureAndMaxOutputTokens`
- [x] `EnrichSendSessionUpdate`: copy instructions onto `_connectActivity` as `gen_ai.system_instructions` (wire: underscore) — **only if field present** — `EnrichSendSessionUpdate_SetsInstructionsAndToolsOnConnectSpan`, `EnrichSendSessionUpdate_DoesNotSetSystemInstructionsOnSendSpan`
- [x] `EnrichSendSessionUpdate`: copy tools onto `_connectActivity` as `gen_ai.request.tools` — **only if field present** — `EnrichSendSessionUpdate_SetsInstructionsAndToolsOnConnectSpan`
- [x] `EnrichSendSessionUpdate`: copy `max_response_output_tokens` onto `_connectActivity` as `gen_ai.request.max_output_tokens` — **only if field present** — `EnrichSendSessionUpdate_SetsTemperatureAndMaxOutputTokens`
- [x] `EnrichSendSessionUpdate`: copy `input_audio_format`, `output_audio_format`, `input_audio_sample_rate` onto `_connectActivity` — **only if fields present** — `EnrichSendSessionUpdate_SetsAudioFormatsOnConnectSpan`, `EnrichSendSessionUpdate_SetsSampleRatesOnConnectSpan`
- [x] `EnrichRecvSessionEvent`: extract `session.agent.agent_id` → `gen_ai.agent.id` on `_connectActivity` (if present; agent sessions only) — `EnrichRecvSessionEvent_SetsAgentIdAndThreadIdOnConnectSpan`
- [x] `EnrichRecvSessionEvent`: extract `session.agent.thread_id` → `gen_ai.agent.thread_id` on `_connectActivity` (if present; agent sessions only) — `EnrichRecvSessionEvent_SetsAgentIdAndThreadIdOnConnectSpan`
- [x] `EnrichRecvSessionEvent`: extract `session.agent.name` → `gen_ai.agent.name` on `_connectActivity` (if not already set from AgentSessionConfig) — `EnrichRecvSessionEvent_SetsAgentNameOnConnectSpan_WhenNotSetFromUrl`
- [N/A] `EnrichRecvSessionEvent`: extract `session.agent.project_name` → `gen_ai.agent.project_name` on `_connectActivity` — **wire field does not exist** in `RespondingAgentOptions`; `project_name` only comes from URL query params (AgentSessionConfig path), not from session events
- [x] Connect-time AgentSessionConfig extraction: set `gen_ai.agent.name`, `gen_ai.agent.version`, `gen_ai.agent.project_name` from `AgentSessionConfig` at `ConnectAsync` time — `ConnectActivity_WithAgentEndpoint_HasAgentAttributes`
- [x] `EnrichRecvSessionEvent`: copy `input_audio_format`, `output_audio_format` onto `_connectActivity` if not already set from send; **do NOT set on the recv span itself** — `EnrichRecvSessionEvent_SetsAudioFormatsOnConnectSpan`, `EnrichRecvSessionEvent_DoesNotSetAudioFormatsOnRecvSpan`
- [x] `EnrichRecvSessionEvent`: fix recv session.created/updated spans to use `gen_ai.request.model` (not `gen_ai.response.model`) — `EnrichRecvSessionEvent_DoesNotSetResponseModelOnAnySpan`
- [x] `EnrichRecvSessionEvent`: remove audio format attrs from recv session spans (connect span only) — `EnrichRecvSessionEvent_DoesNotSetAudioFormatsOnRecvSpan`
- [x] Add `EmitSystemInstructionsEvent(string instructions)` — adds `gen_ai.system.instructions` event to `_connectActivity`; event attrs: `gen_ai.provider.name` + `gen_ai.event.content` = `[{"role":"system","content":"..."}]`; **only when content recording ON** — `EmitSystemInstructionsEvent_WhenContentEnabled_AddsEventToConnectSpan`, `EmitSystemInstructionsEvent_WhenContentDisabled_NoEventOnConnectSpan`

**`VoiceLiveSession.cs`:**
- [x] Remove `gen_ai.system_instructions` attribute from send span (moves to connect span) — `EnrichSendSessionUpdate_DoesNotSetSystemInstructionsOnSendSpan`
- [x] Call `EmitSystemInstructionsEvent` from session.update send path (content recording on only) — `EmitSystemInstructionsEvent_WhenContentEnabled_AddsEventToConnectSpan`

---

### Phase 3 — Counter Fix & Recv Coverage ✅ COMPLETE

> Python: turn_count is incremented on `RESPONSE_DONE`, not `input_audio_buffer.speech_started`.
> Python: first_token_latency_ms is a session-level attribute on connect span, not a per-recv-span attribute.

**`VoiceLiveTracer.cs`:**
- [x] Move turn_count increment from `OnRecvSpeechStarted` to `EnrichRecvResponseDone` — `OnRecvResponseDone_IncrementsTurnCount`
- [x] Move `gen_ai.voice.first_token_latency_ms` from recv span to connect span (record in `_connectActivity` on first audio delta; flush on close) — `TryRecordFirstTokenLatency_FlushesToConnectSpanAtClose`
- [x] (Keep `OnRecvSpeechStarted` for interruption_count or remove it) — `OnRecvResponseDone_IncrementsTurnCount`

**`VoiceLiveSession.Updates.cs`:**
- [x] Add `response.created` case to `InstrumentRecvEvent` switch — `GetUpdatesAsync_ResponseCreated_ProducesRecvSpan`

---

### Phase 4 — Structured Content & Error Events ✅ COMPLETE

> Python: `_extract_done_event_content` returns structured JSON for "done" events regardless of content recording flag.
> Python: `force_content=True` when done_content is not None.
> Rate limits event name: `gen_ai.voice.rate_limits.updated` (NOT `gen_ai.voice.rate_limits`).

**`VoiceLiveTracer.cs`:**
- [x] Add `ExtractDoneEventContent(string eventType, JsonElement root)` → returns structured JSON or null:
  - `response.function_call_arguments.done` → `{"name": .., "arguments": ..}` — `ExtractDoneEventContent_FunctionCallArgumentsDone_ReturnsNameAndArguments`
  - `response.text.done` → `{"text": ..}` — `ExtractDoneEventContent_ResponseTextDone_ReturnsTextObject`
  - `response.audio_transcript.done` → `{"transcript": ..}` — `ExtractDoneEventContent_ResponseAudioTranscriptDone_ReturnsTranscriptObject`
  - `response.content_part.done` → `{"text": .., "transcript": ..}` — `ExtractDoneEventContent_ContentPartDone_ReturnsTextAndTranscript`, `ExtractDoneEventContent_ContentPartDone_TextOnly_OmitsTranscript`
  - `response.output_item.done` → `{"messages": [item]}` — `ExtractDoneEventContent_ResponseOutputItemDone_ReturnsMessages`
  - `response.done` → `{"messages": [all output items]}` — `ExtractDoneEventContent_ResponseDone_ReturnsOutputItemsArray`
- [x] Update `AddRecvContentEvent` to accept optional `forceContent` string — emit it regardless of content recording flag — `AddRecvContentEvent_WithForceContent_EmitsContentWhenRecordingDisabled`
- [x] Add `AddErrorEvent(Activity activity, JsonElement root)` — `gen_ai.voice.error` event with error.code + error.message — `EnrichRecvErrorEvent_SetsErrorStatusAndAddsSpanEvent`
- [x] Add `AddRateLimitsEvent(Activity activity, JsonElement root)` — `gen_ai.voice.rate_limits.updated` event — `AddRateLimitsEvent_WhenContentEnabled_AddsEventWithPayload`, `AddRateLimitsEvent_WhenContentDisabled_AddsEventWithoutPayload`

**`VoiceLiveSession.Updates.cs`:**
- [x] Add `error` case to switch → call `AddErrorEvent` — `EnrichRecvErrorEvent_SetsErrorStatusAndAddsSpanEvent`
- [x] Add `rate_limits.updated` case → call `AddRateLimitsEvent` — `GetUpdatesAsync_RateLimitsUpdated_ProducesRecvSpanWithEvent`
- [x] For done events: compute structured content, pass as `forceContent` to `AddRecvContentEvent` — `GetUpdatesAsync_ResponseTextDone_EmitsStructuredContent`

---

### Phase 5 — Metrics ✅ COMPLETE

- [x] Create `VoiceLiveMeter.cs` with `Meter("Azure.AI.VoiceLive")` — static histograms `OperationDuration` and `TokenUsage`
- [x] `gen_ai.client.operation.duration` histogram (record in `EndConnectActivity`) — dimensions: `gen_ai.system`, `gen_ai.provider.name` (**fixed**: was missing from `BuildCommonMetricTags()` — design doc spec line 310 requires it), `gen_ai.operation.name`, `server.address`, `server.port`, `gen_ai.request.model`, `error.type` (if error) — `EndConnectActivity_RecordsOperationDurationMetric` (updated to assert `gen_ai.provider.name`)
- [x] `gen_ai.client.token.usage` histogram (record from response.done token counts; accumulated across all turns per session) — dimensions: same common tags + `gen_ai.token.type` (input|output) — `EndConnectActivity_WithTokens_RecordsTokenUsageMetric`, `EndConnectActivity_MultipleResponseDone_AccumulatesTokens`
- [x] `gen_ai.voice.message_size` set on every send span — `SendCommandAsync_SessionUpdate_RecordsMessageSize`
- [x] `gen_ai.voice.message_size` set on every recv span — `GetUpdatesAsync_SessionCreated_RecordsMessageSize`

---

### Phase 6 — Design Doc Cross-Validation ✅ COMPLETE

> Cross-validated all implementation and tests against `TELEMETRY_DESIGN.md` (Python reference spec).
> All behavioral requirements confirmed implemented and tested. One implementation gap found and fixed (metric dimensions).

**Findings:**

- [x] Standard span attributes (`az.namespace`, `gen_ai.system`, `gen_ai.operation.name`, `gen_ai.provider.name`, `server.address`, `server.port`) — all correctly set in `SetCommonAttributes()` on every span — `ConnectActivity_HasCommonAttributes`
- [x] Session-level counters (`turn_count`, `interruption_count`, `audio_bytes_sent`, `audio_bytes_received`, `first_token_latency_ms`) — all accumulated and flushed to connect span at close — `SessionCounters_AccumulateAndAppearOnConnectSpan`, `TryRecordFirstTokenLatency_FlushesToConnectSpanAtClose`
- [x] Agent attributes (all 5: `agent.name`, `agent.id`, `agent.thread_id`, `agent.version`, `agent.project_name`) — both connect-time and back-fill sources covered — `ConnectActivity_WithAgentEndpoint_HasAgentAttributes`, `EnrichRecvSessionEvent_SetsAgentIdAndThreadIdOnConnectSpan`
- [x] Structured content events on done events — `ExtractDoneEventContent_*` suite
- [x] `gen_ai.provider.name` **missing from metric tag dimensions** — `BuildCommonMetricTags()` only had `gen_ai.system`; design doc line 310 requires it on both histograms — **fixed**: added `{ Keys.GenAiProviderName, Keys.GenAiProviderValue }` to `BuildCommonMetricTags()` TagList
- [x] `gen_ai.voice.message_size` — implemented in `VoiceLiveSession.cs` (send, line 204) and `VoiceLiveSession.Updates.cs` (recv, line 162); no prior unit test — **added**: `SendCommandAsync_SessionUpdate_RecordsMessageSize`, `GetUpdatesAsync_SessionCreated_RecordsMessageSize`
- [x] MCP approval attributes (`gen_ai.voice.mcp.approval_request_id`, `gen_ai.voice.mcp.approve`) — implemented in `ExtractRecvIds`/`ExtractSendIds`; no prior unit test — **added**: `ExtractRecvIds_OutputItemAddedWithApproval_SetsApprovalAttributes`, `ExtractSendIds_ConversationItemCreate_SetsApprovalAttributes`
- [x] `gen_ai.voice.previous_item_id` on recv `conversation.item.created` — implemented generically in `ExtractRecvIds`; no dedicated test — **added**: `ExtractRecvIds_ConversationItemCreated_SetsPreviousItemIdAndItemId`

---

| Wire value | C# constant | Notes |
|---|---|---|
| `gen_ai.conversation.id` | `GenAiConversationId` | back-filled from response.done/response.created `response.conversation_id`, or `AgentSessionConfig` at connect |
| `gen_ai.voice.session_id` | `GenAiVoiceSessionId` | back-filled from session.created `session.id` |
| `gen_ai.response.id` | `GenAiResponseId` | from `response.id` or top-level `response_id` |
| `gen_ai.voice.call_id` | `GenAiVoiceCallId` | MCP tool call ID |
| `gen_ai.voice.item_id` | `GenAiVoiceItemId` | item-bearing events only |
| `gen_ai.voice.previous_item_id` | `GenAiVoicePreviousItemId` | ordering hint |
| `gen_ai.voice.output_index` | `GenAiVoiceOutputIndex` | position in response output array |
| `gen_ai.agent.name` | `GenAiAgentName` | from `AgentSessionConfig.agent_name` at connect; **or** from `session.agent.name` in recv session.created/updated (fallback if URL param not set); set on connect span (agent sessions only) |
| `gen_ai.agent.version` | `GenAiAgentVersion` | from `AgentSessionConfig.agent_version` at connect; conditional (if present; agent sessions only) |
| `gen_ai.agent.project_name` | `GenAiAgentProjectName` | from `AgentSessionConfig.project_name` at connect; conditional (if present; agent sessions only) |
| `gen_ai.agent.id` | `GenAiAgentId` | back-filled from `session.agent.agent_id` in recv session.created/updated; set on connect span (agent sessions only) |
| `gen_ai.agent.thread_id` | `GenAiAgentThreadId` | back-filled from `session.agent.thread_id` in recv session.created/updated; set on connect span (agent sessions only) |
| `gen_ai.system_instructions` | `GenAiSystemMessage` | ⚠ wire value uses UNDERSCORE; set on connect span |
| `gen_ai.system.instructions` | `SystemInstructionEventName` | ⚠ SPAN EVENT name uses DOTS — different from the attribute above; event attrs: `gen_ai.provider.name` + `gen_ai.event.content` (NOT `gen_ai.system`) |
| `gen_ai.request.max_output_tokens` | `GenAiRequestMaxOutputTokens` | from `session.max_response_output_tokens` in session.update; conditional (if field present); set on connect span |
| `gen_ai.event.content` | `GenAiEventContent` | span event attribute |
| `gen_ai.voice.turn_count` | `GenAiVoiceTurnCount` | flushed to connect span on close |
| `gen_ai.voice.first_token_latency_ms` | `GenAiVoiceFirstTokenLatencyMs` | on BOTH: recv span (first `response.audio.delta`) AND connect span (flushed at close); Python emits on both |
| `gen_ai.voice.input_audio_format` | `GenAiVoiceInputAudioFormat` | from session.update or session.created; set on connect span |
| `gen_ai.voice.output_audio_format` | `GenAiVoiceOutputAudioFormat` | from session.update or session.created; set on connect span |
| `gen_ai.voice.input_sample_rate` | `GenAiVoiceInputSampleRate` | from session.update `input_audio_sample_rate` **or** recv session.created/updated; set on connect span |
| `gen_ai.voice.output_sample_rate` | `GenAiVoiceOutputSampleRate` | from session.update `output_audio_sample_rate` **or** recv session.created/updated; set on connect span |
| `gen_ai.voice.mcp.call_count` | `GenAiVoiceMcpCallCount` | ⚠ dot separator (not underscore) |
| `gen_ai.voice.mcp.list_tools_count` | `GenAiVoiceMcpListToolsCount` | ⚠ dot separator |
| `gen_ai.voice.mcp.server_label` | `GenAiVoiceMcpServerLabel` | ⚠ dot separator |
| `gen_ai.voice.mcp.tool_name` | `GenAiVoiceMcpToolName` | ⚠ dot separator |
| `gen_ai.voice.mcp.approval_request_id` | `GenAiVoiceMcpApprovalRequestId` | ⚠ dot separator |
| `gen_ai.voice.mcp.approve` | `GenAiVoiceMcpApprove` | ⚠ dot separator |
| `gen_ai.voice.rate_limits.updated` | *(event name)* | ⚠ span EVENT name (not attribute); full name with `.updated` suffix |
| `gen_ai.token.type` | `GenAiTokenType` | metric dimension only (not a span attribute); value "input" or "output"; used with `gen_ai.client.token.usage` histogram |

**Item-bearing events** (only these extract nested `item.*` in `ExtractRecvIds`):
- `conversation.item.created`
- `conversation.item.retrieved`
- `response.output_item.added`
- `response.output_item.done`

**Delta events** (skip span, check first-token latency only):
- `response.text.delta`
- `response.audio_transcript.delta`

---

## 7. Key Files

| File | Role |
|---|---|
| `src/Telemetry/VoiceLiveTracer.cs` | All span creation and enrichment |
| `src/Telemetry/VoiceLiveTelemetryAttributeKeys.cs` | All attribute string constants |
| `src/Customizations/VoiceLiveSession.cs` | Send path — dispatches to tracer |
| `src/Customizations/VoiceLiveSession.Updates.cs` | Recv path — `InstrumentRecvEvent` |
| `src/Customizations/VoiceLiveSession.Protocol.cs` | Connect/close span lifecycle |
| `samples/TelemetryValidation/csharp_traces.json` | Actual C# trace output (update after each phase) |

---

## 8. Intentional C# / Python Behavior Differences

These are deliberate SDK-level decisions in C#, **not parity gaps to fix**.

### No spans for audio append events (`input_audio_buffer.append` / `input_audio_turn.append`)

**Python** creates a `send input_audio_buffer.append` span for every audio chunk it sends.
**C#** explicitly returns early in `SendCommandAsync` (`VoiceLiveSession.cs`):
```csharp
if (isAudioAppend)
{
    _tracer?.OnSendAudioData(data.ToMemory().Length);
    await SendCommandAsync(data, cancellationToken).ConfigureAwait(false);
    return;  // no span created
}
```
**Why**: Audio streams at PCM16 / 16 kHz produce one chunk every ~40 ms → ~25 messages/second. A 30-second session = ~750 audio append spans, dwarfing every other span and bloating trace storage/export. C# counters the byte volume via `OnSendAudioData` (aggregated onto `gen_ai.voice.audio_bytes_sent` on the connect span) instead of per-message spans. Python simply hasn't made this optimization yet — the span count difference is noise, not missing behavior.

### No spans for high-frequency delta events

**Python** creates anonymous `recv` spans for every `response.audio_transcript.delta` and `response.text.delta`.
**C#** explicitly skips them in `InstrumentRecvEvent` (`VoiceLiveSession.Updates.cs`):
```csharp
if (eventType == "response.text.delta" || eventType == "response.audio_transcript.delta")
    return;
```
**Why**: Same reasoning — delta events arrive for every token of streamed text/transcript, typically dozens per response. They carry no unique IDs or counters, just incremental text fragments. The `*.done` events carry the complete content and are the right granularity for tracing. Note: `response.audio.delta` is also high-frequency but IS instrumented for first-token latency tracking — it returns immediately after recording the latency on the first occurrence.

### Span export order

Due to the full-duplex WebSocket, send and recv spans are interleaved in export order. This is expected and identical between Python and C# — it reflects real concurrency, not a bug.

### Error span status

Python sets `SpanStatus.ERROR` via OTel's `span.set_status(StatusCode.ERROR)`. C# records the exception on the Activity via `VoiceLiveTracer.RecordError(activity, ex)` which sets `Activity.Status = ActivityStatusCode.Error`. Both translate identically on the wire; the difference is API style (OTel vs BCL `System.Diagnostics`).

### `gen_ai.voice.first_token_latency_ms` on recv span

Python does emit this on the first `response.audio.delta` recv span AND the connect span. C# currently emits it only on the recv span. The gap is the **connect span flush** — the recv span emission is correct and intentional (to show latency close to the event that caused it).

---

## 9. Session Scenario Differences: Function Call vs Agent v2

These two session types produce fundamentally different trace shapes. The parity gaps apply to both, but certain spans and attributes are scenario-specific.

### Function Call session

The client implements tool functions. The service triggers them via function_call events; the client returns results.

**Spans unique to this scenario:**
- `recv response.function_call_arguments.done` — has `gen_ai.voice.call_id`; structured content (Ph4) = `{"name": "fn_name", "arguments": {...}}`
- `send conversation.item.create` with `type: "function_call_output"` — has `gen_ai.voice.call_id` linking back to the function call

**Connect span:** NO `gen_ai.agent.*` attributes — `session.agent` is absent, so none of the 5 agent attrs are ever set.

**Current C# status:** `gen_ai.voice.call_id` is extracted on both send/recv (Ph1 ✅). Structured content for `response.function_call_arguments.done` is a Ph4 gap (raw JSON today).

---

### Agent v2 session

An Azure AI Agent handles tool execution server-side via MCP. The client does not implement tool logic.

**Spans unique to this scenario:**
- `recv mcp_list_tools.completed` / `mcp_list_tools.failed` — has `gen_ai.voice.mcp.server_label`, `gen_ai.voice.mcp.list_tools_count`
- `recv response.mcp_call.completed` / `response.mcp_call.failed` — has `gen_ai.voice.mcp.tool_name`, `gen_ai.voice.mcp.call_count`

**Connect span:** all 5 `gen_ai.agent.*` attrs present (Ph2 ✅):
- At connect: `gen_ai.agent.name`, `gen_ai.agent.version`, `gen_ai.agent.project_name` (from `AgentSessionConfig`)
- Back-filled on `session.created` recv: `gen_ai.agent.id`, `gen_ai.agent.thread_id` (from `session.agent.agent_id` / `session.agent.thread_id`)

**Current C# status:** MCP recv spans are in the `InstrumentRecvEvent` switch and enriched (Ph1 ✅). All agent connect-span attrs implemented (Ph2 ✅).

---

### Gap table additions for function call scenario

| Span | Attribute / Behavior | Status | Phase |
|---|---|---|---|
| recv response.function_call_arguments.done | structured content `{"name": .., "arguments": ..}` | ❌ Raw JSON only | 4 |

*(MCP gaps already covered in the main gap table above.)*

---

## 10. Pre-Phase-2 Checklist

Before writing Phase 2 code, confirm the following:

- [x] **Agent attribute sources (all 5 attrs, two distinct sources)**:
  - **At connect time** from `AgentSessionConfig` (C# class): `gen_ai.agent.name` (field: `agent_name`), `gen_ai.agent.version` (field: `agent_version`), `gen_ai.agent.project_name` (field: `project_name`). Verify C# field names match.
  - **Back-filled from recv** `session.created`/`session.updated` via `session.agent.*` JSON path: `gen_ai.agent.id` (field: `session.agent.agent_id`), `gen_ai.agent.thread_id` (field: `session.agent.thread_id`). Verify these are the correct wire JSON field names in the C# model (check `RealtimeSessionAgent` or equivalent model class).
  - Both sources set attrs on `_connectActivity`, NOT on the recv span.
- [x] **`gen_ai.request.model` vs `gen_ai.response.model`**: Decide whether to change recv session.created to emit `gen_ai.request.model` (Python parity) or keep `gen_ai.response.model` (reflects that the model is the server's response). The recv event returns the actual model used — `gen_ai.request.model` may be semantically wrong here; flag for review.
- [x] **Temperature / tools conditionality**: Confirm the current `EnrichSendSessionUpdate` implementation checks for field presence before setting connect span attrs, or add a guard. Don't set `gen_ai.request.temperature = 0` when the session.update didn't include temperature.
- [x] **`VoiceLiveTelemetryAttributeKeys.cs` new constants**: `GenAiAgentName`, `GenAiAgentProjectName` may not exist yet. Check and add before using them in `VoiceLiveTracer.cs`.
- [x] **`_connectActivity` thread safety**: `EnrichSendSessionUpdate` runs on the send path; `EnrichRecvSessionEvent` runs on the recv path — both access `_connectActivity` concurrently. Verify current code uses `SetTag` (safe on Activity) or add a lock if needed.
- [x] **Content recording flag access in tracer**: `EmitSystemInstructionsEvent` needs to check `_enableContentRecording`. Confirm `VoiceLiveTracer` already has this field (it receives `enableContentRecording` in constructor from `VoiceLiveSession.cs` line 105).
- [x] **Audio format from session.created vs session.update**: The send path (`EnrichSendSessionUpdate`) can set formats from session.update. The recv path (`EnrichRecvSessionEvent`) handles session.created. Ensure the recv path copies to `_connectActivity` but does NOT set on the recv span itself. The current `EnrichRecvSessionEvent` likely sets them on the recv Activity — that needs to change.
