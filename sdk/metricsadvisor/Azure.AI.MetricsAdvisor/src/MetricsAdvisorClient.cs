// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.MetricsAdvisor.Models;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.AI.MetricsAdvisor
{
    /// <summary>
    /// The client to use to connect to the Metrics Advisor Cognitive Service to query information
    /// about the data being monitored, such as detected anomalies, alerts, incidents, and their
    /// root causes. It also provides the ability to send feedback to the service to customize the
    /// behavior of the machine learning models being used.
    /// </summary>
    public class MetricsAdvisorClient
    {
        private readonly ClientDiagnostics _clientDiagnostics;

        private readonly MicrosoftAzureMetricsAdvisorRestAPIOpenAPIV2RestClient _serviceRestClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="MetricsAdvisorClient"/> class.
        /// </summary>
        /// <param name="endpoint">The endpoint to use for connecting to the Metrics Advisor Cognitive Service.</param>
        /// <param name="credential">A credential used to authenticate to the service.</param>
        /// <exception cref="ArgumentNullException"><paramref name="endpoint"/> or <paramref name="credential"/> is null.</exception>
        public MetricsAdvisorClient(Uri endpoint, MetricsAdvisorKeyCredential credential)
            : this(endpoint, credential, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MetricsAdvisorClient"/> class.
        /// </summary>
        /// <param name="endpoint">The endpoint to use for connecting to the Metrics Advisor Cognitive Service.</param>
        /// <param name="credential">A credential used to authenticate to the service.</param>
        /// <param name="options">A set of options to apply when configuring the client.</param>
        /// <exception cref="ArgumentNullException"><paramref name="endpoint"/> or <paramref name="credential"/> is null.</exception>
        public MetricsAdvisorClient(Uri endpoint, MetricsAdvisorKeyCredential credential, MetricsAdvisorClientsOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(credential, nameof(credential));

            options ??= new MetricsAdvisorClientsOptions();

            _clientDiagnostics = new ClientDiagnostics(options);
            HttpPipeline pipeline = HttpPipelineBuilder.Build(options, new MetricsAdvisorKeyCredentialPolicy(credential));

            _serviceRestClient = new MicrosoftAzureMetricsAdvisorRestAPIOpenAPIV2RestClient(_clientDiagnostics, pipeline, endpoint.AbsoluteUri);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MetricsAdvisorClient"/> class.
        /// </summary>
        /// <param name="endpoint">The endpoint to use for connecting to the Metrics Advisor Cognitive Service.</param>
        /// <param name="credential">A credential used to authenticate to the service.</param>
        /// <exception cref="ArgumentNullException"><paramref name="endpoint"/> or <paramref name="credential"/> is null.</exception>
        public MetricsAdvisorClient(Uri endpoint, TokenCredential credential)
            : this(endpoint, credential, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MetricsAdvisorClient"/> class.
        /// </summary>
        /// <param name="endpoint">The endpoint to use for connecting to the Metrics Advisor Cognitive Service.</param>
        /// <param name="credential">A credential used to authenticate to the service.</param>
        /// <param name="options">A set of options to apply when configuring the client.</param>
        /// <exception cref="ArgumentNullException"><paramref name="endpoint"/> or <paramref name="credential"/> is null.</exception>
        public MetricsAdvisorClient(Uri endpoint, TokenCredential credential, MetricsAdvisorClientsOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(credential, nameof(credential));

            options ??= new MetricsAdvisorClientsOptions();

            _clientDiagnostics = new ClientDiagnostics(options);
            HttpPipeline pipeline = HttpPipelineBuilder.Build(options, new BearerTokenAuthenticationPolicy(credential, Constants.DefaultCognitiveScope));

            _serviceRestClient = new MicrosoftAzureMetricsAdvisorRestAPIOpenAPIV2RestClient(_clientDiagnostics, pipeline, endpoint.AbsoluteUri);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MetricsAdvisorClient"/> class. This constructor
        /// is intended to be used for mocking only.
        /// </summary>
        protected MetricsAdvisorClient()
        {
        }

        #region TimeSeries

        /// <summary>
        /// Gets the possible values a <see cref="DataFeedDimension"/> can assume for a specified <see cref="DataFeedMetric"/>.
        /// </summary>
        /// <param name="metricId">The unique identifier of the <see cref="DataFeedMetric"/>.</param>
        /// <param name="dimensionName">The name of the <see cref="DataFeedDimension"/>.</param>
        /// <param name="options">An optional set of options used to configure the request's behavior.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An <see cref="AsyncPageable{T}"/> containing the collection of values the specified <see cref="DataFeedDimension"/> can assume.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="metricId"/> or <paramref name="dimensionName"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="metricId"/> or <paramref name="dimensionName"/> is empty; or <paramref name="metricId"/> is not a valid GUID.</exception>
        public virtual AsyncPageable<string> GetMetricDimensionValuesAsync(string metricId, string dimensionName, GetMetricDimensionValuesOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(metricId, nameof(metricId));
            Argument.AssertNotNullOrEmpty(dimensionName, nameof(dimensionName));

            Guid metricGuid = ClientCommon.ValidateGuid(metricId, nameof(metricId));
            MetricDimensionQueryOptions queryOptions = new MetricDimensionQueryOptions(dimensionName)
            {
                DimensionValueFilter = options?.DimensionValueToFilter
            };
            int? skip = options?.Skip;
            int? maxPageSize = options?.MaxPageSize;

            async Task<Page<string>> FirstPageFunc(int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorClient)}.{nameof(GetMetricDimensionValues)}");
                scope.Start();

                try
                {
                    Response<MetricDimensionList> response = await _serviceRestClient.GetMetricDimensionAsync(metricGuid, queryOptions, skip, maxPageSize, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            async Task<Page<string>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorClient)}.{nameof(GetMetricDimensionValues)}");
                scope.Start();

                try
                {
                    Response<MetricDimensionList> response = await _serviceRestClient.GetMetricDimensionNextAsync(nextLink, queryOptions, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// Gets the possible values a <see cref="DataFeedDimension"/> can assume for a specified <see cref="DataFeedMetric"/>.
        /// </summary>
        /// <param name="metricId">The unique identifier of the <see cref="DataFeedMetric"/>.</param>
        /// <param name="dimensionName">The name of the <see cref="DataFeedDimension"/>.</param>
        /// <param name="options">An optional set of options used to configure the request's behavior.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="Pageable{T}"/> containing the collection of values the specified <see cref="DataFeedDimension"/> can assume.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="metricId"/> or <paramref name="dimensionName"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="metricId"/> or <paramref name="dimensionName"/> is empty; or <paramref name="metricId"/> is not a valid GUID.</exception>
        public virtual Pageable<string> GetMetricDimensionValues(string metricId, string dimensionName, GetMetricDimensionValuesOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(metricId, nameof(metricId));
            Argument.AssertNotNullOrEmpty(dimensionName, nameof(dimensionName));

            Guid metricGuid = ClientCommon.ValidateGuid(metricId, nameof(metricId));
            MetricDimensionQueryOptions queryOptions = new MetricDimensionQueryOptions(dimensionName)
            {
                DimensionValueFilter = options?.DimensionValueToFilter
            };
            int? skip = options?.Skip;
            int? maxPageSize = options?.MaxPageSize;

            Page<string> FirstPageFunc(int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorClient)}.{nameof(GetMetricDimensionValues)}");
                scope.Start();

                try
                {
                    Response<MetricDimensionList> response = _serviceRestClient.GetMetricDimension(metricGuid, queryOptions, skip, maxPageSize, cancellationToken);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            Page<string> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorClient)}.{nameof(GetMetricDimensionValues)}");
                scope.Start();

                try
                {
                    Response<MetricDimensionList> response = _serviceRestClient.GetMetricDimensionNext(nextLink, queryOptions, cancellationToken);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// Gets a collection of items describing the time series of a specified <see cref="DataFeedMetric"/>.
        /// </summary>
        /// <param name="metricId">The unique identifier of the <see cref="DataFeedMetric"/>.</param>
        /// <param name="options">The set of options used to configure the request's behavior.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An <see cref="AsyncPageable{T}"/> containing the collection of <see cref="MetricSeriesDefinition"/>s.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="metricId"/> or <paramref name="options"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="metricId"/> is empty or not a valid GUID.</exception>
        public virtual AsyncPageable<MetricSeriesDefinition> GetMetricSeriesDefinitionsAsync(string metricId, GetMetricSeriesDefinitionsOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(metricId, nameof(metricId));
            Argument.AssertNotNull(options, nameof(options));

            Guid metricGuid = ClientCommon.ValidateGuid(metricId, nameof(metricId));
            MetricSeriesQueryOptions queryOptions = new MetricSeriesQueryOptions(ClientCommon.NormalizeDateTimeOffset(options.ActiveSince));

            int? skip = options.Skip;
            int? maxPageSize = options.MaxPageSize;

            // Deep copy filter contents from options to queryOptions.

            foreach (KeyValuePair<string, IList<string>> kvp in options.DimensionCombinationsToFilter)
            {
                queryOptions.DimensionFilter.Add(kvp.Key, new List<string>(kvp.Value));
            }

            async Task<Page<MetricSeriesDefinition>> FirstPageFunc(int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorClient)}.{nameof(GetMetricSeriesDefinitions)}");
                scope.Start();

                try
                {
                    Response<MetricSeriesList> response = await _serviceRestClient.GetMetricSeriesAsync(metricGuid, queryOptions, skip, maxPageSize, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            async Task<Page<MetricSeriesDefinition>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorClient)}.{nameof(GetMetricSeriesDefinitions)}");
                scope.Start();

                try
                {
                    Response<MetricSeriesList> response = await _serviceRestClient.GetMetricSeriesNextAsync(nextLink, queryOptions, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// Gets a collection of items describing the time series of a specified <see cref="DataFeedMetric"/>.
        /// </summary>
        /// <param name="metricId">The unique identifier of the <see cref="DataFeedMetric"/>.</param>
        /// <param name="options">The set of options used to configure the request's behavior.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="Pageable{T}"/> containing the collection of <see cref="MetricSeriesDefinition"/>s.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="metricId"/> or <paramref name="options"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="metricId"/> is empty or not a valid GUID.</exception>
        public virtual Pageable<MetricSeriesDefinition> GetMetricSeriesDefinitions(string metricId, GetMetricSeriesDefinitionsOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(metricId, nameof(metricId));
            Argument.AssertNotNull(options, nameof(options));

            Guid metricGuid = ClientCommon.ValidateGuid(metricId, nameof(metricId));
            MetricSeriesQueryOptions queryOptions = new MetricSeriesQueryOptions(ClientCommon.NormalizeDateTimeOffset(options.ActiveSince));

            int? skip = options.Skip;
            int? maxPageSize = options.MaxPageSize;

            // Deep copy filter contents from options to queryOptions.

            foreach (KeyValuePair<string, IList<string>> kvp in options.DimensionCombinationsToFilter)
            {
                queryOptions.DimensionFilter.Add(kvp.Key, new List<string>(kvp.Value));
            }

            Page<MetricSeriesDefinition> FirstPageFunc(int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorClient)}.{nameof(GetMetricSeriesDefinitions)}");
                scope.Start();

                try
                {
                    Response<MetricSeriesList> response = _serviceRestClient.GetMetricSeries(metricGuid, queryOptions, skip, maxPageSize, cancellationToken);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            Page<MetricSeriesDefinition> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorClient)}.{nameof(GetMetricSeriesDefinitions)}");
                scope.Start();

                try
                {
                    Response<MetricSeriesList> response = _serviceRestClient.GetMetricSeriesNext(nextLink, queryOptions, cancellationToken);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// Gets a collection of items describing the time series of a specified <see cref="DataFeedMetric"/> and
        /// details about their ingested data points.
        /// </summary>
        /// <param name="metricId">The unique identifier of the <see cref="DataFeedMetric"/>.</param>
        /// <param name="options">The set of options used to configure the request's behavior.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An <see cref="AsyncPageable{T}"/> containing the collection of <see cref="MetricSeriesData"/>s.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="metricId"/> or <paramref name="options"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="metricId"/> is empty or not a valid GUID.</exception>
        public virtual AsyncPageable<MetricSeriesData> GetMetricSeriesDataAsync(string metricId, GetMetricSeriesDataOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(metricId, nameof(metricId));
            Argument.AssertNotNull(options, nameof(options)); // TODO: add validation for options.SeriesToFilter?

            Guid metricGuid = ClientCommon.ValidateGuid(metricId, nameof(metricId));
            IEnumerable<IDictionary<string, string>> series = options.SeriesToFilter.Select(key => key.Dimension);
            MetricDataQueryOptions queryOptions = new MetricDataQueryOptions(ClientCommon.NormalizeDateTimeOffset(options.StartTime), ClientCommon.NormalizeDateTimeOffset(options.EndTime), series);

            async Task<Page<MetricSeriesData>> FirstPageFunc(int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorClient)}.{nameof(GetMetricSeriesData)}");
                scope.Start();

                try
                {
                    Response<MetricDataList> response = await _serviceRestClient.GetMetricDataAsync(metricGuid, queryOptions, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, null, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, null);
        }

        /// <summary>
        /// Gets a collection of items describing the time series of a specified <see cref="DataFeedMetric"/> and
        /// details about their ingested data points.
        /// </summary>
        /// <param name="metricId">The unique identifier of the <see cref="DataFeedMetric"/>.</param>
        /// <param name="options">The set of options used to configure the request's behavior.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="Pageable{T}"/> containing the collection of <see cref="MetricSeriesData"/>s.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="metricId"/> or <paramref name="options"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="metricId"/> is empty or not a valid GUID.</exception>
        public virtual Pageable<MetricSeriesData> GetMetricSeriesData(string metricId, GetMetricSeriesDataOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(metricId, nameof(metricId));
            Argument.AssertNotNull(options, nameof(options)); // TODO: add validation for options.SeriesToFilter?

            Guid metricGuid = ClientCommon.ValidateGuid(metricId, nameof(metricId));
            IEnumerable<IDictionary<string, string>> series = options.SeriesToFilter.Select(key => key.Dimension);
            MetricDataQueryOptions queryOptions = new MetricDataQueryOptions(ClientCommon.NormalizeDateTimeOffset(options.StartTime), ClientCommon.NormalizeDateTimeOffset(options.EndTime), series);

            Page<MetricSeriesData> FirstPageFunc(int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorClient)}.{nameof(GetMetricSeriesData)}");
                scope.Start();

                try
                {
                    Response<MetricDataList> response = _serviceRestClient.GetMetricData(metricGuid, queryOptions, cancellationToken);
                    return Page.FromValues(response.Value.Value, null, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            return PageableHelpers.CreateEnumerable(FirstPageFunc, null);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="metricId"></param>
        /// <param name="options"></param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns></returns>
        public virtual AsyncPageable<EnrichmentStatus> GetMetricEnrichmentStatusesAsync(string metricId, GetMetricEnrichmentStatusesOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(metricId, nameof(metricId));
            Argument.AssertNotNull(options, nameof(options));

            Guid metricGuid = ClientCommon.ValidateGuid(metricId, nameof(metricId));
            EnrichmentStatusQueryOption queryOptions = new EnrichmentStatusQueryOption(ClientCommon.NormalizeDateTimeOffset(options.StartTime), ClientCommon.NormalizeDateTimeOffset(options.EndTime));
            int? skip = options.Skip;
            int? maxPageSize = options.MaxPageSize;

            async Task<Page<EnrichmentStatus>> FirstPageFunc(int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorClient)}.{nameof(GetMetricEnrichmentStatuses)}");
                scope.Start();

                try
                {
                    Response<EnrichmentStatusList> response = await _serviceRestClient.GetEnrichmentStatusByMetricAsync(metricGuid, queryOptions, skip, maxPageSize, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            async Task<Page<EnrichmentStatus>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorClient)}.{nameof(GetMetricEnrichmentStatuses)}");
                scope.Start();

                try
                {
                    Response<EnrichmentStatusList> response = await _serviceRestClient.GetEnrichmentStatusByMetricNextAsync(nextLink, queryOptions, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="metricId"></param>
        /// <param name="options"></param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns></returns>
        public virtual Pageable<EnrichmentStatus> GetMetricEnrichmentStatuses(string metricId, GetMetricEnrichmentStatusesOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(metricId, nameof(metricId));
            Argument.AssertNotNull(options, nameof(options));

            Guid metricGuid = ClientCommon.ValidateGuid(metricId, nameof(metricId));
            EnrichmentStatusQueryOption queryOptions = new EnrichmentStatusQueryOption(ClientCommon.NormalizeDateTimeOffset(options.StartTime), ClientCommon.NormalizeDateTimeOffset(options.EndTime));
            int? skip = options.Skip;
            int? maxPageSize = options.MaxPageSize;

            Page<EnrichmentStatus> FirstPageFunc(int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorClient)}.{nameof(GetMetricEnrichmentStatuses)}");
                scope.Start();

                try
                {
                    Response<EnrichmentStatusList> response = _serviceRestClient.GetEnrichmentStatusByMetric(metricGuid, queryOptions, skip, maxPageSize, cancellationToken);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            Page<EnrichmentStatus> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorClient)}.{nameof(GetMetricEnrichmentStatuses)}");
                scope.Start();

                try
                {
                    Response<EnrichmentStatusList> response = _serviceRestClient.GetEnrichmentStatusByMetricNext(nextLink, queryOptions, cancellationToken);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        #endregion TimeSeries

        #region MetricFeedback

        /// <summary>
        /// Gets a collection of <see cref="MetricFeedback"/> related to the given metric.
        /// </summary>
        /// <param name="metricId">The ID of the metric.</param>
        /// <param name="options">The optional <see cref="GetAllFeedbackOptions"/> containing the options to apply to the request.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>
        /// An <see cref="AsyncPageable{T}"/> containing the collection of <see cref="MetricFeedback"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="metricId"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="metricId"/> is empty or not a valid GUID.</exception>
        public virtual AsyncPageable<MetricFeedback> GetAllFeedbackAsync(string metricId, GetAllFeedbackOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(metricId, nameof(metricId));

            Guid metricGuid = ClientCommon.ValidateGuid(metricId, nameof(metricId));

            MetricFeedbackFilter queryOptions = new MetricFeedbackFilter(metricGuid)
            {
                DimensionFilter = options?.DimensionFilter,
                EndTime = options?.EndTime,
                FeedbackType = options?.FeedbackType,
                StartTime = options?.StartTime,
                TimeMode = options?.TimeMode
            };
            int? skip = options?.Skip;
            int? maxPageSize = options?.MaxPageSize;

            async Task<Page<MetricFeedback>> FirstPageFunc(int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorClient)}.{nameof(GetAllFeedback)}");
                scope.Start();

                try
                {
                    Response<MetricFeedbackList> response = await _serviceRestClient.ListMetricFeedbacksAsync(queryOptions, skip, maxPageSize, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            async Task<Page<MetricFeedback>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorClient)}.{nameof(GetAllFeedback)}");
                scope.Start();

                try
                {
                    Response<MetricFeedbackList> response = await _serviceRestClient.ListMetricFeedbacksNextAsync(nextLink, queryOptions, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// Gets a collection of <see cref="MetricFeedback"/> related to the given metric.
        /// </summary>
        /// <param name="metricId">The ID of the metric.</param>
        /// <param name="options">The optional <see cref="GetAllFeedbackOptions"/> containing the options to apply to the request.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>
        /// A <see cref="Pageable{T}"/> containing the collection of <see cref="MetricFeedback"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="metricId"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="metricId"/> is empty or not a valid GUID.</exception>
        public virtual Pageable<MetricFeedback> GetAllFeedback(string metricId, GetAllFeedbackOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(metricId, nameof(metricId));

            Guid metricGuid = ClientCommon.ValidateGuid(metricId, nameof(metricId));

            MetricFeedbackFilter queryOptions = new MetricFeedbackFilter(metricGuid)
            {
                DimensionFilter = options?.DimensionFilter,
                EndTime = options?.EndTime,
                FeedbackType = options?.FeedbackType,
                StartTime = options?.StartTime,
                TimeMode = options?.TimeMode
            };
            int? skip = options?.Skip;
            int? maxPageSize = options?.MaxPageSize;

            Page<MetricFeedback> FirstPageFunc(int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorClient)}.{nameof(GetAllFeedback)}");
                scope.Start();

                try
                {
                    Response<MetricFeedbackList> response = _serviceRestClient.ListMetricFeedbacks(queryOptions, skip, maxPageSize, cancellationToken);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            Page<MetricFeedback> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorClient)}.{nameof(GetAllFeedback)}");
                scope.Start();

                try
                {
                    Response<MetricFeedbackList> response = _serviceRestClient.ListMetricFeedbacksNext(nextLink, queryOptions, cancellationToken);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// Adds a <see cref="MetricFeedback"/>.
        /// </summary>
        /// <param name="feedback">The <see cref="MetricFeedback"/> to be created.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>
        /// A <see cref="Response{T}"/> containing the result of the operation. The result is a <see cref="MetricFeedback"/>
        /// containing information about the newly added feedback.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="feedback"/> is null.</exception>
        public virtual async Task<Response<MetricFeedback>> AddFeedbackAsync(MetricFeedback feedback, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(feedback, nameof(feedback));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorClient)}.{nameof(AddFeedback)}");
            scope.Start();

            try
            {
                ResponseWithHeaders<MicrosoftAzureMetricsAdvisorRestAPIOpenAPIV2CreateMetricFeedbackHeaders> response = await _serviceRestClient.CreateMetricFeedbackAsync(feedback, cancellationToken).ConfigureAwait(false);
                string feedbackId = ClientCommon.GetFeedbackId(response.Headers.Location);

                try
                {
                    var addedFeedback = await GetFeedbackAsync(feedbackId, cancellationToken).ConfigureAwait(false);

                    return Response.FromValue(addedFeedback, response.GetRawResponse());
                }
                catch (Exception ex)
                {
                    throw new RequestFailedException($"The feedback has been added successfully, but the client failed to fetch its data. Feedback ID: {feedbackId}", ex);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Adds a <see cref="MetricFeedback"/>.
        /// </summary>
        /// <param name="feedback">The <see cref="MetricFeedback"/> to be created.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>
        /// A <see cref="Response{T}"/> containing the result of the operation. The result is a <see cref="MetricFeedback"/>
        /// containing information about the newly added feedback.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="feedback"/> is null.</exception>
        public virtual Response<MetricFeedback> AddFeedback(MetricFeedback feedback, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(feedback, nameof(feedback));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorClient)}.{nameof(AddFeedback)}");
            scope.Start();

            try
            {
                ResponseWithHeaders<MicrosoftAzureMetricsAdvisorRestAPIOpenAPIV2CreateMetricFeedbackHeaders> response = _serviceRestClient.CreateMetricFeedback(feedback, cancellationToken);
                string feedbackId = ClientCommon.GetFeedbackId(response.Headers.Location);

                try
                {
                    var addedFeedback = GetFeedback(feedbackId, cancellationToken);

                    return Response.FromValue(addedFeedback, response.GetRawResponse());
                }
                catch (Exception ex)
                {
                    throw new RequestFailedException($"The feedback has been added successfully, but the client failed to fetch its data. Feedback ID: {feedbackId}", ex);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets a <see cref="MetricFeedback"/>.
        /// </summary>
        /// <param name="feedbackId">The ID of the <see cref="MetricFeedback"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>
        /// A <see cref="Response{T}"/> containing the requested <see cref="MetricFeedback"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="feedbackId"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="feedbackId"/> is empty or not a valid GUID.</exception>
        public virtual async Task<Response<MetricFeedback>> GetFeedbackAsync(string feedbackId, CancellationToken cancellationToken = default)
        {
            Guid feedbackGuid = ClientCommon.ValidateGuid(feedbackId, nameof(feedbackId));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorClient)}.{nameof(GetFeedback)}");
            scope.Start();

            try
            {
                return await _serviceRestClient.GetMetricFeedbackAsync(feedbackGuid, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets a <see cref="MetricFeedback"/>.
        /// </summary>
        /// <param name="feedbackId">The ID of the <see cref="MetricFeedback"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>
        /// A <see cref="Response{T}"/> containing the requested <see cref="MetricFeedback"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="feedbackId"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="feedbackId"/> is empty or not a valid GUID.</exception>
        public virtual Response<MetricFeedback> GetFeedback(string feedbackId, CancellationToken cancellationToken = default)
        {
            Guid feedbackGuid = ClientCommon.ValidateGuid(feedbackId, nameof(feedbackId));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorClient)}.{nameof(GetFeedback)}");
            scope.Start();

            try
            {
                return _serviceRestClient.GetMetricFeedback(feedbackGuid, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        #endregion MetricFeedback

        #region AnomalyDetection

        /// <summary>
        /// Gets a collection of items describing the anomalies detected by a given <see cref="AnomalyDetectionConfiguration"/>.
        /// </summary>
        /// <param name="detectionConfigurationId">The unique identifier of the <see cref="MetricAnomalyAlertConfiguration"/>.</param>
        /// <param name="options">The set of options used to configure the request's behavior.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An <see cref="AsyncPageable{T}"/> containing the collection of <see cref="DataPointAnomaly"/> instances.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="detectionConfigurationId"/> or <paramref name="options"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="detectionConfigurationId"/> is empty or not a valid GUID.</exception>
        public virtual AsyncPageable<DataPointAnomaly> GetAnomaliesForDetectionConfigurationAsync(string detectionConfigurationId, GetAnomaliesForDetectionConfigurationOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(detectionConfigurationId, nameof(detectionConfigurationId));
            Argument.AssertNotNull(options, nameof(options));

            Guid detectionConfigurationGuid = ClientCommon.ValidateGuid(detectionConfigurationId, nameof(detectionConfigurationId));
            DetectionAnomalyResultQuery queryOptions = new DetectionAnomalyResultQuery(ClientCommon.NormalizeDateTimeOffset(options.StartTime), ClientCommon.NormalizeDateTimeOffset(options.EndTime))
            {
                Filter = options.Filter?.GetDetectionAnomalyFilterCondition()
            };
            int? skip = options.Skip;
            int? maxPageSize = options.MaxPageSize;

            async Task<Page<DataPointAnomaly>> FirstPageFunc(int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorClient)}.{nameof(GetAnomaliesForDetectionConfiguration)}");
                scope.Start();

                try
                {
                    Response<AnomalyResultList> response = await _serviceRestClient.GetAnomaliesByAnomalyDetectionConfigurationAsync(detectionConfigurationGuid, queryOptions, skip, maxPageSize, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            async Task<Page<DataPointAnomaly>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorClient)}.{nameof(GetAnomaliesForDetectionConfiguration)}");
                scope.Start();

                try
                {
                    Response<AnomalyResultList> response = await _serviceRestClient.GetAnomaliesByAnomalyDetectionConfigurationNextPageAsync(nextLink, detectionConfigurationGuid, queryOptions, skip, maxPageSize, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// Gets a collection of items describing the anomalies detected by a given <see cref="AnomalyDetectionConfiguration"/>.
        /// </summary>
        /// <param name="detectionConfigurationId">The unique identifier of the <see cref="MetricAnomalyAlertConfiguration"/>.</param>
        /// <param name="options">The set of options used to configure the request's behavior.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="Pageable{T}"/> containing the collection of <see cref="DataPointAnomaly"/> instances.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="detectionConfigurationId"/> or <paramref name="options"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="detectionConfigurationId"/> is empty or not a valid GUID.</exception>
        public virtual Pageable<DataPointAnomaly> GetAnomaliesForDetectionConfiguration(string detectionConfigurationId, GetAnomaliesForDetectionConfigurationOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(detectionConfigurationId, nameof(detectionConfigurationId));
            Argument.AssertNotNull(options, nameof(options));

            Guid detectionConfigurationGuid = ClientCommon.ValidateGuid(detectionConfigurationId, nameof(detectionConfigurationId));
            DetectionAnomalyResultQuery queryOptions = new DetectionAnomalyResultQuery(ClientCommon.NormalizeDateTimeOffset(options.StartTime), ClientCommon.NormalizeDateTimeOffset(options.EndTime))
            {
                Filter = options.Filter?.GetDetectionAnomalyFilterCondition()
            };
            int? skip = options.Skip;
            int? maxPageSize = options.MaxPageSize;

            Page<DataPointAnomaly> FirstPageFunc(int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorClient)}.{nameof(GetAnomaliesForDetectionConfiguration)}");
                scope.Start();

                try
                {
                    Response<AnomalyResultList> response = _serviceRestClient.GetAnomaliesByAnomalyDetectionConfiguration(detectionConfigurationGuid, queryOptions, skip, maxPageSize, cancellationToken);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            Page<DataPointAnomaly> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorClient)}.{nameof(GetAnomaliesForDetectionConfiguration)}");
                scope.Start();

                try
                {
                    Response<AnomalyResultList> response = _serviceRestClient.GetAnomaliesByAnomalyDetectionConfigurationNextPage(nextLink, detectionConfigurationGuid, queryOptions, skip, maxPageSize, cancellationToken);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// Gets a collection of items describing the incidents detected by a given <see cref="AnomalyDetectionConfiguration"/>.
        /// </summary>
        /// <param name="detectionConfigurationId">The unique identifier of the <see cref="MetricAnomalyAlertConfiguration"/>.</param>
        /// <param name="options">The set of options used to configure the request's behavior.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An <see cref="AsyncPageable{T}"/> containing the collection of <see cref="DataPointAnomaly"/> instances.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="detectionConfigurationId"/> or <paramref name="options"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="detectionConfigurationId"/> is empty or not a valid GUID.</exception>
        public virtual AsyncPageable<AnomalyIncident> GetIncidentsForDetectionConfigurationAsync(string detectionConfigurationId, GetIncidentsForDetectionConfigurationOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(detectionConfigurationId, nameof(detectionConfigurationId));
            Argument.AssertNotNull(options, nameof(options));

            Guid detectionConfigurationGuid = ClientCommon.ValidateGuid(detectionConfigurationId, nameof(detectionConfigurationId));
            DetectionIncidentResultQuery queryOptions = new DetectionIncidentResultQuery(ClientCommon.NormalizeDateTimeOffset(options.StartTime), ClientCommon.NormalizeDateTimeOffset(options.EndTime))
            {
                Filter = options.GetDetectionIncidentFilterCondition()
            };
            int? maxPageSize = options.MaxPageSize;

            async Task<Page<AnomalyIncident>> FirstPageFunc(int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorClient)}.{nameof(GetIncidentsForDetectionConfiguration)}");
                scope.Start();

                try
                {
                    Response<IncidentResultList> response = await _serviceRestClient.GetIncidentsByAnomalyDetectionConfigurationAsync(detectionConfigurationGuid, queryOptions, maxPageSize, cancellationToken).ConfigureAwait(false);
                    PopulateDetectionConfigurationIds(response.Value.Value, detectionConfigurationId);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            async Task<Page<AnomalyIncident>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorClient)}.{nameof(GetIncidentsForDetectionConfiguration)}");
                scope.Start();

                try
                {
                    Response<IncidentResultList> response = await _serviceRestClient.GetIncidentsByAnomalyDetectionConfigurationNextPageAsync(nextLink, detectionConfigurationGuid, queryOptions, maxPageSize, cancellationToken).ConfigureAwait(false);
                    PopulateDetectionConfigurationIds(response.Value.Value, detectionConfigurationId);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// Gets a collection of items describing the incidents detected by a given <see cref="AnomalyDetectionConfiguration"/>.
        /// </summary>
        /// <param name="detectionConfigurationId">The unique identifier of the <see cref="MetricAnomalyAlertConfiguration"/>.</param>
        /// <param name="options">The set of options used to configure the request's behavior.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="Pageable{T}"/> containing the collection of <see cref="DataPointAnomaly"/> instances.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="detectionConfigurationId"/> or <paramref name="options"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="detectionConfigurationId"/> is empty or not a valid GUID.</exception>
        public virtual Pageable<AnomalyIncident> GetIncidentsForDetectionConfiguration(string detectionConfigurationId, GetIncidentsForDetectionConfigurationOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(detectionConfigurationId, nameof(detectionConfigurationId));
            Argument.AssertNotNull(options, nameof(options));

            Guid detectionConfigurationGuid = ClientCommon.ValidateGuid(detectionConfigurationId, nameof(detectionConfigurationId));
            DetectionIncidentResultQuery queryOptions = new DetectionIncidentResultQuery(ClientCommon.NormalizeDateTimeOffset(options.StartTime), ClientCommon.NormalizeDateTimeOffset(options.EndTime))
            {
                Filter = options.GetDetectionIncidentFilterCondition()
            };
            int? maxPageSize = options.MaxPageSize;

            Page<AnomalyIncident> FirstPageFunc(int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorClient)}.{nameof(GetIncidentsForDetectionConfiguration)}");
                scope.Start();

                try
                {
                    Response<IncidentResultList> response = _serviceRestClient.GetIncidentsByAnomalyDetectionConfiguration(detectionConfigurationGuid, queryOptions, maxPageSize, cancellationToken);
                    PopulateDetectionConfigurationIds(response.Value.Value, detectionConfigurationId);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            Page<AnomalyIncident> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorClient)}.{nameof(GetIncidentsForDetectionConfiguration)}");
                scope.Start();

                try
                {
                    Response<IncidentResultList> response = _serviceRestClient.GetIncidentsByAnomalyDetectionConfigurationNextPage(nextLink, detectionConfigurationGuid, queryOptions, maxPageSize, cancellationToken);
                    PopulateDetectionConfigurationIds(response.Value.Value, detectionConfigurationId);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// Gets the suggestions for likely root causes of an incident.
        /// </summary>
        /// <param name="detectionConfigurationId">The unique identifier of the <see cref="MetricAnomalyAlertConfiguration"/>.</param>
        /// <param name="incidentId">The unique identifier of the <see cref="AnomalyIncident"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An <see cref="AsyncPageable{T}"/> containing the collection of <see cref="IncidentRootCause"/>s.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="detectionConfigurationId"/> or <paramref name="incidentId"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="detectionConfigurationId"/> or <paramref name="incidentId"/> is empty; or <paramref name="detectionConfigurationId"/> is not a valid GUID.</exception>
        public virtual AsyncPageable<IncidentRootCause> GetIncidentRootCausesAsync(string detectionConfigurationId, string incidentId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(detectionConfigurationId, nameof(detectionConfigurationId));
            Argument.AssertNotNullOrEmpty(incidentId, nameof(incidentId));

            Guid detectionConfigurationGuid = ClientCommon.ValidateGuid(detectionConfigurationId, nameof(detectionConfigurationId));

            async Task<Page<IncidentRootCause>> FirstPageFunc(int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorClient)}.{nameof(GetIncidentRootCauses)}");
                scope.Start();

                try
                {
                    Response<RootCauseList> response = await _serviceRestClient.GetRootCauseOfIncidentByAnomalyDetectionConfigurationAsync(detectionConfigurationGuid, incidentId, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, null, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, null);
        }

        /// <summary>
        /// Gets the suggestions for likely root causes of an incident.
        /// </summary>
        /// <param name="detectionConfigurationId">The unique identifier of the <see cref="MetricAnomalyAlertConfiguration"/>.</param>
        /// <param name="incidentId">The unique identifier of the <see cref="AnomalyIncident"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="Pageable{T}"/> containing the collection of <see cref="IncidentRootCause"/>s.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="detectionConfigurationId"/> or <paramref name="incidentId"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="detectionConfigurationId"/> or <paramref name="incidentId"/> is empty; or <paramref name="detectionConfigurationId"/> is not a valid GUID.</exception>
        public virtual Pageable<IncidentRootCause> GetIncidentRootCauses(string detectionConfigurationId, string incidentId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(detectionConfigurationId, nameof(detectionConfigurationId));
            Argument.AssertNotNullOrEmpty(incidentId, nameof(incidentId));

            Guid detectionConfigurationGuid = ClientCommon.ValidateGuid(detectionConfigurationId, nameof(detectionConfigurationId));

            Page<IncidentRootCause> FirstPageFunc(int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorClient)}.{nameof(GetIncidentRootCauses)}");
                scope.Start();

                try
                {
                    Response<RootCauseList> response = _serviceRestClient.GetRootCauseOfIncidentByAnomalyDetectionConfiguration(detectionConfigurationGuid, incidentId, cancellationToken);
                    return Page.FromValues(response.Value.Value, null, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            return PageableHelpers.CreateEnumerable(FirstPageFunc, null);
        }

        /// <summary>
        /// Gets the suggestions for likely root causes of an incident.
        /// </summary>
        /// <param name="incident">The <see cref="AnomalyIncident"/> from which root causes will be returned.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An <see cref="AsyncPageable{T}"/> containing the collection of <see cref="IncidentRootCause"/>s.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="incident"/> is null.</exception>
        public virtual AsyncPageable<IncidentRootCause> GetIncidentRootCausesAsync(AnomalyIncident incident, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(incident, nameof(incident));

            Guid detectionConfigurationGuid = new Guid(incident.DetectionConfigurationId);
            string incidentId = incident.Id;

            async Task<Page<IncidentRootCause>> FirstPageFunc(int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorClient)}.{nameof(GetIncidentRootCauses)}");
                scope.Start();

                try
                {
                    Response<RootCauseList> response = await _serviceRestClient.GetRootCauseOfIncidentByAnomalyDetectionConfigurationAsync(detectionConfigurationGuid, incidentId, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, null, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, null);
        }

        /// <summary>
        /// Gets the suggestions for likely root causes of an incident.
        /// </summary>
        /// <param name="incident">The <see cref="AnomalyIncident"/> from which root causes will be returned.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="Pageable{T}"/> containing the collection of <see cref="IncidentRootCause"/>s.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="incident"/> is null.</exception>
        public virtual Pageable<IncidentRootCause> GetIncidentRootCauses(AnomalyIncident incident, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(incident, nameof(incident));

            Guid detectionConfigurationGuid = new Guid(incident.DetectionConfigurationId);
            string incidentId = incident.Id;

            Page<IncidentRootCause> FirstPageFunc(int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorClient)}.{nameof(GetIncidentRootCauses)}");
                scope.Start();

                try
                {
                    Response<RootCauseList> response = _serviceRestClient.GetRootCauseOfIncidentByAnomalyDetectionConfiguration(detectionConfigurationGuid, incidentId, cancellationToken);
                    return Page.FromValues(response.Value.Value, null, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            return PageableHelpers.CreateEnumerable(FirstPageFunc, null);
        }

        /// <summary>
        /// Gets all the values a specified dimension has assumed for anomalous data points detected by a
        /// <see cref="MetricAnomalyAlertConfiguration"/>.
        /// </summary>
        /// <param name="detectionConfigurationId">The unique identifier of the <see cref="MetricAnomalyAlertConfiguration"/>.</param>
        /// <param name="dimensionName">The name of the dimension.</param>
        /// <param name="options">The set of options used to configure the request's behavior.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An <see cref="AsyncPageable{T}"/> containing the values the specified dimension assumed for anomalous data points. Items are unique.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="detectionConfigurationId"/>, <paramref name="dimensionName"/>, or <paramref name="options"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="detectionConfigurationId"/> or <paramref name="dimensionName"/> is empty; or <paramref name="detectionConfigurationId"/> is not a valid GUID.</exception>
        public virtual AsyncPageable<string> GetAnomalyDimensionValuesAsync(string detectionConfigurationId, string dimensionName, GetAnomalyDimensionValuesOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(detectionConfigurationId, nameof(detectionConfigurationId));
            Argument.AssertNotNullOrEmpty(dimensionName, nameof(dimensionName));
            Argument.AssertNotNull(options, nameof(options));

            Guid detectionConfigurationGuid = ClientCommon.ValidateGuid(detectionConfigurationId, nameof(detectionConfigurationId));
            AnomalyDimensionQuery queryOptions = new AnomalyDimensionQuery(ClientCommon.NormalizeDateTimeOffset(options.StartTime), ClientCommon.NormalizeDateTimeOffset(options.EndTime), dimensionName)
            {
                DimensionFilter = options.DimensionToFilter?.Clone()
            };
            int? skip = options.Skip;
            int? maxPageSize = options.MaxPageSize;

            async Task<Page<string>> FirstPageFunc(int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorClient)}.{nameof(GetAnomalyDimensionValues)}");
                scope.Start();

                try
                {
                    Response<AnomalyDimensionList> response = await _serviceRestClient.GetDimensionOfAnomaliesByAnomalyDetectionConfigurationAsync(detectionConfigurationGuid, queryOptions, skip, maxPageSize, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            async Task<Page<string>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorClient)}.{nameof(GetAnomalyDimensionValues)}");
                scope.Start();

                try
                {
                    Response<AnomalyDimensionList> response = await _serviceRestClient.GetDimensionOfAnomaliesByAnomalyDetectionConfigurationNextAsync(nextLink, queryOptions, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// Gets all the values a specified dimension has assumed for anomalous data points detected by a
        /// <see cref="MetricAnomalyAlertConfiguration"/>.
        /// </summary>
        /// <param name="detectionConfigurationId">The unique identifier of the <see cref="MetricAnomalyAlertConfiguration"/>.</param>
        /// <param name="dimensionName">The name of the dimension.</param>
        /// <param name="options">The set of options used to configure the request's behavior.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="Pageable{T}"/> containing the values the specified dimension assumed for anomalous data points. Items are unique.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="detectionConfigurationId"/>, <paramref name="dimensionName"/>, or <paramref name="options"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="detectionConfigurationId"/> or <paramref name="dimensionName"/> is empty; or <paramref name="detectionConfigurationId"/> is not a valid GUID.</exception>
        public virtual Pageable<string> GetAnomalyDimensionValues(string detectionConfigurationId, string dimensionName, GetAnomalyDimensionValuesOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(detectionConfigurationId, nameof(detectionConfigurationId));
            Argument.AssertNotNullOrEmpty(dimensionName, nameof(dimensionName));
            Argument.AssertNotNull(options, nameof(options));

            Guid detectionConfigurationGuid = ClientCommon.ValidateGuid(detectionConfigurationId, nameof(detectionConfigurationId));
            AnomalyDimensionQuery queryOptions = new AnomalyDimensionQuery(ClientCommon.NormalizeDateTimeOffset(options.StartTime), ClientCommon.NormalizeDateTimeOffset(options.EndTime), dimensionName)
            {
                DimensionFilter = options.DimensionToFilter?.Clone()
            };
            int? skip = options.Skip;
            int? maxPageSize = options.MaxPageSize;

            Page<string> FirstPageFunc(int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorClient)}.{nameof(GetAnomalyDimensionValues)}");
                scope.Start();

                try
                {
                    Response<AnomalyDimensionList> response = _serviceRestClient.GetDimensionOfAnomaliesByAnomalyDetectionConfiguration(detectionConfigurationGuid, queryOptions, skip, maxPageSize, cancellationToken);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            Page<string> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorClient)}.{nameof(GetAnomalyDimensionValues)}");
                scope.Start();

                try
                {
                    Response<AnomalyDimensionList> response = _serviceRestClient.GetDimensionOfAnomaliesByAnomalyDetectionConfigurationNext(nextLink, queryOptions, cancellationToken);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// Query series enriched by anomaly detection.
        /// </summary>
        /// <param name="detectionConfigurationId">The unique identifier of the <see cref="MetricAnomalyAlertConfiguration"/>.</param>
        /// <param name="seriesKeys">The detection series keys.</param>
        /// <param name="startTime">Filters the result. Only data points after this point in time, in UTC, will be returned.</param>
        /// <param name="endTime">Filters the result. Only data points after this point in time, in UTC, will be returned.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An <see cref="AsyncPageable{T}"/> containing the collection of <see cref="MetricEnrichedSeriesData"/>s.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="detectionConfigurationId"/> or <paramref name="seriesKeys"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="detectionConfigurationId"/> or <paramref name="seriesKeys"/> is empty; or <paramref name="detectionConfigurationId"/> is not a valid GUID.</exception>
        public virtual AsyncPageable<MetricEnrichedSeriesData> GetMetricEnrichedSeriesDataAsync(string detectionConfigurationId, IEnumerable<DimensionKey> seriesKeys, DateTimeOffset startTime, DateTimeOffset endTime, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(detectionConfigurationId, nameof(detectionConfigurationId));
            Argument.AssertNotNullOrEmpty(seriesKeys, nameof(seriesKeys)); // TODO: add validation for seriesKeys.Dimension?

            Guid detectionConfigurationGuid = ClientCommon.ValidateGuid(detectionConfigurationId, nameof(detectionConfigurationId));
            IEnumerable<SeriesIdentity> seriesIdentities = seriesKeys.Select(key => key.ConvertToSeriesIdentity());
            DetectionSeriesQuery queryOptions = new DetectionSeriesQuery(ClientCommon.NormalizeDateTimeOffset(startTime), ClientCommon.NormalizeDateTimeOffset(endTime), seriesIdentities);

            async Task<Page<MetricEnrichedSeriesData>> FirstPageFunc(int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorClient)}.{nameof(GetMetricEnrichedSeriesData)}");
                scope.Start();

                try
                {
                    Response<SeriesResultList> response = await _serviceRestClient.GetSeriesByAnomalyDetectionConfigurationAsync(detectionConfigurationGuid, queryOptions, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, null, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, null);
        }

        /// <summary>
        /// Query series enriched by anomaly detection.
        /// </summary>
        /// <param name="detectionConfigurationId">The unique identifier of the <see cref="MetricAnomalyAlertConfiguration"/>.</param>
        /// <param name="seriesKeys">The detection series keys.</param>
        /// <param name="startTime">Filters the result. Only data points after this point in time, in UTC, will be returned.</param>
        /// <param name="endTime">Filters the result. Only data points after this point in time, in UTC, will be returned.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An <see cref="Pageable{T}"/> containing the collection of <see cref="MetricEnrichedSeriesData"/>s.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="detectionConfigurationId"/> or <paramref name="seriesKeys"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="detectionConfigurationId"/> or <paramref name="seriesKeys"/> is empty; or <paramref name="detectionConfigurationId"/> is not a valid GUID.</exception>
        public virtual Pageable<MetricEnrichedSeriesData> GetMetricEnrichedSeriesData(string detectionConfigurationId, IEnumerable<DimensionKey> seriesKeys, DateTimeOffset startTime, DateTimeOffset endTime, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(detectionConfigurationId, nameof(detectionConfigurationId));
            Argument.AssertNotNullOrEmpty(seriesKeys, nameof(seriesKeys)); // TODO: add validation for seriesKeys.Dimension?

            Guid detectionConfigurationGuid = ClientCommon.ValidateGuid(detectionConfigurationId, nameof(detectionConfigurationId));
            IEnumerable<SeriesIdentity> seriesIdentities = seriesKeys.Select(key => key.ConvertToSeriesIdentity());
            DetectionSeriesQuery queryOptions = new DetectionSeriesQuery(ClientCommon.NormalizeDateTimeOffset(startTime), ClientCommon.NormalizeDateTimeOffset(endTime), seriesIdentities);

            Page<MetricEnrichedSeriesData> FirstPageFunc(int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorClient)}.{nameof(GetMetricEnrichedSeriesData)}");
                scope.Start();

                try
                {
                    Response<SeriesResultList> response = _serviceRestClient.GetSeriesByAnomalyDetectionConfiguration(detectionConfigurationGuid, queryOptions, cancellationToken);
                    return Page.FromValues(response.Value.Value, null, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            return PageableHelpers.CreateEnumerable(FirstPageFunc, null);
        }

        private static void PopulateDetectionConfigurationIds(IEnumerable<AnomalyIncident> incidents, string detectionConfigurationId)
        {
            foreach (AnomalyIncident incident in incidents)
            {
                incident.DetectionConfigurationId = detectionConfigurationId;
            }
        }

        #endregion AnomalyDetection

        #region AlertTriggering

        /// <summary>
        /// Gets a collection of items describing the alerts triggered by a given <see cref="AnomalyAlertConfiguration"/>.
        /// </summary>
        /// <param name="alertConfigurationId">The unique identifier of the <see cref="AnomalyAlertConfiguration"/>.</param>
        /// <param name="options">The set of options used to configure the request's behavior.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An <see cref="AsyncPageable{T}"/> containing the collection of <see cref="AnomalyAlert"/>s.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="alertConfigurationId"/> or <paramref name="options"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="alertConfigurationId"/> is empty or not a valid GUID.</exception>
        public virtual AsyncPageable<AnomalyAlert> GetAlertsAsync(string alertConfigurationId, GetAlertsOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(alertConfigurationId, nameof(alertConfigurationId));
            Argument.AssertNotNull(options, nameof(options));

            Guid alertConfigurationGuid = ClientCommon.ValidateGuid(alertConfigurationId, nameof(alertConfigurationId));
            AlertingResultQuery queryOptions = new AlertingResultQuery(ClientCommon.NormalizeDateTimeOffset(options.StartTime), ClientCommon.NormalizeDateTimeOffset(options.EndTime), options.TimeMode);
            int? skip = options.Skip;
            int? maxPageSize = options.MaxPageSize;

            async Task<Page<AnomalyAlert>> FirstPageFunc(int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorClient)}.{nameof(GetAlerts)}");
                scope.Start();

                try
                {
                    Response<AlertResultList> response = await _serviceRestClient.GetAlertsByAnomalyAlertingConfigurationAsync(alertConfigurationGuid, queryOptions, skip, maxPageSize, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            async Task<Page<AnomalyAlert>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorClient)}.{nameof(GetAlerts)}");
                scope.Start();

                try
                {
                    Response<AlertResultList> response = await _serviceRestClient.GetAlertsByAnomalyAlertingConfigurationNextAsync(nextLink, queryOptions, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// Gets a collection of items describing the alerts triggered by a given <see cref="AnomalyAlertConfiguration"/>.
        /// </summary>
        /// <param name="alertConfigurationId">The unique identifier of the <see cref="AnomalyAlertConfiguration"/>.</param>
        /// <param name="options">The set of options used to configure the request's behavior.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="Pageable{T}"/> containing the collection of <see cref="AnomalyAlert"/>s.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="alertConfigurationId"/> or <paramref name="options"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="alertConfigurationId"/> is empty or not a valid GUID.</exception>
        public virtual Pageable<AnomalyAlert> GetAlerts(string alertConfigurationId, GetAlertsOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(alertConfigurationId, nameof(alertConfigurationId));
            Argument.AssertNotNull(options, nameof(options));

            Guid alertConfigurationGuid = ClientCommon.ValidateGuid(alertConfigurationId, nameof(alertConfigurationId));
            AlertingResultQuery queryOptions = new AlertingResultQuery(ClientCommon.NormalizeDateTimeOffset(options.StartTime), ClientCommon.NormalizeDateTimeOffset(options.EndTime), options.TimeMode);
            int? skip = options.Skip;
            int? maxPageSize = options.MaxPageSize;

            Page<AnomalyAlert> FirstPageFunc(int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorClient)}.{nameof(GetAlerts)}");
                scope.Start();

                try
                {
                    Response<AlertResultList> response = _serviceRestClient.GetAlertsByAnomalyAlertingConfiguration(alertConfigurationGuid, queryOptions, skip, maxPageSize, cancellationToken);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            Page<AnomalyAlert> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorClient)}.{nameof(GetAlerts)}");
                scope.Start();

                try
                {
                    Response<AlertResultList> response = _serviceRestClient.GetAlertsByAnomalyAlertingConfigurationNext(nextLink, queryOptions, cancellationToken);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// Gets the collection of anomalies that triggered a specified alert. The associated <see cref="AnomalyAlertConfiguration"/>
        /// must also be specified.
        /// </summary>
        /// <param name="alertConfigurationId">The unique identifier of the <see cref="AnomalyAlertConfiguration"/>.</param>
        /// <param name="alertId">The unique identifier of the alert.</param>
        /// <param name="options">An optional set of options used to configure the request's behavior.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An <see cref="AsyncPageable{T}"/> containing the collection of <see cref="DataPointAnomaly"/> instances.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="alertConfigurationId"/> or <paramref name="alertId"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="alertConfigurationId"/> or <paramref name="alertId"/> is empty; or <paramref name="alertConfigurationId"/> is not a valid GUID.</exception>
        public virtual AsyncPageable<DataPointAnomaly> GetAnomaliesForAlertAsync(string alertConfigurationId, string alertId, GetAnomaliesForAlertOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(alertConfigurationId, nameof(alertConfigurationId));
            Argument.AssertNotNullOrEmpty(alertId, nameof(alertId));

            Guid alertConfigurationGuid = ClientCommon.ValidateGuid(alertConfigurationId, nameof(alertConfigurationId));
            int? skip = options?.Skip;
            int? maxPageSize = options?.MaxPageSize;

            async Task<Page<DataPointAnomaly>> FirstPageFunc(int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorClient)}.{nameof(GetAnomaliesForAlert)}");
                scope.Start();

                try
                {
                    Response<AnomalyResultList> response = await _serviceRestClient.GetAnomaliesFromAlertByAnomalyAlertingConfigurationAsync(alertConfigurationGuid, alertId, skip, maxPageSize, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            async Task<Page<DataPointAnomaly>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorClient)}.{nameof(GetAnomaliesForAlert)}");
                scope.Start();

                try
                {
                    Response<AnomalyResultList> response = await _serviceRestClient.GetAnomaliesFromAlertByAnomalyAlertingConfigurationNextPageAsync(nextLink, alertConfigurationGuid, alertId, skip, maxPageSize, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// Gets the collection of anomalies that triggered a specified alert. The associated <see cref="AnomalyAlertConfiguration"/>
        /// must also be specified.
        /// </summary>
        /// <param name="alertConfigurationId">The unique identifier of the <see cref="AnomalyAlertConfiguration"/>.</param>
        /// <param name="alertId">The unique identifier of the alert.</param>
        /// <param name="options">An optional set of options used to configure the request's behavior.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="Pageable{T}"/> containing the collection of <see cref="DataPointAnomaly"/> instances.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="alertConfigurationId"/> or <paramref name="alertId"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="alertConfigurationId"/> or <paramref name="alertId"/> is empty; or <paramref name="alertConfigurationId"/> is not a valid GUID.</exception>
        public virtual Pageable<DataPointAnomaly> GetAnomaliesForAlert(string alertConfigurationId, string alertId, GetAnomaliesForAlertOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(alertConfigurationId, nameof(alertConfigurationId));
            Argument.AssertNotNullOrEmpty(alertId, nameof(alertId));

            Guid alertConfigurationGuid = ClientCommon.ValidateGuid(alertConfigurationId, nameof(alertConfigurationId));
            int? skip = options?.Skip;
            int? maxPageSize = options?.MaxPageSize;

            Page<DataPointAnomaly> FirstPageFunc(int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorClient)}.{nameof(GetAnomaliesForAlert)}");
                scope.Start();

                try
                {
                    Response<AnomalyResultList> response = _serviceRestClient.GetAnomaliesFromAlertByAnomalyAlertingConfiguration(alertConfigurationGuid, alertId, skip, maxPageSize, cancellationToken);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            Page<DataPointAnomaly> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorClient)}.{nameof(GetAnomaliesForAlert)}");
                scope.Start();

                try
                {
                    Response<AnomalyResultList> response = _serviceRestClient.GetAnomaliesFromAlertByAnomalyAlertingConfigurationNextPage(nextLink, alertConfigurationGuid, alertId, skip, maxPageSize, cancellationToken);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// Given an alert, gets the incidents associated with the anomalies that triggered it. The associated
        /// <see cref="AnomalyAlertConfiguration"/> must also be specified.
        /// </summary>
        /// <param name="alertConfigurationId">The unique identifier of the <see cref="AnomalyAlertConfiguration"/>.</param>
        /// <param name="alertId">The unique identifier of the alert.</param>
        /// <param name="options">An optional set of options used to configure the request's behavior.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An <see cref="AsyncPageable{T}"/> containing the collection of <see cref="AnomalyIncident"/>s.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="alertConfigurationId"/> or <paramref name="alertId"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="alertConfigurationId"/> or <paramref name="alertId"/> is empty; or <paramref name="alertConfigurationId"/> is not a valid GUID.</exception>
        public virtual AsyncPageable<AnomalyIncident> GetIncidentsForAlertAsync(string alertConfigurationId, string alertId, GetIncidentsForAlertOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(alertConfigurationId, nameof(alertConfigurationId));
            Argument.AssertNotNullOrEmpty(alertId, nameof(alertId));

            Guid alertConfigurationGuid = ClientCommon.ValidateGuid(alertConfigurationId, nameof(alertConfigurationId));
            int? skip = options?.Skip;
            int? maxPageSize = options?.MaxPageSize;

            async Task<Page<AnomalyIncident>> FirstPageFunc(int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorClient)}.{nameof(GetIncidentsForAlert)}");
                scope.Start();

                try
                {
                    Response<IncidentResultList> response = await _serviceRestClient.GetIncidentsFromAlertByAnomalyAlertingConfigurationAsync(alertConfigurationGuid, alertId, skip, maxPageSize, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            async Task<Page<AnomalyIncident>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorClient)}.{nameof(GetIncidentsForAlert)}");
                scope.Start();

                try
                {
                    Response<IncidentResultList> response = await _serviceRestClient.GetIncidentsFromAlertByAnomalyAlertingConfigurationNextPageAsync(nextLink, alertConfigurationGuid, alertId, skip, maxPageSize, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// Given an alert, gets the incidents associated with the anomalies that triggered it. The associated
        /// <see cref="AnomalyAlertConfiguration"/> must also be specified.
        /// </summary>
        /// <param name="alertConfigurationId">The unique identifier of the <see cref="AnomalyAlertConfiguration"/>.</param>
        /// <param name="alertId">The unique identifier of the alert.</param>
        /// <param name="options">An optional set of options used to configure the request's behavior.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="Pageable{T}"/> containing the collection of <see cref="AnomalyIncident"/>s.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="alertConfigurationId"/> or <paramref name="alertId"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="alertConfigurationId"/> or <paramref name="alertId"/> is empty; or <paramref name="alertConfigurationId"/> is not a valid GUID.</exception>
        public virtual Pageable<AnomalyIncident> GetIncidentsForAlert(string alertConfigurationId, string alertId, GetIncidentsForAlertOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(alertConfigurationId, nameof(alertConfigurationId));
            Argument.AssertNotNullOrEmpty(alertId, nameof(alertId));

            Guid alertConfigurationGuid = ClientCommon.ValidateGuid(alertConfigurationId, nameof(alertConfigurationId));
            int? skip = options?.Skip;
            int? maxPageSize = options?.MaxPageSize;

            Page<AnomalyIncident> FirstPageFunc(int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorClient)}.{nameof(GetIncidentsForAlert)}");
                scope.Start();

                try
                {
                    Response<IncidentResultList> response = _serviceRestClient.GetIncidentsFromAlertByAnomalyAlertingConfiguration(alertConfigurationGuid, alertId, skip, maxPageSize, cancellationToken);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            Page<AnomalyIncident> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorClient)}.{nameof(GetIncidentsForAlert)}");
                scope.Start();

                try
                {
                    Response<IncidentResultList> response = _serviceRestClient.GetIncidentsFromAlertByAnomalyAlertingConfigurationNextPage(nextLink, alertConfigurationGuid, alertId, skip, maxPageSize, cancellationToken);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        #endregion AlertTriggering
    }
}
