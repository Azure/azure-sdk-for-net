// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.AI.Agents;

[CodeGenType("WorkflowActionOutputItemResource")]
public partial class AgentWorkflowActionResponseItem
{
    [CodeGenMember("Status")]
    public AgentWorkflowActionStatus? Status { get; }
}
