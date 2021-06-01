// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// Ingests data into a <see cref="DataFeed"/> for anomaly detection.
    /// </summary>
    public abstract class DataFeedSource
    {
        internal DataFeedSourceType Type { get; }

        internal object Parameter { get; set; }

        internal DataFeedSource(DataFeedSourceType dataFeedSourceType)
        {
            Type = dataFeedSourceType;
        }

        internal static DataFeedSource GetDataFeedSource(DataFeedDetail dataFeedDetail) =>
            dataFeedDetail switch
            {
                AzureApplicationInsightsDataFeed d => new AzureApplicationInsightsDataFeedSource(d.DataSourceParameter),
                AzureBlobDataFeed d => new AzureBlobDataFeedSource(d.DataSourceParameter),
                AzureCosmosDBDataFeed d => new AzureCosmosDbDataFeedSource(d.DataSourceParameter),
                AzureDataLakeStorageGen2DataFeed d => new AzureDataLakeStorageGen2DataFeedSource(d.DataSourceParameter),
                AzureTableDataFeed d => new AzureTableDataFeedSource(d.DataSourceParameter),
                InfluxDBDataFeed d => new InfluxDbDataFeedSource(d.DataSourceParameter),
                AzureDataExplorerDataFeed d => new AzureDataExplorerDataFeedSource(d.DataSourceParameter),
                MySqlDataFeed d => new MySqlDataFeedSource(d.DataSourceParameter),
                PostgreSqlDataFeed d => new PostgreSqlDataFeedSource(d.DataSourceParameter),
                SQLServerDataFeed d => new SqlServerDataFeedSource(d.DataSourceParameter),
                MongoDBDataFeed d => new MongoDbDataFeedSource(d.DataSourceParameter),
                _ => throw new InvalidOperationException("Invalid DataFeedDetail type")
            };

        /// <summary>
        /// Initializes a new instance of a data source specific DataFeedDetail.
        /// </summary>
        internal DataFeedDetail InstantiateDataFeedDetail(string name, DataFeedGranularityType granularityType, IList<DataFeedMetric> metricColumns, DateTimeOffset ingestionStartTime)
        {
            ingestionStartTime = ClientCommon.NormalizeDateTimeOffset(ingestionStartTime);

            return Parameter switch
            {
                AzureApplicationInsightsParameter p => new AzureApplicationInsightsDataFeed(name, granularityType, metricColumns, ingestionStartTime, p),
                AzureBlobParameter p => new AzureBlobDataFeed(name, granularityType, metricColumns, ingestionStartTime, p),
                AzureCosmosDBParameter p => new AzureCosmosDBDataFeed(name, granularityType, metricColumns, ingestionStartTime, p),
                AzureDataLakeStorageGen2Parameter p => new AzureDataLakeStorageGen2DataFeed(name, granularityType, metricColumns, ingestionStartTime, p),
                AzureTableParameter p => new AzureTableDataFeed(name, granularityType, metricColumns, ingestionStartTime, p),
                InfluxDBParameter p => new InfluxDBDataFeed(name, granularityType, metricColumns, ingestionStartTime, p),
                SqlSourceParameter p when Type == DataFeedSourceType.AzureDataExplorer => new AzureDataExplorerDataFeed(name, granularityType, metricColumns, ingestionStartTime, p),
                SqlSourceParameter p when Type == DataFeedSourceType.MySql => new MySqlDataFeed(name, granularityType, metricColumns, ingestionStartTime, p),
                SqlSourceParameter p when Type == DataFeedSourceType.PostgreSql => new PostgreSqlDataFeed(name, granularityType, metricColumns, ingestionStartTime, p),
                SqlSourceParameter p when Type == DataFeedSourceType.SqlServer => new SQLServerDataFeed(name, granularityType, metricColumns, ingestionStartTime, p),
                MongoDBParameter p => new MongoDBDataFeed(name, granularityType, metricColumns, ingestionStartTime, p),
                _ => throw new InvalidOperationException("Invalid DataFeedDetail type")
            };
        }

        /// <summary>
        /// Initializes a new instance of a data source specific DataFeedDetailPatch.
        /// </summary>
        internal DataFeedDetailPatch InstantiateDataFeedDetailPatch()
        {
            return Parameter switch
            {
                /*
                AzureApplicationInsightsParameter p => new AzureApplicationInsightsDataFeedPatch() { DataSourceParameter = p },
                AzureBlobParameter p => new AzureBlobDataFeedPatch() { DataSourceParameter = p },
                AzureCosmosDBParameter p => new AzureCosmosDBDataFeedPatch() { DataSourceParameter = p },
                AzureDataLakeStorageGen2Parameter p => new AzureDataLakeStorageGen2DataFeedPatch() { DataSourceParameter = p },
                AzureTableParameter p => new AzureTableDataFeedPatch() { DataSourceParameter = p },
                InfluxDBParameter p => new InfluxDBDataFeedPatch() { DataSourceParameter = p },
                SqlSourceParameter p when Type == DataFeedSourceType.AzureDataExplorer => new AzureDataExplorerDataFeedPatch() { DataSourceParameter = p },
                SqlSourceParameter p when Type == DataFeedSourceType.MySql => new MySqlDataFeedPatch() { DataSourceParameter = p },
                SqlSourceParameter p when Type == DataFeedSourceType.PostgreSql => new PostgreSqlDataFeedPatch() { DataSourceParameter = p },
                SqlSourceParameter p when Type == DataFeedSourceType.SqlServer => new SQLServerDataFeedPatch() { DataSourceParameter = p },
                MongoDBParameter p => new MongoDBDataFeedPatch() { DataSourceParameter = p },
                */
                _ => throw new InvalidOperationException("Invalid DataFeedDetailPatch type")
            };
        }
    }
}
