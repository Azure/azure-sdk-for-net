// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.AI.AgentServer.Core.Storage
{
    /// <summary>
    /// Protocol-neutral HTTP transport for Foundry-backed storage clients. Owns the
    /// <see cref="HttpPipeline"/>, its policy chain (retry, bearer auth, logging,
    /// tracing), and the shared <see cref="SendAsync"/> helper. Protocol packages
    /// compose it and add their own resource methods and payload (de)serialization.
    /// </summary>
    internal class FoundryStorageClient
    {
        /// <summary>OAuth scope used to acquire bearer tokens for the Foundry storage API.</summary>
        internal const string TokenScope = "https://ai.azure.com/.default";

        /// <summary>Content type for JSON request bodies sent to the Foundry storage API.</summary>
        internal const string JsonContentType = "application/json; charset=utf-8";

        private readonly HttpPipeline? _pipeline;

        /// <summary>Initializes a new instance of the <see cref="FoundryStorageClient"/> class for mocking.</summary>
        protected FoundryStorageClient()
        {
        }

        /// <summary>Initializes a new instance of the <see cref="FoundryStorageClient"/> class.</summary>
        /// <param name="credential">A token credential used to obtain bearer tokens.</param>
        /// <param name="endpoint">Resolved Foundry storage endpoint configuration.</param>
        /// <param name="options">Optional client options.</param>
        internal FoundryStorageClient(TokenCredential credential, FoundryStorageEndpoint endpoint, FoundryStorageClientOptions? options = null)
        {
            Argument.AssertNotNull(credential, nameof(credential));
            Argument.AssertNotNull(endpoint, nameof(endpoint));

            Endpoint = endpoint;
            options ??= new FoundryStorageClientOptions();
            _pipeline = HttpPipelineBuilder.Build(options, new BearerTokenAuthenticationPolicy(credential, TokenScope));
        }

        /// <summary>Gets the resolved storage endpoint configuration.</summary>
        internal FoundryStorageEndpoint Endpoint { get; } = null!;

        /// <summary>Creates a new, empty request bound to this client's pipeline.</summary>
        internal Request CreateRequest() => _pipeline!.CreateRequest();

        /// <summary>Sends a request to the Foundry storage API and throws a mapped exception on non-2xx responses.</summary>
        /// <param name="request">The request to send.</param>
        /// <param name="cancellationToken">A cancellation token.</param>
        /// <returns>The HTTP response.</returns>
        internal virtual async Task<Response> SendAsync(Request request, CancellationToken cancellationToken)
        {
            Response response = await _pipeline!.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
            StorageErrors.ThrowIfError(response);
            return response;
        }
    }
}
