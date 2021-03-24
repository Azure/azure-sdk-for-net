// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Azure.Core.Serialization;
#if EXPERIMENTAL_SPATIAL
using Azure.Core.GeoJson;
#endif
using Azure.Core.TestFramework;
using Azure.Search.Documents.Models;
using NUnit.Framework;

namespace Azure.Search.Documents.Tests
{
    [IgnoreOnNet5("https://github.com/Azure/azure-sdk-for-net/issues/16963")]
    public class IndexingTests : SearchTestBase
    {
        public IndexingTests(bool async, SearchClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        #region Utilities
        private static void AssertPartialFailure(
            Response<IndexDocumentsResult> response,
            params string[] expectedFailedKeys)
        {
            Assert.AreEqual(207, response.GetRawResponse().Status);
            IEnumerable<string> actualFailedKeys = response.Value.Results.Where(r => !r.Succeeded).Select(r => r.Key);
            CollectionAssert.AreEqual(expectedFailedKeys, actualFailedKeys);
        }

        private static void AssertActionFailed(
            string key,
            IndexingResult result,
            string expectedMessage,
            int expectedStatusCode)
        {
            Assert.AreEqual(key, result.Key);
            Assert.IsFalse(result.Succeeded);
            Assert.AreEqual(expectedMessage, result.ErrorMessage);
            Assert.AreEqual(expectedStatusCode, result.Status);
        }

        private static void AssertActionSucceeded(
            string key,
            IndexingResult result,
            int expectedStatusCode)
        {
            Assert.AreEqual(key, result.Key);
            Assert.IsTrue(result.Succeeded);
            Assert.IsNull(result.ErrorMessage);
            Assert.AreEqual(expectedStatusCode, result.Status);
        }
        #endregion Utilities

        [Test]
        public async Task IndexingConveniences()
        {
            await using SearchResources resources = await SearchResources.CreateWithEmptyHotelsIndexAsync(this);
            SearchClient client = resources.GetSearchClient();

            // Upload
            var doc1 = new SearchDocument
            {
                ["hotelId"] = "1",
                ["hotelName"] = "Highway Hole in the Wall"
            };
            var doc2 = new SearchDocument
            {
                ["hotelId"] = "2",
                ["hotelName"] = "Freeway Flophouse"
            };
            Response<IndexDocumentsResult> response = await client.UploadDocumentsAsync(new[] { doc1, doc2 });
            Assert.AreEqual(2, response.Value.Results.Count);
            AssertActionSucceeded("1", response.Value.Results[0], 201);
            AssertActionSucceeded("2", response.Value.Results[1], 201);
            await resources.WaitForIndexingAsync();
            long count = await client.GetDocumentCountAsync();
            Assert.AreEqual(2L, count);

            // Merge
            response = await client.MergeDocumentsAsync(
                new[]
                {
                    new SearchDocument { ["hotelId"] = "1", ["hotelName"] = "Highway Haven" }
                });
            Assert.AreEqual(1, response.Value.Results.Count);
            AssertActionSucceeded("1", response.Value.Results[0], 200);
            await resources.WaitForIndexingAsync();
            count = await client.GetDocumentCountAsync();
            Assert.AreEqual(2L, count);
            SearchDocument merged = await client.GetDocumentAsync<SearchDocument>("1");
            Assert.AreNotEqual(doc1["hotelName"], merged["hotelName"]);

            // Upload or Merge
            response = await client.MergeOrUploadDocumentsAsync(
                new[]
                {
                    new SearchDocument { ["hotelId"] = "2", ["hotelName"] = "Freeway Freedom" },
                    new SearchDocument { ["hotelId"] = "3", ["hotelName"] = "Basically a gas station bathroom, but with beds" },
                });
            Assert.AreEqual(2, response.Value.Results.Count);
            AssertActionSucceeded("2", response.Value.Results[0], 200);
            AssertActionSucceeded("3", response.Value.Results[1], 201);
            await resources.WaitForIndexingAsync();
            count = await client.GetDocumentCountAsync();
            Assert.AreEqual(3L, count);
            merged = await client.GetDocumentAsync<SearchDocument>("2");
            Assert.AreNotEqual(doc2["hotelName"], merged["hotelName"]);

            // Delete by document
            response = await client.DeleteDocumentsAsync(new[] { doc1, doc2 });
            Assert.AreEqual(2, response.Value.Results.Count);
            AssertActionSucceeded("1", response.Value.Results[0], 200);
            AssertActionSucceeded("2", response.Value.Results[1], 200);
            await resources.WaitForIndexingAsync();
            count = await client.GetDocumentCountAsync();
            Assert.AreEqual(1L, count);

            // Delete by key
            response = await client.DeleteDocumentsAsync("hotelId", new[] { "3" });
            Assert.AreEqual(1, response.Value.Results.Count);
            AssertActionSucceeded("3", response.Value.Results[0], 200);
            await resources.WaitForIndexingAsync();
            count = await client.GetDocumentCountAsync();
            Assert.AreEqual(0L, count);
        }

        [Test]
        public async Task DynamicDocuments()
        {
            await using SearchResources resources = await SearchResources.CreateWithEmptyHotelsIndexAsync(this);
            SearchClient client = resources.GetSearchClient();
            IndexDocumentsBatch<SearchDocument> batch = IndexDocumentsBatch.Create(
                IndexDocumentsAction.Upload(
                    new SearchDocument
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
                        ["location"] = TestExtensions.CreateDynamicPoint(-73.975403, 40.760586),
                        ["address"] = new SearchDocument()
                        {
                            ["streetAddress"] = "677 5th Ave",
                            ["city"] = "New York",
                            ["stateProvince"] = "NY",
                            ["country"] = "USA",
                            ["postalCode"] = "10022"
                        },
                        ["rooms"] = new[]
                        {
                            new SearchDocument()
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
                            new SearchDocument()
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
                IndexDocumentsAction.Upload(
                    new SearchDocument
                    {
                        ["hotelId"] = "2",
                        ["hotelName"] = "Secret Point Motel",
                        ["description"] = "The hotel is ideally located on the main commercial artery of the city in the heart of New York. A few minutes away is Time's Square and the historic centre of the city, as well as other places of interest that make New York one of America's most attractive and cosmopolitan cities.",
                        ["descriptionFr"] = "L'hôtel est idéalement situé sur la principale artère commerciale de la ville en plein cœur de New York. A quelques minutes se trouve la place du temps et le centre historique de la ville, ainsi que d'autres lieux d'intérêt qui font de New York l'une des villes les plus attractives et cosmopolites de l'Amérique.",
                        ["category"] = "Boutique",
                        ["tags"] = new[] { "pool", "air conditioning", "concierge" },
                        ["parkingIncluded"] = false,
                        ["smokingAllowed"] = true,
                        ["lastRenovationDate"] = new DateTimeOffset(1970, 1, 18, 0, 0, 0, TimeSpan.FromHours(-5)),
                        ["rating"] = 4,
                        ["location"] = TestExtensions.CreateDynamicPoint(-73.975403, 40.760586),
                        ["address"] = new SearchDocument()
                        {
                            ["streetAddress"] = "677 5th Ave",
                            ["city"] = "New York",
                            ["stateProvince"] = "NY",
                            ["country"] = "USA",
                            ["postalCode"] = "10022"
                        },
                        ["rooms"] = new[]
                        {
                            new SearchDocument()
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
                            new SearchDocument()
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
                IndexDocumentsAction.Merge(
                    new SearchDocument
                    {
                        ["hotelId"] = "3",
                        ["description"] = "Surprisingly expensive",
                        ["lastRenovationDate"] = null
                    }),
                IndexDocumentsAction.Delete("hotelId", "4"),
                IndexDocumentsAction.MergeOrUpload(
                    new SearchDocument
                    {
                        ["hotelId"] = "5",
                        ["hotelName"] = null,
                        ["address"] = new SearchDocument(),
                        ["tags"] = new string[0],
                        ["rooms"] = new[]
                        {
                            new SearchDocument()
                            {
                                ["baseRate"] = double.NaN,
                                ["tags"] = new string[0]
                            }
                        }
                    }));

            Response<IndexDocumentsResult> response = await client.IndexDocumentsAsync(batch);
            Assert.AreEqual(5, response.Value.Results.Count);

            AssertPartialFailure(response, "3");

            List<IndexingResult> results = new List<IndexingResult>(response.Value.Results);
            AssertActionSucceeded("1", results[0], 201);
            AssertActionSucceeded("2", results[1], 201);
            AssertActionFailed("3", results[2], "Document not found.", 404);
            AssertActionSucceeded("4", results[3], 200);
            AssertActionSucceeded("5", results[4], 201);

            await resources.WaitForIndexingAsync();

            long count = await client.GetDocumentCountAsync();
            Assert.AreEqual(3L, count);
        }

        [Test]
        public async Task StaticDocuments()
        {
            await using SearchResources resources = await SearchResources.CreateWithEmptyHotelsIndexAsync(this);
            SearchClient client = resources.GetSearchClient();
            IndexDocumentsBatch<Hotel> batch = IndexDocumentsBatch.Create(
                IndexDocumentsAction.Upload(
                    new Hotel
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
                        Location = TestExtensions.CreatePoint(-73.975403, 40.760586),
                        Address = new HotelAddress
                        {
                            StreetAddress = "677 5th Ave",
                            City = "New York",
                            StateProvince = "NY",
                            Country = "USA",
                            PostalCode = "10022"
                        },
                        Rooms = new[]
                        {
                            new HotelRoom
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
                            new HotelRoom
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
                IndexDocumentsAction.Upload(
                    new Hotel
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
                        Location = TestExtensions.CreatePoint(-78.940483, 35.904160),
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
                            new HotelRoom
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
                            new HotelRoom
                            {
                                Description = "Budget Room, 1 Queen Bed (Amenities)",
                                DescriptionFr = "Chambre Économique, 1 grand lit (Services)",
                                Type = "Budget Room",
                                BaseRate = 7.69,
                                BedOptions = "1 Queen Bed",
                                SleepsCount = 2,
                                SmokingAllowed = false,
                                Tags = new[] { "coffee maker" }
                            }
                        }
                    }),
                IndexDocumentsAction.Merge(
                    new Hotel
                    {
                        HotelId = "3",
                        Description = "Surprisingly expensive",
                        LastRenovationDate = null
                    }),
                IndexDocumentsAction.Delete(new Hotel { HotelId = "4" }),
                IndexDocumentsAction.MergeOrUpload(
                    new Hotel
                    {
                        HotelId = "5",
                        HotelName = null,
                        Address = new HotelAddress(),
                        Tags = new string[0],
                        Rooms = new[]
                        {
                            new HotelRoom
                            {
                                BaseRate = double.NaN,
                                Tags = new string[0]
                            }
                        }
                    }));

            Response<IndexDocumentsResult> response = await client.IndexDocumentsAsync(batch);
            Assert.AreEqual(5, response.Value.Results.Count);

            AssertPartialFailure(response, "3");

            List<IndexingResult> results = new List<IndexingResult>(response.Value.Results);
            AssertActionSucceeded("1", results[0], 201);
            AssertActionSucceeded("2", results[1], 201);
            AssertActionFailed("3", results[2], "Document not found.", 404);
            AssertActionSucceeded("4", results[3], 200);
            AssertActionSucceeded("5", results[4], 201);

            await resources.WaitForIndexingAsync();

            long count = await client.GetDocumentCountAsync();
            Assert.AreEqual(3L, count);
        }

        [Test]
        public async Task StaticDocumentsWithCustomSerializer()
        {
            await using SearchResources resources = await SearchResources.CreateWithEmptyHotelsIndexAsync(this);
            SearchClient client = resources.GetSearchClient(
                new SearchClientOptions()
                {
                    Serializer = new JsonObjectSerializer(
                        new JsonSerializerOptions()
                        {
                            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                            Converters =
                            {
#if EXPERIMENTAL_SPATIAL
                                new GeoJsonConverter()
#endif
                            }
                        })
                });
            UncasedHotel expected = new UncasedHotel
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
                Location = TestExtensions.CreatePoint(-73.975403, 40.760586),
                Address = new HotelAddress
                {
                    StreetAddress = "677 5th Ave",
                    City = "New York",
                    StateProvince = "NY",
                    Country = "USA",
                    PostalCode = "10022"
                },
                Rooms = new[]
                {
                    new HotelRoom
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
                    new HotelRoom
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
            IndexDocumentsBatch<UncasedHotel> batch = IndexDocumentsBatch.Create(
                IndexDocumentsAction.Upload(expected));

            Response<IndexDocumentsResult> response = await client.IndexDocumentsAsync(batch);
            Assert.AreEqual(1, response.Value.Results.Count);

            List<IndexingResult> results = new List<IndexingResult>(response.Value.Results);
            AssertActionSucceeded("1", results[0], 201);

            await resources.WaitForIndexingAsync();

            // Pull it back using the default serializer and compare
            Hotel actual = await resources.GetQueryClient().GetDocumentAsync<Hotel>("1");
            Assert.AreEqual(expected, actual);
        }

        internal struct SimpleStructHotel
        {
            [JsonPropertyName("hotelId")]
            public string HotelId { get; set; }

            [JsonPropertyName("hotelName")]
            public string HotelName { get; set; }

            [JsonPropertyName("description")]
            public string Description { get; set; }

            [JsonPropertyName("lastRenovationDate")]
            public DateTimeOffset? LastRenovationDate { get; set; }

            public override bool Equals(object obj) =>
                obj is SimpleStructHotel h &&
                h.HotelId == HotelId &&
                h.HotelName == HotelName &&
                h.Description == Description &&
                h.LastRenovationDate == LastRenovationDate;

            public override int GetHashCode() =>
                HotelId.GetHashCode() ^
                HotelName.GetHashCode() ^
                Description.GetHashCode() ^
                LastRenovationDate.GetHashCode();
        }

        [Test]
        public async Task StructDocuments()
        {
            await using SearchResources resources = await SearchResources.CreateWithEmptyHotelsIndexAsync(this);
            SearchClient client = resources.GetSearchClient();
            IndexDocumentsBatch<SimpleStructHotel> batch = IndexDocumentsBatch.Create(
                IndexDocumentsAction.Upload(
                    new SimpleStructHotel
                    {
                        HotelId = "1",
                        HotelName = "Secret Point Motel",
                        Description = "The hotel is ideally located on the main commercial artery of the city in the heart of New York. A few minutes away is Time's Square and the historic centre of the city, as well as other places of interest that make New York one of America's most attractive and cosmopolitan cities.",
                        LastRenovationDate = new DateTimeOffset(1970, 1, 18, 0, 0, 0, TimeSpan.FromHours(-5))
                    }),
                IndexDocumentsAction.Upload(
                    new SimpleStructHotel
                    {
                        HotelId = "2",
                        HotelName = "Countryside Hotel",
                        Description = "Save up to 50% off traditional hotels.  Free WiFi, great location near downtown, full kitchen, washer & dryer, 24/7 support, bowling alley, fitness center and more.",
                        LastRenovationDate = new DateTimeOffset(1999, 9, 6, 0, 0, 0, TimeSpan.Zero),   //aka.ms/sre-codescan/disable
                    }),
                IndexDocumentsAction.Merge(
                    new SimpleStructHotel
                    {
                        HotelId = "3",
                        Description = "Surprisingly expensive",
                        LastRenovationDate = null
                    }),
                IndexDocumentsAction.Delete(new SimpleStructHotel { HotelId = "4" }),
                IndexDocumentsAction.MergeOrUpload(
                    new SimpleStructHotel
                    {
                        HotelId = "5",
                        HotelName = null
                    }));

            Response<IndexDocumentsResult> response = await client.IndexDocumentsAsync(batch);
            Assert.AreEqual(5, response.Value.Results.Count);

            AssertPartialFailure(response, "3");

            List<IndexingResult> results = new List<IndexingResult>(response.Value.Results);
            AssertActionSucceeded("1", results[0], 201);
            AssertActionSucceeded("2", results[1], 201);
            AssertActionFailed("3", results[2], "Document not found.", 404);
            AssertActionSucceeded("4", results[3], 200);
            AssertActionSucceeded("5", results[4], 201);

            await resources.WaitForIndexingAsync();

            long count = await client.GetDocumentCountAsync();
            Assert.AreEqual(3L, count);
        }

        [Test]
        public async Task DoesNotThrowOnSuccess()
        {
            await using SearchResources resources = await SearchResources.CreateWithEmptyHotelsIndexAsync(this);
            SearchClient client = resources.GetSearchClient();
            IndexDocumentsBatch<Hotel> batch = IndexDocumentsBatch.Upload(
                new[] { new Hotel() { HotelId = "1" } });
            Response<IndexDocumentsResult> response = await client.IndexDocumentsAsync(batch);

            Assert.AreEqual(1, response.Value.Results.Count);
            AssertActionSucceeded("1", response.Value.Results[0], 201);
        }

        [Test]
        public async Task DoesNotThrowOnPartialSuccess()
        {
            await using SearchResources resources = await SearchResources.CreateWithEmptyHotelsIndexAsync(this);
            SearchClient client = resources.GetSearchClient();
            IndexDocumentsBatch<Hotel> batch = IndexDocumentsBatch.Create(
                IndexDocumentsAction.Upload(new Hotel { HotelId = "1" }),
                IndexDocumentsAction.Merge(new Hotel { HotelId = "2" }));
            Response<IndexDocumentsResult> response = await client.IndexDocumentsAsync(batch);

            AssertPartialFailure(response, "2");
            Assert.AreEqual(2, response.Value.Results.Count);
            AssertActionSucceeded("1", response.Value.Results[0], 201);
            AssertActionFailed("2", response.Value.Results[1], "Document not found.", 404);
        }

        [Test]
        public async Task ThrowsOnPartialSuccessWhenAsked()
        {
            await using SearchResources resources = await SearchResources.CreateWithEmptyHotelsIndexAsync(this);
            SearchClient client = resources.GetSearchClient();

            IndexDocumentsBatch<Hotel> batch = IndexDocumentsBatch.Create(
                IndexDocumentsAction.Upload(new Hotel { HotelId = "1", Category = "Luxury" }),
                IndexDocumentsAction.Merge(new Hotel { HotelId = "2" }));
            AggregateException ex = await CatchAsync<AggregateException>(
                async () => await client.IndexDocumentsAsync(
                    batch,
                    new IndexDocumentsOptions { ThrowOnAnyError = true }));
            RequestFailedException inner = ex.InnerException as RequestFailedException;
            Assert.AreEqual(404, inner.Status);
            Assert.AreEqual("Document not found.", inner.Message);
        }

        [Test]
        public async Task ThrowsAggregateException()
        {
            await using SearchResources resources = await SearchResources.CreateWithEmptyHotelsIndexAsync(this);
            SearchClient client = resources.GetSearchClient();

            IndexDocumentsBatch<Hotel> batch = IndexDocumentsBatch.Create(
                IndexDocumentsAction.Upload(new Hotel { HotelId = "1", Category = "Luxury" }),
                IndexDocumentsAction.Merge(new Hotel { HotelId = "2" }),
                IndexDocumentsAction.Merge(new Hotel { HotelId = "3" }));
            AggregateException ex = await CatchAsync<AggregateException>(
                async () => await client.IndexDocumentsAsync(
                    batch,
                    new IndexDocumentsOptions { ThrowOnAnyError = true }));

            StringAssert.StartsWith("Failed to index document(s): 2, 3.", ex.Message);
            RequestFailedException inner = ex.InnerExceptions[0] as RequestFailedException;
            Assert.AreEqual(404, inner.Status);
            Assert.AreEqual("Document not found.", inner.Message);
            inner = ex.InnerExceptions[1] as RequestFailedException;
            Assert.AreEqual(404, inner.Status);
            Assert.AreEqual("Document not found.", inner.Message);
        }

        [Test]
        public async Task DoesNotThrowDeletingExtraStatic()
        {
            await using SearchResources resources = await SearchResources.CreateWithEmptyHotelsIndexAsync(this);
            SearchClient client = resources.GetSearchClient();

            Hotel document = new Hotel() { HotelId = "1", Category = "Luxury" };
            IndexDocumentsBatch<Hotel> batch = IndexDocumentsBatch.Upload(new[] { document });
            await client.IndexDocumentsAsync(batch);
            await resources.WaitForIndexingAsync();

            long count = await client.GetDocumentCountAsync();
            Assert.AreEqual(1, count);

            document.Category = "ignored";
            batch = IndexDocumentsBatch.Delete(new[] { document });
            IndexDocumentsResult result = await client.IndexDocumentsAsync(batch);
            Assert.AreEqual(1, result.Results.Count);
            AssertActionSucceeded("1", result.Results[0], 200);
            await resources.WaitForIndexingAsync();

            count = await client.GetDocumentCountAsync();
            Assert.AreEqual(0, count);
        }

        [Test]
        public async Task DoesNotThrowDeletingExtraDynamic()
        {
            await using SearchResources resources = await SearchResources.CreateWithEmptyHotelsIndexAsync(this);
            SearchClient client = resources.GetSearchClient();

            SearchDocument document = new SearchDocument() { ["hotelId"] = "1", ["category"] = "Luxury" };
            IndexDocumentsBatch<SearchDocument> batch = IndexDocumentsBatch.Upload(new[] { document });
            await client.IndexDocumentsAsync(batch);
            await resources.WaitForIndexingAsync();

            long count = await client.GetDocumentCountAsync();
            Assert.AreEqual(1, count);

            document["category"] = "ignored";
            batch = IndexDocumentsBatch.Delete(new[] { document });
            IndexDocumentsResult result = await client.IndexDocumentsAsync(batch);
            Assert.AreEqual(1, result.Results.Count);
            AssertActionSucceeded("1", result.Results[0], 200);
            await resources.WaitForIndexingAsync();

            count = await client.GetDocumentCountAsync();
            Assert.AreEqual(0, count);
        }

        [Test]
        public async Task DeleteByKeys()
        {
            await using SearchResources resources = await SearchResources.CreateWithEmptyHotelsIndexAsync(this);
            SearchClient client = resources.GetSearchClient();
            IndexDocumentsBatch<Hotel> batch = IndexDocumentsBatch.Upload(
                new[]
                {
                    new Hotel() { HotelId = "1" },
                    new Hotel() { HotelId = "2" }
                });
            await client.IndexDocumentsAsync(batch);
            await resources.WaitForIndexingAsync();
            long count = await client.GetDocumentCountAsync();
            Assert.AreEqual(2, count);

            IndexDocumentsBatch<SearchDocument> trash =
                IndexDocumentsBatch.Delete("hotelId", new[] { "1", "2" });
            IndexDocumentsResult result = await client.IndexDocumentsAsync(trash);
            Assert.AreEqual(2, result.Results.Count);
            AssertActionSucceeded("1", result.Results[0], 200);
            AssertActionSucceeded("2", result.Results[1], 200);
            await resources.WaitForIndexingAsync();

            count = await client.GetDocumentCountAsync();
            Assert.AreEqual(0, count);
        }

        /* TODO: Enable these Track 1 tests when we have support for index creation
        public void CanIndexWithPascalCaseFields()
        {
            Run(() =>
            {
                SearchServiceClient serviceClient = Data.GetSearchServiceClient();

                Index index = Book.DefineIndex();
                serviceClient.Indexes.Create(index);
                SearchClient indexClient = Data.GetSearchClient(index.Name);

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
                SearchClient indexClient = Data.GetSearchClient(index.Name);

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
                SearchClient indexClient = Data.GetSearchClient(index.Name);

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
        /**/

        [Test]
        public async Task ThrowsOnInvalidDocument()
        {
            await using SearchResources resources = await SearchResources.CreateWithEmptyHotelsIndexAsync(this);
            SearchClient client = resources.GetSearchClient();

            IndexDocumentsBatch<SearchDocument> batch = IndexDocumentsBatch.Upload(
                new[] { new SearchDocument() });
            RequestFailedException ex = await CatchAsync<RequestFailedException>(
                async () => await client.IndexDocumentsAsync(
                    batch,
                    new IndexDocumentsOptions { ThrowOnAnyError = true }));
            Assert.AreEqual(400, ex.Status);
            StringAssert.StartsWith("The request is invalid. Details: actions : 0: Document key cannot be missing or empty.", ex.Message);
        }

        [Test]
        public async Task CountStartsAtZero()
        {
            await using SearchResources resources = await SearchResources.CreateWithEmptyHotelsIndexAsync(this);
            long count = await resources.GetSearchClient().GetDocumentCountAsync();
            Assert.AreEqual(0, count);
        }

        [Test]
        public async Task MergeDocumentsDynamic()
        {
            await using SearchResources resources = await SearchResources.CreateWithEmptyHotelsIndexAsync(this);
            SearchClient client = resources.GetSearchClient();
            SearchDocument original =
                new SearchDocument
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
                    ["location"] = TestExtensions.CreateDynamicPoint(-73.975403, 40.760586),
                    ["address"] = new SearchDocument
                    {
                        ["streetAddress"] = "677 5th Ave",
                        ["city"] = "New York",
                        ["stateProvince"] = "NY",
                        ["country"] = "USA",
                        ["postalCode"] = "10022"
                    },
                    ["rooms"] = new[]
                    {
                        new SearchDocument
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
                        new SearchDocument
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
            SearchDocument updated =
                new SearchDocument
                {
                    ["hotelId"] = "1",
                    ["description"] = null,
                    ["category"] = "Economy",
                    ["tags"] = new[] { "pool", "air conditioning" },
                    ["parkingIncluded"] = true,
                    ["lastRenovationDate"] = null,
                    ["rating"] = 3L,
                    ["location"] = null,
                    ["address"] = new SearchDocument(),
                    ["rooms"] = new[]
                    {
                        new SearchDocument
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
            SearchDocument expected =
                new SearchDocument()
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
                    ["address"] = new SearchDocument
                    {
                        ["streetAddress"] = "677 5th Ave",
                        ["city"] = "New York",
                        ["stateProvince"] = "NY",
                        ["country"] = "USA",
                        ["postalCode"] = "10022"
                    },
                    ["rooms"] = new[]
                    {
                        // This should look like the merged doc with
                        // unspecified fields as null because we don't support
                        // partial updates for complex collections.
                        new SearchDocument
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

            await client.IndexDocumentsAsync(
                IndexDocumentsBatch.MergeOrUpload(new[] { original }));
            await resources.WaitForIndexingAsync();

            await client.IndexDocumentsAsync(
                IndexDocumentsBatch.Merge(new[] { updated }));
            await resources.WaitForIndexingAsync();

            SearchDocument actualDoc = await client.GetDocumentAsync<SearchDocument>("1");
            AssertApproximate(expected, actualDoc);

            await client.IndexDocumentsAsync(
                IndexDocumentsBatch.MergeOrUpload(new[] { original }));
            await resources.WaitForIndexingAsync();

            actualDoc = await client.GetDocumentAsync<SearchDocument>("1");
            AssertApproximate(original, actualDoc);
        }

        [Test]
        [Ignore("TODO: #10602 - Fix static merge test")]
        public async Task MergeDocumentsStatic()
        {
            await using SearchResources resources = await SearchResources.CreateWithEmptyHotelsIndexAsync(this);
            SearchClient client = resources.GetSearchClient();
            Hotel original =
                new Hotel
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
                    Location = TestExtensions.CreatePoint(-73.975403, 40.760586),
                    Address = new HotelAddress
                    {
                        StreetAddress = "677 5th Ave",
                        City = "New York",
                        StateProvince = "NY",
                        Country = "USA",
                        PostalCode = "10022"
                    },
                    Rooms = new[]
                    {
                        new HotelRoom
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
                        new HotelRoom
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
            Hotel updated =
                new Hotel
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
                        new HotelRoom
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
            Hotel expected =
                new Hotel
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
                    Location = TestExtensions.CreatePoint(-73.975403, 40.760586),
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
                        // This should look like the merged doc with
                        // unspecified fields as null because we don't support
                        // partial updates for complex collections.
                        new HotelRoom
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

            await client.IndexDocumentsAsync(
                IndexDocumentsBatch.MergeOrUpload(new[] { original }));
            await resources.WaitForIndexingAsync();

            await client.IndexDocumentsAsync(
                IndexDocumentsBatch.Merge(new[] { updated }));
            await resources.WaitForIndexingAsync();

            Hotel actualDoc = await client.GetDocumentAsync<Hotel>("1");
            Assert.AreEqual(expected, actualDoc);
            /*
            TODO: #10602 - Fix static merge test
            Message:
              Expected: <ID: 1; Name: Secret Point Motel; Description: ; Description (French): L'hôtel est idéalement situé sur la principale artère commerciale de la ville en plein cœur de New York. A quelques minutes se trouve la place du temps et le centre historique de la ville, ainsi que d'autres lieux d'intérêt qui font de New York l'une des villes les plus attractives et cosmopolites de l'Amérique.; Category: Economy; Tags: pool,air conditioning; Parking: True; Smoking: True; LastRenovationDate: ; Rating: 3; Location: [0, 0]; Address: { StreetAddress: 677 5th Ave; City: New York; State/Province: NY; Country: USA; PostalCode: 10022 }; Rooms: [{ Description: ; Description (French): ; Type: Budget Room; BaseRate: 10.5; Bed Options: 1 Queen Bed; Sleeps: 2; Smoking: True; Tags: vcr/dvd,balcony }]>
              But was:  <ID: 1; Name: Secret Point Motel; Description: ; Description (French): ; Category: Economy; Tags: pool,air conditioning; Parking: True; Smoking: ; LastRenovationDate: ; Rating: 3; Location: [0, 0]; Address: { StreetAddress: ; City: ; State/Province: ; Country: ; PostalCode:  }; Rooms: [{ Description: ; Description (French): ; Type: Budget Room; BaseRate: 10.5; Bed Options: 1 Queen Bed; Sleeps: 2; Smoking: ; Tags: vcr/dvd,balcony }]>
            */

            await client.IndexDocumentsAsync(
                IndexDocumentsBatch.MergeOrUpload(new[] { original }));
            await resources.WaitForIndexingAsync();

            actualDoc = await client.GetDocumentAsync<Hotel>("1");
            Assert.AreEqual(original, actualDoc);
        }

        /* TODO: Enable this Track 1 test when we have support for naming policies
        [Fact]
        public void CanSetExplicitNullsInStaticallyTypedDocuments()
        {
            Run(() =>
            {
                SearchClient client = Data.GetSearchClient();

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
                        LOCATION = TestExtensions.CreatePoint(40.760586, -73.975403),
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
        /**/

        [Test]
        public async Task RoundtripBoundaryValues()
        {
            await using SearchResources resources = await SearchResources.CreateWithEmptyHotelsIndexAsync(this);
            SearchClient client = resources.GetSearchClient();
            Hotel[] expected = new[]
            {
                // Minimum values
                new Hotel
                {
                    HotelId = "1",
                    Category = string.Empty,
                    LastRenovationDate = DateTimeOffset.MinValue,
                    // South pole, date line from the west
                    Location = TestExtensions.CreatePoint(-180, -90),
                    ParkingIncluded = false,
                    Rating = int.MinValue,
                    Tags = new string[0],
                    Address = new HotelAddress(),
                    Rooms = new[]
                    {
                        new HotelRoom { BaseRate = double.MinValue }
                    }
                },

                // Maximum values
                new Hotel
                {
                    HotelId = "2",
                    // No meaningful string max since there is no length limit
                    // (other than payload size or term length).
                    Category = "test",
                    LastRenovationDate = DateTimeOffset.MaxValue,
                    // North pole, date line from the east
                    Location = TestExtensions.CreatePoint(180, 90),
                    ParkingIncluded = true,
                    Rating = int.MaxValue,
                    // No meaningful string max; see above.
                    Tags = new string[] { "test" },
                    Address = new HotelAddress { City = "Maximum" },
                    Rooms = new[]
                    {
                        new HotelRoom { BaseRate = double.MaxValue }
                    }
                },

                // Other boundary values #1
                new Hotel
                {
                    HotelId = "3",
                    Category = null,
                    LastRenovationDate = null,
                    // Equator, meridian
                    Location = TestExtensions.CreatePoint(0, 0),
                    ParkingIncluded = null,
                    Rating = null,
                    Tags = new string[0],
                    Address = null,
                    Rooms = new[]
                    {
                        new HotelRoom
                        {
                            BaseRate = double.NegativeInfinity
                        }
                    }
                },

                // Other boundary values #2
                new Hotel
                {
                    HotelId = "4",
                    Location = null,
                    Tags = new string[0],
                    Rooms = new[]
                    {
                        new HotelRoom
                        {
                            BaseRate = double.PositiveInfinity
                        }
                    }
                },

                // Other boundary values #3
                new Hotel
                {
                    HotelId = "5",
                    Tags = new string[0],
                    Rooms = new[]
                    {
                        new HotelRoom
                        {
                            BaseRate = double.NaN,
                        }
                    }
                },

                // Other boundary values #4
                new Hotel
                {
                    HotelId = "6",
                    Rating = null,
                    Tags = new string[0],
                    Rooms = new HotelRoom[0]
                }
            };

            IndexDocumentsBatch<Hotel> batch = IndexDocumentsBatch.Upload(expected);
            await client.IndexDocumentsAsync(batch);
            await resources.WaitForIndexingAsync();

            foreach (Hotel doc in expected)
            {
                Hotel actual = await client.GetDocumentAsync<Hotel>(doc.HotelId);
                AssertApproximate(doc, actual);
            }
        }

        [Test]
        public async Task ThrowsWhenMergingWithNewKey()
        {
            await using SearchResources resources = await SearchResources.CreateWithEmptyHotelsIndexAsync(this);
            SearchClient client = resources.GetSearchClient();

            IndexDocumentsBatch<SearchDocument> batch = IndexDocumentsBatch.Merge(
                new[] { new SearchDocument { ["hotelId"] = "42" } });
            AggregateException ex = await CatchAsync<AggregateException>(
                async () => await client.IndexDocumentsAsync(
                    batch,
                    new IndexDocumentsOptions { ThrowOnAnyError = true }));
            RequestFailedException inner = ex.InnerException as RequestFailedException;
            Assert.AreEqual(404, inner.Status);
            StringAssert.StartsWith("Document not found.", inner.Message);
        }

        /* TODO: Enable these Track 1 tests when we have support for index creation
        [Fact]
        public void CanIndexAndRetrieveModelWithExtraProperties()
        {
            Run(() =>
            {
                SearchServiceClient serviceClient = Data.GetSearchServiceClient();

                Index index = Book.DefineIndex();
                serviceClient.Indexes.Create(index);

                SearchClient client = Data.GetSearchClient(index.Name);
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
                SearchClient client = Data.GetSearchClient();
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
                        LOCATION = TestExtensions.CreatePoint(40.760586, -73.975403),
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

                SearchClient client = Data.GetSearchClient(index.Name);
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
            void CustomizeSettings(SearchClient client)
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

                SearchClient indexClient = Data.GetSearchClient(indexWithReservedName.Name);

                var batch = IndexBatch.Upload(new[] { new Document() { { "ID", "1" } } });
                indexClient.Documents.Index(batch);

                SearchTestUtilities.WaitForIndexing();

                Document doc = indexClient.Documents.Get("1");
                Assert.NotNull(doc);
            });
        }

        private void TestCanIndexAndRetrieveWithCustomConverter<TBook, TAuthor>(Action<SearchClient> customizeSettings = null)
            where TBook : CustomBookBase<TAuthor>, new()
            where TAuthor : CustomAuthor, new()
        {
            customizeSettings = customizeSettings ?? (client => { });
            SearchServiceClient serviceClient = Data.GetSearchServiceClient();

            Index index = Book.DefineIndex();
            serviceClient.Indexes.Create(index);

            SearchClient indexClient = Data.GetSearchClient(index.Name);
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
        /**/
    }
}
