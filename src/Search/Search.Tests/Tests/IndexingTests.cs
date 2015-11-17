// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Tests
{
    using System;
    using System.Linq;
    using System.Net;
    using Microsoft.Azure.Search.Models;
    using Microsoft.Azure.Search.Tests.Utilities;
    using Microsoft.Rest.Azure;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Microsoft.Spatial;
    using Xunit;

    public sealed class IndexingTests : SearchTestBase<IndexFixture>
    {
        [Fact]
        [Trait(TestTraits.AcceptanceType, TestTraits.LiveBVT)]
        public void CanIndexDynamicDocuments()
        {
            Run(() =>
            {
                SearchIndexClient client = Data.GetSearchIndexClient();

                var batch = new IndexBatch(new[]
                {
                    new IndexAction(
                        IndexActionType.Upload, 
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
                            { "rating", 5 },
                            { "location", GeographyPoint.Create(47.678581, -122.131577) }
                        }),
                    new IndexAction(
                        IndexActionType.Upload,
                        new Document()
                        {
                            { "hotelId", "2" },
                            { "baseRate", 79.99 },
                            { "description", "Cheapest hotel in town" },
                            { "descriptionFr", "Hôtel le moins cher en ville" },
                            { "hotelName", "Roach Motel" },
                            { "category", "Budget" },
                            { "tags", new[] { "motel", "budget" } },
                            { "parkingIncluded", true },
                            { "smokingAllowed", true },
                            { "lastRenovationDate", new DateTimeOffset(1982, 4, 28, 0, 0, 0, TimeSpan.Zero) },
                            { "rating", 1 },
                            { "location", GeographyPoint.Create(49.678581, -122.131577) }
                        }),
                    new IndexAction(
                        IndexActionType.Merge,
                        new Document()
                        {
                            { "hotelId", "3" },
                            { "baseRate", 279.99 },
                            { "description", "Surprisingly expensive" },
                            { "lastRenovationDate", null }
                        }),
                    new IndexAction(IndexActionType.Delete, new Document() { { "hotelId", "4" } }),
                    new IndexAction(
                        IndexActionType.MergeOrUpload,
                        new Document()
                        {
                            { "hotelId", "5" },
                            { "baseRate", Double.NaN },
                            { "hotelName", null },
                            { "tags", new string[0] }
                        })
                });

                IndexBatchException e = Assert.Throws<IndexBatchException>(() => client.Documents.Index(batch));
                AssertIsPartialFailure(e, batch, "3");

                Assert.Equal(5, e.IndexingResults.Count);

                AssertIndexActionSucceeded("1", e.IndexingResults[0]);
                AssertIndexActionSucceeded("2", e.IndexingResults[1]);
                AssertIndexActionFailed("3", e.IndexingResults[2], "Document not found.");
                AssertIndexActionSucceeded("4", e.IndexingResults[3]);
                AssertIndexActionSucceeded("5", e.IndexingResults[4]);

                SearchTestUtilities.WaitForIndexing();

                Assert.Equal(3L, client.Documents.Count());
            });
        }

        [Fact]
        [Trait(TestTraits.AcceptanceType, TestTraits.LiveBVT)]
        public void CanIndexStaticallyTypedDocuments()
        {
            Run(() =>
            {
                SearchIndexClient client = Data.GetSearchIndexClient();

                var batch = IndexBatch.Create(new[]
                {
                    IndexAction.Create(
                        IndexActionType.Upload,
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
                            LastRenovationDate = new DateTimeOffset(2010, 6, 27, 0, 0, 0, TimeSpan.FromHours(-8)),
                            Rating = 5,
                            Location = GeographyPoint.Create(47.678581, -122.131577)
                        }),
                    IndexAction.Create(
                        IndexActionType.Upload,
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
                        }),
                    IndexAction.Create(
                        IndexActionType.Merge,
                        new Hotel()
                        {
                            HotelId = "3",
                            BaseRate = 279.99,
                            Description = "Surprisingly expensive",
                            LastRenovationDate = null
                        }),
                    IndexAction.Create(IndexActionType.Delete, new Hotel() { HotelId = "4" }),
                    IndexAction.Create(
                        IndexActionType.MergeOrUpload,
                        new Hotel()
                        {
                            HotelId = "5",
                            BaseRate = Double.NaN,
                            HotelName = null,
                            Tags = new string[0]
                        })
                });

                IndexBatchException e = Assert.Throws<IndexBatchException>(() => client.Documents.Index(batch));
                AssertIsPartialFailure(e, batch, "3");

                Assert.Equal(5, e.IndexingResults.Count);

                AssertIndexActionSucceeded("1", e.IndexingResults[0]);
                AssertIndexActionSucceeded("2", e.IndexingResults[1]);
                AssertIndexActionFailed("3", e.IndexingResults[2], "Document not found.");
                AssertIndexActionSucceeded("4", e.IndexingResults[3]);
                AssertIndexActionSucceeded("5", e.IndexingResults[4]);

                SearchTestUtilities.WaitForIndexing();

                Assert.Equal(3, client.Documents.Count());
            });
        }

        [Fact]
        public void IndexDoesNotThrowWhenAllActionsSucceed()
        {
            Run(() =>
            {
                SearchIndexClient client = Data.GetSearchIndexClient();

                var batch = IndexBatch.Create(new[] { IndexAction.Create(new Hotel() { HotelId = "1" }) });

                DocumentIndexResult documentIndexResult = client.Documents.Index(batch);

                Assert.Equal(1, documentIndexResult.Results.Count);
                AssertIndexActionSucceeded("1", documentIndexResult.Results[0]);
            });
        }

        [Fact]
        public void CanIndexWithPascalCaseFields()
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

                serviceClient.Indexes.Create(index);
                SearchIndexClient indexClient = Data.GetSearchIndexClient(index.Name);

                var batch =
                    IndexBatch.Create(
                        new[] 
                        { 
                            IndexAction.Create(
                                new Book() { ISBN = "123", Title = "Lord of the Rings", Author = "J.R.R. Tolkien" }) 
                        });

                DocumentIndexResult indexResponse = indexClient.Documents.Index(batch);

                Assert.Equal(1, indexResponse.Results.Count);
                AssertIndexActionSucceeded("123", indexResponse.Results[0]);
            });
        }

        [Fact]
        public void StaticallyTypedDateTimesRoundTripAsUtc()
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
                            new Field("PublishDate", DataType.DateTimeOffset)
                        }
                    };

                serviceClient.Indexes.Create(index);
                SearchIndexClient indexClient = Data.GetSearchIndexClient(index.Name);

                // Can't test local date time since we might be testing against a pre-recorded mock response.
                DateTime utcDateTime = new DateTime(2000, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                DateTime unspecifiedDateTime = new DateTime(2000, 1, 1, 0, 0, 0, DateTimeKind.Unspecified);

                var batch =
                    IndexBatch.Create(
                        new[] 
                        { 
                            IndexAction.Create(new Book() { ISBN = "1", PublishDate = utcDateTime }),
                            IndexAction.Create(new Book() { ISBN = "2", PublishDate = unspecifiedDateTime })
                        });

                indexClient.Documents.Index(batch);
                SearchTestUtilities.WaitForIndexing();

                Book book = indexClient.Documents.Get<Book>("1");
                Assert.Equal(utcDateTime, book.PublishDate);

                book = indexClient.Documents.Get<Book>("2");
                Assert.Equal(utcDateTime, book.PublishDate);
            });
        }

        [Fact]
        public void DynamicDocumentDateTimesRoundTripAsUtc()
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
                            new Field("PublishDate", DataType.DateTimeOffset)
                        }
                    };

                serviceClient.Indexes.Create(index);
                SearchIndexClient indexClient = Data.GetSearchIndexClient(index.Name);

                // Can't test local date time since we might be testing against a pre-recorded mock response.
                DateTime utcDateTime = new DateTime(2000, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                DateTime unspecifiedDateTime = new DateTime(2000, 1, 1, 0, 0, 0, DateTimeKind.Unspecified);

                var batch =
                    new IndexBatch(
                        new[] 
                        { 
                            new IndexAction(new Document() { { "ISBN", "1" }, { "PublishDate", utcDateTime } }),
                            new IndexAction(new Document() { { "ISBN", "2" }, { "PublishDate", unspecifiedDateTime } })
                        });

                indexClient.Documents.Index(batch);
                SearchTestUtilities.WaitForIndexing();

                Document book = indexClient.Documents.Get("1");
                Assert.Equal(new DateTimeOffset(utcDateTime), book["PublishDate"]);

                book = indexClient.Documents.Get("2");
                Assert.Equal(new DateTimeOffset(utcDateTime), book["PublishDate"]);
            });
        }

        [Fact]
        public void IndexWithInvalidDocumentThrowsException()
        {
            Run(() =>
            {
                SearchIndexClient client = Data.GetSearchIndexClient();

                var batch = new IndexBatch(new[] { new IndexAction(new Document()) });

                CloudException e = Assert.Throws<CloudException>(() => client.Documents.Index(batch));
                Assert.Equal(HttpStatusCode.BadRequest, e.Response.StatusCode);
                Assert.Contains(
                    "The request is invalid. Details: actions : 0: Document key cannot be missing or empty.",
                    e.Message);
            });
        }

        [Fact]
        public void CountingDocsOfNewIndexGivesZero()
        {
            Run(() =>
            {
                SearchIndexClient client = Data.GetSearchIndexClient();

                Assert.Equal(0L, client.Documents.Count());
            });
        }

        private static void AssertIsPartialFailure(
            IndexBatchException e, 
            IndexBatch batch, 
            params string[] failedKeys)
        {
            Assert.Equal((HttpStatusCode)207, e.Response.StatusCode);

            const string KeyFieldName = "hotelId";
            IndexBatch retryBatch = e.FindFailedActionsToRetry(batch, KeyFieldName);
            Assert.Equal(failedKeys.Length, retryBatch.Actions.Count());
            SearchAssert.SequenceEqual(failedKeys, retryBatch.Actions.Select(a => a.Document[KeyFieldName].ToString()));
        }

        private static void AssertIsPartialFailure(
            IndexBatchException e, 
            IndexBatch<Hotel> batch, 
            params string[] failedKeys)
        {
            Assert.Equal((HttpStatusCode)207, e.Response.StatusCode);

            IndexBatch<Hotel> retryBatch = e.FindFailedActionsToRetry(batch, a => a.HotelId);
            Assert.Equal(failedKeys.Length, retryBatch.Actions.Count());
            SearchAssert.SequenceEqual(failedKeys, retryBatch.Actions.Select(a => a.Document.HotelId));
        }

        private static void AssertIndexActionFailed(string key, IndexingResult result, string expectedMessage)
        {
            Assert.Equal(key, result.Key);
            Assert.False(result.Succeeded);
            Assert.Equal(expectedMessage, result.ErrorMessage);
        }

        private static void AssertIndexActionSucceeded(string key, IndexingResult result)
        {
            Assert.Equal(key, result.Key);
            Assert.True(result.Succeeded);
            Assert.Null(result.ErrorMessage);
        }
    }
}
