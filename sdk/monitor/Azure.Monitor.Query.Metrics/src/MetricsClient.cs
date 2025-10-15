// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Monitor.Query.Metrics.Models;

namespace Azure.Monitor.Query.Metrics
{
    public partial class MetricsClient
    {
        /// <summary>
        /// Gets the endpoint used by the client.
        /// </summary>
        public Uri Endpoint => _endpoint;

        /// <summary>
        /// Returns all the Azure Monitor metrics requested for the batch of resources.
        /// </summary>
        /// <param name="resourceIds">The resource URIs for which the metrics are requested.</param>
        /// <param name="metricNames">The names of the metrics to query.</param>
        /// <param name="metricNamespace">The namespace of the metrics to query.</param>
        /// <param name="options">The <see cref="MetricsQueryResourcesOptions"/> to configure the query.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> to use.</param>
        /// <returns>A time series metrics result for the requested metric names.</returns>
        public virtual Response<MetricsQueryResourcesResult> QueryResources(IEnumerable<ResourceIdentifier> resourceIds, IEnumerable<string> metricNames, string metricNamespace, MetricsQueryResourcesOptions options = null, CancellationToken cancellationToken = default)
        {
            if (!resourceIds.Any() || !metricNames.Any())
            {
                throw new ArgumentException($"{nameof(resourceIds)} or {nameof(metricNames)} cannot be empty");
            }
            if (metricNamespace == null)
            {
                throw new ArgumentNullException(nameof(metricNamespace));
            }

            var subscriptionId = GetSubscriptionId(resourceIds.FirstOrDefault());

            string filter = null;
            string granularity = null;
            string aggregations = null;
            string startTime = null;
            int? top = null;
            string orderBy = null;
            string endTime = null;
            IEnumerable<string> rollUpBy = null;

            ResourceIdList resourceIdList = new ResourceIdList(resourceIds.ToList(), additionalBinaryDataProperties: null);

            if (options != null)
            {
                if (options.TimeRange.HasValue)
                {
                    startTime = options.TimeRange.Value.Start.ToIsoString();
                    endTime = options.TimeRange.Value.End.ToIsoString();
                }
                else
                {
                    // Use values from Start and End TimeRange properties if they are set
                    if (options.StartTime.HasValue)
                    {
                        startTime = options.StartTime.Value.ToIsoString();
                    }
                    if (options.EndTime.HasValue)
                    {
                        endTime = options.EndTime.Value.ToIsoString();
                    }
                }

                aggregations = MetricsClientExtensions.CommaJoin(options.Aggregations);
                granularity = options.Granularity == null ? null : TypeFormatters.ConvertToString(options.Granularity, "P");
                top = options.Size;
                orderBy = options.OrderBy;
                filter = options.Filter;
                rollUpBy = options.RollUpBy;
            }

            return QueryResources(subscriptionId, metricNamespace, metricNames, resourceIdList, startTime, endTime, granularity, aggregations, top, orderBy, filter, rollUpBy != null ? MetricsClientExtensions.CommaJoin(rollUpBy) : null, cancellationToken);
        }

        /// <summary>
        /// Returns all the Azure Monitor metrics requested for the batch of resources.
        /// </summary>
        /// <param name="resourceIds">The resource URIs for which the metrics are requested.</param>
        /// <param name="metricNames">The names of the metrics to query.</param>
        /// <param name="metricNamespace">The namespace of the metrics to query.</param>
        /// <param name="options">The <see cref="MetricsQueryResourcesOptions"/> to configure the query.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> to use.</param>
        /// <returns>A time series metrics result for the requested metric names.</returns>
        public virtual async Task<Response<MetricsQueryResourcesResult>> QueryResourcesAsync(IEnumerable<ResourceIdentifier> resourceIds, IEnumerable<string> metricNames, string metricNamespace, MetricsQueryResourcesOptions options = null, CancellationToken cancellationToken = default)
        {
            if (!resourceIds.Any() || !metricNames.Any())
            {
                throw new ArgumentException($"{nameof(resourceIds)} or {nameof(metricNames)} cannot be empty");
            }
            if (metricNamespace == null)
            {
                throw new ArgumentNullException(nameof(metricNamespace));
            }

            var subscriptionId = GetSubscriptionId(resourceIds.FirstOrDefault());

            string filter = null;
            string granularity = null;
            string aggregations = null;
            string startTime = null;
            int? top = null;
            string orderBy = null;
            string endTime = null;
            IEnumerable<string> rollUpBy = null;

            ResourceIdList resourceIdList = new ResourceIdList(resourceIds.ToList(), additionalBinaryDataProperties: null);

            if (options != null)
            {
                if (options.TimeRange.HasValue)
                {
                    startTime = options.TimeRange.Value.Start.ToIsoString();
                    endTime = options.TimeRange.Value.End.ToIsoString();
                }
                else
                {
                    // Use values from Start and End TimeRange properties if they are set
                    if (options.StartTime.HasValue)
                    {
                        startTime = options.StartTime.Value.ToIsoString();
                    }
                    if (options.EndTime.HasValue)
                    {
                        endTime = options.EndTime.Value.ToIsoString();
                    }
                }

                aggregations = MetricsClientExtensions.CommaJoin(options.Aggregations);
                granularity = options.Granularity == null ? null : TypeFormatters.ConvertToString(options.Granularity, "P");
                top = options.Size;
                orderBy = options.OrderBy;
                filter = options.Filter;
                rollUpBy = options.RollUpBy;
            }

            return await QueryResourcesAsync(subscriptionId, metricNamespace, metricNames, resourceIdList, startTime, endTime, granularity, aggregations, top, orderBy, filter, rollUpBy != null ? MetricsClientExtensions.CommaJoin(rollUpBy) : null, cancellationToken).ConfigureAwait(false);
        }
        private Guid GetSubscriptionId(string resourceId)
        {
            int startIndex = resourceId.IndexOf("subscriptions/") + 14;
            return Guid.Parse(resourceId.Substring(startIndex, resourceId.IndexOf("/", startIndex) - startIndex));
        }
    }
}
