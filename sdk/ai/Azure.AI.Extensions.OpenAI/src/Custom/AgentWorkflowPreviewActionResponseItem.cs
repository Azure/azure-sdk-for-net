// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using OpenAI.Responses;

namespace Azure.AI.Extensions.OpenAI;

[CodeGenType("WorkflowActionOutputItem")]
public partial class AgentWorkflowPreviewActionResponseItem
{
    /// <summary> Gets the status of the workflow preview action. </summary>
    [CodeGenMember("Status")]
    public AgentWorkflowPreviewActionStatus? Status { get; }

    /// <summary> Initializes a new instance of <see cref="AgentWorkflowPreviewActionResponseItem"/>. </summary>
    /// <param name="kind"> The kind of CSDL action (e.g., 'SetVariable', 'InvokeAzureAgent'). </param>
    /// <param name="actionId"> Unique identifier for the action. </param>
    /// <param name="status"> Status of the action (e.g., 'in_progress', 'completed', 'failed', 'cancelled'). </param>
    internal AgentWorkflowPreviewActionResponseItem(string kind, string actionId, AgentWorkflowPreviewActionStatus? status) : base(ResponseItemKind.WorkflowAction)
    {
        Kind = kind;
        ActionId = actionId;
        Status = status;
    }

    /// <summary> Initializes a new instance of <see cref="AgentWorkflowPreviewActionResponseItem"/>. </summary>
    /// <param name="id"></param>
    /// <param name="agentReference"> The agent that created the item. </param>
    /// <param name="responseId"> The response on which the item is created. </param>
    /// <param name="kind"> The kind of CSDL action (e.g., 'SetVariable', 'InvokeAzureAgent'). </param>
    /// <param name="actionId"> Unique identifier for the action. </param>
    /// <param name="parentActionId"> ID of the parent action if this is a nested action. </param>
    /// <param name="previousActionId"> ID of the previous action if this action follows another. </param>
    /// <param name="status"> Status of the action (e.g., 'in_progress', 'completed', 'failed', 'cancelled'). </param>
    /// <param name="additionalBinaryDataProperties"> Keeps track of any properties unknown to the library. </param>
    internal AgentWorkflowPreviewActionResponseItem(string id, AgentReference agentReference, string responseId, string kind, string actionId, string parentActionId, string previousActionId, AgentWorkflowPreviewActionStatus? status, IDictionary<string, BinaryData> additionalBinaryDataProperties) : base(ResponseItemKind.WorkflowAction)
    {
        Kind = kind;
        ActionId = actionId;
        ParentActionId = parentActionId;
        PreviousActionId = previousActionId;
        Status = status;
        _additionalBinaryDataProperties = additionalBinaryDataProperties;
    }

    /// <summary> Initializes a new instance of <see cref="AgentWorkflowPreviewActionResponseItem"/> for deserialization. </summary>
    internal AgentWorkflowPreviewActionResponseItem(): base(ResponseItemKind.WorkflowAction)
    {
    }
}
