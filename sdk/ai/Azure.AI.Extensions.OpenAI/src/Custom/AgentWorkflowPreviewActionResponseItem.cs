// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Diagnostics.CodeAnalysis;

namespace Azure.AI.Extensions.OpenAI;

[Experimental("AAIP001")]
[CodeGenType("WorkflowActionOutputItem")]
public partial class AgentWorkflowPreviewActionResponseItem
{
    [CodeGenMember("Status")]
    public AgentWorkflowPreviewActionStatus? Status { get; }
}
