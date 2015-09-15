//
// Copyright (c) Microsoft.  All rights reserved.
//

using System;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Insights.Customizations.Shoebox
{
    /// <summary>
    /// Constants used for retrieving Storage metrics
    /// </summary>
    // TODO: Update StorageMetricRetriever to determine dimension name and capacity metrics from definitons
    internal static class StorageConstants
    {
        // Timegrain constants
        internal static readonly TimeSpan PT1M = TimeSpan.FromMinutes(1);
        internal static readonly TimeSpan PT1H = TimeSpan.FromHours(1);
        internal static readonly TimeSpan P1D = TimeSpan.FromDays(1);

        internal static readonly string CapacityMetricsTableName = "$MetricsCapacityBlob";

        // supported dimensions
        internal static class Dimensions
        {
            // Data type dimension (not supported)
            public static readonly string TransactionDataTypeDimensionUserValue = "user";

            // Operation name dimension
            public static readonly string ApiDimensionName = "apiName";
            public static readonly string ApiDimensionAggregateValue = "All";
        }

        internal static class MetricNames
        {
            public static readonly string Capacity = "Capacity";
            public static readonly string ContainerCount = "ContainerCount";
            public static readonly string ObjectCount = "ObjectCount";

            public static readonly HashSet<string> CapacityMetrics = new HashSet<string>(new[] { Capacity, ContainerCount, ObjectCount });

            public static bool IsCapacityMetric(string metricName)
            {
                return CapacityMetrics.Contains(metricName, StringComparer.OrdinalIgnoreCase);
            }
        }

        // Table name funtions
        internal static bool IsCapacityMetricsTable(string tableName)
        {
            return CapacityMetricsTableName.Equals(tableName);
        }

        internal static bool IsTransactionMetricsTable(string tableName)
        {
            return tableName.IndexOf("Transaction", StringComparison.OrdinalIgnoreCase) >= 0;
        }

        internal static bool IsBlobsMetricsTable(string tableName)
        {
            return tableName.IndexOf("Blob", StringComparison.OrdinalIgnoreCase) >= 0;
        }

        internal static bool IsTableMetricsTable(string tableName)
        {
            return tableName.IndexOf("Table", StringComparison.OrdinalIgnoreCase) >= 0;
        }

        internal static bool IsQueueMetricsTable(string tableName)
        {
            return tableName.IndexOf("Queue", StringComparison.OrdinalIgnoreCase) >= 0;
        }
    }
}
