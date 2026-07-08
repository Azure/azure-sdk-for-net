// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Microsoft.TypeSpec.Generator.Customizations;
using OpenAI.Responses;

namespace Azure.AI.Extensions.OpenAI;

[CodeGenSuppress(nameof(A2AToolCall), typeof(ResponseItemKind), typeof(AgentReference), typeof(string), typeof(string), typeof(string), typeof(string), typeof(ToolCallStatus), typeof(IDictionary<string, BinaryData>))]
public partial class A2AToolCall
{
    internal A2AToolCall(ResponseItemKind type, AgentReference agentReference, string responseId, string callId, string name, string arguments, ToolCallStatus status, IDictionary<string, BinaryData> additionalBinaryDataProperties) : base(type)
    {
        CallId = callId;
        Name = name;
        Arguments = arguments;
        Status = status;
        _additionalBinaryDataProperties = additionalBinaryDataProperties;
    }
}

[CodeGenSuppress(nameof(A2AToolCallOutput), typeof(ResponseItemKind), typeof(AgentReference), typeof(string), typeof(string), typeof(string), typeof(BinaryData), typeof(ToolCallStatus), typeof(IDictionary<string, BinaryData>))]
public partial class A2AToolCallOutput
{
    internal A2AToolCallOutput(ResponseItemKind type, AgentReference agentReference, string responseId, string callId, string name, BinaryData output, ToolCallStatus status, IDictionary<string, BinaryData> additionalBinaryDataProperties) : base(type)
    {
        CallId = callId;
        Name = name;
        Output = output;
        Status = status;
        _additionalBinaryDataProperties = additionalBinaryDataProperties;
    }
}

[CodeGenSuppress(nameof(AgentStructuredOutputsResponseItem), typeof(ResponseItemKind), typeof(AgentReference), typeof(string), typeof(BinaryData), typeof(IDictionary<string, BinaryData>))]
public partial class AgentStructuredOutputsResponseItem
{
    internal AgentStructuredOutputsResponseItem(ResponseItemKind type, AgentReference agentReference, string responseId, BinaryData output, IDictionary<string, BinaryData> additionalBinaryDataProperties) : base(type)
    {
        Output = output;
        _additionalBinaryDataProperties = additionalBinaryDataProperties;
    }
}

[CodeGenSuppress(nameof(AgentWorkflowPreviewActionResponseItem), typeof(ResponseItemKind), typeof(AgentReference), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(AgentWorkflowPreviewActionStatus?), typeof(IDictionary<string, BinaryData>))]
public partial class AgentWorkflowPreviewActionResponseItem
{
    internal AgentWorkflowPreviewActionResponseItem(ResponseItemKind type, AgentReference agentReference, string responseId, string csdlActionKind, string actionId, string parentActionId, string previousActionId, AgentWorkflowPreviewActionStatus? status, IDictionary<string, BinaryData> additionalBinaryDataProperties) : base(type)
    {
        CSDLActionKind = csdlActionKind;
        ActionId = actionId;
        ParentActionId = parentActionId;
        PreviousActionId = previousActionId;
        Status = status;
        _additionalBinaryDataProperties = additionalBinaryDataProperties;
    }
}

[CodeGenSuppress(nameof(AzureAISearchToolCall), typeof(ResponseItemKind), typeof(AgentReference), typeof(string), typeof(string), typeof(string), typeof(ToolCallStatus), typeof(IDictionary<string, BinaryData>))]
public partial class AzureAISearchToolCall
{
    internal AzureAISearchToolCall(ResponseItemKind type, AgentReference agentReference, string responseId, string callId, string arguments, ToolCallStatus status, IDictionary<string, BinaryData> additionalBinaryDataProperties) : base(type)
    {
        CallId = callId;
        Arguments = arguments;
        Status = status;
        _additionalBinaryDataProperties = additionalBinaryDataProperties;
    }
}

[CodeGenSuppress(nameof(AzureAISearchToolCallOutput), typeof(ResponseItemKind), typeof(AgentReference), typeof(string), typeof(string), typeof(BinaryData), typeof(ToolCallStatus), typeof(IDictionary<string, BinaryData>))]
public partial class AzureAISearchToolCallOutput
{
    internal AzureAISearchToolCallOutput(ResponseItemKind type, AgentReference agentReference, string responseId, string callId, BinaryData output, ToolCallStatus status, IDictionary<string, BinaryData> additionalBinaryDataProperties) : base(type)
    {
        CallId = callId;
        Output = output;
        Status = status;
        _additionalBinaryDataProperties = additionalBinaryDataProperties;
    }
}

[CodeGenSuppress(nameof(AzureFunctionToolCall), typeof(ResponseItemKind), typeof(AgentReference), typeof(string), typeof(string), typeof(string), typeof(string), typeof(ToolCallStatus), typeof(IDictionary<string, BinaryData>))]
public partial class AzureFunctionToolCall
{
    internal AzureFunctionToolCall(ResponseItemKind type, AgentReference agentReference, string responseId, string callId, string name, string arguments, ToolCallStatus status, IDictionary<string, BinaryData> additionalBinaryDataProperties) : base(type)
    {
        CallId = callId;
        Name = name;
        Arguments = arguments;
        Status = status;
        _additionalBinaryDataProperties = additionalBinaryDataProperties;
    }
}

[CodeGenSuppress(nameof(AzureFunctionToolCallOutput), typeof(ResponseItemKind), typeof(AgentReference), typeof(string), typeof(string), typeof(string), typeof(BinaryData), typeof(ToolCallStatus), typeof(IDictionary<string, BinaryData>))]
public partial class AzureFunctionToolCallOutput
{
    internal AzureFunctionToolCallOutput(ResponseItemKind type, AgentReference agentReference, string responseId, string callId, string name, BinaryData output, ToolCallStatus status, IDictionary<string, BinaryData> additionalBinaryDataProperties) : base(type)
    {
        CallId = callId;
        Name = name;
        Output = output;
        Status = status;
        _additionalBinaryDataProperties = additionalBinaryDataProperties;
    }
}

[CodeGenSuppress(nameof(BingCustomSearchToolCall), typeof(ResponseItemKind), typeof(AgentReference), typeof(string), typeof(string), typeof(string), typeof(ToolCallStatus), typeof(IDictionary<string, BinaryData>))]
public partial class BingCustomSearchToolCall
{
    internal BingCustomSearchToolCall(ResponseItemKind type, AgentReference agentReference, string responseId, string callId, string arguments, ToolCallStatus status, IDictionary<string, BinaryData> additionalBinaryDataProperties) : base(type)
    {
        CallId = callId;
        Arguments = arguments;
        Status = status;
        _additionalBinaryDataProperties = additionalBinaryDataProperties;
    }
}

[CodeGenSuppress(nameof(BingCustomSearchToolCallOutput), typeof(ResponseItemKind), typeof(AgentReference), typeof(string), typeof(string), typeof(BinaryData), typeof(ToolCallStatus), typeof(IDictionary<string, BinaryData>))]
public partial class BingCustomSearchToolCallOutput
{
    internal BingCustomSearchToolCallOutput(ResponseItemKind type, AgentReference agentReference, string responseId, string callId, BinaryData output, ToolCallStatus status, IDictionary<string, BinaryData> additionalBinaryDataProperties) : base(type)
    {
        CallId = callId;
        Output = output;
        Status = status;
        _additionalBinaryDataProperties = additionalBinaryDataProperties;
    }
}

[CodeGenSuppress(nameof(BingGroundingToolCall), typeof(ResponseItemKind), typeof(AgentReference), typeof(string), typeof(string), typeof(string), typeof(ToolCallStatus), typeof(IDictionary<string, BinaryData>))]
public partial class BingGroundingToolCall
{
    internal BingGroundingToolCall(ResponseItemKind type, AgentReference agentReference, string responseId, string callId, string arguments, ToolCallStatus status, IDictionary<string, BinaryData> additionalBinaryDataProperties) : base(type)
    {
        CallId = callId;
        Arguments = arguments;
        Status = status;
        _additionalBinaryDataProperties = additionalBinaryDataProperties;
    }
}

[CodeGenSuppress(nameof(BingGroundingToolCallOutput), typeof(ResponseItemKind), typeof(AgentReference), typeof(string), typeof(string), typeof(BinaryData), typeof(ToolCallStatus), typeof(IDictionary<string, BinaryData>))]
public partial class BingGroundingToolCallOutput
{
    internal BingGroundingToolCallOutput(ResponseItemKind type, AgentReference agentReference, string responseId, string callId, BinaryData output, ToolCallStatus status, IDictionary<string, BinaryData> additionalBinaryDataProperties) : base(type)
    {
        CallId = callId;
        Output = output;
        Status = status;
        _additionalBinaryDataProperties = additionalBinaryDataProperties;
    }
}

[CodeGenSuppress(nameof(BrowserAutomationToolCall), typeof(ResponseItemKind), typeof(AgentReference), typeof(string), typeof(string), typeof(string), typeof(ToolCallStatus), typeof(IDictionary<string, BinaryData>))]
public partial class BrowserAutomationToolCall
{
    internal BrowserAutomationToolCall(ResponseItemKind type, AgentReference agentReference, string responseId, string callId, string arguments, ToolCallStatus status, IDictionary<string, BinaryData> additionalBinaryDataProperties) : base(type)
    {
        CallId = callId;
        Arguments = arguments;
        Status = status;
        _additionalBinaryDataProperties = additionalBinaryDataProperties;
    }
}

[CodeGenSuppress(nameof(BrowserAutomationToolCallOutput), typeof(ResponseItemKind), typeof(AgentReference), typeof(string), typeof(string), typeof(BinaryData), typeof(ToolCallStatus), typeof(IDictionary<string, BinaryData>))]
public partial class BrowserAutomationToolCallOutput
{
    internal BrowserAutomationToolCallOutput(ResponseItemKind type, AgentReference agentReference, string responseId, string callId, BinaryData output, ToolCallStatus status, IDictionary<string, BinaryData> additionalBinaryDataProperties) : base(type)
    {
        CallId = callId;
        Output = output;
        Status = status;
        _additionalBinaryDataProperties = additionalBinaryDataProperties;
    }
}

[CodeGenSuppress(nameof(FabricDataAgentToolCall), typeof(ResponseItemKind), typeof(AgentReference), typeof(string), typeof(string), typeof(string), typeof(ToolCallStatus), typeof(IDictionary<string, BinaryData>))]
public partial class FabricDataAgentToolCall
{
    internal FabricDataAgentToolCall(ResponseItemKind type, AgentReference agentReference, string responseId, string callId, string arguments, ToolCallStatus status, IDictionary<string, BinaryData> additionalBinaryDataProperties) : base(type)
    {
        CallId = callId;
        Arguments = arguments;
        Status = status;
        _additionalBinaryDataProperties = additionalBinaryDataProperties;
    }
}

[CodeGenSuppress(nameof(FabricDataAgentToolCallOutput), typeof(ResponseItemKind), typeof(AgentReference), typeof(string), typeof(string), typeof(BinaryData), typeof(ToolCallStatus), typeof(IDictionary<string, BinaryData>))]
public partial class FabricDataAgentToolCallOutput
{
    internal FabricDataAgentToolCallOutput(ResponseItemKind type, AgentReference agentReference, string responseId, string callId, BinaryData output, ToolCallStatus status, IDictionary<string, BinaryData> additionalBinaryDataProperties) : base(type)
    {
        CallId = callId;
        Output = output;
        Status = status;
        _additionalBinaryDataProperties = additionalBinaryDataProperties;
    }
}

[CodeGenSuppress(nameof(MemoryCommandToolCall), typeof(ResponseItemKind), typeof(AgentReference), typeof(string), typeof(string), typeof(string), typeof(ToolCallStatus), typeof(IDictionary<string, BinaryData>))]
public partial class MemoryCommandToolCall
{
    internal MemoryCommandToolCall(ResponseItemKind type, AgentReference agentReference, string responseId, string callId, string arguments, ToolCallStatus status, IDictionary<string, BinaryData> additionalBinaryDataProperties) : base(type)
    {
        CallId = callId;
        Arguments = arguments;
        Status = status;
        _additionalBinaryDataProperties = additionalBinaryDataProperties;
    }
}

[CodeGenSuppress(nameof(MemoryCommandToolCallOutput), typeof(ResponseItemKind), typeof(AgentReference), typeof(string), typeof(string), typeof(ToolCallStatus), typeof(IDictionary<string, BinaryData>))]
public partial class MemoryCommandToolCallOutput
{
    internal MemoryCommandToolCallOutput(ResponseItemKind type, AgentReference agentReference, string responseId, string callId, ToolCallStatus status, IDictionary<string, BinaryData> additionalBinaryDataProperties) : base(type)
    {
        CallId = callId;
        Status = status;
        _additionalBinaryDataProperties = additionalBinaryDataProperties;
    }
}

[CodeGenSuppress(nameof(MemorySearchToolCall), typeof(ResponseItemKind), typeof(AgentReference), typeof(string), typeof(ToolCallStatus), typeof(IList<MemoryOutputItem>), typeof(IDictionary<string, BinaryData>))]
public partial class MemorySearchToolCall
{
    internal MemorySearchToolCall(ResponseItemKind type, AgentReference agentReference, string responseId, ToolCallStatus status, IList<MemoryOutputItem> memories, IDictionary<string, BinaryData> additionalBinaryDataProperties) : base(type)
    {
        Status = status;
        Memories = memories;
        _additionalBinaryDataProperties = additionalBinaryDataProperties;
    }
}

[CodeGenSuppress(nameof(OAuthConsentRequestResponseItem), typeof(ResponseItemKind), typeof(AgentReference), typeof(string), typeof(string), typeof(string), typeof(string), typeof(IDictionary<string, BinaryData>))]
[CodeGenSuppress(nameof(Id))]
public partial class OAuthConsentRequestResponseItem
{
    internal OAuthConsentRequestResponseItem(ResponseItemKind type, AgentReference agentReference, string responseId, string id, string internalConsentLink, string serverLabel, IDictionary<string, BinaryData> additionalBinaryDataProperties) : base(type)
    {
        Id = id;
        InternalConsentLink = internalConsentLink;
        ServerLabel = serverLabel;
        _additionalBinaryDataProperties = additionalBinaryDataProperties;
    }

    /// <summary> Gets or sets the Id. </summary>
    public new string Id { get; set; }
}

[CodeGenSuppress(nameof(OpenApiToolCall), typeof(ResponseItemKind), typeof(AgentReference), typeof(string), typeof(string), typeof(string), typeof(string), typeof(ToolCallStatus), typeof(IDictionary<string, BinaryData>))]
public partial class OpenApiToolCall
{
    internal OpenApiToolCall(ResponseItemKind type, AgentReference agentReference, string responseId, string callId, string name, string arguments, ToolCallStatus status, IDictionary<string, BinaryData> additionalBinaryDataProperties) : base(type)
    {
        CallId = callId;
        Name = name;
        Arguments = arguments;
        Status = status;
        _additionalBinaryDataProperties = additionalBinaryDataProperties;
    }
}

[CodeGenSuppress(nameof(OpenApiToolCallOutput), typeof(ResponseItemKind), typeof(AgentReference), typeof(string), typeof(string), typeof(string), typeof(BinaryData), typeof(ToolCallStatus), typeof(IDictionary<string, BinaryData>))]
public partial class OpenApiToolCallOutput
{
    internal OpenApiToolCallOutput(ResponseItemKind type, AgentReference agentReference, string responseId, string callId, string name, BinaryData output, ToolCallStatus status, IDictionary<string, BinaryData> additionalBinaryDataProperties) : base(type)
    {
        CallId = callId;
        Name = name;
        Output = output;
        Status = status;
        _additionalBinaryDataProperties = additionalBinaryDataProperties;
    }
}

[CodeGenSuppress(nameof(SharepointGroundingToolCall), typeof(ResponseItemKind), typeof(AgentReference), typeof(string), typeof(string), typeof(string), typeof(ToolCallStatus), typeof(IDictionary<string, BinaryData>))]
public partial class SharepointGroundingToolCall
{
    internal SharepointGroundingToolCall(ResponseItemKind type, AgentReference agentReference, string responseId, string callId, string arguments, ToolCallStatus status, IDictionary<string, BinaryData> additionalBinaryDataProperties) : base(type)
    {
        CallId = callId;
        Arguments = arguments;
        Status = status;
        _additionalBinaryDataProperties = additionalBinaryDataProperties;
    }
}

[CodeGenSuppress(nameof(SharepointGroundingToolCallOutput), typeof(ResponseItemKind), typeof(AgentReference), typeof(string), typeof(string), typeof(BinaryData), typeof(ToolCallStatus), typeof(IDictionary<string, BinaryData>))]
public partial class SharepointGroundingToolCallOutput
{
    internal SharepointGroundingToolCallOutput(ResponseItemKind type, AgentReference agentReference, string responseId, string callId, BinaryData output, ToolCallStatus status, IDictionary<string, BinaryData> additionalBinaryDataProperties) : base(type)
    {
        CallId = callId;
        Output = output;
        Status = status;
        _additionalBinaryDataProperties = additionalBinaryDataProperties;
    }
}
