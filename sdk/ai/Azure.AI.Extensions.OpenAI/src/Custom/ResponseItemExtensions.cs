// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using OpenAI;
using OpenAI.Responses;

namespace Azure.AI.Extensions.OpenAI;

/// <summary>
/// The class containing various extension methods.
/// </summary>
[Experimental("OPENAI001")]
public static partial class ResponseItemExtensions
{
    // ResponseResult
    extension(ResponseItem response)
    {

        /// <summary> Gets the agent associated with the response result. </summary>
        [Experimental("SCME0001")]
        public AgentReference AgentReference => response.Patch.GetJsonModelEx<AgentReference>("$.agent_reference"u8);

        /// <summary> Gets the agent conversation ID associated with the response result. </summary>
        [Experimental("SCME0001")]
        public string ResponseId => response.Patch.GetStringEx("$.response_id"u8);
    }

    extension(ComputerCallResponseItem computerCall)
    {
        /// <summary> Gets the batched actions associated with the computer call response item. </summary>
        [Experimental("SCME0001")]
        public IReadOnlyList<ComputerCallAction> Actions
        {
            get
            {
                if (!computerCall.Patch.IsRemoved("$.actions"u8)
                    && computerCall.Patch.TryGetJson("$.actions"u8, out ReadOnlyMemory<byte> actionsJson)
                    && !actionsJson.IsEmpty)
                {
                    using JsonDocument doc = JsonDocument.Parse(actionsJson);
                    if (doc.RootElement.ValueKind == JsonValueKind.Array)
                    {
                        List<ComputerCallAction> list = new();
                        foreach (JsonElement element in doc.RootElement.EnumerateArray())
                        {
                            ComputerCallAction action = ModelReaderWriter.Read<ComputerCallAction>(
                                BinaryData.FromString(element.GetRawText()),
                                ModelSerializationExtensions.WireOptions,
                                OpenAIContext.Default);
                            if (action is not null)
                            {
                                list.Add(action);
                            }
                        }
                        return list;
                    }
                }

                return computerCall.Action is not null ? [computerCall.Action] : [];
            }
        }
    }
}
