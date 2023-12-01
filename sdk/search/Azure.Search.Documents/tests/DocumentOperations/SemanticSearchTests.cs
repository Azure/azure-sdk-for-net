// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Search.Documents.Models;
using NUnit.Framework;

namespace Azure.Search.Documents.Tests
{
    public partial class SemanticSearchTests : SearchTestBase
    {
        public SemanticSearchTests(bool async, SearchClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        private async Task AssertKeysEqual<T>(
            SearchResults<T> response,
            Func<SearchResult<T>, string> keyAccessor,
            params string[] expectedKeys)
        {
            List<SearchResult<T>> docs = await response.GetResultsAsync().ToListAsync();
            CollectionAssert.AreEquivalent(expectedKeys, docs.Select(keyAccessor));
        }

        [Test]
        [PlaybackOnly("The availability of Semantic Search is limited to specific regions, as indicated in the list provided here: https://azure.microsoft.com/explore/global-infrastructure/products-by-region/?products=search. Due to this limitation, the deployment of resources for weekly test pipeline for setting the \"semanticSearch\": \"free\" fails in the UsGov and China cloud regions.")]
        public async Task SemanticSearch()
        {
            await using SearchResources resources = await SearchResources.CreateWithHotelsIndexAsync(this);

            SearchResults<Hotel> response = await resources.GetSearchClient().SearchAsync<Hotel>(
                   "Is there any hotel located on the main commercial artery of the city in the heart of New York?",
                    new SearchOptions
                    {
                        SemanticSearch = new()
                        {
                            SemanticConfigurationName = "my-semantic-config",
                            QueryCaption = new(QueryCaptionType.Extractive),
                            QueryAnswer = new(QueryAnswerType.Extractive)
                        },
                        QueryType = SearchQueryType.Semantic
                    });

            Assert.NotNull(response.SemanticSearch.Answers);
            Assert.AreEqual(1, response.SemanticSearch.Answers.Count);

            Assert.NotNull(response.SemanticSearch.Answers[0].Highlights);
            Assert.NotNull(response.SemanticSearch.Answers[0].Text);

            await AssertKeysEqual(
                 response,
                 h => h.Document.HotelId,
                 "9", "10", "3", "4", "1", "2", "5");
        }

        [Test]
        [PlaybackOnly("The availability of Semantic Search is limited to specific regions, as indicated in the list provided here: https://azure.microsoft.com/explore/global-infrastructure/products-by-region/?products=search. Due to this limitation, the deployment of resources for weekly test pipeline for setting the \"semanticSearch\": \"free\" fails in the UsGov and China cloud regions.")]
        public async Task SemanticMaxWaitOutOfRangeThrows()
        {
            await using SearchResources resources = await SearchResources.CreateWithHotelsIndexAsync(this);

            RequestFailedException ex = await CatchAsync<RequestFailedException>(
                async () => await resources.GetSearchClient().SearchAsync<Hotel>(
                    "Is there any luxury hotel in New York?",
                    new SearchOptions
                    {
                        SemanticSearch = new()
                        {
                            SemanticConfigurationName = "my-semantic-config",
                            QueryCaption = new(QueryCaptionType.Extractive),
                            QueryAnswer = new(QueryAnswerType.Extractive),
                            MaxWait = TimeSpan.FromMilliseconds(700),
                        },
                        QueryType = SearchQueryType.Semantic,
                    }));

            Assert.AreEqual(400, ex.Status);
            Assert.AreEqual("InvalidRequestParameter", ex.ErrorCode);
        }

        [Test]
        [PlaybackOnly("The availability of Semantic Search is limited to specific regions, as indicated in the list provided here: https://azure.microsoft.com/explore/global-infrastructure/products-by-region/?products=search. Due to this limitation, the deployment of resources for weekly test pipeline for setting the \"semanticSearch\": \"free\" fails in the UsGov and China cloud regions.")]
        public async Task CanContinueWithNextPageResults()
        {
            const int size = 200;

            await using SearchResources resources = await SearchResources.CreateLargeHotelsIndexAsync(this, size);
            SearchClient client = resources.GetQueryClient();

            ReadOnlyMemory<float> vectorizedResult = VectorSearchEmbeddings.DefaultVectorizeDescription;
            SearchResults<SearchDocument> response = await client.SearchAsync<SearchDocument>("*",
                    new SearchOptions
                    {
                        SemanticSearch = new()
                        {
                            SemanticConfigurationName = "my-semantic-config",
                            QueryCaption = new(QueryCaptionType.Extractive),
                            QueryAnswer = new(QueryAnswerType.Extractive)
                        },
                        QueryType = SearchQueryType.Semantic,
                        Select = new[] { "hotelId" }
                    });

            int totalDocsCount = 0;
            int pageCount = 0;

            await foreach (Page<SearchResult<SearchDocument>> page in response.GetResultsAsync().AsPages())
            {
                pageCount++;
                int docsPerPageCount = 0;
                foreach (SearchResult<SearchDocument> result in page.Values)
                {
                    docsPerPageCount++;
                    totalDocsCount++;
                }
                Assert.AreEqual(docsPerPageCount, 50);
            }

            Assert.AreEqual(totalDocsCount, 200);
            Assert.AreEqual(pageCount, 4);
        }
    }
}
