﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core;
#if EXPERIMENTAL_SPATIAL
using Azure.Core.Spatial;
#endif
using Azure.Core.TestFramework;
using Azure.Search.Documents.Models;
using NUnit.Framework;

namespace Azure.Search.Documents.Tests
{
    public class SearchTests : SearchTestBase
    {
        public SearchTests(bool async, SearchClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        #region Utilities
        private async Task AssertKeysContains<T>(
            Response<SearchResults<T>> response,
            Func<SearchResult<T>, string> keyAccessor,
            params string[] expectedKeys)
        {
            List<SearchResult<T>> docs = await response.Value.GetResultsAsync().ToListAsync();
            CollectionAssert.IsSubsetOf(expectedKeys, docs.Select(keyAccessor));
        }

        private async Task AssertKeysEqual<T>(
            Response<SearchResults<T>> response,
            Func<SearchResult<T>, string> keyAccessor,
            params string[] expectedKeys)
        {
            List<SearchResult<T>> docs = await response.Value.GetResultsAsync().ToListAsync();
            CollectionAssert.AreEqual(expectedKeys, docs.Select(keyAccessor));
        }

        private ICollection<FacetResult> GetFacetsForField(
            IDictionary<string, IList<FacetResult>> facets,
            string expectedField,
            int expectedCount)
        {
            Assert.True(facets.ContainsKey(expectedField), $"Expecting facets to contain {expectedField}");
            ICollection<FacetResult> fieldFacets = facets[expectedField];
            Assert.AreEqual(expectedCount, fieldFacets.Count);
            return fieldFacets;
        }

        public FacetResult MakeRangeFacet(int count, object from, object to) =>
            new FacetResult(count, new Dictionary<string, object>()
            {
                ["from"] = from,
                ["to"] = to
            });

        public FacetResult MakeValueFacet(int count, object value) =>
            new FacetResult(count, new Dictionary<string, object>()
            {
                ["value"] = value
            });

        private void AssertFacetsEqual(
            ICollection<FacetResult> actualFacets,
            params FacetResult[] expectedFacets)
        {
            Assert.AreEqual(actualFacets.Count, expectedFacets.Length);
            int i = 0;
            foreach (FacetResult actualFacet in actualFacets)
            {
                FacetResult expectedFacet = expectedFacets[i++];
                Assert.AreEqual(expectedFacet.Count, actualFacet.Count);
                CollectionAssert.IsSubsetOf(actualFacet.Keys, expectedFacet.Keys);
                foreach (string key in expectedFacet.Keys)
                {
                    Assert.AreEqual(
                        expectedFacet[key],
                        actualFacet.TryGetValue(key, out object value) ? value : null);
                }
            }
        }

        /// <summary>
        /// Create a hotels index with the standard test documents and as many
        /// extra empty documents needed to test.
        /// </summary>
        /// <param name="size">The total number of documents in the index.</param>
        /// <returns>SearchResources for testing.</returns>
        public async Task<SearchResources> CreateLargeHotelsIndexAsync(int size)
        {
            // Start with the standard test hotels
            SearchResources resources = await SearchResources.CreateWithHotelsIndexAsync(this);

            // Create empty hotels with just an ID for the rest
            int existingDocumentCount = SearchResources.TestDocuments.Length;
            IEnumerable<string> hotelIds =
                Enumerable.Range(
                    existingDocumentCount + 1,
                    size - existingDocumentCount)
                .Select(id => id.ToString());
            List<SearchDocument> hotels = hotelIds.Select(id => new SearchDocument { ["hotelId"] = id }).ToList();

            // Upload the empty hotels in batches of 1000 until we're complete
            SearchClient client = resources.GetSearchClient();
            for (int i = 0; i < hotels.Count; i += 1000)
            {
                IEnumerable<SearchDocument> nextHotels = hotels.Skip(i).Take(1000);
                if (!nextHotels.Any()) { break; }
                await client.IndexDocumentsAsync(IndexDocumentsBatch.Upload(nextHotels));
                await resources.WaitForIndexingAsync();
            }

            return resources;
        }
        #endregion Utilities

        [Test]
        public async Task DynamicDocuments()
        {
            await using SearchResources resources = await SearchResources.GetSharedHotelsIndexAsync(this);

            SearchClient client = resources.GetQueryClient();
            SearchResults<SearchDocument> response = await client.SearchAsync<SearchDocument>("*");
            Assert.IsNull(response.TotalCount);
            Assert.IsNull(response.Coverage);
            Assert.IsNull(response.Facets);

            List<SearchResult<SearchDocument>> docs = await response.GetResultsAsync().ToListAsync();
            Assert.AreEqual(SearchResources.TestDocuments.Length, docs.Count);
            for (int i = 0; i < docs.Count; i++)
            {
                Assert.AreEqual(1, docs[i].Score);
                Assert.IsNull(docs[i].Highlights);
                SearchTestBase.AssertApproximate(
                    SearchResources.TestDocuments[i].AsDocument(),
                    docs[i].Document);
            }
        }

        [Test]
        public async Task StaticDocuments()
        {
            await using SearchResources resources = await SearchResources.GetSharedHotelsIndexAsync(this);

            SearchClient client = resources.GetQueryClient();
            SearchResults<Hotel> response = await client.SearchAsync<Hotel>("*");
            Assert.IsNull(response.TotalCount);
            Assert.IsNull(response.Coverage);
            Assert.IsNull(response.Facets);

            List<SearchResult<Hotel>> docs = await response.GetResultsAsync().ToListAsync();
            Assert.AreEqual(SearchResources.TestDocuments.Length, docs.Count);
            for (int i = 0; i < docs.Count; i++)
            {
                Assert.AreEqual(1, docs[i].Score);
                Assert.IsNull(docs[i].Highlights);
                Assert.AreEqual(SearchResources.TestDocuments[i], docs[i].Document);
            }
        }

#if EXPERIMENTAL_SERIALIZER
        [Test]
#endif
        public async Task StaticDocumentsWithCustomSerializer()
        {
            await using SearchResources resources = await SearchResources.GetSharedHotelsIndexAsync(this);

            SearchClient client = resources.GetQueryClient(
                new SearchClientOptions()
                {
#if EXPERIMENTAL_SERIALIZER
                    Serializer = new JsonObjectSerializer(
                        new JsonSerializerOptions()
                        {
                            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                            Converters =
                            {
#if EXPERIMENTAL_SPATIAL
                                new GeometryJsonConverter()
#endif
                            }
                        })
#endif
                });
            SearchResults<UncasedHotel> response = await client.SearchAsync<UncasedHotel>("*");
            Assert.IsNull(response.TotalCount);
            Assert.IsNull(response.Coverage);
            Assert.IsNull(response.Facets);

            List<SearchResult<UncasedHotel>> docs = await response.GetResultsAsync().ToListAsync();
            Assert.AreEqual(SearchResources.TestDocuments.Length, docs.Count);
            for (int i = 0; i < docs.Count; i++)
            {
                Assert.AreEqual(1, docs[i].Score);
                Assert.IsNull(docs[i].Highlights);
                // Flip expected/actual order because we implemented Equals in UncasedHotel
                Assert.AreEqual(docs[i].Document, SearchResources.TestDocuments[i]);
            }
        }

        [Test]
        public async Task ThrowsWhenRequestIsMalformed()
        {
            await using SearchResources resources = await SearchResources.GetSharedHotelsIndexAsync(this);

            SearchClient client = resources.GetQueryClient();
            SearchOptions invalidOptions = new SearchOptions { Filter = "This is not a valid filter." };
            RequestFailedException ex = await CatchAsync<RequestFailedException>(
                async () => await client.SearchAsync<SearchDocument>("*", invalidOptions));
            Assert.AreEqual(400, ex.Status);
            StringAssert.StartsWith("Invalid expression: Syntax error at position 7 in 'This is not a valid filter.'", ex.Message);
        }

        [Test]
        public async Task DefaultSearchModeIsAny()
        {
            await using SearchResources resources = await SearchResources.GetSharedHotelsIndexAsync(this);
            Response<SearchResults<Hotel>> response =
                await resources.GetQueryClient().SearchAsync<Hotel>("Cheapest hotel");
            await AssertKeysContains(
                response,
                h => h.Document.HotelId,
                "1", "2", "3");
        }

        [Test]
        public async Task SearchModeAll()
        {
            await using SearchResources resources = await SearchResources.GetSharedHotelsIndexAsync(this);
            Response<SearchResults<Hotel>> response =
                await resources.GetQueryClient().SearchAsync<Hotel>(
                    "Cheapest hotel",
                    new SearchOptions
                    {
                        // Set explicitly at least once for test coverage
                        QueryType = SearchQueryType.Simple,
                        SearchMode = SearchMode.All
                    });
            await AssertKeysEqual(
                response,
                h => h.Document.HotelId,
                "2");
        }

        [Test]
        public async Task TotalCount()
        {
            await using SearchResources resources = await SearchResources.GetSharedHotelsIndexAsync(this);
            SearchOptions options = new SearchOptions { IncludeTotalCount = true };
            Response<SearchResults<Hotel>> response =
                await resources.GetQueryClient().SearchAsync<Hotel>("*", options);
            Assert.AreEqual(SearchResources.TestDocuments.Length, response.Value.TotalCount);
        }

        [Test]
        public async Task Filter()
        {
            await using SearchResources resources = await SearchResources.GetSharedHotelsIndexAsync(this);
            Response<SearchResults<Hotel>> response =
                await resources.GetQueryClient().SearchAsync<Hotel>(
                    null,
                    new SearchOptions
                    {
                        Filter = "rating gt 3 and lastRenovationDate gt 2000-01-01T00:00:00Z"
                    });
            await AssertKeysEqual(
                response,
                h => h.Document.HotelId,
                "1", "5");
        }

        [Test]
        public async Task HitHighlighting()
        {
            const string Description = "description";
            const string Category = "category";

            await using SearchResources resources = await SearchResources.GetSharedHotelsIndexAsync(this);
            Response<SearchResults<Hotel>> response =
                await resources.GetQueryClient().SearchAsync<Hotel>(
                    "luxury hotel",
                    new SearchOptions
                    {
                        Filter = "rating eq 5",
                        HighlightPreTag = "<b>",
                        HighlightPostTag = "</b>",
                        HighlightFields = new[] { Description, Category }
                    });
            await AssertKeysEqual(
                response,
                h => h.Document.HotelId,
                "1");
            SearchResult<Hotel> doc = await response.Value.GetResultsAsync().FirstAsync();
            Assert.IsNotNull(doc.Highlights);
            Assert.AreEqual(2, doc.Highlights.Count);
            CollectionAssert.Contains(doc.Highlights.Keys, Description);
            CollectionAssert.Contains(doc.Highlights.Keys, Category);

            Assert.AreEqual(
                "<b>Luxury</b>",
                doc.Highlights[Category].Single());
            CollectionAssert.AreEqual(
                new[]
                {
                    "Best <b>hotel</b> in town if you like <b>luxury</b> <b>hotels</b>.",
                    "We highly recommend this <b>hotel</b>."
                },
                doc.Highlights[Description]);
        }

        [Test]
        public async Task OrderByProgressivelyBreaksTies()
        {
            await using SearchResources resources = await SearchResources.GetSharedHotelsIndexAsync(this);
            Response<SearchResults<Hotel>> response =
                await resources.GetQueryClient().SearchAsync<Hotel>(
                    "*",
                    new SearchOptions
                    {
                        OrderBy = new[]
                        {
                            "rating desc",
                            "lastRenovationDate asc",
                            "geo.distance(location, geography'POINT(-122.0 49.0)')"
                        }
                    });
            await AssertKeysEqual(
                response,
                h => h.Document.HotelId,
                "1", "9", "4", "3", "5", "10", "2", "6", "7", "8");
        }

        [Test]
        public async Task NoOrderBySortsByScore()
        {
            await using SearchResources resources = await SearchResources.GetSharedHotelsIndexAsync(this);
            Response<SearchResults<Hotel>> response =
                await resources.GetQueryClient().SearchAsync<Hotel>(
                    "cheapest hotel in town",
                    new SearchOptions { Filter = "rating lt 4" });
            await AssertKeysEqual(
                response,
                h => h.Document.HotelId,
                "2", "10");
            List<SearchResult<Hotel>> docs = await response.Value.GetResultsAsync().ToListAsync();
            Assert.Greater(docs[0].Score, docs[1].Score);
        }

        [Test]
        public async Task SelectedFields()
        {
            await using SearchResources resources = await SearchResources.GetSharedHotelsIndexAsync(this);
            Response<SearchResults<Hotel>> response =
                await resources.GetQueryClient().SearchAsync<Hotel>(
                    "fancy luxury secret",
                    new SearchOptions
                    {
                        SearchFields = new[] { "category", "hotelName" },
                        Select = new[] { "hotelName", "rating", "address/city", "rooms/type" }
                    });

            Hotel[] expectedDocs =
                new[]
                {
                    new Hotel { HotelName = "Fancy Stay", Rating = 5 },
                    new Hotel
                    {
                        HotelName = "Secret Point Motel",
                        Rating = 4,
                        Address = new HotelAddress { City = "New York" },
                        Rooms = new[]
                        {
                            new HotelRoom { Type = "Budget Room" },
                            new HotelRoom { Type = "Budget Room" }
                        }
                    }
                };
            List<SearchResult<Hotel>> actualDocs =
                await response.Value.GetResultsAsync().ToListAsync();

            CollectionAssert.AreEqual(
                expectedDocs.OrderBy(h => h.HotelName),
                actualDocs.Select(d => d.Document).OrderBy(h => h.HotelName));
        }

        [Test]
        public async Task LuceneSyntax()
        {
            await using SearchResources resources = await SearchResources.GetSharedHotelsIndexAsync(this);
            Response<SearchResults<Hotel>> response =
                await resources.GetQueryClient().SearchAsync<Hotel>(
                    "hotelName:roch~",
                    new SearchOptions
                    {
                        QueryType = SearchQueryType.Full,
                        Select = new[] { "hotelName", "rating" }
                    });

            Hotel expectedDoc = new Hotel() { HotelName = "Roach Motel", Rating = 1 };
            List<SearchResult<Hotel>> actualDocs =
                await response.Value.GetResultsAsync().ToListAsync();

            Assert.AreEqual(1, actualDocs.Count);
            Assert.AreEqual(expectedDoc, actualDocs.First().Document);
        }

        /* TODO: Enable this Track 1 test when we have support for Synonym maps
        [Test]
        public async Task Synonyms()
        {
            await using SearchResources resources = await SearchResources.CreateWithHotelsIndexAsync(this);

            SearchServiceClient searchClient = resources.GetServiceClient();

            const string SynonymMapName = "names";
            var synonymMap = new SynonymMap(name: SynonymMapName, synonyms: "luxury,fancy");
            await searchClient.CreateSynonymMapAsync(synonymMap);

            SearchClient client = resources.GetIndexClient();
            SearchIndex index = await searchClient.GetIndexAsync(client.IndexName);
            index.Fields.First(f => f.Name == "hotelName").SynonymMaps = new[] { SynonymMapName };
            await searchClient.CreateOrUpdateIndexAsync(index);

            // When this test runs live, it runs against a free service that
            // has 3 replicas. Sometimes the synonym map update doesn't make
            // it to the replica that handles the query below, causing a test
            // failure. We wait here to increase the odds of consistency and
            // decrease the likelihood of spurious test failures.
            await resources.WaitForSynonymMapUpdateAsync();

            Response<SearchResults<Hotel>> response = await client.SearchAsync<Hotel>(
                "luxury",
                new SearchOptions()
                {
                    QueryType = SearchQueryType.Full,
                    SearchFields = new[] { "hotelName" },
                    Select = new[] { "hotelName", "rating" }
                });

            var expectedDoc = new Hotel { HotelName = "Fancy Stay", Rating = 5 };
            List<SearchResult<Hotel>> actualDocs =
                await response.Value.GetResultsAsync().ToListAsync();

            Assert.AreEqual(1, actualDocs.Count);
            Assert.AreEqual(expectedDoc, actualDocs.First().Document);
        }
        /**/

        [Test]
        public async Task RegexSearch()
        {
            await using SearchResources resources = await SearchResources.GetSharedHotelsIndexAsync(this);
            Response<SearchResults<Hotel>> response =
                await resources.GetQueryClient().SearchAsync<Hotel>(
                    @"hotelName:/.*oach.*\/?/",
                    new SearchOptions
                    {
                        QueryType = SearchQueryType.Full,
                        Select = new[] { "hotelName", "rating" }
                    });

            Hotel expectedDoc = new Hotel() { HotelName = "Roach Motel", Rating = 1 };
            List<SearchResult<Hotel>> actualDocs =
                await response.Value.GetResultsAsync().ToListAsync();

            Assert.AreEqual(1, actualDocs.Count);
            Assert.AreEqual(expectedDoc, actualDocs.First().Document);
        }

        [Test]
        public async Task RegexSpecialChars()
        {
            await using SearchResources resources = await SearchResources.GetSharedHotelsIndexAsync(this);
            Response<SearchResults<Hotel>> response =
                await resources.GetQueryClient().SearchAsync<Hotel>(
                    @"/\+\-\&\|\!\(\)\{\}\[\]\^\""\\~\*\?\:\\\//",
                    new SearchOptions { QueryType = SearchQueryType.Full });
            List<SearchResult<Hotel>> docs = await response.Value.GetResultsAsync().ToListAsync();
            Assert.AreEqual(0, docs.Count);
        }

        [Test]
        public async Task RegexSpecialCharsUnescapedThrows()
        {
            await using SearchResources resources = await SearchResources.GetSharedHotelsIndexAsync(this);
            SearchClient client = resources.GetQueryClient();
            RequestFailedException ex = await CatchAsync<RequestFailedException>(
                async () => await client.SearchAsync<SearchDocument>(
                    @"/.*/.*/",
                    new SearchOptions { QueryType = SearchQueryType.Full }));
            Assert.AreEqual(400, ex.Status);
            StringAssert.StartsWith("Failed to parse query string at line 1, column 8.", ex.Message);
        }

        [Test]
        public async Task SizeAndSkipForPaging()
        {
            await using SearchResources resources = await SearchResources.GetSharedHotelsIndexAsync(this);
            SearchOptions options = new SearchOptions
            {
                Skip = 0,
                Size = 3,
                OrderBy = new[] { "hotelId" }
            };

            Response<SearchResults<Hotel>> response =
                await resources.GetQueryClient().SearchAsync<Hotel>("*", options);
            await AssertKeysEqual(
                response,
                h => h.Document.HotelId,
                "1", "10", "2");

            options.Skip = 3;
            response = await resources.GetQueryClient().SearchAsync<Hotel>("*", options);
            await AssertKeysEqual(
                response,
                h => h.Document.HotelId,
                "3", "4", "5");
        }

        /* TODO: Enable this Track 1 test when we have support for ScoringParameter
        [Test]
        public async Task ScoringProfileBoostsScore()
        {
            await using SearchResources resources = await SearchResources.GetSharedHotelsIndexAsync(this);
            Response<SearchResults<Hotel>> response =
                await resources.GetQueryClient().SearchAsync<Hotel>(
                    "hotel",
                    new SearchOptions
                    {
                        ScoringProfile = "nearest",
                        ScoringParameters = new[] { new ScoringParameter("myloc", TestExtensions.CreatePoint(49, -122)) },
                        Filter = "rating eq 5 or rating eq 1"
                    });
            await AssertKeysEqual(
                response,
                h => h.Document.HotelId,
                "2", "1");
        }
        /**/

        [Test]
        public async Task RangeFacets()
        {
            await using SearchResources resources = await SearchResources.GetSharedHotelsIndexAsync(this);
            Response<SearchResults<Hotel>> response =
                await resources.GetQueryClient().SearchAsync<Hotel>(
                    "*",
                    new SearchOptions
                    {
                        Facets = new[]
                        {
                            "rooms/baseRate,values:5|8|10",
                            "lastRenovationDate,values:2000-01-01T00:00:00Z"
                        }
                    });
            await AssertKeysContains(
                response,
                h => h.Document.HotelId,
                SearchResources.TestDocuments.Select(h => h.HotelId).ToArray());

            Assert.IsNotNull(response.Value.Facets);
            AssertFacetsEqual(
                GetFacetsForField(response.Value.Facets, "rooms/baseRate", 4),
                MakeRangeFacet(count: 1, from: null, to: 5.0),
                MakeRangeFacet(count: 1, from: 5.0, to: 8.0),
                MakeRangeFacet(count: 1, from: 8.0, to: 10.0),
                MakeRangeFacet(count: 0, from: 10.0, to: null));
            AssertFacetsEqual(
                GetFacetsForField(response.Value.Facets, "lastRenovationDate", 2),
                MakeRangeFacet(count: 5, from: null, to: new DateTimeOffset(2000, 1, 1, 0, 0, 0, TimeSpan.Zero)),
                MakeRangeFacet(count: 2, from: new DateTimeOffset(2000, 1, 1, 0, 0, 0, TimeSpan.Zero), to: null));

            // Check strongly typed range facets
            ICollection<FacetResult> facets = GetFacetsForField(response.Value.Facets, "rooms/baseRate", 4);
            RangeFacetResult<double> first = facets.ElementAt(0).AsRangeFacetResult<double>();
            Assert.AreEqual(1, first.Count);
            Assert.AreEqual(5, first.To);
            RangeFacetResult<double> second = facets.ElementAt(1).AsRangeFacetResult<double>();
            Assert.AreEqual(1, second.Count);
            Assert.AreEqual(5, second.From);
            Assert.AreEqual(8, second.To);
            RangeFacetResult<double> last = facets.ElementAt(3).AsRangeFacetResult<double>();
            Assert.AreEqual(null, first.From);
            Assert.AreEqual(null, last.To);

        }

        [Test]
        public async Task ValueFacets()
        {
            await using SearchResources resources = await SearchResources.GetSharedHotelsIndexAsync(this);
            Response<SearchResults<Hotel>> response =
                await resources.GetQueryClient().SearchAsync<Hotel>(
                    "*",
                    new SearchOptions
                    {
                        Facets = new[]
                        {
                            "rating,count:2,sort:-value",
                            "smokingAllowed,sort:count",
                            "category",
                            "lastRenovationDate,interval:year",
                            "rooms/baseRate,sort:value",
                            "tags,sort:value"
                        }
                    });
            await AssertKeysContains(
                response,
                h => h.Document.HotelId,
                SearchResources.TestDocuments.Select(h => h.HotelId).ToArray());

            Assert.IsNotNull(response.Value.Facets);
            AssertFacetsEqual(
                GetFacetsForField(response.Value.Facets, "rating", 2),
                MakeValueFacet(1, 5),
                MakeValueFacet(4, 4));
            AssertFacetsEqual(
                GetFacetsForField(response.Value.Facets, "smokingAllowed", 2),
                MakeValueFacet(4, false),
                MakeValueFacet(3, true));
            AssertFacetsEqual(
                GetFacetsForField(response.Value.Facets, "category", 3),
                MakeValueFacet(5, "Budget"),
                MakeValueFacet(1, "Boutique"),
                MakeValueFacet(1, "Luxury"));
            AssertFacetsEqual(
                GetFacetsForField(response.Value.Facets, "lastRenovationDate", 6),
                MakeValueFacet(1, new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)),
                MakeValueFacet(1, new DateTimeOffset(1982, 1, 1, 0, 0, 0, TimeSpan.Zero)),
                MakeValueFacet(2, new DateTimeOffset(1995, 1, 1, 0, 0, 0, TimeSpan.Zero)),
                MakeValueFacet(1, new DateTimeOffset(1999, 1, 1, 0, 0, 0, TimeSpan.Zero)),
                MakeValueFacet(1, new DateTimeOffset(2010, 1, 1, 0, 0, 0, TimeSpan.Zero)),
                MakeValueFacet(1, new DateTimeOffset(2012, 1, 1, 0, 0, 0, TimeSpan.Zero)));
            AssertFacetsEqual(
                GetFacetsForField(response.Value.Facets, "rooms/baseRate", 4),
                MakeValueFacet(1, 2.44),
                MakeValueFacet(1, 7.69),
                MakeValueFacet(1, 8.09),
                MakeValueFacet(1, 9.69));
            AssertFacetsEqual(
                GetFacetsForField(response.Value.Facets, "tags", 10),
                MakeValueFacet(1, "24-hour front desk service"),
                MakeValueFacet(1, "air conditioning"),
                MakeValueFacet(4, "budget"),
                MakeValueFacet(1, "coffee in lobby"),
                MakeValueFacet(2, "concierge"),
                MakeValueFacet(1, "motel"),
                MakeValueFacet(2, "pool"),
                MakeValueFacet(1, "restaurant"),
                MakeValueFacet(1, "view"),
                MakeValueFacet(4, "wifi"));

            // Check strongly typed value facets
            ICollection<FacetResult> facets = GetFacetsForField(response.Value.Facets, "rating", 2);
            ValueFacetResult<int> first = facets.ElementAt(0).AsValueFacetResult<int>();
            Assert.AreEqual(5, first.Value);
            Assert.AreEqual(1, first.Count);
            ValueFacetResult<int> second = facets.ElementAt(1).AsValueFacetResult<int>();
            Assert.AreEqual(4, second.Value);
            Assert.AreEqual(4, second.Count);
        }

        [Test]
        public async Task CanContinueStatic()
        {
            const int size = 2001;
            await using SearchResources resources = await CreateLargeHotelsIndexAsync(size);
            SearchClient client = resources.GetQueryClient();
            Response<SearchResults<Hotel>> response =
                await client.SearchAsync<Hotel>(
                    "*",
                    new SearchOptions
                    {
                        Size = 3000,
                        OrderBy = new[] { "hotelId asc" },
                        Select = new[] { "hotelId" }
                    });
            List<string> ids = new List<string>();

            // Get the first page
            Page<SearchResult<Hotel>> page = await response.Value.GetResultsAsync().AsPages().FirstAsync();
            Assert.LessOrEqual(page.Values.Count, 1000);
            ids.AddRange(page.Values.Select(h => h.Document.HotelId));
            Assert.NotNull(page.ContinuationToken);

            // Get the second page
            response = await client.SearchAsync<Hotel>(null, new SearchOptions(page.ContinuationToken));
            page = await response.Value.GetResultsAsync().AsPages().FirstAsync();
            Assert.LessOrEqual(page.Values.Count, 1000);
            ids.AddRange(page.Values.Select(h => h.Document.HotelId));
            Assert.NotNull(page.ContinuationToken);

            // Get the third page
            response = await client.SearchAsync<Hotel>(null, new SearchOptions(page.ContinuationToken));
            page = await response.Value.GetResultsAsync().AsPages().FirstAsync();
            Assert.LessOrEqual(page.Values.Count, 1000);
            ids.AddRange(page.Values.Select(h => h.Document.HotelId));
            Assert.IsNull(page.ContinuationToken);

            // Verify we saw everything
            CollectionAssert.AreEquivalent(
                Enumerable.Range(1, size).Select(i => i.ToString()),
                ids);
        }

        [Test]
        public async Task CanContinueDynamic()
        {
            const int size = 2001;
            await using SearchResources resources = await CreateLargeHotelsIndexAsync(size);
            SearchClient client = resources.GetQueryClient();
            Response<SearchResults<SearchDocument>> response =
                await client.SearchAsync<SearchDocument>(
                    "*",
                    new SearchOptions
                    {
                        Size = 3000,
                        OrderBy = new[] { "hotelId asc" },
                        Select = new[] { "hotelId" }
                    });
            List<string> ids = new List<string>();

            // Get the first page
            Page<SearchResult<SearchDocument>> page = await response.Value.GetResultsAsync().AsPages().FirstAsync();
            Assert.LessOrEqual(page.Values.Count, 1000);
            ids.AddRange(page.Values.Select(d => (string)d.Document["hotelId"]));
            Assert.NotNull(page.ContinuationToken);

            // Get the second page
            response = await client.SearchAsync<SearchDocument>(null, new SearchOptions(page.ContinuationToken));
            page = await response.Value.GetResultsAsync().AsPages().FirstAsync();
            Assert.LessOrEqual(page.Values.Count, 1000);
            ids.AddRange(page.Values.Select(d => (string)d.Document["hotelId"]));
            Assert.NotNull(page.ContinuationToken);

            // Get the third page
            response = await client.SearchAsync<SearchDocument>(null, new SearchOptions(page.ContinuationToken));
            page = await response.Value.GetResultsAsync().AsPages().FirstAsync();
            Assert.LessOrEqual(page.Values.Count, 1000);
            ids.AddRange(page.Values.Select(d => (string)d.Document["hotelId"]));
            Assert.IsNull(page.ContinuationToken);

            // Verify we saw everything
            CollectionAssert.AreEquivalent(
                Enumerable.Range(1, size).Select(i => i.ToString()),
                ids);
        }

        [Test]
        public async Task CanContinueWithoutSize()
        {
            const int size = 167;
            await using SearchResources resources = await CreateLargeHotelsIndexAsync(size);
            SearchClient client = resources.GetQueryClient();
            Response<SearchResults<SearchDocument>> response =
                await client.SearchAsync<SearchDocument>(
                    "*",
                    new SearchOptions
                    {
                        OrderBy = new[] { "hotelId asc" },
                        Select = new[] { "hotelId" }
                    });
            List<string> ids = new List<string>();

            // Get the first page
            Page<SearchResult<SearchDocument>> page = await response.Value.GetResultsAsync().AsPages().FirstAsync();
            Assert.LessOrEqual(page.Values.Count, 50);
            ids.AddRange(page.Values.Select(d => (string)d.Document["hotelId"]));
            Assert.NotNull(page.ContinuationToken);

            // Get the second page
            response = await client.SearchAsync<SearchDocument>(null, new SearchOptions(page.ContinuationToken));
            page = await response.Value.GetResultsAsync().AsPages().FirstAsync();
            Assert.LessOrEqual(page.Values.Count, 50);
            ids.AddRange(page.Values.Select(d => (string)d.Document["hotelId"]));
            Assert.NotNull(page.ContinuationToken);

            // Get the third page
            response = await client.SearchAsync<SearchDocument>(null, new SearchOptions(page.ContinuationToken));
            page = await response.Value.GetResultsAsync().AsPages().FirstAsync();
            Assert.LessOrEqual(page.Values.Count, 50);
            ids.AddRange(page.Values.Select(d => (string)d.Document["hotelId"]));
            Assert.NotNull(page.ContinuationToken);

            // Get the final page
            response = await client.SearchAsync<SearchDocument>(null, new SearchOptions(page.ContinuationToken));
            page = await response.Value.GetResultsAsync().AsPages().FirstAsync();
            Assert.LessOrEqual(page.Values.Count, 50);
            ids.AddRange(page.Values.Select(d => (string)d.Document["hotelId"]));
            Assert.IsNull(page.ContinuationToken);

            // Verify we saw everything
            CollectionAssert.AreEquivalent(
                Enumerable.Range(1, size).Select(i => i.ToString()),
                ids);
        }

        [Test]
        public async Task MinimumCoverage()
        {
            await using SearchResources resources = await SearchResources.GetSharedHotelsIndexAsync(this);
            Response<SearchResults<Hotel>> response =
                await resources.GetQueryClient().SearchAsync<Hotel>(
                "*",
                new SearchOptions { MinimumCoverage = 50 });
            Assert.AreEqual(100, response.Value.Coverage);
        }

        [Test]
        public async Task PagingDynamicDocuments()
        {
            const int size = 2001;
            await using SearchResources resources = await CreateLargeHotelsIndexAsync(size);
            Response<SearchResults<SearchDocument>> response =
                await resources.GetQueryClient().SearchAsync<SearchDocument>(
                    "*",
                    new SearchOptions
                    {
                        Size = 3000,
                        OrderBy = new[] { "hotelId asc" },
                        Select = new[] { "hotelId" }
                    });
            List<string> ids = new List<string>();
            await foreach (Page<SearchResult<SearchDocument>> page in response.Value.GetResultsAsync().AsPages())
            {
                Assert.LessOrEqual(page.Values.Count, 1000);
                ids.AddRange(page.Values.Select(d => (string)d.Document["hotelId"]));
            }
            CollectionAssert.AreEquivalent(
                Enumerable.Range(1, size).Select(i => i.ToString()),
                ids);
        }

        [Test]
        public async Task PagingStaticDocuments()
        {
            const int size = 2001;
            await using SearchResources resources = await CreateLargeHotelsIndexAsync(size);
            Response<SearchResults<Hotel>> response =
                await resources.GetQueryClient().SearchAsync<Hotel>(
                    "*",
                    new SearchOptions
                    {
                        Size = 3000,
                        OrderBy = new[] { "hotelId asc" },
                        Select = new[] { "hotelId" }
                    });
            List<string> ids = new List<string>();
            await foreach (Page<SearchResult<Hotel>> page in response.Value.GetResultsAsync().AsPages())
            {
                Assert.LessOrEqual(page.Values.Count, 1000);
                ids.AddRange(page.Values.Select(d => d.Document.HotelId));
            }
            CollectionAssert.AreEquivalent(
                Enumerable.Range(1, size).Select(i => i.ToString()),
                ids);
        }

        [Test]
        public async Task PagingWithoutSize()
        {
            const int size = 167;
            await using SearchResources resources = await CreateLargeHotelsIndexAsync(size);
            Response<SearchResults<Hotel>> response =
                await resources.GetQueryClient().SearchAsync<Hotel>(
                    "*",
                    new SearchOptions
                    {
                        OrderBy = new[] { "hotelId asc" },
                        Select = new[] { "hotelId" }
                    });
            List<string> ids = new List<string>();
            await foreach (Page<SearchResult<Hotel>> page in response.Value.GetResultsAsync().AsPages())
            {
                Assert.LessOrEqual(page.Values.Count, 50);
                ids.AddRange(page.Values.Select(d => d.Document.HotelId));
            }
            CollectionAssert.AreEquivalent(
                Enumerable.Range(1, size).Select(i => i.ToString()),
                ids);
        }

        /* TODO: Enable these Track 1 tests when we have support for index creation
        protected void TestCanSearchWithDateTimeInStaticModel()
        {
            SearchServiceClient serviceClient = Data.GetSearchServiceClient();

            Index index = Book.DefineIndex();
            serviceClient.Indexes.Create(index);
            SearchClient indexClient = Data.GetSearchClient(index.Name);

            var tolkien = new Author() { FirstName = "J.R.R.", LastName = "Tolkien" };
            var doc1 = new Book() { ISBN = "123", Title = "Lord of the Rings", Author = tolkien };
            var doc2 = new Book() { ISBN = "456", Title = "War and Peace", PublishDate = new DateTime(2015, 8, 18) };
            var batch = IndexBatch.Upload(new[] { doc1, doc2 });

            indexClient.Documents.Index(batch);
            SearchTestUtilities.WaitForIndexing();

            DocumentSearchResult<Book> response = indexClient.Documents.Search<Book>("War and Peace");
            Assert.Equal(1, response.Results.Count);
            Assert.Equal(doc2, response.Results[0].Document);
        }

        protected void TestCanRoundTripNonNullableValueTypes()
        {
            SearchServiceClient serviceClient = Data.GetSearchServiceClient();

            var index = new Index()
            {
                Name = SearchTestUtilities.GenerateName(),
                Fields = FieldBuilder.BuildForType<NonNullableModel>()
            };

            serviceClient.Indexes.Create(index);
            SearchClient indexClient = Data.GetSearchClient(index.Name);

            var startDate = new DateTimeOffset(2015, 11, 24, 14, 01, 00, TimeSpan.FromHours(-8));
            DateTime endDate = startDate.UtcDateTime + TimeSpan.FromDays(15);

            var doc1 = new NonNullableModel()
            {
                Key = "123",
                Count = 3,
                EndDate = endDate,
                IsEnabled = true,
                Rating = 5,
                Ratio = 3.14,
                StartDate = startDate,
                TopLevelBucket = new Bucket() { BucketName =  "A", Count = 12 },
                Buckets = new[]
                {
                    new Bucket() { BucketName = "B", Count = 20 },
                    new Bucket() { BucketName = "C", Count = 7 }
                }
            };

            var doc2 = new NonNullableModel()
            {
                Key = "456",
                Count = default(long),
                EndDate = default(DateTime),
                IsEnabled = default(bool),
                Rating = default(int),
                Ratio = default(double),
                StartDate = default(DateTimeOffset),
                TopLevelBucket = default(Bucket),
                Buckets = new[] { default(Bucket) }
            };

            var batch = IndexBatch.Upload(new[] { doc1, doc2 });

            indexClient.Documents.Index(batch);
            SearchTestUtilities.WaitForIndexing();

            DocumentSearchResult<NonNullableModel> response = indexClient.Documents.Search<NonNullableModel>("*");

            Assert.Equal(2, response.Results.Count);
            Assert.Equal(doc1, response.Results[0].Document);
            Assert.Equal(doc2, response.Results[1].Document);
        }

        protected void TestNullCannotBeConvertedToValueType()
        {
            SearchServiceClient serviceClient = Data.GetSearchServiceClient();

            var index = new Index()
            {
                Name = SearchTestUtilities.GenerateName(),
                Fields = FieldBuilder.BuildForType<ModelWithNullableValueTypes>()
            };

            serviceClient.Indexes.Create(index);
            SearchClient indexClient = Data.GetSearchClient(index.Name);

            var batch =
                IndexBatch.Upload(new[]
                {
                    new ModelWithNullableValueTypes()
                    {
                        Key = "123",
                        IntValue = null,
                        Bucket = new Bucket() { BucketName = "Z", Count = 1 }
                    },
                    new ModelWithNullableValueTypes()
                    {
                        Key = "456",
                        IntValue = 5,
                        Bucket = null
                    }
                });

            indexClient.Documents.Index(batch);
            SearchTestUtilities.WaitForIndexing();

            SerializationException e = Assert.Throws<SerializationException>(() => indexClient.Documents.Search<ModelWithValueTypes>("123"));
            Assert.Contains("Error converting value {null} to type 'System.Int32'. Path 'IntValue'.", e.ToString());

            e = Assert.Throws<SerializationException>(() => indexClient.Documents.Search<ModelWithValueTypes>("456"));
            Assert.Contains("Error converting value {null} to type 'Microsoft.Azure.Search.Tests.SearchTests+Bucket'. Path 'Bucket'.", e.ToString());
        }

        protected void TestCanFilterNonNullableType()
        {
            SearchServiceClient serviceClient = Data.GetSearchServiceClient();

            var index = new Index()
            {
                Name = SearchTestUtilities.GenerateName(),
                Fields = FieldBuilder.BuildForType<ModelWithValueTypes>()
            };

            serviceClient.Indexes.Create(index);
            SearchClient indexClient = Data.GetSearchClient(index.Name);

            var docs = new[]
            {
                new ModelWithValueTypes() { Key = "123", IntValue = 0, Bucket = new Bucket() { BucketName = "A", Count = 3 } },
                new ModelWithValueTypes() { Key = "456", IntValue = 7, Bucket = new Bucket() { BucketName = "B", Count = 5 } },
                new ModelWithValueTypes() { Key = "789", IntValue = 1, Bucket = new Bucket() { BucketName = "B", Count = 99 } }
            };

            IEnumerable<ModelWithValueTypes> expectedDocs = docs.Where(d => d.Key != "789");

            indexClient.Documents.Index(IndexBatch.Upload(docs));
            SearchTestUtilities.WaitForIndexing();

            var parameters = new SearchParameters()
            {
                Filter = "IntValue eq 0 or (Bucket/BucketName eq 'B' and Bucket/Count lt 10)"
            };

            DocumentSearchResult<ModelWithValueTypes> response = indexClient.Documents.Search<ModelWithValueTypes>("*", parameters);

            Assert.Equal(expectedDocs, response.Results.Select(r => r.Document));
        }

        protected void TestCanSearchWithCustomContractResolver()
        {
            SearchClient client = GetClientForQuery();
            client.DeserializationSettings.ContractResolver = new MyCustomContractResolver();

            DocumentSearchResult<LoudHotel> response = client.Documents.Search<LoudHotel>("Best");

            Assert.Equal(1, response.Results.Count);
            Assert.Equal(Data.TestDocuments[0], response.Results[0].Document.ToHotel());
        }

        protected void TestCanSearchWithCustomConverter()
        {
            TestCanSearchWithCustomConverter<CustomBookWithConverter, CustomAuthorWithConverter>();
        }

        protected void TestCanSearchWithCustomConverterViaSettings()
        {
            void CustomizeSettings(SearchClient client)
            {
                var bookConverter = new CustomBookConverter<CustomBook, CustomAuthor>();
                bookConverter.Install(client);

                var authorConverter = new CustomAuthorConverter<CustomAuthor>();
                authorConverter.Install(client);
            }

            TestCanSearchWithCustomConverter<CustomBook, CustomAuthor>(CustomizeSettings);
        }

        private void TestCanSearchWithCustomConverter<TBook, TAuthor>(Action<SearchClient> customizeSettings = null)
            where TBook : CustomBookBase<TAuthor>, new()
            where TAuthor : CustomAuthor, new()
        {
            customizeSettings = customizeSettings ?? (client => { });

            SearchServiceClient serviceClient = Data.GetSearchServiceClient();

            Index index = Book.DefineIndex();
            serviceClient.Indexes.Create(index);
            SearchClient indexClient = Data.GetSearchClient(index.Name);
            customizeSettings(indexClient);

            var doc = new TBook()
            {
                InternationalStandardBookNumber = "123",
                Name = "Lord of the Rings",
                AuthorName = new TAuthor() { FullName = "J.R.R. Tolkien" },
                PublishDateTime = new DateTime(1954, 7, 29)
            };

            var batch = IndexBatch.Upload(new[] { doc });

            indexClient.Documents.Index(batch);
            SearchTestUtilities.WaitForIndexing();

            DocumentSearchResult<TBook> response = indexClient.Documents.Search<TBook>("*");

            Assert.Equal(1, response.Results.Count);
            Assert.Equal(doc, response.Results[0].Document);
        }

        private struct Bucket
        {
            [IsFilterable]
            public string BucketName { get; set; }

            [IsFilterable]
            public int Count { get; set; }

            public override bool Equals(object obj) =>
                obj is Bucket other &&
                BucketName == other.BucketName &&
                Count == other.Count;

            public override int GetHashCode() => (BucketName?.GetHashCode() ?? 0) ^ Count.GetHashCode();
        }

        private class NonNullableModel
        {
            [Key]
            public string Key { get; set; }

            public int Rating { get; set; }

            public long Count { get; set; }

            public bool IsEnabled { get; set; }

            public double Ratio { get; set; }

            public DateTimeOffset StartDate { get; set; }

            public DateTime EndDate { get; set; }

            public Bucket TopLevelBucket { get; set; }

            public Bucket[] Buckets { get; set; }

            public override bool Equals(object obj) =>
                obj is NonNullableModel other &&
                Count == other.Count &&
                EndDate == other.EndDate &&
                IsEnabled == other.IsEnabled &&
                Key == other.Key &&
                Rating == other.Rating &&
                Ratio == other.Ratio &&
                StartDate == other.StartDate &&
                TopLevelBucket.Equals(other.TopLevelBucket) &&
                Buckets.SequenceEqualsNullSafe(other.Buckets);

            public override int GetHashCode() => Key?.GetHashCode() ?? 0;
        }

        private class ModelWithValueTypes
        {
            [Key]
            [IsSearchable]
            public string Key { get; set; }

            [IsFilterable]
            public int IntValue { get; set; }

            public Bucket Bucket { get; set; }

            public override bool Equals(object obj) =>
                obj is ModelWithValueTypes other &&
                Key == other.Key &&
                IntValue == other.IntValue &&
                Bucket.Equals(other.Bucket);

            public override int GetHashCode() => Key?.GetHashCode() ?? 0;
        }

        private class ModelWithNullableValueTypes
        {
            [Key]
            [IsSearchable]
            public string Key { get; set; }

            [IsFilterable]
            public int? IntValue { get; set; }

            public Bucket? Bucket { get; set; }

            public override bool Equals(object obj) =>
                obj is ModelWithValueTypes other &&
                Key == other.Key &&
                IntValue == other.IntValue &&
                Bucket.Equals(other.Bucket);

            public override int GetHashCode() => Key?.GetHashCode() ?? 0;
        }
        */
    }
}
