// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.CodeAnalysis;
using OpenAI.Responses;

namespace Azure.AI.Extensions.OpenAI;

/// <summary>
/// The class containing various extension methods.
/// </summary>
[Experimental("OPENAI001")]
public static partial class ResponseResultExtensions
{
    // ResponseResult
    extension(ResponseResult response)
    {

        /// <summary> Gets the agent associated with the response result. </summary>
        [Experimental("SCME0001")]
        public AgentReference Agent => response.Patch.GetJsonModelEx<AgentReference>("$.agent_reference"u8);

        /// <summary> Gets the agent conversation ID associated with the response result. </summary>
        [Experimental("SCME0001")]
        public string AgentConversationId => response.Patch.GetStringEx("$.conversation.id"u8);
    }
}
