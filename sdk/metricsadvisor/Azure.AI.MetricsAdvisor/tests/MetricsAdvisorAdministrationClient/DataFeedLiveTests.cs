// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
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
        private const string DataSourceClientId = "clientId";
        private const string DataSourceClientSecret = "clientSecret";
        private const string DataSourceCloud = "cloud";
        private const string DataSourceCollectionId = "collectId";
        private const string DataSourceCommand = "command";
        private const string DataSourceConnectionString = "connectionStr";
        private const string DataSourceConsumerGroup = "consumerGroup";
        private const string DataSourceContainer = "container";
        private const string DataSourceDatabase = "database";
        private const string DataSourceDirectory = "dir";
        private const string DataSourceFile = "file";
        private const string DataSourceFileSystem = "fileSystem";
        private const string DataSourceKey = "key";
        private const string DataSourcePassword = "pass";
        private const string DataSourceQuery = "query";
        private const string DataSourceTable = "table";
        private const string DataSourceTemplate = "template";
        private const string DataSourceTenantId = "tenantId";
        private const string DataSourceUsername = "username";
        private const string DataSourceWorkspaceId = "workspaceId";

        public DataFeedLiveTests(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        [TestCase(true)]
        [TestCase(false)]
        public async Task CreateAndGetAzureApplicationInsightsDataFeedWithMinimumSetup(bool useTokenCredential)
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient(useTokenCredential);

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new AzureApplicationInsightsDataFeedSource(DataSourceAppId, DataSourceKey, DataSourceCloud, DataSourceQuery);
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed createdDataFeed = disposableDataFeed.DataFeed;

            ValidateDataFeedWithMinimumSetup(createdDataFeed, dataFeedName);
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

            DataFeed createdDataFeed = disposableDataFeed.DataFeed;

            ValidateDataFeedWithOptionalMembersSet(createdDataFeed, dataFeedName);
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

            DataFeed createdDataFeed = disposableDataFeed.DataFeed;

            ValidateDataFeedWithMinimumSetup(createdDataFeed, dataFeedName);
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

            DataFeed createdDataFeed = disposableDataFeed.DataFeed;

            ValidateDataFeedWithOptionalMembersSet(createdDataFeed, dataFeedName);
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

            DataFeed createdDataFeed = disposableDataFeed.DataFeed;

            ValidateDataFeedWithMinimumSetup(createdDataFeed, dataFeedName);
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

            DataFeed createdDataFeed = disposableDataFeed.DataFeed;

            ValidateDataFeedWithOptionalMembersSet(createdDataFeed, dataFeedName);
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

            DataFeed createdDataFeed = disposableDataFeed.DataFeed;

            ValidateDataFeedWithMinimumSetup(createdDataFeed, dataFeedName);
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

            DataFeed createdDataFeed = disposableDataFeed.DataFeed;

            ValidateDataFeedWithOptionalMembersSet(createdDataFeed, dataFeedName);
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

            DataFeed createdDataFeed = disposableDataFeed.DataFeed;

            ValidateDataFeedWithMinimumSetup(createdDataFeed, dataFeedName);
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

            DataFeed createdDataFeed = disposableDataFeed.DataFeed;

            ValidateDataFeedWithOptionalMembersSet(createdDataFeed, dataFeedName);
            ValidateAzureDataLakeStorageGen2DataSource(createdDataFeed.DataSource as AzureDataLakeStorageGen2DataFeedSource);
        }

        [RecordedTest]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/21623")]
        public async Task CreateAndGetAzureEventHubsDataFeedWithMinimumSetup()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new AzureEventHubsDataFeedSource(DataSourceConnectionString, DataSourceConsumerGroup);
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed createdDataFeed = disposableDataFeed.DataFeed;

            ValidateDataFeedWithMinimumSetup(createdDataFeed, dataFeedName);
            ValidateAzureEventHubsDataSource(createdDataFeed.DataSource as AzureEventHubsDataFeedSource);
        }

        [RecordedTest]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/21623")]
        public async Task CreateAndGetAzureEventHubsDataFeedWithOptionalMembers()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new AzureEventHubsDataFeedSource(DataSourceConnectionString, DataSourceConsumerGroup);
            DataFeed dataFeedToCreate = GetDataFeedWithOptionalMembersSet(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed createdDataFeed = disposableDataFeed.DataFeed;

            ValidateDataFeedWithOptionalMembersSet(createdDataFeed, dataFeedName);
            ValidateAzureEventHubsDataSource(createdDataFeed.DataSource as AzureEventHubsDataFeedSource);
        }

        [RecordedTest]
        public async Task CreateAndGetAzureTableDataFeedWithMinimumSetup()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new AzureTableDataFeedSource(DataSourceConnectionString, DataSourceTable, DataSourceQuery);
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed createdDataFeed = disposableDataFeed.DataFeed;

            ValidateDataFeedWithMinimumSetup(createdDataFeed, dataFeedName);
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

            DataFeed createdDataFeed = disposableDataFeed.DataFeed;

            ValidateDataFeedWithOptionalMembersSet(createdDataFeed, dataFeedName);
            ValidateAzureTableDataSource(createdDataFeed.DataSource as AzureTableDataFeedSource);
        }

        [RecordedTest]
        public async Task CreateAndGetInfluxDbDataFeedWithMinimumSetup()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new InfluxDbDataFeedSource(DataSourceConnectionString, DataSourceDatabase, DataSourceUsername, DataSourcePassword, DataSourceQuery);
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed createdDataFeed = disposableDataFeed.DataFeed;

            ValidateDataFeedWithMinimumSetup(createdDataFeed, dataFeedName);
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

            DataFeed createdDataFeed = disposableDataFeed.DataFeed;

            ValidateDataFeedWithOptionalMembersSet(createdDataFeed, dataFeedName);
            ValidateInfluxDbDataSource(createdDataFeed.DataSource as InfluxDbDataFeedSource);
        }

        [RecordedTest]
        public async Task CreateAndGetLogAnalyticsDataFeedWithMinimumSetup()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new LogAnalyticsDataFeedSource(DataSourceWorkspaceId, DataSourceQuery, DataSourceClientId, DataSourceClientSecret, DataSourceTenantId);
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed createdDataFeed = disposableDataFeed.DataFeed;

            ValidateDataFeedWithMinimumSetup(createdDataFeed, dataFeedName);
            ValidateLogAnalyticsDataSource(createdDataFeed.DataSource as LogAnalyticsDataFeedSource);
        }

        [RecordedTest]
        public async Task CreateAndGetLogAnalyticsDataFeedWithOptionalMembers()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new LogAnalyticsDataFeedSource(DataSourceWorkspaceId, DataSourceQuery, DataSourceClientId, DataSourceClientSecret, DataSourceTenantId);
            DataFeed dataFeedToCreate = GetDataFeedWithOptionalMembersSet(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed createdDataFeed = disposableDataFeed.DataFeed;

            ValidateDataFeedWithOptionalMembersSet(createdDataFeed, dataFeedName);
            ValidateLogAnalyticsDataSource(createdDataFeed.DataSource as LogAnalyticsDataFeedSource);
        }

        [RecordedTest]
        public async Task CreateAndGetMongoDbDataFeedWithMinimumSetup()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new MongoDbDataFeedSource(DataSourceConnectionString, DataSourceDatabase, DataSourceCommand);
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed createdDataFeed = disposableDataFeed.DataFeed;

            ValidateDataFeedWithMinimumSetup(createdDataFeed, dataFeedName);
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

            DataFeed createdDataFeed = disposableDataFeed.DataFeed;

            ValidateDataFeedWithOptionalMembersSet(createdDataFeed, dataFeedName);
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

            DataFeed createdDataFeed = disposableDataFeed.DataFeed;

            ValidateDataFeedWithMinimumSetup(createdDataFeed, dataFeedName);
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

            DataFeed createdDataFeed = disposableDataFeed.DataFeed;

            ValidateDataFeedWithOptionalMembersSet(createdDataFeed, dataFeedName);
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

            DataFeed createdDataFeed = disposableDataFeed.DataFeed;

            ValidateDataFeedWithMinimumSetup(createdDataFeed, dataFeedName);
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

            DataFeed createdDataFeed = disposableDataFeed.DataFeed;

            ValidateDataFeedWithOptionalMembersSet(createdDataFeed, dataFeedName);
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

            DataFeed createdDataFeed = disposableDataFeed.DataFeed;

            ValidateDataFeedWithMinimumSetup(createdDataFeed, dataFeedName);
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

            DataFeed createdDataFeed = disposableDataFeed.DataFeed;

            ValidateDataFeedWithOptionalMembersSet(createdDataFeed, dataFeedName);
            ValidateSqlServerDataSource(createdDataFeed.DataSource as SqlServerDataFeedSource);
        }

        [RecordedTest]
        [TestCase(AzureBlobDataFeedSource.AuthenticationType.Basic)]
        [TestCase(AzureBlobDataFeedSource.AuthenticationType.ManagedIdentity)]
        public async Task CreateAndGetAzureBlobDataFeedWithAuthentication(AzureBlobDataFeedSource.AuthenticationType authentication)
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new AzureBlobDataFeedSource("mock", "mock", "mock")
            {
                Authentication = authentication
            };
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed createdDataFeed = disposableDataFeed.DataFeed;
            AzureBlobDataFeedSource createdDataSource = createdDataFeed.DataSource as AzureBlobDataFeedSource;

            Assert.That(createdDataSource.Authentication, Is.EqualTo(authentication));
        }

        [RecordedTest]
        [TestCase(AzureDataExplorerDataFeedSource.AuthenticationType.Basic)]
        [TestCase(AzureDataExplorerDataFeedSource.AuthenticationType.ManagedIdentity)]
        public async Task CreateAndGetAzureDataExplorerDataFeedWithAuthentication(AzureDataExplorerDataFeedSource.AuthenticationType authentication)
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new AzureDataExplorerDataFeedSource("mock", "mock")
            {
                Authentication = authentication
            };
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed createdDataFeed = disposableDataFeed.DataFeed;
            AzureDataExplorerDataFeedSource createdDataSource = createdDataFeed.DataSource as AzureDataExplorerDataFeedSource;

            Assert.That(createdDataSource.Authentication, Is.EqualTo(authentication));
        }

        [RecordedTest]
        [TestCase(AzureDataExplorerDataFeedSource.AuthenticationType.ServicePrincipal)]
        [TestCase(AzureDataExplorerDataFeedSource.AuthenticationType.ServicePrincipalInKeyVault)]
        public async Task CreateAndGetAzureDataExplorerDataFeedWithCredentialAuthentication(AzureDataExplorerDataFeedSource.AuthenticationType authentication)
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var credentialName = Recording.GenerateAlphaNumericId("credential");
            await using var disposableCredential = await DisposableDataSourceCredentialEntity.CreateDataSourceCredentialEntityAsync(adminClient, credentialName, authentication.ToString());
            string credentialId = disposableCredential.Credential.Id;

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new AzureDataExplorerDataFeedSource("mock", "mock")
            {
                Authentication = authentication,
                DataSourceCredentialId = credentialId
            };
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed createdDataFeed = disposableDataFeed.DataFeed;
            AzureDataExplorerDataFeedSource createdDataSource = createdDataFeed.DataSource as AzureDataExplorerDataFeedSource;

            Assert.That(createdDataSource.Authentication, Is.EqualTo(authentication));
            Assert.That(createdDataSource.DataSourceCredentialId, Is.EqualTo(credentialId));
        }

        [RecordedTest]
        public async Task CreateAndGetAzureDataLakeStorageGen2DataFeedWithAuthentication()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new AzureDataLakeStorageGen2DataFeedSource("mock", "mock", "mock", "mock", "mock")
            {
                Authentication = AzureDataLakeStorageGen2DataFeedSource.AuthenticationType.Basic
            };
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed createdDataFeed = disposableDataFeed.DataFeed;
            AzureDataLakeStorageGen2DataFeedSource createdDataSource = createdDataFeed.DataSource as AzureDataLakeStorageGen2DataFeedSource;

            Assert.That(createdDataSource.Authentication, Is.EqualTo(AzureDataLakeStorageGen2DataFeedSource.AuthenticationType.Basic));
        }

        [RecordedTest]
        [TestCase(AzureDataLakeStorageGen2DataFeedSource.AuthenticationType.ServicePrincipal)]
        [TestCase(AzureDataLakeStorageGen2DataFeedSource.AuthenticationType.ServicePrincipalInKeyVault)]
        [TestCase(AzureDataLakeStorageGen2DataFeedSource.AuthenticationType.SharedKey)]
        public async Task CreateAndGetAzureDataLakeStorageGen2DataFeedWithCredentialAuthentication(AzureDataLakeStorageGen2DataFeedSource.AuthenticationType authentication)
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var credentialName = Recording.GenerateAlphaNumericId("credential");
            await using var disposableCredential = await DisposableDataSourceCredentialEntity.CreateDataSourceCredentialEntityAsync(adminClient, credentialName, authentication.ToString());
            string credentialId = disposableCredential.Credential.Id;

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new AzureDataLakeStorageGen2DataFeedSource("mock", "mock", "mock", "mock", "mock")
            {
                Authentication = authentication,
                DataSourceCredentialId = credentialId
            };
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed createdDataFeed = disposableDataFeed.DataFeed;
            AzureDataLakeStorageGen2DataFeedSource createdDataSource = createdDataFeed.DataSource as AzureDataLakeStorageGen2DataFeedSource;

            Assert.That(createdDataSource.Authentication, Is.EqualTo(authentication));
            Assert.That(createdDataSource.DataSourceCredentialId, Is.EqualTo(credentialId));
        }

        [RecordedTest]
        [TestCase(SqlServerDataFeedSource.AuthenticationType.Basic)]
        [TestCase(SqlServerDataFeedSource.AuthenticationType.ManagedIdentity)]
        public async Task CreateAndGetSqlServerDataFeedWithAuthentication(SqlServerDataFeedSource.AuthenticationType authentication)
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new SqlServerDataFeedSource("mock", "mock")
            {
                Authentication = authentication
            };
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed createdDataFeed = disposableDataFeed.DataFeed;
            SqlServerDataFeedSource createdDataSource = createdDataFeed.DataSource as SqlServerDataFeedSource;

            Assert.That(createdDataSource.Authentication, Is.EqualTo(authentication));
        }

        [RecordedTest]
        [TestCase(SqlServerDataFeedSource.AuthenticationType.ServicePrincipal)]
        [TestCase(SqlServerDataFeedSource.AuthenticationType.ServicePrincipalInKeyVault)]
        [TestCase(SqlServerDataFeedSource.AuthenticationType.SqlConnectionString)]
        public async Task CreateAndGetSqlServerDataFeedWithCredentialAuthentication(SqlServerDataFeedSource.AuthenticationType authentication)
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var credentialName = Recording.GenerateAlphaNumericId("credential");
            await using var disposableCredential = await DisposableDataSourceCredentialEntity.CreateDataSourceCredentialEntityAsync(adminClient, credentialName, authentication.ToString());
            string credentialId = disposableCredential.Credential.Id;

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new SqlServerDataFeedSource("mock", "mock")
            {
                Authentication = authentication,
                DataSourceCredentialId = credentialId
            };
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed createdDataFeed = disposableDataFeed.DataFeed;
            SqlServerDataFeedSource createdDataSource = createdDataFeed.DataSource as SqlServerDataFeedSource;

            Assert.That(createdDataSource.Authentication, Is.EqualTo(authentication));
            Assert.That(createdDataSource.DataSourceCredentialId, Is.EqualTo(credentialId));
        }

        [RecordedTest]
        public async Task UpdateAzureApplicationInsightsDataFeedWithMinimumSetup()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new AzureApplicationInsightsDataFeedSource(DataSourceAppId, DataSourceKey, DataSourceCloud, DataSourceQuery);
            const string description = "This data feed was created to test the .NET client.";
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed dataFeedToUpdate = disposableDataFeed.DataFeed;

            dataFeedToUpdate.Description = description;

            DataFeed updatedDataFeed = await adminClient.UpdateDataFeedAsync(dataFeedToUpdate);

            ValidateDataFeedWithMinimumSetup(updatedDataFeed, dataFeedName, description, dataFeedToUpdate.Id);
            ValidateAzureApplicationInsightsDataSource(updatedDataFeed.DataSource as AzureApplicationInsightsDataFeedSource);
        }

        [RecordedTest]
        public async Task UpdateAzureApplicationInsightsDataFeedWithEveryMember()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var updatedDataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new AzureApplicationInsightsDataFeedSource(DataSourceAppId, DataSourceKey, DataSourceCloud, DataSourceQuery);
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed dataFeedToUpdate = disposableDataFeed.DataFeed;

            SetOptionalMembers(dataFeedToUpdate, updatedDataFeedName);

            DataFeed updatedDataFeed = await adminClient.UpdateDataFeedAsync(dataFeedToUpdate);

            ValidateUpdatedDataFeedWithOptionalMembersSet(updatedDataFeed, dataFeedToUpdate.Id, updatedDataFeedName);
            ValidateAzureApplicationInsightsDataSource(updatedDataFeed.DataSource as AzureApplicationInsightsDataFeedSource);
        }

        [RecordedTest]
        [TestCase(true)]
        [TestCase(false)]
        public async Task UpdateAzureBlobDataFeedWithMinimumSetup(bool useTokenCredential)
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient(useTokenCredential);

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new AzureBlobDataFeedSource(DataSourceConnectionString, DataSourceContainer, DataSourceTemplate);
            const string description = "This data feed was created to test the .NET client.";
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed dataFeedToUpdate = disposableDataFeed.DataFeed;

            dataFeedToUpdate.Description = description;

            DataFeed updatedDataFeed = await adminClient.UpdateDataFeedAsync(dataFeedToUpdate);

            ValidateDataFeedWithMinimumSetup(updatedDataFeed, dataFeedName, description, dataFeedToUpdate.Id);
            ValidateAzureBlobDataSource(updatedDataFeed.DataSource as AzureBlobDataFeedSource);
        }

        [RecordedTest]
        public async Task UpdateAzureBlobDataFeedWithEveryMember()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var updatedDataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new AzureBlobDataFeedSource(DataSourceConnectionString, DataSourceContainer, DataSourceTemplate);
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed dataFeedToUpdate = disposableDataFeed.DataFeed;

            SetOptionalMembers(dataFeedToUpdate, updatedDataFeedName);

            DataFeed updatedDataFeed = await adminClient.UpdateDataFeedAsync(dataFeedToUpdate);

            ValidateUpdatedDataFeedWithOptionalMembersSet(updatedDataFeed, dataFeedToUpdate.Id, updatedDataFeedName);
            ValidateAzureBlobDataSource(updatedDataFeed.DataSource as AzureBlobDataFeedSource);
        }

        [RecordedTest]
        public async Task UpdateAzureCosmosDbDataFeedWithMinimumSetup()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new AzureCosmosDbDataFeedSource(DataSourceConnectionString, DataSourceQuery, DataSourceDatabase, DataSourceCollectionId);
            const string description = "This data feed was created to test the .NET client.";
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed dataFeedToUpdate = disposableDataFeed.DataFeed;

            dataFeedToUpdate.Description = description;

            DataFeed updatedDataFeed = await adminClient.UpdateDataFeedAsync(dataFeedToUpdate);

            ValidateDataFeedWithMinimumSetup(updatedDataFeed, dataFeedName, description, dataFeedToUpdate.Id);
            ValidateAzureCosmosDbDataSource(updatedDataFeed.DataSource as AzureCosmosDbDataFeedSource);
        }

        [RecordedTest]
        public async Task UpdateAzureCosmosDbDataFeedWithEveryMember()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var updatedDataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new AzureCosmosDbDataFeedSource(DataSourceConnectionString, DataSourceQuery, DataSourceDatabase, DataSourceCollectionId);
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed dataFeedToUpdate = disposableDataFeed.DataFeed;

            SetOptionalMembers(dataFeedToUpdate, updatedDataFeedName);

            DataFeed updatedDataFeed = await adminClient.UpdateDataFeedAsync(dataFeedToUpdate);

            ValidateUpdatedDataFeedWithOptionalMembersSet(updatedDataFeed, dataFeedToUpdate.Id, updatedDataFeedName);
            ValidateAzureCosmosDbDataSource(updatedDataFeed.DataSource as AzureCosmosDbDataFeedSource);
        }

        [RecordedTest]
        public async Task UpdateAzureDataExplorerDataFeedWithMinimumSetup()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new AzureDataExplorerDataFeedSource(DataSourceConnectionString, DataSourceQuery);
            const string description = "This data feed was created to test the .NET client.";
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed dataFeedToUpdate = disposableDataFeed.DataFeed;

            dataFeedToUpdate.Description = description;

            DataFeed updatedDataFeed = await adminClient.UpdateDataFeedAsync(dataFeedToUpdate);

            ValidateDataFeedWithMinimumSetup(updatedDataFeed, dataFeedName, description, dataFeedToUpdate.Id);
            ValidateAzureDataExplorerDataSource(updatedDataFeed.DataSource as AzureDataExplorerDataFeedSource);
        }

        [RecordedTest]
        public async Task UpdateAzureDataExplorerDataFeedWithEveryMember()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var updatedDataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new AzureDataExplorerDataFeedSource(DataSourceConnectionString, DataSourceQuery);
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed dataFeedToUpdate = disposableDataFeed.DataFeed;

            SetOptionalMembers(dataFeedToUpdate, updatedDataFeedName);

            DataFeed updatedDataFeed = await adminClient.UpdateDataFeedAsync(dataFeedToUpdate);

            ValidateUpdatedDataFeedWithOptionalMembersSet(updatedDataFeed, dataFeedToUpdate.Id, updatedDataFeedName);
            ValidateAzureDataExplorerDataSource(updatedDataFeed.DataSource as AzureDataExplorerDataFeedSource);
        }

        [RecordedTest]
        public async Task UpdateAzureDataLakeStorageGen2DataFeedWithMinimumSetup()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new AzureDataLakeStorageGen2DataFeedSource(DataSourceAccount, DataSourceKey, DataSourceFileSystem, DataSourceDirectory, DataSourceFile);
            const string description = "This data feed was created to test the .NET client.";
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed dataFeedToUpdate = disposableDataFeed.DataFeed;

            dataFeedToUpdate.Description = description;

            DataFeed updatedDataFeed = await adminClient.UpdateDataFeedAsync(dataFeedToUpdate);

            ValidateDataFeedWithMinimumSetup(updatedDataFeed, dataFeedName, description, dataFeedToUpdate.Id);
            ValidateAzureDataLakeStorageGen2DataSource(updatedDataFeed.DataSource as AzureDataLakeStorageGen2DataFeedSource);
        }

        [RecordedTest]
        public async Task UpdateAzureDataLakeStorageGen2DataFeedWithEveryMember()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var updatedDataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new AzureDataLakeStorageGen2DataFeedSource(DataSourceAccount, DataSourceKey, DataSourceFileSystem, DataSourceDirectory, DataSourceFile);
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed dataFeedToUpdate = disposableDataFeed.DataFeed;

            SetOptionalMembers(dataFeedToUpdate, updatedDataFeedName);

            DataFeed updatedDataFeed = await adminClient.UpdateDataFeedAsync(dataFeedToUpdate);

            ValidateUpdatedDataFeedWithOptionalMembersSet(updatedDataFeed, dataFeedToUpdate.Id, updatedDataFeedName);
            ValidateAzureDataLakeStorageGen2DataSource(updatedDataFeed.DataSource as AzureDataLakeStorageGen2DataFeedSource);
        }

        [RecordedTest]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/21623")]
        public async Task UpdateAzureEventHubsDataFeedWithMinimumSetup()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new AzureEventHubsDataFeedSource(DataSourceConnectionString, DataSourceConsumerGroup);
            const string description = "This data feed was created to test the .NET client.";
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed dataFeedToUpdate = disposableDataFeed.DataFeed;

            dataFeedToUpdate.Description = description;

            DataFeed updatedDataFeed = await adminClient.UpdateDataFeedAsync(dataFeedToUpdate);

            ValidateDataFeedWithMinimumSetup(updatedDataFeed, dataFeedName, description, dataFeedToUpdate.Id);
            ValidateAzureEventHubsDataSource(updatedDataFeed.DataSource as AzureEventHubsDataFeedSource);
        }

        [RecordedTest]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/21623")]
        public async Task UpdateAzureEventHubsDataFeedWithEveryMember()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var updatedDataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new AzureEventHubsDataFeedSource(DataSourceConnectionString, DataSourceConsumerGroup);
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed dataFeedToUpdate = disposableDataFeed.DataFeed;

            SetOptionalMembers(dataFeedToUpdate, updatedDataFeedName);

            DataFeed updatedDataFeed = await adminClient.UpdateDataFeedAsync(dataFeedToUpdate);

            ValidateUpdatedDataFeedWithOptionalMembersSet(updatedDataFeed, dataFeedToUpdate.Id, updatedDataFeedName);
            ValidateAzureEventHubsDataSource(updatedDataFeed.DataSource as AzureEventHubsDataFeedSource);
        }

        [RecordedTest]
        public async Task UpdateAzureTableDataFeedWithMinimumSetup()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new AzureTableDataFeedSource(DataSourceConnectionString, DataSourceTable, DataSourceQuery);
            const string description = "This data feed was created to test the .NET client.";
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed dataFeedToUpdate = disposableDataFeed.DataFeed;

            dataFeedToUpdate.Description = description;

            DataFeed updatedDataFeed = await adminClient.UpdateDataFeedAsync(dataFeedToUpdate);

            ValidateDataFeedWithMinimumSetup(updatedDataFeed, dataFeedName, description, dataFeedToUpdate.Id);
            ValidateAzureTableDataSource(updatedDataFeed.DataSource as AzureTableDataFeedSource);
        }

        [RecordedTest]
        public async Task UpdateAzureTableDataFeedWithEveryMember()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var updatedDataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new AzureTableDataFeedSource(DataSourceConnectionString, DataSourceTable, DataSourceQuery);
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed dataFeedToUpdate = disposableDataFeed.DataFeed;

            SetOptionalMembers(dataFeedToUpdate, updatedDataFeedName);

            DataFeed updatedDataFeed = await adminClient.UpdateDataFeedAsync(dataFeedToUpdate);

            ValidateUpdatedDataFeedWithOptionalMembersSet(updatedDataFeed, dataFeedToUpdate.Id, updatedDataFeedName);
            ValidateAzureTableDataSource(updatedDataFeed.DataSource as AzureTableDataFeedSource);
        }

        [RecordedTest]
        public async Task UpdateInfluxDbDataFeedWithMinimumSetup()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new InfluxDbDataFeedSource(DataSourceConnectionString, DataSourceDatabase, DataSourceUsername, DataSourcePassword, DataSourceQuery);
            const string description = "This data feed was created to test the .NET client.";
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed dataFeedToUpdate = disposableDataFeed.DataFeed;

            dataFeedToUpdate.Description = description;

            DataFeed updatedDataFeed = await adminClient.UpdateDataFeedAsync(dataFeedToUpdate);

            ValidateDataFeedWithMinimumSetup(updatedDataFeed, dataFeedName, description, dataFeedToUpdate.Id);
            ValidateInfluxDbDataSource(updatedDataFeed.DataSource as InfluxDbDataFeedSource);
        }

        [RecordedTest]
        public async Task UpdateInfluxDbDataFeedWithEveryMember()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var updatedDataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new InfluxDbDataFeedSource(DataSourceConnectionString, DataSourceDatabase, DataSourceUsername, DataSourcePassword, DataSourceQuery);
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed dataFeedToUpdate = disposableDataFeed.DataFeed;

            SetOptionalMembers(dataFeedToUpdate, updatedDataFeedName);

            DataFeed updatedDataFeed = await adminClient.UpdateDataFeedAsync(dataFeedToUpdate);

            ValidateUpdatedDataFeedWithOptionalMembersSet(updatedDataFeed, dataFeedToUpdate.Id, updatedDataFeedName);
            ValidateInfluxDbDataSource(updatedDataFeed.DataSource as InfluxDbDataFeedSource);
        }

        [RecordedTest]
        public async Task UpdateLogAnalyticsDataFeedWithMinimumSetup()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new LogAnalyticsDataFeedSource(DataSourceWorkspaceId, DataSourceQuery, DataSourceClientId, DataSourceClientSecret, DataSourceTenantId);
            const string description = "This data feed was created to test the .NET client.";
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed dataFeedToUpdate = disposableDataFeed.DataFeed;

            dataFeedToUpdate.Description = description;

            DataFeed updatedDataFeed = await adminClient.UpdateDataFeedAsync(dataFeedToUpdate);

            ValidateDataFeedWithMinimumSetup(updatedDataFeed, dataFeedName, description, dataFeedToUpdate.Id);
            ValidateLogAnalyticsDataSource(updatedDataFeed.DataSource as LogAnalyticsDataFeedSource);
        }

        [RecordedTest]
        public async Task UpdateLogAnalyticsDataFeedWithEveryMember()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var updatedDataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new LogAnalyticsDataFeedSource(DataSourceWorkspaceId, DataSourceQuery, DataSourceClientId, DataSourceClientSecret, DataSourceTenantId);
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed dataFeedToUpdate = disposableDataFeed.DataFeed;

            SetOptionalMembers(dataFeedToUpdate, updatedDataFeedName);

            DataFeed updatedDataFeed = await adminClient.UpdateDataFeedAsync(dataFeedToUpdate);

            ValidateUpdatedDataFeedWithOptionalMembersSet(updatedDataFeed, dataFeedToUpdate.Id, updatedDataFeedName);
            ValidateLogAnalyticsDataSource(updatedDataFeed.DataSource as LogAnalyticsDataFeedSource);
        }

        [RecordedTest]
        public async Task UpdateMongoDbDataFeedWithMinimumSetup()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new MongoDbDataFeedSource(DataSourceConnectionString, DataSourceDatabase, DataSourceCommand);
            const string description = "This data feed was created to test the .NET client.";
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed dataFeedToUpdate = disposableDataFeed.DataFeed;

            dataFeedToUpdate.Description = description;

            DataFeed updatedDataFeed = await adminClient.UpdateDataFeedAsync(dataFeedToUpdate);

            ValidateDataFeedWithMinimumSetup(updatedDataFeed, dataFeedName, description, dataFeedToUpdate.Id);
            ValidateMongoDbDataSource(updatedDataFeed.DataSource as MongoDbDataFeedSource);
        }

        [RecordedTest]
        public async Task UpdateMongoDbDataFeedWithEveryMember()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var updatedDataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new MongoDbDataFeedSource(DataSourceConnectionString, DataSourceDatabase, DataSourceCommand);
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed dataFeedToUpdate = disposableDataFeed.DataFeed;

            SetOptionalMembers(dataFeedToUpdate, updatedDataFeedName);

            DataFeed updatedDataFeed = await adminClient.UpdateDataFeedAsync(dataFeedToUpdate);

            ValidateUpdatedDataFeedWithOptionalMembersSet(updatedDataFeed, dataFeedToUpdate.Id, updatedDataFeedName);
            ValidateMongoDbDataSource(updatedDataFeed.DataSource as MongoDbDataFeedSource);
        }

        [RecordedTest]
        public async Task UpdateMySqlDataFeedWithMinimumSetup()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new MySqlDataFeedSource(DataSourceConnectionString, DataSourceQuery);
            const string description = "This data feed was created to test the .NET client.";
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed dataFeedToUpdate = disposableDataFeed.DataFeed;

            dataFeedToUpdate.Description = description;

            DataFeed updatedDataFeed = await adminClient.UpdateDataFeedAsync(dataFeedToUpdate);

            ValidateDataFeedWithMinimumSetup(updatedDataFeed, dataFeedName, description, dataFeedToUpdate.Id);
            ValidateMySqlDataSource(updatedDataFeed.DataSource as MySqlDataFeedSource);
        }

        [RecordedTest]
        public async Task UpdateMySqlDataFeedWithEveryMember()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var updatedDataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new MySqlDataFeedSource(DataSourceConnectionString, DataSourceQuery);
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed dataFeedToUpdate = disposableDataFeed.DataFeed;

            SetOptionalMembers(dataFeedToUpdate, updatedDataFeedName);

            DataFeed updatedDataFeed = await adminClient.UpdateDataFeedAsync(dataFeedToUpdate);

            ValidateUpdatedDataFeedWithOptionalMembersSet(updatedDataFeed, dataFeedToUpdate.Id, updatedDataFeedName);
            ValidateMySqlDataSource(updatedDataFeed.DataSource as MySqlDataFeedSource);
        }

        [RecordedTest]
        public async Task UpdatePostgreSqlDataFeedWithMinimumSetup()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new PostgreSqlDataFeedSource(DataSourceConnectionString, DataSourceQuery);
            const string description = "This data feed was created to test the .NET client.";
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed dataFeedToUpdate = disposableDataFeed.DataFeed;

            dataFeedToUpdate.Description = description;

            DataFeed updatedDataFeed = await adminClient.UpdateDataFeedAsync(dataFeedToUpdate);

            ValidateDataFeedWithMinimumSetup(updatedDataFeed, dataFeedName, description, dataFeedToUpdate.Id);
            ValidatePostgreSqlDataSource(updatedDataFeed.DataSource as PostgreSqlDataFeedSource);
        }

        [RecordedTest]
        public async Task UpdatePostgreSqlDataFeedWithEveryMember()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var updatedDataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new PostgreSqlDataFeedSource(DataSourceConnectionString, DataSourceQuery);
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed dataFeedToUpdate = disposableDataFeed.DataFeed;

            SetOptionalMembers(dataFeedToUpdate, updatedDataFeedName);

            DataFeed updatedDataFeed = await adminClient.UpdateDataFeedAsync(dataFeedToUpdate);

            ValidateUpdatedDataFeedWithOptionalMembersSet(updatedDataFeed, dataFeedToUpdate.Id, updatedDataFeedName);
            ValidatePostgreSqlDataSource(updatedDataFeed.DataSource as PostgreSqlDataFeedSource);
        }

        [RecordedTest]
        public async Task UpdateSqlServerDataFeedWithMinimumSetup()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new SqlServerDataFeedSource(DataSourceConnectionString, DataSourceQuery);
            const string description = "This data feed was created to test the .NET client.";
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed dataFeedToUpdate = disposableDataFeed.DataFeed;

            dataFeedToUpdate.Description = description;

            DataFeed updatedDataFeed = await adminClient.UpdateDataFeedAsync(dataFeedToUpdate);

            ValidateDataFeedWithMinimumSetup(updatedDataFeed, dataFeedName, description, dataFeedToUpdate.Id);
            ValidateSqlServerDataSource(updatedDataFeed.DataSource as SqlServerDataFeedSource);
        }

        [RecordedTest]
        public async Task UpdateSqlServerDataFeedWithEveryMember()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var updatedDataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new SqlServerDataFeedSource(DataSourceConnectionString, DataSourceQuery);
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed dataFeedToUpdate = disposableDataFeed.DataFeed;

            SetOptionalMembers(dataFeedToUpdate, updatedDataFeedName);

            DataFeed updatedDataFeed = await adminClient.UpdateDataFeedAsync(dataFeedToUpdate);

            ValidateUpdatedDataFeedWithOptionalMembersSet(updatedDataFeed, dataFeedToUpdate.Id, updatedDataFeedName);
            ValidateSqlServerDataSource(updatedDataFeed.DataSource as SqlServerDataFeedSource);
        }

        [RecordedTest]
        [TestCase(AzureBlobDataFeedSource.AuthenticationType.Basic)]
        [TestCase(AzureBlobDataFeedSource.AuthenticationType.ManagedIdentity)]
        public async Task UpdateAzureBlobDataFeedWithAuthentication(AzureBlobDataFeedSource.AuthenticationType authentication)
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new AzureBlobDataFeedSource("mock", "mock", "mock");
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed dataFeedToUpdate = disposableDataFeed.DataFeed;
            AzureBlobDataFeedSource dataSourceToUpdate = dataFeedToUpdate.DataSource as AzureBlobDataFeedSource;

            dataSourceToUpdate.Authentication = authentication;

            DataFeed updatedDataFeed = await adminClient.UpdateDataFeedAsync(dataFeedToUpdate);
            AzureBlobDataFeedSource updatedDataSource = updatedDataFeed.DataSource as AzureBlobDataFeedSource;

            Assert.That(updatedDataSource.Authentication, Is.EqualTo(authentication));
        }

        [RecordedTest]
        [TestCase(AzureDataExplorerDataFeedSource.AuthenticationType.Basic)]
        [TestCase(AzureDataExplorerDataFeedSource.AuthenticationType.ManagedIdentity)]
        public async Task UpdateAzureDataExplorerDataFeedWithAuthentication(AzureDataExplorerDataFeedSource.AuthenticationType authentication)
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new AzureDataExplorerDataFeedSource("mock", "mock");
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed dataFeedToUpdate = disposableDataFeed.DataFeed;
            AzureDataExplorerDataFeedSource dataSourceToUpdate = dataFeedToUpdate.DataSource as AzureDataExplorerDataFeedSource;

            dataSourceToUpdate.Authentication = authentication;

            DataFeed updatedDataFeed = await adminClient.UpdateDataFeedAsync(dataFeedToUpdate);
            AzureDataExplorerDataFeedSource updatedDataSource = updatedDataFeed.DataSource as AzureDataExplorerDataFeedSource;

            Assert.That(updatedDataSource.Authentication, Is.EqualTo(authentication));
        }

        [RecordedTest]
        [TestCase(AzureDataExplorerDataFeedSource.AuthenticationType.ServicePrincipal)]
        [TestCase(AzureDataExplorerDataFeedSource.AuthenticationType.ServicePrincipalInKeyVault)]
        public async Task UpdateAzureDataExplorerDataFeedWithCredentialAuthentication(AzureDataExplorerDataFeedSource.AuthenticationType authentication)
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var credentialName = Recording.GenerateAlphaNumericId("credential");
            await using var disposableCredential = await DisposableDataSourceCredentialEntity.CreateDataSourceCredentialEntityAsync(adminClient, credentialName, authentication.ToString());
            string credentialId = disposableCredential.Credential.Id;

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new AzureDataExplorerDataFeedSource("mock", "mock");
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed dataFeedToUpdate = disposableDataFeed.DataFeed;
            AzureDataExplorerDataFeedSource dataSourceToUpdate = dataFeedToUpdate.DataSource as AzureDataExplorerDataFeedSource;

            dataSourceToUpdate.Authentication = authentication;
            dataSourceToUpdate.DataSourceCredentialId = credentialId;

            DataFeed updatedDataFeed = await adminClient.UpdateDataFeedAsync(dataFeedToUpdate);
            AzureDataExplorerDataFeedSource updatedDataSource = updatedDataFeed.DataSource as AzureDataExplorerDataFeedSource;

            Assert.That(updatedDataSource.Authentication, Is.EqualTo(authentication));
            Assert.That(updatedDataSource.DataSourceCredentialId, Is.EqualTo(credentialId));
        }

        [RecordedTest]
        public async Task UpdateAzureDataLakeStorageGen2DataFeedWithAuthentication()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new AzureDataLakeStorageGen2DataFeedSource("mock", "mock", "mock", "mock", "mock");
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed dataFeedToUpdate = disposableDataFeed.DataFeed;
            AzureDataLakeStorageGen2DataFeedSource dataSourceToUpdate = dataFeedToUpdate.DataSource as AzureDataLakeStorageGen2DataFeedSource;

            dataSourceToUpdate.Authentication = AzureDataLakeStorageGen2DataFeedSource.AuthenticationType.Basic;

            DataFeed updatedDataFeed = await adminClient.UpdateDataFeedAsync(dataFeedToUpdate);
            AzureDataLakeStorageGen2DataFeedSource updatedDataSource = updatedDataFeed.DataSource as AzureDataLakeStorageGen2DataFeedSource;

            Assert.That(updatedDataSource.Authentication, Is.EqualTo(AzureDataLakeStorageGen2DataFeedSource.AuthenticationType.Basic));
        }

        [RecordedTest]
        [TestCase(AzureDataLakeStorageGen2DataFeedSource.AuthenticationType.ServicePrincipal)]
        [TestCase(AzureDataLakeStorageGen2DataFeedSource.AuthenticationType.ServicePrincipalInKeyVault)]
        [TestCase(AzureDataLakeStorageGen2DataFeedSource.AuthenticationType.SharedKey)]
        public async Task UpdateAzureDataLakeStorageGen2DataFeedWithCredentialAuthentication(AzureDataLakeStorageGen2DataFeedSource.AuthenticationType authentication)
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var credentialName = Recording.GenerateAlphaNumericId("credential");
            await using var disposableCredential = await DisposableDataSourceCredentialEntity.CreateDataSourceCredentialEntityAsync(adminClient, credentialName, authentication.ToString());
            string credentialId = disposableCredential.Credential.Id;

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new AzureDataLakeStorageGen2DataFeedSource("mock", "mock", "mock", "mock", "mock");
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed dataFeedToUpdate = disposableDataFeed.DataFeed;
            AzureDataLakeStorageGen2DataFeedSource dataSourceToUpdate = dataFeedToUpdate.DataSource as AzureDataLakeStorageGen2DataFeedSource;

            dataSourceToUpdate.Authentication = authentication;
            dataSourceToUpdate.DataSourceCredentialId = credentialId;

            DataFeed updatedDataFeed = await adminClient.UpdateDataFeedAsync(dataFeedToUpdate);
            AzureDataLakeStorageGen2DataFeedSource updatedDataSource = updatedDataFeed.DataSource as AzureDataLakeStorageGen2DataFeedSource;

            Assert.That(updatedDataSource.Authentication, Is.EqualTo(authentication));
            Assert.That(updatedDataSource.DataSourceCredentialId, Is.EqualTo(credentialId));
        }

        [RecordedTest]
        [TestCase(SqlServerDataFeedSource.AuthenticationType.Basic)]
        [TestCase(SqlServerDataFeedSource.AuthenticationType.ManagedIdentity)]
        public async Task UpdateSqlServerDataFeedWithAuthentication(SqlServerDataFeedSource.AuthenticationType authentication)
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new SqlServerDataFeedSource("mock", "mock");
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed dataFeedToUpdate = disposableDataFeed.DataFeed;
            SqlServerDataFeedSource dataSourceToUpdate = dataFeedToUpdate.DataSource as SqlServerDataFeedSource;

            dataSourceToUpdate.Authentication = authentication;

            DataFeed updatedDataFeed = await adminClient.UpdateDataFeedAsync(dataFeedToUpdate);
            SqlServerDataFeedSource updatedDataSource = updatedDataFeed.DataSource as SqlServerDataFeedSource;

            Assert.That(updatedDataSource.Authentication, Is.EqualTo(authentication));
        }

        [RecordedTest]
        [TestCase(SqlServerDataFeedSource.AuthenticationType.ServicePrincipal)]
        [TestCase(SqlServerDataFeedSource.AuthenticationType.ServicePrincipalInKeyVault)]
        [TestCase(SqlServerDataFeedSource.AuthenticationType.SqlConnectionString)]
        public async Task UpdateSqlServerDataFeedWithCredentialAuthentication(SqlServerDataFeedSource.AuthenticationType authentication)
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var credentialName = Recording.GenerateAlphaNumericId("credential");
            await using var disposableCredential = await DisposableDataSourceCredentialEntity.CreateDataSourceCredentialEntityAsync(adminClient, credentialName, authentication.ToString());
            string credentialId = disposableCredential.Credential.Id;

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new SqlServerDataFeedSource("mock", "mock");
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed dataFeedToUpdate = disposableDataFeed.DataFeed;
            SqlServerDataFeedSource dataSourceToUpdate = dataFeedToUpdate.DataSource as SqlServerDataFeedSource;

            dataSourceToUpdate.Authentication = authentication;
            dataSourceToUpdate.DataSourceCredentialId = credentialId;

            DataFeed updatedDataFeed = await adminClient.UpdateDataFeedAsync(dataFeedToUpdate);
            SqlServerDataFeedSource updatedDataSource = updatedDataFeed.DataSource as SqlServerDataFeedSource;

            Assert.That(updatedDataSource.Authentication, Is.EqualTo(authentication));
            Assert.That(updatedDataSource.DataSourceCredentialId, Is.EqualTo(credentialId));
        }

        [RecordedTest]
        [TestCase(true)]
        [TestCase(false)]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/18004")]
        public async Task GetDataFeeds(bool useTokenCredential)
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient(useTokenCredential);

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
                Assert.That(dataFeed.CreatorEmail, Is.Not.Null.And.Not.Empty);
                Assert.That(dataFeed.AdministratorsEmails, Is.Not.Null);
                Assert.That(dataFeed.ViewersEmails, Is.Not.Null);
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
                    Assert.That(metric.Id, Is.Not.Null.And.Not.Empty);
                    Assert.That(metric.Name, Is.Not.Null.And.Not.Empty);
                    Assert.That(metric.DisplayName, Is.Not.Null.And.Not.Empty);
                    Assert.That(metric.Description, Is.Not.Null);
                }

                Assert.That(dataFeed.Schema.DimensionColumns, Is.Not.Null);

                foreach (DataFeedDimension dimensionColumn in dataFeed.Schema.DimensionColumns)
                {
                    Assert.That(dimensionColumn, Is.Not.Null);
                    Assert.That(dimensionColumn.Name, Is.Not.Null.And.Not.Empty);
                    Assert.That(dimensionColumn.DisplayName, Is.Not.Null.And.Not.Empty);
                }

                Assert.That(dataFeed.Schema.TimestampColumn, Is.Not.Null);

                Assert.That(dataFeed.IngestionSettings, Is.Not.Null);
                Assert.That(dataFeed.IngestionSettings.IngestionStartTime, Is.Not.EqualTo(default(DateTimeOffset)));
                Assert.That(dataFeed.IngestionSettings.IngestionStartOffset, Is.Not.Null);
                Assert.That(dataFeed.IngestionSettings.IngestionRetryDelay, Is.Not.Null);
                Assert.That(dataFeed.IngestionSettings.StopRetryAfter, Is.Not.Null);
                Assert.That(dataFeed.IngestionSettings.DataSourceRequestConcurrency, Is.Not.Null);

                ValidateGenericDataSource(dataFeed.DataSource, dataFeed.IsAdministrator.Value);

                if (++dataFeedCount >= MaximumSamplesCount)
                {
                    break;
                }
            }

            Assert.That(dataFeedCount, Is.GreaterThan(0));
        }

        [RecordedTest]
        [TestCase(true)]
        [TestCase(false)]
        public async Task DeleteDataFeed(bool useTokenCredential)
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient(useTokenCredential);

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new SqlServerDataFeedSource("connectionStr", "query");
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            string dataFeedId = null;

            try
            {
                DataFeed createdDataFeed = await adminClient.CreateDataFeedAsync(dataFeedToCreate);
                dataFeedId = createdDataFeed.Id;

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
            var ingestionStartTime = DateTimeOffset.Parse("2020-08-01T00:00:00Z");

            return new DataFeed()
            {
                Name = name,
                DataSource = dataSource,
                Granularity = new DataFeedGranularity(DataFeedGranularityType.Daily),
                Schema = new DataFeedSchema() { MetricColumns = { new("cost") } },
                IngestionSettings = new DataFeedIngestionSettings(ingestionStartTime)
            };
        }

        private DataFeed GetDataFeedWithOptionalMembersSet(string name, DataFeedSource dataSource)
        {
            var ingestionStartTime = DateTimeOffset.Parse("2020-08-01T00:00:00Z");

            var ingestionSettings = new DataFeedIngestionSettings(ingestionStartTime)
            {
                IngestionStartOffset = TimeSpan.FromMinutes(30),
                IngestionRetryDelay = TimeSpan.FromSeconds(80),
                StopRetryAfter = TimeSpan.FromMinutes(10),
                DataSourceRequestConcurrency = 5
            };

            var dataFeed = new DataFeed()
            {
                Name = name,
                DataSource = dataSource,
                Granularity = new DataFeedGranularity(DataFeedGranularityType.Custom) { CustomGranularityValue = 1360 },
                Schema = new DataFeedSchema() { TimestampColumn = "timestamp" },
                IngestionSettings = ingestionSettings,
                Description = "This data feed was created to test the .NET client.",
                AccessMode = DataFeedAccessMode.Public,
                ActionLinkTemplate = "https://fakeurl.com/%metric/%datafeed",
                MissingDataPointFillSettings = new(DataFeedMissingDataPointFillType.CustomValue) { CustomFillValue = 45.0 }
            };

            dataFeed.AdministratorsEmails.Add("fake@admin.com");
            dataFeed.ViewersEmails.Add("fake@viewer.com");

            dataFeed.Schema.MetricColumns.Add(new("cost") { DisplayName = "costDisplayName", Description = "costDescription" });
            dataFeed.Schema.MetricColumns.Add(new("revenue") { DisplayName = "revenueDisplayName", Description = "revenueDescription" });

            dataFeed.Schema.DimensionColumns.Add(new("city"));
            dataFeed.Schema.DimensionColumns.Add(new("category") { DisplayName = "categoryDisplayName" });

            return dataFeed;
        }

        private void SetOptionalMembers(DataFeed dataFeed, string dataFeedName)
        {
            dataFeed.Name = dataFeedName;
            dataFeed.Description = "This data feed was updated to test the .NET client.";
            dataFeed.AccessMode = DataFeedAccessMode.Public;
            dataFeed.ActionLinkTemplate = "https://fakeurl.com/%datafeed/%metric";

            // - If we're creating the data feed from scratch, currently the Administrators list has no elements.
            //   If we add a fake admin and send it to the service, it will overwrite the current list of admins,
            //   removing ourselves from the list. Doing so would cause permission errors during the next service
            //   calls.
            // - If we're updating a data feed obtained from a GetDataFeed operation, the Administrators list already
            //   includes our email. Even if we add new admins, this will not remove our admin role.
            //
            // For this reason, we do a conditional validation in the ValidateUpdatedDataFeedWithOptionalMembersSet
            // method.

            if (dataFeed.AdministratorsEmails.Count > 0)
            {
                dataFeed.AdministratorsEmails.Add("fake@admin.com");
            }

            dataFeed.ViewersEmails.Add("fake@viewer.com");

            dataFeed.Schema = new DataFeedSchema();
            dataFeed.Schema.TimestampColumn = "updatedTimestampColumn";

            dataFeed.IngestionSettings = new DataFeedIngestionSettings(DateTimeOffset.Parse("2020-09-21T00:00:00Z"));
            dataFeed.IngestionSettings.IngestionStartOffset = TimeSpan.FromMinutes(40);
            dataFeed.IngestionSettings.IngestionRetryDelay = TimeSpan.FromSeconds(90);
            dataFeed.IngestionSettings.StopRetryAfter = TimeSpan.FromMinutes(20);
            dataFeed.IngestionSettings.DataSourceRequestConcurrency = 6;

            dataFeed.MissingDataPointFillSettings = new(DataFeedMissingDataPointFillType.NoFilling);
        }

        private void ValidateDataFeedWithMinimumSetup(DataFeed dataFeed, string expectedName, string expectedDescription = "", string expectedId = null)
        {
            var ingestionStartTime = DateTimeOffset.Parse("2020-08-01T00:00:00Z");

            Assert.That(dataFeed, Is.Not.Null);
            Assert.That(dataFeed.Id, Is.Not.Null.And.Not.Empty);
            Assert.That(dataFeed.Name, Is.EqualTo(expectedName));
            Assert.That(dataFeed.Description, Is.EqualTo(expectedDescription));
            Assert.That(dataFeed.Status, Is.EqualTo(DataFeedStatus.Active));
            Assert.That(dataFeed.AccessMode, Is.EqualTo(DataFeedAccessMode.Private));
            Assert.That(dataFeed.ActionLinkTemplate, Is.Not.Null.And.Empty);
            Assert.That(dataFeed.CreatorEmail, Is.Not.Null.And.Not.Empty);
            Assert.That(dataFeed.AdministratorsEmails, Is.Not.Null);
            Assert.That(dataFeed.AdministratorsEmails.Single(), Is.EqualTo(dataFeed.CreatorEmail));
            Assert.That(dataFeed.ViewersEmails, Is.Not.Null.And.Empty);
            Assert.That(dataFeed.IsAdministrator, Is.True);

            if (expectedId != null)
            {
                Assert.That(dataFeed.Id, Is.EqualTo(expectedId));
            }

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
            Assert.That(metric.Id, Is.Not.Null.And.Not.Empty);
            Assert.That(metric.Name, Is.EqualTo("cost"));
            Assert.That(metric.DisplayName, Is.EqualTo("cost"));
            Assert.That(metric.Description, Is.Empty);

            Assert.That(dataFeed.Schema.DimensionColumns, Is.Not.Null.And.Empty);
            Assert.That(dataFeed.Schema.TimestampColumn, Is.Empty);

            Assert.That(dataFeed.IngestionSettings, Is.Not.Null);
            Assert.That(dataFeed.IngestionSettings.IngestionStartTime, Is.EqualTo(ingestionStartTime));
            Assert.That(dataFeed.IngestionSettings.IngestionStartOffset, Is.EqualTo(TimeSpan.Zero));
            Assert.That(dataFeed.IngestionSettings.IngestionRetryDelay, Is.EqualTo(TimeSpan.FromSeconds(-1)));
            Assert.That(dataFeed.IngestionSettings.StopRetryAfter, Is.EqualTo(TimeSpan.FromSeconds(-1)));
            Assert.That(dataFeed.IngestionSettings.DataSourceRequestConcurrency, Is.EqualTo(-1));
        }

        private void ValidateDataFeedWithOptionalMembersSet(DataFeed dataFeed, string expectedName)
        {
            var ingestionStartTime = DateTimeOffset.Parse("2020-08-01T00:00:00Z");

            Assert.That(dataFeed, Is.Not.Null);
            Assert.That(dataFeed.Id, Is.Not.Null.And.Not.Empty);
            Assert.That(dataFeed.Name, Is.EqualTo(expectedName));
            Assert.That(dataFeed.Description, Is.EqualTo("This data feed was created to test the .NET client."));
            Assert.That(dataFeed.Status, Is.EqualTo(DataFeedStatus.Active));
            Assert.That(dataFeed.AccessMode, Is.EqualTo(DataFeedAccessMode.Public));
            Assert.That(dataFeed.ActionLinkTemplate, Is.EqualTo("https://fakeurl.com/%metric/%datafeed"));
            Assert.That(dataFeed.CreatorEmail, Is.Not.Null.And.Not.Empty);

            Assert.That(dataFeed.AdministratorsEmails, Is.Not.Null);
            Assert.That(dataFeed.AdministratorsEmails.Count, Is.EqualTo(2));
            Assert.That(dataFeed.AdministratorsEmails, Contains.Item(dataFeed.CreatorEmail));
            Assert.That(dataFeed.AdministratorsEmails, Contains.Item("fake@admin.com"));
            Assert.That(dataFeed.ViewersEmails, Is.Not.Null);
            Assert.That(dataFeed.ViewersEmails.Count, Is.EqualTo(1));
            Assert.That(dataFeed.ViewersEmails, Contains.Item("fake@viewer.com"));
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
            Assert.That(metric0.Id, Is.Not.Null.And.Not.Empty);
            Assert.That(metric0.Name, Is.EqualTo("cost"));
            Assert.That(metric0.DisplayName, Is.EqualTo("costDisplayName"));
            Assert.That(metric0.Description, Is.EqualTo("costDescription"));

            Assert.That(metric1, Is.Not.Null);
            Assert.That(metric1.Id, Is.Not.Null.And.Not.Empty);
            Assert.That(metric1.Name, Is.EqualTo("revenue"));
            Assert.That(metric1.DisplayName, Is.EqualTo("revenueDisplayName"));
            Assert.That(metric1.Description, Is.EqualTo("revenueDescription"));

            Assert.That(dataFeed.Schema.DimensionColumns, Is.Not.Null);
            Assert.That(dataFeed.Schema.DimensionColumns.Count, Is.EqualTo(2));

            var sortedDimensionColumns = dataFeed.Schema.DimensionColumns.OrderBy(column => column.Name).ToList();

            Assert.That(sortedDimensionColumns[0].Name, Is.EqualTo("category"));
            Assert.That(sortedDimensionColumns[0].DisplayName, Is.EqualTo("categoryDisplayName"));
            Assert.That(sortedDimensionColumns[1].Name, Is.EqualTo("city"));
            Assert.That(sortedDimensionColumns[1].DisplayName, Is.EqualTo("city"));
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
            var ingestionStartTime = DateTimeOffset.Parse("2020-09-21T00:00:00Z");

            Assert.That(dataFeed.Id, Is.EqualTo(expectedId));
            Assert.That(dataFeed.Name, Is.EqualTo(expectedName));
            Assert.That(dataFeed.Description, Is.EqualTo("This data feed was updated to test the .NET client."));
            Assert.That(dataFeed.Status, Is.EqualTo(DataFeedStatus.Active));
            Assert.That(dataFeed.AccessMode, Is.EqualTo(DataFeedAccessMode.Public));
            Assert.That(dataFeed.ActionLinkTemplate, Is.EqualTo("https://fakeurl.com/%datafeed/%metric"));
            Assert.That(dataFeed.CreatorEmail, Is.Not.Null.And.Not.Empty);

            // In the SetOptionalMembers method, we may or may not add a new admin (fake@admin.com) depending on whether
            // the data feed instance used for the Update call was created from scratch or from a GetDataFeed operation:
            // - If the data feed to update was created from scratch, we didn't update the admins list (count = 1).
            // - If the data feed to update was created from a GetDataFeed operation, we added a new fake admin (count = 2).

            Assert.That(dataFeed.AdministratorsEmails, Is.Not.Null);
            Assert.That(dataFeed.AdministratorsEmails.Count, Is.EqualTo(1).Or.EqualTo(2));
            Assert.That(dataFeed.AdministratorsEmails, Contains.Item(dataFeed.CreatorEmail));

            if (dataFeed.AdministratorsEmails.Count == 2)
            {
                Assert.That(dataFeed.AdministratorsEmails, Contains.Item("fake@admin.com"));
            }

            Assert.That(dataFeed.ViewersEmails, Is.Not.Null);
            Assert.That(dataFeed.ViewersEmails.Count, Is.EqualTo(1));
            Assert.That(dataFeed.ViewersEmails, Contains.Item("fake@viewer.com"));

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
            Assert.That(metric.Id, Is.Not.Null.And.Not.Empty);
            Assert.That(metric.Name, Is.EqualTo("cost"));
            Assert.That(metric.DisplayName, Is.EqualTo("cost"));
            Assert.That(metric.Description, Is.Empty);

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
            Assert.That(dataSource, Is.Not.Null);
            Assert.That(dataSource.DataSourceType, Is.EqualTo(DataFeedSourceType.AzureApplicationInsights));
            Assert.That(dataSource.ApplicationId, Is.EqualTo(DataSourceAppId));
            Assert.That(dataSource.AzureCloud, Is.EqualTo(DataSourceCloud));
            Assert.That(dataSource.Query, Is.EqualTo(DataSourceQuery));
        }

        private void ValidateAzureBlobDataSource(AzureBlobDataFeedSource dataSource)
        {
            Assert.That(dataSource, Is.Not.Null);
            Assert.That(dataSource.DataSourceType, Is.EqualTo(DataFeedSourceType.AzureBlob));
            Assert.That(dataSource.Container, Is.EqualTo(DataSourceContainer));
            Assert.That(dataSource.BlobTemplate, Is.EqualTo(DataSourceTemplate));
        }

        private void ValidateAzureCosmosDbDataSource(AzureCosmosDbDataFeedSource dataSource)
        {
            Assert.That(dataSource, Is.Not.Null);
            Assert.That(dataSource.DataSourceType, Is.EqualTo(DataFeedSourceType.AzureCosmosDb));
            Assert.That(dataSource.SqlQuery, Is.EqualTo(DataSourceQuery));
            Assert.That(dataSource.Database, Is.EqualTo(DataSourceDatabase));
            Assert.That(dataSource.CollectionId, Is.EqualTo(DataSourceCollectionId));
        }

        private void ValidateAzureDataExplorerDataSource(AzureDataExplorerDataFeedSource dataSource)
        {
            Assert.That(dataSource, Is.Not.Null);
            Assert.That(dataSource.DataSourceType, Is.EqualTo(DataFeedSourceType.AzureDataExplorer));
            Assert.That(dataSource.Query, Is.EqualTo(DataSourceQuery));
        }

        private void ValidateAzureDataLakeStorageGen2DataSource(AzureDataLakeStorageGen2DataFeedSource dataSource)
        {
            Assert.That(dataSource, Is.Not.Null);
            Assert.That(dataSource.DataSourceType, Is.EqualTo(DataFeedSourceType.AzureDataLakeStorageGen2));
            Assert.That(dataSource.AccountName, Is.EqualTo(DataSourceAccount));
            Assert.That(dataSource.FileSystemName, Is.EqualTo(DataSourceFileSystem));
            Assert.That(dataSource.DirectoryTemplate, Is.EqualTo(DataSourceDirectory));
            Assert.That(dataSource.FileTemplate, Is.EqualTo(DataSourceFile));
        }

        private void ValidateAzureEventHubsDataSource(AzureEventHubsDataFeedSource dataSource)
        {
            Assert.That(dataSource, Is.Not.Null);
            Assert.That(dataSource.DataSourceType, Is.EqualTo(DataFeedSourceType.AzureEventHubs));
            Assert.That(dataSource.ConsumerGroup, Is.EqualTo(DataSourceConsumerGroup));
        }

        private void ValidateAzureTableDataSource(AzureTableDataFeedSource dataSource)
        {
            Assert.That(dataSource, Is.Not.Null);
            Assert.That(dataSource.DataSourceType, Is.EqualTo(DataFeedSourceType.AzureTable));
            Assert.That(dataSource.Table, Is.EqualTo(DataSourceTable));
            Assert.That(dataSource.Query, Is.EqualTo(DataSourceQuery));
        }

        private void ValidateInfluxDbDataSource(InfluxDbDataFeedSource dataSource)
        {
            Assert.That(dataSource, Is.Not.Null);
            Assert.That(dataSource.DataSourceType, Is.EqualTo(DataFeedSourceType.InfluxDb));
            Assert.That(dataSource.Database, Is.EqualTo(DataSourceDatabase));
            Assert.That(dataSource.Username, Is.EqualTo(DataSourceUsername));
            Assert.That(dataSource.Query, Is.EqualTo(DataSourceQuery));
        }

        private void ValidateLogAnalyticsDataSource(LogAnalyticsDataFeedSource dataSource)
        {
            Assert.That(dataSource, Is.Not.Null);
            Assert.That(dataSource.DataSourceType, Is.EqualTo(DataFeedSourceType.LogAnalytics));
            Assert.That(dataSource.WorkspaceId, Is.EqualTo(DataSourceWorkspaceId));
            Assert.That(dataSource.Query, Is.EqualTo(DataSourceQuery));
            Assert.That(dataSource.ClientId, Is.EqualTo(DataSourceClientId));
            Assert.That(dataSource.TenantId, Is.EqualTo(DataSourceTenantId));
        }

        private void ValidateMongoDbDataSource(MongoDbDataFeedSource dataSource)
        {
            Assert.That(dataSource, Is.Not.Null);
            Assert.That(dataSource.DataSourceType, Is.EqualTo(DataFeedSourceType.MongoDb));
            Assert.That(dataSource.Database, Is.EqualTo(DataSourceDatabase));
            Assert.That(dataSource.Command, Is.EqualTo(DataSourceCommand));
        }

        private void ValidateMySqlDataSource(MySqlDataFeedSource dataSource)
        {
            Assert.That(dataSource, Is.Not.Null);
            Assert.That(dataSource.DataSourceType, Is.EqualTo(DataFeedSourceType.MySql));
            Assert.That(dataSource.Query, Is.EqualTo(DataSourceQuery));
        }

        private void ValidatePostgreSqlDataSource(PostgreSqlDataFeedSource dataSource)
        {
            Assert.That(dataSource, Is.Not.Null);
            Assert.That(dataSource.DataSourceType, Is.EqualTo(DataFeedSourceType.PostgreSql));
            Assert.That(dataSource.Query, Is.EqualTo(DataSourceQuery));
        }

        private void ValidateSqlServerDataSource(SqlServerDataFeedSource dataSource)
        {
            Assert.That(dataSource, Is.Not.Null);
            Assert.That(dataSource.DataSourceType, Is.EqualTo(DataFeedSourceType.SqlServer));
            Assert.That(dataSource.Query, Is.EqualTo(DataSourceQuery));
        }

        private void ValidateGenericDataSource(DataFeedSource dataSource, bool isAdmin)
        {
            DataFeedSourceType sourceType = dataSource.DataSourceType;

            if (sourceType == DataFeedSourceType.AzureApplicationInsights)
            {
                var specificDataSource = dataSource as AzureApplicationInsightsDataFeedSource;

                Assert.That(specificDataSource, Is.Not.Null);

                if (isAdmin)
                {
                    Assert.That(specificDataSource.ApplicationId, Is.Not.Null.And.Not.Empty);
                    Assert.That(specificDataSource.AzureCloud, Is.Not.Null.And.Not.Empty);
                    Assert.That(specificDataSource.Query, Is.Not.Null.And.Not.Empty);
                }
                else
                {
                    Assert.That(specificDataSource.ApplicationId, Is.Null);
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
                    Assert.That(specificDataSource.Container, Is.Not.Null.And.Not.Empty);
                    Assert.That(specificDataSource.BlobTemplate, Is.Not.Null.And.Not.Empty);
                }
                else
                {
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
                    Assert.That(specificDataSource.SqlQuery, Is.Not.Null.And.Not.Empty);
                    Assert.That(specificDataSource.Database, Is.Not.Null.And.Not.Empty);
                    Assert.That(specificDataSource.CollectionId, Is.Not.Null.And.Not.Empty);
                }
                else
                {
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
                    Assert.That(specificDataSource.Query, Is.Not.Null.And.Not.Empty);
                }
                else
                {
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
                    Assert.That(specificDataSource.FileSystemName, Is.Not.Null.And.Not.Empty);
                    Assert.That(specificDataSource.DirectoryTemplate, Is.Not.Null.And.Not.Empty);
                    Assert.That(specificDataSource.FileTemplate, Is.Not.Null.And.Not.Empty);
                }
                else
                {
                    Assert.That(specificDataSource.AccountName, Is.Null);
                    Assert.That(specificDataSource.FileSystemName, Is.Null);
                    Assert.That(specificDataSource.DirectoryTemplate, Is.Null);
                    Assert.That(specificDataSource.FileTemplate, Is.Null);
                }
            }
            else if (sourceType == DataFeedSourceType.AzureEventHubs)
            {
                var specificDataSource = dataSource as AzureEventHubsDataFeedSource;

                Assert.That(specificDataSource, Is.Not.Null);

                if (isAdmin)
                {
                    Assert.That(specificDataSource.ConsumerGroup, Is.Not.Null.And.Not.Empty);
                }
                else
                {
                    Assert.That(specificDataSource.ConsumerGroup, Is.Null);
                }
            }
            else if (sourceType == DataFeedSourceType.AzureTable)
            {
                var specificDataSource = dataSource as AzureTableDataFeedSource;

                Assert.That(specificDataSource, Is.Not.Null);

                if (isAdmin)
                {
                    Assert.That(specificDataSource.Table, Is.Not.Null.And.Not.Empty);
                    Assert.That(specificDataSource.Query, Is.Not.Null.And.Not.Empty);
                }
                else
                {
                    Assert.That(specificDataSource.Table, Is.Null);
                    Assert.That(specificDataSource.Query, Is.Null);
                }
            }
            else if (sourceType == DataFeedSourceType.InfluxDb)
            {
                var specificDataSource = dataSource as InfluxDbDataFeedSource;

                Assert.That(specificDataSource, Is.Not.Null);

                if (isAdmin)
                {
                    Assert.That(specificDataSource.Database, Is.Not.Null.And.Not.Empty);
                    Assert.That(specificDataSource.Username, Is.Not.Null.And.Not.Empty);
                    Assert.That(specificDataSource.Query, Is.Not.Null.And.Not.Empty);
                }
                else
                {
                    Assert.That(specificDataSource.Database, Is.Null);
                    Assert.That(specificDataSource.Username, Is.Null);
                    Assert.That(specificDataSource.Query, Is.Null);
                }
            }
            else if (sourceType == DataFeedSourceType.LogAnalytics)
            {
                var specificDataSource = dataSource as LogAnalyticsDataFeedSource;

                Assert.That(specificDataSource, Is.Not.Null);

                if (isAdmin)
                {
                    Assert.That(specificDataSource.WorkspaceId, Is.Not.Null.And.Not.Empty);
                    Assert.That(specificDataSource.Query, Is.Not.Null.And.Not.Empty);
                    Assert.That(specificDataSource.ClientId, Is.Not.Null.And.Not.Empty);
                    Assert.That(specificDataSource.TenantId, Is.Not.Null.And.Not.Empty);
                }
                else
                {
                    Assert.That(specificDataSource.WorkspaceId, Is.Null);
                    Assert.That(specificDataSource.Query, Is.Null);
                    Assert.That(specificDataSource.ClientId, Is.Null);
                    Assert.That(specificDataSource.TenantId, Is.Null);
                }
            }
            else if (sourceType == DataFeedSourceType.MongoDb)
            {
                var specificDataSource = dataSource as MongoDbDataFeedSource;

                Assert.That(specificDataSource, Is.Not.Null);

                if (isAdmin)
                {
                    Assert.That(specificDataSource.Database, Is.Not.Null.And.Not.Empty);
                    Assert.That(specificDataSource.Command, Is.Not.Null.And.Not.Empty);
                }
                else
                {
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
                    Assert.That(specificDataSource.Query, Is.Not.Null.And.Not.Empty);
                }
                else
                {
                    Assert.That(specificDataSource.Query, Is.Null);
                }
            }
            else if (sourceType == DataFeedSourceType.PostgreSql)
            {
                var specificDataSource = dataSource as PostgreSqlDataFeedSource;

                Assert.That(specificDataSource, Is.Not.Null);

                if (isAdmin)
                {
                    Assert.That(specificDataSource.Query, Is.Not.Null.And.Not.Empty);
                }
                else
                {
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
                    Assert.That(specificDataSource.Query, Is.Not.Null.And.Not.Empty);
                }
                else
                {
                    Assert.That(specificDataSource.Query, Is.Null);
                }
            }
        }
    }
}
