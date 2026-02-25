// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Search.Documents.Indexes;
using Azure.Search.Documents.Indexes.Models;
using NUnit.Framework;

namespace Azure.Search.Documents.Tests
{
    /// <summary>
    /// Mock-based tests to verify all client overloads route parameters correctly
    /// without making actual service calls.
    /// </summary>
    public class SearchIndexerClientOverloadTests : ClientTestBase
    {
        private static readonly Uri s_endpoint = new("https://test-search.search.windows.net");
        private static readonly AzureKeyCredential s_credential = new("fake-api-key");

        public SearchIndexerClientOverloadTests(bool isAsync) : base(isAsync)
        {
        }

        #region Test Infrastructure

        /// <summary>
        /// Creates a client with a mock transport that captures requests and returns a configurable response.
        /// </summary>
        private SearchIndexerClient CreateMockClient(MockTransport mockTransport)
        {
            var options = new SearchClientOptions
            {
                Transport = mockTransport
            };

            return InstrumentClient(new SearchIndexerClient(s_endpoint, s_credential, options));
        }

        #region Mock Response Factories

        private static MockResponse CreateSkillsetResponse(string skillsetName)
        {
            var response = new MockResponse(200);
            response.SetContent($@"{{
                ""name"": ""{skillsetName}"",
                ""description"": ""Test skillset"",
                ""skills"": [],
                ""@odata.etag"": ""0x12345""
            }}");
            return response;
        }

        private static MockResponse CreateIndexerResponse(string indexerName)
        {
            var response = new MockResponse(200);
            response.SetContent($@"{{
                ""name"": ""{indexerName}"",
                ""dataSourceName"": ""test-datasource"",
                ""targetIndexName"": ""test-index"",
                ""@odata.etag"": ""0x12345""
            }}");
            return response;
        }

        private static MockResponse CreateDataSourceResponse(string dataSourceName)
        {
            var response = new MockResponse(200);
            response.SetContent($@"{{
                ""name"": ""{dataSourceName}"",
                ""type"": ""azureblob"",
                ""credentials"": {{ ""connectionString"": null }},
                ""container"": {{ ""name"": ""test-container"" }},
                ""@odata.etag"": ""0x12345""
            }}");
            return response;
        }

        private static MockResponse CreateDeleteResponse() => new MockResponse(204);

        private static MockResponse CreateListSkillsetsResponse()
        {
            var response = new MockResponse(200);
            response.SetContent(@"{""value"": [{""name"": ""skillset1"", ""skills"": []}]}");
            return response;
        }

        private static MockResponse CreateListIndexersResponse()
        {
            var response = new MockResponse(200);
            response.SetContent(@"{""value"": [{""name"": ""indexer1"", ""dataSourceName"": ""ds1"", ""targetIndexName"": ""idx1""}]}");
            return response;
        }

        private static MockResponse CreateListDataSourcesResponse()
        {
            var response = new MockResponse(200);
            response.SetContent(@"{""value"": [{""name"": ""datasource1"", ""type"": ""azureblob"", ""credentials"": {""connectionString"": null}, ""container"": {""name"": ""test""}}]}");
            return response;
        }

        #endregion

        #region Test Object Factories

        private static SearchIndexerSkillset CreateTestSkillset(string name = "test-skillset") =>
            new(name, new List<SearchIndexerSkill>());

        private static SearchIndexer CreateTestIndexer(string name = "test-indexer") =>
            new(name, "test-datasource", "test-index");

        private static SearchIndexerDataSourceConnection CreateTestDataSource(string name = "test-datasource") =>
            new(name, SearchIndexerDataSourceType.AzureBlob, "DefaultEndpointsProtocol=https;AccountName=test", new SearchIndexerDataContainer("test-container"));

        #endregion

        #region Assertion Helpers

        private static void AssertQueryParameter(MockRequest request, string paramName, string expectedValue)
        {
            var query = request.Uri.Query;
            var expected = $"{paramName}={expectedValue}";
            Assert.IsTrue(query.Contains(expected), $"Expected query to contain '{expected}' but was '{query}'");
        }

        private static void AssertQueryParameterAbsent(MockRequest request, string paramName)
        {
            var query = request.Uri.Query;
            Assert.IsFalse(query.Contains($"{paramName}="), $"Expected query to NOT contain '{paramName}' but was '{query}'");
        }

        private static void AssertRequestMethod(MockRequest request, string expectedMethod)
        {
            Assert.AreEqual(expectedMethod, request.Method.Method.ToUpperInvariant());
        }

        private static void AssertRequestPath(MockRequest request, string expectedPathPart)
        {
            Assert.IsTrue(request.Uri.Path.Contains(expectedPathPart), $"Expected path to contain '{expectedPathPart}' but was '{request.Uri.Path}'");
        }

        private static void AssertIfMatchHeader(MockRequest request, string expectedValue)
        {
            Assert.IsTrue(request.Headers.TryGetValue("If-Match", out var ifMatch), "Expected If-Match header to be present");
            Assert.AreEqual(expectedValue, ifMatch);
        }

        private static void AssertNoIfMatchHeader(MockRequest request)
        {
            Assert.IsFalse(request.Headers.TryGetValue("If-Match", out _), "Expected If-Match header to NOT be present");
        }

        #endregion

        #endregion

        #region Skillset Operations

        #region CreateOrUpdateSkillset Overload Tests

        [Test]
        public async Task CreateOrUpdateSkillset_MinimalOverload_RoutesCorrectly()
        {
            var skillset = CreateTestSkillset();
            var mockTransport = new MockTransport(CreateSkillsetResponse(skillset.Name));
            var client = CreateMockClient(mockTransport);

            await client.CreateOrUpdateSkillsetAsync(skillset);

            var request = mockTransport.Requests[0];
            AssertRequestMethod(request, "PUT");
            AssertRequestPath(request, $"/skillsets('{skillset.Name}')");
            AssertQueryParameterAbsent(request, "ignoreCacheResetRequirements");
            AssertQueryParameterAbsent(request, "disableCacheReprocessingChangeDetection");
        }

        [Test]
        public async Task CreateOrUpdateSkillset_WithOnlyIfUnchanged_SetsIfMatchHeader()
        {
            var skillset = CreateTestSkillset();
            skillset.ETag = new Azure.ETag("etag-value");
            var mockTransport = new MockTransport(CreateSkillsetResponse(skillset.Name));
            var client = CreateMockClient(mockTransport);

            await client.CreateOrUpdateSkillsetAsync(skillset, onlyIfUnchanged: true);

            var request = mockTransport.Requests[0];
            AssertRequestMethod(request, "PUT");
            AssertIfMatchHeader(request, "etag-value");
        }

        [Test]
        public async Task CreateOrUpdateSkillset_WithOnlyIfUnchangedFalse_NoIfMatchHeader()
        {
            var skillset = CreateTestSkillset();
            skillset.ETag = new Azure.ETag("etag-value");
            var mockTransport = new MockTransport(CreateSkillsetResponse(skillset.Name));
            var client = CreateMockClient(mockTransport);

            await client.CreateOrUpdateSkillsetAsync(skillset, onlyIfUnchanged: false);

            var request = mockTransport.Requests[0];
            AssertNoIfMatchHeader(request);
        }

        [Test]
        public async Task CreateOrUpdateSkillset_LegacyOverload_RoutesCorrectly()
        {
            var skillset = CreateTestSkillset();
            var mockTransport = new MockTransport(CreateSkillsetResponse(skillset.Name));
            var client = CreateMockClient(mockTransport);

            await client.CreateOrUpdateSkillsetAsync(skillset, onlyIfUnchanged: false, CancellationToken.None);

            var request = mockTransport.Requests[0];
            AssertRequestMethod(request, "PUT");
            AssertRequestPath(request, $"/skillsets('{skillset.Name}')");
            AssertQueryParameterAbsent(request, "ignoreCacheResetRequirements");
            AssertQueryParameterAbsent(request, "disableCacheReprocessingChangeDetection");
        }

        [Test]
        public async Task CreateOrUpdateSkillset_WithAllCacheParameters_RoutesCorrectly()
        {
            var skillset = CreateTestSkillset();
            var mockTransport = new MockTransport(CreateSkillsetResponse(skillset.Name));
            var client = CreateMockClient(mockTransport);

            await client.CreateOrUpdateSkillsetAsync(
                skillset,
                onlyIfUnchanged: false,
                ignoreCacheResetRequirements: true,
                disableCacheReprocessingChangeDetection: true);

            var request = mockTransport.Requests[0];
            AssertRequestMethod(request, "PUT");
            AssertQueryParameter(request, "ignoreCacheResetRequirements", "true");
            AssertQueryParameter(request, "disableCacheReprocessingChangeDetection", "true");
        }

        [Test]
        public async Task CreateOrUpdateSkillset_WithOnlyIgnoreCacheResetRequirements_RoutesCorrectly()
        {
            var skillset = CreateTestSkillset();
            var mockTransport = new MockTransport(CreateSkillsetResponse(skillset.Name));
            var client = CreateMockClient(mockTransport);

            await client.CreateOrUpdateSkillsetAsync(
                skillset,
                onlyIfUnchanged: false,
                ignoreCacheResetRequirements: true,
                disableCacheReprocessingChangeDetection: null);

            var request = mockTransport.Requests[0];
            AssertQueryParameter(request, "ignoreCacheResetRequirements", "true");
            AssertQueryParameterAbsent(request, "disableCacheReprocessingChangeDetection");
        }

        [Test]
        public async Task CreateOrUpdateSkillset_WithOnlyDisableCacheReprocessing_RoutesCorrectly()
        {
            var skillset = CreateTestSkillset();
            var mockTransport = new MockTransport(CreateSkillsetResponse(skillset.Name));
            var client = CreateMockClient(mockTransport);

            await client.CreateOrUpdateSkillsetAsync(
                skillset,
                onlyIfUnchanged: false,
                ignoreCacheResetRequirements: null,
                disableCacheReprocessingChangeDetection: false);

            var request = mockTransport.Requests[0];
            AssertQueryParameterAbsent(request, "ignoreCacheResetRequirements");
            AssertQueryParameter(request, "disableCacheReprocessingChangeDetection", "false");
        }

        [Test]
        public async Task CreateOrUpdateSkillset_WithCacheParametersFalse_RoutesCorrectly()
        {
            var skillset = CreateTestSkillset();
            var mockTransport = new MockTransport(CreateSkillsetResponse(skillset.Name));
            var client = CreateMockClient(mockTransport);

            await client.CreateOrUpdateSkillsetAsync(
                skillset,
                onlyIfUnchanged: false,
                ignoreCacheResetRequirements: false,
                disableCacheReprocessingChangeDetection: false);

            var request = mockTransport.Requests[0];
            AssertQueryParameter(request, "ignoreCacheResetRequirements", "false");
            AssertQueryParameter(request, "disableCacheReprocessingChangeDetection", "false");
        }

        #endregion

        #region DeleteSkillset Overload Tests

        [Test]
        public async Task DeleteSkillset_ByName_RoutesCorrectly()
        {
            var mockTransport = new MockTransport(CreateDeleteResponse());
            var client = CreateMockClient(mockTransport);

            await client.DeleteSkillsetAsync("my-skillset");

            var request = mockTransport.Requests[0];
            AssertRequestMethod(request, "DELETE");
            AssertRequestPath(request, "/skillsets('my-skillset')");
        }

        [Test]
        public async Task DeleteSkillset_ByNameWithCancellationToken_RoutesCorrectly()
        {
            var mockTransport = new MockTransport(CreateDeleteResponse());
            var client = CreateMockClient(mockTransport);

            await client.DeleteSkillsetAsync("my-skillset", CancellationToken.None);

            var request = mockTransport.Requests[0];
            AssertRequestMethod(request, "DELETE");
            AssertRequestPath(request, "/skillsets('my-skillset')");
        }

        [Test]
        public async Task DeleteSkillset_ByObject_RoutesCorrectly()
        {
            var skillset = CreateTestSkillset("my-skillset");
            var mockTransport = new MockTransport(CreateDeleteResponse());
            var client = CreateMockClient(mockTransport);

            await client.DeleteSkillsetAsync(skillset);

            var request = mockTransport.Requests[0];
            AssertRequestMethod(request, "DELETE");
            AssertRequestPath(request, "/skillsets('my-skillset')");
        }

        [Test]
        public async Task DeleteSkillset_ByObjectWithOnlyIfUnchangedTrue_SetsIfMatchHeader()
        {
            var skillset = CreateTestSkillset("my-skillset");
            skillset.ETag = new Azure.ETag("my-etag");
            var mockTransport = new MockTransport(CreateDeleteResponse());
            var client = CreateMockClient(mockTransport);

            await client.DeleteSkillsetAsync(skillset, onlyIfUnchanged: true);

            var request = mockTransport.Requests[0];
            AssertIfMatchHeader(request, "my-etag");
        }

        [Test]
        public async Task DeleteSkillset_ByObjectWithOnlyIfUnchangedFalse_NoIfMatchHeader()
        {
            var skillset = CreateTestSkillset("my-skillset");
            skillset.ETag = new Azure.ETag("my-etag");
            var mockTransport = new MockTransport(CreateDeleteResponse());
            var client = CreateMockClient(mockTransport);

            await client.DeleteSkillsetAsync(skillset, onlyIfUnchanged: false);

            var request = mockTransport.Requests[0];
            AssertNoIfMatchHeader(request);
        }

        #endregion

        #region GetSkillsets Overload Tests

        [Test]
        public async Task GetSkillsets_RoutesCorrectly()
        {
            var mockTransport = new MockTransport(CreateListSkillsetsResponse());
            var client = CreateMockClient(mockTransport);

            await client.GetSkillsetsAsync();

            var request = mockTransport.Requests[0];
            AssertRequestMethod(request, "GET");
            AssertRequestPath(request, "/skillsets");
            AssertQueryParameter(request, "$select", "*");
        }

        [Test]
        public async Task GetSkillsets_WithCancellationToken_RoutesCorrectly()
        {
            var mockTransport = new MockTransport(CreateListSkillsetsResponse());
            var client = CreateMockClient(mockTransport);

            await client.GetSkillsetsAsync(CancellationToken.None);

            var request = mockTransport.Requests[0];
            AssertRequestMethod(request, "GET");
            AssertRequestPath(request, "/skillsets");
            AssertQueryParameter(request, "$select", "*");
        }

        [Test]
        public async Task GetSkillsetNames_RoutesCorrectly()
        {
            var mockTransport = new MockTransport(CreateListSkillsetsResponse());
            var client = CreateMockClient(mockTransport);

            await client.GetSkillsetNamesAsync();

            var request = mockTransport.Requests[0];
            AssertRequestMethod(request, "GET");
            AssertRequestPath(request, "/skillsets");
            AssertQueryParameter(request, "$select", "name");
        }

        [Test]
        public async Task GetSkillsetNames_WithCancellationToken_RoutesCorrectly()
        {
            var mockTransport = new MockTransport(CreateListSkillsetsResponse());
            var client = CreateMockClient(mockTransport);

            await client.GetSkillsetNamesAsync(CancellationToken.None);

            var request = mockTransport.Requests[0];
            AssertRequestMethod(request, "GET");
            AssertRequestPath(request, "/skillsets");
            AssertQueryParameter(request, "$select", "name");
        }

        #endregion

        #endregion

        #region Indexer Operations

        #region CreateOrUpdateIndexer Overload Tests

        [Test]
        public async Task CreateOrUpdateIndexer_MinimalOverload_RoutesCorrectly()
        {
            var indexer = CreateTestIndexer();
            var mockTransport = new MockTransport(CreateIndexerResponse(indexer.Name));
            var client = CreateMockClient(mockTransport);

            await client.CreateOrUpdateIndexerAsync(indexer);

            var request = mockTransport.Requests[0];
            AssertRequestMethod(request, "PUT");
            AssertRequestPath(request, $"/indexers('{indexer.Name}')");
            AssertQueryParameterAbsent(request, "ignoreCacheResetRequirements");
            AssertQueryParameterAbsent(request, "disableCacheReprocessingChangeDetection");
        }

        [Test]
        public async Task CreateOrUpdateIndexer_WithOnlyIfUnchanged_SetsIfMatchHeader()
        {
            var indexer = CreateTestIndexer();
            indexer.ETag = new Azure.ETag("indexer-etag");
            var mockTransport = new MockTransport(CreateIndexerResponse(indexer.Name));
            var client = CreateMockClient(mockTransport);

            await client.CreateOrUpdateIndexerAsync(indexer, onlyIfUnchanged: true);

            var request = mockTransport.Requests[0];
            AssertRequestMethod(request, "PUT");
            AssertIfMatchHeader(request, "indexer-etag");
        }

        [Test]
        public async Task CreateOrUpdateIndexer_WithOnlyIfUnchangedFalse_NoIfMatchHeader()
        {
            var indexer = CreateTestIndexer();
            indexer.ETag = new Azure.ETag("indexer-etag");
            var mockTransport = new MockTransport(CreateIndexerResponse(indexer.Name));
            var client = CreateMockClient(mockTransport);

            await client.CreateOrUpdateIndexerAsync(indexer, onlyIfUnchanged: false);

            var request = mockTransport.Requests[0];
            AssertNoIfMatchHeader(request);
        }

        [Test]
        public async Task CreateOrUpdateIndexer_LegacyOverload_RoutesCorrectly()
        {
            var indexer = CreateTestIndexer();
            var mockTransport = new MockTransport(CreateIndexerResponse(indexer.Name));
            var client = CreateMockClient(mockTransport);

            await client.CreateOrUpdateIndexerAsync(indexer, onlyIfUnchanged: false, CancellationToken.None);

            var request = mockTransport.Requests[0];
            AssertRequestMethod(request, "PUT");
            AssertRequestPath(request, $"/indexers('{indexer.Name}')");
            AssertQueryParameterAbsent(request, "ignoreCacheResetRequirements");
            AssertQueryParameterAbsent(request, "disableCacheReprocessingChangeDetection");
        }

        [Test]
        public async Task CreateOrUpdateIndexer_WithAllCacheParameters_RoutesCorrectly()
        {
            var indexer = CreateTestIndexer();
            var mockTransport = new MockTransport(CreateIndexerResponse(indexer.Name));
            var client = CreateMockClient(mockTransport);

            await client.CreateOrUpdateIndexerAsync(
                indexer,
                onlyIfUnchanged: false,
                ignoreCacheResetRequirements: true,
                disableCacheReprocessingChangeDetection: true);

            var request = mockTransport.Requests[0];
            AssertRequestMethod(request, "PUT");
            AssertQueryParameter(request, "ignoreCacheResetRequirements", "true");
            AssertQueryParameter(request, "disableCacheReprocessingChangeDetection", "true");
        }

        [Test]
        public async Task CreateOrUpdateIndexer_WithOnlyIgnoreCacheResetRequirements_RoutesCorrectly()
        {
            var indexer = CreateTestIndexer();
            var mockTransport = new MockTransport(CreateIndexerResponse(indexer.Name));
            var client = CreateMockClient(mockTransport);

            await client.CreateOrUpdateIndexerAsync(
                indexer,
                onlyIfUnchanged: false,
                ignoreCacheResetRequirements: true,
                disableCacheReprocessingChangeDetection: null);

            var request = mockTransport.Requests[0];
            AssertQueryParameter(request, "ignoreCacheResetRequirements", "true");
            AssertQueryParameterAbsent(request, "disableCacheReprocessingChangeDetection");
        }

        [Test]
        public async Task CreateOrUpdateIndexer_WithOnlyDisableCacheReprocessing_RoutesCorrectly()
        {
            var indexer = CreateTestIndexer();
            var mockTransport = new MockTransport(CreateIndexerResponse(indexer.Name));
            var client = CreateMockClient(mockTransport);

            await client.CreateOrUpdateIndexerAsync(
                indexer,
                onlyIfUnchanged: false,
                ignoreCacheResetRequirements: null,
                disableCacheReprocessingChangeDetection: false);

            var request = mockTransport.Requests[0];
            AssertQueryParameterAbsent(request, "ignoreCacheResetRequirements");
            AssertQueryParameter(request, "disableCacheReprocessingChangeDetection", "false");
        }

        [Test]
        public async Task CreateOrUpdateIndexer_WithCacheParametersFalse_RoutesCorrectly()
        {
            var indexer = CreateTestIndexer();
            var mockTransport = new MockTransport(CreateIndexerResponse(indexer.Name));
            var client = CreateMockClient(mockTransport);

            await client.CreateOrUpdateIndexerAsync(
                indexer,
                onlyIfUnchanged: false,
                ignoreCacheResetRequirements: false,
                disableCacheReprocessingChangeDetection: false);

            var request = mockTransport.Requests[0];
            AssertQueryParameter(request, "ignoreCacheResetRequirements", "false");
            AssertQueryParameter(request, "disableCacheReprocessingChangeDetection", "false");
        }

        #endregion

        #region DeleteIndexer Overload Tests

        [Test]
        public async Task DeleteIndexer_ByName_RoutesCorrectly()
        {
            var mockTransport = new MockTransport(CreateDeleteResponse());
            var client = CreateMockClient(mockTransport);

            await client.DeleteIndexerAsync("my-indexer");

            var request = mockTransport.Requests[0];
            AssertRequestMethod(request, "DELETE");
            AssertRequestPath(request, "/indexers('my-indexer')");
        }

        [Test]
        public async Task DeleteIndexer_ByNameWithCancellationToken_RoutesCorrectly()
        {
            var mockTransport = new MockTransport(CreateDeleteResponse());
            var client = CreateMockClient(mockTransport);

            await client.DeleteIndexerAsync("my-indexer", CancellationToken.None);

            var request = mockTransport.Requests[0];
            AssertRequestMethod(request, "DELETE");
            AssertRequestPath(request, "/indexers('my-indexer')");
        }

        [Test]
        public async Task DeleteIndexer_ByObject_RoutesCorrectly()
        {
            var indexer = CreateTestIndexer("my-indexer");
            var mockTransport = new MockTransport(CreateDeleteResponse());
            var client = CreateMockClient(mockTransport);

            await client.DeleteIndexerAsync(indexer);

            var request = mockTransport.Requests[0];
            AssertRequestMethod(request, "DELETE");
            AssertRequestPath(request, "/indexers('my-indexer')");
            AssertNoIfMatchHeader(request);
        }

        [Test]
        public async Task DeleteIndexer_ByObjectWithOnlyIfUnchangedTrue_SetsIfMatchHeader()
        {
            var indexer = CreateTestIndexer("my-indexer");
            indexer.ETag = new Azure.ETag("indexer-etag");
            var mockTransport = new MockTransport(CreateDeleteResponse());
            var client = CreateMockClient(mockTransport);

            await client.DeleteIndexerAsync(indexer, onlyIfUnchanged: true);

            var request = mockTransport.Requests[0];
            AssertIfMatchHeader(request, "indexer-etag");
        }

        [Test]
        public async Task DeleteIndexer_ByObjectWithOnlyIfUnchangedFalse_NoIfMatchHeader()
        {
            var indexer = CreateTestIndexer("my-indexer");
            indexer.ETag = new Azure.ETag("indexer-etag");
            var mockTransport = new MockTransport(CreateDeleteResponse());
            var client = CreateMockClient(mockTransport);

            await client.DeleteIndexerAsync(indexer, onlyIfUnchanged: false);

            var request = mockTransport.Requests[0];
            AssertNoIfMatchHeader(request);
        }

        #endregion

        #region GetIndexers Overload Tests

        [Test]
        public async Task GetIndexers_RoutesCorrectly()
        {
            var mockTransport = new MockTransport(CreateListIndexersResponse());
            var client = CreateMockClient(mockTransport);

            await client.GetIndexersAsync();

            var request = mockTransport.Requests[0];
            AssertRequestMethod(request, "GET");
            AssertRequestPath(request, "/indexers");
            AssertQueryParameter(request, "$select", "*");
        }

        [Test]
        public async Task GetIndexers_WithCancellationToken_RoutesCorrectly()
        {
            var mockTransport = new MockTransport(CreateListIndexersResponse());
            var client = CreateMockClient(mockTransport);

            await client.GetIndexersAsync(CancellationToken.None);

            var request = mockTransport.Requests[0];
            AssertRequestMethod(request, "GET");
            AssertRequestPath(request, "/indexers");
            AssertQueryParameter(request, "$select", "*");
        }

        [Test]
        public async Task GetIndexerNames_RoutesCorrectly()
        {
            var mockTransport = new MockTransport(CreateListIndexersResponse());
            var client = CreateMockClient(mockTransport);

            await client.GetIndexerNamesAsync();

            var request = mockTransport.Requests[0];
            AssertRequestMethod(request, "GET");
            AssertRequestPath(request, "/indexers");
            AssertQueryParameter(request, "$select", "name");
        }

        [Test]
        public async Task GetIndexerNames_WithCancellationToken_RoutesCorrectly()
        {
            var mockTransport = new MockTransport(CreateListIndexersResponse());
            var client = CreateMockClient(mockTransport);

            await client.GetIndexerNamesAsync(CancellationToken.None);

            var request = mockTransport.Requests[0];
            AssertRequestMethod(request, "GET");
            AssertRequestPath(request, "/indexers");
            AssertQueryParameter(request, "$select", "name");
        }

        #endregion

        #endregion

        #region DataSource Operations

        #region CreateOrUpdateDataSourceConnection Overload Tests

        [Test]
        public async Task CreateOrUpdateDataSourceConnection_MinimalOverload_RoutesCorrectly()
        {
            var dataSource = CreateTestDataSource();
            var mockTransport = new MockTransport(CreateDataSourceResponse(dataSource.Name));
            var client = CreateMockClient(mockTransport);

            await client.CreateOrUpdateDataSourceConnectionAsync(dataSource);

            var request = mockTransport.Requests[0];
            AssertRequestMethod(request, "PUT");
            AssertRequestPath(request, $"/datasources('{dataSource.Name}')");
            AssertQueryParameterAbsent(request, "ignoreCacheResetRequirements");
        }

        [Test]
        public async Task CreateOrUpdateDataSourceConnection_WithOnlyIfUnchanged_SetsIfMatchHeader()
        {
            var dataSource = CreateTestDataSource();
            dataSource.ETag = new Azure.ETag("datasource-etag");
            var mockTransport = new MockTransport(CreateDataSourceResponse(dataSource.Name));
            var client = CreateMockClient(mockTransport);

            await client.CreateOrUpdateDataSourceConnectionAsync(dataSource, onlyIfUnchanged: true);

            var request = mockTransport.Requests[0];
            AssertRequestMethod(request, "PUT");
            AssertIfMatchHeader(request, "datasource-etag");
        }

        [Test]
        public async Task CreateOrUpdateDataSourceConnection_WithOnlyIfUnchangedFalse_NoIfMatchHeader()
        {
            var dataSource = CreateTestDataSource();
            dataSource.ETag = new Azure.ETag("datasource-etag");
            var mockTransport = new MockTransport(CreateDataSourceResponse(dataSource.Name));
            var client = CreateMockClient(mockTransport);

            await client.CreateOrUpdateDataSourceConnectionAsync(dataSource, onlyIfUnchanged: false);

            var request = mockTransport.Requests[0];
            AssertNoIfMatchHeader(request);
        }

        [Test]
        public async Task CreateOrUpdateDataSourceConnection_LegacyOverload_RoutesCorrectly()
        {
            var dataSource = CreateTestDataSource();
            var mockTransport = new MockTransport(CreateDataSourceResponse(dataSource.Name));
            var client = CreateMockClient(mockTransport);

            await client.CreateOrUpdateDataSourceConnectionAsync(dataSource, onlyIfUnchanged: false, CancellationToken.None);

            var request = mockTransport.Requests[0];
            AssertRequestMethod(request, "PUT");
            AssertRequestPath(request, $"/datasources('{dataSource.Name}')");
            AssertQueryParameterAbsent(request, "ignoreCacheResetRequirements");
        }

        [Test]
        public async Task CreateOrUpdateDataSourceConnection_WithIgnoreCacheResetRequirementsTrue_RoutesCorrectly()
        {
            var dataSource = CreateTestDataSource();
            var mockTransport = new MockTransport(CreateDataSourceResponse(dataSource.Name));
            var client = CreateMockClient(mockTransport);

            await client.CreateOrUpdateDataSourceConnectionAsync(
                dataSource,
                onlyIfUnchanged: false,
                ignoreCacheResetRequirements: true);

            var request = mockTransport.Requests[0];
            AssertRequestMethod(request, "PUT");
            AssertQueryParameter(request, "ignoreCacheResetRequirements", "true");
        }

        [Test]
        public async Task CreateOrUpdateDataSourceConnection_WithIgnoreCacheResetRequirementsFalse_RoutesCorrectly()
        {
            var dataSource = CreateTestDataSource();
            var mockTransport = new MockTransport(CreateDataSourceResponse(dataSource.Name));
            var client = CreateMockClient(mockTransport);

            await client.CreateOrUpdateDataSourceConnectionAsync(
                dataSource,
                onlyIfUnchanged: false,
                ignoreCacheResetRequirements: false);

            var request = mockTransport.Requests[0];
            AssertRequestMethod(request, "PUT");
            AssertQueryParameter(request, "ignoreCacheResetRequirements", "false");
        }

        [Test]
        public async Task CreateOrUpdateDataSourceConnection_WithIgnoreCacheResetRequirementsNull_RoutesCorrectly()
        {
            var dataSource = CreateTestDataSource();
            var mockTransport = new MockTransport(CreateDataSourceResponse(dataSource.Name));
            var client = CreateMockClient(mockTransport);

            await client.CreateOrUpdateDataSourceConnectionAsync(
                dataSource,
                onlyIfUnchanged: false,
                ignoreCacheResetRequirements: null);

            var request = mockTransport.Requests[0];
            AssertRequestMethod(request, "PUT");
            AssertQueryParameterAbsent(request, "ignoreCacheResetRequirements");
        }

        #endregion

        #region DeleteDataSourceConnection Overload Tests

        [Test]
        public async Task DeleteDataSourceConnection_ByName_RoutesCorrectly()
        {
            var mockTransport = new MockTransport(CreateDeleteResponse());
            var client = CreateMockClient(mockTransport);

            await client.DeleteDataSourceConnectionAsync("my-datasource");

            var request = mockTransport.Requests[0];
            AssertRequestMethod(request, "DELETE");
            AssertRequestPath(request, "/datasources('my-datasource')");
        }

        [Test]
        public async Task DeleteDataSourceConnection_ByNameWithCancellationToken_RoutesCorrectly()
        {
            var mockTransport = new MockTransport(CreateDeleteResponse());
            var client = CreateMockClient(mockTransport);

            await client.DeleteDataSourceConnectionAsync("my-datasource", CancellationToken.None);

            var request = mockTransport.Requests[0];
            AssertRequestMethod(request, "DELETE");
            AssertRequestPath(request, "/datasources('my-datasource')");
        }

        [Test]
        public async Task DeleteDataSourceConnection_ByObject_RoutesCorrectly()
        {
            var dataSource = CreateTestDataSource("my-datasource");
            var mockTransport = new MockTransport(CreateDeleteResponse());
            var client = CreateMockClient(mockTransport);

            await client.DeleteDataSourceConnectionAsync(dataSource);

            var request = mockTransport.Requests[0];
            AssertRequestMethod(request, "DELETE");
            AssertRequestPath(request, "/datasources('my-datasource')");
            AssertNoIfMatchHeader(request);
        }

        [Test]
        public async Task DeleteDataSourceConnection_ByObjectWithOnlyIfUnchangedTrue_SetsIfMatchHeader()
        {
            var dataSource = CreateTestDataSource("my-datasource");
            dataSource.ETag = new Azure.ETag("datasource-etag");
            var mockTransport = new MockTransport(CreateDeleteResponse());
            var client = CreateMockClient(mockTransport);

            await client.DeleteDataSourceConnectionAsync(dataSource, onlyIfUnchanged: true);

            var request = mockTransport.Requests[0];
            AssertIfMatchHeader(request, "datasource-etag");
        }

        [Test]
        public async Task DeleteDataSourceConnection_ByObjectWithOnlyIfUnchangedFalse_NoIfMatchHeader()
        {
            var dataSource = CreateTestDataSource("my-datasource");
            dataSource.ETag = new Azure.ETag("datasource-etag");
            var mockTransport = new MockTransport(CreateDeleteResponse());
            var client = CreateMockClient(mockTransport);

            await client.DeleteDataSourceConnectionAsync(dataSource, onlyIfUnchanged: false);

            var request = mockTransport.Requests[0];
            AssertNoIfMatchHeader(request);
        }

        #endregion

        #region GetDataSourceConnections Overload Tests

        [Test]
        public async Task GetDataSourceConnections_RoutesCorrectly()
        {
            var mockTransport = new MockTransport(CreateListDataSourcesResponse());
            var client = CreateMockClient(mockTransport);

            await client.GetDataSourceConnectionsAsync();

            var request = mockTransport.Requests[0];
            AssertRequestMethod(request, "GET");
            AssertRequestPath(request, "/datasources");
            AssertQueryParameter(request, "$select", "*");
        }

        [Test]
        public async Task GetDataSourceConnections_WithCancellationToken_RoutesCorrectly()
        {
            var mockTransport = new MockTransport(CreateListDataSourcesResponse());
            var client = CreateMockClient(mockTransport);

            await client.GetDataSourceConnectionsAsync(CancellationToken.None);

            var request = mockTransport.Requests[0];
            AssertRequestMethod(request, "GET");
            AssertRequestPath(request, "/datasources");
            AssertQueryParameter(request, "$select", "*");
        }

        [Test]
        public async Task GetDataSourceConnectionNames_RoutesCorrectly()
        {
            var mockTransport = new MockTransport(CreateListDataSourcesResponse());
            var client = CreateMockClient(mockTransport);

            await client.GetDataSourceConnectionNamesAsync();

            var request = mockTransport.Requests[0];
            AssertRequestMethod(request, "GET");
            AssertRequestPath(request, "/datasources");
            AssertQueryParameter(request, "$select", "name");
        }

        [Test]
        public async Task GetDataSourceConnectionNames_WithCancellationToken_RoutesCorrectly()
        {
            var mockTransport = new MockTransport(CreateListDataSourcesResponse());
            var client = CreateMockClient(mockTransport);

            await client.GetDataSourceConnectionNamesAsync(CancellationToken.None);

            var request = mockTransport.Requests[0];
            AssertRequestMethod(request, "GET");
            AssertRequestPath(request, "/datasources");
            AssertQueryParameter(request, "$select", "name");
        }

        #endregion

        #endregion
    }
}
