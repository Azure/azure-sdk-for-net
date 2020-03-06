﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.Azure.Search;
using Microsoft.Azure.Search.Models;
using Microsoft.Spatial;

#pragma warning disable SA1402 // File may only contain a single type

namespace Azure.Search.Tests
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
        public string HotelId { get; set; }

        [IsSearchable, IsFilterable, IsSortable]
        public string HotelName { get; set; }

        [IsSearchable, Analyzer(AnalyzerName.AsString.EnLucene)]
        public string Description { get; set; }

        [IsSearchable, Analyzer(AnalyzerName.AsString.FrLucene)]
        public string DescriptionFr { get; set; }

        [IsSearchable, IsFilterable, IsSortable, IsFacetable]
        public string Category { get; set; }

        [IsSearchable, IsFilterable, IsFacetable]
        public string[] Tags { get; set; }

        [IsFilterable, IsSortable, IsFacetable]
        public bool? ParkingIncluded { get; set; }

        [IsFilterable, IsSortable, IsFacetable]
        public bool? SmokingAllowed { get; set; }

        [IsFilterable, IsSortable, IsFacetable]
        public DateTimeOffset? LastRenovationDate { get; set; }

        [IsFilterable, IsSortable, IsFacetable]
        public int? Rating { get; set; }

        [IsFilterable, IsSortable]
        public GeographyPoint Location { get; set; }

        public HotelAddress Address { get; set; }

        public HotelRoom[] Rooms { get; set; }
    }

    [SerializePropertyNamesAsCamelCase]
    internal class HotelAddress
    {
        [IsSearchable]
        public string StreetAddress { get; set; }

        [IsSearchable, IsFilterable, IsSortable, IsFacetable]
        public string City { get; set; }

        [IsSearchable, IsFilterable, IsSortable, IsFacetable]
        public string StateProvince { get; set; }

        [IsSearchable, IsFilterable, IsSortable, IsFacetable]
        public string Country { get; set; }

        [IsSearchable, IsFilterable, IsSortable, IsFacetable]
        public string PostalCode { get; set; }
    }

    [SerializePropertyNamesAsCamelCase]
    internal class HotelRoom
    {
        [IsSearchable, Analyzer(AnalyzerName.AsString.EnLucene)]
        public string Description { get; set; }

        [IsSearchable, Analyzer(AnalyzerName.AsString.FrLucene)]
        public string DescriptionFr { get; set; }

        [IsSearchable, IsFilterable, IsFacetable]
        public string Type { get; set; }

        [IsFilterable, IsFacetable]
        public double? BaseRate { get; set; }

        [IsSearchable, IsFilterable, IsFacetable]
        public string BedOptions { get; set; }

        [IsFilterable, IsFacetable]
        public int? SleepsCount { get; set; }

        [IsFilterable, IsFacetable]
        public bool? SmokingAllowed { get; set; }

        [IsSearchable, IsFilterable, IsFacetable]
        public string[] Tags { get; set; }
    }
}
