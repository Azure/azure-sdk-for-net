// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.AI.MetricsAdvisor.Administration;
using Azure.AI.MetricsAdvisor.Models;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.MetricsAdvisor.Tests
{
    public class DataFeedLiveTests : MetricsAdvisorLiveTestBase
    {
        private const string DataSourceAccount = "account";
        private const string DataSourceAppId = "appId";
        private const string DataSourceAuth = "auth";
        private const string DataSourceCloud = "cloud";
        private const string DataSourceCollectionId = "collectId";
        private const string DataSourceCommand = "command";
        private const string DataSourceConnectionString = "connectionStr";
        private const string DataSourceContainer = "container";
        private const string DataSourceDatabase = "database";
        private const string DataSourceDirectory = "dir";
        private const string DataSourceFile = "file";
        private const string DataSourceFileSystem = "fileSystem";
        private const string DataSourceHeader = "header";
        private const string DataSourceHost = "https://fakehost.com/";
        private const string DataSourceKey = "key";
        private const string DataSourceMethod = "method";
        private const string DataSourcePassword = "pass";
        private const string DataSourcePayload = "payload";
        private const string DataSourcePort = "port";
        private const string DataSourceQuery = "query";
        private const string DataSourceTable = "table";
        private const string DataSourceTemplate = "template";
        private const string DataSourceUsername = "username";

        public DataFeedLiveTests(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task CreateAndGetAzureApplicationInsightsDataFeedWithMinimumSetup()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new AzureApplicationInsightsDataFeedSource(DataSourceAppId, DataSourceKey, DataSourceCloud, DataSourceQuery);
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed createdDataFeed = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            ValidateDataFeedWithMinimumSetup(createdDataFeed, disposableDataFeed.Id, dataFeedName);

            Assert.That(createdDataFeed.SourceType, Is.EqualTo(DataFeedSourceType.AzureApplicationInsights));

            ValidateAzureApplicationInsightsDataSource(createdDataFeed.DataSource as AzureApplicationInsightsDataFeedSource);
        }

        [RecordedTest]
        public async Task CreateAndGetAzureApplicationInsightsDataFeedWithOptionalMembers()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new AzureApplicationInsightsDataFeedSource(DataSourceAppId, DataSourceKey, DataSourceCloud, DataSourceQuery);
            DataFeed dataFeedToCreate = GetDataFeedWithOptionalMembersSet(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed createdDataFeed = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            ValidateDataFeedWithOptionalMembersSet(createdDataFeed, disposableDataFeed.Id, dataFeedName);

            Assert.That(createdDataFeed.SourceType, Is.EqualTo(DataFeedSourceType.AzureApplicationInsights));

            ValidateAzureApplicationInsightsDataSource(createdDataFeed.DataSource as AzureApplicationInsightsDataFeedSource);
        }

        [RecordedTest]
        public async Task CreateAndGetAzureBlobDataFeedWithMinimumSetup()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new AzureBlobDataFeedSource(DataSourceConnectionString, DataSourceContainer, DataSourceTemplate);
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed createdDataFeed = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            ValidateDataFeedWithMinimumSetup(createdDataFeed, disposableDataFeed.Id, dataFeedName);

            Assert.That(createdDataFeed.SourceType, Is.EqualTo(DataFeedSourceType.AzureBlob));

            ValidateAzureBlobDataSource(createdDataFeed.DataSource as AzureBlobDataFeedSource);
        }

        [RecordedTest]
        public async Task CreateAndGetAzureBlobDataFeedWithOptionalMembers()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new AzureBlobDataFeedSource(DataSourceConnectionString, DataSourceContainer, DataSourceTemplate);
            DataFeed dataFeedToCreate = GetDataFeedWithOptionalMembersSet(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed createdDataFeed = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            ValidateDataFeedWithOptionalMembersSet(createdDataFeed, disposableDataFeed.Id, dataFeedName);

            Assert.That(createdDataFeed.SourceType, Is.EqualTo(DataFeedSourceType.AzureBlob));

            var createdDataSource = createdDataFeed.DataSource as AzureBlobDataFeedSource;

            ValidateAzureBlobDataSource(createdDataFeed.DataSource as AzureBlobDataFeedSource);
        }

        [RecordedTest]
        public async Task CreateAndGetAzureCosmosDbDataFeedWithMinimumSetup()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new AzureCosmosDbDataFeedSource(DataSourceConnectionString, DataSourceQuery, DataSourceDatabase, DataSourceCollectionId);
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed createdDataFeed = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            ValidateDataFeedWithMinimumSetup(createdDataFeed, disposableDataFeed.Id, dataFeedName);

            Assert.That(createdDataFeed.SourceType, Is.EqualTo(DataFeedSourceType.AzureCosmosDb));

            ValidateAzureCosmosDbDataSource(createdDataFeed.DataSource as AzureCosmosDbDataFeedSource);
        }

        [RecordedTest]
        public async Task CreateAndGetAzureCosmosDbDataFeedWithOptionalMembers()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new AzureCosmosDbDataFeedSource(DataSourceConnectionString, DataSourceQuery, DataSourceDatabase, DataSourceCollectionId);
            DataFeed dataFeedToCreate = GetDataFeedWithOptionalMembersSet(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed createdDataFeed = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            ValidateDataFeedWithOptionalMembersSet(createdDataFeed, disposableDataFeed.Id, dataFeedName);

            Assert.That(createdDataFeed.SourceType, Is.EqualTo(DataFeedSourceType.AzureCosmosDb));

            ValidateAzureCosmosDbDataSource(createdDataFeed.DataSource as AzureCosmosDbDataFeedSource);
        }

        [RecordedTest]
        public async Task CreateAndGetAzureDataExplorerDataFeedWithMinimumSetup()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new AzureDataExplorerDataFeedSource(DataSourceConnectionString, DataSourceQuery);
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed createdDataFeed = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            ValidateDataFeedWithMinimumSetup(createdDataFeed, disposableDataFeed.Id, dataFeedName);

            Assert.That(createdDataFeed.SourceType, Is.EqualTo(DataFeedSourceType.AzureDataExplorer));

            ValidateAzureDataExplorerDataSource(createdDataFeed.DataSource as AzureDataExplorerDataFeedSource);
        }

        [RecordedTest]
        public async Task CreateAndGetAzureDataExplorerDataFeedWithOptionalMembers()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new AzureDataExplorerDataFeedSource(DataSourceConnectionString, DataSourceQuery);
            DataFeed dataFeedToCreate = GetDataFeedWithOptionalMembersSet(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed createdDataFeed = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            ValidateDataFeedWithOptionalMembersSet(createdDataFeed, disposableDataFeed.Id, dataFeedName);

            Assert.That(createdDataFeed.SourceType, Is.EqualTo(DataFeedSourceType.AzureDataExplorer));

            ValidateAzureDataExplorerDataSource(createdDataFeed.DataSource as AzureDataExplorerDataFeedSource);
        }

        [RecordedTest]
        public async Task CreateAndGetAzureDataLakeStorageGen2DataFeedWithMinimumSetup()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new AzureDataLakeStorageGen2DataFeedSource(DataSourceAccount, DataSourceKey, DataSourceFileSystem, DataSourceDirectory, DataSourceFile);
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed createdDataFeed = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            ValidateDataFeedWithMinimumSetup(createdDataFeed, disposableDataFeed.Id, dataFeedName);

            Assert.That(createdDataFeed.SourceType, Is.EqualTo(DataFeedSourceType.AzureDataLakeStorageGen2));

            ValidateAzureDataLakeStorageGen2DataSource(createdDataFeed.DataSource as AzureDataLakeStorageGen2DataFeedSource);
        }

        [RecordedTest]
        public async Task CreateAndGetAzureDataLakeStorageGen2DataFeedWithOptionalMembers()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new AzureDataLakeStorageGen2DataFeedSource(DataSourceAccount, DataSourceKey, DataSourceFileSystem, DataSourceDirectory, DataSourceFile);
            DataFeed dataFeedToCreate = GetDataFeedWithOptionalMembersSet(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed createdDataFeed = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            ValidateDataFeedWithOptionalMembersSet(createdDataFeed, disposableDataFeed.Id, dataFeedName);

            Assert.That(createdDataFeed.SourceType, Is.EqualTo(DataFeedSourceType.AzureDataLakeStorageGen2));

            ValidateAzureDataLakeStorageGen2DataSource(createdDataFeed.DataSource as AzureDataLakeStorageGen2DataFeedSource);
        }

        [RecordedTest]
        public async Task CreateAndGetAzureTableDataFeedWithMinimumSetup()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new AzureTableDataFeedSource(DataSourceConnectionString, DataSourceTable, DataSourceQuery);
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed createdDataFeed = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            ValidateDataFeedWithMinimumSetup(createdDataFeed, disposableDataFeed.Id, dataFeedName);

            Assert.That(createdDataFeed.SourceType, Is.EqualTo(DataFeedSourceType.AzureTable));

            ValidateAzureTableDataSource(createdDataFeed.DataSource as AzureTableDataFeedSource);
        }

        [RecordedTest]
        public async Task CreateAndGetAzureTableDataFeedWithOptionalMembers()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new AzureTableDataFeedSource(DataSourceConnectionString, DataSourceTable, DataSourceQuery);
            DataFeed dataFeedToCreate = GetDataFeedWithOptionalMembersSet(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed createdDataFeed = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            ValidateDataFeedWithOptionalMembersSet(createdDataFeed, disposableDataFeed.Id, dataFeedName);

            Assert.That(createdDataFeed.SourceType, Is.EqualTo(DataFeedSourceType.AzureTable));

            ValidateAzureTableDataSource(createdDataFeed.DataSource as AzureTableDataFeedSource);
        }

        [RecordedTest]
        public async Task CreateAndGetElasticsearchDataFeedWithMinimumSetup()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new ElasticsearchDataFeedSource(DataSourceHost, DataSourcePort, DataSourceAuth, DataSourceQuery);
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed createdDataFeed = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            ValidateDataFeedWithMinimumSetup(createdDataFeed, disposableDataFeed.Id, dataFeedName);

            Assert.That(createdDataFeed.SourceType, Is.EqualTo(DataFeedSourceType.Elasticsearch));

            ValidateElasticsearchDataSource(createdDataFeed.DataSource as ElasticsearchDataFeedSource);
        }

        [RecordedTest]
        public async Task CreateAndGetElasticsearchDataFeedWithOptionalMembers()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new ElasticsearchDataFeedSource(DataSourceHost, DataSourcePort, DataSourceAuth, DataSourceQuery);
            DataFeed dataFeedToCreate = GetDataFeedWithOptionalMembersSet(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed createdDataFeed = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            ValidateDataFeedWithOptionalMembersSet(createdDataFeed, disposableDataFeed.Id, dataFeedName);

            Assert.That(createdDataFeed.SourceType, Is.EqualTo(DataFeedSourceType.Elasticsearch));

            ValidateElasticsearchDataSource(createdDataFeed.DataSource as ElasticsearchDataFeedSource);
        }

        [RecordedTest]
        public async Task CreateAndGetHttpRequestDataFeedWithMinimumSetup()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new HttpRequestDataFeedSource(new Uri(DataSourceHost), DataSourceHeader, DataSourceMethod, DataSourcePayload);
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed createdDataFeed = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            ValidateDataFeedWithMinimumSetup(createdDataFeed, disposableDataFeed.Id, dataFeedName);

            Assert.That(createdDataFeed.SourceType, Is.EqualTo(DataFeedSourceType.HttpRequest));

            ValidateHttpRequestDataSource(createdDataFeed.DataSource as HttpRequestDataFeedSource);
        }

        [RecordedTest]
        public async Task CreateAndGetHttpRequestDataFeedWithOptionalMembers()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new HttpRequestDataFeedSource(new Uri(DataSourceHost), DataSourceHeader, DataSourceMethod, DataSourcePayload);
            DataFeed dataFeedToCreate = GetDataFeedWithOptionalMembersSet(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed createdDataFeed = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            ValidateDataFeedWithOptionalMembersSet(createdDataFeed, disposableDataFeed.Id, dataFeedName);

            Assert.That(createdDataFeed.SourceType, Is.EqualTo(DataFeedSourceType.HttpRequest));

            ValidateHttpRequestDataSource(createdDataFeed.DataSource as HttpRequestDataFeedSource);
        }

        [RecordedTest]
        public async Task CreateAndGetInfluxDbDataFeedWithMinimumSetup()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new InfluxDbDataFeedSource(DataSourceConnectionString, DataSourceDatabase, DataSourceUsername, DataSourcePassword, DataSourceQuery);
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed createdDataFeed = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            ValidateDataFeedWithMinimumSetup(createdDataFeed, disposableDataFeed.Id, dataFeedName);

            Assert.That(createdDataFeed.SourceType, Is.EqualTo(DataFeedSourceType.InfluxDb));

            ValidateInfluxDbDataSource(createdDataFeed.DataSource as InfluxDbDataFeedSource);
        }

        [RecordedTest]
        public async Task CreateAndGetInfluxDbDataFeedWithOptionalMembers()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new InfluxDbDataFeedSource(DataSourceConnectionString, DataSourceDatabase, DataSourceUsername, DataSourcePassword, DataSourceQuery);
            DataFeed dataFeedToCreate = GetDataFeedWithOptionalMembersSet(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed createdDataFeed = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            ValidateDataFeedWithOptionalMembersSet(createdDataFeed, disposableDataFeed.Id, dataFeedName);

            Assert.That(createdDataFeed.SourceType, Is.EqualTo(DataFeedSourceType.InfluxDb));

            ValidateInfluxDbDataSource(createdDataFeed.DataSource as InfluxDbDataFeedSource);
        }

        [RecordedTest]
        public async Task CreateAndGetMongoDbDataFeedWithMinimumSetup()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new MongoDbDataFeedSource(DataSourceConnectionString, DataSourceDatabase, DataSourceCommand);
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed createdDataFeed = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            ValidateDataFeedWithMinimumSetup(createdDataFeed, disposableDataFeed.Id, dataFeedName);

            Assert.That(createdDataFeed.SourceType, Is.EqualTo(DataFeedSourceType.MongoDb));

            ValidateMongoDbDataSource(createdDataFeed.DataSource as MongoDbDataFeedSource);
        }

        [RecordedTest]
        public async Task CreateAndGetMongoDbDataFeedWithOptionalMembers()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new MongoDbDataFeedSource(DataSourceConnectionString, DataSourceDatabase, DataSourceCommand);
            DataFeed dataFeedToCreate = GetDataFeedWithOptionalMembersSet(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed createdDataFeed = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            ValidateDataFeedWithOptionalMembersSet(createdDataFeed, disposableDataFeed.Id, dataFeedName);

            Assert.That(createdDataFeed.SourceType, Is.EqualTo(DataFeedSourceType.MongoDb));

            ValidateMongoDbDataSource(createdDataFeed.DataSource as MongoDbDataFeedSource);
        }

        [RecordedTest]
        public async Task CreateAndGetMySqlDataFeedWithMinimumSetup()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new MySqlDataFeedSource(DataSourceConnectionString, DataSourceQuery);
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed createdDataFeed = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            ValidateDataFeedWithMinimumSetup(createdDataFeed, disposableDataFeed.Id, dataFeedName);

            Assert.That(createdDataFeed.SourceType, Is.EqualTo(DataFeedSourceType.MySql));

            ValidateMySqlDataSource(createdDataFeed.DataSource as MySqlDataFeedSource);
        }

        [RecordedTest]
        public async Task CreateAndGetMySqlDataFeedWithOptionalMembers()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new MySqlDataFeedSource(DataSourceConnectionString, DataSourceQuery);
            DataFeed dataFeedToCreate = GetDataFeedWithOptionalMembersSet(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed createdDataFeed = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            ValidateDataFeedWithOptionalMembersSet(createdDataFeed, disposableDataFeed.Id, dataFeedName);

            Assert.That(createdDataFeed.SourceType, Is.EqualTo(DataFeedSourceType.MySql));

            ValidateMySqlDataSource(createdDataFeed.DataSource as MySqlDataFeedSource);
        }

        [RecordedTest]
        public async Task CreateAndGetPostgreSqlDataFeedWithMinimumSetup()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new PostgreSqlDataFeedSource(DataSourceConnectionString, DataSourceQuery);
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed createdDataFeed = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            ValidateDataFeedWithMinimumSetup(createdDataFeed, disposableDataFeed.Id, dataFeedName);

            Assert.That(createdDataFeed.SourceType, Is.EqualTo(DataFeedSourceType.PostgreSql));

            ValidatePostgreSqlDataSource(createdDataFeed.DataSource as PostgreSqlDataFeedSource);
        }

        [RecordedTest]
        public async Task CreateAndGetPostgreSqlDataFeedWithOptionalMembers()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new PostgreSqlDataFeedSource(DataSourceConnectionString, DataSourceQuery);
            DataFeed dataFeedToCreate = GetDataFeedWithOptionalMembersSet(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed createdDataFeed = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            ValidateDataFeedWithOptionalMembersSet(createdDataFeed, disposableDataFeed.Id, dataFeedName);

            Assert.That(createdDataFeed.SourceType, Is.EqualTo(DataFeedSourceType.PostgreSql));

            ValidatePostgreSqlDataSource(createdDataFeed.DataSource as PostgreSqlDataFeedSource);
        }

        [RecordedTest]
        public async Task CreateAndGetSqlServerDataFeedWithMinimumSetup()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new SqlServerDataFeedSource(DataSourceConnectionString, DataSourceQuery);
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed createdDataFeed = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            ValidateDataFeedWithMinimumSetup(createdDataFeed, disposableDataFeed.Id, dataFeedName);

            Assert.That(createdDataFeed.SourceType, Is.EqualTo(DataFeedSourceType.SqlServer));

            ValidateSqlServerDataSource(createdDataFeed.DataSource as SqlServerDataFeedSource);
        }

        [RecordedTest]
        public async Task CreateAndGetSqlServerDataFeedWithOptionalMembers()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new SqlServerDataFeedSource(DataSourceConnectionString, DataSourceQuery);
            DataFeed dataFeedToCreate = GetDataFeedWithOptionalMembersSet(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed createdDataFeed = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            ValidateDataFeedWithOptionalMembersSet(createdDataFeed, disposableDataFeed.Id, dataFeedName);

            Assert.That(createdDataFeed.SourceType, Is.EqualTo(DataFeedSourceType.SqlServer));

            ValidateSqlServerDataSource(createdDataFeed.DataSource as SqlServerDataFeedSource);
        }

        [RecordedTest]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/17726")]
        public async Task UpdateAzureApplicationInsightsDataFeedWithMinimumSetupAndGetInstance()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new AzureApplicationInsightsDataFeedSource(DataSourceAppId, DataSourceKey, DataSourceCloud, DataSourceQuery);
            const string description = "This data feed was created to test the .NET client.";
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed dataFeedToUpdate = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            dataFeedToUpdate.Description = description;

            await adminClient.UpdateDataFeedAsync(disposableDataFeed.Id, dataFeedToUpdate);

            DataFeed updatedDataFeed = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            ValidateDataFeedWithMinimumSetup(updatedDataFeed, disposableDataFeed.Id, dataFeedName, description);

            Assert.That(updatedDataFeed.SourceType, Is.EqualTo(DataFeedSourceType.AzureApplicationInsights));

            ValidateAzureApplicationInsightsDataSource(updatedDataFeed.DataSource as AzureApplicationInsightsDataFeedSource);
        }

        [RecordedTest]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/17726")]
        public async Task UpdateAzureApplicationInsightsDataFeedWithMinimumSetupAndNewInstance()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new AzureApplicationInsightsDataFeedSource(DataSourceAppId, DataSourceKey, DataSourceCloud, DataSourceQuery);
            const string description = "This data feed was created to test the .NET client.";
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed dataFeedToUpdate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            dataFeedToUpdate.Description = description;

            await adminClient.UpdateDataFeedAsync(disposableDataFeed.Id, dataFeedToUpdate);

            DataFeed updatedDataFeed = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            ValidateDataFeedWithMinimumSetup(updatedDataFeed, disposableDataFeed.Id, dataFeedName, description);

            Assert.That(updatedDataFeed.SourceType, Is.EqualTo(DataFeedSourceType.AzureApplicationInsights));

            ValidateAzureApplicationInsightsDataSource(updatedDataFeed.DataSource as AzureApplicationInsightsDataFeedSource);
        }

        [RecordedTest]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/17726")]
        public async Task UpdateAzureApplicationInsightsDataFeedWithEveryMemberAndGetInstance()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new AzureApplicationInsightsDataFeedSource(DataSourceAppId, DataSourceKey, DataSourceCloud, DataSourceQuery);
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed dataFeedToUpdate = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            SetOptionalMembers(dataFeedToUpdate);

            await adminClient.UpdateDataFeedAsync(disposableDataFeed.Id, dataFeedToUpdate);

            DataFeed updatedDataFeed = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            ValidateUpdatedDataFeedWithOptionalMembersSet(updatedDataFeed, disposableDataFeed.Id, dataFeedName);

            Assert.That(updatedDataFeed.SourceType, Is.EqualTo(DataFeedSourceType.AzureApplicationInsights));

            ValidateAzureApplicationInsightsDataSource(updatedDataFeed.DataSource as AzureApplicationInsightsDataFeedSource);
        }

        [RecordedTest]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/17726")]
        public async Task UpdateAzureApplicationInsightsDataFeedWithEveryMemberAndNewInstance()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new AzureApplicationInsightsDataFeedSource(DataSourceAppId, DataSourceKey, DataSourceCloud, DataSourceQuery);
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed dataFeedToUpdate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            SetOptionalMembers(dataFeedToUpdate);

            await adminClient.UpdateDataFeedAsync(disposableDataFeed.Id, dataFeedToUpdate);

            DataFeed updatedDataFeed = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            ValidateUpdatedDataFeedWithOptionalMembersSet(updatedDataFeed, disposableDataFeed.Id, dataFeedName);

            Assert.That(updatedDataFeed.SourceType, Is.EqualTo(DataFeedSourceType.AzureApplicationInsights));

            ValidateAzureApplicationInsightsDataSource(updatedDataFeed.DataSource as AzureApplicationInsightsDataFeedSource);
        }

        [RecordedTest]
        public async Task UpdateAzureBlobDataFeedWithMinimumSetupAndGetInstance()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new AzureBlobDataFeedSource(DataSourceConnectionString, DataSourceContainer, DataSourceTemplate);
            const string description = "This data feed was created to test the .NET client.";
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed dataFeedToUpdate = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            dataFeedToUpdate.Description = description;

            await adminClient.UpdateDataFeedAsync(disposableDataFeed.Id, dataFeedToUpdate);

            DataFeed updatedDataFeed = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            ValidateDataFeedWithMinimumSetup(updatedDataFeed, disposableDataFeed.Id, dataFeedName, description);

            Assert.That(updatedDataFeed.SourceType, Is.EqualTo(DataFeedSourceType.AzureBlob));

            ValidateAzureBlobDataSource(updatedDataFeed.DataSource as AzureBlobDataFeedSource);
        }

        [RecordedTest]
        public async Task UpdateAzureBlobDataFeedWithMinimumSetupAndNewInstance()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new AzureBlobDataFeedSource(DataSourceConnectionString, DataSourceContainer, DataSourceTemplate);
            const string description = "This data feed was created to test the .NET client.";
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed dataFeedToUpdate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            dataFeedToUpdate.Description = description;

            await adminClient.UpdateDataFeedAsync(disposableDataFeed.Id, dataFeedToUpdate);

            DataFeed updatedDataFeed = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            ValidateDataFeedWithMinimumSetup(updatedDataFeed, disposableDataFeed.Id, dataFeedName, description);

            Assert.That(updatedDataFeed.SourceType, Is.EqualTo(DataFeedSourceType.AzureBlob));

            ValidateAzureBlobDataSource(updatedDataFeed.DataSource as AzureBlobDataFeedSource);
        }

        [RecordedTest]
        public async Task UpdateAzureBlobDataFeedWithEveryMemberAndGetInstance()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new AzureBlobDataFeedSource(DataSourceConnectionString, DataSourceContainer, DataSourceTemplate);
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed dataFeedToUpdate = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            SetOptionalMembers(dataFeedToUpdate);

            await adminClient.UpdateDataFeedAsync(disposableDataFeed.Id, dataFeedToUpdate);

            DataFeed updatedDataFeed = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            ValidateUpdatedDataFeedWithOptionalMembersSet(updatedDataFeed, disposableDataFeed.Id, dataFeedName);

            Assert.That(updatedDataFeed.SourceType, Is.EqualTo(DataFeedSourceType.AzureBlob));

            ValidateAzureBlobDataSource(updatedDataFeed.DataSource as AzureBlobDataFeedSource);
        }

        [RecordedTest]
        public async Task UpdateAzureBlobDataFeedWithEveryMemberAndNewInstance()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new AzureBlobDataFeedSource(DataSourceConnectionString, DataSourceContainer, DataSourceTemplate);
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed dataFeedToUpdate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            SetOptionalMembers(dataFeedToUpdate);

            await adminClient.UpdateDataFeedAsync(disposableDataFeed.Id, dataFeedToUpdate);

            DataFeed updatedDataFeed = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            ValidateUpdatedDataFeedWithOptionalMembersSet(updatedDataFeed, disposableDataFeed.Id, dataFeedName);

            Assert.That(updatedDataFeed.SourceType, Is.EqualTo(DataFeedSourceType.AzureBlob));

            ValidateAzureBlobDataSource(updatedDataFeed.DataSource as AzureBlobDataFeedSource);
        }

        [RecordedTest]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/17726")]
        public async Task UpdateAzureCosmosDbDataFeedWithMinimumSetupAndGetInstance()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new AzureCosmosDbDataFeedSource(DataSourceConnectionString, DataSourceQuery, DataSourceDatabase, DataSourceCollectionId);
            const string description = "This data feed was created to test the .NET client.";
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed dataFeedToUpdate = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            dataFeedToUpdate.Description = description;

            await adminClient.UpdateDataFeedAsync(disposableDataFeed.Id, dataFeedToUpdate);

            DataFeed updatedDataFeed = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            ValidateDataFeedWithMinimumSetup(updatedDataFeed, disposableDataFeed.Id, dataFeedName, description);

            Assert.That(updatedDataFeed.SourceType, Is.EqualTo(DataFeedSourceType.AzureCosmosDb));

            ValidateAzureCosmosDbDataSource(updatedDataFeed.DataSource as AzureCosmosDbDataFeedSource);
        }

        [RecordedTest]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/17726")]
        public async Task UpdateAzureCosmosDbDataFeedWithMinimumSetupAndNewInstance()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new AzureCosmosDbDataFeedSource(DataSourceConnectionString, DataSourceQuery, DataSourceDatabase, DataSourceCollectionId);
            const string description = "This data feed was created to test the .NET client.";
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed dataFeedToUpdate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            dataFeedToUpdate.Description = description;

            await adminClient.UpdateDataFeedAsync(disposableDataFeed.Id, dataFeedToUpdate);

            DataFeed updatedDataFeed = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            ValidateDataFeedWithMinimumSetup(updatedDataFeed, disposableDataFeed.Id, dataFeedName, description);

            Assert.That(updatedDataFeed.SourceType, Is.EqualTo(DataFeedSourceType.AzureCosmosDb));

            ValidateAzureCosmosDbDataSource(updatedDataFeed.DataSource as AzureCosmosDbDataFeedSource);
        }

        [RecordedTest]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/17726")]
        public async Task UpdateAzureCosmosDbDataFeedWithEveryMemberAndGetInstance()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new AzureCosmosDbDataFeedSource(DataSourceConnectionString, DataSourceQuery, DataSourceDatabase, DataSourceCollectionId);
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed dataFeedToUpdate = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            SetOptionalMembers(dataFeedToUpdate);

            await adminClient.UpdateDataFeedAsync(disposableDataFeed.Id, dataFeedToUpdate);

            DataFeed updatedDataFeed = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            ValidateUpdatedDataFeedWithOptionalMembersSet(updatedDataFeed, disposableDataFeed.Id, dataFeedName);

            Assert.That(updatedDataFeed.SourceType, Is.EqualTo(DataFeedSourceType.AzureCosmosDb));

            ValidateAzureCosmosDbDataSource(updatedDataFeed.DataSource as AzureCosmosDbDataFeedSource);
        }

        [RecordedTest]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/17726")]
        public async Task UpdateAzureCosmosDbDataFeedWithEveryMemberAndNewInstance()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new AzureCosmosDbDataFeedSource(DataSourceConnectionString, DataSourceQuery, DataSourceDatabase, DataSourceCollectionId);
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed dataFeedToUpdate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            SetOptionalMembers(dataFeedToUpdate);

            await adminClient.UpdateDataFeedAsync(disposableDataFeed.Id, dataFeedToUpdate);

            DataFeed updatedDataFeed = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            ValidateUpdatedDataFeedWithOptionalMembersSet(updatedDataFeed, disposableDataFeed.Id, dataFeedName);

            Assert.That(updatedDataFeed.SourceType, Is.EqualTo(DataFeedSourceType.AzureCosmosDb));

            ValidateAzureCosmosDbDataSource(updatedDataFeed.DataSource as AzureCosmosDbDataFeedSource);
        }

        [RecordedTest]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/17726")]
        public async Task UpdateAzureDataExplorerDataFeedWithMinimumSetupAndGetInstance()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new AzureDataExplorerDataFeedSource(DataSourceConnectionString, DataSourceQuery);
            const string description = "This data feed was created to test the .NET client.";
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed dataFeedToUpdate = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            dataFeedToUpdate.Description = description;

            await adminClient.UpdateDataFeedAsync(disposableDataFeed.Id, dataFeedToUpdate);

            DataFeed updatedDataFeed = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            ValidateDataFeedWithMinimumSetup(updatedDataFeed, disposableDataFeed.Id, dataFeedName, description);

            Assert.That(updatedDataFeed.SourceType, Is.EqualTo(DataFeedSourceType.AzureDataExplorer));

            ValidateAzureDataExplorerDataSource(updatedDataFeed.DataSource as AzureDataExplorerDataFeedSource);
        }

        [RecordedTest]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/17726")]
        public async Task UpdateAzureDataExplorerDataFeedWithMinimumSetupAndNewInstance()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new AzureDataExplorerDataFeedSource(DataSourceConnectionString, DataSourceQuery);
            const string description = "This data feed was created to test the .NET client.";
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed dataFeedToUpdate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            dataFeedToUpdate.Description = description;

            await adminClient.UpdateDataFeedAsync(disposableDataFeed.Id, dataFeedToUpdate);

            DataFeed updatedDataFeed = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            ValidateDataFeedWithMinimumSetup(updatedDataFeed, disposableDataFeed.Id, dataFeedName, description);

            Assert.That(updatedDataFeed.SourceType, Is.EqualTo(DataFeedSourceType.AzureDataExplorer));

            ValidateAzureDataExplorerDataSource(updatedDataFeed.DataSource as AzureDataExplorerDataFeedSource);
        }

        [RecordedTest]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/17726")]
        public async Task UpdateAzureDataExplorerDataFeedWithEveryMemberAndGetInstance()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new AzureDataExplorerDataFeedSource(DataSourceConnectionString, DataSourceQuery);
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed dataFeedToUpdate = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            SetOptionalMembers(dataFeedToUpdate);

            await adminClient.UpdateDataFeedAsync(disposableDataFeed.Id, dataFeedToUpdate);

            DataFeed updatedDataFeed = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            ValidateUpdatedDataFeedWithOptionalMembersSet(updatedDataFeed, disposableDataFeed.Id, dataFeedName);

            Assert.That(updatedDataFeed.SourceType, Is.EqualTo(DataFeedSourceType.AzureDataExplorer));

            ValidateAzureDataExplorerDataSource(updatedDataFeed.DataSource as AzureDataExplorerDataFeedSource);
        }

        [RecordedTest]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/17726")]
        public async Task UpdateAzureDataExplorerDataFeedWithEveryMemberAndNewInstance()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new AzureDataExplorerDataFeedSource(DataSourceConnectionString, DataSourceQuery);
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed dataFeedToUpdate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            SetOptionalMembers(dataFeedToUpdate);

            await adminClient.UpdateDataFeedAsync(disposableDataFeed.Id, dataFeedToUpdate);

            DataFeed updatedDataFeed = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            ValidateUpdatedDataFeedWithOptionalMembersSet(updatedDataFeed, disposableDataFeed.Id, dataFeedName);

            Assert.That(updatedDataFeed.SourceType, Is.EqualTo(DataFeedSourceType.AzureDataExplorer));

            ValidateAzureDataExplorerDataSource(updatedDataFeed.DataSource as AzureDataExplorerDataFeedSource);
        }

        [RecordedTest]
        public async Task UpdateAzureDataLakeStorageGen2DataFeedWithMinimumSetupAndGetInstance()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new AzureDataLakeStorageGen2DataFeedSource(DataSourceAccount, DataSourceKey, DataSourceFileSystem, DataSourceDirectory, DataSourceFile);
            const string description = "This data feed was created to test the .NET client.";
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed dataFeedToUpdate = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            dataFeedToUpdate.Description = description;

            await adminClient.UpdateDataFeedAsync(disposableDataFeed.Id, dataFeedToUpdate);

            DataFeed updatedDataFeed = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            ValidateDataFeedWithMinimumSetup(updatedDataFeed, disposableDataFeed.Id, dataFeedName, description);

            Assert.That(updatedDataFeed.SourceType, Is.EqualTo(DataFeedSourceType.AzureDataLakeStorageGen2));

            ValidateAzureDataLakeStorageGen2DataSource(updatedDataFeed.DataSource as AzureDataLakeStorageGen2DataFeedSource);
        }

        [RecordedTest]
        public async Task UpdateAzureDataLakeStorageGen2DataFeedWithMinimumSetupAndNewInstance()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new AzureDataLakeStorageGen2DataFeedSource(DataSourceAccount, DataSourceKey, DataSourceFileSystem, DataSourceDirectory, DataSourceFile);
            const string description = "This data feed was created to test the .NET client.";
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed dataFeedToUpdate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            dataFeedToUpdate.Description = description;

            await adminClient.UpdateDataFeedAsync(disposableDataFeed.Id, dataFeedToUpdate);

            DataFeed updatedDataFeed = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            ValidateDataFeedWithMinimumSetup(updatedDataFeed, disposableDataFeed.Id, dataFeedName, description);

            Assert.That(updatedDataFeed.SourceType, Is.EqualTo(DataFeedSourceType.AzureDataLakeStorageGen2));

            ValidateAzureDataLakeStorageGen2DataSource(updatedDataFeed.DataSource as AzureDataLakeStorageGen2DataFeedSource);
        }

        [RecordedTest]
        public async Task UpdateAzureDataLakeStorageGen2DataFeedWithEveryMemberAndGetInstance()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new AzureDataLakeStorageGen2DataFeedSource(DataSourceAccount, DataSourceKey, DataSourceFileSystem, DataSourceDirectory, DataSourceFile);
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed dataFeedToUpdate = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            SetOptionalMembers(dataFeedToUpdate);

            await adminClient.UpdateDataFeedAsync(disposableDataFeed.Id, dataFeedToUpdate);

            DataFeed updatedDataFeed = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            ValidateUpdatedDataFeedWithOptionalMembersSet(updatedDataFeed, disposableDataFeed.Id, dataFeedName);

            Assert.That(updatedDataFeed.SourceType, Is.EqualTo(DataFeedSourceType.AzureDataLakeStorageGen2));

            ValidateAzureDataLakeStorageGen2DataSource(updatedDataFeed.DataSource as AzureDataLakeStorageGen2DataFeedSource);
        }

        [RecordedTest]
        public async Task UpdateAzureDataLakeStorageGen2DataFeedWithEveryMemberAndNewInstance()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new AzureDataLakeStorageGen2DataFeedSource(DataSourceAccount, DataSourceKey, DataSourceFileSystem, DataSourceDirectory, DataSourceFile);
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed dataFeedToUpdate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            SetOptionalMembers(dataFeedToUpdate);

            await adminClient.UpdateDataFeedAsync(disposableDataFeed.Id, dataFeedToUpdate);

            DataFeed updatedDataFeed = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            ValidateUpdatedDataFeedWithOptionalMembersSet(updatedDataFeed, disposableDataFeed.Id, dataFeedName);

            Assert.That(updatedDataFeed.SourceType, Is.EqualTo(DataFeedSourceType.AzureDataLakeStorageGen2));

            ValidateAzureDataLakeStorageGen2DataSource(updatedDataFeed.DataSource as AzureDataLakeStorageGen2DataFeedSource);
        }

        [RecordedTest]
        public async Task UpdateAzureTableDataFeedWithMinimumSetupAndGetInstance()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new AzureTableDataFeedSource(DataSourceConnectionString, DataSourceTable, DataSourceQuery);
            const string description = "This data feed was created to test the .NET client.";
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed dataFeedToUpdate = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            dataFeedToUpdate.Description = description;

            await adminClient.UpdateDataFeedAsync(disposableDataFeed.Id, dataFeedToUpdate);

            DataFeed updatedDataFeed = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            ValidateDataFeedWithMinimumSetup(updatedDataFeed, disposableDataFeed.Id, dataFeedName, description);

            Assert.That(updatedDataFeed.SourceType, Is.EqualTo(DataFeedSourceType.AzureTable));

            ValidateAzureTableDataSource(updatedDataFeed.DataSource as AzureTableDataFeedSource);
        }

        [RecordedTest]
        public async Task UpdateAzureTableDataFeedWithMinimumSetupAndNewInstance()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new AzureTableDataFeedSource(DataSourceConnectionString, DataSourceTable, DataSourceQuery);
            const string description = "This data feed was created to test the .NET client.";
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed dataFeedToUpdate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            dataFeedToUpdate.Description = description;

            await adminClient.UpdateDataFeedAsync(disposableDataFeed.Id, dataFeedToUpdate);

            DataFeed updatedDataFeed = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            ValidateDataFeedWithMinimumSetup(updatedDataFeed, disposableDataFeed.Id, dataFeedName, description);

            Assert.That(updatedDataFeed.SourceType, Is.EqualTo(DataFeedSourceType.AzureTable));

            ValidateAzureTableDataSource(updatedDataFeed.DataSource as AzureTableDataFeedSource);
        }

        [RecordedTest]
        public async Task UpdateAzureTableDataFeedWithEveryMemberAndGetInstance()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new AzureTableDataFeedSource(DataSourceConnectionString, DataSourceTable, DataSourceQuery);
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed dataFeedToUpdate = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            SetOptionalMembers(dataFeedToUpdate);

            await adminClient.UpdateDataFeedAsync(disposableDataFeed.Id, dataFeedToUpdate);

            DataFeed updatedDataFeed = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            ValidateUpdatedDataFeedWithOptionalMembersSet(updatedDataFeed, disposableDataFeed.Id, dataFeedName);

            Assert.That(updatedDataFeed.SourceType, Is.EqualTo(DataFeedSourceType.AzureTable));

            ValidateAzureTableDataSource(updatedDataFeed.DataSource as AzureTableDataFeedSource);
        }

        [RecordedTest]
        public async Task UpdateAzureTableDataFeedWithEveryMemberAndNewInstance()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new AzureTableDataFeedSource(DataSourceConnectionString, DataSourceTable, DataSourceQuery);
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed dataFeedToUpdate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            SetOptionalMembers(dataFeedToUpdate);

            await adminClient.UpdateDataFeedAsync(disposableDataFeed.Id, dataFeedToUpdate);

            DataFeed updatedDataFeed = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            ValidateUpdatedDataFeedWithOptionalMembersSet(updatedDataFeed, disposableDataFeed.Id, dataFeedName);

            Assert.That(updatedDataFeed.SourceType, Is.EqualTo(DataFeedSourceType.AzureTable));

            ValidateAzureTableDataSource(updatedDataFeed.DataSource as AzureTableDataFeedSource);
        }

        [RecordedTest]
        public async Task UpdateElasticsearchDataFeedWithMinimumSetupAndGetInstance()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new ElasticsearchDataFeedSource(DataSourceHost, DataSourcePort, DataSourceAuth, DataSourceQuery);
            const string description = "This data feed was created to test the .NET client.";
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed dataFeedToUpdate = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            dataFeedToUpdate.Description = description;

            await adminClient.UpdateDataFeedAsync(disposableDataFeed.Id, dataFeedToUpdate);

            DataFeed updatedDataFeed = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            ValidateDataFeedWithMinimumSetup(updatedDataFeed, disposableDataFeed.Id, dataFeedName, description);

            Assert.That(updatedDataFeed.SourceType, Is.EqualTo(DataFeedSourceType.Elasticsearch));

            ValidateElasticsearchDataSource(updatedDataFeed.DataSource as ElasticsearchDataFeedSource);
        }

        [RecordedTest]
        public async Task UpdateElasticsearchDataFeedWithMinimumSetupAndNewInstance()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new ElasticsearchDataFeedSource(DataSourceHost, DataSourcePort, DataSourceAuth, DataSourceQuery);
            const string description = "This data feed was created to test the .NET client.";
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed dataFeedToUpdate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            dataFeedToUpdate.Description = description;

            await adminClient.UpdateDataFeedAsync(disposableDataFeed.Id, dataFeedToUpdate);

            DataFeed updatedDataFeed = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            ValidateDataFeedWithMinimumSetup(updatedDataFeed, disposableDataFeed.Id, dataFeedName, description);

            Assert.That(updatedDataFeed.SourceType, Is.EqualTo(DataFeedSourceType.Elasticsearch));

            ValidateElasticsearchDataSource(updatedDataFeed.DataSource as ElasticsearchDataFeedSource);
        }

        [RecordedTest]
        public async Task UpdateElasticsearchDataFeedWithEveryMemberAndGetInstance()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new ElasticsearchDataFeedSource(DataSourceHost, DataSourcePort, DataSourceAuth, DataSourceQuery);
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed dataFeedToUpdate = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            SetOptionalMembers(dataFeedToUpdate);

            await adminClient.UpdateDataFeedAsync(disposableDataFeed.Id, dataFeedToUpdate);

            DataFeed updatedDataFeed = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            ValidateUpdatedDataFeedWithOptionalMembersSet(updatedDataFeed, disposableDataFeed.Id, dataFeedName);

            Assert.That(updatedDataFeed.SourceType, Is.EqualTo(DataFeedSourceType.Elasticsearch));

            ValidateElasticsearchDataSource(updatedDataFeed.DataSource as ElasticsearchDataFeedSource);
        }

        [RecordedTest]
        public async Task UpdateElasticsearchDataFeedWithEveryMemberAndNewInstance()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new ElasticsearchDataFeedSource(DataSourceHost, DataSourcePort, DataSourceAuth, DataSourceQuery);
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed dataFeedToUpdate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            SetOptionalMembers(dataFeedToUpdate);

            await adminClient.UpdateDataFeedAsync(disposableDataFeed.Id, dataFeedToUpdate);

            DataFeed updatedDataFeed = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            ValidateUpdatedDataFeedWithOptionalMembersSet(updatedDataFeed, disposableDataFeed.Id, dataFeedName);

            Assert.That(updatedDataFeed.SourceType, Is.EqualTo(DataFeedSourceType.Elasticsearch));

            ValidateElasticsearchDataSource(updatedDataFeed.DataSource as ElasticsearchDataFeedSource);
        }

        [RecordedTest]
        public async Task UpdateHttpRequestDataFeedWithMinimumSetupAndGetInstance()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new HttpRequestDataFeedSource(new Uri(DataSourceHost), DataSourceHeader, DataSourceMethod, DataSourcePayload);
            const string description = "This data feed was created to test the .NET client.";
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed dataFeedToUpdate = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            dataFeedToUpdate.Description = description;

            await adminClient.UpdateDataFeedAsync(disposableDataFeed.Id, dataFeedToUpdate);

            DataFeed updatedDataFeed = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            ValidateDataFeedWithMinimumSetup(updatedDataFeed, disposableDataFeed.Id, dataFeedName, description);

            Assert.That(updatedDataFeed.SourceType, Is.EqualTo(DataFeedSourceType.HttpRequest));

            ValidateHttpRequestDataSource(updatedDataFeed.DataSource as HttpRequestDataFeedSource);
        }

        [RecordedTest]
        public async Task UpdateHttpRequestDataFeedWithMinimumSetupAndNewInstance()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new HttpRequestDataFeedSource(new Uri(DataSourceHost), DataSourceHeader, DataSourceMethod, DataSourcePayload);
            const string description = "This data feed was created to test the .NET client.";
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed dataFeedToUpdate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            dataFeedToUpdate.Description = description;

            await adminClient.UpdateDataFeedAsync(disposableDataFeed.Id, dataFeedToUpdate);

            DataFeed updatedDataFeed = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            ValidateDataFeedWithMinimumSetup(updatedDataFeed, disposableDataFeed.Id, dataFeedName, description);

            Assert.That(updatedDataFeed.SourceType, Is.EqualTo(DataFeedSourceType.HttpRequest));

            ValidateHttpRequestDataSource(updatedDataFeed.DataSource as HttpRequestDataFeedSource);
        }

        [RecordedTest]
        public async Task UpdateHttpRequestDataFeedWithEveryMemberAndGetInstance()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new HttpRequestDataFeedSource(new Uri(DataSourceHost), DataSourceHeader, DataSourceMethod, DataSourcePayload);
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed dataFeedToUpdate = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            SetOptionalMembers(dataFeedToUpdate);

            await adminClient.UpdateDataFeedAsync(disposableDataFeed.Id, dataFeedToUpdate);

            DataFeed updatedDataFeed = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            ValidateUpdatedDataFeedWithOptionalMembersSet(updatedDataFeed, disposableDataFeed.Id, dataFeedName);

            Assert.That(updatedDataFeed.SourceType, Is.EqualTo(DataFeedSourceType.HttpRequest));

            ValidateHttpRequestDataSource(updatedDataFeed.DataSource as HttpRequestDataFeedSource);
        }

        [RecordedTest]
        public async Task UpdateHttpRequestDataFeedWithEveryMemberAndNewInstance()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new HttpRequestDataFeedSource(new Uri(DataSourceHost), DataSourceHeader, DataSourceMethod, DataSourcePayload);
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed dataFeedToUpdate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            SetOptionalMembers(dataFeedToUpdate);

            await adminClient.UpdateDataFeedAsync(disposableDataFeed.Id, dataFeedToUpdate);

            DataFeed updatedDataFeed = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            ValidateUpdatedDataFeedWithOptionalMembersSet(updatedDataFeed, disposableDataFeed.Id, dataFeedName);

            ValidateHttpRequestDataSource(updatedDataFeed.DataSource as HttpRequestDataFeedSource);
        }

        [RecordedTest]
        public async Task UpdateInfluxDbDataFeedWithMinimumSetupAndGetInstance()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new InfluxDbDataFeedSource(DataSourceConnectionString, DataSourceDatabase, DataSourceUsername, DataSourcePassword, DataSourceQuery);
            const string description = "This data feed was created to test the .NET client.";
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed dataFeedToUpdate = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            dataFeedToUpdate.Description = description;

            await adminClient.UpdateDataFeedAsync(disposableDataFeed.Id, dataFeedToUpdate);

            DataFeed updatedDataFeed = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            ValidateDataFeedWithMinimumSetup(updatedDataFeed, disposableDataFeed.Id, dataFeedName, description);

            Assert.That(updatedDataFeed.SourceType, Is.EqualTo(DataFeedSourceType.InfluxDb));

            ValidateInfluxDbDataSource(updatedDataFeed.DataSource as InfluxDbDataFeedSource);
        }

        [RecordedTest]
        public async Task UpdateInfluxDbDataFeedWithMinimumSetupAndNewInstance()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new InfluxDbDataFeedSource(DataSourceConnectionString, DataSourceDatabase, DataSourceUsername, DataSourcePassword, DataSourceQuery);
            const string description = "This data feed was created to test the .NET client.";
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed dataFeedToUpdate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            dataFeedToUpdate.Description = description;

            await adminClient.UpdateDataFeedAsync(disposableDataFeed.Id, dataFeedToUpdate);

            DataFeed updatedDataFeed = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            ValidateDataFeedWithMinimumSetup(updatedDataFeed, disposableDataFeed.Id, dataFeedName, description);

            Assert.That(updatedDataFeed.SourceType, Is.EqualTo(DataFeedSourceType.InfluxDb));

            ValidateInfluxDbDataSource(updatedDataFeed.DataSource as InfluxDbDataFeedSource);
        }

        [RecordedTest]
        public async Task UpdateInfluxDbDataFeedWithEveryMemberAndGetInstance()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new InfluxDbDataFeedSource(DataSourceConnectionString, DataSourceDatabase, DataSourceUsername, DataSourcePassword, DataSourceQuery);
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed dataFeedToUpdate = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            SetOptionalMembers(dataFeedToUpdate);

            await adminClient.UpdateDataFeedAsync(disposableDataFeed.Id, dataFeedToUpdate);

            DataFeed updatedDataFeed = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            ValidateUpdatedDataFeedWithOptionalMembersSet(updatedDataFeed, disposableDataFeed.Id, dataFeedName);

            Assert.That(updatedDataFeed.SourceType, Is.EqualTo(DataFeedSourceType.InfluxDb));

            ValidateInfluxDbDataSource(updatedDataFeed.DataSource as InfluxDbDataFeedSource);
        }

        [RecordedTest]
        public async Task UpdateInfluxDbDataFeedWithEveryMemberAndNewInstance()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new InfluxDbDataFeedSource(DataSourceConnectionString, DataSourceDatabase, DataSourceUsername, DataSourcePassword, DataSourceQuery);
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed dataFeedToUpdate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            SetOptionalMembers(dataFeedToUpdate);

            await adminClient.UpdateDataFeedAsync(disposableDataFeed.Id, dataFeedToUpdate);

            DataFeed updatedDataFeed = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            ValidateUpdatedDataFeedWithOptionalMembersSet(updatedDataFeed, disposableDataFeed.Id, dataFeedName);

            Assert.That(updatedDataFeed.SourceType, Is.EqualTo(DataFeedSourceType.InfluxDb));

            ValidateInfluxDbDataSource(updatedDataFeed.DataSource as InfluxDbDataFeedSource);
        }

        [RecordedTest]
        public async Task UpdateMongoDbDataFeedWithMinimumSetupAndGetInstance()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new MongoDbDataFeedSource(DataSourceConnectionString, DataSourceDatabase, DataSourceCommand);
            const string description = "This data feed was created to test the .NET client.";
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed dataFeedToUpdate = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            dataFeedToUpdate.Description = description;

            await adminClient.UpdateDataFeedAsync(disposableDataFeed.Id, dataFeedToUpdate);

            DataFeed updatedDataFeed = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            ValidateDataFeedWithMinimumSetup(updatedDataFeed, disposableDataFeed.Id, dataFeedName, description);

            Assert.That(updatedDataFeed.SourceType, Is.EqualTo(DataFeedSourceType.MongoDb));

            ValidateMongoDbDataSource(updatedDataFeed.DataSource as MongoDbDataFeedSource);
        }

        [RecordedTest]
        public async Task UpdateMongoDbDataFeedWithMinimumSetupAndNewInstance()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new MongoDbDataFeedSource(DataSourceConnectionString, DataSourceDatabase, DataSourceCommand);
            const string description = "This data feed was created to test the .NET client.";
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed dataFeedToUpdate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            dataFeedToUpdate.Description = description;

            await adminClient.UpdateDataFeedAsync(disposableDataFeed.Id, dataFeedToUpdate);

            DataFeed updatedDataFeed = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            ValidateDataFeedWithMinimumSetup(updatedDataFeed, disposableDataFeed.Id, dataFeedName, description);

            Assert.That(updatedDataFeed.SourceType, Is.EqualTo(DataFeedSourceType.MongoDb));

            ValidateMongoDbDataSource(updatedDataFeed.DataSource as MongoDbDataFeedSource);
        }

        [RecordedTest]
        public async Task UpdateMongoDbDataFeedWithEveryMemberAndGetInstance()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new MongoDbDataFeedSource(DataSourceConnectionString, DataSourceDatabase, DataSourceCommand);
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed dataFeedToUpdate = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            SetOptionalMembers(dataFeedToUpdate);

            await adminClient.UpdateDataFeedAsync(disposableDataFeed.Id, dataFeedToUpdate);

            DataFeed updatedDataFeed = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            ValidateUpdatedDataFeedWithOptionalMembersSet(updatedDataFeed, disposableDataFeed.Id, dataFeedName);

            Assert.That(updatedDataFeed.SourceType, Is.EqualTo(DataFeedSourceType.MongoDb));

            ValidateMongoDbDataSource(updatedDataFeed.DataSource as MongoDbDataFeedSource);
        }

        [RecordedTest]
        public async Task UpdateMongoDbDataFeedWithEveryMemberAndNewInstance()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new MongoDbDataFeedSource(DataSourceConnectionString, DataSourceDatabase, DataSourceCommand);
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed dataFeedToUpdate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            SetOptionalMembers(dataFeedToUpdate);

            await adminClient.UpdateDataFeedAsync(disposableDataFeed.Id, dataFeedToUpdate);

            DataFeed updatedDataFeed = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            ValidateUpdatedDataFeedWithOptionalMembersSet(updatedDataFeed, disposableDataFeed.Id, dataFeedName);

            Assert.That(updatedDataFeed.SourceType, Is.EqualTo(DataFeedSourceType.MongoDb));

            ValidateMongoDbDataSource(updatedDataFeed.DataSource as MongoDbDataFeedSource);
        }

        [RecordedTest]
        public async Task UpdateMySqlDataFeedWithMinimumSetupAndGetInstance()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new MySqlDataFeedSource(DataSourceConnectionString, DataSourceQuery);
            const string description = "This data feed was created to test the .NET client.";
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed dataFeedToUpdate = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            dataFeedToUpdate.Description = description;

            await adminClient.UpdateDataFeedAsync(disposableDataFeed.Id, dataFeedToUpdate);

            DataFeed updatedDataFeed = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            ValidateDataFeedWithMinimumSetup(updatedDataFeed, disposableDataFeed.Id, dataFeedName, description);

            Assert.That(updatedDataFeed.SourceType, Is.EqualTo(DataFeedSourceType.MySql));

            ValidateMySqlDataSource(updatedDataFeed.DataSource as MySqlDataFeedSource);
        }

        [RecordedTest]
        public async Task UpdateMySqlDataFeedWithMinimumSetupAndNewInstance()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new MySqlDataFeedSource(DataSourceConnectionString, DataSourceQuery);
            const string description = "This data feed was created to test the .NET client.";
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed dataFeedToUpdate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            dataFeedToUpdate.Description = description;

            await adminClient.UpdateDataFeedAsync(disposableDataFeed.Id, dataFeedToUpdate);

            DataFeed updatedDataFeed = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            ValidateDataFeedWithMinimumSetup(updatedDataFeed, disposableDataFeed.Id, dataFeedName, description);

            Assert.That(updatedDataFeed.SourceType, Is.EqualTo(DataFeedSourceType.MySql));

            ValidateMySqlDataSource(updatedDataFeed.DataSource as MySqlDataFeedSource);
        }

        [RecordedTest]
        public async Task UpdateMySqlDataFeedWithEveryMemberAndGetInstance()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new MySqlDataFeedSource(DataSourceConnectionString, DataSourceQuery);
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed dataFeedToUpdate = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            SetOptionalMembers(dataFeedToUpdate);

            await adminClient.UpdateDataFeedAsync(disposableDataFeed.Id, dataFeedToUpdate);

            DataFeed updatedDataFeed = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            ValidateUpdatedDataFeedWithOptionalMembersSet(updatedDataFeed, disposableDataFeed.Id, dataFeedName);

            Assert.That(updatedDataFeed.SourceType, Is.EqualTo(DataFeedSourceType.MySql));

            ValidateMySqlDataSource(updatedDataFeed.DataSource as MySqlDataFeedSource);
        }

        [RecordedTest]
        public async Task UpdateMySqlDataFeedWithEveryMemberAndNewInstance()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new MySqlDataFeedSource(DataSourceConnectionString, DataSourceQuery);
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed dataFeedToUpdate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            SetOptionalMembers(dataFeedToUpdate);

            await adminClient.UpdateDataFeedAsync(disposableDataFeed.Id, dataFeedToUpdate);

            DataFeed updatedDataFeed = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            ValidateUpdatedDataFeedWithOptionalMembersSet(updatedDataFeed, disposableDataFeed.Id, dataFeedName);

            Assert.That(updatedDataFeed.SourceType, Is.EqualTo(DataFeedSourceType.MySql));

            ValidateMySqlDataSource(updatedDataFeed.DataSource as MySqlDataFeedSource);
        }

        [RecordedTest]
        public async Task UpdatePostgreSqlDataFeedWithMinimumSetupAndGetInstance()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new PostgreSqlDataFeedSource(DataSourceConnectionString, DataSourceQuery);
            const string description = "This data feed was created to test the .NET client.";
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed dataFeedToUpdate = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            dataFeedToUpdate.Description = description;

            await adminClient.UpdateDataFeedAsync(disposableDataFeed.Id, dataFeedToUpdate);

            DataFeed updatedDataFeed = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            ValidateDataFeedWithMinimumSetup(updatedDataFeed, disposableDataFeed.Id, dataFeedName, description);

            Assert.That(updatedDataFeed.SourceType, Is.EqualTo(DataFeedSourceType.PostgreSql));

            ValidatePostgreSqlDataSource(updatedDataFeed.DataSource as PostgreSqlDataFeedSource);
        }

        [RecordedTest]
        public async Task UpdatePostgreSqlDataFeedWithMinimumSetupAndNewInstance()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new PostgreSqlDataFeedSource(DataSourceConnectionString, DataSourceQuery);
            const string description = "This data feed was created to test the .NET client.";
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed dataFeedToUpdate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            dataFeedToUpdate.Description = description;

            await adminClient.UpdateDataFeedAsync(disposableDataFeed.Id, dataFeedToUpdate);

            DataFeed updatedDataFeed = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            ValidateDataFeedWithMinimumSetup(updatedDataFeed, disposableDataFeed.Id, dataFeedName, description);

            Assert.That(updatedDataFeed.SourceType, Is.EqualTo(DataFeedSourceType.PostgreSql));

            ValidatePostgreSqlDataSource(updatedDataFeed.DataSource as PostgreSqlDataFeedSource);
        }

        [RecordedTest]
        public async Task UpdatePostgreSqlDataFeedWithEveryMemberAndGetInstance()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new PostgreSqlDataFeedSource(DataSourceConnectionString, DataSourceQuery);
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed dataFeedToUpdate = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            SetOptionalMembers(dataFeedToUpdate);

            await adminClient.UpdateDataFeedAsync(disposableDataFeed.Id, dataFeedToUpdate);

            DataFeed updatedDataFeed = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            ValidateUpdatedDataFeedWithOptionalMembersSet(updatedDataFeed, disposableDataFeed.Id, dataFeedName);

            Assert.That(updatedDataFeed.SourceType, Is.EqualTo(DataFeedSourceType.PostgreSql));

            ValidatePostgreSqlDataSource(updatedDataFeed.DataSource as PostgreSqlDataFeedSource);
        }

        [RecordedTest]
        public async Task UpdatePostgreSqlDataFeedWithEveryMemberAndNewInstance()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new PostgreSqlDataFeedSource(DataSourceConnectionString, DataSourceQuery);
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed dataFeedToUpdate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            SetOptionalMembers(dataFeedToUpdate);

            await adminClient.UpdateDataFeedAsync(disposableDataFeed.Id, dataFeedToUpdate);

            DataFeed updatedDataFeed = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            ValidateUpdatedDataFeedWithOptionalMembersSet(updatedDataFeed, disposableDataFeed.Id, dataFeedName);

            Assert.That(updatedDataFeed.SourceType, Is.EqualTo(DataFeedSourceType.PostgreSql));

            ValidatePostgreSqlDataSource(updatedDataFeed.DataSource as PostgreSqlDataFeedSource);
        }

        [RecordedTest]
        public async Task UpdateSqlServerDataFeedWithMinimumSetupAndGetInstance()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new SqlServerDataFeedSource(DataSourceConnectionString, DataSourceQuery);
            const string description = "This data feed was created to test the .NET client.";
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed dataFeedToUpdate = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            dataFeedToUpdate.Description = description;

            await adminClient.UpdateDataFeedAsync(disposableDataFeed.Id, dataFeedToUpdate);

            DataFeed updatedDataFeed = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            ValidateDataFeedWithMinimumSetup(updatedDataFeed, disposableDataFeed.Id, dataFeedName, description);

            Assert.That(updatedDataFeed.SourceType, Is.EqualTo(DataFeedSourceType.SqlServer));

            ValidateSqlServerDataSource(updatedDataFeed.DataSource as SqlServerDataFeedSource);
        }

        [RecordedTest]
        public async Task UpdateSqlServerDataFeedWithMinimumSetupAndNewInstance()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new SqlServerDataFeedSource(DataSourceConnectionString, DataSourceQuery);
            const string description = "This data feed was created to test the .NET client.";
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed dataFeedToUpdate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            dataFeedToUpdate.Description = description;

            await adminClient.UpdateDataFeedAsync(disposableDataFeed.Id, dataFeedToUpdate);

            DataFeed updatedDataFeed = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            ValidateDataFeedWithMinimumSetup(updatedDataFeed, disposableDataFeed.Id, dataFeedName, description);

            Assert.That(updatedDataFeed.SourceType, Is.EqualTo(DataFeedSourceType.SqlServer));

            ValidateSqlServerDataSource(updatedDataFeed.DataSource as SqlServerDataFeedSource);
        }

        [RecordedTest]
        public async Task UpdateSqlServerDataFeedWithEveryMemberAndGetInstance()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new SqlServerDataFeedSource(DataSourceConnectionString, DataSourceQuery);
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed dataFeedToUpdate = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            SetOptionalMembers(dataFeedToUpdate);

            await adminClient.UpdateDataFeedAsync(disposableDataFeed.Id, dataFeedToUpdate);

            DataFeed updatedDataFeed = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            ValidateUpdatedDataFeedWithOptionalMembersSet(updatedDataFeed, disposableDataFeed.Id, dataFeedName);

            Assert.That(updatedDataFeed.SourceType, Is.EqualTo(DataFeedSourceType.SqlServer));

            ValidateSqlServerDataSource(updatedDataFeed.DataSource as SqlServerDataFeedSource);
        }

        [RecordedTest]
        public async Task UpdateSqlServerDataFeedWithEveryMemberAndNewInstance()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new SqlServerDataFeedSource(DataSourceConnectionString, DataSourceQuery);
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed dataFeedToUpdate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            SetOptionalMembers(dataFeedToUpdate);

            await adminClient.UpdateDataFeedAsync(disposableDataFeed.Id, dataFeedToUpdate);

            DataFeed updatedDataFeed = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            ValidateUpdatedDataFeedWithOptionalMembersSet(updatedDataFeed, disposableDataFeed.Id, dataFeedName);

            Assert.That(updatedDataFeed.SourceType, Is.EqualTo(DataFeedSourceType.SqlServer));

            ValidateSqlServerDataSource(updatedDataFeed.DataSource as SqlServerDataFeedSource);
        }

        [RecordedTest]
        public async Task GetDataFeeds()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var dataFeedCount = 0;

            await foreach (DataFeed dataFeed in adminClient.GetDataFeedsAsync())
            {
                Assert.That(dataFeed.Id, Is.Not.Null.And.Not.Empty);
                Assert.That(dataFeed.Name, Is.Not.Null.And.Not.Empty);
                Assert.That(dataFeed.Description, Is.Not.Null);
                Assert.That(dataFeed.Status, Is.Not.Null);
                Assert.That(dataFeed.Status, Is.Not.EqualTo(default(DataFeedStatus)));
                Assert.That(dataFeed.AccessMode, Is.Not.Null);
                Assert.That(dataFeed.AccessMode, Is.Not.EqualTo(default(DataFeedAccessMode)));
                Assert.That(dataFeed.ActionLinkTemplate, Is.Not.Null);
                Assert.That(dataFeed.Creator, Is.Not.Null.And.Not.Empty);
                Assert.That(dataFeed.Administrators, Is.Not.Null);
                Assert.That(dataFeed.Viewers, Is.Not.Null);
                Assert.That(dataFeed.IsAdministrator, Is.Not.Null);
                Assert.That(dataFeed.CreatedTime, Is.Not.Null);
                Assert.That(dataFeed.CreatedTime, Is.Not.EqualTo(default(DateTimeOffset)));

                Assert.That(dataFeed.MissingDataPointFillSettings, Is.Not.Null);
                Assert.That(dataFeed.MissingDataPointFillSettings.FillType, Is.Not.Null);
                Assert.That(dataFeed.MissingDataPointFillSettings.FillType, Is.Not.EqualTo(default(DataFeedMissingDataPointFillType)));

                if (dataFeed.MissingDataPointFillSettings.FillType == DataFeedMissingDataPointFillType.CustomValue)
                {
                    Assert.That(dataFeed.MissingDataPointFillSettings.CustomFillValue, Is.Not.Null);
                }
                else
                {
                    Assert.That(dataFeed.MissingDataPointFillSettings.CustomFillValue, Is.Null);
                }

                Assert.That(dataFeed.Granularity, Is.Not.Null);
                Assert.That(dataFeed.Granularity.GranularityType, Is.Not.EqualTo(default(DataFeedGranularityType)));

                if (dataFeed.Granularity.GranularityType == DataFeedGranularityType.Custom)
                {
                    Assert.That(dataFeed.Granularity.CustomGranularityValue, Is.Not.Null);
                }
                else
                {
                    Assert.That(dataFeed.Granularity.CustomGranularityValue, Is.Null);
                }

                Assert.That(dataFeed.Schema, Is.Not.Null);
                Assert.That(dataFeed.Schema.MetricColumns, Is.Not.Null);

                foreach (DataFeedMetric metric in dataFeed.Schema.MetricColumns)
                {
                    Assert.That(metric, Is.Not.Null);
                    Assert.That(metric.MetricId, Is.Not.Null.And.Not.Empty);
                    Assert.That(metric.MetricName, Is.Not.Null.And.Not.Empty);
                    Assert.That(metric.MetricDisplayName, Is.Not.Null.And.Not.Empty);
                    Assert.That(metric.MetricDescription, Is.Not.Null);
                }

                Assert.That(dataFeed.Schema.DimensionColumns, Is.Not.Null);

                foreach (DataFeedDimension dimensionColumn in dataFeed.Schema.DimensionColumns)
                {
                    Assert.That(dimensionColumn, Is.Not.Null);
                    Assert.That(dimensionColumn.DimensionName, Is.Not.Null.And.Not.Empty);
                    Assert.That(dimensionColumn.DimensionDisplayName, Is.Not.Null.And.Not.Empty);
                }

                Assert.That(dataFeed.Schema.TimestampColumn, Is.Not.Null);

                Assert.That(dataFeed.IngestionSettings, Is.Not.Null);
                Assert.That(dataFeed.IngestionSettings.IngestionStartTime, Is.Not.EqualTo(default(DateTimeOffset)));
                Assert.That(dataFeed.IngestionSettings.IngestionStartOffset, Is.Not.Null);
                Assert.That(dataFeed.IngestionSettings.IngestionRetryDelay, Is.Not.Null);
                Assert.That(dataFeed.IngestionSettings.StopRetryAfter, Is.Not.Null);
                Assert.That(dataFeed.IngestionSettings.DataSourceRequestConcurrency, Is.Not.Null);

                ValidateGenericDataSource(dataFeed.DataSource, dataFeed.SourceType, dataFeed.IsAdministrator.Value);

                if (++dataFeedCount >= MaximumSamplesCount)
                {
                    break;
                }
            }

            Assert.That(dataFeedCount, Is.GreaterThan(0));
        }

        [RecordedTest]
        public async Task DeleteDataFeed()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new SqlServerDataFeedSource("connectionStr", "query");
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            string dataFeedId = null;

            try
            {
                dataFeedId = await adminClient.CreateDataFeedAsync(dataFeedToCreate);

                Assert.That(dataFeedId, Is.Not.Null.And.Not.Empty);
            }
            finally
            {
                if (dataFeedId != null)
                {
                    await adminClient.DeleteDataFeedAsync(dataFeedId);

                    var errorCause = "datafeedId is invalid";
                    Assert.That(async () => await adminClient.GetDataFeedAsync(dataFeedId), Throws.InstanceOf<RequestFailedException>().With.Message.Contains(errorCause));
                }
            }
        }

        private DataFeed GetDataFeedWithMinimumSetup(string name, DataFeedSource dataSource)
        {
            var metrics = new List<DataFeedMetric>() { new ("cost") };
            var ingestionStartTime = DateTimeOffset.Parse("2020-08-01T00:00:00Z");

            var granularity = new DataFeedGranularity(DataFeedGranularityType.Daily);
            var schema = new DataFeedSchema(metrics);
            var ingestionSettings = new DataFeedIngestionSettings(ingestionStartTime);

            return new DataFeed(name, dataSource, granularity, schema, ingestionSettings);
        }

        private DataFeed GetDataFeedWithOptionalMembersSet(string name, DataFeedSource dataSource)
        {
            var metrics = new List<DataFeedMetric>()
            {
                new ("cost") { MetricDisplayName = "costDisplayName", MetricDescription = "costDescription" },
                new ("revenue") { MetricDisplayName = "revenueDisplayName", MetricDescription = "revenueDescription" }
            };
            var dimensionColumns = new List<DataFeedDimension>()
            {
                new ("city"),
                new ("category") { DimensionDisplayName = "categoryDisplayName" }
            };
            var ingestionStartTime = DateTimeOffset.Parse("2020-08-01T00:00:00Z");

            var granularity = new DataFeedGranularity(DataFeedGranularityType.Custom) { CustomGranularityValue = 1360 };
            var schema = new DataFeedSchema(metrics) { DimensionColumns = dimensionColumns, TimestampColumn = "timestamp" };
            var ingestionSettings = new DataFeedIngestionSettings(ingestionStartTime)
            {
                IngestionStartOffset = TimeSpan.FromMinutes(30),
                IngestionRetryDelay = TimeSpan.FromSeconds(80),
                StopRetryAfter = TimeSpan.FromMinutes(10),
                DataSourceRequestConcurrency = 5
            };

            return new DataFeed(name, dataSource, granularity, schema, ingestionSettings)
            {
                Description = "This data feed was created to test the .NET client.",
                AccessMode = DataFeedAccessMode.Public,
                ActionLinkTemplate = "https://fakeurl.com/%metric/%datafeed",
                Administrators = new List<string>() { "fake@admin.com" },
                Viewers = new List<string>() { "fake@viewer.com" },
                MissingDataPointFillSettings = new () { FillType = DataFeedMissingDataPointFillType.CustomValue, CustomFillValue = 45.0 }
            };
        }

        private void SetOptionalMembers(DataFeed dataFeed)
        {
            dataFeed.Description = "This data feed was updated to test the .NET client.";
            dataFeed.AccessMode = DataFeedAccessMode.Public;
            dataFeed.ActionLinkTemplate = "https://fakeurl.com/%datafeed/%metric";
            // TODO: add administrator update validation. Related: https://github.com/Azure/azure-sdk-for-net/issues/17766
            dataFeed.Viewers.Add("fake@viewer.com");

            dataFeed.Schema.TimestampColumn = "updatedTimestampColumn";

            dataFeed.IngestionSettings.IngestionStartOffset = TimeSpan.FromMinutes(40);
            dataFeed.IngestionSettings.IngestionRetryDelay = TimeSpan.FromSeconds(90);
            dataFeed.IngestionSettings.StopRetryAfter = TimeSpan.FromMinutes(20);
            dataFeed.IngestionSettings.DataSourceRequestConcurrency = 6;

            dataFeed.MissingDataPointFillSettings = new ()
            {
                FillType = DataFeedMissingDataPointFillType.NoFilling
            };
        }

        private void ValidateDataFeedWithMinimumSetup(DataFeed dataFeed, string expectedId, string expectedName, string expectedDescription = "")
        {
            var ingestionStartTime = DateTimeOffset.Parse("2020-08-01T00:00:00Z");

            Assert.That(dataFeed.Id, Is.EqualTo(expectedId));
            Assert.That(dataFeed.Name, Is.EqualTo(expectedName));
            Assert.That(dataFeed.Description, Is.EqualTo(expectedDescription));
            Assert.That(dataFeed.Status, Is.EqualTo(DataFeedStatus.Active));
            Assert.That(dataFeed.AccessMode, Is.EqualTo(DataFeedAccessMode.Private));
            Assert.That(dataFeed.ActionLinkTemplate, Is.Not.Null.And.Empty);
            Assert.That(dataFeed.Creator, Is.Not.Null.And.Not.Empty);
            Assert.That(dataFeed.Administrators, Is.Not.Null);
            Assert.That(dataFeed.Administrators.Single(), Is.EqualTo(dataFeed.Creator));
            Assert.That(dataFeed.Viewers, Is.Not.Null.And.Empty);
            Assert.That(dataFeed.IsAdministrator, Is.True);

            DateTimeOffset justNow = Recording.UtcNow.Subtract(TimeSpan.FromMinutes(5));
            Assert.That(dataFeed.CreatedTime, Is.GreaterThan(justNow));

            Assert.That(dataFeed.MissingDataPointFillSettings, Is.Not.Null);
            Assert.That(dataFeed.MissingDataPointFillSettings.FillType, Is.EqualTo(DataFeedMissingDataPointFillType.PreviousValue));
            Assert.That(dataFeed.MissingDataPointFillSettings.CustomFillValue, Is.Null);

            Assert.That(dataFeed.Granularity, Is.Not.Null);
            Assert.That(dataFeed.Granularity.GranularityType, Is.EqualTo(DataFeedGranularityType.Daily));
            Assert.That(dataFeed.Granularity.CustomGranularityValue, Is.Null);

            Assert.That(dataFeed.Schema, Is.Not.Null);
            Assert.That(dataFeed.Schema.MetricColumns, Is.Not.Null);

            DataFeedMetric metric = dataFeed.Schema.MetricColumns.Single();

            Assert.That(metric, Is.Not.Null);
            Assert.That(metric.MetricId, Is.Not.Null.And.Not.Empty);
            Assert.That(metric.MetricName, Is.EqualTo("cost"));
            Assert.That(metric.MetricDisplayName, Is.EqualTo("cost"));
            Assert.That(metric.MetricDescription, Is.Empty);

            Assert.That(dataFeed.Schema.DimensionColumns, Is.Not.Null.And.Empty);
            Assert.That(dataFeed.Schema.TimestampColumn, Is.Empty);

            Assert.That(dataFeed.IngestionSettings, Is.Not.Null);
            Assert.That(dataFeed.IngestionSettings.IngestionStartTime, Is.EqualTo(ingestionStartTime));
            Assert.That(dataFeed.IngestionSettings.IngestionStartOffset, Is.EqualTo(TimeSpan.Zero));
            Assert.That(dataFeed.IngestionSettings.IngestionRetryDelay, Is.EqualTo(TimeSpan.FromSeconds(-1)));
            Assert.That(dataFeed.IngestionSettings.StopRetryAfter, Is.EqualTo(TimeSpan.FromSeconds(-1)));
            Assert.That(dataFeed.IngestionSettings.DataSourceRequestConcurrency, Is.EqualTo(-1));
        }

        private void ValidateDataFeedWithOptionalMembersSet(DataFeed dataFeed, string expectedId, string expectedName)
        {
            var ingestionStartTime = DateTimeOffset.Parse("2020-08-01T00:00:00Z");

            Assert.That(dataFeed.Id, Is.EqualTo(expectedId));
            Assert.That(dataFeed.Name, Is.EqualTo(expectedName));
            Assert.That(dataFeed.Description, Is.EqualTo("This data feed was created to test the .NET client."));
            Assert.That(dataFeed.Status, Is.EqualTo(DataFeedStatus.Active));
            Assert.That(dataFeed.AccessMode, Is.EqualTo(DataFeedAccessMode.Public));
            Assert.That(dataFeed.ActionLinkTemplate, Is.EqualTo("https://fakeurl.com/%metric/%datafeed"));
            Assert.That(dataFeed.Creator, Is.Not.Null.And.Not.Empty);

            // TODO: https://github.com/Azure/azure-sdk-for-net/issues/17719
            Assert.That(dataFeed.Administrators, Is.Not.Null);
            Assert.That(dataFeed.Administrators.Count, Is.EqualTo(1));
            Assert.That(dataFeed.Administrators, Contains.Item(dataFeed.Creator));
            Assert.That(dataFeed.Viewers, Is.Not.Null.And.Empty);
            Assert.That(dataFeed.IsAdministrator, Is.True);

            DateTimeOffset justNow = Recording.UtcNow.Subtract(TimeSpan.FromMinutes(5));
            Assert.That(dataFeed.CreatedTime, Is.GreaterThan(justNow));

            Assert.That(dataFeed.MissingDataPointFillSettings, Is.Not.Null);
            Assert.That(dataFeed.MissingDataPointFillSettings.FillType, Is.EqualTo(DataFeedMissingDataPointFillType.CustomValue));
            Assert.That(dataFeed.MissingDataPointFillSettings.CustomFillValue, Is.EqualTo(45.0));

            Assert.That(dataFeed.Granularity, Is.Not.Null);
            Assert.That(dataFeed.Granularity.GranularityType, Is.EqualTo(DataFeedGranularityType.Custom));
            Assert.That(dataFeed.Granularity.CustomGranularityValue, Is.EqualTo(1360));

            Assert.That(dataFeed.Schema, Is.Not.Null);
            Assert.That(dataFeed.Schema.MetricColumns, Is.Not.Null);
            Assert.That(dataFeed.Schema.MetricColumns.Count, Is.EqualTo(2));

            DataFeedMetric metric0 = dataFeed.Schema.MetricColumns[0];
            DataFeedMetric metric1 = dataFeed.Schema.MetricColumns[1];

            Assert.That(metric0, Is.Not.Null);
            Assert.That(metric0.MetricId, Is.Not.Null.And.Not.Empty);
            Assert.That(metric0.MetricName, Is.EqualTo("cost"));
            Assert.That(metric0.MetricDisplayName, Is.EqualTo("costDisplayName"));
            Assert.That(metric0.MetricDescription, Is.EqualTo("costDescription"));

            Assert.That(metric1, Is.Not.Null);
            Assert.That(metric1.MetricId, Is.Not.Null.And.Not.Empty);
            Assert.That(metric1.MetricName, Is.EqualTo("revenue"));
            Assert.That(metric1.MetricDisplayName, Is.EqualTo("revenueDisplayName"));
            Assert.That(metric1.MetricDescription, Is.EqualTo("revenueDescription"));

            Assert.That(dataFeed.Schema.DimensionColumns, Is.Not.Null);
            Assert.That(dataFeed.Schema.DimensionColumns.Count, Is.EqualTo(2));

            var sortedDimensionColumns = dataFeed.Schema.DimensionColumns.OrderBy(column => column.DimensionName).ToList();

            Assert.That(sortedDimensionColumns[0].DimensionName, Is.EqualTo("category"));
            Assert.That(sortedDimensionColumns[0].DimensionDisplayName, Is.EqualTo("categoryDisplayName"));
            Assert.That(sortedDimensionColumns[1].DimensionName, Is.EqualTo("city"));
            Assert.That(sortedDimensionColumns[1].DimensionDisplayName, Is.EqualTo("city"));
            Assert.That(dataFeed.Schema.TimestampColumn, Is.EqualTo("timestamp"));

            Assert.That(dataFeed.IngestionSettings, Is.Not.Null);
            Assert.That(dataFeed.IngestionSettings.IngestionStartTime, Is.EqualTo(ingestionStartTime));
            Assert.That(dataFeed.IngestionSettings.IngestionStartOffset, Is.EqualTo(TimeSpan.FromMinutes(30)));
            Assert.That(dataFeed.IngestionSettings.IngestionRetryDelay, Is.EqualTo(TimeSpan.FromSeconds(80)));
            Assert.That(dataFeed.IngestionSettings.StopRetryAfter, Is.EqualTo(TimeSpan.FromMinutes(10)));
            Assert.That(dataFeed.IngestionSettings.DataSourceRequestConcurrency, Is.EqualTo(5));
        }

        private void ValidateUpdatedDataFeedWithOptionalMembersSet(DataFeed dataFeed, string expectedId, string expectedName)
        {
            var ingestionStartTime = DateTimeOffset.Parse("2020-08-01T00:00:00Z");

            Assert.That(dataFeed.Id, Is.EqualTo(expectedId));
            Assert.That(dataFeed.Name, Is.EqualTo(expectedName));
            Assert.That(dataFeed.Description, Is.EqualTo("This data feed was updated to test the .NET client."));
            Assert.That(dataFeed.Status, Is.EqualTo(DataFeedStatus.Active));
            Assert.That(dataFeed.AccessMode, Is.EqualTo(DataFeedAccessMode.Public));
            Assert.That(dataFeed.ActionLinkTemplate, Is.EqualTo("https://fakeurl.com/%datafeed/%metric"));
            Assert.That(dataFeed.Creator, Is.Not.Null.And.Not.Empty);

            Assert.That(dataFeed.Administrators, Is.Not.Null);
            Assert.That(dataFeed.Administrators.Count, Is.EqualTo(1));
            Assert.That(dataFeed.Administrators, Contains.Item(dataFeed.Creator));

            Assert.That(dataFeed.Viewers, Is.Not.Null);
            Assert.That(dataFeed.Viewers.Count, Is.EqualTo(1));
            Assert.That(dataFeed.Viewers, Contains.Item("fake@viewer.com"));

            DateTimeOffset justNow = Recording.UtcNow.Subtract(TimeSpan.FromMinutes(5));
            Assert.That(dataFeed.CreatedTime, Is.GreaterThan(justNow));

            Assert.That(dataFeed.MissingDataPointFillSettings, Is.Not.Null);
            Assert.That(dataFeed.MissingDataPointFillSettings.FillType, Is.EqualTo(DataFeedMissingDataPointFillType.NoFilling));
            Assert.That(dataFeed.MissingDataPointFillSettings.CustomFillValue, Is.Null);

            Assert.That(dataFeed.Granularity, Is.Not.Null);
            Assert.That(dataFeed.Granularity.GranularityType, Is.EqualTo(DataFeedGranularityType.Daily));
            Assert.That(dataFeed.Granularity.CustomGranularityValue, Is.Null);

            Assert.That(dataFeed.Schema, Is.Not.Null);
            Assert.That(dataFeed.Schema.MetricColumns, Is.Not.Null);

            DataFeedMetric metric = dataFeed.Schema.MetricColumns.Single();

            Assert.That(metric, Is.Not.Null);
            Assert.That(metric.MetricId, Is.Not.Null.And.Not.Empty);
            Assert.That(metric.MetricName, Is.EqualTo("cost"));
            Assert.That(metric.MetricDisplayName, Is.EqualTo("cost"));
            Assert.That(metric.MetricDescription, Is.Empty);

            Assert.That(dataFeed.Schema.DimensionColumns, Is.Not.Null.And.Empty);
            Assert.That(dataFeed.Schema.TimestampColumn, Is.EqualTo("updatedTimestampColumn"));

            Assert.That(dataFeed.IngestionSettings, Is.Not.Null);
            Assert.That(dataFeed.IngestionSettings.IngestionStartTime, Is.EqualTo(ingestionStartTime));
            Assert.That(dataFeed.IngestionSettings.IngestionStartOffset, Is.EqualTo(TimeSpan.FromMinutes(40)));
            Assert.That(dataFeed.IngestionSettings.IngestionRetryDelay, Is.EqualTo(TimeSpan.FromSeconds(90)));
            Assert.That(dataFeed.IngestionSettings.StopRetryAfter, Is.EqualTo(TimeSpan.FromMinutes(20)));
            Assert.That(dataFeed.IngestionSettings.DataSourceRequestConcurrency, Is.EqualTo(6));
        }

        private void ValidateAzureApplicationInsightsDataSource(AzureApplicationInsightsDataFeedSource dataSource)
        {
            var expectedKey = TestEnvironment.Mode == RecordedTestMode.Playback ? "Sanitized" : DataSourceKey;

            Assert.That(dataSource, Is.Not.Null);
            Assert.That(dataSource.ApplicationId, Is.EqualTo(DataSourceAppId));
            Assert.That(dataSource.ApiKey, Is.EqualTo(expectedKey));
            Assert.That(dataSource.AzureCloud, Is.EqualTo(DataSourceCloud));
            Assert.That(dataSource.Query, Is.EqualTo(DataSourceQuery));
        }

        private void ValidateAzureBlobDataSource(AzureBlobDataFeedSource dataSource)
        {
            var expectedConnectStr = TestEnvironment.Mode == RecordedTestMode.Playback ? "Sanitized" : DataSourceConnectionString;

            Assert.That(dataSource, Is.Not.Null);
            Assert.That(dataSource.ConnectionString, Is.EqualTo(expectedConnectStr));
            Assert.That(dataSource.Container, Is.EqualTo(DataSourceContainer));
            Assert.That(dataSource.BlobTemplate, Is.EqualTo(DataSourceTemplate));
        }

        private void ValidateAzureCosmosDbDataSource(AzureCosmosDbDataFeedSource dataSource)
        {
            var expectedConnectStr = TestEnvironment.Mode == RecordedTestMode.Playback ? "Sanitized" : DataSourceConnectionString;

            Assert.That(dataSource, Is.Not.Null);
            Assert.That(dataSource.ConnectionString, Is.EqualTo(expectedConnectStr));
            Assert.That(dataSource.SqlQuery, Is.EqualTo(DataSourceQuery));
            Assert.That(dataSource.Database, Is.EqualTo(DataSourceDatabase));
            Assert.That(dataSource.CollectionId, Is.EqualTo(DataSourceCollectionId));
        }

        private void ValidateAzureDataExplorerDataSource(AzureDataExplorerDataFeedSource dataSource)
        {
            var expectedConnectStr = TestEnvironment.Mode == RecordedTestMode.Playback ? "Sanitized" : DataSourceConnectionString;

            Assert.That(dataSource, Is.Not.Null);
            Assert.That(dataSource.ConnectionString, Is.EqualTo(expectedConnectStr));
            Assert.That(dataSource.Query, Is.EqualTo(DataSourceQuery));
        }

        private void ValidateAzureDataLakeStorageGen2DataSource(AzureDataLakeStorageGen2DataFeedSource dataSource)
        {
            var expectedKey = TestEnvironment.Mode == RecordedTestMode.Playback ? "Sanitized" : DataSourceKey;

            Assert.That(dataSource, Is.Not.Null);
            Assert.That(dataSource.AccountName, Is.EqualTo(DataSourceAccount));
            Assert.That(dataSource.AccountKey, Is.EqualTo(expectedKey));
            Assert.That(dataSource.FileSystemName, Is.EqualTo(DataSourceFileSystem));
            Assert.That(dataSource.DirectoryTemplate, Is.EqualTo(DataSourceDirectory));
            Assert.That(dataSource.FileTemplate, Is.EqualTo(DataSourceFile));
        }

        private void ValidateAzureTableDataSource(AzureTableDataFeedSource dataSource)
        {
            var expectedConnectStr = TestEnvironment.Mode == RecordedTestMode.Playback ? "Sanitized" : DataSourceConnectionString;

            Assert.That(dataSource, Is.Not.Null);
            Assert.That(dataSource.ConnectionString, Is.EqualTo(expectedConnectStr));
            Assert.That(dataSource.Table, Is.EqualTo(DataSourceTable));
            Assert.That(dataSource.Query, Is.EqualTo(DataSourceQuery));
        }

        private void ValidateElasticsearchDataSource(ElasticsearchDataFeedSource dataSource)
        {
            var expectedAuth = TestEnvironment.Mode == RecordedTestMode.Playback ? "Sanitized" : DataSourceAuth;

            Assert.That(dataSource, Is.Not.Null);
            Assert.That(dataSource.Host, Is.EqualTo(DataSourceHost));
            Assert.That(dataSource.Port, Is.EqualTo(DataSourcePort));
            Assert.That(dataSource.AuthorizationHeader, Is.EqualTo(expectedAuth));
            Assert.That(dataSource.Query, Is.EqualTo(DataSourceQuery));
        }

        private void ValidateHttpRequestDataSource(HttpRequestDataFeedSource dataSource)
        {
            var expectedHeader = TestEnvironment.Mode == RecordedTestMode.Playback ? "Sanitized" : DataSourceHeader;

            Assert.That(dataSource, Is.Not.Null);
            Assert.That(dataSource.Url.AbsoluteUri, Is.EqualTo(DataSourceHost));
            Assert.That(dataSource.HttpHeader, Is.EqualTo(expectedHeader));
            Assert.That(dataSource.HttpMethod, Is.EqualTo(DataSourceMethod));
            Assert.That(dataSource.Payload, Is.EqualTo(DataSourcePayload));
        }

        private void ValidateInfluxDbDataSource(InfluxDbDataFeedSource dataSource)
        {
            var expectedConnectStr = TestEnvironment.Mode == RecordedTestMode.Playback ? "Sanitized" : DataSourceConnectionString;

            Assert.That(dataSource, Is.Not.Null);
            Assert.That(dataSource.ConnectionString, Is.EqualTo(expectedConnectStr));
            Assert.That(dataSource.Database, Is.EqualTo(DataSourceDatabase));
            Assert.That(dataSource.Username, Is.EqualTo(DataSourceUsername));
            Assert.That(dataSource.Password, Is.EqualTo(DataSourcePassword));
            Assert.That(dataSource.Query, Is.EqualTo(DataSourceQuery));
        }

        private void ValidateMongoDbDataSource(MongoDbDataFeedSource dataSource)
        {
            var expectedConnectStr = TestEnvironment.Mode == RecordedTestMode.Playback ? "Sanitized" : DataSourceConnectionString;

            Assert.That(dataSource, Is.Not.Null);
            Assert.That(dataSource.ConnectionString, Is.EqualTo(expectedConnectStr));
            Assert.That(dataSource.Database, Is.EqualTo(DataSourceDatabase));
            Assert.That(dataSource.Command, Is.EqualTo(DataSourceCommand));
        }

        private void ValidateMySqlDataSource(MySqlDataFeedSource dataSource)
        {
            var expectedConnectStr = TestEnvironment.Mode == RecordedTestMode.Playback ? "Sanitized" : DataSourceConnectionString;

            Assert.That(dataSource, Is.Not.Null);
            Assert.That(dataSource.ConnectionString, Is.EqualTo(expectedConnectStr));
            Assert.That(dataSource.Query, Is.EqualTo(DataSourceQuery));
        }

        private void ValidatePostgreSqlDataSource(PostgreSqlDataFeedSource dataSource)
        {
            var expectedConnectStr = TestEnvironment.Mode == RecordedTestMode.Playback ? "Sanitized" : DataSourceConnectionString;

            Assert.That(dataSource, Is.Not.Null);
            Assert.That(dataSource.ConnectionString, Is.EqualTo(expectedConnectStr));
            Assert.That(dataSource.Query, Is.EqualTo(DataSourceQuery));
        }

        private void ValidateSqlServerDataSource(SqlServerDataFeedSource dataSource)
        {
            var expectedConnectStr = TestEnvironment.Mode == RecordedTestMode.Playback ? "Sanitized" : DataSourceConnectionString;

            Assert.That(dataSource, Is.Not.Null);
            Assert.That(dataSource.ConnectionString, Is.EqualTo(expectedConnectStr));
            Assert.That(dataSource.Query, Is.EqualTo(DataSourceQuery));
        }

        private void ValidateGenericDataSource(DataFeedSource dataSource, DataFeedSourceType sourceType, bool isAdmin)
        {
            if (sourceType == DataFeedSourceType.AzureApplicationInsights)
            {
                var specificDataSource = dataSource as AzureApplicationInsightsDataFeedSource;

                Assert.That(specificDataSource, Is.Not.Null);

                if (isAdmin)
                {
                    Assert.That(specificDataSource.ApplicationId, Is.Not.Null.And.Not.Empty);
                    Assert.That(specificDataSource.ApiKey, Is.Not.Null.And.Not.Empty);
                    Assert.That(specificDataSource.AzureCloud, Is.Not.Null.And.Not.Empty);
                    Assert.That(specificDataSource.Query, Is.Not.Null.And.Not.Empty);
                }
                else
                {
                    Assert.That(specificDataSource.ApplicationId, Is.Null);
                    Assert.That(specificDataSource.ApiKey, Is.Null);
                    Assert.That(specificDataSource.AzureCloud, Is.Null);
                    Assert.That(specificDataSource.Query, Is.Null);
                }
            }
            else if (sourceType == DataFeedSourceType.AzureBlob)
            {
                var specificDataSource = dataSource as AzureBlobDataFeedSource;

                Assert.That(specificDataSource, Is.Not.Null);

                if (isAdmin)
                {
                    Assert.That(specificDataSource.ConnectionString, Is.Not.Null.And.Not.Empty);
                    Assert.That(specificDataSource.Container, Is.Not.Null.And.Not.Empty);
                    Assert.That(specificDataSource.BlobTemplate, Is.Not.Null.And.Not.Empty);
                }
                else
                {
                    Assert.That(specificDataSource.ConnectionString, Is.Null);
                    Assert.That(specificDataSource.Container, Is.Null);
                    Assert.That(specificDataSource.BlobTemplate, Is.Null);
                }
            }
            else if (sourceType == DataFeedSourceType.AzureCosmosDb)
            {
                var specificDataSource = dataSource as AzureCosmosDbDataFeedSource;

                Assert.That(specificDataSource, Is.Not.Null);

                if (isAdmin)
                {
                    Assert.That(specificDataSource.ConnectionString, Is.Not.Null.And.Not.Empty);
                    Assert.That(specificDataSource.SqlQuery, Is.Not.Null.And.Not.Empty);
                    Assert.That(specificDataSource.Database, Is.Not.Null.And.Not.Empty);
                    Assert.That(specificDataSource.CollectionId, Is.Not.Null.And.Not.Empty);
                }
                else
                {
                    Assert.That(specificDataSource.ConnectionString, Is.Null);
                    Assert.That(specificDataSource.SqlQuery, Is.Null);
                    Assert.That(specificDataSource.Database, Is.Null);
                    Assert.That(specificDataSource.CollectionId, Is.Null);
                }
            }
            else if (sourceType == DataFeedSourceType.AzureDataExplorer)
            {
                var specificDataSource = dataSource as AzureDataExplorerDataFeedSource;

                Assert.That(specificDataSource, Is.Not.Null);

                if (isAdmin)
                {
                    Assert.That(specificDataSource.ConnectionString, Is.Not.Null.And.Not.Empty);
                    Assert.That(specificDataSource.Query, Is.Not.Null.And.Not.Empty);
                }
                else
                {
                    Assert.That(specificDataSource.ConnectionString, Is.Null);
                    Assert.That(specificDataSource.Query, Is.Null);
                }
            }
            else if (sourceType == DataFeedSourceType.AzureDataLakeStorageGen2)
            {
                var specificDataSource = dataSource as AzureDataLakeStorageGen2DataFeedSource;

                Assert.That(specificDataSource, Is.Not.Null);

                if (isAdmin)
                {
                    Assert.That(specificDataSource.AccountName, Is.Not.Null.And.Not.Empty);
                    Assert.That(specificDataSource.AccountKey, Is.Not.Null.And.Not.Empty);
                    Assert.That(specificDataSource.FileSystemName, Is.Not.Null.And.Not.Empty);
                    Assert.That(specificDataSource.DirectoryTemplate, Is.Not.Null.And.Not.Empty);
                    Assert.That(specificDataSource.FileTemplate, Is.Not.Null.And.Not.Empty);
                }
                else
                {
                    Assert.That(specificDataSource.AccountName, Is.Null);
                    Assert.That(specificDataSource.AccountKey, Is.Null);
                    Assert.That(specificDataSource.FileSystemName, Is.Null);
                    Assert.That(specificDataSource.DirectoryTemplate, Is.Null);
                    Assert.That(specificDataSource.FileTemplate, Is.Null);
                }
            }
            else if (sourceType == DataFeedSourceType.AzureTable)
            {
                var specificDataSource = dataSource as AzureTableDataFeedSource;

                Assert.That(specificDataSource, Is.Not.Null);

                if (isAdmin)
                {
                    Assert.That(specificDataSource.ConnectionString, Is.Not.Null.And.Not.Empty);
                    Assert.That(specificDataSource.Table, Is.Not.Null.And.Not.Empty);
                    Assert.That(specificDataSource.Query, Is.Not.Null.And.Not.Empty);
                }
                else
                {
                    Assert.That(specificDataSource.ConnectionString, Is.Null);
                    Assert.That(specificDataSource.Table, Is.Null);
                    Assert.That(specificDataSource.Query, Is.Null);
                }
            }
            else if (sourceType == DataFeedSourceType.Elasticsearch)
            {
                var specificDataSource = dataSource as ElasticsearchDataFeedSource;

                Assert.That(specificDataSource, Is.Not.Null);

                if (isAdmin)
                {
                    Assert.That(specificDataSource.Host, Is.Not.Null.And.Not.Empty);
                    Assert.That(specificDataSource.Port, Is.Not.Null.And.Not.Empty);
                    Assert.That(specificDataSource.AuthorizationHeader, Is.Not.Null.And.Not.Empty);
                    Assert.That(specificDataSource.Query, Is.Not.Null.And.Not.Empty);
                }
                else
                {
                    Assert.That(specificDataSource.Host, Is.Null);
                    Assert.That(specificDataSource.Port, Is.Null);
                    Assert.That(specificDataSource.AuthorizationHeader, Is.Null);
                    Assert.That(specificDataSource.Query, Is.Null);
                }
            }
            else if (sourceType == DataFeedSourceType.HttpRequest)
            {
                var specificDataSource = dataSource as HttpRequestDataFeedSource;

                Assert.That(specificDataSource, Is.Not.Null);

                if (isAdmin)
                {
                    Assert.That(specificDataSource.Url, Is.Not.Null);
                    Assert.That(specificDataSource.HttpHeader, Is.Not.Null.And.Not.Empty);
                    Assert.That(specificDataSource.HttpMethod, Is.Not.Null.And.Not.Empty);
                    Assert.That(specificDataSource.Payload, Is.Not.Null.And.Not.Empty);
                }
                else
                {
                    Assert.That(specificDataSource.Url, Is.Not.Null);
                    Assert.That(specificDataSource.HttpHeader, Is.Null);
                    Assert.That(specificDataSource.HttpMethod, Is.Null);
                    Assert.That(specificDataSource.Payload, Is.Null);
                }
            }
            else if (sourceType == DataFeedSourceType.InfluxDb)
            {
                var specificDataSource = dataSource as InfluxDbDataFeedSource;

                Assert.That(specificDataSource, Is.Not.Null);

                if (isAdmin)
                {
                    Assert.That(specificDataSource.ConnectionString, Is.Not.Null.And.Not.Empty);
                    Assert.That(specificDataSource.Database, Is.Not.Null.And.Not.Empty);
                    Assert.That(specificDataSource.Username, Is.Not.Null.And.Not.Empty);
                    Assert.That(specificDataSource.Password, Is.Not.Null.And.Not.Empty);
                    Assert.That(specificDataSource.Query, Is.Not.Null.And.Not.Empty);
                }
                else
                {
                    Assert.That(specificDataSource.ConnectionString, Is.Null);
                    Assert.That(specificDataSource.Database, Is.Null);
                    Assert.That(specificDataSource.Username, Is.Null);
                    Assert.That(specificDataSource.Password, Is.Null);
                    Assert.That(specificDataSource.Query, Is.Null);
                }
            }
            else if (sourceType == DataFeedSourceType.MongoDb)
            {
                var specificDataSource = dataSource as MongoDbDataFeedSource;

                Assert.That(specificDataSource, Is.Not.Null);

                if (isAdmin)
                {
                    Assert.That(specificDataSource.ConnectionString, Is.Not.Null.And.Not.Empty);
                    Assert.That(specificDataSource.Database, Is.Not.Null.And.Not.Empty);
                    Assert.That(specificDataSource.Command, Is.Not.Null.And.Not.Empty);
                }
                else
                {
                    Assert.That(specificDataSource.ConnectionString, Is.Null);
                    Assert.That(specificDataSource.Database, Is.Null);
                    Assert.That(specificDataSource.Command, Is.Null);
                }
            }
            else if (sourceType == DataFeedSourceType.MySql)
            {
                var specificDataSource = dataSource as MySqlDataFeedSource;

                Assert.That(specificDataSource, Is.Not.Null);

                if (isAdmin)
                {
                    Assert.That(specificDataSource.ConnectionString, Is.Not.Null.And.Not.Empty);
                    Assert.That(specificDataSource.Query, Is.Not.Null.And.Not.Empty);
                }
                else
                {
                    Assert.That(specificDataSource.ConnectionString, Is.Null);
                    Assert.That(specificDataSource.Query, Is.Null);
                }
            }
            else if (sourceType == DataFeedSourceType.PostgreSql)
            {
                var specificDataSource = dataSource as PostgreSqlDataFeedSource;

                Assert.That(specificDataSource, Is.Not.Null);

                if (isAdmin)
                {
                    Assert.That(specificDataSource.ConnectionString, Is.Not.Null.And.Not.Empty);
                    Assert.That(specificDataSource.Query, Is.Not.Null.And.Not.Empty);
                }
                else
                {
                    Assert.That(specificDataSource.ConnectionString, Is.Null);
                    Assert.That(specificDataSource.Query, Is.Null);
                }
            }
            else
            {
                Assert.That(sourceType, Is.EqualTo(DataFeedSourceType.SqlServer));

                var specificDataSource = dataSource as SqlServerDataFeedSource;

                Assert.That(specificDataSource, Is.Not.Null);

                if (isAdmin)
                {
                    Assert.That(specificDataSource.ConnectionString, Is.Not.Null.And.Not.Empty);
                    Assert.That(specificDataSource.Query, Is.Not.Null.And.Not.Empty);
                }
                else
                {
                    Assert.That(specificDataSource.ConnectionString, Is.Null);
                    Assert.That(specificDataSource.Query, Is.Null);
                }
            }
        }
    }
}
