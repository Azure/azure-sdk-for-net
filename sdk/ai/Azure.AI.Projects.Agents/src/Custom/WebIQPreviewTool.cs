// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using OpenAI.Responses;

namespace Azure.AI.Projects.Agents;

public partial class WebIQPreviewTool
{
    /// <summary>
    /// (Optional) Whether the agent requires approval before executing actions. Default is always.
    /// </summary>
    [CodeGenMember("RequireApproval")]
    public BinaryData RequireApprovalInternal { get; set; }

    /// <summary>
    /// Whether the agent requires approval before executing actions. Default is always.
    /// </summary>
    public McpToolCallApprovalPolicy RequireApproval { get => ModelReaderWriter.Read<McpToolCallApprovalPolicy>(RequireApprovalInternal, ModelSerializationExtensions.WireOptions, AzureAIProjectsAgentsContext.Default); set => RequireApprovalInternal = ModelReaderWriter.Write(value, ModelSerializationExtensions.WireOptions, AzureAIProjectsAgentsContext.Default); }
}
