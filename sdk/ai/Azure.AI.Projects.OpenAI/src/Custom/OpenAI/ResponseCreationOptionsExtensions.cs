// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.IO;
using System.Text;
using System.Text.Json.Nodes;
using Azure.AI.Projects.OpenAI;
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

        public AgentReference Agent
        {
            get
            {
                if (options.Patch.TryGetJson("$.agent"u8, out ReadOnlyMemory<byte> agentBytes))
                {
                    AgentReference retrievedReference = ModelReaderWriter.Read<AgentReference>(BinaryData.FromBytes(agentBytes), ModelSerializationExtensions.WireOptions, AzureAIProjectsOpenAIContext.Default);
                    return retrievedReference;
                }
                return null;
            }
            set
            {
                options.Patch.Set("$.agent"u8, ModelReaderWriter.Write(value, ModelSerializationExtensions.WireOptions, AzureAIProjectsOpenAIContext.Default));
            }
        }

        public string AgentConversationId
        {
            get
            {
                return options.Patch.TryGetValue("$.conversation.id"u8, out string conversationIdFromJsonObject) && !string.IsNullOrEmpty(conversationIdFromJsonObject)
                    ? conversationIdFromJsonObject
                    : options.Patch.TryGetValue("$.conversation"u8, out string conversationIdFromRoot) && !string.IsNullOrEmpty(conversationIdFromRoot)
                        ? conversationIdFromRoot
                        : null;
            }
            set
            {
                options.Patch.Set("$.conversation"u8, value);
            }
        }
    }

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
