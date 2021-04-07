// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.AI.QnaMaker
{
    public class QnaMakerClient
    {
        private const string AuthorizationHeader = "Ocp-Apim-Subscription-Key";

        private readonly ClientDiagnostics _diagnostics;
        private readonly KnowledgebaseRestClient _knowledgebaseRestClient;

        public QnaMakerClient(Uri endpoint, AzureKeyCredential credential) : this(endpoint, credential, null)
        {
        }

        public QnaMakerClient(Uri endpoint, AzureKeyCredential credential, QnaMakerClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(credential, nameof(credential));

            Endpoint = endpoint;
            options ??= new QnaMakerClientOptions();

            _diagnostics = new ClientDiagnostics(options);

            HttpPipeline pipeline = HttpPipelineBuilder.Build(
                options,
                new AzureKeyCredentialPolicy(credential, AuthorizationHeader));

            // TODO: The api-version is hardcoded into the path and needs to be parameterized.
            _knowledgebaseRestClient = new KnowledgebaseRestClient(_diagnostics, pipeline, endpoint.AbsoluteUri);
        }

        /// <summary>
        /// Protected constructor to allow mocking.
        /// </summary>
        protected QnaMakerClient()
        {
        }

        /// <summary>
        /// Get the service endpoint for this client.
        /// </summary>
        public Uri Endpoint { get; }
    }
}
