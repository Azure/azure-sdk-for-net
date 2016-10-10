// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using Microsoft.Azure.Search.Models;
    using Microsoft.Azure.Search.Tests.Utilities;
    using Microsoft.Rest.Azure;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Microsoft.Spatial;
    using Newtonsoft.Json.Serialization;
    using Rest.Serialization;
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

                var batch = IndexBatch.New(new[]
                {
                    IndexAction.Upload(
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
                    IndexAction.Upload(
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
                            { "lastRenovationDate", new DateTimeOffset(1982, 4, 28, 0, 0, 0, TimeSpan.Zero) },  //aka.ms/sre-codescan/disable
                            { "rating", 1 },
                            { "location", GeographyPoint.Create(49.678581, -122.131577) }
                        }),
                    IndexAction.Merge(
                        new Document()
                        {
                            { "hotelId", "3" },
                            { "baseRate", 279.99 },
                            { "description", "Surprisingly expensive" },
                            { "lastRenovationDate", null }
                        }),
                    IndexAction.Delete(keyName: "hotelId", keyValue: "4"),
                    IndexAction.MergeOrUpload(
                        new Document()
                        {
                            { "hotelId", "5" },
                            { "baseRate", Double.NaN },
                            { "hotelName", null },
                            { "tags", new string[0] }
                        })
                });

                IndexBatchException e = Assert.Throws<IndexBatchException>(() => client.Documents.Index(batch));
                AssertIsPartialFailure(e, "3");

                Assert.Equal(5, e.IndexingResults.Count);

                AssertIndexActionSucceeded("1", e.IndexingResults[0], 201);
                AssertIndexActionSucceeded("2", e.IndexingResults[1], 201);
                AssertIndexActionFailed("3", e.IndexingResults[2], "Document not found.", 404);
                AssertIndexActionSucceeded("4", e.IndexingResults[3], 200);
                AssertIndexActionSucceeded("5", e.IndexingResults[4], 201);

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

                var batch = IndexBatch.New(new[]
                {
                    IndexAction.Upload(
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
                    IndexAction.Upload(
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
                        }),
                    IndexAction.Merge(
                        new Hotel()
                        {
                            HotelId = "3",
                            BaseRate = 279.99,
                            Description = "Surprisingly expensive",
                            LastRenovationDate = null
                        }),
                    IndexAction.Delete(new Hotel() { HotelId = "4" }),
                    IndexAction.MergeOrUpload(
                        new Hotel()
                        {
                            HotelId = "5",
                            BaseRate = Double.NaN,
                            HotelName = null,
                            Tags = new string[0]
                        })
                });

                IndexBatchException e = Assert.Throws<IndexBatchException>(() => client.Documents.Index(batch));
                AssertIsPartialFailure(e, "3");

                Assert.Equal(5, e.IndexingResults.Count);

                AssertIndexActionSucceeded("1", e.IndexingResults[0], 201);
                AssertIndexActionSucceeded("2", e.IndexingResults[1], 201);
                AssertIndexActionFailed("3", e.IndexingResults[2], "Document not found.", 404);
                AssertIndexActionSucceeded("4", e.IndexingResults[3], 200);
                AssertIndexActionSucceeded("5", e.IndexingResults[4], 201);

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

                var batch = IndexBatch.Upload(new[] { new Hotel() { HotelId = "1" } });

                DocumentIndexResult documentIndexResult = client.Documents.Index(batch);

                Assert.Equal(1, documentIndexResult.Results.Count);
                AssertIndexActionSucceeded("1", documentIndexResult.Results[0], 201);
            });
        }

        [Fact]
        public void IndexDoesNotThrowWhenDeletingDocumentWithExtraFields()
        {
            Run(() =>
            {
                SearchIndexClient client = Data.GetSearchIndexClient();

                var document = new Hotel() { HotelId = "1", Category = "Luxury" };
                var batch = IndexBatch.Upload(new[] { document });

                client.Documents.Index(batch);
                SearchTestUtilities.WaitForIndexing();

                Assert.Equal(1, client.Documents.Count());

                document.Category = "ignored";
                batch = IndexBatch.Delete(new[] { document });

                DocumentIndexResult documentIndexResult = client.Documents.Index(batch);
                SearchTestUtilities.WaitForIndexing();

                Assert.Equal(1, documentIndexResult.Results.Count);
                AssertIndexActionSucceeded("1", documentIndexResult.Results[0], 200);

                Assert.Equal(0, client.Documents.Count());
            });
        }

        [Fact]
        public void IndexDoesNotThrowWhenDeletingDynamicDocumentWithExtraFields()
        {
            Run(() =>
            {
                SearchIndexClient client = Data.GetSearchIndexClient();

                var document = new Document() { { "hotelId", "1" }, { "category", "Luxury" } };
                var batch = IndexBatch.Upload(new[] { document });

                client.Documents.Index(batch);
                SearchTestUtilities.WaitForIndexing();

                Assert.Equal(1, client.Documents.Count());

                document["category"] = "ignored";
                batch = IndexBatch.Delete(new[] { document });

                DocumentIndexResult documentIndexResult = client.Documents.Index(batch);
                SearchTestUtilities.WaitForIndexing();

                Assert.Equal(1, documentIndexResult.Results.Count);
                AssertIndexActionSucceeded("1", documentIndexResult.Results[0], 200);

                Assert.Equal(0, client.Documents.Count());
            });
        }

        [Fact]
        public void CanDeleteBatchByKeys()
        {
            Run(() =>
            {
                SearchIndexClient client = Data.GetSearchIndexClient();

                var uploadBatch = 
                    IndexBatch.Upload(
                        new[]
                        {
                            new Hotel() { HotelId = "1" },
                            new Hotel() { HotelId = "2" }
                        });

                client.Documents.Index(uploadBatch);
                SearchTestUtilities.WaitForIndexing();

                Assert.Equal(2, client.Documents.Count());

                var deleteBatch = IndexBatch.Delete("hotelId", new[] { "1", "2" });

                DocumentIndexResult documentIndexResult = client.Documents.Index(deleteBatch);
                SearchTestUtilities.WaitForIndexing();

                Assert.Equal(2, documentIndexResult.Results.Count);
                AssertIndexActionSucceeded("1", documentIndexResult.Results[0], 200);
                AssertIndexActionSucceeded("2", documentIndexResult.Results[1], 200);

                Assert.Equal(0, client.Documents.Count());
            });
        }

        [Fact]
        public void CanIndexWithPascalCaseFields()
        {
            Run(() =>
            {
                SearchServiceClient serviceClient = Data.GetSearchServiceClient();

                Index index = Book.DefineIndex();
                serviceClient.Indexes.Create(index);
                SearchIndexClient indexClient = Data.GetSearchIndexClient(index.Name);

                var batch =
                    IndexBatch.Upload(new[] 
                    { 
                        new Book() { ISBN = "123", Title = "Lord of the Rings", Author = "J.R.R. Tolkien" } 
                    });

                DocumentIndexResult indexResponse = indexClient.Documents.Index(batch);

                Assert.Equal(1, indexResponse.Results.Count);
                AssertIndexActionSucceeded("123", indexResponse.Results[0], 201);
            });
        }

        [Fact]
        public void StaticallyTypedDateTimesRoundTripAsUtc()
        {
            Run(() =>
            {
                SearchServiceClient serviceClient = Data.GetSearchServiceClient();

                Index index = Book.DefineIndex();
                serviceClient.Indexes.Create(index);
                SearchIndexClient indexClient = Data.GetSearchIndexClient(index.Name);

                // Can't test local date time since we might be testing against a pre-recorded mock response.
                DateTime utcDateTime = new DateTime(2000, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                DateTime unspecifiedDateTime = new DateTime(2000, 1, 1, 0, 0, 0, DateTimeKind.Unspecified);

                var batch =
                    IndexBatch.Upload(
                        new[] 
                        { 
                            new Book() { ISBN = "1", PublishDate = utcDateTime },
                            new Book() { ISBN = "2", PublishDate = unspecifiedDateTime }
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

                Index index = Book.DefineIndex();
                serviceClient.Indexes.Create(index);
                SearchIndexClient indexClient = Data.GetSearchIndexClient(index.Name);

                // Can't test local date time since we might be testing against a pre-recorded mock response.
                DateTime utcDateTime = new DateTime(2000, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                DateTime unspecifiedDateTime = new DateTime(2000, 1, 1, 0, 0, 0, DateTimeKind.Unspecified);

                var batch =
                    IndexBatch.Upload(
                        new[] 
                        { 
                            new Document() { { "ISBN", "1" }, { "PublishDate", utcDateTime } },
                            new Document() { { "ISBN", "2" }, { "PublishDate", unspecifiedDateTime } }
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

                var batch = IndexBatch.Upload(new[] { new Document() });

                SearchAssert.ThrowsCloudException(
                    () => client.Documents.Index(batch),
                    HttpStatusCode.BadRequest,
                    "The request is invalid. Details: actions : 0: Document key cannot be missing or empty.");
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

        [Fact]
        [Trait(TestTraits.AcceptanceType, TestTraits.LiveBVT)]
        public void CanMergeDynamicDocuments()
        {
            Run(() =>
            {
                SearchIndexClient client = Data.GetSearchIndexClient();

                var originalDoc =
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

                var updatedDoc =
                    new Document()
                    {
                        { "hotelId", "1" },
                        { "baseRate", 99.0 },
                        { "description", null },
                        { "category", "Business" },
                        { "tags", new[] { "pool", "view", "wifi" } },
                        { "parkingIncluded", true },
                        { "lastRenovationDate", null },
                        { "rating", 4L },
                        { "location", null }
                    };

                var expectedDoc =
                    new Document()
                    {
                        { "hotelId", "1" },
                        { "baseRate", 99.0 },
                        { "description", null },
                        { "descriptionFr", "Meilleur hôtel en ville" },
                        { "hotelName", "Fancy Stay" },
                        { "category", "Business" },
                        { "tags", new[] { "pool", "view", "wifi" } },
                        { "parkingIncluded", true },
                        { "smokingAllowed", false },
                        { "lastRenovationDate", null },
                        { "rating", 4L },
                        { "location", null }
                    };

                client.Documents.Index(IndexBatch.MergeOrUpload(new[] { originalDoc }));
                SearchTestUtilities.WaitForIndexing();

                client.Documents.Index(IndexBatch.Merge(new[] { updatedDoc }));
                SearchTestUtilities.WaitForIndexing();

                Document actualDoc = client.Documents.Get("1");

                Assert.Equal(expectedDoc, actualDoc);

                client.Documents.Index(IndexBatch.MergeOrUpload(new[] { originalDoc }));
                SearchTestUtilities.WaitForIndexing();

                actualDoc = client.Documents.Get("1");

                Assert.Equal(originalDoc, actualDoc);
            });
        }

        [Fact]
        [Trait(TestTraits.AcceptanceType, TestTraits.LiveBVT)]
        public void CanMergeStaticallyTypedDocuments()
        {
            Run(() =>
            {
                SearchIndexClient client = Data.GetSearchIndexClient();

                var originalDoc =
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
                    };

                var updatedDoc =
                    new Hotel()
                    {
                        HotelId = "1",
                        BaseRate = 99.0,
                        Description = null,
                        Category = "Business",
                        Tags = new[] { "pool", "view", "wifi" },
                        ParkingIncluded = true,
                        LastRenovationDate = null,
                        Rating = 4,
                        Location = null
                    };

                var expectedDoc =
                    new Hotel()
                    {
                        HotelId = "1",
                        BaseRate = 99.0,
                        Description = "Best hotel in town",
                        DescriptionFr = "Meilleur hôtel en ville",
                        HotelName = "Fancy Stay",
                        Category = "Business",
                        Tags = new[] { "pool", "view", "wifi" },
                        ParkingIncluded = true,
                        SmokingAllowed = false,
                        LastRenovationDate = new DateTimeOffset(2010, 6, 27, 0, 0, 0, TimeSpan.FromHours(-8)),
                        Rating = 4,
                        Location = GeographyPoint.Create(47.678581, -122.131577)
                    };

                client.Documents.Index(IndexBatch.MergeOrUpload(new[] { originalDoc }));
                SearchTestUtilities.WaitForIndexing();

                client.Documents.Index(IndexBatch.Merge(new[] { updatedDoc }));
                SearchTestUtilities.WaitForIndexing();

                Hotel actualDoc = client.Documents.Get<Hotel>("1");

                Assert.Equal(expectedDoc, actualDoc);

                client.Documents.Index(IndexBatch.MergeOrUpload(new[] { originalDoc }));
                SearchTestUtilities.WaitForIndexing();

                actualDoc = client.Documents.Get<Hotel>("1");

                Assert.Equal(originalDoc, actualDoc);
            });
        }

        [Fact]
        public void CanSetExplicitNullsInStaticallyTypedDocuments()
        {
            Run(() =>
            {
                SearchIndexClient client = Data.GetSearchIndexClient();

                // This is just so we can use the LoudHotel class instead of Hotel since it has per-property
                // NullValueHandling set.
                var resolver = new MyCustomContractResolver();
                client.SerializationSettings.ContractResolver = resolver;
                client.DeserializationSettings.ContractResolver = resolver;

                var originalDoc =
                    new LoudHotel()
                    {
                        HOTELID = "1",
                        BASERATE = 199.0,
                        DESCRIPTION = "Best hotel in town",
                        DESCRIPTIONFRENCH = "Meilleur hôtel en ville",
                        HOTELNAME = "Fancy Stay",
                        CATEGORY = "Luxury",
                        TAGS = new[] { "pool", "view", "wifi", "concierge" },
                        PARKINGINCLUDED = false,
                        SMOKINGALLOWED = false,
                        LASTRENOVATIONDATE = new DateTimeOffset(2010, 6, 27, 0, 0, 0, TimeSpan.FromHours(-8)),
                        RATING = 5,
                        LOCATION = GeographyPoint.Create(47.678581, -122.131577)
                    };

                var updatedDoc =
                    new LoudHotel()
                    {
                        HOTELID = "1",
                        BASERATE = 99.0,
                        DESCRIPTION = null,
                        CATEGORY = null,    // This property doesn't have NullValueHandling.Include, so this should have no effect.
                        TAGS = new[] { "pool", "view", "wifi" },
                        PARKINGINCLUDED = true,
                        LASTRENOVATIONDATE = new DateTimeOffset(2010, 6, 27, 0, 0, 0, TimeSpan.FromHours(-8)),
                        RATING = 4,
                        LOCATION = null
                    };

                var expectedDoc =
                    new LoudHotel()
                    {
                        HOTELID = "1",
                        BASERATE = 99.0,
                        DESCRIPTION = null,
                        DESCRIPTIONFRENCH = "Meilleur hôtel en ville",
                        HOTELNAME = "Fancy Stay",
                        CATEGORY = "Luxury",
                        TAGS = new[] { "pool", "view", "wifi" },
                        PARKINGINCLUDED = true,
                        SMOKINGALLOWED = false,
                        LASTRENOVATIONDATE = new DateTimeOffset(2010, 6, 27, 0, 0, 0, TimeSpan.FromHours(-8)),
                        RATING = 4,
                        LOCATION = null
                    };

                client.Documents.Index(IndexBatch.Upload(new[] { originalDoc }));
                SearchTestUtilities.WaitForIndexing();

                client.Documents.Index(IndexBatch.Merge(new[] { updatedDoc }));
                SearchTestUtilities.WaitForIndexing();

                LoudHotel actualDoc = client.Documents.Get<LoudHotel>("1");

                Assert.Equal(expectedDoc, actualDoc);

                client.Documents.Index(IndexBatch.Upload(new[] { originalDoc }));
                SearchTestUtilities.WaitForIndexing();

                actualDoc = client.Documents.Get<LoudHotel>("1");

                Assert.Equal(originalDoc, actualDoc);
            });
        }

        [Fact]
        public void CanIndexAndRetrieveModelWithExtraProperties()
        {
            Run(() =>
            {
                SearchServiceClient serviceClient = Data.GetSearchServiceClient();

                Index index = Book.DefineIndex();
                serviceClient.Indexes.Create(index);

                SearchIndexClient client = Data.GetSearchIndexClient(index.Name);
                var resolver = new MyCustomContractResolver();
                client.SerializationSettings.ContractResolver = resolver;
                client.DeserializationSettings.ContractResolver = resolver;

                string bookJson = 
                    @"{ ""ISBN"": ""123"", ""Title"": ""The Hobbit"", ""Author"": ""J.R.R.Tolkien"", ""Rating"": 5 }";
                
                // Real customers would just use JsonConvert, but that would break the test.
                var expectedBook = SafeJsonConvert.DeserializeObject<ReviewedBook>(bookJson);

                DocumentIndexResult result = client.Documents.Index(IndexBatch.Upload(new[] { expectedBook }));

                Assert.Equal(1, result.Results.Count);
                AssertIndexActionSucceeded("123", result.Results[0], 201);

                SearchTestUtilities.WaitForIndexing();

                Assert.Equal(1, client.Documents.Count());

                ReviewedBook actualBook = client.Documents.Get<ReviewedBook>(expectedBook.ISBN);

                Assert.Equal(0, actualBook.Rating);
                actualBook.Rating = 5;
                Assert.Equal(expectedBook, actualBook);
            });
        }

        [Fact]
        public void CanIndexAndRetrieveWithCustomContractResolver()
        {
            Run(() =>
            {
                SearchIndexClient client = Data.GetSearchIndexClient();
                var resolver = new MyCustomContractResolver();
                client.SerializationSettings.ContractResolver = resolver;
                client.DeserializationSettings.ContractResolver = resolver;

                var expectedHotel =
                    new LoudHotel()
                    {
                        HOTELID = "1",
                        BASERATE = 0,
                        DESCRIPTION = "Best hotel in town",
                        DESCRIPTIONFRENCH = "Meilleur hôtel en ville",
                        HOTELNAME = "Fancy Stay",
                        CATEGORY = "Luxury",
                        TAGS = new[] { "pool", "view", "wifi", "concierge" },
                        PARKINGINCLUDED = true,
                        SMOKINGALLOWED = false,
                        LASTRENOVATIONDATE = new DateTimeOffset(2010, 6, 27, 0, 0, 0, TimeSpan.FromHours(-8)),
                        RATING = 5,
                        LOCATION = GeographyPoint.Create(47.678581, -122.131577)
                    };

                DocumentIndexResult result = client.Documents.Index(IndexBatch.Upload(new[] { expectedHotel }));

                Assert.Equal(1, result.Results.Count);
                AssertIndexActionSucceeded("1", result.Results[0], 201);

                SearchTestUtilities.WaitForIndexing();

                Assert.Equal(1, client.Documents.Count());

                LoudHotel actualHotel = client.Documents.Get<LoudHotel>(expectedHotel.HOTELID);

                Assert.Equal(expectedHotel, actualHotel);
            });
        }

        [Fact]
        public void CanIndexAndRetrieveWithCamelCaseContractResolver()
        {
            Run(() =>
            {
                SearchServiceClient serviceClient = Data.GetSearchServiceClient();

                Index index = Book.DefineIndex(useCamelCase: true);
                serviceClient.Indexes.Create(index);

                SearchIndexClient client = Data.GetSearchIndexClient(index.Name);
                client.SerializationSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

                var expectedBook = new Book() { ISBN = "123", Title = "The Hobbit", Author = "J.R.R. Tolkien" };
                DocumentIndexResult result = client.Documents.Index(IndexBatch.Upload(new[] { expectedBook }));

                Assert.Equal(1, result.Results.Count);
                AssertIndexActionSucceeded("123", result.Results[0], 201);

                SearchTestUtilities.WaitForIndexing();

                Assert.Equal(1, client.Documents.Count());

                Book actualBook = client.Documents.Get<Book>(expectedBook.ISBN);

                Assert.Equal(expectedBook, actualBook);
            });
        }

        [Fact]
        public void CanIndexAndRetrieveWithCustomConverter()
        {
            Run(() => TestCanIndexAndRetrieveWithCustomConverter<CustomBookWithConverter>());
        }

        [Fact]
        public void CanIndexAndRetrieveWithCustomConverterViaSettings()
        {
            Action<SearchIndexClient> customizeSettings =
                client =>
                {
                    var converter = new CustomBookConverter<CustomBook>();
                    converter.Install(client);
                };

            Run(() => TestCanIndexAndRetrieveWithCustomConverter<CustomBook>(customizeSettings));
        }

        [Fact]
        public void CanUseIndexWithReservedName()
        {
            Run(() =>
            {
                SearchServiceClient serviceClient = Data.GetSearchServiceClient();

                var indexWithReservedName =
                    new Index()
                    {
                        Name = "prototype",
                        Fields = new[] { new Field("ID", DataType.String) { IsKey = true } }
                    };

                serviceClient.Indexes.Create(indexWithReservedName);

                SearchIndexClient indexClient = Data.GetSearchIndexClient(indexWithReservedName.Name);

                var batch = IndexBatch.Upload(new[] { new Document() { { "ID", "1" } } });
                indexClient.Documents.Index(batch);

                SearchTestUtilities.WaitForIndexing();

                Document doc = indexClient.Documents.Get("1");
                Assert.NotNull(doc);
            });
        }

        private void TestCanIndexAndRetrieveWithCustomConverter<T>(Action<SearchIndexClient> customizeSettings = null) 
            where T : CustomBook, new()
        {
            customizeSettings = customizeSettings ?? (client => { });
            SearchServiceClient serviceClient = Data.GetSearchServiceClient();

            Index index = Book.DefineIndex();
            serviceClient.Indexes.Create(index);

            SearchIndexClient indexClient = Data.GetSearchIndexClient(index.Name);
            customizeSettings(indexClient);

            // Pre-index the document so we can test that Merge works with the custom converter.
            var firstBook = new Book()
            {
                ISBN = "123",
                Title = "The Hobbit",
                Author = "J.R.R. Tolkeen",  // Misspelled on purpose.
                PublishDate = new DateTime(1945, 09, 21)    // Incorrect date on purpose (should be 1937).
            };

            DocumentIndexResult result = indexClient.Documents.Index(IndexBatch.Upload(new[] { firstBook }));

            Assert.Equal(1, result.Results.Count);
            AssertIndexActionSucceeded("123", result.Results[0], 201);

            SearchTestUtilities.WaitForIndexing();

            var expectedBook = new T()
            {
                InternationalStandardBookNumber = "123",
                AuthorName = "J.R.R. Tolkien",
                PublishDateTime = new DateTime(1937, 09, 21)
            };

            result = indexClient.Documents.Index(IndexBatch.Merge(new[] { expectedBook }));

            Assert.Equal(1, result.Results.Count);
            AssertIndexActionSucceeded("123", result.Results[0], 200);

            SearchTestUtilities.WaitForIndexing();

            Assert.Equal(1, indexClient.Documents.Count());

            T actualBook = indexClient.Documents.Get<T>(expectedBook.InternationalStandardBookNumber);

            Assert.Equal(expectedBook, actualBook);
        }

        private static void AssertIsPartialFailure(IndexBatchException e, params string[] expectedFailedKeys)
        {
            Assert.Equal((HttpStatusCode)207, e.Response.StatusCode);

            IEnumerable<string> actualFailedKeys = e.IndexingResults.Where(r => !r.Succeeded).Select(r => r.Key);
            Assert.Equal(expectedFailedKeys, actualFailedKeys);
        }

        private static void AssertIndexActionFailed(
            string key, 
            IndexingResult result, 
            string expectedMessage, 
            int expectedStatusCode)
        {
            Assert.Equal(key, result.Key);
            Assert.False(result.Succeeded);
            Assert.Equal(expectedMessage, result.ErrorMessage);
            Assert.Equal(expectedStatusCode, result.StatusCode);
        }

        private static void AssertIndexActionSucceeded(string key, IndexingResult result, int expectedStatusCode)
        {
            Assert.Equal(key, result.Key);
            Assert.True(result.Succeeded);
            Assert.Null(result.ErrorMessage);
            Assert.Equal(expectedStatusCode, result.StatusCode);
        }
    }
}
