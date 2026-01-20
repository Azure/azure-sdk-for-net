// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text;

using Azure.AI.AgentServer.Contracts.Generated.Agents;
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
    /// Gets or initializes the agent run context.
    /// </summary>
    required public AgentRunContext Context { get; init; }

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
    /// Creates a CreatedBy object from the author name.
    /// </summary>
    /// <param name="authorName">The name of the author from the agent update.</param>
    /// <returns>A CreatedBy object with agent information and response ID.</returns>
    private CreatedBy CreateCreatedBy(string? authorName)
    {
        AgentId? agentId = null;
        if (!string.IsNullOrEmpty(authorName))
        {
            agentId = new AgentId(authorName, string.Empty);
        }

        return new CreatedBy(agentId, Context.ResponseId, null);
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
            FunctionCallContent => GenerateFunctionCallEvents(p.Source, onItemResource),
            FunctionResultContent => GenerateFunctionCallOutputEvents(p.Source, onItemResource),
            TextContent => GenerateAssistantMessageEvents(p.Source, onItemResource),
            _ => null!
        };

        await foreach (var e in events.WithCancellation(CancellationToken).ConfigureAwait(false))
        {
            yield return e;
        }
    }

    private async IAsyncEnumerable<(AgentRunResponseUpdate Update, AIContent Content)> FlattenContents(
        IAsyncEnumerable<AgentRunResponseUpdate> updates)
    {
        await foreach (var update in updates.ConfigureAwait(false))
        {
            foreach (var content in update.Contents)
            {
                throwOnErrorContent(content);
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
        IAsyncEnumerable<(AgentRunResponseUpdate Update, AIContent Content)> source,
        Action<ItemResource> onItemResource)
    {
        string? authorName = null;
        await foreach (var (update, content) in source.WithCancellation(CancellationToken).ConfigureAwait(false))
        {
            if (content is not FunctionCallContent functionCallContent)
            {
                continue;
            }

            // Capture the author name from the first update
            authorName ??= update.AuthorName;

            var groupSeq = GroupSeq.Next();
            var createdBy = CreateCreatedBy(authorName);
            var item = functionCallContent.ToFunctionToolCallItemResource(
                Context.IdGenerator.GenerateFunctionCallId(),
                createdBy);
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
        IAsyncEnumerable<(AgentRunResponseUpdate Update, AIContent Content)> source,
        Action<ItemResource> onItemResource)
    {
        string? authorName = null;
        await foreach (var (update, content) in source.WithCancellation(CancellationToken).ConfigureAwait(false))
        {
            if (content is not FunctionResultContent functionResultContent)
            {
                continue;
            }

            // Capture the author name from the first update
            authorName ??= update.AuthorName;

            var groupSeq = GroupSeq.Next();
            var createdBy = CreateCreatedBy(authorName);
            var item = functionResultContent.ToFunctionToolCallOutputItemResource(
                Context.IdGenerator.GenerateFunctionOutputId(),
                createdBy);
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
        IAsyncEnumerable<(AgentRunResponseUpdate Update, AIContent Content)> source,
        Action<ItemResource> onItemResource)
    {
        var groupSeq = GroupSeq.Next();
        var itemId = Context.IdGenerator.GenerateMessageId();
        string? authorName = null;

        // Create incomplete item without createdBy (will be set in final item)
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
        await foreach (var (update, content) in source.WithCancellation(CancellationToken).ConfigureAwait(false))
        {
            if (content is not TextContent textContent)
            {
                continue;
            }

            // Capture the author name from the first update
            authorName ??= update.AuthorName;

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

        var createdBy = CreateCreatedBy(authorName);
        var itemResource = new ResponsesAssistantMessageItemResource(
            id: itemId,
            status: ResponsesMessageItemResourceStatus.Completed,
            content: [itemContent],
            createdBy: createdBy
        );
        onItemResource(itemResource);
        yield return new ResponseOutputItemDoneEvent(
            sequenceNumber: Seq.Next(),
            outputIndex: groupSeq,
            item: itemResource);
    }

    private static void throwOnErrorContent(AIContent content)
    {
        if (content is ErrorContent errorContent)
        {
            throw new AgentInvocationException(errorContent.ToResponseError());
        }
    }
}
