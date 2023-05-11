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
            Response<SearchResults<T>> response,
            Func<SearchResult<T>, string> keyAccessor,
            params string[] expectedKeys)
        {
            List<SearchResult<T>> docs = await response.Value.GetResultsAsync().ToListAsync();
            CollectionAssert.AreEquivalent(expectedKeys, docs.Select(keyAccessor));
        }

        [Test]
        public async Task SingleVectorSearch()
        {
            await using SearchResources resources = await SearchResources.CreateWithHotelsIndexAsync(this);

            var vectorizedResult = VectorSearchEmbeddings.SearchVectorizeDescription; // "Top hotels in town"
            await Task.Delay(TimeSpan.FromSeconds(1));

            Response<SearchResults<Hotel>> response = await resources.GetSearchClient().SearchAsync<Hotel>(
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

            Response<SearchResults<Hotel>> response = await resources.GetSearchClient().SearchAsync<Hotel>(
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

            Response<SearchResults<Hotel>> response = await resources.GetSearchClient().SearchAsync<Hotel>(
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
    }
}
