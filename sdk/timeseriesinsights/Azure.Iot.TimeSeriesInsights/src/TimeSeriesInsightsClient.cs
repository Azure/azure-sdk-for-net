// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
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
        private readonly string _clientSessionId;

        private const string TsiDefaultAppId = "https://api.timeseries.azure.com/";
        private const string DefaultPermissionConsent = "/.default";

        private static readonly string[] s_tsiDefaultScopes = new[] { TsiDefaultAppId + DefaultPermissionConsent };

        private readonly ModelSettingsRestClient _modelSettingsRestClient;
        private readonly TimeSeriesInstancesRestClient _timeSeriesInstancesRestClient;

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
            Argument.AssertNotNull(credential, nameof(environmentFqdn));
            Argument.AssertNotNull(options, nameof(options));

            _clientSessionId = new Guid().ToString();
            _clientDiagnostics = new ClientDiagnostics(options);

            options.AddPolicy(new BearerTokenAuthenticationPolicy(credential, GetAuthorizationScopes()), HttpPipelinePosition.PerCall);
            _httpPipeline = HttpPipelineBuilder.Build(options);

            string versionString = options.GetVersionString();
            _modelSettingsRestClient = new ModelSettingsRestClient(_clientDiagnostics, _httpPipeline, environmentFqdn, versionString);
            _timeSeriesInstancesRestClient = new TimeSeriesInstancesRestClient(_clientDiagnostics, _httpPipeline, environmentFqdn, versionString);
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
        /// <returns>The model settings which includes model display name, Time Series Id properties and default type Id with the http response <see cref="Response{TimeSeriesModelSettings}"/>.</returns>
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
        /// <returns>The model settings which includes model display name, Time Series Id properties and default type Id with the http response <see cref="Response{TimeSeriesModelSettings}"/>.</returns>
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
        /// Updates model name or default type Id on Time Series model settings asynchronously.
        /// </summary>
        /// <param name="options">Model settings update request body.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The updated model settings with the http response <see cref="Response{TimeSeriesModelSettings}"/>.</returns>
        /// <exception cref="ArgumentNullException"> <paramref name="options"/> is null. </exception>
        public virtual async Task<Response<TimeSeriesModelSettings>> UpdateModelSettingsAsync(UpdateModelSettingsOptions options, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TimeSeriesInsightsClient)}.{nameof(UpdateModelSettings)}");
            scope.Start();
            try
            {
                // To do: Generate client session Id
                Argument.AssertNotNull(options, nameof(options));
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
        /// Updates model name or default type Id on Time Series model settings synchronously.
        /// </summary>
        /// <param name="options">Model settings update request body.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The updated model settings with the http response <see cref="Response{TimeSeriesModelSettings}"/>.</returns>
        /// <exception cref="ArgumentNullException"> <paramref name="options"/> is null. </exception>
        public virtual Response<TimeSeriesModelSettings> UpdateModelSettings(UpdateModelSettingsOptions options, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TimeSeriesInsightsClient)}.{nameof(UpdateModelSettings)}");
            scope.Start();
            try
            {
                // To do: Generate client session Id
                Argument.AssertNotNull(options, nameof(options));
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
        /// Gets Time Series instances asynchronously from the environment in pages.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The pageable list <see cref="AsyncPageable{TimeSeriesInstance}"/> of Time Series instances belonging to the TSI environment and the http response.</returns>
        /// <remarks>
        /// For more samples, see <see href="https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/timeseriesinsights/Azure.Iot.TimeSeriesInsights/samples">our repo samples</see>.
        /// </remarks>
        /// <example>
        /// <code snippet="Snippet:TimeSeriesInsightsSampleGetInstances">
        /// </code>
        /// </example>
        public virtual AsyncPageable<TimeSeriesInstance> GetTimeSeriesInstancesAsync(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TimeSeriesInsightsClient)}.{nameof(GetTimeSeriesInstancesAsync)}");
            scope.Start();

            try
            {
                async Task<Page<TimeSeriesInstance>> FirstPageFunc(int? pageSizeHint)
                {
                    using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TimeSeriesInsightsClient)}.{nameof(GetSearchSuggestions)}");
                    scope.Start();

                    try
                    {
                        Response<GetInstancesPage> getInstancesResponse = await _timeSeriesInstancesRestClient.ListAsync(null, _clientSessionId, cancellationToken).ConfigureAwait(false);
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
                    using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TimeSeriesInsightsClient)}.{nameof(GetSearchSuggestions)}");
                    scope.Start();

                    try
                    {
                        Response<GetInstancesPage> getInstancesResponse = await _timeSeriesInstancesRestClient.ListAsync(nextLink, _clientSessionId, cancellationToken).ConfigureAwait(false);
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
        /// Gets Time Series instances from the environment in pages.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The pageable list <see cref="Pageable{TimeSeriesInstance}"/> of Time Series instances belonging to the TSI environment and the http response.</returns>
        /// <seealso cref="GetTimeSeriesInstancesAsync(CancellationToken)">
        /// See the asynchronous version of this method for examples.
        /// </seealso>
        public virtual Pageable<TimeSeriesInstance> GetTimeSeriesInstances(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TimeSeriesInsightsClient)}.{nameof(GetTimeSeriesInstancesAsync)}");
            scope.Start();

            try
            {
                Page<TimeSeriesInstance> FirstPageFunc(int? pageSizeHint)
                {
                    using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TimeSeriesInsightsClient)}.{nameof(GetSearchSuggestions)}");
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
                    using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TimeSeriesInsightsClient)}.{nameof(GetSearchSuggestions)}");
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
        /// Gets Time Series instances from the environment by instance names asynchronously.
        /// </summary>
        /// <param name="timeSeriesNames">List of names of the Time Series instance to return.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>
        /// List of instance or error objects corresponding by position to the array in the request. Instance object is set when operation is successful
        /// and error object is set when operation is unsuccessful.
        /// </returns>
        /// <remarks>
        /// For more samples, see <see href="https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/timeseriesinsights/Azure.Iot.TimeSeriesInsights/samples">our repo samples</see>.
        /// </remarks>
        /// <example>
        /// <code snippet="Snippet:TimeSeriesInsightsSampleGetInstancesByNames">
        /// </code>
        /// </example>
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
        /// Gets Time Series instances from the environment by instance names.
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
        /// Gets Time Series instances from the environment by Time Series Id asynchronously.
        /// </summary>
        /// <param name="timeSeriesIds">List of Ids of the Time Series instance to return.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>
        /// List of instance or error objects corresponding by position to the array in the request. Instance object is set when operation is successful
        /// and error object is set when operation is unsuccessful.
        /// </returns>
        /// <remarks>
        /// For more samples, see <see href="https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/timeseriesinsights/Azure.Iot.TimeSeriesInsights/samples">our repo samples</see>.
        /// </remarks>
        /// <example>
        /// <code snippet="Snippet:TimeSeriesInsightsSampleGetInstancesByIds">
        /// </code>
        /// </example>
        public virtual async Task<Response<InstancesOperationResult[]>> GetInstancesAsync(
            IEnumerable<ITimeSeriesId> timeSeriesIds,
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

                foreach (ITimeSeriesId timeSeriesId in timeSeriesIds)
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
        /// Gets Time Series instances from the environment by Time Series Id.
        /// </summary>
        /// <param name="timeSeriesIds">List of Ids of the Time Series instance to return.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>
        /// List of instance or error objects corresponding by position to the array in the request. Instance object is set when operation is successful
        /// and error object is set when operation is unsuccessful.
        /// </returns>
        /// <seealso cref="GetInstancesAsync(IEnumerable{ITimeSeriesId}, CancellationToken)">
        /// See the asynchronous version of this method for examples.
        /// </seealso>
        public virtual Response<InstancesOperationResult[]> GetInstances(
            IEnumerable<ITimeSeriesId> timeSeriesIds,
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

                foreach (ITimeSeriesId timeSeriesId in timeSeriesIds)
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
        /// Get search suggestion keywords asynchronously based on Time Series instance attributes to be later used to search for instances.
        /// </summary>
        /// <param name="searchString">The search string for which suggestions are required. Empty is allowed, but not null.</param>
        /// <param name="maxNumberOfSuggestions">The maximum number of suggestions expected in the result. Defaults to 10 when not set.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A list of suggested search strings to be used for further search for Time Series instances or heirarchies.</returns>
        /// <remarks>
        /// For more samples, see <see href="https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/timeseriesinsights/Azure.Iot.TimeSeriesInsights/samples">our repo samples</see>.
        /// </remarks>
        /// <example>
        /// <code snippet="Snippet:TimeSeriesInsightsSampleGetSearchSuggestions">
        /// </code>
        /// </example>
        public virtual async Task<Response<SearchSuggestion[]>> GetSearchSuggestionsAsync(
            string searchString,
            int? maxNumberOfSuggestions,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TimeSeriesInsightsClient)}.{nameof(GetSearchSuggestions)}");
            scope.Start();

            try
            {
                Argument.AssertNotNull(searchString, nameof(searchString));

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
        /// Get search suggestion keywords based on Time Series instance attributes to be later used to search for instances.
        /// </summary>
        /// <param name="searchString">The search string for which suggestions are required. Empty is allowed, but not null.</param>
        /// <param name="maxNumberOfSuggestions">The maximum number of suggestions expected in the result. Defaults to 10 when not set.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A list of suggested search strings to be used for further search for Time Series instances or heirarchies.</returns>
        /// <seealso cref="GetSearchSuggestionsAsync(string, int?, CancellationToken)">
        /// See the asynchronous version of this method for examples.
        /// </seealso>
        public virtual Response<SearchSuggestion[]> GetSearchSuggestions(string searchString, int? maxNumberOfSuggestions, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TimeSeriesInsightsClient)}.{nameof(GetSearchSuggestions)}");
            scope.Start();

            try
            {
                Argument.AssertNotNullOrEmpty(searchString, nameof(searchString));

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
        /// A <seealso cref="InstancesOperationError"/> object will be set when operation is unsuccessful.
        /// </returns>
        /// <remarks>
        /// For more samples, see <see href="https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/timeseriesinsights/Azure.Iot.TimeSeriesInsights/samples">our repo samples</see>.
        /// </remarks>
        /// <example>
        /// <code snippet="Snippet:TimeSeriesInsightsSampleCreateOrReplaceInstances">
        /// </code>
        /// </example>
        public virtual async Task<Response<InstancesOperationError[]>> CreateOrReplaceTimeSeriesInstancesAsync(
            IEnumerable<TimeSeriesInstance> timeSeriesInstances,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics
                .CreateScope($"{nameof(TimeSeriesInsightsClient)}.{nameof(CreateOrReplaceTimeSeriesInstances)}");
            scope.Start();

            try
            {
                Argument.AssertNotNull(timeSeriesInstances, nameof(timeSeriesInstances));

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
                IEnumerable<InstancesOperationError> errorResults = executeBatchResponse.Value.Put.Select((result) => result.Error);

                return Response.FromValue(errorResults.ToArray(), executeBatchResponse.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Creates Time Series instances. If a provided instance is already in use, then this will attempt to replace the existing
        /// instance with the provided Time Series Instance.
        /// </summary>
        /// <param name="timeSeriesInstances">The Time Series instances to be created or replaced.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>
        /// List of error objects corresponding by position to the <paramref name="timeSeriesInstances"/> array in the request.
        /// A <seealso cref="InstancesOperationError"/> object will be set when operation is unsuccessful.
        /// </returns>
        /// <seealso cref="CreateOrReplaceTimeSeriesInstancesAsync(IEnumerable{TimeSeriesInstance}, CancellationToken)">
        /// See the asynchronous version of this method for examples.
        /// </seealso>
        public virtual Response<InstancesOperationError[]> CreateOrReplaceTimeSeriesInstances(
            IEnumerable<TimeSeriesInstance> timeSeriesInstances,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TimeSeriesInsightsClient)}.{nameof(CreateOrReplaceTimeSeriesInstances)}");
            scope.Start();

            try
            {
                Argument.AssertNotNull(timeSeriesInstances, nameof(timeSeriesInstances));

                InstancesBatchRequest batchRequest = new InstancesBatchRequest();

                foreach (TimeSeriesInstance instance in timeSeriesInstances)
                {
                    batchRequest.Put.Add(instance);
                }

                Response<InstancesBatchResponse> executeBatchResponse = _timeSeriesInstancesRestClient
                    .ExecuteBatch(batchRequest, _clientSessionId, cancellationToken);

                // Extract the errors array from the response. If there was an error with creating or replacing one of the instances,
                // it will be placed at the same index location that corresponds to its place in the input array.
                IEnumerable<InstancesOperationError> errorResults = executeBatchResponse.Value.Put.Select((result) => result.Error);

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
        /// For more samples, see <see href="https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/timeseriesinsights/Azure.Iot.TimeSeriesInsights/samples">our repo samples</see>.
        /// </remarks>
        /// <example>
        /// <code snippet="Snippet:TimeSeriesInsightsSampleReplaceInstances">
        /// </code>
        /// </example>
        public virtual async Task<Response<InstancesOperationResult[]>> ReplaceTimeSeriesInstancesAsync(
            IEnumerable<TimeSeriesInstance> timeSeriesInstances,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics
                .CreateScope($"{nameof(TimeSeriesInsightsClient)}.{nameof(CreateOrReplaceTimeSeriesInstances)}");
            scope.Start();

            try
            {
                Argument.AssertNotNull(timeSeriesInstances, nameof(timeSeriesInstances));

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
        /// Replaces Time Series instances.
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
        public virtual Response<InstancesOperationResult[]> ReplaceTimeSeriesInstances(
            IEnumerable<TimeSeriesInstance> timeSeriesInstances,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TimeSeriesInsightsClient)}.{nameof(CreateOrReplaceTimeSeriesInstances)}");
            scope.Start();

            try
            {
                Argument.AssertNotNull(timeSeriesInstances, nameof(timeSeriesInstances));

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
        /// For more samples, see <see href="https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/timeseriesinsights/Azure.Iot.TimeSeriesInsights/samples">our repo samples</see>.
        /// </remarks>
        /// <example>
        /// <code snippet="Snippet:TimeSeriesInsightsSampleDeletesInstancesByNames">
        /// </code>
        /// </example>
        public virtual async Task<Response<InstancesOperationError[]>> DeleteInstancesAsync(
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
        /// Deletes Time Series instances from the environment by instance names.
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
        public virtual Response<InstancesOperationError[]> DeleteInstances(
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
        /// Deletes Time Series instances from the environment by Time Series Id asynchronously.
        /// </summary>
        /// <param name="timeSeriesIds">List of Ids of the Time Series instance to delete.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>
        /// List of error objects corresponding by position to the array in the request. Null means the instance has been deleted, or did not exist.
        /// Error object is set when operation is unsuccessful.
        /// </returns>
        /// <remarks>
        /// For more samples, see <see href="https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/timeseriesinsights/Azure.Iot.TimeSeriesInsights/samples">our repo samples</see>.
        /// </remarks>
        /// <example>
        /// <code snippet="Snippet:TimeSeriesInsightsSampleDeleteInstancesByIds">
        /// </code>
        /// </example>
        public virtual async Task<Response<InstancesOperationError[]>> DeleteInstancesAsync(
            IEnumerable<ITimeSeriesId> timeSeriesIds,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TimeSeriesInsightsClient)}.{nameof(GetInstances)}");
            scope.Start();

            try
            {
                Argument.AssertNotNullOrEmpty(timeSeriesIds, nameof(timeSeriesIds));

                InstancesBatchRequest batchRequest = new InstancesBatchRequest()
                {
                    Delete = new InstancesRequestBatchGetOrDelete()
                };

                foreach (ITimeSeriesId timeSeriesId in timeSeriesIds)
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
        /// Deletes Time Series instances from the environment by Time Series Id.
        /// </summary>
        /// <param name="timeSeriesIds">List of Ids of the Time Series instance to delete.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>
        /// List of error objects corresponding by position to the array in the request. Null means the instance has been deleted, or did not exist.
        /// Error object is set when operation is unsuccessful.
        /// </returns>
        /// <seealso cref="DeleteInstancesAsync(IEnumerable{ITimeSeriesId}, CancellationToken)">
        /// See the asynchronous version of this method for examples.
        /// </seealso>
        public virtual Response<InstancesOperationError[]> DeleteInstances(
            IEnumerable<ITimeSeriesId> timeSeriesIds,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TimeSeriesInsightsClient)}.{nameof(GetInstances)}");
            scope.Start();

            try
            {
                Argument.AssertNotNullOrEmpty(timeSeriesIds, nameof(timeSeriesIds));

                InstancesBatchRequest batchRequest = new InstancesBatchRequest()
                {
                    Delete = new InstancesRequestBatchGetOrDelete()
                };

                foreach (ITimeSeriesId timeSeriesId in timeSeriesIds)
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
    }
}
