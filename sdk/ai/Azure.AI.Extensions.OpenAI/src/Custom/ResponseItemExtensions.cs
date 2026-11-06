// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
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
}
