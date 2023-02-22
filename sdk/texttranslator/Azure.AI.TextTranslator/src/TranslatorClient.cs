// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Pipeline;
using Azure.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.AI.TextTranslator
{
    /// <summary> The Translator service client. </summary>
    public partial class TranslatorClient
    {
        private const string KEY_HEADER_NAME = "Ocp-Apim-Subscription-Key";
        private const string TOKEN_SCOPE = "https://cognitiveservices.azure.com/.default";

        /// <summary>
        /// Initializes a new instance of the <see cref="TranslatorClient"/> class.
        /// </summary>
        /// <param name="endpoint">Endpoint</param>
        /// <param name="key">Security key</param>
        /// <param name="region">Region</param>
#pragma warning disable AZC0007 // DO provide a minimal constructor that takes only the parameters required to connect to the service.
        public TranslatorClient(Uri endpoint, AzureKeyCredential key, string region) : this(endpoint)
#pragma warning restore AZC0007 // DO provide a minimal constructor that takes only the parameters required to connect to the service.
        {
            var policy = new GlobalEndpointAuthenticationPolicy(key, region);

            this._pipeline = HttpPipelineBuilder.Build(new TranslatorClientOptions(), new[] { policy }, Array.Empty<HttpPipelinePolicy>(), new ResponseClassifier());
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TranslatorClient"/> class.
        /// </summary>
        /// <param name="endpoint">Endpoint</param>
        /// <param name="key">Security key</param>
#pragma warning disable AZC0007 // DO provide a minimal constructor that takes only the parameters required to connect to the service.
        public TranslatorClient(Uri endpoint, AzureKeyCredential key) : this(endpoint)
#pragma warning restore AZC0007 // DO provide a minimal constructor that takes only the parameters required to connect to the service.
        {
            var policy = new AzureKeyCredentialPolicy(key, KEY_HEADER_NAME);

            this._pipeline = HttpPipelineBuilder.Build(new TranslatorClientOptions(), new[] { policy }, Array.Empty<HttpPipelinePolicy>(), new ResponseClassifier());
            this._endpoint = new Uri(endpoint, "/translator/text/v3.0");
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TranslatorClient"/> class.
        /// </summary>
        /// <param name="endpoint">Endpoint</param>
        /// <param name="token">Cognitive Services Token</param>
#pragma warning disable AZC0007 // DO provide a minimal constructor that takes only the parameters required to connect to the service.
        public TranslatorClient(Uri endpoint, TokenCredential token) : this(endpoint)
#pragma warning restore AZC0007 // DO provide a minimal constructor that takes only the parameters required to connect to the service.
        {
            var policy = new BearerTokenAuthenticationPolicy(token, TOKEN_SCOPE);

            this._pipeline = HttpPipelineBuilder.Build(new TranslatorClientOptions(), new[] { policy }, Array.Empty<HttpPipelinePolicy>(), new ResponseClassifier());
        }
    }
}
