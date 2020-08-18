// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.AnomalyDetector.Models;
using Azure.Core;
using Azure.Core.Pipeline;
using Request = Azure.AI.AnomalyDetector.Models.Request;

namespace Azure.AI.AnomalyDetector
{
    /// <summary>
    /// <see cref="AnomalyDetectorClient"/> is use to connect to the Azure Cognitive Anomaly Detector Service.
    /// </summary>
    public class AnomalyDetectorClient
    {
        /// <summary>Provides communication with the Anomaly Detector Azure Cognitive Service through its REST API.</summary>
        internal readonly ServiceRestClient ServiceClient;

        /// <summary>Provides tools for exception creation in case of failure.</summary>
        internal readonly ClientDiagnostics Diagnostics;

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

            Diagnostics = new ClientDiagnostics(options);
            var pipeline = HttpPipelineBuilder.Build(options, new AzureKeyCredentialPolicy(credential, Constants.AuthorizationHeader));
            ServiceClient = new ServiceRestClient(Diagnostics, pipeline, endpoint.AbsoluteUri);
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

            Diagnostics = new ClientDiagnostics(options);
            var pipeline = HttpPipelineBuilder.Build(options, new BearerTokenAuthenticationPolicy(credential, Constants.DefaultCognitiveScope));
            ServiceClient = new ServiceRestClient(Diagnostics, pipeline, endpoint.AbsoluteUri);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AnomalyDetectorClient"/> class.
        /// </summary>
        /// <param name="diagnostics">Provides tools for exception creation in case of failure.</param>
        /// <param name="serviceClient">Provides communication with the Anomaly Detector Azure Cognitive Service through its REST API.</param>
        internal AnomalyDetectorClient(ClientDiagnostics diagnostics, ServiceRestClient serviceClient)
        {
            Diagnostics = diagnostics;
            ServiceClient = serviceClient;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AnomalyDetectorClient"/> class.
        /// </summary>
        protected AnomalyDetectorClient()
        {
        }

        /// <summary> This operation generates a model using an entire series, each point is detected with the same model. With this method, points before and after a certain point are used to determine whether it is an anomaly. The entire detection can give user an overall status of the time series. </summary>
        /// <param name="body"> Time series points and period if needed. Advanced model parameters can also be set in the request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="body"/> is null. </exception>
        public virtual async Task<Response<EntireDetectResponse>> EntireDetectAsync(Request body, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(body, nameof(body));

            using DiagnosticScope scope = Diagnostics.CreateScope($"{nameof(AnomalyDetectorClient)}.{nameof(EntireDetectAsync)}");
            scope.Start();

            try
            {
                return await ServiceClient.EntireDetectAsync(body, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> This operation generates a model using an entire series, each point is detected with the same model. With this method, points before and after a certain point are used to determine whether it is an anomaly. The entire detection can give user an overall status of the time series. </summary>
        /// <param name="body"> Time series points and period if needed. Advanced model parameters can also be set in the request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="body"/> is null. </exception>
        public virtual Response<EntireDetectResponse> EntireDetect(Request body, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(body, nameof(body));

            using DiagnosticScope scope = Diagnostics.CreateScope($"{nameof(AnomalyDetectorClient)}.{nameof(EntireDetect)}");
            scope.Start();

            try
            {
                return ServiceClient.EntireDetect(body, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> This operation generates a model using points before the latest one. With this method, only historical points are used to determine whether the target point is an anomaly. The latest point detecting operation matches the scenario of real-time monitoring of business metrics. </summary>
        /// <param name="body"> Time series points and period if needed. Advanced model parameters can also be set in the request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="body"/> is null. </exception>
        public virtual async Task<Response<LastDetectResponse>> LastDetectAsync(Request body, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(body, nameof(body));

            using DiagnosticScope scope = Diagnostics.CreateScope($"{nameof(AnomalyDetectorClient)}.{nameof(LastDetectAsync)}");
            scope.Start();

            try
            {
                return await ServiceClient.LastDetectAsync(body, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> This operation generates a model using points before the latest one. With this method, only historical points are used to determine whether the target point is an anomaly. The latest point detecting operation matches the scenario of real-time monitoring of business metrics. </summary>
        /// <param name="body"> Time series points and period if needed. Advanced model parameters can also be set in the request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="body"/> is null. </exception>
        public virtual Response<LastDetectResponse> LastDetect(Request body, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(body, nameof(body));

            using DiagnosticScope scope = Diagnostics.CreateScope($"{nameof(AnomalyDetectorClient)}.{nameof(LastDetect)}");
            scope.Start();

            try
            {
                return ServiceClient.LastDetect(body, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Evaluate change point score of every series point. </summary>
        /// <param name="body"> Time series points and granularity is needed. Advanced model parameters can also be set in the request if needed. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="body"/> is null. </exception>
        public virtual async Task<Response<ChangePointDetectResponse>> ChangePointDetectAsync(ChangePointDetectRequest body, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(body, nameof(body));

            using DiagnosticScope scope = Diagnostics.CreateScope($"{nameof(AnomalyDetectorClient)}.{nameof(ChangePointDetectAsync)}");
            scope.Start();

            try
            {
                return await ServiceClient.ChangePointDetectAsync(body, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Evaluate change point score of every series point. </summary>
        /// <param name="body"> Time series points and granularity is needed. Advanced model parameters can also be set in the request if needed. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="body"/> is null. </exception>
        public virtual Response<ChangePointDetectResponse> ChangePointDetect(ChangePointDetectRequest body, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(body, nameof(body));

            using DiagnosticScope scope = Diagnostics.CreateScope($"{nameof(AnomalyDetectorClient)}.{nameof(ChangePointDetect)}");
            scope.Start();

            try
            {
                return ServiceClient.ChangePointDetect(body, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
