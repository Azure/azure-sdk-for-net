# Azure AI Agent Server A2A

Follow the [parent instructions](../AGENTS.md).

This package is a Foundry hosting adapter, not an A2A protocol implementation.
Use native A2A models, handlers, storage contracts, JSON-RPC validation, errors,
card serialization, and SSE transport. Verify native preview APIs against the
restored assembly or the matching upstream release before changing integration.

Preserve these contracts:

- Canonical routes are `/a2a` and `/a2a/.well-known/agent-card.json`.
  Compatibility routes must share native behavior without rewriting the card.
- Preserve explicitly supplied native handlers and stores.
- Hosted storage must fail closed without identity or verified server-side user
  isolation. Never substitute in-memory storage after a hosted storage failure.
- Native operation spans retain Agent Card identity; hosted invocation spans use
  deployment identity. Keep spans open through response transmission.
- Response observation must remain bounded and forward bytes unchanged.
- Do not add another transport or advertise unsupported capabilities implicitly.

Endpoint changes require HTTP tests. Every sample handler needs both a compiled
snippet and an end-to-end test. Keep tests offline unless explicitly marked live.
