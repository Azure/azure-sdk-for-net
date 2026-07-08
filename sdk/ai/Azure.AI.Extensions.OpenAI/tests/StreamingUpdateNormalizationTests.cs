// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
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
            $$"""{ "type": "response.output_item.added", "sequence_number": 1, "output_index": 0, "item": { "type": "{{ResponseItemKind.BingGroundingCall}}" } }""");

        Assert.That(update.Item, Is.Not.InstanceOf<BingGroundingToolCall>(),
            "Precondition: nested Azure item should be opaque before normalization.");

        var normalized = (StreamingResponseOutputItemAddedUpdate)AzureAIExtensions.NormalizeStreamingUpdate(update);

        Assert.That(normalized.Item, Is.InstanceOf<BingGroundingToolCall>());
    }

    [Test]
    public void NormalizeStreamingUpdateTypesOutputItemDoneItem()
    {
        var update = (StreamingResponseOutputItemDoneUpdate)ReadUpdate(
            $$"""{ "type": "response.output_item.done", "sequence_number": 1, "output_index": 0, "item": { "type": "{{ResponseItemKind.BingGroundingCall}}" } }""");

        Assert.That(update.Item, Is.Not.InstanceOf<BingGroundingToolCall>());

        var normalized = (StreamingResponseOutputItemDoneUpdate)AzureAIExtensions.NormalizeStreamingUpdate(update);

        Assert.That(normalized.Item, Is.InstanceOf<BingGroundingToolCall>());
    }

    [Test]
    public void NormalizeStreamingUpdateTypesCompletedResponseOutput()
    {
        var update = (StreamingResponseCompletedUpdate)ReadUpdate(
            $$"""
            {
              "type": "response.completed",
              "sequence_number": 1,
              "response": {
                "id": "resp_1", "object": "response", "created_at": 0,
                "status": "completed", "model": "gpt-4o",
                "output": [ { "type": "{{ResponseItemKind.BingGroundingCall}}" } ]
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

    // Every lifecycle update carries a snapshot ResponseResult whose output can already contain
    // Azure-specific items (e.g. a consumer inspecting the response on a failed/incomplete update).
    // Those snapshots must be normalized too, not just the terminal completed update.
    private static IEnumerable<TestCaseData> LifecycleUpdateEvents()
    {
        yield return new TestCaseData("response.created", "in_progress").SetName("{m}(response.created)");
        yield return new TestCaseData("response.in_progress", "in_progress").SetName("{m}(response.in_progress)");
        yield return new TestCaseData("response.queued", "queued").SetName("{m}(response.queued)");
        yield return new TestCaseData("response.incomplete", "incomplete").SetName("{m}(response.incomplete)");
        yield return new TestCaseData("response.failed", "failed").SetName("{m}(response.failed)");
        yield return new TestCaseData("response.completed", "completed").SetName("{m}(response.completed)");
    }

    [TestCaseSource(nameof(LifecycleUpdateEvents))]
    public void NormalizeStreamingUpdateTypesLifecycleResponseOutput(string eventType, string status)
    {
        StreamingResponseUpdate update = ReadUpdate($$"""
            {
              "type": "{{eventType}}",
              "sequence_number": 1,
              "response": {
                "id": "resp_1", "object": "response", "created_at": 0,
                "status": "{{status}}", "model": "gpt-4o",
                "output": [ { "type": "{{ResponseItemKind.BingGroundingCall}}" } ]
              }
            }
            """);

        ResponseResult SnapshotOf(StreamingResponseUpdate u)
            => (ResponseResult)u.GetType().GetProperty("Response").GetValue(u);

        Assert.That(SnapshotOf(update).OutputItems[0], Is.Not.InstanceOf<BingGroundingToolCall>(),
            $"Precondition: '{eventType}' snapshot item should be opaque before normalization.");

        StreamingResponseUpdate normalized = AzureAIExtensions.NormalizeStreamingUpdate(update);

        Assert.That(SnapshotOf(normalized).OutputItems[0], Is.InstanceOf<BingGroundingToolCall>(),
            $"'{eventType}' snapshot output items should be typed after normalization.");
    }

    [Test]
    public void NormalizeStreamingUpdateTypesCompletedResponseTools()
    {
        var update = (StreamingResponseCompletedUpdate)ReadUpdate(
            $$"""
            {
              "type": "response.completed",
              "sequence_number": 1,
              "response": {
                "id": "resp_1", "object": "response", "created_at": 0,
                "status": "completed", "model": "gpt-4o",
                "output": [],
                "tools": [ { "type": "{{ResponseToolKind.BingGrounding}}" } ]
              }
            }
            """);

        Assert.That(update.Response.Tools[0], Is.Not.InstanceOf<BingGroundingTool>());

        var normalized = (StreamingResponseCompletedUpdate)AzureAIExtensions.NormalizeStreamingUpdate(update);

        Assert.That(normalized.Response.Tools[0], Is.InstanceOf<BingGroundingTool>(),
            "Echoed tools on a completed update's response should also be normalized.");
    }
}
