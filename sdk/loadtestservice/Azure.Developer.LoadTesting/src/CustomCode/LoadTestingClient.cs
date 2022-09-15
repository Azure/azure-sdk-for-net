// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Core.Pipeline;
using Azure.Core;

namespace Azure.Developer.LoadTesting
{
    // Data plane generated client. The AppComponent service client.
    /// <summary> The LoadTesting service client. </summary>
    public partial class LoadTestingClient
    {
        private static readonly string[] AuthorizationScopes = new string[] { "https://loadtest.azure-dev.com/.default" };
        private readonly TokenCredential _tokenCredential;
        private readonly HttpPipeline _pipeline;
        private readonly string _endpoint;
        private readonly string _apiVersion;

        /// <summary>
        /// AppComponent Client
        /// </summary>
        public AppComponentClient AppComponent;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        public virtual HttpPipeline Pipeline => _pipeline;

        /// <summary> Initializes a new instance of LoadTestingClient for mocking. </summary>
        protected LoadTestingClient()
        {
        }

        /// <summary> Initializes a new instance of LoadTestingClient. </summary>
        /// <param name="endpoint"> URL to perform data plane API operations on the resource. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> or <paramref name="credential"/> is null. </exception>
        public LoadTestingClient(string endpoint, TokenCredential credential) : this(endpoint, credential, new AzureLoadTestingClientOptions())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LoadTestingClient"/> class.
        /// </summary>
        public LoadTestingClient(string endpoint, TokenCredential credential, AzureLoadTestingClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(credential, nameof(credential));
            options ??= new AzureLoadTestingClientOptions();

            ClientDiagnostics = new ClientDiagnostics(options, true);
            _tokenCredential = credential;
            _pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), new HttpPipelinePolicy[] { new BearerTokenAuthenticationPolicy(_tokenCredential, AuthorizationScopes) }, new ResponseClassifier());
            _endpoint = endpoint;
            _apiVersion = options.Version;

            AppComponent = new AppComponentClient(endpoint, credential);
        }
    }
}
