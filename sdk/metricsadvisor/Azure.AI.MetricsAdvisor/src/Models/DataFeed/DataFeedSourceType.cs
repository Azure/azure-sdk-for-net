// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// The type of data source that ingests a <see cref="DataFeed"/> with data.
    /// </summary>
    [CodeGenModel("DataSourceType")]
    public readonly partial struct DataFeedSourceType
    {
        /// <summary>
        /// Azure Application Insights.
        /// </summary>
        public static DataFeedSourceType AzureApplicationInsights { get; } = new DataFeedSourceType(AzureApplicationInsightsValue);

        /// <summary>
        /// Azure Blob Storage.
        /// </summary>
        public static DataFeedSourceType AzureBlob { get; } = new DataFeedSourceType(AzureBlobValue);

        /// <summary>
        /// Azure Cosmos DB.
        /// </summary>
        [CodeGenMember("AzureCosmosDB")]
        public static DataFeedSourceType AzureCosmosDb { get; } = new DataFeedSourceType(AzureCosmosDbValue);

        /// <summary>
        /// Azure Data Explorer.
        /// </summary>
        public static DataFeedSourceType AzureDataExplorer { get; } = new DataFeedSourceType(AzureDataExplorerValue);

        /// <summary>
        /// Azure Data Lake Storage Gen2.
        /// </summary>
        public static DataFeedSourceType AzureDataLakeStorageGen2 { get; } = new DataFeedSourceType(AzureDataLakeStorageGen2Value);

        /// <summary>
        /// Azure Table.
        /// </summary>
        public static DataFeedSourceType AzureTable { get; } = new DataFeedSourceType(AzureTableValue);

        /// <summary>
        /// Elasticsearch.
        /// </summary>
        public static DataFeedSourceType Elasticsearch { get; } = new DataFeedSourceType(ElasticsearchValue);

        /// <summary>
        /// HTTP Request.
        /// </summary>
        public static DataFeedSourceType HttpRequest { get; } = new DataFeedSourceType(HttpRequestValue);

        /// <summary>
        /// InfluxDB.
        /// </summary>
        [CodeGenMember("InfluxDB")]
        public static DataFeedSourceType InfluxDb { get; } = new DataFeedSourceType(InfluxDbValue);

        /// <summary>
        /// MongoDB.
        /// </summary>
        [CodeGenMember("MongoDB")]
        public static DataFeedSourceType MongoDb { get; } = new DataFeedSourceType(MongoDbValue);

        /// <summary>
        /// MySQL.
        /// </summary>
        public static DataFeedSourceType MySql { get; } = new DataFeedSourceType(MySqlValue);

        /// <summary>
        /// PostgreSQL.
        /// </summary>
        public static DataFeedSourceType PostgreSql { get; } = new DataFeedSourceType(PostgreSqlValue);

        /// <summary>
        /// SQL Server.
        /// </summary>
        public static DataFeedSourceType SqlServer { get; } = new DataFeedSourceType(SqlServerValue);
    }
}
