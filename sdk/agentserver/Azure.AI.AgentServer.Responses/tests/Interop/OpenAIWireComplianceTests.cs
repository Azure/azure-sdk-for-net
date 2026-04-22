// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Tests in this file define the OpenAI wire-format contract.
// When a test fails, FIX THE SERVICE — do not change the test.
// See COMPLIANCE.md for the source-of-truth specification.

#pragma warning disable OPENAI001 // Responses API is experimental in the OpenAI SDK
#pragma warning disable OPENAICUA001 // Computer use API is experimental

using System.ClientModel.Primitives;
using System.Net;
using System.Text;
using System.Text.Json;
using Azure.AI.AgentServer.Responses.Models;
using Azure.AI.AgentServer.Responses.Tests.Helpers;
using NUnit.Framework;
using OpenAI.Responses;
using CodeInterpreterTool = Azure.AI.AgentServer.Responses.Models.CodeInterpreterTool;
using FileSearchTool = Azure.AI.AgentServer.Responses.Models.FileSearchTool;
using FunctionTool = Azure.AI.AgentServer.Responses.Models.FunctionTool;
// Disambiguate types that exist in both Azure and OpenAI namespaces
using MessageRole = Azure.AI.AgentServer.Responses.Models.MessageRole;
using WebSearchPreviewTool = Azure.AI.AgentServer.Responses.Models.WebSearchPreviewTool;

namespace Azure.AI.AgentServer.Responses.Tests.Interop;

/// <summary>
/// Raw JSON wire-format compliance tests. Each test sends a JSON payload that
/// is valid per the OpenAI Responses API specification and verifies our server
/// accepts it and deserializes it correctly.
///
/// The JSON payloads match exactly what the OpenAI SDK (or any compliant client)
/// would produce. No fields are added or removed to accommodate our server.
/// </summary>
[TestFixture]
public class OpenAIWireComplianceTests
{
    // ═══════════════════════════════════════════════════════════════════
    //  GAP-01: EasyInputMessage — type is OPTIONAL (C-MSG-01)
    // ═══════════════════════════════════════════════════════════════════

    [Test]
    public async Task C_MSG_01_Message_WithoutType_AcceptedAsMessage()
    {
        // OpenAI spec: EasyInputMessage does NOT require "type"
        // The server must default to "message" when type is absent
        var (items, _) = await SendInputAndCapture("""
            [
                { "role": "user", "content": "Hello without type" }
            ]
            """);

        Assert.That(items, Has.Count.EqualTo(1));
        var msg = XAssert.IsType<ItemMessage>(items[0]);
        Assert.That(msg.Role, Is.EqualTo(MessageRole.User));
        var content = msg.GetContentExpanded();
        Assert.That(content, Has.Count.EqualTo(1));
        var text = XAssert.IsType<MessageContentInputTextContent>(content[0]);
        Assert.That(text.Text, Is.EqualTo("Hello without type"));
    }

    [Test]
    public async Task C_MSG_01_Message_WithType_AlsoAccepted()
    {
        // Including type: "message" is also valid
        var (items, _) = await SendInputAndCapture("""
            [
                { "type": "message", "role": "user", "content": "With type" }
            ]
            """);

        Assert.That(items, Has.Count.EqualTo(1));
        var msg = XAssert.IsType<ItemMessage>(items[0]);
        Assert.That(msg.Role, Is.EqualTo(MessageRole.User));
    }

    [Test]
    public async Task C_MSG_01_MultipleMessages_WithoutType()
    {
        // All messages can omit type
        var (items, _) = await SendInputAndCapture("""
            [
                { "role": "developer", "content": "System msg" },
                { "role": "user", "content": "User msg" },
                { "role": "assistant", "content": "Asst msg" }
            ]
            """);

        Assert.That(items, Has.Count.EqualTo(3));
        Assert.That(((ItemMessage)items[0]).Role, Is.EqualTo(MessageRole.Developer));
        Assert.That(((ItemMessage)items[1]).Role, Is.EqualTo(MessageRole.User));
        Assert.That(((ItemMessage)items[2]).Role, Is.EqualTo(MessageRole.Assistant));
    }

    // ═══════════════════════════════════════════════════════════════════
    //  ItemReferenceParam — type is REQUIRED (SDK always sends it)
    //  OpenAI spec marks type as optional/nullable, but the SDK's
    //  ResponseItem.JsonModelWriteCore unconditionally writes it.
    //  This is a spec anomaly — we keep type required.
    // ═══════════════════════════════════════════════════════════════════

    [Test]
    public async Task ItemReference_WithType_Accepted()
    {
        var (items, _) = await SendInputAndCapture("""
            [
                { "type": "item_reference", "id": "msg_existing_002" }
            ]
            """);

        Assert.That(items, Has.Count.EqualTo(1));
        var reference = XAssert.IsType<ItemReferenceParam>(items[0]);
        Assert.That(reference.Id, Is.EqualTo("msg_existing_002"));
    }

    // ═══════════════════════════════════════════════════════════════════
    //  GAP-03: InputImageContent.detail is OPTIONAL (C-IMG-01)
    // ═══════════════════════════════════════════════════════════════════

    [Test]
    public async Task C_IMG_01_InputImage_WithoutDetail_Accepted()
    {
        // OpenAI spec: detail is nullable/optional, defaults to "auto"
        var (items, _) = await SendInputAndCapture("""
            [
                {
                    "type": "message",
                    "role": "user",
                    "content": [
                        { "type": "input_image", "image_url": "https://example.com/img.png" }
                    ]
                }
            ]
            """);

        Assert.That(items, Has.Count.EqualTo(1));
        var msg = XAssert.IsType<ItemMessage>(items[0]);
        var content = msg.GetContentExpanded();
        Assert.That(content, Has.Count.EqualTo(1));
        XAssert.IsType<MessageContentInputImageContent>(content[0]);
    }

    [Test]
    public async Task C_IMG_01_InputImage_WithDetail_AlsoAccepted()
    {
        var (items, _) = await SendInputAndCapture("""
            [
                {
                    "type": "message",
                    "role": "user",
                    "content": [
                        { "type": "input_image", "image_url": "https://example.com/img.png", "detail": "high" }
                    ]
                }
            ]
            """);

        Assert.That(items, Has.Count.EqualTo(1));
        var msg = XAssert.IsType<ItemMessage>(items[0]);
        var content = msg.GetContentExpanded();
        Assert.That(content, Has.Count.EqualTo(1));
        XAssert.IsType<MessageContentInputImageContent>(content[0]);
    }

    [Test]
    public async Task C_IMG_01_InputImage_WithNullDetail_Accepted()
    {
        var (items, _) = await SendInputAndCapture("""
            [
                {
                    "type": "message",
                    "role": "user",
                    "content": [
                        { "type": "input_image", "image_url": "https://example.com/img.png", "detail": null }
                    ]
                }
            ]
            """);

        Assert.That(items, Has.Count.EqualTo(1));
    }

    // ═══════════════════════════════════════════════════════════════════
    //  GAP-04 & GAP-05: FunctionTool — strict & parameters OPTIONAL
    // ═══════════════════════════════════════════════════════════════════

    [Test]
    public async Task C_FUNC_01_FunctionTool_WithoutStrict_Accepted()
    {
        // OpenAI spec: FunctionToolParam only requires "name" and "type"
        var (_, request) = await SendAndCapture("""
            {
                "model": "test",
                "tools": [
                    {
                        "type": "function",
                        "name": "get_weather",
                        "description": "Get weather",
                        "parameters": { "type": "object", "properties": {} }
                    }
                ]
            }
            """);

        Assert.That(request!.Tools, Has.Count.EqualTo(1));
        var tool = XAssert.IsType<FunctionTool>(request.Tools[0]);
        Assert.That(tool.Name, Is.EqualTo("get_weather"));
    }

    [Test]
    public async Task C_FUNC_02_FunctionTool_WithoutParameters_Accepted()
    {
        // OpenAI spec: parameters is nullable/optional
        var (_, request) = await SendAndCapture("""
            {
                "model": "test",
                "tools": [
                    {
                        "type": "function",
                        "name": "no_params_tool"
                    }
                ]
            }
            """);

        Assert.That(request!.Tools, Has.Count.EqualTo(1));
        var tool = XAssert.IsType<FunctionTool>(request.Tools[0]);
        Assert.That(tool.Name, Is.EqualTo("no_params_tool"));
    }

    [Test]
    public async Task C_FUNC_01_02_FunctionTool_MinimalForm_Accepted()
    {
        // Only name + type — the minimal valid function tool per OpenAI
        var (_, request) = await SendAndCapture("""
            {
                "model": "test",
                "tools": [
                    { "type": "function", "name": "minimal_tool" }
                ]
            }
            """);

        Assert.That(request!.Tools, Has.Count.EqualTo(1));
        var tool = XAssert.IsType<FunctionTool>(request.Tools[0]);
        Assert.That(tool.Name, Is.EqualTo("minimal_tool"));
    }

    [Test]
    public async Task C_FUNC_01_FunctionTool_WithStrictNull_Accepted()
    {
        // strict: null is explicitly valid
        var (_, request) = await SendAndCapture("""
            {
                "model": "test",
                "tools": [
                    {
                        "type": "function",
                        "name": "get_weather",
                        "strict": null,
                        "parameters": { "type": "object", "properties": {} }
                    }
                ]
            }
            """);

        Assert.That(request!.Tools, Has.Count.EqualTo(1));
        XAssert.IsType<FunctionTool>(request.Tools[0]);
    }

    [Test]
    public async Task C_FUNC_01_FunctionTool_WithStrictTrue_Accepted()
    {
        var (_, request) = await SendAndCapture("""
            {
                "model": "test",
                "tools": [
                    {
                        "type": "function",
                        "name": "strict_tool",
                        "strict": true,
                        "parameters": { "type": "object", "properties": {} }
                    }
                ]
            }
            """);

        Assert.That(request!.Tools, Has.Count.EqualTo(1));
        XAssert.IsType<FunctionTool>(request.Tools[0]);
    }

    // ═══════════════════════════════════════════════════════════════════
    //  INPUT ITEM TYPES — all types recognized by the OpenAI spec
    // ═══════════════════════════════════════════════════════════════════

    [Test]
    public async Task Input_Message_TextContent()
    {
        var (items, _) = await SendInputAndCapture("""
            [
                {
                    "type": "message",
                    "role": "user",
                    "content": [{ "type": "input_text", "text": "Hello" }]
                }
            ]
            """);

        Assert.That(items, Has.Count.EqualTo(1));
        var msg = XAssert.IsType<ItemMessage>(items[0]);
        Assert.That(msg.Role, Is.EqualTo(MessageRole.User));
        var content = msg.GetContentExpanded();
        Assert.That(content, Has.Count.EqualTo(1));
        var text = XAssert.IsType<MessageContentInputTextContent>(content[0]);
        Assert.That(text.Text, Is.EqualTo("Hello"));
    }

    [Test]
    public async Task Input_Message_StringContent()
    {
        var (items, _) = await SendInputAndCapture("""
            [
                { "type": "message", "role": "developer", "content": "System prompt" }
            ]
            """);

        Assert.That(items, Has.Count.EqualTo(1));
        var msg = XAssert.IsType<ItemMessage>(items[0]);
        Assert.That(msg.Role, Is.EqualTo(MessageRole.Developer));
        var content = msg.GetContentExpanded();
        Assert.That(content, Has.Count.EqualTo(1));
        var text = XAssert.IsType<MessageContentInputTextContent>(content[0]);
        Assert.That(text.Text, Is.EqualTo("System prompt"));
    }

    [Test]
    public async Task Input_Message_MultipleContentParts()
    {
        // No "detail" on input_image — C-IMG-01
        var (items, _) = await SendInputAndCapture("""
            [
                {
                    "type": "message",
                    "role": "user",
                    "content": [
                        { "type": "input_text", "text": "Look at this image" },
                        { "type": "input_image", "image_url": "https://example.com/img.png" }
                    ]
                }
            ]
            """);

        Assert.That(items, Has.Count.EqualTo(1));
        var msg = XAssert.IsType<ItemMessage>(items[0]);
        var content = msg.GetContentExpanded();
        Assert.That(content, Has.Count.EqualTo(2));
        XAssert.IsType<MessageContentInputTextContent>(content[0]);
        XAssert.IsType<MessageContentInputImageContent>(content[1]);
    }

    [Test]
    public async Task Input_Message_AllRoles()
    {
        var (items, _) = await SendInputAndCapture("""
            [
                { "type": "message", "role": "user", "content": "r1" },
                { "type": "message", "role": "assistant", "content": "r2" },
                { "type": "message", "role": "developer", "content": "r3" },
                { "type": "message", "role": "system", "content": "r4" },
                { "type": "message", "role": "tool", "content": "r5" }
            ]
            """);

        Assert.That(items, Has.Count.EqualTo(5));
        Assert.That(((ItemMessage)items[0]).Role, Is.EqualTo(MessageRole.User));
        Assert.That(((ItemMessage)items[1]).Role, Is.EqualTo(MessageRole.Assistant));
        Assert.That(((ItemMessage)items[2]).Role, Is.EqualTo(MessageRole.Developer));
        Assert.That(((ItemMessage)items[3]).Role, Is.EqualTo(MessageRole.System));
        Assert.That(((ItemMessage)items[4]).Role, Is.EqualTo(MessageRole.Tool));
    }

    [Test]
    public async Task Input_FunctionCall()
    {
        var (items, _) = await SendInputAndCapture("""
            [
                {
                    "type": "function_call",
                    "call_id": "call_abc",
                    "name": "get_weather",
                    "arguments": "{\"city\":\"Seattle\"}"
                }
            ]
            """);

        Assert.That(items, Has.Count.EqualTo(1));
        var fc = XAssert.IsType<ItemFunctionToolCall>(items[0]);
        Assert.That(fc.CallId, Is.EqualTo("call_abc"));
        Assert.That(fc.Name, Is.EqualTo("get_weather"));
        Assert.That(fc.Arguments, Is.EqualTo("{\"city\":\"Seattle\"}"));
    }

    [Test]
    public async Task Input_FunctionCallOutput_StringOutput()
    {
        var (items, _) = await SendInputAndCapture("""
            [
                {
                    "type": "function_call_output",
                    "call_id": "call_abc",
                    "output": "72°F and sunny"
                }
            ]
            """);

        Assert.That(items, Has.Count.EqualTo(1));
        var fco = XAssert.IsType<FunctionCallOutputItemParam>(items[0]);
        Assert.That(fco.CallId, Is.EqualTo("call_abc"));
        using var doc = JsonDocument.Parse(fco.Output);
        Assert.That(doc.RootElement.GetString(), Is.EqualTo("72°F and sunny"));
    }

    [Test]
    public async Task Input_FunctionCallOutput_ArrayOutput()
    {
        // output can be an array of content parts per OpenAI spec
        var (items, _) = await SendInputAndCapture("""
            [
                {
                    "type": "function_call_output",
                    "call_id": "call_xyz",
                    "output": [
                        { "type": "input_text", "text": "Result text" }
                    ]
                }
            ]
            """);

        Assert.That(items, Has.Count.EqualTo(1));
        var fco = XAssert.IsType<FunctionCallOutputItemParam>(items[0]);
        using var doc = JsonDocument.Parse(fco.Output);
        Assert.That(doc.RootElement.ValueKind, Is.EqualTo(JsonValueKind.Array));
    }

    [Test]
    public async Task Input_Reasoning()
    {
        var (items, _) = await SendInputAndCapture("""
            [
                {
                    "type": "reasoning",
                    "id": "rs_abc",
                    "summary": [
                        { "type": "summary_text", "text": "Thinking step 1" }
                    ]
                }
            ]
            """);

        Assert.That(items, Has.Count.EqualTo(1));
        var reasoning = XAssert.IsType<ItemReasoningItem>(items[0]);
        Assert.That(reasoning.Id, Is.EqualTo("rs_abc"));
        Assert.That(reasoning.Summary, Has.Count.EqualTo(1));
    }

    [Test]
    public async Task Input_ComputerCallOutput()
    {
        var (items, _) = await SendInputAndCapture("""
            [
                {
                    "type": "computer_call_output",
                    "call_id": "cu_abc",
                    "output": {
                        "type": "computer_screenshot",
                        "image_url": "https://example.com/screenshot.png"
                    }
                }
            ]
            """);

        Assert.That(items, Has.Count.EqualTo(1));
        var output = XAssert.IsType<ComputerCallOutputItemParam>(items[0]);
        Assert.That(output.CallId, Is.EqualTo("cu_abc"));
    }

    [Test]
    public async Task Input_McpApprovalResponse()
    {
        var (items, _) = await SendInputAndCapture("""
            [
                {
                    "type": "mcp_approval_response",
                    "approval_request_id": "mcpr_abc",
                    "approve": true
                }
            ]
            """);

        Assert.That(items, Has.Count.EqualTo(1));
        var approval = XAssert.IsType<MCPApprovalResponse>(items[0]);
        Assert.That(approval.ApprovalRequestId, Is.EqualTo("mcpr_abc"));
        Assert.That(approval.Approve, Is.True);
    }

    [Test]
    public async Task Input_MixedTypes_AllDeserialize()
    {
        var (items, _) = await SendInputAndCapture("""
            [
                { "role": "user", "content": "Hello" },
                { "type": "function_call", "call_id": "c1", "name": "fn", "arguments": "{}" },
                { "type": "function_call_output", "call_id": "c1", "output": "done" },
                { "type": "item_reference", "id": "ref_001" }
            ]
            """);

        Assert.That(items, Has.Count.EqualTo(4));
        XAssert.IsType<ItemMessage>(items[0]);
        XAssert.IsType<ItemFunctionToolCall>(items[1]);
        XAssert.IsType<FunctionCallOutputItemParam>(items[2]);
        XAssert.IsType<ItemReferenceParam>(items[3]);
    }

    // ═══════════════════════════════════════════════════════════════════
    //  OUTPUT ITEM TYPES — server output → OpenAI SDK readability
    // ═══════════════════════════════════════════════════════════════════

    [Test]
    public void Output_Message_ReadableByOpenAISdk()
    {
        var response = ReadOpenAIResponse(BuildOutputJson("""
            {
                "id": "msg_001",
                "type": "message",
                "role": "assistant",
                "status": "completed",
                "content": [{ "type": "output_text", "text": "Hello!" }]
            }
            """));

        Assert.That(response.OutputItems, Has.Count.EqualTo(1));
        var msg = XAssert.IsAssignableFrom<MessageResponseItem>(response.OutputItems[0]);
        Assert.That(msg.Role, Is.EqualTo(OpenAI.Responses.MessageRole.Assistant));
        Assert.That(msg.Content, Has.Count.EqualTo(1));
        Assert.That(msg.Content[0].Kind, Is.EqualTo(ResponseContentPartKind.OutputText));
        Assert.That(msg.Content[0].Text, Is.EqualTo("Hello!"));
    }

    [Test]
    public void Output_FunctionCall_ReadableByOpenAISdk()
    {
        var response = ReadOpenAIResponse(BuildOutputJson("""
            {
                "id": "fc_001",
                "type": "function_call",
                "call_id": "call_abc",
                "name": "get_weather",
                "arguments": "{\"city\":\"NYC\"}",
                "status": "completed"
            }
            """));

        Assert.That(response.OutputItems, Has.Count.EqualTo(1));
        var fc = XAssert.IsAssignableFrom<FunctionCallResponseItem>(response.OutputItems[0]);
        Assert.That(fc.FunctionName, Is.EqualTo("get_weather"));
        Assert.That(fc.FunctionArguments.ToString(), Is.EqualTo("{\"city\":\"NYC\"}"));
        Assert.That(fc.CallId, Is.EqualTo("call_abc"));
    }

    [Test]
    public void Output_FunctionCallOutput_ReadableByOpenAISdk()
    {
        var response = ReadOpenAIResponse(BuildOutputJson("""
            {
                "id": "fco_001",
                "type": "function_call_output",
                "call_id": "call_abc",
                "output": "72°F and sunny",
                "status": "completed"
            }
            """));

        Assert.That(response.OutputItems, Has.Count.EqualTo(1));
        var fco = XAssert.IsType<FunctionCallOutputResponseItem>(response.OutputItems[0]);
        Assert.That(fco.CallId, Is.EqualTo("call_abc"));
        Assert.That(fco.FunctionOutput, Is.EqualTo("72°F and sunny"));
    }

    [Test]
    public void Output_Reasoning_ReadableByOpenAISdk()
    {
        var response = ReadOpenAIResponse(BuildOutputJson("""
            {
                "id": "rs_001",
                "type": "reasoning",
                "summary": [
                    { "type": "summary_text", "text": "Thinking step 1" }
                ],
                "status": "completed"
            }
            """));

        Assert.That(response.OutputItems, Has.Count.EqualTo(1));
        XAssert.IsType<ReasoningResponseItem>(response.OutputItems[0]);
    }

    [Test]
    public void Output_FileSearchCall_ReadableByOpenAISdk()
    {
        var response = ReadOpenAIResponse(BuildOutputJson("""
            {
                "id": "fs_001",
                "type": "file_search_call",
                "status": "completed",
                "queries": ["annual report"],
                "results": null
            }
            """));

        Assert.That(response.OutputItems, Has.Count.EqualTo(1));
        var fs = XAssert.IsType<FileSearchCallResponseItem>(response.OutputItems[0]);
        Assert.That(fs.Queries, Has.Count.EqualTo(1));
    }

    [Test]
    public void Output_WebSearchCall_ReadableByOpenAISdk()
    {
        var response = ReadOpenAIResponse(BuildOutputJson("""
            {
                "id": "ws_001",
                "type": "web_search_call",
                "status": "completed"
            }
            """));

        Assert.That(response.OutputItems, Has.Count.EqualTo(1));
        XAssert.IsType<WebSearchCallResponseItem>(response.OutputItems[0]);
    }

    [Test]
    public void Output_CodeInterpreterCall_ReadableByOpenAISdk()
    {
        var response = ReadOpenAIResponse(BuildOutputJson("""
            {
                "id": "ci_001",
                "type": "code_interpreter_call",
                "status": "completed",
                "container_id": "ctr_abc",
                "code": "print('hello')",
                "outputs": [{ "type": "logs", "logs": "hello" }]
            }
            """));

        Assert.That(response.OutputItems, Has.Count.EqualTo(1));
        XAssert.IsType<CodeInterpreterCallResponseItem>(response.OutputItems[0]);
    }

    [Test]
    public void Output_ImageGenerationCall_ReadableByOpenAISdk()
    {
        var response = ReadOpenAIResponse(BuildOutputJson("""
            {
                "id": "ig_001",
                "type": "image_generation_call",
                "status": "completed",
                "result": "aGVsbG8="
            }
            """));

        Assert.That(response.OutputItems, Has.Count.EqualTo(1));
        XAssert.IsType<ImageGenerationCallResponseItem>(response.OutputItems[0]);
    }

    [Test]
    public void Output_ComputerCall_ReadableByOpenAISdk()
    {
        var response = ReadOpenAIResponse(BuildOutputJson("""
            {
                "id": "cu_001",
                "type": "computer_call",
                "call_id": "cu_call_001",
                "action": { "type": "screenshot" },
                "pending_safety_checks": [],
                "status": "completed"
            }
            """));

        Assert.That(response.OutputItems, Has.Count.EqualTo(1));
        XAssert.IsType<ComputerCallResponseItem>(response.OutputItems[0]);
    }

    [Test]
    public void Output_McpCall_ReadableByOpenAISdk()
    {
        var response = ReadOpenAIResponse(BuildOutputJson("""
            {
                "id": "mcp_001",
                "type": "mcp_call",
                "server_label": "my_server",
                "name": "get_data",
                "arguments": "{}"
            }
            """));

        Assert.That(response.OutputItems, Has.Count.EqualTo(1));
        XAssert.IsType<McpToolCallItem>(response.OutputItems[0]);
    }

    [Test]
    public void Output_McpApprovalRequest_ReadableByOpenAISdk()
    {
        var response = ReadOpenAIResponse(BuildOutputJson("""
            {
                "id": "mcpa_001",
                "type": "mcp_approval_request",
                "server_label": "my_server",
                "name": "dangerous_fn",
                "arguments": "{}"
            }
            """));

        Assert.That(response.OutputItems, Has.Count.EqualTo(1));
        XAssert.IsType<McpToolCallApprovalRequestItem>(response.OutputItems[0]);
    }

    [Test]
    public void Output_McpListTools_ReadableByOpenAISdk()
    {
        var response = ReadOpenAIResponse(BuildOutputJson("""
            {
                "id": "mcpl_001",
                "type": "mcp_list_tools",
                "server_label": "my_server",
                "tools": [
                    {
                        "name": "tool_a",
                        "input_schema": { "type": "object", "properties": {} }
                    }
                ]
            }
            """));

        Assert.That(response.OutputItems, Has.Count.EqualTo(1));
        XAssert.IsType<McpToolDefinitionListItem>(response.OutputItems[0]);
    }

    // ═══════════════════════════════════════════════════════════════════
    //  WIRE-FORMAT TRANSLATION — Azure model ↔ OpenAI model
    // ═══════════════════════════════════════════════════════════════════

    [Test]
    public void Translate_ItemMessage_ToResponseItem()
    {
        var msg = new ItemMessage(MessageRole.User, new List<Models.MessageContent>
        {
            new MessageContentInputTextContent("Hello from Azure"),
        });

        var openAiItem = msg.Translate().To<ResponseItem>();
        Assert.That(openAiItem, Is.InstanceOf<MessageResponseItem>());
        Assert.That(((MessageResponseItem)openAiItem).Role, Is.EqualTo(OpenAI.Responses.MessageRole.User));
    }

    [Test]
    public void Translate_FunctionCall_ToResponseItem()
    {
        var fc = new ItemFunctionToolCall("call_1", "my_func", "{\"x\":1}");

        var openAiItem = fc.Translate().To<ResponseItem>();
        Assert.That(openAiItem, Is.InstanceOf<FunctionCallResponseItem>());
        var result = (FunctionCallResponseItem)openAiItem;
        Assert.That(result.FunctionName, Is.EqualTo("my_func"));
        Assert.That(result.FunctionArguments.ToString(), Is.EqualTo("{\"x\":1}"));
    }

    [Test]
    public void Translate_FunctionCallOutput_ToResponseItem()
    {
        var fco = new FunctionCallOutputItemParam("call_1", BinaryData.FromObjectAsJson("result"));

        var openAiItem = fco.Translate().To<ResponseItem>();
        Assert.That(openAiItem, Is.InstanceOf<FunctionCallOutputResponseItem>());
        Assert.That(((FunctionCallOutputResponseItem)openAiItem).CallId, Is.EqualTo("call_1"));
    }

    [Test]
    public void Translate_ItemReference_ToResponseItem()
    {
        var reference = new ItemReferenceParam("msg_existing_001");

        var openAiItem = reference.Translate().To<ResponseItem>();
        Assert.That(openAiItem, Is.InstanceOf<ReferenceResponseItem>());
    }

    [Test]
    public void Translate_OpenAI_MessageResponseItem_ToAzure()
    {
        var json = BinaryData.FromString("""
            {
                "type": "message",
                "id": "msg_openai_001",
                "role": "assistant",
                "status": "completed",
                "content": [{ "type": "output_text", "text": "response text" }]
            }
            """);
        var openAiItem = ModelReaderWriter.Read<ResponseItem>(json)!;
        var azureItem = openAiItem.Translate().To<Item>();
        Assert.That(azureItem, Is.InstanceOf<ItemMessage>());
    }

    // ═══════════════════════════════════════════════════════════════════
    //  CREATERESPONSE PROPERTIES — all fields round-trip
    // ═══════════════════════════════════════════════════════════════════

    [Test]
    public async Task CreateResponse_Model() =>
        Assert.That((await CaptureRequest("""{ "model": "gpt-4o-mini" }""")).Model, Is.EqualTo("gpt-4o-mini"));

    [Test]
    public async Task CreateResponse_Instructions() =>
        Assert.That((await CaptureRequest("""{ "model": "test", "instructions": "Be helpful" }""")).Instructions, Is.EqualTo("Be helpful"));

    [Test]
    public async Task CreateResponse_Temperature() =>
        Assert.That((await CaptureRequest("""{ "model": "test", "temperature": 0.7 }""")).Temperature, Is.EqualTo(0.7).Within(0.001));

    [Test]
    public async Task CreateResponse_TopP() =>
        Assert.That((await CaptureRequest("""{ "model": "test", "top_p": 0.9 }""")).TopP, Is.EqualTo(0.9).Within(0.001));

    [Test]
    public async Task CreateResponse_MaxOutputTokens() =>
        Assert.That((await CaptureRequest("""{ "model": "test", "max_output_tokens": 1024 }""")).MaxOutputTokens, Is.EqualTo(1024));

    [Test]
    public async Task CreateResponse_PreviousResponseId()
    {
        var validId = IdGenerator.NewResponseId();
        var req = await CaptureRequest($$"""{ "model": "test", "previous_response_id": "{{validId}}" }""");
        Assert.That(req.PreviousResponseId, Is.EqualTo(validId));
    }

    [Test]
    public async Task CreateResponse_Store() =>
        Assert.That((await CaptureRequest("""{ "model": "test", "store": false }""")).Store, Is.False);

    [Test]
    public async Task CreateResponse_Metadata()
    {
        var req = await CaptureRequest("""{ "model": "test", "metadata": { "key": "value" } }""");
        Assert.That(req.Metadata, Is.Not.Null);
    }

    [Test]
    public async Task CreateResponse_ParallelToolCalls() =>
        Assert.That((await CaptureRequest("""{ "model": "test", "parallel_tool_calls": false }""")).ParallelToolCalls, Is.False);

    [Test]
    public async Task CreateResponse_Truncation()
    {
        var req = await CaptureRequest("""{ "model": "test", "truncation": "auto" }""");
        Assert.That(req.Truncation, Is.Not.Null);
    }

    [Test]
    public async Task CreateResponse_Reasoning()
    {
        var req = await CaptureRequest("""{ "model": "test", "reasoning": { "effort": "high" } }""");
        Assert.That(req.Reasoning, Is.Not.Null);
    }

    [Test]
    public async Task CreateResponse_ToolChoice_Auto()
    {
        var req = await CaptureRequest("""{ "model": "test", "tool_choice": "auto" }""");
        var tc = req.GetToolChoiceExpanded();
        var allowed = XAssert.IsType<ToolChoiceAllowed>(tc);
        Assert.That(allowed.Mode, Is.EqualTo(ToolChoiceAllowedMode.Auto));
    }

    [Test]
    public async Task CreateResponse_ToolChoice_Required()
    {
        var req = await CaptureRequest("""{ "model": "test", "tool_choice": "required" }""");
        var tc = req.GetToolChoiceExpanded();
        var allowed = XAssert.IsType<ToolChoiceAllowed>(tc);
        Assert.That(allowed.Mode, Is.EqualTo(ToolChoiceAllowedMode.Required));
    }

    [Test]
    public async Task CreateResponse_ToolChoice_None()
    {
        var req = await CaptureRequest("""{ "model": "test", "tool_choice": "none" }""");
        Assert.That(req.GetToolChoiceExpanded(), Is.Null);
    }

    [Test]
    public async Task CreateResponse_ToolChoice_FunctionObject()
    {
        var req = await CaptureRequest("""
            { "model": "test", "tool_choice": { "type": "function", "name": "get_weather" } }
            """);
        var tc = XAssert.IsType<ToolChoiceFunction>(req.GetToolChoiceExpanded());
        Assert.That(tc.Name, Is.EqualTo("get_weather"));
    }

    [Test]
    public async Task CreateResponse_Tools_WebSearch()
    {
        var req = await CaptureRequest("""
            { "model": "test", "tools": [{ "type": "web_search_preview" }] }
            """);
        Assert.That(req.Tools, Has.Count.EqualTo(1));
        XAssert.IsType<WebSearchPreviewTool>(req.Tools[0]);
    }

    [Test]
    public async Task CreateResponse_Tools_FileSearch()
    {
        var req = await CaptureRequest("""
            { "model": "test", "tools": [{ "type": "file_search", "vector_store_ids": ["vs_abc"] }] }
            """);
        Assert.That(req.Tools, Has.Count.EqualTo(1));
        XAssert.IsType<FileSearchTool>(req.Tools[0]);
    }

    [Test]
    public async Task CreateResponse_Tools_CodeInterpreter()
    {
        var req = await CaptureRequest("""
            { "model": "test", "tools": [{ "type": "code_interpreter" }] }
            """);
        Assert.That(req.Tools, Has.Count.EqualTo(1));
        XAssert.IsType<CodeInterpreterTool>(req.Tools[0]);
    }

    [Test]
    public async Task CreateResponse_Stream()
    {
        var (_, req) = await SendAndCapture("""{ "model": "test", "stream": true }""", expectSse: true);
        Assert.That(req!.Stream, Is.True);
    }

    // ═══════════════════════════════════════════════════════════════════
    //  RESPONSE OBJECT — OpenAI SDK readability
    // ═══════════════════════════════════════════════════════════════════

    [Test]
    public async Task ResponseObject_ReadableByOpenAISdk()
    {
        using var factory = new TestWebApplicationFactory();
        using var client = factory.CreateClient();

        var response = await client.PostAsync("/responses",
            new StringContent("""{ "model": "gpt-4o" }""", Encoding.UTF8, "application/json"));
        response.EnsureSuccessStatusCode();

        var body = await response.Content.ReadAsByteArrayAsync();
        var result = ModelReaderWriter.Read<ResponseResult>(BinaryData.FromBytes(body))!;

        Assert.That(result.Id, Does.Contain("resp"));
        Assert.That(result.Model, Is.EqualTo("gpt-4o"));
        Assert.That(result.Status, Is.EqualTo(OpenAI.Responses.ResponseStatus.Completed));
    }

    // ═══════════════════════════════════════════════════════════════════
    //  SHORTHAND NOTATIONS — string | array forms
    // ═══════════════════════════════════════════════════════════════════

    [Test]
    public async Task Input_StringShorthand_ExpandsToUserMessage()
    {
        var req = await CaptureRequest("""{ "model": "test", "input": "Hello world" }""");
        var items = req.GetInputExpanded();
        Assert.That(items, Has.Count.EqualTo(1));
        var msg = XAssert.IsType<ItemMessage>(items[0]);
        Assert.That(msg.Role, Is.EqualTo(MessageRole.User));
        var text = XAssert.IsType<MessageContentInputTextContent>(msg.GetContentExpanded()[0]);
        Assert.That(text.Text, Is.EqualTo("Hello world"));
    }

    [Test]
    public async Task Input_EmptyArray_ReturnsEmpty()
    {
        var req = await CaptureRequest("""{ "model": "test", "input": [] }""");
        Assert.That(req.GetInputExpanded(), Is.Empty);
    }

    [Test]
    public async Task Input_NullOrAbsent_ReturnsEmpty()
    {
        var req = await CaptureRequest("""{ "model": "test" }""");
        Assert.That(req.GetInputExpanded(), Is.Empty);
    }

    [Test]
    public async Task MessageContent_StringShorthand_ExpandsToInputText()
    {
        var items = await GetExpandedInput("""
            { "model": "test", "input": [{ "type": "message", "role": "user", "content": "shorthand" }] }
            """);
        var text = XAssert.IsType<MessageContentInputTextContent>(
            ((ItemMessage)items[0]).GetContentExpanded()[0]);
        Assert.That(text.Text, Is.EqualTo("shorthand"));
    }

    [Test]
    public async Task MessageContent_EmptyString_ExpandsToEmptyText()
    {
        var items = await GetExpandedInput("""
            { "model": "test", "input": [{ "type": "message", "role": "user", "content": "" }] }
            """);
        var text = XAssert.IsType<MessageContentInputTextContent>(
            ((ItemMessage)items[0]).GetContentExpanded()[0]);
        Assert.That(text.Text, Is.EqualTo(""));
    }

    [Test]
    public async Task FunctionOutput_String()
    {
        var items = await GetExpandedInput("""
            { "model": "test", "input": [{ "type": "function_call_output", "call_id": "c1", "output": "72 degrees" }] }
            """);
        var fco = XAssert.IsType<FunctionCallOutputItemParam>(items[0]);
        using var doc = JsonDocument.Parse(fco.Output);
        Assert.That(doc.RootElement.GetString(), Is.EqualTo("72 degrees"));
    }

    [Test]
    public async Task FunctionOutput_ContentArray()
    {
        var items = await GetExpandedInput("""
            {
                "model": "test",
                "input": [
                    {
                        "type": "function_call_output",
                        "call_id": "c1",
                        "output": [
                            { "type": "input_text", "text": "Result" },
                            { "type": "input_image", "image_url": "https://example.com/img.png" }
                        ]
                    }
                ]
            }
            """);
        var fco = XAssert.IsType<FunctionCallOutputItemParam>(items[0]);
        using var doc = JsonDocument.Parse(fco.Output);
        Assert.That(doc.RootElement.ValueKind, Is.EqualTo(JsonValueKind.Array));
        Assert.That(doc.RootElement.GetArrayLength(), Is.EqualTo(2));
    }

    // ═══════════════════════════════════════════════════════════════════
    //  COMBINED SCENARIO — realistic multi-turn with all shorthands
    // ═══════════════════════════════════════════════════════════════════

    [Test]
    public async Task FullPayload_AllShorthandsAndMinimalForms()
    {
        // Uses ALL shorthand/minimal forms in one request:
        // - input as string
        // - tool_choice as string
        // - function tool without strict or parameters (C-FUNC-01, C-FUNC-02)
        var req = await CaptureRequest("""
            {
                "model": "gpt-4o",
                "input": "What is the weather?",
                "instructions": "Be helpful",
                "tool_choice": "auto",
                "store": true,
                "temperature": 0.5,
                "max_output_tokens": 500,
                "tools": [
                    { "type": "function", "name": "get_weather" }
                ]
            }
            """);

        Assert.That(req.Model, Is.EqualTo("gpt-4o"));
        Assert.That(req.Instructions, Is.EqualTo("Be helpful"));
        Assert.That(req.Temperature, Is.EqualTo(0.5).Within(0.001));
        Assert.That(req.MaxOutputTokens, Is.EqualTo(500));
        Assert.That(req.Store, Is.True);

        var items = req.GetInputExpanded();
        Assert.That(items, Has.Count.EqualTo(1));
        XAssert.IsType<ItemMessage>(items[0]);

        var tc = XAssert.IsType<ToolChoiceAllowed>(req.GetToolChoiceExpanded());
        Assert.That(tc.Mode, Is.EqualTo(ToolChoiceAllowedMode.Auto));

        Assert.That(req.Tools, Has.Count.EqualTo(1));
        XAssert.IsType<FunctionTool>(req.Tools[0]);
    }

    [Test]
    public async Task MultiTurn_MixedShorthandAndFullForm()
    {
        // Mix message-without-type, string content, array content with image-without-detail
        var items = await GetExpandedInput("""
            {
                "model": "test",
                "input": [
                    { "role": "developer", "content": "You are helpful" },
                    {
                        "type": "message",
                        "role": "user",
                        "content": [
                            { "type": "input_text", "text": "Look at this" },
                            { "type": "input_image", "image_url": "https://example.com/img.png" }
                        ]
                    }
                ]
            }
            """);

        Assert.That(items, Has.Count.EqualTo(2));
        var msg0 = XAssert.IsType<ItemMessage>(items[0]);
        Assert.That(msg0.Role, Is.EqualTo(MessageRole.Developer));
        var msg1 = XAssert.IsType<ItemMessage>(items[1]);
        Assert.That(msg1.GetContentExpanded(), Has.Count.EqualTo(2));
    }

    // ═══════════════════════════════════════════════════════════════════
    //  VALIDATION — reject truly invalid inputs
    // ═══════════════════════════════════════════════════════════════════

    [Test]
    public async Task Reject_InputAsNumber()
    {
        using var factory = new TestWebApplicationFactory();
        using var client = factory.CreateClient();

        var resp = await client.PostAsync("/responses",
            new StringContent("""{ "model": "test", "input": 42 }""", Encoding.UTF8, "application/json"));
        Assert.That((int)resp.StatusCode, Is.EqualTo(400));
    }

    [Test]
    public async Task Reject_InputAsBoolean()
    {
        using var factory = new TestWebApplicationFactory();
        using var client = factory.CreateClient();

        var resp = await client.PostAsync("/responses",
            new StringContent("""{ "model": "test", "input": true }""", Encoding.UTF8, "application/json"));
        Assert.That((int)resp.StatusCode, Is.EqualTo(400));
    }

    [Test]
    public async Task Reject_ContentAsNumber()
    {
        using var factory = new TestWebApplicationFactory();
        using var client = factory.CreateClient();

        var resp = await client.PostAsync("/responses",
            new StringContent("""
                { "model": "test", "input": [{ "type": "message", "role": "user", "content": 42 }] }
                """, Encoding.UTF8, "application/json"));
        Assert.That((int)resp.StatusCode, Is.EqualTo(400));
    }

    // ═══════════════════════════════════════════════════════════════════
    //  Helpers
    // ═══════════════════════════════════════════════════════════════════

    private static async Task<(List<Item> Items, CreateResponse? Request)> SendInputAndCapture(string inputItemsJson)
    {
        var json = $$"""{ "model": "test", "input": {{inputItemsJson}} }""";
        return await SendAndCapture(json);
    }

    private static async Task<(List<Item> Items, CreateResponse? Request)> SendAndCapture(
        string jsonBody, bool expectSse = false)
    {
        var handler = new TestHandler();
        using var factory = new TestWebApplicationFactory(handler);
        using var client = factory.CreateClient();

        var response = await client.PostAsync("/responses",
            new StringContent(jsonBody, Encoding.UTF8, "application/json"));
        response.EnsureSuccessStatusCode();

        var request = handler.LastRequest;
        var items = request?.GetInputExpanded() ?? [];
        return (items, request);
    }

    private static async Task<CreateResponse> CaptureRequest(string jsonBody)
    {
        var handler = new TestHandler();
        using var factory = new TestWebApplicationFactory(handler);
        using var client = factory.CreateClient();

        var response = await client.PostAsync("/responses",
            new StringContent(jsonBody, Encoding.UTF8, "application/json"));
        response.EnsureSuccessStatusCode();

        return handler.LastRequest!;
    }

    private static async Task<List<Item>> GetExpandedInput(string jsonBody)
    {
        var req = await CaptureRequest(jsonBody);
        return req.GetInputExpanded();
    }

    private static ResponseResult ReadOpenAIResponse(string responseJson) =>
        ModelReaderWriter.Read<ResponseResult>(BinaryData.FromString(responseJson))!;

    private static string BuildOutputJson(string outputItemJson) =>
        $$"""
        {
            "id": "resp_mock_compliance",
            "object": "response",
            "status": "completed",
            "model": "test-model",
            "output": [{{outputItemJson}}],
            "usage": { "input_tokens": 10, "output_tokens": 5, "total_tokens": 15 }
        }
        """;
}
