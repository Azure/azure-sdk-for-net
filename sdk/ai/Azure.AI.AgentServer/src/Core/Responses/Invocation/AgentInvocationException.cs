namespace Azure.AI.AgentServer.Responses.Invocation;

public class AgentInvocationException(Contracts.Generated.OpenAI.ResponseError error) : Exception
{
    public Contracts.Generated.OpenAI.ResponseError Error { get; } = error;
}
