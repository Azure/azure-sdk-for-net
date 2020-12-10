// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Search.Documents.Models;
using NUnit.Framework;

namespace Azure.Search.Documents.Tests
{
    [IgnoreOnNet5("https://github.com/Azure/azure-sdk-for-net/issues/16963")]
    public class GetDocumentTests : SearchTestBase
    {
        public GetDocumentTests(bool async, SearchClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        #region Utilities
        public async Task VerifyRoundtrip<T>(
            Func<T, string> getKey,
            T document,
            T expected = default,
            GetDocumentOptions options = null)
        {
            await using SearchResources resources = await SearchResources.CreateWithEmptyHotelsIndexAsync(this);
            await resources.GetSearchClient().IndexDocumentsAsync<T>(
                IndexDocumentsBatch.Upload<T>(new[] { document }));
            await resources.WaitForIndexingAsync();
            Response<T> response = await resources.GetQueryClient().GetDocumentAsync<T>(getKey(document), options);

            // Only validate expected properties
            AssertApproximate(expected ?? document, response.Value);
        }

        /// <summary>
        /// Creates a $select clause from the given document that includes all
        /// explicitly initialized fields.
        /// </summary>
        private static IList<string> SelectPopulatedFields(SearchDocument doc)
        {
            List<string> selected = new List<string>();
            foreach (KeyValuePair<string, object> kvp in doc)
            {
                string field = kvp.Key;
                string MakeFieldPath(string subField) => field + "/" + subField;
                switch (kvp.Value)
                {
                    case SearchDocument subDoc:
                        ICollection<string> subFields = SelectPopulatedFields(subDoc);
                        if (!subFields.Any() ||
                            (subFields.Contains("type") && subDoc.GetString("type") == "Point"))
                        {
                            // Ignore empty documents or GeographyPoints represented as documents
                            selected.Add(field);
                        }
                        else
                        {
                            foreach (string subField in subFields)
                            {
                                selected.Add(MakeFieldPath(subField));
                            }
                        }
                        break;

                    case SearchDocument[] subDocs:
                        var uniqueSubFields = new HashSet<string>(subDocs.SelectMany(SelectPopulatedFields));
                        if (uniqueSubFields.Any())
                        {
                            foreach (string subField in uniqueSubFields)
                            {
                                selected.Add(MakeFieldPath(subField));
                            }
                        }
                        else
                        {
                            selected.Add(field);
                        }
                        break;

                    default:
                        selected.Add(field);
                        break;
                }
            }
            return selected;
        }
        #endregion Utilities

        [Test]
        public async Task GetDocumentDict()
        {
            await using SearchResources resources = await SearchResources.GetSharedHotelsIndexAsync(this);

            SearchClient client = resources.GetQueryClient();
            Response<SearchDocument> response = await client.GetDocumentAsync<SearchDocument>("3");
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual("3", response.Value["hotelId"]);
        }

#if EXPERIMENTAL_DYNAMIC
        [Test]
#endif
        public async Task GetDocumentDynamic()
        {
            await using SearchResources resources = await SearchResources.GetSharedHotelsIndexAsync(this);

            SearchClient client = resources.GetQueryClient();
            Response<SearchDocument> response = await client.GetDocumentAsync<SearchDocument>("3");
            dynamic hotel = response.Value;
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual("3", hotel.hotelId);
        }

        [Test]
        public async Task GetDocumentStatic()
        {
            await using SearchResources resources = await SearchResources.GetSharedHotelsIndexAsync(this);

            SearchClient client = resources.GetQueryClient();
            Response<Hotel> response = await client.GetDocumentAsync<Hotel>("3");
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual("3", response.Value.HotelId);
        }

        [Test]
        public async Task RecentlyIndexedStaticDocument()
        {
            await using SearchResources resources = await SearchResources.CreateWithEmptyHotelsIndexAsync(this);
            Hotel document = SearchResources.TestDocuments[0];

            await resources.GetSearchClient().IndexDocumentsAsync(
                IndexDocumentsBatch.Upload(new[] { document }));
            await resources.WaitForIndexingAsync();

            Response<Hotel> response = await resources.GetQueryClient().GetDocumentAsync<Hotel>(document.HotelId);
            Assert.AreEqual(document.HotelId, response.Value.HotelId);
        }

        [Test]
        public async Task RecentlyIndexedDynamicDocument()
        {
            await using SearchResources resources = await SearchResources.CreateWithEmptyHotelsIndexAsync(this);
            Hotel document = SearchResources.TestDocuments[0];

            await resources.GetSearchClient().IndexDocumentsAsync(
                IndexDocumentsBatch.Upload(new[] { document.AsDocument() }));
            await resources.WaitForIndexingAsync();

            Response<Hotel> response = await resources.GetQueryClient().GetDocumentAsync<Hotel>(document.HotelId);
            Assert.AreEqual(document.HotelId, response.Value.HotelId);
        }

        [Test]
        public async Task EmptyValuesDynamicDocument()
        {
            await using SearchResources resources = await SearchResources.CreateWithEmptyHotelsIndexAsync(this);
            SearchDocument document =
                new SearchDocument
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
                        new SearchDocument
                        {
                            ["baseRate"] = null,
                            ["bedOptions"] = null,
                            ["sleepsCount"] = null,
                            ["smokingAllowed"] = null,
                            ["tags"] = new object[0]
                        }
                    }
                };

            await resources.GetSearchClient().IndexDocumentsAsync(
                IndexDocumentsBatch.Upload(new[] { document }));
            await resources.WaitForIndexingAsync();

            Response<SearchDocument> response = await resources.GetQueryClient().GetDocumentAsync<SearchDocument>((string)document["hotelId"]);
            Assert.AreEqual(document["hotelId"], response.Value["hotelId"]);
        }

        [Test]
        public async Task EmptyValuesBecomeNulls() =>
            await VerifyRoundtrip(
                d => (string)d["hotelId"],
                new SearchDocument
                {
                    ["hotelId"] = "1",
                    ["address"] = new SearchDocument()
                },
                new SearchDocument
                {
                    ["hotelId"] = "1",
                    ["address"] = new SearchDocument
                    {
                        ["streetAddress"] = null,
                        ["city"] = null,
                        ["stateProvince"] = null,
                        ["country"] = null,
                        ["postalCode"] = null
                    }
                });

        [Test]
        public async Task EmptyGetsOmittedWhenIgnoredBySubfields()
        {
            SearchDocument doc = new SearchDocument
            {
                ["hotelId"] = "1",
                ["address"] = new SearchDocument()
            };
            await VerifyRoundtrip<SearchDocument>(
                d => (string)d["hotelId"],
                doc,
                new SearchDocument
                {
                    ["hotelId"] = "1",
                    ["address"] = new SearchDocument
                    {
                        ["streetAddress"] = null,
                        ["city"] = null,
                        ["stateProvince"] = null,
                        ["country"] = null,
                        ["postalCode"] = null
                    }
                },
                new GetDocumentOptions
                {
                    SelectedFields = SelectPopulatedFields(doc)
                });
        }

        [Test]
        public async Task EmptyExpandedWithSubfields() =>
            await VerifyRoundtrip<SearchDocument>(
                d => (string)d["hotelId"],
                new SearchDocument
                {
                    ["hotelId"] = "1",
                    ["rooms"] = new[]
                    {
                        new SearchDocument(),
                        new SearchDocument()
                        {
                            ["baseRate"] = null,
                            ["bedOptions"] = null,
                            ["sleepsCount"] = null,
                            ["smokingAllowed"] = null,
                            ["tags"] = new object[0]
                        }
                    }
                },
                new SearchDocument
                {
                    ["hotelId"] = "1",
                    ["rooms"] = new[]
                    {
                        new SearchDocument
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
                        new SearchDocument
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
                },
                new GetDocumentOptions
                {
                    SelectedFields = new[] { "hotelId", "rooms" }
                });

        [Test]
        public async Task CannotAlwaysDetermineCorrectType()
        {
            SearchDocument doc = new SearchDocument
            {
                ["hotelId"] = "1",
                ["hotelName"] = "2015-02-11T12:58:00Z",
                ["location"] = TestExtensions.CreateDynamicPoint(-73.975403, 40.760586), // Test that we don't confuse Geo-JSON & complex types.
                ["rooms"] = new[]
                {
                    new SearchDocument
                    {
                        ["baseRate"] = double.NaN
                    }
                }
            };
            await VerifyRoundtrip(
                d => (string)d["hotelId"],
                doc,
                new SearchDocument
                {
                    ["hotelId"] = "1",
                    ["hotelName"] = new DateTimeOffset(2015, 2, 11, 12, 58, 0, TimeSpan.Zero),
                    ["location"] = TestExtensions.CreateDynamicPoint(-73.975403, 40.760586),
                    ["rooms"] = new[]
                    {
                        new SearchDocument
                        {
                            ["baseRate"] = "NaN"
                        }
                    }
                },
                new GetDocumentOptions
                {
                    SelectedFields = SelectPopulatedFields(doc)
                });
        }

        private struct SimpleStructHotel
        {
            [JsonPropertyName("hotelId")]
            public string HotelId { get; set; }

            [JsonPropertyName("hotelName")]
            public string HotelName { get; set; }

            public override bool Equals(object obj) =>
                obj is SimpleStructHotel h &&
                h.HotelId == HotelId &&
                h.HotelName == HotelName;

            public override int GetHashCode() =>
                HotelId.GetHashCode() ^ HotelName.GetHashCode();
        }

        [Test]
        public async Task Structs()
        {
            await using SearchResources resources = await SearchResources.CreateWithEmptyHotelsIndexAsync(this);
            SimpleStructHotel document = new SimpleStructHotel
            {
                HotelId = "4",
                HotelName = "Value Inn"
            };

            await resources.GetSearchClient().IndexDocumentsAsync(
                IndexDocumentsBatch.Upload(new[] { document }));
            await resources.WaitForIndexingAsync();

            SearchClient client = resources.GetQueryClient();
            Response<SimpleStructHotel> response = await client.GetDocumentAsync<SimpleStructHotel>(document.HotelId);
            Assert.AreEqual(document, response.Value);
        }

        [Test]
        public async Task Base64Keys()
        {
            string key = Convert.ToBase64String(new byte[] { 1, 2, 3, 4, 5 });
            await VerifyRoundtrip(
                d => (string)d["hotelId"],
                new SearchDocument { ["hotelId"] = key },
                new SearchDocument { ["hotelId"] = key },
                new GetDocumentOptions() { SelectedFields = new[] { "hotelId" } });
        }

        [Test]
        public async Task RoundtripChangesToUtc() =>
            await VerifyRoundtrip(
                d => d.HotelId,
                new Hotel()
                {
                    HotelId = "1",
                    LastRenovationDate = new DateTimeOffset(2010, 6, 27, 0, 0, 0, TimeSpan.FromHours(-8))
                },
                new Hotel()
                {
                    HotelId = "1",
                    Tags = new string[0],   // null arrays become empty arrays during indexing.
                    LastRenovationDate = new DateTimeOffset(2010, 6, 27, 8, 0, 0, TimeSpan.Zero)
                });

        [Test]
        public async Task StaticDocumentWithNullsRoundtrips() =>
            await VerifyRoundtrip(
                h => h.HotelId,
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
                });

        /* TODO: Enable this Track 1 test when we have support for index creation
        [Test]
        public async Task PascalCaseFieldsStatic()
        {
            await using SearchResources resources = await SearchResources.CreateWithNoIndexesAsync();
            SearchServiceClient serviceClient = resources.GetServiceClient();

            Book document =
                new Book()
                {
                    Isbn = "123",
                    Title = "Lord of the Rings",
                    Author = new Author() { FirstName = "J.R.R.", LastName = "Tolkien" }
                };

            await serviceClient.CreateIndexAsync(Book.CreateIndex());

            SearchClient indexClient = serviceClient.GetSearchClient(index.Name);
            await resources.GetIndexClient().IndexDocumentsAsync(
                IndexDocumentsBatch.Upload(new[] { document }));
            await resources.WaitForIndexingAsync();

            Book actual = await indexClient.GetDocumentAsync<Book>("123");
            Assert.AreEqual(document, actual);
        }
        /**/

        [Test]
        public async Task UnselectedFieldsNullStatic() =>
            await VerifyRoundtrip(
                h => h.HotelId,
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
                            Tags = new[] { "coffee maker" }
                        }
                    }
                },
                new Hotel()
                {
                    HotelName = "Countryside Hotel",
                    Description = "Save up to 50% off traditional hotels.  Free WiFi, great location near downtown, full kitchen, washer & dryer, 24/7 support, bowling alley, fitness center and more.",
                    Address = new HotelAddress() { City = "Durham" },
                    Rooms = new[]
                    {
                        new HotelRoom() { BaseRate = 2.44 },
                        new HotelRoom() { BaseRate = 7.69 }
                    }
                },
                new GetDocumentOptions()
                {
                    SelectedFields = new[] { "description", "hotelName", "address/city", "rooms/baseRate" }
                });

        [Test]
        public async Task ThrowsWhenNotFound()
        {
            await using SearchResources resources = await SearchResources.GetSharedHotelsIndexAsync(this);
            SearchClient client = resources.GetQueryClient();
            RequestFailedException ex = await CatchAsync<RequestFailedException>(
                async () => await client.GetDocumentAsync<SearchDocument>("ThisDocumentDoesNotExist"));
            Assert.AreEqual(404, ex.Status);
        }

        [Test]
        public async Task ThrowsWhenMalformed()
        {
            await using SearchResources resources = await SearchResources.GetSharedHotelsIndexAsync(this);
            SearchClient client = resources.GetQueryClient();
            RequestFailedException ex = await CatchAsync<RequestFailedException>(
                async () => await client.GetDocumentAsync<SearchDocument>(
                    "3",
                    new GetDocumentOptions() { SelectedFields = new[] { "ThisFieldDoesNotExist" } }));
            Assert.AreEqual(400, ex.Status);
            StringAssert.StartsWith("Invalid expression: Could not find a property named 'ThisFieldDoesNotExist' on type 'search.document'.", ex.Message);
        }

        /* TODO: Enable these Track 1 tests when we have support for index creation
        [Fact]
        public void CanRoundtripStaticallyTypedPrimitiveCollections()
        {
            Run(() =>
            {
                SearchServiceClient serviceClient = Data.GetSearchServiceClient();

                Index index = ModelWithPrimitiveCollections.CreateIndex();
                serviceClient.Indexes.Create(index);

                SearchClient indexClient = Data.GetSearchClient(index.Name);

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
                            TestExtensions.CreatePoint(49, -123),
                            TestExtensions.CreatePoint(47, -121)
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

                SearchClient indexClient = Data.GetSearchClient(index.Name);

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
                        TestExtensions.CreatePoint(49, -123),
                        TestExtensions.CreatePoint(47, -121)
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
                        TestExtensions.CreatePoint(49, -123),
                        TestExtensions.CreatePoint(47, -121)
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

                SearchClient indexClient = Data.GetSearchClient(index.Name);

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
        */
    }
}
