using Azure.AI.AgentServer.Contracts.Generated.OpenAI;
using Azure.AI.AgentServer.Contracts.Generated.Responses;

namespace Azure.AI.AgentServer.Responses.Invocation;

public interface IAgentInvocation
{
    Task<Contracts.Generated.Responses.Response> InvokeAsync(CreateResponseRequest request,
        AgentInvocationContext context,
        CancellationToken cancellationToken = default);

    IAsyncEnumerable<ResponseStreamEvent> InvokeStreamAsync(CreateResponseRequest request,
        AgentInvocationContext context,
        CancellationToken cancellationToken = default);
}
