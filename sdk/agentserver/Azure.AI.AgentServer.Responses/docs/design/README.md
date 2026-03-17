# .NET SDK Design Documentation

> .NET-specific implementation details for SDK contributors and maintainers.
> For language-agnostic SDK behavioural rules, see [SDK Behavioural Specification](../sdk-behaviour-spec.md).

---

| Document | Description |
|----------|-------------|
| [Orchestration](orchestration.md) | Request pipeline, event processing loop, handler validation, snapshot serialization, terminal event authority |
| [Error Handling](error-handling.md) | ExceptionFilter, ApiErrorFactory, OCE classification, validation exception classes |
| [Provider Contract](provider-contract.md) | IResponsesProvider interface, InMemoryResponsesProvider internals, persistence timing |
