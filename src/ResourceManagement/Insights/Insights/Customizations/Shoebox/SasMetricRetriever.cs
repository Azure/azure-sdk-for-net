//
// Copyright (c) Microsoft.  All rights reserved.
//

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Hyak.Common;
using Microsoft.Azure.Insights.Models;
using Microsoft.WindowsAzure.Storage.Table;

namespace Microsoft.Azure.Insights.Customizations.Shoebox
{
    /// <summary>
    /// Base metric retriever for SAS-based metrics
    /// </summary>
    internal abstract class SasMetricRetriever : IMetricRetriever
    {
        public async Task<MetricListResponse> GetMetricsAsync(string resourceId, string filterString, IEnumerable<MetricDefinition> definitions, string invocationId)
        {
            MetricFilter filter = MetricFilterExpressionParser.Parse(filterString);

            // Group definitions by location so we can make one request to each location
            Dictionary<MetricAvailability, MetricFilter> groups =
                definitions.GroupBy(d => d.MetricAvailabilities.First(a => a.TimeGrain == filter.TimeGrain),
                    new SasMetricRetriever.AvailabilityComparer()).ToDictionary(g => g.Key, g => new MetricFilter()
                    {
                        TimeGrain = filter.TimeGrain,
                        StartTime = filter.StartTime,
                        EndTime = filter.EndTime,
                        DimensionFilters = g.Select(d =>
                            filter.DimensionFilters.FirstOrDefault(df => string.Equals(df.Name, d.Name.Value, StringComparison.OrdinalIgnoreCase))
                            ?? new MetricDimension() {Name = d.Name.Value})
                    });

            // Verify all groups represent shoebox metrics
            if (groups.Any(g => g.Key.Location == null))
            {
                throw new ArgumentException("All definitions provided to ShoeboxMetricRetriever must include location information.", "definitions");
            }

            // Get Metrics from each location (group)
            IEnumerable<Task<MetricListResponse>> locationTasks = groups.Select(g => this.GetMetricsInternalAsync(g.Value, g.Key.Location, invocationId));

            // Aggregate metrics from all groups
            MetricListResponse[] results = (await Task.Factory.ContinueWhenAll(locationTasks.ToArray(), tasks => tasks.Select(t => t.Result))).ToArray();
            IEnumerable<Metric> metrics = results.Aggregate<MetricListResponse, IEnumerable<Metric>>(
                new List<Metric>(), (list, response) => list.Union(response.MetricCollection.Value));

            // Return aggregated results (the MetricOperations class will fill in additional info from the MetricDefinitions)
            return new MetricListResponse()
            {
                RequestId = invocationId,
                StatusCode = HttpStatusCode.OK,
                MetricCollection = new MetricCollection()
                {
                    Value = metrics.ToList()
                }
            };
        }

        /// <summary>
        /// Retrieves the metric values from the shoebox
        /// </summary>
        /// <param name="filter">The $filter query string</param>
        /// <param name="location">The MetricLocation object</param>
        /// <param name="invocationId">The invocation id</param>
        /// <returns>The MetricValueListResponse</returns>
        // Note: Does not populate Metric fields unrelated to query (i.e. "display name", resourceUri, and properties)
        internal MetricListResponse GetMetricsInternal(MetricFilter filter, MetricLocation location, string invocationId)
        {
            return GetMetricsInternalAsync(filter, location, invocationId).Result;
        }

        /// <summary>
        /// Retrieves the metric values from the shoebox
        /// </summary>
        /// <param name="filter">The $filter query string</param>
        /// <param name="location">The MetricLocation object</param>
        /// <param name="invocationId">The invocation id</param>
        /// <returns>The MetricValueListResponse</returns>
        // Note: Does not populate Metric fields unrelated to query (i.e. "display name", resourceUri, and properties)
        internal abstract Task<MetricListResponse> GetMetricsInternalAsync(MetricFilter filter, MetricLocation location, string invocationId);

        protected static async Task<IEnumerable<TEntity>> GetEntitiesAsync<TEntity>(CloudTable table, TableQuery<TEntity> query, string invocationId, int maxBatchSize = 0) where TEntity : ITableEntity, new()
        {
            string traceRequestId;
            List<TEntity> results = new List<TEntity>();

            try
            {
                // If 0 or less then there is no max value
                maxBatchSize = maxBatchSize <= 0 ? int.MaxValue : maxBatchSize;
                TableContinuationToken continuationToken = null;
                do
                {
                    continuationToken = null;
                    TableQuerySegment<TEntity> resultSegment = null;

                    traceRequestId = Guid.NewGuid().ToString();

                    TableOperationContextLogger operationContextLogger = new TableOperationContextLogger(
                        accountName: table.ServiceClient.Credentials.AccountName,
                        resourceUri: table.Name,
                        operationName: "ExecuteQuerySegmentedAsync",
                        requestId: invocationId);

                    resultSegment = await table.ExecuteQuerySegmentedAsync<TEntity>(query, continuationToken, requestOptions: new TableRequestOptions(), operationContext: operationContextLogger.OperationContext);

                    if (resultSegment != null)
                    {
                        var count = resultSegment.Results == null ? 0 : resultSegment.Results.Count;
                        var recordsToInclude = Math.Min(maxBatchSize - results.Count, count);

                        if (resultSegment.Results != null)
                        {
                            results.AddRange(resultSegment.Results.Take(recordsToInclude));
                        }

                        continuationToken = resultSegment.ContinuationToken;
                    }
                }
                while (continuationToken != null && results.Count < maxBatchSize);
            }
            catch (Exception ex)
            {
                TracingAdapter.Error(invocationId, ex);
                throw ex.GetBaseException();
            }

            return results;
        }

        protected static MetricValue GetMetricValueFromEntity(DynamicTableEntity entity, string metricName)
        {
            // Get the key (metric name) from the entity properties dictionary to retrieve the correctly-cased key since the key lookup is case sensitive
            string key = entity.Properties.Keys.FirstOrDefault(k => string.Equals(k, metricName, StringComparison.OrdinalIgnoreCase));

            // metric name does not exist in keys
            if (key == null)
            {
                throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "Unable to retrieve metric {0}. Metric name does not exist", metricName), "metricName");
            }

            MetricValue value = new MetricValue();
            DateTime created;

            if (!DateTime.TryParseExact(entity.PartitionKey, "yyyyMMddTHHmm", CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal, out created))
            {
                // trace failure as best possible
                TracingAdapter.Information("Failed to parse partition key (date) {0}", entity.PartitionKey);
            }

            // dateTime is not parsing and correctly setting the kind so we force it here
            value.Timestamp = DateTime.SpecifyKind(created, DateTimeKind.Utc);
            value.Count = 1;

            // convert value to double
            switch (entity.Properties[key].PropertyType)
            {
                case EdmType.Double:
                    SetAllMetricValues(value, entity.Properties[key].DoubleValue ?? 0);
                    break;
                case EdmType.Int32:
                    SetAllMetricValues(value, entity.Properties[key].Int32Value ?? 0);
                    break;
                case EdmType.Int64:
                    SetAllMetricValues(value, entity.Properties[key].Int64Value ?? 0);
                    break;
                default:
                    throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, "Table value for column {0} is not a numeric type", metricName));
            }

            return value;
        }

        private static void SetAllMetricValues(MetricValue metric, double value)
        {
            metric.Average = value;
            metric.Last = value;
            metric.Maximum = value;
            metric.Minimum = value;
            metric.Total = value;
        }

        protected static IEnumerable<T> CollectResults<T>(IEnumerable<Task<IEnumerable<T>>> tasks)
        {
            return tasks.Aggregate((IEnumerable<T>)new T[0], (list, t) => list.Union(t.Result));
        }

        protected static async Task<IEnumerable<T>> CollectResultsAsync<T>(IEnumerable<Task<IEnumerable<T>>> tasks)
        {
            return await Task.Factory.ContinueWhenAll(tasks.ToArray(), (t) => CollectResults(t)).ConfigureAwait(false);
        }

        // Creates a TableQuery object which filters entities to a particular partition key and the given row key range
        protected static TableQuery GenerateMetricQuery(string partitionKey, string startRowKey, string endRowKey)
        {
            string partitionFilter = TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, partitionKey);
            string rowStartFilter = TableQuery.GenerateFilterCondition("RowKey", QueryComparisons.GreaterThanOrEqual, startRowKey);
            string rowEndFilter = TableQuery.GenerateFilterCondition("RowKey", QueryComparisons.LessThan, endRowKey);

            return new TableQuery()
            {
                FilterString = TableQuery.CombineFilters(partitionFilter, TableOperators.And, TableQuery.CombineFilters(rowStartFilter, TableOperators.And, rowEndFilter))
            };
        }

        private class AvailabilityComparer : IEqualityComparer<MetricAvailability>
        {
            public bool Equals(MetricAvailability x, MetricAvailability y)
            {
                if (x.Location == null && y.Location == null)
                {
                    return true;
                }

                if (x.Location == null || y.Location == null)
                {
                    return false;
                }

                return x.Location.TableEndpoint == y.Location.TableEndpoint;
            }

            public int GetHashCode(MetricAvailability obj)
            {
                return obj.Location == null ? 0 : obj.Location.TableEndpoint.GetHashCode();
            }
        }
    }
}
