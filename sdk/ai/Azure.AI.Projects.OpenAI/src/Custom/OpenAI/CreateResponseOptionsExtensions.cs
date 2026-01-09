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

public static partial class CreateResponseOptionsExtensions
{
    extension(CreateResponseOptions options)
    {
        public AgentReference Agent
        {
            get => options.Patch.GetJsonModelEx<AgentReference>("$.agent"u8);
            set => options.Patch.SetOrClearEx("$.agent"u8, "$.agent"u8, value);
        }

        public string AgentConversationId
        {
            get => options.Patch.GetStringEx("$.conversation.id"u8);
            set => options.Patch.SetOrClearEx("$.conversation.id"u8, "$.conversation"u8, value);
        }

        public ExtraDataDictionary StructuredInputs => new ExtraDataDictionary(options, "$.structured_inputs"u8);
    }
}
