// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections;
using System.Collections.Generic;
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

        public ExtraDataDictionary StructuredInputs => new ExtraDataDictionary(options, "$.structured_inputs"u8);
    }
}
