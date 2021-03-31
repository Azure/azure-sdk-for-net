// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
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
        private readonly string _clientSessionId;

        private const string TsiDefaultAppId = "https://api.timeseries.azure.com/";
        private const string DefaultPermissionConsent = "/.default";

        private static readonly string[] s_tsiDefaultScopes = new[] { TsiDefaultAppId + DefaultPermissionConsent };

        private readonly ModelSettingsRestClient _modelSettingsRestClient;
        private readonly TimeSeriesInstancesRestClient _timeSeriesInstancesRestClient;
        private readonly TimeSeriesTypesRestClient _timeSeriesTypesRestClient;
        private readonly QueryRestClient _queryRestClient;

        /// <summary>
        /// Creates a new instance of the <see cref="TimeSeriesInsightsClient"/> class.
        /// </summary>
        /// <param name='environmentFqdn'>Per environment FQDN, for example 10000000-0000-0000-0000-100000000109.env.timeseries.azure.com.
        /// You can obtain this domain name from the response of the Get Environments API, Azure portal, or Azure Resource Manager.</param>
        /// <param name="credential">The <see cref="TokenCredential"/> implementation which will be used to request for the authentication token.</param>
        /// <seealso cref="TimeSeriesInsightsClient(string, TokenCredential, TimeSeriesInsightsClientOptions)">
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
            Argument.AssertNotNullOrEmpty(environmentFqdn, nameof(environmentFqdn));
            Argument.AssertNotNull(credential, nameof(credential));
            Argument.AssertNotNull(options, nameof(options));

            _clientSessionId = new Guid().ToString();
            _clientDiagnostics = new ClientDiagnostics(options);

            options.AddPolicy(new BearerTokenAuthenticationPolicy(credential, GetAuthorizationScopes()), HttpPipelinePosition.PerCall);
            _httpPipeline = HttpPipelineBuilder.Build(options);

            string versionString = options.GetVersionString();
            _modelSettingsRestClient = new ModelSettingsRestClient(_clientDiagnostics, _httpPipeline, environmentFqdn, versionString);
            _timeSeriesInstancesRestClient = new TimeSeriesInstancesRestClient(_clientDiagnostics, _httpPipeline, environmentFqdn, versionString);
            _timeSeriesTypesRestClient = new TimeSeriesTypesRestClient(_clientDiagnostics, _httpPipeline, environmentFqdn, versionString);
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

        /// <summary>
        /// Gets Time Series model settings asynchronously.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>
        /// The model settings which includes model display name, Time Series Id properties and default type Id with the
        /// http response <see cref="Response{TimeSeriesModelSettings}"/>.
        /// </returns>
        public virtual async Task<Response<TimeSeriesModelSettings>> GetModelSettingsAsync(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TimeSeriesInsightsClient)}.{nameof(GetModelSettings)}");
            scope.Start();
            try
            {
                // To do: Generate client session Id
                Response<ModelSettingsResponse> modelSettings = await _modelSettingsRestClient.GetAsync(null, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(modelSettings.Value.ModelSettings, modelSettings.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Gets Time Series model settings synchronously.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>
        /// The model settings which includes model display name, Time Series Id properties and default type Id with the
        /// http response <see cref="Response{TimeSeriesModelSettings}"/>.
        /// </returns>
        public virtual Response<TimeSeriesModelSettings> GetModelSettings(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TimeSeriesInsightsClient)}.{nameof(GetModelSettings)}");
            scope.Start();
            try
            {
                // To do: Generate client session Id
                Response<ModelSettingsResponse> modelSettings = _modelSettingsRestClient.Get(null, cancellationToken);
                return Response.FromValue(modelSettings.Value.ModelSettings, modelSettings.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Updates model name on Time Series model settings asynchronously.
        /// </summary>
        /// <param name="name">Model display name which is mutable by the user. Initial value is &quot;DefaultModel&quot;.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The updated model settings with the http response <see cref="Response{TimeSeriesModelSettings}"/>.</returns>
        public virtual async Task<Response<TimeSeriesModelSettings>> UpdateModelSettingsNameAsync(string name, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TimeSeriesInsightsClient)}.{nameof(UpdateModelSettingsName)}");
            scope.Start();
            try
            {
                // To do: Generate client session Id
                var options = new UpdateModelSettingsRequest { Name = name };
                Response<ModelSettingsResponse> modelSettings = await _modelSettingsRestClient.UpdateAsync(options, null, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(modelSettings.Value.ModelSettings, modelSettings.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Updates model default type Id on Time Series model settings asynchronously.
        /// </summary>
        /// <param name="defaultTypeId">Default type Id of the model that new instances will automatically belong to.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The updated model settings with the http response <see cref="Response{TimeSeriesModelSettings}"/>.</returns>
        public virtual async Task<Response<TimeSeriesModelSettings>> UpdateModelSettingsDefaultTypeIdAsync(string defaultTypeId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TimeSeriesInsightsClient)}.{nameof(UpdateModelSettingsDefaultTypeId)}");
            scope.Start();
            try
            {
                // To do: Generate client session Id
                var options = new UpdateModelSettingsRequest { DefaultTypeId = defaultTypeId };
                Response<ModelSettingsResponse> modelSettings = await _modelSettingsRestClient.UpdateAsync(options, null, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(modelSettings.Value.ModelSettings, modelSettings.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Updates model name on Time Series model settings synchronously.
        /// </summary>
        /// <param name="name">Model display name which is mutable by the user. Initial value is &quot;DefaultModel&quot;.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The updated model settings with the http response <see cref="Response{TimeSeriesModelSettings}"/>.</returns>
        public virtual Response<TimeSeriesModelSettings> UpdateModelSettingsName(string name, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TimeSeriesInsightsClient)}.{nameof(UpdateModelSettingsName)}");
            scope.Start();
            try
            {
                // To do: Generate client session Id
                var options = new UpdateModelSettingsRequest { Name = name };
                Response<ModelSettingsResponse> modelSettings = _modelSettingsRestClient.Update(options, null, cancellationToken);
                return Response.FromValue(modelSettings.Value.ModelSettings, modelSettings.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Updates default type Id on Time Series model settings synchronously.
        /// </summary>
        /// <param name="defaultTypeId">Default type Id of the model that new instances will automatically belong to.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The updated model settings with the http response <see cref="Response{TimeSeriesModelSettings}"/>.</returns>
        public virtual Response<TimeSeriesModelSettings> UpdateModelSettingsDefaultTypeId(string defaultTypeId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TimeSeriesInsightsClient)}.{nameof(UpdateModelSettingsDefaultTypeId)}");
            scope.Start();
            try
            {
                // To do: Generate client session Id
                var options = new UpdateModelSettingsRequest { DefaultTypeId = defaultTypeId };
                Response<ModelSettingsResponse> modelSettings = _modelSettingsRestClient.Update(options, null, cancellationToken);
                return Response.FromValue(modelSettings.Value.ModelSettings, modelSettings.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Gets Time Series instances in pages asynchronously.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The pageable list <see cref="AsyncPageable{TimeSeriesInstance}"/> of Time Series instances belonging to the TSI environment and the http response.</returns>
        /// <remarks>
        /// For more samples, see <see href="https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/timeseriesinsights/Azure.IoT.TimeSeriesInsights/samples">our repo samples</see>.
        /// </remarks>
        public virtual AsyncPageable<TimeSeriesInstance> GetInstancesAsync(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TimeSeriesInsightsClient)}.{nameof(GetInstances)}");
            scope.Start();

            try
            {
                async Task<Page<TimeSeriesInstance>> FirstPageFunc(int? pageSizeHint)
                {
                    using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TimeSeriesInsightsClient)}.{nameof(GetInstances)}");
                    scope.Start();

                    try
                    {
                        Response<GetInstancesPage> getInstancesResponse = await _timeSeriesInstancesRestClient
                            .ListAsync(null, _clientSessionId, cancellationToken)
                            .ConfigureAwait(false);
                        return Page.FromValues(getInstancesResponse.Value.Instances, getInstancesResponse.Value.ContinuationToken, getInstancesResponse.GetRawResponse());
                    }
                    catch (Exception ex)
                    {
                        scope.Failed(ex);
                        throw;
                    }
                }

                async Task<Page<TimeSeriesInstance>> NextPageFunc(string nextLink, int? pageSizeHint)
                {
                    using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TimeSeriesInsightsClient)}.{nameof(GetInstances)}");
                    scope.Start();

                    try
                    {
                        Response<GetInstancesPage> getInstancesResponse = await _timeSeriesInstancesRestClient
                            .ListAsync(nextLink, _clientSessionId, cancellationToken)
                            .ConfigureAwait(false);
                        return Page.FromValues(getInstancesResponse.Value.Instances, getInstancesResponse.Value.ContinuationToken, getInstancesResponse.GetRawResponse());
                    }
                    catch (Exception ex)
                    {
                        scope.Failed(ex);
                        throw;
                    }
                }

                return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Gets Time Series instances synchronously in pages.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The pageable list <see cref="Pageable{TimeSeriesInstance}"/> of Time Series instances belonging to the TSI environment and the http response.</returns>
        /// <seealso cref="GetInstancesAsync(CancellationToken)">
        /// See the asynchronous version of this method for examples.
        /// </seealso>
        public virtual Pageable<TimeSeriesInstance> GetInstances(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TimeSeriesInsightsClient)}.{nameof(GetInstances)}");
            scope.Start();

            try
            {
                Page<TimeSeriesInstance> FirstPageFunc(int? pageSizeHint)
                {
                    using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TimeSeriesInsightsClient)}.{nameof(GetInstances)}");
                    scope.Start();

                    try
                    {
                        Response<GetInstancesPage> getInstancesResponse = _timeSeriesInstancesRestClient.List(null, _clientSessionId, cancellationToken);
                        return Page.FromValues(getInstancesResponse.Value.Instances, getInstancesResponse.Value.ContinuationToken, getInstancesResponse.GetRawResponse());
                    }
                    catch (Exception ex)
                    {
                        scope.Failed(ex);
                        throw;
                    }
                }

                Page<TimeSeriesInstance> NextPageFunc(string nextLink, int? pageSizeHint)
                {
                    using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TimeSeriesInsightsClient)}.{nameof(GetInstances)}");
                    scope.Start();

                    try
                    {
                        Response<GetInstancesPage> getInstancesResponse = _timeSeriesInstancesRestClient.List(nextLink, _clientSessionId, cancellationToken);
                        return Page.FromValues(getInstancesResponse.Value.Instances, getInstancesResponse.Value.ContinuationToken, getInstancesResponse.GetRawResponse());
                    }
                    catch (Exception ex)
                    {
                        scope.Failed(ex);
                        throw;
                    }
                }

                return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Gets Time Series instances by instance names asynchronously.
        /// </summary>
        /// <param name="timeSeriesNames">List of names of the Time Series instance to return.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>
        /// List of instance or error objects corresponding by position to the array in the request. Instance object is set when operation is successful
        /// and error object is set when operation is unsuccessful.
        /// </returns>
        /// <remarks>
        /// For more samples, see <see href="https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/timeseriesinsights/Azure.IoT.TimeSeriesInsights/samples">our repo samples</see>.
        /// </remarks>
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="timeSeriesNames"/> is <c>null</c>.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// The exception is thrown when <paramref name="timeSeriesNames"/> is empty.
        /// </exception>
        public virtual async Task<Response<InstancesOperationResult[]>> GetInstancesAsync(
            IEnumerable<string> timeSeriesNames,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TimeSeriesInsightsClient)}.{nameof(GetInstances)}");
            scope.Start();

            try
            {
                Argument.AssertNotNullOrEmpty(timeSeriesNames, nameof(timeSeriesNames));

                InstancesBatchRequest batchRequest = new InstancesBatchRequest()
                {
                    Get = new InstancesRequestBatchGetOrDelete()
                };

                foreach (string timeSeriesName in timeSeriesNames)
                {
                    batchRequest.Get.Names.Add(timeSeriesName);
                }

                Response<InstancesBatchResponse> executeBatchResponse = await _timeSeriesInstancesRestClient
                    .ExecuteBatchAsync(batchRequest, _clientSessionId, cancellationToken)
                    .ConfigureAwait(false);

                return Response.FromValue(executeBatchResponse.Value.Get.ToArray(), executeBatchResponse.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Gets Time Series instances by instance names synchronously.
        /// </summary>
        /// <param name="timeSeriesNames">List of names of the Time Series instance to return.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>
        /// List of instance or error objects corresponding by position to the array in the request. Instance object is set when operation is successful
        /// and error object is set when operation is unsuccessful.
        /// </returns>
        /// <seealso cref="GetInstancesAsync(IEnumerable{string}, CancellationToken)">
        /// See the asynchronous version of this method for examples.
        /// </seealso>
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="timeSeriesNames"/> is <c>null</c>.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// The exception is thrown when <paramref name="timeSeriesNames"/> is empty.
        /// </exception>
        public virtual Response<InstancesOperationResult[]> GetInstances(
            IEnumerable<string> timeSeriesNames,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TimeSeriesInsightsClient)}.{nameof(GetInstances)}");
            scope.Start();

            try
            {
                Argument.AssertNotNullOrEmpty(timeSeriesNames, nameof(timeSeriesNames));

                InstancesBatchRequest batchRequest = new InstancesBatchRequest()
                {
                    Get = new InstancesRequestBatchGetOrDelete()
                };

                foreach (string timeSeriesName in timeSeriesNames)
                {
                    batchRequest.Get.Names.Add(timeSeriesName);
                }

                Response<InstancesBatchResponse> executeBatchResponse = _timeSeriesInstancesRestClient
                    .ExecuteBatch(batchRequest, _clientSessionId, cancellationToken);

                return Response.FromValue(executeBatchResponse.Value.Get.ToArray(), executeBatchResponse.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Gets Time Series instances by Time Series Ids asynchronously.
        /// </summary>
        /// <param name="timeSeriesIds">List of Ids of the Time Series instances to return.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>
        /// List of instance or error objects corresponding by position to the array in the request. Instance object is set when operation is successful
        /// and error object is set when operation is unsuccessful.
        /// </returns>
        /// <remarks>
        /// For more samples, see <see href="https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/timeseriesinsights/Azure.IoT.TimeSeriesInsights/samples">our repo samples</see>.
        /// </remarks>
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="timeSeriesIds"/> is <c>null</c>.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// The exception is thrown when <paramref name="timeSeriesIds"/> is empty.
        /// </exception>
        public virtual async Task<Response<InstancesOperationResult[]>> GetInstancesAsync(
            IEnumerable<TimeSeriesId> timeSeriesIds,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TimeSeriesInsightsClient)}.{nameof(GetInstances)}");
            scope.Start();

            try
            {
                Argument.AssertNotNullOrEmpty(timeSeriesIds, nameof(timeSeriesIds));

                InstancesBatchRequest batchRequest = new InstancesBatchRequest()
                {
                    Get = new InstancesRequestBatchGetOrDelete()
                };

                foreach (TimeSeriesId timeSeriesId in timeSeriesIds)
                {
                    batchRequest.Get.TimeSeriesIds.Add(timeSeriesId);
                }

                Response<InstancesBatchResponse> executeBatchResponse = await _timeSeriesInstancesRestClient
                    .ExecuteBatchAsync(batchRequest, _clientSessionId, cancellationToken)
                    .ConfigureAwait(false);

                return Response.FromValue(executeBatchResponse.Value.Get.ToArray(), executeBatchResponse.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Gets Time Series instances by Time Series Ids synchronously.
        /// </summary>
        /// <param name="timeSeriesIds">List of Ids of the Time Series instances to return.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>
        /// List of instance or error objects corresponding by position to the array in the request. Instance object is set when operation is successful
        /// and error object is set when operation is unsuccessful.
        /// </returns>
        /// <seealso cref="GetInstancesAsync(IEnumerable{TimeSeriesId}, CancellationToken)">
        /// See the asynchronous version of this method for examples.
        /// </seealso>
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="timeSeriesIds"/> is <c>null</c>.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// The exception is thrown when <paramref name="timeSeriesIds"/> is empty.
        /// </exception>
        public virtual Response<InstancesOperationResult[]> GetInstances(
            IEnumerable<TimeSeriesId> timeSeriesIds,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TimeSeriesInsightsClient)}.{nameof(GetInstances)}");
            scope.Start();

            try
            {
                Argument.AssertNotNullOrEmpty(timeSeriesIds, nameof(timeSeriesIds));

                InstancesBatchRequest batchRequest = new InstancesBatchRequest()
                {
                    Get = new InstancesRequestBatchGetOrDelete()
                };

                foreach (TimeSeriesId timeSeriesId in timeSeriesIds)
                {
                    batchRequest.Get.TimeSeriesIds.Add(timeSeriesId);
                }

                Response<InstancesBatchResponse> executeBatchResponse = _timeSeriesInstancesRestClient
                    .ExecuteBatch(batchRequest, _clientSessionId, cancellationToken);

                return Response.FromValue(executeBatchResponse.Value.Get.ToArray(), executeBatchResponse.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Get search suggestion keywords based on Time Series instance attributes to be used later to search for instances asynchronously.
        /// </summary>
        /// <param name="searchString">The search string for which suggestions are required. Empty is allowed, but not null.</param>
        /// <param name="maxNumberOfSuggestions">The maximum number of suggestions expected in the result. Defaults to 10 when not set.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A list of suggested search strings to be used for further search for Time Series instances or hierarchies.</returns>
        /// <remarks>
        /// For more samples, see <see href="https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/timeseriesinsights/Azure.IoT.TimeSeriesInsights/samples">our repo samples</see>.
        /// </remarks>
        public virtual async Task<Response<SearchSuggestion[]>> GetSearchSuggestionsAsync(
            string searchString,
            int? maxNumberOfSuggestions = null,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TimeSeriesInsightsClient)}.{nameof(GetSearchSuggestions)}");
            scope.Start();

            try
            {
                var instancesSuggestRequest = new InstancesSuggestRequest(searchString)
                {
                    Take = maxNumberOfSuggestions,
                };
                Response<InstancesSuggestResponse> suggestResponse = await _timeSeriesInstancesRestClient
                    .SuggestAsync(instancesSuggestRequest, _clientSessionId, cancellationToken)
                    .ConfigureAwait(false);

                return Response.FromValue(suggestResponse.Value.Suggestions.ToArray(), suggestResponse.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Get search suggestion keywords synchronously based on Time Series instance attributes to be later used to search for instances.
        /// </summary>
        /// <param name="searchString">The search string for which suggestions are required. Empty is allowed, but not null.</param>
        /// <param name="maxNumberOfSuggestions">The maximum number of suggestions expected in the result. Defaults to 10 when not set.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A list of suggested search strings to be used for further search for Time Series instances or hierarchies.</returns>
        /// <seealso cref="GetSearchSuggestionsAsync(string, int?, CancellationToken)">
        /// See the asynchronous version of this method for examples.
        /// </seealso>
        public virtual Response<SearchSuggestion[]> GetSearchSuggestions(string searchString, int? maxNumberOfSuggestions, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TimeSeriesInsightsClient)}.{nameof(GetSearchSuggestions)}");
            scope.Start();

            try
            {
                var instancesSuggestRequest = new InstancesSuggestRequest(searchString)
                {
                    Take = maxNumberOfSuggestions,
                };
                Response<InstancesSuggestResponse> suggestResponse = _timeSeriesInstancesRestClient
                    .Suggest(instancesSuggestRequest, _clientSessionId, cancellationToken);

                return Response.FromValue(suggestResponse.Value.Suggestions.ToArray(), suggestResponse.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Creates Time Series instances asynchronously. If a provided instance is already in use, then this will attempt to replace the existing
        /// instance with the provided Time Series Instance.
        /// </summary>
        /// <param name="timeSeriesInstances">The Time Series instances to be created or replaced.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>
        /// List of error objects corresponding by position to the <paramref name="timeSeriesInstances"/> array in the request.
        /// A <seealso cref="TimeSeriesOperationError"/> object will be set when operation is unsuccessful.
        /// </returns>
        /// <remarks>
        /// For more samples, see <see href="https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/timeseriesinsights/Azure.IoT.TimeSeriesInsights/samples">our repo samples</see>.
        /// </remarks>
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="timeSeriesInstances"/> is <c>null</c>.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// The exception is thrown when <paramref name="timeSeriesInstances"/> is empty.
        /// </exception>
        public virtual async Task<Response<TimeSeriesOperationError[]>> CreateOrReplaceTimeSeriesInstancesAsync(
            IEnumerable<TimeSeriesInstance> timeSeriesInstances,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics
                .CreateScope($"{nameof(TimeSeriesInsightsClient)}.{nameof(CreateOrReplaceTimeSeriesInstances)}");
            scope.Start();

            try
            {
                Argument.AssertNotNullOrEmpty(timeSeriesInstances, nameof(timeSeriesInstances));

                InstancesBatchRequest batchRequest = new InstancesBatchRequest();

                foreach (TimeSeriesInstance instance in timeSeriesInstances)
                {
                    batchRequest.Put.Add(instance);
                }

                Response<InstancesBatchResponse> executeBatchResponse = await _timeSeriesInstancesRestClient
                    .ExecuteBatchAsync(batchRequest, _clientSessionId, cancellationToken)
                    .ConfigureAwait(false);

                // Extract the errors array from the response. If there was an error with creating or replacing one of the instances,
                // it will be placed at the same index location that corresponds to its place in the input array.
                IEnumerable<TimeSeriesOperationError> errorResults = executeBatchResponse.Value.Put.Select((result) => result.Error);

                return Response.FromValue(errorResults.ToArray(), executeBatchResponse.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Creates Time Series instances synchronously. If a provided instance is already in use, then this will attempt to replace the existing
        /// instance with the provided Time Series Instance.
        /// </summary>
        /// <param name="timeSeriesInstances">The Time Series instances to be created or replaced.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>
        /// List of error objects corresponding by position to the <paramref name="timeSeriesInstances"/> array in the request.
        /// A <seealso cref="TimeSeriesOperationError"/> object will be set when operation is unsuccessful.
        /// </returns>
        /// <seealso cref="CreateOrReplaceTimeSeriesInstancesAsync(IEnumerable{TimeSeriesInstance}, CancellationToken)">
        /// See the asynchronous version of this method for examples.
        /// </seealso>
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="timeSeriesInstances"/> is <c>null</c>.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// The exception is thrown when <paramref name="timeSeriesInstances"/> is empty.
        /// </exception>
        public virtual Response<TimeSeriesOperationError[]> CreateOrReplaceTimeSeriesInstances(
            IEnumerable<TimeSeriesInstance> timeSeriesInstances,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TimeSeriesInsightsClient)}.{nameof(CreateOrReplaceTimeSeriesInstances)}");
            scope.Start();

            try
            {
                Argument.AssertNotNullOrEmpty(timeSeriesInstances, nameof(timeSeriesInstances));

                InstancesBatchRequest batchRequest = new InstancesBatchRequest();

                foreach (TimeSeriesInstance instance in timeSeriesInstances)
                {
                    batchRequest.Put.Add(instance);
                }

                Response<InstancesBatchResponse> executeBatchResponse = _timeSeriesInstancesRestClient
                    .ExecuteBatch(batchRequest, _clientSessionId, cancellationToken);

                // Extract the errors array from the response. If there was an error with creating or replacing one of the instances,
                // it will be placed at the same index location that corresponds to its place in the input array.
                IEnumerable<TimeSeriesOperationError> errorResults = executeBatchResponse.Value.Put.Select((result) => result.Error);

                return Response.FromValue(errorResults.ToArray(), executeBatchResponse.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Replaces Time Series instances asynchronously.
        /// </summary>
        /// <param name="timeSeriesInstances">The Time Series instances to replaced.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>
        /// List of objects corresponding by position to the <paramref name="timeSeriesInstances"/> array in the request. Instance object
        /// is set when operation is successful and error object is set when operation is unsuccessful.
        /// </returns>
        /// <remarks>
        /// For more samples, see <see href="https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/timeseriesinsights/Azure.IoT.TimeSeriesInsights/samples">our repo samples</see>.
        /// </remarks>
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="timeSeriesInstances"/> is <c>null</c>.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// The exception is thrown when <paramref name="timeSeriesInstances"/> is empty.
        /// </exception>
        public virtual async Task<Response<InstancesOperationResult[]>> ReplaceTimeSeriesInstancesAsync(
            IEnumerable<TimeSeriesInstance> timeSeriesInstances,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics
                .CreateScope($"{nameof(TimeSeriesInsightsClient)}.{nameof(ReplaceTimeSeriesInstances)}");
            scope.Start();

            try
            {
                Argument.AssertNotNullOrEmpty(timeSeriesInstances, nameof(timeSeriesInstances));

                InstancesBatchRequest batchRequest = new InstancesBatchRequest();

                foreach (TimeSeriesInstance instance in timeSeriesInstances)
                {
                    batchRequest.Update.Add(instance);
                }

                Response<InstancesBatchResponse> executeBatchResponse = await _timeSeriesInstancesRestClient
                    .ExecuteBatchAsync(batchRequest, _clientSessionId, cancellationToken)
                    .ConfigureAwait(false);

                return Response.FromValue(executeBatchResponse.Value.Update.ToArray(), executeBatchResponse.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Replaces Time Series instances synchronously.
        /// </summary>
        /// <param name="timeSeriesInstances">The Time Series instances to be replaced.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>
        /// List of objects corresponding by position to the <paramref name="timeSeriesInstances"/> array in the request. Instance object
        /// is set when operation is successful and error object is set when operation is unsuccessful.
        /// </returns>
        /// <seealso cref="ReplaceTimeSeriesInstancesAsync(IEnumerable{TimeSeriesInstance}, CancellationToken)">
        /// See the asynchronous version of this method for examples.
        /// </seealso>
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="timeSeriesInstances"/> is <c>null</c>.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// The exception is thrown when <paramref name="timeSeriesInstances"/> is empty.
        /// </exception>
        public virtual Response<InstancesOperationResult[]> ReplaceTimeSeriesInstances(
            IEnumerable<TimeSeriesInstance> timeSeriesInstances,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TimeSeriesInsightsClient)}.{nameof(ReplaceTimeSeriesInstances)}");
            scope.Start();

            try
            {
                Argument.AssertNotNullOrEmpty(timeSeriesInstances, nameof(timeSeriesInstances));

                InstancesBatchRequest batchRequest = new InstancesBatchRequest();

                foreach (TimeSeriesInstance instance in timeSeriesInstances)
                {
                    batchRequest.Update.Add(instance);
                }

                Response<InstancesBatchResponse> executeBatchResponse = _timeSeriesInstancesRestClient
                    .ExecuteBatch(batchRequest, _clientSessionId, cancellationToken);

                return Response.FromValue(executeBatchResponse.Value.Update.ToArray(), executeBatchResponse.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Deletes Time Series instances from the environment by instance names asynchronously.
        /// </summary>
        /// <param name="timeSeriesNames">List of names of the Time Series instance to delete.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>
        /// List of error objects corresponding by position to the array in the request. Null means the instance has been deleted, or did not exist.
        /// Error object is set when operation is unsuccessful.
        /// </returns>
        /// <remarks>
        /// For more samples, see <see href="https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/timeseriesinsights/Azure.IoT.TimeSeriesInsights/samples">our repo samples</see>.
        /// </remarks>
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="timeSeriesNames"/> is <c>null</c>.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// The exception is thrown when <paramref name="timeSeriesNames"/> is empty.
        /// </exception>
        public virtual async Task<Response<TimeSeriesOperationError[]>> DeleteInstancesAsync(
            IEnumerable<string> timeSeriesNames,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TimeSeriesInsightsClient)}.{nameof(DeleteInstances)}");
            scope.Start();

            try
            {
                Argument.AssertNotNullOrEmpty(timeSeriesNames, nameof(timeSeriesNames));

                InstancesBatchRequest batchRequest = new InstancesBatchRequest()
                {
                    Delete = new InstancesRequestBatchGetOrDelete()
                };

                foreach (string timeSeriesName in timeSeriesNames)
                {
                    batchRequest.Delete.Names.Add(timeSeriesName);
                }

                Response<InstancesBatchResponse> executeBatchResponse = await _timeSeriesInstancesRestClient
                    .ExecuteBatchAsync(batchRequest, _clientSessionId, cancellationToken)
                    .ConfigureAwait(false);

                return Response.FromValue(executeBatchResponse.Value.Delete.ToArray(), executeBatchResponse.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Deletes Time Series instances from the environment by instance names synchronously.
        /// </summary>
        /// <param name="timeSeriesNames">List of names of the Time Series instance to delete.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>
        /// List of error objects corresponding by position to the array in the request. Null means the instance has been deleted, or did not exist.
        /// Error object is set when operation is unsuccessful.
        /// </returns>
        /// <seealso cref="DeleteInstancesAsync(IEnumerable{string}, CancellationToken)">
        /// See the asynchronous version of this method for examples.
        /// </seealso>
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="timeSeriesNames"/> is <c>null</c>.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// The exception is thrown when <paramref name="timeSeriesNames"/> is empty.
        /// </exception>
        public virtual Response<TimeSeriesOperationError[]> DeleteInstances(
            IEnumerable<string> timeSeriesNames,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TimeSeriesInsightsClient)}.{nameof(DeleteInstances)}");
            scope.Start();

            try
            {
                Argument.AssertNotNullOrEmpty(timeSeriesNames, nameof(timeSeriesNames));

                InstancesBatchRequest batchRequest = new InstancesBatchRequest()
                {
                    Delete = new InstancesRequestBatchGetOrDelete()
                };

                foreach (string timeSeriesName in timeSeriesNames)
                {
                    batchRequest.Delete.Names.Add(timeSeriesName);
                }

                Response<InstancesBatchResponse> executeBatchResponse = _timeSeriesInstancesRestClient
                    .ExecuteBatch(batchRequest, _clientSessionId, cancellationToken);

                return Response.FromValue(executeBatchResponse.Value.Delete.ToArray(), executeBatchResponse.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Deletes Time Series instances from the environment by Time Series Ids asynchronously.
        /// </summary>
        /// <param name="timeSeriesIds">List of Ids of the Time Series instances to delete.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>
        /// List of error objects corresponding by position to the array in the request. Null means the instance has been deleted, or did not exist.
        /// Error object is set when operation is unsuccessful.
        /// </returns>
        /// <remarks>
        /// For more samples, see <see href="https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/timeseriesinsights/Azure.IoT.TimeSeriesInsights/samples">our repo samples</see>.
        /// </remarks>
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="timeSeriesIds"/> is <c>null</c>.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// The exception is thrown when <paramref name="timeSeriesIds"/> is empty.
        /// </exception>
        public virtual async Task<Response<TimeSeriesOperationError[]>> DeleteInstancesAsync(
            IEnumerable<TimeSeriesId> timeSeriesIds,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TimeSeriesInsightsClient)}.{nameof(DeleteInstances)}");
            scope.Start();

            try
            {
                Argument.AssertNotNullOrEmpty(timeSeriesIds, nameof(timeSeriesIds));

                InstancesBatchRequest batchRequest = new InstancesBatchRequest()
                {
                    Delete = new InstancesRequestBatchGetOrDelete()
                };

                foreach (TimeSeriesId timeSeriesId in timeSeriesIds)
                {
                    batchRequest.Delete.TimeSeriesIds.Add(timeSeriesId);
                }

                Response<InstancesBatchResponse> executeBatchResponse = await _timeSeriesInstancesRestClient
                    .ExecuteBatchAsync(batchRequest, _clientSessionId, cancellationToken)
                    .ConfigureAwait(false);

                return Response.FromValue(executeBatchResponse.Value.Delete.ToArray(), executeBatchResponse.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Deletes Time Series instances from the environment by Time Series Ids synchronously.
        /// </summary>
        /// <param name="timeSeriesIds">List of Ids of the Time Series instances to delete.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>
        /// List of error objects corresponding by position to the array in the request. Null means the instance has been deleted, or did not exist.
        /// Error object is set when operation is unsuccessful.
        /// </returns>
        /// <seealso cref="DeleteInstancesAsync(IEnumerable{TimeSeriesId}, CancellationToken)">
        /// See the asynchronous version of this method for examples.
        /// </seealso>
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="timeSeriesIds"/> is <c>null</c>.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// The exception is thrown when <paramref name="timeSeriesIds"/> is empty.
        /// </exception>
        public virtual Response<TimeSeriesOperationError[]> DeleteInstances(
            IEnumerable<TimeSeriesId> timeSeriesIds,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TimeSeriesInsightsClient)}.{nameof(DeleteInstances)}");
            scope.Start();

            try
            {
                Argument.AssertNotNullOrEmpty(timeSeriesIds, nameof(timeSeriesIds));

                InstancesBatchRequest batchRequest = new InstancesBatchRequest()
                {
                    Delete = new InstancesRequestBatchGetOrDelete()
                };

                foreach (TimeSeriesId timeSeriesId in timeSeriesIds)
                {
                    batchRequest.Delete.TimeSeriesIds.Add(timeSeriesId);
                }

                Response<InstancesBatchResponse> executeBatchResponse = _timeSeriesInstancesRestClient
                    .ExecuteBatch(batchRequest, _clientSessionId, cancellationToken);

                return Response.FromValue(executeBatchResponse.Value.Delete.ToArray(), executeBatchResponse.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Retrieve raw events for a given Time Series Id asynchronously.
        /// </summary>
        /// <param name="timeSeriesId">The Time Series Id to retrieve raw events for.</param>
        /// <param name="startTime">Start timestamp of the time range. Events that have this timestamp are included.</param>
        /// <param name="endTime">End timestamp of the time range. Events that match this timestamp are excluded.</param>
        /// <param name="options">Optional parameters to use when querying for events.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The pageable list <see cref="AsyncPageable{QueryResultPage}"/> of query result frames.</returns>
        public virtual AsyncPageable<QueryResultPage> QueryEventsAsync(
            TimeSeriesId timeSeriesId,
            DateTimeOffset startTime,
            DateTimeOffset endTime,
            QueryEventsRequestOptions options = null,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TimeSeriesInsightsClient)}.{nameof(QueryEvents)}");
            scope.Start();

            try
            {
                var searchSpan = new DateTimeRange(startTime, endTime);
                var queryRequest = new QueryRequest
                {
                    GetEvents = new GetEvents(timeSeriesId, searchSpan)
                };

                BuildEventsRequestOptions(options, queryRequest);

                return QueryInternalAsync(queryRequest, options?.StoreType?.ToString(), cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Retrieve raw events for a given Time Series Id synchronously.
        /// </summary>
        /// <param name="timeSeriesId">The Time Series Id to retrieve raw events for.</param>
        /// <param name="startTime">Start timestamp of the time range. Events that have this timestamp are included.</param>
        /// <param name="endTime">End timestamp of the time range. Events that match this timestamp are excluded.</param>
        /// <param name="options">Optional parameters to use when querying for events.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The pageable list <see cref="AsyncPageable{QueryResultPage}"/> of query result frames.</returns>
        public virtual Pageable<QueryResultPage> QueryEvents(
            TimeSeriesId timeSeriesId,
            DateTimeOffset startTime,
            DateTimeOffset endTime,
            QueryEventsRequestOptions options = null,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TimeSeriesInsightsClient)}.{nameof(QueryEvents)}");
            scope.Start();

            try
            {
                var searchSpan = new DateTimeRange(startTime, endTime);
                var queryRequest = new QueryRequest
                {
                    GetEvents = new GetEvents(timeSeriesId, searchSpan)
                };

                BuildEventsRequestOptions(options, queryRequest);

                return QueryInternal(queryRequest, options?.StoreType?.ToString(), cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Retrieve raw events for a given Time Series Id over a specified time interval asynchronously.
        /// </summary>
        /// <param name="timeSeriesId">The Time Series Id to retrieve raw events for.</param>
        /// <param name="timeSpan">The time interval over which to query data.</param>
        /// <param name="endTime">End timestamp of the time range. Events that match this timestamp are excluded. If null is provided, <c>DateTimeOffset.UtcNow</c> is used.</param>
        /// <param name="options">Optional parameters to use when querying for events.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The pageable list <see cref="AsyncPageable{QueryResultPage}"/> of query result frames. Each frame is an array of
        /// timestamps along with their associated properties.</returns>
        public virtual AsyncPageable<QueryResultPage> QueryEventsAsync(
            TimeSeriesId timeSeriesId,
            TimeSpan timeSpan,
            DateTimeOffset? endTime = null,
            QueryEventsRequestOptions options = null,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TimeSeriesInsightsClient)}.{nameof(QueryEvents)}");
            scope.Start();

            try
            {
                DateTimeOffset rangeEndTime = endTime ?? DateTimeOffset.UtcNow;
                DateTimeOffset rangeStartTime = rangeEndTime - timeSpan;
                var searchSpan = new DateTimeRange(rangeStartTime, rangeEndTime);
                var queryRequest = new QueryRequest
                {
                    GetEvents = new GetEvents(timeSeriesId, searchSpan)
                };

                BuildEventsRequestOptions(options, queryRequest);

                return QueryInternalAsync(queryRequest, options?.StoreType?.ToString(), cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Retrieve raw events for a given Time Series Id over a certain time interval synchronously.
        /// </summary>
        /// <param name="timeSeriesId">The Time Series Id to retrieve raw events for.</param>
        /// <param name="timeSpan">The time interval over which to query data.</param>
        /// <param name="endTime">End timestamp of the time range. Events that match this timestamp are excluded. If null is provided, <c>DateTimeOffset.UtcNow</c> is used.</param>
        /// <param name="options">Optional parameters to use when querying for events.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The pageable list <see cref="AsyncPageable{QueryResultPage}"/> of query result frames.</returns>
        public virtual Pageable<QueryResultPage> QueryEvents(
            TimeSeriesId timeSeriesId,
            TimeSpan timeSpan,
            DateTimeOffset? endTime = null,
            QueryEventsRequestOptions options = null,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TimeSeriesInsightsClient)}.{nameof(QueryEvents)}");
            scope.Start();

            try
            {
                DateTimeOffset rangeEndTime = endTime ?? DateTimeOffset.UtcNow;
                DateTimeOffset rangeStartTime = rangeEndTime - timeSpan;
                var searchSpan = new DateTimeRange(rangeStartTime, rangeEndTime);
                var queryRequest = new QueryRequest
                {
                    GetEvents = new GetEvents(timeSeriesId, searchSpan)
                };

                BuildEventsRequestOptions(options, queryRequest);

                return QueryInternal(queryRequest, options?.StoreType?.ToString(), cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Retrieve series events for a given Time Series Id asynchronously.
        /// </summary>
        /// <param name="timeSeriesId">The Time Series Id to retrieve series events for.</param>
        /// <param name="startTime">Start timestamp of the time range. Events that have this timestamp are included.</param>
        /// <param name="endTime">End timestamp of the time range. Events that match this timestamp are excluded.</param>
        /// <param name="options">Optional parameters to use when querying for series events.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The pageable list <see cref="AsyncPageable{QueryResultPage}"/> of query result frames.</returns>
        public virtual AsyncPageable<QueryResultPage> QuerySeriesAsync(
            TimeSeriesId timeSeriesId,
            DateTimeOffset startTime,
            DateTimeOffset endTime,
            QuerySeriesRequestOptions options = null,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TimeSeriesInsightsClient)}.{nameof(QuerySeries)}");
            scope.Start();

            try
            {
                var searchSpan = new DateTimeRange(startTime, endTime);
                var queryRequest = new QueryRequest
                {
                    GetSeries = new GetSeries(timeSeriesId, searchSpan)
                };

                BuildSeriesRequestOptions(options, queryRequest);

                return QueryInternalAsync(queryRequest, options?.StoreType?.ToString(), cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Retrieve series events for a given Time Series Id synchronously.
        /// </summary>
        /// <param name="timeSeriesId">The Time Series Id to retrieve series events for.</param>
        /// <param name="startTime">Start timestamp of the time range. Events that have this timestamp are included.</param>
        /// <param name="endTime">End timestamp of the time range. Events that match this timestamp are excluded.</param>
        /// <param name="options">Optional parameters to use when querying for series events.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The pageable list <see cref="AsyncPageable{QueryResultPage}"/> of query result frames.</returns>
        public virtual Pageable<QueryResultPage> QuerySeries(
            TimeSeriesId timeSeriesId,
            DateTimeOffset startTime,
            DateTimeOffset endTime,
            QuerySeriesRequestOptions options = null,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TimeSeriesInsightsClient)}.{nameof(QuerySeries)}");
            scope.Start();

            try
            {
                var searchSpan = new DateTimeRange(startTime, endTime);
                var queryRequest = new QueryRequest
                {
                    GetSeries = new GetSeries(timeSeriesId, searchSpan)
                };

                BuildSeriesRequestOptions(options, queryRequest);

                return QueryInternal(queryRequest, options?.StoreType?.ToString(), cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Retrieve series events for a given Time Series Id over a specified time interval asynchronously.
        /// </summary>
        /// <param name="timeSeriesId">The Time Series Id to retrieve series events for.</param>
        /// <param name="timeSpan">The time interval over which to query data.</param>
        /// <param name="endTime">End timestamp of the time range. Events that match this timestamp are excluded. If null is provided, <c>DateTimeOffset.UtcNow</c> is used.</param>
        /// <param name="options">Optional parameters to use when querying for series events.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The pageable list <see cref="AsyncPageable{QueryResultPage}"/> of query result frames.</returns>
        public virtual AsyncPageable<QueryResultPage> QuerySeriesAsync(
            TimeSeriesId timeSeriesId,
            TimeSpan timeSpan,
            DateTimeOffset? endTime = null,
            QuerySeriesRequestOptions options = null,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TimeSeriesInsightsClient)}.{nameof(QuerySeries)}");
            scope.Start();

            try
            {
                DateTimeOffset rangeEndTime = endTime ?? DateTimeOffset.UtcNow;
                DateTimeOffset rangeStartTime = rangeEndTime - timeSpan;
                var searchSpan = new DateTimeRange(rangeStartTime, rangeEndTime);
                var queryRequest = new QueryRequest
                {
                    GetSeries = new GetSeries(timeSeriesId, searchSpan)
                };

                BuildSeriesRequestOptions(options, queryRequest);

                return QueryInternalAsync(queryRequest, options?.StoreType?.ToString(), cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Retrieve series events for a given Time Series Id over a certain time interval synchronously.
        /// </summary>
        /// <param name="timeSeriesId">The Time Series Id to retrieve series events for.</param>
        /// <param name="timeSpan">The time interval over which to query data.</param>
        /// <param name="endTime">End timestamp of the time range. Events that match this timestamp are excluded. If null is provided, <c>DateTimeOffset.UtcNow</c> is used.</param>
        /// <param name="options">Optional parameters to use when querying for series events.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The pageable list <see cref="AsyncPageable{QueryResultPage}"/> of query result frames.</returns>
        public virtual Pageable<QueryResultPage> QuerySeries(
            TimeSeriesId timeSeriesId,
            TimeSpan timeSpan,
            DateTimeOffset? endTime = null,
            QuerySeriesRequestOptions options = null,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TimeSeriesInsightsClient)}.{nameof(QuerySeries)}");
            scope.Start();

            try
            {
                DateTimeOffset rangeEndTime = endTime ?? DateTimeOffset.UtcNow;
                DateTimeOffset rangeStartTime = rangeEndTime - timeSpan;
                var searchSpan = new DateTimeRange(rangeStartTime, rangeEndTime);
                var queryRequest = new QueryRequest
                {
                    GetSeries = new GetSeries(timeSeriesId, searchSpan)
                };

                BuildSeriesRequestOptions(options, queryRequest);

                return QueryInternal(queryRequest, options?.StoreType?.ToString(), cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Gets Time Series Insights types in pages asynchronously.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The pageable list <see cref="AsyncPageable{TimeSeriesType}"/> of Time Series types with the http response.</returns>
        public virtual AsyncPageable<TimeSeriesType> GetTimeSeriesTypesAsync(
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TimeSeriesInsightsClient)}.{nameof(GetTimeSeriesTypes)}");
            scope.Start();

            try
            {
                async Task<Page<TimeSeriesType>> FirstPageFunc(int? pageSizeHint)
                {
                    using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TimeSeriesInsightsClient)}.{nameof(GetTimeSeriesTypes)}");
                    scope.Start();

                    try
                    {
                        Response<GetTypesPage> getTypesResponse = await _timeSeriesTypesRestClient
                            .ListAsync(null, _clientSessionId, cancellationToken)
                            .ConfigureAwait(false);
                        return Page.FromValues(getTypesResponse.Value.Types, getTypesResponse.Value.ContinuationToken, getTypesResponse.GetRawResponse());
                    }
                    catch (Exception ex)
                    {
                        scope.Failed(ex);
                        throw;
                    }
                }

                async Task<Page<TimeSeriesType>> NextPageFunc(string nextLink, int? pageSizeHint)
                {
                    using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TimeSeriesInsightsClient)}.{nameof(GetTimeSeriesTypes)}");
                    scope.Start();

                    try
                    {
                        Response<GetTypesPage> getTypesResponse = await _timeSeriesTypesRestClient
                            .ListAsync(nextLink, _clientSessionId, cancellationToken)
                            .ConfigureAwait(false);
                        return Page.FromValues(getTypesResponse.Value.Types, getTypesResponse.Value.ContinuationToken, getTypesResponse.GetRawResponse());
                    }
                    catch (Exception ex)
                    {
                        scope.Failed(ex);
                        throw;
                    }
                }

                return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Gets Time Series Insights types in pages synchronously.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The pageable list <see cref="Pageable{TimeSeriesType}"/> of Time Series types with the http response.</returns>
        /// <seealso cref="GetTimeSeriesTypesAsync(CancellationToken)">
        /// See the asynchronous version of this method for examples.
        /// </seealso>
        public virtual Pageable<TimeSeriesType> GetTimeSeriesTypes(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TimeSeriesInsightsClient)}.{nameof(GetTimeSeriesTypes)}");
            scope.Start();

            try
            {
                Page<TimeSeriesType> FirstPageFunc(int? pageSizeHint)
                {
                    using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TimeSeriesInsightsClient)}.{nameof(GetTimeSeriesTypes)}");
                    scope.Start();

                    try
                    {
                        Response<GetTypesPage> getTypesResponse = _timeSeriesTypesRestClient.List(null, _clientSessionId, cancellationToken);
                        return Page.FromValues(getTypesResponse.Value.Types, getTypesResponse.Value.ContinuationToken, getTypesResponse.GetRawResponse());
                    }
                    catch (Exception ex)
                    {
                        scope.Failed(ex);
                        throw;
                    }
                }

                Page<TimeSeriesType> NextPageFunc(string nextLink, int? pageSizeHint)
                {
                    using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TimeSeriesInsightsClient)}.{nameof(GetTimeSeriesTypes)}");
                    scope.Start();

                    try
                    {
                        Response<GetTypesPage> getTypesResponse = _timeSeriesTypesRestClient.List(nextLink, _clientSessionId, cancellationToken);
                        return Page.FromValues(getTypesResponse.Value.Types, getTypesResponse.Value.ContinuationToken, getTypesResponse.GetRawResponse());
                    }
                    catch (Exception ex)
                    {
                        scope.Failed(ex);
                        throw;
                    }
                }

                return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Gets Time Series Insights types by type names asynchronously.
        /// </summary>
        /// <param name="timeSeriesTypeNames">List of names of the Time Series types to return.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>
        /// List of type or error objects corresponding by position to the array in the request.
        /// Type object is set when operation is successful and error object is set when operation is unsuccessful.
        /// </returns>
        /// <remarks>
        /// For more samples, see <see href="https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/timeseriesinsights/Azure.IoT.TimeSeriesInsights/samples">our repo samples</see>.
        /// </remarks>
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="timeSeriesTypeNames"/> is <c>null</c>.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// The exception is thrown when <paramref name="timeSeriesTypeNames"/> is empty.
        /// </exception>
        public virtual async Task<Response<TimeSeriesTypeOperationResult[]>> GetTimeSeriesTypesByNamesAsync(
            IEnumerable<string> timeSeriesTypeNames,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TimeSeriesInsightsClient)}.{nameof(GetTimeSeriesTypesByNames)}");
            scope.Start();

            try
            {
                Argument.AssertNotNullOrEmpty(timeSeriesTypeNames, nameof(timeSeriesTypeNames));

                var batchRequest = new TypesBatchRequest()
                {
                    Get = new TypesRequestBatchGetOrDelete()
                };

                foreach (string timeSeriesName in timeSeriesTypeNames)
                {
                    batchRequest.Get.Names.Add(timeSeriesName);
                }

                Response<TypesBatchResponse> executeBatchResponse = await _timeSeriesTypesRestClient
                    .ExecuteBatchAsync(batchRequest, _clientSessionId, cancellationToken)
                    .ConfigureAwait(false);

                return Response.FromValue(executeBatchResponse.Value.Get.ToArray(), executeBatchResponse.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Gets Time Series Insights types by type names synchronously.
        /// </summary>
        /// <param name="timeSeriesTypeNames">List of names of the Time Series types to return.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>
        /// List of type or error objects corresponding by position to the array in the request.
        /// Type object is set when operation is successful and error object is set when operation is unsuccessful.
        /// </returns>
        /// <seealso cref="GetTimeSeriesTypesByNamesAsync(IEnumerable{string}, CancellationToken)">
        /// See the asynchronous version of this method for examples.
        /// </seealso>
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="timeSeriesTypeNames"/> is <c>null</c>.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// The exception is thrown when <paramref name="timeSeriesTypeNames"/> is empty.
        /// </exception>
        public virtual Response<TimeSeriesTypeOperationResult[]> GetTimeSeriesTypesByNames(
            IEnumerable<string> timeSeriesTypeNames,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TimeSeriesInsightsClient)}.{nameof(GetTimeSeriesTypesByNames)}");
            scope.Start();

            try
            {
                Argument.AssertNotNullOrEmpty(timeSeriesTypeNames, nameof(timeSeriesTypeNames));

                var batchRequest = new TypesBatchRequest()
                {
                    Get = new TypesRequestBatchGetOrDelete()
                };

                foreach (string timeSeriesName in timeSeriesTypeNames)
                {
                    batchRequest.Get.Names.Add(timeSeriesName);
                }

                Response<TypesBatchResponse> executeBatchResponse = _timeSeriesTypesRestClient
                    .ExecuteBatch(batchRequest, _clientSessionId, cancellationToken);

                return Response.FromValue(executeBatchResponse.Value.Get.ToArray(), executeBatchResponse.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Gets Time Series Insights types by type Ids asynchronously.
        /// </summary>
        /// <param name="timeSeriesTypeIds">List of Time Series type Ids of the Time Series types to return.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>
        /// List of type or error objects corresponding by position to the array in the request.
        /// Type object is set when operation is successful and error object is set when operation is unsuccessful.
        /// </returns>
        /// <remarks>
        /// For more samples, see <see href="https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/timeseriesinsights/Azure.IoT.TimeSeriesInsights/samples">our repo samples</see>.
        /// </remarks>
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="timeSeriesTypeIds"/> is <c>null</c>.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// The exception is thrown when <paramref name="timeSeriesTypeIds"/> is empty.
        /// </exception>
        public virtual async Task<Response<TimeSeriesTypeOperationResult[]>> GetTimeSeriesTypesByIdAsync(
            IEnumerable<string> timeSeriesTypeIds,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TimeSeriesInsightsClient)}.{nameof(GetTimeSeriesTypesById)}");
            scope.Start();

            try
            {
                Argument.AssertNotNullOrEmpty(timeSeriesTypeIds, nameof(timeSeriesTypeIds));

                var batchRequest = new TypesBatchRequest()
                {
                    Get = new TypesRequestBatchGetOrDelete()
                };

                foreach (string typeId in timeSeriesTypeIds)
                {
                    batchRequest.Get.TypeIds.Add(typeId);
                }

                Response<TypesBatchResponse> executeBatchResponse = await _timeSeriesTypesRestClient
                    .ExecuteBatchAsync(batchRequest, _clientSessionId, cancellationToken)
                    .ConfigureAwait(false);

                return Response.FromValue(executeBatchResponse.Value.Get.ToArray(), executeBatchResponse.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Gets Time Series Insights types by type Ids synchronously.
        /// </summary>
        /// <param name="timeSeriesTypeIds">List of Time Series type Ids of the Time Series types to return.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>
        /// List of type or error objects corresponding by position to the array in the request.
        /// Type object is set when operation is successful and error object is set when operation is unsuccessful.
        /// </returns>
        /// <seealso cref="GetTimeSeriesTypesByIdAsync(IEnumerable{string}, CancellationToken)">
        /// See the asynchronous version of this method for examples.
        /// </seealso>
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="timeSeriesTypeIds"/> is <c>null</c>.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// The exception is thrown when <paramref name="timeSeriesTypeIds"/> is empty.
        /// </exception>
        public virtual Response<TimeSeriesTypeOperationResult[]> GetTimeSeriesTypesById(
            IEnumerable<string> timeSeriesTypeIds,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TimeSeriesInsightsClient)}.{nameof(GetTimeSeriesTypesById)}");
            scope.Start();

            try
            {
                Argument.AssertNotNullOrEmpty(timeSeriesTypeIds, nameof(timeSeriesTypeIds));

                var batchRequest = new TypesBatchRequest()
                {
                    Get = new TypesRequestBatchGetOrDelete()
                };

                foreach (string typeId in timeSeriesTypeIds)
                {
                    batchRequest.Get.TypeIds.Add(typeId);
                }

                Response<TypesBatchResponse> executeBatchResponse = _timeSeriesTypesRestClient
                    .ExecuteBatch(batchRequest, _clientSessionId, cancellationToken);

                return Response.FromValue(executeBatchResponse.Value.Get.ToArray(), executeBatchResponse.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Creates Time Series instances types asynchronously. If a provided instance type is already in use, then this will attempt to replace the existing instance type with the provided Time Series Instance.
        /// </summary>
        /// <param name="timeSeriesTypes">The Time Series instances types to be created or replaced.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>
        /// List of error objects corresponding by position to the <paramref name="timeSeriesTypes"/> array in the request.
        /// An error object will be set when operation is unsuccessful.
        /// </returns>
        /// <remarks>
        /// For more samples, see <see href="https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/timeseriesinsights/Azure.IoT.TimeSeriesInsights/samples">our repo samples</see>.
        /// </remarks>
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="timeSeriesTypes"/> is <c>null</c>.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// The exception is thrown when <paramref name="timeSeriesTypes"/> is empty.
        /// </exception>
        public virtual async Task<Response<TimeSeriesOperationError[]>> CreateOrReplaceTimeSeriesTypesAsync(
            IEnumerable<TimeSeriesType> timeSeriesTypes,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics
                .CreateScope($"{nameof(TimeSeriesInsightsClient)}.{nameof(CreateOrReplaceTimeSeriesTypes)}");
            scope.Start();

            try
            {
                Argument.AssertNotNullOrEmpty(timeSeriesTypes, nameof(timeSeriesTypes));

                var batchRequest = new TypesBatchRequest();

                foreach (TimeSeriesType type in timeSeriesTypes)
                {
                    batchRequest.Put.Add(type);
                }

                Response<TypesBatchResponse> executeBatchResponse = await _timeSeriesTypesRestClient
                    .ExecuteBatchAsync(batchRequest, _clientSessionId, cancellationToken)
                    .ConfigureAwait(false);

                // Extract the errors array from the response. If there was an error with creating or replacing one of the types,
                // it will be placed at the same index location that corresponds to its place in the input array.
                IEnumerable<TimeSeriesOperationError> errorResults = executeBatchResponse.Value.Put.Select((result) => result.Error);

                return Response.FromValue(errorResults.ToArray(), executeBatchResponse.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Creates Time Series instances types asynchronously. If a provided instance type is already in use, then this will attempt to replace the existing instance type with the provided Time Series Instance.
        /// </summary>
        /// <param name="timeSeriesTypes">The Time Series instances types to be created or replaced.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>
        /// List of error objects corresponding by position to the <paramref name="timeSeriesTypes"/> array in the request.
        /// An error object will be set when operation is unsuccessful.
        /// </returns>
        /// <seealso cref="CreateOrReplaceTimeSeriesInstancesAsync(IEnumerable{TimeSeriesInstance}, CancellationToken)">
        /// See the asynchronous version of this method for examples.
        /// </seealso>
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="timeSeriesTypes"/> is <c>null</c>.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// The exception is thrown when <paramref name="timeSeriesTypes"/> is empty.
        /// </exception>
        public virtual Response<TimeSeriesOperationError[]> CreateOrReplaceTimeSeriesTypes(
            IEnumerable<TimeSeriesType> timeSeriesTypes,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TimeSeriesInsightsClient)}.{nameof(CreateOrReplaceTimeSeriesInstances)}");
            scope.Start();

            try
            {
                Argument.AssertNotNullOrEmpty(timeSeriesTypes, nameof(timeSeriesTypes));

                var batchRequest = new TypesBatchRequest();

                foreach (TimeSeriesType type in timeSeriesTypes)
                {
                    batchRequest.Put.Add(type);
                }

                Response<TypesBatchResponse> executeBatchResponse = _timeSeriesTypesRestClient
                    .ExecuteBatch(batchRequest, _clientSessionId, cancellationToken);

                // Extract the errors array from the response. If there was an error with creating or replacing one of the types,
                // it will be placed at the same index location that corresponds to its place in the input array.
                IEnumerable<TimeSeriesOperationError> errorResults = executeBatchResponse.Value.Put.Select((result) => result.Error);

                return Response.FromValue(errorResults.ToArray(), executeBatchResponse.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Deletes Time Series Insights types by type names asynchronously.
        /// </summary>
        /// <param name="timeSeriesTypeNames">List of names of the Time Series types to delete.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>
        /// List of type or error objects corresponding by position to the array in the request.
        /// Type object is set when operation is successful and error object is set when operation is unsuccessful.
        /// </returns>
        /// <remarks>
        /// For more samples, see <see href="https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/timeseriesinsights/Azure.IoT.TimeSeriesInsights/samples">our repo samples</see>.
        /// </remarks>
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="timeSeriesTypeNames"/> is <c>null</c>.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// The exception is thrown when <paramref name="timeSeriesTypeNames"/> is empty.
        /// </exception>
        public virtual async Task<Response<TimeSeriesOperationError[]>> DeleteTimeSeriesTypesByNamesAsync(
            IEnumerable<string> timeSeriesTypeNames,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TimeSeriesInsightsClient)}.{nameof(DeleteTimeSeriesTypesByNames)}");
            scope.Start();

            try
            {
                Argument.AssertNotNullOrEmpty(timeSeriesTypeNames, nameof(timeSeriesTypeNames));

                var batchRequest = new TypesBatchRequest
                {
                    Delete = new TypesRequestBatchGetOrDelete()
                };

                foreach (string timeSeriesName in timeSeriesTypeNames)
                {
                    batchRequest.Delete.Names.Add(timeSeriesName);
                }

                Response<TypesBatchResponse> executeBatchResponse = await _timeSeriesTypesRestClient
                    .ExecuteBatchAsync(batchRequest, _clientSessionId, cancellationToken)
                    .ConfigureAwait(false);

                return Response.FromValue(executeBatchResponse.Value.Delete.ToArray(), executeBatchResponse.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Deletes Time Series Insights types by type names asynchronously.
        /// </summary>
        /// <param name="timeSeriesTypeNames">List of names of the Time Series types to delete.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>
        /// List of type or error objects corresponding by position to the array in the request.
        /// Type object is set when operation is successful and error object is set when operation is unsuccessful.
        /// </returns>
        /// <seealso cref="DeleteTimeSeriesTypesByNamesAsync(IEnumerable{string}, CancellationToken)">
        /// See the asynchronous version of this method for examples.
        /// </seealso>
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="timeSeriesTypeNames"/> is <c>null</c>.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// The exception is thrown when <paramref name="timeSeriesTypeNames"/> is empty.
        /// </exception>
        public virtual Response<TimeSeriesOperationError[]> DeleteTimeSeriesTypesByNames(
            IEnumerable<string> timeSeriesTypeNames,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TimeSeriesInsightsClient)}.{nameof(DeleteTimeSeriesTypesByNames)}");
            scope.Start();

            try
            {
                Argument.AssertNotNullOrEmpty(timeSeriesTypeNames, nameof(timeSeriesTypeNames));

                var batchRequest = new TypesBatchRequest
                {
                    Delete = new TypesRequestBatchGetOrDelete()
                };

                foreach (string timeSeriesName in timeSeriesTypeNames)
                {
                    batchRequest.Delete.Names.Add(timeSeriesName);
                }

                Response<TypesBatchResponse> executeBatchResponse = _timeSeriesTypesRestClient
                    .ExecuteBatch(batchRequest, _clientSessionId, cancellationToken);

                return Response.FromValue(executeBatchResponse.Value.Delete.ToArray(), executeBatchResponse.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Deletes Time Series Insights types by type Ids asynchronously.
        /// </summary>
        /// <param name="timeSeriesTypeIds">List of Time Series type Ids of the Time Series types to delete.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>
        /// List of type or error objects corresponding by position to the array in the request.
        /// Type object is set when operation is successful and error object is set when operation is unsuccessful.
        /// </returns>
        /// <remarks>
        /// For more samples, see <see href="https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/timeseriesinsights/Azure.IoT.TimeSeriesInsights/samples">our repo samples</see>.
        /// </remarks>
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="timeSeriesTypeIds"/> is <c>null</c>.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// The exception is thrown when <paramref name="timeSeriesTypeIds"/> is empty.
        /// </exception>
        public virtual async Task<Response<TimeSeriesOperationError[]>> DeleteTimeSeriesTypesbyIdAsync(
            IEnumerable<string> timeSeriesTypeIds,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TimeSeriesInsightsClient)}.{nameof(DeleteInstances)}");
            scope.Start();

            try
            {
                Argument.AssertNotNullOrEmpty(timeSeriesTypeIds, nameof(timeSeriesTypeIds));

                var batchRequest = new TypesBatchRequest
                {
                    Delete = new TypesRequestBatchGetOrDelete()
                };

                foreach (string typeId in timeSeriesTypeIds)
                {
                    batchRequest.Delete.TypeIds.Add(typeId);
                }

                Response<TypesBatchResponse> executeBatchResponse = await _timeSeriesTypesRestClient
                    .ExecuteBatchAsync(batchRequest, _clientSessionId, cancellationToken)
                    .ConfigureAwait(false);

                return Response.FromValue(executeBatchResponse.Value.Delete.ToArray(), executeBatchResponse.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Deletes Time Series instances from the environment by Time Series Ids synchronously.
        /// </summary>
        /// <param name="timeSeriesTypeIds">List of Ids of the Time Series instances to delete.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>
        /// List of error objects corresponding by position to the array in the request. Null means the instance has been deleted, or did not exist.
        /// Error object is set when operation is unsuccessful.
        /// </returns>
        /// <seealso cref="DeleteInstancesAsync(IEnumerable{TimeSeriesId}, CancellationToken)">
        /// See the asynchronous version of this method for examples.
        /// </seealso>
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="timeSeriesTypeIds"/> is <c>null</c>.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// The exception is thrown when <paramref name="timeSeriesTypeIds"/> is empty.
        /// </exception>
        public virtual Response<TimeSeriesOperationError[]> DeleteTimeSeriesTypesbyId(
            IEnumerable<string> timeSeriesTypeIds,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TimeSeriesInsightsClient)}.{nameof(DeleteInstances)}");
            scope.Start();
            try
            {
                Argument.AssertNotNullOrEmpty(timeSeriesTypeIds, nameof(timeSeriesTypeIds));

                var batchRequest = new TypesBatchRequest
                {
                    Delete = new TypesRequestBatchGetOrDelete()
                };

                foreach (string typeId in timeSeriesTypeIds ?? Enumerable.Empty<string>())
                {
                    batchRequest.Delete.TypeIds.Add(typeId);
                }
                Response<TypesBatchResponse> executeBatchResponse = _timeSeriesTypesRestClient
                    .ExecuteBatch(batchRequest, _clientSessionId, cancellationToken);
                return Response.FromValue(executeBatchResponse.Value.Delete.ToArray(), executeBatchResponse.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        private AsyncPageable<QueryResultPage> QueryInternalAsync(
                    QueryRequest queryRequest,
                    string storeType, CancellationToken cancellationToken)
        {
            async Task<Page<QueryResultPage>> FirstPageFunc(int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TimeSeriesInsightsClient)}.{nameof(QueryEvents)}");
                scope.Start();
                try
                {
                    Response<QueryResultPage> response = await _queryRestClient
                        .ExecuteAsync(queryRequest, storeType, null, null, cancellationToken)
                        .ConfigureAwait(false);

                    var frame = new QueryResultPage[]
                    {
                            response.Value
                    };

                    return Page.FromValues(frame, response.Value.ContinuationToken, response.GetRawResponse());
                }
                catch (Exception ex)
                {
                    scope.Failed(ex);
                    throw;
                }
            }

            async Task<Page<QueryResultPage>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TimeSeriesInsightsClient)}.{nameof(QueryEvents)}");
                scope.Start();
                try
                {
                    Response<QueryResultPage> response = await _queryRestClient
                        .ExecuteAsync(queryRequest, storeType, nextLink, null, cancellationToken)
                        .ConfigureAwait(false);

                    var frame = new QueryResultPage[]
                    {
                            response.Value
                    };

                    return Page.FromValues(frame, response.Value.ContinuationToken, response.GetRawResponse());
                }
                catch (Exception ex)
                {
                    scope.Failed(ex);
                    throw;
                }
            }

            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        private Pageable<QueryResultPage> QueryInternal(
            QueryRequest queryRequest,
            string storeType,
            CancellationToken cancellationToken)
        {
            Page<QueryResultPage> FirstPageFunc(int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TimeSeriesInsightsClient)}.{nameof(QueryInternal)}");
                scope.Start();
                try
                {
                    Response<QueryResultPage> response = _queryRestClient
                        .Execute(queryRequest, storeType, null, null, cancellationToken);

                    var frame = new QueryResultPage[]
                    {
                            response.Value
                    };

                    return Page.FromValues(frame, response.Value.ContinuationToken, response.GetRawResponse());
                }
                catch (Exception ex)
                {
                    scope.Failed(ex);
                    throw;
                }
            }

            Page<QueryResultPage> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TimeSeriesInsightsClient)}.{nameof(QueryInternal)}");
                scope.Start();
                try
                {
                    Response<QueryResultPage> response = _queryRestClient
                        .Execute(queryRequest, storeType, nextLink, null, cancellationToken);

                    var frame = new QueryResultPage[]
                    {
                            response.Value
                    };

                    return Page.FromValues(frame, response.Value.ContinuationToken, response.GetRawResponse());
                }
                catch (Exception ex)
                {
                    scope.Failed(ex);
                    throw;
                }
            }

            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        private static void BuildEventsRequestOptions(QueryEventsRequestOptions options, QueryRequest queryRequest)
        {
            if (options != null)
            {
                if (options.Filter != null)
                {
                    queryRequest.GetEvents.Filter = new TimeSeriesExpression(options.Filter);
                }

                if (options.ProjectedProperties != null)
                {
                    foreach (EventProperty projectedProperty in options.ProjectedProperties)
                    {
                        queryRequest.GetEvents.ProjectedProperties.Add(projectedProperty);
                    }
                }

                queryRequest.GetEvents.Take = options.MaximumNumberOfEvents;
            }
        }

        private static void BuildSeriesRequestOptions(QuerySeriesRequestOptions options, QueryRequest queryRequest)
        {
            if (options != null)
            {
                if (options.Filter != null)
                {
                    queryRequest.GetSeries.Filter = new TimeSeriesExpression(options.Filter);
                }

                if (options.ProjectedVariables != null)
                {
                    foreach (string projectedVariable in options.ProjectedVariables)
                    {
                        queryRequest.GetSeries.ProjectedVariables.Add(projectedVariable);
                    }
                }

                if (options.InlineVariables != null)
                {
                    foreach (string inlineVariableKey in options.InlineVariables.Keys)
                    {
                        queryRequest.GetSeries.InlineVariables[inlineVariableKey] = options.InlineVariables[inlineVariableKey];
                    }
                }

                queryRequest.GetSeries.Take = options.MaximumNumberOfEvents;
            }
        }
    }
}
