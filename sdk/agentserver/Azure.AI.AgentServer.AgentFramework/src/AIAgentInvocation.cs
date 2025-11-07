// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;
using Azure.AI.AgentServer.AgentFramework.Converters;
using Azure.AI.AgentServer.Contracts.Generated.OpenAI;
using Azure.AI.AgentServer.Contracts.Generated.Responses;
using Azure.AI.AgentServer.Core.Telemetry;
using Azure.AI.AgentServer.Responses.Invocation;
using Azure.AI.AgentServer.Responses.Invocation.Stream;
using Microsoft.Agents.AI;

namespace Azure.AI.AgentServer.AgentFramework;

/// <summary>
/// Provides an implementation of agent invocation using the Microsoft Agents AI framework.
/// </summary>
/// <param name="agent">The AI agent to invoke.</param>
public class AIAgentInvocation(AIAgent agent) : AgentInvocationBase
{
    /// <summary>
    /// Executes the agent invocation asynchronously.
    /// </summary>
    /// <param name="request">The create response request.</param>
    /// <param name="context">The agent invocation context.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The response from the agent.</returns>
    protected override async Task<Contracts.Generated.Responses.Response> DoInvokeAsync(CreateResponseRequest request,
        AgentInvocationContext context,
        CancellationToken cancellationToken)
    {
        Activity.Current?.SetServiceNamespace("agentframework");

        var messages = request.GetInputMessages();
        var response = await agent.RunAsync(messages, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        var updates = agent.RunStreamingAsync(messages, cancellationToken: cancellationToken);
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
}
