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

#pragma warning disable SCME0001

/// <summary>
/// The class containing various extension methods.
/// </summary>
[Experimental("AAIP001")]
public static partial class CreateResponseOptionsExtensions
{
    // Keep the preview's compiled accessor entry points without introducing a
    // second set of extension properties competing with the restored GA container.
    /// <summary> Gets the response's agent using the preview accessor entry point. </summary>
    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    [System.Runtime.CompilerServices.SpecialName]
    public static AgentReference get_Agent(CreateResponseOptions options) => options.Agent;

    /// <summary> Sets the response's agent using the preview accessor entry point. </summary>
    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    [System.Runtime.CompilerServices.SpecialName]
    public static void set_Agent(CreateResponseOptions options, AgentReference value) => options.Agent = value;

    /// <summary> Gets the conversation using the preview accessor entry point. </summary>
    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    [System.Runtime.CompilerServices.SpecialName]
    public static string get_AgentConversationId(CreateResponseOptions options) => options.AgentConversationId;

    /// <summary> Sets the conversation using the preview accessor entry point. </summary>
    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    [System.Runtime.CompilerServices.SpecialName]
    public static void set_AgentConversationId(CreateResponseOptions options, string value) => options.AgentConversationId = value;

    extension(CreateResponseOptions options)
    {
        /// <summary> Session used to get the response. </summary>
        [Experimental("SCME0001")]
        public string SessionId
        {
            get => options.Patch.GetStringEx("$.agent_session_id"u8);
            set => options.Patch.SetOrClearEx("$.agent_session_id"u8, "$.agent_session_id"u8, value);
        }

    }
}
