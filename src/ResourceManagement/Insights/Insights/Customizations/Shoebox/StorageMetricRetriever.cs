//
// Copyright (c) Microsoft.  All rights reserved.
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Azure.Insights.Models;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Table;

namespace Microsoft.Azure.Insights.Customizations.Shoebox
{
    /// <summary>
    /// Metric retriever for getting Storage metrics directly from Storage
    /// </summary>
    internal class StorageMetricRetriever : SasMetricRetriever
    {
        // Calling this based on a grouping (in SasMetricRetriever) should guarantee that it will have metric names specified (cannot have empty group)
        internal override async Task<MetricListResponse> GetMetricsInternalAsync(MetricFilter filter, MetricLocation location, string invocationId)
        {
            if (filter == null)
            {
                throw new ArgumentNullException("filter");
            }

            if (location == null)
            {
                throw new ArgumentNullException("location");
            }

            // This is called based on the definitions no the dimension portion of the filter should never be null or empty
            if (filter.DimensionFilters == null || !filter.DimensionFilters.Any())
            {
                throw new ArgumentNullException("filter.DimensionFilters");
            }

            // Separate out capacity metrics and transaction metrics into two groups
            IEnumerable<string> capacityMetrics = filter.DimensionFilters.Select(df => df.Name).Where(StorageConstants.MetricNames.IsCapacityMetric);
            IEnumerable<string> transactionMetrics = filter.DimensionFilters.Select(df => df.Name).Where(n => !StorageConstants.MetricNames.IsCapacityMetric(n));

            List<Task<IEnumerable<Metric>>> queryTasks = new List<Task<IEnumerable<Metric>>>(); 

            // Add task to get capacity metrics (if any)
            if (capacityMetrics.Any())
            {
                MetricTableInfo capacityTableInfo = location.TableInfo.FirstOrDefault(ti => StorageConstants.IsCapacityMetricsTable(ti.TableName));
                if (capacityTableInfo == null)
                {
                    throw new InvalidOperationException("Definitions for capacity metrics must contain table info for capacity metrics table");
                }

                queryTasks.Add(GetCapacityMetricsAsync(filter, GetTableReference(location, capacityTableInfo), capacityMetrics, invocationId));
            }

            // Add tasks to get transaction metrics (if any)
            if (transactionMetrics.Any())
            {
                IEnumerable<MetricTableInfo> transactionTableInfos = location.TableInfo.Where(ti => !StorageConstants.IsCapacityMetricsTable(ti.TableName));
                if (!transactionTableInfos.Any())
                {
                    throw new InvalidOperationException("Definitions for transaction metrics must contain table info for transaction metrics table");
                }

                queryTasks.AddRange(transactionTableInfos
                    .Select(info => GetTransactionMetricsAsync(filter, GetTableReference(location, info), transactionMetrics, invocationId)));
            }

            // Collect results and wrap
            return new MetricListResponse()
            {
                RequestId = invocationId,
                StatusCode = HttpStatusCode.OK,
                MetricCollection = new MetricCollection()
                {
                    Value = (await CollectResultsAsync(queryTasks)).ToList()
                }
            };
        }

        private static CloudTable GetTableReference(MetricLocation location, MetricTableInfo tableInfo)
        {
            return new CloudTableClient(new Uri(location.TableEndpoint), new StorageCredentials(tableInfo.SasToken)).GetTableReference(tableInfo.TableName);
        }

        private static async Task<IEnumerable<Metric>> GetCapacityMetricsAsync(MetricFilter filter, CloudTable table, IEnumerable<string> metricNames, string invocationId)
        {
            IEnumerable<DynamicTableEntity> entities = await SasMetricRetriever.GetEntitiesAsync(
                table: table, 
                query: GetCapacityQuery(filter), 
                invocationId: invocationId,
                maxBatchSize: Util.MaxMetricEntities);

            return metricNames.Select(n => new Metric()
            {
                Name = new LocalizableString()
                {
                    Value = n,
                    LocalizedValue = n
                },
                StartTime = filter.StartTime,
                EndTime = filter.EndTime,
                TimeGrain = filter.TimeGrain,
                Properties = new Dictionary<string, string>(),
                MetricValues = entities.Select(entity => GetMetricValueFromEntity(entity, n)).ToList()
            });
        }

        private static async Task<IEnumerable<Metric>> GetTransactionMetricsAsync(MetricFilter filter, CloudTable table, IEnumerable<string> metricNames, string invocationId)
        {
            // Get relevant dimensions
            IEnumerable<MetricDimension> metricDimensions = filter.DimensionFilters.Where(df => metricNames.Contains(df.Name));

            // Get appropriate entities from table
            IEnumerable<DynamicTableEntity> entities = await GetEntitiesAsync(
                table: table, 
                query: GetTransactionQuery(
                           filter: filter, 
                           operationName: GetOperationNameForQuery(
                               dimensions:metricDimensions, 
                               dimensionName: StorageConstants.Dimensions.ApiDimensionName, 
                               dimensionAggregateValue: StorageConstants.Dimensions.ApiDimensionAggregateValue)), 
                invocationId: invocationId,
                maxBatchSize: Util.MaxMetricEntities);

            // Construct Metrics and accumulate results
            return metricDimensions
                .Select(md => CreateTransactionMetric(filter, md, entities))
                .Aggregate<IEnumerable<Metric>,IEnumerable<Metric>>(new Metric[0], (a, b) => a.Union(b));
        }

        private static string GetOperationNameForQuery(IEnumerable<MetricDimension> dimensions, string dimensionName, string dimensionAggregateValue)
        {
            string operationName = null;

            // Long story short: look at all the dimension values for all the metrics (dimensions) for the dimensionName,
            // if any two dimensionValues are specified, we will get all the dimensions (rows) and filter afterward (return null),
            // if no dimension values are specified anywhere, only get the "Aggregate" row (specified by dimensionAggregateValue),
            // if exactly one dimension value is specified across all the metrics, get only that row
            foreach (string value in 
                from d in dimensions
                where d.Dimensions != null
                select d.Dimensions.FirstOrDefault(fd => string.Equals(fd.Name, dimensionName))
                into filterDimension
                where filterDimension != null
                from value in filterDimension.Values
                select value)
            {
                if (operationName == null)
                {
                    operationName = value;
                }
                else if (!string.Equals(operationName, value, StringComparison.OrdinalIgnoreCase))
                {
                    return null;
                }
            }

            return operationName ?? dimensionAggregateValue;
        }

        private static IEnumerable<Metric> CreateTransactionMetric(MetricFilter filter, MetricDimension metricDimension, IEnumerable<DynamicTableEntity> entities)
        {
            List<Metric> metrics = new List<Metric>();

            // Get supported metric dimension
            MetricFilterDimension filterDimension = metricDimension.Dimensions == null
                ? null
                : metricDimension.Dimensions.FirstOrDefault(fd =>
                    string.Equals(fd.Name, StorageConstants.Dimensions.ApiDimensionName, StringComparison.OrdinalIgnoreCase));

            // no dimensions (or no supported dimensions) means only get aggregate values (user;All)
            if (filterDimension == null)
            {
                metrics.Add(new Metric()
                {
                    Name = new LocalizableString()
                    {
                        Value = metricDimension.Name,
                        LocalizedValue = metricDimension.Name
                    },
                    StartTime = filter.StartTime,
                    EndTime = filter.EndTime,
                    TimeGrain = filter.TimeGrain,
                    Properties = new Dictionary<string, string>(),
                    MetricValues = entities
                        .Where(e => string.Equals(e.RowKey, GetTransactionRowKey(StorageConstants.Dimensions.ApiDimensionAggregateValue), StringComparison.OrdinalIgnoreCase))
                        .Select(e => GetMetricValueFromEntity(e, metricDimension.Name)).ToList()
                });
            }

            // Dimension specified, get samples with requested dimension value
            else
            {
                // This is the function for filtering based on dimension value (row key)
                Func<IGrouping<string, DynamicTableEntity>, bool> groupFilter;

                // dimension specified, but no values means get all and group by dimension value (row key)
                if (filterDimension.Values == null || !filterDimension.Values.Any())
                {
                    // select all groups, but leave off aggregate. Each group becomes one metric
                    groupFilter = (entityGroup) =>
                        !string.Equals(entityGroup.Key, GetTransactionRowKey(StorageConstants.Dimensions.ApiDimensionName), StringComparison.OrdinalIgnoreCase);
                }
                else
                {
                    // select only groups specified by dimension values
                    groupFilter = (entityGroup) => filterDimension.Values.Select(GetTransactionRowKey).Contains(entityGroup.Key);
                }

                // Construct and add the metrics to the collection to return
                metrics.AddRange(entities
                    .GroupBy(e => e.RowKey)
                    .Where(groupFilter)
                    .Select(entityGroup => new Metric()
                    {
                        Name = new LocalizableString()
                        {
                            Value = metricDimension.Name,
                            LocalizedValue = metricDimension.Name
                        },
                        StartTime = filter.StartTime,
                        EndTime = filter.EndTime,
                        TimeGrain = filter.TimeGrain,
                        Properties = new Dictionary<string, string>(),
                        MetricValues = entityGroup.Select(e => GetMetricValueFromEntity(e, metricDimension.Name)).ToList()
                    }));
            }

            // return only values specified
            return metrics;
        }

        private static string GetTransactionRowKey(string dimensionValue)
        {
            return string.Concat(StorageConstants.Dimensions.TransactionDataTypeDimensionUserValue, ";", dimensionValue);
        }

        // Copied from Microsoft.WindowsAzure.Management.Monitoring.ResourceProviders.Storage.Rest.V2011_12.MetricBaseController
        private static TableQuery<DynamicTableEntity> GetTransactionQuery(MetricFilter filter, string operationName = null)
        {
            // storage transaction queries are only supported for 1 hr and 1 min timegrains
            if (filter.TimeGrain != StorageConstants.PT1H && filter.TimeGrain != StorageConstants.PT1M)
            {
                return null;
            }

            DateTime partitionKeyStartTime = filter.StartTime;
            DateTime partitionKeyEndTime = filter.EndTime;

            // start by assuming that we are querying for hr metrics
            // since the timestamp field does not represent the actual sample period the only time value represented is the partitionkey
            // this is basically truncated to the hr with the min zeroed out.
            string startKey = partitionKeyStartTime.ToString("yyyyMMddTHH00");
            string endKey = partitionKeyEndTime.ToString("yyyyMMddTHH00");

            // if this is actually a minute metric request correct the partition keys and table name format
            if (filter.TimeGrain == TimeSpan.FromMinutes(1))
            {
                startKey = partitionKeyStartTime.ToString("yyyyMMddTHHmm");
                endKey = partitionKeyEndTime.ToString("yyyyMMddTHHmm");
            }

            string rowKey = "user;";
            string rowComparison = QueryComparisons.Equal;

            // If requesting a particular operation, get only that one (dimension value), otherwise get all
            if (operationName == null)
            {
                rowComparison = QueryComparisons.GreaterThanOrEqual;
            }
            else
            {
                rowKey += operationName;
            }

            var filter1 = TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.GreaterThanOrEqual, startKey);
            var filter2 = TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.LessThanOrEqual, endKey);
            var filter3 = TableQuery.GenerateFilterCondition("RowKey", rowComparison, rowKey);

            var tableQuery = new TableQuery<DynamicTableEntity>().Where(
                TableQuery.CombineFilters(TableQuery.CombineFilters(filter1, TableOperators.And, filter2), TableOperators.And, filter3));

            return tableQuery;
        }

        // Copied from Microsoft.WindowsAzure.Management.Monitoring.ResourceProviders.Storage.Rest.V2011_12.MetricBaseController
        private static TableQuery<DynamicTableEntity> GetCapacityQuery(MetricFilter filter)
        {
            // capacity only applies for blob service and only for a timegrain of 1 day
            if (filter.TimeGrain != TimeSpan.FromDays(1))
            {
                return null;
            }

            // since the timestamp field does not represent the actual sample period the only time vaule represented is the partitionkey
            // this is basically truncated to the hr with the min zeroed out.
            DateTime partitionKeyStartTime = filter.StartTime;
            DateTime partitionKeyEndTime = filter.EndTime;

            string startKey = partitionKeyStartTime.ToString("yyyyMMddTHH00");
            string endKey = partitionKeyEndTime.ToString("yyyyMMddTHH00");

            var filter1 = TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.GreaterThanOrEqual, startKey);
            var filter2 = TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.LessThanOrEqual, endKey);
            var filter3 = TableQuery.GenerateFilterCondition("RowKey", QueryComparisons.Equal, "data");

            var tableQuery = new TableQuery<DynamicTableEntity>()
                .Where(TableQuery.CombineFilters(TableQuery.CombineFilters(filter1, TableOperators.And, filter2), TableOperators.And, filter3));

            return tableQuery;
        }
    }
}
