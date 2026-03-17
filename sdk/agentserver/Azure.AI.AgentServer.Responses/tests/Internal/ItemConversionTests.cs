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
        var message = new ItemMessage("msg_input", MessageStatus.Completed, MessageRole.User, content);

        var result = ItemConversion.ToOutputItem(message, PartitionKeyHint);

        var outputMessage = XAssert.IsType<OutputItemMessage>(result);
        XAssert.StartsWith("msg_", outputMessage.Id);
        Assert.AreEqual(MessageStatus.Completed, outputMessage.Status);
        Assert.AreEqual(MessageRole.User, outputMessage.Role);
        Assert.IsNotEmpty(outputMessage.Content);
    }

    [Test]
    public void ToOutputItem_ItemMessage_PreservesRole()
    {
        var content = BinaryData.FromObjectAsJson("System prompt");
        var message = new ItemMessage("msg_dev", MessageStatus.Completed, MessageRole.Developer, content);

        var result = ItemConversion.ToOutputItem(message, PartitionKeyHint);

        var outputMessage = XAssert.IsType<OutputItemMessage>(result);
        XAssert.StartsWith("msg_", outputMessage.Id);
        Assert.AreEqual(MessageRole.Developer, outputMessage.Role);
    }

    [Test]
    public void ToOutputItem_ItemOutputMessage_ReturnsOutputItemOutputMessage()
    {
        var content = new List<OutputMessageContent>
        {
            new OutputMessageContentOutputTextContent("Hello from assistant", Array.Empty<Annotation>(), Array.Empty<LogProb>()),
        };
        var outputMsg = new ItemOutputMessage("om_1", content, OutputItemOutputMessageStatus.Completed);

        var result = ItemConversion.ToOutputItem(outputMsg, PartitionKeyHint);

        var converted = XAssert.IsType<OutputItemOutputMessage>(result);
        XAssert.StartsWith("om_", converted.Id);
        Assert.AreEqual(OutputItemOutputMessageStatus.Completed, converted.Status);
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
        Assert.AreEqual("call_func", converted.CallId);
        Assert.AreEqual("get_weather", converted.Name);
        Assert.AreEqual("{\"city\":\"Seattle\"}", converted.Arguments);
        Assert.AreEqual(OutputItemFunctionToolCallStatus.Completed, converted.Status);
    }

    [Test]
    public void ToOutputItem_FunctionCallOutputItemParam_ReturnsFunctionToolCallOutputResource()
    {
        var output = BinaryData.FromObjectAsJson("function result");
        var funcOutput = new FunctionCallOutputItemParam("call_123", output);

        var result = ItemConversion.ToOutputItem(funcOutput, PartitionKeyHint);

        var outputFunc = XAssert.IsType<FunctionToolCallOutputResource>(result);
        XAssert.StartsWith("fco_", outputFunc.Id);
        Assert.AreEqual("call_123", outputFunc.CallId);
        Assert.AreEqual(FunctionToolCallOutputResourceStatus.Completed, outputFunc.Status);
    }

    // ── Custom tool calls ───────────────────────────────────────────────

    [Test]
    public void ToOutputItem_ItemCustomToolCall_ReturnsOutputItemCustomToolCall()
    {
        var customCall = new ItemCustomToolCall("call_ct", "my_tool", "some input");

        var result = ItemConversion.ToOutputItem(customCall, PartitionKeyHint);

        var converted = XAssert.IsType<OutputItemCustomToolCall>(result);
        XAssert.StartsWith("ctc_", converted.Id);
        Assert.AreEqual("call_ct", converted.CallId);
        Assert.AreEqual("my_tool", converted.Name);
        Assert.AreEqual("some input", converted.Input);
    }

    [Test]
    public void ToOutputItem_ItemCustomToolCallOutput_ReturnsOutputItemCustomToolCallOutput()
    {
        var output = BinaryData.FromObjectAsJson("custom result");
        var customOutput = new ItemCustomToolCallOutput("call_cto", output);

        var result = ItemConversion.ToOutputItem(customOutput, PartitionKeyHint);

        var converted = XAssert.IsType<OutputItemCustomToolCallOutput>(result);
        XAssert.StartsWith("ctco_", converted.Id);
        Assert.AreEqual("call_cto", converted.CallId);
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
        Assert.AreEqual("call_comp", converted.CallId);
        Assert.AreEqual(OutputItemComputerToolCallStatus.Completed, converted.Status);
    }

    [Test]
    public void ToOutputItem_ComputerCallOutputItemParam_ReturnsOutputItemComputerToolCallOutputResource()
    {
        var screenshot = new ComputerScreenshotImage();
        var computerOutput = new ComputerCallOutputItemParam("call_456", screenshot);

        var result = ItemConversion.ToOutputItem(computerOutput, PartitionKeyHint);

        var outputComputer = XAssert.IsType<OutputItemComputerToolCallOutputResource>(result);
        XAssert.StartsWith("cuo_", outputComputer.Id);
        Assert.AreEqual("call_456", outputComputer.CallId);
        Assert.AreEqual(OutputItemComputerToolCallOutputResourceStatus.Completed, outputComputer.Status);
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
        Assert.AreEqual(OutputItemFileSearchToolCallStatus.Completed, converted.Status);
        XAssert.Single(converted.Queries);
        Assert.AreEqual("query1", converted.Queries[0]);
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
        Assert.AreEqual(OutputItemWebSearchToolCallStatus.Completed, converted.Status);
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
        Assert.AreEqual(OutputItemImageGenToolCallStatus.Completed, converted.Status);
        Assert.AreEqual("base64data", converted.Result);
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
        Assert.AreEqual(OutputItemCodeInterpreterToolCallStatus.Completed, converted.Status);
        Assert.AreEqual("container_1", converted.ContainerId);
        Assert.AreEqual("print('hello')", converted.Code);
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
        Assert.AreEqual("call_ls", converted.CallId);
        Assert.AreEqual(OutputItemLocalShellToolCallStatus.Completed, converted.Status);
    }

    [Test]
    public void ToOutputItem_ItemLocalShellToolCallOutput_ReturnsOutputItemLocalShellToolCallOutput()
    {
        var localShellOutput = new ItemLocalShellToolCallOutput("lso_id", "some output");

        var result = ItemConversion.ToOutputItem(localShellOutput, PartitionKeyHint);

        var converted = XAssert.IsType<OutputItemLocalShellToolCallOutput>(result);
        XAssert.StartsWith("lsho_", converted.Id);
        Assert.AreEqual("some output", converted.Output);
        Assert.AreEqual(OutputItemLocalShellToolCallOutputStatus.Completed, converted.Status);
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
        Assert.AreEqual("call_sh", converted.CallId);
        Assert.AreEqual(LocalShellCallStatus.Completed, converted.Status);
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
        Assert.AreEqual("call_sho", converted.CallId);
        Assert.AreEqual(LocalShellCallOutputStatusEnum.Completed, converted.Status);
        XAssert.Single(converted.Output);
        Assert.AreEqual("hello\n", converted.Output[0].Stdout);
        XAssert.IsType<FunctionShellCallOutputExitOutcome>(converted.Output[0].Outcome);
        Assert.AreEqual(4096, converted.MaxOutputLength);
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
        Assert.AreEqual("call_ap", converted.CallId);
        Assert.AreEqual(ApplyPatchCallStatus.Completed, converted.Status);
        var createOp = XAssert.IsType<ApplyPatchCreateFileOperation>(converted.Operation);
        Assert.AreEqual("src/main.cs", createOp.Path);
        Assert.AreEqual("+using System;", createOp.Diff);
    }

    [Test]
    public void ToOutputItem_ApplyPatchToolCallItemParam_DeleteFile()
    {
        var operation = new ApplyPatchDeleteFileOperationParam("old.txt");
        var applyPatch = new ApplyPatchToolCallItemParam("call_del", ApplyPatchCallStatusParam.Completed, operation);

        var result = ItemConversion.ToOutputItem(applyPatch, PartitionKeyHint);

        var converted = XAssert.IsType<OutputItemApplyPatchToolCall>(result);
        var deleteOp = XAssert.IsType<ApplyPatchDeleteFileOperation>(converted.Operation);
        Assert.AreEqual("old.txt", deleteOp.Path);
    }

    [Test]
    public void ToOutputItem_ApplyPatchToolCallItemParam_UpdateFile()
    {
        var operation = new ApplyPatchUpdateFileOperationParam("readme.md", "+new line");
        var applyPatch = new ApplyPatchToolCallItemParam("call_upd", ApplyPatchCallStatusParam.InProgress, operation);

        var result = ItemConversion.ToOutputItem(applyPatch, PartitionKeyHint);

        var converted = XAssert.IsType<OutputItemApplyPatchToolCall>(result);
        Assert.AreEqual(ApplyPatchCallStatus.InProgress, converted.Status);
        var updateOp = XAssert.IsType<ApplyPatchUpdateFileOperation>(converted.Operation);
        Assert.AreEqual("readme.md", updateOp.Path);
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
        Assert.AreEqual("call_apo", converted.CallId);
        Assert.AreEqual(ApplyPatchCallOutputStatus.Completed, converted.Status);
        Assert.AreEqual("patch applied", converted.Output);
    }

    [Test]
    public void ToOutputItem_ApplyPatchToolCallOutputItemParam_Failed()
    {
        var applyPatchOutput = new ApplyPatchToolCallOutputItemParam("call_fail",
            ApplyPatchCallOutputStatusParam.Failed)
        { Output = "conflict" };

        var result = ItemConversion.ToOutputItem(applyPatchOutput, PartitionKeyHint);

        var converted = XAssert.IsType<OutputItemApplyPatchToolCallOutput>(result);
        Assert.AreEqual(ApplyPatchCallOutputStatus.Failed, converted.Status);
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
        Assert.AreEqual("server_1", converted.ServerLabel);
        Assert.IsEmpty(converted.Tools);
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
        Assert.AreEqual("server_2", converted.ServerLabel);
        Assert.AreEqual("tool_name", converted.Name);
        Assert.AreEqual("{}", converted.Arguments);
        Assert.AreEqual("result", converted.Output);
        Assert.AreEqual("ar_1", converted.ApprovalRequestId);
        Assert.AreEqual(MCPToolCallStatus.Completed, converted.Status);
    }

    [Test]
    public void ToOutputItem_ItemMcpApprovalRequest_ReturnsOutputItemMcpApprovalRequest()
    {
        var mcpApproval = new ItemMcpApprovalRequest("mcp_ar", "server_3", "dangerous_tool", "{}");

        var result = ItemConversion.ToOutputItem(mcpApproval, PartitionKeyHint);

        var converted = XAssert.IsType<OutputItemMcpApprovalRequest>(result);
        XAssert.StartsWith("mcpr_", converted.Id);
        Assert.AreEqual("server_3", converted.ServerLabel);
        Assert.AreEqual("dangerous_tool", converted.Name);
    }

    [Test]
    public void ToOutputItem_MCPApprovalResponse_ReturnsOutputItemMcpApprovalResponseResource()
    {
        var mcpResponse = new MCPApprovalResponse("ar_2", true) { Id = "mcp_resp", Reason = "Looks safe" };

        var result = ItemConversion.ToOutputItem(mcpResponse, PartitionKeyHint);

        var converted = XAssert.IsType<OutputItemMcpApprovalResponseResource>(result);
        XAssert.StartsWith("mcpa_", converted.Id);
        Assert.AreEqual("ar_2", converted.ApprovalRequestId);
        Assert.IsTrue(converted.Approve);
        Assert.AreEqual("Looks safe", converted.Reason);
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
        Assert.AreEqual("thinking...", converted.Summary[0].Text);
        Assert.AreEqual("encrypted_blob", converted.EncryptedContent);
        Assert.AreEqual(OutputItemReasoningItemStatus.Completed, converted.Status);
    }

    // ── Compaction ──────────────────────────────────────────────────────

    [Test]
    public void ToOutputItem_CompactionSummaryItemParam_ReturnsOutputItemCompactionBody()
    {
        var compaction = new CompactionSummaryItemParam("encrypted_data");

        var result = ItemConversion.ToOutputItem(compaction, PartitionKeyHint);

        var converted = XAssert.IsType<OutputItemCompactionBody>(result);
        XAssert.StartsWith("cmp_", converted.Id);
        Assert.AreEqual("encrypted_data", converted.EncryptedContent);
    }

    // ── Reference & unknown ─────────────────────────────────────────────

    [Test]
    public void ToOutputItem_ItemReferenceParam_ReturnsNull()
    {
        var reference = new ItemReferenceParam("existing_item_id");

        var result = ItemConversion.ToOutputItem(reference, PartitionKeyHint);

        Assert.IsNull(result);
    }

    // ── Batch conversion ────────────────────────────────────────────────

    [Test]
    public void ToOutputItems_MixedItems_ConvertsInlineAndSkipsReferences()
    {
        var items = new List<Item>
        {
            new ItemMessage("msg_1", MessageStatus.Completed, MessageRole.User, BinaryData.FromObjectAsJson("Hello")),
            new ItemReferenceParam("ref_1"),
            new FunctionCallOutputItemParam("call_1", BinaryData.FromObjectAsJson("result")),
        };

        var results = ItemConversion.ToOutputItems(items, PartitionKeyHint).ToList();

        Assert.AreEqual(2, results.Count);
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

        Assert.IsEmpty(results);
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

        Assert.AreEqual(4, results.Count);
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
        var msg1 = new ItemMessage("m1", MessageStatus.Completed, MessageRole.User, BinaryData.FromObjectAsJson("a"));
        var msg2 = new ItemMessage("m2", MessageStatus.Completed, MessageRole.User, BinaryData.FromObjectAsJson("b"));

        var result1 = ItemConversion.ToOutputItem(msg1, PartitionKeyHint);
        var result2 = ItemConversion.ToOutputItem(msg2, PartitionKeyHint);

        Assert.IsNotNull(result1);
        Assert.IsNotNull(result2);
        var msg1Out = XAssert.IsType<OutputItemMessage>(result1);
        var msg2Out = XAssert.IsType<OutputItemMessage>(result2);
        Assert.AreNotEqual(msg1Out.Id, msg2Out.Id);
        XAssert.StartsWith("msg_", msg1Out.Id);
        XAssert.StartsWith("msg_", msg2Out.Id);
    }
}
