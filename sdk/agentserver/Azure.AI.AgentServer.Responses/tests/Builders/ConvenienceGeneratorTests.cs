// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Responses.Internal;
using Azure.AI.AgentServer.Responses.Models;

namespace Azure.AI.AgentServer.Responses.Tests.Builders;

/// <summary>
/// Tests for sub-item and output-item convenience generators (S-053 through S-060).
/// </summary>
public class ConvenienceGeneratorTests
{
    private static ResponseEventStream CreateStream()
    {
        var context = new ResponseContext("resp_test");
        return new ResponseEventStream(context, new CreateResponse { Model = "gpt-4o" });
    }

    // ──────────────────────────────────────────────────────────
    //  S-053: Sub-Item Convenience – Message TextContent
    // ──────────────────────────────────────────────────────────

    [Test]
    public void TextContent_Complete_EmitsCorrectEventSequence()
    {
        var stream = CreateStream();
        var msg = stream.AddOutputItemMessage();
        msg.EmitAdded();

        var events = msg.TextContent("Hello").ToList();

        Assert.That(events, Has.Count.EqualTo(4));
        XAssert.IsType<ResponseContentPartAddedEvent>(events[0]);
        XAssert.IsType<ResponseTextDeltaEvent>(events[1]);
        XAssert.IsType<ResponseTextDoneEvent>(events[2]);
        XAssert.IsType<ResponseContentPartDoneEvent>(events[3]);
    }

    [Test]
    public void TextContent_Complete_DeltaContainsFullText()
    {
        var stream = CreateStream();
        var msg = stream.AddOutputItemMessage();
        msg.EmitAdded();

        var events = msg.TextContent("The answer").ToList();

        var delta = XAssert.IsType<ResponseTextDeltaEvent>(events[1]);
        Assert.That(delta.Delta, Is.EqualTo("The answer"));
    }

    [Test]
    public async Task TextContent_Streaming_EmitsChunkDeltas()
    {
        var stream = CreateStream();
        var msg = stream.AddOutputItemMessage();
        msg.EmitAdded();

        var events = await CollectAsync(msg.TextContent(ToAsync("Hel", "lo"), default));

        Assert.That(events, Has.Count.EqualTo(5));
        XAssert.IsType<ResponseContentPartAddedEvent>(events[0]);
        var d1 = XAssert.IsType<ResponseTextDeltaEvent>(events[1]);
        var d2 = XAssert.IsType<ResponseTextDeltaEvent>(events[2]);
        var done = XAssert.IsType<ResponseTextDoneEvent>(events[3]);
        XAssert.IsType<ResponseContentPartDoneEvent>(events[4]);

        Assert.That(d1.Delta, Is.EqualTo("Hel"));
        Assert.That(d2.Delta, Is.EqualTo("lo"));
        Assert.That(done.Text, Is.EqualTo("Hello"));
    }

    // ──────────────────────────────────────────────────────────
    //  S-053: Sub-Item Convenience – Message RefusalContent
    // ──────────────────────────────────────────────────────────

    [Test]
    public void RefusalContent_Complete_EmitsCorrectEventSequence()
    {
        var stream = CreateStream();
        var msg = stream.AddOutputItemMessage();
        msg.EmitAdded();

        var events = msg.RefusalContent("I cannot help").ToList();

        Assert.That(events, Has.Count.EqualTo(4));
        XAssert.IsType<ResponseContentPartAddedEvent>(events[0]);
        XAssert.IsType<ResponseRefusalDeltaEvent>(events[1]);
        XAssert.IsType<ResponseRefusalDoneEvent>(events[2]);
        XAssert.IsType<ResponseContentPartDoneEvent>(events[3]);
    }

    [Test]
    public async Task RefusalContent_Streaming_AccumulatesAll()
    {
        var stream = CreateStream();
        var msg = stream.AddOutputItemMessage();
        msg.EmitAdded();

        var events = await CollectAsync(msg.RefusalContent(ToAsync("I ca", "nnot"), default));

        var done = XAssert.IsType<ResponseRefusalDoneEvent>(events[3]);
        Assert.That(done.Refusal, Is.EqualTo("I cannot"));
    }

    // ──────────────────────────────────────────────────────────
    //  S-053: Sub-Item Convenience – FunctionCall Arguments
    // ──────────────────────────────────────────────────────────

    [Test]
    public void Arguments_Complete_EmitsCorrectEventSequence()
    {
        var stream = CreateStream();
        var fc = stream.AddOutputItemFunctionCall("get_weather", "call_1");
        fc.EmitAdded();

        var events = fc.Arguments("{\"city\":\"Seattle\"}").ToList();

        Assert.That(events, Has.Count.EqualTo(2));
        XAssert.IsType<ResponseFunctionCallArgumentsDeltaEvent>(events[0]);
        XAssert.IsType<ResponseFunctionCallArgumentsDoneEvent>(events[1]);
    }

    [Test]
    public async Task Arguments_Streaming_EmitsChunkDeltas()
    {
        var stream = CreateStream();
        var fc = stream.AddOutputItemFunctionCall("get_weather", "call_1");
        fc.EmitAdded();

        var events = await CollectAsync(fc.Arguments(ToAsync("{\"city\":", "\"Seattle\"}"), default));

        Assert.That(events, Has.Count.EqualTo(3));
        var d1 = XAssert.IsType<ResponseFunctionCallArgumentsDeltaEvent>(events[0]);
        var d2 = XAssert.IsType<ResponseFunctionCallArgumentsDeltaEvent>(events[1]);
        var done = XAssert.IsType<ResponseFunctionCallArgumentsDoneEvent>(events[2]);

        Assert.That(d1.Delta, Is.EqualTo("{\"city\":"));
        Assert.That(d2.Delta, Is.EqualTo("\"Seattle\"}"));
        Assert.That(done.Arguments, Is.EqualTo("{\"city\":\"Seattle\"}"));
    }

    // ──────────────────────────────────────────────────────────
    //  S-053: Sub-Item Convenience – Reasoning SummaryPart
    // ──────────────────────────────────────────────────────────

    [Test]
    public void SummaryPart_Complete_EmitsCorrectEventSequence()
    {
        var stream = CreateStream();
        var reasoning = stream.AddOutputItemReasoningItem();
        reasoning.EmitAdded();

        var events = reasoning.SummaryPart("Thinking...").ToList();

        Assert.That(events, Has.Count.EqualTo(4));
        XAssert.IsType<ResponseReasoningSummaryPartAddedEvent>(events[0]);
        XAssert.IsType<ResponseReasoningSummaryTextDeltaEvent>(events[1]);
        XAssert.IsType<ResponseReasoningSummaryTextDoneEvent>(events[2]);
        XAssert.IsType<ResponseReasoningSummaryPartDoneEvent>(events[3]);
    }

    [Test]
    public async Task SummaryPart_Streaming_AccumulatesAll()
    {
        var stream = CreateStream();
        var reasoning = stream.AddOutputItemReasoningItem();
        reasoning.EmitAdded();

        var events = await CollectAsync(reasoning.SummaryPart(ToAsync("Think", "ing"), default));

        var done = XAssert.IsType<ResponseReasoningSummaryTextDoneEvent>(events[3]);
        Assert.That(done.Text, Is.EqualTo("Thinking"));
    }

    // ──────────────────────────────────────────────────────────
    //  S-053: Sub-Item Convenience – CodeInterpreter Code
    // ──────────────────────────────────────────────────────────

    [Test]
    public void Code_Complete_EmitsCorrectEventSequence()
    {
        var stream = CreateStream();
        var ci = stream.AddOutputItemCodeInterpreterCall();
        ci.EmitAdded();

        var events = ci.Code("print('hi')").ToList();

        Assert.That(events, Has.Count.EqualTo(2));
        XAssert.IsType<ResponseCodeInterpreterCallCodeDeltaEvent>(events[0]);
        XAssert.IsType<ResponseCodeInterpreterCallCodeDoneEvent>(events[1]);
    }

    [Test]
    public async Task Code_Streaming_AccumulatesAll()
    {
        var stream = CreateStream();
        var ci = stream.AddOutputItemCodeInterpreterCall();
        ci.EmitAdded();

        var events = await CollectAsync(ci.Code(ToAsync("print(", "'hi')"), default));

        var done = XAssert.IsType<ResponseCodeInterpreterCallCodeDoneEvent>(events[2]);
        Assert.That(done.Code, Is.EqualTo("print('hi')"));
    }

    // ──────────────────────────────────────────────────────────
    //  S-053: Sub-Item Convenience – MCP Call Arguments
    // ──────────────────────────────────────────────────────────

    [Test]
    public void McpArguments_Complete_EmitsCorrectEventSequence()
    {
        var stream = CreateStream();
        var mcp = stream.AddOutputItemMcpCall("myserver", "my_tool");
        mcp.EmitAdded();

        var events = mcp.Arguments("{\"key\":\"val\"}").ToList();

        Assert.That(events, Has.Count.EqualTo(2));
        XAssert.IsType<ResponseMCPCallArgumentsDeltaEvent>(events[0]);
        XAssert.IsType<ResponseMCPCallArgumentsDoneEvent>(events[1]);
    }

    [Test]
    public async Task McpArguments_Streaming_AccumulatesAll()
    {
        var stream = CreateStream();
        var mcp = stream.AddOutputItemMcpCall("myserver", "my_tool");
        mcp.EmitAdded();

        var events = await CollectAsync(mcp.Arguments(ToAsync("{\"k\":", "\"v\"}"), default));

        var done = XAssert.IsType<ResponseMCPCallArgumentsDoneEvent>(events[2]);
        Assert.That(done.Arguments, Is.EqualTo("{\"k\":\"v\"}"));
    }

    // ──────────────────────────────────────────────────────────
    //  S-053: Sub-Item Convenience – CustomToolCall Input
    // ──────────────────────────────────────────────────────────

    [Test]
    public void Input_Complete_EmitsCorrectEventSequence()
    {
        var stream = CreateStream();
        var ct = stream.AddOutputItemCustomToolCall("call_1", "my_tool");
        ct.EmitAdded();

        var events = ct.Input("some input").ToList();

        Assert.That(events, Has.Count.EqualTo(2));
        XAssert.IsType<ResponseCustomToolCallInputDeltaEvent>(events[0]);
        XAssert.IsType<ResponseCustomToolCallInputDoneEvent>(events[1]);
    }

    [Test]
    public async Task Input_Streaming_AccumulatesAll()
    {
        var stream = CreateStream();
        var ct = stream.AddOutputItemCustomToolCall("call_1", "my_tool");
        ct.EmitAdded();

        var events = await CollectAsync(ct.Input(ToAsync("some ", "input"), default));

        var done = XAssert.IsType<ResponseCustomToolCallInputDoneEvent>(events[2]);
        Assert.That(done.Input, Is.EqualTo("some input"));
    }

    // ──────────────────────────────────────────────────────────
    //  S-056: Output-Item Convenience – Message
    // ──────────────────────────────────────────────────────────

    [Test]
    public void OutputItemMessage_Complete_EmitsFullLifecycle()
    {
        var stream = CreateStream();

        var events = stream.OutputItemMessage("Hello").ToList();

        // output_item.added → content_part.added → text.delta → text.done → content_part.done → output_item.done
        Assert.That(events, Has.Count.EqualTo(6));
        XAssert.IsType<ResponseOutputItemAddedEvent>(events[0]);
        XAssert.IsType<ResponseContentPartAddedEvent>(events[1]);
        XAssert.IsType<ResponseTextDeltaEvent>(events[2]);
        XAssert.IsType<ResponseTextDoneEvent>(events[3]);
        XAssert.IsType<ResponseContentPartDoneEvent>(events[4]);
        XAssert.IsType<ResponseOutputItemDoneEvent>(events[5]);
    }

    [Test]
    public async Task OutputItemMessage_Streaming_EmitsFullLifecycle()
    {
        var stream = CreateStream();

        var events = await CollectAsync(stream.OutputItemMessage(ToAsync("Hel", "lo"), default));

        // output_item.added → content_part.added → delta × 2 → text.done → content_part.done → output_item.done
        Assert.That(events, Has.Count.EqualTo(7));
        XAssert.IsType<ResponseOutputItemAddedEvent>(events[0]);
        XAssert.IsType<ResponseContentPartAddedEvent>(events[1]);
        XAssert.IsType<ResponseTextDeltaEvent>(events[2]);
        XAssert.IsType<ResponseTextDeltaEvent>(events[3]);
        XAssert.IsType<ResponseTextDoneEvent>(events[4]);
        XAssert.IsType<ResponseContentPartDoneEvent>(events[5]);
        XAssert.IsType<ResponseOutputItemDoneEvent>(events[6]);
    }

    [Test]
    public void OutputItemMessage_Complete_DoneContainsText()
    {
        var stream = CreateStream();

        var events = stream.OutputItemMessage("Hello").ToList();

        var done = XAssert.IsType<ResponseOutputItemDoneEvent>(events[5]);
        var msg = XAssert.IsType<OutputItemMessage>(done.Item);
        Assert.That(msg.Content, Has.Count.EqualTo(1));
    }

    // ──────────────────────────────────────────────────────────
    //  S-056: Output-Item Convenience – FunctionCall
    // ──────────────────────────────────────────────────────────

    [Test]
    public void OutputItemFunctionCall_Complete_EmitsFullLifecycle()
    {
        var stream = CreateStream();

        var events = stream.OutputItemFunctionCall("get_weather", "call_1", "{\"city\":\"NYC\"}").ToList();

        // output_item.added → args.delta → args.done → output_item.done
        Assert.That(events, Has.Count.EqualTo(4));
        XAssert.IsType<ResponseOutputItemAddedEvent>(events[0]);
        XAssert.IsType<ResponseFunctionCallArgumentsDeltaEvent>(events[1]);
        XAssert.IsType<ResponseFunctionCallArgumentsDoneEvent>(events[2]);
        XAssert.IsType<ResponseOutputItemDoneEvent>(events[3]);
    }

    [Test]
    public async Task OutputItemFunctionCall_Streaming_EmitsFullLifecycle()
    {
        var stream = CreateStream();

        var events = await CollectAsync(stream.OutputItemFunctionCall(
            "get_weather", "call_1", ToAsync("{\"city\":", "\"NYC\"}"), default));

        // output_item.added → delta × 2 → args.done → output_item.done
        Assert.That(events, Has.Count.EqualTo(5));
        XAssert.IsType<ResponseOutputItemAddedEvent>(events[0]);
        XAssert.IsType<ResponseFunctionCallArgumentsDeltaEvent>(events[1]);
        XAssert.IsType<ResponseFunctionCallArgumentsDeltaEvent>(events[2]);
        XAssert.IsType<ResponseFunctionCallArgumentsDoneEvent>(events[3]);
        XAssert.IsType<ResponseOutputItemDoneEvent>(events[4]);
    }

    [Test]
    public void OutputItemFunctionCall_Complete_DoneContainsArguments()
    {
        var stream = CreateStream();

        var events = stream.OutputItemFunctionCall("get_weather", "call_1", "{\"city\":\"NYC\"}").ToList();

        var done = XAssert.IsType<ResponseOutputItemDoneEvent>(events[3]);
        var fc = XAssert.IsType<OutputItemFunctionToolCall>(done.Item);
        Assert.That(fc.Arguments, Is.EqualTo("{\"city\":\"NYC\"}"));
        Assert.That(fc.Name, Is.EqualTo("get_weather"));
        Assert.That(fc.CallId, Is.EqualTo("call_1"));
    }

    // ──────────────────────────────────────────────────────────
    //  S-056: Output-Item Convenience – FunctionCallOutput
    // ──────────────────────────────────────────────────────────

    [Test]
    public void OutputItemFunctionCallOutput_EmitsAddedAndDone()
    {
        var stream = CreateStream();
        var output = BinaryData.FromString("\"72 degrees\"");

        var events = stream.OutputItemFunctionCallOutput("call_1", output).ToList();

        Assert.That(events, Has.Count.EqualTo(2));
        XAssert.IsType<ResponseOutputItemAddedEvent>(events[0]);
        XAssert.IsType<ResponseOutputItemDoneEvent>(events[1]);
    }

    [Test]
    public void OutputItemFunctionCallOutput_DoneContainsCallIdAndOutput()
    {
        var stream = CreateStream();
        var output = BinaryData.FromString("\"72 degrees\"");

        var events = stream.OutputItemFunctionCallOutput("call_1", output).ToList();

        var done = XAssert.IsType<ResponseOutputItemDoneEvent>(events[1]);
        var fco = XAssert.IsType<FunctionToolCallOutputResource>(done.Item);
        Assert.That(fco.CallId, Is.EqualTo("call_1"));
        Assert.That(fco.Output.ToString(), Is.EqualTo("\"72 degrees\""));
    }

    // ──────────────────────────────────────────────────────────
    //  S-056: Output-Item Convenience – ReasoningItem
    // ──────────────────────────────────────────────────────────

    [Test]
    public void OutputItemReasoningItem_Complete_EmitsFullLifecycle()
    {
        var stream = CreateStream();

        var events = stream.OutputItemReasoningItem("Thinking deeply").ToList();

        // output_item.added → summary_part.added → text.delta → text.done → summary_part.done → output_item.done
        Assert.That(events, Has.Count.EqualTo(6));
        XAssert.IsType<ResponseOutputItemAddedEvent>(events[0]);
        XAssert.IsType<ResponseReasoningSummaryPartAddedEvent>(events[1]);
        XAssert.IsType<ResponseReasoningSummaryTextDeltaEvent>(events[2]);
        XAssert.IsType<ResponseReasoningSummaryTextDoneEvent>(events[3]);
        XAssert.IsType<ResponseReasoningSummaryPartDoneEvent>(events[4]);
        XAssert.IsType<ResponseOutputItemDoneEvent>(events[5]);
    }

    [Test]
    public async Task OutputItemReasoningItem_Streaming_EmitsFullLifecycle()
    {
        var stream = CreateStream();

        var events = await CollectAsync(stream.OutputItemReasoningItem(
            ToAsync("Think", "ing"), default));

        // output_item.added → summary_part.added → delta × 2 → text.done → summary_part.done → output_item.done
        Assert.That(events, Has.Count.EqualTo(7));
        XAssert.IsType<ResponseOutputItemAddedEvent>(events[0]);
        XAssert.IsType<ResponseReasoningSummaryPartAddedEvent>(events[1]);
        XAssert.IsType<ResponseReasoningSummaryTextDeltaEvent>(events[2]);
        XAssert.IsType<ResponseReasoningSummaryTextDeltaEvent>(events[3]);
        XAssert.IsType<ResponseReasoningSummaryTextDoneEvent>(events[4]);
        XAssert.IsType<ResponseReasoningSummaryPartDoneEvent>(events[5]);
        XAssert.IsType<ResponseOutputItemDoneEvent>(events[6]);
    }

    // ──────────────────────────────────────────────────────────
    //  S-060: MCP Terminal State Tracking
    // ──────────────────────────────────────────────────────────

    [Test]
    public void McpCall_EmitCompleted_DoneUsesCompletedStatus()
    {
        var stream = CreateStream();
        var mcp = stream.AddOutputItemMcpCall("srv", "tool");
        mcp.EmitAdded();
        mcp.EmitArgumentsDone("{}");
        mcp.EmitCompleted();

        var done = mcp.EmitDone();

        var item = XAssert.IsType<OutputItemMcpToolCall>(done.Item);
        Assert.That(item.Status, Is.EqualTo(MCPToolCallStatus.Completed));
    }

    [Test]
    public void McpCall_EmitFailed_DoneUsesFailedStatus()
    {
        var stream = CreateStream();
        var mcp = stream.AddOutputItemMcpCall("srv", "tool");
        mcp.EmitAdded();
        mcp.EmitArgumentsDone("{}");
        mcp.EmitFailed();

        var done = mcp.EmitDone();

        var item = XAssert.IsType<OutputItemMcpToolCall>(done.Item);
        Assert.That(item.Status, Is.EqualTo(MCPToolCallStatus.Failed));
    }

    [Test]
    public void McpCall_NoTerminalEvent_DoneDefaultsToCompleted()
    {
        var stream = CreateStream();
        var mcp = stream.AddOutputItemMcpCall("srv", "tool");
        mcp.EmitAdded();
        mcp.EmitArgumentsDone("{}");

        var done = mcp.EmitDone();

        var item = XAssert.IsType<OutputItemMcpToolCall>(done.Item);
        Assert.That(item.Status, Is.EqualTo(MCPToolCallStatus.Completed));
    }

    // ──────────────────────────────────────────────────────────
    //  S-057: Naming convention – output-item factory ↔ convenience
    // ──────────────────────────────────────────────────────────

    [Test]
    public void OutputItemConveniences_IncrementOutputIndex()
    {
        var stream = CreateStream();

        // Each output-item convenience should consume an output index
        _ = stream.OutputItemMessage("hi").ToList();           // index 0
        _ = stream.OutputItemFunctionCall("fn", "c1", "{}").ToList(); // index 1
        _ = stream.OutputItemFunctionCallOutput("c2", BinaryData.FromString("\"ok\"")).ToList(); // index 2
        _ = stream.OutputItemReasoningItem("think").ToList();   // index 3

        // The next factory should get index 4
        var next = stream.AddOutputItemMessage();
        Assert.That(next.OutputIndex, Is.EqualTo(4));
    }

    // ──────────────────────────────────────────────────────────
    //  S-054/S-055: Sequence numbers increment correctly
    // ──────────────────────────────────────────────────────────

    [Test]
    public void OutputItemMessage_SequenceNumbersAreMonotonic()
    {
        var stream = CreateStream();

        var events = stream.OutputItemMessage("hi").ToList();

        for (int i = 1; i < events.Count; i++)
        {
            Assert.That(events[i].SequenceNumber, Is.GreaterThan(events[i - 1].SequenceNumber),
                $"Event {i} should have a greater sequence number than event {i - 1}");
        }
    }

    // ═══════════════════════════════════════════════════════════════════
    //  S-056: Output-Item Convenience – ImageGenCall
    // ═══════════════════════════════════════════════════════════════════

    [Test]
    public void OutputItemImageGenCall_String_ProducesCompleteLifecycle()
    {
        var context = new ResponseContext("resp_test");
        var stream = new ResponseEventStream(context, new CreateResponse { Model = "m" });
        var resultBase64 = Convert.ToBase64String(new byte[] { 0x89, 0x50, 0x4E, 0x47 });

        var events = stream.OutputItemImageGenCall(resultBase64).ToList();

        Assert.That(events, Has.Count.EqualTo(5));
        XAssert.IsType<ResponseOutputItemAddedEvent>(events[0]);
        XAssert.IsType<ResponseImageGenCallInProgressEvent>(events[1]);
        XAssert.IsType<ResponseImageGenCallGeneratingEvent>(events[2]);
        XAssert.IsType<ResponseImageGenCallCompletedEvent>(events[3]);
        var done = XAssert.IsType<ResponseOutputItemDoneEvent>(events[4]);
        var item = XAssert.IsType<OutputItemImageGenToolCall>(done.Item);
        Assert.That(item.Status, Is.EqualTo(OutputItemImageGenToolCallStatus.Completed));
        Assert.That(item.Result, Is.EqualTo(resultBase64));
    }

    [Test]
    public void OutputItemImageGenCall_SequenceNumbersAreMonotonic()
    {
        var context = new ResponseContext("resp_test");
        var stream = new ResponseEventStream(context, new CreateResponse { Model = "m" });

        var events = stream.OutputItemImageGenCall("dGVzdA==").ToList();

        for (int i = 1; i < events.Count; i++)
        {
            Assert.That(events[i].SequenceNumber, Is.GreaterThan(events[i - 1].SequenceNumber),
                $"Event {i} should have a greater sequence number than event {i - 1}");
        }
    }

    [Test]
    public void OutputItemStructuredOutputs_ProducesCompleteLifecycle()
    {
        var context = new ResponseContext("resp_test");
        var stream = new ResponseEventStream(context, new CreateResponse { Model = "m" });
        var payload = BinaryData.FromObjectAsJson(new { score = 42 });

        var events = stream.OutputItemStructuredOutputs(payload).ToList();

        Assert.That(events, Has.Count.EqualTo(2));
        var added = XAssert.IsType<ResponseOutputItemAddedEvent>(events[0]);
        var addedItem = XAssert.IsType<StructuredOutputsOutputItem>(added.Item);
        Assert.That(addedItem.Output.ToString(), Does.Contain("42"));
        Assert.That(addedItem.Id, Does.StartWith("fco_"));

        var done = XAssert.IsType<ResponseOutputItemDoneEvent>(events[1]);
        var doneItem = XAssert.IsType<StructuredOutputsOutputItem>(done.Item);
        Assert.That(doneItem.Output.ToString(), Does.Contain("42"));
    }

    [Test]
    public void OutputItemStructuredOutputs_SequenceNumbersAreMonotonic()
    {
        var context = new ResponseContext("resp_test");
        var stream = new ResponseEventStream(context, new CreateResponse { Model = "m" });
        var payload = BinaryData.FromObjectAsJson(new { value = "test" });

        var events = stream.OutputItemStructuredOutputs(payload).ToList();

        for (int i = 1; i < events.Count; i++)
        {
            Assert.That(events[i].SequenceNumber, Is.GreaterThan(events[i - 1].SequenceNumber),
                $"Event {i} should have a greater sequence number than event {i - 1}");
        }
    }

    // ── Helpers ──────────────────────────────────────────────

    private static async Task<List<ResponseStreamEvent>> CollectAsync(
        IAsyncEnumerable<ResponseStreamEvent> source)
    {
        var events = new List<ResponseStreamEvent>();
        await foreach (var e in source)
        {
            events.Add(e);
        }
        return events;
    }

    private static async IAsyncEnumerable<string> ToAsync(params string[] chunks)
    {
        foreach (var chunk in chunks)
        {
            await Task.Yield();
            yield return chunk;
        }
    }
}
