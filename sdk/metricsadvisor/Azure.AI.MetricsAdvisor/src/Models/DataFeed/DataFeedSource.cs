// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// Ingests data into a <see cref="DataFeed"/> for anomaly detection.
    /// </summary>
    public abstract class DataFeedSource
    {
        internal DataFeedDetail DataFeedDetail { get; set; }

        internal object Parameter { get; set; }

        private DataFeedSourceType DataFeedSourceType { get; }

        internal DataFeedSource(DataFeedSourceType dataFeedSourceType)
        {
            DataFeedSourceType = dataFeedSourceType;
        }

        internal DataFeedSource(DataFeedDetail detail)
        {
            Argument.AssertNotNull(detail, nameof(detail));

            DataFeedSourceType = detail.DataSourceType;
            DataFeedDetail = detail;
        }

        /// <summary> Initializes a new instance of a data source specific DataFeedDetail. </summary>
        /// <param name="dataFeedName"> data feed name. </param>
        /// <param name="dataFeedGranularity"></param>
        /// <param name="dataFeedSchema"></param>
        /// <param name="dataFeedIngestionSettings"></param>
        /// <param name="dataFeedOptions"></param>
        internal void SetDetail(string dataFeedName, DataFeedGranularity dataFeedGranularity, DataFeedSchema dataFeedSchema, DataFeedIngestionSettings dataFeedIngestionSettings, DataFeedOptions dataFeedOptions)
        {
            dataFeedIngestionSettings.IngestionStartTime = ClientCommon.NormalizeDateTimeOffset(dataFeedIngestionSettings.IngestionStartTime);

            DataFeedDetail = Parameter switch
            {
                AzureApplicationInsightsParameter p => new AzureApplicationInsightsDataFeed(dataFeedName, dataFeedGranularity.GranularityType, dataFeedSchema.MetricColumns, dataFeedIngestionSettings.IngestionStartTime, p),
                AzureBlobParameter p => new AzureBlobDataFeed(dataFeedName, dataFeedGranularity.GranularityType, dataFeedSchema.MetricColumns, dataFeedIngestionSettings.IngestionStartTime, p),
                AzureCosmosDBParameter p => new AzureCosmosDBDataFeed(dataFeedName, dataFeedGranularity.GranularityType, dataFeedSchema.MetricColumns, dataFeedIngestionSettings.IngestionStartTime, p),
                AzureDataLakeStorageGen2Parameter p => new AzureDataLakeStorageGen2DataFeed(dataFeedName, dataFeedGranularity.GranularityType, dataFeedSchema.MetricColumns, dataFeedIngestionSettings.IngestionStartTime, p),
                AzureTableParameter p => new AzureTableDataFeed(dataFeedName, dataFeedGranularity.GranularityType, dataFeedSchema.MetricColumns, dataFeedIngestionSettings.IngestionStartTime, p),
                ElasticsearchParameter p => new ElasticsearchDataFeed(dataFeedName, dataFeedGranularity.GranularityType, dataFeedSchema.MetricColumns, dataFeedIngestionSettings.IngestionStartTime, p),
                HttpRequestParameter p => new HttpRequestDataFeed(dataFeedName, dataFeedGranularity.GranularityType, dataFeedSchema.MetricColumns, dataFeedIngestionSettings.IngestionStartTime, p),
                InfluxDBParameter p => new InfluxDBDataFeed(dataFeedName, dataFeedGranularity.GranularityType, dataFeedSchema.MetricColumns, dataFeedIngestionSettings.IngestionStartTime, p),
                SqlSourceParameter p when DataFeedSourceType == DataFeedSourceType.AzureDataExplorer => new AzureDataExplorerDataFeed(dataFeedName, dataFeedGranularity.GranularityType, dataFeedSchema.MetricColumns, dataFeedIngestionSettings.IngestionStartTime, p),
                SqlSourceParameter p when DataFeedSourceType == DataFeedSourceType.MySql => new MySqlDataFeed(dataFeedName, dataFeedGranularity.GranularityType, dataFeedSchema.MetricColumns, dataFeedIngestionSettings.IngestionStartTime, p),
                SqlSourceParameter p when DataFeedSourceType == DataFeedSourceType.PostgreSql => new PostgreSqlDataFeed(dataFeedName, dataFeedGranularity.GranularityType, dataFeedSchema.MetricColumns, dataFeedIngestionSettings.IngestionStartTime, p),
                SqlSourceParameter p when DataFeedSourceType == DataFeedSourceType.SqlServer => new SQLServerDataFeed(dataFeedName, dataFeedGranularity.GranularityType, dataFeedSchema.MetricColumns, dataFeedIngestionSettings.IngestionStartTime, p),
                MongoDBParameter p => new MongoDBDataFeed(dataFeedName, dataFeedGranularity.GranularityType, dataFeedSchema.MetricColumns, dataFeedIngestionSettings.IngestionStartTime, p),
                _ => throw new InvalidOperationException("Invalid DataFeedDetail type")
            };

            DataFeedDetail.GranularityAmount = dataFeedGranularity.CustomGranularityValue;
            foreach (var column in dataFeedSchema.DimensionColumns)
            {
                DataFeedDetail.Dimension.Add(column);
            }
            DataFeedDetail.TimestampColumn = dataFeedSchema.TimestampColumn;
            DataFeedDetail.MaxConcurrency = dataFeedIngestionSettings.DataSourceRequestConcurrency;
            DataFeedDetail.MinRetryIntervalInSeconds = (long?)dataFeedIngestionSettings.IngestionRetryDelay?.TotalSeconds;
            DataFeedDetail.StartOffsetInSeconds = (long?)dataFeedIngestionSettings.IngestionStartOffset?.TotalSeconds;
            DataFeedDetail.StopRetryAfterInSeconds = (long?)dataFeedIngestionSettings.StopRetryAfter?.TotalSeconds;
            if (dataFeedOptions != null)
            {
                foreach (var admin in dataFeedOptions.Administrators)
                {
                    DataFeedDetail.Admins.Add(admin);
                }
                foreach (var viewer in dataFeedOptions.Viewers)
                {
                    DataFeedDetail.Viewers.Add(viewer);
                }
                DataFeedDetail.DataFeedDescription = dataFeedOptions.FeedDescription;
                DataFeedDetail.ViewMode = dataFeedOptions.AccessMode;
                if (dataFeedOptions.RollupSettings != null)
                {
                    foreach (var columnName in dataFeedOptions.RollupSettings.AutoRollupGroupByColumnNames)
                    {
                        DataFeedDetail.RollUpColumns.Add(columnName);
                    }
                    DataFeedDetail.RollUpMethod = dataFeedOptions.RollupSettings.RollupMethod;
                    DataFeedDetail.NeedRollup = dataFeedOptions.RollupSettings.RollupType;
                }
                if (dataFeedOptions.MissingDataPointFillSettings != null)
                {
                    DataFeedDetail.FillMissingPointType = dataFeedOptions.MissingDataPointFillSettings.FillType;
                    DataFeedDetail.FillMissingPointValue = dataFeedOptions.MissingDataPointFillSettings.CustomFillValue;
                }
            }
        }
    }
}
