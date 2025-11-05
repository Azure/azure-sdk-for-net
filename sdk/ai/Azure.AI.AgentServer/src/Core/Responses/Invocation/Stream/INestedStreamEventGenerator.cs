using Azure.AI.AgentServer.Contracts.Generated.OpenAI;

namespace Azure.AI.AgentServer.Responses.Invocation.Stream;

public interface INestedStreamEventGenerator<TAggregate> where TAggregate : class
{
    IAsyncEnumerable<NestedEventsGroup<TAggregate>> Generate();
}

public class NestedEventsGroup<T> where T : class
{
    public required Func<T> CreateAggregate { get; init; }

    public required IAsyncEnumerable<ResponseStreamEvent> Events { get; init; }
}
