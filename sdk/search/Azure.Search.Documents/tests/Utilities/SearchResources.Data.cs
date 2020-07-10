// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Text.Json.Serialization;
using Azure.Search.Documents.Models;
using Azure.Search.Documents.Indexes.Models;
#if EXPERIMENTAL_SPATIAL
using Azure.Core.Spatial;
#else
using System.Text.Json;
using System.Collections.Generic;
using Microsoft.Spatial;
#endif

#pragma warning disable SA1402 // File may only contain a single type

namespace Azure.Search.Documents.Tests
{
    public partial class SearchResources
    {
        /// <summary>
        /// <para>
        /// Get a <see cref="SearchIndex"/> for the Hotels sample data.
        /// </para>
        /// <para>
        /// This index is tuned more for exercising document serialization,
        /// indexing, and querying operations. Also, the fields of this index
        /// should exactly match the properties of the Hotel test model class
        /// below.
        /// </para>
        /// </summary>
        /// <param name="name">The name of the index to create.</param>
        /// <returns>A <see cref="SearchIndex"/> for the Hotels sample data.</returns>
        internal static SearchIndex GetHotelIndex(string name) =>
            new SearchIndex(name)
            {
                Fields =
                {
                    new SimpleField("hotelId", SearchFieldDataType.String) { IsKey = true, IsFilterable = true, IsSortable = true, IsFacetable = true },
                    new SearchableField("hotelName") { IsFilterable = true, IsSortable = true },
                    new SearchableField("description") { AnalyzerName = LexicalAnalyzerName.EnLucene },
                    new SearchableField("descriptionFr") { AnalyzerName = LexicalAnalyzerName.FrLucene },
                    new SearchableField("category") { IsFilterable = true, IsSortable = true, IsFacetable = true },
                    new SearchableField("tags", collection: true) { IsFilterable = true, IsFacetable = true },
                    new SimpleField("parkingIncluded", SearchFieldDataType.Boolean) { IsFilterable = true, IsSortable = true, IsFacetable = true },
                    new SimpleField("smokingAllowed", SearchFieldDataType.Boolean) { IsFilterable = true, IsSortable = true, IsFacetable = true },
                    new SimpleField("lastRenovationDate", SearchFieldDataType.DateTimeOffset) { IsFilterable = true, IsSortable = true, IsFacetable = true },
                    new SimpleField("rating", SearchFieldDataType.Int32) { IsFilterable = true, IsSortable = true, IsFacetable = true },
                    new SimpleField("location", SearchFieldDataType.GeographyPoint) { IsFilterable = true, IsSortable = true },
                    new ComplexField("address")
                    {
                        Fields =
                        {
                            new SearchableField("streetAddress"),
                            new SearchableField("city") { IsFilterable = true, IsSortable = true, IsFacetable = true },
                            new SearchableField("stateProvince") { IsFilterable = true, IsSortable = true, IsFacetable = true },
                            new SearchableField("country") { IsFilterable = true, IsSortable = true, IsFacetable = true },
                            new SearchableField("postalCode") { IsFilterable = true, IsSortable = true, IsFacetable = true },
                        },
                    },
                    new ComplexField("rooms", collection: true)
                    {
                        Fields =
                        {
                            new SearchableField("description") { AnalyzerName = LexicalAnalyzerName.EnLucene },
                            new SearchableField("descriptionFr") { AnalyzerName = LexicalAnalyzerName.FrLucene },
                            new SearchableField("type") { IsFilterable = true, IsFacetable = true },
                            new SimpleField("baseRate", SearchFieldDataType.Double) { IsFilterable = true, IsFacetable = true },
                            new SearchableField("bedOptions") { IsFilterable = true, IsFacetable = true },
                            new SimpleField("sleepsCount", SearchFieldDataType.Int32) { IsFilterable = true, IsFacetable = true },
                            new SimpleField("smokingAllowed", SearchFieldDataType.Boolean) { IsFilterable = true, IsFacetable = true },
                            new SearchableField("tags", collection: true) { IsFilterable = true, IsFacetable = true },
                        },
                    },
                },
                Suggesters =
                {
                    new SearchSuggester("sg", "description", "hotelName"),
                },
                ScoringProfiles =
                {
                    new ScoringProfile("nearest")
                    {
                        FunctionAggregation = ScoringFunctionAggregation.Sum,
                        Functions =
                        {
                            new DistanceScoringFunction("location", 2, new DistanceScoringParameters("myloc", 100)),
                        },
                    },
                },
            };

        /// <summary>
        /// Sample documents used by the tests.
        /// </summary>
        internal static readonly Hotel[] TestDocuments =
            new[]
            {
                new Hotel()
                {
                    HotelId = "1",
                    Description =
                        "Best hotel in town if you like luxury hotels. They have an amazing infinity pool, a spa, " +
                        "and a really helpful concierge. The location is perfect -- right downtown, close to all " +
                        "the tourist attractions. We highly recommend this hotel.",
                    DescriptionFr =
                        "Meilleur hôtel en ville si vous aimez les hôtels de luxe. Ils ont une magnifique piscine " +
                        "à débordement, un spa et un concierge très utile. L'emplacement est parfait – en plein " +
                        "centre, à proximité de toutes les attractions touristiques. Nous recommandons fortement " +
                        "cet hôtel.",
                    HotelName = "Fancy Stay",
                    Category = "Luxury",
                    Tags = new[] { "pool", "view", "wifi", "concierge" },
                    ParkingIncluded = false,
                    SmokingAllowed = false,
                    LastRenovationDate = new DateTimeOffset(2010, 6, 27, 0, 0, 0, TimeSpan.Zero),
                    Rating = 5,
                    Location = TestExtensions.CreatePoint(-122.131577, 47.678581)
                },
                new Hotel()
                {
                    HotelId = "2",
                    Description = "Cheapest hotel in town. Infact, a motel.",
                    DescriptionFr = "Hôtel le moins cher en ville. Infact, un motel.",
                    HotelName = "Roach Motel",
                    Category = "Budget",
                    Tags = new[] { "motel", "budget" },
                    ParkingIncluded = true,
                    SmokingAllowed = true,
                    LastRenovationDate = new DateTimeOffset(1982, 4, 28, 0, 0, 0, TimeSpan.Zero),   //aka.ms/sre-codescan/disable
                    Rating = 1,
                    Location = TestExtensions.CreatePoint(-122.131577, 49.678581)
                },
                new Hotel()
                {
                    HotelId = "3",
                    Description = "Very popular hotel in town",
                    DescriptionFr = "Hôtel le plus populaire en ville",
                    HotelName = "EconoStay",
                    Category = "Budget",
                    Tags = new[] { "wifi", "budget" },
                    ParkingIncluded = true,
                    SmokingAllowed = false,
                    LastRenovationDate = new DateTimeOffset(1995, 7, 1, 0, 0, 0, TimeSpan.Zero),
                    Rating = 4,
                    Location = TestExtensions.CreatePoint(-122.131577, 46.678581)
                },
                new Hotel()
                {
                    HotelId = "4",
                    Description = "Pretty good hotel",
                    DescriptionFr = "Assez bon hôtel",
                    HotelName = "Express Rooms",
                    Category = "Budget",
                    Tags = new[] { "wifi", "budget" },
                    ParkingIncluded = true,
                    SmokingAllowed = false,
                    LastRenovationDate = new DateTimeOffset(1995, 7, 1, 0, 0, 0, TimeSpan.Zero),
                    Rating = 4,
                    Location = TestExtensions.CreatePoint(-122.131577, 48.678581)
                },
                new Hotel()
                {
                    HotelId = "5",
                    Description = "Another good hotel",
                    DescriptionFr = "Un autre bon hôtel",
                    HotelName = "Comfy Place",
                    Category = "Budget",
                    Tags = new[] { "wifi", "budget" },
                    ParkingIncluded = true,
                    SmokingAllowed = false,
                    LastRenovationDate = new DateTimeOffset(2012, 8, 12, 0, 0, 0, TimeSpan.Zero),
                    Rating = 4,
                    Location = TestExtensions.CreatePoint(-122.131577, 48.678581)
                },
                new Hotel()
                {
                    HotelId = "6",
                    Description = "Surprisingly expensive. Model suites have an ocean-view.",
                    LastRenovationDate = null
                },
                new Hotel()
                {
                    HotelId = "7",
                    Description = "Modern architecture, very polite staff and very clean. Also very affordable.",
                    DescriptionFr = "Architecture moderne, personnel poli et très propre. Aussi très abordable.",
                    HotelName = "Modern Stay"
                },
                new Hotel()
                {
                    HotelId = "8",
                    Description = "Has some road noise and is next to the very police station. Bathrooms had morel coverings.",
                    DescriptionFr = "Il y a du bruit de la route et se trouve à côté de la station de police. Les salles de bain avaient des revêtements de morilles."
                },
                new Hotel()
                {
                    HotelId = "9",
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
                },
                new Hotel()
                {
                    HotelId = "10",
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
                }
            };
    }

    internal class Hotel
    {
        [JsonPropertyName("hotelId")]
        public string HotelId { get; set; }

        [JsonPropertyName("hotelName")]
        public string HotelName { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("descriptionFr")]
        public string DescriptionFr { get; set; }

        [JsonPropertyName("category")]
        public string Category { get; set; }

        [JsonPropertyName("tags")]
        // TODO: #10596 - Investigate JsonConverter for null arrays
        public string[] Tags { get; set; } = new string[] { };

        [JsonPropertyName("parkingIncluded")]
        public bool? ParkingIncluded { get; set; }

        [JsonPropertyName("smokingAllowed")]
        public bool? SmokingAllowed { get; set; }

        [JsonPropertyName("lastRenovationDate")]
        public DateTimeOffset? LastRenovationDate { get; set; }

        [JsonPropertyName("rating")]
        public int? Rating { get; set; }

#if EXPERIMENTAL_SPATIAL
        [JsonPropertyName("location")]
        public PointGeometry Location { get; set; }
#else
        [JsonPropertyName("location")]
        [JsonConverter(typeof(GeographyPointConverter))]
        public GeographyPoint Location { get; set; }
#endif

        [JsonPropertyName("address")]
        public HotelAddress Address { get; set; }

        [JsonPropertyName("rooms")]
        // TODO: #10596 - Investigate JsonConverter for null arrays
        public HotelRoom[] Rooms { get; set; } = new HotelRoom[] { };

        public override bool Equals(object obj) =>
            obj is Hotel other &&
            HotelId == other.HotelId &&
            HotelName == other.HotelName &&
            Description == other.Description &&
            DescriptionFr == other.DescriptionFr &&
            Category == other.Category &&
            Tags.SequenceEqualsNullSafe(other.Tags) &&
            ParkingIncluded == other.ParkingIncluded &&
            SmokingAllowed == other.SmokingAllowed &&
            LastRenovationDate.EqualsDateTimeOffset(other.LastRenovationDate) &&
            Rating == other.Rating &&
#if EXPERIMENTAL_SPATIAL
            (Location?.Position ?? default).Equals(other.Location?.Position ?? default) &&
#else
            Location.EqualsNullSafe(other.Location) &&
#endif
            Address.EqualsNullSafe(other.Address) &&
            Rooms.SequenceEqualsNullSafe(other.Rooms);

        public override int GetHashCode() => HotelId?.GetHashCode() ?? 0;

        public override string ToString()
        {
            string FormatRoom(HotelRoom room) => $"{{ {room} }}";
            return
                $"ID: {HotelId}; Name: {HotelName}; Description: {Description}; " +
                $"Description (French): {DescriptionFr}; Category: {Category}; " +
                $"Tags: {Tags?.ToCommaSeparatedString() ?? "null"}; Parking: {ParkingIncluded}; " +
                $"Smoking: {SmokingAllowed}; LastRenovationDate: {LastRenovationDate}; Rating: {Rating}; " +
#if EXPERIMENTAL_SPATIAL
                $"Location: [{Location?.Position.Longitude ?? 0}, {Location?.Position.Latitude ?? 0}]; " +
#else
                $"Location: [{Location?.Longitude ?? 0}, {Location?.Latitude ?? 0}]; " +
#endif
                $"Address: {{ {Address} }}; Rooms: [{string.Join("; ", Rooms?.Select(FormatRoom) ?? new string[0])}]";
        }

        public SearchDocument AsDocument() =>
            new SearchDocument()
            {
                ["hotelId"] = HotelId,
                ["hotelName"] = HotelName,
                ["description"] = Description,
                ["descriptionFr"] = DescriptionFr,
                ["category"] = Category,
                ["tags"] = Tags ?? new object[0],   // OData always gives [] instead of null for collections.
                ["parkingIncluded"] = ParkingIncluded,
                ["smokingAllowed"] = SmokingAllowed,
                ["lastRenovationDate"] = LastRenovationDate,
                ["rating"] = Rating,
#if EXPERIMENTAL_SPATIAL
                ["location"] = Location,
#else
                ["location"] = GeographyPointConverter.AsDocument(Location),
#endif
                ["address"] = Address?.AsDocument(),
                // With no elements to infer the type during deserialization, we must assume object[].
                ["rooms"] = Rooms?.Select(r => r.AsDocument())?.ToArray() ?? new object[0]
            };
    }

#if !EXPERIMENTAL_SPATIAL
    /// <summary>
    /// Convert GeographyPoints to System.Text.Json or SearchDocument
    /// representations.
    /// </summary>
    internal class GeographyPointConverter : JsonConverter<GeographyPoint>
    {
        public override GeographyPoint Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.StartObject)
            {
                string type = null;
                double? longitude = null;
                double? latitude = null;

                while (reader.Read() && reader.TokenType == JsonTokenType.PropertyName)
                {
                    string propertyName = reader.GetString();
                    if (reader.Read())
                    {
                        switch (propertyName)
                        {
                            case "type":
                                type = reader.GetString();
                                break;
                            case "coordinates":
                                if (reader.TokenType == JsonTokenType.StartArray &&
                                    reader.Read() &&
                                    reader.TokenType == JsonTokenType.Number)
                                {
                                    longitude = reader.GetDouble();
                                    if (reader.Read() && reader.TokenType == JsonTokenType.Number)
                                    {
                                        latitude = reader.GetDouble();
                                        while (reader.Read() && reader.TokenType != JsonTokenType.EndArray)
                                        {
                                            // Skip optional altitude
                                        }
                                    }
                                }
                                break;
                            default:
                                reader.Skip();
                                break;
                        }
                    }
                }

                if (type == "Point" && longitude != null && latitude != null)
                {
                    return GeographyPoint.Create(latitude.Value, longitude.Value);
                }
            }

            throw new JsonException();
        }

        public override void Write(Utf8JsonWriter writer, GeographyPoint value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WriteString("type", "Point");
            writer.WritePropertyName("coordinates");
            writer.WriteStartArray();
            writer.WriteNumberValue(value.Longitude);
            writer.WriteNumberValue(value.Latitude);
            writer.WriteEndArray();
            writer.WriteEndObject();
        }

        public static SearchDocument AsDocument(GeographyPoint value)
        {
            if (value == null) { return null; }
            List<double> coords = new List<double> { value.Longitude, value.Latitude };
            if (value.Z != null)
            {
                coords.Add(value.Z.Value);
            }
            return new SearchDocument()
            {
                ["type"] = "Point",
                ["coordinates"] = coords.ToArray()
            };
        }
    }
#endif

    // Same structure as Hotel, but without attributes that change to camelCase
    internal class UncasedHotel
    {
        public string HotelId { get; set; }
        public string HotelName { get; set; }
        public string Description { get; set; }
        public string DescriptionFr { get; set; }
        public string Category { get; set; }
        // TODO: #10596 - Investigate JsonConverter for null arrays
        public string[] Tags { get; set; } = new string[] { };
        public bool? ParkingIncluded { get; set; }
        public bool? SmokingAllowed { get; set; }
        public DateTimeOffset? LastRenovationDate { get; set; }
        public int? Rating { get; set; }
#if EXPERIMENTAL_SPATIAL
        public PointGeometry Location { get; set; }
#else
        [JsonConverter(typeof(GeographyPointConverter))]
        public GeographyPoint Location { get; set; } = null;
#endif
        public HotelAddress Address { get; set; }
        public HotelRoom[] Rooms { get; set; } = new HotelRoom[] { };

        public override bool Equals(object obj) =>
            obj is Hotel other &&
            HotelId == other.HotelId &&
            HotelName == other.HotelName &&
            Description == other.Description &&
            DescriptionFr == other.DescriptionFr &&
            Category == other.Category &&
            Tags.SequenceEqualsNullSafe(other.Tags) &&
            ParkingIncluded == other.ParkingIncluded &&
            SmokingAllowed == other.SmokingAllowed &&
            LastRenovationDate.EqualsDateTimeOffset(other.LastRenovationDate) &&
            Rating == other.Rating &&
#if EXPERIMENTAL_SPATIAL
            (Location?.Position ?? default).Equals(other.Location?.Position ?? default) &&
#else
            Location.EqualsNullSafe(other.Location) &&
#endif
            Address.EqualsNullSafe(other.Address) &&
            Rooms.SequenceEqualsNullSafe(other.Rooms);
        public override int GetHashCode() => HotelId?.GetHashCode() ?? 0;
    }

    internal class HotelAddress
    {
        [JsonPropertyName("streetAddress")]
        public string StreetAddress { get; set; }

        [JsonPropertyName("city")]
        public string City { get; set; }

        [JsonPropertyName("stateProvince")]
        public string StateProvince { get; set; }

        [JsonPropertyName("country")]
        public string Country { get; set; }

        [JsonPropertyName("postalCode")]
        public string PostalCode { get; set; }

        public override bool Equals(object obj) =>
            obj is HotelAddress other &&
            StreetAddress == other.StreetAddress &&
            City == other.City &&
            StateProvince == other.StateProvince &&
            Country == other.Country &&
            PostalCode == other.PostalCode;

        public override int GetHashCode() => StreetAddress?.GetHashCode() ?? 0;

        public override string ToString() =>
            $"StreetAddress: {StreetAddress}; City: {City}; State/Province: {StateProvince}; Country: {Country}; " +
            $"PostalCode: {PostalCode}";

        public SearchDocument AsDocument() =>
            new SearchDocument()
            {
                ["streetAddress"] = StreetAddress,
                ["city"] = City,
                ["stateProvince"] = StateProvince,
                ["country"] = Country,
                ["postalCode"] = PostalCode
            };
    }

    internal class HotelRoom
    {
        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("descriptionFr")]
        public string DescriptionFr { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("baseRate")]
        public double? BaseRate { get; set; }

        [JsonPropertyName("bedOptions")]
        public string BedOptions { get; set; }

        [JsonPropertyName("sleepsCount")]
        public int? SleepsCount { get; set; }

        [JsonPropertyName("smokingAllowed")]
        public bool? SmokingAllowed { get; set; }

        [JsonPropertyName("tags")]
        // TODO: #10596 - Investigate JsonConverter for null arrays
        public string[] Tags { get; set; } = new string[] { };

        public override bool Equals(object obj) =>
            obj is HotelRoom other &&
            Description == other.Description &&
            DescriptionFr == other.DescriptionFr &&
            Type == other.Type &&
            BaseRate.EqualsDouble(other.BaseRate) &&
            BedOptions == other.BedOptions &&
            SleepsCount == other.SleepsCount &&
            SmokingAllowed == other.SmokingAllowed &&
            Tags.SequenceEqualsNullSafe(other.Tags);

        public override int GetHashCode() => Description?.GetHashCode() ?? 0;

        public override string ToString() =>
            $"Description: {Description}; Description (French): {DescriptionFr}; Type: {Type}; BaseRate: {BaseRate}; " +
            $"Bed Options: {BedOptions}; Sleeps: {SleepsCount}; Smoking: {SmokingAllowed}; " +
            $"Tags: {Tags?.ToCommaSeparatedString() ?? "null"}";

        public SearchDocument AsDocument() =>
            new SearchDocument()
            {
                ["description"] = Description,
                ["descriptionFr"] = DescriptionFr,
                ["type"] = Type,
                ["baseRate"] = BaseRate,
                ["bedOptions"] = BedOptions,
                ["sleepsCount"] = SleepsCount,
                ["smokingAllowed"] = SmokingAllowed,
                ["tags"] = Tags ?? new object[0]   // OData always gives [] instead of null for collections.
            };
    }
}
