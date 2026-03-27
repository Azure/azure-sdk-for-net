// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.AI.AgentServer.Responses.Models;

namespace Azure.AI.AgentServer.Responses.Tests.Internal;

public class ItemConversionTests
{
    private const string PartitionKeyHint = "resp_test";

    // ── Messages ────────────────────────────────────────────────────────

    [Test]
    public void ToOutputItem_ItemMessage_ReturnsOutputItemMessage()
    {
        var content = BinaryData.FromObjectAsJson("Hello, world!");
        var message = new ItemMessage(MessageRole.User, content);

        var result = ItemConversion.ToOutputItem(message, PartitionKeyHint);

        var outputMessage = XAssert.IsType<OutputItemMessage>(result);
        XAssert.StartsWith("msg_", outputMessage.Id);
        Assert.That(outputMessage.Status, Is.EqualTo(MessageStatus.Completed));
        Assert.That(outputMessage.Role, Is.EqualTo(MessageRole.User));
        Assert.That(outputMessage.Content, Is.Not.Empty);
    }

    [Test]
    public void ToOutputItem_ItemMessage_PreservesRole()
    {
        var content = BinaryData.FromObjectAsJson("System prompt");
        var message = new ItemMessage(MessageRole.Developer, content);

        var result = ItemConversion.ToOutputItem(message, PartitionKeyHint);

        var outputMessage = XAssert.IsType<OutputItemMessage>(result);
        XAssert.StartsWith("msg_", outputMessage.Id);
        Assert.That(outputMessage.Role, Is.EqualTo(MessageRole.Developer));
    }

    [Test]
    public void ToOutputItem_ItemOutputMessage_ReturnsOutputItemMessage()
    {
        var content = new List<OutputMessageContent>
        {
            new OutputMessageContentOutputTextContent("Hello from assistant", Array.Empty<Annotation>(), Array.Empty<LogProb>()),
        };
        var outputMsg = new ItemOutputMessage("om_1", content, OutputItemOutputMessageStatus.Completed);

        var result = ItemConversion.ToOutputItem(outputMsg, PartitionKeyHint);

        var converted = XAssert.IsType<OutputItemMessage>(result);
        XAssert.StartsWith("om_", converted.Id);
        Assert.That(converted.Status, Is.EqualTo(MessageStatus.Completed));
        XAssert.Single(converted.Content);
    }

    // ── Function tool calls ─────────────────────────────────────────────

    [Test]
    public void ToOutputItem_ItemFunctionToolCall_ReturnsOutputItemFunctionToolCall()
    {
        var funcCall = new ItemFunctionToolCall("call_func", "get_weather", "{\"city\":\"Seattle\"}");

        var result = ItemConversion.ToOutputItem(funcCall, PartitionKeyHint);

        var converted = XAssert.IsType<OutputItemFunctionToolCall>(result);
        XAssert.StartsWith("fc_", converted.Id);
        Assert.That(converted.CallId, Is.EqualTo("call_func"));
        Assert.That(converted.Name, Is.EqualTo("get_weather"));
        Assert.That(converted.Arguments, Is.EqualTo("{\"city\":\"Seattle\"}"));
        Assert.That(converted.Status, Is.EqualTo(OutputItemFunctionToolCallStatus.Completed));
    }

    [Test]
    public void ToOutputItem_FunctionCallOutputItemParam_ReturnsFunctionToolCallOutputResource()
    {
        var output = BinaryData.FromObjectAsJson("function result");
        var funcOutput = new FunctionCallOutputItemParam("call_123", output);

        var result = ItemConversion.ToOutputItem(funcOutput, PartitionKeyHint);

        var outputFunc = XAssert.IsType<FunctionToolCallOutputResource>(result);
        XAssert.StartsWith("fco_", outputFunc.Id);
        Assert.That(outputFunc.CallId, Is.EqualTo("call_123"));
        Assert.That(outputFunc.Status, Is.EqualTo(FunctionToolCallOutputResourceStatus.Completed));
    }

    // ── Custom tool calls ───────────────────────────────────────────────

    [Test]
    public void ToOutputItem_ItemCustomToolCall_ReturnsOutputItemCustomToolCall()
    {
        var customCall = new ItemCustomToolCall("call_ct", "my_tool", "some input");

        var result = ItemConversion.ToOutputItem(customCall, PartitionKeyHint);

        var converted = XAssert.IsType<OutputItemCustomToolCall>(result);
        XAssert.StartsWith("ctc_", converted.Id);
        Assert.That(converted.CallId, Is.EqualTo("call_ct"));
        Assert.That(converted.Name, Is.EqualTo("my_tool"));
        Assert.That(converted.Input, Is.EqualTo("some input"));
    }

    [Test]
    public void ToOutputItem_ItemCustomToolCallOutput_ReturnsOutputItemCustomToolCallOutput()
    {
        var output = BinaryData.FromObjectAsJson("custom result");
        var customOutput = new ItemCustomToolCallOutput("call_cto", output);

        var result = ItemConversion.ToOutputItem(customOutput, PartitionKeyHint);

        var converted = XAssert.IsType<OutputItemCustomToolCallOutput>(result);
        XAssert.StartsWith("ctco_", converted.Id);
        Assert.That(converted.CallId, Is.EqualTo("call_cto"));
    }

    // ── Computer tool calls ─────────────────────────────────────────────

    [Test]
    public void ToOutputItem_ItemComputerToolCall_ReturnsOutputItemComputerToolCall()
    {
        var action = new DoubleClickAction(100, 200);
        var computerCall = new ItemComputerToolCall("comp_id", "call_comp", action,
            Array.Empty<ComputerCallSafetyCheckParam>(),
            OutputItemComputerToolCallStatus.Completed);

        var result = ItemConversion.ToOutputItem(computerCall, PartitionKeyHint);

        var converted = XAssert.IsType<OutputItemComputerToolCall>(result);
        XAssert.StartsWith("cu_", converted.Id);
        Assert.That(converted.CallId, Is.EqualTo("call_comp"));
        Assert.That(converted.Status, Is.EqualTo(OutputItemComputerToolCallStatus.Completed));
    }

    [Test]
    public void ToOutputItem_ComputerCallOutputItemParam_ReturnsOutputItemComputerToolCallOutputResource()
    {
        var screenshot = new ComputerScreenshotImage();
        var computerOutput = new ComputerCallOutputItemParam("call_456", screenshot);

        var result = ItemConversion.ToOutputItem(computerOutput, PartitionKeyHint);

        var outputComputer = XAssert.IsType<OutputItemComputerToolCallOutputResource>(result);
        XAssert.StartsWith("cuo_", outputComputer.Id);
        Assert.That(outputComputer.CallId, Is.EqualTo("call_456"));
        Assert.That(outputComputer.Status, Is.EqualTo(OutputItemComputerToolCallOutputResourceStatus.Completed));
    }

    // ── File search ─────────────────────────────────────────────────────

    [Test]
    public void ToOutputItem_ItemFileSearchToolCall_ReturnsOutputItemFileSearchToolCall()
    {
        var fileSearch = new ItemFileSearchToolCall("fs_id",
            OutputItemFileSearchToolCallStatus.Completed,
            new List<string> { "query1" });

        var result = ItemConversion.ToOutputItem(fileSearch, PartitionKeyHint);

        var converted = XAssert.IsType<OutputItemFileSearchToolCall>(result);
        XAssert.StartsWith("fs_", converted.Id);
        Assert.That(converted.Status, Is.EqualTo(OutputItemFileSearchToolCallStatus.Completed));
        XAssert.Single(converted.Queries);
        Assert.That(converted.Queries[0], Is.EqualTo("query1"));
    }

    // ── Web search ──────────────────────────────────────────────────────

    [Test]
    public void ToOutputItem_ItemWebSearchToolCall_ReturnsOutputItemWebSearchToolCall()
    {
        var action = BinaryData.FromObjectAsJson(new { type = "search", query = "test" });
        var webSearch = new ItemWebSearchToolCall("ws_id",
            OutputItemWebSearchToolCallStatus.Completed, action);

        var result = ItemConversion.ToOutputItem(webSearch, PartitionKeyHint);

        var converted = XAssert.IsType<OutputItemWebSearchToolCall>(result);
        XAssert.StartsWith("ws_", converted.Id);
        Assert.That(converted.Status, Is.EqualTo(OutputItemWebSearchToolCallStatus.Completed));
    }

    // ── Image generation ────────────────────────────────────────────────

    [Test]
    public void ToOutputItem_ItemImageGenToolCall_ReturnsOutputItemImageGenToolCall()
    {
        var imageGen = new ItemImageGenToolCall("ig_id",
            OutputItemImageGenToolCallStatus.Completed, "base64data");

        var result = ItemConversion.ToOutputItem(imageGen, PartitionKeyHint);

        var converted = XAssert.IsType<OutputItemImageGenToolCall>(result);
        XAssert.StartsWith("ig_", converted.Id);
        Assert.That(converted.Status, Is.EqualTo(OutputItemImageGenToolCallStatus.Completed));
        Assert.That(converted.Result, Is.EqualTo("base64data"));
    }

    // ── Code interpreter ────────────────────────────────────────────────

    [Test]
    public void ToOutputItem_ItemCodeInterpreterToolCall_ReturnsOutputItemCodeInterpreterToolCall()
    {
        var codeInterpreter = new ItemCodeInterpreterToolCall("ci_id",
            OutputItemCodeInterpreterToolCallStatus.Completed,
            "container_1",
            "print('hello')",
            new List<BinaryData> { BinaryData.FromObjectAsJson("output") });

        var result = ItemConversion.ToOutputItem(codeInterpreter, PartitionKeyHint);

        var converted = XAssert.IsType<OutputItemCodeInterpreterToolCall>(result);
        XAssert.StartsWith("ci_", converted.Id);
        Assert.That(converted.Status, Is.EqualTo(OutputItemCodeInterpreterToolCallStatus.Completed));
        Assert.That(converted.ContainerId, Is.EqualTo("container_1"));
        Assert.That(converted.Code, Is.EqualTo("print('hello')"));
        XAssert.Single(converted.Outputs);
    }

    // ── Local shell ─────────────────────────────────────────────────────

    [Test]
    public void ToOutputItem_ItemLocalShellToolCall_ReturnsOutputItemLocalShellToolCall()
    {
        var action = new LocalShellExecAction(new List<string> { "ls" }, new Dictionary<string, string>());
        var localShell = new ItemLocalShellToolCall("ls_id", "call_ls", action,
            OutputItemLocalShellToolCallStatus.Completed);

        var result = ItemConversion.ToOutputItem(localShell, PartitionKeyHint);

        var converted = XAssert.IsType<OutputItemLocalShellToolCall>(result);
        XAssert.StartsWith("lsh_", converted.Id);
        Assert.That(converted.CallId, Is.EqualTo("call_ls"));
        Assert.That(converted.Status, Is.EqualTo(OutputItemLocalShellToolCallStatus.Completed));
    }

    [Test]
    public void ToOutputItem_ItemLocalShellToolCallOutput_ReturnsOutputItemLocalShellToolCallOutput()
    {
        var localShellOutput = new ItemLocalShellToolCallOutput("lso_id", "some output");

        var result = ItemConversion.ToOutputItem(localShellOutput, PartitionKeyHint);

        var converted = XAssert.IsType<OutputItemLocalShellToolCallOutput>(result);
        XAssert.StartsWith("lsho_", converted.Id);
        Assert.That(converted.Output, Is.EqualTo("some output"));
        Assert.That(converted.Status, Is.EqualTo(OutputItemLocalShellToolCallOutputStatus.Completed));
    }

    // ── Function shell ──────────────────────────────────────────────────

    [Test]
    public void ToOutputItem_FunctionShellCallItemParam_ReturnsOutputItemFunctionShellCall()
    {
        var action = new FunctionShellActionParam(new List<string> { "echo hello" });
        var shellCall = new FunctionShellCallItemParam("call_sh", action)
        {
            Environment = new FunctionShellCallItemParamEnvironmentContainerReferenceParam("cnt_1"),
        };

        var result = ItemConversion.ToOutputItem(shellCall, PartitionKeyHint);

        var converted = XAssert.IsType<OutputItemFunctionShellCall>(result);
        XAssert.StartsWith("lsh_", converted.Id);
        Assert.That(converted.CallId, Is.EqualTo("call_sh"));
        Assert.That(converted.Status, Is.EqualTo(LocalShellCallStatus.Completed));
        XAssert.IsType<ContainerReferenceResource>(converted.Environment);
    }

    [Test]
    public void ToOutputItem_FunctionShellCallItemParam_LocalEnvironment_DefaultsToLocal()
    {
        var action = new FunctionShellActionParam(new List<string> { "pwd" });
        var shellCall = new FunctionShellCallItemParam("call_sh2", action)
        {
            Environment = new FunctionShellCallItemParamEnvironmentLocalEnvironmentParam(),
        };

        var result = ItemConversion.ToOutputItem(shellCall, PartitionKeyHint);

        var converted = XAssert.IsType<OutputItemFunctionShellCall>(result);
        XAssert.IsType<LocalEnvironmentResource>(converted.Environment);
    }

    [Test]
    public void ToOutputItem_FunctionShellCallOutputItemParam_ReturnsOutputItemFunctionShellCallOutput()
    {
        var exitOutcome = new FunctionShellCallOutputExitOutcomeParam(0);
        var outputContent = new FunctionShellCallOutputContentParam("hello\n", "", exitOutcome);
        var shellOutput = new FunctionShellCallOutputItemParam("call_sho", new[] { outputContent })
        {
            MaxOutputLength = 4096,
        };

        var result = ItemConversion.ToOutputItem(shellOutput, PartitionKeyHint);

        var converted = XAssert.IsType<OutputItemFunctionShellCallOutput>(result);
        XAssert.StartsWith("lsho_", converted.Id);
        Assert.That(converted.CallId, Is.EqualTo("call_sho"));
        Assert.That(converted.Status, Is.EqualTo(LocalShellCallOutputStatusEnum.Completed));
        XAssert.Single(converted.Output);
        Assert.That(converted.Output[0].Stdout, Is.EqualTo("hello\n"));
        XAssert.IsType<FunctionShellCallOutputExitOutcome>(converted.Output[0].Outcome);
        Assert.That(converted.MaxOutputLength, Is.EqualTo(4096));
    }

    [Test]
    public void ToOutputItem_FunctionShellCallOutputItemParam_TimeoutOutcome()
    {
        var timeoutOutcome = new FunctionShellCallOutputTimeoutOutcomeParam();
        var outputContent = new FunctionShellCallOutputContentParam("partial", "err", timeoutOutcome);
        var shellOutput = new FunctionShellCallOutputItemParam("call_to", new[] { outputContent });

        var result = ItemConversion.ToOutputItem(shellOutput, PartitionKeyHint);

        var converted = XAssert.IsType<OutputItemFunctionShellCallOutput>(result);
        XAssert.IsType<FunctionShellCallOutputTimeoutOutcome>(converted.Output[0].Outcome);
    }

    // ── Apply patch ─────────────────────────────────────────────────────

    [Test]
    public void ToOutputItem_ApplyPatchToolCallItemParam_CreateFile_ReturnsOutputItemApplyPatchToolCall()
    {
        var operation = new ApplyPatchCreateFileOperationParam("src/main.cs", "+using System;");
        var applyPatch = new ApplyPatchToolCallItemParam("call_ap", ApplyPatchCallStatusParam.Completed, operation);

        var result = ItemConversion.ToOutputItem(applyPatch, PartitionKeyHint);

        var converted = XAssert.IsType<OutputItemApplyPatchToolCall>(result);
        XAssert.StartsWith("ap_", converted.Id);
        Assert.That(converted.CallId, Is.EqualTo("call_ap"));
        Assert.That(converted.Status, Is.EqualTo(ApplyPatchCallStatus.Completed));
        var createOp = XAssert.IsType<ApplyPatchCreateFileOperation>(converted.Operation);
        Assert.That(createOp.Path, Is.EqualTo("src/main.cs"));
        Assert.That(createOp.Diff, Is.EqualTo("+using System;"));
    }

    [Test]
    public void ToOutputItem_ApplyPatchToolCallItemParam_DeleteFile()
    {
        var operation = new ApplyPatchDeleteFileOperationParam("old.txt");
        var applyPatch = new ApplyPatchToolCallItemParam("call_del", ApplyPatchCallStatusParam.Completed, operation);

        var result = ItemConversion.ToOutputItem(applyPatch, PartitionKeyHint);

        var converted = XAssert.IsType<OutputItemApplyPatchToolCall>(result);
        var deleteOp = XAssert.IsType<ApplyPatchDeleteFileOperation>(converted.Operation);
        Assert.That(deleteOp.Path, Is.EqualTo("old.txt"));
    }

    [Test]
    public void ToOutputItem_ApplyPatchToolCallItemParam_UpdateFile()
    {
        var operation = new ApplyPatchUpdateFileOperationParam("readme.md", "+new line");
        var applyPatch = new ApplyPatchToolCallItemParam("call_upd", ApplyPatchCallStatusParam.InProgress, operation);

        var result = ItemConversion.ToOutputItem(applyPatch, PartitionKeyHint);

        var converted = XAssert.IsType<OutputItemApplyPatchToolCall>(result);
        Assert.That(converted.Status, Is.EqualTo(ApplyPatchCallStatus.InProgress));
        var updateOp = XAssert.IsType<ApplyPatchUpdateFileOperation>(converted.Operation);
        Assert.That(updateOp.Path, Is.EqualTo("readme.md"));
    }

    [Test]
    public void ToOutputItem_ApplyPatchToolCallOutputItemParam_ReturnsOutputItemApplyPatchToolCallOutput()
    {
        var applyPatchOutput = new ApplyPatchToolCallOutputItemParam("call_apo",
            ApplyPatchCallOutputStatusParam.Completed)
        { Output = "patch applied" };

        var result = ItemConversion.ToOutputItem(applyPatchOutput, PartitionKeyHint);

        var converted = XAssert.IsType<OutputItemApplyPatchToolCallOutput>(result);
        XAssert.StartsWith("apo_", converted.Id);
        Assert.That(converted.CallId, Is.EqualTo("call_apo"));
        Assert.That(converted.Status, Is.EqualTo(ApplyPatchCallOutputStatus.Completed));
        Assert.That(converted.Output, Is.EqualTo("patch applied"));
    }

    [Test]
    public void ToOutputItem_ApplyPatchToolCallOutputItemParam_Failed()
    {
        var applyPatchOutput = new ApplyPatchToolCallOutputItemParam("call_fail",
            ApplyPatchCallOutputStatusParam.Failed)
        { Output = "conflict" };

        var result = ItemConversion.ToOutputItem(applyPatchOutput, PartitionKeyHint);

        var converted = XAssert.IsType<OutputItemApplyPatchToolCallOutput>(result);
        Assert.That(converted.Status, Is.EqualTo(ApplyPatchCallOutputStatus.Failed));
    }

    // ── MCP ─────────────────────────────────────────────────────────────

    [Test]
    public void ToOutputItem_ItemMcpListTools_ReturnsOutputItemMcpListTools()
    {
        var mcpList = new ItemMcpListTools("mcp_lt", "server_1",
            new List<MCPListToolsTool>());

        var result = ItemConversion.ToOutputItem(mcpList, PartitionKeyHint);

        var converted = XAssert.IsType<OutputItemMcpListTools>(result);
        XAssert.StartsWith("mcpl_", converted.Id);
        Assert.That(converted.ServerLabel, Is.EqualTo("server_1"));
        Assert.That(converted.Tools, Is.Empty);
    }

    [Test]
    public void ToOutputItem_ItemMcpToolCall_ReturnsOutputItemMcpToolCall()
    {
        var mcpCall = new ItemMcpToolCall("mcp_tc", "server_2", "tool_name", "{}")
        {
            Output = "result",
            ApprovalRequestId = "ar_1",
        };

        var result = ItemConversion.ToOutputItem(mcpCall, PartitionKeyHint);

        var converted = XAssert.IsType<OutputItemMcpToolCall>(result);
        XAssert.StartsWith("mcp_", converted.Id);
        Assert.That(converted.ServerLabel, Is.EqualTo("server_2"));
        Assert.That(converted.Name, Is.EqualTo("tool_name"));
        Assert.That(converted.Arguments, Is.EqualTo("{}"));
        Assert.That(converted.Output, Is.EqualTo("result"));
        Assert.That(converted.ApprovalRequestId, Is.EqualTo("ar_1"));
        Assert.That(converted.Status, Is.EqualTo(MCPToolCallStatus.Completed));
    }

    [Test]
    public void ToOutputItem_ItemMcpApprovalRequest_ReturnsOutputItemMcpApprovalRequest()
    {
        var mcpApproval = new ItemMcpApprovalRequest("mcp_ar", "server_3", "dangerous_tool", "{}");

        var result = ItemConversion.ToOutputItem(mcpApproval, PartitionKeyHint);

        var converted = XAssert.IsType<OutputItemMcpApprovalRequest>(result);
        XAssert.StartsWith("mcpr_", converted.Id);
        Assert.That(converted.ServerLabel, Is.EqualTo("server_3"));
        Assert.That(converted.Name, Is.EqualTo("dangerous_tool"));
    }

    [Test]
    public void ToOutputItem_MCPApprovalResponse_ReturnsOutputItemMcpApprovalResponseResource()
    {
        var mcpResponse = new MCPApprovalResponse("ar_2", true) { Id = "mcp_resp", Reason = "Looks safe" };

        var result = ItemConversion.ToOutputItem(mcpResponse, PartitionKeyHint);

        var converted = XAssert.IsType<OutputItemMcpApprovalResponseResource>(result);
        XAssert.StartsWith("mcpa_", converted.Id);
        Assert.That(converted.ApprovalRequestId, Is.EqualTo("ar_2"));
        Assert.That(converted.Approve, Is.True);
        Assert.That(converted.Reason, Is.EqualTo("Looks safe"));
    }

    // ── Reasoning ───────────────────────────────────────────────────────

    [Test]
    public void ToOutputItem_ItemReasoningItem_ReturnsOutputItemReasoningItem()
    {
        var summary = new List<SummaryTextContent> { new SummaryTextContent("thinking...") };
        var reasoning = new ItemReasoningItem("ri_1", summary)
        {
            EncryptedContent = "encrypted_blob",
        };

        var result = ItemConversion.ToOutputItem(reasoning, PartitionKeyHint);

        var converted = XAssert.IsType<OutputItemReasoningItem>(result);
        XAssert.StartsWith("rs_", converted.Id);
        XAssert.Single(converted.Summary);
        Assert.That(converted.Summary[0].Text, Is.EqualTo("thinking..."));
        Assert.That(converted.EncryptedContent, Is.EqualTo("encrypted_blob"));
        Assert.That(converted.Status, Is.EqualTo(OutputItemReasoningItemStatus.Completed));
    }

    // ── Compaction ──────────────────────────────────────────────────────

    [Test]
    public void ToOutputItem_CompactionSummaryItemParam_ReturnsOutputItemCompactionBody()
    {
        var compaction = new CompactionSummaryItemParam("encrypted_data");

        var result = ItemConversion.ToOutputItem(compaction, PartitionKeyHint);

        var converted = XAssert.IsType<OutputItemCompactionBody>(result);
        XAssert.StartsWith("cmp_", converted.Id);
        Assert.That(converted.EncryptedContent, Is.EqualTo("encrypted_data"));
    }

    // ── Reference & unknown ─────────────────────────────────────────────

    [Test]
    public void ToOutputItem_ItemReferenceParam_ReturnsNull()
    {
        var reference = new ItemReferenceParam("existing_item_id");

        var result = ItemConversion.ToOutputItem(reference, PartitionKeyHint);

        Assert.That(result, Is.Null);
    }

    // ── Batch conversion ────────────────────────────────────────────────

    [Test]
    public void ToOutputItems_MixedItems_ConvertsInlineAndSkipsReferences()
    {
        var items = new List<Item>
        {
            new ItemMessage(MessageRole.User, BinaryData.FromObjectAsJson("Hello")),
            new ItemReferenceParam("ref_1"),
            new FunctionCallOutputItemParam("call_1", BinaryData.FromObjectAsJson("result")),
        };

        var results = ItemConversion.ToOutputItems(items, PartitionKeyHint).ToList();

        Assert.That(results.Count, Is.EqualTo(2));
        var msg = XAssert.IsType<OutputItemMessage>(results[0]);
        XAssert.StartsWith("msg_", msg.Id);
        var fco = XAssert.IsType<FunctionToolCallOutputResource>(results[1]);
        XAssert.StartsWith("fco_", fco.Id);
    }

    [Test]
    public void ToOutputItems_EmptyInput_ReturnsEmpty()
    {
        var items = Enumerable.Empty<Item>();

        var results = ItemConversion.ToOutputItems(items, PartitionKeyHint).ToList();

        Assert.That(results, Is.Empty);
    }

    [Test]
    public void ToOutputItems_AllNewTypes_ConvertsSuccessfully()
    {
        var items = new List<Item>
        {
            new ItemFunctionToolCall("call_f", "func", "{}"),
            new ItemCustomToolCall("call_c", "custom", "in"),
            new ItemWebSearchToolCall("ws_id", OutputItemWebSearchToolCallStatus.Completed, BinaryData.FromObjectAsJson("search")),
            new CompactionSummaryItemParam("enc"),
        };

        var results = ItemConversion.ToOutputItems(items, PartitionKeyHint).ToList();

        Assert.That(results.Count, Is.EqualTo(4));
        var fc = XAssert.IsType<OutputItemFunctionToolCall>(results[0]);
        XAssert.StartsWith("fc_", fc.Id);
        var ctc = XAssert.IsType<OutputItemCustomToolCall>(results[1]);
        XAssert.StartsWith("ctc_", ctc.Id);
        var ws = XAssert.IsType<OutputItemWebSearchToolCall>(results[2]);
        XAssert.StartsWith("ws_", ws.Id);
        var cmp = XAssert.IsType<OutputItemCompactionBody>(results[3]);
        XAssert.StartsWith("cmp_", cmp.Id);
    }

    // ── ID prefix correctness ───────────────────────────────────────────

    [Test]
    public void ToOutputItem_GeneratesUniqueIds_ForSameItemType()
    {
        var msg1 = new ItemMessage(MessageRole.User, BinaryData.FromObjectAsJson("a"));
        var msg2 = new ItemMessage(MessageRole.User, BinaryData.FromObjectAsJson("b"));

        var result1 = ItemConversion.ToOutputItem(msg1, PartitionKeyHint);
        var result2 = ItemConversion.ToOutputItem(msg2, PartitionKeyHint);

        Assert.That(result1, Is.Not.Null);
        Assert.That(result2, Is.Not.Null);
        var msg1Out = XAssert.IsType<OutputItemMessage>(result1);
        var msg2Out = XAssert.IsType<OutputItemMessage>(result2);
        Assert.That(msg2Out.Id, Is.Not.EqualTo(msg1Out.Id));
        XAssert.StartsWith("msg_", msg1Out.Id);
        XAssert.StartsWith("msg_", msg2Out.Id);
    }
}
