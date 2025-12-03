// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text;

using Azure.AI.AgentServer.Contracts.Generated.OpenAI;
using Azure.AI.AgentServer.Core.Common;
using Azure.AI.AgentServer.Core.Common.Id;
using Azure.AI.AgentServer.Responses.Invocation;
using Azure.AI.AgentServer.Responses.Invocation.Stream;

using Microsoft.Agents.AI;
using Microsoft.Extensions.AI;

namespace Azure.AI.AgentServer.AgentFramework.Converters;

/// <summary>
/// Generates item resources from agent run response updates with streaming support.
/// </summary>
public class ItemResourceGenerator
    : NestedChunkedUpdatingGeneratorBase<IEnumerable<ItemResource>, AgentRunResponseUpdate>
{
    /// <summary>
    /// Gets or initializes the agent invocation context.
    /// </summary>
    required public AgentInvocationContext Context { get; init; }

    /// <summary>
    /// Gets or initializes the action to notify when usage is updated.
    /// </summary>
    public Action<ResponseUsage>? NotifyOnUsageUpdate { get; init; }

    /// <summary>
    /// Determines whether two consecutive updates represent a change based on message ID.
    /// </summary>
    /// <param name="previous">The previous update.</param>
    /// <param name="current">The current update.</param>
    /// <returns>True if the message ID has changed; otherwise, false.</returns>
    protected override bool Changed(AgentRunResponseUpdate previous, AgentRunResponseUpdate current)
    {
        return previous.MessageId != current.MessageId;
    }

    /// <summary>
    /// Creates a nested events group from a chunk of updates.
    /// </summary>
    /// <param name="updateGroup">The group of updates to process.</param>
    /// <returns>A nested events group containing item resources.</returns>
    protected override NestedEventsGroup<IEnumerable<ItemResource>> CreateGroup(
        IAsyncEnumerable<AgentRunResponseUpdate> updateGroup)
    {
        List<ItemResource> items = [];
        return new NestedEventsGroup<IEnumerable<ItemResource>>()
        {
            CreateAggregate = () => items,
            Events = GenerateEvents(updateGroup, items.Add)
        };
    }

    private async IAsyncEnumerable<ResponseStreamEvent> GenerateEvents(
        IAsyncEnumerable<AgentRunResponseUpdate> updates,
        Action<ItemResource> onItemResource)
    {
        var p = await FlattenContents(updates).Peek(CancellationToken).ConfigureAwait(false);
        if (!p.HasValue)
        {
            yield break;
        }

        var events = p.First.Content switch
        {
            FunctionCallContent => GenerateFunctionCallEvents(ReadContents(p.Source), onItemResource),
            FunctionResultContent => GenerateFunctionCallOutputEvents(ReadContents(p.Source), onItemResource),
            TextContent => GenerateAssistantMessageEvents(ReadContents(p.Source), onItemResource),
            _ => null!
        };

        await foreach (var e in events.WithCancellation(CancellationToken).ConfigureAwait(false))
        {
            yield return e;
        }
    }

    private static async IAsyncEnumerable<AIContent> ReadContents(
        IAsyncEnumerable<(AgentRunResponseUpdate Update, AIContent Content)> contents)
    {
        await foreach ((_, AIContent content) in contents.ConfigureAwait(false))
        {
            yield return content;
        }
    }

    private async IAsyncEnumerable<(AgentRunResponseUpdate Update, AIContent Content)> FlattenContents(
        IAsyncEnumerable<AgentRunResponseUpdate> updates)
    {
        await foreach (var update in updates.ConfigureAwait(false))
        {
            foreach (var content in update.Contents)
            {
                switch (content)
                {
                    case UsageContent usageContent:
                        if (NotifyOnUsageUpdate != null && usageContent.Details != null)
                        {
                            NotifyOnUsageUpdate(usageContent.Details.ToResponseUsage()!);
                        }
                        continue;
                    case FunctionCallContent or FunctionResultContent or TextContent:
                        yield return (update, content);
                        break;
                }
            }
        }
    }

    private async IAsyncEnumerable<ResponseStreamEvent> GenerateFunctionCallEvents(
        IAsyncEnumerable<AIContent> source,
        Action<ItemResource> onItemResource)
    {
        await foreach (var content in source.WithCancellation(CancellationToken).ConfigureAwait(false))
        {
            if (content is not FunctionCallContent functionCallContent)
            {
                continue;
            }

            var groupSeq = GroupSeq.Next();
            var item = functionCallContent.ToFunctionToolCallItemResource(Context.IdGenerator.GenerateFunctionCallId());
            onItemResource(item);

            yield return new ResponseOutputItemAddedEvent(
                sequenceNumber: Seq.Next(),
                outputIndex: groupSeq,
                item: item);

            yield return new ResponseFunctionCallArgumentsDeltaEvent(
                sequenceNumber: Seq.Next(),
                itemId: item.Id,
                outputIndex: GroupSeq.Current(),
                delta: item.Arguments);

            yield return new ResponseFunctionCallArgumentsDoneEvent(
                sequenceNumber: Seq.Next(),
                itemId: item.Id,
                outputIndex: GroupSeq.Current(),
                arguments: item.Arguments);

            yield return new ResponseOutputItemDoneEvent(
                sequenceNumber: Seq.Next(),
                outputIndex: groupSeq,
                item: item);
        }
    }

    private async IAsyncEnumerable<ResponseStreamEvent> GenerateFunctionCallOutputEvents(
        IAsyncEnumerable<AIContent> source,
        Action<ItemResource> onItemResource)
    {
        await foreach (var content in source.WithCancellation(CancellationToken).ConfigureAwait(false))
        {
            if (content is not FunctionResultContent functionResultContent)
            {
                continue;
            }

            var groupSeq = GroupSeq.Next();
            var item = functionResultContent.ToFunctionToolCallOutputItemResource(Context.IdGenerator.GenerateFunctionOutputId());
            onItemResource(item);

            yield return new ResponseOutputItemAddedEvent(
                sequenceNumber: Seq.Next(),
                outputIndex: groupSeq,
                item: item);

            yield return new ResponseOutputItemDoneEvent(
                sequenceNumber: Seq.Next(),
                outputIndex: groupSeq,
                item: item);
        }
    }

    private async IAsyncEnumerable<ResponseStreamEvent> GenerateAssistantMessageEvents(
        IAsyncEnumerable<AIContent> source,
        Action<ItemResource> onItemResource)
    {
        var groupSeq = GroupSeq.Next();
        var itemId = Context.IdGenerator.GenerateMessageId();
        var incompleteItem = new ResponsesAssistantMessageItemResource(
            id: itemId,
            status: ResponsesMessageItemResourceStatus.Completed,
            content: []
        );

        yield return new ResponseOutputItemAddedEvent(
            sequenceNumber: Seq.Next(),
            outputIndex: groupSeq,
            item: incompleteItem);

        yield return new ResponseContentPartAddedEvent(
            sequenceNumber: Seq.Next(),
            itemId: itemId,
            outputIndex: groupSeq,
            contentIndex: 0,
            part: new ItemContentOutputText(string.Empty, []));

        var text = new StringBuilder();
        await foreach (var content in source.WithCancellation(CancellationToken).ConfigureAwait(false))
        {
            if (content is not TextContent textContent)
            {
                continue;
            }

            text.Append(textContent.Text);
            yield return new ResponseTextDeltaEvent(
                sequenceNumber: Seq.Next(),
                itemId: itemId,
                outputIndex: groupSeq,
                contentIndex: 0,
                delta: textContent.Text
            );
        }

        var itemContent = new ItemContentOutputText(text.ToString(), []);
        yield return new ResponseContentPartDoneEvent(
            sequenceNumber: Seq.Next(),
            itemId: itemId,
            outputIndex: groupSeq,
            contentIndex: 0,
            part: itemContent);

        var itemResource = new ResponsesAssistantMessageItemResource(
            id: itemId,
            status: ResponsesMessageItemResourceStatus.Completed,
            content: [itemContent]
        );
        onItemResource(itemResource);
        yield return new ResponseOutputItemDoneEvent(
            sequenceNumber: Seq.Next(),
            outputIndex: groupSeq,
            item: itemResource);
    }
}
