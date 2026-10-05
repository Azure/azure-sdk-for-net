// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using OpenAI.Realtime;

namespace Azure.AI.Projects.Agents
{
    public partial class AzureAIProjectsAgentsContext
    {
        // Generated voice models read referenced OpenAI string enums through ModelReaderWriter.
#pragma warning disable OPENAI002
        partial void AddAdditionalFactories(Dictionary<Type, Func<ModelReaderWriterTypeBuilder>> factories)
        {
            factories[typeof(RealtimeResponseStatus?)] = static () => new RealtimeStringEnumTypeBuilder<RealtimeResponseStatus?>(static value => new RealtimeResponseStatus(value));
            factories[typeof(RealtimeOutputModality)] = static () => new RealtimeStringEnumTypeBuilder<RealtimeOutputModality>(static value => new RealtimeOutputModality(value));
            factories[typeof(RealtimeSemanticVadEagernessLevel?)] = static () => new RealtimeStringEnumTypeBuilder<RealtimeSemanticVadEagernessLevel?>(static value => new RealtimeSemanticVadEagernessLevel(value));
        }
#pragma warning restore OPENAI002
    }
}
