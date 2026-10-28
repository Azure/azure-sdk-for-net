// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel;
using System.Threading;
using System.Threading.Tasks;
using OpenAILike.Responses;

namespace FoundryLikeA
{
    /// <summary>
    /// A wrapper client that registers FoundryLikeA's proxies internally, so its caller does no proxy setup.
    /// Registrations other libraries already placed on the supplied options stay in place, and discriminators
    /// that no proxy claims still fall back to the base library.
    /// </summary>
    public sealed class AzureResponsesClient
    {
        private readonly ResponsesClient _client;

        public AzureResponsesClient(ApiKeyCredential credential, ResponsesClientOptions? options = null)
        {
            options ??= new ResponsesClientOptions();
            options.AddAzureSerializationExtensions();
            _client = new ResponsesClient(credential, options);
        }

        public Task<ClientResult<ResponseResult>> GetResponseAsync(string responseId, CancellationToken cancellationToken = default)
            => _client.GetResponseAsync(responseId, cancellationToken);
    }
}
