// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Iot.TimeSeriesInsights.Models;

namespace Azure.Iot.TimeSeriesInsights
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
        private readonly QueryRestClient _queryRestClient;
        private readonly TimeSeriesHierarchiesRestClient _timeSeriesHierarchiesRestClient;
        private readonly TimeSeriesTypesRestClient _timeSeriesTypesRestClient;

        /// <summary>
        /// Creates a new instance of the <see cref="TimeSeriesInsightsClient"/> class.
        /// </summary>
        /// <param name='environmentFqdn'>Per environment FQDN, for example 10000000-0000-0000-0000-100000000109.env.timeseries.azure.com.
        /// You can obtain this domain name from the response of the Get Environments API, Azure portal, or Azure Resource Manager.</param>
        /// <param name="credential">The <see cref="TokenCredential"/> implementation which will be used to request for the authentication token.</param>
        /// <seealso cref="TimeSeriesInsightsClient(string, TokenCredential)">
        /// This other constructor provides an opportunity to override default behavior, including specifying API version,
        /// overriding <see href="https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/core/Azure.Core/samples/Pipeline.md">transport</see>,
        /// enabling <see href="https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/core/Azure.Core/samples/Diagnostics.md">diagnostics</see>,
        /// and controlling <see href="https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/core/Azure.Core/samples/Configuration.md">retry strategy</see>.
        /// </seealso>
        /// <example>
        /// <code snippet="Snippet:TimeSeriesInsightsSampleCreateServiceClientWithClientSecret">
        /// // DefaultAzureCredential supports different authentication mechanisms and determines the appropriate credential type based of the environment it is executing in.
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
        /// overriding <see href="https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/core/Azure.Core/samples/Pipeline.md">transport</see>,
        /// enabling <see href="https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/core/Azure.Core/samples/Diagnostics.md">diagnostics</see>,
        /// and controlling <see href="https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/core/Azure.Core/samples/Configuration.md">retry strategy</see>.
        /// </para>
        /// </remarks>
        public TimeSeriesInsightsClient(string environmentFqdn, TokenCredential credential, TimeSeriesInsightsClientOptions options)
        {
            Argument.AssertNotNull(options, nameof(options));

            _clientDiagnostics = new ClientDiagnostics(options);

            options.AddPolicy(new BearerTokenAuthenticationPolicy(credential, GetAuthorizationScopes()), HttpPipelinePosition.PerCall);
            _httpPipeline = HttpPipelineBuilder.Build(options);

            string versionString = options.GetVersionString();
            _modelSettingsRestClient = new ModelSettingsRestClient(_clientDiagnostics, _httpPipeline, environmentFqdn, versionString);
            _queryRestClient = new QueryRestClient(_clientDiagnostics, _httpPipeline, environmentFqdn, versionString);
            _timeSeriesHierarchiesRestClient = new TimeSeriesHierarchiesRestClient(_clientDiagnostics, _httpPipeline, environmentFqdn, versionString);
            _timeSeriesTypesRestClient = new TimeSeriesTypesRestClient(_clientDiagnostics, _httpPipeline, environmentFqdn, versionString);
        }

        /// <summary>
        /// Creates a new instance of the <see cref="TimeSeriesInsightsClient"/> class, provided for unit testing purposes only.
        /// </summary>
        protected TimeSeriesInsightsClient()
        {
        }

        /// <summary>
        /// Returns the model settings which includes model display name, Time Series ID properties and default type ID. Every Gen2 environment has a model that is automatically created.
        /// </summary>
        /// <param name="clientSessionId"> Optional client session ID. Service records this value. Allows the service to trace a group of related operations across services, and allows the customer to contact support regarding a particular group of requests. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns>The deserialized application/json model settings digital twin and the http response <see cref="Response{ModelSettingsResponse}"/>.</returns>
        /// <example>
        /// This sample demonstrates getting and deserializing a model settings.
        ///
        /// <code snippet="Snippet:TimeSeriesInsightsGetModelSettings">
        /// // Get the model settings for the time series insights environment
        /// Response&lt;Models.ModelSettingsResponse&gt; response = await client.GetAsync().ConfigureAwait(false);
        /// Console.WriteLine($&quot;Retrieved model {response.Value.ModelSettings.Name}.&quot;);
        /// </code>
        /// </example>
        public virtual Task<Response<ModelSettingsResponse>> GetAsync(string clientSessionId = null, CancellationToken cancellationToken = default)
        {
            return _modelSettingsRestClient.GetAsync(clientSessionId, cancellationToken);
        }

        /// <summary>
        /// Returns the model settings which includes model display name, Time Series ID properties and default type ID. Every Gen2 environment has a model that is automatically created.
        /// </summary>
        /// <param name="clientSessionId"> Optional client session ID. Service records this value. Allows the service to trace a group of related operations across services, and allows the customer to contact support regarding a particular group of requests. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns>The deserialized application/json model settings digital twin and the http response <see cref="Response{ModelSettingsResponse}"/>.</returns>
        public virtual Response<ModelSettingsResponse> Get(string clientSessionId = null, CancellationToken cancellationToken = default)
        {
            return _modelSettingsRestClient.Get(clientSessionId, cancellationToken);
        }

        /// <summary>
        /// Gets the scope for authentication/authorization policy.
        /// </summary>
        /// <returns>List of scopes for the specified endpoint.</returns>
        internal static string[] GetAuthorizationScopes() => s_tsiDefaultScopes;
    }
}
