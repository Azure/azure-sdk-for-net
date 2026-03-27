# .NET Library Design Documentation

> .NET-specific implementation details for library contributors and maintainers.
> For language-agnostic library behavioural rules, see [Library Behavioural Specification](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/library-behaviour-spec.md).

---

| Document | Description |
|----------|-------------|
| [Orchestration](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/design/orchestration.md) | Request pipeline, event processing loop, handler validation, snapshot serialization, terminal event authority |
| [Error Handling](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/design/error-handling.md) | ExceptionFilter, ApiErrorFactory, OCE classification, validation exception classes |
| [Provider Contract](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/design/provider-contract.md) | ResponsesProvider interface, InMemoryResponsesProvider internals, persistence timing |
