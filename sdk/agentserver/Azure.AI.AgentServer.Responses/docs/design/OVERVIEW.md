# .NET SDK Design Documentation

> .NET-specific implementation details for SDK contributors and maintainers.
> For language-agnostic SDK behavioural rules, see [SDK Behavioural Specification](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/sdk-behaviour-spec.md).

---

| Document | Description |
|----------|-------------|
| [Orchestration](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/design/orchestration.md) | Request pipeline, event processing loop, handler validation, snapshot serialization, terminal event authority |
| [Error Handling](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/design/error-handling.md) | ExceptionFilter, ApiErrorFactory, OCE classification, validation exception classes |
| [Provider Contract](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/design/provider-contract.md) | IResponsesProvider interface, InMemoryResponsesProvider internals, persistence timing |
