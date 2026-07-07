// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using NUnit.Framework;
using OpenAI;
using OpenAI.Responses;

namespace Azure.AI.Extensions.OpenAI.Tests;

[Category("Smoke")]
[Parallelizable(ParallelScope.All)]
public class StreamingUpdateNormalizationTests
{
    private static StreamingResponseUpdate ReadUpdate(string json) => ModelReaderWriter.Read<StreamingResponseUpdate>(
        BinaryData.FromString(json),
        ModelReaderWriterOptions.Json,
        OpenAIContext.Default);

    [Test]
    public void NormalizeStreamingUpdateTypesOutputItemAddedItem()
    {
        var update = (StreamingResponseOutputItemAddedUpdate)ReadUpdate(
            """{ "type": "response.output_item.added", "sequence_number": 1, "output_index": 0, "item": { "type": "bing_grounding_call" } }""");

        Assert.That(update.Item, Is.Not.InstanceOf<BingGroundingToolCall>(),
            "Precondition: nested Azure item should be opaque before normalization.");

        var normalized = (StreamingResponseOutputItemAddedUpdate)AzureAIExtensions.NormalizeStreamingUpdate(update);

        Assert.That(normalized.Item, Is.InstanceOf<BingGroundingToolCall>());
    }

    [Test]
    public void NormalizeStreamingUpdateTypesOutputItemDoneItem()
    {
        var update = (StreamingResponseOutputItemDoneUpdate)ReadUpdate(
            """{ "type": "response.output_item.done", "sequence_number": 1, "output_index": 0, "item": { "type": "bing_grounding_call" } }""");

        Assert.That(update.Item, Is.Not.InstanceOf<BingGroundingToolCall>());

        var normalized = (StreamingResponseOutputItemDoneUpdate)AzureAIExtensions.NormalizeStreamingUpdate(update);

        Assert.That(normalized.Item, Is.InstanceOf<BingGroundingToolCall>());
    }

    [Test]
    public void NormalizeStreamingUpdateTypesCompletedResponseOutput()
    {
        var update = (StreamingResponseCompletedUpdate)ReadUpdate(
            """
            {
              "type": "response.completed",
              "sequence_number": 1,
              "response": {
                "id": "resp_1", "object": "response", "created_at": 0,
                "status": "completed", "model": "gpt-4o",
                "output": [ { "type": "bing_grounding_call" } ]
              }
            }
            """);

        Assert.That(update.Response.OutputItems[0], Is.Not.InstanceOf<BingGroundingToolCall>());

        var normalized = (StreamingResponseCompletedUpdate)AzureAIExtensions.NormalizeStreamingUpdate(update);

        Assert.That(normalized.Response.OutputItems[0], Is.InstanceOf<BingGroundingToolCall>());
    }

    [Test]
    public void NormalizeStreamingUpdateLeavesUnrelatedUpdatesUnchanged()
    {
        var update = ReadUpdate("""{ "type": "response.created", "sequence_number": 1, "response": { "id": "r", "object": "response", "created_at": 0, "status": "in_progress", "model": "gpt-4o", "output": [] } }""");

        Assert.DoesNotThrow(() => AzureAIExtensions.NormalizeStreamingUpdate(update));
    }
}
