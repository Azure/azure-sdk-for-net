// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using OpenAI.Responses;

namespace Azure.AI.Extensions.OpenAI;

#pragma warning disable OPENAI001

public static partial class ResponseItemExtensions
{
    public static AgentResponseItem AsAgentResponseItem(this ResponseItem responseItem)
    {
        BinaryData serializedResponseItem = ModelReaderWriter.Write(responseItem, ModelSerializationExtensions.WireOptions, AzureAIExtensionsOpenAIContext.Default);
        return ModelReaderWriter.Read<AgentResponseItem>(serializedResponseItem, ModelSerializationExtensions.WireOptions, AzureAIExtensionsOpenAIContext.Default);
    }
}
