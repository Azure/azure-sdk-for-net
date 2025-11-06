// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json.Nodes;
using OpenAI.Responses;

#pragma warning disable OPENAI001
#pragma warning disable SCME0001

namespace Azure.AI.Agents;

public static partial class ResponseCreationOptionsExtensions
{
    extension(ResponseCreationOptions options)
    {
        public AgentReference Agent
        {
            get => JsonPatchHelpers.GetAgentValue<AgentReference>(ref options.Patch, "$.agent"u8);
            set
            {
                JsonPatchHelpers.SetAgentValue(ref options.Patch, "$.agent"u8, value);
                if (value is not null)
                {
                    options.Patch.Remove("$.model"u8);
                }
            }
        }

        public AgentConversationReference Conversation
        {
            get => JsonPatchHelpers.GetAgentValue<AgentConversationReference>(ref options.Patch, "$.conversation"u8);
            set => JsonPatchHelpers.SetAgentValue(ref options.Patch, "$.conversation"u8, value);
        }

            public void AddStructuredInput(string key, string value)
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

        public void SetStructuredInputs(BinaryData structuredInputsBytes)
        {
            options.Patch.Set("$.structured_inputs"u8, structuredInputsBytes);
        }
    }
}
