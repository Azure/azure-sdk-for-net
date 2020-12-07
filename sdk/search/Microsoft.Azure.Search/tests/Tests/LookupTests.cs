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
    using Microsoft.AspNetCore.WebUtilities;
    using Microsoft.Azure.Search.Models;
    using Microsoft.Azure.Search.Tests.Utilities;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Microsoft.Spatial;
    using Xunit;
    using Index = Microsoft.Azure.Search.Models.Index;

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
                        ["hotelId"] = "1",
                        ["hotelName"] = null,
                        ["tags"] = new object[0],
                        ["parkingIncluded"] = null,
                        ["lastRenovationDate"] = null,
                        ["rating"] = null,
                        ["location"] = null,
                        ["address"] = null,
                        ["rooms"] = new[]
                        {
                            new Document()
                            {
                                ["baseRate"] = null,
                                ["bedOptions"] = null,
                                ["sleepsCount"] = null,
                                ["smokingAllowed"] = null,
                                ["tags"] = new object[0]
                            }
                        }
                    };

                var batch = IndexBatch.Upload(new[] { expectedDoc });
                client.Documents.Index(batch);
                SearchTestUtilities.WaitForIndexing();

                // Select only the fields set in the test case so we don't get superfluous data back.
                IEnumerable<string> selectedFields = SelectPopulatedFields(expectedDoc);

                Document actualDoc = client.Documents.Get("1", selectedFields);
                Assert.Equal(expectedDoc, actualDoc);
            });
        }

        [Fact]
        public void GetDynamicDocumentWithEmptyObjectsReturnsObjectsFullOfNulls()
        {
            Run(() =>
            {
                SearchIndexClient client = Data.GetSearchIndexClient();

                var originalDoc =
                    new Document()
                    {
                        ["hotelId"] = "1",
                        ["address"] = new Document()
                    };

                var expectedDoc =
                    new Document()
                    {
                        ["hotelId"] = "1",
                        ["address"] = new Document()
                        {
                            ["streetAddress"] = null,
                            ["city"] = null,
                            ["stateProvince"] = null,
                            ["country"] = null,
                            ["postalCode"] = null
                        }
                    };

                var batch = IndexBatch.Upload(new[] { originalDoc });
                client.Documents.Index(batch);
                SearchTestUtilities.WaitForIndexing();

                // Select only the fields set in the test case so we don't get superfluous data back.
                IEnumerable<string> selectedFields = SelectPopulatedFields(originalDoc);

                Document actualDoc = client.Documents.Get("1", selectedFields);
                Assert.Equal(expectedDoc, actualDoc);
            });
        }

        [Fact]
        public void EmptyDynamicObjectsOmittedFromCollectionOnGetWhenSubFieldsSelected()
        {
            Run(() =>
            {
                SearchIndexClient client = Data.GetSearchIndexClient();

                var originalDoc =
                    new Document()
                    {
                        ["hotelId"] = "1",
                        ["rooms"] = new[]
                        {
                            new Document(),
                            new Document()
                            {
                                ["baseRate"] = null,
                                ["bedOptions"] = null,
                                ["sleepsCount"] = null,
                                ["smokingAllowed"] = null,
                                ["tags"] = new object[0]
                            }
                        }
                    };

                var expectedDoc =
                    new Document()
                    {
                        ["hotelId"] = "1",
                        ["rooms"] = new[]
                        {
                            new Document()
                            {
                                ["baseRate"] = null,
                                ["bedOptions"] = null,
                                ["sleepsCount"] = null,
                                ["smokingAllowed"] = null,
                                ["tags"] = new object[0]
                            }
                        }
                    };

                var batch = IndexBatch.Upload(new[] { originalDoc });
                client.Documents.Index(batch);
                SearchTestUtilities.WaitForIndexing();

                // Select only the fields set in the test case so we don't get superfluous data back.
                IEnumerable<string> selectedFields = SelectPopulatedFields(originalDoc);

                Document actualDoc = client.Documents.Get("1", selectedFields);
                Assert.Equal(expectedDoc, actualDoc);
            });
        }

        [Fact]
        public void EmptyDynamicObjectsInCollectionExpandedOnGetWhenCollectionFieldSelected()
        {
            Run(() =>
            {
                SearchIndexClient client = Data.GetSearchIndexClient();

                var originalDoc =
                    new Document()
                    {
                        ["hotelId"] = "1",
                        ["rooms"] = new[]
                        {
                            new Document(),
                            new Document()
                            {
                                ["baseRate"] = null,
                                ["bedOptions"] = null,
                                ["sleepsCount"] = null,
                                ["smokingAllowed"] = null,
                                ["tags"] = new object[0]
                            }
                        }
                    };

                var expectedDoc =
                    new Document()
                    {
                        ["hotelId"] = "1",
                        ["rooms"] = new[]
                        {
                            new Document()
                            {
                                ["description"] = null,
                                ["descriptionFr"] = null,
                                ["type"] = null,
                                ["baseRate"] = null,
                                ["bedOptions"] = null,
                                ["sleepsCount"] = null,
                                ["smokingAllowed"] = null,
                                ["tags"] = new object[0]
                            },
                            new Document()
                            {
                                ["description"] = null,
                                ["descriptionFr"] = null,
                                ["type"] = null,
                                ["baseRate"] = null,
                                ["bedOptions"] = null,
                                ["sleepsCount"] = null,
                                ["smokingAllowed"] = null,
                                ["tags"] = new object[0]
                            },
                        }
                    };

                var batch = IndexBatch.Upload(new[] { originalDoc });
                client.Documents.Index(batch);
                SearchTestUtilities.WaitForIndexing();

                Document actualDoc = client.Documents.Get("1", selectedFields: new[] { "hotelId", "rooms" });
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
                        ["hotelId"] = "1",
                        ["hotelName"] = "2015-02-11T12:58:00Z",
                        ["location"] = GeographyPoint.Create(40.760586, -73.975403), // Test that we don't confuse Geo-JSON & complex types.
                        ["rooms"] = new[]
                        {
                            new Document()
                            {
                                ["baseRate"] = double.NaN
                            }
                        }
                    };

                var expectedDoc =
                    new Document()
                    {
                        ["hotelId"] = "1",
                        ["hotelName"] = new DateTimeOffset(2015, 2, 11, 12, 58, 0, TimeSpan.Zero),
                        ["location"] = GeographyPoint.Create(40.760586, -73.975403),
                        ["rooms"] = new[]
                        {
                            new Document()
                            {
                                ["baseRate"] = "NaN"
                            }
                        }
                    };

                var batch = IndexBatch.Upload(new[] { expectedDoc });
                client.Documents.Index(batch);
                SearchTestUtilities.WaitForIndexing();

                // Select only the fields set in the test case so we don't get superfluous data back.
                IEnumerable<string> selectedFields = SelectPopulatedFields(indexedDoc);

                Document actualDoc = client.Documents.Get("1", selectedFields);
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

                var batch = IndexBatch.Upload(new[] { expectedDoc });
                client.Documents.Index(batch);

                Hotel actualDoc = client.Documents.Get<Hotel>("1");
                Assert.Equal(expectedDoc, actualDoc);
            });
        }

        [Fact]
        [Trait(TestTraits.AcceptanceType, TestTraits.LiveBVT)]
        public void CanGetDocumentMappedToStruct()
        {
            Run(() =>
            {
                SearchIndexClient client = Data.GetSearchIndexClient();

                var expectedDoc =
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
                    };

                var batch = IndexBatch.Upload(new[] { expectedDoc });
                client.Documents.Index(batch);

                StructHotel actualDoc = client.Documents.Get<StructHotel>("1");
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

                var expectedDoc = new Document() { ["hotelId"] = complexKey };
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
                        HotelName = null,
                        Tags = new string[0],
                        ParkingIncluded = null,
                        LastRenovationDate = null,
                        Rating = null,
                        Location = null,
                        Address = new HotelAddress(),
                        Rooms = new[]
                        {
                            new HotelRoom(),
                            new HotelRoom()
                            {
                                BaseRate = null,
                                BedOptions = null,
                                SleepsCount = null,
                                SmokingAllowed = null,
                                Tags = new string[0]
                            }
                        }
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

                var expectedDoc =
                    new Book()
                    {
                        ISBN = "123",
                        Title = "Lord of the Rings",
                        Author = new Author() { FirstName = "J.R.R.", LastName = "Tolkien" }
                    };

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
                    };

                var expectedDoc =
                    new Hotel()
                    {
                        HotelName = "Countryside Hotel",
                        Description = "Save up to 50% off traditional hotels.  Free WiFi, great location near downtown, full kitchen, washer & dryer, 24/7 support, bowling alley, fitness center and more.",
                        Address = new HotelAddress()
                        {
                            City = "Durham"
                        },
                        Rooms = new[]
                        {
                            new HotelRoom()
                            {
                                BaseRate = 2.44
                            },
                            new HotelRoom()
                            {
                                BaseRate = 7.69
                            }
                        }
                    };

                var batch = IndexBatch.Upload(new[] { indexedDoc });
                client.Documents.Index(batch);

                var selectedFields = new[] { "description", "hotelName", "address/city", "rooms/baseRate" };
                Hotel actualDoc = client.Documents.Get<Hotel>("2", selectedFields);
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

        [Fact(Skip = "Test is currently broken.")]
        public void CanRoundtripStaticallyTypedPrimitiveCollections()
        {
            Run(() =>
            {
                SearchServiceClient serviceClient = Data.GetSearchServiceClient();

                Index index = ModelWithPrimitiveCollections.CreateIndex();
                serviceClient.Indexes.Create(index);

                SearchIndexClient indexClient = Data.GetSearchIndexClient(index.Name);

                var expectedDoc =
                    new ModelWithPrimitiveCollections()
                    {
                        Key = "1",
                        Bools = new[] { true, false },
                        Dates = new[]
                        {
                            new DateTimeOffset(2019, 4, 14, 14, 24, 0, TimeSpan.FromHours(-7)),
                            new DateTimeOffset(1999, 12, 31, 23, 59, 59, TimeSpan.Zero)
                        },
                        Doubles = new[] { double.NegativeInfinity, 0.0, 2.78, double.NaN, 3.14, double.PositiveInfinity },
                        Ints = new[] { 1, 2, 3, 4, -13, 5, 0 },
                        Longs = new[] { -9_999_999_999_999_999L, 832_372_345_832_523L },
                        Points = new[]
                        {
                            GeographyPoint.Create(49, -123),
                            GeographyPoint.Create(47, -121)
                        },
                        Strings = new[]
                        {
                            "hello",
                            "2019-04-14T14:56:00-07:00"
                        }
                    };

                var batch = IndexBatch.Upload(new[] { expectedDoc });
                indexClient.Documents.Index(batch);

                var actualDoc = indexClient.Documents.Get<ModelWithPrimitiveCollections>(expectedDoc.Key);

                Assert.Equal(expectedDoc, actualDoc);
            });
        }

        [Fact]
        public void DynamicallyTypedPrimitiveCollectionsDoNotAllRoundtripCorrectly()
        {
            Run(() =>
            {
                SearchServiceClient serviceClient = Data.GetSearchServiceClient();

                Index index = ModelWithPrimitiveCollections.CreateIndex();
                serviceClient.Indexes.Create(index);

                SearchIndexClient indexClient = Data.GetSearchIndexClient(index.Name);

                var indexedDoc = new Document()
                {
                    ["Key"] = "1",
                    ["Bools"] = new bool[] { true, false },
                    ["Dates"] = new DateTimeOffset[]
                    {
                        new DateTimeOffset(2019, 4, 14, 14, 24, 0, TimeSpan.FromHours(-7)),
                        new DateTimeOffset(1999, 12, 31, 23, 59, 59, TimeSpan.Zero)
                    },
                    ["Doubles"] = new double[] { double.NegativeInfinity, 0.0, 2.78, double.NaN, 3.14, double.PositiveInfinity },
                    ["Ints"] = new int[] { 1, 2, 3, 4, -13, 5, 0 },
                    ["Longs"] = new long[] { -9_999_999_999_999_999L, 832_372_345_832_523L },
                    ["Points"] = new GeographyPoint[]
                    {
                        GeographyPoint.Create(49, -123),
                        GeographyPoint.Create(47, -121)
                    },
                    ["Strings"] = new string[]
                    {
                        "hello",
                        "2019-04-14T14:56:00-07:00"
                    }
                };

                var expectedDoc = new Document()
                {
                    ["Key"] = "1",
                    ["Bools"] = new bool[] { true, false },
                    ["Dates"] = new DateTimeOffset[]
                    {
                        new DateTimeOffset(2019, 4, 14, 14, 24, 0, TimeSpan.FromHours(-7)),
                        new DateTimeOffset(1999, 12, 31, 23, 59, 59, TimeSpan.Zero)
                    },
                    ["Doubles"] = new object[] { "-INF", 0.0, 2.78, "NaN", 3.14, "INF" },
                    ["Ints"] = new long[] { 1L, 2L, 3L, 4L, -13L, 5L, 0L },
                    ["Longs"] = new long[] { -9_999_999_999_999_999L, 832_372_345_832_523L },
                    ["Points"] = new GeographyPoint[]
                    {
                        GeographyPoint.Create(49, -123),
                        GeographyPoint.Create(47, -121)
                    },
                    ["Strings"] = new object[]
                    {
                        "hello",
                        new DateTimeOffset(2019, 4, 14, 14, 56, 0, TimeSpan.FromHours(-7))
                    }
                };

                var batch = IndexBatch.Upload(new[] { indexedDoc });
                indexClient.Documents.Index(batch);

                Document actualDoc = indexClient.Documents.Get("1");

                Assert.Equal(expectedDoc, actualDoc);
            });
        }

        [Fact]
        public void EmptyDynamicallyTypedPrimitiveCollectionsRoundtripAsObjectArrays()
        {
            Run(() =>
            {
                SearchServiceClient serviceClient = Data.GetSearchServiceClient();

                Index index = ModelWithPrimitiveCollections.CreateIndex();
                serviceClient.Indexes.Create(index);

                SearchIndexClient indexClient = Data.GetSearchIndexClient(index.Name);

                var indexedDoc = new Document()
                {
                    ["Key"] = "1",
                    ["Bools"] = new bool[0],
                    ["Dates"] = new DateTimeOffset[0],
                    ["Doubles"] = new double[0],
                    ["Ints"] = new int[0],
                    ["Longs"] = new long[0],
                    ["Points"] = new GeographyPoint[0],
                    ["Strings"] = new string[0]
                };

                var expectedDoc = new Document()
                {
                    ["Key"] = "1",
                    ["Bools"] = new object[0],
                    ["Dates"] = new object[0],
                    ["Doubles"] = new object[0],
                    ["Ints"] = new object[0],
                    ["Longs"] = new object[0],
                    ["Points"] = new object[0],
                    ["Strings"] = new object[0]
                };

                var batch = IndexBatch.Upload(new[] { indexedDoc });
                indexClient.Documents.Index(batch);

                Document actualDoc = indexClient.Documents.Get("1");

                Assert.Equal(expectedDoc, actualDoc);
            });
        }

        /// <summary>
        /// Creates a $select clause from the given document that includes all explicitly initialized fields.
        /// </summary>
        private static IEnumerable<string> SelectPopulatedFields(Document doc)
        {
            foreach (KeyValuePair<string, object> kvp in doc)
            {
                string field = kvp.Key;

                string MakeFieldPath(string subField) => field + "/" + subField;

                switch (kvp.Value)
                {
                    case Document subDoc:
                        IEnumerable<string> subFields = SelectPopulatedFields(subDoc);

                        if (subFields.Any())
                        {
                            foreach (string subField in subFields)
                            {
                                yield return MakeFieldPath(subField);
                            }
                        }
                        else
                        {
                            yield return field;
                        }
                        break;

                    case Document[] subDocs:
                        var uniqueSubFields = new HashSet<string>(subDocs.SelectMany(SelectPopulatedFields));

                        if (uniqueSubFields.Any())
                        {
                            foreach (string subField in uniqueSubFields)
                            {
                                yield return MakeFieldPath(subField);
                            }
                        }
                        else
                        {
                            yield return field;
                        }
                        break;

                    default:
                        yield return field;
                        break;
                }
            }
        }

        private class ModelWithPrimitiveCollections
        {
            [Key]
            public string Key { get; set; }

            public bool[] Bools { get; set; }

            public DateTimeOffset[] Dates { get; set; }

            public double[] Doubles { get; set; }

            public int[] Ints { get; set; }

            public long[] Longs { get; set; }

            public GeographyPoint[] Points { get; set; }

            public string[] Strings { get; set; }

            public static Index CreateIndex() =>
                new Index()
                {
                    Name = SearchTestUtilities.GenerateName(),
                    Fields = FieldBuilder.BuildForType<ModelWithPrimitiveCollections>()
                };

            public override bool Equals(object obj) =>
                obj is ModelWithPrimitiveCollections other &&
                Key == other.Key &&
                Bools.SequenceEqualsNullSafe(other.Bools) &&
                Dates.SequenceEqualsNullSafe(other.Dates) &&
                Doubles.SequenceEqualsNullSafe(other.Doubles) &&
                Ints.SequenceEqualsNullSafe(other.Ints) &&
                Longs.SequenceEqualsNullSafe(other.Longs) &&
                Points.SequenceEqualsNullSafe(other.Points) &&
                Strings.SequenceEqualsNullSafe(other.Strings);

            public override int GetHashCode() => Key?.GetHashCode() ?? 0;
        }
    }
}
