using System.Diagnostics;
using Azure.AI.AgentServer.AgentFramework.Converters;
using Azure.AI.AgentServer.Contracts.Generated.OpenAI;
using Azure.AI.AgentServer.Contracts.Generated.Responses;
using Azure.AI.AgentServer.Core.Telemetry;
using Azure.AI.AgentServer.Responses.Invocation;
using Azure.AI.AgentServer.Responses.Invocation.Stream;
using Microsoft.Agents.AI;

namespace Azure.AI.AgentServer.AgentFramework;

public class AIAgentInvocation(AIAgent agent) : AgentInvocationBase
{
    protected override async Task<Contracts.Generated.Responses.Response> DoInvokeAsync(CreateResponseRequest request,
        AgentInvocationContext context,
        CancellationToken cancellationToken)
    {
        Activity.Current?.SetServiceNamespace("agentframework");

        var messages = request.GetInputMessages();
        var response = await agent.RunAsync(messages, cancellationToken: cancellationToken).ConfigureAwait(false);
        return response.ToResponse(request, context);
    }

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
