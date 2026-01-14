// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.AI.AgentServer.Contracts.Generated.Agents;
using Azure.AI.AgentServer.Contracts.Generated.Conversations;
using Azure.AI.AgentServer.Contracts.Generated.Responses;
using Azure.AI.AgentServer.Core.Common.Id;
using Azure.AI.AgentServer.Core.Tools.Models;

namespace Azure.AI.AgentServer.Core.AgentRun;

/// <summary>
/// Provides rich context information for agent runs, including request data, user information,
/// tool definitions, and ID generation capabilities.
/// </summary>
public class AgentRunContext
{
    private static readonly AsyncLocal<AgentRunContext?> _current = new();

    /// <summary>
    /// Initializes a new instance of the <see cref="AgentRunContext"/> class.
    /// </summary>
    /// <param name="request">The create response request.</param>
    /// <param name="rawPayload">The raw JSON payload as a dictionary.</param>
    /// <param name="userInfo">Optional user information.</param>
    /// <param name="agentTools">Optional list of agent tool definitions.</param>
    public AgentRunContext(
        CreateResponseRequest request,
        IReadOnlyDictionary<string, object?>? rawPayload = null,
        UserInfo? userInfo = null,
        IReadOnlyList<object>? agentTools = null)
    {
        Request = request ?? throw new ArgumentNullException(nameof(request));
        RawPayload = rawPayload ?? new Dictionary<string, object?>();
        UserInfo = userInfo;
        AgentTools = agentTools ?? Array.Empty<object>();

        // Create ID generator from request
        var foundryIdGenerator = FoundryIdGenerator.From(request);
        IdGenerator = foundryIdGenerator;
        ResponseId = foundryIdGenerator.ResponseId;
        ConversationId = foundryIdGenerator.ConversationId;
        Stream = request.Stream ?? false;
    }

    /// <summary>
    /// Gets the current agent run context from the async local storage.
    /// </summary>
    public static AgentRunContext? Current => _current.Value;

    /// <summary>
    /// Sets up the agent run context in async local storage.
    /// Returns a scope that restores the previous context when disposed.
    /// </summary>
    /// <param name="context">The context to set.</param>
    /// <returns>An IAsyncDisposable that restores the previous context when disposed.</returns>
    internal static IAsyncDisposable Setup(AgentRunContext context)
    {
        var previous = _current.Value;
        _current.Value = context;
        return new ScopedContext(previous);
    }

    /// <summary>
    /// Gets the create response request.
    /// </summary>
    public CreateResponseRequest Request { get; }

    /// <summary>
    /// Gets the raw JSON payload as a dictionary.
    /// Useful for accessing properties not available in the typed request.
    /// </summary>
    public IReadOnlyDictionary<string, object?> RawPayload { get; }

    /// <summary>
    /// Gets the ID generator for creating unique identifiers.
    /// </summary>
    public IIdGenerator IdGenerator { get; }

    /// <summary>
    /// Gets the response ID for this agent run.
    /// </summary>
    public string ResponseId { get; }

    /// <summary>
    /// Gets the conversation ID for this agent run.
    /// </summary>
    public string ConversationId { get; }

    /// <summary>
    /// Gets whether this is a streaming request.
    /// </summary>
    public bool Stream { get; }

    /// <summary>
    /// Gets the user information for this request, if available.
    /// This is populated from HTTP headers by the UserInfoContextMiddleware.
    /// </summary>
    public UserInfo? UserInfo { get; }

    /// <summary>
    /// Gets the list of agent tool definitions.
    /// These can be FoundryTool instances or dictionary-based facades.
    /// </summary>
    public IReadOnlyList<object> AgentTools { get; }

    /// <summary>
    /// Gets the agent reference from the request, if available.
    /// </summary>
    /// <returns>The agent reference, or null if not present in the request.</returns>
    public AgentReference? GetAgentIdObject()
    {
        return Request.Agent;
    }

    /// <summary>
    /// Gets the conversation object from the request, if available.
    /// </summary>
    /// <returns>The conversation object, or null if not present in the request.</returns>
    public ResponseConversation1? GetConversationObject()
    {
        if (Request.Conversation == null)
        {
            return null;
        }

        try
        {
            var jsonString = Request.Conversation.ToString();
            return JsonSerializer.Deserialize<ResponseConversation1>(jsonString);
        }
        catch
        {
            return null;
        }
    }

    /// <summary>
    /// Gets the list of tools from the request.
    /// </summary>
    /// <returns>The list of tools, or an empty list if no tools are present.</returns>
    public IReadOnlyList<object> GetTools()
    {
        if (Request.Tools == null || Request.Tools.Count == 0)
        {
            return AgentTools;
        }

        return Request.Tools.Cast<object>().ToList();
    }

    private sealed class ScopedContext : IAsyncDisposable
    {
        private readonly AgentRunContext? _previous;

        public ScopedContext(AgentRunContext? previous)
        {
            _previous = previous;
        }

        public ValueTask DisposeAsync()
        {
            _current.Value = _previous;
            return ValueTask.CompletedTask;
        }
    }
}
