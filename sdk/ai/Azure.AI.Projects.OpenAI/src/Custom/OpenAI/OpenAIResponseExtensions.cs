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

public static partial class OpenAIResponseExtensions
{
    extension(OpenAIResponse response)
    {
        public AgentReference Agent
        {
            get
            {
                // try/catch: SCM 1.8.0 workaround (fixed in 1.8.1)
                try
                {
                    if (response.Patch.Contains("$.agent"u8)
                        && !response.Patch.IsRemoved("$.agent"u8)
                        && response.Patch.TryGetJson("$.agent"u8, out ReadOnlyMemory<byte> agentBytes)
                        && !agentBytes.IsEmpty)
                    {
                        AgentReference retrievedReference = ModelReaderWriter.Read<AgentReference>(BinaryData.FromBytes(agentBytes), ModelSerializationExtensions.WireOptions, AzureAIProjectsOpenAIContext.Default);
                        return retrievedReference;
                    }
                }
                catch (InvalidOperationException) { }
                return null;
            }
        }

        public string AgentConversationId
        {
            get
            {
                // try/catch: SCM 1.8.0 workaround (fixed in 1.8.1)
                try
                {
                    if (response.Patch.Contains("$.conversation"u8)
                        && !response.Patch.IsRemoved("$.conversation"u8)
                        && response.Patch.TryGetJson("$.conversation.id"u8, out ReadOnlyMemory<byte> jsonPathValue)
                        && !jsonPathValue.IsEmpty)
                    {
                        return BinaryData.FromBytes(jsonPathValue).ToString();
                    }
                }
                catch (InvalidOperationException) { }
                return null;
            }
        }
    }
}
