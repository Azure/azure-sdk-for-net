// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.AI.QuestionAnswering
{
    /// <summary>
    /// The QuestionAnsweringClient provides synchronous and asynchronous methods to managed knowledgebases
    /// and generate answers from questions using those knowledgebases.
    /// </summary>
    public class QuestionAnsweringClient
    {
        private const string AuthorizationHeader = "Ocp-Apim-Subscription-Key";

        private readonly ClientDiagnostics _diagnostics;
        private readonly KnowledgebaseRestClient _knowledgebaseRestClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="QuestionAnsweringClient"/> class.
        /// </summary>
        /// <param name="endpoint">The Question Answering endpoint on which to operate.</param>
        /// <param name="credential">A <see cref="TokenCredential"/> used to authenticate requests to the <paramref name="endpoint"/>, such as <c>DefaultAzureCredential</c>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="endpoint"/> or <paramref name="credential"/> is null.</exception>
        public QuestionAnsweringClient(Uri endpoint, AzureKeyCredential credential) : this(endpoint, credential, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QuestionAnsweringClient"/> class.
        /// </summary>
        /// <param name="endpoint">The Question Answering endpoint on which to operate.</param>
        /// <param name="credential">A <see cref="TokenCredential"/> used to authenticate requests to the <paramref name="endpoint"/>, such as <c>DefaultAzureCredential</c>.</param>
        /// <param name="options">Optional <see cref="QuestionAnsweringClientOptions"/> to customize requests sent to the endpoint.</param>
        /// <exception cref="ArgumentNullException"><paramref name="endpoint"/> or <paramref name="credential"/> is null.</exception>
        public QuestionAnsweringClient(Uri endpoint, AzureKeyCredential credential, QuestionAnsweringClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(credential, nameof(credential));

            Endpoint = endpoint;
            options ??= new QuestionAnsweringClientOptions();

            _diagnostics = new ClientDiagnostics(options);

            HttpPipeline pipeline = HttpPipelineBuilder.Build(
                options,
                new AzureKeyCredentialPolicy(credential, AuthorizationHeader));

            // TODO: The api-version is hardcoded into the path and needs to be parameterized.
            _knowledgebaseRestClient = new KnowledgebaseRestClient(_diagnostics, pipeline, endpoint);
        }

        /// <summary>
        /// Protected constructor to allow mocking.
        /// </summary>
        protected QuestionAnsweringClient()
        {
        }

        /// <summary>
        /// Get the service endpoint for this client.
        /// </summary>
        public Uri Endpoint { get; }
    }
}
