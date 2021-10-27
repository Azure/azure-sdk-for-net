// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.AI.MetricsAdvisor.Models;

namespace Azure.AI.MetricsAdvisor.Administration
{
    /// <summary>
    /// The source that periodically provides data to a <see cref="DataFeed"/>. The service
    /// accepts tables of aggregated data. The supported data feed sources are:
    /// <list type="bullet">
    ///   <item><description><see cref="AzureApplicationInsightsDataFeedSource"/></description></item>
    ///   <item><description><see cref="AzureBlobDataFeedSource"/></description></item>
    ///   <item><description><see cref="AzureCosmosDbDataFeedSource"/></description></item>
    ///   <item><description><see cref="AzureDataExplorerDataFeedSource"/></description></item>
    ///   <item><description><see cref="AzureDataLakeStorageDataFeedSource"/></description></item>
    ///   <item><description><see cref="AzureEventHubsDataFeedSource"/></description></item>
    ///   <item><description><see cref="AzureTableDataFeedSource"/></description></item>
    ///   <item><description><see cref="InfluxDbDataFeedSource"/></description></item>
    ///   <item><description><see cref="LogAnalyticsDataFeedSource"/></description></item>
    ///   <item><description><see cref="MongoDbDataFeedSource"/></description></item>
    ///   <item><description><see cref="MySqlDataFeedSource"/></description></item>
    ///   <item><description><see cref="PostgreSqlDataFeedSource"/></description></item>
    ///   <item><description><see cref="SqlServerDataFeedSource"/></description></item>
    /// </list>
    /// </summary>
    public abstract class DataFeedSource
    {
        internal DataFeedSource(DataFeedSourceKind dataFeedSourceKind)
        {
            DataSourceKind = dataFeedSourceKind;
        }

        /// <summary>
        /// The data source kind.
        /// </summary>
        public DataFeedSourceKind DataSourceKind { get; }

        internal static DataFeedSource GetDataFeedSource(DataFeedDetail dataFeedDetail) =>
            dataFeedDetail switch
            {
                AzureApplicationInsightsDataFeed d => new AzureApplicationInsightsDataFeedSource(d.DataSourceParameter),
                AzureBlobDataFeed d => new AzureBlobDataFeedSource(d.DataSourceParameter, d.AuthenticationType),
                AzureCosmosDBDataFeed d => new AzureCosmosDbDataFeedSource(d.DataSourceParameter),
                AzureDataExplorerDataFeed d => new AzureDataExplorerDataFeedSource(d.DataSourceParameter, d.AuthenticationType, d.CredentialId),
                AzureDataLakeStorageGen2DataFeed d => new AzureDataLakeStorageDataFeedSource(d.DataSourceParameter, d.AuthenticationType, d.CredentialId),
                AzureEventHubsDataFeed d => new AzureEventHubsDataFeedSource(d.DataSourceParameter),
                AzureLogAnalyticsDataFeed d => new LogAnalyticsDataFeedSource(d.DataSourceParameter),
                AzureTableDataFeed d => new AzureTableDataFeedSource(d.DataSourceParameter),
                InfluxDBDataFeed d => new InfluxDbDataFeedSource(d.DataSourceParameter),
                MongoDBDataFeed d => new MongoDbDataFeedSource(d.DataSourceParameter),
                MySqlDataFeed d => new MySqlDataFeedSource(d.DataSourceParameter),
                PostgreSqlDataFeed d => new PostgreSqlDataFeedSource(d.DataSourceParameter),
                SQLServerDataFeed d => new SqlServerDataFeedSource(d.DataSourceParameter, d.AuthenticationType, d.CredentialId),
                _ => new UnknownDataFeedSource(dataFeedDetail.DataSourceType)
            };

        /// <summary>
        /// Initializes a new instance of a data source specific DataFeedDetail.
        /// </summary>
        internal DataFeedDetail InstantiateDataFeedDetail(string name, DataFeedGranularityType granularityType, IList<DataFeedMetric> metricColumns, DateTimeOffset ingestionStartTime)
        {
            ingestionStartTime = ClientCommon.NormalizeDateTimeOffset(ingestionStartTime);

            return this switch
            {
                AzureApplicationInsightsDataFeedSource d => new AzureApplicationInsightsDataFeed(name, granularityType, metricColumns, ingestionStartTime,
                    new AzureApplicationInsightsParameter(d.Query) { ApiKey = d.ApiKey, ApplicationId = d.ApplicationId, AzureCloud = d.AzureCloud }),
                AzureBlobDataFeedSource d => new AzureBlobDataFeed(name, granularityType, metricColumns, ingestionStartTime,
                    new AzureBlobParameter(d.Container, d.BlobTemplate) { ConnectionString = d.ConnectionString }),
                AzureCosmosDbDataFeedSource d => new AzureCosmosDBDataFeed(name, granularityType, metricColumns, ingestionStartTime,
                    new AzureCosmosDBParameter(d.SqlQuery, d.Database, d.CollectionId) { ConnectionString = d.ConnectionString }),
                AzureDataExplorerDataFeedSource d => new AzureDataExplorerDataFeed(name, granularityType, metricColumns, ingestionStartTime,
                    new SqlSourceParameter(d.Query) { ConnectionString = d.ConnectionString }),
                AzureDataLakeStorageDataFeedSource d => new AzureDataLakeStorageGen2DataFeed(name, granularityType, metricColumns, ingestionStartTime,
                    new AzureDataLakeStorageGen2Parameter(d.FileSystemName, d.DirectoryTemplate, d.FileTemplate) { AccountKey = d.AccountKey, AccountName = d.AccountName }),
                AzureEventHubsDataFeedSource d => new AzureEventHubsDataFeed(name, granularityType, metricColumns, ingestionStartTime,
                    new AzureEventHubsParameter(d.ConsumerGroup) { ConnectionString = d.ConnectionString }),
                AzureTableDataFeedSource d => new AzureTableDataFeed(name, granularityType, metricColumns, ingestionStartTime,
                    new AzureTableParameter(d.Table, d.Query) { ConnectionString = d.ConnectionString }),
                InfluxDbDataFeedSource d => new InfluxDBDataFeed(name, granularityType, metricColumns, ingestionStartTime,
                    new InfluxDBParameter(d.Query) { UserName = d.Username, Password = d.Password, Database = d.Database, ConnectionString = d.ConnectionString }),
                LogAnalyticsDataFeedSource d => new AzureLogAnalyticsDataFeed(name, granularityType, metricColumns, ingestionStartTime,
                    new AzureLogAnalyticsParameter(d.WorkspaceId, d.Query) { ClientId = d.ClientId, ClientSecret = d.ClientSecret, TenantId = d.TenantId }),
                MongoDbDataFeedSource d => new MongoDBDataFeed(name, granularityType, metricColumns, ingestionStartTime,
                    new MongoDBParameter(d.Command) { Database = d.Database, ConnectionString = d.ConnectionString }),
                MySqlDataFeedSource d => new MySqlDataFeed(name, granularityType, metricColumns, ingestionStartTime,
                    new SqlSourceParameter(d.Query) { ConnectionString = d.ConnectionString }),
                PostgreSqlDataFeedSource d => new PostgreSqlDataFeed(name, granularityType, metricColumns, ingestionStartTime,
                    new SqlSourceParameter(d.Query) { ConnectionString = d.ConnectionString }),
                SqlServerDataFeedSource d => new SQLServerDataFeed(name, granularityType, metricColumns, ingestionStartTime,
                    new SqlSourceParameter(d.Query) { ConnectionString = d.ConnectionString }),
                _ => new DataFeedDetail(name, granularityType, metricColumns, ingestionStartTime) { DataSourceType = DataSourceKind }
            };
        }

        /// <summary>
        /// Initializes a new instance of a data source specific DataFeedDetailPatch.
        /// </summary>
        internal DataFeedDetailPatch InstantiateDataFeedDetailPatch() => this switch
        {
            AzureApplicationInsightsDataFeedSource d => new AzureApplicationInsightsDataFeedPatch()
                { DataSourceParameter = new() { Query = d.Query, ApiKey = d.ApiKey, ApplicationId = d.ApplicationId, AzureCloud = d.AzureCloud } },
            AzureBlobDataFeedSource d => new AzureBlobDataFeedPatch()
                { DataSourceParameter = new() { Container = d.Container, BlobTemplate = d.BlobTemplate, ConnectionString = d.ConnectionString } },
            AzureCosmosDbDataFeedSource d => new AzureCosmosDBDataFeedPatch()
                { DataSourceParameter = new() { SqlQuery = d.SqlQuery, Database = d.Database, CollectionId = d.CollectionId, ConnectionString = d.ConnectionString } },
            AzureDataExplorerDataFeedSource d => new AzureDataExplorerDataFeedPatch()
                { DataSourceParameter = new() { Query = d.Query, ConnectionString = d.ConnectionString } },
            AzureDataLakeStorageDataFeedSource d => new AzureDataLakeStorageGen2DataFeedPatch()
                { DataSourceParameter = new() { FileSystemName = d.FileSystemName, DirectoryTemplate = d.DirectoryTemplate, FileTemplate = d.FileTemplate, AccountKey = d.AccountKey, AccountName = d.AccountName } },
            AzureEventHubsDataFeedSource d => new AzureEventHubsDataFeedPatch()
                { DataSourceParameter = new() { ConnectionString = d.ConnectionString, ConsumerGroup = d.ConsumerGroup } },
            AzureTableDataFeedSource d => new AzureTableDataFeedPatch()
                { DataSourceParameter = new() { Table = d.Table, Query = d.Query, ConnectionString = d.ConnectionString } },
            InfluxDbDataFeedSource d => new InfluxDBDataFeedPatch()
                { DataSourceParameter = new() { Query = d.Query, UserName = d.Username, Password = d.Password, Database = d.Database, ConnectionString = d.ConnectionString } },
            LogAnalyticsDataFeedSource d => new AzureLogAnalyticsDataFeedPatch()
                { DataSourceParameter = new() { WorkspaceId = d.WorkspaceId, Query = d.Query, ClientId = d.ClientId, ClientSecret = d.ClientSecret, TenantId = d.TenantId } },
            MongoDbDataFeedSource d => new MongoDBDataFeedPatch()
                { DataSourceParameter = new() { Command = d.Command, Database = d.Database, ConnectionString = d.ConnectionString } },
            MySqlDataFeedSource d => new MySqlDataFeedPatch()
                { DataSourceParameter = new() { Query = d.Query, ConnectionString = d.ConnectionString } },
            PostgreSqlDataFeedSource d => new PostgreSqlDataFeedPatch()
                { DataSourceParameter = new() { Query = d.Query, ConnectionString = d.ConnectionString } },
            SqlServerDataFeedSource d => new SQLServerDataFeedPatch()
                { DataSourceParameter = new() { Query = d.Query, ConnectionString = d.ConnectionString } },
            _ => new DataFeedDetailPatch() { DataSourceType = DataSourceKind }
        };

        private class UnknownDataFeedSource : DataFeedSource
        {
            public UnknownDataFeedSource(DataFeedSourceKind dataFeedSourceKind)
                : base(dataFeedSourceKind)
            {
            }
        }
    }
}
