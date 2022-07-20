// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.AI.Language.QuestionAnswering.Projects
{
    /// <summary> The QuestionAnsweringProjects service client. </summary>
    [CodeGenType("QuestionAnsweringProjectsClient")]
    public partial class QuestionAnsweringProjectsClient
    {
        /// <summary> Initializes a new instance of QuestionAnsweringProjectsClient. </summary>
        /// <param name="endpoint"> Supported Cognitive Services endpoint (e.g., https://&lt;resource-name&gt;.cognitiveservices.azure.com). </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> or <paramref name="credential"/> is null. </exception>
        public QuestionAnsweringProjectsClient(Uri endpoint, TokenCredential credential) : this(endpoint, credential, new QuestionAnsweringClientOptions())
        {
        }

        /// <summary> Initializes a new instance of QuestionAnsweringProjectsClient. </summary>
        /// <param name="endpoint"> Supported Cognitive Services endpoint (e.g., https://&lt;resource-name&gt;.cognitiveservices.azure.com). </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> or <paramref name="credential"/> is null. </exception>
        public QuestionAnsweringProjectsClient(Uri endpoint, TokenCredential credential, QuestionAnsweringClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(credential, nameof(credential));
            options ??= new QuestionAnsweringClientOptions();

            var authorizationScope = $"{(string.IsNullOrEmpty(options.Audience?.ToString()) ? QuestionAnsweringAudience.AzurePublicCloud : options.Audience)}/.default";

            ClientDiagnostics = new ClientDiagnostics(options, true);
            _pipeline = HttpPipelineBuilder.Build(options, new HttpPipelinePolicy[] { new BearerTokenAuthenticationPolicy(credential, authorizationScope) }, Array.Empty<HttpPipelinePolicy>(), new ResponseClassifier());
            _endpoint = endpoint;
            _apiVersion = options.Version;
        }
    }
}
