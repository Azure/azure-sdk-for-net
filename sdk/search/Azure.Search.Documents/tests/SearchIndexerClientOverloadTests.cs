// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

//using System;
//using System.Collections.Generic;
//using System.Threading;
//using System.Threading.Tasks;
//using Azure.Core.TestFramework;
//using Azure.Search.Documents.Indexes;
//using Azure.Search.Documents.Indexes.Models;
//using NUnit.Framework;

//namespace Azure.Search.Documents.Tests
//{
//    /// <summary>
//    /// Mock-based tests to verify all SearchIndexerClient convenience overloads route parameters correctly.
//    /// Uses parameterized tests to minimize maintenance overhead.
//    /// </summary>
//    public class SearchIndexerClientOverloadTests : ClientTestBase
//    {
//        private static readonly Uri s_endpoint = new("https://test-search.search.windows.net");
//        private static readonly AzureKeyCredential s_credential = new("fake-api-key");

//        public SearchIndexerClientOverloadTests(bool isAsync) : base(isAsync) { }

//        private SearchIndexerClient CreateMockClient(MockTransport transport) =>
//            InstrumentClient(new SearchIndexerClient(s_endpoint, s_credential, new SearchClientOptions { Transport = transport }));

//        #region Skillset Operations

//        [Test]
//        public async Task CreateOrUpdateSkillsetAsync_RoutesToCorrectEndpoint()
//        {
//            var transport = new MockTransport(JsonResponse(200, @"{""name"":""s"",""skills"":[]}"));
//            var client = CreateMockClient(transport);

//            await client.CreateOrUpdateSkillsetAsync(new SearchIndexerSkillset("s", new List<SearchIndexerSkill>()));

//            Assert.AreEqual("PUT", transport.Requests[0].Method.Method);
//            StringAssert.Contains("/skillsets('s')", transport.Requests[0].Uri.Path);
//        }

//        [TestCase(true, "etag-value", true, Description = "onlyIfUnchanged=true sets If-Match header")]
//        [TestCase(false, "etag-value", false, Description = "onlyIfUnchanged=false omits If-Match header")]
//        public async Task CreateOrUpdateSkillsetAsync_OnlyIfUnchanged_SetsIfMatchHeader(bool onlyIfUnchanged, string etag, bool expectHeader)
//        {
//            var transport = new MockTransport(JsonResponse(200, @"{""name"":""s"",""skills"":[]}"));
//            var client = CreateMockClient(transport);
//            var skillset = new SearchIndexerSkillset("s", new List<SearchIndexerSkill>()) { ETag = new ETag(etag) };

//            await client.CreateOrUpdateSkillsetAsync(skillset, onlyIfUnchanged);

//            AssertIfMatchHeader(transport.Requests[0], expectHeader ? etag : null);
//        }

//        [TestCase(true, true, "true", "true")]
//        [TestCase(false, false, "false", "false")]
//        [TestCase(null, null, null, null)]
//       public async Task CreateOrUpdateSkillsetAsync_CacheParameters_RouteCorrectly(bool? ignoreCache, bool? disableCache, string expectedIgnore, string expectedDisable)
//        {
//            var transport = new MockTransport(JsonResponse(200, @"{""name"":""s"",""skills"":[]}"));
//            var client = CreateMockClient(transport);

//            await client.CreateOrUpdateSkillsetAsync(
//                new SearchIndexerSkillset("s", new List<SearchIndexerSkill>()),
//                onlyIfUnchanged: false,
//                ignoreCacheResetRequirements: ignoreCache,
//                disableCacheReprocessingChangeDetection: disableCache);

//            AssertQueryParam(transport.Requests[0], "ignoreResetRequirements", expectedIgnore);
//            AssertQueryParam(transport.Requests[0], "disableCacheReprocessingChangeDetection", expectedDisable);
//        }

//        [Test]
//        public async Task DeleteSkillsetAsync_ByName_RoutesToCorrectEndpoint()
//        {
//            var transport = new MockTransport(new MockResponse(204));
//            var client = CreateMockClient(transport);

//            await client.DeleteSkillsetAsync("my-skillset", cancellationToken: CancellationToken.None);

//            Assert.AreEqual("DELETE", transport.Requests[0].Method.Method);
//            StringAssert.Contains("/skillsets('my-skillset')", transport.Requests[0].Uri.Path);
//        }

//        [TestCase(true, "etag", true)]
//        [TestCase(false, "etag", false)]
//        public async Task DeleteSkillsetAsync_ByObject_OnlyIfUnchanged(bool onlyIfUnchanged, string etag, bool expectHeader)
//        {
//            var transport = new MockTransport(new MockResponse(204));
//            var client = CreateMockClient(transport);
//            var skillset = new SearchIndexerSkillset("s", new List<SearchIndexerSkill>()) { ETag = new ETag(etag) };

//            await client.DeleteSkillsetAsync(skillset, onlyIfUnchanged);

//            AssertIfMatchHeader(transport.Requests[0], expectHeader ? etag : null);
//        }

//        [TestCase("*", "%2A", Description = "GetSkillsetsAsync uses $select=*")]
//        [TestCase("name", "name", Description = "GetSkillsetNamesAsync uses $select=name")]
//        public async Task GetSkillsets_SelectParameter(string selectValue, string expectedEncoded)
//        {
//            var transport = new MockTransport(JsonResponse(200, @"{""value"":[]}"));
//            var client = CreateMockClient(transport);

//            if (selectValue == "*")
//                await client.GetSkillsetsAsync(cancellationToken: CancellationToken.None);
//            else
//                await client.GetSkillsetNamesAsync();

//            StringAssert.Contains("/skillsets", transport.Requests[0].Uri.Path);
//            StringAssert.Contains($"$select={expectedEncoded}", transport.Requests[0].Uri.Query);
//        }

//        #endregion

//        #region Indexer Operations

//        [Test]
//        public async Task CreateOrUpdateIndexerAsync_RoutesToCorrectEndpoint()
//        {
//            var transport = new MockTransport(JsonResponse(200, @"{""name"":""i"",""dataSourceName"":""ds"",""targetIndexName"":""idx""}"));
//            var client = CreateMockClient(transport);

//            await client.CreateOrUpdateIndexerAsync(new SearchIndexer("i", "ds", "idx"));

//            Assert.AreEqual("PUT", transport.Requests[0].Method.Method);
//            StringAssert.Contains("/indexers('i')", transport.Requests[0].Uri.Path);
//        }

//        [TestCase(true, "etag", true)]
//        [TestCase(false, "etag", false)]
//        public async Task CreateOrUpdateIndexerAsync_OnlyIfUnchanged(bool onlyIfUnchanged, string etag, bool expectHeader)
//        {
//            var transport = new MockTransport(JsonResponse(200, @"{""name"":""i"",""dataSourceName"":""ds"",""targetIndexName"":""idx""}"));
//            var client = CreateMockClient(transport);
//            var indexer = new SearchIndexer("i", "ds", "idx") { ETag = new ETag(etag) };

//            await client.CreateOrUpdateIndexerAsync(indexer, onlyIfUnchanged, cancellationToken: CancellationToken.None);

//            AssertIfMatchHeader(transport.Requests[0], expectHeader ? etag : null);
//        }

//        [TestCase(true, true, "true", "true")]
//        [TestCase(false, false, "false", "false")]
//        [TestCase(null, null, null, null)]
//        public async Task CreateOrUpdateIndexerAsync_CacheParameters(bool? ignoreCache, bool? disableCache, string expectedIgnore, string expectedDisable)
//        {
//            var transport = new MockTransport(JsonResponse(200, @"{""name"":""i"",""dataSourceName"":""ds"",""targetIndexName"":""idx""}"));
//            var client = CreateMockClient(transport);

//            await client.CreateOrUpdateIndexerAsync(
//                new SearchIndexer("i", "ds", "idx"),
//                onlyIfUnchanged: false,
//                ignoreCacheResetRequirements: ignoreCache,
//                disableCacheReprocessingChangeDetection: disableCache);

//            AssertQueryParam(transport.Requests[0], "ignoreResetRequirements", expectedIgnore);
//            AssertQueryParam(transport.Requests[0], "disableCacheReprocessingChangeDetection", expectedDisable);
//        }

//        [Test]
//        public async Task DeleteIndexerAsync_ByName_RoutesToCorrectEndpoint()
//        {
//            var transport = new MockTransport(new MockResponse(204));
//            var client = CreateMockClient(transport);

//            await client.DeleteIndexerAsync("my-indexer", cancellationToken: CancellationToken.None);

//            Assert.AreEqual("DELETE", transport.Requests[0].Method.Method);
//            StringAssert.Contains("/indexers('my-indexer')", transport.Requests[0].Uri.Path);
//        }

//        [TestCase(true, "etag", true)]
//        [TestCase(false, "etag", false)]
//        public async Task DeleteIndexerAsync_ByObject_OnlyIfUnchanged(bool onlyIfUnchanged, string etag, bool expectHeader)
//        {
//            var transport = new MockTransport(new MockResponse(204));
//            var client = CreateMockClient(transport);
//            var indexer = new SearchIndexer("i", "ds", "idx") { ETag = new ETag(etag) };

//            await client.DeleteIndexerAsync(indexer, onlyIfUnchanged);

//            AssertIfMatchHeader(transport.Requests[0], expectHeader ? etag : null);
//        }

//        [TestCase("*", "%2A", Description = "GetIndexersAsync uses $select=*")]
//        [TestCase("name", "name", Description = "GetIndexerNamesAsync uses $select=name")]
//        public async Task GetIndexers_SelectParameter(string selectValue, string expectedEncoded)
//        {
//            var transport = new MockTransport(JsonResponse(200, @"{""value"":[]}"));
//            var client = CreateMockClient(transport);

//            if (selectValue == "*")
//                await client.GetIndexersAsync(cancellationToken: CancellationToken.None);
//            else
//                await client.GetIndexerNamesAsync();

//            StringAssert.Contains("/indexers", transport.Requests[0].Uri.Path);
//            StringAssert.Contains($"$select={expectedEncoded}", transport.Requests[0].Uri.Query);
//        }

//        #endregion

//        #region DataSource Operations

//        [Test]
//        public async Task CreateOrUpdateDataSourceConnectionAsync_RoutesToCorrectEndpoint()
//        {
//            var transport = new MockTransport(JsonResponse(200, @"{""name"":""ds"",""type"":""azureblob"",""credentials"":{},""container"":{""name"":""c""}}"));
//            var client = CreateMockClient(transport);

//            await client.CreateOrUpdateDataSourceConnectionAsync(
//                new SearchIndexerDataSourceConnection("ds", SearchIndexerDataSourceType.AzureBlob, "conn", new SearchIndexerDataContainer("c")));

//            Assert.AreEqual("PUT", transport.Requests[0].Method.Method);
//            StringAssert.Contains("/datasources('ds')", transport.Requests[0].Uri.Path);
//        }

//        [TestCase(true, "etag", true)]
//        [TestCase(false, "etag", false)]
//        public async Task CreateOrUpdateDataSourceConnectionAsync_OnlyIfUnchanged(bool onlyIfUnchanged, string etag, bool expectHeader)
//        {
//            var transport = new MockTransport(JsonResponse(200, @"{""name"":""ds"",""type"":""azureblob"",""credentials"":{},""container"":{""name"":""c""}}"));
//            var client = CreateMockClient(transport);
//            var ds = new SearchIndexerDataSourceConnection("ds", SearchIndexerDataSourceType.AzureBlob, "conn", new SearchIndexerDataContainer("c")) { ETag = new ETag(etag) };

//            await client.CreateOrUpdateDataSourceConnectionAsync(ds, onlyIfUnchanged);

//            AssertIfMatchHeader(transport.Requests[0], expectHeader ? etag : null);
//        }

//        [TestCase(true, "true")]
//        [TestCase(false, "false")]
//        [TestCase(null, null)]
//        public async Task CreateOrUpdateDataSourceConnectionAsync_IgnoreCacheResetRequirements(bool? ignoreCache, string expected)
//        {
//            var transport = new MockTransport(JsonResponse(200, @"{""name"":""ds"",""type"":""azureblob"",""credentials"":{},""container"":{""name"":""c""}}"));
//            var client = CreateMockClient(transport);

//            await client.CreateOrUpdateDataSourceConnectionAsync(
//                new SearchIndexerDataSourceConnection("ds", SearchIndexerDataSourceType.AzureBlob, "conn", new SearchIndexerDataContainer("c")),
//                onlyIfUnchanged: false,
//                ignoreCacheResetRequirements: ignoreCache);

//            AssertQueryParam(transport.Requests[0], "ignoreResetRequirements", expected);
//        }

//        [Test]
//        public async Task DeleteDataSourceConnectionAsync_ByName_RoutesToCorrectEndpoint()
//        {
//            var transport = new MockTransport(new MockResponse(204));
//            var client = CreateMockClient(transport);

//            await client.DeleteDataSourceConnectionAsync("my-ds", cancellationToken: CancellationToken.None);

//            Assert.AreEqual("DELETE", transport.Requests[0].Method.Method);
//            StringAssert.Contains("/datasources('my-ds')", transport.Requests[0].Uri.Path);
//        }

//        [TestCase(true, "etag", true)]
//        [TestCase(false, "etag", false)]
//        public async Task DeleteDataSourceConnectionAsync_ByObject_OnlyIfUnchanged(bool onlyIfUnchanged, string etag, bool expectHeader)
//        {
//            var transport = new MockTransport(new MockResponse(204));
//            var client = CreateMockClient(transport);
//            var ds = new SearchIndexerDataSourceConnection("ds", SearchIndexerDataSourceType.AzureBlob, "conn", new SearchIndexerDataContainer("c")) { ETag = new ETag(etag) };

//            await client.DeleteDataSourceConnectionAsync(ds, onlyIfUnchanged);

//            AssertIfMatchHeader(transport.Requests[0], expectHeader ? etag : null);
//        }

//        [TestCase("*", "%2A", Description = "GetDataSourceConnectionsAsync uses $select=*")]
//        [TestCase("name", "name", Description = "GetDataSourceConnectionNamesAsync uses $select=name")]
//        public async Task GetDataSourceConnections_SelectParameter(string selectValue, string expectedEncoded)
//        {
//            var transport = new MockTransport(JsonResponse(200, @"{""value"":[]}"));
//            var client = CreateMockClient(transport);

//            if (selectValue == "*")
//                await client.GetDataSourceConnectionsAsync(cancellationToken: CancellationToken.None);
//            else
//                await client.GetDataSourceConnectionNamesAsync();

//            StringAssert.Contains("/datasources", transport.Requests[0].Uri.Path);
//            StringAssert.Contains($"$select={expectedEncoded}", transport.Requests[0].Uri.Query);
//        }

//        #endregion

//        #region Helpers

//        private static MockResponse JsonResponse(int status, string json)
//        {
//            var response = new MockResponse(status);
//            response.SetContent(json);
//            return response;
//        }

//        private static void AssertIfMatchHeader(MockRequest request, string expectedValue)
//        {
//            bool hasHeader = request.Headers.TryGetValue("If-Match", out var actual);
//            if (expectedValue == null)
//                Assert.IsFalse(hasHeader, "If-Match header should not be present");
//            else
//            {
//                Assert.IsTrue(hasHeader, "If-Match header should be present");
//                Assert.AreEqual($"\"{expectedValue}\"", actual);
//            }
//        }

//        private static void AssertQueryParam(MockRequest request, string param, string expectedValue)
//        {
//            var query = request.Uri.Query;
//            if (expectedValue == null)
//                Assert.IsFalse(query.Contains($"{param}="), $"Query should not contain {param}");
//            else
//                StringAssert.Contains($"{param}={expectedValue}", query);
//        }

//        #endregion
//    }
//}
