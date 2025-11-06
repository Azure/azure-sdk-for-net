using Azure.AI.AgentServer.Core.Common.Id;

namespace Azure.AI.AgentServer.Responses.Invocation;

/// <summary>
/// Provides context information for agent invocations including ID generation and conversation tracking.
/// </summary>
/// <param name="idGenerator">The ID generator for creating unique identifiers.</param>
/// <param name="responseId">The response ID for this invocation.</param>
/// <param name="conversationId">The conversation ID for this invocation.</param>
public class AgentInvocationContext(IIdGenerator idGenerator,
    string responseId,
    string conversationId)
{
    private static readonly AsyncLocal<AgentInvocationContext?> _current = new();

    /// <summary>
    /// Gets the current agent invocation context from the async local storage.
    /// </summary>
    public static AgentInvocationContext? Current => _current.Value;

    internal static IAsyncDisposable Setup(AgentInvocationContext context)
    {
        var previous = _current.Value;
        _current.Value = context;
        return new ScopedContext(previous);
    }

    /// <summary>
    /// Gets the ID generator for creating unique identifiers.
    /// </summary>
    public IIdGenerator IdGenerator { get; } = idGenerator;

    /// <summary>
    /// Gets the response ID for this invocation.
    /// </summary>
    public string ResponseId { get; } = responseId;

    /// <summary>
    /// Gets the conversation ID for this invocation.
    /// </summary>
    public string ConversationId { get; } = conversationId;

    private sealed class ScopedContext(AgentInvocationContext? previous) : IAsyncDisposable
    {
        public ValueTask DisposeAsync()
        {
            _current.Value = previous;
            return ValueTask.CompletedTask;
        }
    }
}
