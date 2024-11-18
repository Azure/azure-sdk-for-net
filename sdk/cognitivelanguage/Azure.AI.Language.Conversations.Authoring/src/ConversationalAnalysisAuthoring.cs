// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Azure.Core;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.AI.Language.Conversations.Authoring;

namespace Azure.AI.Language.Conversations.Authoring
{
    /// <summary> The language service API is a suite of natural language processing (NLP) skills built with best-in-class Microsoft machine learning algorithms.  The API can be used to analyze unstructured text for tasks such as sentiment analysis, key phrase extraction, language detection and question answering. Further documentation can be found in &lt;a href=\"https://docs.microsoft.com/azure/cognitive-services/language-service/overview\"&gt;https://docs.microsoft.com/azure/cognitive-services/language-service/overview&lt;/a&gt;.0. </summary>
    public partial class ConversationalAnalysisAuthoring
    {
        /// <summary> Initializes a new instance of ConversationalAnalysisAuthoring. </summary>
        /// <param name="endpoint"> Supported Cognitive Services endpoint (e.g., https://&lt;resource-name&gt;.cognitiveservices.azure.com). </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> or <paramref name="credential"/> is null. </exception>
        public ConversationalAnalysisAuthoring(Uri endpoint, TokenCredential credential, AuthoringClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(credential, nameof(credential));
            options ??= new AuthoringClientOptions();

            var authorizationScope = $"{(string.IsNullOrEmpty(options.Audience?.ToString()) ? ConversationsAuthoringAudience.AzurePublicCloud : options.Audience)}/.default";

            _tokenCredential = credential;

            ClientDiagnostics = new ClientDiagnostics(options, true);
            _pipeline = HttpPipelineBuilder.Build(options, new HttpPipelinePolicy[] { new BearerTokenAuthenticationPolicy(credential, authorizationScope) }, Array.Empty<HttpPipelinePolicy>(), new ResponseClassifier());
            _endpoint = endpoint;
            _apiVersion = options.Version;
        }
    }
}
