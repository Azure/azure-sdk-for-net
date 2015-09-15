//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hyak.Common;
using Microsoft.Azure.Insights.Models;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Table;
using System.Diagnostics;

namespace Microsoft.Azure.Insights
{
    /// <summary>
    /// Thick client component for retrieving shoebox metrics
    /// </summary>
    internal static class ShoeboxClient
    {
        private static readonly string[] doubleUnderscore = { "__" };
        internal static int MaxParallelRequestsByName = 4;

        /// <summary>
        /// Retrieves the metric values from the shoebox
        /// </summary>
        /// <param name="filter">The $filter query string</param>
        /// <param name="location">The MetricLocation object</param>
        /// <param name="invocationId">The invocation id</param>
        /// <returns>The MetricValueListResponse</returns>
        // Note: Does not populate Metric fields unrelated to query (i.e. "display name", resourceUri, and properties)
        internal static MetricListResponse GetMetricsInternal(MetricFilter filter, MetricLocation location, string invocationId)
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
        internal static async Task<MetricListResponse> GetMetricsInternalAsync(MetricFilter filter, MetricLocation location, string invocationId)
        {
            // TODO [davmc]: ShoeboxClient doesn't support dimensions
            if (filter.DimensionFilters != null && filter.DimensionFilters.Any(df => df.Dimensions != null))
            {
                if (TracingAdapter.IsEnabled)
                {
                    TracingAdapter.Information("InvocationId: {0}. ShoeboxClient encountered metrics with dimensions specified. These will be ignored.", invocationId);
                }

                // Remove dimensions from filter (The MetricFilter class has strict mutation rules used in parsing so the best way to modify it is to create a new one)
                filter = new MetricFilter()
                {
                    TimeGrain = filter.TimeGrain,
                    StartTime = filter.StartTime,
                    EndTime = filter.EndTime,
                    DimensionFilters = filter.DimensionFilters.Select(df => new MetricDimension()
                    {
                        Name = df.Name
                    })
                };
            }

            // If metrics are requested by name, get those metrics specifically, unless too many are requested.
            // If no names or too many names are provided, get all metrics and filter if necessary.
            return new MetricListResponse()
            {
                MetricCollection = await (filter.DimensionFilters == null || filter.DimensionFilters.Count() > MaxParallelRequestsByName
                    ? GetMetricsByTimestampAsync(filter, location, invocationId)
                    : GetMetricsByNameAsync(filter, location, invocationId)).ConfigureAwait(false)
            };
        }

        // Generates queries for each metric by name (name-timestamp rowKey format) at collects the results
        // Note: Does not populate Metric fields unrelated to query (i.e. "display name", resourceUri, and properties)
        private static async Task<MetricCollection> GetMetricsByNameAsync(MetricFilter filter, MetricLocation location, string invocationId)
        {
            // Create a query for each metric name
            Dictionary<string, TableQuery> queries = GenerateMetricNameQueries(filter.DimensionFilters.Select(df => df.Name), location.PartitionKey,
                filter.StartTime, filter.EndTime);

            // Create a task for each query. Each query will correspond to one metric
            IEnumerable<Task<Metric>> queryTasks = queries.Select(async kvp => await GetMetricByNameAsync(kvp.Key, kvp.Value, filter, location, invocationId).ConfigureAwait(false));

            // Execute the queries in parallel and collect the results
            IList<Metric> metrics = await Task.Factory.ContinueWhenAll(queryTasks.ToArray(), tasks => new List<Metric>(tasks.Select(t => t.Result))).ConfigureAwait(false);

            // Wrap metrics in MetricCollectionObject
            return new MetricCollection()
            {
                Value = metrics
            };
        }

        // Generates queries for all metrics by timestamp (timestamp-name rowKey format) and filters the results to the requested metrics (if any)
        // Note: Does not populate Metric fields unrelated to query (i.e. "display name", resourceUri, and properties)
        private static async Task<MetricCollection> GetMetricsByTimestampAsync(MetricFilter filter, MetricLocation location, string invocationId)
        {
            // Find all the tables that fall partially or fully within the timerange
            IEnumerable<CloudTable> tables = GetNdayTables(filter, location);

            // Generate a query for the partition key and time range
            TableQuery query = GenerateMetricTimestampQuery(location.PartitionKey, filter.StartTime, filter.EndTime);

            // Get all the entities for the query
            IEnumerable<DynamicTableEntity> entities = await GetEntitiesAsync(tables, query, invocationId).ConfigureAwait(false);

            ICollection<string> dimensionFilterNames = null;
            if (filter.DimensionFilters != null)
            {
                dimensionFilterNames = new HashSet<string>(filter.DimensionFilters.Select(df => ShoeboxHelper.TrimAndEscapeKey(df.Name)));
            }

            var metricWraps = new Dictionary<string, MetricWrap>();
            var metrics = new List<Metric>();

            // Iterate over the instances to do conversion and aggregation when needed. 
            foreach (var entity in entities)
            {
                string encodedName = GetMetricNameFromRowKeyByTimestampByMetricName(entity.RowKey);

                // When there is filter, skip entities not included in the filter.
                if (dimensionFilterNames != null && !dimensionFilterNames.Contains(encodedName, StringComparer.OrdinalIgnoreCase))
                {
                    continue;
                }

                MetricWrap metricWrap;
                if (!metricWraps.TryGetValue(encodedName, out metricWrap))
                {
                    metricWrap = new MetricWrap
                    {
                        Metric = new Metric()
                        {
                            Name = new LocalizableString()
                            {
                                Value = encodedName
                            },
                            StartTime = filter.StartTime,
                            EndTime = filter.EndTime,
                            TimeGrain = filter.TimeGrain,
                            MetricValues = new List<MetricValue>()
                        },
                        InstanceMetrics = new List<MetricValue>(),
                        GlobalMetrics = new List<DynamicTableEntity>()
                    };
                        
                    metricWraps[encodedName] = metricWrap;
                    metrics.Add(metricWrap.Metric);
                }

                // Skip aggregated entities
                if (!IsInstanceMetric(entity.RowKey))
                {
                    // We ignore the aggergated metrics if there are instance metrics.
                    if (metricWrap.InstanceMetrics.Count == 0)
                    {
                        metricWrap.GlobalMetrics.Add(entity);
                    }
                    
                    continue;
                }

                MetricValue lastMetricValue = metricWrap.InstanceMetrics.LastOrDefault();
                if (lastMetricValue == null)
                {
                    metricWrap.InstanceMetrics.Add(ResolveMetricEntity(entity));
                }
                else
                {
                    if (lastMetricValue.Timestamp.Ticks == GetTimestampFromIndexTimestampMetricName(entity))
                    {
                        Aggregate(lastMetricValue, entity);
                    }
                    else
                    {
                        metricWrap.InstanceMetrics.Add(ResolveMetricEntity(entity));
                    }
                }
            }

            foreach (var metricWrap in metricWraps.Values)
            {
                // Decide whether to return the aggregation of the instance metrics on the fly or the final value in the storage account
                // If there are instance metrics, the aggregation on the fly is used.
                Metric metric = metricWrap.Metric;
                metric.Name.Value = FindMetricName(metric.Name.Value, dimensionFilterNames);
                if (metricWrap.InstanceMetrics.Count > 0)
                {
                    foreach (var metricValue in metricWrap.InstanceMetrics)
                    {
                        metricValue.Average = metricValue.Total / metricValue.Count;
                    }

                    metric.MetricValues = metricWrap.InstanceMetrics;
                }
                else
                {
                    metric.MetricValues = metricWrap.GlobalMetrics.Select(me => ResolveMetricEntity(me)).ToList();
                }
            }

            return new MetricCollection()
            {
                Value = metrics
            };
        }

        private static long GetTimestampFromIndexTimestampMetricName(DynamicTableEntity entity)
        {
            int index = entity.RowKey.IndexOf('_');
            long reverseTimestamp = long.Parse(entity.RowKey.Substring(0, index));

            return DateTime.MaxValue.Ticks - reverseTimestamp;
        }

        private static long GetTimestampFromIndexMetricNameTimestamp(DynamicTableEntity entity)
        {
            string[] splitByUnderscore = entity.RowKey.Split(doubleUnderscore, StringSplitOptions.RemoveEmptyEntries);
            long reverseTimestamp = long.Parse(splitByUnderscore[1]);

            return DateTime.MaxValue.Ticks - reverseTimestamp;
        }

        private static void Aggregate(MetricValue lastMetricValue, DynamicTableEntity e)
        {
            // Average will be calculated at the end
            lastMetricValue.Count += e.Properties["Count"].Int32Value;

            // It is impossible to calculate Last
            lastMetricValue.Last = null;

            double? max = e.Properties["Maximum"].DoubleValue;
            if (lastMetricValue.Maximum < max)
            {
                lastMetricValue.Maximum = max;
            }

            double? min = e.Properties["Minimum"].DoubleValue;
            if (lastMetricValue.Minimum > min)
            {
                lastMetricValue.Minimum = min;
            }

            lastMetricValue.Total += e.Properties["Total"].DoubleValue;
        }

        // Instance metrics have the rowKeys in the format Timestamp__EncodedMetricName__InstanceId. The way to detec is counting the double
        // underscores.
        private static bool IsInstanceMetric(string rowKey)
        {
            return rowKey.Split(doubleUnderscore, StringSplitOptions.None).Length > 2;
        }

        private static string GetMetricNameFromRowKeyByTimestampByMetricName(string rowKey)
        {
            if (string.IsNullOrWhiteSpace(rowKey))
            {
                return null;
            }

            string[] split = rowKey.Split(doubleUnderscore, StringSplitOptions.None);

            if (split.Length < 2)
            {
                return null;
            }

            return split[1];
        }

        // This method tries to figure out the original name of the metric from the encoded name
        // Note: Will unescape the name if it is not in the list, but it will not be able to unhash it if it was hashed
        private static string FindMetricName(string encodedName, IEnumerable<string> names)
        {
            return names.FirstOrDefault(n => string.Equals(ShoeboxHelper.TrimAndEscapeKey(n), encodedName, StringComparison.OrdinalIgnoreCase)) ??
                ShoeboxHelper.UnEscapeKey(encodedName);
        }

        // Gets the named metric by calling the provided query on each table that overlaps the given time range
        // Note: Does not populate Metric fields unrelated to query (i.e. "display name", resourceUri, and properties)
        private static async Task<Metric> GetMetricByNameAsync(string name, TableQuery query, MetricFilter filter, MetricLocation location, string invocationId)
        {
            Metric metric = new Metric()
            {
                Name = new LocalizableString()
                {
                    Value = name
                },
                StartTime = filter.StartTime,
                EndTime = filter.EndTime,
                TimeGrain = filter.TimeGrain,
                MetricValues = new List<MetricValue>()
            };

            var instanceMetrics = new List<MetricValue>();
            var globalMetrics = new List<DynamicTableEntity>();

            // The GetEnititesAsync function provides one task that will call all the queries in parallel
            var entities = await GetEntitiesAsync(GetNdayTables(filter, location), query, invocationId).ConfigureAwait(false);

            // Iterate over the instances to do conversion and aggregation when needed
            foreach (var entity in entities)
            {
                // Skip aggregated entities
                if (!IsInstanceMetric(entity.RowKey))
                {
                    // We ignore the aggergated metrics if there are instance metrics.
                    if (instanceMetrics.Count == 0)
                    {
                        globalMetrics.Add(entity);
                    }

                    continue;
                }

                MetricValue lastMetricValue = instanceMetrics.LastOrDefault();
                if (lastMetricValue == null)
                {
                    instanceMetrics.Add(ResolveMetricEntity(entity));
                }
                else
                {
                    if (lastMetricValue.Timestamp.Ticks == GetTimestampFromIndexMetricNameTimestamp(entity))
                    {
                        Aggregate(lastMetricValue, entity);
                    }
                    else
                    {
                        instanceMetrics.Add(ResolveMetricEntity(entity));
                    }
                }
            }

            if (instanceMetrics.Count > 0)
            {
                foreach (var metricValue in instanceMetrics)
                {
                    metricValue.Average = metricValue.Total / metricValue.Count;
                }

                metric.MetricValues = instanceMetrics;
            }
            else
            {
                metric.MetricValues = globalMetrics.Select(me => ResolveMetricEntity(me)).ToList();
            }

            return metric;
        }

        // Executes a table query, following continuation tokens and returns the resulting entities
        private static async Task<IEnumerable<DynamicTableEntity>> GetEntitiesAsync(CloudTable table, TableQuery query, string invocationId)
        {
            List<DynamicTableEntity> results = new List<DynamicTableEntity>();

            TableOperationContextLogger operationContextLogger = new TableOperationContextLogger(
                accountName: table.ServiceClient.Credentials.AccountName, 
                resourceUri: table.Name, 
                operationName: "ExecuteQuerySegmentedAsync", 
                requestId: invocationId);

            TableQuerySegment<DynamicTableEntity> resultSegment;
            TableContinuationToken continuationToken = null;

            // Table query returns a max of 1000 entities at a time, so continuation tokens must be followed
            do
            {
                resultSegment = await table.ExecuteQuerySegmentedAsync(query, continuationToken, requestOptions: new TableRequestOptions(), operationContext: operationContextLogger.OperationContext).ConfigureAwait(false);
                results.AddRange(resultSegment.Results);
                continuationToken = resultSegment.ContinuationToken;
            }
            while (continuationToken != null);

            return results;
        }

        // Gets the entities from running a query on multiple tables and collects the results
        private static async Task<IEnumerable<DynamicTableEntity>> GetEntitiesAsync(IEnumerable<CloudTable> tables, TableQuery query, string invocationId)
        {
            // Return empty collection for no tables
            if (!tables.Any())
            {
                return new DynamicTableEntity[0];
            }

            // Create a task for each table
            IEnumerable<Task<IEnumerable<DynamicTableEntity>>> queryTasks = tables.Select(table => GetEntitiesAsync(table, query, invocationId));

            // Execute tasks and collect results
            return await Task.Factory.ContinueWhenAll(queryTasks.ToArray(), tasks => CollectResults(tasks)).ConfigureAwait(false);
        }

        private static IEnumerable<T> CollectResults<T>(IEnumerable<Task<IEnumerable<T>>> tasks)
        {
            return tasks.Aggregate((IEnumerable<T>) new T[0], (list, t) => list.Union(t.Result));
        }

        private static IEnumerable<CloudTable> GetNdayTables(MetricFilter filter, MetricLocation location)
        {
            // Get the tables that overlap the timerange and create a table reference for each table
            return location.TableInfo
                .Where(info => info.StartTime < filter.EndTime && info.EndTime > filter.StartTime)
                .Select(info => new CloudTableClient(new Uri(location.TableEndpoint), new StorageCredentials(info.SasToken)).GetTableReference(info.TableName));
        }

        // Creates a TableQuery for each named metric and returns a dictionary mapping each name to its query
        // Note: The overall start and end times are used in each query since this reduces processing and the query will still work the same on each Nday table
        private static Dictionary<string, TableQuery> GenerateMetricNameQueries(IEnumerable<string> names, string partitionKey, DateTime startTime, DateTime endTime)
        {
            return names.ToDictionary(name => ShoeboxHelper.TrimAndEscapeKey(name) + "__").ToDictionary(kvp => kvp.Value, kvp =>
                GenerateMetricQuery(
                partitionKey,
                kvp.Key + (DateTime.MaxValue.Ticks - endTime.Ticks).ToString("D19"),
                kvp.Key + (DateTime.MaxValue.Ticks - startTime.Ticks).ToString("D19")));
        }

        // Creates a TableQuery for getting metrics by timestamp
        private static TableQuery GenerateMetricTimestampQuery(string partitionKey, DateTime startTime, DateTime endTime)
        {
            return GenerateMetricQuery(
                partitionKey,
                (DateTime.MaxValue.Ticks - endTime.Ticks + 1).ToString("D19") + "__",
                (DateTime.MaxValue.Ticks - startTime.Ticks).ToString("D19") + "__");
        }

        // Creates a TableQuery object which filters entities to a particular partition key and the given row key range
        private static TableQuery GenerateMetricQuery(string partitionKey, string startRowKey, string endRowKey)
        {
            string partitionFilter = TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, partitionKey);
            string rowStartFilter = TableQuery.GenerateFilterCondition("RowKey", QueryComparisons.GreaterThanOrEqual, startRowKey);
            string rowEndFilter = TableQuery.GenerateFilterCondition("RowKey", QueryComparisons.LessThan, endRowKey);
            
            return new TableQuery()
            {
                FilterString = TableQuery.CombineFilters(partitionFilter, TableOperators.And, TableQuery.CombineFilters(rowStartFilter, TableOperators.And, rowEndFilter))
            };
        }

        // Converts a TableEntity to a MetricValue object
        // TODO: this needs to be made more robust to handle types properly and do conversions as needed
        private static MetricValue ResolveMetricEntity(DynamicTableEntity entity)
        {
            Dictionary<string, string> otherProperties = new Dictionary<string, string>();
            MetricValue metricValue = new MetricValue();

            EntityProperty timestamp = entity["TIMESTAMP"];
            switch (timestamp.PropertyType)
            {
                case EdmType.DateTime:
                    metricValue.Timestamp = timestamp.DateTime ?? entity.Timestamp.UtcDateTime;
                    break;
                case EdmType.String:
                    DateTime value;
                    if (DateTime.TryParse(timestamp.StringValue, out value))
                    {
                        metricValue.Timestamp = value;
                    }

                    break;
                default:
                    metricValue.Timestamp = entity.Timestamp.UtcDateTime;
                    break;
            }

            foreach (string key in entity.Properties.Keys)
            {
                switch (key)
                {
                    case "Average":
                        metricValue.Average = entity[key].DoubleValue;
                        break;
                    case "Minimum":
                        metricValue.Minimum = entity[key].DoubleValue;
                        break;
                    case "Maximum":
                        metricValue.Maximum = entity[key].DoubleValue;
                        break;
                    case "Total":
                        metricValue.Total = entity[key].DoubleValue;
                        break;
                    case "Count":
                        metricValue.Count = entity[key].PropertyType == EdmType.Int64 ? entity[key].Int64Value : entity[key].Int32Value;
                        break;
                    case "Last":
                        metricValue.Last = entity[key].DoubleValue;
                        break;
                    default:
                        // if it is a string then store it in the properties
                        if (entity[key].PropertyType == EdmType.String)
                        {
                            otherProperties.Add(key, entity[key].StringValue);
                        }

                        break;
                }
            }

            metricValue.Properties = otherProperties;
            return metricValue;
        }
    }
}

