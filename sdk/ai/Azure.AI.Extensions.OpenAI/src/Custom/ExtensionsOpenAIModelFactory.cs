// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using OpenAI.Responses;

namespace Azure.AI.Extensions.OpenAI;

public static partial class ExtensionsOpenAIModelFactory
{
    //////////////////////////////////////////////////////////////////
    // These changes needed because the ExtensionsOpenAIModelFactory
    // entries for the derived types contain the first parameter
    // @type, which is used in the type constructor and whicn may
    // break the type discriminator.
    // For each tool call / call output we
    // * internalize the  generated method.
    // * add the correct one without type in it.
    //////////////////////////////////////////////////////////////////

    /// <summary> An A2A (Agent-to-Agent) tool call. </summary>
    /// <param name="type"></param>
    /// <param name="id_"></param>
    /// <param name="agentReference"></param>
    /// <param name="responseId"></param>
    /// <param name="callId"></param>
    /// <param name="name"></param>
    /// <param name="arguments"></param>
    /// <param name="status"></param>
    /// <param name="responseIdInternal"></param>
    /// <param name="agentReferenceInternal"></param>
    /// <returns> A new <see cref="OpenAI.A2AToolCall"/> instance for mocking. </returns>
    [Experimental("AAIP001")]
    internal static A2AToolCall A2AToolCall(ResponseItemKind @type = default, string id_ = default, AgentReference agentReference = default, string responseId = default, string callId = default, string name = default, string arguments = default, ToolCallStatus status = default, string responseIdInternal = default, AgentReference agentReferenceInternal = default)
    {
        return A2AToolCall(
            id_,
            agentReference,
            responseId,
            callId,
            name,
            arguments,
            status);
    }

    /// <summary> An A2A (Agent-to-Agent) tool call. </summary>
    /// <param name="id"></param>
    /// <param name="agentReference"></param>
    /// <param name="responseId"></param>
    /// <param name="callId"></param>
    /// <param name="name"></param>
    /// <param name="arguments"></param>
    /// <param name="status"></param>
    /// <returns> A new <see cref="OpenAI.A2AToolCall"/> instance for mocking. </returns>
    [Experimental("AAIP001")]
    public static A2AToolCall A2AToolCall(string id = default, AgentReference agentReference = default, string responseId = default, string callId = default, string name = default, string arguments = default, ToolCallStatus status = default)
    {
        return new A2AToolCall(
            ResponseItemKind.A2APreviewCall,
            id,
            agentReference,
            responseId,
            callId,
            name,
            arguments,
            status,
            responseId,
            agentReference,
            additionalBinaryDataProperties: null);
    }

    /// <summary> The AgentWorkflowPreviewActionResponseItem. </summary>
    /// <param name="type"></param>
    /// <param name="id_"></param>
    /// <param name="agentReference"></param>
    /// <param name="responseId"></param>
    /// <param name="csdlActionKind"></param>
    /// <param name="actionId"></param>
    /// <param name="parentActionId"></param>
    /// <param name="previousActionId"></param>
    /// <param name="status"></param>
    /// <param name="responseIdInternal"></param>
    /// <param name="agentReferenceInternal"></param>
    /// <returns> A new <see cref="OpenAI.AgentWorkflowPreviewActionResponseItem"/> instance for mocking. </returns>
    [Experimental("AAIP002")]
    internal static AgentWorkflowPreviewActionResponseItem AgentWorkflowPreviewActionResponseItem(ResponseItemKind @type = default, string id_ = default, AgentReference agentReference = default, string responseId = default, string csdlActionKind = default, string actionId = default, string parentActionId = default, string previousActionId = default, AgentWorkflowPreviewActionStatus? status = default, string responseIdInternal = default, AgentReference agentReferenceInternal = default)
    {
        return AgentWorkflowPreviewActionResponseItem(
            id_,
            agentReference,
            responseId,
            csdlActionKind,
            actionId,
            parentActionId,
            previousActionId,
            status);
    }

    /// <summary> The AgentWorkflowPreviewActionResponseItem. </summary>
    /// <param name="id"></param>
    /// <param name="agentReference"></param>
    /// <param name="responseId"></param>
    /// <param name="csdlActionKind"></param>
    /// <param name="actionId"></param>
    /// <param name="parentActionId"></param>
    /// <param name="previousActionId"></param>
    /// <param name="status"></param>
    /// <returns> A new <see cref="OpenAI.AgentWorkflowPreviewActionResponseItem"/> instance for mocking. </returns>
    [Experimental("AAIP002")]
    public static AgentWorkflowPreviewActionResponseItem AgentWorkflowPreviewActionResponseItem(string id = default, AgentReference agentReference = default, string responseId = default, string csdlActionKind = default, string actionId = default, string parentActionId = default, string previousActionId = default, AgentWorkflowPreviewActionStatus? status = default)
    {
        return new AgentWorkflowPreviewActionResponseItem(
            ResponseItemKind.WorkflowAction,
            id,
            agentReference,
            responseId,
            csdlActionKind,
            actionId,
            parentActionId,
            previousActionId,
            status,
            responseId,
            agentReference,
            additionalBinaryDataProperties: null);
    }

    /// <summary> The AgentStructuredOutputsResponseItem. </summary>
    /// <param name="type"></param>
    /// <param name="id_"></param>
    /// <param name="agentReference"></param>
    /// <param name="responseId"></param>
    /// <param name="output"></param>
    /// <param name="responseIdInternal"></param>
    /// <param name="agentReferenceInternal"></param>
    /// <returns> A new <see cref="OpenAI.AgentStructuredOutputsResponseItem"/> instance for mocking. </returns>
    [Experimental("AAIP002")]
    internal static AgentStructuredOutputsResponseItem AgentStructuredOutputsResponseItem(ResponseItemKind @type = default, string id_ = default, AgentReference agentReference = default, string responseId = default, BinaryData output = default, string responseIdInternal = default, AgentReference agentReferenceInternal = default)
    {
        return AgentStructuredOutputsResponseItem(
            id_,
            agentReference,
            responseId,
            output);
    }

    /// <summary> The AgentStructuredOutputsResponseItem. </summary>
    /// <param name="id"></param>
    /// <param name="agentReference"></param>
    /// <param name="responseId"></param>
    /// <param name="output"></param>
    /// <returns> A new <see cref="OpenAI.AgentStructuredOutputsResponseItem"/> instance for mocking. </returns>
    [Experimental("AAIP002")]
    public static AgentStructuredOutputsResponseItem AgentStructuredOutputsResponseItem(string id = default, AgentReference agentReference = default, string responseId = default, BinaryData output = default)
    {
        return new AgentStructuredOutputsResponseItem(
            ResponseItemKind.StructuredOutputs,
            id,
            agentReference,
            responseId,
            output,
            responseId,
            agentReference,
            additionalBinaryDataProperties: null);
    }

    /// <summary> Request from the service for the user to perform OAuth consent. </summary>
    /// <param name="type"></param>
    /// <param name="id_"></param>
    /// <param name="agentReference"></param>
    /// <param name="responseId"></param>
    /// <param name="consentLink"></param>
    /// <param name="serverLabel"></param>
    /// <param name="responseIdInternal"></param>
    /// <param name="agentReferenceInternal"></param>
    /// <returns> A new <see cref="OpenAI.OAuthConsentRequestResponseItem"/> instance for mocking. </returns>
    [Experimental("AAIP002")]
    internal static OAuthConsentRequestResponseItem OAuthConsentRequestResponseItem(ResponseItemKind @type = default, string id_ = default, AgentReference agentReference = default, string responseId = default, Uri consentLink = default, string serverLabel = default, string responseIdInternal = default, AgentReference agentReferenceInternal = default)
    {
        return OAuthConsentRequestResponseItem(
            id_,
            agentReference,
            responseId,
            consentLink,
            serverLabel);
    }

    /// <summary> Request from the service for the user to perform OAuth consent. </summary>
    /// <param name="id"></param>
    /// <param name="agentReference"></param>
    /// <param name="responseId"></param>
    /// <param name="consentLink"></param>
    /// <param name="serverLabel"></param>
    /// <returns> A new <see cref="OpenAI.OAuthConsentRequestResponseItem"/> instance for mocking. </returns>
    [Experimental("AAIP002")]
    public static OAuthConsentRequestResponseItem OAuthConsentRequestResponseItem(string id = default, AgentReference agentReference = default, string responseId = default, Uri consentLink = default, string serverLabel = default)
    {
        return new OAuthConsentRequestResponseItem(
            ResponseItemKind.OAuthConsentRequest,
            id,
            agentReference,
            responseId,
            consentLink,
            serverLabel,
            responseId,
            agentReference,
            additionalBinaryDataProperties: null);
    }

    /// <summary> A Bing grounding tool call. </summary>
    /// <param name="type"></param>
    /// <param name="id_"></param>
    /// <param name="agentReference"></param>
    /// <param name="responseId"></param>
    /// <param name="callId"></param>
    /// <param name="arguments"></param>
    /// <param name="status"></param>
    /// <param name="responseIdInternal"></param>
    /// <param name="agentReferenceInternal"></param>
    /// <returns> A new <see cref="OpenAI.BingGroundingToolCall"/> instance for mocking. </returns>
    [Experimental("AAIP002")]
    internal static BingGroundingToolCall BingGroundingToolCall(ResponseItemKind @type = default, string id_ = default, AgentReference agentReference = default, string responseId = default, string callId = default, string arguments = default, ToolCallStatus status = default, string responseIdInternal = default, AgentReference agentReferenceInternal = default)
    {
        return BingGroundingToolCall(
            id_,
            agentReference,
            responseId,
            callId,
            arguments,
            status);
    }

    /// <summary> A Bing grounding tool call. </summary>
    /// <param name="id"></param>
    /// <param name="agentReference"></param>
    /// <param name="responseId"></param>
    /// <param name="callId"></param>
    /// <param name="arguments"></param>
    /// <param name="status"></param>
    /// <returns> A new <see cref="OpenAI.BingGroundingToolCall"/> instance for mocking. </returns>
    [Experimental("AAIP002")]
    public static BingGroundingToolCall BingGroundingToolCall(string id = default, AgentReference agentReference = default, string responseId = default, string callId = default, string arguments = default, ToolCallStatus status = default)
    {
        return new BingGroundingToolCall(
            ResponseItemKind.BingGroundingCall,
            id,
            agentReference,
            responseId,
            callId,
            arguments,
            status,
            responseId,
            agentReference,
            additionalBinaryDataProperties: null);
    }

    /// <summary> The output of a Bing grounding tool call. </summary>
    /// <param name="type"></param>
    /// <param name="id_"></param>
    /// <param name="agentReference"></param>
    /// <param name="responseId"></param>
    /// <param name="callId"></param>
    /// <param name="output"></param>
    /// <param name="status"></param>
    /// <param name="responseIdInternal"></param>
    /// <param name="agentReferenceInternal"></param>
    /// <returns> A new <see cref="OpenAI.BingGroundingToolCallOutput"/> instance for mocking. </returns>
    [Experimental("AAIP002")]
    internal static BingGroundingToolCallOutput BingGroundingToolCallOutput(ResponseItemKind @type = default, string id_ = default, AgentReference agentReference = default, string responseId = default, string callId = default, BinaryData output = default, ToolCallStatus status = default, string responseIdInternal = default, AgentReference agentReferenceInternal = default)
    {
        return BingGroundingToolCallOutput(
            id_,
            agentReference,
            responseId,
            callId,
            output,
            status);
    }
    /// <summary> The output of a Bing grounding tool call. </summary>
    /// <param name="id"></param>
    /// <param name="agentReference"></param>
    /// <param name="responseId"></param>
    /// <param name="callId"></param>
    /// <param name="output"></param>
    /// <param name="status"></param>
    /// <returns> A new <see cref="OpenAI.BingGroundingToolCallOutput"/> instance for mocking. </returns>
    [Experimental("AAIP002")]
    public static BingGroundingToolCallOutput BingGroundingToolCallOutput(string id = default, AgentReference agentReference = default, string responseId = default, string callId = default, BinaryData output = default, ToolCallStatus status = default)
    {
        return new BingGroundingToolCallOutput(
            ResponseItemKind.BingGroundingCallOutput,
            id,
            agentReference,
            responseId,
            callId,
            output,
            status,
            responseId,
            agentReference,
            additionalBinaryDataProperties: null);
    }

    /// <summary> A SharePoint grounding tool call. </summary>
    /// <param name="type"></param>
    /// <param name="id_"></param>
    /// <param name="agentReference"></param>
    /// <param name="responseId"></param>
    /// <param name="callId"></param>
    /// <param name="arguments"></param>
    /// <param name="status"></param>
    /// <param name="responseIdInternal"></param>
    /// <param name="agentReferenceInternal"></param>
    /// <returns> A new <see cref="OpenAI.SharePointGroundingToolCall"/> instance for mocking. </returns>
    [Experimental("AAIP001")]
    internal static SharePointGroundingToolCall SharePointGroundingToolCall(ResponseItemKind @type = default, string id_ = default, AgentReference agentReference = default, string responseId = default, string callId = default, string arguments = default, ToolCallStatus status = default, string responseIdInternal = default, AgentReference agentReferenceInternal = default)
    {
        return SharePointGroundingToolCall(
            id_,
            agentReference,
            responseId,
            callId,
            arguments,
            status);
    }

    /// <summary> A SharePoint grounding tool call. </summary>
    /// <param name="id"></param>
    /// <param name="agentReference"></param>
    /// <param name="responseId"></param>
    /// <param name="callId"></param>
    /// <param name="arguments"></param>
    /// <param name="status"></param>
    /// <returns> A new <see cref="OpenAI.SharePointGroundingToolCall"/> instance for mocking. </returns>
    [Experimental("AAIP001")]
    public static SharePointGroundingToolCall SharePointGroundingToolCall(string id = default, AgentReference agentReference = default, string responseId = default, string callId = default, string arguments = default, ToolCallStatus status = default)
    {
        return new SharePointGroundingToolCall(
            ResponseItemKind.SharepointGroundingPreviewCall,
            id,
            agentReference,
            responseId,
            callId,
            arguments,
            status,
            responseId,
            agentReference,
            additionalBinaryDataProperties: null);
    }

    /// <summary> The output of a SharePoint grounding tool call. </summary>
    /// <param name="type"></param>
    /// <param name="id_"></param>
    /// <param name="agentReference"></param>
    /// <param name="responseId"></param>
    /// <param name="callId"></param>
    /// <param name="output"></param>
    /// <param name="status"></param>
    /// <param name="responseIdInternal"></param>
    /// <param name="agentReferenceInternal"></param>
    /// <returns> A new <see cref="OpenAI.SharePointGroundingToolCallOutput"/> instance for mocking. </returns>
    [Experimental("AAIP001")]
    internal static SharePointGroundingToolCallOutput SharePointGroundingToolCallOutput(ResponseItemKind @type = default, string id_ = default, AgentReference agentReference = default, string responseId = default, string callId = default, BinaryData output = default, ToolCallStatus status = default, string responseIdInternal = default, AgentReference agentReferenceInternal = default)
    {
        return SharePointGroundingToolCallOutput(
            id_,
            agentReference,
            responseId,
            callId,
            output,
            status);
    }

    /// <summary> The output of a SharePoint grounding tool call. </summary>
    /// <param name="id"></param>
    /// <param name="agentReference"></param>
    /// <param name="responseId"></param>
    /// <param name="callId"></param>
    /// <param name="output"></param>
    /// <param name="status"></param>
    /// <returns> A new <see cref="OpenAI.SharePointGroundingToolCallOutput"/> instance for mocking. </returns>
    [Experimental("AAIP001")]
    public static SharePointGroundingToolCallOutput SharePointGroundingToolCallOutput(string id = default, AgentReference agentReference = default, string responseId = default, string callId = default, BinaryData output = default, ToolCallStatus status = default)
    {
        return new SharePointGroundingToolCallOutput(
            ResponseItemKind.SharepointGroundingPreviewCallOutput,
            id,
            agentReference,
            responseId,
            callId,
            output,
            status,
            responseId,
            agentReference,
            additionalBinaryDataProperties: null);
    }

    /// <summary> An Azure AI Search tool call. </summary>
    /// <param name="type"></param>
    /// <param name="id_"></param>
    /// <param name="agentReference"></param>
    /// <param name="responseId"></param>
    /// <param name="callId"></param>
    /// <param name="arguments"></param>
    /// <param name="status"></param>
    /// <param name="responseIdInternal"></param>
    /// <param name="agentReferenceInternal"></param>
    /// <returns> A new <see cref="OpenAI.AzureAISearchToolCall"/> instance for mocking. </returns>
    [Experimental("AAIP002")]
    internal static AzureAISearchToolCall AzureAISearchToolCall(ResponseItemKind @type = default, string id_ = default, AgentReference agentReference = default, string responseId = default, string callId = default, string arguments = default, ToolCallStatus status = default, string responseIdInternal = default, AgentReference agentReferenceInternal = default)
    {
        return AzureAISearchToolCall(
            id_,
            agentReference,
            responseId,
            callId,
            arguments,
            status);
    }

    /// <summary> An Azure AI Search tool call. </summary>
    /// <param name="id"></param>
    /// <param name="agentReference"></param>
    /// <param name="responseId"></param>
    /// <param name="callId"></param>
    /// <param name="arguments"></param>
    /// <param name="status"></param>
    /// <returns> A new <see cref="OpenAI.AzureAISearchToolCall"/> instance for mocking. </returns>
    [Experimental("AAIP002")]
    public static AzureAISearchToolCall AzureAISearchToolCall(string id = default, AgentReference agentReference = default, string responseId = default, string callId = default, string arguments = default, ToolCallStatus status = default)
    {
        return new AzureAISearchToolCall(
            ResponseItemKind.AzureAISearchCall,
            id,
            agentReference,
            responseId,
            callId,
            arguments,
            status,
            responseId,
            agentReference,
            additionalBinaryDataProperties: null);
    }

    /// <summary> The output of an Azure AI Search tool call. </summary>
    /// <param name="type"></param>
    /// <param name="id_"></param>
    /// <param name="agentReference"></param>
    /// <param name="responseId"></param>
    /// <param name="callId"></param>
    /// <param name="output"></param>
    /// <param name="status"></param>
    /// <param name="responseIdInternal"></param>
    /// <param name="agentReferenceInternal"></param>
    /// <returns> A new <see cref="OpenAI.AzureAISearchToolCallOutput"/> instance for mocking. </returns>
    [Experimental("AAIP002")]
    internal static AzureAISearchToolCallOutput AzureAISearchToolCallOutput(ResponseItemKind @type = default, string id_ = default, AgentReference agentReference = default, string responseId = default, string callId = default, BinaryData output = default, ToolCallStatus status = default, string responseIdInternal = default, AgentReference agentReferenceInternal = default)
    {
        return AzureAISearchToolCallOutput(
            id_,
            agentReference,
            responseId,
            callId,
            output,
            status);
    }

    /// <summary> The output of an Azure AI Search tool call. </summary>
    /// <param name="id"></param>
    /// <param name="agentReference"></param>
    /// <param name="responseId"></param>
    /// <param name="callId"></param>
    /// <param name="output"></param>
    /// <param name="status"></param>
    /// <returns> A new <see cref="OpenAI.AzureAISearchToolCallOutput"/> instance for mocking. </returns>
    [Experimental("AAIP002")]
    public static AzureAISearchToolCallOutput AzureAISearchToolCallOutput(string id = default, AgentReference agentReference = default, string responseId = default, string callId = default, BinaryData output = default, ToolCallStatus status = default)
    {
        return new AzureAISearchToolCallOutput(
            ResponseItemKind.AzureAISearchCallOutput,
            id,
            agentReference,
            responseId,
            callId,
            output,
            status,
            responseId,
            agentReference,
            additionalBinaryDataProperties: null);
    }

    /// <summary> A Bing custom search tool call. </summary>
    /// <param name="type"></param>
    /// <param name="id_"></param>
    /// <param name="agentReference"></param>
    /// <param name="responseId"></param>
    /// <param name="callId"></param>
    /// <param name="arguments"></param>
    /// <param name="status"></param>
    /// <param name="responseIdInternal"></param>
    /// <param name="agentReferenceInternal"></param>
    /// <returns> A new <see cref="OpenAI.BingCustomSearchToolCall"/> instance for mocking. </returns>
    [Experimental("AAIP001")]
    internal static BingCustomSearchToolCall BingCustomSearchToolCall(ResponseItemKind @type = default, string id_ = default, AgentReference agentReference = default, string responseId = default, string callId = default, string arguments = default, ToolCallStatus status = default, string responseIdInternal = default, AgentReference agentReferenceInternal = default)
    {
        return BingCustomSearchToolCall(
            id_,
            agentReference,
            responseId,
            callId,
            arguments,
            status);
    }

    /// <summary> A Bing custom search tool call. </summary>
    /// <param name="id"></param>
    /// <param name="agentReference"></param>
    /// <param name="responseId"></param>
    /// <param name="callId"></param>
    /// <param name="arguments"></param>
    /// <param name="status"></param>
    /// <returns> A new <see cref="OpenAI.BingCustomSearchToolCall"/> instance for mocking. </returns>
    [Experimental("AAIP001")]
    public static BingCustomSearchToolCall BingCustomSearchToolCall(string id = default, AgentReference agentReference = default, string responseId = default, string callId = default, string arguments = default, ToolCallStatus status = default)
    {
        return new BingCustomSearchToolCall(
            ResponseItemKind.BingCustomSearchPreviewCall,
            id,
            agentReference,
            responseId,
            callId,
            arguments,
            status,
            responseId,
            agentReference,
            additionalBinaryDataProperties: null);
    }

    /// <summary> The output of a Bing custom search tool call. </summary>
    /// <param name="type"></param>
    /// <param name="id_"></param>
    /// <param name="agentReference"></param>
    /// <param name="responseId"></param>
    /// <param name="callId"></param>
    /// <param name="output"></param>
    /// <param name="status"></param>
    /// <param name="responseIdInternal"></param>
    /// <param name="agentReferenceInternal"></param>
    /// <returns> A new <see cref="OpenAI.BingCustomSearchToolCallOutput"/> instance for mocking. </returns>
    [Experimental("AAIP001")]
    internal static BingCustomSearchToolCallOutput BingCustomSearchToolCallOutput(ResponseItemKind @type = default, string id_ = default, AgentReference agentReference = default, string responseId = default, string callId = default, BinaryData output = default, ToolCallStatus status = default, string responseIdInternal = default, AgentReference agentReferenceInternal = default)
    {
        return BingCustomSearchToolCallOutput(
            id_,
            agentReference,
            responseId,
            callId,
            output,
            status);
    }
    /// <summary> The output of a Bing custom search tool call. </summary>
    /// <param name="id"></param>
    /// <param name="agentReference"></param>
    /// <param name="responseId"></param>
    /// <param name="callId"></param>
    /// <param name="output"></param>
    /// <param name="status"></param>
    /// <returns> A new <see cref="OpenAI.BingCustomSearchToolCallOutput"/> instance for mocking. </returns>
    [Experimental("AAIP001")]
    public static BingCustomSearchToolCallOutput BingCustomSearchToolCallOutput(string id = default, AgentReference agentReference = default, string responseId = default, string callId = default, BinaryData output = default, ToolCallStatus status = default)
    {
        return new BingCustomSearchToolCallOutput(
            ResponseItemKind.BingCustomSearchPreviewCallOutput,
            id,
            agentReference,
            responseId,
            callId,
            output,
            status,
            responseId,
            agentReference,
            additionalBinaryDataProperties: null);
    }

    /// <summary> An OpenAPI tool call. </summary>
    /// <param name="type"></param>
    /// <param name="id_"></param>
    /// <param name="agentReference"></param>
    /// <param name="responseId"></param>
    /// <param name="callId"></param>
    /// <param name="name"></param>
    /// <param name="arguments"></param>
    /// <param name="status"></param>
    /// <param name="responseIdInternal"></param>
    /// <param name="agentReferenceInternal"></param>
    /// <returns> A new <see cref="OpenAI.OpenApiToolCall"/> instance for mocking. </returns>
    [Experimental("AAIP002")]
    internal static OpenApiToolCall OpenApiToolCall(ResponseItemKind @type = default, string id_ = default, AgentReference agentReference = default, string responseId = default, string callId = default, string name = default, string arguments = default, ToolCallStatus status = default, string responseIdInternal = default, AgentReference agentReferenceInternal = default)
    {
        return OpenApiToolCall(
            id_,
            agentReference,
            responseId,
            callId,
            name,
            arguments,
            status);
    }

    /// <summary> An OpenAPI tool call. </summary>
    /// <param name="id"></param>
    /// <param name="agentReference"></param>
    /// <param name="responseId"></param>
    /// <param name="callId"></param>
    /// <param name="name"></param>
    /// <param name="arguments"></param>
    /// <param name="status"></param>
    /// <returns> A new <see cref="OpenAI.OpenApiToolCall"/> instance for mocking. </returns>
    [Experimental("AAIP002")]
    public static OpenApiToolCall OpenApiToolCall(string id = default, AgentReference agentReference = default, string responseId = default, string callId = default, string name = default, string arguments = default, ToolCallStatus status = default)
    {
        return new OpenApiToolCall(
            ResponseItemKind.OpenApiCall,
            id,
            agentReference,
            responseId,
            callId,
            name,
            arguments,
            status,
            responseId,
            agentReference,
            additionalBinaryDataProperties: null);
    }

    /// <summary> The output of an OpenAPI tool call. </summary>
    /// <param name="type"></param>
    /// <param name="id_"></param>
    /// <param name="agentReference"></param>
    /// <param name="responseId"></param>
    /// <param name="callId"></param>
    /// <param name="name"></param>
    /// <param name="output"></param>
    /// <param name="status"></param>
    /// <param name="responseIdInternal"></param>
    /// <param name="agentReferenceInternal"></param>
    /// <returns> A new <see cref="OpenAI.OpenApiToolCallOutput"/> instance for mocking. </returns>
    [Experimental("AAIP002")]
    internal static OpenApiToolCallOutput OpenApiToolCallOutput(ResponseItemKind @type = default, string id_ = default, AgentReference agentReference = default, string responseId = default, string callId = default, string name = default, BinaryData output = default, ToolCallStatus status = default, string responseIdInternal = default, AgentReference agentReferenceInternal = default)
    {
        return OpenApiToolCallOutput(
            id_,
            agentReference,
            responseId,
            callId,
            name,
            output,
            status);
    }

    /// <summary> The output of an OpenAPI tool call. </summary>
    /// <param name="id"></param>
    /// <param name="agentReference"></param>
    /// <param name="responseId"></param>
    /// <param name="callId"></param>
    /// <param name="name"></param>
    /// <param name="output"></param>
    /// <param name="status"></param>
    /// <returns> A new <see cref="OpenAI.OpenApiToolCallOutput"/> instance for mocking. </returns>
    [Experimental("AAIP002")]
    public static OpenApiToolCallOutput OpenApiToolCallOutput(string id = default, AgentReference agentReference = default, string responseId = default, string callId = default, string name = default, BinaryData output = default, ToolCallStatus status = default)
    {
        return new OpenApiToolCallOutput(
            ResponseItemKind.OpenApiCallOutput,
            id,
            agentReference,
            responseId,
            callId,
            name,
            output,
            status,
            responseId,
            agentReference,
            additionalBinaryDataProperties: null);
    }

    /// <summary> A browser automation tool call. </summary>
    /// <param name="type"></param>
    /// <param name="id_"></param>
    /// <param name="agentReference"></param>
    /// <param name="responseId"></param>
    /// <param name="callId"></param>
    /// <param name="arguments"></param>
    /// <param name="status"></param>
    /// <param name="responseIdInternal"></param>
    /// <param name="agentReferenceInternal"></param>
    /// <returns> A new <see cref="OpenAI.BrowserAutomationToolCall"/> instance for mocking. </returns>
    [Experimental("AAIP002")]
    internal static BrowserAutomationToolCall BrowserAutomationToolCall(ResponseItemKind @type = default, string id_ = default, AgentReference agentReference = default, string responseId = default, string callId = default, string arguments = default, ToolCallStatus status = default, string responseIdInternal = default, AgentReference agentReferenceInternal = default)
    {
        return BrowserAutomationToolCall(
            id_,
            agentReference,
            responseId,
            callId,
            arguments,
            status);
    }

    /// <summary> A browser automation tool call. </summary>
    /// <param name="id"></param>
    /// <param name="agentReference"></param>
    /// <param name="responseId"></param>
    /// <param name="callId"></param>
    /// <param name="arguments"></param>
    /// <param name="status"></param>
    /// <returns> A new <see cref="OpenAI.BrowserAutomationToolCall"/> instance for mocking. </returns>
    [Experimental("AAIP002")]
    public static BrowserAutomationToolCall BrowserAutomationToolCall(string id = default, AgentReference agentReference = default, string responseId = default, string callId = default, string arguments = default, ToolCallStatus status = default)
    {
        return new BrowserAutomationToolCall(
            ResponseItemKind.BrowserAutomationPreviewCall,
            id,
            agentReference,
            responseId,
            callId,
            arguments,
            status,
            responseId,
            agentReference,
            additionalBinaryDataProperties: null);
    }

    /// <summary> The output of a browser automation tool call. </summary>
    /// <param name="type"></param>
    /// <param name="id_"></param>
    /// <param name="agentReference"></param>
    /// <param name="responseId"></param>
    /// <param name="callId"></param>
    /// <param name="output"></param>
    /// <param name="status"></param>
    /// <param name="responseIdInternal"></param>
    /// <param name="agentReferenceInternal"></param>
    /// <returns> A new <see cref="OpenAI.BrowserAutomationToolCallOutput"/> instance for mocking. </returns>
    [Experimental("AAIP002")]
    internal static BrowserAutomationToolCallOutput BrowserAutomationToolCallOutput(ResponseItemKind @type = default, string id_ = default, AgentReference agentReference = default, string responseId = default, string callId = default, BinaryData output = default, ToolCallStatus status = default, string responseIdInternal = default, AgentReference agentReferenceInternal = default)
    {
        return BrowserAutomationToolCallOutput(
            id_,
            agentReference,
            responseId,
            callId,
            output,
            status);
    }

    /// <summary> The output of a browser automation tool call. </summary>
    /// <param name="id"></param>
    /// <param name="agentReference"></param>
    /// <param name="responseId"></param>
    /// <param name="callId"></param>
    /// <param name="output"></param>
    /// <param name="status"></param>
    /// <returns> A new <see cref="OpenAI.BrowserAutomationToolCallOutput"/> instance for mocking. </returns>
    [Experimental("AAIP002")]
    public static BrowserAutomationToolCallOutput BrowserAutomationToolCallOutput(string id = default, AgentReference agentReference = default, string responseId = default, string callId = default, BinaryData output = default, ToolCallStatus status = default)
    {
        return new BrowserAutomationToolCallOutput(
            ResponseItemKind.BrowserAutomationPreviewCallOutput,
            id,
            agentReference,
            responseId,
            callId,
            output,
            status,
            responseId,
            agentReference,
            additionalBinaryDataProperties: null);
    }

    /// <summary> A Fabric data agent tool call. </summary>
    /// <param name="type"></param>
    /// <param name="id_"></param>
    /// <param name="agentReference"></param>
    /// <param name="responseId"></param>
    /// <param name="callId"></param>
    /// <param name="arguments"></param>
    /// <param name="status"></param>
    /// <param name="responseIdInternal"></param>
    /// <param name="agentReferenceInternal"></param>
    /// <returns> A new <see cref="OpenAI.FabricDataAgentToolCall"/> instance for mocking. </returns>
    [Experimental("AAIP001")]
    internal static FabricDataAgentToolCall FabricDataAgentToolCall(ResponseItemKind @type = default, string id_ = default, AgentReference agentReference = default, string responseId = default, string callId = default, string arguments = default, ToolCallStatus status = default, string responseIdInternal = default, AgentReference agentReferenceInternal = default)
    {
        return FabricDataAgentToolCall(
            id_,
            agentReference,
            responseId,
            callId,
            arguments,
            status);
    }

    /// <summary> A Fabric data agent tool call. </summary>
    /// <param name="id"></param>
    /// <param name="agentReference"></param>
    /// <param name="responseId"></param>
    /// <param name="callId"></param>
    /// <param name="arguments"></param>
    /// <param name="status"></param>
    /// <returns> A new <see cref="OpenAI.FabricDataAgentToolCall"/> instance for mocking. </returns>
    [Experimental("AAIP001")]
    public static FabricDataAgentToolCall FabricDataAgentToolCall(string id = default, AgentReference agentReference = default, string responseId = default, string callId = default, string arguments = default, ToolCallStatus status = default)
    {
        return new FabricDataAgentToolCall(
            ResponseItemKind.FabricDataAgentPreviewCall,
            id,
            agentReference,
            responseId,
            callId,
            arguments,
            status,
            responseId,
            agentReference,
            additionalBinaryDataProperties: null);
    }

    /// <summary> The output of a Fabric data agent tool call. </summary>
    /// <param name="type"></param>
    /// <param name="id_"></param>
    /// <param name="agentReference"></param>
    /// <param name="responseId"></param>
    /// <param name="callId"></param>
    /// <param name="output"></param>
    /// <param name="status"></param>
    /// <param name="responseIdInternal"></param>
    /// <param name="agentReferenceInternal"></param>
    /// <returns> A new <see cref="OpenAI.FabricDataAgentToolCallOutput"/> instance for mocking. </returns>
    [Experimental("AAIP001")]
    internal static FabricDataAgentToolCallOutput FabricDataAgentToolCallOutput(ResponseItemKind @type = default, string id_ = default, AgentReference agentReference = default, string responseId = default, string callId = default, BinaryData output = default, ToolCallStatus status = default, string responseIdInternal = default, AgentReference agentReferenceInternal = default)
    {
        return FabricDataAgentToolCallOutput(
            id_,
            agentReference,
            responseId,
            callId,
            output,
            status);
    }

    /// <summary> The output of a Fabric data agent tool call. </summary>
    /// <param name="id"></param>
    /// <param name="agentReference"></param>
    /// <param name="responseId"></param>
    /// <param name="callId"></param>
    /// <param name="output"></param>
    /// <param name="status"></param>
    /// <returns> A new <see cref="OpenAI.FabricDataAgentToolCallOutput"/> instance for mocking. </returns>
    [Experimental("AAIP001")]
    public static FabricDataAgentToolCallOutput FabricDataAgentToolCallOutput(string id = default, AgentReference agentReference = default, string responseId = default, string callId = default, BinaryData output = default, ToolCallStatus status = default)
    {
        return new FabricDataAgentToolCallOutput(
            ResponseItemKind.FabricDataAgentPreviewCallOutput,
            id,
            agentReference,
            responseId,
            callId,
            output,
            status,
            responseId,
            agentReference,
            additionalBinaryDataProperties: null);
    }

    /// <summary> An Azure Function tool call. </summary>
    /// <param name="type"></param>
    /// <param name="id_"></param>
    /// <param name="agentReference"></param>
    /// <param name="responseId"></param>
    /// <param name="callId"></param>
    /// <param name="name"></param>
    /// <param name="arguments"></param>
    /// <param name="status"></param>
    /// <param name="responseIdInternal"></param>
    /// <param name="agentReferenceInternal"></param>
    /// <returns> A new <see cref="OpenAI.AzureFunctionToolCall"/> instance for mocking. </returns>
    [Experimental("AAIP002")]
    internal static AzureFunctionToolCall AzureFunctionToolCall(ResponseItemKind @type = default, string id_ = default, AgentReference agentReference = default, string responseId = default, string callId = default, string name = default, string arguments = default, ToolCallStatus status = default, string responseIdInternal = default, AgentReference agentReferenceInternal = default)
    {
        return AzureFunctionToolCall(
            id_,
            agentReference,
            responseId,
            callId,
            name,
            arguments,
            status);
    }
    /// <summary> An Azure Function tool call. </summary>
    /// <param name="id"></param>
    /// <param name="agentReference"></param>
    /// <param name="responseId"></param>
    /// <param name="callId"></param>
    /// <param name="name"></param>
    /// <param name="arguments"></param>
    /// <param name="status"></param>
    /// <returns> A new <see cref="OpenAI.AzureFunctionToolCall"/> instance for mocking. </returns>
    [Experimental("AAIP002")]
    public static AzureFunctionToolCall AzureFunctionToolCall(string id = default, AgentReference agentReference = default, string responseId = default, string callId = default, string name = default, string arguments = default, ToolCallStatus status = default)
    {
        return new AzureFunctionToolCall(
            ResponseItemKind.AzureFunctionCall,
            id,
            agentReference,
            responseId,
            callId,
            name,
            arguments,
            status,
            responseId,
            agentReference,
            additionalBinaryDataProperties: null);
    }

    /// <summary> The output of an Azure Function tool call. </summary>
    /// <param name="type"></param>
    /// <param name="id_"></param>
    /// <param name="agentReference"></param>
    /// <param name="responseId"></param>
    /// <param name="callId"></param>
    /// <param name="name"></param>
    /// <param name="output"></param>
    /// <param name="status"></param>
    /// <param name="responseIdInternal"></param>
    /// <param name="agentReferenceInternal"></param>
    /// <returns> A new <see cref="OpenAI.AzureFunctionToolCallOutput"/> instance for mocking. </returns>
    [Experimental("AAIP002")]
    internal static AzureFunctionToolCallOutput AzureFunctionToolCallOutput(ResponseItemKind @type = default, string id_ = default, AgentReference agentReference = default, string responseId = default, string callId = default, string name = default, BinaryData output = default, ToolCallStatus status = default, string responseIdInternal = default, AgentReference agentReferenceInternal = default)
    {
        return AzureFunctionToolCallOutput(
            id_,
            agentReference,
            responseId,
            callId,
            name,
            output,
            status);
    }

    /// <summary> The output of an Azure Function tool call. </summary>
    /// <param name="id"></param>
    /// <param name="agentReference"></param>
    /// <param name="responseId"></param>
    /// <param name="callId"></param>
    /// <param name="name"></param>
    /// <param name="output"></param>
    /// <param name="status"></param>
    /// <returns> A new <see cref="OpenAI.AzureFunctionToolCallOutput"/> instance for mocking. </returns>
    [Experimental("AAIP002")]
    public static AzureFunctionToolCallOutput AzureFunctionToolCallOutput(string id = default, AgentReference agentReference = default, string responseId = default, string callId = default, string name = default, BinaryData output = default, ToolCallStatus status = default)
    {
        return new AzureFunctionToolCallOutput(
            ResponseItemKind.AzureFunctionCallOutput,
            id,
            agentReference,
            responseId,
            callId,
            name,
            output,
            status,
            responseId,
            agentReference,
            additionalBinaryDataProperties: null);
    }

    /// <summary> The output of an A2A (Agent-to-Agent) tool call. </summary>
    /// <param name="type"></param>
    /// <param name="id_"></param>
    /// <param name="agentReference"></param>
    /// <param name="responseId"></param>
    /// <param name="callId"></param>
    /// <param name="name"></param>
    /// <param name="output"></param>
    /// <param name="status"></param>
    /// <param name="responseIdInternal"></param>
    /// <param name="agentReferenceInternal"></param>
    /// <returns> A new <see cref="OpenAI.A2AToolCallOutput"/> instance for mocking. </returns>
    [Experimental("AAIP001")]
    internal static A2AToolCallOutput A2AToolCallOutput(ResponseItemKind @type = default, string id_ = default, AgentReference agentReference = default, string responseId = default, string callId = default, string name = default, BinaryData output = default, ToolCallStatus status = default, string responseIdInternal = default, AgentReference agentReferenceInternal = default)
    {
        return A2AToolCallOutput(
            id_,
            agentReference,
            responseId,
            callId,
            name,
            output,
            status);
    }

    /// <summary> The output of an A2A (Agent-to-Agent) tool call. </summary>
    /// <param name="id"></param>
    /// <param name="agentReference"></param>
    /// <param name="responseId"></param>
    /// <param name="callId"></param>
    /// <param name="name"></param>
    /// <param name="output"></param>
    /// <param name="status"></param>
    /// <returns> A new <see cref="OpenAI.A2AToolCallOutput"/> instance for mocking. </returns>
    [Experimental("AAIP001")]
    public static A2AToolCallOutput A2AToolCallOutput(string id = default, AgentReference agentReference = default, string responseId = default, string callId = default, string name = default, BinaryData output = default, ToolCallStatus status = default)
    {
        return new A2AToolCallOutput(
            ResponseItemKind.A2APreviewCallOutput,
            id,
            agentReference,
            responseId,
            callId,
            name,
            output,
            status,
            responseId,
            agentReference,
            additionalBinaryDataProperties: null);
    }

    /// <summary> A memory search tool call. </summary>
    /// <param name="type"></param>
    /// <param name="id_"></param>
    /// <param name="agentReference"></param>
    /// <param name="responseId"></param>
    /// <param name="status"></param>
    /// <param name="memories"></param>
    /// <param name="responseIdInternal"></param>
    /// <param name="agentReferenceInternal"></param>
    /// <returns> A new <see cref="OpenAI.MemorySearchToolCall"/> instance for mocking. </returns>
    [Experimental("AAIP001")]
    internal static MemorySearchToolCall MemorySearchToolCall(ResponseItemKind @type = default, string id_ = default, AgentReference agentReference = default, string responseId = default, ToolCallStatus status = default, IEnumerable<MemoryOutputItem> memories = default, string responseIdInternal = default, AgentReference agentReferenceInternal = default)
    {
        return MemorySearchToolCall(
            id_,
            agentReference,
            responseId,
            status,
            memories);
    }

    /// <summary> A memory search tool call. </summary>
    /// <param name="id"></param>
    /// <param name="agentReference"></param>
    /// <param name="responseId"></param>
    /// <param name="status"></param>
    /// <param name="memories"></param>
    /// <returns> A new <see cref="OpenAI.MemorySearchToolCall"/> instance for mocking. </returns>
    [Experimental("AAIP001")]
    public static MemorySearchToolCall MemorySearchToolCall(string id = default, AgentReference agentReference = default, string responseId = default, ToolCallStatus status = default, IEnumerable<MemoryOutputItem> memories = default)
    {
        memories ??= new ChangeTrackingList<MemoryOutputItem>();

        return new MemorySearchToolCall(
            ResponseItemKind.MemorySearchCall,
            id,
            agentReference,
            responseId,
            status,
            [.. memories],
            responseId,
            agentReference,
            additionalBinaryDataProperties: null);
    }
}
