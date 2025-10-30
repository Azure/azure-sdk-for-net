// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Reflection;
using OpenAI.Responses;

#pragma warning disable OPENAI001

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
        responseCreationOptions.SetAdditionalProperty("agent", agentReference);
        // Agent specification is mutually exclusive with model specification; see internal issue 4770700
        responseCreationOptions.SetAdditionalProperty("model", BinaryData.FromBytes("\"__EMPTY__\""u8.ToArray()));
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
        responseCreationOptions.SetAdditionalProperty(
            "conversation",
            BinaryData.FromString($"\"{conversationId}\""));
    }

    /// <summary>
    /// Adds a provided reference to an OpenAI Conversation to the request options for an OpenAI Responses API call.
    /// </summary>
    /// <param name="responseCreationOptions"></param>
    /// <param name="conversation"></param>
    public static void SetConversationReference(this ResponseCreationOptions responseCreationOptions, AgentConversation conversation)
        => SetConversationReference(responseCreationOptions, conversation.Id);

    private static void SetAdditionalProperty<T>(this ResponseCreationOptions responseCreationOptions, string key, T value)
    {
        PropertyInfo additionalDataProperty = typeof(ResponseCreationOptions).GetProperty("SerializedAdditionalRawData", BindingFlags.Instance | BindingFlags.NonPublic);
        object existingSerializedAdditionalRawData = additionalDataProperty.GetValue(responseCreationOptions);

        IDictionary<string, BinaryData> additionalData = (IDictionary<string, BinaryData>)existingSerializedAdditionalRawData ?? new Dictionary<string, BinaryData>();
        BinaryData writtenBinaryData = value switch
        {
            BinaryData binaryDataObject => binaryDataObject,
            string stringObject => BinaryData.FromString(stringObject),
            _ => ModelReaderWriter.Write(value, ModelSerializationExtensions.WireOptions, AzureAIAgentsContext.Default),
        };
        additionalData[key] = writtenBinaryData;
        additionalDataProperty.SetValue(responseCreationOptions, additionalData);
    }
}
