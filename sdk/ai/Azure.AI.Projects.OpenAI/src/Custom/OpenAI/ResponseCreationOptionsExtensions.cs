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
            set
            {
                if (value is not null)
                {
                    options.Patch.Set("$.model"u8, value);
                }
                else if (options.Patch.Contains("$.model"u8))
                {
                    options.Patch.Remove("$.model"u8);
                }
            }
        }

        public AgentReference Agent
        {
            get
            {
                if (options.Patch.Contains("$.agent"u8)
                    && !options.Patch.IsRemoved("$.agent"u8)
                    && options.Patch.TryGetJson("$.agent"u8, out ReadOnlyMemory<byte> agentBytes)
                    && !agentBytes.IsEmpty)
                {
                    AgentReference retrievedReference = ModelReaderWriter.Read<AgentReference>(BinaryData.FromBytes(agentBytes), ModelSerializationExtensions.WireOptions, AzureAIProjectsOpenAIContext.Default);
                    return retrievedReference;
                }
                return null;
            }
            set
            {
                if (value is not null)
                {
                    options.Patch.Set("$.agent"u8, ModelReaderWriter.Write(value, ModelSerializationExtensions.WireOptions, AzureAIProjectsOpenAIContext.Default));
                }
                else if (options.Patch.Contains("$.agent"u8))
                {
                    options.Patch.Remove("$.agent"u8);
                }
            }
        }

        public string AgentConversationId
        {
            get
            {
                if (options.Patch.Contains("$.conversation"u8)
                    && !options.Patch.IsRemoved("$.conversation"u8)
                    && options.Patch.TryGetJson("$.conversation.id"u8, out ReadOnlyMemory<byte> jsonPathValue)
                    && !jsonPathValue.IsEmpty)
                {
                    return BinaryData.FromBytes(jsonPathValue).ToString();
                }
                return null;
            }
            set
            {
                if (value is not null)
                {
                    options.Patch.Set("$.conversation.id"u8, value);
                }
                else if (options.Patch.Contains("$.conversation"u8))
                {
                    options.Patch.Remove("$.conversation"u8);
                }
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
