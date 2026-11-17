// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;

namespace Azure.AI.Projects;

internal static partial class ClientResultExtensions
{
    extension(ClientResult result)
    {
        public ClientResult<T> ToProjectResult<T>()
            where T : IJsonModel<T>
                => result.ToTypedResult<T>(AzureAIProjectsContext.Default);

        private ClientResult<T> ToTypedResult<T>(ModelReaderWriterContext context)
            where T : IJsonModel<T>
        {
            PipelineResponse rawResponse = result.GetRawResponse();
            T value = ModelReaderWriter.Read<T>(rawResponse.Content, ModelSerializationExtensions.WireOptions, context);
            return ClientResult.FromValue(value, rawResponse);
        }
    }
}
