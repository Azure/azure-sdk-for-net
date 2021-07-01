// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Net;
    using Microsoft.Azure.Search.Models;
    using Microsoft.Azure.Search.Tests.Utilities;
    using Xunit;
    using Index = Microsoft.Azure.Search.Models.Index;

    // MAINTENANCE NOTE: Test methods (those marked with [Fact]) need to be in the derived classes in order for
    // the mock recording/playback to work properly.
    public abstract class SuggestTests : QueryTests
    {
        protected void TestCanSuggestStaticallyTypedDocuments()
        {
            SearchIndexClient client = GetClientForQuery();

            var suggestParameters = new SuggestParameters() { OrderBy = new[] { "hotelId" } };
            DocumentSuggestResult<Hotel> response =
                client.Documents.Suggest<Hotel>("more", "sg", suggestParameters);

            Assert.Null(response.Coverage);
            Assert.NotNull(response.Results);

            IEnumerable<Hotel> expectedDocs =
                Data.TestDocuments.Where(h => h.HotelId == "8" || h.HotelId == "10").OrderBy(h => h.HotelId);

            Assert.Equal(expectedDocs, response.Results.Select(r => r.Document));
            Assert.Equal(expectedDocs.Select(h => h.Description), response.Results.Select(r => r.Text));
        }

        protected void TestCanSuggestDynamicDocuments()
        {
            SearchIndexClient client = GetClientForQuery();

            var suggestParameters = new SuggestParameters() { OrderBy = new[] { "hotelId" } };
            DocumentSuggestResult<Document> response = client.Documents.Suggest("more", "sg", suggestParameters);

            Assert.Null(response.Coverage);
            Assert.NotNull(response.Results);

            Document[] expectedDocs =
                Data.TestDocuments
                    .Where(h => h.HotelId == "8" || h.HotelId == "10")
                    .OrderBy(h => h.HotelId)
                    .Select(h => h.AsDocument())
                    .ToArray();

            Assert.Equal(expectedDocs, response.Results.Select(r => r.Document));
            Assert.Equal(expectedDocs.Select(d => d["description"]), response.Results.Select(r => r.Text));
        }

        protected void TestSuggestThrowsWhenRequestIsMalformed()
        {
            SearchIndexClient client = GetClient();

            var invalidParameters = new SuggestParameters() { OrderBy = new[] { "This is not a valid orderby." } };
            SearchAssert.ThrowsCloudException(
                () => client.Documents.Suggest("hotel", "sg", invalidParameters),
                HttpStatusCode.BadRequest,
                "Invalid expression: Syntax error at position 7 in 'This is not a valid orderby.'");
        }

        protected void TestSuggestThrowsWhenGivenBadSuggesterName()
        {
            SearchIndexClient client = GetClient();

            SearchAssert.ThrowsCloudException(
                () => client.Documents.Suggest("hotel", "Suggester does not exist", new SuggestParameters()),
                HttpStatusCode.BadRequest,
                "The specified suggester name 'Suggester does not exist' does not exist in this index definition.");
        }

        protected void TestFuzzyIsOffByDefault()
        {
            SearchIndexClient client = GetClientForQuery();
            DocumentSuggestResult<Hotel> response =
                client.Documents.Suggest<Hotel>("hitel", "sg");

            Assert.NotNull(response.Results);
            Assert.Equal(0, response.Results.Count);
        }

        protected void TestCanGetFuzzySuggestions()
        {
            SearchIndexClient client = GetClientForQuery();

            var suggestParameters = new SuggestParameters() { UseFuzzyMatching = true };
            DocumentSuggestResult<Hotel> response =
                client.Documents.Suggest<Hotel>("hitel", "sg", suggestParameters);

            Assert.NotNull(response.Results);
            Assert.Equal(5, response.Results.Count);
        }

        protected void TestCanFilter()
        {
            SearchIndexClient client = GetClientForQuery();

            var suggestParameters =
                new SuggestParameters()
                {
                    Filter = "rating gt 3 and lastRenovationDate gt 2000-01-01T00:00:00Z",
                    OrderBy = new[] { "hotelId" }   // Use OrderBy so changes in ranking don't break the test.
                };

            DocumentSuggestResult<Hotel> response =
                client.Documents.Suggest<Hotel>("hotel", "sg", suggestParameters);

            AssertKeySequenceEqual(response, "1", "5");
        }

        protected void TestCanUseHitHighlighting()
        {
            SearchIndexClient client = GetClientForQuery();

            var suggestParameters =
                new SuggestParameters()
                {
                    HighlightPreTag = "<b>",
                    HighlightPostTag = "</b>",
                    Filter = "category eq 'Luxury'",
                    Top = 1
                };

            DocumentSuggestResult<Hotel> response =
                client.Documents.Suggest<Hotel>("hotel", "sg", suggestParameters);

            AssertKeySequenceEqual(response, "1");

            Assert.True(
                response.Results[0].Text.StartsWith("Best <b>hotel</b> in town", StringComparison.Ordinal),
                String.Format(CultureInfo.InvariantCulture, "Actual text: {0}", response.Results[0].Text));
        }

        protected void TestOrderByProgressivelyBreaksTies()
        {
            SearchIndexClient client = GetClientForQuery();

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

            DocumentSuggestResult<Hotel> response =
                client.Documents.Suggest<Hotel>("hotel", "sg", suggestParameters);

            AssertKeySequenceEqual(response, "1", "9", "4", "3", "5");
        }

        protected void TestTopTrimsResults()
        {
            SearchIndexClient client = GetClientForQuery();

            var suggestParameters =
                new SuggestParameters()
                {
                    OrderBy = new string[] { "hotelId" },
                    Top = 3
                };

            DocumentSuggestResult<Hotel> response =
                client.Documents.Suggest<Hotel>("hotel", "sg", suggestParameters);

            AssertKeySequenceEqual(response, "1", "10", "2");
        }

        protected void TestCanSuggestWithSelectedFields()
        {
            SearchIndexClient client = GetClientForQuery();

            var suggestParameters =
                new SuggestParameters()
                {
                    Select = new[] { "hotelName", "rating", "address/city", "rooms/type" }
                };

            DocumentSuggestResult<Hotel> response =
                client.Documents.Suggest<Hotel>("secret", "sg", suggestParameters);

            var expectedDoc = new Hotel()
            {
                HotelName = "Secret Point Motel",
                Rating = 4,
                Address = new HotelAddress() { City = "New York" },
                Rooms = new[] { new HotelRoom() { Type = "Budget Room" }, new HotelRoom() { Type = "Budget Room" } }
            };

            Assert.Equal(1, response.Results.Count);
            Assert.Equal(expectedDoc, response.Results.First().Document);
        }

        protected void TestSearchFieldsExcludesFieldsFromSuggest()
        {
            SearchIndexClient client = GetClientForQuery();

            var suggestParameters =
                new SuggestParameters()
                {
                    SearchFields = new[] { "hotelName" },
                };

            DocumentSuggestResult<Hotel> response =
                client.Documents.Suggest<Hotel>("luxury", "sg", suggestParameters);

            Assert.NotNull(response.Results);
            Assert.Equal(0, response.Results.Count);
        }

        protected void TestCanSuggestWithMinimumCoverage()
        {
            SearchIndexClient client = GetClientForQuery();

            var parameters = new SuggestParameters() { MinimumCoverage = 50 };
            DocumentSuggestResult<Hotel> response = client.Documents.Suggest<Hotel>("luxury", "sg", parameters);

            Assert.Equal(100, response.Coverage);
        }

        protected void TestCanSuggestWithDateTimeInStaticModel()
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

            var parameters = new SuggestParameters() { Select = new[] { "ISBN", "Title", "PublishDate" } };
            DocumentSuggestResult<Book> response = indexClient.Documents.Suggest<Book>("War", "sg", parameters);
            Assert.Equal(1, response.Results.Count);
            Assert.Equal(doc2, response.Results[0].Document);
        }

        protected void TestCanSuggestWithCustomContractResolver()
        {
            SearchIndexClient client = GetClientForQuery();
            client.DeserializationSettings.ContractResolver = new MyCustomContractResolver();

            var parameters = new SuggestParameters() { Select = new[] { "*" } };
            DocumentSuggestResult<LoudHotel> response = client.Documents.Suggest<LoudHotel>("Best", "sg", parameters);

            Assert.Equal(1, response.Results.Count);
            Assert.Equal(Data.TestDocuments[0], response.Results[0].Document.ToHotel());
        }

        protected void TestCanSuggestWithCustomConverter()
        {
            TestCanSuggestWithCustomConverter<CustomBookWithConverter, CustomAuthorWithConverter>();
        }

        protected void TestCanSuggestWithCustomConverterViaSettings()
        {
            void CustomizeSettings(SearchIndexClient client)
            {
                var bookConverter = new CustomBookConverter<CustomBook, CustomAuthor>();
                bookConverter.Install(client);

                var authorConverter = new CustomAuthorConverter<CustomAuthor>();
                authorConverter.Install(client);
            }

            TestCanSuggestWithCustomConverter<CustomBook, CustomAuthor>(CustomizeSettings);
        }

        private void TestCanSuggestWithCustomConverter<TBook, TAuthor>(Action<SearchIndexClient> customizeSettings = null)
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

            var parameters = new SuggestParameters() { Select = new[] { "*" } };
            DocumentSuggestResult<TBook> response = indexClient.Documents.Suggest<TBook>("Lord", "sg", parameters);

            Assert.Equal(1, response.Results.Count);
            Assert.Equal(doc, response.Results[0].Document);
        }

        private void AssertKeySequenceEqual(DocumentSuggestResult<Hotel> response, params string[] expectedKeys)
        {
            Assert.NotNull(response.Results);

            IEnumerable<string> actualKeys = response.Results.Select(r => r.Document.HotelId);
            Assert.Equal(expectedKeys, actualKeys);
        }
    }
}
