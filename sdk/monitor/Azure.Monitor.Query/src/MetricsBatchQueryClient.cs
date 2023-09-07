// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Net;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Monitor.Query.Models;

namespace Azure.Monitor.Query
{
    /// <summary>
    /// The <see cref="MetricsBatchQueryClient"/> allows you to query multiple Azure Monitor Metric services.
    /// </summary>
    public class MetricsBatchQueryClient
    {
        private static readonly Uri _defaultEndpoint = new Uri("https://management.azure.com");

        private readonly MetricsBatchRestClient _metricBatchClient;
        private readonly ClientDiagnostics _clientDiagnostics;

        /// <summary>
        /// Initializes a new instance of <see cref="MetricsBatchQueryClient"/>. Uses the default 'https://management.azure.com' endpoint.
        /// <code snippet="Snippet:CreateMetricsClient" language="csharp">
        /// var client = new MetricsBatchQueryClient(new DefaultAzureCredential());
        /// </code>
        /// </summary>
        /// <param name="credential">The <see cref="TokenCredential"/> instance to use for authentication.</param>
        public MetricsBatchQueryClient(TokenCredential credential) : this(credential, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of <see cref="MetricsBatchQueryClient"/>. Uses the default 'https://management.azure.com' endpoint.
        /// </summary>
        /// <param name="credential">The <see cref="TokenCredential"/> instance to use for authentication.</param>
        /// <param name="options">The <see cref="MetricsQueryClientOptions"/> instance to as client configuration.</param>
        public MetricsBatchQueryClient(TokenCredential credential, MetricsQueryClientOptions options) : this(_defaultEndpoint, credential, options)
        {
        }

        /// <summary>
        /// Initializes a new instance of <see cref="MetricsBatchQueryClient"/>.
        /// </summary>
        /// <param name="endpoint">The resource manager service endpoint to use. For example <c>https://management.azure.com/</c> for public cloud.</param>
        /// <param name="credential">The <see cref="TokenCredential"/> instance to use for authentication.</param>
        /// <param name="options">The <see cref="MetricsQueryClientOptions"/> instance to as client configuration.</param>
        public MetricsBatchQueryClient(Uri endpoint, TokenCredential credential, MetricsQueryClientOptions options = null)
        {
            Argument.AssertNotNull(credential, nameof(credential));

            options ??= new MetricsQueryClientOptions();

            _clientDiagnostics = new ClientDiagnostics(options);

            var scope = $"{endpoint.AbsoluteUri}/.default";
            Endpoint = endpoint;

            var pipeline = HttpPipelineBuilder.Build(options,
                new BearerTokenAuthenticationPolicy(credential, scope));

            _metricBatchClient = new MetricsBatchRestClient(_clientDiagnostics, pipeline, endpoint);
        }

        /// <summary>
        /// Initializes a new instance of <see cref="MetricsBatchQueryClient"/> for mocking.
        /// </summary>
        protected MetricsBatchQueryClient()
        {
        }

        /// <summary>
        /// Gets the endpoint used by the client.
        /// </summary>
        public Uri Endpoint { get; }

        /// <summary> Lists the metric values for multiple resources. </summary>
        /// <param name="subscriptionId"> The subscription identifier for the resources in this batch. </param>
        /// <param name="metricnamespace"> Metric namespace that contains the requested metric names. </param>
        /// <param name="metricnames"> The names of the metrics (comma separated) to retrieve. </param>
        /// <param name="resourceIds"> The comma separated list of resource IDs to query metrics for. </param>
        /// <param name="starttime">
        /// The start time of the query. It is a string in the format 'yyyy-MM-ddTHH:mm:ss.fffZ'. If you have specified the endtime parameter, then this parameter is required.
        /// If only starttime is specified, then endtime defaults to the current time.
        /// If no time interval is specified, the default is 1 hour.
        /// </param>
        /// <param name="endtime"> The end time of the query. It is a string in the format 'yyyy-MM-ddTHH:mm:ss.fffZ'. </param>
        /// <param name="interval">
        /// The interval (i.e. timegrain) of the query.
        /// *Examples: PT15M, PT1H, P1D*
        /// </param>
        /// <param name="aggregation">
        /// The list of aggregation types (comma separated) to retrieve.
        /// *Examples: average, minimum, maximum*
        /// </param>
        /// <param name="top">
        /// The maximum number of records to retrieve per resource ID in the request.
        /// Valid only if filter is specified.
        /// Defaults to 10.
        /// </param>
        /// <param name="orderby">
        /// The aggregation to use for sorting results and the direction of the sort.
        /// Only one order can be specified.
        /// *Examples: sum asc*
        /// </param>
        /// <param name="filter"> The filter is used to reduce the set of metric data returned.&lt;br&gt;Example:&lt;br&gt;Metric contains metadata A, B and C.&lt;br&gt;- Return all time series of C where A = a1 and B = b1 or b2&lt;br&gt;**filter=A eq ‘a1’ and B eq ‘b1’ or B eq ‘b2’ and C eq ‘*’**&lt;br&gt;- Invalid variant:&lt;br&gt;**filter=A eq ‘a1’ and B eq ‘b1’ and C eq ‘*’ or B = ‘b2’**&lt;br&gt;This is invalid because the logical or operator cannot separate two different metadata names.&lt;br&gt;- Return all time series where A = a1, B = b1 and C = c1:&lt;br&gt;**filter=A eq ‘a1’ and B eq ‘b1’ and C eq ‘c1’**&lt;br&gt;- Return all time series where A = a1&lt;br&gt;**filter=A eq ‘a1’ and B eq ‘*’ and C eq ‘*’**. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="metricnamespace"/>, <paramref name="metricnames"/> or <paramref name="resourceIds"/> is null. </exception>
        public virtual Response<MetricResultsResponse> Batch(string subscriptionId, string metricnamespace, IEnumerable<string> metricnames, ResourceIdList resourceIds, string starttime = null, string endtime = null, TimeSpan? interval = null, string aggregation = null, int? top = null, string orderby = null, string filter = null, CancellationToken cancellationToken = default)
        {
            return _metricBatchClient.Batch(subscriptionId, metricnamespace, metricnames, resourceIds, starttime, endtime, interval, aggregation, top, orderby, filter, cancellationToken);
        }

        /// <summary> Lists the metric values for multiple resources. </summary>
        /// <param name="subscriptionId"> The subscription identifier for the resources in this batch. </param>
        /// <param name="metricnamespace"> Metric namespace that contains the requested metric names. </param>
        /// <param name="metricnames"> The names of the metrics (comma separated) to retrieve. </param>
        /// <param name="resourceIds"> The comma separated list of resource IDs to query metrics for. </param>
        /// <param name="starttime">
        /// The start time of the query. It is a string in the format 'yyyy-MM-ddTHH:mm:ss.fffZ'. If you have specified the endtime parameter, then this parameter is required.
        /// If only starttime is specified, then endtime defaults to the current time.
        /// If no time interval is specified, the default is 1 hour.
        /// </param>
        /// <param name="endtime"> The end time of the query. It is a string in the format 'yyyy-MM-ddTHH:mm:ss.fffZ'. </param>
        /// <param name="interval">
        /// The interval (i.e. timegrain) of the query.
        /// *Examples: PT15M, PT1H, P1D*
        /// </param>
        /// <param name="aggregation">
        /// The list of aggregation types (comma separated) to retrieve.
        /// *Examples: average, minimum, maximum*
        /// </param>
        /// <param name="top">
        /// The maximum number of records to retrieve per resource ID in the request.
        /// Valid only if filter is specified.
        /// Defaults to 10.
        /// </param>
        /// <param name="orderby">
        /// The aggregation to use for sorting results and the direction of the sort.
        /// Only one order can be specified.
        /// *Examples: sum asc*
        /// </param>
        /// <param name="filter"> The filter is used to reduce the set of metric data returned.&lt;br&gt;Example:&lt;br&gt;Metric contains metadata A, B and C.&lt;br&gt;- Return all time series of C where A = a1 and B = b1 or b2&lt;br&gt;**filter=A eq ‘a1’ and B eq ‘b1’ or B eq ‘b2’ and C eq ‘*’**&lt;br&gt;- Invalid variant:&lt;br&gt;**filter=A eq ‘a1’ and B eq ‘b1’ and C eq ‘*’ or B = ‘b2’**&lt;br&gt;This is invalid because the logical or operator cannot separate two different metadata names.&lt;br&gt;- Return all time series where A = a1, B = b1 and C = c1:&lt;br&gt;**filter=A eq ‘a1’ and B eq ‘b1’ and C eq ‘c1’**&lt;br&gt;- Return all time series where A = a1&lt;br&gt;**filter=A eq ‘a1’ and B eq ‘*’ and C eq ‘*’**. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="metricnamespace"/>, <paramref name="metricnames"/> or <paramref name="resourceIds"/> is null. </exception>
        public virtual async Task<Response<MetricResultsResponse>> BatchAsync(string subscriptionId, string metricnamespace, IEnumerable<string> metricnames, ResourceIdList resourceIds, string starttime = null, string endtime = null, TimeSpan? interval = null, string aggregation = null, int? top = null, string orderby = null, string filter = null, CancellationToken cancellationToken = default)
        {
            return await _metricBatchClient.BatchAsync(subscriptionId, metricnamespace, metricnames, resourceIds, starttime, endtime, interval, aggregation, top, orderby, filter, cancellationToken).ConfigureAwait(false);
        }
    }
}
