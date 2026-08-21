// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#pragma warning disable CS1591

using System;
using System.ComponentModel;
using OpenAI.Responses;

namespace Azure.AI.Extensions.OpenAI;

public readonly partial struct AgentResponseItemKind : IEquatable<AgentResponseItemKind>
{
    private readonly string _value;

    public AgentResponseItemKind(string value) => _value = value ?? throw new ArgumentNullException(nameof(value));

    public static AgentResponseItemKind Message { get; } = new("message");
    public static AgentResponseItemKind OutputMessage { get; } = new("output_message");
    public static AgentResponseItemKind FileSearchCall { get; } = new("file_search_call");
    public static AgentResponseItemKind FunctionCall { get; } = new("function_call");
    public static AgentResponseItemKind FunctionCallOutput { get; } = new("function_call_output");
    public static AgentResponseItemKind WebSearchCall { get; } = new("web_search_call");
    public static AgentResponseItemKind ComputerCall { get; } = new("computer_call");
    public static AgentResponseItemKind ComputerCallOutput { get; } = new("computer_call_output");
    public static AgentResponseItemKind Reasoning { get; } = new("reasoning");
    public static AgentResponseItemKind ToolSearchCall { get; } = new("tool_search_call");
    public static AgentResponseItemKind ToolSearchOutput { get; } = new("tool_search_output");
    public static AgentResponseItemKind Compaction { get; } = new("compaction");
    public static AgentResponseItemKind ImageGenerationCall { get; } = new("image_generation_call");
    public static AgentResponseItemKind CodeInterpreterCall { get; } = new("code_interpreter_call");
    public static AgentResponseItemKind LocalShellCall { get; } = new("local_shell_call");
    public static AgentResponseItemKind LocalShellCallOutput { get; } = new("local_shell_call_output");
    public static AgentResponseItemKind ShellCall { get; } = new("shell_call");
    public static AgentResponseItemKind ShellCallOutput { get; } = new("shell_call_output");
    public static AgentResponseItemKind ApplyPatchCall { get; } = new("apply_patch_call");
    public static AgentResponseItemKind ApplyPatchCallOutput { get; } = new("apply_patch_call_output");
    public static AgentResponseItemKind McpCall { get; } = new("mcp_call");
    public static AgentResponseItemKind McpListTools { get; } = new("mcp_list_tools");
    public static AgentResponseItemKind McpApprovalRequest { get; } = new("mcp_approval_request");
    public static AgentResponseItemKind McpApprovalResponse { get; } = new("mcp_approval_response");
    public static AgentResponseItemKind CustomToolCall { get; } = new("custom_tool_call");
    public static AgentResponseItemKind CustomToolCallOutput { get; } = new("custom_tool_call_output");
    public static AgentResponseItemKind StructuredOutputs { get; } = new("structured_outputs");
    public static AgentResponseItemKind OauthConsentRequest { get; } = new("oauth_consent_request");
    public static AgentResponseItemKind MemorySearchCall { get; } = new("memory_search_call");
    public static AgentResponseItemKind MemoryCommandPreviewCall { get; } = new("memory_command_preview_call");
    public static AgentResponseItemKind MemoryCommandPreviewCallOutput { get; } = new("memory_command_preview_call_output");
    public static AgentResponseItemKind WorkflowAction { get; } = new("workflow_action");
    public static AgentResponseItemKind A2APreviewCall { get; } = new("a2a_preview_call");
    public static AgentResponseItemKind A2APreviewCallOutput { get; } = new("a2a_preview_call_output");
    public static AgentResponseItemKind BingGroundingCall { get; } = new("bing_grounding_call");
    public static AgentResponseItemKind BingGroundingCallOutput { get; } = new("bing_grounding_call_output");
    public static AgentResponseItemKind SharepointGroundingPreviewCall { get; } = new("sharepoint_grounding_preview_call");
    public static AgentResponseItemKind SharepointGroundingPreviewCallOutput { get; } = new("sharepoint_grounding_preview_call_output");
    public static AgentResponseItemKind AzureAiSearchCall { get; } = new("azure_ai_search_call");
    public static AgentResponseItemKind AzureAiSearchCallOutput { get; } = new("azure_ai_search_call_output");
    public static AgentResponseItemKind BingCustomSearchPreviewCall { get; } = new("bing_custom_search_preview_call");
    public static AgentResponseItemKind BingCustomSearchPreviewCallOutput { get; } = new("bing_custom_search_preview_call_output");
    public static AgentResponseItemKind OpenapiCall { get; } = new("openapi_call");
    public static AgentResponseItemKind OpenapiCallOutput { get; } = new("openapi_call_output");
    public static AgentResponseItemKind BrowserAutomationPreviewCall { get; } = new("browser_automation_preview_call");
    public static AgentResponseItemKind BrowserAutomationPreviewCallOutput { get; } = new("browser_automation_preview_call_output");
    public static AgentResponseItemKind FabricDataagentPreviewCall { get; } = new("fabric_dataagent_preview_call");
    public static AgentResponseItemKind FabricDataagentPreviewCallOutput { get; } = new("fabric_dataagent_preview_call_output");
    public static AgentResponseItemKind AzureFunctionCall { get; } = new("azure_function_call");
    public static AgentResponseItemKind AzureFunctionCallOutput { get; } = new("azure_function_call_output");

    public static bool operator ==(AgentResponseItemKind left, AgentResponseItemKind right) => left.Equals(right);
    public static bool operator !=(AgentResponseItemKind left, AgentResponseItemKind right) => !left.Equals(right);
    public static implicit operator AgentResponseItemKind(string value) => new(value);
    public static implicit operator AgentResponseItemKind?(string value) => value == null ? null : new(value);
    public static implicit operator ResponseItemKind(AgentResponseItemKind value) => new(value._value);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public override bool Equals(object obj) => obj is AgentResponseItemKind other && Equals(other);
    public bool Equals(AgentResponseItemKind other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
    public override string ToString() => _value;
}
