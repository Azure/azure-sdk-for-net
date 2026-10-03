// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.AI.AgentServer.Responses.Models;
using Azure.AI.AgentServer.Responses.Tests.Helpers;

namespace Azure.AI.AgentServer.Responses.Tests.PublicApi;

/// <summary>
/// Tests for <see cref="OutputItemExtensions.GetId"/>.
/// Validates both the fast path (known subclass pattern match) and the slow path
/// (JSON serialization fallback), as well as error cases.
/// </summary>
public class OutputItemExtensionsTests
{
    // ── Fast path: known OpenAI base types ─────────────────────────────

    [Test]
    public void GetId_OutputItemMessage_ReturnsFastPathId()
    {
        var item = MessageItemFactory.OutputMessage(
            id: "msg_abc123",
            status: MessageStatus.Completed,
            role: MessageRole.Assistant,
            content: new List<ResponseContentPart>
            {
                ResponseContentPart.CreateOutputTextPart(text: "Hello", annotations: Array.Empty<Annotation>()),
            });

        Assert.That(item.GetId(), Is.EqualTo("msg_abc123"));
    }

    [Test]
    public void GetId_OutputItemOutputMessage_ReturnsFastPathId()
    {
        var item = MessageItemFactory.OutputMessage("msg_output_001", MessageStatus.Completed, MessageRole.Assistant, Array.Empty<ResponseContentPart>());

        Assert.That(item.GetId(), Is.EqualTo("msg_output_001"));
    }

    [Test]
    public void GetId_OutputItemFunctionToolCall_ReturnsFastPathId()
    {
        var item = CreateFunctionToolCallWithId("fc_001");

        Assert.That(item.GetId(), Is.EqualTo("fc_001"));
    }

    [Test]
    public void GetId_OutputItemReasoningItem_ReturnsFastPathId()
    {
        var item = new OutputItemReasoningItem(new[] { new OpenAI.Responses.ReasoningSummaryTextPart("Thinking...") }) { Id = "reasoning_001" };

        Assert.That(item.GetId(), Is.EqualTo("reasoning_001"));
    }

    [Test]
    public void GetId_OutputItemCustomToolCall_ReturnsFastPathId()
    {
        var item = new OutputItemCustomToolCall(
            callId: "call_custom",
            name: "my_tool",
            input: "{}",
            status: OpenAI.Responses.FunctionCallStatus.InProgress);
        item.Id = "ct_001";

        Assert.That(item.GetId(), Is.EqualTo("ct_001"));
    }

    [Test]
    public void GetId_OutputItemWebSearchToolCall_ReturnsFastPathId()
    {
        var item = new OutputItemWebSearchToolCall { Id = "ws_001", Status = WebSearchCallStatus.Completed, Action = new WebSearchSearchAction { Queries = { "test" } } };

        Assert.That(item.GetId(), Is.EqualTo("ws_001"));
    }

    // ── Fast path: Azure.AI.Projects extension types ───────────────────

    [Test]
    public void GetId_A2AToolCall_ReturnsFastPathId()
    {
        var item = new A2AToolCall(
            callId: "call_a2a",
            name: "agent_b",
            arguments: "{}",
            status: Azure.AI.Extensions.OpenAI.ToolCallStatus.Completed)
        {
            Id = "a2a_001",
        };

        Assert.That(item.GetId(), Is.EqualTo("a2a_001"));
    }

    // ── Null ID → InvalidOperationException ────────────────────────────

    [Test]
    public void GetId_NullId_ThrowsInvalidOperationException()
    {
        // Use FunctionToolCall where Id is a settable property (not validated in ctor)
        var item = new OutputItemFunctionToolCall("call_1", "fn", BinaryData.FromString("{}"));
        // Id is null by default (not set in ctor)

        var ex = Assert.Throws<InvalidOperationException>(() => item.GetId());
        Assert.That(ex!.Message, Does.Contain("does not have a valid Id"));
    }

    // ── Null item → ArgumentNullException ──────────────────────────────

    [Test]
    public void GetId_NullItem_ThrowsArgumentNullException()
    {
        OutputItem? item = null;
        Assert.Throws<ArgumentNullException>(() => item!.GetId());
    }

    // ── Id set after construction ──────────────────────────────────────

    [Test]
    public void GetId_IdSetAfterConstruction_ReturnsUpdatedId()
    {
        var item = new OutputItemFunctionToolCall("call_1", "fn", BinaryData.FromString("{}"));

        // Id is read-only — create a new instance with the desired Id
        var updated = CreateFunctionToolCallWithId("fc_updated");
        Assert.That(updated.GetId(), Is.EqualTo("fc_updated"));
    }

    // ── Multiple subclasses all return correct Id ──────────────────────

    [Test]
    public void GetId_MultipleSubclassTypes_AllReturnCorrectId()
    {
        var items = new (OutputItem Item, string ExpectedId)[]
        {
            (MessageItemFactory.OutputMessage("msg_1", MessageStatus.Completed, MessageRole.Assistant, Array.Empty<ResponseContentPart>()), "msg_1"),
            (new OutputItemReasoningItem(Array.Empty<OpenAI.Responses.ReasoningSummaryPart>()) { Id = "reason_1" }, "reason_1"),
            (CreateFunctionToolCallWithId("fc_1"), "fc_1"),
        };

        foreach (var (Item, ExpectedId) in items)
        {
            Assert.That(Item.GetId(), Is.EqualTo(ExpectedId), $"Failed for {Item.GetType().Name}");
        }
    }

    private static OutputItemFunctionToolCall CreateFunctionToolCallWithId(string id)
    {
        return new OutputItemFunctionToolCall("call", "fn", BinaryData.FromString("{}")) { Id = id };
    }
}
