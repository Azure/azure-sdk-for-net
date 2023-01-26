// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.OpenAI.Models;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.AI.OpenAI
{
    // Data plane generated client.
    /// <summary> Azure OpenAI APIs for completions and search. </summary>
    public partial class OpenAIClient
    {
        private readonly string _completionsDeploymentId;
        private readonly string _embeddingsDeploymentId;

        /// <summary> Initializes a new instance of OpenAIClient. </summary>
        /// <param name="endpoint">
        /// Supported Cognitive Services endpoints (protocol and hostname, for example:
        /// https://westus.api.cognitive.microsoft.com).
        /// </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="completionsDeploymentId"> default deployment id to use for completions </param>
        /// <param name="embeddingsDeploymentId"> default deployment id to use for embeddings </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> or <paramref name="credential"/> is null. </exception>
        public OpenAIClient(Uri endpoint, TokenCredential credential, string completionsDeploymentId, string embeddingsDeploymentId = null) : this(endpoint, credential, completionsDeploymentId, embeddingsDeploymentId, new OpenAIClientOptions())
        {
        }

        /// <summary> Initializes a new instance of OpenAIClient. </summary>
        /// <param name="endpoint">
        /// Supported Cognitive Services endpoints (protocol and hostname, for example:
        /// https://westus.api.cognitive.microsoft.com).
        /// </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="completionsDeploymentId"> default deployment id to use for completions </param>
        /// <param name="embeddingsDeploymentId"> default deployment id to use for embeddings </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> or <paramref name="credential"/> is null. </exception>
        public OpenAIClient(Uri endpoint, TokenCredential credential, string completionsDeploymentId, string embeddingsDeploymentId, OpenAIClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(credential, nameof(credential));
            options ??= new OpenAIClientOptions();

            ClientDiagnostics = new ClientDiagnostics(options, true);
            _tokenCredential = credential;
            _pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), new HttpPipelinePolicy[] { new BearerTokenAuthenticationPolicy(_tokenCredential, AuthorizationScopes) }, new ResponseClassifier());
            _endpoint = endpoint;
            _apiVersion = options.Version;
            _completionsDeploymentId = completionsDeploymentId;
            _embeddingsDeploymentId = embeddingsDeploymentId;
        }

        /// <summary> Return the completion for a given prompt. </summary>
        /// <param name="prompt"> Input string prompt to create a prompt completion from a deployment. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<Completion>> CompletionsAsync(string prompt, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_completionsDeploymentId, nameof(_completionsDeploymentId));
            Argument.AssertNotNullOrEmpty(prompt, nameof(prompt));

            CompletionsRequest completionsRequest = new CompletionsRequest();
            completionsRequest.Prompt.Add(prompt);
            return await CompletionsAsync(_completionsDeploymentId, completionsRequest, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Return the completions for a given prompt. </summary>
        /// <param name="prompt"> Input string prompt to create a prompt completion from a deployment. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<Completion> Completions(string prompt, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_completionsDeploymentId, nameof(_completionsDeploymentId));
            Argument.AssertNotNullOrEmpty(prompt, nameof(prompt));

            CompletionsRequest completionsRequest = new CompletionsRequest();
            completionsRequest.Prompt.Add(prompt);
            return Completions(_completionsDeploymentId, completionsRequest, cancellationToken);
        }
    }
}
