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
        public DataFeedLiveTests(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task CreateAndGetAzureApplicationInsightsDataFeedWithMinimumSetup()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var originalAppId = "appId";
            var originalKey = "key";
            var originalCloud = "cloud";
            var originalQuery = "query";

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new AzureApplicationInsightsDataFeedSource(originalAppId, originalKey, originalCloud, originalQuery);
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed createdDataFeed = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            ValidateDataFeedWithMinimumSetup(createdDataFeed, disposableDataFeed.Id, dataFeedName);

            Assert.That(createdDataFeed.SourceType, Is.EqualTo(DataFeedSourceType.AzureApplicationInsights));

            var createdDataSource = createdDataFeed.DataSource as AzureApplicationInsightsDataFeedSource;

            var expectedKey = TestEnvironment.Mode == RecordedTestMode.Playback ? "Sanitized" : originalKey;

            Assert.That(createdDataSource, Is.Not.Null);
            Assert.That(createdDataSource.ApplicationId, Is.EqualTo(originalAppId));
            Assert.That(createdDataSource.ApiKey, Is.EqualTo(expectedKey));
            Assert.That(createdDataSource.AzureCloud, Is.EqualTo(originalCloud));
            Assert.That(createdDataSource.Query, Is.EqualTo(originalQuery));
        }

        [RecordedTest]
        public async Task CreateAndGetAzureApplicationInsightsDataFeedWithOptionalMembers()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var originalAppId = "appId";
            var originalKey = "key";
            var originalCloud = "cloud";
            var originalQuery = "query";

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new AzureApplicationInsightsDataFeedSource(originalAppId, originalKey, originalCloud, originalQuery);
            DataFeed dataFeedToCreate = GetDataFeedWithOptionalMembersSet(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed createdDataFeed = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            ValidateDataFeedWithOptionalMembersSet(createdDataFeed, disposableDataFeed.Id, dataFeedName);

            Assert.That(createdDataFeed.SourceType, Is.EqualTo(DataFeedSourceType.AzureApplicationInsights));

            var createdDataSource = createdDataFeed.DataSource as AzureApplicationInsightsDataFeedSource;

            var expectedKey = TestEnvironment.Mode == RecordedTestMode.Playback ? "Sanitized" : originalKey;

            Assert.That(createdDataSource, Is.Not.Null);
            Assert.That(createdDataSource.ApplicationId, Is.EqualTo(originalAppId));
            Assert.That(createdDataSource.ApiKey, Is.EqualTo(expectedKey));
            Assert.That(createdDataSource.AzureCloud, Is.EqualTo(originalCloud));
            Assert.That(createdDataSource.Query, Is.EqualTo(originalQuery));
        }

        [RecordedTest]
        public async Task CreateAndGetAzureBlobDataFeedWithMinimumSetup()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var originalConnectionString = "connectionStr";
            var originalContainer = "container";
            var originalTemplate = "template";

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new AzureBlobDataFeedSource(originalConnectionString, originalContainer, originalTemplate);
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed createdDataFeed = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            ValidateDataFeedWithMinimumSetup(createdDataFeed, disposableDataFeed.Id, dataFeedName);

            Assert.That(createdDataFeed.SourceType, Is.EqualTo(DataFeedSourceType.AzureBlob));

            var createdDataSource = createdDataFeed.DataSource as AzureBlobDataFeedSource;

            var expectedConnectStr = TestEnvironment.Mode == RecordedTestMode.Playback ? "Sanitized" : originalConnectionString;

            Assert.That(createdDataSource, Is.Not.Null);
            Assert.That(createdDataSource.ConnectionString, Is.EqualTo(expectedConnectStr));
            Assert.That(createdDataSource.Container, Is.EqualTo(originalContainer));
            Assert.That(createdDataSource.BlobTemplate, Is.EqualTo(originalTemplate));
        }

        [RecordedTest]
        public async Task CreateAndGetAzureBlobDataFeedWithOptionalMembers()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var originalConnectionString = "connectionStr";
            var originalContainer = "container";
            var originalTemplate = "template";

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new AzureBlobDataFeedSource(originalConnectionString, originalContainer, originalTemplate);
            DataFeed dataFeedToCreate = GetDataFeedWithOptionalMembersSet(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed createdDataFeed = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            ValidateDataFeedWithOptionalMembersSet(createdDataFeed, disposableDataFeed.Id, dataFeedName);

            Assert.That(createdDataFeed.SourceType, Is.EqualTo(DataFeedSourceType.AzureBlob));

            var createdDataSource = createdDataFeed.DataSource as AzureBlobDataFeedSource;

            var expectedConnectStr = TestEnvironment.Mode == RecordedTestMode.Playback ? "Sanitized" : originalConnectionString;

            Assert.That(createdDataSource, Is.Not.Null);
            Assert.That(createdDataSource.ConnectionString, Is.EqualTo(expectedConnectStr));
            Assert.That(createdDataSource.Container, Is.EqualTo(originalContainer));
            Assert.That(createdDataSource.BlobTemplate, Is.EqualTo(originalTemplate));
        }

        [RecordedTest]
        public async Task CreateAndGetAzureCosmosDbDataFeedWithMinimumSetup()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var originalConnectionString = "connectionStr";
            var originalQuery = "query";
            var originalDatabase = "database";
            var originalCollectionId = "collectId";

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new AzureCosmosDbDataFeedSource(originalConnectionString, originalQuery, originalDatabase, originalCollectionId);
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed createdDataFeed = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            ValidateDataFeedWithMinimumSetup(createdDataFeed, disposableDataFeed.Id, dataFeedName);

            Assert.That(createdDataFeed.SourceType, Is.EqualTo(DataFeedSourceType.AzureCosmosDb));

            var createdDataSource = createdDataFeed.DataSource as AzureCosmosDbDataFeedSource;

            var expectedConnectStr = TestEnvironment.Mode == RecordedTestMode.Playback ? "Sanitized" : originalConnectionString;

            Assert.That(createdDataSource, Is.Not.Null);
            Assert.That(createdDataSource.ConnectionString, Is.EqualTo(expectedConnectStr));
            Assert.That(createdDataSource.SqlQuery, Is.EqualTo(originalQuery));
            Assert.That(createdDataSource.Database, Is.EqualTo(originalDatabase));
            Assert.That(createdDataSource.CollectionId, Is.EqualTo(originalCollectionId));
        }

        [RecordedTest]
        public async Task CreateAndGetAzureCosmosDbDataFeedWithOptionalMembers()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var originalConnectionString = "connectionStr";
            var originalQuery = "query";
            var originalDatabase = "database";
            var originalCollectionId = "collectId";

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new AzureCosmosDbDataFeedSource(originalConnectionString, originalQuery, originalDatabase, originalCollectionId);
            DataFeed dataFeedToCreate = GetDataFeedWithOptionalMembersSet(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed createdDataFeed = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            ValidateDataFeedWithOptionalMembersSet(createdDataFeed, disposableDataFeed.Id, dataFeedName);

            Assert.That(createdDataFeed.SourceType, Is.EqualTo(DataFeedSourceType.AzureCosmosDb));

            var createdDataSource = createdDataFeed.DataSource as AzureCosmosDbDataFeedSource;

            var expectedConnectStr = TestEnvironment.Mode == RecordedTestMode.Playback ? "Sanitized" : originalConnectionString;

            Assert.That(createdDataSource, Is.Not.Null);
            Assert.That(createdDataSource.ConnectionString, Is.EqualTo(expectedConnectStr));
            Assert.That(createdDataSource.SqlQuery, Is.EqualTo(originalQuery));
            Assert.That(createdDataSource.Database, Is.EqualTo(originalDatabase));
            Assert.That(createdDataSource.CollectionId, Is.EqualTo(originalCollectionId));
        }

        [RecordedTest]
        public async Task CreateAndGetAzureDataExplorerDataFeedWithMinimumSetup()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var originalConnectionString = "connectionStr";
            var originalQuery = "query";

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new AzureDataExplorerDataFeedSource(originalConnectionString, originalQuery);
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed createdDataFeed = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            ValidateDataFeedWithMinimumSetup(createdDataFeed, disposableDataFeed.Id, dataFeedName);

            Assert.That(createdDataFeed.SourceType, Is.EqualTo(DataFeedSourceType.AzureDataExplorer));

            var createdDataSource = createdDataFeed.DataSource as AzureDataExplorerDataFeedSource;

            var expectedConnectStr = TestEnvironment.Mode == RecordedTestMode.Playback ? "Sanitized" : originalConnectionString;

            Assert.That(createdDataSource, Is.Not.Null);
            Assert.That(createdDataSource.ConnectionString, Is.EqualTo(expectedConnectStr));
            Assert.That(createdDataSource.Query, Is.EqualTo(originalQuery));
        }

        [RecordedTest]
        public async Task CreateAndGetAzureDataExplorerDataFeedWithOptionalMembers()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var originalConnectionString = "connectionStr";
            var originalQuery = "query";

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new AzureDataExplorerDataFeedSource(originalConnectionString, originalQuery);
            DataFeed dataFeedToCreate = GetDataFeedWithOptionalMembersSet(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed createdDataFeed = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            ValidateDataFeedWithOptionalMembersSet(createdDataFeed, disposableDataFeed.Id, dataFeedName);

            Assert.That(createdDataFeed.SourceType, Is.EqualTo(DataFeedSourceType.AzureDataExplorer));

            var createdDataSource = createdDataFeed.DataSource as AzureDataExplorerDataFeedSource;

            var expectedConnectStr = TestEnvironment.Mode == RecordedTestMode.Playback ? "Sanitized" : originalConnectionString;

            Assert.That(createdDataSource, Is.Not.Null);
            Assert.That(createdDataSource.ConnectionString, Is.EqualTo(expectedConnectStr));
            Assert.That(createdDataSource.Query, Is.EqualTo(originalQuery));
        }

        [RecordedTest]
        public async Task CreateAndGetAzureDataLakeStorageGen2DataFeedWithMinimumSetup()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var originalAccount = "account";
            var originalKey = "key";
            var originalFileSystem = "fileSystem";
            var originalDirectory = "dir";
            var originalFile = "file";

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new AzureDataLakeStorageGen2DataFeedSource(originalAccount, originalKey, originalFileSystem, originalDirectory, originalFile);
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed createdDataFeed = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            ValidateDataFeedWithMinimumSetup(createdDataFeed, disposableDataFeed.Id, dataFeedName);

            Assert.That(createdDataFeed.SourceType, Is.EqualTo(DataFeedSourceType.AzureDataLakeStorageGen2));

            var createdDataSource = createdDataFeed.DataSource as AzureDataLakeStorageGen2DataFeedSource;

            var expectedKey = TestEnvironment.Mode == RecordedTestMode.Playback ? "Sanitized" : originalKey;

            Assert.That(createdDataSource, Is.Not.Null);
            Assert.That(createdDataSource.AccountName, Is.EqualTo(originalAccount));
            Assert.That(createdDataSource.AccountKey, Is.EqualTo(expectedKey));
            Assert.That(createdDataSource.FileSystemName, Is.EqualTo(originalFileSystem));
            Assert.That(createdDataSource.DirectoryTemplate, Is.EqualTo(originalDirectory));
            Assert.That(createdDataSource.FileTemplate, Is.EqualTo(originalFile));
        }

        [RecordedTest]
        public async Task CreateAndGetAzureDataLakeStorageGen2DataFeedWithOptionalMembers()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var originalAccount = "account";
            var originalKey = "key";
            var originalFileSystem = "fileSystem";
            var originalDirectory = "dir";
            var originalFile = "file";

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new AzureDataLakeStorageGen2DataFeedSource(originalAccount, originalKey, originalFileSystem, originalDirectory, originalFile);
            DataFeed dataFeedToCreate = GetDataFeedWithOptionalMembersSet(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed createdDataFeed = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            ValidateDataFeedWithOptionalMembersSet(createdDataFeed, disposableDataFeed.Id, dataFeedName);

            Assert.That(createdDataFeed.SourceType, Is.EqualTo(DataFeedSourceType.AzureDataLakeStorageGen2));

            var createdDataSource = createdDataFeed.DataSource as AzureDataLakeStorageGen2DataFeedSource;

            var expectedKey = TestEnvironment.Mode == RecordedTestMode.Playback ? "Sanitized" : originalKey;

            Assert.That(createdDataSource, Is.Not.Null);
            Assert.That(createdDataSource.AccountName, Is.EqualTo(originalAccount));
            Assert.That(createdDataSource.AccountKey, Is.EqualTo(expectedKey));
            Assert.That(createdDataSource.FileSystemName, Is.EqualTo(originalFileSystem));
            Assert.That(createdDataSource.DirectoryTemplate, Is.EqualTo(originalDirectory));
            Assert.That(createdDataSource.FileTemplate, Is.EqualTo(originalFile));
        }

        [RecordedTest]
        public async Task CreateAndGetAzureTableDataFeedWithMinimumSetup()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var originalConnectionString = "connectionStr";
            var originalTable = "table";
            var originalQuery = "query";

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new AzureTableDataFeedSource(originalConnectionString, originalTable, originalQuery);
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed createdDataFeed = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            ValidateDataFeedWithMinimumSetup(createdDataFeed, disposableDataFeed.Id, dataFeedName);

            Assert.That(createdDataFeed.SourceType, Is.EqualTo(DataFeedSourceType.AzureTable));

            var createdDataSource = createdDataFeed.DataSource as AzureTableDataFeedSource;

            var expectedConnectStr = TestEnvironment.Mode == RecordedTestMode.Playback ? "Sanitized" : originalConnectionString;

            Assert.That(createdDataSource, Is.Not.Null);
            Assert.That(createdDataSource.ConnectionString, Is.EqualTo(expectedConnectStr));
            Assert.That(createdDataSource.Table, Is.EqualTo(originalTable));
            Assert.That(createdDataSource.Query, Is.EqualTo(originalQuery));
        }

        [RecordedTest]
        public async Task CreateAndGetAzureTableDataFeedWithOptionalMembers()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var originalConnectionString = "connectionStr";
            var originalTable = "table";
            var originalQuery = "query";

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new AzureTableDataFeedSource(originalConnectionString, originalTable, originalQuery);
            DataFeed dataFeedToCreate = GetDataFeedWithOptionalMembersSet(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed createdDataFeed = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            ValidateDataFeedWithOptionalMembersSet(createdDataFeed, disposableDataFeed.Id, dataFeedName);

            Assert.That(createdDataFeed.SourceType, Is.EqualTo(DataFeedSourceType.AzureTable));

            var createdDataSource = createdDataFeed.DataSource as AzureTableDataFeedSource;

            var expectedConnectStr = TestEnvironment.Mode == RecordedTestMode.Playback ? "Sanitized" : originalConnectionString;

            Assert.That(createdDataSource, Is.Not.Null);
            Assert.That(createdDataSource.ConnectionString, Is.EqualTo(expectedConnectStr));
            Assert.That(createdDataSource.Table, Is.EqualTo(originalTable));
            Assert.That(createdDataSource.Query, Is.EqualTo(originalQuery));
        }

        [RecordedTest]
        public async Task CreateAndGetElasticsearchDataFeedWithMinimumSetup()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var originalHost = "host";
            var originalPort = "port";
            var originalAuth = "auth";
            var originalQuery = "query";

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new ElasticsearchDataFeedSource(originalHost, originalPort, originalAuth, originalQuery);
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed createdDataFeed = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            ValidateDataFeedWithMinimumSetup(createdDataFeed, disposableDataFeed.Id, dataFeedName);

            Assert.That(createdDataFeed.SourceType, Is.EqualTo(DataFeedSourceType.Elasticsearch));

            var createdDataSource = createdDataFeed.DataSource as ElasticsearchDataFeedSource;

            var expectedAuth = TestEnvironment.Mode == RecordedTestMode.Playback ? "Sanitized" : originalAuth;

            Assert.That(createdDataSource, Is.Not.Null);
            Assert.That(createdDataSource.Host, Is.EqualTo(originalHost));
            Assert.That(createdDataSource.Port, Is.EqualTo(originalPort));
            Assert.That(createdDataSource.AuthorizationHeader, Is.EqualTo(expectedAuth));
            Assert.That(createdDataSource.Query, Is.EqualTo(originalQuery));
        }

        [RecordedTest]
        public async Task CreateAndGetElasticsearchDataFeedWithOptionalMembers()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var originalHost = "host";
            var originalPort = "port";
            var originalAuth = "auth";
            var originalQuery = "query";

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new ElasticsearchDataFeedSource(originalHost, originalPort, originalAuth, originalQuery);
            DataFeed dataFeedToCreate = GetDataFeedWithOptionalMembersSet(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed createdDataFeed = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            ValidateDataFeedWithOptionalMembersSet(createdDataFeed, disposableDataFeed.Id, dataFeedName);

            Assert.That(createdDataFeed.SourceType, Is.EqualTo(DataFeedSourceType.Elasticsearch));

            var createdDataSource = createdDataFeed.DataSource as ElasticsearchDataFeedSource;

            var expectedAuth = TestEnvironment.Mode == RecordedTestMode.Playback ? "Sanitized" : originalAuth;

            Assert.That(createdDataSource, Is.Not.Null);
            Assert.That(createdDataSource.Host, Is.EqualTo(originalHost));
            Assert.That(createdDataSource.Port, Is.EqualTo(originalPort));
            Assert.That(createdDataSource.AuthorizationHeader, Is.EqualTo(expectedAuth));
            Assert.That(createdDataSource.Query, Is.EqualTo(originalQuery));
        }

        [RecordedTest]
        public async Task CreateAndGetHttpRequestDataFeedWithMinimumSetup()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var originalHeader = "header";
            var originalMethod = "method";
            var originalPayload = "payload";

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSourceHost = new Uri("https://fakehost.com/");
            var dataSource = new HttpRequestDataFeedSource(dataSourceHost, originalHeader, originalMethod, originalPayload);
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed createdDataFeed = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            ValidateDataFeedWithMinimumSetup(createdDataFeed, disposableDataFeed.Id, dataFeedName);

            Assert.That(createdDataFeed.SourceType, Is.EqualTo(DataFeedSourceType.HttpRequest));

            var createdDataSource = createdDataFeed.DataSource as HttpRequestDataFeedSource;

            var expectedHeader = TestEnvironment.Mode == RecordedTestMode.Playback ? "Sanitized" : originalHeader;

            Assert.That(createdDataSource, Is.Not.Null);
            Assert.That(createdDataSource.Url.AbsoluteUri, Is.EqualTo(dataSourceHost.AbsoluteUri));
            Assert.That(createdDataSource.HttpHeader, Is.EqualTo(expectedHeader));
            Assert.That(createdDataSource.HttpMethod, Is.EqualTo(originalMethod));
            Assert.That(createdDataSource.Payload, Is.EqualTo(originalPayload));
        }

        [RecordedTest]
        public async Task CreateAndGetHttpRequestDataFeedWithOptionalMembers()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var originalHeader = "header";
            var originalMethod = "method";
            var originalPayload = "payload";

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSourceHost = new Uri("https://fakehost.com/");
            var dataSource = new HttpRequestDataFeedSource(dataSourceHost, originalHeader, originalMethod, originalPayload);
            DataFeed dataFeedToCreate = GetDataFeedWithOptionalMembersSet(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed createdDataFeed = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            ValidateDataFeedWithOptionalMembersSet(createdDataFeed, disposableDataFeed.Id, dataFeedName);

            Assert.That(createdDataFeed.SourceType, Is.EqualTo(DataFeedSourceType.HttpRequest));

            var createdDataSource = createdDataFeed.DataSource as HttpRequestDataFeedSource;

            var expectedHeader = TestEnvironment.Mode == RecordedTestMode.Playback ? "Sanitized" : originalHeader;

            Assert.That(createdDataSource, Is.Not.Null);
            Assert.That(createdDataSource.Url.AbsoluteUri, Is.EqualTo(dataSourceHost.AbsoluteUri));
            Assert.That(createdDataSource.HttpHeader, Is.EqualTo(expectedHeader));
            Assert.That(createdDataSource.HttpMethod, Is.EqualTo(originalMethod));
            Assert.That(createdDataSource.Payload, Is.EqualTo(originalPayload));
        }

        [RecordedTest]
        public async Task CreateAndGetInfluxDbDataFeedWithMinimumSetup()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var originalConnectionString = "connectionStr";
            var originalDatabase = "database";
            var originalUsername = "username";
            var originalPassword = "pass";
            var originalQuery = "query";

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new InfluxDbDataFeedSource(originalConnectionString, originalDatabase, originalUsername, originalPassword, originalQuery);
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed createdDataFeed = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            ValidateDataFeedWithMinimumSetup(createdDataFeed, disposableDataFeed.Id, dataFeedName);

            Assert.That(createdDataFeed.SourceType, Is.EqualTo(DataFeedSourceType.InfluxDb));

            var createdDataSource = createdDataFeed.DataSource as InfluxDbDataFeedSource;

            var expectedConnectStr = TestEnvironment.Mode == RecordedTestMode.Playback ? "Sanitized" : originalConnectionString;

            Assert.That(createdDataSource, Is.Not.Null);
            Assert.That(createdDataSource.ConnectionString, Is.EqualTo(expectedConnectStr));
            Assert.That(createdDataSource.Database, Is.EqualTo(originalDatabase));
            Assert.That(createdDataSource.Username, Is.EqualTo(originalUsername));
            Assert.That(createdDataSource.Password, Is.EqualTo(originalPassword));
            Assert.That(createdDataSource.Query, Is.EqualTo(originalQuery));
        }

        [RecordedTest]
        public async Task CreateAndGetInfluxDbDataFeedWithOptionalMembers()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var originalConnectionString = "connectionStr";
            var originalDatabase = "database";
            var originalUsername = "username";
            var originalPassword = "pass";
            var originalQuery = "query";

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new InfluxDbDataFeedSource(originalConnectionString, originalDatabase, originalUsername, originalPassword, originalQuery);
            DataFeed dataFeedToCreate = GetDataFeedWithOptionalMembersSet(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed createdDataFeed = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            ValidateDataFeedWithOptionalMembersSet(createdDataFeed, disposableDataFeed.Id, dataFeedName);

            Assert.That(createdDataFeed.SourceType, Is.EqualTo(DataFeedSourceType.InfluxDb));

            var createdDataSource = createdDataFeed.DataSource as InfluxDbDataFeedSource;

            var expectedConnectStr = TestEnvironment.Mode == RecordedTestMode.Playback ? "Sanitized" : originalConnectionString;

            Assert.That(createdDataSource, Is.Not.Null);
            Assert.That(createdDataSource.ConnectionString, Is.EqualTo(expectedConnectStr));
            Assert.That(createdDataSource.Database, Is.EqualTo(originalDatabase));
            Assert.That(createdDataSource.Username, Is.EqualTo(originalUsername));
            Assert.That(createdDataSource.Password, Is.EqualTo(originalPassword));
            Assert.That(createdDataSource.Query, Is.EqualTo(originalQuery));
        }

        [RecordedTest]
        public async Task CreateAndGetMongoDbDataFeedWithMinimumSetup()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var originalConnectionString = "connectionStr";
            var originalDatabase = "database";
            var originalCommand = "command";

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new MongoDbDataFeedSource(originalConnectionString, originalDatabase, originalCommand);
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed createdDataFeed = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            ValidateDataFeedWithMinimumSetup(createdDataFeed, disposableDataFeed.Id, dataFeedName);

            Assert.That(createdDataFeed.SourceType, Is.EqualTo(DataFeedSourceType.MongoDb));

            var createdDataSource = createdDataFeed.DataSource as MongoDbDataFeedSource;

            var expectedConnectStr = TestEnvironment.Mode == RecordedTestMode.Playback ? "Sanitized" : originalConnectionString;

            Assert.That(createdDataSource, Is.Not.Null);
            Assert.That(createdDataSource.ConnectionString, Is.EqualTo(expectedConnectStr));
            Assert.That(createdDataSource.Database, Is.EqualTo(originalDatabase));
            Assert.That(createdDataSource.Command, Is.EqualTo(originalCommand));
        }

        [RecordedTest]
        public async Task CreateAndGetMongoDbDataFeedWithOptionalMembers()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var originalConnectionString = "connectionStr";
            var originalDatabase = "database";
            var originalCommand = "command";

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new MongoDbDataFeedSource(originalConnectionString, originalDatabase, originalCommand);
            DataFeed dataFeedToCreate = GetDataFeedWithOptionalMembersSet(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed createdDataFeed = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            ValidateDataFeedWithOptionalMembersSet(createdDataFeed, disposableDataFeed.Id, dataFeedName);

            Assert.That(createdDataFeed.SourceType, Is.EqualTo(DataFeedSourceType.MongoDb));

            var createdDataSource = createdDataFeed.DataSource as MongoDbDataFeedSource;

            var expectedConnectStr = TestEnvironment.Mode == RecordedTestMode.Playback ? "Sanitized" : originalConnectionString;

            Assert.That(createdDataSource, Is.Not.Null);
            Assert.That(createdDataSource.ConnectionString, Is.EqualTo(expectedConnectStr));
            Assert.That(createdDataSource.Database, Is.EqualTo(originalDatabase));
            Assert.That(createdDataSource.Command, Is.EqualTo(originalCommand));
        }

        [RecordedTest]
        public async Task CreateAndGetMySqlDataFeedWithMinimumSetup()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var originalConnectionString = "connectionStr";
            var originalQuery = "query";

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new MySqlDataFeedSource(originalConnectionString, originalQuery);
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed createdDataFeed = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            ValidateDataFeedWithMinimumSetup(createdDataFeed, disposableDataFeed.Id, dataFeedName);

            Assert.That(createdDataFeed.SourceType, Is.EqualTo(DataFeedSourceType.MySql));

            var createdDataSource = createdDataFeed.DataSource as MySqlDataFeedSource;

            var expectedConnectStr = TestEnvironment.Mode == RecordedTestMode.Playback ? "Sanitized" : originalConnectionString;

            Assert.That(createdDataSource, Is.Not.Null);
            Assert.That(createdDataSource.ConnectionString, Is.EqualTo(expectedConnectStr));
            Assert.That(createdDataSource.Query, Is.EqualTo(originalQuery));
        }

        [RecordedTest]
        public async Task CreateAndGetMySqlDataFeedWithOptionalMembers()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var originalConnectionString = "connectionStr";
            var originalQuery = "query";

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new MySqlDataFeedSource(originalConnectionString, originalQuery);
            DataFeed dataFeedToCreate = GetDataFeedWithOptionalMembersSet(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed createdDataFeed = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            ValidateDataFeedWithOptionalMembersSet(createdDataFeed, disposableDataFeed.Id, dataFeedName);

            Assert.That(createdDataFeed.SourceType, Is.EqualTo(DataFeedSourceType.MySql));

            var createdDataSource = createdDataFeed.DataSource as MySqlDataFeedSource;

            var expectedConnectStr = TestEnvironment.Mode == RecordedTestMode.Playback ? "Sanitized" : originalConnectionString;

            Assert.That(createdDataSource, Is.Not.Null);
            Assert.That(createdDataSource.ConnectionString, Is.EqualTo(expectedConnectStr));
            Assert.That(createdDataSource.Query, Is.EqualTo(originalQuery));
        }

        [RecordedTest]
        public async Task CreateAndGetPostgreSqlDataFeedWithMinimumSetup()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var originalConnectionString = "connectionStr";
            var originalQuery = "query";

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new PostgreSqlDataFeedSource(originalConnectionString, originalQuery);
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed createdDataFeed = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            ValidateDataFeedWithMinimumSetup(createdDataFeed, disposableDataFeed.Id, dataFeedName);

            Assert.That(createdDataFeed.SourceType, Is.EqualTo(DataFeedSourceType.PostgreSql));

            var createdDataSource = createdDataFeed.DataSource as PostgreSqlDataFeedSource;

            var expectedConnectStr = TestEnvironment.Mode == RecordedTestMode.Playback ? "Sanitized" : originalConnectionString;

            Assert.That(createdDataSource, Is.Not.Null);
            Assert.That(createdDataSource.ConnectionString, Is.EqualTo(expectedConnectStr));
            Assert.That(createdDataSource.Query, Is.EqualTo(originalQuery));
        }

        [RecordedTest]
        public async Task CreateAndGetPostgreSqlDataFeedWithOptionalMembers()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var originalConnectionString = "connectionStr";
            var originalQuery = "query";

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new PostgreSqlDataFeedSource(originalConnectionString, originalQuery);
            DataFeed dataFeedToCreate = GetDataFeedWithOptionalMembersSet(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed createdDataFeed = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            ValidateDataFeedWithOptionalMembersSet(createdDataFeed, disposableDataFeed.Id, dataFeedName);

            Assert.That(createdDataFeed.SourceType, Is.EqualTo(DataFeedSourceType.PostgreSql));

            var createdDataSource = createdDataFeed.DataSource as PostgreSqlDataFeedSource;

            var expectedConnectStr = TestEnvironment.Mode == RecordedTestMode.Playback ? "Sanitized" : originalConnectionString;

            Assert.That(createdDataSource, Is.Not.Null);
            Assert.That(createdDataSource.ConnectionString, Is.EqualTo(expectedConnectStr));
            Assert.That(createdDataSource.Query, Is.EqualTo(originalQuery));
        }

        [RecordedTest]
        public async Task CreateAndGetSqlServerDataFeedWithMinimumSetup()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var originalConnectionString = "connectionStr";
            var originalQuery = "query";

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new SqlServerDataFeedSource(originalConnectionString, originalQuery);
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed createdDataFeed = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            ValidateDataFeedWithMinimumSetup(createdDataFeed, disposableDataFeed.Id, dataFeedName);

            Assert.That(createdDataFeed.SourceType, Is.EqualTo(DataFeedSourceType.SqlServer));

            var createdDataSource = createdDataFeed.DataSource as SqlServerDataFeedSource;

            var expectedConnectStr = TestEnvironment.Mode == RecordedTestMode.Playback ? "Sanitized" : originalConnectionString;

            Assert.That(createdDataSource, Is.Not.Null);
            Assert.That(createdDataSource.ConnectionString, Is.EqualTo(expectedConnectStr));
            Assert.That(createdDataSource.Query, Is.EqualTo(originalQuery));
        }

        [RecordedTest]
        public async Task CreateAndGetSqlServerDataFeedWithOptionalMembers()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var originalConnectionString = "connectionStr";
            var originalQuery = "query";

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new SqlServerDataFeedSource(originalConnectionString, originalQuery);
            DataFeed dataFeedToCreate = GetDataFeedWithOptionalMembersSet(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed createdDataFeed = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            ValidateDataFeedWithOptionalMembersSet(createdDataFeed, disposableDataFeed.Id, dataFeedName);

            Assert.That(createdDataFeed.SourceType, Is.EqualTo(DataFeedSourceType.SqlServer));

            var createdDataSource = createdDataFeed.DataSource as SqlServerDataFeedSource;

            var expectedConnectStr = TestEnvironment.Mode == RecordedTestMode.Playback ? "Sanitized" : originalConnectionString;

            Assert.That(createdDataSource, Is.Not.Null);
            Assert.That(createdDataSource.ConnectionString, Is.EqualTo(expectedConnectStr));
            Assert.That(createdDataSource.Query, Is.EqualTo(originalQuery));
        }

        [RecordedTest]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/17726")]
        public async Task UpdateAzureApplicationInsightsDataFeedWithMinimumSetupAndGetInstance()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var originalAppId = "appId";
            var originalKey = "key";
            var originalCloud = "cloud";
            var originalQuery = "query";

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new AzureApplicationInsightsDataFeedSource(originalAppId, originalKey, originalCloud, originalQuery);
            var description = "This data feed was created to test the .NET client.";
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed dataFeedToUpdate = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            dataFeedToUpdate.Description = description;

            await adminClient.UpdateDataFeedAsync(disposableDataFeed.Id, dataFeedToUpdate);

            DataFeed updatedDataFeed = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            ValidateDataFeedWithMinimumSetup(updatedDataFeed, disposableDataFeed.Id, dataFeedName, description);

            Assert.That(updatedDataFeed.SourceType, Is.EqualTo(DataFeedSourceType.AzureApplicationInsights));

            var updatedDataSource = updatedDataFeed.DataSource as AzureApplicationInsightsDataFeedSource;

            var expectedKey = TestEnvironment.Mode == RecordedTestMode.Playback ? "Sanitized" : originalKey;

            Assert.That(updatedDataSource, Is.Not.Null);
            Assert.That(updatedDataSource.ApplicationId, Is.EqualTo(originalAppId));
            Assert.That(updatedDataSource.ApiKey, Is.EqualTo(expectedKey));
            Assert.That(updatedDataSource.AzureCloud, Is.EqualTo(originalCloud));
            Assert.That(updatedDataSource.Query, Is.EqualTo(originalQuery));
        }

        [RecordedTest]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/17726")]
        public async Task UpdateAzureApplicationInsightsDataFeedWithMinimumSetupAndNewInstance()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var originalAppId = "appId";
            var originalKey = "key";
            var originalCloud = "cloud";
            var originalQuery = "query";

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new AzureApplicationInsightsDataFeedSource(originalAppId, originalKey, originalCloud, originalQuery);
            var description = "This data feed was created to test the .NET client.";
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed dataFeedToUpdate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            dataFeedToUpdate.Description = description;

            await adminClient.UpdateDataFeedAsync(disposableDataFeed.Id, dataFeedToUpdate);

            DataFeed updatedDataFeed = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            ValidateDataFeedWithMinimumSetup(updatedDataFeed, disposableDataFeed.Id, dataFeedName, description);

            Assert.That(updatedDataFeed.SourceType, Is.EqualTo(DataFeedSourceType.AzureApplicationInsights));

            var updatedDataSource = updatedDataFeed.DataSource as AzureApplicationInsightsDataFeedSource;

            var expectedKey = TestEnvironment.Mode == RecordedTestMode.Playback ? "Sanitized" : originalKey;

            Assert.That(updatedDataSource, Is.Not.Null);
            Assert.That(updatedDataSource.ApplicationId, Is.EqualTo(originalAppId));
            Assert.That(updatedDataSource.ApiKey, Is.EqualTo(expectedKey));
            Assert.That(updatedDataSource.AzureCloud, Is.EqualTo(originalCloud));
            Assert.That(updatedDataSource.Query, Is.EqualTo(originalQuery));
        }

        [RecordedTest]
        public async Task UpdateAzureBlobDataFeedWithMinimumSetupAndGetInstance()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var originalConnectionString = "connectionStr";
            var originalContainer = "container";
            var originalTemplate = "template";

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new AzureBlobDataFeedSource(originalConnectionString, originalContainer, originalTemplate);
            var description = "This data feed was created to test the .NET client.";
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed dataFeedToUpdate = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            dataFeedToUpdate.Description = description;

            await adminClient.UpdateDataFeedAsync(disposableDataFeed.Id, dataFeedToUpdate);

            DataFeed updatedDataFeed = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            ValidateDataFeedWithMinimumSetup(updatedDataFeed, disposableDataFeed.Id, dataFeedName, description);

            Assert.That(updatedDataFeed.SourceType, Is.EqualTo(DataFeedSourceType.AzureBlob));

            var updatedDataSource = updatedDataFeed.DataSource as AzureBlobDataFeedSource;

            var expectedConnectStr = TestEnvironment.Mode == RecordedTestMode.Playback ? "Sanitized" : originalConnectionString;

            Assert.That(updatedDataSource, Is.Not.Null);
            Assert.That(updatedDataSource.ConnectionString, Is.EqualTo(expectedConnectStr));
            Assert.That(updatedDataSource.Container, Is.EqualTo(originalContainer));
            Assert.That(updatedDataSource.BlobTemplate, Is.EqualTo(originalTemplate));
        }

        [RecordedTest]
        public async Task UpdateAzureBlobDataFeedWithMinimumSetupAndNewInstance()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var originalConnectionString = "connectionStr";
            var originalContainer = "container";
            var originalTemplate = "template";

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new AzureBlobDataFeedSource(originalConnectionString, originalContainer, originalTemplate);
            var description = "This data feed was created to test the .NET client.";
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed dataFeedToUpdate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            dataFeedToUpdate.Description = description;

            await adminClient.UpdateDataFeedAsync(disposableDataFeed.Id, dataFeedToUpdate);

            DataFeed updatedDataFeed = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            ValidateDataFeedWithMinimumSetup(updatedDataFeed, disposableDataFeed.Id, dataFeedName, description);

            Assert.That(updatedDataFeed.SourceType, Is.EqualTo(DataFeedSourceType.AzureBlob));

            var updatedDataSource = updatedDataFeed.DataSource as AzureBlobDataFeedSource;

            var expectedConnectStr = TestEnvironment.Mode == RecordedTestMode.Playback ? "Sanitized" : originalConnectionString;

            Assert.That(updatedDataSource, Is.Not.Null);
            Assert.That(updatedDataSource.ConnectionString, Is.EqualTo(expectedConnectStr));
            Assert.That(updatedDataSource.Container, Is.EqualTo(originalContainer));
            Assert.That(updatedDataSource.BlobTemplate, Is.EqualTo(originalTemplate));
        }

        [RecordedTest]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/17726")]
        public async Task UpdateAzureCosmosDbDataFeedWithMinimumSetupAndGetInstance()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var originalConnectionString = "connectionStr";
            var originalQuery = "query";
            var originalDatabase = "database";
            var originalCollectionId = "collectId";

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new AzureCosmosDbDataFeedSource(originalConnectionString, originalQuery, originalDatabase, originalCollectionId);
            var description = "This data feed was created to test the .NET client.";
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed dataFeedToUpdate = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            dataFeedToUpdate.Description = description;

            await adminClient.UpdateDataFeedAsync(disposableDataFeed.Id, dataFeedToUpdate);

            DataFeed updatedDataFeed = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            ValidateDataFeedWithMinimumSetup(updatedDataFeed, disposableDataFeed.Id, dataFeedName, description);

            Assert.That(updatedDataFeed.SourceType, Is.EqualTo(DataFeedSourceType.AzureCosmosDb));

            var updatedDataSource = updatedDataFeed.DataSource as AzureCosmosDbDataFeedSource;

            var expectedConnectStr = TestEnvironment.Mode == RecordedTestMode.Playback ? "Sanitized" : originalConnectionString;

            Assert.That(updatedDataSource, Is.Not.Null);
            Assert.That(updatedDataSource.ConnectionString, Is.EqualTo(expectedConnectStr));
            Assert.That(updatedDataSource.SqlQuery, Is.EqualTo(originalQuery));
            Assert.That(updatedDataSource.Database, Is.EqualTo(originalDatabase));
            Assert.That(updatedDataSource.CollectionId, Is.EqualTo(originalCollectionId));
        }

        [RecordedTest]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/17726")]
        public async Task UpdateAzureCosmosDbDataFeedWithMinimumSetupAndNewInstance()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var originalConnectionString = "connectionStr";
            var originalQuery = "query";
            var originalDatabase = "database";
            var originalCollectionId = "collectId";

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new AzureCosmosDbDataFeedSource(originalConnectionString, originalQuery, originalDatabase, originalCollectionId);
            var description = "This data feed was created to test the .NET client.";
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed dataFeedToUpdate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            dataFeedToUpdate.Description = description;

            await adminClient.UpdateDataFeedAsync(disposableDataFeed.Id, dataFeedToUpdate);

            DataFeed updatedDataFeed = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            ValidateDataFeedWithMinimumSetup(updatedDataFeed, disposableDataFeed.Id, dataFeedName, description);

            Assert.That(updatedDataFeed.SourceType, Is.EqualTo(DataFeedSourceType.AzureCosmosDb));

            var updatedDataSource = updatedDataFeed.DataSource as AzureCosmosDbDataFeedSource;

            var expectedConnectStr = TestEnvironment.Mode == RecordedTestMode.Playback ? "Sanitized" : originalConnectionString;

            Assert.That(updatedDataSource, Is.Not.Null);
            Assert.That(updatedDataSource.ConnectionString, Is.EqualTo(expectedConnectStr));
            Assert.That(updatedDataSource.SqlQuery, Is.EqualTo(originalQuery));
            Assert.That(updatedDataSource.Database, Is.EqualTo(originalDatabase));
            Assert.That(updatedDataSource.CollectionId, Is.EqualTo(originalCollectionId));
        }

        [RecordedTest]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/17726")]
        public async Task UpdateAzureDataExplorerDataFeedWithMinimumSetupAndGetInstance()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var originalConnectionString = "connectionStr";
            var originalQuery = "query";

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new AzureDataExplorerDataFeedSource(originalConnectionString, originalQuery);
            var description = "This data feed was created to test the .NET client.";
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed dataFeedToUpdate = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            dataFeedToUpdate.Description = description;

            await adminClient.UpdateDataFeedAsync(disposableDataFeed.Id, dataFeedToUpdate);

            DataFeed updatedDataFeed = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            ValidateDataFeedWithMinimumSetup(updatedDataFeed, disposableDataFeed.Id, dataFeedName, description);

            Assert.That(updatedDataFeed.SourceType, Is.EqualTo(DataFeedSourceType.AzureDataExplorer));

            var updatedDataSource = updatedDataFeed.DataSource as AzureDataExplorerDataFeedSource;

            var expectedConnectStr = TestEnvironment.Mode == RecordedTestMode.Playback ? "Sanitized" : originalConnectionString;

            Assert.That(updatedDataSource, Is.Not.Null);
            Assert.That(updatedDataSource.ConnectionString, Is.EqualTo(expectedConnectStr));
            Assert.That(updatedDataSource.Query, Is.EqualTo(originalQuery));
        }

        [RecordedTest]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/17726")]
        public async Task UpdateAzureDataExplorerDataFeedWithMinimumSetupAndNewInstance()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var originalConnectionString = "connectionStr";
            var originalQuery = "query";

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new AzureDataExplorerDataFeedSource(originalConnectionString, originalQuery);
            var description = "This data feed was created to test the .NET client.";
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed dataFeedToUpdate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            dataFeedToUpdate.Description = description;

            await adminClient.UpdateDataFeedAsync(disposableDataFeed.Id, dataFeedToUpdate);

            DataFeed updatedDataFeed = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            ValidateDataFeedWithMinimumSetup(updatedDataFeed, disposableDataFeed.Id, dataFeedName, description);

            Assert.That(updatedDataFeed.SourceType, Is.EqualTo(DataFeedSourceType.AzureDataExplorer));

            var updatedDataSource = updatedDataFeed.DataSource as AzureDataExplorerDataFeedSource;

            var expectedConnectStr = TestEnvironment.Mode == RecordedTestMode.Playback ? "Sanitized" : originalConnectionString;

            Assert.That(updatedDataSource, Is.Not.Null);
            Assert.That(updatedDataSource.ConnectionString, Is.EqualTo(expectedConnectStr));
            Assert.That(updatedDataSource.Query, Is.EqualTo(originalQuery));
        }

        [RecordedTest]
        public async Task UpdateAzureDataLakeStorageGen2DataFeedWithMinimumSetupAndGetInstance()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var originalAccount = "account";
            var originalKey = "key";
            var originalFileSystem = "fileSystem";
            var originalDirectory = "dir";
            var originalFile = "file";

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new AzureDataLakeStorageGen2DataFeedSource(originalAccount, originalKey, originalFileSystem, originalDirectory, originalFile);
            var description = "This data feed was created to test the .NET client.";
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed dataFeedToUpdate = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            dataFeedToUpdate.Description = description;

            await adminClient.UpdateDataFeedAsync(disposableDataFeed.Id, dataFeedToUpdate);

            DataFeed updatedDataFeed = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            ValidateDataFeedWithMinimumSetup(updatedDataFeed, disposableDataFeed.Id, dataFeedName, description);

            Assert.That(updatedDataFeed.SourceType, Is.EqualTo(DataFeedSourceType.AzureDataLakeStorageGen2));

            var updatedDataSource = updatedDataFeed.DataSource as AzureDataLakeStorageGen2DataFeedSource;

            var expectedKey = TestEnvironment.Mode == RecordedTestMode.Playback ? "Sanitized" : originalKey;

            Assert.That(updatedDataSource, Is.Not.Null);
            Assert.That(updatedDataSource.AccountName, Is.EqualTo(originalAccount));
            Assert.That(updatedDataSource.AccountKey, Is.EqualTo(expectedKey));
            Assert.That(updatedDataSource.FileSystemName, Is.EqualTo(originalFileSystem));
            Assert.That(updatedDataSource.DirectoryTemplate, Is.EqualTo(originalDirectory));
            Assert.That(updatedDataSource.FileTemplate, Is.EqualTo(originalFile));
        }

        [RecordedTest]
        public async Task UpdateAzureDataLakeStorageGen2DataFeedWithMinimumSetupAndNewInstance()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var originalAccount = "account";
            var originalKey = "key";
            var originalFileSystem = "fileSystem";
            var originalDirectory = "dir";
            var originalFile = "file";

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new AzureDataLakeStorageGen2DataFeedSource(originalAccount, originalKey, originalFileSystem, originalDirectory, originalFile);
            var description = "This data feed was created to test the .NET client.";
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed dataFeedToUpdate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            dataFeedToUpdate.Description = description;

            await adminClient.UpdateDataFeedAsync(disposableDataFeed.Id, dataFeedToUpdate);

            DataFeed updatedDataFeed = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            ValidateDataFeedWithMinimumSetup(updatedDataFeed, disposableDataFeed.Id, dataFeedName, description);

            Assert.That(updatedDataFeed.SourceType, Is.EqualTo(DataFeedSourceType.AzureDataLakeStorageGen2));

            var updatedDataSource = updatedDataFeed.DataSource as AzureDataLakeStorageGen2DataFeedSource;

            var expectedKey = TestEnvironment.Mode == RecordedTestMode.Playback ? "Sanitized" : originalKey;

            Assert.That(updatedDataSource, Is.Not.Null);
            Assert.That(updatedDataSource.AccountName, Is.EqualTo(originalAccount));
            Assert.That(updatedDataSource.AccountKey, Is.EqualTo(expectedKey));
            Assert.That(updatedDataSource.FileSystemName, Is.EqualTo(originalFileSystem));
            Assert.That(updatedDataSource.DirectoryTemplate, Is.EqualTo(originalDirectory));
            Assert.That(updatedDataSource.FileTemplate, Is.EqualTo(originalFile));
        }

        [RecordedTest]
        public async Task UpdateAzureTableDataFeedWithMinimumSetupAndGetInstance()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var originalConnectionString = "connectionStr";
            var originalTable = "table";
            var originalQuery = "query";

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new AzureTableDataFeedSource(originalConnectionString, originalTable, originalQuery);
            var description = "This data feed was created to test the .NET client.";
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed dataFeedToUpdate = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            dataFeedToUpdate.Description = description;

            await adminClient.UpdateDataFeedAsync(disposableDataFeed.Id, dataFeedToUpdate);

            DataFeed updatedDataFeed = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            ValidateDataFeedWithMinimumSetup(updatedDataFeed, disposableDataFeed.Id, dataFeedName, description);

            Assert.That(updatedDataFeed.SourceType, Is.EqualTo(DataFeedSourceType.AzureTable));

            var updatedDataSource = updatedDataFeed.DataSource as AzureTableDataFeedSource;

            var expectedConnectStr = TestEnvironment.Mode == RecordedTestMode.Playback ? "Sanitized" : originalConnectionString;

            Assert.That(updatedDataSource, Is.Not.Null);
            Assert.That(updatedDataSource.ConnectionString, Is.EqualTo(expectedConnectStr));
            Assert.That(updatedDataSource.Table, Is.EqualTo(originalTable));
            Assert.That(updatedDataSource.Query, Is.EqualTo(originalQuery));
        }

        [RecordedTest]
        public async Task UpdateAzureTableDataFeedWithMinimumSetupAndNewInstance()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var originalConnectionString = "connectionStr";
            var originalTable = "table";
            var originalQuery = "query";

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new AzureTableDataFeedSource(originalConnectionString, originalTable, originalQuery);
            var description = "This data feed was created to test the .NET client.";
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed dataFeedToUpdate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            dataFeedToUpdate.Description = description;

            await adminClient.UpdateDataFeedAsync(disposableDataFeed.Id, dataFeedToUpdate);

            DataFeed updatedDataFeed = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            ValidateDataFeedWithMinimumSetup(updatedDataFeed, disposableDataFeed.Id, dataFeedName, description);

            Assert.That(updatedDataFeed.SourceType, Is.EqualTo(DataFeedSourceType.AzureTable));

            var updatedDataSource = updatedDataFeed.DataSource as AzureTableDataFeedSource;

            var expectedConnectStr = TestEnvironment.Mode == RecordedTestMode.Playback ? "Sanitized" : originalConnectionString;

            Assert.That(updatedDataSource, Is.Not.Null);
            Assert.That(updatedDataSource.ConnectionString, Is.EqualTo(expectedConnectStr));
            Assert.That(updatedDataSource.Table, Is.EqualTo(originalTable));
            Assert.That(updatedDataSource.Query, Is.EqualTo(originalQuery));
        }

        [RecordedTest]
        public async Task UpdateElasticsearchDataFeedWithMinimumSetupAndGetInstance()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var originalHost = "host";
            var originalPort = "port";
            var originalAuth = "auth";
            var originalQuery = "query";

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new ElasticsearchDataFeedSource(originalHost, originalPort, originalAuth, originalQuery);
            var description = "This data feed was created to test the .NET client.";
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed dataFeedToUpdate = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            dataFeedToUpdate.Description = description;

            await adminClient.UpdateDataFeedAsync(disposableDataFeed.Id, dataFeedToUpdate);

            DataFeed updatedDataFeed = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            ValidateDataFeedWithMinimumSetup(updatedDataFeed, disposableDataFeed.Id, dataFeedName, description);

            Assert.That(updatedDataFeed.SourceType, Is.EqualTo(DataFeedSourceType.Elasticsearch));

            var updatedDataSource = updatedDataFeed.DataSource as ElasticsearchDataFeedSource;

            var expectedAuth = TestEnvironment.Mode == RecordedTestMode.Playback ? "Sanitized" : originalAuth;

            Assert.That(updatedDataSource, Is.Not.Null);
            Assert.That(updatedDataSource.Host, Is.EqualTo(originalHost));
            Assert.That(updatedDataSource.Port, Is.EqualTo(originalPort));
            Assert.That(updatedDataSource.AuthorizationHeader, Is.EqualTo(expectedAuth));
            Assert.That(updatedDataSource.Query, Is.EqualTo(originalQuery));
        }

        [RecordedTest]
        public async Task UpdateElasticsearchDataFeedWithMinimumSetupAndNewInstance()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var originalHost = "host";
            var originalPort = "port";
            var originalAuth = "auth";
            var originalQuery = "query";

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new ElasticsearchDataFeedSource(originalHost, originalPort, originalAuth, originalQuery);
            var description = "This data feed was created to test the .NET client.";
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed dataFeedToUpdate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            dataFeedToUpdate.Description = description;

            await adminClient.UpdateDataFeedAsync(disposableDataFeed.Id, dataFeedToUpdate);

            DataFeed updatedDataFeed = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            ValidateDataFeedWithMinimumSetup(updatedDataFeed, disposableDataFeed.Id, dataFeedName, description);

            Assert.That(updatedDataFeed.SourceType, Is.EqualTo(DataFeedSourceType.Elasticsearch));

            var updatedDataSource = updatedDataFeed.DataSource as ElasticsearchDataFeedSource;

            var expectedAuth = TestEnvironment.Mode == RecordedTestMode.Playback ? "Sanitized" : originalAuth;

            Assert.That(updatedDataSource, Is.Not.Null);
            Assert.That(updatedDataSource.Host, Is.EqualTo(originalHost));
            Assert.That(updatedDataSource.Port, Is.EqualTo(originalPort));
            Assert.That(updatedDataSource.AuthorizationHeader, Is.EqualTo(expectedAuth));
            Assert.That(updatedDataSource.Query, Is.EqualTo(originalQuery));
        }

        [RecordedTest]
        public async Task UpdateHttpRequestDataFeedWithMinimumSetupAndGetInstance()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var originalHeader = "header";
            var originalMethod = "method";
            var originalPayload = "payload";

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSourceHost = new Uri("https://fakehost.com/");
            var dataSource = new HttpRequestDataFeedSource(dataSourceHost, originalHeader, originalMethod, originalPayload);
            var description = "This data feed was created to test the .NET client.";
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed dataFeedToUpdate = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            dataFeedToUpdate.Description = description;

            await adminClient.UpdateDataFeedAsync(disposableDataFeed.Id, dataFeedToUpdate);

            DataFeed updatedDataFeed = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            ValidateDataFeedWithMinimumSetup(updatedDataFeed, disposableDataFeed.Id, dataFeedName, description);

            Assert.That(updatedDataFeed.SourceType, Is.EqualTo(DataFeedSourceType.HttpRequest));

            var updatedDataSource = updatedDataFeed.DataSource as HttpRequestDataFeedSource;

            var expectedHeader = TestEnvironment.Mode == RecordedTestMode.Playback ? "Sanitized" : originalHeader;

            Assert.That(updatedDataSource, Is.Not.Null);
            Assert.That(updatedDataSource.Url.AbsoluteUri, Is.EqualTo(dataSourceHost.AbsoluteUri));
            Assert.That(updatedDataSource.HttpHeader, Is.EqualTo(expectedHeader));
            Assert.That(updatedDataSource.HttpMethod, Is.EqualTo(originalMethod));
            Assert.That(updatedDataSource.Payload, Is.EqualTo(originalPayload));
        }

        [RecordedTest]
        public async Task UpdateHttpRequestDataFeedWithMinimumSetupAndNewInstance()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var originalHeader = "header";
            var originalMethod = "method";
            var originalPayload = "payload";

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSourceHost = new Uri("https://fakehost.com/");
            var dataSource = new HttpRequestDataFeedSource(dataSourceHost, originalHeader, originalMethod, originalPayload);
            var description = "This data feed was created to test the .NET client.";
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed dataFeedToUpdate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            dataFeedToUpdate.Description = description;

            await adminClient.UpdateDataFeedAsync(disposableDataFeed.Id, dataFeedToUpdate);

            DataFeed updatedDataFeed = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            ValidateDataFeedWithMinimumSetup(updatedDataFeed, disposableDataFeed.Id, dataFeedName, description);

            Assert.That(updatedDataFeed.SourceType, Is.EqualTo(DataFeedSourceType.HttpRequest));

            var updatedDataSource = updatedDataFeed.DataSource as HttpRequestDataFeedSource;

            var expectedHeader = TestEnvironment.Mode == RecordedTestMode.Playback ? "Sanitized" : originalHeader;

            Assert.That(updatedDataSource, Is.Not.Null);
            Assert.That(updatedDataSource.Url.AbsoluteUri, Is.EqualTo(dataSourceHost.AbsoluteUri));
            Assert.That(updatedDataSource.HttpHeader, Is.EqualTo(expectedHeader));
            Assert.That(updatedDataSource.HttpMethod, Is.EqualTo(originalMethod));
            Assert.That(updatedDataSource.Payload, Is.EqualTo(originalPayload));
        }

        [RecordedTest]
        public async Task UpdateInfluxDbDataFeedWithMinimumSetupAndGetInstance()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var originalConnectionString = "connectionStr";
            var originalDatabase = "database";
            var originalUsername = "username";
            var originalPassword = "pass";
            var originalQuery = "query";

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new InfluxDbDataFeedSource(originalConnectionString, originalDatabase, originalUsername, originalPassword, originalQuery);
            var description = "This data feed was created to test the .NET client.";
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed dataFeedToUpdate = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            dataFeedToUpdate.Description = description;

            await adminClient.UpdateDataFeedAsync(disposableDataFeed.Id, dataFeedToUpdate);

            DataFeed updatedDataFeed = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            ValidateDataFeedWithMinimumSetup(updatedDataFeed, disposableDataFeed.Id, dataFeedName, description);

            Assert.That(updatedDataFeed.SourceType, Is.EqualTo(DataFeedSourceType.InfluxDb));

            var updatedDataSource = updatedDataFeed.DataSource as InfluxDbDataFeedSource;

            var expectedConnectStr = TestEnvironment.Mode == RecordedTestMode.Playback ? "Sanitized" : originalConnectionString;

            Assert.That(updatedDataSource, Is.Not.Null);
            Assert.That(updatedDataSource.ConnectionString, Is.EqualTo(expectedConnectStr));
            Assert.That(updatedDataSource.Database, Is.EqualTo(originalDatabase));
            Assert.That(updatedDataSource.Username, Is.EqualTo(originalUsername));
            Assert.That(updatedDataSource.Password, Is.EqualTo(originalPassword));
            Assert.That(updatedDataSource.Query, Is.EqualTo(originalQuery));
        }

        [RecordedTest]
        public async Task UpdateInfluxDbDataFeedWithMinimumSetupAndNewInstance()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var originalConnectionString = "connectionStr";
            var originalDatabase = "database";
            var originalUsername = "username";
            var originalPassword = "pass";
            var originalQuery = "query";

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new InfluxDbDataFeedSource(originalConnectionString, originalDatabase, originalUsername, originalPassword, originalQuery);
            var description = "This data feed was created to test the .NET client.";
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed dataFeedToUpdate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            dataFeedToUpdate.Description = description;

            await adminClient.UpdateDataFeedAsync(disposableDataFeed.Id, dataFeedToUpdate);

            DataFeed updatedDataFeed = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            ValidateDataFeedWithMinimumSetup(updatedDataFeed, disposableDataFeed.Id, dataFeedName, description);

            Assert.That(updatedDataFeed.SourceType, Is.EqualTo(DataFeedSourceType.InfluxDb));

            var updatedDataSource = updatedDataFeed.DataSource as InfluxDbDataFeedSource;

            var expectedConnectStr = TestEnvironment.Mode == RecordedTestMode.Playback ? "Sanitized" : originalConnectionString;

            Assert.That(updatedDataSource, Is.Not.Null);
            Assert.That(updatedDataSource.ConnectionString, Is.EqualTo(expectedConnectStr));
            Assert.That(updatedDataSource.Database, Is.EqualTo(originalDatabase));
            Assert.That(updatedDataSource.Username, Is.EqualTo(originalUsername));
            Assert.That(updatedDataSource.Password, Is.EqualTo(originalPassword));
            Assert.That(updatedDataSource.Query, Is.EqualTo(originalQuery));
        }

        [RecordedTest]
        public async Task UpdateMongoDbDataFeedWithMinimumSetupAndGetInstance()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var originalConnectionString = "connectionStr";
            var originalDatabase = "database";
            var originalCommand = "command";

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new MongoDbDataFeedSource(originalConnectionString, originalDatabase, originalCommand);
            var description = "This data feed was created to test the .NET client.";
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed dataFeedToUpdate = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            dataFeedToUpdate.Description = description;

            await adminClient.UpdateDataFeedAsync(disposableDataFeed.Id, dataFeedToUpdate);

            DataFeed updatedDataFeed = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            ValidateDataFeedWithMinimumSetup(updatedDataFeed, disposableDataFeed.Id, dataFeedName, description);

            Assert.That(updatedDataFeed.SourceType, Is.EqualTo(DataFeedSourceType.MongoDb));

            var updatedDataSource = updatedDataFeed.DataSource as MongoDbDataFeedSource;

            var expectedConnectStr = TestEnvironment.Mode == RecordedTestMode.Playback ? "Sanitized" : originalConnectionString;

            Assert.That(updatedDataSource, Is.Not.Null);
            Assert.That(updatedDataSource.ConnectionString, Is.EqualTo(expectedConnectStr));
            Assert.That(updatedDataSource.Database, Is.EqualTo(originalDatabase));
            Assert.That(updatedDataSource.Command, Is.EqualTo(originalCommand));
        }

        [RecordedTest]
        public async Task UpdateMongoDbDataFeedWithMinimumSetupAndNewInstance()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var originalConnectionString = "connectionStr";
            var originalDatabase = "database";
            var originalCommand = "command";

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new MongoDbDataFeedSource(originalConnectionString, originalDatabase, originalCommand);
            var description = "This data feed was created to test the .NET client.";
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed dataFeedToUpdate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            dataFeedToUpdate.Description = description;

            await adminClient.UpdateDataFeedAsync(disposableDataFeed.Id, dataFeedToUpdate);

            DataFeed updatedDataFeed = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            ValidateDataFeedWithMinimumSetup(updatedDataFeed, disposableDataFeed.Id, dataFeedName, description);

            Assert.That(updatedDataFeed.SourceType, Is.EqualTo(DataFeedSourceType.MongoDb));

            var updatedDataSource = updatedDataFeed.DataSource as MongoDbDataFeedSource;

            var expectedConnectStr = TestEnvironment.Mode == RecordedTestMode.Playback ? "Sanitized" : originalConnectionString;

            Assert.That(updatedDataSource, Is.Not.Null);
            Assert.That(updatedDataSource.ConnectionString, Is.EqualTo(expectedConnectStr));
            Assert.That(updatedDataSource.Database, Is.EqualTo(originalDatabase));
            Assert.That(updatedDataSource.Command, Is.EqualTo(originalCommand));
        }

        [RecordedTest]
        public async Task UpdateMySqlDataFeedWithMinimumSetupAndGetInstance()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var originalConnectionString = "connectionStr";
            var originalQuery = "query";

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new MySqlDataFeedSource(originalConnectionString, originalQuery);
            var description = "This data feed was created to test the .NET client.";
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed dataFeedToUpdate = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            dataFeedToUpdate.Description = description;

            await adminClient.UpdateDataFeedAsync(disposableDataFeed.Id, dataFeedToUpdate);

            DataFeed updatedDataFeed = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            ValidateDataFeedWithMinimumSetup(updatedDataFeed, disposableDataFeed.Id, dataFeedName, description);

            Assert.That(updatedDataFeed.SourceType, Is.EqualTo(DataFeedSourceType.MySql));

            var updatedDataSource = updatedDataFeed.DataSource as MySqlDataFeedSource;

            var expectedConnectStr = TestEnvironment.Mode == RecordedTestMode.Playback ? "Sanitized" : originalConnectionString;

            Assert.That(updatedDataSource, Is.Not.Null);
            Assert.That(updatedDataSource.ConnectionString, Is.EqualTo(expectedConnectStr));
            Assert.That(updatedDataSource.Query, Is.EqualTo(originalQuery));
        }

        [RecordedTest]
        public async Task UpdateMySqlDataFeedWithMinimumSetupAndNewInstance()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var originalConnectionString = "connectionStr";
            var originalQuery = "query";

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new MySqlDataFeedSource(originalConnectionString, originalQuery);
            var description = "This data feed was created to test the .NET client.";
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed dataFeedToUpdate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            dataFeedToUpdate.Description = description;

            await adminClient.UpdateDataFeedAsync(disposableDataFeed.Id, dataFeedToUpdate);

            DataFeed updatedDataFeed = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            ValidateDataFeedWithMinimumSetup(updatedDataFeed, disposableDataFeed.Id, dataFeedName, description);

            Assert.That(updatedDataFeed.SourceType, Is.EqualTo(DataFeedSourceType.MySql));

            var updatedDataSource = updatedDataFeed.DataSource as MySqlDataFeedSource;

            var expectedConnectStr = TestEnvironment.Mode == RecordedTestMode.Playback ? "Sanitized" : originalConnectionString;

            Assert.That(updatedDataSource, Is.Not.Null);
            Assert.That(updatedDataSource.ConnectionString, Is.EqualTo(expectedConnectStr));
            Assert.That(updatedDataSource.Query, Is.EqualTo(originalQuery));
        }

        [RecordedTest]
        public async Task UpdatePostgreSqlDataFeedWithMinimumSetupAndGetInstance()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var originalConnectionString = "connectionStr";
            var originalQuery = "query";

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new PostgreSqlDataFeedSource(originalConnectionString, originalQuery);
            var description = "This data feed was created to test the .NET client.";
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed dataFeedToUpdate = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            dataFeedToUpdate.Description = description;

            await adminClient.UpdateDataFeedAsync(disposableDataFeed.Id, dataFeedToUpdate);

            DataFeed updatedDataFeed = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            ValidateDataFeedWithMinimumSetup(updatedDataFeed, disposableDataFeed.Id, dataFeedName, description);

            Assert.That(updatedDataFeed.SourceType, Is.EqualTo(DataFeedSourceType.PostgreSql));

            var updatedDataSource = updatedDataFeed.DataSource as PostgreSqlDataFeedSource;

            var expectedConnectStr = TestEnvironment.Mode == RecordedTestMode.Playback ? "Sanitized" : originalConnectionString;

            Assert.That(updatedDataSource, Is.Not.Null);
            Assert.That(updatedDataSource.ConnectionString, Is.EqualTo(expectedConnectStr));
            Assert.That(updatedDataSource.Query, Is.EqualTo(originalQuery));
        }

        [RecordedTest]
        public async Task UpdatePostgreSqlDataFeedWithMinimumSetupAndNewInstance()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var originalConnectionString = "connectionStr";
            var originalQuery = "query";

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new PostgreSqlDataFeedSource(originalConnectionString, originalQuery);
            var description = "This data feed was created to test the .NET client.";
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed dataFeedToUpdate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            dataFeedToUpdate.Description = description;

            await adminClient.UpdateDataFeedAsync(disposableDataFeed.Id, dataFeedToUpdate);

            DataFeed updatedDataFeed = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            ValidateDataFeedWithMinimumSetup(updatedDataFeed, disposableDataFeed.Id, dataFeedName, description);

            Assert.That(updatedDataFeed.SourceType, Is.EqualTo(DataFeedSourceType.PostgreSql));

            var updatedDataSource = updatedDataFeed.DataSource as PostgreSqlDataFeedSource;

            var expectedConnectStr = TestEnvironment.Mode == RecordedTestMode.Playback ? "Sanitized" : originalConnectionString;

            Assert.That(updatedDataSource, Is.Not.Null);
            Assert.That(updatedDataSource.ConnectionString, Is.EqualTo(expectedConnectStr));
            Assert.That(updatedDataSource.Query, Is.EqualTo(originalQuery));
        }

        [RecordedTest]
        public async Task UpdateSqlServerDataFeedWithMinimumSetupAndGetInstance()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var originalConnectionString = "connectionStr";
            var originalQuery = "query";

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new SqlServerDataFeedSource(originalConnectionString, originalQuery);
            var description = "This data feed was created to test the .NET client.";
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed dataFeedToUpdate = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            dataFeedToUpdate.Description = description;

            await adminClient.UpdateDataFeedAsync(disposableDataFeed.Id, dataFeedToUpdate);

            DataFeed updatedDataFeed = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            ValidateDataFeedWithMinimumSetup(updatedDataFeed, disposableDataFeed.Id, dataFeedName, description);

            Assert.That(updatedDataFeed.SourceType, Is.EqualTo(DataFeedSourceType.SqlServer));

            var updatedDataSource = updatedDataFeed.DataSource as SqlServerDataFeedSource;

            var expectedConnectStr = TestEnvironment.Mode == RecordedTestMode.Playback ? "Sanitized" : originalConnectionString;

            Assert.That(updatedDataSource, Is.Not.Null);
            Assert.That(updatedDataSource.ConnectionString, Is.EqualTo(expectedConnectStr));
            Assert.That(updatedDataSource.Query, Is.EqualTo(originalQuery));
        }

        [RecordedTest]
        public async Task UpdateSqlServerDataFeedWithMinimumSetupAndNewInstance()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var originalConnectionString = "connectionStr";
            var originalQuery = "query";

            var dataFeedName = Recording.GenerateAlphaNumericId("dataFeed");
            var dataSource = new SqlServerDataFeedSource(originalConnectionString, originalQuery);
            var description = "This data feed was created to test the .NET client.";
            DataFeed dataFeedToCreate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            await using var disposableDataFeed = await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeedToCreate);

            DataFeed dataFeedToUpdate = GetDataFeedWithMinimumSetup(dataFeedName, dataSource);

            dataFeedToUpdate.Description = description;

            await adminClient.UpdateDataFeedAsync(disposableDataFeed.Id, dataFeedToUpdate);

            DataFeed updatedDataFeed = await adminClient.GetDataFeedAsync(disposableDataFeed.Id);

            ValidateDataFeedWithMinimumSetup(updatedDataFeed, disposableDataFeed.Id, dataFeedName, description);

            Assert.That(updatedDataFeed.SourceType, Is.EqualTo(DataFeedSourceType.SqlServer));

            var updatedDataSource = updatedDataFeed.DataSource as SqlServerDataFeedSource;

            var expectedConnectStr = TestEnvironment.Mode == RecordedTestMode.Playback ? "Sanitized" : originalConnectionString;

            Assert.That(updatedDataSource, Is.Not.Null);
            Assert.That(updatedDataSource.ConnectionString, Is.EqualTo(expectedConnectStr));
            Assert.That(updatedDataSource.Query, Is.EqualTo(originalQuery));
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
    }
}
