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
    /// <summary> The LoadTesting Administration Wrapper. </summary>
    public partial class LoadTestAdministration
    {
        private static readonly string[] AuthorizationScopes = new string[] { "https://loadtest.azure-dev.com/.default" };
        private readonly TokenCredential _tokenCredential;
        private readonly HttpPipeline _pipeline;
        private readonly string _endpoint;
        private readonly string _apiVersion;

        /// <summary>
        /// AppComponent Client Object
        /// </summary>
        public AppComponentClient AppComponent;

        /// <summary>
        /// ServerMetrics Client Object
        /// </summary>
        public ServerMetricsClient ServerMetrics;

        /// <summary>
        /// Test Client Object
        /// </summary>
        public TestClient Test;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        public virtual HttpPipeline Pipeline => _pipeline;

        /// <summary> Initializes a new instance of LoadTestingClient for mocking. </summary>
        protected LoadTestAdministration()
        {
        }

        /// <summary> Initializes a new instance of LoadTestAdministration. </summary>
        /// <param name="endpoint"> URL to perform data plane API operations on the resource. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> or <paramref name="credential"/> is null. </exception>
        internal LoadTestAdministration(string endpoint, TokenCredential credential) : this(endpoint, credential, new AzureLoadTestingClientOptions())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LoadTestingClient"/> class.
        /// </summary>
        internal LoadTestAdministration(string endpoint, TokenCredential credential, AzureLoadTestingClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(credential, nameof(credential));
            options ??= new AzureLoadTestingClientOptions();

            ClientDiagnostics = new ClientDiagnostics(options, true);
            _tokenCredential = credential;
            _pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), new HttpPipelinePolicy[] { new BearerTokenAuthenticationPolicy(_tokenCredential, AuthorizationScopes) }, new ResponseClassifier());
            _endpoint = endpoint;
            _apiVersion = options.Version;

            AppComponent = new AppComponentClient(endpoint, credential, options);
            ServerMetrics = new ServerMetricsClient(endpoint, credential, options);
            Test = new TestClient(endpoint, credential, options);
        }
    }
}
