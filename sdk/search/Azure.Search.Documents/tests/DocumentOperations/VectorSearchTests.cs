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
    [ClientTestFixture(SearchClientOptions.ServiceVersion.V2023_07_01_Preview)]
    public partial class VectorSearch : SearchTestBase
    {
        public VectorSearch(bool async, SearchClientOptions.ServiceVersion serviceVersion)
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
        public async Task SingleVectorSearch()
        {
            await using SearchResources resources = await SearchResources.CreateWithHotelsIndexAsync(this);

            var vectorizedResult = VectorSearchEmbeddings.SearchVectorizeDescription; // "Top hotels in town"
            await Task.Delay(TimeSpan.FromSeconds(1));

            SearchResults<Hotel> response = await resources.GetSearchClient().SearchAsync<Hotel>(
                   null,
                   new SearchOptions
                   {
                       Vector = new SearchQueryVector { Value = vectorizedResult, K = 3, Fields = "descriptionVector" },
                       Select = { "hotelId", "hotelName" }
                   });

            await AssertKeysEqual(
                response,
                h => h.Document.HotelId,
                "3", "5", "1");
        }

        [Test]
        public async Task SingleVectorSearchWithFilter()
        {
            await using SearchResources resources = await SearchResources.CreateWithHotelsIndexAsync(this);

            var vectorizedResult = VectorSearchEmbeddings.SearchVectorizeDescription; // "Top hotels in town"

            SearchResults<Hotel> response = await resources.GetSearchClient().SearchAsync<Hotel>(
                    null,
                    new SearchOptions
                    {
                        Vector = new SearchQueryVector { Value = vectorizedResult, K = 3, Fields = "descriptionVector" },
                        Filter = "category eq 'Budget'",
                        Select = { "hotelId", "hotelName", "category" }
                    });

            await AssertKeysEqual(
                response,
                h => h.Document.HotelId,
                "3", "5", "4");
        }

        [Test]
        public async Task SimpleHybridSearch()
        {
            await using SearchResources resources = await SearchResources.CreateWithHotelsIndexAsync(this);

            var vectorizedResult = VectorSearchEmbeddings.SearchVectorizeDescription; // "Top hotels in town"

            SearchResults<Hotel> response = await resources.GetSearchClient().SearchAsync<Hotel>(
                    "Top hotels in town",
                    new SearchOptions
                    {
                        Vector = new SearchQueryVector { Value = vectorizedResult, K = 3, Fields = "descriptionVector" },
                        Select = { "hotelId", "hotelName" },
                    });

            await AssertKeysEqual(
                response,
                h => h.Document.HotelId,
                "3", "1", "2", "10", "4", "5", "9");
        }

        [Test]
        [PlaybackOnly("The availability of Semantic Search is limited to specific regions, as indicated in the list provided here: https://azure.microsoft.com/explore/global-infrastructure/products-by-region/?products=search. Due to this limitation, the deployment of resources for weekly test pipeline for setting the \"semanticSearch\": \"free\" fails in the UsGov and China cloud regions.")]
        public async Task SemanticHybridSearch()
        {
            await using SearchResources resources = await SearchResources.CreateWithHotelsIndexAsync(this);

            var vectorizedResult = VectorSearchEmbeddings.SearchVectorizeDescription; // "Top hotels in town"

            SearchResults<Hotel> response = await resources.GetSearchClient().SearchAsync<Hotel>(
                    "Is there any hotel located on the main commercial artery of the city in the heart of New York?",
                    new SearchOptions
                    {
                        Vector = new SearchQueryVector { Value = vectorizedResult, K = 3, Fields = "descriptionVector" },
                        Select = { "hotelId", "hotelName", "description", "category" },
                        QueryType = SearchQueryType.Semantic,
                        QueryLanguage = QueryLanguage.EnUs,
                        SemanticConfigurationName = "my-semantic-config",
                        QueryCaption = QueryCaptionType.Extractive,
                        QueryAnswer = QueryAnswerType.Extractive,
                    });

            Assert.NotNull(response.Answers);
            Assert.AreEqual(1, response.Answers.Count);
            Assert.AreEqual("9", response.Answers[0].Key);
            Assert.NotNull(response.Answers[0].Highlights);
            Assert.NotNull(response.Answers[0].Text);

            await foreach (SearchResult<Hotel> result in response.GetResultsAsync())
            {
                Hotel doc = result.Document;

                Assert.NotNull(result.Captions);

                var caption = result.Captions.FirstOrDefault();
                Assert.NotNull(caption.Highlights, "Caption highlight is null");
                Assert.NotNull(caption.Text, "Caption text is null");
            }

            await AssertKeysEqual(
                response,
                h => h.Document.HotelId,
                "9", "3", "2", "5", "10", "1", "4");
        }
    }
}
