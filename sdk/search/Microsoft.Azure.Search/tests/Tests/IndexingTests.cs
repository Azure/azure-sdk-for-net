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
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Microsoft.Spatial;
    using Newtonsoft.Json.Serialization;
    using Rest.Serialization;
    using Xunit;
    using Index = Microsoft.Azure.Search.Models.Index;

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
                            ["hotelId"] = "1",
                            ["hotelName"] = "Secret Point Motel",
                            ["description"] = "The hotel is ideally located on the main commercial artery of the city in the heart of New York. A few minutes away is Time's Square and the historic centre of the city, as well as other places of interest that make New York one of America's most attractive and cosmopolitan cities.",
                            ["descriptionFr"] = "L'hôtel est idéalement situé sur la principale artère commerciale de la ville en plein cœur de New York. A quelques minutes se trouve la place du temps et le centre historique de la ville, ainsi que d'autres lieux d'intérêt qui font de New York l'une des villes les plus attractives et cosmopolites de l'Amérique.",
                            ["category"] = "Boutique",
                            ["tags"] = new[] { "pool", "air conditioning", "concierge" },
                            ["parkingIncluded"] = false,
                            ["smokingAllowed"] = true,
                            ["lastRenovationDate"] = new DateTimeOffset(1970, 1, 18, 0, 0, 0, TimeSpan.FromHours(-5)),
                            ["rating"] = 4,
                            ["location"] = GeographyPoint.Create(40.760586, -73.975403),
                            ["address"] = new Document()
                            {
                                ["streetAddress"] = "677 5th Ave",
                                ["city"] = "New York",
                                ["stateProvince"] = "NY",
                                ["country"] = "USA",
                                ["postalCode"] = "10022"
                            },
                            ["rooms"] = new[]
                            {
                                new Document()
                                {
                                    ["description"] = "Budget Room, 1 Queen Bed (Cityside)",
                                    ["descriptionFr"] = "Chambre Économique, 1 grand lit (côté ville)",
                                    ["type"] = "Budget Room",
                                    ["baseRate"] = 9.69,
                                    ["bedOptions"] = "1 Queen Bed",
                                    ["sleepsCount"] = 2,
                                    ["smokingAllowed"] = true,
                                    ["tags"] = new[] { "vcr/dvd" }
                                },
                                new Document()
                                {
                                    ["description"] = "Budget Room, 1 King Bed (Mountain View)",
                                    ["descriptionFr"] = "Chambre Économique, 1 très grand lit (Mountain View)",
                                    ["type"] = "Budget Room",
                                    ["baseRate"] = 8.09,
                                    ["bedOptions"] = "1 King Bed",
                                    ["sleepsCount"] = 2,
                                    ["smokingAllowed"] = true,
                                    ["tags"] = new[] { "vcr/dvd", "jacuzzi tub" }
                                }
                            }
                        }),
                    IndexAction.Upload(
                        new Document()
                        {
                            ["hotelId"] = "2",
                            ["hotelName"] = "Countryside Hotel",
                            ["description"] = "Save up to 50% off traditional hotels.  Free WiFi, great location near downtown, full kitchen, washer & dryer, 24/7 support, bowling alley, fitness center and more.",
                            ["descriptionFr"] = "Économisez jusqu'à 50% sur les hôtels traditionnels.  WiFi gratuit, très bien situé près du centre-ville, cuisine complète, laveuse & sécheuse, support 24/7, bowling, centre de fitness et plus encore.",
                            ["category"] = "Budget",
                            ["tags"] = new[] { "24-hour front desk service", "coffee in lobby", "restaurant" },
                            ["parkingIncluded"] = false,
                            ["smokingAllowed"] = true,
                            ["lastRenovationDate"] = new DateTimeOffset(1999, 9, 6, 0, 0, 0, TimeSpan.Zero),   //aka.ms/sre-codescan/disable
                            ["rating"] = 3,
                            ["location"] = GeographyPoint.Create(35.904160, -78.940483),
                            ["address"] = new Document()
                            {
                                ["streetAddress"] = "6910 Fayetteville Rd",
                                ["city"] = "Durham",
                                ["stateProvince"] = "NC",
                                ["country"] = "USA",
                                ["postalCode"] = "27713"
                            },
                            ["rooms"] = new[]
                            {
                                new Document()
                                {
                                    ["description"] = "Suite, 1 King Bed (Amenities)",
                                    ["descriptionFr"] = "Suite, 1 très grand lit (Services)",
                                    ["type"] = "Suite",
                                    ["baseRate"] = 2.44,
                                    ["bedOptions"] = "1 King Bed",
                                    ["sleepsCount"] = 2,
                                    ["smokingAllowed"] = true,
                                    ["tags"] = new[] { "coffee maker" }
                                },
                                new Document()
                                {
                                    ["description"] = "Budget Room, 1 Queen Bed (Amenities)",
                                    ["descriptionFr"] = "Chambre Économique, 1 grand lit (Services)",
                                    ["type"] = "Budget Room",
                                    ["baseRate"] = 7.69,
                                    ["bedOptions"] = "1 Queen Bed",
                                    ["sleepsCount"] = 2,
                                    ["smokingAllowed"] = false,
                                    ["tags"] = new [] { "coffee maker" }
                                }
                            }
                        }),
                    IndexAction.Merge(
                        new Document()
                        {
                            ["hotelId"] = "3",
                            ["description"] = "Surprisingly expensive",
                            ["lastRenovationDate"] = null
                        }),
                    IndexAction.Delete(keyName: "hotelId", keyValue: "4"),
                    IndexAction.MergeOrUpload(
                        new Document()
                        {
                            ["hotelId"] = "5",
                            ["hotelName"] = null,
                            ["address"] = new Document(),
                            ["tags"] = new string[0],
                            ["rooms"] = new[]
                            {
                                new Document()
                                {
                                    ["baseRate"] = double.NaN,
                                    ["tags"] = new string[0]
                                }
                            }
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
                            HotelName = "Secret Point Motel",
                            Description = "The hotel is ideally located on the main commercial artery of the city in the heart of New York. A few minutes away is Time's Square and the historic centre of the city, as well as other places of interest that make New York one of America's most attractive and cosmopolitan cities.",
                            DescriptionFr = "L'hôtel est idéalement situé sur la principale artère commerciale de la ville en plein cœur de New York. A quelques minutes se trouve la place du temps et le centre historique de la ville, ainsi que d'autres lieux d'intérêt qui font de New York l'une des villes les plus attractives et cosmopolites de l'Amérique.",
                            Category = "Boutique",
                            Tags = new[] { "pool", "air conditioning", "concierge" },
                            ParkingIncluded = false,
                            SmokingAllowed = true,
                            LastRenovationDate = new DateTimeOffset(1970, 1, 18, 0, 0, 0, TimeSpan.FromHours(-5)),
                            Rating = 4,
                            Location = GeographyPoint.Create(40.760586, -73.975403),
                            Address = new HotelAddress()
                            {
                                StreetAddress = "677 5th Ave",
                                City = "New York",
                                StateProvince = "NY",
                                Country = "USA",
                                PostalCode = "10022"
                            },
                            Rooms = new[]
                            {
                                new HotelRoom()
                                {
                                    Description = "Budget Room, 1 Queen Bed (Cityside)",
                                    DescriptionFr = "Chambre Économique, 1 grand lit (côté ville)",
                                    Type = "Budget Room",
                                    BaseRate = 9.69,
                                    BedOptions = "1 Queen Bed",
                                    SleepsCount = 2,
                                    SmokingAllowed = true,
                                    Tags = new[] { "vcr/dvd" }
                                },
                                new HotelRoom()
                                {
                                    Description = "Budget Room, 1 King Bed (Mountain View)",
                                    DescriptionFr = "Chambre Économique, 1 très grand lit (Mountain View)",
                                    Type = "Budget Room",
                                    BaseRate = 8.09,
                                    BedOptions = "1 King Bed",
                                    SleepsCount = 2,
                                    SmokingAllowed = true,
                                    Tags = new[] { "vcr/dvd", "jacuzzi tub" }
                                }
                            }
                        }),
                    IndexAction.Upload(
                        new Hotel()
                        {
                            HotelId = "2",
                            HotelName = "Countryside Hotel",
                            Description = "Save up to 50% off traditional hotels.  Free WiFi, great location near downtown, full kitchen, washer & dryer, 24/7 support, bowling alley, fitness center and more.",
                            DescriptionFr = "Économisez jusqu'à 50% sur les hôtels traditionnels.  WiFi gratuit, très bien situé près du centre-ville, cuisine complète, laveuse & sécheuse, support 24/7, bowling, centre de fitness et plus encore.",
                            Category = "Budget",
                            Tags = new[] { "24-hour front desk service", "coffee in lobby", "restaurant" },
                            ParkingIncluded = false,
                            SmokingAllowed = true,
                            LastRenovationDate = new DateTimeOffset(1999, 9, 6, 0, 0, 0, TimeSpan.Zero),   //aka.ms/sre-codescan/disable
                            Rating = 3,
                            Location = GeographyPoint.Create(35.904160, -78.940483),
                            Address = new HotelAddress()
                            {
                                StreetAddress = "6910 Fayetteville Rd",
                                City = "Durham",
                                StateProvince = "NC",
                                Country = "USA",
                                PostalCode = "27713"
                            },
                            Rooms = new[]
                            {
                                new HotelRoom()
                                {
                                    Description = "Suite, 1 King Bed (Amenities)",
                                    DescriptionFr = "Suite, 1 très grand lit (Services)",
                                    Type = "Suite",
                                    BaseRate = 2.44,
                                    BedOptions = "1 King Bed",
                                    SleepsCount = 2,
                                    SmokingAllowed = true,
                                    Tags = new[] { "coffee maker" }
                                },
                                new HotelRoom()
                                {
                                    Description = "Budget Room, 1 Queen Bed (Amenities)",
                                    DescriptionFr = "Chambre Économique, 1 grand lit (Services)",
                                    Type = "Budget Room",
                                    BaseRate = 7.69,
                                    BedOptions = "1 Queen Bed",
                                    SleepsCount = 2,
                                    SmokingAllowed = false,
                                    Tags = new [] { "coffee maker" }
                                }
                            }
                        }),
                    IndexAction.Merge(
                        new Hotel()
                        {
                            HotelId = "3",
                            Description = "Surprisingly expensive",
                            LastRenovationDate = null
                        }),
                    IndexAction.Delete(new Hotel() { HotelId = "4" }),
                    IndexAction.MergeOrUpload(
                        new Hotel()
                        {
                            HotelId = "5",
                            HotelName = null,
                            Address = new HotelAddress(),
                            Tags = new string[0],
                            Rooms = new[]
                            {
                                new HotelRoom()
                                {
                                    BaseRate = double.NaN,
                                    Tags = new string[0]
                                }
                            }
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
        [Trait(TestTraits.AcceptanceType, TestTraits.LiveBVT)]
        public void CanIndexDocumentsMappedFromStructs()
        {
            Run(() =>
            {
                SearchIndexClient client = Data.GetSearchIndexClient();

                var batch = IndexBatch.New(new[]
                {
                    IndexAction.Upload(
                        new StructHotel()
                        {
                            HotelId = "1",
                            HotelName = "Secret Point Motel",
                            Description = "The hotel is ideally located on the main commercial artery of the city in the heart of New York. A few minutes away is Time's Square and the historic centre of the city, as well as other places of interest that make New York one of America's most attractive and cosmopolitan cities.",
                            DescriptionFr = "L'hôtel est idéalement situé sur la principale artère commerciale de la ville en plein cœur de New York. A quelques minutes se trouve la place du temps et le centre historique de la ville, ainsi que d'autres lieux d'intérêt qui font de New York l'une des villes les plus attractives et cosmopolites de l'Amérique.",
                            Category = "Boutique",
                            Tags = new[] { "pool", "air conditioning", "concierge" },
                            ParkingIncluded = false,
                            SmokingAllowed = true,
                            LastRenovationDate = new DateTimeOffset(1970, 1, 18, 0, 0, 0, TimeSpan.FromHours(-5)),
                            Rating = 4,
                            Location = GeographyPoint.Create(40.760586, -73.975403),
                            Address = new StructHotelAddress()
                            {
                                StreetAddress = "677 5th Ave",
                                City = "New York",
                                StateProvince = "NY",
                                Country = "USA",
                                PostalCode = "10022"
                            },
                            Rooms = new[]
                            {
                                new StructHotelRoom()
                                {
                                    Description = "Budget Room, 1 Queen Bed (Cityside)",
                                    DescriptionFr = "Chambre Économique, 1 grand lit (côté ville)",
                                    Type = "Budget Room",
                                    BaseRate = 9.69,
                                    BedOptions = "1 Queen Bed",
                                    SleepsCount = 2,
                                    SmokingAllowed = true,
                                    Tags = new[] { "vcr/dvd" }
                                },
                                new StructHotelRoom()
                                {
                                    Description = "Budget Room, 1 King Bed (Mountain View)",
                                    DescriptionFr = "Chambre Économique, 1 très grand lit (Mountain View)",
                                    Type = "Budget Room",
                                    BaseRate = 8.09,
                                    BedOptions = "1 King Bed",
                                    SleepsCount = 2,
                                    SmokingAllowed = true,
                                    Tags = new[] { "vcr/dvd", "jacuzzi tub" }
                                }
                            }
                        }),
                    IndexAction.Upload(
                        new StructHotel()
                        {
                            HotelId = "2",
                            HotelName = "Countryside Hotel",
                            Description = "Save up to 50% off traditional hotels.  Free WiFi, great location near downtown, full kitchen, washer & dryer, 24/7 support, bowling alley, fitness center and more.",
                            DescriptionFr = "Économisez jusqu'à 50% sur les hôtels traditionnels.  WiFi gratuit, très bien situé près du centre-ville, cuisine complète, laveuse & sécheuse, support 24/7, bowling, centre de fitness et plus encore.",
                            Category = "Budget",
                            Tags = new[] { "24-hour front desk service", "coffee in lobby", "restaurant" },
                            ParkingIncluded = false,
                            SmokingAllowed = true,
                            LastRenovationDate = new DateTimeOffset(1999, 9, 6, 0, 0, 0, TimeSpan.Zero),   //aka.ms/sre-codescan/disable
                            Rating = 3,
                            Location = GeographyPoint.Create(35.904160, -78.940483),
                            Address = new StructHotelAddress()
                            {
                                StreetAddress = "6910 Fayetteville Rd",
                                City = "Durham",
                                StateProvince = "NC",
                                Country = "USA",
                                PostalCode = "27713"
                            },
                            Rooms = new[]
                            {
                                new StructHotelRoom()
                                {
                                    Description = "Suite, 1 King Bed (Amenities)",
                                    DescriptionFr = "Suite, 1 très grand lit (Services)",
                                    Type = "Suite",
                                    BaseRate = 2.44,
                                    BedOptions = "1 King Bed",
                                    SleepsCount = 2,
                                    SmokingAllowed = true,
                                    Tags = new[] { "coffee maker" }
                                },
                                new StructHotelRoom()
                                {
                                    Description = "Budget Room, 1 Queen Bed (Amenities)",
                                    DescriptionFr = "Chambre Économique, 1 grand lit (Services)",
                                    Type = "Budget Room",
                                    BaseRate = 7.69,
                                    BedOptions = "1 Queen Bed",
                                    SleepsCount = 2,
                                    SmokingAllowed = false,
                                    Tags = new [] { "coffee maker" }
                                }
                            }
                        }),
                    IndexAction.Merge(
                        new StructHotel()
                        {
                            HotelId = "3",
                            Description = "Surprisingly expensive",
                            LastRenovationDate = null
                        }),
                    IndexAction.Delete(new StructHotel() { HotelId = "4" }),
                    IndexAction.MergeOrUpload(
                        new StructHotel()
                        {
                            HotelId = "5",
                            HotelName = null,
                            Address = new StructHotelAddress(),
                            Tags = new string[0],
                            Rooms = new[]
                            {
                                new StructHotelRoom()
                                {
                                    BaseRate = double.NaN,
                                    Tags = new string[0]
                                }
                            }
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

                var document = new Document() { ["hotelId"] = "1", ["category"] = "Luxury" };
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
                        new Book()
                        {
                            ISBN = "123",
                            Title = "Lord of the Rings",
                            Author = new Author()
                            {
                                FirstName = "J.R.R.",
                                LastName = "Tolkien"
                            }
                        }
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
                var utcDateTime = new DateTime(2000, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                var unspecifiedDateTime = new DateTime(2000, 1, 1, 0, 0, 0, DateTimeKind.Unspecified);

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
                var utcDateTime = new DateTime(2000, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                var unspecifiedDateTime = new DateTime(2000, 1, 1, 0, 0, 0, DateTimeKind.Unspecified);

                var batch =
                    IndexBatch.Upload(
                        new[]
                        {
                            new Document() { ["ISBN"] = "1", ["PublishDate"] = utcDateTime },
                            new Document() { ["ISBN"] = "2", ["PublishDate"] = unspecifiedDateTime }
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
                        ["hotelId"] = "1",
                        ["hotelName"] = "Secret Point Motel",
                        ["description"] = "The hotel is ideally located on the main commercial artery of the city in the heart of New York. A few minutes away is Time's Square and the historic centre of the city, as well as other places of interest that make New York one of America's most attractive and cosmopolitan cities.",
                        ["descriptionFr"] = "L'hôtel est idéalement situé sur la principale artère commerciale de la ville en plein cœur de New York. A quelques minutes se trouve la place du temps et le centre historique de la ville, ainsi que d'autres lieux d'intérêt qui font de New York l'une des villes les plus attractives et cosmopolites de l'Amérique.",
                        ["category"] = "Boutique",
                        ["tags"] = new[] { "pool", "air conditioning", "concierge" },
                        ["parkingIncluded"] = false,
                        ["smokingAllowed"] = true,
                        ["lastRenovationDate"] = new DateTimeOffset(1970, 1, 18, 0, 0, 0, TimeSpan.FromHours(-5)),
                        ["rating"] = 4L,
                        ["location"] = GeographyPoint.Create(40.760586, -73.975403),
                        ["address"] = new Document()
                        {
                            ["streetAddress"] = "677 5th Ave",
                            ["city"] = "New York",
                            ["stateProvince"] = "NY",
                            ["country"] = "USA",
                            ["postalCode"] = "10022"
                        },
                        ["rooms"] = new[]
                        {
                            new Document()
                            {
                                ["description"] = "Budget Room, 1 Queen Bed (Cityside)",
                                ["descriptionFr"] = "Chambre Économique, 1 grand lit (côté ville)",
                                ["type"] = "Budget Room",
                                ["baseRate"] = 9.69,
                                ["bedOptions"] = "1 Queen Bed",
                                ["sleepsCount"] = 2L,
                                ["smokingAllowed"] = true,
                                ["tags"] = new[] { "vcr/dvd" }
                            },
                            new Document()
                            {
                                ["description"] = "Budget Room, 1 King Bed (Mountain View)",
                                ["descriptionFr"] = "Chambre Économique, 1 très grand lit (Mountain View)",
                                ["type"] = "Budget Room",
                                ["baseRate"] = 8.09,
                                ["bedOptions"] = "1 King Bed",
                                ["sleepsCount"] = 2L,
                                ["smokingAllowed"] = true,
                                ["tags"] = new[] { "vcr/dvd", "jacuzzi tub" }
                            }
                        }
                    };

                var updatedDoc =
                    new Document()
                    {
                        ["hotelId"] = "1",
                        ["description"] = null,
                        ["category"] = "Economy",
                        ["tags"] = new[] { "pool", "air conditioning" },
                        ["parkingIncluded"] = true,
                        ["lastRenovationDate"] = null,
                        ["rating"] = 3L,
                        ["location"] = null,
                        ["address"] = new Document(),
                        ["rooms"] = new[]
                        {
                            new Document()
                            {
                                ["description"] = null,
                                ["type"] = "Budget Room",
                                ["baseRate"] = 10.5,
                                ["bedOptions"] = "1 Queen Bed",
                                ["sleepsCount"] = 2L,
                                ["smokingAllowed"] = true,
                                ["tags"] = new[] { "vcr/dvd", "balcony" }
                            }
                        }
                    };

                var expectedDoc =
                    new Document()
                    {
                        ["hotelId"] = "1",
                        ["hotelName"] = "Secret Point Motel",
                        ["description"] = null,
                        ["descriptionFr"] = "L'hôtel est idéalement situé sur la principale artère commerciale de la ville en plein cœur de New York. A quelques minutes se trouve la place du temps et le centre historique de la ville, ainsi que d'autres lieux d'intérêt qui font de New York l'une des villes les plus attractives et cosmopolites de l'Amérique.",
                        ["category"] = "Economy",
                        ["tags"] = new[] { "pool", "air conditioning" },
                        ["parkingIncluded"] = true,
                        ["smokingAllowed"] = true,
                        ["lastRenovationDate"] = null,
                        ["rating"] = 3L,
                        ["location"] = null,
                        ["address"] = new Document()
                        {
                            ["streetAddress"] = "677 5th Ave",
                            ["city"] = "New York",
                            ["stateProvince"] = "NY",
                            ["country"] = "USA",
                            ["postalCode"] = "10022"
                        },
                        ["rooms"] = new[]
                        {
                            // This should look like the merged doc with unspecified fields as null because we don't support
                            // partial updates for complex collections.
                            new Document()
                            {
                                ["description"] = null,
                                ["descriptionFr"] = null,
                                ["type"] = "Budget Room",
                                ["baseRate"] = 10.5,
                                ["bedOptions"] = "1 Queen Bed",
                                ["sleepsCount"] = 2L,
                                ["smokingAllowed"] = true,
                                ["tags"] = new[] { "vcr/dvd", "balcony" }
                            }
                        }
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
                        HotelName = "Secret Point Motel",
                        Description = "The hotel is ideally located on the main commercial artery of the city in the heart of New York. A few minutes away is Time's Square and the historic centre of the city, as well as other places of interest that make New York one of America's most attractive and cosmopolitan cities.",
                        DescriptionFr = "L'hôtel est idéalement situé sur la principale artère commerciale de la ville en plein cœur de New York. A quelques minutes se trouve la place du temps et le centre historique de la ville, ainsi que d'autres lieux d'intérêt qui font de New York l'une des villes les plus attractives et cosmopolites de l'Amérique.",
                        Category = "Boutique",
                        Tags = new[] { "pool", "air conditioning", "concierge" },
                        ParkingIncluded = false,
                        SmokingAllowed = true,
                        LastRenovationDate = new DateTimeOffset(1970, 1, 18, 0, 0, 0, TimeSpan.FromHours(-5)),
                        Rating = 4,
                        Location = GeographyPoint.Create(40.760586, -73.975403),
                        Address = new HotelAddress()
                        {
                            StreetAddress = "677 5th Ave",
                            City = "New York",
                            StateProvince = "NY",
                            Country = "USA",
                            PostalCode = "10022"
                        },
                        Rooms = new[]
                        {
                            new HotelRoom()
                            {
                                Description = "Budget Room, 1 Queen Bed (Cityside)",
                                DescriptionFr = "Chambre Économique, 1 grand lit (côté ville)",
                                Type = "Budget Room",
                                BaseRate = 9.69,
                                BedOptions = "1 Queen Bed",
                                SleepsCount = 2,
                                SmokingAllowed = true,
                                Tags = new[] { "vcr/dvd" }
                            },
                            new HotelRoom()
                            {
                                Description = "Budget Room, 1 King Bed (Mountain View)",
                                DescriptionFr = "Chambre Économique, 1 très grand lit (Mountain View)",
                                Type = "Budget Room",
                                BaseRate = 8.09,
                                BedOptions = "1 King Bed",
                                SleepsCount = 2,
                                SmokingAllowed = true,
                                Tags = new[] { "vcr/dvd", "jacuzzi tub" }
                            }
                        }
                    };

                var updatedDoc =
                    new Hotel()
                    {
                        HotelId = "1",
                        HotelName = "Secret Point Motel",
                        Description = null,
                        Category = "Economy",
                        Tags = new[] { "pool", "air conditioning" },
                        ParkingIncluded = true,
                        LastRenovationDate = null,
                        Rating = 3,
                        Location = null,
                        Address = new HotelAddress(),
                        Rooms = new[]
                        {
                            new HotelRoom()
                            {
                                Description = null,
                                Type = "Budget Room",
                                BaseRate = 10.5,
                                BedOptions = "1 Queen Bed",
                                SleepsCount = 2,
                                Tags = new[] { "vcr/dvd", "balcony" }
                            }
                        }
                    };

                var expectedDoc =
                    new Hotel()
                    {
                        HotelId = "1",
                        HotelName = "Secret Point Motel",
                        Description = "The hotel is ideally located on the main commercial artery of the city in the heart of New York. A few minutes away is Time's Square and the historic centre of the city, as well as other places of interest that make New York one of America's most attractive and cosmopolitan cities.",
                        DescriptionFr = "L'hôtel est idéalement situé sur la principale artère commerciale de la ville en plein cœur de New York. A quelques minutes se trouve la place du temps et le centre historique de la ville, ainsi que d'autres lieux d'intérêt qui font de New York l'une des villes les plus attractives et cosmopolites de l'Amérique.",
                        Category = "Economy",
                        Tags = new[] { "pool", "air conditioning" },
                        ParkingIncluded = true,
                        SmokingAllowed = true,
                        LastRenovationDate = new DateTimeOffset(1970, 1, 18, 5, 0, 0, TimeSpan.Zero),
                        Rating = 3,
                        Location = GeographyPoint.Create(40.760586, -73.975403),
                        Address = new HotelAddress()
                        {
                            StreetAddress = "677 5th Ave",
                            City = "New York",
                            StateProvince = "NY",
                            Country = "USA",
                            PostalCode = "10022"
                        },
                        Rooms = new[]
                        {
                            // This should look like the merged doc with unspecified fields as null because we don't support
                            // partial updates for complex collections.
                            new HotelRoom()
                            {
                                Description = null,
                                DescriptionFr = null,
                                Type = "Budget Room",
                                BaseRate = 10.5,
                                BedOptions = "1 Queen Bed",
                                SleepsCount = 2,
                                Tags = new[] { "vcr/dvd", "balcony" }
                            }
                        }
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
                        HOTELNAME = "Secret Point Motel",
                        DESCRIPTION = "The hotel is ideally located on the main commercial artery of the city in the heart of New York. A few minutes away is Time's Square and the historic centre of the city, as well as other places of interest that make New York one of America's most attractive and cosmopolitan cities.",
                        DESCRIPTIONFRENCH = "L'hôtel est idéalement situé sur la principale artère commerciale de la ville en plein cœur de New York. A quelques minutes se trouve la place du temps et le centre historique de la ville, ainsi que d'autres lieux d'intérêt qui font de New York l'une des villes les plus attractives et cosmopolites de l'Amérique.",
                        CATEGORY = "Boutique",
                        TAGS = new[] { "pool", "air conditioning", "concierge" },
                        PARKINGINCLUDED = false,
                        SMOKINGALLOWED = false,
                        LASTRENOVATIONDATE = new DateTimeOffset(1970, 1, 18, 0, 0, 0, TimeSpan.FromHours(-5)),
                        RATING = 4,
                        LOCATION = GeographyPoint.Create(40.760586, -73.975403),
                        ADDRESS = new LoudHotelAddress()
                        {
                            STREETADDRESS = "677 5th Ave",
                            CITY = "New York",
                            STATEPROVINCE = "NY",
                            COUNTRY = "USA",
                            POSTALCODE = "10022"
                        },
                        ROOMS = new[]
                        {
                            new LoudHotelRoom()
                            {
                                DESCRIPTION = "Budget Room, 1 Queen Bed (Cityside)",
                                DESCRIPTIONFRENCH = "Chambre Économique, 1 grand lit (côté ville)",
                                TYPE = "Budget Room",
                                BASERATE = 9.69,
                                BEDOPTIONS = "1 Queen Bed",
                                SLEEPSCOUNT = 2,
                                SMOKINGALLOWED = true,
                                TAGS = new[] { "vcr/dvd" }
                            },
                            new LoudHotelRoom()
                            {
                                DESCRIPTION = "Budget Room, 1 King Bed (Mountain View)",
                                DESCRIPTIONFRENCH = "Chambre Économique, 1 très grand lit (Mountain View)",
                                TYPE = "Budget Room",
                                BASERATE = 8.09,
                                BEDOPTIONS = "1 King Bed",
                                SLEEPSCOUNT = 2,
                                SMOKINGALLOWED = true,
                                TAGS = new[] { "vcr/dvd", "jacuzzi tub" }
                            }
                        }
                    };

                // Omitted properties don't have NullValueHandling.Include, so omitting them results in no change.
                var updatedDoc =
                    new LoudHotel()
                    {
                        HOTELID = "1",
                        DESCRIPTION = null,    // This property has NullValueHandling.Include, so this will null out the field.
                        CATEGORY = null,    // This property doesn't have NullValueHandling.Include, so this should have no effect.
                        TAGS = new[] { "pool", "air conditioning" },
                        PARKINGINCLUDED = true,
                        LASTRENOVATIONDATE = new DateTimeOffset(1970, 1, 18, 0, 0, 0, TimeSpan.FromHours(-5)),
                        RATING = 3,
                        LOCATION = null,    // This property has NullValueHandling.Include, so this will null out the field.
                        ADDRESS = new LoudHotelAddress(),
                        ROOMS = new[]
                        {
                            new LoudHotelRoom()
                            {
                                DESCRIPTION = null,
                                TYPE = "Budget Room",
                                BASERATE = 10.5,
                                SMOKINGALLOWED = false,
                                TAGS = new[] { "vcr/dvd", "balcony" }
                            }
                        }
                    };

                var expectedDoc =
                    new LoudHotel()
                    {
                        HOTELID = "1",
                        HOTELNAME = "Secret Point Motel",
                        DESCRIPTION = null,
                        DESCRIPTIONFRENCH = "L'hôtel est idéalement situé sur la principale artère commerciale de la ville en plein cœur de New York. A quelques minutes se trouve la place du temps et le centre historique de la ville, ainsi que d'autres lieux d'intérêt qui font de New York l'une des villes les plus attractives et cosmopolites de l'Amérique.",
                        CATEGORY = "Boutique",
                        TAGS = new[] { "pool", "air conditioning" },
                        PARKINGINCLUDED = true,
                        SMOKINGALLOWED = false,
                        LASTRENOVATIONDATE = new DateTimeOffset(1970, 1, 18, 5, 0, 0, TimeSpan.Zero),
                        RATING = 3,
                        LOCATION = null,
                        ADDRESS = new LoudHotelAddress()
                        {
                            STREETADDRESS = "677 5th Ave",
                            CITY = "New York",
                            STATEPROVINCE = "NY",
                            COUNTRY = "USA",
                            POSTALCODE = "10022"
                        },
                        ROOMS = new[]
                        {
                            // Regardless of NullValueHandling, this should look like the merged doc with unspecified fields as null
                            // because we don't support partial updates for complex collections.
                            new LoudHotelRoom()
                            {
                                DESCRIPTION = null,
                                DESCRIPTIONFRENCH = null,
                                TYPE = "Budget Room",
                                BASERATE = 10.5,
                                BEDOPTIONS = null,
                                SLEEPSCOUNT = null,
                                SMOKINGALLOWED = false,
                                TAGS = new[] { "vcr/dvd", "balcony" }
                            }
                        }
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

                const string BookJson =
@"{
    ""ISBN"": ""123"",
    ""Title"": ""The Hobbit"",
    ""Author"": {
        ""FirstName"": ""J.R.R."",
        ""LastName"": ""Tolkien""
    },
    ""Rating"": 5
}";

                // Real customers would just use JsonConvert, but that would break the test.
                var expectedBook = SafeJsonConvert.DeserializeObject<ReviewedBook>(BookJson);

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
                        HOTELNAME = "Secret Point Motel",
                        DESCRIPTION = "The hotel is ideally located on the main commercial artery of the city in the heart of New York. A few minutes away is Time's Square and the historic centre of the city, as well as other places of interest that make New York one of America's most attractive and cosmopolitan cities.",
                        DESCRIPTIONFRENCH = "L'hôtel est idéalement situé sur la principale artère commerciale de la ville en plein cœur de New York. A quelques minutes se trouve la place du temps et le centre historique de la ville, ainsi que d'autres lieux d'intérêt qui font de New York l'une des villes les plus attractives et cosmopolites de l'Amérique.",
                        CATEGORY = "Boutique",
                        TAGS = new[] { "pool", "air conditioning", "concierge" },
                        PARKINGINCLUDED = false,
                        SMOKINGALLOWED = true,
                        LASTRENOVATIONDATE = new DateTimeOffset(1970, 1, 18, 0, 0, 0, TimeSpan.FromHours(-5)),
                        RATING = 4,
                        LOCATION = GeographyPoint.Create(40.760586, -73.975403),
                        ADDRESS = new LoudHotelAddress()
                        {
                            STREETADDRESS = "677 5th Ave",
                            CITY = "New York",
                            STATEPROVINCE = "NY",
                            COUNTRY = "USA",
                            POSTALCODE = "10022"
                        },
                        ROOMS = new[]
                        {
                            new LoudHotelRoom()
                            {
                                DESCRIPTION = "Budget Room, 1 Queen Bed (Cityside)",
                                DESCRIPTIONFRENCH = "Chambre Économique, 1 grand lit (côté ville)",
                                TYPE = "Budget Room",
                                BASERATE = 9.69,
                                BEDOPTIONS = "1 Queen Bed",
                                SLEEPSCOUNT = 2,
                                SMOKINGALLOWED = true,
                                TAGS = new[] { "vcr/dvd" }
                            },
                            new LoudHotelRoom()
                            {
                                DESCRIPTION = "Budget Room, 1 King Bed (Mountain View)",
                                DESCRIPTIONFRENCH = "Chambre Économique, 1 très grand lit (Mountain View)",
                                TYPE = "Budget Room",
                                BASERATE = 8.09,
                                BEDOPTIONS = "1 King Bed",
                                SLEEPSCOUNT = 2,
                                SMOKINGALLOWED = true,
                                TAGS = new[] { "vcr/dvd", "jacuzzi tub" }
                            }
                        }
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

                var expectedBook =
                    new Book()
                    {
                        ISBN = "123",
                        Title = "The Hobbit",
                        Author = new Author() { FirstName = "J.R.R.", LastName = "Tolkien" }
                    };

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
            Run(() => TestCanIndexAndRetrieveWithCustomConverter<CustomBookWithConverter, CustomAuthorWithConverter>());
        }

        [Fact]
        public void CanIndexAndRetrieveWithCustomConverterViaSettings()
        {
            void CustomizeSettings(SearchIndexClient client)
            {
                var bookConverter = new CustomBookConverter<CustomBook, CustomAuthor>();
                bookConverter.Install(client);

                var authorConverter = new CustomAuthorConverter<CustomAuthor>();
                authorConverter.Install(client);
            }

            Run(() => TestCanIndexAndRetrieveWithCustomConverter<CustomBook, CustomAuthor>(CustomizeSettings));
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

        [Fact]
        public void CanRoundtripBoundaryValues()
        {
            Run(() =>
            {
                SearchIndexClient client = Data.GetSearchIndexClient();

                var expectedDocs = new[]
                {
                    // Minimum values
                    new Hotel()
                    {
                        HotelId = "1",
                        Category = string.Empty,
                        LastRenovationDate = DateTimeOffset.MinValue,
                        Location = GeographyPoint.Create(-90, -180),   // South pole, date line from the west
                        ParkingIncluded = false,
                        Rating = int.MinValue,
                        Tags = new string[0],
                        Address = new HotelAddress(),
                        Rooms = new[]
                        {
                            new HotelRoom()
                            {
                                BaseRate = double.MinValue
                            }
                        }
                    },
                    // Maximimum values
                    new Hotel()
                    {
                        HotelId = "2",
                        Category = "test",  // No meaningful string max since there is no length limit (other than payload size or term length).
                        LastRenovationDate = DateTimeOffset.MaxValue,
                        Location = GeographyPoint.Create(90, 180),   // North pole, date line from the east
                        ParkingIncluded = true,
                        Rating = int.MaxValue,
                        Tags = new string[] { "test" },  // No meaningful string max; see above.
                        Address = new HotelAddress()
                        {
                            City = "Maximum"
                        },
                        Rooms = new[]
                        {
                            new HotelRoom()
                            {
                                BaseRate = double.MaxValue
                            }
                        }
                    },
                    // Other boundary values #1
                    new Hotel()
                    {
                        HotelId = "3",
                        Category = null,
                        LastRenovationDate = null,
                        Location = GeographyPoint.Create(0, 0),   // Equator, meridian
                        ParkingIncluded = null,
                        Rating = null,
                        Tags = new string[0],
                        Address = null,
                        Rooms = new[]
                        {
                            new HotelRoom()
                            {
                                BaseRate = double.NegativeInfinity
                            }
                        }
                    },
                    // Other boundary values #2
                    new Hotel()
                    {
                        HotelId = "4",
                        Location = null,
                        Tags = new string[0],
                        Rooms = new[]
                        {
                            new HotelRoom()
                            {
                                BaseRate = double.PositiveInfinity
                            }
                        }
                    },
                    // Other boundary values #3
                    new Hotel()
                    {
                        HotelId = "5",
                        Tags = new string[0],
                        Rooms = new[]
                        {
                            new HotelRoom()
                            {
                                BaseRate = double.NaN,
                            }
                        }
                    },
                    // Other boundary values #4
                    new Hotel()
                    {
                        HotelId = "6",
                        Rating = null,
                        Tags = new string[0],
                        Rooms = new HotelRoom[0]
                    }
                };

                var batch = IndexBatch.Upload(expectedDocs);

                client.Documents.Index(batch);

                SearchTestUtilities.WaitForIndexing();

                Hotel[] actualDocs = expectedDocs.Select(d => client.Documents.Get<Hotel>(d.HotelId)).ToArray();
                for (int i = 0; i < actualDocs.Length; i++)
                {
                    Assert.Equal(expectedDocs[i], actualDocs[i]);
                }
            });
        }

        [Fact]
        public void MergeDocumentWithoutExistingKeyThrowsIndexingException()
        {
            Run(() =>
            {
                SearchIndexClient client = Data.GetSearchIndexClient();

                var documents = new[]
                {
                    new Hotel()
                    {
                        HotelId = "1",
                        ParkingIncluded = false,
                        Rating = int.MinValue,
                        Tags = new string[0],
                        Address = new HotelAddress(),
                        Rooms = new[]
                        {
                            new HotelRoom()
                            {
                                BaseRate = double.MinValue
                            }
                        }
                    },
                };

                var batch = IndexBatch.Merge(documents);
                Assert.Throws<IndexBatchException>(() => client.Documents.Index(batch));
            });
        }

        private void TestCanIndexAndRetrieveWithCustomConverter<TBook, TAuthor>(Action<SearchIndexClient> customizeSettings = null)
            where TBook : CustomBookBase<TAuthor>, new()
            where TAuthor : CustomAuthor, new()
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
                Author = new Author() { FirstName = "J.R.R.", LastName = "Tolkeen" }, // Last name misspelled on purpose.
                PublishDate = new DateTime(1945, 09, 21)    // Incorrect date on purpose (should be 1937).
            };

            DocumentIndexResult result = indexClient.Documents.Index(IndexBatch.Upload(new[] { firstBook }));

            Assert.Equal(1, result.Results.Count);
            AssertIndexActionSucceeded("123", result.Results[0], 201);

            SearchTestUtilities.WaitForIndexing();

            var expectedBook = new TBook()
            {
                InternationalStandardBookNumber = "123",
                AuthorName = new TAuthor() { FullName = "J.R.R. Tolkien" },
                PublishDateTime = new DateTime(1937, 09, 21)
            };

            result = indexClient.Documents.Index(IndexBatch.Merge(new[] { expectedBook }));

            Assert.Equal(1, result.Results.Count);
            AssertIndexActionSucceeded("123", result.Results[0], 200);

            SearchTestUtilities.WaitForIndexing();

            Assert.Equal(1, indexClient.Documents.Count());

            TBook actualBook = indexClient.Documents.Get<TBook>(expectedBook.InternationalStandardBookNumber);

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
