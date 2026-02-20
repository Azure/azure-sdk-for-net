// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using OpenAI.Responses;

#pragma warning disable OPENAI001
#pragma warning disable SCME0001

namespace Azure.AI.Projects.OpenAI;

public static partial class ResponseResultExtensions
{
    extension(ResponseResult response)
    {
        public AgentReference Agent => response.Patch.GetJsonModelEx<AgentReference>("$.agent"u8);

        public string AgentConversationId => response.Patch.GetStringEx("$.conversation.id"u8);
    }
}
