// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Reflection;
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
        private string DataSourceAppId => Mode == RecordedTestMode.Live ? "appId" : EmptyGuid;
        private string DataSourceClientId => Mode == RecordedTestMode.Live ? "clientId" : EmptyGuid;
        private const string DataSourceCloud = "cloud";
        private const string DataSourceCollectionId = "collectId";
        private const string DataSourceCommand = "command";
        private const string DataSourceConsumerGroup = "consumerGroup";
        private const string DataSourceContainer = "container";
        private const string DataSourceDatabase = "database";
        private const string DataSourceDirectory = "dir";
        private const string DataSourceFile = "file";
        private const string DataSourceFileSystem = "fileSystem";
        private const string DataSourceQuery = "query";
        private const string DataSourceTable = "table";
        private const string DataSourceTemplate = "template";
        private string DataSourceTenantId => Mode == RecordedTestMode.Live ? "tenantId" : EmptyGuid;
        private string DataSourceUsername => Mode == RecordedTestMode.Live ? "username" : SanitizeValue;
        private const string DataSourceWorkspaceId = "workspaceId";

        private static string[] DataFeedSourceTestCases =
        {
            nameof(DataFeedSourceKind.AzureApplicationInsights),
            nameof(DataFeedSourceKind.AzureBlob),
            nameof(DataFeedSourceKind.AzureCosmosDb),
            nameof(DataFeedSourceKind.AzureDataExplorer),
            nameof(DataFeedSourceKind.AzureDataLakeStorage),
            nameof(DataFeedSourceKind.AzureEventHubs),
            nameof(DataFeedSourceKind.AzureTable),
            nameof(DataFeedSourceKind.InfluxDb),
            nameof(DataFeedSourceKind.LogAnalytics),
            nameof(DataFeedSourceKind.MongoDb),
            nameof(DataFeedSourceKind.MySql),
            nameof(DataFeedSourceKind.PostgreSql),
            nameof(DataFeedSourceKind.SqlServer)
        };

        public DataFeedLiveTests(bool isAsync) : base(isAsync)
        {
        }

        private DateTimeOffset IngestionStartsOnForCustom
        {
            get
            {
                DateTimeOffset startsOn = Recording.UtcNow.Subtract(TimeSpan.FromDays(2));
                return new DateTimeOffset(startsOn.Year, startsOn.Month, startsOn.Day, startsOn.Hour, startsOn.Minute, 0, TimeSpan.Zero);
            }
        }

        [RecordedTest]
        public async Task CreateAndGetWithTokenCredential()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient(useTokenCredential: true);

            string dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            DataFeedSource dataSource = CreateDataFeedSource(nameof(DataFeedSourceKind.AzureApplicationInsights));
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed createdDataFeed = disposableDataFeed.DataFeed;

            Assert.That(createdDataFeed.Id, Is.Not.Null.And.Not.Empty);
        }

        [RecordedTest]
        [TestCaseSource(nameof(DataFeedSourceTestCases))]
        public async Task CreateAndGetWithMinimumSetup(string dataSourceKind)
        {
            // https://github.com/Azure/azure-sdk-for-net/issues/21623
            if (dataSourceKind == nameof(DataFeedSourceKind.AzureEventHubs))
            {
                Assert.Ignore();
            }

            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            string dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            DataFeedSource dataSource = CreateDataFeedSource(dataSourceKind);
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed createdDataFeed = disposableDataFeed.DataFeed;

            ValidateDataFeedWithMinimumSetup(createdDataFeed, dataFeedName);
            ValidateDataFeedSource(createdDataFeed.DataSource, dataSourceKind);
        }

        [RecordedTest]
        [TestCaseSource(nameof(DataFeedSourceTestCases))]
        public async Task CreateAndGetWithOptionalMembers(string dataSourceKind)
        {
            // https://github.com/Azure/azure-sdk-for-net/issues/21623
            if (dataSourceKind == nameof(DataFeedSourceKind.AzureEventHubs))
            {
                Assert.Ignore();
            }

            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            string dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            DataFeedSource dataSource = CreateDataFeedSource(dataSourceKind);
            DateTimeOffset ingestionStartsOn = IngestionStartsOnForCustom;
            DataFeed dataFeedToCreate = GetDataFeedWithOptionalMembersSet(dataFeedName, dataSource, ingestionStartsOn);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed createdDataFeed = disposableDataFeed.DataFeed;

            ValidateDataFeedWithOptionalMembersSet(createdDataFeed, dataFeedName, ingestionStartsOn);
            ValidateDataFeedSource(createdDataFeed.DataSource, dataSourceKind);
        }

        [RecordedTest]
        [TestCase("Basic")]
        [TestCase("ManagedIdentity")]
        public async Task CreateAndGetAzureBlobDataFeedWithAuthentication(string authenticationType)
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();
            AzureBlobDataFeedSource.AuthenticationType authentication =
                GetAuthenticationInstance<AzureBlobDataFeedSource.AuthenticationType>(authenticationType);

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
        [TestCase("Basic")]
        [TestCase("ManagedIdentity")]
        public async Task CreateAndGetAzureDataExplorerDataFeedWithAuthentication(string authenticationType)
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();
            AzureDataExplorerDataFeedSource.AuthenticationType authentication =
                GetAuthenticationInstance<AzureDataExplorerDataFeedSource.AuthenticationType>(authenticationType);

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
        [TestCase("ServicePrincipal")]
        [TestCase("ServicePrincipalInKeyVault")]
        public async Task CreateAndGetAzureDataExplorerDataFeedWithCredentialAuthentication(string authenticationType)
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();
            AzureDataExplorerDataFeedSource.AuthenticationType authentication =
                GetAuthenticationInstance<AzureDataExplorerDataFeedSource.AuthenticationType>(authenticationType);

            var credentialName = Recording.GenerateAlphaNumericId("credential");
            await using var disposableCredential = await DisposableDataSourceCredentialEntity.CreateDataSourceCredentialEntityAsync(adminClient, credentialName, authenticationType);
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
        public async Task CreateAndGetAzureDataLakeStorageDataFeedWithAuthentication()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new AzureDataLakeStorageDataFeedSource("mock", "mock", "mock", "mock", "mock")
            {
                Authentication = AzureDataLakeStorageDataFeedSource.AuthenticationType.Basic
            };
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed createdDataFeed = disposableDataFeed.DataFeed;
            AzureDataLakeStorageDataFeedSource createdDataSource = createdDataFeed.DataSource as AzureDataLakeStorageDataFeedSource;

            Assert.That(createdDataSource.Authentication, Is.EqualTo(AzureDataLakeStorageDataFeedSource.AuthenticationType.Basic));
        }

        [RecordedTest]
        [TestCase("ServicePrincipal")]
        [TestCase("ServicePrincipalInKeyVault")]
        [TestCase("SharedKey")]
        public async Task CreateAndGetAzureDataLakeStorageDataFeedWithCredentialAuthentication(string authenticationType)
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();
            AzureDataLakeStorageDataFeedSource.AuthenticationType authentication =
                GetAuthenticationInstance<AzureDataLakeStorageDataFeedSource.AuthenticationType>(authenticationType);

            var credentialName = Recording.GenerateAlphaNumericId("credential");
            await using var disposableCredential = await DisposableDataSourceCredentialEntity.CreateDataSourceCredentialEntityAsync(adminClient, credentialName, authenticationType);
            string credentialId = disposableCredential.Credential.Id;

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new AzureDataLakeStorageDataFeedSource("mock", "mock", "mock", "mock", "mock")
            {
                Authentication = authentication,
                DataSourceCredentialId = credentialId
            };
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed createdDataFeed = disposableDataFeed.DataFeed;
            AzureDataLakeStorageDataFeedSource createdDataSource = createdDataFeed.DataSource as AzureDataLakeStorageDataFeedSource;

            Assert.That(createdDataSource.Authentication, Is.EqualTo(authentication));
            Assert.That(createdDataSource.DataSourceCredentialId, Is.EqualTo(credentialId));
        }

        [RecordedTest]
        [TestCase("Basic")]
        [TestCase("ManagedIdentity")]
        public async Task CreateAndGetSqlServerDataFeedWithAuthentication(string authenticationType)
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();
            SqlServerDataFeedSource.AuthenticationType authentication =
                GetAuthenticationInstance<SqlServerDataFeedSource.AuthenticationType>(authenticationType);

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
        [TestCase("ServicePrincipal")]
        [TestCase("ServicePrincipalInKeyVault")]
        [TestCase("SqlConnectionString")]
        public async Task CreateAndGetSqlServerDataFeedWithCredentialAuthentication(string authenticationType)
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();
            SqlServerDataFeedSource.AuthenticationType authentication =
                GetAuthenticationInstance<SqlServerDataFeedSource.AuthenticationType>(authenticationType);

            var credentialName = Recording.GenerateAlphaNumericId("credential");
            await using var disposableCredential = await DisposableDataSourceCredentialEntity.CreateDataSourceCredentialEntityAsync(adminClient, credentialName, authenticationType);
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
        public async Task UpdateWithTokenCredential()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient(useTokenCredential: true);

            string dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            string description = "This data feed was created to test the .NET client.";
            DataFeedSource dataSource = CreateDataFeedSource(nameof(DataFeedSourceKind.AzureBlob));
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed dataFeedToUpdate = disposableDataFeed.DataFeed;

            dataFeedToUpdate.Description = description;

            DataFeed updatedDataFeed = await adminClient.UpdateDataFeedAsync(dataFeedToUpdate);

            Assert.That(updatedDataFeed.Description, Is.EqualTo(description));
        }

        [RecordedTest]
        [TestCaseSource(nameof(DataFeedSourceTestCases))]
        public async Task UpdateWithMinimumSetup(string dataSourceKind)
        {
            // https://github.com/Azure/azure-sdk-for-net/issues/21623
            if (dataSourceKind == nameof(DataFeedSourceKind.AzureEventHubs))
            {
                Assert.Ignore();
            }

            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            string dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            string description = "This data feed was created to test the .NET client.";
            DataFeedSource dataSource = CreateDataFeedSource(dataSourceKind);
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed dataFeedToUpdate = disposableDataFeed.DataFeed;

            dataFeedToUpdate.Description = description;

            DataFeed updatedDataFeed = await adminClient.UpdateDataFeedAsync(dataFeedToUpdate);

            ValidateDataFeedWithMinimumSetup(updatedDataFeed, dataFeedName, description, dataFeedToUpdate.Id);
            ValidateDataFeedSource(updatedDataFeed.DataSource, dataSourceKind);
        }

        [RecordedTest]
        [TestCaseSource(nameof(DataFeedSourceTestCases))]
        public async Task UpdateWithEveryMember(string dataSourceKind)
        {
            // https://github.com/Azure/azure-sdk-for-net/issues/21623
            if (dataSourceKind == nameof(DataFeedSourceKind.AzureEventHubs))
            {
                Assert.Ignore();
            }

            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            string dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            string updatedDataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            DataFeedSource dataSource = CreateDataFeedSource(dataSourceKind);
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed dataFeedToUpdate = disposableDataFeed.DataFeed;

            SetOptionalMembers(dataFeedToUpdate, updatedDataFeedName);

            DataFeed updatedDataFeed = await adminClient.UpdateDataFeedAsync(dataFeedToUpdate);

            ValidateUpdatedDataFeedWithOptionalMembersSet(updatedDataFeed, dataFeedToUpdate.Id, updatedDataFeedName);
            ValidateDataFeedSource(updatedDataFeed.DataSource, dataSourceKind);
        }

        [RecordedTest]
        [TestCase("Basic")]
        [TestCase("ManagedIdentity")]
        public async Task UpdateAzureBlobDataFeedWithAuthentication(string authenticationType)
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();
            AzureBlobDataFeedSource.AuthenticationType authentication =
                GetAuthenticationInstance<AzureBlobDataFeedSource.AuthenticationType>(authenticationType);

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
        [TestCase("Basic")]
        [TestCase("ManagedIdentity")]
        public async Task UpdateAzureDataExplorerDataFeedWithAuthentication(string authenticationType)
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();
            AzureDataExplorerDataFeedSource.AuthenticationType authentication =
                GetAuthenticationInstance<AzureDataExplorerDataFeedSource.AuthenticationType>(authenticationType);

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
        [TestCase("ServicePrincipal")]
        [TestCase("ServicePrincipalInKeyVault")]
        public async Task UpdateAzureDataExplorerDataFeedWithCredentialAuthentication(string authenticationType)
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();
            AzureDataExplorerDataFeedSource.AuthenticationType authentication =
                GetAuthenticationInstance<AzureDataExplorerDataFeedSource.AuthenticationType>(authenticationType);

            var credentialName = Recording.GenerateAlphaNumericId("credential");
            await using var disposableCredential = await DisposableDataSourceCredentialEntity.CreateDataSourceCredentialEntityAsync(adminClient, credentialName, authenticationType);
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
        public async Task UpdateAzureDataLakeStorageDataFeedWithAuthentication()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new AzureDataLakeStorageDataFeedSource("mock", "mock", "mock", "mock", "mock");
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed dataFeedToUpdate = disposableDataFeed.DataFeed;
            AzureDataLakeStorageDataFeedSource dataSourceToUpdate = dataFeedToUpdate.DataSource as AzureDataLakeStorageDataFeedSource;

            dataSourceToUpdate.Authentication = AzureDataLakeStorageDataFeedSource.AuthenticationType.Basic;

            DataFeed updatedDataFeed = await adminClient.UpdateDataFeedAsync(dataFeedToUpdate);
            AzureDataLakeStorageDataFeedSource updatedDataSource = updatedDataFeed.DataSource as AzureDataLakeStorageDataFeedSource;

            Assert.That(updatedDataSource.Authentication, Is.EqualTo(AzureDataLakeStorageDataFeedSource.AuthenticationType.Basic));
        }

        [RecordedTest]
        [TestCase("ServicePrincipal")]
        [TestCase("ServicePrincipalInKeyVault")]
        [TestCase("SharedKey")]
        public async Task UpdateAzureDataLakeStorageDataFeedWithCredentialAuthentication(string authenticationType)
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();
            AzureDataLakeStorageDataFeedSource.AuthenticationType authentication =
                GetAuthenticationInstance<AzureDataLakeStorageDataFeedSource.AuthenticationType>(authenticationType);

            var credentialName = Recording.GenerateAlphaNumericId("credential");
            await using var disposableCredential = await DisposableDataSourceCredentialEntity.CreateDataSourceCredentialEntityAsync(adminClient, credentialName, authenticationType);
            string credentialId = disposableCredential.Credential.Id;

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new AzureDataLakeStorageDataFeedSource("mock", "mock", "mock", "mock", "mock");
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed dataFeedToUpdate = disposableDataFeed.DataFeed;
            AzureDataLakeStorageDataFeedSource dataSourceToUpdate = dataFeedToUpdate.DataSource as AzureDataLakeStorageDataFeedSource;

            dataSourceToUpdate.Authentication = authentication;
            dataSourceToUpdate.DataSourceCredentialId = credentialId;

            DataFeed updatedDataFeed = await adminClient.UpdateDataFeedAsync(dataFeedToUpdate);
            AzureDataLakeStorageDataFeedSource updatedDataSource = updatedDataFeed.DataSource as AzureDataLakeStorageDataFeedSource;

            Assert.That(updatedDataSource.Authentication, Is.EqualTo(authentication));
            Assert.That(updatedDataSource.DataSourceCredentialId, Is.EqualTo(credentialId));
        }

        [RecordedTest]
        [TestCase("Basic")]
        [TestCase("ManagedIdentity")]
        public async Task UpdateSqlServerDataFeedWithAuthentication(string authenticationType)
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();
            SqlServerDataFeedSource.AuthenticationType authentication =
                GetAuthenticationInstance<SqlServerDataFeedSource.AuthenticationType>(authenticationType);

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
        [TestCase("ServicePrincipal")]
        [TestCase("ServicePrincipalInKeyVault")]
        [TestCase("SqlConnectionString")]
        public async Task UpdateSqlServerDataFeedWithCredentialAuthentication(string authenticationType)
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();
            SqlServerDataFeedSource.AuthenticationType authentication =
                GetAuthenticationInstance<SqlServerDataFeedSource.AuthenticationType>(authenticationType);

            var credentialName = Recording.GenerateAlphaNumericId("credential");
            await using var disposableCredential = await DisposableDataSourceCredentialEntity.CreateDataSourceCredentialEntityAsync(adminClient, credentialName, authenticationType);
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
        [TestCaseSource(nameof(DataFeedSourceTestCases))]
        public async Task UpdateCommonMembersWithNullSetsToDefault(string dataSourceKind)
        {
            // https://github.com/Azure/azure-sdk-for-net/issues/21623
            if (dataSourceKind == nameof(DataFeedSourceKind.AzureEventHubs))
            {
                Assert.Ignore();
            }

            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            string dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            DataFeedSource dataSource = CreateMockDataFeedSource(dataSourceKind);
            var dataFeedToCreate = new DataFeed()
            {
                Name = dataFeedName,
                DataSource = dataSource,
                Granularity = new DataFeedGranularity(DataFeedGranularityType.Daily),
                IngestionSettings = new DataFeedIngestionSettings(DateTimeOffset.Parse("2021-01-01T00:00:00Z"))
                {
                    IngestionStartOffset = TimeSpan.FromMinutes(1),
                    IngestionRetryDelay = TimeSpan.FromMinutes(1),
                    StopRetryAfter = TimeSpan.FromMinutes(1),
                    DataSourceRequestConcurrency = 1
                },
                Schema = new DataFeedSchema()
                {
                    MetricColumns = { new DataFeedMetric("metric") },
                    DimensionColumns = { new DataFeedDimension("dimension") },
                    TimestampColumn = "timestamp"
                },
                Description = "description",
                RollupSettings = new DataFeedRollupSettings()
                {
                    RollupType = DataFeedRollupType.RollupNeeded,
                    AutoRollupMethod = DataFeedAutoRollupMethod.Sum,
                    RollupIdentificationValue = "dimension"
                },
                MissingDataPointFillSettings = new DataFeedMissingDataPointFillSettings(DataFeedMissingDataPointFillType.NoFilling),
                AccessMode = DataFeedAccessMode.Public,
                ActionLinkTemplate = "https://fakeurl.com/%datafeed/%metric"
            };

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed dataFeedToUpdate = disposableDataFeed.DataFeed;

            dataFeedToUpdate.IngestionSettings.IngestionStartOffset = null;
            dataFeedToUpdate.IngestionSettings.IngestionRetryDelay = null;
            dataFeedToUpdate.IngestionSettings.StopRetryAfter = null;
            dataFeedToUpdate.IngestionSettings.DataSourceRequestConcurrency = null;
            dataFeedToUpdate.Schema.TimestampColumn = null;
            dataFeedToUpdate.Description = null;
            dataFeedToUpdate.RollupSettings.RollupType = null;
            dataFeedToUpdate.RollupSettings.AutoRollupMethod = null;
            dataFeedToUpdate.RollupSettings.RollupIdentificationValue = null;
            dataFeedToUpdate.MissingDataPointFillSettings = null;
            dataFeedToUpdate.AccessMode = null;
            dataFeedToUpdate.ActionLinkTemplate = null;

            DataFeed updatedDataFeed = await adminClient.UpdateDataFeedAsync(dataFeedToUpdate);

            Assert.That(updatedDataFeed.IngestionSettings.IngestionStartOffset, Is.EqualTo(TimeSpan.Zero));
            Assert.That(updatedDataFeed.IngestionSettings.IngestionRetryDelay, Is.EqualTo(TimeSpan.FromSeconds(-1)));
            Assert.That(updatedDataFeed.IngestionSettings.StopRetryAfter, Is.EqualTo(TimeSpan.FromSeconds(-1)));
            Assert.That(updatedDataFeed.IngestionSettings.DataSourceRequestConcurrency, Is.EqualTo(-1));
            Assert.That(updatedDataFeed.Schema.TimestampColumn, Is.Empty);
            Assert.That(updatedDataFeed.Description, Is.Empty);
            Assert.That(updatedDataFeed.RollupSettings.RollupType, Is.EqualTo(DataFeedRollupType.NoRollupNeeded));
            Assert.That(updatedDataFeed.RollupSettings.AutoRollupMethod, Is.EqualTo(DataFeedAutoRollupMethod.None));
            Assert.That(updatedDataFeed.RollupSettings.RollupIdentificationValue, Is.Null);
            Assert.That(updatedDataFeed.MissingDataPointFillSettings.FillType, Is.EqualTo(DataFeedMissingDataPointFillType.SmartFilling));
            Assert.That(updatedDataFeed.AccessMode, Is.EqualTo(DataFeedAccessMode.Private));
            Assert.That(updatedDataFeed.ActionLinkTemplate, Is.Empty);
        }

        [RecordedTest]
        public async Task UpdateAzureBlobDataFeedAuthenticationWithNullSetsToDefault()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            string dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new AzureBlobDataFeedSource("mock", "mock", "mock")
            {
                Authentication = AzureBlobDataFeedSource.AuthenticationType.ManagedIdentity
            };
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed dataFeedToUpdate = disposableDataFeed.DataFeed;
            AzureBlobDataFeedSource dataSourceToUpdate = dataFeedToUpdate.DataSource as AzureBlobDataFeedSource;

            dataSourceToUpdate.Authentication = null;

            DataFeed updatedDataFeed = await adminClient.UpdateDataFeedAsync(dataFeedToUpdate);
            AzureBlobDataFeedSource updatedDataSource = updatedDataFeed.DataSource as AzureBlobDataFeedSource;

            Assert.That(updatedDataSource.Authentication, Is.EqualTo(AzureBlobDataFeedSource.AuthenticationType.Basic));
        }

        [RecordedTest]
        public async Task UpdateAzureDataExplorerDataFeedAuthenticationWithNullSetsToDefault()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var credentialName = Recording.GenerateAlphaNumericId("credential");
            await using var disposableCredential = await DisposableDataSourceCredentialEntity.CreateDataSourceCredentialEntityAsync(adminClient, credentialName, "ServicePrincipal");
            string credentialId = disposableCredential.Credential.Id;

            string dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new AzureDataExplorerDataFeedSource("mock", "mock")
            {
                Authentication = AzureDataExplorerDataFeedSource.AuthenticationType.ServicePrincipal,
                DataSourceCredentialId = credentialId
            };
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed dataFeedToUpdate = disposableDataFeed.DataFeed;
            AzureDataExplorerDataFeedSource dataSourceToUpdate = dataFeedToUpdate.DataSource as AzureDataExplorerDataFeedSource;

            dataSourceToUpdate.Authentication = null;
            dataSourceToUpdate.DataSourceCredentialId = null;

            DataFeed updatedDataFeed = await adminClient.UpdateDataFeedAsync(dataFeedToUpdate);
            AzureDataExplorerDataFeedSource updatedDataSource = updatedDataFeed.DataSource as AzureDataExplorerDataFeedSource;

            Assert.That(updatedDataSource.Authentication, Is.EqualTo(AzureDataExplorerDataFeedSource.AuthenticationType.Basic));
            Assert.That(updatedDataSource.DataSourceCredentialId, Is.Null);
        }

        [RecordedTest]
        public async Task UpdateAzureDataLakeStorageDataFeedAuthenticationWithNullSetsToDefault()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var credentialName = Recording.GenerateAlphaNumericId("credential");
            await using var disposableCredential = await DisposableDataSourceCredentialEntity.CreateDataSourceCredentialEntityAsync(adminClient, credentialName, "ServicePrincipal");
            string credentialId = disposableCredential.Credential.Id;

            string dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new AzureDataLakeStorageDataFeedSource("mock", "mock", "mock", "mock", "mock")
            {
                Authentication = AzureDataLakeStorageDataFeedSource.AuthenticationType.ServicePrincipal,
                DataSourceCredentialId = credentialId
            };
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed dataFeedToUpdate = disposableDataFeed.DataFeed;
            AzureDataLakeStorageDataFeedSource dataSourceToUpdate = dataFeedToUpdate.DataSource as AzureDataLakeStorageDataFeedSource;

            dataSourceToUpdate.Authentication = null;
            dataSourceToUpdate.DataSourceCredentialId = null;

            DataFeed updatedDataFeed = await adminClient.UpdateDataFeedAsync(dataFeedToUpdate);
            AzureDataLakeStorageDataFeedSource updatedDataSource = updatedDataFeed.DataSource as AzureDataLakeStorageDataFeedSource;

            Assert.That(updatedDataSource.Authentication, Is.EqualTo(AzureDataLakeStorageDataFeedSource.AuthenticationType.Basic));
            Assert.That(updatedDataSource.DataSourceCredentialId, Is.Null);
        }

        [RecordedTest]
        public async Task UpdateSqlServerDataFeedAuthenticationWithNullSetsToDefault()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var credentialName = Recording.GenerateAlphaNumericId("credential");
            await using var disposableCredential = await DisposableDataSourceCredentialEntity.CreateDataSourceCredentialEntityAsync(adminClient, credentialName, "ServicePrincipal");
            string credentialId = disposableCredential.Credential.Id;

            string dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new SqlServerDataFeedSource("mock", "mock")
            {
                Authentication = SqlServerDataFeedSource.AuthenticationType.ServicePrincipal,
                DataSourceCredentialId = credentialId
            };
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed dataFeedToUpdate = disposableDataFeed.DataFeed;
            SqlServerDataFeedSource dataSourceToUpdate = dataFeedToUpdate.DataSource as SqlServerDataFeedSource;

            dataSourceToUpdate.Authentication = null;
            dataSourceToUpdate.DataSourceCredentialId = null;

            DataFeed updatedDataFeed = await adminClient.UpdateDataFeedAsync(dataFeedToUpdate);
            SqlServerDataFeedSource updatedDataSource = updatedDataFeed.DataSource as SqlServerDataFeedSource;

            Assert.That(updatedDataSource.Authentication, Is.EqualTo(SqlServerDataFeedSource.AuthenticationType.Basic));
            Assert.That(updatedDataSource.DataSourceCredentialId, Is.Null);
        }

        [RecordedTest]
        [TestCase(true)]
        [TestCase(false)]
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
                Assert.That(dataFeed.Creator, Is.Not.Null.And.Not.Empty);
                Assert.That(dataFeed.Administrators, Is.Not.Null);
                Assert.That(dataFeed.Viewers, Is.Not.Null);
                Assert.That(dataFeed.IsAdministrator, Is.Not.Null);
                Assert.That(dataFeed.CreatedOn, Is.Not.Null);
                Assert.That(dataFeed.CreatedOn, Is.Not.EqualTo(default(DateTimeOffset)));

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
                Assert.That(dataFeed.IngestionSettings.IngestionStartsOn, Is.Not.EqualTo(default(DateTimeOffset)));
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

        private DataFeed GetDataFeedWithOptionalMembersSet(string name, DataFeedSource dataSource, DateTimeOffset ingestionStartsOn)
        {
            var ingestionSettings = new DataFeedIngestionSettings(ingestionStartsOn)
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
                Granularity = new DataFeedGranularity(DataFeedGranularityType.Custom) { CustomGranularityValue = 3000 },
                Schema = new DataFeedSchema() { TimestampColumn = "timestamp" },
                IngestionSettings = ingestionSettings,
                Description = "This data feed was created to test the .NET client.",
                AccessMode = DataFeedAccessMode.Public,
                ActionLinkTemplate = "https://fakeurl.com/%metric/%datafeed",
                MissingDataPointFillSettings = new(DataFeedMissingDataPointFillType.CustomValue) { CustomFillValue = 45.0 }
            };

            dataFeed.Administrators.Add("fake@admin.com");
            dataFeed.Viewers.Add("fake@viewer.com");

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

            if (dataFeed.Administrators.Count > 0)
            {
                dataFeed.Administrators.Add("fake@admin.com");
            }

            dataFeed.Viewers.Add("fake@viewer.com");

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
            Assert.That(dataFeed.Creator, Is.Not.Null.And.Not.Empty);
            Assert.That(dataFeed.Administrators, Is.Not.Null);
            Assert.That(dataFeed.Administrators.Single(), Is.EqualTo(dataFeed.Creator));
            Assert.That(dataFeed.Viewers, Is.Not.Null.And.Empty);
            Assert.That(dataFeed.IsAdministrator, Is.True);

            if (expectedId != null)
            {
                Assert.That(dataFeed.Id, Is.EqualTo(expectedId));
            }

            DateTimeOffset justNow = Recording.UtcNow.Subtract(TimeSpan.FromMinutes(5));
            Assert.That(dataFeed.CreatedOn, Is.GreaterThan(justNow));

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
            Assert.That(dataFeed.IngestionSettings.IngestionStartsOn, Is.EqualTo(ingestionStartTime));
            Assert.That(dataFeed.IngestionSettings.IngestionStartOffset, Is.EqualTo(TimeSpan.Zero));
            Assert.That(dataFeed.IngestionSettings.IngestionRetryDelay, Is.EqualTo(TimeSpan.FromSeconds(-1)));
            Assert.That(dataFeed.IngestionSettings.StopRetryAfter, Is.EqualTo(TimeSpan.FromSeconds(-1)));
            Assert.That(dataFeed.IngestionSettings.DataSourceRequestConcurrency, Is.EqualTo(-1));
        }

        private void ValidateDataFeedWithOptionalMembersSet(DataFeed dataFeed, string expectedName, DateTimeOffset expectedIngestionStartsOn)
        {
            Assert.That(dataFeed, Is.Not.Null);
            Assert.That(dataFeed.Id, Is.Not.Null.And.Not.Empty);
            Assert.That(dataFeed.Name, Is.EqualTo(expectedName));
            Assert.That(dataFeed.Description, Is.EqualTo("This data feed was created to test the .NET client."));
            Assert.That(dataFeed.Status, Is.EqualTo(DataFeedStatus.Active));
            Assert.That(dataFeed.AccessMode, Is.EqualTo(DataFeedAccessMode.Public));
            Assert.That(dataFeed.ActionLinkTemplate, Is.EqualTo("https://fakeurl.com/%metric/%datafeed"));
            Assert.That(dataFeed.Creator, Is.Not.Null.And.Not.Empty);

            Assert.That(dataFeed.Administrators, Is.Not.Null);
            Assert.That(dataFeed.Administrators.Count, Is.EqualTo(2));
            Assert.That(dataFeed.Administrators, Contains.Item(dataFeed.Creator));
            Assert.That(dataFeed.Administrators, Contains.Item("fake@admin.com"));
            Assert.That(dataFeed.Viewers, Is.Not.Null);
            Assert.That(dataFeed.Viewers.Count, Is.EqualTo(1));
            Assert.That(dataFeed.Viewers, Contains.Item("fake@viewer.com"));
            Assert.That(dataFeed.IsAdministrator, Is.True);

            DateTimeOffset justNow = Recording.UtcNow.Subtract(TimeSpan.FromMinutes(5));
            Assert.That(dataFeed.CreatedOn, Is.GreaterThan(justNow));

            Assert.That(dataFeed.MissingDataPointFillSettings, Is.Not.Null);
            Assert.That(dataFeed.MissingDataPointFillSettings.FillType, Is.EqualTo(DataFeedMissingDataPointFillType.CustomValue));
            Assert.That(dataFeed.MissingDataPointFillSettings.CustomFillValue, Is.EqualTo(45.0));

            Assert.That(dataFeed.Granularity, Is.Not.Null);
            Assert.That(dataFeed.Granularity.GranularityType, Is.EqualTo(DataFeedGranularityType.Custom));
            Assert.That(dataFeed.Granularity.CustomGranularityValue, Is.EqualTo(3000));

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
            Assert.That(dataFeed.IngestionSettings.IngestionStartsOn, Is.EqualTo(expectedIngestionStartsOn));
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
            Assert.That(dataFeed.Creator, Is.Not.Null.And.Not.Empty);

            // In the SetOptionalMembers method, we may or may not add a new admin (fake@admin.com) depending on whether
            // the data feed instance used for the Update call was created from scratch or from a GetDataFeed operation:
            // - If the data feed to update was created from scratch, we didn't update the admins list (count = 1).
            // - If the data feed to update was created from a GetDataFeed operation, we added a new fake admin (count = 2).

            Assert.That(dataFeed.Administrators, Is.Not.Null);
            Assert.That(dataFeed.Administrators.Count, Is.EqualTo(1).Or.EqualTo(2));
            Assert.That(dataFeed.Administrators, Contains.Item(dataFeed.Creator));

            if (dataFeed.Administrators.Count == 2)
            {
                Assert.That(dataFeed.Administrators, Contains.Item("fake@admin.com"));
            }

            Assert.That(dataFeed.Viewers, Is.Not.Null);
            Assert.That(dataFeed.Viewers.Count, Is.EqualTo(1));
            Assert.That(dataFeed.Viewers, Contains.Item("fake@viewer.com"));

            DateTimeOffset justNow = Recording.UtcNow.Subtract(TimeSpan.FromMinutes(5));
            Assert.That(dataFeed.CreatedOn, Is.GreaterThan(justNow));

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
            Assert.That(dataFeed.IngestionSettings.IngestionStartsOn, Is.EqualTo(ingestionStartTime));
            Assert.That(dataFeed.IngestionSettings.IngestionStartOffset, Is.EqualTo(TimeSpan.FromMinutes(40)));
            Assert.That(dataFeed.IngestionSettings.IngestionRetryDelay, Is.EqualTo(TimeSpan.FromSeconds(90)));
            Assert.That(dataFeed.IngestionSettings.StopRetryAfter, Is.EqualTo(TimeSpan.FromMinutes(20)));
            Assert.That(dataFeed.IngestionSettings.DataSourceRequestConcurrency, Is.EqualTo(6));
        }

        private void ValidateGenericDataSource(DataFeedSource dataSource, bool isAdmin)
        {
            DataFeedSourceKind sourceType = dataSource.DataSourceKind;

            if (sourceType == DataFeedSourceKind.AzureApplicationInsights)
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
            else if (sourceType == DataFeedSourceKind.AzureBlob)
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
            else if (sourceType == DataFeedSourceKind.AzureCosmosDb)
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
            else if (sourceType == DataFeedSourceKind.AzureDataExplorer)
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
            else if (sourceType == DataFeedSourceKind.AzureDataLakeStorage)
            {
                var specificDataSource = dataSource as AzureDataLakeStorageDataFeedSource;

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
            else if (sourceType == DataFeedSourceKind.AzureEventHubs)
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
            else if (sourceType == DataFeedSourceKind.AzureTable)
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
            else if (sourceType == DataFeedSourceKind.InfluxDb)
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
            else if (sourceType == DataFeedSourceKind.LogAnalytics)
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
            else if (sourceType == DataFeedSourceKind.MongoDb)
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
            else if (sourceType == DataFeedSourceKind.MySql)
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
            else if (sourceType == DataFeedSourceKind.PostgreSql)
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
                Assert.That(sourceType, Is.EqualTo(DataFeedSourceKind.SqlServer));

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

        private DataFeedSource CreateMockDataFeedSource(string kind) => kind switch
        {
            nameof(DataFeedSourceKind.AzureApplicationInsights) => new AzureApplicationInsightsDataFeedSource("mock", "mock", "mock", "mock"),
            nameof(DataFeedSourceKind.AzureBlob) => new AzureBlobDataFeedSource("mock", "mock", "mock"),
            nameof(DataFeedSourceKind.AzureCosmosDb) => new AzureCosmosDbDataFeedSource("mock", "mock", "mock", "mock"),
            nameof(DataFeedSourceKind.AzureDataExplorer) => new AzureDataExplorerDataFeedSource("mock", "mock"),
            nameof(DataFeedSourceKind.AzureDataLakeStorage) => new AzureDataLakeStorageDataFeedSource("mock", "mock", "mock", "mock", "mock"),
            nameof(DataFeedSourceKind.AzureEventHubs) => new AzureEventHubsDataFeedSource("mock", "mock"),
            nameof(DataFeedSourceKind.AzureTable) => new AzureTableDataFeedSource("mock", "mock", "mock"),
            nameof(DataFeedSourceKind.InfluxDb) => new InfluxDbDataFeedSource("mock", "mock", "mock", "mock", "mock"),
            nameof(DataFeedSourceKind.LogAnalytics) => new LogAnalyticsDataFeedSource("mock", "mock", "mock", "mock", "mock"),
            nameof(DataFeedSourceKind.MongoDb) => new MongoDbDataFeedSource("mock", "mock", "mock"),
            nameof(DataFeedSourceKind.MySql) => new MySqlDataFeedSource("mock", "mock"),
            nameof(DataFeedSourceKind.PostgreSql) => new PostgreSqlDataFeedSource("mock", "mock"),
            nameof(DataFeedSourceKind.SqlServer) => new SqlServerDataFeedSource("mock", "mock"),
            _ => throw new ArgumentOutOfRangeException("Invalid data feed source kind.")
        };

        private DataFeedSource CreateDataFeedSource(string kind) => kind switch
        {
            nameof(DataFeedSourceKind.AzureApplicationInsights) => new AzureApplicationInsightsDataFeedSource(DataSourceAppId, "secret", DataSourceCloud, DataSourceQuery),
            nameof(DataFeedSourceKind.AzureBlob) => new AzureBlobDataFeedSource("secret", DataSourceContainer, DataSourceTemplate),
            nameof(DataFeedSourceKind.AzureCosmosDb) => new AzureCosmosDbDataFeedSource("secret", DataSourceQuery, DataSourceDatabase, DataSourceCollectionId),
            nameof(DataFeedSourceKind.AzureDataExplorer) => new AzureDataExplorerDataFeedSource("secret", DataSourceQuery),
            nameof(DataFeedSourceKind.AzureDataLakeStorage) => new AzureDataLakeStorageDataFeedSource(DataSourceAccount, "secret", DataSourceFileSystem, DataSourceDirectory, DataSourceFile),
            nameof(DataFeedSourceKind.AzureEventHubs) => new AzureEventHubsDataFeedSource("secret", DataSourceConsumerGroup),
            nameof(DataFeedSourceKind.AzureTable) => new AzureTableDataFeedSource("secret", DataSourceTable, DataSourceQuery),
            nameof(DataFeedSourceKind.InfluxDb) => new InfluxDbDataFeedSource("secret", DataSourceDatabase, DataSourceUsername, "secret", DataSourceQuery),
            nameof(DataFeedSourceKind.LogAnalytics) => new LogAnalyticsDataFeedSource(DataSourceWorkspaceId, DataSourceQuery, DataSourceClientId, "secret", DataSourceTenantId),
            nameof(DataFeedSourceKind.MongoDb) => new MongoDbDataFeedSource("secret", DataSourceDatabase, DataSourceCommand),
            nameof(DataFeedSourceKind.MySql) => new MySqlDataFeedSource("secret", DataSourceQuery),
            nameof(DataFeedSourceKind.PostgreSql) => new PostgreSqlDataFeedSource("secret", DataSourceQuery),
            nameof(DataFeedSourceKind.SqlServer) => new SqlServerDataFeedSource("secret", DataSourceQuery),
            _ => throw new ArgumentOutOfRangeException("Invalid data feed source kind.")
        };

        private void ValidateDataFeedSource(DataFeedSource dataSource, string expectedKind)
        {
            if (expectedKind == nameof(DataFeedSourceKind.AzureApplicationInsights))
            {
                var concreteDataSource = dataSource as AzureApplicationInsightsDataFeedSource;

                Assert.That(concreteDataSource, Is.Not.Null);
                Assert.That(concreteDataSource.DataSourceKind, Is.EqualTo(DataFeedSourceKind.AzureApplicationInsights));
                Assert.That(concreteDataSource.ApplicationId, Is.EqualTo(DataSourceAppId));
                Assert.That(concreteDataSource.AzureCloud, Is.EqualTo(DataSourceCloud));
                Assert.That(concreteDataSource.Query, Is.EqualTo(DataSourceQuery));
            }
            else if (expectedKind == nameof(DataFeedSourceKind.AzureBlob))
            {
                var concreteDataSource = dataSource as AzureBlobDataFeedSource;

                Assert.That(concreteDataSource, Is.Not.Null);
                Assert.That(concreteDataSource.DataSourceKind, Is.EqualTo(DataFeedSourceKind.AzureBlob));
                Assert.That(concreteDataSource.Container, Is.EqualTo(DataSourceContainer));
                Assert.That(concreteDataSource.BlobTemplate, Is.EqualTo(DataSourceTemplate));
            }
            else if (expectedKind == nameof(DataFeedSourceKind.AzureCosmosDb))
            {
                var concreteDataSource = dataSource as AzureCosmosDbDataFeedSource;

                Assert.That(concreteDataSource, Is.Not.Null);
                Assert.That(concreteDataSource.DataSourceKind, Is.EqualTo(DataFeedSourceKind.AzureCosmosDb));
                Assert.That(concreteDataSource.SqlQuery, Is.EqualTo(DataSourceQuery));
                Assert.That(concreteDataSource.Database, Is.EqualTo(DataSourceDatabase));
                Assert.That(concreteDataSource.CollectionId, Is.EqualTo(DataSourceCollectionId));
            }
            else if (expectedKind == nameof(DataFeedSourceKind.AzureDataExplorer))
            {
                var concreteDataSource = dataSource as AzureDataExplorerDataFeedSource;

                Assert.That(concreteDataSource, Is.Not.Null);
                Assert.That(concreteDataSource.DataSourceKind, Is.EqualTo(DataFeedSourceKind.AzureDataExplorer));
                Assert.That(concreteDataSource.Query, Is.EqualTo(DataSourceQuery));
            }
            else if (expectedKind == nameof(DataFeedSourceKind.AzureDataLakeStorage))
            {
                var concreteDataSource = dataSource as AzureDataLakeStorageDataFeedSource;

                Assert.That(concreteDataSource, Is.Not.Null);
                Assert.That(concreteDataSource.DataSourceKind, Is.EqualTo(DataFeedSourceKind.AzureDataLakeStorage));
                Assert.That(concreteDataSource.AccountName, Is.EqualTo(DataSourceAccount));
                Assert.That(concreteDataSource.FileSystemName, Is.EqualTo(DataSourceFileSystem));
                Assert.That(concreteDataSource.DirectoryTemplate, Is.EqualTo(DataSourceDirectory));
                Assert.That(concreteDataSource.FileTemplate, Is.EqualTo(DataSourceFile));
            }
            else if (expectedKind == nameof(DataFeedSourceKind.AzureEventHubs))
            {
                var concreteDataSource = dataSource as AzureEventHubsDataFeedSource;

                Assert.That(concreteDataSource, Is.Not.Null);
                Assert.That(concreteDataSource.DataSourceKind, Is.EqualTo(DataFeedSourceKind.AzureEventHubs));
                Assert.That(concreteDataSource.ConsumerGroup, Is.EqualTo(DataSourceConsumerGroup));
            }
            else if (expectedKind == nameof(DataFeedSourceKind.AzureTable))
            {
                var concreteDataSource = dataSource as AzureTableDataFeedSource;

                Assert.That(concreteDataSource, Is.Not.Null);
                Assert.That(concreteDataSource.DataSourceKind, Is.EqualTo(DataFeedSourceKind.AzureTable));
                Assert.That(concreteDataSource.Table, Is.EqualTo(DataSourceTable));
                Assert.That(concreteDataSource.Query, Is.EqualTo(DataSourceQuery));
            }
            else if (expectedKind == nameof(DataFeedSourceKind.InfluxDb))
            {
                var concreteDataSource = dataSource as InfluxDbDataFeedSource;

                Assert.That(concreteDataSource, Is.Not.Null);
                Assert.That(concreteDataSource.DataSourceKind, Is.EqualTo(DataFeedSourceKind.InfluxDb));
                Assert.That(concreteDataSource.Database, Is.EqualTo(DataSourceDatabase));
                Assert.That(concreteDataSource.Username, Is.EqualTo(DataSourceUsername));
                Assert.That(concreteDataSource.Query, Is.EqualTo(DataSourceQuery));
            }
            else if (expectedKind == nameof(DataFeedSourceKind.LogAnalytics))
            {
                var concreteDataSource = dataSource as LogAnalyticsDataFeedSource;

                Assert.That(concreteDataSource, Is.Not.Null);
                Assert.That(concreteDataSource.DataSourceKind, Is.EqualTo(DataFeedSourceKind.LogAnalytics));
                Assert.That(concreteDataSource.WorkspaceId, Is.EqualTo(DataSourceWorkspaceId));
                Assert.That(concreteDataSource.Query, Is.EqualTo(DataSourceQuery));
                Assert.That(concreteDataSource.ClientId, Is.EqualTo(DataSourceClientId));
                Assert.That(concreteDataSource.TenantId, Is.EqualTo(DataSourceTenantId));
            }
            else if (expectedKind == nameof(DataFeedSourceKind.MongoDb))
            {
                var concreteDataSource = dataSource as MongoDbDataFeedSource;

                Assert.That(concreteDataSource, Is.Not.Null);
                Assert.That(concreteDataSource.DataSourceKind, Is.EqualTo(DataFeedSourceKind.MongoDb));
                Assert.That(concreteDataSource.Database, Is.EqualTo(DataSourceDatabase));
                Assert.That(concreteDataSource.Command, Is.EqualTo(DataSourceCommand));
            }
            else if (expectedKind == nameof(DataFeedSourceKind.MySql))
            {
                var concreteDataSource = dataSource as MySqlDataFeedSource;

                Assert.That(concreteDataSource, Is.Not.Null);
                Assert.That(concreteDataSource.DataSourceKind, Is.EqualTo(DataFeedSourceKind.MySql));
                Assert.That(concreteDataSource.Query, Is.EqualTo(DataSourceQuery));
            }
            else if (expectedKind == nameof(DataFeedSourceKind.PostgreSql))
            {
                var concreteDataSource = dataSource as PostgreSqlDataFeedSource;

                Assert.That(concreteDataSource, Is.Not.Null);
                Assert.That(concreteDataSource.DataSourceKind, Is.EqualTo(DataFeedSourceKind.PostgreSql));
                Assert.That(concreteDataSource.Query, Is.EqualTo(DataSourceQuery));
            }
            else if (expectedKind == nameof(DataFeedSourceKind.SqlServer))
            {
                var concreteDataSource = dataSource as SqlServerDataFeedSource;

                Assert.That(concreteDataSource, Is.Not.Null);
                Assert.That(concreteDataSource.DataSourceKind, Is.EqualTo(DataFeedSourceKind.SqlServer));
                Assert.That(concreteDataSource.Query, Is.EqualTo(DataSourceQuery));
            }
            else
            {
                throw new ArgumentOutOfRangeException($"Invalid data feed source kind: {expectedKind}");
            }
        }

        private T GetAuthenticationInstance<T>(string authenticationType)
        {
            Type dataSourceType = typeof(T);
            PropertyInfo staticProperty = dataSourceType.GetProperty(authenticationType);

            return (T)staticProperty.GetValue(null);
        }
    }
}
