// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading;
using System.Threading.Tasks;
using OpenAI.Conversations;
using OpenAI.Files;
using OpenAI.Responses;

namespace Azure.AI.Extensions.OpenAI;

/// <summary>
/// The class containing various extension methods.
/// </summary>
[Experimental("OPENAI001")]
public static partial class ResponseResultExtensions
{
    /// <summary> Gets the response's agent using the preview accessor entry point. </summary>
    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    [System.Runtime.CompilerServices.SpecialName]
    public static AgentReference get_Agent(ResponseResult response) => response.Agent;

    /// <summary> Gets the conversation using the preview accessor entry point. </summary>
    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    [System.Runtime.CompilerServices.SpecialName]
    public static string get_AgentConversationId(ResponseResult response) => response.AgentConversationId;
}
