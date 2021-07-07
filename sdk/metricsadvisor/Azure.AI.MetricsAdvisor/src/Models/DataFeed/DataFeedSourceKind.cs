// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// The kind of data source that ingests a <see cref="DataFeed"/> with data.
    /// </summary>
    [CodeGenModel("DataSourceType")]
    public readonly partial struct DataFeedSourceKind
    {
        /// <summary>
        /// Azure Application Insights.
        /// </summary>
        public static DataFeedSourceKind AzureApplicationInsights { get; } = new DataFeedSourceKind(AzureApplicationInsightsValue);

        /// <summary>
        /// Azure Blob Storage.
        /// </summary>
        public static DataFeedSourceKind AzureBlob { get; } = new DataFeedSourceKind(AzureBlobValue);

        /// <summary>
        /// Azure Cosmos DB.
        /// </summary>
        [CodeGenMember("AzureCosmosDB")]
        public static DataFeedSourceKind AzureCosmosDb { get; } = new DataFeedSourceKind(AzureCosmosDbValue);

        /// <summary>
        /// Azure Data Explorer.
        /// </summary>
        public static DataFeedSourceKind AzureDataExplorer { get; } = new DataFeedSourceKind(AzureDataExplorerValue);

        /// <summary>
        /// Azure Data Lake Storage Gen2.
        /// </summary>
        [CodeGenMember("AzureDataLakeStorageGen2")]
        public static DataFeedSourceKind AzureDataLakeStorage { get; } = new DataFeedSourceKind(AzureDataLakeStorageValue);

        /// <summary>
        /// Azure Event Hubs.
        /// </summary>
        public static DataFeedSourceKind AzureEventHubs { get; } = new DataFeedSourceKind(AzureEventHubsValue);

        /// <summary>
        /// Azure Table.
        /// </summary>
        public static DataFeedSourceKind AzureTable { get; } = new DataFeedSourceKind(AzureTableValue);

        /// <summary>
        /// InfluxDB.
        /// </summary>
        [CodeGenMember("InfluxDB")]
        public static DataFeedSourceKind InfluxDb { get; } = new DataFeedSourceKind(InfluxDbValue);

        /// <summary>
        /// Log Analytics.
        /// </summary>
        [CodeGenMember("AzureLogAnalytics")]
        public static DataFeedSourceKind LogAnalytics { get; } = new DataFeedSourceKind(LogAnalyticsValue);

        /// <summary>
        /// MongoDB.
        /// </summary>
        [CodeGenMember("MongoDB")]
        public static DataFeedSourceKind MongoDb { get; } = new DataFeedSourceKind(MongoDbValue);

        /// <summary>
        /// MySQL.
        /// </summary>
        public static DataFeedSourceKind MySql { get; } = new DataFeedSourceKind(MySqlValue);

        /// <summary>
        /// PostgreSQL.
        /// </summary>
        public static DataFeedSourceKind PostgreSql { get; } = new DataFeedSourceKind(PostgreSqlValue);

        /// <summary>
        /// SQL Server.
        /// </summary>
        public static DataFeedSourceKind SqlServer { get; } = new DataFeedSourceKind(SqlServerValue);
    }
}
