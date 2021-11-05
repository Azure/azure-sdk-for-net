// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Tests
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Net;
    using Microsoft.Azure.Search.Models;
    using Microsoft.Azure.Search.Tests.Utilities;
    using Microsoft.Rest;
    using Microsoft.Spatial;
    using Xunit;
    using FacetResults = System.Collections.Generic.IDictionary<string, System.Collections.Generic.IList<Models.FacetResult>>;
    using HitHighlights = System.Collections.Generic.IDictionary<string, System.Collections.Generic.IList<string>>;
    using Index = Microsoft.Azure.Search.Models.Index;

    // MAINTENANCE NOTE: Test methods (those marked with [Fact]) need to be in the derived classes in order for
    // the mock recording/playback to work properly.
    public abstract class SearchTests : QueryTests
    {
        protected void TestCanSearchStaticallyTypedDocuments()
        {
            SearchIndexClient client = GetClientForQuery();
            DocumentSearchResult<Hotel> response = client.Documents.Search<Hotel>("*");

            Assert.Null(response.ContinuationToken);
            Assert.Null(response.Count);
            Assert.Null(response.Coverage);
            Assert.Null(response.Facets);
            Assert.NotNull(response.Results);

            Assert.Equal(Data.TestDocuments.Length, response.Results.Count);

            for (int i = 0; i < response.Results.Count; i++)
            {
                Assert.Equal(1, response.Results[i].Score);
                Assert.Null(response.Results[i].Highlights);
            }

            Assert.Equal(response.Results.Select(r => r.Document), Data.TestDocuments);
        }

        protected void TestCanSearchDynamicDocuments()
        {
            SearchIndexClient client = GetClientForQuery();
            DocumentSearchResult<Document> response = client.Documents.Search("*");

            Assert.Null(response.ContinuationToken);
            Assert.Null(response.Count);
            Assert.Null(response.Coverage);
            Assert.Null(response.Facets);
            Assert.NotNull(response.Results);

            Assert.Equal(Data.TestDocuments.Length, response.Results.Count);

            for (int i = 0; i < response.Results.Count; i++)
            {
                Assert.Equal(1, response.Results[i].Score);
                Assert.Null(response.Results[i].Highlights);
                Assert.Equal(Data.TestDocuments[i].AsDocument(), response.Results[i].Document);
            }
        }

        protected void TestSearchThrowsWhenRequestIsMalformed()
        {
            SearchIndexClient client = GetClient();

            var invalidParameters = new SearchParameters() { Filter = "This is not a valid filter." };
            SearchAssert.ThrowsCloudException(
                () => client.Documents.Search("*", invalidParameters),
                HttpStatusCode.BadRequest,
                "Invalid expression: Syntax error at position 7 in 'This is not a valid filter.'");
        }

        protected void TestDefaultSearchModeIsAny()
        {
            SearchIndexClient client = GetClientForQuery();
            DocumentSearchResult<Hotel> response =
                client.Documents.Search<Hotel>("Cheapest hotel");

            AssertContainsKeys(response, "1", "2", "3");
        }

        protected void TestCanSearchWithSearchModeAll()
        {
            SearchIndexClient client = GetClientForQuery();

            var searchParameters =
                new SearchParameters()
                {
                    QueryType = QueryType.Simple,   // Set explicitly at least once for test coverage.
                    SearchMode = SearchMode.All
                };

            DocumentSearchResult<Hotel> response =
                client.Documents.Search<Hotel>("Cheapest hotel", searchParameters);

            AssertKeySequenceEqual(response, "2");
        }

        protected void TestCanGetResultCountInSearch()
        {
            SearchIndexClient client = GetClientForQuery();

            var searchParameters = new SearchParameters() { IncludeTotalResultCount = true };
            DocumentSearchResult<Hotel> response =
                client.Documents.Search<Hotel>("*", searchParameters);

            Assert.NotNull(response.Results);
            Assert.Equal(Data.TestDocuments.Length, response.Count);
        }

        protected void TestCanFilter()
        {
            SearchIndexClient client = GetClientForQuery();

            var searchParameters =
                new SearchParameters() { Filter = "rating gt 3 and lastRenovationDate gt 2000-01-01T00:00:00Z" };

            // Also test that searchText can be null.
            DocumentSearchResult<Hotel> response =
                client.Documents.Search<Hotel>(null, searchParameters);

            AssertKeySequenceEqual(response, "1", "5");
        }

        protected void TestCanUseHitHighlighting()
        {
            const string Description = "description";
            const string Category = "category";

            SearchIndexClient client = GetClientForQuery();

            var searchParameters =
                new SearchParameters()
                {
                    Filter = "rating eq 5",
                    HighlightPreTag = "<b>",
                    HighlightPostTag = "</b>",
                    HighlightFields = new[] { Description, Category }
                };

            DocumentSearchResult<Hotel> response =
                client.Documents.Search<Hotel>("luxury hotel", searchParameters);

            AssertKeySequenceEqual(response, "1");

            HitHighlights highlights = response.Results[0].Highlights;
            Assert.NotNull(highlights);
            Assert.Equal(2, highlights.Keys.Count);
            Assert.Contains(Description, highlights.Keys);
            Assert.Contains(Category, highlights.Keys);

            string categoryHighlight = highlights[Category].Single();
            Assert.Equal("<b>Luxury</b>", categoryHighlight);

            // Typed as IEnumerable so we get the right overload of Assert.Equals below.
            IEnumerable<string> expectedDescriptionHighlights =
                new[]
                {
                    "Best <b>hotel</b> in town if you like <b>luxury</b> <b>hotels</b>.",
                    "We highly recommend this <b>hotel</b>."
                };

            Assert.Equal(expectedDescriptionHighlights, highlights[Description]);
        }

        protected void TestOrderByProgressivelyBreaksTies()
        {
            SearchIndexClient client = GetClientForQuery();

            var searchParameters =
                new SearchParameters()
                {
                    OrderBy = new string[]
                    {
                        "rating desc",
                        "lastRenovationDate asc",
                        "geo.distance(location, geography'POINT(-122.0 49.0)')"
                    }
                };

            DocumentSearchResult<Hotel> response =
                client.Documents.Search<Hotel>("*", searchParameters);

            AssertKeySequenceEqual(response, "1", "9", "4", "3", "5", "10", "2", "6", "7", "8");
        }

        protected void TestSearchWithoutOrderBySortsByScore()
        {
            SearchIndexClient client = GetClientForQuery();

            var searchParameters = new SearchParameters() { Filter = "rating lt 4" };
            DocumentSearchResult<Hotel> response =
                client.Documents.Search<Hotel>("cheapest hotel in town", searchParameters);

            AssertKeySequenceEqual(response, "2", "10");
            Assert.True(response.Results[0].Score > response.Results[1].Score);
        }

        protected void TestCanSearchWithSelectedFields()
        {
            SearchIndexClient client = GetClientForQuery();

            var searchParameters =
                new SearchParameters()
                {
                    SearchFields = new[] { "category", "hotelName" },
                    Select = new[] { "hotelName", "rating", "address/city", "rooms/type" }
                };

            DocumentSearchResult<Hotel> response =
                client.Documents.Search<Hotel>("fancy luxury secret", searchParameters);

            var expectedDocs = new[]
            {
                new Hotel() { HotelName = "Fancy Stay", Rating = 5 },
                new Hotel()
                {
                    HotelName = "Secret Point Motel",
                    Rating = 4,
                    Address = new HotelAddress() { City = "New York" },
                    Rooms = new[] { new HotelRoom() { Type = "Budget Room" }, new HotelRoom() { Type = "Budget Room" } }
                }
            }.OrderBy(hotel => hotel.HotelName);

            var actualDocs = response.Results.Select(r => r.Document).OrderBy(hotel => hotel.HotelName);

            Assert.Equal(expectedDocs, actualDocs);
        }

        protected void TestCanSearchWithLuceneSyntax()
        {
            SearchIndexClient client = GetClientForQuery();

            var searchParameters =
                new SearchParameters()
                {
                    QueryType = QueryType.Full,
                    Select = new[] { "hotelName", "rating" }
                };

            DocumentSearchResult<Hotel> response =
                client.Documents.Search<Hotel>("hotelName:roch~", searchParameters);

            var expectedDoc = new Hotel() { HotelName = "Roach Motel", Rating = 1 };

            Assert.NotNull(response.Results);
            Assert.Equal(1, response.Results.Count);
            Assert.Equal(expectedDoc, response.Results.First().Document);
        }

        protected void TestCanSearchWithSynonyms()
        {
            SearchServiceClient searchClient = Data.GetSearchServiceClient();

            const string SynonymMapName = "names";
            var synonymMap = new SynonymMap(name: SynonymMapName, synonyms: "luxury,fancy");
            searchClient.SynonymMaps.Create(synonymMap);

            SearchIndexClient client = GetClientForQuery();
            Index index = searchClient.Indexes.Get(client.IndexName);
            index.Fields.First(f => f.Name == "hotelName").SynonymMaps = new[] { SynonymMapName };

            searchClient.Indexes.CreateOrUpdate(index);

            // When this test runs live, it runs against a free service that has 3 replicas.
            // Sometimes the synonym map update doesn't make it to the replica that handles
            // the query below, causing a test failure. We wait here to increase the odds of
            // consistency and decrease the likelihood of spurious test failures.
            SearchTestUtilities.WaitForSynonymMapUpdate();

            var searchParameters =
                new SearchParameters()
                {
                    QueryType = QueryType.Full,
                    SearchFields = new[] { "hotelName" },
                    Select = new[] { "hotelName", "rating" }
                };

            DocumentSearchResult<Hotel> response =
                client.Documents.Search<Hotel>("luxury", searchParameters);

            var expectedDoc = new Hotel() { HotelName = "Fancy Stay", Rating = 5 };

            Assert.NotNull(response.Results);
            Assert.Equal(1, response.Results.Count);
            Assert.Equal(expectedDoc, response.Results.First().Document);
        }

        protected void TestCanSearchWithRegex()
        {
            SearchIndexClient client = GetClientForQuery();

            var searchParameters =
                new SearchParameters()
                {
                    QueryType = QueryType.Full,
                    Select = new[] { "hotelName", "rating" }
                };

            DocumentSearchResult<Hotel> response =
                client.Documents.Search<Hotel>(@"hotelName:/.*oach.*\/?/", searchParameters);

            var expectedDoc = new Hotel() { HotelName = "Roach Motel", Rating = 1 };

            Assert.NotNull(response.Results);
            Assert.Equal(1, response.Results.Count);
            Assert.Equal(expectedDoc, response.Results.First().Document);
        }

        protected void TestCanSearchWithEscapedSpecialCharsInRegex()
        {
            SearchIndexClient client = GetClientForQuery();

            var searchParameters = new SearchParameters() { QueryType = QueryType.Full };

            DocumentSearchResult<Document> response =
                client.Documents.Search(@"/\+\-\&\|\!\(\)\{\}\[\]\^\""\\~\*\?\:\\\//", searchParameters);

            Assert.NotNull(response.Results);
            Assert.Equal(0, response.Results.Count);
        }

        protected void TestSearchThrowsWhenSpecialCharInRegexIsUnescaped()
        {
            SearchIndexClient client = GetClient();

            var searchParameters = new SearchParameters() { QueryType = QueryType.Full };

            SearchAssert.ThrowsCloudException(
                () => client.Documents.Search(@"/.*/.*/", searchParameters),
                HttpStatusCode.BadRequest,
                "Failed to parse query string at line 1, column 8.");
        }

        protected void TestCanUseTopAndSkipForClientSidePaging()
        {
            SearchIndexClient client = GetClientForQuery();

            var searchParameters = new SearchParameters() { Top = 3, Skip = 0, OrderBy = new[] { "hotelId" } };
            DocumentSearchResult<Hotel> response = client.Documents.Search<Hotel>("*", searchParameters);

            AssertKeySequenceEqual(response, "1", "10", "2");

            searchParameters.Skip = 3;
            response = client.Documents.Search<Hotel>("*", searchParameters);

            AssertKeySequenceEqual(response, "3", "4", "5");
        }

        protected void TestSearchWithScoringProfileBoostsScore()
        {
            SearchIndexClient client = GetClientForQuery();

            var searchParameters =
                new SearchParameters()
                {
                    ScoringProfile = "nearest",
                    ScoringParameters = new[] { new ScoringParameter("myloc", GeographyPoint.Create(49, -122)) },
                    Filter = "rating eq 5 or rating eq 1"
                };

            DocumentSearchResult<Hotel> response =
                client.Documents.Search<Hotel>("hotel", searchParameters);
            AssertKeySequenceEqual(response, "2", "1");
        }

        protected void TestCanSearchWithRangeFacets()
        {
            SearchIndexClient client = GetClientForQuery();

            var searchParameters =
                new SearchParameters()
                {
                    Facets = new[]
                    {
                        "rooms/baseRate,values:5|8|10",
                        "lastRenovationDate,values:2000-01-01T00:00:00Z"
                    }
                };

            DocumentSearchResult<Hotel> response = client.Documents.Search<Hotel>("*", searchParameters);
            AssertContainsKeys(response, Data.TestDocuments.Select(d => d.HotelId).ToArray());

            Assert.NotNull(response.Facets);

            AssertRangeFacetsEqual(
                GetRangeFacetsForField<double>(response.Facets, "rooms/baseRate", 4),
                new RangeFacetResult<double>(count: 1, from: null, to: 5.0),
                new RangeFacetResult<double>(count: 1, from: 5.0, to: 8.0),
                new RangeFacetResult<double>(count: 1, from: 8.0, to: 10.0),
                new RangeFacetResult<double>(count: 0, from: 10.0, to: null));

            AssertRangeFacetsEqual(
                GetRangeFacetsForField<DateTimeOffset>(response.Facets, "lastRenovationDate", 2),
                new RangeFacetResult<DateTimeOffset>(count: 5, from: null, to: new DateTimeOffset(2000, 1, 1, 0, 0, 0, TimeSpan.Zero)),
                new RangeFacetResult<DateTimeOffset>(count: 2, from: new DateTimeOffset(2000, 1, 1, 0, 0, 0, TimeSpan.Zero), to: null));
        }

        protected void TestCanSearchWithValueFacets()
        {
            SearchIndexClient client = GetClientForQuery();

            var searchParameters =
                new SearchParameters()
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
                };

            DocumentSearchResult<Hotel> response = client.Documents.Search<Hotel>("*", searchParameters);
            AssertContainsKeys(response, Data.TestDocuments.Select(d => d.HotelId).ToArray());

            Assert.NotNull(response.Facets);

            AssertValueFacetsEqual(
                GetValueFacetsForField<long>(response.Facets, "rating", 2),
                new ValueFacetResult<long>(1, 5),
                new ValueFacetResult<long>(4, 4));

            AssertValueFacetsEqual(
                GetValueFacetsForField<bool>(response.Facets, "smokingAllowed", 2),
                new ValueFacetResult<bool>(4, false),
                new ValueFacetResult<bool>(3, true));

            AssertValueFacetsEqual(
                GetValueFacetsForField<string>(response.Facets, "category", 3),
                new ValueFacetResult<string>(5, "Budget"),
                new ValueFacetResult<string>(1, "Boutique"),
                new ValueFacetResult<string>(1, "Luxury"));

            AssertValueFacetsEqual(
                GetValueFacetsForField<DateTimeOffset>(response.Facets, "lastRenovationDate", 6),
                new ValueFacetResult<DateTimeOffset>(1, new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)),
                new ValueFacetResult<DateTimeOffset>(1, new DateTimeOffset(1982, 1, 1, 0, 0, 0, TimeSpan.Zero)),
                new ValueFacetResult<DateTimeOffset>(2, new DateTimeOffset(1995, 1, 1, 0, 0, 0, TimeSpan.Zero)),
                new ValueFacetResult<DateTimeOffset>(1, new DateTimeOffset(1999, 1, 1, 0, 0, 0, TimeSpan.Zero)),
                new ValueFacetResult<DateTimeOffset>(1, new DateTimeOffset(2010, 1, 1, 0, 0, 0, TimeSpan.Zero)),
                new ValueFacetResult<DateTimeOffset>(1, new DateTimeOffset(2012, 1, 1, 0, 0, 0, TimeSpan.Zero)));

            AssertValueFacetsEqual(
                GetValueFacetsForField<double>(response.Facets, "rooms/baseRate", 4),
                new ValueFacetResult<double>(1, 2.44),
                new ValueFacetResult<double>(1, 7.69),
                new ValueFacetResult<double>(1, 8.09),
                new ValueFacetResult<double>(1, 9.69));

            AssertValueFacetsEqual(
                GetValueFacetsForField<string>(response.Facets, "tags", 10),
                new ValueFacetResult<string>(1, "24-hour front desk service"),
                new ValueFacetResult<string>(1, "air conditioning"),
                new ValueFacetResult<string>(4, "budget"),
                new ValueFacetResult<string>(1, "coffee in lobby"),
                new ValueFacetResult<string>(2, "concierge"),
                new ValueFacetResult<string>(1, "motel"),
                new ValueFacetResult<string>(2, "pool"),
                new ValueFacetResult<string>(1, "restaurant"),
                new ValueFacetResult<string>(1, "view"),
                new ValueFacetResult<string>(4, "wifi"));
        }

        protected void TestCanContinueSearchForStaticallyTypedDocuments()
        {
            SearchIndexClient client = GetClient();
            IEnumerable<string> hotelIds = Data.IndexDocuments(client, 2001);

            var searchParameters =
                new SearchParameters()
                {
                    Top = 3000,
                    OrderBy = new[] { "hotelId asc" },
                    Select = new[] { "hotelId" }
                };

            IEnumerable<string> expectedIds =
                Data.TestDocuments.Select(d => d.HotelId).Concat(hotelIds).OrderBy(id => id);

            DocumentSearchResult<Hotel> response = client.Documents.Search<Hotel>("*", searchParameters);
            AssertKeySequenceEqual(response, expectedIds.Take(1000).ToArray());

            Assert.NotNull(response.ContinuationToken);

            // Test that ContinueSearch still works even if you toggle GET/POST.
            client.UseHttpGetForQueries = !client.UseHttpGetForQueries;

            response = client.Documents.ContinueSearch<Hotel>(response.ContinuationToken);
            AssertKeySequenceEqual(response, expectedIds.Skip(1000).Take(1000).ToArray());

            Assert.NotNull(response.ContinuationToken);

            // Toggle GET/POST again.
            client.UseHttpGetForQueries = !client.UseHttpGetForQueries;

            response = client.Documents.ContinueSearch<Hotel>(response.ContinuationToken);
            AssertKeySequenceEqual(response, expectedIds.Last());

            Assert.Null(response.ContinuationToken);
        }

        protected void TestCanContinueSearchForDynamicDocuments()
        {
            SearchIndexClient client = GetClient();
            IEnumerable<string> hotelIds = Data.IndexDocuments(client, 2001);

            var searchParameters =
                new SearchParameters()
                {
                    Top = 3000,
                    OrderBy = new[] { "hotelId asc" },
                    Select = new[] { "hotelId" }
                };

            IEnumerable<string> expectedIds =
                Data.TestDocuments.Select(d => d.HotelId).Concat(hotelIds).OrderBy(id => id);

            DocumentSearchResult<Document> response = client.Documents.Search("*", searchParameters);
            AssertKeySequenceEqual(response, expectedIds.Take(1000).ToArray());

            Assert.NotNull(response.ContinuationToken);

            // Test that ContinueSearch still works even if you toggle GET/POST.
            client.UseHttpGetForQueries = !client.UseHttpGetForQueries;

            response = client.Documents.ContinueSearch(response.ContinuationToken);
            AssertKeySequenceEqual(response, expectedIds.Skip(1000).Take(1000).ToArray());

            Assert.NotNull(response.ContinuationToken);

            // Toggle GET/POST again.
            client.UseHttpGetForQueries = !client.UseHttpGetForQueries;

            response = client.Documents.ContinueSearch(response.ContinuationToken);
            AssertKeySequenceEqual(response, expectedIds.Last());

            Assert.Null(response.ContinuationToken);
        }

        protected void TestCanContinueSearchWithoutTop()
        {
            SearchIndexClient client = GetClient();
            IEnumerable<string> hotelIds = Data.IndexDocuments(client, 167);

            var searchParameters =
                new SearchParameters()
                {
                    OrderBy = new[] { "hotelId asc" },
                    Select = new[] { "hotelId" }
                };

            IEnumerable<string> expectedIds =
                Data.TestDocuments.Select(d => d.HotelId).Concat(hotelIds).OrderBy(id => id);

            DocumentSearchResult<Hotel> response = client.Documents.Search<Hotel>("*", searchParameters);
            AssertKeySequenceEqual(response, expectedIds.Take(50).ToArray());

            Assert.NotNull(response.ContinuationToken);

            response = client.Documents.ContinueSearch<Hotel>(response.ContinuationToken);
            AssertKeySequenceEqual(response, expectedIds.Skip(50).Take(50).ToArray());

            Assert.NotNull(response.ContinuationToken);

            response = client.Documents.ContinueSearch<Hotel>(response.ContinuationToken);
            AssertKeySequenceEqual(response, expectedIds.Skip(100).Take(50).ToArray());

            Assert.NotNull(response.ContinuationToken);

            response = client.Documents.ContinueSearch<Hotel>(response.ContinuationToken);
            AssertKeySequenceEqual(response, expectedIds.Skip(150).ToArray());

            Assert.Null(response.ContinuationToken);
        }

        protected void TestCanSearchWithMinimumCoverage()
        {
            SearchIndexClient client = GetClientForQuery();

            var parameters = new SearchParameters() { MinimumCoverage = 50 };
            DocumentSearchResult<Hotel> response = client.Documents.Search<Hotel>("*", parameters);

            Assert.Equal(100, response.Coverage);
        }

        protected void TestCanSearchWithDateTimeInStaticModel()
        {
            SearchServiceClient serviceClient = Data.GetSearchServiceClient();

            Index index = Book.DefineIndex();
            serviceClient.Indexes.Create(index);
            SearchIndexClient indexClient = Data.GetSearchIndexClient(index.Name);

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
            SearchIndexClient indexClient = Data.GetSearchIndexClient(index.Name);

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
            SearchIndexClient indexClient = Data.GetSearchIndexClient(index.Name);

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
            SearchIndexClient indexClient = Data.GetSearchIndexClient(index.Name);

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
            SearchIndexClient client = GetClientForQuery();
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
            void CustomizeSettings(SearchIndexClient client)
            {
                var bookConverter = new CustomBookConverter<CustomBook, CustomAuthor>();
                bookConverter.Install(client);

                var authorConverter = new CustomAuthorConverter<CustomAuthor>();
                authorConverter.Install(client);
            }

            TestCanSearchWithCustomConverter<CustomBook, CustomAuthor>(CustomizeSettings);
        }

        private void TestCanSearchWithCustomConverter<TBook, TAuthor>(Action<SearchIndexClient> customizeSettings = null)
            where TBook : CustomBookBase<TAuthor>, new()
            where TAuthor : CustomAuthor, new()
        {
            customizeSettings = customizeSettings ?? (client => { });

            SearchServiceClient serviceClient = Data.GetSearchServiceClient();

            Index index = Book.DefineIndex();
            serviceClient.Indexes.Create(index);
            SearchIndexClient indexClient = Data.GetSearchIndexClient(index.Name);
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

        private void AssertKeySequenceEqual(DocumentSearchResult<Hotel> response, params string[] expectedKeys)
        {
            Assert.NotNull(response.Results);

            IEnumerable<string> actualKeys = response.Results.Select(r => r.Document.HotelId);
            Assert.Equal(expectedKeys, actualKeys);
        }

        private void AssertKeySequenceEqual(DocumentSearchResult<Document> response, params string[] expectedKeys)
        {
            Assert.NotNull(response.Results);

            IEnumerable<string> actualKeys = response.Results.Select(r => (string)r.Document["hotelId"]);
            Assert.Equal(expectedKeys, actualKeys);
        }

        private void AssertContainsKeys(DocumentSearchResult<Hotel> response, params string[] expectedKeys)
        {
            Assert.NotNull(response.Results);

            IEnumerable<string> actualKeys = response.Results.Select(r => r.Document.HotelId);
            foreach (string expectedKey in expectedKeys)
            {
                Assert.Contains(expectedKey, actualKeys);
            }
        }

        private void AssertContainsKeys(DocumentSearchResult<Document> response, params string[] expectedKeys)
        {
            Assert.NotNull(response.Results);

            IEnumerable<string> actualKeys = response.Results.Select(r => (string)r.Document["hotelId"]);
            foreach (string expectedKey in expectedKeys)
            {
                Assert.Contains(expectedKey, actualKeys);
            }
        }

        private IList<FacetResult> GetFacetsForField(FacetResults facets, string expectedField, int expectedCount)
        {
            Assert.True(facets.ContainsKey(expectedField), $"Expecting facets to contain {expectedField}");
            IList<FacetResult> facetCollection = facets[expectedField];
            Assert.Equal(expectedCount, facetCollection.Count);
            return facetCollection;
        }

        private RangeFacetResult<T>[] GetRangeFacetsForField<T>(FacetResults facets, string expectedField, int expectedCount)
            where T : struct
        {
            IList<FacetResult> facetCollection = GetFacetsForField(facets, expectedField, expectedCount);
            return facetCollection.Select(f => f.AsRangeFacetResult<T>()).ToArray();
        }

        private ValueFacetResult<T>[] GetValueFacetsForField<T>(FacetResults facets, string expectedField, int expectedCount)
        {
            IList<FacetResult> facetCollection = GetFacetsForField(facets, expectedField, expectedCount);
            return facetCollection.Select(f => f.AsValueFacetResult<T>()).ToArray();
        }

        private void AssertValueFacetsEqual<T>(ValueFacetResult<T>[] actualFacets, params ValueFacetResult<T>[] expectedFacets)
        {
            Assert.Equal(actualFacets.Length, expectedFacets.Length);

            for (int i = 0; i < actualFacets.Length; i++)
            {
                Assert.Equal(expectedFacets[i].Value, actualFacets[i].Value);
                Assert.Equal(expectedFacets[i].Count, actualFacets[i].Count);
            }
        }

        private void AssertRangeFacetsEqual<T>(RangeFacetResult<T>[] actualFacets, params RangeFacetResult<T>[] expectedFacets)
            where T : struct
        {
            Assert.Equal(actualFacets.Length, expectedFacets.Length);

            for (int i = 0; i < actualFacets.Length; i++)
            {
                Assert.Equal(expectedFacets[i].To, actualFacets[i].To);
                Assert.Equal(expectedFacets[i].From, actualFacets[i].From);
                Assert.Equal(expectedFacets[i].Count, actualFacets[i].Count);
            }
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
    }
}
