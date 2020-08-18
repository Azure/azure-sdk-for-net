// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.AI.AnomalyDetector
{
    /// <summary>
    /// <see cref="AnomalyDetectorClient"/> is use to connect to the Azure Cognitive Anomaly Detector Service.
    /// </summary>
    [CodeGenClient("ServiceClient")]
    public partial class AnomalyDetectorClient
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AnomalyDetectorClient"/> class.
        /// </summary>
        /// <param name="endpoint">The endpoint to use for connecting to the Anomaly Detector Azure Cognitive Service.</param>
        /// <param name="credential">A credential used to authenticate to an Azure Service.</param>
        /// <remarks>
        /// Both the <paramref name="endpoint"/> URI string and the <paramref name="credential"/> <c>string</c> key
        /// can be found in the Azure Portal.
        /// </remarks>
        public AnomalyDetectorClient(Uri endpoint, AzureKeyCredential credential)
            : this(endpoint, credential, new AnomalyDetectorClientOptions())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AnomalyDetectorClient"/> class.
        /// </summary>
        /// <param name="endpoint">The endpoint to use for connecting to the Anomaly Detector Azure Cognitive Service.</param>
        /// <param name="credential">A credential used to authenticate to an Azure Service.</param>
        /// <param name="options">A set of options to apply when configuring the client.</param>
        /// <remarks>
        /// Both the <paramref name="endpoint"/> URI string and the <paramref name="credential"/> <c>string</c> key
        /// can be found in the Azure Portal.
        /// </remarks>
        public AnomalyDetectorClient(Uri endpoint, AzureKeyCredential credential, AnomalyDetectorClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(credential, nameof(credential));
            Argument.AssertNotNull(options, nameof(options));

            _clientDiagnostics = new ClientDiagnostics(options);
            var pipeline = HttpPipelineBuilder.Build(options, new AzureKeyCredentialPolicy(credential, Constants.AuthorizationHeader));
            RestClient = new AnomalyDetectorRestClient(_clientDiagnostics, pipeline, endpoint.AbsoluteUri);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AnomalyDetectorClient"/> class.
        /// </summary>
        /// <param name="endpoint">The endpoint to use for connecting to the Anomaly Detector Azure Cognitive Service.</param>
        /// <param name="credential">A credential used to authenticate to an Azure Service.</param>
        /// <remarks>
        /// The <paramref name="endpoint"/> URI string can be found in the Azure Portal.
        /// </remarks>
        public AnomalyDetectorClient(Uri endpoint, TokenCredential credential)
            : this(endpoint, credential, new AnomalyDetectorClientOptions())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AnomalyDetectorClient"/> class.
        /// </summary>
        /// <param name="endpoint">The endpoint to use for connecting to the Anomaly Detector Azure Cognitive Service.</param>
        /// <param name="credential">A credential used to authenticate to an Azure Service.</param>
        /// <param name="options">A set of options to apply when configuring the client.</param>
        /// <remarks>
        /// The <paramref name="endpoint"/> URI string can be found in the Azure Portal.
        /// </remarks>
        public AnomalyDetectorClient(Uri endpoint, TokenCredential credential, AnomalyDetectorClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(credential, nameof(credential));
            Argument.AssertNotNull(options, nameof(options));

            _clientDiagnostics = new ClientDiagnostics(options);
            var pipeline = HttpPipelineBuilder.Build(options, new BearerTokenAuthenticationPolicy(credential, Constants.DefaultCognitiveScope));
            RestClient = new AnomalyDetectorRestClient(_clientDiagnostics, pipeline, endpoint.AbsoluteUri);
        }
    }
}
