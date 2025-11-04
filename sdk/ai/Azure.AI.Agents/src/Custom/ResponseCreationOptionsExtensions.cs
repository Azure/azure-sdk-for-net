// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using OpenAI.Responses;

#pragma warning disable OPENAI001
#pragma warning disable SCME0001

namespace Azure.AI.Agents;

public static partial class ResponseCreationOptionsExtensions
{
    extension(ResponseCreationOptions target)
    {
        public AgentReference Agent
        {
            get => JsonPatchHelpers.GetAgentValue<AgentReference>(ref target.Patch, "$.agent"u8);
            set
            {
                JsonPatchHelpers.SetAgentValue(ref target.Patch, "$.agent"u8, value);
                if (value is not null)
                {
                    target.Patch.Remove("$.model"u8);
                }
            }
        }

        public AgentConversationReference Conversation
        {
            get => JsonPatchHelpers.GetAgentValue<AgentConversationReference>(ref target.Patch, "$.conversation"u8);
            set => JsonPatchHelpers.SetAgentValue(ref target.Patch, "$.conversation"u8, value);
        }
    }
}
