// 
// Copyright (c) Microsoft.  All rights reserved. 
// 
// Licensed under the Apache License, Version 2.0 (the "License"); 
// you may not use this file except in compliance with the License. 
// You may obtain a copy of the License at 
//   http://www.apache.org/licenses/LICENSE-2.0 
// 
// Unless required by applicable law or agreed to in writing, software 
// distributed under the License is distributed on an "AS IS" BASIS, 
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. 
// See the License for the specific language governing permissions and 
// limitations under the License. 
// 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Hyak.Common;
using Microsoft.Azure.Search.Models;
using Microsoft.Azure.Search.Tests.Utilities;
using Microsoft.Azure.Test;
using Microsoft.Azure.Test.TestCategories;
using Xunit;

namespace Microsoft.Azure.Search.Tests
{
    // MAINTENANCE NOTE: Test methods (those marked with [Fact]) need to be in the derived classes in order for
    // the mock recording/playback to work properly.
    public abstract class SearchTests : QueryTests
    {
        protected void TestCanSearchStaticallyTypedDocuments()
        {
            SearchIndexClient client = GetClientForQuery();
            DocumentSearchResponse<Hotel> response = client.Documents.Search<Hotel>("*");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
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
                
            SearchAssert.SequenceEqual(response.Results.Select(r => r.Document), Data.TestDocuments);
        }

        protected void TestCanSearchDynamicDocuments()
        {
            SearchIndexClient client = GetClientForQuery();
            DocumentSearchResponse response = client.Documents.Search("*");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
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
                SearchAssert.DocumentsEqual(Data.TestDocuments[i].AsDocument(), response.Results[i].Document);
            }
        }

        protected void TestSearchThrowsWhenRequestIsMalformed()
        {
            SearchIndexClient client = GetClient();

            var invalidParameters = new SearchParameters() { Filter = "This is not a valid filter." };
            CloudException e = 
                Assert.Throws<CloudException>(() => client.Documents.Search("*", invalidParameters));

            Assert.Equal(HttpStatusCode.BadRequest, e.Response.StatusCode);
            Assert.Contains(
                "Invalid expression: Syntax error at position 7 in 'This is not a valid filter.'",
                e.Message);
        }

        protected void TestDefaultSearchModeIsAny()
        {
            SearchIndexClient client = GetClientForQuery();
            DocumentSearchResponse<Hotel> response = 
                client.Documents.Search<Hotel>("Cheapest hotel");

            AssertContainsKeys(response, "1", "2", "3");
        }

        protected void TestCanSearchWithSearchModeAll()
        {
            SearchIndexClient client = GetClientForQuery();

            var searchParameters = new SearchParameters() { SearchMode = SearchMode.All };
            DocumentSearchResponse<Hotel> response =
                client.Documents.Search<Hotel>("Cheapest hotel", searchParameters);

            AssertKeySequenceEqual(response, "2");
        }

        protected void TestCanGetResultCountInSearch()
        {
            SearchIndexClient client = GetClientForQuery();

            var searchParameters = new SearchParameters() { IncludeTotalResultCount = true };
            DocumentSearchResponse<Hotel> response =
                client.Documents.Search<Hotel>("*", searchParameters);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.NotNull(response.Results);
            Assert.Equal(Data.TestDocuments.Length, response.Count);
        }

        protected void TestCanFilter()
        {
            SearchIndexClient client = GetClientForQuery();

            var searchParameters = 
                new SearchParameters() { Filter = "rating gt 3 and lastRenovationDate gt 2000-01-01T00:00:00Z" };

            // Also test that searchText can be null.
            DocumentSearchResponse<Hotel> response =
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
                    HighlightPostTag = "</b>"
                };
                
            // Try using the collection without initializing it to make sure it is lazily initialized.
            searchParameters.HighlightFields.Add(Description);
            searchParameters.HighlightFields.Add(Category);

            DocumentSearchResponse<Hotel> response = 
                client.Documents.Search<Hotel>("luxury hotel", searchParameters);
                
            AssertKeySequenceEqual(response, "1");

            HitHighlights highlights = response.Results[0].Highlights;
            Assert.NotNull(highlights);
            SearchAssert.SequenceEqual(new[] { Description, Category }, highlights.Keys);

            string categoryHighlight = highlights[Category].Single();
            Assert.Equal("<b>Luxury</b>", categoryHighlight);

            string[] expectedDescriptionHighlights =
                new[] 
                { 
                    "Best <b>hotel</b> in town if you like <b>luxury</b> hotels.",
                    "We highly recommend this <b>hotel</b>."
                };

            SearchAssert.SequenceEqual(expectedDescriptionHighlights, highlights[Description]);
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
                
            DocumentSearchResponse<Hotel> response =
                client.Documents.Search<Hotel>("*", searchParameters);

            AssertKeySequenceEqual(response, "1", "4", "3", "5", "2", "6");
        }

        protected void TestSearchWithoutOrderBySortsByScore()
        {
            SearchIndexClient client = GetClientForQuery();

            var searchParameters = new SearchParameters() { Filter = "baseRate gt 190" };
            DocumentSearchResponse<Hotel> response =
                client.Documents.Search<Hotel>("surprisingly expensive hotel", searchParameters);

            AssertKeySequenceEqual(response, "6", "1");
            Assert.True(response.Results[0].Score > response.Results[1].Score);
        }

        protected void TestCanSearchWithSelectedFields()
        {
            SearchIndexClient client = GetClientForQuery();

            var searchParameters =
                new SearchParameters()
                {
                    SearchFields = new[] { "category", "hotelName" },
                    Select = new[] { "hotelName", "baseRate" }
                };

            DocumentSearchResponse<Hotel> response =
                client.Documents.Search<Hotel>("fancy luxury", searchParameters);

            var expectedDoc = new Hotel() { HotelName = "Fancy Stay", BaseRate = 199.0 };

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.NotNull(response.Results);
            Assert.Equal(1, response.Results.Count);
            Assert.Equal(expectedDoc, response.Results.First().Document);
        }

        protected void TestCanUseTopAndSkipForClientSidePaging()
        {
            SearchIndexClient client = GetClientForQuery();

            var searchParameters = new SearchParameters() { Top = 3, Skip = 0, OrderBy = new[] { "hotelId" } };
            DocumentSearchResponse<Hotel> response = client.Documents.Search<Hotel>("*", searchParameters);

            AssertKeySequenceEqual(response, "1", "2", "3");

            searchParameters.Skip = 3;
            response = client.Documents.Search<Hotel>("*", searchParameters);

            AssertKeySequenceEqual(response, "4", "5", "6");
        }

        protected void TestSearchWithScoringProfileBoostsScore()
        {
            SearchIndexClient client = GetClientForQuery();

            var searchParameters = 
                new SearchParameters() 
                { 
                    ScoringProfile = "nearest", 
                    ScoringParameters = new[] { "myloc:-122,49" },
                    Filter = "rating eq 5 or rating eq 1"
                };
                
            DocumentSearchResponse<Hotel> response = 
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
                        "baseRate,values:80|150|200",
                        "lastRenovationDate,values:2000-01-01T00:00:00Z"
                    }
                };

            DocumentSearchResponse<Hotel> response = client.Documents.Search<Hotel>("*", searchParameters);
            AssertContainsKeys(response, Data.TestDocuments.Select(d => d.HotelId).ToArray());

            Assert.NotNull(response.Facets);

            RangeFacetResult<double>[] baseRateFacets = GetRangeFacetsForField<double>(response.Facets, "baseRate", 4);
                
            Assert.False(baseRateFacets[0].From.HasValue);
            Assert.Equal(80.0, baseRateFacets[0].To);
            Assert.Equal(80.0, baseRateFacets[1].From);
            Assert.Equal(150.0, baseRateFacets[1].To);
            Assert.Equal(150.0, baseRateFacets[2].From);
            Assert.Equal(200.0, baseRateFacets[2].To);
            Assert.Equal(200.0, baseRateFacets[3].From);
            Assert.False(baseRateFacets[3].To.HasValue);

            Assert.Equal(1, baseRateFacets[0].Count);
            Assert.Equal(3, baseRateFacets[1].Count);
            Assert.Equal(1, baseRateFacets[2].Count);
            Assert.Equal(1, baseRateFacets[3].Count);

            RangeFacetResult<DateTimeOffset>[] lastRenovationDateFacets =
                GetRangeFacetsForField<DateTimeOffset>(response.Facets, "lastRenovationDate", 2);

            Assert.False(lastRenovationDateFacets[0].From.HasValue);
            Assert.Equal(new DateTimeOffset(2000, 1, 1, 0, 0, 0, TimeSpan.Zero), lastRenovationDateFacets[0].To);
            Assert.Equal(new DateTimeOffset(2000, 1, 1, 0, 0, 0, TimeSpan.Zero), lastRenovationDateFacets[1].From);
            Assert.False(lastRenovationDateFacets[1].To.HasValue);

            Assert.Equal(3, lastRenovationDateFacets[0].Count);
            Assert.Equal(2, lastRenovationDateFacets[1].Count);
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
                        "baseRate,sort:value",
                        "tags,sort:value"
                    }
                };

            DocumentSearchResponse<Hotel> response = client.Documents.Search<Hotel>("*", searchParameters);
            AssertContainsKeys(response, Data.TestDocuments.Select(d => d.HotelId).ToArray());

            Assert.NotNull(response.Facets);

            AssertValueFacetsEqual(
                GetValueFacetsForField<long>(response.Facets, "rating", 2), 
                new ValueFacetResult<long>(1, 5), 
                new ValueFacetResult<long>(3, 4));
                
            AssertValueFacetsEqual(
                GetValueFacetsForField<bool>(response.Facets, "smokingAllowed", 2), 
                new ValueFacetResult<bool>(4, false), 
                new ValueFacetResult<bool>(1, true));

            AssertValueFacetsEqual(
                GetValueFacetsForField<string>(response.Facets, "category", 2),
                new ValueFacetResult<string>(4, "Budget"),
                new ValueFacetResult<string>(1, "Luxury"));

            AssertValueFacetsEqual(
                GetValueFacetsForField<DateTimeOffset>(response.Facets, "lastRenovationDate", 4),
                new ValueFacetResult<DateTimeOffset>(1, new DateTimeOffset(1982, 1, 1, 0, 0, 0, TimeSpan.Zero)),
                new ValueFacetResult<DateTimeOffset>(2, new DateTimeOffset(1995, 1, 1, 0, 0, 0, TimeSpan.Zero)),
                new ValueFacetResult<DateTimeOffset>(1, new DateTimeOffset(2010, 1, 1, 0, 0, 0, TimeSpan.Zero)),
                new ValueFacetResult<DateTimeOffset>(1, new DateTimeOffset(2012, 1, 1, 0, 0, 0, TimeSpan.Zero)));

            AssertValueFacetsEqual(
                GetValueFacetsForField<double>(response.Facets, "baseRate", 4),
                new ValueFacetResult<double>(1, 79.99),
                new ValueFacetResult<double>(3, 129.99),
                new ValueFacetResult<double>(1, 199.0),
                new ValueFacetResult<double>(1, 279.99));

            AssertValueFacetsEqual(
                GetValueFacetsForField<string>(response.Facets, "tags", 6),
                new ValueFacetResult<string>(4, "budget"),
                new ValueFacetResult<string>(1, "concierge"),
                new ValueFacetResult<string>(1, "motel"),
                new ValueFacetResult<string>(1, "pool"),
                new ValueFacetResult<string>(1, "view"),
                new ValueFacetResult<string>(4, "wifi"));
        }

        protected void TestCanContinueSearchForStaticallyTypedDocuments()
        {
            SearchIndexClient client = GetClient();
            IEnumerable<string> hotelIds = IndexDocuments(client, 2001);

            var searchParameters =
                new SearchParameters()
                {
                    Top = 3000,
                    OrderBy = new[] { "hotelId asc" },
                    Select = new[] { "hotelId" }
                };

            IEnumerable<string> expectedIds =
                Data.TestDocuments.Select(d => d.HotelId).Concat(hotelIds).OrderBy(id => id);

            DocumentSearchResponse<Hotel> response = client.Documents.Search<Hotel>("*", searchParameters);
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
            IEnumerable<string> hotelIds = IndexDocuments(client, 2001);

            var searchParameters =
                new SearchParameters()
                {
                    Top = 3000,
                    OrderBy = new[] { "hotelId asc" },
                    Select = new[] { "hotelId" }
                };

            IEnumerable<string> expectedIds =
                Data.TestDocuments.Select(d => d.HotelId).Concat(hotelIds).OrderBy(id => id);

            DocumentSearchResponse response = client.Documents.Search("*", searchParameters);
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
            IEnumerable<string> hotelIds = IndexDocuments(client, 167);

            var searchParameters =
                new SearchParameters()
                {
                    OrderBy = new[] { "hotelId asc" },
                    Select = new[] { "hotelId" }
                };

            IEnumerable<string> expectedIds =
                Data.TestDocuments.Select(d => d.HotelId).Concat(hotelIds).OrderBy(id => id);

            DocumentSearchResponse<Hotel> response = client.Documents.Search<Hotel>("*", searchParameters);
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
            DocumentSearchResponse<Hotel> response = client.Documents.Search<Hotel>("*", parameters);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(100, response.Coverage);
        }

        protected void TestCanSearchWithDateTimeInStaticModel()
        {
            SearchServiceClient serviceClient = Data.GetSearchServiceClient();

            Index index =
                new Index()
                {
                    Name = TestUtilities.GenerateName(),
                    Fields = new[]
                    {
                        new Field("ISBN", DataType.String) { IsKey = true },
                        new Field("Title", DataType.String) { IsSearchable = true },
                        new Field("Author", DataType.String),
                        new Field("PublishDate", DataType.DateTimeOffset)
                    }
                };

            IndexDefinitionResponse createIndexResponse = serviceClient.Indexes.Create(index);
            SearchIndexClient indexClient = Data.GetSearchIndexClient(createIndexResponse.Index.Name);

            var doc1 = new Book() { ISBN = "123", Title = "Lord of the Rings", Author = "J.R.R. Tolkien" };
            var doc2 = new Book() { ISBN = "456", Title = "War and Peace", PublishDate = new DateTime(2015, 8, 18) };
            var batch = IndexBatch.Create(IndexAction.Create(doc1), IndexAction.Create(doc2));
                
            indexClient.Documents.Index(batch);
            SearchTestUtilities.WaitForIndexing();

            DocumentSearchResponse<Book> response = indexClient.Documents.Search<Book>("War and Peace");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(1, response.Results.Count);
            Assert.Equal(doc2, response.Results[0].Document);
        }

        private IEnumerable<string> IndexDocuments(SearchIndexClient client, int totalDocCount)
        {
            int existingDocumentCount = Data.TestDocuments.Length;

            IEnumerable<string> hotelIds =
                Enumerable.Range(existingDocumentCount + 1, totalDocCount - existingDocumentCount)
                .Select(id => id.ToString());

            IEnumerable<Hotel> hotels = hotelIds.Select(id => new Hotel() { HotelId = id });
            List<IndexAction<Hotel>> actions = hotels.Select(h => IndexAction.Create(h)).ToList();

            for (int i = 0; i < actions.Count; i += 1000)
            {
                IEnumerable<IndexAction<Hotel>> nextActions = actions.Skip(i).Take(1000);

                if (!nextActions.Any())
                {
                    break;
                }

                var batch = IndexBatch.Create(nextActions);
                client.Documents.Index(batch);

                SearchTestUtilities.WaitForIndexing();
            }

            return hotelIds;
        }

        private void AssertKeySequenceEqual(DocumentSearchResponse<Hotel> response, params string[] expectedKeys)
        {
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.NotNull(response.Results);

            IEnumerable<string> actualKeys = response.Results.Select(r => r.Document.HotelId);
            SearchAssert.SequenceEqual(expectedKeys, actualKeys);
        }

        private void AssertKeySequenceEqual(DocumentSearchResponse response, params string[] expectedKeys)
        {
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.NotNull(response.Results);

            IEnumerable<string> actualKeys = response.Results.Select(r => (string)r.Document["hotelId"]);
            SearchAssert.SequenceEqual(expectedKeys, actualKeys);
        }

        private void AssertContainsKeys(DocumentSearchResponse<Hotel> response, params string[] expectedKeys)
        {
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.NotNull(response.Results);

            IEnumerable<string> actualKeys = response.Results.Select(r => r.Document.HotelId);
            foreach (string expectedKey in expectedKeys)
            {
                Assert.Contains(expectedKey, actualKeys);
            }
        }

        private void AssertContainsKeys(DocumentSearchResponse response, params string[] expectedKeys)
        {
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.NotNull(response.Results);

            IEnumerable<string> actualKeys = response.Results.Select(r => (string)r.Document["hotelId"]);
            foreach (string expectedKey in expectedKeys)
            {
                Assert.Contains(expectedKey, actualKeys);
            }
        }

        private IList<FacetResult> GetFacetsForField(FacetResults facets, string expectedField, int expectedCount)
        {
            Assert.True(facets.ContainsKey(expectedField));
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
    }
}
