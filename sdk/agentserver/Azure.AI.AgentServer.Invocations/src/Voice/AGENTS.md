# Voice submodule instructions

> Read [sdk/agentserver/AGENTS.md](../../../AGENTS.md) first. Its protocol
> fidelity, test-first, async, thread-safety, documentation, and minimal-API
> rules apply here.

## Scope

This directory implements the preview `Azure.AI.AgentServer.Invocations.Voice`
submodule in the **Azure.AI.AgentServer.Invocations** NuGet package. It is not a
separate package. It implements Voice Live Bridge Protocol 1.0 over the existing
`invocations_ws` transport, so `VoiceHandler` derives from
`InvocationWebSocketHandler`. Voice Live owns audio, STT, TTS, VAD, turn-taking,
and barge-in; this submodule never handles media.

## Authoritative specifications

| Document | Scope |
|---|---|
| `foundrysdk_specs/.../voice_live_bridge/spec.md` | Wire contract: every message type, field, and close code |
| `voice-agent-orchestrator/docs/hosted_text_agent_and_voice_live_bridge.md` | Bridge lifecycle and cleanup |
| Python reference | The completed Python Voice Live Bridge implementation |

The wire specification wins over code. Deviations are bugs.

## Design decisions

- **Invocations submodule, not another package.** Public APIs use the
  `Azure.AI.AgentServer.Invocations.Voice` namespace and ship in
  `Azure.AI.AgentServer.Invocations`.
- **Handler, not host subclass.** `VoiceHandler : InvocationWebSocketHandler`
  has overridable turn callbacks and registers through `AddVoice<T>()` or
  `VoiceServer.Run<T>()`.
- **Reuse the transport.** WebSocket accept, handler-selected close-code
  preservation, session ID resolution, W3C trace-context propagation, and
  keep-alive Ping remain owned by Invocations.
- **Outbound wire models are internal.** Customer code cannot construct frames;
  `VoiceResponse` and `VoiceSession` own framing, ordering, and terminals.
- **Content-free telemetry.** Never log transcripts, generated text, or caller
  metadata.
- **Exactly three lifecycle owners.** Every application frame goes through
  `VoiceSendTransaction`; every response/connection terminal goes through
  `VoiceTerminationCoordinator`; reactive and accepted proactive turns share
  the single `VoiceTurnLease` slot. Do not add parallel send locks, terminal-ID
  registries, active-response fields, or proactive Activity maps.
- **Response operation gates are not wire owners.** `VoiceResponse` may
  serialize its own high-level API calls, but preparation, wire ordering,
  state reservation, and post-send commit remain connection transaction work.

## Implementation status

The current implementation contains the hosting entry points, immutable inbound
models, strict codec, exact-payload dedupe, serialized send path, activation
handshake, ordered callback coordinator, single- and multi-item output,
decline/cancel/barge-in/timeout arbitration, proactive admission, handoff, and
bounded connection cleanup. A host-scoped retained-work governor provides
aggregate admission for all Voice connections created by one AgentServer host.
Content-free `agentserver.connection` / `hosted_agent.turn` activities and
activation, callback, terminal, protocol-violation, connection, and close-code
metrics use only approved identifiers or low-cardinality classifications.

Bridge interoperability, external route conformance, API review, and the
cross-service observability gates remain release validation work. The SDK does
not redial or replay; each reattached WebSocket creates a fresh runtime and
receives `session.start{reconnect:true}` from the bridge.

## Testing

- Use deterministic synchronization; do not use blind delays.
- Add end-to-end tests over the full `/invocations_ws` pipeline for every
  protocol behavior. Unit tests alone are insufficient.
- Model WebSocket tests on `tests/WebSocketEndpointTests.cs`.
- Share codec vectors with the Python implementation for parity.

## API snapshot

Regenerate the existing `Azure.AI.AgentServer.Invocations` API snapshots after
every public Voice API change. Voice does not have a separate API snapshot or
release artifact.

Voice API changes ship on the Invocations package release cadence.
