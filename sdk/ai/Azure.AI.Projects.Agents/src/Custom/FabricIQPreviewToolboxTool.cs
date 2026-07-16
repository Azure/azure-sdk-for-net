// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using OpenAI.Responses;

namespace Azure.AI.Projects.Agents;

public partial class FabricIQPreviewToolboxTool
{
    /// <summary>
    /// (Optional) Whether the agent requires approval before executing actions. Default is always.
    /// <para> To assign an object to this property use <see cref="BinaryData.FromObjectAsJson{T}(T, System.Text.Json.JsonSerializerOptions?)"/>. </para>
    /// <para> To assign an already formatted json string to this property use <see cref="BinaryData.FromString(string)"/>. </para>
    /// <para>
    /// <remarks>
    /// Supported types:
    /// <list type="bullet">
    /// <item>
    /// <description> <see cref="McpToolCallApprovalPolicy"/>. </description>
    /// </item>
    /// <item>
    /// <description> <see cref="string"/>. </description>
    /// </item>
    /// </list>
    /// </remarks>
    /// </para>
    /// <para>
    /// Examples:
    /// <list type="bullet">
    /// <item>
    /// <term> BinaryData.FromObjectAsJson("foo"). </term>
    /// <description> Creates a payload of "foo". </description>
    /// </item>
    /// <item>
    /// <term> BinaryData.FromString("\"foo\""). </term>
    /// <description> Creates a payload of "foo". </description>
    /// </item>
    /// <item>
    /// <term> BinaryData.FromObjectAsJson(new { key = "value" }). </term>
    /// <description> Creates a payload of { "key": "value" }. </description>
    /// </item>
    /// <item>
    /// <term> BinaryData.FromString("{\"key\": \"value\"}"). </term>
    /// <description> Creates a payload of { "key": "value" }. </description>
    /// </item>
    /// </list>
    /// </para>
    /// </summary>
    [CodeGenMember("RequireApproval")]
    public BinaryData RequireApprovalInternal { get; set; }

    /// <summary>
    /// Approval policy for FabricIQ tools.
    /// </summary>
    public McpToolCallApprovalPolicy RequireApproval { get => ModelReaderWriter.Read<McpToolCallApprovalPolicy>(RequireApprovalInternal, ModelSerializationExtensions.WireOptions, AzureAIProjectsAgentsContext.Default); set => RequireApprovalInternal = ModelReaderWriter.Write(value, ModelSerializationExtensions.WireOptions, AzureAIProjectsAgentsContext.Default); }
}
