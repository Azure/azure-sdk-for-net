// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.IoT.TimeSeriesInsights
{
    /// <summary>
    /// The Time Series Insights client.
    /// </summary>
    public class TimeSeriesInsightsClient
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly HttpPipeline _httpPipeline;

        private const string TsiDefaultAppId = "https://api.timeseries.azure.com/";
        private const string DefaultPermissionConsent = "/.default";

        private static readonly string[] s_tsiDefaultScopes = new[] { TsiDefaultAppId + DefaultPermissionConsent };

        private readonly ModelSettingsRestClient _modelSettingsRestClient;
        private readonly TimeSeriesInstancesRestClient _timeSeriesInstancesRestClient;
        private readonly TimeSeriesTypesRestClient _timeSeriesTypesRestClient;
        private readonly TimeSeriesHierarchiesRestClient _timeSeriesHierarchiesRestClient;
        private readonly QueryRestClient _queryRestClient;

        /// <summary>
        /// Create a new <see cref="TimeSeriesInsightsModelSettings"/> client to get and update model settings.
        /// </summary>
        /// <returns>A new <see cref="TimeSeriesInsightsModelSettings"/> instance.</returns>
        public virtual TimeSeriesInsightsModelSettings GetModelSettingsClient()
        {
            return new TimeSeriesInsightsModelSettings(_modelSettingsRestClient, _clientDiagnostics);
        }

        /// <summary>
        /// Create a new <see cref="TimeSeriesInsightsInstances"/> client to perform various Time Series Insights instances operations.
        /// </summary>
        /// <returns>A new <see cref="TimeSeriesInsightsInstances"/> instance.</returns>
        public virtual TimeSeriesInsightsInstances GetInstancesClient()
        {
            return new TimeSeriesInsightsInstances(_timeSeriesInstancesRestClient, _clientDiagnostics);
        }

        /// <summary>
        /// Create a new <see cref="TimeSeriesInsightsTypes"/> client to perform various Time Series Insights types operations.
        /// </summary>
        /// <returns>A new <see cref="TimeSeriesInsightsTypes"/> instance.</returns>
        public virtual TimeSeriesInsightsTypes GetTypesClient()
        {
            return new TimeSeriesInsightsTypes(_timeSeriesTypesRestClient, _clientDiagnostics);
        }

        /// <summary>
        /// Create a new <see cref="TimeSeriesInsightsHierarchies"/> client to perform various Time Series Insights hierarchies operations.
        /// </summary>
        /// <returns>A new <see cref="TimeSeriesInsightsHierarchies"/> instance.</returns>
        public virtual TimeSeriesInsightsHierarchies GetHierarchiesClient()
        {
            return new TimeSeriesInsightsHierarchies(_timeSeriesHierarchiesRestClient, _clientDiagnostics);
        }

        /// <summary>
        /// Create a new <see cref="TimeSeriesInsightsQueries"/> client that can be used can be used to perform query operations on Time Series Insights.
        /// </summary>
        /// <returns>A new <see cref="TimeSeriesInsightsQueries"/> instance.</returns>
        public virtual TimeSeriesInsightsQueries GetQueriesClient()
        {
            return new TimeSeriesInsightsQueries(_queryRestClient, _clientDiagnostics);
        }

        /// <summary>
        /// Creates a new instance of the <see cref="TimeSeriesInsightsClient"/> class.
        /// </summary>
        /// <param name='environmentFqdn'>Per environment FQDN, for example 10000000-0000-0000-0000-100000000109.env.timeseries.azure.com.
        /// You can obtain this domain name from the response of the Get Environments API, Azure portal, or Azure Resource Manager.</param>
        /// <param name="credential">The <see cref="TokenCredential"/> implementation which will be used to request for the authentication token.</param>
        /// <seealso cref="TimeSeriesInsightsClient(string, TokenCredential, TimeSeriesInsightsClientOptions)">
        /// This other constructor provides an opportunity to override default behavior, including specifying API version,
        /// overriding <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Pipeline.md">transport</see>,
        /// enabling <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Diagnostics.md">diagnostics</see>,
        /// and controlling <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Configuration.md">retry strategy</see>.
        /// </seealso>
        /// <example>
        /// <code snippet="Snippet:TimeSeriesInsightsSampleCreateServiceClientWithClientSecret" language="csharp">
        /// // DefaultAzureCredential supports different authentication mechanisms and determines the appropriate credential type based on the environment it is executing in.
        /// // It attempts to use multiple credential types in an order until it finds a working credential.
        /// var tokenCredential = new DefaultAzureCredential();
        ///
        /// var client = new TimeSeriesInsightsClient(
        ///     tsiEndpoint,
        ///     tokenCredential);
        /// </code>
        /// </example>
        public TimeSeriesInsightsClient(string environmentFqdn, TokenCredential credential)
            : this(environmentFqdn, credential, new TimeSeriesInsightsClientOptions())
        {
        }

        /// <summary>
        /// Creates a new instance of the <see cref="TimeSeriesInsightsClient"/> class, with options.
        /// </summary>
        /// <param name='environmentFqdn'>Per environment FQDN, for example 10000000-0000-0000-0000-100000000109.env.timeseries.azure.com.
        /// You can obtain this domain name from the response of the Get Environments API, Azure portal, or Azure Resource Manager.</param>
        /// <param name="credential">The <see cref="TokenCredential"/> implementation which will be used to request for the authentication token.</param>
        /// <param name="options">Options that allow configuration of requests sent to the time series insights service.</param>
        /// <remarks>
        /// <para>
        /// The options parameter provides an opportunity to override default behavior, including specifying API version,
        /// overriding <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Pipeline.md">transport</see>,
        /// enabling <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Diagnostics.md">diagnostics</see>,
        /// and controlling <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Configuration.md">retry strategy</see>.
        /// </para>
        /// </remarks>
        public TimeSeriesInsightsClient(string environmentFqdn, TokenCredential credential, TimeSeriesInsightsClientOptions options)
        {
            Argument.AssertNotNullOrEmpty(environmentFqdn, nameof(environmentFqdn));
            Argument.AssertNotNull(credential, nameof(credential));
            Argument.AssertNotNull(options, nameof(options));

            _clientDiagnostics = new ClientDiagnostics(options);

            options.AddPolicy(new BearerTokenAuthenticationPolicy(credential, GetAuthorizationScopes()), HttpPipelinePosition.PerCall);
            _httpPipeline = HttpPipelineBuilder.Build(options);

            string versionString = options.GetVersionString();
            _modelSettingsRestClient = new ModelSettingsRestClient(_clientDiagnostics, _httpPipeline, environmentFqdn, versionString);
            _timeSeriesInstancesRestClient = new TimeSeriesInstancesRestClient(_clientDiagnostics, _httpPipeline, environmentFqdn, versionString);
            _timeSeriesTypesRestClient = new TimeSeriesTypesRestClient(_clientDiagnostics, _httpPipeline, environmentFqdn, versionString);
            _timeSeriesHierarchiesRestClient = new TimeSeriesHierarchiesRestClient(_clientDiagnostics, _httpPipeline, environmentFqdn, versionString);
            _queryRestClient = new QueryRestClient(_clientDiagnostics, _httpPipeline, environmentFqdn, versionString);
        }

        /// <summary>
        /// Creates a new instance of the <see cref="TimeSeriesInsightsClient"/> class, provided for unit testing purposes only.
        /// </summary>
        protected TimeSeriesInsightsClient()
        {
        }

        /// <summary>
        /// Gets the scope for authentication/authorization policy.
        /// </summary>
        /// <returns>List of scopes for the specified endpoint.</returns>
        internal static string[] GetAuthorizationScopes() => s_tsiDefaultScopes;
    }
}
