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

namespace Azure.AI.AgentServer.AgentFramework;

/// <summary>
/// Provides an implementation of agent invocation using a workflow as the agent.
/// </summary>
/// <param name="workflowAgentFactory">A factory to create the workflow agent.</param>
/// <param name="threadRepository">Optional repository for managing agent threads.</param>
public class WorkflowAgentInvocation(
        IWorkflowAgentFactory workflowAgentFactory,
        IAgentThreadRepository? threadRepository = null) : AgentInvocationBase
{
    /// <summary>
    /// Invokes the workflow agent asynchronously and returns a complete response.
    /// </summary>
    /// <param name="context">The agent run context.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The response from the agent.</returns>
    public override async Task<Contracts.Generated.Responses.Response> InvokeAsync(
        AgentRunContext context,
        CancellationToken cancellationToken = default)
    {
        Activity.Current?.SetServiceNamespace("agentframework");

        var workflowAgent = workflowAgentFactory.BuildWorkflow();

        var request = context.Request;
        AgentThread? thread = await GetThread(context, workflowAgent).ConfigureAwait(false);
        var messages = await GetInput(request, thread).ConfigureAwait(false);

        var response = await workflowAgent.RunAsync(
            messages, thread: thread,
            cancellationToken: cancellationToken).ConfigureAwait(false);

        await SaveThread(context, thread).ConfigureAwait(false);

        return response.ToResponse(request, context);
    }

    /// <summary>
    /// Executes the workflow agent invocation with streaming support.
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

        var workflowAgent = workflowAgentFactory.BuildWorkflow();

        AgentThread? thread = await GetThread(context, workflowAgent).ConfigureAwait(false);

        var request = context.Request;
        var messages = await GetInput(request, thread).ConfigureAwait(false);
        var updates = workflowAgent.RunStreamingAsync(messages, thread: thread, cancellationToken: cancellationToken);
        // TODO refine to multicast event
        IList<Action<ResponseUsage>> usageUpdaters = [];

        var seq = ISequenceNumber.Default;
        INestedStreamEventGenerator<Contracts.Generated.Responses.Response> generator = new NestedResponseGenerator()
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
            await SaveThread(context, thread).ConfigureAwait(false);
        });
        return (generator, func);
    }

    private async Task<AgentThread?> GetThread(AgentRunContext context, AIAgent workflowAgent)
    {
        if (threadRepository != null)
        {
            return await threadRepository.Get(context.ConversationId, workflowAgent).ConfigureAwait(false);
        }
        return null;
    }

    private async Task SaveThread(AgentRunContext context, AgentThread? agentThread)
    {
        if (agentThread != null && threadRepository != null)
        {
            await threadRepository.Set(context.ConversationId, agentThread).ConfigureAwait(false);
        }
    }

    private async Task<IReadOnlyCollection<ChatMessage>> GetInput(CreateResponseRequest request, AgentThread? thread)
    {
        Dictionary<string, UserInputRequestContent> pendingApprovalRequests = new();
        if (thread != null)
        {
            pendingApprovalRequests = await thread.GetPendingUserInputRequestContents().ConfigureAwait(false);
            var res = request.ValidateAndConvertResponse(pendingApprovalRequests);
            if (res != null && res.Count > 0)
            {
                return res;
            }
        }
        return request.GetInputMessages();
    }
}
