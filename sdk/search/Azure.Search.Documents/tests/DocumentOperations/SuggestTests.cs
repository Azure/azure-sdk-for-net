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
    public class SuggestTests : SearchTestBase
    {
        public SuggestTests(bool async, SearchClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        private static void AssertContainsIds(SuggestResults<Hotel> suggestions, params string[] expectedKeys)
        {
            Assert.NotNull(suggestions.Results);
            CollectionAssert.AreEqual(expectedKeys, suggestions.Results.Select(r => r.Document.HotelId).ToArray());
        }

        [Test]
        public async Task SuggestDynamicDocuments()
        {
            await using SearchResources resources = await SearchResources.GetSharedHotelsIndexAsync(this);
            SuggestResults<SearchDocument> suggestions =
                await resources.GetQueryClient().SuggestAsync<SearchDocument>(
                    "more",
                    "sg",
                    new SuggestOptions { OrderBy = new[] { "hotelId" } });

            IEnumerable<SearchDocument> expected =
                SearchResources.TestDocuments
                .Where(h => h.HotelId == "8" || h.HotelId == "10")
                .OrderBy(h => h.HotelId)
                .Select(h => h.AsDocument());

            Assert.Null(suggestions.Coverage);
            Assert.NotNull(suggestions.Results);
            CollectionAssert.AreEqual(
                expected.Select(d => d["hotelId"]),
                suggestions.Results.Select(r => r.Document["hotelId"]));
            CollectionAssert.AreEqual(
                expected.Select(d => d["description"]),
                suggestions.Results.Select(r => r.Text));
        }

        [Test]
        public async Task SuggestStaticDocuments()
        {
            await using SearchResources resources = await SearchResources.GetSharedHotelsIndexAsync(this);
            SuggestResults<Hotel> suggestions =
                await resources.GetQueryClient().SuggestAsync<Hotel>(
                    "more",
                    "sg",
                    new SuggestOptions { OrderBy = new[] { "hotelId" } });

            IEnumerable<Hotel> expected =
                SearchResources.TestDocuments
                .Where(h => h.HotelId == "8" || h.HotelId == "10")
                .OrderBy(h => h.HotelId);

            Assert.Null(suggestions.Coverage);
            Assert.NotNull(suggestions.Results);
            CollectionAssert.AreEqual(
                expected.Select(h => h.HotelId),
                suggestions.Results.Select(r => r.Document.HotelId));
            CollectionAssert.AreEqual(
                expected.Select(h => h.Description),
                suggestions.Results.Select(r => r.Text));
        }

        [Test]
        public async Task ThrowsWhenRequestIsMalformed()
        {
            await using SearchResources resources = await SearchResources.GetSharedHotelsIndexAsync(this);
            RequestFailedException ex = await CatchAsync<RequestFailedException>(
                async () => await resources.GetQueryClient().SuggestAsync<SearchDocument>(
                    "hotel",
                    "sg",
                    new SuggestOptions { OrderBy = new[] { "This is not a valid orderby." } }));
            Assert.AreEqual(400, ex.Status);
            StringAssert.StartsWith(
                "Invalid expression: Syntax error at position 7 in 'This is not a valid orderby.'",
                ex.Message);
        }

        [Test]
        public async Task ThrowsWhenGivenBadSuggesterName()
        {
            await using SearchResources resources = await SearchResources.GetSharedHotelsIndexAsync(this);
            string invalidName = "Invalid suggester";
            RequestFailedException ex = await CatchAsync<RequestFailedException>(
                async () => await resources.GetQueryClient().SuggestAsync<SearchDocument>(
                    "hotel",
                    invalidName));
            Assert.AreEqual(400, ex.Status);
            StringAssert.StartsWith(
                $"The specified suggester name '{invalidName}' does not exist in this index definition.",
                ex.Message);
        }

        [Test]
        public async Task FuzzyOffByDefault()
        {
            await using SearchResources resources = await SearchResources.GetSharedHotelsIndexAsync(this);
            SuggestResults<Hotel> suggestions =
                await resources.GetQueryClient().SuggestAsync<Hotel>("hitel", "sg");
            Assert.NotNull(suggestions);
            Assert.NotNull(suggestions.Results);
            Assert.Zero(suggestions.Results.Count);
        }

        [Test]
        public async Task Fuzzy()
        {
            await using SearchResources resources = await SearchResources.GetSharedHotelsIndexAsync(this);
            SuggestResults<Hotel> suggestions =
                await resources.GetQueryClient().SuggestAsync<Hotel>(
                    "hitel",
                    "sg",
                    new SuggestOptions { UseFuzzyMatching = true });
            Assert.NotNull(suggestions);
            Assert.NotNull(suggestions.Results);
            Assert.AreEqual(5, suggestions.Results.Count);
        }

        [Test]
        public async Task Filter()
        {
            await using SearchResources resources = await SearchResources.GetSharedHotelsIndexAsync(this);
            SuggestResults<Hotel> suggestions =
                await resources.GetQueryClient().SuggestAsync<Hotel>(
                    "hotel",
                    "sg",
                    new SuggestOptions
                    {
                        Filter = "rating gt 3 and lastRenovationDate gt 2000-01-01T00:00:00Z",
                        // Use OrderBy so changes in ranking don't break the test
                        OrderBy = new[] { "hotelId" }
                    });
            AssertContainsIds(suggestions, "1", "5");
        }

        [Test]
        public async Task HitHighlighting()
        {
            await using SearchResources resources = await SearchResources.GetSharedHotelsIndexAsync(this);
            SuggestResults<Hotel> suggestions =
                await resources.GetQueryClient().SuggestAsync<Hotel>(
                    "hotel",
                    "sg",
                    new SuggestOptions
                    {
                        HighlightPreTag = "<b>",
                        HighlightPostTag = "</b>",
                        Filter = "category eq 'Luxury'",
                        Size = 1
                    });
            AssertContainsIds(suggestions, "1");
            StringAssert.StartsWith("Best <b>hotel</b> in town", suggestions.Results.First().Text);
        }

        [Test]
        public async Task OrderByProgressivelyBreaksTies()
        {
            await using SearchResources resources = await SearchResources.GetSharedHotelsIndexAsync(this);
            SuggestResults<Hotel> suggestions =
                await resources.GetQueryClient().SuggestAsync<Hotel>(
                    "hotel",
                    "sg",
                    new SuggestOptions
                    {
                        OrderBy = new string[]
                        {
                            "rating desc",
                            "lastRenovationDate asc",
                            "geo.distance(location, geography'POINT(-122.0 49.0)')"
                        }
                    });
            AssertContainsIds(suggestions, "1", "9", "4", "3", "5");
        }

        [Test]
        public async Task SizeTrimsResults()
        {
            await using SearchResources resources = await SearchResources.GetSharedHotelsIndexAsync(this);
            SuggestResults<Hotel> suggestions =
                await resources.GetQueryClient().SuggestAsync<Hotel>(
                    "hotel",
                    "sg",
                    new SuggestOptions
                    {
                        OrderBy = new string[] { "hotelId" },
                        Size = 3
                    });
            AssertContainsIds(suggestions, "1", "10", "2");
        }

        [Test]
        public async Task SelectedFields()
        {
            await using SearchResources resources = await SearchResources.GetSharedHotelsIndexAsync(this);
            SuggestResults<Hotel> suggestions =
                await resources.GetQueryClient().SuggestAsync<Hotel>(
                    "secret",
                    "sg",
                    new SuggestOptions
                    {
                        Select = new[] { "hotelName", "rating", "address/city", "rooms/type" }
                    });

            var expected = new Hotel
            {
                HotelName = "Secret Point Motel",
                Rating = 4,
                Address = new HotelAddress() { City = "New York" },
                Rooms = new[] { new HotelRoom() { Type = "Budget Room" }, new HotelRoom() { Type = "Budget Room" } }
            };

            Assert.AreEqual(1, suggestions.Results.Count);
            Assert.AreEqual(expected, suggestions.Results.First().Document);
        }

        [Test]
        public async Task ExcludeFieldsFromSuggest()
        {
            await using SearchResources resources = await SearchResources.GetSharedHotelsIndexAsync(this);
            SuggestResults<Hotel> suggestions =
                await resources.GetQueryClient().SuggestAsync<Hotel>(
                    "luxury",
                    "sg",
                    new SuggestOptions
                    {
                        SearchFields = new[] { "hotelName" }
                    });
            Assert.AreEqual(0, suggestions.Results.Count);
        }

        [Test]
        public async Task MinimumCoverage()
        {
            await using SearchResources resources = await SearchResources.GetSharedHotelsIndexAsync(this);
            SuggestResults<Hotel> suggestions =
                await resources.GetQueryClient().SuggestAsync<Hotel>(
                    "luxury",
                    "sg",
                    new SuggestOptions { MinimumCoverage = 50 });
            Assert.AreEqual(100, suggestions.Coverage);
        }

        /*
         * Remaining Track 1 tests
         *

        protected void TestCanSuggestWithDateTimeInStaticModel()
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

            var parameters = new SuggestParameters() { Select = new[] { "ISBN", "Title", "PublishDate" } };
            DocumentSuggestResult<Book> response = indexClient.Documents.Suggest<Book>("War", "sg", parameters);
            Assert.Equal(1, response.Results.Count);
            Assert.Equal(doc2, response.Results[0].Document);
        }

        protected void TestCanSuggestWithCustomContractResolver()
        {
            SearchClient client = GetClientForQuery();
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
            void CustomizeSettings(SearchClient client)
            {
                var bookConverter = new CustomBookConverter<CustomBook, CustomAuthor>();
                bookConverter.Install(client);

                var authorConverter = new CustomAuthorConverter<CustomAuthor>();
                authorConverter.Install(client);
            }

            TestCanSuggestWithCustomConverter<CustomBook, CustomAuthor>(CustomizeSettings);
        }

        private void TestCanSuggestWithCustomConverter<TBook, TAuthor>(Action<SearchClient> customizeSettings = null)
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

            var parameters = new SuggestParameters() { Select = new[] { "*" } };
            DocumentSuggestResult<TBook> response = indexClient.Documents.Suggest<TBook>("Lord", "sg", parameters);

            Assert.Equal(1, response.Results.Count);
            Assert.Equal(doc, response.Results[0].Document);
        }
        */
    }
}
