// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Tests
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using Common;
    using Models;
    using Spatial;

    // MAINTENANCE NOTE: Keep these types in sync with the fields defined by IndexFixture.CreateTestIndex().
    // Any changes to property names, types, attributes, or ordering must be reflected in both places or
    // tests will fail.

    [SerializePropertyNamesAsCamelCase]
    public struct StructHotelAddress
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

        public override bool Equals(object obj) =>
            obj is StructHotelAddress other &&
            StreetAddress == other.StreetAddress &&
            City == other.City &&
            StateProvince == other.StateProvince &&
            Country == other.Country &&
            PostalCode == other.PostalCode;

        public override int GetHashCode() => StreetAddress?.GetHashCode() ?? 0;

        public override string ToString() =>
            $"StreetAddress: {StreetAddress}; City: {City}; State/Province: {StateProvince}; Country: {Country}; " +
            $"PostalCode: {PostalCode}";
    }

    [SerializePropertyNamesAsCamelCase]
    public struct StructHotelRoom
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

        public override bool Equals(object obj) =>
            obj is StructHotelRoom other &&
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
    }

    [SerializePropertyNamesAsCamelCase]
    public struct StructHotel
    {
        [Key, IsFilterable, IsSortable, IsFacetable]
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

        public StructHotelAddress Address { get; set; }

        public StructHotelRoom[] Rooms { get; set; }

        public override bool Equals(object obj) =>
            obj is StructHotel other &&
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
            Location.EqualsNullSafe(other.Location) &&
            Address.Equals(other.Address) &&
            Rooms.SequenceEqualsNullSafe(other.Rooms);

        public override int GetHashCode() => HotelId?.GetHashCode() ?? 0;

        public override string ToString()
        {
            string FormatRoom(StructHotelRoom room) => $"{{ {room} }}";

            return
                $"ID: {HotelId}; Name: {HotelName}; Description: {Description}; " +
                $"Description (French): {DescriptionFr}; Category: {Category}; " +
                $"Tags: {Tags?.ToCommaSeparatedString() ?? "null"}; Parking: {ParkingIncluded}; " +
                $"Smoking: {SmokingAllowed}; LastRenovationDate: {LastRenovationDate}; Rating: {Rating}; " +
                $"Location: [{Location?.Longitude ?? 0}, {Location?.Latitude ?? 0}]; " +
                $"Address: {{ {Address} }}; Rooms: [{string.Join("; ", Rooms?.Select(FormatRoom) ?? new string[0])}]";
        }
    }
}
