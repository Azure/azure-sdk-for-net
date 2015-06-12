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
using Microsoft.Azure.Test.TestCategories;
using Xunit;

namespace Microsoft.Azure.Search.Tests
{
    public sealed class SuggestTests : SearchTestBase<DocumentsFixture>
    {
        [Fact]
        [Trait(TestTraits.AcceptanceType, TestTraits.LiveBVT)]
        public void CanSuggestStaticallyTypedDocuments()
        {
            Run(() =>
            {
                SearchIndexClient client = Data.GetSearchIndexClientForQuery();

                var suggestParameters = new SuggestParameters() { OrderBy = new[] { "hotelId" } };
                DocumentSuggestResponse<Hotel> response =
                    client.Documents.Suggest<Hotel>("good", "sg", suggestParameters);

                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
                Assert.NotNull(response.Results);

                IEnumerable<Hotel> expectedDocs =
                    Data.TestDocuments.Where(h => h.HotelId == "4" || h.HotelId == "5").OrderBy(h => h.HotelId);
                
                SearchAssert.SequenceEqual(
                    expectedDocs,
                    response.Results.Select(r => r.Document));

                SearchAssert.SequenceEqual(
                    expectedDocs.Select(h => h.Description),
                    response.Results.Select(r => r.Text));
            });
        }

        [Fact]
        [Trait(TestTraits.AcceptanceType, TestTraits.LiveBVT)]
        public void CanSuggestDynamicDocuments()
        {
            Run(() =>
            {
                SearchIndexClient client = Data.GetSearchIndexClientForQuery();

                var suggestParameters = new SuggestParameters() { OrderBy = new[] { "hotelId" } };
                DocumentSuggestResponse response = client.Documents.Suggest("good", "sg", suggestParameters);

                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
                Assert.NotNull(response.Results);

                Document[] expectedDocs =
                    Data.TestDocuments
                        .Where(h => h.HotelId == "4" || h.HotelId == "5")
                        .OrderBy(h => h.HotelId)
                        .Select(h => h.AsDocument())
                        .ToArray();

                Assert.Equal(expectedDocs.Length, response.Results.Count);
                for (int i = 0; i < expectedDocs.Length; i++)
                {
                    SearchAssert.DocumentsEqual(expectedDocs[i], response.Results[i].Document);
                    Assert.Equal(expectedDocs[i]["description"], response.Results[i].Text);
                }
            });
        }

        [Fact]
        public void SuggestThrowsWhenRequestIsMalformed()
        {
            Run(() =>
            {
                SearchIndexClient client = Data.GetSearchIndexClient();

                var invalidParameters = new SuggestParameters() { OrderBy = new[] { "This is not a valid orderby." } };
                CloudException e =
                    Assert.Throws<CloudException>(() => client.Documents.Suggest("hotel", "sg", invalidParameters));

                Assert.Equal(HttpStatusCode.BadRequest, e.Response.StatusCode);
                Assert.Contains(
                    "Invalid expression: Syntax error at position 7 in 'This is not a valid orderby.'",
                    e.Message);
            });
        }

        [Fact]
        public void SuggestThrowsWhenGivenBadSuggesterName()
        {
            Run(() =>
            {
                SearchIndexClient client = Data.GetSearchIndexClient();

                CloudException e =
                    Assert.Throws<CloudException>(
                        () => client.Documents.Suggest("hotel", "Suggester does not exist", new SuggestParameters()));

                Assert.Equal(HttpStatusCode.BadRequest, e.Response.StatusCode);
                Assert.Contains(
                    "The specified suggester name 'Suggester does not exist' does not exist in this index definition.",
                    e.Message);
            });
        }

        [Fact]
        public void FuzzyIsOffByDefault()
        {
            Run(() =>
            {
                SearchIndexClient client = Data.GetSearchIndexClientForQuery();
                DocumentSuggestResponse<Hotel> response =
                    client.Documents.Suggest<Hotel>("hitel", "sg");

                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
                Assert.NotNull(response.Results);
                Assert.Equal(0, response.Results.Count);
            });
        }

        [Fact]
        public void CanGetFuzzySuggestions()
        {
            Run(() =>
            {
                SearchIndexClient client = Data.GetSearchIndexClientForQuery();

                var suggestParameters = new SuggestParameters() { UseFuzzyMatching = true };
                DocumentSuggestResponse<Hotel> response =
                    client.Documents.Suggest<Hotel>("hitel", "sg", suggestParameters);

                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
                Assert.NotNull(response.Results);
                Assert.Equal(5, response.Results.Count);
            });
        }

        [Fact]
        public void CanFilter()
        {
            Run(() =>
            {
                SearchIndexClient client = Data.GetSearchIndexClientForQuery();

                var suggestParameters =
                    new SuggestParameters() { Filter = "rating gt 3 and lastRenovationDate gt 2000-01-01T00:00:00Z" };
                DocumentSuggestResponse<Hotel> response =
                    client.Documents.Suggest<Hotel>("hotel", "sg", suggestParameters);

                AssertKeySequenceEqual(response, "1", "5");
            });
        }

        [Fact]
        public void CanUseHitHighlighting()
        {
            Run(() =>
            {
                SearchIndexClient client = Data.GetSearchIndexClientForQuery();

                var suggestParameters =
                    new SuggestParameters()
                    {
                        HighlightPreTag = "<b>",
                        HighlightPostTag = "</b>",
                        Filter = "category eq 'Luxury'",
                        Top = 1
                    };

                DocumentSuggestResponse<Hotel> response =
                    client.Documents.Suggest<Hotel>("hotel", "sg", suggestParameters);

                AssertKeySequenceEqual(response, "1");

                // Note: Highlighting is not perfect due to the way Azure Search builds edge n-grams for suggestions.
                Assert.True(
                    response.Results[0].Text.StartsWith("Best <b>hotel in</b> town", StringComparison.Ordinal));
            });
        }

        [Fact]
        public void OrderByProgressivelyBreaksTies()
        {
            Run(() =>
            {
                SearchIndexClient client = Data.GetSearchIndexClientForQuery();

                var suggestParameters =
                    new SuggestParameters()
                    {
                        OrderBy = new string[] 
                        { 
                            "rating desc",
                            "lastRenovationDate asc",
                            "geo.distance(location, geography'POINT(-122.0 49.0)')"
                        }
                    };

                DocumentSuggestResponse<Hotel> response =
                    client.Documents.Suggest<Hotel>("hotel", "sg", suggestParameters);

                AssertKeySequenceEqual(response, "1", "4", "3", "5", "2");
            });
        }

        [Fact]
        public void TopTrimsResults()
        {
            Run(() =>
            {
                SearchIndexClient client = Data.GetSearchIndexClientForQuery();

                var suggestParameters =
                    new SuggestParameters()
                    {
                        OrderBy = new string[] { "hotelId" },
                        Top = 3
                    };

                DocumentSuggestResponse<Hotel> response =
                    client.Documents.Suggest<Hotel>("hotel", "sg", suggestParameters);

                AssertKeySequenceEqual(response, "1", "2", "3");
            });
        }

        [Fact]
        public void CanSuggestWithSelectedFields()
        {
            Run(() =>
            {
                SearchIndexClient client = Data.GetSearchIndexClientForQuery();

                var suggestParameters =
                    new SuggestParameters()
                    {
                        Select = new[] { "hotelName", "baseRate" }
                    };

                DocumentSuggestResponse<Hotel> response =
                    client.Documents.Suggest<Hotel>("luxury", "sg", suggestParameters);

                var expectedDoc = new Hotel() { HotelName = "Fancy Stay", BaseRate = 199.0 };

                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
                Assert.NotNull(response.Results);
                Assert.Equal(1, response.Results.Count);
                Assert.Equal(expectedDoc, response.Results.First().Document);
            });
        }

        [Fact]
        public void SearchFieldsExcludesFieldsFromSuggest()
        {
            Run(() =>
            {
                SearchIndexClient client = Data.GetSearchIndexClientForQuery();

                var suggestParameters =
                    new SuggestParameters()
                    {
                        SearchFields = new[] { "hotelName" },
                    };

                DocumentSuggestResponse<Hotel> response =
                    client.Documents.Suggest<Hotel>("luxury", "sg", suggestParameters);

                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
                Assert.NotNull(response.Results);
                Assert.Equal(0, response.Results.Count);
            });
        }

        private void AssertKeySequenceEqual(DocumentSuggestResponse<Hotel> response, params string[] expectedKeys)
        {
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.NotNull(response.Results);

            IEnumerable<string> actualKeys = response.Results.Select(r => r.Document.HotelId);
            SearchAssert.SequenceEqual(expectedKeys, actualKeys);
        }
    }
}
