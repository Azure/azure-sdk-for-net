// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Tests
{
    using System;
    using System.Net;
    using Microsoft.AspNetCore.WebUtilities;
    using Microsoft.Azure.Search.Models;
    using Microsoft.Azure.Search.Tests.Utilities;
    using Microsoft.Rest.Azure;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Microsoft.Spatial;
    using Xunit;

    public sealed class LookupTests : SearchTestBase<IndexFixture>
    {
        [Fact]
        [Trait(TestTraits.AcceptanceType, TestTraits.LiveBVT)]
        public void CanGetDynamicDocument()
        {
            Run(() =>
            {
                SearchIndexClient client = Data.GetSearchIndexClient();

                var expectedDoc =
                    new Document()
                    {
                        { "hotelId", "1" },
                        { "baseRate", 199.0 },
                        { "description", "Best hotel in town" },
                        { "descriptionFr", "Meilleur hôtel en ville" },
                        { "hotelName", "Fancy Stay" },
                        { "category", "Luxury" },
                        { "tags", new[] { "pool", "view", "wifi", "concierge" } },
                        { "parkingIncluded", false },
                        { "smokingAllowed", false },
                        { "lastRenovationDate", new DateTimeOffset(2010, 6, 27, 0, 0, 0, TimeSpan.FromHours(-8)) },
                        { "rating", 5L },
                        { "location", GeographyPoint.Create(47.678581, -122.131577) }
                    };

                var batch = IndexBatch.Upload(new[] { expectedDoc });
                client.Documents.Index(batch);
                SearchTestUtilities.WaitForIndexing();

                Document actualDoc = client.Documents.Get("1");
                Assert.Equal(expectedDoc, actualDoc);
            });
        }

        [Fact]
        public void CanGetDynamicDocumentWithNullOrEmptyValues()
        {
            Run(() =>
            {
                SearchIndexClient client = Data.GetSearchIndexClient();

                var expectedDoc =
                    new Document()
                    {
                        { "hotelId", "1" },
                        { "baseRate", null },
                        { "hotelName", null },
                        { "tags", new string[0] },
                        { "parkingIncluded", null },
                        { "lastRenovationDate", null },
                        { "rating", null },
                        { "location", null }
                    };

                var batch = IndexBatch.Upload(new[] { expectedDoc });
                client.Documents.Index(batch);
                SearchTestUtilities.WaitForIndexing();

                Document actualDoc = client.Documents.Get("1", expectedDoc.Keys);
                Assert.Equal(expectedDoc, actualDoc);
            });
        }

        [Fact]
        public void GetDynamicDocumentCannotAlwaysDetermineCorrectType()
        {
            Run(() =>
            {
                SearchIndexClient client = Data.GetSearchIndexClient();

                var indexedDoc =
                    new Document()
                    {
                        { "hotelId", "1" },
                        { "baseRate", Double.NaN },
                        { "hotelName", "2015-02-11T12:58:00Z" }
                    };

                var expectedDoc =
                    new Document()
                    {
                        { "hotelId", "1" },
                        { "baseRate", "NaN" },
                        { "hotelName", new DateTimeOffset(2015, 2, 11, 12, 58, 0, TimeSpan.Zero) }
                    };

                var batch = IndexBatch.Upload(new[] { expectedDoc });
                client.Documents.Index(batch);
                SearchTestUtilities.WaitForIndexing();

                Document actualDoc = client.Documents.Get("1", indexedDoc.Keys);
                Assert.Equal(expectedDoc, actualDoc);
            });
        }

        [Fact]
        [Trait(TestTraits.AcceptanceType, TestTraits.LiveBVT)]
        public void CanGetStaticallyTypedDocument()
        {
            Run(() =>
            {
                SearchIndexClient client = Data.GetSearchIndexClient();

                var expectedDoc =
                    new Hotel()
                    {
                        HotelId = "1",
                        BaseRate = 199.0,
                        Description = "Best hotel in town",
                        DescriptionFr = "Meilleur hôtel en ville",
                        HotelName = "Fancy Stay",
                        Category = "Luxury",
                        Tags = new[] { "pool", "view", "wifi", "concierge" },
                        ParkingIncluded = false,
                        SmokingAllowed = false,
                        LastRenovationDate = new DateTimeOffset(2010, 6, 27, 0, 0, 0, TimeSpan.Zero),
                        Rating = 5,
                        Location = GeographyPoint.Create(47.678581, -122.131577)
                    };

                var batch = IndexBatch.Upload(new[] { expectedDoc });
                client.Documents.Index(batch);

                Hotel actualDoc = client.Documents.Get<Hotel>("1");
                Assert.Equal(expectedDoc, actualDoc);
            });
        }

        [Fact]
        public void CanGetDocumentWithBase64EncodedKey()
        {
            Run(() =>
            {
                SearchIndexClient client = Data.GetSearchIndexClient();
                string complexKey = WebEncoders.Base64UrlEncode(new byte[] { 1, 2, 3, 4, 5 });

                var expectedDoc =
                    new Document()
                    {
                        { "hotelId", complexKey }
                    };

                var batch = IndexBatch.Upload(new[] { expectedDoc });
                client.Documents.Index(batch);
                SearchTestUtilities.WaitForIndexing();

                Document actualDoc = client.Documents.Get(complexKey, expectedDoc.Keys);
                Assert.Equal(expectedDoc, actualDoc);
            });
        }

        [Fact]
        public void RoundTrippingDateTimeOffsetNormalizesToUtc()
        {
            Run(() =>
            {
                SearchIndexClient client = Data.GetSearchIndexClient();

                var indexedDoc =
                    new Hotel()
                    {
                        HotelId = "1",
                        LastRenovationDate = new DateTimeOffset(2010, 6, 27, 0, 0, 0, TimeSpan.FromHours(-8))
                    };

                var expectedDoc =
                    new Hotel()
                    {
                        HotelId = "1",
                        Tags = new string[0],   // null arrays become empty arrays during indexing.
                        LastRenovationDate = new DateTimeOffset(2010, 6, 27, 8, 0, 0, TimeSpan.Zero)
                    };

                var batch = IndexBatch.Upload(new[] { expectedDoc });
                client.Documents.Index(batch);

                Hotel actualDoc = client.Documents.Get<Hotel>("1");
                Assert.Equal(expectedDoc, actualDoc);
            });
        }

        [Fact]
        public void CanGetStaticallyTypedDocumentWithNullOrEmptyValues()
        {
            Run(() =>
            {
                SearchIndexClient client = Data.GetSearchIndexClient();

                var expectedDoc =
                    new Hotel()
                    {
                        HotelId = "1",
                        BaseRate = null,
                        HotelName = null,
                        Tags = new string[0],
                        ParkingIncluded = null,
                        LastRenovationDate = null,
                        Rating = null,
                        Location = null
                    };

                var batch = IndexBatch.Upload(new[] { expectedDoc });
                client.Documents.Index(batch);
                SearchTestUtilities.WaitForIndexing();

                Hotel actualDoc = client.Documents.Get<Hotel>("1");
                Assert.Equal(expectedDoc, actualDoc);
            });
        }

        [Fact]
        public void CanGetStaticallyTypedDocumentWithPascalCaseFields()
        {
            Run(() =>
            {
                SearchServiceClient serviceClient = Data.GetSearchServiceClient();

                Index index = Book.DefineIndex();
                serviceClient.Indexes.Create(index);
                SearchIndexClient indexClient = Data.GetSearchIndexClient(index.Name);

                var expectedDoc = new Book() { ISBN = "123", Title = "Lord of the Rings", Author = "J.R.R. Tolkien" };
                var batch = IndexBatch.Upload(new[] { expectedDoc });
                indexClient.Documents.Index(batch);

                Book actualDoc = indexClient.Documents.Get<Book>("123");
                Assert.Equal(expectedDoc, actualDoc);
            });
        }

        [Fact]
        public void GetStaticallyTypedDocumentSetsUnselectedFieldsToNull()
        {
            Run(() =>
            {
                SearchIndexClient client = Data.GetSearchIndexClient();

                var indexedDoc =
                    new Hotel()
                    {
                        HotelId = "2",
                        BaseRate = 79.99,
                        Description = "Cheapest hotel in town",
                        DescriptionFr = "Hôtel le moins cher en ville",
                        HotelName = "Roach Motel",
                        Category = "Budget",
                        Tags = new[] { "motel", "budget" },
                        ParkingIncluded = true,
                        SmokingAllowed = true,
                        LastRenovationDate = new DateTimeOffset(1982, 4, 28, 0, 0, 0, TimeSpan.Zero),   //aka.ms/sre-codescan/disable
                        Rating = 1,
                        Location = GeographyPoint.Create(49.678581, -122.131577)
                    };

                var expectedDoc =
                    new Hotel()
                    {
                        Description = "Cheapest hotel in town",
                        HotelName = "Roach Motel"
                    };

                var batch = IndexBatch.Upload(new[] { indexedDoc });
                client.Documents.Index(batch);

                Hotel actualDoc = client.Documents.Get<Hotel>("2", new[] { "description", "hotelName" });
                Assert.Equal(expectedDoc, actualDoc);
            });
        }

        [Fact]
        public void GetDocumentThrowsWhenDocumentNotFound()
        {
            Run(() =>
            {
                SearchIndexClient client = Data.GetSearchIndexClient();
                SearchAssert.ThrowsCloudException(() => client.Documents.Get("ThisDocumentDoesNotExist"), HttpStatusCode.NotFound);
            });
        }

        [Fact]
        public void GetDocumentThrowsWhenRequestIsMalformed()
        {
            Run(() =>
            {
                SearchIndexClient client = Data.GetSearchIndexClient();

                var indexedDoc =
                    new Hotel()
                    {
                        HotelId = "3",
                        BaseRate = 279.99,
                        Description = "Surprisingly expensive"
                    };

                var batch = IndexBatch.Upload(new[] { indexedDoc });
                client.Documents.Index(batch);

                string[] selectedFields = new[] { "hotelId", "ThisFieldDoesNotExist" };

                SearchAssert.ThrowsCloudException(
                    () => client.Documents.Get("3", selectedFields),
                    HttpStatusCode.BadRequest,
                    "Invalid expression: Could not find a property named 'ThisFieldDoesNotExist' on type 'search.document'.");
            });
        }
    }
}
