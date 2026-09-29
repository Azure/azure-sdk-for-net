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
    extension(CreateResponseOptions options)
    {
        /// <summary> Session used to get the response. </summary>
        [Experimental("SCME0001")]
        public string SessionId
        {
            get => options.Patch.GetStringEx("$.agent_session_id"u8);
            set => options.Patch.SetOrClearEx("$.agent_session_id"u8, "$.agent_session_id"u8, value);
        }

        /// <summary> Gets or sets the agent associated with the response options. </summary>
        [Experimental("SCME0001")]
        public AgentReference Agent
        {
            get => options.Patch.GetJsonModelEx<AgentReference>("$.agent_reference"u8);
            set => options.Patch.SetOrClearEx("$.agent_reference"u8, "$.agent_reference"u8, value);
        }

        /// <summary> Gets or sets the agent conversation ID associated with the response options. </summary>
        [Experimental("SCME0001")]
        public string AgentConversationId
        {
            get => options.Patch.GetStringEx("$.conversation.id"u8);
            set => options.Patch.SetOrClearEx("$.conversation.id"u8, "$.conversation"u8, value);
        }
    }
}
