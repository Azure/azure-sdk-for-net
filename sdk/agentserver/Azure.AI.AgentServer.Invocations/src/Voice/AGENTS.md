# Voice relay maintenance rules

The `Voice` namespace is a thin typed event relay for the Voice Live Bridge Protocol. Read these rules before changing files in this directory.

## Authority

- The authoritative contract is `/home/wujin/git/foundrysdk_specs/specs/agents/hosted_agents/voice_live_bridge/spec.md`.
- Protocol fidelity takes precedence over convenience or symmetry with older implementations.
- The selected Public Preview profile is exact `1.0`.

## Ownership boundary

The Voice layer may only:

- assemble one UTF-8 text message and decode it into one immutable inbound event;
- dispatch that event to its typed callback;
- encode one customer-created outbound message and write one text frame;
- serialize data and close writes on one connection;
- reject malformed individual frames using context-free validation; and
- notify the application once, synchronously, before transport close so it can signal cancellation.

The Voice layer must not own:

- pending input batches or response/item lifecycle state;
- message-ID deduplication or payload ledgers;
- response, proactive-admission, or cancellation futures;
- customer callback tasks, model/tool tasks, or task joining;
- response/session timers;
- history reconciliation or mutation state;
- reconnect dialing, replay, or durable restoration; or
- automatic readiness, response creation, completion, cancellation, or error frames.

The Bridge validates cross-message semantics. The application owns IDs, every outbound event, application tasks, cancellation, history, and reconnect restoration.

## Selected 1.0 surface

Inbound events:

- `session.start`
- `user.message`
- `user.no_input`
- `user.speech_started`
- `barge_in`
- `response.accepted`
- `response.dropped`
- `response.cancelled`
- `response.timeout`
- `session.end`

Outbound messages:

- `session.ready`
- `session.rejected`
- `response.created`
- `response.none`
- `response.output_text.delta`
- `response.output_text.done`
- `response.done`
- `response.cancel`
- `end_call`
- `error`

Do not add DTMF, handoff, history mutation, or `input_image` to exact 1.0 unless the authoritative selected profile changes.

## Transport invariants

- Application sends and the final close frame share one write gate.
- Mark the session unwritable before invoking `OnConnectionTerminating`.
- Invoke `OnConnectionTerminating` exactly once and before awaited close I/O.
- Cleanup exceptions are diagnostics only and cannot replace the selected close outcome.
- Peer and local protocol close codes must reach both the wire and structured telemetry.
- Close I/O has an absolute deadline; abort and observe late faults after expiry.
- Logger and scope callbacks are observational and cannot suppress close.
- Do not perform network I/O while holding unrelated state locks.

## Validation

From the repository root:

```bash
dotnet test sdk/agentserver/Azure.AI.AgentServer.Invocations/tests/Azure.AI.AgentServer.Invocations.Tests.csproj --framework net8.0 --filter 'FullyQualifiedName~.Voice.|FullyQualifiedName~WebSocketEndpointTests'
```

Before committing, follow `sdk/agentserver/AGENTS.md`: run the full AgentServer tests, export API listings, update snippets, build with `BuildSnippets=true`, then format last.