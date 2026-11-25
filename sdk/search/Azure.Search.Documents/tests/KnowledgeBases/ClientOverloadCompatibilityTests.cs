// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.Net.ServerSentEvents;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Search.Documents.Indexes;
using Azure.Search.Documents.Indexes.Models;
using Azure.Search.Documents.KnowledgeBases;
using Azure.Search.Documents.KnowledgeBases.Models;
using NUnit.Framework;

namespace Azure.Search.Documents.Tests
{
    public class ClientOverloadCompatibilityTests
    {
        [TestCase(false)]
        [TestCase(true)]
        public async Task OrdinaryCacheCallsReachGaOverrides(bool async)
        {
            SearchIndexerClient client = new GaIndexerClient();
            var indexer = new SearchIndexer("indexer", "source", "index");
            var source = new SearchIndexerDataSourceConnection("source", SearchIndexerDataSourceType.AzureBlob,
                "connection", new SearchIndexerDataContainer("container"));
            var skillset = new SearchIndexerSkillset("skills", Array.Empty<SearchIndexerSkill>());
            using var cancellation = new CancellationTokenSource();
            if (async)
            {
                Assert.AreSame(indexer, (await client.CreateOrUpdateIndexerAsync(indexer)).Value);
                Assert.AreSame(source, (await client.CreateOrUpdateDataSourceConnectionAsync(source)).Value);
                Assert.AreSame(skillset, (await client.CreateOrUpdateSkillsetAsync(skillset)).Value);
                Assert.AreSame(indexer, (await client.CreateOrUpdateIndexerAsync(indexer, true, cancellation.Token)).Value);
                Assert.AreSame(source, (await client.CreateOrUpdateDataSourceConnectionAsync(source, true, default)).Value);
                Assert.AreSame(skillset, (await client.CreateOrUpdateSkillsetAsync(skillset, cancellationToken: cancellation.Token)).Value);
            }
            else
            {
                Assert.AreSame(indexer, client.CreateOrUpdateIndexer(indexer).Value);
                Assert.AreSame(source, client.CreateOrUpdateDataSourceConnection(source).Value);
                Assert.AreSame(skillset, client.CreateOrUpdateSkillset(skillset).Value);
                Assert.AreSame(indexer, client.CreateOrUpdateIndexer(indexer, true, cancellation.Token).Value);
                Assert.AreSame(source, client.CreateOrUpdateDataSourceConnection(source, true, default).Value);
                Assert.AreSame(skillset, client.CreateOrUpdateSkillset(skillset, cancellationToken: cancellation.Token).Value);
            }
        }

        [TestCase(false)]
        [TestCase(true)]
        public async Task OrdinaryRetrieveCallsReachGaTypedOverrides(bool async)
        {
            var response = new KnowledgeBaseRetrievalResponse();
            KnowledgeBaseRetrievalClient client = new GaTypedRetrievalClient(response);
            var request = new KnowledgeBaseRetrievalRequest();
            using var cancellation = new CancellationTokenSource();
            if (async)
            {
                Assert.AreSame(response, (await client.RetrieveAsync(request)).Value);
                Assert.AreSame(response, (await client.RetrieveAsync(request, cancellation.Token)).Value);
                Assert.AreSame(response, (await client.RetrieveAsync(request, "user", cancellation.Token)).Value);
                Assert.AreSame(response, (await client.RetrieveAsync(request, "user", default)).Value);
                Assert.AreSame(response, (await client.RetrieveAsync(request, "user", queryWorkIQSourceAuthorization: null, cancellationToken: default)).Value);
            }
            else
            {
                Assert.AreSame(response, client.Retrieve(request).Value);
                Assert.AreSame(response, client.Retrieve(request, cancellation.Token).Value);
                Assert.AreSame(response, client.Retrieve(request, "user", cancellation.Token).Value);
                Assert.AreSame(response, client.Retrieve(request, "user", default).Value);
                Assert.AreSame(response, client.Retrieve(request, "user", queryWorkIQSourceAuthorization: null, cancellationToken: default).Value);
            }
        }

        [TestCase(false)]
        [TestCase(true)]
        public async Task GaTypedRetrievalForwardsThroughGaProtocolOverride(bool async)
        {
            var client = new GaProtocolRetrievalClient();
            var request = new KnowledgeBaseRetrievalRequest();
            using var cancellation = new CancellationTokenSource();
            using RequestContent content = RequestContent.Create(new { });
            if (async)
            {
                await client.RetrieveAsync(request, "user", cancellation.Token);
                await client.RetrieveAsync(content, new RequestContext { CancellationToken = cancellation.Token });
            }
            else
            {
                client.Retrieve(request, "user", cancellation.Token);
                client.Retrieve(content, new RequestContext { CancellationToken = cancellation.Token });
            }
            Assert.AreEqual(2, client.Calls);
            Assert.AreEqual(cancellation.Token, client.LastCancellationToken);
        }

        [Test]
        public void GaTypedStreamingForwardsThroughGaProtocolOverride()
        {
            KnowledgeBaseRetrievalClient client = new GaProtocolRetrievalClient();
            Assert.ThrowsAsync<GaStreamOverrideException>(async () =>
            {
                await foreach (var item in client.RetrieveStreamAsync(new KnowledgeBaseRetrievalRequest()))
                {
                    Assert.Fail("The GA protocol override must run before yielding.");
                }
            });
        }

        private sealed class GaIndexerClient : SearchIndexerClient
        {
            public override Response<SearchIndexer> CreateOrUpdateIndexer(SearchIndexer indexer, bool onlyIfUnchanged, CancellationToken cancellationToken) =>
                Response.FromValue(indexer, new MockResponse(200));
            public override Task<Response<SearchIndexer>> CreateOrUpdateIndexerAsync(SearchIndexer indexer, bool onlyIfUnchanged, CancellationToken cancellationToken) =>
                Task.FromResult(CreateOrUpdateIndexer(indexer, onlyIfUnchanged, cancellationToken));
            public override Response<SearchIndexerDataSourceConnection> CreateOrUpdateDataSourceConnection(SearchIndexerDataSourceConnection source, bool onlyIfUnchanged, CancellationToken cancellationToken) =>
                Response.FromValue(source, new MockResponse(200));
            public override Task<Response<SearchIndexerDataSourceConnection>> CreateOrUpdateDataSourceConnectionAsync(SearchIndexerDataSourceConnection source, bool onlyIfUnchanged, CancellationToken cancellationToken) =>
                Task.FromResult(CreateOrUpdateDataSourceConnection(source, onlyIfUnchanged, cancellationToken));
            public override Response<SearchIndexerSkillset> CreateOrUpdateSkillset(SearchIndexerSkillset skillset, bool onlyIfUnchanged, CancellationToken cancellationToken) =>
                Response.FromValue(skillset, new MockResponse(200));
            public override Task<Response<SearchIndexerSkillset>> CreateOrUpdateSkillsetAsync(SearchIndexerSkillset skillset, bool onlyIfUnchanged, CancellationToken cancellationToken) =>
                Task.FromResult(CreateOrUpdateSkillset(skillset, onlyIfUnchanged, cancellationToken));
        }

        private sealed class GaTypedRetrievalClient : KnowledgeBaseRetrievalClient
        {
            private readonly KnowledgeBaseRetrievalResponse _response;
            public GaTypedRetrievalClient(KnowledgeBaseRetrievalResponse response) => _response = response;
            public override Response<KnowledgeBaseRetrievalResponse> Retrieve(KnowledgeBaseRetrievalRequest request, string querySourceAuthorization, CancellationToken cancellationToken) =>
                Response.FromValue(_response, new MockResponse(200));
            public override Task<Response<KnowledgeBaseRetrievalResponse>> RetrieveAsync(KnowledgeBaseRetrievalRequest request, string querySourceAuthorization, CancellationToken cancellationToken) =>
                Task.FromResult(Retrieve(request, querySourceAuthorization, cancellationToken));
        }

        private sealed class GaProtocolRetrievalClient : KnowledgeBaseRetrievalClient
        {
            public int Calls { get; private set; }
            public CancellationToken LastCancellationToken { get; private set; }
            public override Response Retrieve(RequestContent content, string querySourceAuthorization, RequestContext context)
            {
                Calls++;
                LastCancellationToken = context.CancellationToken;
                return SearchTestHelpers.CreateMockJsonResponse(200, "{\"response\":[],\"references\":[],\"activity\":[]}");
            }
            public override Task<Response> RetrieveAsync(RequestContent content, string querySourceAuthorization, RequestContext context) =>
                Task.FromResult(Retrieve(content, querySourceAuthorization, context));
            public override Task<AsyncStreamingResult<SseItem<BinaryData>>> RetrieveStreamAsync(RequestContent content, string querySourceAuthorization, RequestContext context) =>
                throw new GaStreamOverrideException();
        }

        private sealed class GaStreamOverrideException : Exception { }
    }
}
