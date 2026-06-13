// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.AI.Extensions.OpenAI;

[CodeGenType("WorkflowActionOutputItem")]
public partial class AgentWorkflowPreviewActionResponseItem
{
    /// <summary> Gets the status of the workflow preview action. </summary>
    [CodeGenMember("Status")]
    public AgentWorkflowPreviewActionStatus? Status { get; }
}
