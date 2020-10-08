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

        private readonly AzureCognitiveServiceMetricsAdvisorRestAPIOpenAPIV2RestClient _serviceRestClient;

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
        public MetricsAdvisorClient(Uri endpoint, MetricsAdvisorKeyCredential credential, MetricsAdvisorClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(credential, nameof(credential));

            options ??= new MetricsAdvisorClientOptions();

            _clientDiagnostics = new ClientDiagnostics(options);
            HttpPipeline pipeline = HttpPipelineBuilder.Build(options, new MetricsAdvisorKeyCredentialPolicy(credential));

            _serviceRestClient = new AzureCognitiveServiceMetricsAdvisorRestAPIOpenAPIV2RestClient(_clientDiagnostics, pipeline, endpoint.AbsoluteUri);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MetricsAdvisorClient"/> class.
        /// </summary>
        /// <param name="endpoint">The endpoint to use for connecting to the Metrics Advisor Cognitive Service.</param>
        /// <param name="credential">A credential used to authenticate to the service.</param>
        /// <exception cref="ArgumentNullException"><paramref name="endpoint"/> or <paramref name="credential"/> is null.</exception>
        internal MetricsAdvisorClient(Uri endpoint, TokenCredential credential)
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
        internal MetricsAdvisorClient(Uri endpoint, TokenCredential credential, MetricsAdvisorClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(credential, nameof(credential));

            options ??= new MetricsAdvisorClientOptions();

            _clientDiagnostics = new ClientDiagnostics(options);
            HttpPipeline pipeline = HttpPipelineBuilder.Build(options, new BearerTokenAuthenticationPolicy(credential, Constants.DefaultCognitiveScope));

            _serviceRestClient = new AzureCognitiveServiceMetricsAdvisorRestAPIOpenAPIV2RestClient(_clientDiagnostics, pipeline, endpoint.AbsoluteUri);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MetricsAdvisorClient"/> class. This constructor
        /// is intended to be used for mocking only.
        /// </summary>
        protected MetricsAdvisorClient()
        {
        }

        #region Metrics

        /// <summary>
        /// Gets the possible values a <see cref="MetricDimension"/> can assume for a specified <see cref="DataFeedMetric"/>.
        /// </summary>
        /// <param name="metricId">The unique identifier of the <see cref="DataFeedMetric"/>.</param>
        /// <param name="dimensionName">The name of the <see cref="MetricDimension"/>.</param>
        /// <param name="options">An optional set of options used to configure the request's behavior.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An <see cref="AsyncPageable{T}"/> containing the collection of values the specified <see cref="MetricDimension"/> can assume.</returns>
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
            int? skip = options?.SkipCount;
            int? top = options?.TopCount;

            async Task<Page<string>> FirstPageFunc(int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorClient)}.{nameof(GetMetricDimensionValues)}");
                scope.Start();

                try
                {
                    Response<MetricDimensionList> response = await _serviceRestClient.GetMetricDimensionAsync(metricGuid, queryOptions, skip, top, cancellationToken).ConfigureAwait(false);
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
        /// Gets the possible values a <see cref="MetricDimension"/> can assume for a specified <see cref="DataFeedMetric"/>.
        /// </summary>
        /// <param name="metricId">The unique identifier of the <see cref="DataFeedMetric"/>.</param>
        /// <param name="dimensionName">The name of the <see cref="MetricDimension"/>.</param>
        /// <param name="options">An optional set of options used to configure the request's behavior.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="Pageable{T}"/> containing the collection of values the specified <see cref="MetricDimension"/> can assume.</returns>
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
            int? skip = options?.SkipCount;
            int? top = options?.TopCount;

            Page<string> FirstPageFunc(int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorClient)}.{nameof(GetMetricDimensionValues)}");
                scope.Start();

                try
                {
                    Response<MetricDimensionList> response = _serviceRestClient.GetMetricDimension(metricGuid, queryOptions, skip, top, cancellationToken);
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

            int? skip = options.SkipCount;
            int? top = options.TopCount;

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
                    Response<MetricSeriesList> response = await _serviceRestClient.GetMetricSeriesAsync(metricGuid, queryOptions, skip, top, cancellationToken).ConfigureAwait(false);
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

            int? skip = options.SkipCount;
            int? top = options.TopCount;

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
                    Response<MetricSeriesList> response = _serviceRestClient.GetMetricSeries(metricGuid, queryOptions, skip, top, cancellationToken);
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
        /// <returns>A collection of <see cref="MetricSeriesData"/> items.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="metricId"/> or <paramref name="options"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="metricId"/> is empty or not a valid GUID.</exception>
        public virtual async Task<Response<IReadOnlyList<MetricSeriesData>>> GetMetricSeriesDataAsync(string metricId, GetMetricSeriesDataOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(metricId, nameof(metricId));
            Argument.AssertNotNull(options, nameof(options)); // TODO: add validation for options.SeriesToFilter?

            Guid metricGuid = ClientCommon.ValidateGuid(metricId, nameof(metricId));
            IEnumerable<IDictionary<string, string>> series = options.SeriesToFilter.Select(key => key.Dimension);
            MetricDataQueryOptions queryOptions = new MetricDataQueryOptions(ClientCommon.NormalizeDateTimeOffset(options.StartTime), ClientCommon.NormalizeDateTimeOffset(options.EndTime), series);

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorClient)}.{nameof(GetMetricSeriesData)}");
            scope.Start();

            try
            {
                Response<MetricDataList> response = await _serviceRestClient.GetMetricDataAsync(metricGuid, queryOptions, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value.Value, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets a collection of items describing the time series of a specified <see cref="DataFeedMetric"/> and
        /// details about their ingested data points.
        /// </summary>
        /// <param name="metricId">The unique identifier of the <see cref="DataFeedMetric"/>.</param>
        /// <param name="options">The set of options used to configure the request's behavior.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A collection of <see cref="MetricSeriesData"/> items.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="metricId"/> or <paramref name="options"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="metricId"/> is empty or not a valid GUID.</exception>
        public virtual Response<IReadOnlyList<MetricSeriesData>> GetMetricSeriesData(string metricId, GetMetricSeriesDataOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(metricId, nameof(metricId));
            Argument.AssertNotNull(options, nameof(options)); // TODO: add validation for options.SeriesToFilter?

            Guid metricGuid = ClientCommon.ValidateGuid(metricId, nameof(metricId));
            IEnumerable<IDictionary<string, string>> series = options.SeriesToFilter.Select(key => key.Dimension);
            MetricDataQueryOptions queryOptions = new MetricDataQueryOptions(ClientCommon.NormalizeDateTimeOffset(options.StartTime), ClientCommon.NormalizeDateTimeOffset(options.EndTime), series);

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorClient)}.{nameof(GetMetricSeriesData)}");
            scope.Start();

            try
            {
                Response<MetricDataList> response = _serviceRestClient.GetMetricData(metricGuid, queryOptions, cancellationToken);
                return Response.FromValue(response.Value.Value, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
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
            int? skip = options.SkipCount;
            int? top = options.TopCount;

            async Task<Page<EnrichmentStatus>> FirstPageFunc(int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorClient)}.{nameof(GetMetricEnrichmentStatuses)}");
                scope.Start();

                try
                {
                    Response<EnrichmentStatusList> response = await _serviceRestClient.GetEnrichmentStatusByMetricAsync(metricGuid, queryOptions, skip, top, cancellationToken).ConfigureAwait(false);
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
            int? skip = options.SkipCount;
            int? top = options.TopCount;

            Page<EnrichmentStatus> FirstPageFunc(int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorClient)}.{nameof(GetMetricEnrichmentStatuses)}");
                scope.Start();

                try
                {
                    Response<EnrichmentStatusList> response = _serviceRestClient.GetEnrichmentStatusByMetric(metricGuid, queryOptions, skip, top, cancellationToken);
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

        #endregion Metrics

        #region MetricFeedback

        /// <summary>
        /// Gets a collection of <see cref="MetricFeedback"/>s related to the given metric.
        /// </summary>
        /// <param name="metricId">The ID of the metric.</param>
        /// <param name="options">The optional <see cref="GetMetricFeedbacksOptions"/> containing the options to apply to the request.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>
        /// An <see cref="AsyncPageable{T}"/> containing the collection of <see cref="MetricFeedback"/>s.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="metricId"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="metricId"/> is empty or not a valid GUID.</exception>
        public virtual AsyncPageable<MetricFeedback> GetMetricFeedbacksAsync(string metricId, GetMetricFeedbacksOptions options = default, CancellationToken cancellationToken = default)
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
            int? skip = options?.SkipCount;
            int? top = options?.TopCount;

            async Task<Page<MetricFeedback>> FirstPageFunc(int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorClient)}.{nameof(GetMetricFeedbacks)}");
                scope.Start();

                try
                {
                    Response<MetricFeedbackList> response = await _serviceRestClient.ListMetricFeedbacksAsync(queryOptions, skip, top, cancellationToken).ConfigureAwait(false);
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
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorClient)}.{nameof(GetMetricFeedbacks)}");
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
        /// Gets a collection of <see cref="MetricFeedback"/>s related to the given metric.
        /// </summary>
        /// <param name="metricId">The ID of the metric.</param>
        /// <param name="options">The optional <see cref="GetMetricFeedbacksOptions"/> containing the options to apply to the request.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>
        /// A <see cref="Pageable{T}"/> containing the collection of <see cref="MetricFeedback"/>s.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="metricId"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="metricId"/> is empty or not a valid GUID.</exception>
        /// <returns></returns>
        public virtual Pageable<MetricFeedback> GetMetricFeedbacks(string metricId, GetMetricFeedbacksOptions options = default, CancellationToken cancellationToken = default)
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
            int? skip = options?.SkipCount;
            int? top = options?.TopCount;

            Page<MetricFeedback> FirstPageFunc(int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorClient)}.{nameof(GetMetricFeedbacks)}");
                scope.Start();

                try
                {
                    Response<MetricFeedbackList> response = _serviceRestClient.ListMetricFeedbacks(queryOptions, skip, top, cancellationToken);
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
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorClient)}.{nameof(GetMetricFeedbacks)}");
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
        /// Creates a <see cref="MetricFeedback"/>.
        /// </summary>
        /// <param name="feedback">The <see cref="MetricFeedback"/> to be created.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>
        /// A <see cref="Response{T}"/> containing the created <see cref="MetricFeedback"/>s.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="feedback"/> is null.</exception>
        public virtual async Task<Response<MetricFeedback>> CreateMetricFeedbackAsync(MetricFeedback feedback, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(feedback, nameof(feedback));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorClient)}.{nameof(CreateMetricFeedback)}");
            scope.Start();

            try
            {
                ResponseWithHeaders<AzureCognitiveServiceMetricsAdvisorRestAPIOpenAPIV2CreateMetricFeedbackHeaders> response = await _serviceRestClient.CreateMetricFeedbackAsync(feedback, cancellationToken).ConfigureAwait(false);

                feedback.Id = ClientCommon.GetFeedbackId(response.Headers.Location);

                return Response.FromValue(feedback, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Creates a <see cref="MetricFeedback"/>.
        /// </summary>
        /// <param name="feedback">The <see cref="MetricFeedback"/> to be created.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>
        /// A <see cref="Response{T}"/> containing the created <see cref="MetricFeedback"/>s.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="feedback"/> is null.</exception>
        public virtual Response<MetricFeedback> CreateMetricFeedback(MetricFeedback feedback, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(feedback, nameof(feedback));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorClient)}.{nameof(CreateMetricFeedback)}");
            scope.Start();

            try
            {
                ResponseWithHeaders<AzureCognitiveServiceMetricsAdvisorRestAPIOpenAPIV2CreateMetricFeedbackHeaders> response = _serviceRestClient.CreateMetricFeedback(feedback, cancellationToken);

                feedback.Id = ClientCommon.GetFeedbackId(response.Headers.Location);

                return Response.FromValue(feedback, response.GetRawResponse());
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
        /// A <see cref="Response{T}"/> containing the created <see cref="MetricFeedback"/>s.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="feedbackId"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="feedbackId"/> is empty or not a valid GUID.</exception>
        public virtual async Task<Response<MetricFeedback>> GetMetricFeedbackAsync(string feedbackId, CancellationToken cancellationToken = default)
        {
            Guid feedbackGuid = ClientCommon.ValidateGuid(feedbackId, nameof(feedbackId));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorClient)}.{nameof(GetMetricFeedback)}");
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
        /// A <see cref="Response{T}"/> containing the created <see cref="MetricFeedback"/>s.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="feedbackId"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="feedbackId"/> is empty or not a valid GUID.</exception>
        public virtual Response<MetricFeedback> GetMetricFeedback(string feedbackId, CancellationToken cancellationToken = default)
        {
            Guid feedbackGuid = ClientCommon.ValidateGuid(feedbackId, nameof(feedbackId));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorClient)}.{nameof(GetMetricFeedback)}");
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
        /// <returns>An <see cref="AsyncPageable{T}"/> containing the collection of <see cref="DataAnomaly"/> instances.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="detectionConfigurationId"/> or <paramref name="options"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="detectionConfigurationId"/> is empty or not a valid GUID.</exception>
        public virtual AsyncPageable<DataAnomaly> GetAnomaliesForDetectionConfigurationAsync(string detectionConfigurationId, GetAnomaliesForDetectionConfigurationOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(detectionConfigurationId, nameof(detectionConfigurationId));
            Argument.AssertNotNull(options, nameof(options));

            Guid detectionConfigurationGuid = ClientCommon.ValidateGuid(detectionConfigurationId, nameof(detectionConfigurationId));
            DetectionAnomalyResultQuery queryOptions = new DetectionAnomalyResultQuery(ClientCommon.NormalizeDateTimeOffset(options.StartTime), ClientCommon.NormalizeDateTimeOffset(options.EndTime))
            {
                Filter = options.Filter?.GetDetectionAnomalyFilterCondition()
            };
            int? skip = options.SkipCount;
            int? top = options.TopCount;

            async Task<Page<DataAnomaly>> FirstPageFunc(int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorClient)}.{nameof(GetAnomaliesForDetectionConfiguration)}");
                scope.Start();

                try
                {
                    Response<AnomalyResultList> response = await _serviceRestClient.GetAnomaliesByAnomalyDetectionConfigurationAsync(detectionConfigurationGuid, queryOptions, skip, top, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            async Task<Page<DataAnomaly>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorClient)}.{nameof(GetAnomaliesForDetectionConfiguration)}");
                scope.Start();

                try
                {
                    Response<AnomalyResultList> response = await _serviceRestClient.GetAnomaliesByAnomalyDetectionConfigurationNextPageAsync(nextLink, detectionConfigurationGuid, queryOptions, skip, top, cancellationToken).ConfigureAwait(false);
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
        /// <returns>A <see cref="Pageable{T}"/> containing the collection of <see cref="DataAnomaly"/> instances.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="detectionConfigurationId"/> or <paramref name="options"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="detectionConfigurationId"/> is empty or not a valid GUID.</exception>
        public virtual Pageable<DataAnomaly> GetAnomaliesForDetectionConfiguration(string detectionConfigurationId, GetAnomaliesForDetectionConfigurationOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(detectionConfigurationId, nameof(detectionConfigurationId));
            Argument.AssertNotNull(options, nameof(options));

            Guid detectionConfigurationGuid = ClientCommon.ValidateGuid(detectionConfigurationId, nameof(detectionConfigurationId));
            DetectionAnomalyResultQuery queryOptions = new DetectionAnomalyResultQuery(ClientCommon.NormalizeDateTimeOffset(options.StartTime), ClientCommon.NormalizeDateTimeOffset(options.EndTime))
            {
                Filter = options.Filter?.GetDetectionAnomalyFilterCondition()
            };
            int? skip = options.SkipCount;
            int? top = options.TopCount;

            Page<DataAnomaly> FirstPageFunc(int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorClient)}.{nameof(GetAnomaliesForDetectionConfiguration)}");
                scope.Start();

                try
                {
                    Response<AnomalyResultList> response = _serviceRestClient.GetAnomaliesByAnomalyDetectionConfiguration(detectionConfigurationGuid, queryOptions, skip, top, cancellationToken);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            Page<DataAnomaly> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorClient)}.{nameof(GetAnomaliesForDetectionConfiguration)}");
                scope.Start();

                try
                {
                    Response<AnomalyResultList> response = _serviceRestClient.GetAnomaliesByAnomalyDetectionConfigurationNextPage(nextLink, detectionConfigurationGuid, queryOptions, skip, top, cancellationToken);
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
        /// <returns>An <see cref="AsyncPageable{T}"/> containing the collection of <see cref="DataAnomaly"/> instances.</returns>
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
            int? skip = options.SkipCount; // Unused?
            int? top = options.TopCount;

            async Task<Page<AnomalyIncident>> FirstPageFunc(int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorClient)}.{nameof(GetIncidentsForDetectionConfiguration)}");
                scope.Start();

                try
                {
                    Response<IncidentResultList> response = await _serviceRestClient.GetIncidentsByAnomalyDetectionConfigurationAsync(detectionConfigurationGuid, queryOptions, top, cancellationToken).ConfigureAwait(false);
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
                    Response<IncidentResultList> response = await _serviceRestClient.GetIncidentsByAnomalyDetectionConfigurationNextPageAsync(nextLink, detectionConfigurationGuid, queryOptions, top, cancellationToken).ConfigureAwait(false);
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
        /// <returns>A <see cref="Pageable{T}"/> containing the collection of <see cref="DataAnomaly"/> instances.</returns>
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
            int? skip = options.SkipCount; // Unused?
            int? top = options.TopCount;

            Page<AnomalyIncident> FirstPageFunc(int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorClient)}.{nameof(GetIncidentsForDetectionConfiguration)}");
                scope.Start();

                try
                {
                    Response<IncidentResultList> response = _serviceRestClient.GetIncidentsByAnomalyDetectionConfiguration(detectionConfigurationGuid, queryOptions, top, cancellationToken);
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
                    Response<IncidentResultList> response = _serviceRestClient.GetIncidentsByAnomalyDetectionConfigurationNextPage(nextLink, detectionConfigurationGuid, queryOptions, top, cancellationToken);
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
        /// Gets the automatic suggestions for likely root causes of an incident.
        /// </summary>
        /// <param name="detectionConfigurationId">The unique identifier of the <see cref="MetricAnomalyAlertConfiguration"/>.</param>
        /// <param name="incidentId">The unique identifier of the <see cref="AnomalyIncident"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A collection of <see cref="IncidentRootCause"/>s for the specified alert configuration and incident.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="detectionConfigurationId"/> or <paramref name="incidentId"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="detectionConfigurationId"/> or <paramref name="incidentId"/> is empty; or <paramref name="detectionConfigurationId"/> is not a valid GUID.</exception>
        public virtual async Task<Response<IReadOnlyList<IncidentRootCause>>> GetIncidentRootCausesAsync(string detectionConfigurationId, string incidentId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(detectionConfigurationId, nameof(detectionConfigurationId));
            Argument.AssertNotNullOrEmpty(incidentId, nameof(incidentId));

            Guid detectionConfigurationGuid = ClientCommon.ValidateGuid(detectionConfigurationId, nameof(detectionConfigurationId));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorClient)}.{nameof(GetIncidentRootCauses)}");
            scope.Start();

            try
            {
                Response<RootCauseList> response = await _serviceRestClient.GetRootCauseOfIncidentByAnomalyDetectionConfigurationAsync(detectionConfigurationGuid, incidentId, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value.Value, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets the automatic suggestions for likely root causes of an incident.
        /// </summary>
        /// <param name="detectionConfigurationId">The unique identifier of the <see cref="MetricAnomalyAlertConfiguration"/>.</param>
        /// <param name="incidentId">The unique identifier of the <see cref="AnomalyIncident"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A collection of <see cref="IncidentRootCause"/>s for the specified alert configuration and incident.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="detectionConfigurationId"/> or <paramref name="incidentId"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="detectionConfigurationId"/> or <paramref name="incidentId"/> is empty; or <paramref name="detectionConfigurationId"/> is not a valid GUID.</exception>
        public virtual Response<IReadOnlyList<IncidentRootCause>> GetIncidentRootCauses(string detectionConfigurationId, string incidentId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(detectionConfigurationId, nameof(detectionConfigurationId));
            Argument.AssertNotNullOrEmpty(incidentId, nameof(incidentId));

            Guid detectionConfigurationGuid = ClientCommon.ValidateGuid(detectionConfigurationId, nameof(detectionConfigurationId));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorClient)}.{nameof(GetIncidentRootCauses)}");
            scope.Start();

            try
            {
                Response<RootCauseList> response = _serviceRestClient.GetRootCauseOfIncidentByAnomalyDetectionConfiguration(detectionConfigurationGuid, incidentId, cancellationToken);
                return Response.FromValue(response.Value.Value, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
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
        public virtual AsyncPageable<string> GetValuesOfDimensionWithAnomaliesAsync(string detectionConfigurationId, string dimensionName, GetValuesOfDimensionWithAnomaliesOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(detectionConfigurationId, nameof(detectionConfigurationId));
            Argument.AssertNotNullOrEmpty(dimensionName, nameof(dimensionName));
            Argument.AssertNotNull(options, nameof(options));

            Guid detectionConfigurationGuid = ClientCommon.ValidateGuid(detectionConfigurationId, nameof(detectionConfigurationId));
            AnomalyDimensionQuery queryOptions = new AnomalyDimensionQuery(ClientCommon.NormalizeDateTimeOffset(options.StartTime), ClientCommon.NormalizeDateTimeOffset(options.EndTime), dimensionName)
            {
                DimensionFilter = options.DimensionToFilter?.Clone()
            };
            int? skip = options.SkipCount;
            int? top = options.TopCount;

            async Task<Page<string>> FirstPageFunc(int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorClient)}.{nameof(GetValuesOfDimensionWithAnomalies)}");
                scope.Start();

                try
                {
                    Response<AnomalyDimensionList> response = await _serviceRestClient.GetDimensionOfAnomaliesByAnomalyDetectionConfigurationAsync(detectionConfigurationGuid, queryOptions, skip, top, cancellationToken).ConfigureAwait(false);
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
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorClient)}.{nameof(GetValuesOfDimensionWithAnomalies)}");
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
        public virtual Pageable<string> GetValuesOfDimensionWithAnomalies(string detectionConfigurationId, string dimensionName, GetValuesOfDimensionWithAnomaliesOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(detectionConfigurationId, nameof(detectionConfigurationId));
            Argument.AssertNotNullOrEmpty(dimensionName, nameof(dimensionName));
            Argument.AssertNotNull(options, nameof(options));

            Guid detectionConfigurationGuid = ClientCommon.ValidateGuid(detectionConfigurationId, nameof(detectionConfigurationId));
            AnomalyDimensionQuery queryOptions = new AnomalyDimensionQuery(ClientCommon.NormalizeDateTimeOffset(options.StartTime), ClientCommon.NormalizeDateTimeOffset(options.EndTime), dimensionName)
            {
                DimensionFilter = options.DimensionToFilter?.Clone()
            };
            int? skip = options.SkipCount;
            int? top = options.TopCount;

            Page<string> FirstPageFunc(int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorClient)}.{nameof(GetValuesOfDimensionWithAnomalies)}");
                scope.Start();

                try
                {
                    Response<AnomalyDimensionList> response = _serviceRestClient.GetDimensionOfAnomaliesByAnomalyDetectionConfiguration(detectionConfigurationGuid, queryOptions, skip, top, cancellationToken);
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
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorClient)}.{nameof(GetValuesOfDimensionWithAnomalies)}");
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

        // TODODOCS.
        /// <summary>
        /// Query series enriched by anomaly detection.
        /// </summary>
        /// <param name="seriesKeys">The deection series keys.</param>
        /// <param name="detectionConfigurationId">The unique identifier of the <see cref="MetricAnomalyAlertConfiguration"/>.</param>
        /// <param name="startTime">Filters the result. Only data points after this point in time, in UTC, will be returned.</param>
        /// <param name="endTime">Filters the result. Only data points after this point in time, in UTC, will be returned.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A collection of <see cref="MetricEnrichedSeriesData"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="seriesKeys"/> or <paramref name="detectionConfigurationId"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="seriesKeys"/> or <paramref name="detectionConfigurationId"/> is empty; or <paramref name="detectionConfigurationId"/> is not a valid GUID.</exception>
        public virtual async Task<Response<IReadOnlyList<MetricEnrichedSeriesData>>> GetMetricEnrichedSeriesDataAsync(IEnumerable<DimensionKey> seriesKeys, string detectionConfigurationId, DateTimeOffset startTime, DateTimeOffset endTime, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(seriesKeys, nameof(seriesKeys)); // TODO: add validation for seriesKeys.Dimension?
            Argument.AssertNotNullOrEmpty(detectionConfigurationId, nameof(detectionConfigurationId));

            Guid detectionConfigurationGuid = ClientCommon.ValidateGuid(detectionConfigurationId, nameof(detectionConfigurationId));
            IEnumerable<SeriesIdentity> seriesIdentities = seriesKeys.Select(key => key.ConvertToSeriesIdentity());
            DetectionSeriesQuery queryOptions = new DetectionSeriesQuery(ClientCommon.NormalizeDateTimeOffset(startTime), ClientCommon.NormalizeDateTimeOffset(endTime), seriesIdentities);

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorClient)}.{nameof(GetMetricEnrichedSeriesData)}");
            scope.Start();

            try
            {
                Response<SeriesResultList> response = await _serviceRestClient.GetSeriesByAnomalyDetectionConfigurationAsync(detectionConfigurationGuid, queryOptions, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value.Value, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Query series enriched by anomaly detection.
        /// </summary>
        /// <param name="seriesKeys">The deection series keys.</param>
        /// <param name="detectionConfigurationId">The unique identifier of the <see cref="MetricAnomalyAlertConfiguration"/>.</param>
        /// <param name="startTime">Filters the result. Only data points after this point in time, in UTC, will be returned.</param>
        /// <param name="endTime">Filters the result. Only data points after this point in time, in UTC, will be returned.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A collection of <see cref="MetricEnrichedSeriesData"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="seriesKeys"/> or <paramref name="detectionConfigurationId"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="seriesKeys"/> or <paramref name="detectionConfigurationId"/> is empty; or <paramref name="detectionConfigurationId"/> is not a valid GUID.</exception>
        public virtual Response<IReadOnlyList<MetricEnrichedSeriesData>> GetMetricEnrichedSeriesData(IEnumerable<DimensionKey> seriesKeys, string detectionConfigurationId, DateTimeOffset startTime, DateTimeOffset endTime, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(seriesKeys, nameof(seriesKeys)); // TODO: add validation for seriesKeys.Dimension?
            Argument.AssertNotNullOrEmpty(detectionConfigurationId, nameof(detectionConfigurationId));

            Guid detectionConfigurationGuid = ClientCommon.ValidateGuid(detectionConfigurationId, nameof(detectionConfigurationId));
            IEnumerable<SeriesIdentity> seriesIdentities = seriesKeys.Select(key => key.ConvertToSeriesIdentity());
            DetectionSeriesQuery queryOptions = new DetectionSeriesQuery(ClientCommon.NormalizeDateTimeOffset(startTime), ClientCommon.NormalizeDateTimeOffset(endTime), seriesIdentities);

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorClient)}.{nameof(GetMetricEnrichedSeriesData)}");
            scope.Start();

            try
            {
                Response<SeriesResultList> response = _serviceRestClient.GetSeriesByAnomalyDetectionConfiguration(detectionConfigurationGuid, queryOptions, cancellationToken);
                return Response.FromValue(response.Value.Value, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        #endregion AnomalyDetection

        #region AlertDetection

        /// <summary>
        /// Gets a collection of items describing the alerts triggered by a given <see cref="AnomalyAlertConfiguration"/>.
        /// </summary>
        /// <param name="alertConfigurationId">The unique identifier of the <see cref="AnomalyAlertConfiguration"/>.</param>
        /// <param name="options">The set of options used to configure the request's behavior.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An <see cref="AsyncPageable{T}"/> containing the collection of <see cref="AlertResult"/>s.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="alertConfigurationId"/> or <paramref name="options"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="alertConfigurationId"/> is empty or not a valid GUID.</exception>
        public virtual AsyncPageable<AlertResult> GetAlertsAsync(string alertConfigurationId, GetAlertsOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(alertConfigurationId, nameof(alertConfigurationId));
            Argument.AssertNotNull(options, nameof(options));

            Guid alertConfigurationGuid = ClientCommon.ValidateGuid(alertConfigurationId, nameof(alertConfigurationId));
            AlertingResultQuery queryOptions = new AlertingResultQuery(ClientCommon.NormalizeDateTimeOffset(options.StartTime), ClientCommon.NormalizeDateTimeOffset(options.EndTime), options.TimeMode);
            int? skip = options.SkipCount;
            int? top = options.TopCount;

            async Task<Page<AlertResult>> FirstPageFunc(int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorClient)}.{nameof(GetAlerts)}");
                scope.Start();

                try
                {
                    Response<AlertResultList> response = await _serviceRestClient.GetAlertsByAnomalyAlertingConfigurationAsync(alertConfigurationGuid, queryOptions, skip, top, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            async Task<Page<AlertResult>> NextPageFunc(string nextLink, int? pageSizeHint)
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
        /// <returns>A <see cref="Pageable{T}"/> containing the collection of <see cref="AlertResult"/>s.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="alertConfigurationId"/> or <paramref name="options"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="alertConfigurationId"/> is empty or not a valid GUID.</exception>
        public virtual Pageable<AlertResult> GetAlerts(string alertConfigurationId, GetAlertsOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(alertConfigurationId, nameof(alertConfigurationId));
            Argument.AssertNotNull(options, nameof(options));

            Guid alertConfigurationGuid = ClientCommon.ValidateGuid(alertConfigurationId, nameof(alertConfigurationId));
            AlertingResultQuery queryOptions = new AlertingResultQuery(ClientCommon.NormalizeDateTimeOffset(options.StartTime), ClientCommon.NormalizeDateTimeOffset(options.EndTime), options.TimeMode);
            int? skip = options.SkipCount;
            int? top = options.TopCount;

            Page<AlertResult> FirstPageFunc(int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorClient)}.{nameof(GetAlerts)}");
                scope.Start();

                try
                {
                    Response<AlertResultList> response = _serviceRestClient.GetAlertsByAnomalyAlertingConfiguration(alertConfigurationGuid, queryOptions, skip, top, cancellationToken);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            Page<AlertResult> NextPageFunc(string nextLink, int? pageSizeHint)
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
        /// <returns>An <see cref="AsyncPageable{T}"/> containing the collection of <see cref="DataAnomaly"/> instances.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="alertConfigurationId"/> or <paramref name="alertId"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="alertConfigurationId"/> or <paramref name="alertId"/> is empty; or <paramref name="alertConfigurationId"/> is not a valid GUID.</exception>
        public virtual AsyncPageable<DataAnomaly> GetAnomaliesForAlertAsync(string alertConfigurationId, string alertId, GetAnomaliesForAlertOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(alertConfigurationId, nameof(alertConfigurationId));
            Argument.AssertNotNullOrEmpty(alertId, nameof(alertId));

            Guid alertConfigurationGuid = ClientCommon.ValidateGuid(alertConfigurationId, nameof(alertConfigurationId));
            int? skip = options?.SkipCount;
            int? top = options?.TopCount;

            async Task<Page<DataAnomaly>> FirstPageFunc(int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorClient)}.{nameof(GetAnomaliesForAlert)}");
                scope.Start();

                try
                {
                    Response<AnomalyResultList> response = await _serviceRestClient.GetAnomaliesFromAlertByAnomalyAlertingConfigurationAsync(alertConfigurationGuid, alertId, skip, top, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            async Task<Page<DataAnomaly>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorClient)}.{nameof(GetAnomaliesForAlert)}");
                scope.Start();

                try
                {
                    Response<AnomalyResultList> response = await _serviceRestClient.GetAnomaliesFromAlertByAnomalyAlertingConfigurationNextPageAsync(nextLink, alertConfigurationGuid, alertId, skip, top, cancellationToken).ConfigureAwait(false);
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
        /// <returns>A <see cref="Pageable{T}"/> containing the collection of <see cref="DataAnomaly"/> instances.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="alertConfigurationId"/> or <paramref name="alertId"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="alertConfigurationId"/> or <paramref name="alertId"/> is empty; or <paramref name="alertConfigurationId"/> is not a valid GUID.</exception>
        public virtual Pageable<DataAnomaly> GetAnomaliesForAlert(string alertConfigurationId, string alertId, GetAnomaliesForAlertOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(alertConfigurationId, nameof(alertConfigurationId));
            Argument.AssertNotNullOrEmpty(alertId, nameof(alertId));

            Guid alertConfigurationGuid = ClientCommon.ValidateGuid(alertConfigurationId, nameof(alertConfigurationId));
            int? skip = options?.SkipCount;
            int? top = options?.TopCount;

            Page<DataAnomaly> FirstPageFunc(int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorClient)}.{nameof(GetAnomaliesForAlert)}");
                scope.Start();

                try
                {
                    Response<AnomalyResultList> response = _serviceRestClient.GetAnomaliesFromAlertByAnomalyAlertingConfiguration(alertConfigurationGuid, alertId, skip, top, cancellationToken);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            Page<DataAnomaly> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorClient)}.{nameof(GetAnomaliesForAlert)}");
                scope.Start();

                try
                {
                    Response<AnomalyResultList> response = _serviceRestClient.GetAnomaliesFromAlertByAnomalyAlertingConfigurationNextPage(nextLink, alertConfigurationGuid, alertId, skip, top, cancellationToken);
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
            int? skip = options?.SkipCount;
            int? top = options?.TopCount;

            async Task<Page<AnomalyIncident>> FirstPageFunc(int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorClient)}.{nameof(GetIncidentsForAlert)}");
                scope.Start();

                try
                {
                    Response<IncidentResultList> response = await _serviceRestClient.GetIncidentsFromAlertByAnomalyAlertingConfigurationAsync(alertConfigurationGuid, alertId, skip, top, cancellationToken).ConfigureAwait(false);
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
                    Response<IncidentResultList> response = await _serviceRestClient.GetIncidentsFromAlertByAnomalyAlertingConfigurationNextPageAsync(nextLink, alertConfigurationGuid, alertId, skip, top, cancellationToken).ConfigureAwait(false);
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
            int? skip = options?.SkipCount;
            int? top = options?.TopCount;

            Page<AnomalyIncident> FirstPageFunc(int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorClient)}.{nameof(GetIncidentsForAlert)}");
                scope.Start();

                try
                {
                    Response<IncidentResultList> response = _serviceRestClient.GetIncidentsFromAlertByAnomalyAlertingConfiguration(alertConfigurationGuid, alertId, skip, top, cancellationToken);
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
                    Response<IncidentResultList> response = _serviceRestClient.GetIncidentsFromAlertByAnomalyAlertingConfigurationNextPage(nextLink, alertConfigurationGuid, alertId, skip, top, cancellationToken);
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

        #endregion AlertDetection
    }
}
