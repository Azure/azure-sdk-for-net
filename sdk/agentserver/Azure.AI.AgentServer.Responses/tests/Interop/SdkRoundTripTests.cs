// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// SDK → Server → SDK round-trip compliance tests.
// Each test uses the OpenAI SDK to construct a request, sends it through our
// server with a custom handler that emits specific output items using our
// builder API, then reads the response back through the OpenAI SDK and asserts
// all fields survived the round trip.
//
// When a test fails, FIX THE SERVICE — do not change the test.

#pragma warning disable OPENAI001 // Responses API is experimental in the OpenAI SDK
#pragma warning disable OPENAICUA001 // Computer use API is experimental

using System.ClientModel;
using System.ClientModel.Primitives;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using Azure.AI.AgentServer.Responses.Models;
using Azure.AI.AgentServer.Responses.Tests.Helpers;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using OpenAI;
using OpenAI.Responses;

// Disambiguate shared type names
using AzureMessageRole = Azure.AI.AgentServer.Responses.Models.MessageRole;
using SdkResponseStatus = OpenAI.Responses.ResponseStatus;

namespace Azure.AI.AgentServer.Responses.Tests.Interop;

/// <summary>
/// Full SDK → Server → SDK round-trip tests.
///
/// Pattern for each test:
///   1. Create a <see cref="TestWebApplicationFactory"/> with a custom handler
///      that emits the output item type under test using our builder API.
///   2. Create an OpenAI <see cref="ResponsesClient"/> pointing at the test server.
///   3. Call <see cref="ResponsesClient.CreateResponseAsync"/> (non-streaming) or
///      <see cref="ResponsesClient.CreateResponseStreamingAsync"/> (streaming).
///   4. Assert the SDK-parsed <see cref="ResponseResult"/> has the expected types and values.
///
/// This validates that our builders produce JSON the OpenAI SDK can parse.
/// </summary>
[TestFixture]
public class SdkRoundTripTests
{
    // ═══════════════════════════════════════════════════════════════════
    //  OUTPUT: Text message (non-streaming)
    // ═══════════════════════════════════════════════════════════════════

    [Test]
    public async Task Output_TextMessage_RoundTrips()
    {
        var result = await CallWithHandler(EmitTextMessage("Hello from round trip!"));

        Assert.That(result.Status, Is.EqualTo(SdkResponseStatus.Completed));
        Assert.That(result.OutputItems, Has.Count.EqualTo(1));
        var msg = XAssert.IsAssignableFrom<MessageResponseItem>(result.OutputItems[0]);
        Assert.That(msg.Role, Is.EqualTo(OpenAI.Responses.MessageRole.Assistant));
        Assert.That(msg.Content, Has.Count.EqualTo(1));
        Assert.That(msg.Content[0].Text, Is.EqualTo("Hello from round trip!"));
    }

    // ═══════════════════════════════════════════════════════════════════
    //  OUTPUT: Text message (streaming)
    // ═══════════════════════════════════════════════════════════════════

    [Test]
    public async Task Output_TextMessage_Streaming_RoundTrips()
    {
        var updates = await StreamWithHandler(EmitTextMessage("Streamed!"));

        var deltas = updates.OfType<StreamingResponseOutputTextDeltaUpdate>().ToList();
        Assert.That(deltas, Has.Count.GreaterThan(0));
        var fullText = string.Join("", deltas.Select(d => d.Delta));
        Assert.That(fullText, Is.EqualTo("Streamed!"));

        var completed = updates.OfType<StreamingResponseCompletedUpdate>().ToList();
        Assert.That(completed, Has.Count.EqualTo(1));
    }

    // ═══════════════════════════════════════════════════════════════════
    //  OUTPUT: Function call
    // ═══════════════════════════════════════════════════════════════════

    [Test]
    public async Task Output_FunctionCall_RoundTrips()
    {
        var result = await CallWithHandler(EmitFunctionCall("get_weather", "call_001", """{"city":"Seattle"}"""));

        Assert.That(result.OutputItems, Has.Count.EqualTo(1));
        var fc = XAssert.IsAssignableFrom<FunctionCallResponseItem>(result.OutputItems[0]);
        Assert.That(fc.FunctionName, Is.EqualTo("get_weather"));
        Assert.That(fc.CallId, Is.EqualTo("call_001"));
        Assert.That(fc.FunctionArguments.ToString(), Is.EqualTo("""{"city":"Seattle"}"""));
    }

    [Test]
    public async Task Output_FunctionCall_Streaming_RoundTrips()
    {
        var updates = await StreamWithHandler(EmitFunctionCall("get_weather", "call_002", """{"city":"NYC"}"""));

        var argDeltas = updates.OfType<StreamingResponseFunctionCallArgumentsDeltaUpdate>().ToList();
        Assert.That(argDeltas, Has.Count.GreaterThan(0));

        var doneUpdates = updates.OfType<StreamingResponseOutputItemDoneUpdate>().ToList();
        Assert.That(doneUpdates, Has.Count.EqualTo(1));
    }

    // ═══════════════════════════════════════════════════════════════════
    //  OUTPUT: Reasoning item
    // ═══════════════════════════════════════════════════════════════════

    [Test]
    public async Task Output_Reasoning_RoundTrips()
    {
        var result = await CallWithHandler(EmitReasoning("Step 1: analyze the data"));

        Assert.That(result.OutputItems, Has.Count.EqualTo(1));
        var reasoning = XAssert.IsAssignableFrom<ReasoningResponseItem>(result.OutputItems[0]);
        Assert.That(reasoning.SummaryParts, Has.Count.EqualTo(1));
        var textPart = XAssert.IsAssignableFrom<ReasoningSummaryTextPart>(reasoning.SummaryParts[0]);
        Assert.That(textPart.Text, Is.EqualTo("Step 1: analyze the data"));
    }

    [Test]
    public async Task Output_Reasoning_Streaming_RoundTrips()
    {
        var updates = await StreamWithHandler(EmitReasoning("Thinking..."));

        var summaryDeltas = updates.OfType<StreamingResponseReasoningSummaryTextDeltaUpdate>().ToList();
        Assert.That(summaryDeltas, Has.Count.GreaterThan(0));

        var doneUpdates = updates.OfType<StreamingResponseOutputItemDoneUpdate>().ToList();
        Assert.That(doneUpdates, Has.Count.EqualTo(1));
    }

    // ═══════════════════════════════════════════════════════════════════
    //  OUTPUT: File search call
    // ═══════════════════════════════════════════════════════════════════

    [Test]
    public async Task Output_FileSearchCall_RoundTrips()
    {
        var result = await CallWithHandler(EmitFileSearchCall());

        Assert.That(result.OutputItems, Has.Count.EqualTo(1));
        var fs = XAssert.IsAssignableFrom<FileSearchCallResponseItem>(result.OutputItems[0]);
        Assert.That(fs.Id, Does.StartWith("fs_"));
    }

    // ═══════════════════════════════════════════════════════════════════
    //  OUTPUT: Web search call
    // ═══════════════════════════════════════════════════════════════════

    [Test]
    public async Task Output_WebSearchCall_RoundTrips()
    {
        var result = await CallWithHandler(EmitWebSearchCall());

        Assert.That(result.OutputItems, Has.Count.EqualTo(1));
        var ws = XAssert.IsAssignableFrom<WebSearchCallResponseItem>(result.OutputItems[0]);
        Assert.That(ws.Id, Does.StartWith("ws_"));
    }

    // ═══════════════════════════════════════════════════════════════════
    //  OUTPUT: Code interpreter call
    // ═══════════════════════════════════════════════════════════════════

    [Test]
    public async Task Output_CodeInterpreterCall_RoundTrips()
    {
        var result = await CallWithHandler(EmitCodeInterpreterCall("print('hello')"));

        Assert.That(result.OutputItems, Has.Count.EqualTo(1));
        var ci = XAssert.IsAssignableFrom<CodeInterpreterCallResponseItem>(result.OutputItems[0]);
        Assert.That(ci.Code, Is.EqualTo("print('hello')"));
    }

    [Test]
    public async Task Output_CodeInterpreterCall_Streaming_RoundTrips()
    {
        var updates = await StreamWithHandler(EmitCodeInterpreterCall("import math"));

        var codeDeltas = updates.OfType<StreamingResponseCodeInterpreterCallCodeDeltaUpdate>().ToList();
        Assert.That(codeDeltas, Has.Count.GreaterThan(0));
    }

    // ═══════════════════════════════════════════════════════════════════
    //  OUTPUT: Image generation call
    // ═══════════════════════════════════════════════════════════════════

    [Test]
    public async Task Output_ImageGenCall_RoundTrips()
    {
        var result = await CallWithHandler(EmitImageGenCall());

        Assert.That(result.OutputItems, Has.Count.EqualTo(1));
        var ig = XAssert.IsAssignableFrom<ImageGenerationCallResponseItem>(result.OutputItems[0]);
        Assert.That(ig.Id, Does.StartWith("ig_"));
    }

    // ═══════════════════════════════════════════════════════════════════
    //  OUTPUT: MCP tool call
    // ═══════════════════════════════════════════════════════════════════

    [Test]
    public async Task Output_McpCall_RoundTrips()
    {
        var result = await CallWithHandler(EmitMcpCall("db_server", "query_data", """{"sql":"SELECT 1"}"""));

        Assert.That(result.OutputItems, Has.Count.EqualTo(1));
        var mcp = XAssert.IsAssignableFrom<McpToolCallItem>(result.OutputItems[0]);
        Assert.That(mcp.ServerLabel, Is.EqualTo("db_server"));
        Assert.That(mcp.ToolName, Is.EqualTo("query_data"));
    }

    // ═══════════════════════════════════════════════════════════════════
    //  OUTPUT: MCP list tools
    // ═══════════════════════════════════════════════════════════════════

    [Test]
    public async Task Output_McpListTools_RoundTrips()
    {
        var result = await CallWithHandler(EmitMcpListTools("my_server"));

        Assert.That(result.OutputItems, Has.Count.EqualTo(1));
        var list = XAssert.IsAssignableFrom<McpToolDefinitionListItem>(result.OutputItems[0]);
        Assert.That(list.ServerLabel, Is.EqualTo("my_server"));
    }

    // ═══════════════════════════════════════════════════════════════════
    //  OUTPUT: Multiple output items in one response
    // ═══════════════════════════════════════════════════════════════════

    [Test]
    public async Task Output_MultipleItems_AllRoundTrip()
    {
        var result = await CallWithHandler(EmitMultipleItems());

        // reasoning + function_call + message
        Assert.That(result.OutputItems, Has.Count.EqualTo(3));
        XAssert.IsAssignableFrom<ReasoningResponseItem>(result.OutputItems[0]);
        XAssert.IsAssignableFrom<FunctionCallResponseItem>(result.OutputItems[1]);
        XAssert.IsAssignableFrom<MessageResponseItem>(result.OutputItems[2]);
    }

    [Test]
    public async Task Output_MultipleItems_Streaming_AllRoundTrip()
    {
        var updates = await StreamWithHandler(EmitMultipleItems());

        var addedUpdates = updates.OfType<StreamingResponseOutputItemAddedUpdate>().ToList();
        Assert.That(addedUpdates, Has.Count.EqualTo(3));

        var doneUpdates = updates.OfType<StreamingResponseOutputItemDoneUpdate>().ToList();
        Assert.That(doneUpdates, Has.Count.EqualTo(3));

        var completed = updates.OfType<StreamingResponseCompletedUpdate>().ToList();
        Assert.That(completed, Has.Count.EqualTo(1));
    }

    // ═══════════════════════════════════════════════════════════════════
    //  INPUT: SDK-constructed request → server parses it
    // ═══════════════════════════════════════════════════════════════════

    [Test]
    public async Task Input_SdkMessage_ServerReceives()
    {
        CreateResponse? captured = null;
        var handler = new TestHandler
        {
            EventFactory = (req, ctx, ct) =>
            {
                captured = req;
                return EmitTextMessage("ok")(req, ctx, ct);
            }
        };

        await CallWithCustomHandler(handler, opts =>
        {
            opts.InputItems.Add(ResponseItem.CreateUserMessageItem(
                [ResponseContentPart.CreateInputTextPart("Hello from SDK")]));
        });

        Assert.That(captured, Is.Not.Null);
        var items = captured!.GetInputExpanded();
        Assert.That(items, Has.Count.EqualTo(1));
        var msg = XAssert.IsType<ItemMessage>(items[0]);
        Assert.That(msg.Role, Is.EqualTo(AzureMessageRole.User));
        var content = msg.GetContentExpanded();
        Assert.That(content, Has.Count.EqualTo(1));
        var text = XAssert.IsType<MessageContentInputTextContent>(content[0]);
        Assert.That(text.Text, Is.EqualTo("Hello from SDK"));
    }

    [Test]
    public async Task Input_SdkFunctionCallOutput_ServerReceives()
    {
        CreateResponse? captured = null;
        var handler = new TestHandler
        {
            EventFactory = (req, ctx, ct) =>
            {
                captured = req;
                return EmitTextMessage("ok")(req, ctx, ct);
            }
        };

        await CallWithCustomHandler(handler, opts =>
        {
            opts.InputItems.Add(ResponseItem.CreateFunctionCallOutputItem("call_sdk_001", "72 degrees"));
        });

        Assert.That(captured, Is.Not.Null);
        var items = captured!.GetInputExpanded();
        Assert.That(items, Has.Count.EqualTo(1));
        var fco = XAssert.IsType<FunctionCallOutputItemParam>(items[0]);
        Assert.That(fco.CallId, Is.EqualTo("call_sdk_001"));
    }

    [Test]
    public async Task Input_SdkMultipleItems_ServerReceives()
    {
        CreateResponse? captured = null;
        var handler = new TestHandler
        {
            EventFactory = (req, ctx, ct) =>
            {
                captured = req;
                return EmitTextMessage("ok")(req, ctx, ct);
            }
        };

        await CallWithCustomHandler(handler, opts =>
        {
            opts.InputItems.Add(ResponseItem.CreateUserMessageItem(
                [ResponseContentPart.CreateInputTextPart("question")]));
            opts.InputItems.Add(ResponseItem.CreateFunctionCallItem("call_1", "fn", BinaryData.FromString("{}")));
            opts.InputItems.Add(ResponseItem.CreateFunctionCallOutputItem("call_1", "result"));
        });

        Assert.That(captured, Is.Not.Null);
        var items = captured!.GetInputExpanded();
        Assert.That(items, Has.Count.EqualTo(3));
        XAssert.IsType<ItemMessage>(items[0]);
        XAssert.IsType<ItemFunctionToolCall>(items[1]);
        XAssert.IsType<FunctionCallOutputItemParam>(items[2]);
    }

    // ═══════════════════════════════════════════════════════════════════
    //  INPUT: SDK properties round-trip to server
    // ═══════════════════════════════════════════════════════════════════

    [Test]
    public async Task Input_SdkRequestProperties_ServerReceives()
    {
        CreateResponse? captured = null;
        var handler = new TestHandler
        {
            EventFactory = (req, ctx, ct) =>
            {
                captured = req;
                return EmitTextMessage("ok")(req, ctx, ct);
            }
        };

        await CallWithCustomHandler(handler, opts =>
        {
            opts.Instructions = "Be helpful";
            opts.Temperature = 0.7f;
            opts.TopP = 0.9f;
            opts.MaxOutputTokenCount = 1024;
        });

        Assert.That(captured, Is.Not.Null);
        Assert.That(captured!.Instructions, Is.EqualTo("Be helpful"));
        Assert.That(captured.Temperature, Is.EqualTo(0.7f).Within(0.01f));
        Assert.That(captured.TopP, Is.EqualTo(0.9f).Within(0.01f));
        Assert.That(captured.MaxOutputTokens, Is.EqualTo(1024));  // Server model uses MaxOutputTokens
    }

    // ═══════════════════════════════════════════════════════════════════
    //  FULL ROUND TRIP: SDK input → server handler → SDK output
    // ═══════════════════════════════════════════════════════════════════

    [Test]
    public async Task FullRoundTrip_SdkInput_FunctionCall_SdkOutput()
    {
        // Simulates: user asks a question → server returns a function call
        var result = await CallWithCustomHandler(
            new TestHandler
            {
                EventFactory = EmitFunctionCall("get_weather", "call_rt_001", """{"city":"London"}""")
            },
            opts =>
            {
                opts.InputItems.Add(ResponseItem.CreateUserMessageItem(
                    [ResponseContentPart.CreateInputTextPart("What's the weather in London?")]));
            });

        Assert.That(result.Status, Is.EqualTo(SdkResponseStatus.Completed));
        Assert.That(result.OutputItems, Has.Count.EqualTo(1));
        var fc = XAssert.IsAssignableFrom<FunctionCallResponseItem>(result.OutputItems[0]);
        Assert.That(fc.FunctionName, Is.EqualTo("get_weather"));
        Assert.That(fc.CallId, Is.EqualTo("call_rt_001"));
    }

    [Test]
    public async Task FullRoundTrip_SdkInput_Streaming_TextResponse()
    {
        // Simulates: user sends message → server streams back text
        var updates = await StreamWithCustomHandler(
            new TestHandler
            {
                EventFactory = EmitTextMessage("The weather is sunny!")
            },
            opts =>
            {
                opts.InputItems.Add(ResponseItem.CreateUserMessageItem(
                    [ResponseContentPart.CreateInputTextPart("What's the weather?")]));
            });

        var deltas = updates.OfType<StreamingResponseOutputTextDeltaUpdate>().ToList();
        var fullText = string.Join("", deltas.Select(d => d.Delta));
        Assert.That(fullText, Is.EqualTo("The weather is sunny!"));
    }

    [Test]
    public async Task FullRoundTrip_MultiTurn_FunctionCallThenResponse()
    {
        // Turn 1 input: user message + function call + function output
        // Turn 1 output: assistant text response
        var result = await CallWithCustomHandler(
            new TestHandler
            {
                EventFactory = EmitTextMessage("The weather in Seattle is 72°F and sunny.")
            },
            opts =>
            {
                opts.InputItems.Add(ResponseItem.CreateUserMessageItem(
                    [ResponseContentPart.CreateInputTextPart("What's the weather?")]));
                opts.InputItems.Add(ResponseItem.CreateFunctionCallItem("call_mt", "get_weather", BinaryData.FromString("""{"city":"Seattle"}""")));
                opts.InputItems.Add(ResponseItem.CreateFunctionCallOutputItem("call_mt", "72°F and sunny"));
            });

        Assert.That(result.OutputItems, Has.Count.EqualTo(1));
        var msg = XAssert.IsAssignableFrom<MessageResponseItem>(result.OutputItems[0]);
        Assert.That(msg.Content[0].Text, Is.EqualTo("The weather in Seattle is 72°F and sunny."));
    }

    // ═══════════════════════════════════════════════════════════════════
    //  RESPONSE OBJECT PROPERTIES
    // ═══════════════════════════════════════════════════════════════════

    [Test]
    public async Task ResponseObject_HasRequiredFields()
    {
        var result = await CallWithHandler(EmitTextMessage("test"));

        Assert.That(result.Id, Is.Not.Null.And.Not.Empty);
        Assert.That(result.Model, Is.EqualTo("test-model"));
        Assert.That(result.Status, Is.EqualTo(SdkResponseStatus.Completed));
        Assert.That(result.CreatedAt, Is.GreaterThan(default(DateTimeOffset)));
    }

    [Test]
    public async Task ResponseObject_Model_PreservedFromRequest()
    {
        var result = await CallWithHandler(EmitTextMessage("test"), model: "my-fancy-model");

        Assert.That(result.Model, Is.EqualTo("my-fancy-model"));
    }

    // ═══════════════════════════════════════════════════════════════════
    //  Handler factories — produce event streams via builder API
    // ═══════════════════════════════════════════════════════════════════

    private static Func<CreateResponse, ResponseContext, CancellationToken, IAsyncEnumerable<ResponseStreamEvent>>
        EmitTextMessage(string text)
    {
        return (req, ctx, ct) => EmitTextMessageCore(req, ctx, text);
    }

    private static async IAsyncEnumerable<ResponseStreamEvent> EmitTextMessageCore(
        CreateResponse req, ResponseContext ctx, string text)
    {
        var stream = new ResponseEventStream(ctx, req);
        yield return stream.EmitCreated();
        yield return stream.EmitInProgress();

        var msg = stream.AddOutputItemMessage();
        yield return msg.EmitAdded();

        var tc = msg.AddTextContent();
        yield return tc.EmitAdded();
        yield return tc.EmitDelta(text);
        yield return tc.EmitDone(text);
        yield return msg.EmitContentDone(tc);
        yield return msg.EmitDone();

        yield return stream.EmitCompleted();
        await Task.CompletedTask;
    }

    private static Func<CreateResponse, ResponseContext, CancellationToken, IAsyncEnumerable<ResponseStreamEvent>>
        EmitFunctionCall(string name, string callId, string arguments)
    {
        return (req, ctx, ct) => EmitFunctionCallCore(req, ctx, name, callId, arguments);
    }

    private static async IAsyncEnumerable<ResponseStreamEvent> EmitFunctionCallCore(
        CreateResponse req, ResponseContext ctx, string name, string callId, string arguments)
    {
        var stream = new ResponseEventStream(ctx, req);
        yield return stream.EmitCreated();
        yield return stream.EmitInProgress();

        var fc = stream.AddOutputItemFunctionCall(name, callId);
        yield return fc.EmitAdded();
        yield return fc.EmitArgumentsDelta(arguments);
        yield return fc.EmitArgumentsDone(arguments);
        yield return fc.EmitDone();

        yield return stream.EmitCompleted();
        await Task.CompletedTask;
    }

    private static Func<CreateResponse, ResponseContext, CancellationToken, IAsyncEnumerable<ResponseStreamEvent>>
        EmitReasoning(string summaryText)
    {
        return (req, ctx, ct) => EmitReasoningCore(req, ctx, summaryText);
    }

    private static async IAsyncEnumerable<ResponseStreamEvent> EmitReasoningCore(
        CreateResponse req, ResponseContext ctx, string summaryText)
    {
        var stream = new ResponseEventStream(ctx, req);
        yield return stream.EmitCreated();
        yield return stream.EmitInProgress();

        var reasoning = stream.AddOutputItemReasoningItem();
        yield return reasoning.EmitAdded();

        var part = reasoning.AddSummaryPart();
        yield return part.EmitAdded();
        yield return part.EmitTextDelta(summaryText);
        yield return part.EmitTextDone(summaryText);
        yield return part.EmitDone();
        reasoning.EmitSummaryPartDone(part);
        yield return reasoning.EmitDone();

        yield return stream.EmitCompleted();
        await Task.CompletedTask;
    }

    private static Func<CreateResponse, ResponseContext, CancellationToken, IAsyncEnumerable<ResponseStreamEvent>>
        EmitFileSearchCall()
    {
        return (req, ctx, ct) => EmitFileSearchCallCore(req, ctx);
    }

    private static async IAsyncEnumerable<ResponseStreamEvent> EmitFileSearchCallCore(
        CreateResponse req, ResponseContext ctx)
    {
        var stream = new ResponseEventStream(ctx, req);
        yield return stream.EmitCreated();
        yield return stream.EmitInProgress();

        var fs = stream.AddOutputItemFileSearchCall();
        yield return fs.EmitAdded();
        yield return fs.EmitInProgress();
        yield return fs.EmitSearching();
        yield return fs.EmitCompleted();
        yield return fs.EmitDone();

        yield return stream.EmitCompleted();
        await Task.CompletedTask;
    }

    private static Func<CreateResponse, ResponseContext, CancellationToken, IAsyncEnumerable<ResponseStreamEvent>>
        EmitWebSearchCall()
    {
        return (req, ctx, ct) => EmitWebSearchCallCore(req, ctx);
    }

    private static async IAsyncEnumerable<ResponseStreamEvent> EmitWebSearchCallCore(
        CreateResponse req, ResponseContext ctx)
    {
        var stream = new ResponseEventStream(ctx, req);
        yield return stream.EmitCreated();
        yield return stream.EmitInProgress();

        var ws = stream.AddOutputItemWebSearchCall();
        yield return ws.EmitAdded();
        yield return ws.EmitInProgress();
        yield return ws.EmitSearching();
        yield return ws.EmitCompleted();
        yield return ws.EmitDone();

        yield return stream.EmitCompleted();
        await Task.CompletedTask;
    }

    private static Func<CreateResponse, ResponseContext, CancellationToken, IAsyncEnumerable<ResponseStreamEvent>>
        EmitCodeInterpreterCall(string code)
    {
        return (req, ctx, ct) => EmitCodeInterpreterCallCore(req, ctx, code);
    }

    private static async IAsyncEnumerable<ResponseStreamEvent> EmitCodeInterpreterCallCore(
        CreateResponse req, ResponseContext ctx, string code)
    {
        var stream = new ResponseEventStream(ctx, req);
        yield return stream.EmitCreated();
        yield return stream.EmitInProgress();

        var ci = stream.AddOutputItemCodeInterpreterCall();
        yield return ci.EmitAdded();
        yield return ci.EmitInProgress();
        yield return ci.EmitInterpreting();
        yield return ci.EmitCodeDelta(code);
        yield return ci.EmitCodeDone(code);
        yield return ci.EmitCompleted();
        yield return ci.EmitDone();

        yield return stream.EmitCompleted();
        await Task.CompletedTask;
    }

    private static Func<CreateResponse, ResponseContext, CancellationToken, IAsyncEnumerable<ResponseStreamEvent>>
        EmitImageGenCall()
    {
        return (req, ctx, ct) => EmitImageGenCallCore(req, ctx);
    }

    private static async IAsyncEnumerable<ResponseStreamEvent> EmitImageGenCallCore(
        CreateResponse req, ResponseContext ctx)
    {
        var stream = new ResponseEventStream(ctx, req);
        yield return stream.EmitCreated();
        yield return stream.EmitInProgress();

        var ig = stream.AddOutputItemImageGenCall();
        yield return ig.EmitAdded();
        yield return ig.EmitInProgress();
        yield return ig.EmitGenerating();
        yield return ig.EmitCompleted();
        yield return ig.EmitDone("dGVzdC1pbWFnZS1kYXRh");

        yield return stream.EmitCompleted();
        await Task.CompletedTask;
    }

    private static Func<CreateResponse, ResponseContext, CancellationToken, IAsyncEnumerable<ResponseStreamEvent>>
        EmitMcpCall(string serverLabel, string name, string arguments)
    {
        return (req, ctx, ct) => EmitMcpCallCore(req, ctx, serverLabel, name, arguments);
    }

    private static async IAsyncEnumerable<ResponseStreamEvent> EmitMcpCallCore(
        CreateResponse req, ResponseContext ctx, string serverLabel, string name, string arguments)
    {
        var stream = new ResponseEventStream(ctx, req);
        yield return stream.EmitCreated();
        yield return stream.EmitInProgress();

        var mcp = stream.AddOutputItemMcpCall(serverLabel, name);
        yield return mcp.EmitAdded();
        yield return mcp.EmitInProgress();
        yield return mcp.EmitArgumentsDelta(arguments);
        yield return mcp.EmitArgumentsDone(arguments);
        yield return mcp.EmitCompleted();
        yield return mcp.EmitDone();

        yield return stream.EmitCompleted();
        await Task.CompletedTask;
    }

    private static Func<CreateResponse, ResponseContext, CancellationToken, IAsyncEnumerable<ResponseStreamEvent>>
        EmitMcpListTools(string serverLabel)
    {
        return (req, ctx, ct) => EmitMcpListToolsCore(req, ctx, serverLabel);
    }

    private static async IAsyncEnumerable<ResponseStreamEvent> EmitMcpListToolsCore(
        CreateResponse req, ResponseContext ctx, string serverLabel)
    {
        var stream = new ResponseEventStream(ctx, req);
        yield return stream.EmitCreated();
        yield return stream.EmitInProgress();

        var list = stream.AddOutputItemMcpListTools(serverLabel);
        yield return list.EmitAdded();
        yield return list.EmitInProgress();
        yield return list.EmitCompleted();
        yield return list.EmitDone();

        yield return stream.EmitCompleted();
        await Task.CompletedTask;
    }

    private static Func<CreateResponse, ResponseContext, CancellationToken, IAsyncEnumerable<ResponseStreamEvent>>
        EmitMultipleItems()
    {
        return (req, ctx, ct) => EmitMultipleItemsCore(req, ctx);
    }

    private static async IAsyncEnumerable<ResponseStreamEvent> EmitMultipleItemsCore(
        CreateResponse req, ResponseContext ctx)
    {
        var stream = new ResponseEventStream(ctx, req);
        yield return stream.EmitCreated();
        yield return stream.EmitInProgress();

        // 1. Reasoning
        var reasoning = stream.AddOutputItemReasoningItem();
        yield return reasoning.EmitAdded();
        var sp = reasoning.AddSummaryPart();
        yield return sp.EmitAdded();
        yield return sp.EmitTextDone("Thinking about the answer...");
        yield return sp.EmitDone();
        reasoning.EmitSummaryPartDone(sp);
        yield return reasoning.EmitDone();

        // 2. Function call
        var fc = stream.AddOutputItemFunctionCall("calculate", "call_multi_001");
        yield return fc.EmitAdded();
        yield return fc.EmitArgumentsDone("""{"x":42}""");
        yield return fc.EmitDone();

        // 3. Message
        var msg = stream.AddOutputItemMessage();
        yield return msg.EmitAdded();
        var tc = msg.AddTextContent();
        yield return tc.EmitAdded();
        yield return tc.EmitDone("The answer is 42");
        yield return msg.EmitContentDone(tc);
        yield return msg.EmitDone();

        yield return stream.EmitCompleted();
        await Task.CompletedTask;
    }

    // ═══════════════════════════════════════════════════════════════════
    //  Test infrastructure
    // ═══════════════════════════════════════════════════════════════════

    /// <summary>
    /// Calls our server via the OpenAI SDK (non-streaming) using a custom handler.
    /// </summary>
    private static async Task<ResponseResult> CallWithHandler(
        Func<CreateResponse, ResponseContext, CancellationToken, IAsyncEnumerable<ResponseStreamEvent>> factory,
        string model = "test-model")
    {
        var handler = new TestHandler { EventFactory = factory };
        return await CallWithCustomHandler(handler, model: model);
    }

    /// <summary>
    /// Streams from our server via the OpenAI SDK using a custom handler.
    /// </summary>
    private static async Task<List<StreamingResponseUpdate>> StreamWithHandler(
        Func<CreateResponse, ResponseContext, CancellationToken, IAsyncEnumerable<ResponseStreamEvent>> factory,
        string model = "test-model")
    {
        var handler = new TestHandler { EventFactory = factory };
        return await StreamWithCustomHandler(handler, model: model);
    }

    private static async Task<ResponseResult> CallWithCustomHandler(
        TestHandler handler,
        Action<CreateResponseOptions>? configureOptions = null,
        string model = "test-model")
    {
        using var factory = new TestWebApplicationFactory(handler);
        var sdkClient = CreateSdkClient(factory);

        var opts = new CreateResponseOptions { Model = model };
        configureOptions?.Invoke(opts);

        // The SDK always sends stream=true under the hood for CreateResponseAsync
        var result = await sdkClient.CreateResponseAsync(opts);
        return result.Value;
    }

    private static async Task<List<StreamingResponseUpdate>> StreamWithCustomHandler(
        TestHandler handler,
        Action<CreateResponseOptions>? configureOptions = null,
        string model = "test-model")
    {
        using var factory = new TestWebApplicationFactory(handler);
        var sdkClient = CreateSdkClient(factory);

        var opts = new CreateResponseOptions { Model = model, StreamingEnabled = true };
        configureOptions?.Invoke(opts);

        var updates = new List<StreamingResponseUpdate>();
        await foreach (var update in sdkClient.CreateResponseStreamingAsync(opts))
        {
            updates.Add(update);
        }
        return updates;
    }

    private static ResponsesClient CreateSdkClient(TestWebApplicationFactory factory)
    {
        var httpClient = factory.CreateClient();
        return new ResponsesClient(
            new ApiKeyCredential("test-key"),
            new OpenAIClientOptions
            {
                Endpoint = new Uri("http://localhost"),
                Transport = new HttpClientPipelineTransport(httpClient),
            });
    }
}
