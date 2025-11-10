// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.IO;
using System.Text;
using System.Text.Json.Nodes;
using Azure.AI.Agents;
using OpenAI.Responses;

#pragma warning disable OPENAI001
#pragma warning disable SCME0001

namespace Azure.AI.Projects.OpenAI;

public static partial class ResponseCreationOptionsExtensions
{
    extension(ResponseCreationOptions options)
    {
        public string Model
        {
            get => options.Model;
            set => options.Patch.Set("$.model"u8, value);
        }
    }

    /// <summary>
    /// Adds a provided reference to an Azure Agent to the request options for an OpenAI Responses API call.
    /// </summary>
    /// <param name="options"></param>
    /// <param name="agent"></param>
    public static void SetAgentReference(this ResponseCreationOptions options, AgentReference agent)
    {
        BinaryData agentReferenceBin = ModelReaderWriter.Write(agent, ModelSerializationExtensions.WireOptions, AzureAIAgentsContext.Default);
        options.Patch.Set("$.agent"u8, agentReferenceBin);
        options.Patch.Remove("$.model"u8);
    }

    /// <summary>
    /// Adds a provided reference to an Azure Agent to the request options for an OpenAI Responses API call.
    /// </summary>
    /// <param name="options"></param>
    /// <param name="agentName"></param>
    /// <param name="agentVersion"></param>
    public static void SetAgentReference(this ResponseCreationOptions options, string agentName, string agentVersion = null)
        => SetAgentReference(options, new AgentReference(agentName) { Version = agentVersion });

    /// <summary>
    /// Adds a provided reference to an Azure Agent to the request options for an OpenAI Responses API call.
    /// </summary>
    /// <param name="options"></param>
    /// <param name="agentVersion"></param>
    public static void SetAgentReference(this ResponseCreationOptions options, AgentVersion agentVersion)
        => SetAgentReference(options, new AgentReference(agentVersion.Name) { Version = agentVersion.Version });

    /// <summary>
    /// Adds a provided reference to an Azure Agent to the request options for an OpenAI Responses API call.
    /// </summary>
    /// <param name="options"></param>
    /// <param name="agent"></param>
    /// <param name="agentVersion"></param>
    public static void SetAgentReference(this ResponseCreationOptions options, AgentRecord agent, string agentVersion = null)
        => SetAgentReference(options, new AgentReference(agent.Name) { Version = agentVersion ?? agent.Versions.Latest.Version });

    /// <summary>
    /// Adds a provided reference to an OpenAI Conversation to the request options for an OpenAI Responses API call.
    /// </summary>
    /// <param name="options"></param>
    /// <param name="conversationId"></param>
    public static void SetConversationReference(this ResponseCreationOptions options, string conversationId)
    {
        options.Patch.Set("$.conversation"u8, $"{conversationId}");
    }

    /// <summary>
    /// Adds a provided reference to an OpenAI Conversation to the request options for an OpenAI Responses API call.
    /// </summary>
    /// <param name="options"></param>
    /// <param name="conversation"></param>
    public static void SetConversationReference(this ResponseCreationOptions options, AgentConversation conversation)
        => SetConversationReference(options, conversation.Id);

    public static void AddStructuredInput(this ResponseCreationOptions options, string key, string value)
    {
        JsonObject doc;
        if (options.Patch.Contains("$.structured_inputs"u8) && options.Patch.TryGetJson("$.structured_inputs"u8, out ReadOnlyMemory<byte> jsonBytes))
        {
            using var stream = new MemoryStream();
            stream.Write(jsonBytes.ToArray(), 0, jsonBytes.Length);
            string json = Encoding.UTF8.GetString(stream.ToArray());
            doc = JsonObject.Parse(json).AsObject();
        }
        else
        {
            doc = new();
        }
        doc.Remove(key);
        doc.Add(key, JsonValue.Create(value));
        options.Patch.Set("$.structured_inputs"u8, BinaryData.FromString(doc.ToJsonString()));
    }

    public static void SetStructuredInputs(this ResponseCreationOptions options, BinaryData structuredInputsBytes)
    {
        options.Patch.Set("$.structured_inputs"u8, structuredInputsBytes);
    }
}
