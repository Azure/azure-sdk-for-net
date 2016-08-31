// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Models
{
    public partial class DataSource : IResourceWithETag
    {
        /// <summary>
        /// Creates a new DataSource to connect to an Azure SQL database.
        /// </summary>
        /// <param name="name">The name of the datasource.</param>
        /// <param name="sqlConnectionString">The connection string for the Azure SQL database.</param>
        /// <param name="tableOrViewName">The name of the table or view from which to read rows.</param>
        /// <param name="deletionDetectionPolicy">Optional. The data deletion detection policy for the datasource.</param>
        /// <param name="description">Optional. Description of the datasource.</param>
        /// <returns>A new DataSource instance.</returns>
        public static DataSource AzureSql(
            string name,
            string sqlConnectionString,
            string tableOrViewName,
            DataDeletionDetectionPolicy deletionDetectionPolicy = null,
            string description = null)
        {
            return CreateSqlDataSource(name, sqlConnectionString, tableOrViewName, description, null, deletionDetectionPolicy);
        }

        /// <summary>
        /// Creates a new DataSource to connect to an Azure SQL database with change detection enabled.
        /// </summary>
        /// <param name="name">The name of the datasource.</param>
        /// <param name="sqlConnectionString">The connection string for the Azure SQL database.</param>
        /// <param name="tableOrViewName">The name of the table or view from which to read rows.</param>
        /// <param name="changeDetectionPolicy">The change detection policy for the datasource.</param>
        /// <param name="description">Optional. Description of the datasource.</param>
        /// <returns>A new DataSource instance.</returns>
        public static DataSource AzureSql(
            string name,
            string sqlConnectionString,
            string tableOrViewName,
            DataChangeDetectionPolicy changeDetectionPolicy,
            string description = null)
        {
            Throw.IfArgumentNull(changeDetectionPolicy, nameof(changeDetectionPolicy));
            return CreateSqlDataSource(name, sqlConnectionString, tableOrViewName, description, changeDetectionPolicy);
        }

        /// <summary>
        /// Creates a new DataSource to connect to an Azure SQL database with change detection and deletion detection enabled.
        /// </summary>
        /// <param name="name">The name of the datasource.</param>
        /// <param name="sqlConnectionString">The connection string for the Azure SQL database.</param>
        /// <param name="tableOrViewName">The name of the table or view from which to read rows.</param>
        /// <param name="changeDetectionPolicy">The change detection policy for the datasource. Note that only high watermark change detection is
        /// allowed for Azure SQL when deletion detection is enabled.</param>
        /// <param name="deletionDetectionPolicy">The data deletion detection policy for the datasource.</param>
        /// <param name="description">Optional. Description of the datasource.</param>
        /// <returns>A new DataSource instance.</returns>
        public static DataSource AzureSql(
            string name,
            string sqlConnectionString,
            string tableOrViewName,
            HighWaterMarkChangeDetectionPolicy changeDetectionPolicy,
            DataDeletionDetectionPolicy deletionDetectionPolicy,
            string description = null)
        {
            Throw.IfArgumentNull(changeDetectionPolicy, nameof(changeDetectionPolicy));
            Throw.IfArgumentNull(deletionDetectionPolicy, nameof(deletionDetectionPolicy));

            return CreateSqlDataSource(name, sqlConnectionString, tableOrViewName, description, changeDetectionPolicy, deletionDetectionPolicy);
        }

        /// <summary>
        /// Creates a new DataSource to connect to a VM-hosted SQL Server database.
        /// </summary>
        /// <param name="name">The name of the datasource.</param>
        /// <param name="sqlConnectionString">The connection string for the SQL Server database.</param>
        /// <param name="tableOrViewName">The name of the table or view from which to read rows.</param>
        /// <param name="deletionDetectionPolicy">Optional. The data deletion detection policy for the datasource.</param>
        /// <param name="description">Optional. Description of the datasource.</param>
        /// <returns>A new DataSource instance.</returns>
        public static DataSource SqlServerOnAzureVM(
            string name,
            string sqlConnectionString,
            string tableOrViewName,
            DataDeletionDetectionPolicy deletionDetectionPolicy = null,
            string description = null)
        {
            return AzureSql(name, sqlConnectionString, tableOrViewName, deletionDetectionPolicy, description);
        }

        /// <summary>
        /// Creates a new DataSource to connect to a VM-hosted SQL Server database with change detection enabled.
        /// </summary>
        /// <param name="name">The name of the datasource.</param>
        /// <param name="sqlConnectionString">The connection string for the SQL Server database.</param>
        /// <param name="tableOrViewName">The name of the table or view from which to read rows.</param>
        /// <param name="changeDetectionPolicy">The change detection policy for the datasource.</param>
        /// <param name="description">Optional. Description of the datasource.</param>
        /// <returns>A new DataSource instance.</returns>
        public static DataSource SqlServerOnAzureVM(
            string name,
            string sqlConnectionString,
            string tableOrViewName,
            DataChangeDetectionPolicy changeDetectionPolicy,
            string description = null)
        {
            return AzureSql(name, sqlConnectionString, tableOrViewName, changeDetectionPolicy, description);
        }

        /// <summary>
        /// Creates a new DataSource to connect to a VM-hosted SQL Server database with change detection and deletion detection enabled.
        /// </summary>
        /// <param name="name">The name of the datasource.</param>
        /// <param name="sqlConnectionString">The connection string for the SQL Server database.</param>
        /// <param name="tableOrViewName">The name of the table or view from which to read rows.</param>
        /// <param name="changeDetectionPolicy">The change detection policy for the datasource. Note that only high watermark change detection is
        /// allowed for SQL Server when deletion detection is enabled.</param>
        /// <param name="deletionDetectionPolicy">The data deletion detection policy for the datasource.</param>
        /// <param name="description">Optional. Description of the datasource.</param>
        /// <returns>A new DataSource instance.</returns>
        public static DataSource SqlServerOnAzureVM(
            string name,
            string sqlConnectionString,
            string tableOrViewName,
            HighWaterMarkChangeDetectionPolicy changeDetectionPolicy,
            DataDeletionDetectionPolicy deletionDetectionPolicy,
            string description = null)
        {
            return AzureSql(name, sqlConnectionString, tableOrViewName, changeDetectionPolicy, deletionDetectionPolicy, description);
        }

        /// <summary>
        /// Creates a new DataSource to connect to a DocumentDb database.
        /// </summary>
        /// <param name="name">The name of the datasource.</param>
        /// <param name="documentDbConnectionString">The connection string for the DocumentDb database. It must follow this format:
        /// "AccountName|AccountEndpoint=[your account name or endpoint];AccountKey=[your account key];Database=[your database name]"</param>
        /// <param name="collectionName">The name of the collection from which to read documents.</param>
        /// <param name="query">Optional. A query that is applied to the collection when reading documents.</param>
        /// <param name="useChangeDetection">Optional. Indicates whether to use change detection when indexing. Default is true.</param>
        /// <param name="deletionDetectionPolicy">Optional. The data deletion detection policy for the datasource.</param>
        /// <param name="description">Optional. Description of the datasource.</param>
        /// <returns>A new DataSource instance.</returns>
        public static DataSource DocumentDb(
            string name,
            string documentDbConnectionString,
            string collectionName,
            string query = null,
            bool useChangeDetection = true,
            DataDeletionDetectionPolicy deletionDetectionPolicy = null,
            string description = null)
        {
            Throw.IfArgumentNullOrEmpty(name, nameof(name));
            Throw.IfArgumentNullOrEmpty(collectionName, nameof(collectionName));
            Throw.IfArgumentNullOrEmpty(documentDbConnectionString, nameof(documentDbConnectionString));

            return new DataSource()
            {
                Type = DataSourceType.DocumentDb,
                Name = name,
                Description = description,
                Container = new DataContainer()
                {
                    Name = collectionName,
                    Query = query
                },
                Credentials = new DataSourceCredentials(documentDbConnectionString),
                DataChangeDetectionPolicy = useChangeDetection ? new HighWaterMarkChangeDetectionPolicy("_ts") : null,
                DataDeletionDetectionPolicy = deletionDetectionPolicy
            };
        }

        /// <summary>
        /// Creates a new DataSource to connect to an Azure Blob container.
        /// </summary>
        /// <param name="name">The name of the datasource.</param>
        /// <param name="storageConnectionString">The connection string for the Azure Storage account. It must follow this format:
        /// "DefaultEndpointsProtocol=https;AccountName=[your storage account];AccountKey=[your account key];" Note that HTTPS is required.</param>
        /// <param name="containerName">The name of the container from which to read blobs.</param>
        /// <param name="pathPrefix">Optional. If specified, the datasource will include only blobs with names starting with this prefix. This is
        /// useful when blobs are organized into "virtual folders", for example.</param>
        /// <param name="deletionDetectionPolicy">Optional. The data deletion detection policy for the datasource.</param>
        /// <param name="description">Optional. Description of the datasource.</param>
        /// <returns>A new DataSource instance.</returns>
        public static DataSource AzureBlobStorage(
            string name,
            string storageConnectionString,
            string containerName,
            string pathPrefix = null,
            DataDeletionDetectionPolicy deletionDetectionPolicy = null,
            string description = null)
        {
            Throw.IfArgumentNullOrEmpty(name, nameof(name));
            Throw.IfArgumentNullOrEmpty(containerName, nameof(containerName));
            Throw.IfArgumentNullOrEmpty(storageConnectionString, nameof(storageConnectionString));

            return new DataSource()
            {
                Type = DataSourceType.AzureBlob,
                Name = name,
                Description = description,
                Container = new DataContainer()
                {
                    Name = containerName,
                    Query = pathPrefix
                },
                Credentials = new DataSourceCredentials(storageConnectionString),
                DataDeletionDetectionPolicy = deletionDetectionPolicy
            };
        }

        /// <summary>
        /// Creates a new DataSource to connect to an Azure Table.
        /// </summary>
        /// <param name="name">The name of the datasource.</param>
        /// <param name="storageConnectionString">The connection string for the Azure Storage account. It must follow this format:
        /// "DefaultEndpointsProtocol=https;AccountName=[your storage account];AccountKey=[your account key];" Note that HTTPS is required.</param>
        /// <param name="tableName">The name of the table from which to read rows.</param>
        /// <param name="query">Optional. A query that is applied to the table when reading rows.</param>
        /// <param name="deletionDetectionPolicy">Optional. The data deletion detection policy for the datasource.</param>
        /// <param name="description">Optional. Description of the datasource.</param>
        /// <returns>A new DataSource instance.</returns>
        public static DataSource AzureTableStorage(
            string name,
            string storageConnectionString,
            string tableName,
            string query = null,
            DataDeletionDetectionPolicy deletionDetectionPolicy = null,
            string description = null)
        {
            Throw.IfArgumentNullOrEmpty(name, nameof(name));
            Throw.IfArgumentNullOrEmpty(tableName, nameof(tableName));
            Throw.IfArgumentNullOrEmpty(storageConnectionString, nameof(storageConnectionString));

            return new DataSource()
            {
                Type = DataSourceType.AzureTable,
                Name = name,
                Description = description,
                Container = new DataContainer()
                {
                    Name = tableName,
                    Query = query
                },
                Credentials = new DataSourceCredentials(storageConnectionString),
                DataDeletionDetectionPolicy = deletionDetectionPolicy
            };
        }

        private static DataSource CreateSqlDataSource(
            string name,
            string sqlConnectionString,
            string tableOrViewName,
            string description,
            DataChangeDetectionPolicy changeDetectionPolicy = null,
            DataDeletionDetectionPolicy deletionDetectionPolicy = null)
        {
            Throw.IfArgumentNullOrEmpty(name, nameof(name));
            Throw.IfArgumentNullOrEmpty(tableOrViewName, nameof(tableOrViewName));
            Throw.IfArgumentNullOrEmpty(sqlConnectionString, nameof(sqlConnectionString));

            return new DataSource()
            {
                Type = DataSourceType.AzureSql,
                Name = name,
                Description = description,
                Container = new DataContainer()
                {
                    Name = tableOrViewName
                },
                Credentials = new DataSourceCredentials(sqlConnectionString),
                DataChangeDetectionPolicy = changeDetectionPolicy,
                DataDeletionDetectionPolicy = deletionDetectionPolicy
            };
        }
    }
}
