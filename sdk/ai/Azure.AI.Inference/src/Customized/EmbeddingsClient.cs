// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.AI.Inference
{
    // CUSTOM CODE NOTE:
    //   Modified code for the ChatCompletionsClient

    /// <summary> The Embeddings service client. </summary>
    public partial class EmbeddingsClient
    {
        /// <summary> Initializes a new instance of EmbeddingsClient. </summary>
        /// <param name="endpoint"> The <see cref="Uri"/> to use. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> or <paramref name="credential"/> is null. </exception>
        public EmbeddingsClient(Uri endpoint, AzureKeyCredential credential, AzureAIInferenceClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(credential, nameof(credential));
            options ??= new AzureAIInferenceClientOptions();
            credential.Deconstruct(out var key);
            options.AddPolicy(new AddApiKeyHeaderPolicy(key), HttpPipelinePosition.PerCall);

            ClientDiagnostics = new ClientDiagnostics(options, true);
            _keyCredential = credential;
            _pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), new HttpPipelinePolicy[] { new AzureKeyCredentialPolicy(_keyCredential, AuthorizationHeader, AuthorizationApiKeyPrefix) }, new ResponseClassifier());
            _endpoint = endpoint;
            _apiVersion = options.Version;
        }

        /// <summary>
        /// Return the embedding vectors for given text prompts.
        /// The method makes a REST API call to the `/embeddings` route on the given endpoint.
        /// </summary>
        /// <param name="embeddingsOptions"></param>
        /// <param name="extraParams">
        /// Controls what happens if extra parameters, undefined by the REST API,
        /// are passed in the JSON request payload.
        /// This sets the HTTP request header `extra-parameters`.
        /// </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="embeddingsOptions"/> is null. </exception>
        /// <include file="../Generated/Docs/EmbeddingsClient.xml" path="doc/members/member[@name='EmbedAsync(EmbeddingsOptions,ExtraParameters?,CancellationToken)']/*" />
        public virtual async Task<Response<EmbeddingsResult>> EmbedAsync(EmbeddingsOptions embeddingsOptions, ExtraParameters? extraParams = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(embeddingsOptions, nameof(embeddingsOptions));

            using RequestContent content = embeddingsOptions.ToRequestContent();
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await EmbedAsync(content, extraParams?.ToString(), context).ConfigureAwait(false);
            return Response.FromValue(EmbeddingsResult.FromResponse(response), response);
        }

        /// <summary>
        /// Return the embedding vectors for given text prompts.
        /// The method makes a REST API call to the `/embeddings` route on the given endpoint.
        /// </summary>
        /// <param name="embeddingsOptions"></param>
        /// <param name="extraParams">
        /// Controls what happens if extra parameters, undefined by the REST API,
        /// are passed in the JSON request payload.
        /// This sets the HTTP request header `extra-parameters`.
        /// </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="embeddingsOptions"/> is null. </exception>
        /// <include file="../Generated/Docs/EmbeddingsClient.xml" path="doc/members/member[@name='Embed(EmbeddingsOptions,ExtraParameters?,CancellationToken)']/*" />
        public virtual Response<EmbeddingsResult> Embed(EmbeddingsOptions embeddingsOptions, ExtraParameters? extraParams = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(embeddingsOptions, nameof(embeddingsOptions));

            using RequestContent content = embeddingsOptions.ToRequestContent();
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = Embed(content, extraParams?.ToString(), context);
            return Response.FromValue(EmbeddingsResult.FromResponse(response), response);
        }

        private class AddApiKeyHeaderPolicy : HttpPipelinePolicy
        {
            public string Token { get; }

            public AddApiKeyHeaderPolicy(string token)
            {
                Token = token;
            }

            public override void Process(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
            {
                // Add your desired header name and value
                message.Request.Headers.Add("api-key", Token);

                ProcessNext(message, pipeline);
            }

            public override ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
            {
                // Add your desired header name and value
                message.Request.Headers.Add("api-key", Token);

                return ProcessNextAsync(message, pipeline);
            }
        }
    }
}
