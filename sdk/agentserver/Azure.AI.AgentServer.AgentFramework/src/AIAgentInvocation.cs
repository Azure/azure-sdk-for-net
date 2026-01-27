// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;
using Azure.AI.AgentServer.AgentFramework.Converters;
using Azure.AI.AgentServer.AgentFramework.Persistence;
using Azure.AI.AgentServer.Contracts.Generated.OpenAI;
using Azure.AI.AgentServer.Core.Telemetry;
using Azure.AI.AgentServer.Responses.Invocation;
using Azure.AI.AgentServer.Responses.Invocation.Stream;
using Microsoft.Agents.AI;

namespace Azure.AI.AgentServer.AgentFramework;

/// <summary>
/// Provides an implementation of agent invocation using the Microsoft Agents AI framework.
/// </summary>
/// <param name="agent">The AI agent to invoke.</param>
/// <param name="threadRepository">Optional repository for managing agent threads.</param>
public class AIAgentInvocation(
    AIAgent agent,
    IAgentThreadRepository? threadRepository = null) : AgentInvocationBase
{
    /// <summary>
    /// Invokes the agent asynchronously and returns a complete response.
    /// </summary>
    /// <param name="context">The agent run context.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The response from the agent.</returns>
    public override async Task<Contracts.Generated.Responses.Response> InvokeAsync(
        AgentRunContext context,
        CancellationToken cancellationToken = default)
    {
        Activity.Current?.SetServiceNamespace("agentframework");

        var request = context.Request;
        var messages = request.GetInputMessages();
        AgentThread? thread = null;
        if (threadRepository != null)
        {
            thread = await threadRepository.Get(context.ConversationId).ConfigureAwait(false);
        }
        var response = await agent.RunAsync(
            messages, thread: thread,
            cancellationToken: cancellationToken).ConfigureAwait(false);
        if (threadRepository != null && thread != null)
        {
            await threadRepository.Set(context.ConversationId, thread).ConfigureAwait(false);
        }
        return response.ToResponse(request, context);
    }

    /// <summary>
    /// Executes the agent invocation with streaming support.
    /// </summary>
    /// <param name="context">The agent run context.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>A stream event generator for the response.</returns>
    protected override INestedStreamEventGenerator<Contracts.Generated.Responses.Response> DoInvokeStreamAsync(
        AgentRunContext context,
        CancellationToken cancellationToken)
    {
        Activity.Current?.SetServiceNamespace("agentframework");

        var request = context.Request;
        var messages = request.GetInputMessages();
        var updates = agent.RunStreamingAsync(messages, cancellationToken: cancellationToken);
        // TODO refine to multicast event
        IList<Action<ResponseUsage>> usageUpdaters = [];

        var seq = ISequenceNumber.Default;
        return new NestedResponseGenerator()
        {
            Context = context,
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
}
