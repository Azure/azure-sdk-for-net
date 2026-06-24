// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using OpenAI.Responses;

namespace Azure.AI.Projects.Agents;

public partial class MCPToolboxTool
{
    [CodeGenMember("RequireApproval")]
    internal BinaryData RequireApprovalInternal { get; set; }

    /// <summary>
    /// The approval policy used by the tool.
    /// </summary>
    public McpToolCallApprovalPolicy ToolCallApprovalPolicy { get => ModelReaderWriter.Read<McpToolCallApprovalPolicy>(RequireApprovalInternal, ModelReaderWriterOptions.Json, AzureAIProjectsAgentsContext.Default); set => RequireApprovalInternal = ModelReaderWriter.Write(value, ModelSerializationExtensions.WireOptions, AzureAIProjectsAgentsContext.Default); }
    /// <summary>
    /// The URI of an MCP server.
    /// </summary>
    [CodeGenMember("ServerUrl")]
    public Uri ServerUri { get; set; }
}
