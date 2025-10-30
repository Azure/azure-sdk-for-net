// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ClientModel;
using System.ClientModel.Primitives;
using System.Threading;

namespace Azure.AI.Agents;

/// <summary> The AgentsClient. </summary>
internal static partial class ClientResultExtensions
{
    public static ClientResult<T> ToOpenAIResult<T>(this ClientResult protocolResult)
        where T : IJsonModel<T>
            => ToTypedResult<T>(protocolResult, OpenAI.OpenAIContext.Default);

    public static ClientResult<T> ToAgentsClientResult<T>(this ClientResult protocolResult)
        where T : IJsonModel<T>
            => ToTypedResult<T>(protocolResult, AzureAIAgentsContext.Default);

    public static ClientResult<T> ToTypedResult<T>(this ClientResult protocolResult, ModelReaderWriterContext context)
        where T : IJsonModel<T>
    {
        PipelineResponse rawResponse = protocolResult.GetRawResponse();
        T value = ModelReaderWriter.Read<T>(rawResponse.Content, ModelReaderWriterOptions.Json, context);
        return ClientResult.FromValue(value, rawResponse);
    }
}
