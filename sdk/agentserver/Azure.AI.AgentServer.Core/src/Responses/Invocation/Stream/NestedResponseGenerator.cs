// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Contracts.Generated.OpenAI;
using Azure.AI.AgentServer.Contracts.Generated.Responses;

namespace Azure.AI.AgentServer.Responses.Invocation.Stream;

/// <summary>
/// Generates nested stream events for agent responses.
/// </summary>
public class NestedResponseGenerator : NestedStreamEventGeneratorBase<Contracts.Generated.Responses.Response>
{
    /// <summary>
    /// Gets or initializes the agent invocation context.
    /// </summary>
    required public AgentInvocationContext Context { get; init; }

    /// <summary>
    /// Gets or initializes the create response request.
    /// </summary>
    required public CreateResponseRequest Request { get; init; }

    /// <summary>
    /// Gets or initializes the output generator for item resources.
    /// </summary>
    required public INestedStreamEventGenerator<IEnumerable<ItemResource>> OutputGenerator { get; init; }

    /// <summary>
    /// Initializes the subscription for usage updates.
    /// </summary>
    public Action<Action<ResponseUsage>> SubscribeUsageUpdate
    {
        init => value(SetUsage);
    }

    private readonly DateTimeOffset _createdAt = DateTimeOffset.UtcNow;

    private ResponseUsage? _latestUsage;

    private Contracts.Generated.Responses.Response? CompletedResponse { get; set; }

#pragma warning disable CS1998
    /// <summary>
    /// Generates groups of nested events for the response.
    /// </summary>
    /// <returns>An async enumerable of nested event groups.</returns>
    public override async IAsyncEnumerable<NestedEventsGroup<Contracts.Generated.Responses.Response>> Generate()
    {
        yield return new NestedEventsGroup<Contracts.Generated.Responses.Response>()
        {
            CreateAggregate = () => CompletedResponse!, Events = GenerateEventsAsync()
        };
    }
#pragma warning restore CS1998

    private async IAsyncEnumerable<ResponseStreamEvent> GenerateEventsAsync()
    {
        yield return new ResponseCreatedEvent(Seq.Next(), ToResponse(status: ResponseStatus.InProgress));
        yield return new ResponseInProgressEvent(Seq.Next(), ToResponse(status: ResponseStatus.InProgress));

        IList<Func<IEnumerable<ItemResource>>> outputFactories = [];
        await foreach (var group in OutputGenerator.Generate().WithCancellation(CancellationToken)
                           .ConfigureAwait(false))
        {
            outputFactories.Add(group.CreateAggregate);
            await foreach (var e in group.Events.WithCancellation(CancellationToken).ConfigureAwait(false))
            {
                yield return e;
            }
        }

        var output = outputFactories.SelectMany(f => f());
        CompletedResponse = ToResponse(status: ResponseStatus.Completed, output);
        yield return new ResponseCompletedEvent(Seq.Next(), CompletedResponse);
    }

    private Contracts.Generated.Responses.Response ToResponse(ResponseStatus status = ResponseStatus.Completed,
        IEnumerable<ItemResource>? output = null)
    {
        return Request.ToResponse(
            context: Context,
            output: output,
            status: status,
            createdAt: _createdAt,
            usage: _latestUsage
        );
    }

    private void SetUsage(ResponseUsage usage)
    {
        if (_latestUsage == null)
        {
            _latestUsage = usage;
            return;
        }

        _latestUsage = new ResponseUsage(
            inputTokens: usage.InputTokens + _latestUsage.InputTokens,
            inputTokensDetails: new ResponseUsageInputTokensDetails(cachedTokens:
                usage.InputTokensDetails?.CachedTokens ?? 0 + _latestUsage.InputTokensDetails?.CachedTokens ?? 0),
            outputTokens: usage.OutputTokens + _latestUsage.OutputTokens,
            outputTokensDetails: new ResponseUsageOutputTokensDetails(reasoningTokens:
                usage.OutputTokensDetails?.ReasoningTokens ?? 0 + _latestUsage.OutputTokensDetails?.ReasoningTokens ?? 0),
            totalTokens: usage.TotalTokens + _latestUsage.TotalTokens);
    }
}
