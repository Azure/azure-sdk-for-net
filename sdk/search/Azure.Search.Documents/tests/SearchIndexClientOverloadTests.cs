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
//    /// Mock-based tests to verify all SearchIndexClient convenience overloads route parameters correctly.
//    /// Uses parameterized tests to minimize maintenance overhead.
//    /// </summary>
//    public class SearchIndexClientOverloadTests : ClientTestBase
//    {
//        private static readonly Uri s_endpoint = new("https://test-search.search.windows.net");
//        private static readonly AzureKeyCredential s_credential = new("fake-api-key");

//        public SearchIndexClientOverloadTests(bool isAsync) : base(isAsync) { }

//        private SearchIndexClient CreateMockClient(MockTransport transport) =>
//            InstrumentClient(new SearchIndexClient(s_endpoint, s_credential, new SearchClientOptions { Transport = transport }));

//        #region Index Operations

//        [Test]
//        public async Task CreateOrUpdateIndexAsync_RoutesToCorrectEndpoint()
//        {
//            var transport = new MockTransport(JsonResponse(200, @"{""name"":""idx"",""fields"":[]}"));
//            var client = CreateMockClient(transport);

//            await client.CreateOrUpdateIndexAsync(new SearchIndex("idx"));

//            Assert.AreEqual("PUT", transport.Requests[0].Method.Method);
//            StringAssert.Contains("/indexes('idx')", transport.Requests[0].Uri.Path);
//        }

//        [TestCase(true, "etag", true)]
//        [TestCase(false, "etag", false)]
//        public async Task CreateOrUpdateIndexAsync_OnlyIfUnchanged(bool onlyIfUnchanged, string etag, bool expectHeader)
//        {
//            var transport = new MockTransport(JsonResponse(200, @"{""name"":""idx"",""fields"":[]}"));
//            var client = CreateMockClient(transport);
//            var index = new SearchIndex("idx") { ETag = new ETag(etag) };

//            await client.CreateOrUpdateIndexAsync(index, onlyIfUnchanged: onlyIfUnchanged);

//            AssertIfMatchHeader(transport.Requests[0], expectHeader ? etag : null);
//        }

//        [TestCase(true, "true")]
//        [TestCase(false, "false")]
//        public async Task CreateOrUpdateIndexAsync_AllowIndexDowntime(bool allowDowntime, string expected)
//        {
//            var transport = new MockTransport(JsonResponse(200, @"{""name"":""idx"",""fields"":[]}"));
//            var client = CreateMockClient(transport);

//            await client.CreateOrUpdateIndexAsync(new SearchIndex("idx"), allowIndexDowntime: allowDowntime);

//            StringAssert.Contains($"allowIndexDowntime={expected}", transport.Requests[0].Uri.Query);
//        }

//        [Test]
//        public async Task DeleteIndexAsync_ByName_RoutesToCorrectEndpoint()
//        {
//            var transport = new MockTransport(new MockResponse(204));
//            var client = CreateMockClient(transport);

//            await client.DeleteIndexAsync("my-index", cancellationToken: CancellationToken.None);

//            Assert.AreEqual("DELETE", transport.Requests[0].Method.Method);
//            StringAssert.Contains("/indexes('my-index')", transport.Requests[0].Uri.Path);
//        }

//        [TestCase(true, "etag", true)]
//        [TestCase(false, "etag", false)]
//        public async Task DeleteIndexAsync_ByObject_OnlyIfUnchanged(bool onlyIfUnchanged, string etag, bool expectHeader)
//        {
//            var transport = new MockTransport(new MockResponse(204));
//            var client = CreateMockClient(transport);
//            var index = new SearchIndex("idx") { ETag = new ETag(etag) };

//            await client.DeleteIndexAsync(index, onlyIfUnchanged);

//            AssertIfMatchHeader(transport.Requests[0], expectHeader ? etag : null);
//        }

//        #endregion

//        #region SynonymMap Operations

//        [Test]
//        public async Task CreateOrUpdateSynonymMapAsync_RoutesToCorrectEndpoint()
//        {
//            var transport = new MockTransport(JsonResponse(200, @"{""name"":""sm"",""format"":""solr"",""synonyms"":""""}"));
//            var client = CreateMockClient(transport);

//            await client.CreateOrUpdateSynonymMapAsync(new SynonymMap("sm", "word1,word2"));

//            Assert.AreEqual("PUT", transport.Requests[0].Method.Method);
//            StringAssert.Contains("/synonymmaps('sm')", transport.Requests[0].Uri.Path);
//        }

//        [TestCase(true, "etag", true)]
//        [TestCase(false, "etag", false)]
//        public async Task CreateOrUpdateSynonymMapAsync_OnlyIfUnchanged(bool onlyIfUnchanged, string etag, bool expectHeader)
//        {
//            var transport = new MockTransport(JsonResponse(200, @"{""name"":""sm"",""format"":""solr"",""synonyms"":""""}"));
//            var client = CreateMockClient(transport);
//            var synonymMap = new SynonymMap("sm", "word1,word2") { ETag = new ETag(etag) };

//            await client.CreateOrUpdateSynonymMapAsync(synonymMap, onlyIfUnchanged);

//            AssertIfMatchHeader(transport.Requests[0], expectHeader ? etag : null);
//        }

//        [Test]
//        public async Task DeleteSynonymMapAsync_ByName_RoutesToCorrectEndpoint()
//        {
//            var transport = new MockTransport(new MockResponse(204));
//            var client = CreateMockClient(transport);

//            await client.DeleteSynonymMapAsync("my-synonymmap", cancellationToken: CancellationToken.None);

//            Assert.AreEqual("DELETE", transport.Requests[0].Method.Method);
//            StringAssert.Contains("/synonymmaps('my-synonymmap')", transport.Requests[0].Uri.Path);
//        }

//        [TestCase(true, "etag", true)]
//        [TestCase(false, "etag", false)]
//        public async Task DeleteSynonymMapAsync_ByObject_OnlyIfUnchanged(bool onlyIfUnchanged, string etag, bool expectHeader)
//        {
//            var transport = new MockTransport(new MockResponse(204));
//            var client = CreateMockClient(transport);
//            var synonymMap = new SynonymMap("sm", "word1,word2") { ETag = new ETag(etag) };

//            await client.DeleteSynonymMapAsync(synonymMap, onlyIfUnchanged);

//            AssertIfMatchHeader(transport.Requests[0], expectHeader ? etag : null);
//        }

//        [Test]
//        public async Task GetSynonymMapsAsync_RoutesToCorrectEndpoint()
//        {
//            var transport = new MockTransport(JsonResponse(200, @"{""value"":[]}"));
//            var client = CreateMockClient(transport);

//            await client.GetSynonymMapsAsync(cancellationToken: CancellationToken.None);

//            Assert.AreEqual("GET", transport.Requests[0].Method.Method);
//            StringAssert.Contains("/synonymmaps", transport.Requests[0].Uri.Path);
//        }

//        [Test]
//        public async Task GetSynonymMapNamesAsync_UsesSelectName()
//        {
//            var transport = new MockTransport(JsonResponse(200, @"{""value"":[]}"));
//            var client = CreateMockClient(transport);

//            await client.GetSynonymMapNamesAsync();

//            StringAssert.Contains("/synonymmaps", transport.Requests[0].Uri.Path);
//            StringAssert.Contains("$select=name", transport.Requests[0].Uri.Query);
//        }

//        #endregion

//        #region Alias Operations

//        [Test]
//        public async Task CreateOrUpdateAliasAsync_RoutesToCorrectEndpoint()
//        {
//            var transport = new MockTransport(JsonResponse(200, @"{""name"":""alias"",""indexes"":[""idx""]}"));
//            var client = CreateMockClient(transport);

//            await client.CreateOrUpdateAliasAsync(new SearchAlias("alias", "idx"));

//            Assert.AreEqual("PUT", transport.Requests[0].Method.Method);
//            StringAssert.Contains("/aliases('alias')", transport.Requests[0].Uri.Path);
//        }

//        [Test]
//        public async Task DeleteAliasAsync_RoutesToCorrectEndpoint()
//        {
//            var transport = new MockTransport(new MockResponse(204));
//            var client = CreateMockClient(transport);

//            await client.DeleteAliasAsync("my-alias");

//            Assert.AreEqual("DELETE", transport.Requests[0].Method.Method);
//            StringAssert.Contains("/aliases('my-alias')", transport.Requests[0].Uri.Path);
//        }

//        [Test]
//        public async Task GetAliasAsync_RoutesToCorrectEndpoint()
//        {
//            var transport = new MockTransport(JsonResponse(200, @"{""name"":""alias"",""indexes"":[""idx""]}"));
//            var client = CreateMockClient(transport);

//            await client.GetAliasAsync("my-alias");

//            Assert.AreEqual("GET", transport.Requests[0].Method.Method);
//            StringAssert.Contains("/aliases('my-alias')", transport.Requests[0].Uri.Path);
//        }

//        #endregion

//        #region KnowledgeBase Operations

//        [Test]
//        public async Task CreateKnowledgeBaseAsync_RoutesToCorrectEndpoint()
//        {
//           var transport = new MockTransport(JsonResponse(201, @"{""name"":""kb"",""knowledgeSources"":[]}"));
//            var client = CreateMockClient(transport);

//            await client.CreateKnowledgeBaseAsync(new KnowledgeBase("kb", new List<KnowledgeSourceReference>()));

//            Assert.AreEqual("POST", transport.Requests[0].Method.Method);
//            StringAssert.Contains("/knowledgebases", transport.Requests[0].Uri.Path);
//        }

//        [Test]
//        public async Task CreateOrUpdateKnowledgeBaseAsync_RoutesToCorrectEndpoint()
//        {
//            var transport = new MockTransport(JsonResponse(200, @"{""name"":""kb"",""knowledgeSources"":[]}"));
//            var client = CreateMockClient(transport);

//            await client.CreateOrUpdateKnowledgeBaseAsync(new KnowledgeBase("kb", new List<KnowledgeSourceReference>()));

//            Assert.AreEqual("PUT", transport.Requests[0].Method.Method);
//            StringAssert.Contains("/knowledgebases('kb')", transport.Requests[0].Uri.Path);
//        }

//        [TestCase(true, "etag", true)]
//        [TestCase(false, "etag", false)]
//        public async Task CreateOrUpdateKnowledgeBaseAsync_OnlyIfUnchanged(bool onlyIfUnchanged, string etag, bool expectHeader)
//        {
//            var transport = new MockTransport(JsonResponse(200, @"{""name"":""kb"",""knowledgeSources"":[]}"));
//            var client = CreateMockClient(transport);
//            var kb = new KnowledgeBase("kb", new List<KnowledgeSourceReference>()) { ETag = new ETag(etag) };

//            await client.CreateOrUpdateKnowledgeBaseAsync(kb, onlyIfUnchanged);

//            AssertIfMatchHeader(transport.Requests[0], expectHeader ? etag : null);
//        }

//        [Test]
//        public async Task DeleteKnowledgeBaseAsync_ByName_RoutesToCorrectEndpoint()
//        {
//            var transport = new MockTransport(new MockResponse(204));
//            var client = CreateMockClient(transport);

//            await client.DeleteKnowledgeBaseAsync("my-kb", cancellationToken: CancellationToken.None);

//            Assert.AreEqual("DELETE", transport.Requests[0].Method.Method);
//            StringAssert.Contains("/knowledgebases('my-kb')", transport.Requests[0].Uri.Path);
//        }

//        [TestCase(true, "etag", true)]
//        [TestCase(false, "etag", false)]
//        public async Task DeleteKnowledgeBaseAsync_ByObject_OnlyIfUnchanged(bool onlyIfUnchanged, string etag, bool expectHeader)
//        {
//            var transport = new MockTransport(new MockResponse(204));
//            var client = CreateMockClient(transport);
//            var kb = new KnowledgeBase("kb", new List<KnowledgeSourceReference>()) { ETag = new ETag(etag) };

//            await client.DeleteKnowledgeBaseAsync(kb, onlyIfUnchanged);

//            AssertIfMatchHeader(transport.Requests[0], expectHeader ? etag : null);
//        }

//        [Test]
//        public async Task GetKnowledgeBaseAsync_RoutesToCorrectEndpoint()
//        {
//            var transport = new MockTransport(JsonResponse(200, @"{""name"":""kb"",""knowledgeSources"":[]}"));
//            var client = CreateMockClient(transport);

//            await client.GetKnowledgeBaseAsync("my-kb");

//            Assert.AreEqual("GET", transport.Requests[0].Method.Method);
//            StringAssert.Contains("/knowledgebases('my-kb')", transport.Requests[0].Uri.Path);
//        }

//        #endregion

//        #region KnowledgeSource Operations

//        [Test]
//        public async Task CreateKnowledgeSourceAsync_RoutesToCorrectEndpoint()
//        {
//            var transport = new MockTransport(JsonResponse(201, @"{""name"":""ks"",""kind"":""searchIndex"",""searchIndexParameters"":{""searchIndexName"":""idx""}}"));
//            var client = CreateMockClient(transport);

//            await client.CreateKnowledgeSourceAsync(new SearchIndexKnowledgeSource("ks", new SearchIndexKnowledgeSourceParameters("idx")));

//            Assert.AreEqual("POST", transport.Requests[0].Method.Method);
//            StringAssert.Contains("/knowledgesources", transport.Requests[0].Uri.Path);
//        }

//        [Test]
//        public async Task CreateOrUpdateKnowledgeSourceAsync_RoutesToCorrectEndpoint()
//        {
//            var transport = new MockTransport(JsonResponse(200, @"{""name"":""ks"",""kind"":""searchIndex"",""searchIndexParameters"":{""searchIndexName"":""idx""}}"));
//            var client = CreateMockClient(transport);

//            await client.CreateOrUpdateKnowledgeSourceAsync(new SearchIndexKnowledgeSource("ks", new SearchIndexKnowledgeSourceParameters("idx")));

//            Assert.AreEqual("PUT", transport.Requests[0].Method.Method);
//            StringAssert.Contains("/knowledgesources('ks')", transport.Requests[0].Uri.Path);
//        }

//        [TestCase(true, "etag", true)]
//        [TestCase(false, "etag", false)]
//        public async Task CreateOrUpdateKnowledgeSourceAsync_OnlyIfUnchanged(bool onlyIfUnchanged, string etag, bool expectHeader)
//        {
//            var transport = new MockTransport(JsonResponse(200, @"{""name"":""ks"",""kind"":""searchIndex"",""searchIndexParameters"":{""searchIndexName"":""idx""}}"));
//            var client = CreateMockClient(transport);
//            var ks = new SearchIndexKnowledgeSource("ks", new SearchIndexKnowledgeSourceParameters("idx")) { ETag = new ETag(etag) };

//            await client.CreateOrUpdateKnowledgeSourceAsync(ks, onlyIfUnchanged);

//            AssertIfMatchHeader(transport.Requests[0], expectHeader ? etag : null);
//        }

//        [Test]
//        public async Task DeleteKnowledgeSourceAsync_ByName_RoutesToCorrectEndpoint()
//        {
//            var transport = new MockTransport(new MockResponse(204));
//            var client = CreateMockClient(transport);

//            await client.DeleteKnowledgeSourceAsync("my-ks", cancellationToken: CancellationToken.None);

//            Assert.AreEqual("DELETE", transport.Requests[0].Method.Method);
//            StringAssert.Contains("/knowledgesources('my-ks')", transport.Requests[0].Uri.Path);
//        }

//        [TestCase(true, "etag", true)]
//        [TestCase(false, "etag", false)]
//        public async Task DeleteKnowledgeSourceAsync_ByObject_OnlyIfUnchanged(bool onlyIfUnchanged, string etag, bool expectHeader)
//        {
//            var transport = new MockTransport(new MockResponse(204));
//            var client = CreateMockClient(transport);
//            var ks = new SearchIndexKnowledgeSource("ks", new SearchIndexKnowledgeSourceParameters("idx")) { ETag = new ETag(etag) };

//            await client.DeleteKnowledgeSourceAsync(ks, onlyIfUnchanged);

//            AssertIfMatchHeader(transport.Requests[0], expectHeader ? etag : null);
//        }

//        [Test]
//        public async Task GetKnowledgeSourceAsync_RoutesToCorrectEndpoint()
//        {
//            var transport = new MockTransport(JsonResponse(200, @"{""name"":""ks"",""kind"":""searchIndex"",""searchIndexParameters"":{""searchIndexName"":""idx""}}"));
//            var client = CreateMockClient(transport);

//            await client.GetKnowledgeSourceAsync("my-ks");

//            Assert.AreEqual("GET", transport.Requests[0].Method.Method);
//            StringAssert.Contains("/knowledgesources('my-ks')", transport.Requests[0].Uri.Path);
//        }

//        #endregion

//        #region AnalyzeText Operations

//        [Test]
//        public async Task AnalyzeTextAsync_RoutesToCorrectEndpoint()
//        {
//            var transport = new MockTransport(JsonResponse(200, @"{""tokens"":[]}"));
//            var client = CreateMockClient(transport);

//            await client.AnalyzeTextAsync("my-index", new AnalyzeTextOptions("hello world", LexicalAnalyzerName.StandardLucene));

//            Assert.AreEqual("POST", transport.Requests[0].Method.Method);
//            StringAssert.Contains("/indexes('my-index')/search.analyze", transport.Requests[0].Uri.Path);
//        }

//        #endregion

//        #region Helpers

//        private static MockResponse JsonResponse(int status, string json)
//        {
//            var response = new MockResponse(status);
//           response.AddHeader("Content-Type", "application/json");
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

//        #endregion
//    }
//}
