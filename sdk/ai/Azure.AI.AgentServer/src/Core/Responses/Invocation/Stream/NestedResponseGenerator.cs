using Azure.AI.AgentServer.Contracts.Generated.OpenAI;
using Azure.AI.AgentServer.Contracts.Generated.Responses;

namespace Azure.AI.AgentServer.Responses.Invocation.Stream;

public class NestedResponseGenerator : NestedStreamEventGeneratorBase<Contracts.Generated.Responses.Response>
{
    public required AgentInvocationContext Context { get; init; }

    public required CreateResponseRequest Request { get; init; }

    public required INestedStreamEventGenerator<IEnumerable<ItemResource>> OutputGenerator { get; init; }

    public Action<Action<ResponseUsage>> SubscribeUsageUpdate
    {
        init => value(SetUsage);
    }

    private readonly DateTimeOffset _createdAt = DateTimeOffset.UtcNow;

    private ResponseUsage? _latestUsage;

    private Contracts.Generated.Responses.Response? CompletedResponse { get; set; }

#pragma warning disable CS1998
    public override async IAsyncEnumerable<NestedEventsGroup<Contracts.Generated.Responses.Response>> Generate()
    {
        yield return new NestedEventsGroup<Contracts.Generated.Responses.Response>()
        {
            CreateAggregate = () => CompletedResponse!,
            Events = GenerateEventsAsync()
        };
    }
#pragma warning restore CS1998

    private async IAsyncEnumerable<ResponseStreamEvent> GenerateEventsAsync()
    {
        yield return new ResponseCreatedEvent(Seq.Next(), ToResponse(status: ResponseStatus.InProgress));
        yield return new ResponseInProgressEvent(Seq.Next(), ToResponse(status: ResponseStatus.InProgress));

        IList<Func<IEnumerable<ItemResource>>> outputFactories = [];
        await foreach (var group in OutputGenerator.Generate().WithCancellation(CancellationToken).ConfigureAwait(false))
        {
            outputFactories.Add(group.CreateAggregate);
            await foreach(var e in group.Events.WithCancellation(CancellationToken).ConfigureAwait(false))
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
            inputTokensDetails: new ResponseUsageInputTokensDetails(
                cachedTokens: usage.InputTokensDetails.CachedTokens + _latestUsage.InputTokensDetails.CachedTokens),
            outputTokens: usage.OutputTokens + _latestUsage.OutputTokens,
            outputTokensDetails: new ResponseUsageOutputTokensDetails(
                reasoningTokens: usage.OutputTokensDetails.ReasoningTokens + _latestUsage.OutputTokensDetails.ReasoningTokens),
            totalTokens: usage.TotalTokens + _latestUsage.TotalTokens);
    }
}
