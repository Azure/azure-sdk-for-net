// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;
using Azure.AI.AgentServer.AgentFramework.Converters;
using Azure.AI.AgentServer.AgentFramework.Persistence;
using Azure.AI.AgentServer.Contracts.Generated.OpenAI;
using Azure.AI.AgentServer.Contracts.Generated.Responses;
using Azure.AI.AgentServer.Core.Telemetry;
using Azure.AI.AgentServer.Responses.Invocation;
using Azure.AI.AgentServer.Responses.Invocation.Stream;
using Microsoft.Agents.AI;
using Microsoft.Extensions.AI;

using AgentRunContext = Azure.AI.AgentServer.Responses.Invocation.AgentRunContext;

namespace Azure.AI.AgentServer.AgentFramework;

/// <summary>
/// Provides an implementation of agent invocation using the Microsoft Agents AI framework.
/// </summary>
/// <param name="agent">The AI agent to invoke.</param>
/// <param name="threadRepository">Optional repository for managing agent sessions.</param>
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
        AgentSession? session = await GetSession(context).ConfigureAwait(false);

        var messages = await GetInput(request, session).ConfigureAwait(false);

        var response = await agent.RunAsync(
            messages,
            session: session,
            cancellationToken: cancellationToken).ConfigureAwait(false);
        await SaveSession(context, session).ConfigureAwait(false);
        return response.ToResponse(request, context);
    }

    /// <summary>
    /// Executes the agent invocation with streaming support.
    /// </summary>
    /// <param name="context">The agent run context.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>A stream event generator for the response.</returns>
    protected override async Task<
        (INestedStreamEventGenerator<Contracts.Generated.Responses.Response> Generator, Func<CancellationToken, Task> PostInvoke)
        > DoInvokeStreamAsync(
        AgentRunContext context,
        CancellationToken cancellationToken)
    {
        Activity.Current?.SetServiceNamespace("agentframework");

        AgentSession? session = await GetSession(context).ConfigureAwait(false);

        var request = context.Request;
        var messages = await GetInput(request, session).ConfigureAwait(false);

        var updates = agent.RunStreamingAsync(messages, session: session, cancellationToken: cancellationToken);
        // TODO refine to multicast event
        IList<Action<ResponseUsage>> usageUpdaters = [];

        var seq = ISequenceNumber.Default;
        var generator = new NestedResponseGenerator()
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

        var func = (async (CancellationToken ct) =>
        {
            await SaveSession(context, session).ConfigureAwait(false);
        });
        return (generator, func);
    }

    private async Task<AgentSession?> GetSession(AgentRunContext context)
    {
        if (threadRepository != null && !string.IsNullOrEmpty(context.ConversationId))
        {
            return await threadRepository.Get(context.ConversationId, agent).ConfigureAwait(false);
        }
        return null;
    }

    private async Task SaveSession(AgentRunContext context, AgentSession? session)
    {
        if (session != null && threadRepository != null && !string.IsNullOrEmpty(context.ConversationId))
        {
            await threadRepository.Set(context.ConversationId, session).ConfigureAwait(false);
        }
    }

    private Task<IReadOnlyCollection<ChatMessage>> GetInput(CreateResponseRequest request, AgentSession? session)
    {
        if (session != null && agent is ChatClientAgent chatClientAgent &&
            chatClientAgent.ChatHistoryProvider is InMemoryChatHistoryProvider memoryProvider)
        {
            var sessionMessages = memoryProvider.GetMessages(session);
            var pendingApprovalRequests = GetPendingUserInputRequestContents(sessionMessages);
            if (pendingApprovalRequests.Count > 0)
            {
                var res = request.ValidateAndConvertResponse(pendingApprovalRequests);
                if (res != null && res.Count > 0)
                {
                    return Task.FromResult<IReadOnlyCollection<ChatMessage>>(res);
                }
            }
        }
        return Task.FromResult<IReadOnlyCollection<ChatMessage>>(request.GetInputMessages());
    }

    private static Dictionary<string, UserInputRequestContent> GetPendingUserInputRequestContents(
        IEnumerable<ChatMessage> messages)
    {
        var res = new Dictionary<string, UserInputRequestContent>();
        foreach (var message in messages)
        {
            foreach (var content in message.Contents)
            {
                if (content is UserInputRequestContent userRequestContent)
                {
                    res[userRequestContent.Id] = userRequestContent;
                }
                else if (content is UserInputResponseContent userInputResponseContent)
                {
                    res.Remove(userInputResponseContent.Id);
                }
            }
        }
        return res;
    }
}
