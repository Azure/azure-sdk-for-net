// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Text.Json.Serialization;
using Azure.Search.Documents.Models;
using Microsoft.Azure.Search;
using Microsoft.Azure.Search.Models;
using Microsoft.Spatial;
using AnalyzerName = Microsoft.Azure.Search.Models.AnalyzerName;
using DataType = Microsoft.Azure.Search.Models.DataType;
using DistanceScoringFunction = Microsoft.Azure.Search.Models.DistanceScoringFunction;
using DistanceScoringParameters = Microsoft.Azure.Search.Models.DistanceScoringParameters;
using ScoringFunctionAggregation = Microsoft.Azure.Search.Models.ScoringFunctionAggregation;
using ScoringProfile = Microsoft.Azure.Search.Models.ScoringProfile;
using Suggester = Microsoft.Azure.Search.Models.Suggester;

#pragma warning disable SA1402 // File may only contain a single type

namespace Azure.Search.Documents.Tests
{
    public partial class SearchResources
    {
        /// <summary>
        /// Get a Search Index for the Hotels sample data.
        ///
        /// This index is tuned more for exercising document serialization,
        /// indexing, and querying operations. Also, the fields of this index
        /// should exactly match the properties of the Hotel test model class
        /// below.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private static Microsoft.Azure.Search.Models.Index GetHotelIndex(string name) =>
            new Microsoft.Azure.Search.Models.Index()
            {
                Name = name,
                Fields = new[]
                {
                    Field.New("hotelId", DataType.String, isKey: true, isFilterable: true, isSortable: true, isFacetable: true),
                    Field.New("hotelName", DataType.String, isSearchable: true, isFilterable: true, isSortable: true, isFacetable: false),
                    Field.NewSearchableString("description", AnalyzerName.EnLucene),
                    Field.NewSearchableString("descriptionFr", AnalyzerName.FrLucene),
                    Field.New("category", DataType.String, isSearchable: true, isFilterable: true, isSortable: true, isFacetable: true),
                    Field.New("tags", DataType.Collection(DataType.String), isSearchable: true, isFilterable: true, isFacetable: true),
                    Field.New("parkingIncluded", DataType.Boolean, isFilterable: true, isSortable: true, isFacetable: true),
                    Field.New("smokingAllowed", DataType.Boolean, isFilterable: true, isSortable: true, isFacetable: true),
                    Field.New("lastRenovationDate", DataType.DateTimeOffset, isFilterable: true, isSortable: true, isFacetable: true),
                    Field.New("rating", DataType.Int32, isFilterable: true, isSortable: true, isFacetable: true),
                    Field.New("location", DataType.GeographyPoint, isFilterable: true, isSortable: true),
                    Field.NewComplex("address", isCollection: false, fields: new[]
                    {
                        Field.New("streetAddress", DataType.String, isSearchable: true),
                        Field.New("city", DataType.String, isSearchable: true, isFilterable: true, isSortable: true, isFacetable: true),
                        Field.New("stateProvince", DataType.String, isSearchable: true, isFilterable: true, isSortable: true, isFacetable: true),
                        Field.New("country", DataType.String, isSearchable: true, isFilterable: true, isSortable: true, isFacetable: true),
                        Field.New("postalCode", DataType.String, isSearchable: true, isFilterable: true, isSortable: true, isFacetable: true)
                    }),
                    Field.NewComplex("rooms", isCollection: true, fields: new[]
                    {
                        Field.NewSearchableString("description", AnalyzerName.EnLucene),
                        Field.NewSearchableString("descriptionFr", AnalyzerName.FrLucene),
                        Field.New("type", DataType.String, isSearchable: true, isFilterable: true, isFacetable: true),
                        Field.New("baseRate", DataType.Double, isFilterable: true, isFacetable: true),
                        Field.New("bedOptions", DataType.String, isSearchable: true, isFilterable: true, isFacetable: true),
                        Field.New("sleepsCount", DataType.Int32, isFilterable: true, isFacetable: true),
                        Field.New("smokingAllowed", DataType.Boolean, isFilterable: true, isFacetable: true),
                        Field.New("tags", DataType.Collection(DataType.String), isSearchable: true, isFilterable: true, isFacetable: true)
                    })
                },
                Suggesters = new[]
                {
                    new Suggester(
                        name: "sg",
                        sourceFields: new[] { "description", "hotelName" })
                },
                ScoringProfiles = new[]
                {
                    new ScoringProfile("nearest")
                    {
                        FunctionAggregation = ScoringFunctionAggregation.Sum,
                        Functions = new[]
                        {
                            new DistanceScoringFunction("location", 2, new DistanceScoringParameters("myloc", 100))
                        }
                    }
                }
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
                    Location = GeographyPoint.Create(47.678581, -122.131577)
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
                    Location = GeographyPoint.Create(49.678581, -122.131577)
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
                    Location = GeographyPoint.Create(46.678581, -122.131577)
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
                    Location = GeographyPoint.Create(48.678581, -122.131577)
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
                    Location = GeographyPoint.Create(48.678581, -122.131577)
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
                            Tags = new[] { "coffee maker" }
                        }
                    }
                }
            };
    }

    [SerializePropertyNamesAsCamelCase]
    internal class Hotel
    {
        [System.ComponentModel.DataAnnotations.Key, IsFilterable, IsSortable, IsFacetable]
        [JsonPropertyName("hotelId")]
        public string HotelId { get; set; }

        [IsSearchable, IsFilterable, IsSortable]
        [JsonPropertyName("hotelName")]
        public string HotelName { get; set; }

        [IsSearchable, Analyzer(AnalyzerName.AsString.EnLucene)]
        [JsonPropertyName("description")]
        public string Description { get; set; }

        [IsSearchable, Analyzer(AnalyzerName.AsString.FrLucene)]
        [JsonPropertyName("descriptionFr")]
        public string DescriptionFr { get; set; }

        [IsSearchable, IsFilterable, IsSortable, IsFacetable]
        [JsonPropertyName("category")]
        public string Category { get; set; }

        [IsSearchable, IsFilterable, IsFacetable]
        [JsonPropertyName("tags")]
        // TODO: #10596 - Investigate JsonConverter for null arrays
        public string[] Tags { get; set; } = new string[] { };

        [IsFilterable, IsSortable, IsFacetable]
        [JsonPropertyName("parkingIncluded")]
        public bool? ParkingIncluded { get; set; }

        [IsFilterable, IsSortable, IsFacetable]
        [JsonPropertyName("smokingAllowed")]
        public bool? SmokingAllowed { get; set; }

        [IsFilterable, IsSortable, IsFacetable]
        [JsonPropertyName("lastRenovationDate")]
        public DateTimeOffset? LastRenovationDate { get; set; }

        [IsFilterable, IsSortable, IsFacetable]
        [JsonPropertyName("rating")]
        public int? Rating { get; set; }

        [IsFilterable, IsSortable]
        // TODO: #10592- Unify on an Azure.Core spatial type
        [JsonIgnore]
        public GeographyPoint Location { get; set; } = null;

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
            // TODO: #10592- Unify on an Azure.Core spatial type
            // Location.EqualsNullSafe(other.Location) &&
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
                $"Location: [{Location?.Longitude ?? 0}, {Location?.Latitude ?? 0}]; " +
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
                // TODO: #10592- Unify on an Azure.Core spatial type
                // ["location"] = Location,
                ["location"] = Location == null ? null : new SearchDocument()
                {
                    ["type"] = "Point",
                    ["coordinates"] = new double[] { Location.Longitude, Location.Latitude },
                    ["crs"] = new SearchDocument()
                    {
                        ["type"] = "name",
                        ["properties"] = new SearchDocument()
                        {
                            ["name"] = "EPSG:4326"
                        }
                    }
                },
                ["address"] = Address?.AsDocument(),
                // With no elements to infer the type during deserialization, we must assume object[].
                ["rooms"] = Rooms?.Select(r => r.AsDocument())?.ToArray() ?? new object[0]
            };
    }

    [SerializePropertyNamesAsCamelCase]
    internal class HotelAddress
    {
        [IsSearchable]
        [JsonPropertyName("streetAddress")]
        public string StreetAddress { get; set; }

        [IsSearchable, IsFilterable, IsSortable, IsFacetable]
        [JsonPropertyName("city")]
        public string City { get; set; }

        [IsSearchable, IsFilterable, IsSortable, IsFacetable]
        [JsonPropertyName("stateProvince")]
        public string StateProvince { get; set; }

        [IsSearchable, IsFilterable, IsSortable, IsFacetable]
        [JsonPropertyName("country")]
        public string Country { get; set; }

        [IsSearchable, IsFilterable, IsSortable, IsFacetable]
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

    [SerializePropertyNamesAsCamelCase]
    internal class HotelRoom
    {
        [IsSearchable, Analyzer(AnalyzerName.AsString.EnLucene)]
        [JsonPropertyName("description")]
        public string Description { get; set; }

        [IsSearchable, Analyzer(AnalyzerName.AsString.FrLucene)]
        [JsonPropertyName("descriptionFr")]
        public string DescriptionFr { get; set; }

        [IsSearchable, IsFilterable, IsFacetable]
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [IsFilterable, IsFacetable]
        [JsonPropertyName("baseRate")]
        public double? BaseRate { get; set; }

        [IsSearchable, IsFilterable, IsFacetable]
        [JsonPropertyName("bedOptions")]
        public string BedOptions { get; set; }

        [IsFilterable, IsFacetable]
        [JsonPropertyName("sleepsCount")]
        public int? SleepsCount { get; set; }

        [IsFilterable, IsFacetable]
        [JsonPropertyName("smokingAllowed")]
        public bool? SmokingAllowed { get; set; }

        [IsSearchable, IsFilterable, IsFacetable]
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
