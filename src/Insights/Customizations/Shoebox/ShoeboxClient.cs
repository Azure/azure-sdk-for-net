using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.Insights.Models;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Table;

namespace Microsoft.Azure.Insights
{
    internal static class ShoeboxClient
    {
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
            // If metrics are requested by name, get those metrics specifically, unless too many are requested.
            // If no names or too many names are provided, get all metrics and filter if necessary.
            return new MetricListResponse()
            {
                MetricCollection = await (filter.Names == null || filter.Names.Count() > MaxParallelRequestsByName
                    ? GetMetricsByTimestampAsync(filter, location, invocationId)
                    : GetMetricsByNameAsync(filter, location, invocationId)).ConfigureAwait(false)
            };
        }

        // Generates queries for each metric by name (name-timestamp rowKey format) at collects the results
        // Note: Does not populate Metric fields unrelated to query (i.e. "display name", resourceUri, and properties)
        private static async Task<MetricCollection> GetMetricsByNameAsync(MetricFilter filter, MetricLocation location, string invocationId)
        {
            // Create a query for each metric name
            Dictionary<string, TableQuery> queries = GenerateMetricNameQueries(filter.Names, location.PartitionKey,
                filter.StartTime, filter.EndTime);

            // Create a task for each query. Each query will correspond to one metric
            IEnumerable<Task<Metric>> queryTasks = queries.Select(async kvp => await GetMetricAsync(kvp.Key, kvp.Value, filter, location, invocationId).ConfigureAwait(false));

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

            // Group entities by (encoded) name
            IEnumerable<IGrouping<string, DynamicTableEntity>> groups = entities.GroupBy(entity => entity.RowKey.Substring(entity.RowKey.LastIndexOf('_') + 1));

            // if names are specified, filter the results to those metrics only
            if (filter.Names != null)
            {
                groups = groups.Where(g => filter.Names.Select(ShoeboxHelper.TrimAndEscapeKey).Contains(g.Key));
            }

            // Construct MetricCollection (list of metrics) by taking each group and converting the entities in that group to MetricValue objects
            return new MetricCollection()
            {
                Value =
                    groups.Select(g => new Metric()
                    {
                        Name = new LocalizableString()
                        {
                            Value = FindMetricName(g.Key, filter.Names)
                        },
                        StartTime = filter.StartTime,
                        EndTime = filter.EndTime,
                        TimeGrain = filter.TimeGrain,
                        MetricValues = g.Select(ResolveMetricEntity).ToList()
                    }).ToList()
            };
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
        private static async Task<Metric> GetMetricAsync(string name, TableQuery query, MetricFilter filter, MetricLocation location, string invocationId)
        {
            // The GetEnititesAsync function provides one task that will call all the queries in parallel
            return new Metric()
            {
                Name = new LocalizableString()
                {
                    Value = name
                },
                StartTime = filter.StartTime,
                EndTime = filter.EndTime,
                TimeGrain = filter.TimeGrain,
                MetricValues = (await GetEntitiesAsync(GetNdayTables(filter, location), query, invocationId).ConfigureAwait(false)).Select(ResolveMetricEntity).ToList()
            };
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
            MetricValue metricValue = new MetricValue()
            {
                Timestamp = entity["TIMESTAMP"].DateTime ?? entity.Timestamp.UtcDateTime
            };

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
                        metricValue.Count = entity[key].Int32Value;
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

