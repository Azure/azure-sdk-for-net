// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.AI.Projects.OpenAI;

[CodeGenType("WorkflowActionOutputItemResource")]
public partial class AgentWorkflowActionResponseItem
{
    [CodeGenMember("Status")]
    public AgentWorkflowActionStatus? Status { get; }
}
