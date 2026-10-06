// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Search.Documents.Indexes;
using Azure.Search.Documents.Indexes.Models;
using NUnit.Framework;

namespace Azure.Search.Documents.Tests
{
    [TestFixture(false)]
    [TestFixture(true)]
    public class ListingPaginationTests
    {
        private static readonly Uri s_endpoint = new Uri("https://fake-search.search.windows.net");
        private static readonly string[] s_selectedPropertyResources = { "indexers", "datasources", "skillsets", "synonymmaps" };
        private static readonly string[] s_pagedResources =
        {
            "aliases", "indexes", "selected-indexes", "indexstats", "knowledgebases", "knowledgesources", "files",
            "indexers", "datasources", "skillsets", "synonymmaps"
        };
        private readonly bool _async;

        public ListingPaginationTests(bool isAsync)
        {
            _async = isAsync;
        }

        public static IEnumerable<TestCaseData> SelectedPropertyCases() => CreateCases(s_selectedPropertyResources);

        public static IEnumerable<TestCaseData> PagedCases() => CreateCases(s_pagedResources);

        private static IEnumerable<TestCaseData> CreateCases(IEnumerable<string> resources)
        {
            foreach (string resource in resources)
            {
                yield return new TestCaseData(resource, false);
                yield return new TestCaseData(resource, true);
            }
        }

        [TestCaseSource(nameof(SelectedPropertyCases))]
        public async Task SelectedPropertiesListingSendsControls(string resource, bool protocol)
        {
            var transport = new MockTransport(CreateResponse(resource));

            PageInfo page = await FirstPageAsync(transport, resource, protocol, pageSize: 2, search: "hotel + spa");

            Assert.AreEqual(1, page.Count);
            Assert.IsNull(page.ContinuationToken);
            Assert.AreEqual(1, transport.Requests.Count);
            Assert.AreEqual(ResourcePath(resource), transport.Requests.Single().Uri.ToUri().AbsolutePath);
            Dictionary<string, string> query = GetQuery(transport);
            Assert.AreEqual("name", query["$select"]);
            Assert.AreEqual("hotel + spa", query["search"]);
            Assert.AreEqual("2", query["pageSize"]);
            Assert.AreEqual("prefix", query["searchType"]);
        }

        [TestCaseSource(nameof(PagedCases))]
        public async Task PageSizeHintOverridesConfiguredSize(string resource, bool protocol)
        {
            var transport = new MockTransport(CreateResponse(resource));

            await FirstPageAsync(transport, resource, protocol, pageSize: 2, pageSizeHint: 4);

            Assert.AreEqual("4", GetQuery(transport)["pageSize"]);
        }

        [TestCaseSource(nameof(PagedCases))]
        public async Task ConfiguredSizeIsPreservedWithoutHint(string resource, bool protocol)
        {
            var transport = new MockTransport(CreateResponse(resource));

            await FirstPageAsync(transport, resource, protocol, pageSize: 2);

            Assert.AreEqual("2", GetQuery(transport)["pageSize"]);
        }

        [TestCaseSource(nameof(PagedCases))]
        public async Task DefaultListingDoesNotSendPageSize(string resource, bool protocol)
        {
            var transport = new MockTransport(CreateResponse(resource));

            await FirstPageAsync(transport, resource, protocol);

            Assert.IsFalse(GetQuery(transport).ContainsKey("pageSize"));
        }

        [TestCaseSource(nameof(PagedCases))]
        public async Task ServiceContinuationIsExposedAndResumable(string resource, bool protocol)
        {
            string nextLink = new Uri(s_endpoint,
                ResourcePath(resource) + "?cursor=opaque%2Btoken&pageSize=4&search=from-service&api-version=2026-10-01").AbsoluteUri;
            var firstTransport = new MockTransport(CreateResponse(resource, nextLink));

            PageInfo firstPage = await FirstPageAsync(firstTransport, resource, protocol, pageSize: 2, pageSizeHint: 4);

            Assert.AreEqual(nextLink, firstPage.ContinuationToken);
            Assert.AreEqual("4", GetQuery(firstTransport)["pageSize"]);

            var resumedTransport = new MockTransport(CreateResponse(resource));
            PageInfo resumedPage = await FirstPageAsync(resumedTransport, resource, protocol,
                continuationToken: firstPage.ContinuationToken, pageSize: 2, pageSizeHint: 7, search: "request-search");

            Assert.AreEqual(1, resumedPage.Count);
            Assert.IsNull(resumedPage.ContinuationToken);
            Assert.AreEqual(1, resumedTransport.Requests.Count);
            Dictionary<string, string> resumedQuery = GetQuery(resumedTransport);
            Assert.AreEqual("opaque+token", resumedQuery["cursor"]);
            Assert.AreEqual("7", resumedQuery["pageSize"]);
            Assert.AreEqual("from-service", resumedQuery["search"]);
        }

        [TestCaseSource(nameof(SelectedPropertyCases))]
        public async Task SelectedPropertiesListingFollowsServiceContinuation(string resource, bool protocol)
        {
            string nextLink = new Uri(s_endpoint, ResourcePath(resource) + "?cursor=next&pageSize=4").AbsoluteUri;
            var transport = new MockTransport(CreateResponse(resource, nextLink), CreateResponse(resource));
            int count = 0;

            await foreach (PageInfo page in GetPagesAsync(transport, resource, protocol, pageSize: 2, pageSizeHint: 4))
            {
                count += page.Count;
            }

            Assert.AreEqual(2, count);
            Assert.AreEqual(2, transport.Requests.Count);
            Assert.AreEqual("4", GetQuery(transport, 0)["pageSize"]);
            Assert.AreEqual("next", GetQuery(transport, 1)["cursor"]);
            Assert.AreEqual("4", GetQuery(transport, 1)["pageSize"]);
        }

        [TestCase("indexers")]
        [TestCase("datasources")]
        [TestCase("skillsets")]
        [TestCase("synonymmaps")]
        public async Task ExistingListMethodsStillBufferAllPages(string resource)
        {
            string nextLink = new Uri(s_endpoint, ResourcePath(resource) + "?cursor=next").AbsoluteUri;
            var transport = new MockTransport(CreateResponse(resource, nextLink), CreateResponse(resource));
            (SearchIndexClient indexes, SearchIndexerClient indexers) = CreateClients(transport);

            int count = resource switch
            {
                "indexers" => _async ? (await indexers.GetIndexersAsync(CancellationToken.None)).Value.Count : indexers.GetIndexers(CancellationToken.None).Value.Count,
                "datasources" => _async ? (await indexers.GetDataSourceConnectionsAsync(CancellationToken.None)).Value.Count : indexers.GetDataSourceConnections(CancellationToken.None).Value.Count,
                "skillsets" => _async ? (await indexers.GetSkillsetsAsync(CancellationToken.None)).Value.Count : indexers.GetSkillsets(CancellationToken.None).Value.Count,
                "synonymmaps" => _async ? (await indexes.GetSynonymMapsAsync(CancellationToken.None)).Value.Count : indexes.GetSynonymMaps(CancellationToken.None).Value.Count,
                _ => throw new ArgumentOutOfRangeException(nameof(resource), resource, "Unknown listing resource.")
            };

            Assert.AreEqual(2, count);
            Assert.AreEqual(2, transport.Requests.Count);
            Assert.IsFalse(GetQuery(transport, 0).ContainsKey("pageSize"));
        }

        [TestCase("indexers")]
        [TestCase("datasources")]
        [TestCase("skillsets")]
        [TestCase("synonymmaps")]
        public async Task ExistingParameterlessCallsStillBufferAllPages(string resource)
        {
            string nextLink = new Uri(s_endpoint, ResourcePath(resource) + "?cursor=next").AbsoluteUri;
            var transport = new MockTransport(CreateResponse(resource, nextLink), CreateResponse(resource));
            (SearchIndexClient indexes, SearchIndexerClient indexers) = CreateClients(transport);

            int count = resource switch
            {
                "indexers" => _async ? (await indexers.GetIndexersAsync()).Value.Count : indexers.GetIndexers().Value.Count,
                "datasources" => _async ? (await indexers.GetDataSourceConnectionsAsync()).Value.Count : indexers.GetDataSourceConnections().Value.Count,
                "skillsets" => _async ? (await indexers.GetSkillsetsAsync()).Value.Count : indexers.GetSkillsets().Value.Count,
                "synonymmaps" => _async ? (await indexes.GetSynonymMapsAsync()).Value.Count : indexes.GetSynonymMaps().Value.Count,
                _ => throw new ArgumentOutOfRangeException(nameof(resource), resource, "Unknown listing resource.")
            };

            Assert.AreEqual(2, count);
            Assert.AreEqual(2, transport.Requests.Count);
        }

        [TestCase("indexers")]
        [TestCase("datasources")]
        [TestCase("skillsets")]
        [TestCase("synonymmaps")]
        public async Task ExistingDefaultCallsStillBufferAllPages(string resource)
        {
            string nextLink = new Uri(s_endpoint, ResourcePath(resource) + "?cursor=next").AbsoluteUri;
            var transport = new MockTransport(CreateResponse(resource, nextLink), CreateResponse(resource));
            (SearchIndexClient indexes, SearchIndexerClient indexers) = CreateClients(transport);

            int count = resource switch
            {
                "indexers" => _async ? (await indexers.GetIndexersAsync(default)).Value.Count : indexers.GetIndexers(default).Value.Count,
                "datasources" => _async ? (await indexers.GetDataSourceConnectionsAsync(default)).Value.Count : indexers.GetDataSourceConnections(default).Value.Count,
                "skillsets" => _async ? (await indexers.GetSkillsetsAsync(default)).Value.Count : indexers.GetSkillsets(default).Value.Count,
                "synonymmaps" => _async ? (await indexes.GetSynonymMapsAsync(default)).Value.Count : indexes.GetSynonymMaps(default).Value.Count,
                _ => throw new ArgumentOutOfRangeException(nameof(resource), resource, "Unknown listing resource.")
            };

            Assert.AreEqual(2, count);
            Assert.AreEqual(2, transport.Requests.Count);
        }

        [TestCase("indexers")]
        [TestCase("datasources")]
        [TestCase("skillsets")]
        [TestCase("synonymmaps")]
        public async Task ExistingNameMethodsStillBufferAllPages(string resource)
        {
            string nextLink = new Uri(s_endpoint, ResourcePath(resource) + "?cursor=next").AbsoluteUri;
            var transport = new MockTransport(CreateResponse(resource, nextLink), CreateResponse(resource));
            (SearchIndexClient indexes, SearchIndexerClient indexers) = CreateClients(transport);

            IReadOnlyList<string> names = resource switch
            {
                "indexers" => _async ? (await indexers.GetIndexerNamesAsync()).Value : indexers.GetIndexerNames().Value,
                "datasources" => _async ? (await indexers.GetDataSourceConnectionNamesAsync()).Value : indexers.GetDataSourceConnectionNames().Value,
                "skillsets" => _async ? (await indexers.GetSkillsetNamesAsync()).Value : indexers.GetSkillsetNames().Value,
                "synonymmaps" => _async ? (await indexes.GetSynonymMapNamesAsync()).Value : indexes.GetSynonymMapNames().Value,
                _ => throw new ArgumentOutOfRangeException(nameof(resource), resource, "Unknown listing resource.")
            };

            Assert.AreEqual(new[] { "first", "first" }, names);
            Assert.AreEqual(2, transport.Requests.Count);
            Assert.AreEqual("name", GetQuery(transport)["$select"]);
        }

        [Test]
        public async Task PageableListingSample()
        {
            var transport = new MockTransport(CreateResponse("indexers"));
            (_, SearchIndexerClient indexerClient) = CreateClients(transport);
            int count = 0;

            #region Snippet:Azure_Search_Tests_Samples_ListIndexersWithSelectedProperties
            await foreach (Page<SearchIndexer> page in indexerClient.GetIndexersWithSelectedPropertiesAsync(
                select: new[] { "name" },
                search: "hotel",
                pageSize: 10,
                searchType: ListingSearchType.Prefix).AsPages())
            {
                foreach (SearchIndexer indexer in page.Values)
                {
                    Console.WriteLine(indexer.Name);
                }
                Console.WriteLine($"Continuation token: {page.ContinuationToken}");
#if !SNIPPET
                count += page.Values.Count;
#endif
            }
            #endregion

            Assert.AreEqual(1, count);
        }

        private async Task<PageInfo> FirstPageAsync(MockTransport transport, string resource, bool protocol,
            string continuationToken = null, int? pageSizeHint = null, int? pageSize = null, string search = null)
        {
            await foreach (PageInfo page in GetPagesAsync(transport, resource, protocol, continuationToken, pageSizeHint, pageSize, search))
            {
                return page;
            }
            throw new InvalidOperationException("The mock listing did not return a page.");
        }

        private IAsyncEnumerable<PageInfo> GetPagesAsync(MockTransport transport, string resource, bool protocol,
            string continuationToken = null, int? pageSizeHint = null, int? pageSize = null, string search = null)
        {
            (SearchIndexClient indexes, SearchIndexerClient indexers) = CreateClients(transport);
            string[] select = { "name" };
            var context = new RequestContext();

            IAsyncEnumerable<PageInfo> Pages<T>(Func<Pageable<T>> sync, Func<AsyncPageable<T>> async) =>
                EnumeratePagesAsync(sync, async, continuationToken, pageSizeHint);

            if (protocol)
            {
                return resource switch
                {
                    "indexers" => Pages(
                        () => indexers.GetIndexersWithSelectedProperties(select, search, pageSize, "prefix", context),
                        () => indexers.GetIndexersWithSelectedPropertiesAsync(select, search, pageSize, "prefix", context)),
                    "datasources" => Pages(
                        () => indexers.GetDataSourceConnectionsWithSelectedProperties(select, search, pageSize, "prefix", context),
                        () => indexers.GetDataSourceConnectionsWithSelectedPropertiesAsync(select, search, pageSize, "prefix", context)),
                    "skillsets" => Pages(
                        () => indexers.GetSkillsetsWithSelectedProperties(select, search, pageSize, "prefix", context),
                        () => indexers.GetSkillsetsWithSelectedPropertiesAsync(select, search, pageSize, "prefix", context)),
                    "synonymmaps" => Pages(
                        () => indexes.GetSynonymMapsWithSelectedProperties(select, search, pageSize, "prefix", context),
                        () => indexes.GetSynonymMapsWithSelectedPropertiesAsync(select, search, pageSize, "prefix", context)),
                    "aliases" => Pages(
                        () => indexes.GetAliases(search, pageSize, "prefix", context),
                        () => indexes.GetAliasesAsync(search, pageSize, "prefix", context)),
                    "indexes" => Pages(
                        () => indexes.GetIndexes(search, pageSize, "prefix", context),
                        () => indexes.GetIndexesAsync(search, pageSize, "prefix", context)),
                    "selected-indexes" => Pages(
                        () => indexes.GetIndexesWithSelectedProperties(select, search, pageSize, "prefix", context),
                        () => indexes.GetIndexesWithSelectedPropertiesAsync(select, search, pageSize, "prefix", context)),
                    "indexstats" => Pages(
                        () => indexes.GetIndexStatsSummary(search, pageSize, "prefix", context),
                        () => indexes.GetIndexStatsSummaryAsync(search, pageSize, "prefix", context)),
                    "knowledgebases" => Pages(
                        () => indexes.GetKnowledgeBases(search, pageSize, "prefix", context),
                        () => indexes.GetKnowledgeBasesAsync(search, pageSize, "prefix", context)),
                    "knowledgesources" => Pages(
                        () => indexes.GetKnowledgeSources(search, pageSize, "prefix", context),
                        () => indexes.GetKnowledgeSourcesAsync(search, pageSize, "prefix", context)),
                    "files" => Pages(
                        () => indexes.GetKnowledgeSourceFiles("source", null, search, pageSize, "prefix", context),
                        () => indexes.GetKnowledgeSourceFilesAsync("source", null, search, pageSize, "prefix", context)),
                    _ => throw new ArgumentOutOfRangeException(nameof(resource), resource, "Unknown listing resource.")
                };
            }

            return resource switch
            {
                "indexers" => Pages(
                    () => indexers.GetIndexersWithSelectedProperties(select, search, pageSize, ListingSearchType.Prefix),
                    () => indexers.GetIndexersWithSelectedPropertiesAsync(select, search, pageSize, ListingSearchType.Prefix)),
                "datasources" => Pages(
                    () => indexers.GetDataSourceConnectionsWithSelectedProperties(select, search, pageSize, ListingSearchType.Prefix),
                    () => indexers.GetDataSourceConnectionsWithSelectedPropertiesAsync(select, search, pageSize, ListingSearchType.Prefix)),
                "skillsets" => Pages(
                    () => indexers.GetSkillsetsWithSelectedProperties(select, search, pageSize, ListingSearchType.Prefix),
                    () => indexers.GetSkillsetsWithSelectedPropertiesAsync(select, search, pageSize, ListingSearchType.Prefix)),
                "synonymmaps" => Pages(
                    () => indexes.GetSynonymMapsWithSelectedProperties(select, search, pageSize, ListingSearchType.Prefix),
                    () => indexes.GetSynonymMapsWithSelectedPropertiesAsync(select, search, pageSize, ListingSearchType.Prefix)),
                "aliases" => Pages(
                    () => indexes.GetAliases(search, pageSize, ListingSearchType.Prefix),
                    () => indexes.GetAliasesAsync(search, pageSize, ListingSearchType.Prefix)),
                "indexes" => Pages(
                    () => indexes.GetIndexes(search, pageSize, ListingSearchType.Prefix),
                    () => indexes.GetIndexesAsync(search, pageSize, ListingSearchType.Prefix)),
                "selected-indexes" => Pages(
                    () => indexes.GetIndexesWithSelectedProperties(select, search, pageSize, ListingSearchType.Prefix),
                    () => indexes.GetIndexesWithSelectedPropertiesAsync(select, search, pageSize, ListingSearchType.Prefix)),
                "indexstats" => Pages(
                    () => indexes.GetIndexStatsSummary(search, pageSize, ListingSearchType.Prefix),
                    () => indexes.GetIndexStatsSummaryAsync(search, pageSize, ListingSearchType.Prefix)),
                "knowledgebases" => Pages(
                    () => indexes.GetKnowledgeBases(search, pageSize, ListingSearchType.Prefix),
                    () => indexes.GetKnowledgeBasesAsync(search, pageSize, ListingSearchType.Prefix)),
                "knowledgesources" => Pages(
                    () => indexes.GetKnowledgeSources(search, pageSize, ListingSearchType.Prefix),
                    () => indexes.GetKnowledgeSourcesAsync(search, pageSize, ListingSearchType.Prefix)),
                "files" => Pages(
                    () => indexes.GetKnowledgeSourceFiles("source", search: search, pageSize: pageSize, searchType: ListingSearchType.Prefix),
                    () => indexes.GetKnowledgeSourceFilesAsync("source", search: search, pageSize: pageSize, searchType: ListingSearchType.Prefix)),
                _ => throw new ArgumentOutOfRangeException(nameof(resource), resource, "Unknown listing resource.")
            };
        }

        private async IAsyncEnumerable<PageInfo> EnumeratePagesAsync<T>(Func<Pageable<T>> sync, Func<AsyncPageable<T>> async,
            string continuationToken, int? pageSizeHint)
        {
            if (_async)
            {
                await foreach (Page<T> page in async().AsPages(continuationToken, pageSizeHint))
                {
                    yield return new PageInfo(page.Values.Count, page.ContinuationToken);
                }
            }
            else
            {
                foreach (Page<T> page in sync().AsPages(continuationToken, pageSizeHint))
                {
                    yield return new PageInfo(page.Values.Count, page.ContinuationToken);
                }
            }
        }

        private static (SearchIndexClient Indexes, SearchIndexerClient Indexers) CreateClients(MockTransport transport)
        {
            var options = new SearchClientOptions { Transport = transport };
            var credential = new AzureKeyCredential("fake-key");
            return (new SearchIndexClient(s_endpoint, credential, options), new SearchIndexerClient(s_endpoint, credential, options));
        }

        private static Dictionary<string, string> GetQuery(MockTransport transport, int requestIndex = 0) =>
            transport.Requests[requestIndex].Uri.ToUri().Query.TrimStart('?').Split('&', StringSplitOptions.RemoveEmptyEntries)
                .Select(part => part.Split('=', 2))
                .ToDictionary(part => Uri.UnescapeDataString(part[0]), part => Uri.UnescapeDataString(part[1]));

        private static string ResourcePath(string resource) => resource switch
        {
            "files" => "/knowledgesources('source')/files",
            "selected-indexes" => "/indexes",
            _ => "/" + resource
        };

        private static MockResponse CreateResponse(string resource, string nextLink = null)
        {
            string item = resource switch
            {
                "indexers" => """{"name":"first","dataSourceName":"source","targetIndexName":"index"}""",
                "datasources" => """{"name":"first","type":"azureblob","credentials":{"connectionString":"fake"},"container":{"name":"container"}}""",
                "skillsets" => """{"name":"first","skills":[]}""",
                "synonymmaps" => """{"name":"first","format":"solr","synonyms":"hotel, resort"}""",
                "aliases" => """{"name":"first","indexes":["index"]}""",
                "indexes" or "selected-indexes" => """{"name":"first","fields":[]}""",
                "indexstats" => """{"name":"first","documentCount":1,"storageSize":0,"vectorIndexSize":0}""",
                "knowledgebases" => """{"name":"first","knowledgeSources":[]}""",
                "knowledgesources" => """{"name":"first","kind":"searchIndex","searchIndexParameters":{"searchIndexName":"index"}}""",
                "files" => """{"id":"first","name":"first.txt"}""",
                _ => throw new ArgumentOutOfRangeException(nameof(resource), resource, "Unknown listing resource.")
            };
            var response = new MockResponse(200);
            response.SetContent("{\"value\":[" + item + "],\"@odata.nextLink\":" + JsonSerializer.Serialize(nextLink) + "}");
            return response;
        }

        private readonly struct PageInfo
        {
            public PageInfo(int count, string continuationToken)
            {
                Count = count;
                ContinuationToken = continuationToken;
            }

            public int Count { get; }
            public string ContinuationToken { get; }
        }
    }
}
