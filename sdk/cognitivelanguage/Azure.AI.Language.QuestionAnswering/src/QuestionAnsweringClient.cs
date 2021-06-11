// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.AI.Language.QuestionAnswering
{
    /// <summary>
    /// The <see cref="QuestionAnsweringClient"/> allows you to ask questions of a custom or built-in knowledgebase.
    /// </summary>
    public class QuestionAnsweringClient
    {
        internal const string AuthorizationHeader = "Ocp-Apim-Subscription-Key";

        /// <summary>
        /// Initializes a new instance of the <see cref="QuestionAnsweringClient"/> class.
        /// </summary>
        /// <param name="endpoint">The Question Answering endpoint on which to operate.</param>
        /// <param name="credential">A <see cref="AzureKeyCredential"/> used to authenticate requests to the <paramref name="endpoint"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="endpoint"/> or <paramref name="credential"/> is null.</exception>
        public QuestionAnsweringClient(Uri endpoint, AzureKeyCredential credential) : this(endpoint, credential, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QuestionAnsweringClient"/> class.
        /// </summary>
        /// <param name="endpoint">The Question Answering endpoint on which to operate.</param>
        /// <param name="credential">A <see cref="AzureKeyCredential"/> used to authenticate requests to the <paramref name="endpoint"/>.</param>
        /// <param name="options">Optional <see cref="QuestionAnsweringClientOptions"/> to customize requests sent to the endpoint.</param>
        /// <exception cref="ArgumentNullException"><paramref name="endpoint"/> or <paramref name="credential"/> is null.</exception>
        public QuestionAnsweringClient(Uri endpoint, AzureKeyCredential credential, QuestionAnsweringClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(credential, nameof(credential));

            Endpoint = endpoint;
            options ??= new QuestionAnsweringClientOptions();

            Diagnostics = new ClientDiagnostics(options);
            Pipeline = HttpPipelineBuilder.Build(
                options,
                new AzureKeyCredentialPolicy(credential, AuthorizationHeader));

            // TODO: The api-version is hard-coded into the path and needs to be parameterized.
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
        public virtual Uri Endpoint { get; }

        /// <summary>
        /// Gets the <see cref="ClientDiagnostics"/> for this client.
        /// </summary>
        internal virtual ClientDiagnostics Diagnostics { get; }

        /// <summary>
        /// Gets the <see cref="HttpPipeline"/> for this client.
        /// </summary>
        internal virtual HttpPipeline Pipeline { get; }
    }
}
