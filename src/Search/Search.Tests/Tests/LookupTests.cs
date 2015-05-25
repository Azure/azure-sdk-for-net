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
using System.Linq;
using System.Net;
using System.Web;
using Hyak.Common;
using Microsoft.Azure.Search.Models;
using Microsoft.Azure.Search.Tests.Utilities;
using Microsoft.Azure.Test;
using Microsoft.Azure.Test.TestCategories;
using Microsoft.Spatial;
using Xunit;

namespace Microsoft.Azure.Search.Tests
{
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

                var batch = new IndexBatch(new[] { new IndexAction(expectedDoc) });
                client.Documents.Index(batch);
                SearchTestUtilities.WaitForIndexing();

                DocumentGetResponse getResponse = client.Documents.Get("1");
                Assert.Equal(HttpStatusCode.OK, getResponse.StatusCode);
                SearchAssert.DocumentsEqual(expectedDoc, getResponse.Document);
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

                var batch = new IndexBatch(new[] { new IndexAction(expectedDoc) });
                client.Documents.Index(batch);
                SearchTestUtilities.WaitForIndexing();

                DocumentGetResponse getResponse = client.Documents.Get("1", expectedDoc.Keys);
                Assert.Equal(HttpStatusCode.OK, getResponse.StatusCode);
                SearchAssert.DocumentsEqual(expectedDoc, getResponse.Document);
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

                var batch = new IndexBatch(new[] { new IndexAction(indexedDoc) });
                client.Documents.Index(batch);
                SearchTestUtilities.WaitForIndexing();

                DocumentGetResponse getResponse = client.Documents.Get("1", indexedDoc.Keys);
                Assert.Equal(HttpStatusCode.OK, getResponse.StatusCode);
                SearchAssert.DocumentsEqual(expectedDoc, getResponse.Document);
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

                var batch = IndexBatch.Create(IndexAction.Create(expectedDoc));
                client.Documents.Index(batch);

                DocumentGetResponse<Hotel> response = client.Documents.Get<Hotel>("1");
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
                Assert.Equal(expectedDoc, response.Document);
            });
        }

        [Fact]
        public void CanGetDocumentWithBase64EncodedKey()
        {
            Run(() =>
            {
                SearchIndexClient client = Data.GetSearchIndexClient();
                string complexKey = HttpServerUtility.UrlTokenEncode(new byte[] { 1, 2, 3, 4, 5 });

                var expectedDoc =
                    new Document()
                    {
                        { "hotelId", complexKey }
                    };

                var batch = new IndexBatch(new[] { new IndexAction(expectedDoc) });
                client.Documents.Index(batch);
                SearchTestUtilities.WaitForIndexing();

                DocumentGetResponse getResponse = client.Documents.Get(complexKey, expectedDoc.Keys);
                Assert.Equal(HttpStatusCode.OK, getResponse.StatusCode);
                SearchAssert.DocumentsEqual(expectedDoc, getResponse.Document);
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

                var batch = IndexBatch.Create(IndexAction.Create(indexedDoc));
                client.Documents.Index(batch);

                DocumentGetResponse<Hotel> response = client.Documents.Get<Hotel>("1");
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
                Assert.Equal(expectedDoc, response.Document);
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

                var batch = IndexBatch.Create(IndexAction.Create(expectedDoc));
                client.Documents.Index(batch);
                SearchTestUtilities.WaitForIndexing();

                DocumentGetResponse<Hotel> getResponse = client.Documents.Get<Hotel>("1");
                Assert.Equal(HttpStatusCode.OK, getResponse.StatusCode);
                Assert.Equal(expectedDoc, getResponse.Document);
            });
        }

        [Fact]
        public void CanGetStaticallyTypedDocumentWithPascalCaseFields()
        {
            Run(() =>
            {
                SearchServiceClient serviceClient = Data.GetSearchServiceClient();

                Index index =
                    new Index()
                    {
                        Name = TestUtilities.GenerateName(),
                        Fields = new[]
                        {
                            new Field("ISBN", DataType.String) { IsKey = true },
                            new Field("Title", DataType.String),
                            new Field("Author", DataType.String)
                        }
                    };

                IndexDefinitionResponse createIndexResponse = serviceClient.Indexes.Create(index);
                Assert.Equal(HttpStatusCode.Created, createIndexResponse.StatusCode);

                SearchIndexClient indexClient = Data.GetSearchIndexClient(createIndexResponse.Index.Name);

                var expectedDoc = new Book() { ISBN = "123", Title = "Lord of the Rings", Author = "J.R.R. Tolkien" };
                var batch = IndexBatch.Create(IndexAction.Create(expectedDoc));
                indexClient.Documents.Index(batch);

                DocumentGetResponse<Book> response = indexClient.Documents.Get<Book>("123");
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
                Assert.Equal(expectedDoc, response.Document);
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
                        LastRenovationDate = new DateTimeOffset(1982, 4, 28, 0, 0, 0, TimeSpan.Zero),
                        Rating = 1,
                        Location = GeographyPoint.Create(49.678581, -122.131577)
                    };

                var expectedDoc =
                    new Hotel()
                    {
                        Description = "Cheapest hotel in town",
                        HotelName = "Roach Motel"
                    };

                var batch = IndexBatch.Create(IndexAction.Create(indexedDoc));
                client.Documents.Index(batch);

                DocumentGetResponse<Hotel> response =
                    client.Documents.Get<Hotel>("2", new[] { "description", "hotelName" });
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
                Assert.Equal(expectedDoc, response.Document);
            });
        }

        [Fact]
        public void GetDocumentThrowsWhenDocumentNotFound()
        {
            Run(() =>
            {
                SearchIndexClient client = Data.GetSearchIndexClient();

                CloudException e = 
                    Assert.Throws<CloudException>(() => client.Documents.Get("ThisDocumentDoesNotExist"));

                Assert.Equal(HttpStatusCode.NotFound, e.Response.StatusCode);
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

                var batch = IndexBatch.Create(IndexAction.Create(indexedDoc));
                client.Documents.Index(batch);

                string[] selectedFields = new[] { "hotelId", "ThisFieldDoesNotExist" };

                CloudException e = Assert.Throws<CloudException>(() => client.Documents.Get("3", selectedFields));

                Assert.Equal(HttpStatusCode.BadRequest, e.Response.StatusCode);
                Assert.Contains(
                    "Invalid expression: Could not find a property named 'ThisFieldDoesNotExist' on type 'search.document'.",
                    e.Message);
            });
        }
    }
}
