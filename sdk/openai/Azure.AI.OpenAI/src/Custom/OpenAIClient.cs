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
        /// <param name="deploymentId"> default deployment id to use for operations </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> or <paramref name="credential"/> is null. </exception>
        public OpenAIClient(Uri endpoint, string deploymentId, TokenCredential credential) : this(endpoint, deploymentId, credential, new OpenAIClientOptions())
        {
        }

        /// <summary> Initializes a new instance of OpenAIClient. </summary>
        /// <param name="endpoint">
        /// Supported Cognitive Services endpoints (protocol and hostname, for example:
        /// https://westus.api.cognitive.microsoft.com).
        /// </param>
        /// <param name="deploymentId"> default deployment id to use for operations </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> or <paramref name="credential"/> is null. </exception>
        public OpenAIClient(Uri endpoint, string deploymentId, TokenCredential credential, OpenAIClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(credential, nameof(credential));
            options ??= new OpenAIClientOptions();

            ClientDiagnostics = new ClientDiagnostics(options, true);
            _tokenCredential = credential;
            _pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), new HttpPipelinePolicy[] { new BearerTokenAuthenticationPolicy(_tokenCredential, AuthorizationScopes) }, new ResponseClassifier());
            _endpoint = endpoint;
            _apiVersion = options.Version;
            _completionsDeploymentId ??= deploymentId;
            _embeddingsDeploymentId ??= deploymentId;
        }

        /// <summary> Return the completion for a given prompt. </summary>
        /// <param name="prompt"> Input string prompt to create a prompt completion from a deployment. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<Completions>> GetCompletionsAsync(string prompt, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_completionsDeploymentId, nameof(_completionsDeploymentId));
            Argument.AssertNotNullOrEmpty(prompt, nameof(prompt));

            CompletionsOptions completionsOptions = new CompletionsOptions("text-davinci-002");
            completionsOptions.Prompt.Add(prompt);
            return await GetCompletionsAsync(_completionsDeploymentId, completionsOptions, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Return the completions for a given prompt. </summary>
        /// <param name="prompt"> Input string prompt to create a prompt completion from a deployment. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<Completions> GetCompletions(string prompt, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_completionsDeploymentId, nameof(_completionsDeploymentId));
            Argument.AssertNotNullOrEmpty(prompt, nameof(prompt));

            CompletionsOptions completionsOptions = new CompletionsOptions("text-davinci-002");
            completionsOptions.Prompt.Add(prompt);
            return GetCompletions(_completionsDeploymentId, completionsOptions, cancellationToken);
        }
    }
}
