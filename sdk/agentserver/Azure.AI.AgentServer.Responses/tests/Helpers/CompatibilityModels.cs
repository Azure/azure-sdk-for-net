// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Responses.Models;
using Azure.AI.Extensions.OpenAI;
using OpenAI.Responses;

namespace Azure.AI.AgentServer.Responses.Tests.Helpers;

internal class FunctionCallOutputItemParam : FunctionCallOutputResponseItem
{
    public FunctionCallOutputItemParam(string callId, BinaryData output)
        : base(callId, output.ToString()) => OutputItems = output;

    public BinaryData? OutputItems { get; }

    public string Output => FunctionOutput;
}

internal class ItemCustomToolCall : FunctionCallResponseItem
{
    public ItemCustomToolCall(string callId, string name, string input)
        : base(callId, name, BinaryData.FromString(input)) { }

    public string Name => FunctionName;
    public new string FunctionArguments => base.FunctionArguments.ToString();
}

internal class ItemCustomToolCallOutput : FunctionCallOutputItemParam
{
    public ItemCustomToolCallOutput(string callId, BinaryData output) : base(callId, output) { }
}

internal class ItemComputerToolCall : ComputerCallResponseItem
{
    public ItemComputerToolCall(string id, string callId, IEnumerable<ComputerCallSafetyCheckParam> pendingSafetyChecks, ComputerCallStatus status)
        : base(callId, null!, Array.Empty<ComputerCallSafetyCheck>())
    {
        Id = id;
        Status = status;
    }

    public new object? Action { get; set; }
}

internal class ComputerCallOutputItemParam : ComputerCallOutputResponseItem
{
    public ComputerCallOutputItemParam(string callId, object output) : base(callId, null!) { }
}

internal class ItemWebSearchToolCall : WebSearchCallResponseItem
{
    public ItemWebSearchToolCall(string id, WebSearchCallStatus status, BinaryData action)
    {
        Id = id;
        Status = status;
    }
}

internal class ItemImageGenToolCall : ImageGenerationCallResponseItem
{
    public ItemImageGenToolCall(string id, ImageGenerationCallStatus status, string result) : base(BinaryData.FromString(result))
    {
        Id = id;
        Status = status;
    }
}

internal class ItemCodeInterpreterToolCall : CodeInterpreterCallResponseItem
{
    public ItemCodeInterpreterToolCall(string id, CodeInterpreterCallStatus status, string containerId, string code, IEnumerable<BinaryData> outputs)
        : base(code)
    {
        Id = id;
        Status = status;
        ContainerId = containerId;
    }
}

internal class ItemMcpToolCall : McpToolCallItem
{
    public ItemMcpToolCall(string id, string serverLabel, string toolName, string toolArguments)
        : base(serverLabel, toolName, BinaryData.FromString(toolArguments)) => Id = id;

    public string? Output { get => ToolOutput; set => ToolOutput = value; }
    public string? ApprovalRequestId { get; set; }
    public string Name => ToolName;
    public string FunctionName => ToolName;
    public string FunctionArguments => ToolArguments.ToString();
    public string Status { get; set; } = "completed";
    public IList<ResponseItem> OutputItems { get; } = new List<ResponseItem>();
}

internal class ItemMcpListTools : McpToolDefinitionListItem
{
    public ItemMcpListTools(string id, string serverLabel, IEnumerable<McpToolDefinition> tools) : base(serverLabel, Array.Empty<McpToolDefinition>()) => Id = id;
}

internal class MCPApprovalResponse : McpToolCallApprovalResponseItem
{
    public MCPApprovalResponse(string approvalRequestId, bool approved) : base(approvalRequestId, approved) { }

    public new string? Id { get => ApprovalRequestId; set { } }
}

internal class CompactionSummaryItemParam : OutputItemCompactionBody
{
    public CompactionSummaryItemParam(string encryptedContent) : base("cmp_test", encryptedContent) { }
}
