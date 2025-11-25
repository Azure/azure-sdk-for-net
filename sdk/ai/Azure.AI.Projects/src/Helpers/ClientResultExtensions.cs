// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel;
using System.ClientModel.Primitives;
using Azure.AI.Projects.OpenAI;
using OpenAI;

namespace Azure.AI.Projects;
internal static partial class ClientResultExtensions
{
    extension(ClientResult result)
    {
        public ClientResult<T> ToProjectOpenAIResult<T>()
            where T : IJsonModel<T>
                => result.ToTypedResult<T>(AzureAIProjectsOpenAIContext.Default);

        public ClientResult<T> ToExternalOpenAIResult<T>()
            where T : IJsonModel<T>
                => result.ToTypedResult<T>(OpenAIContext.Default);

        private ClientResult<T> ToTypedResult<T>(ModelReaderWriterContext context)
            where T : IJsonModel<T>
        {
            PipelineResponse rawResponse = result.GetRawResponse();
            T value = ModelReaderWriter.Read<T>(rawResponse.Content, ModelSerializationExtensions.WireOptions, context);
            return ClientResult.FromValue(value, rawResponse);
        }
    }
}
