// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Runtime.CompilerServices;
using System.Reflection;
using Microsoft.Agents.AI;
using Microsoft.Extensions.AI;

namespace Azure.AI.AgentServer.AgentFramework;

internal sealed class FoundryToolAgent : DelegatingAIAgent, IAsyncDisposable
{
    private readonly ToolClient _toolClient;
    private readonly bool _innerAgentAddsDefaultTools;
    private static readonly PropertyInfo? s_innerAgentProperty =
        typeof(DelegatingAIAgent).GetProperty("InnerAgent", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

    public FoundryToolAgent(AIAgent innerAgent, ToolClient toolClient) : base(innerAgent)
    {
        _toolClient = toolClient ?? throw new ArgumentNullException(nameof(toolClient));
        _innerAgentAddsDefaultTools = IsOrWrapsChatClientAgent(innerAgent);
    }

    public override async Task<AgentRunResponse> RunAsync(
        IEnumerable<ChatMessage> messages,
        AgentThread? thread = null,
        AgentRunOptions? options = null,
        CancellationToken cancellationToken = default)
    {
        var runOptions = await CreateRunOptionsAsync(options, cancellationToken).ConfigureAwait(false);
        return await InnerAgent.RunAsync(messages, thread, runOptions, cancellationToken).ConfigureAwait(false);
    }

    public override async IAsyncEnumerable<AgentRunResponseUpdate> RunStreamingAsync(
        IEnumerable<ChatMessage> messages,
        AgentThread? thread = null,
        AgentRunOptions? options = null,
        [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        var runOptions = await CreateRunOptionsAsync(options, cancellationToken).ConfigureAwait(false);
        await foreach (var update in InnerAgent.RunStreamingAsync(messages, thread, runOptions, cancellationToken).ConfigureAwait(false))
        {
            yield return update;
        }
    }

    public async ValueTask DisposeAsync() => await _toolClient.DisposeAsync().ConfigureAwait(false);

    private async Task<AgentRunOptions?> CreateRunOptionsAsync(AgentRunOptions? options, CancellationToken cancellationToken)
    {
        var isChatClientAgent = IsOrWrapsChatClientAgent(InnerAgent);
        if (!isChatClientAgent)
        {
            return options;
        }

        var foundryTools = await _toolClient.ListToolsAsync(cancellationToken).ConfigureAwait(false);
        var requestTools = (options as ChatClientAgentRunOptions)?.ChatOptions?.Tools;
        var agentTools = InnerAgent.GetService<ChatOptions>()?.Tools;

        var mergedTools = MergeTools(requestTools, agentTools, foundryTools, _innerAgentAddsDefaultTools);
        if (mergedTools.Count == 0)
        {
            return options;
        }

        var runOptions = EnsureChatClientRunOptions(options);
        runOptions.ChatOptions ??= new ChatOptions();
        runOptions.ChatOptions.Tools = mergedTools;
        return runOptions;
    }

    private static IList<AITool> MergeTools(
        IList<AITool>? requestTools,
        IList<AITool>? agentTools,
        IReadOnlyList<AIFunction> foundryTools,
        bool innerAgentAddsDefaultTools)
    {
        List<AITool> merged = [];
        HashSet<string> names = new(StringComparer.OrdinalIgnoreCase);

        if (innerAgentAddsDefaultTools && agentTools is { Count: > 0 })
        {
            foreach (var tool in agentTools)
            {
                if (tool is not null)
                {
                    _ = names.Add(tool.Name);
                }
            }
        }

        AddUnique(merged, names, requestTools);
        AddUnique(merged, names, foundryTools);

        if (!innerAgentAddsDefaultTools)
        {
            AddUnique(merged, names, agentTools);
        }

        return merged;
    }

    private static void AddUnique(ICollection<AITool> target, ISet<string> names, IEnumerable<AITool>? tools)
    {
        if (tools is null)
        {
            return;
        }

        foreach (var tool in tools)
        {
            if (tool is null)
            {
                continue;
            }

            if (names.Add(tool.Name))
            {
                target.Add(tool);
            }
        }
    }

    private static ChatClientAgentRunOptions EnsureChatClientRunOptions(AgentRunOptions? options)
    {
        if (options is ChatClientAgentRunOptions chatOptions)
        {
            return chatOptions;
        }

        var runOptions = new ChatClientAgentRunOptions();
        if (options is not null)
        {
            runOptions.AllowBackgroundResponses = options.AllowBackgroundResponses;
            runOptions.ContinuationToken = options.ContinuationToken;
        }

        return runOptions;
    }

    private static bool IsOrWrapsChatClientAgent(AIAgent agent) => TryFindChatClientAgent(agent) is not null;

    private static ChatClientAgent? TryFindChatClientAgent(AIAgent agent)
    {
        var current = agent;
        while (current is not null)
        {
            if (current is ChatClientAgent chatClientAgent)
            {
                return chatClientAgent;
            }

            if (current is DelegatingAIAgent delegating)
            {
                current = GetInnerAgent(delegating);
                continue;
            }

            return null;
        }

        return null;
    }

    private static AIAgent? GetInnerAgent(DelegatingAIAgent agent)
    {
        return s_innerAgentProperty?.GetValue(agent) as AIAgent;
    }
}
