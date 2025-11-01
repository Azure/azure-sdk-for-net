// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json.Nodes;
using System.ClientModel.Primitives;
using OpenAI.Responses;

#pragma warning disable OPENAI001
#pragma warning disable SCME0001

namespace Azure.AI.Agents;

public static partial class ResponseCreationOptionsExtensions
{
    /// <summary>
    /// Adds a provided reference to an Azure Agent to the request options for an OpenAI Responses API call.
    /// </summary>
    /// <param name="responseCreationOptions"></param>
    /// <param name="agentReference"></param>
    public static void SetAgentReference(this ResponseCreationOptions responseCreationOptions, AgentReference agentReference)
    {
        BinaryData agentReferenceBin = ModelReaderWriter.Write(agentReference, ModelSerializationExtensions.WireOptions, AzureAIAgentsContext.Default);
        responseCreationOptions.Patch.Set("$.agent"u8, agentReferenceBin);
        responseCreationOptions.Patch.Remove("$.model"u8);
    }

    /// <summary>
    /// Adds a provided reference to an Azure Agent to the request options for an OpenAI Responses API call.
    /// </summary>
    /// <param name="responseCreationOptions"></param>
    /// <param name="agentName"></param>
    /// <param name="version"></param>
    public static void SetAgentReference(this ResponseCreationOptions responseCreationOptions, string agentName, string version = null)
        => SetAgentReference(responseCreationOptions, new AgentReference(agentName) { Version = version });

    /// <summary>
    /// Adds a provided reference to an Azure Agent to the request options for an OpenAI Responses API call.
    /// </summary>
    /// <param name="responseCreationOptions"></param>
    /// <param name="agentVersion"></param>
    public static void SetAgentReference(this ResponseCreationOptions responseCreationOptions, AgentVersion agentVersion)
        => SetAgentReference(responseCreationOptions, new AgentReference(agentVersion.Name) { Version = agentVersion.Version });

    /// <summary>
    /// Adds a provided reference to an Azure Agent to the request options for an OpenAI Responses API call.
    /// </summary>
    /// <param name="responseCreationOptions"></param>
    /// <param name="agentObject"></param>
    /// <param name="version"></param>
    public static void SetAgentReference(this ResponseCreationOptions responseCreationOptions, AgentRecord agentObject, string version = null)
        => SetAgentReference(responseCreationOptions, new AgentReference(agentObject.Name) { Version = version ?? agentObject.Versions.Latest.Version });

    /// <summary>
    /// Adds a provided reference to an OpenAI Conversation to the request options for an OpenAI Responses API call.
    /// </summary>
    /// <param name="responseCreationOptions"></param>
    /// <param name="conversationId"></param>
    public static void SetConversationReference(this ResponseCreationOptions responseCreationOptions, string conversationId)
    {
        responseCreationOptions.Patch.Set("$.conversation"u8, $"{conversationId}");
    }

    /// <summary>
    /// Adds a provided reference to an OpenAI Conversation to the request options for an OpenAI Responses API call.
    /// </summary>
    /// <param name="responseCreationOptions"></param>
    /// <param name="conversation"></param>
    public static void SetConversationReference(this ResponseCreationOptions responseCreationOptions, AgentConversation conversation)
        => SetConversationReference(responseCreationOptions, conversation.Id);

    public static void AddStructuredInput(this ResponseCreationOptions options, string key, string value)
    {
        IDictionary<string, BinaryData> structuredInputs
            = options.TryGetAdditionalProperty("structured_inputs", out IDictionary<string, BinaryData> existingDictionary)
                ? existingDictionary
                : new ChangeTrackingDictionary<string, BinaryData>();
        structuredInputs[key] = BinaryData.FromString(JsonValue.Create(value).ToJsonString());
        options.SetAdditionalProperty("structured_inputs", structuredInputs);
    }

    public static void SetStructuredInputs(this ResponseCreationOptions options, BinaryData structuredInputsBytes)
    {
        options.SetAdditionalProperty("structured_inputs", structuredInputsBytes);
    }
}
