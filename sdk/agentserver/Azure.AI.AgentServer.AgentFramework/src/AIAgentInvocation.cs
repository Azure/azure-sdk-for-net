// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;
using System.Runtime.CompilerServices;
using Azure.AI.AgentServer.AgentFramework.Converters;
using Azure.AI.AgentServer.Contracts.Generated.OpenAI;
using Azure.AI.AgentServer.Contracts.Generated.Responses;
using Azure.AI.AgentServer.Core.Telemetry;
using Azure.AI.AgentServer.Responses.Invocation;
using Azure.AI.AgentServer.Responses.Invocation.Stream;
using Microsoft.Agents.AI;
using Microsoft.Extensions.AI;

namespace Azure.AI.AgentServer.AgentFramework;

/// <summary>
/// Provides an implementation of agent invocation using the Microsoft Agents AI framework.
/// </summary>
/// <param name="agent">The AI agent to invoke.</param>
/// <param name="aiFunctionProvider">Optional tool provider that will be queried at invocation time.</param>
public class AIAgentInvocation(
    AIAgent agent,
    IAIFunctionProvider? aiFunctionProvider = null) : AgentInvocationBase
{
    private readonly AIAgent _agent = agent ?? throw new ArgumentNullException(nameof(agent));
    private readonly IAIFunctionProvider? _aiFunctionProvider = aiFunctionProvider;

    /// <summary>
    /// Invokes the agent asynchronously and returns a complete response.
    /// </summary>
    /// <param name="request">The create response request.</param>
    /// <param name="context">The agent invocation context.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The response from the agent.</returns>
    public override async Task<Contracts.Generated.Responses.Response> InvokeAsync(CreateResponseRequest request,
        AgentInvocationContext context,
        CancellationToken cancellationToken = default)
    {
        Activity.Current?.SetServiceNamespace("agentframework");

        var messages = request.GetInputMessages();
        var runOptions = await GetRunOptionsAsync(cancellationToken).ConfigureAwait(false);
        var response = await _agent.RunAsync(
            messages,
            options: runOptions,
            cancellationToken: cancellationToken).ConfigureAwait(false);
        return response.ToResponse(request, context);
    }

    /// <summary>
    /// Executes the agent invocation with streaming support.
    /// </summary>
    /// <param name="request">The create response request.</param>
    /// <param name="context">The agent invocation context.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>A stream event generator for the response.</returns>
    protected override INestedStreamEventGenerator<Contracts.Generated.Responses.Response> DoInvokeStreamAsync(
        CreateResponseRequest request,
        AgentInvocationContext context,
        CancellationToken cancellationToken)
    {
        Activity.Current?.SetServiceNamespace("agentframework");

        var messages = request.GetInputMessages();
        var updates = RunStreamingWithLatestTools(messages, cancellationToken);
        // TODO refine to multicast event
        IList<Action<ResponseUsage>> usageUpdaters = [];

        var seq = ISequenceNumber.Default;
        return new NestedResponseGenerator()
        {
            Context = context,
            Request = request,
            Seq = seq,
            CancellationToken = cancellationToken,
            SubscribeUsageUpdate = usageUpdaters.Add,
            OutputGenerator = new ItemResourceGenerator()
            {
                Context = context,
                NotifyOnUsageUpdate = usage =>
                {
                    foreach (var updater in usageUpdaters)
                    {
                        updater(usage);
                    }
                },
                Updates = updates,
                Seq = seq,
                CancellationToken = cancellationToken,
            }
        };
    }

    private async Task<AgentRunOptions?> GetRunOptionsAsync(CancellationToken cancellationToken)
    {
        IReadOnlyList<AIFunction>? aiFunctions = null;
        if (_aiFunctionProvider is not null)
        {
            aiFunctions = await _aiFunctionProvider.ListToolsAsync(cancellationToken).ConfigureAwait(false);
        }

        return BuildRunOptions(aiFunctions);
    }

    private async IAsyncEnumerable<AgentRunResponseUpdate> RunStreamingWithLatestTools(
        IEnumerable<ChatMessage> messages,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var runOptions = await GetRunOptionsAsync(cancellationToken).ConfigureAwait(false);
        var updates = _agent.RunStreamingAsync(messages, options: runOptions, cancellationToken: cancellationToken);
        await foreach (var update in updates.WithCancellation(cancellationToken).ConfigureAwait(false))
        {
            yield return update;
        }
    }

    private static AgentRunOptions? BuildRunOptions(IReadOnlyList<AIFunction>? aiFunctions)
    {
        if (aiFunctions is { Count: > 0 })
        {
            // Surface tool definitions to the agent so the model can request them.
            var chatOptions = new ChatOptions
            {
                Tools = aiFunctions.Cast<AITool>().ToList()
            };
            return new ChatClientAgentRunOptions(chatOptions);
        }

        return null;
    }
}
