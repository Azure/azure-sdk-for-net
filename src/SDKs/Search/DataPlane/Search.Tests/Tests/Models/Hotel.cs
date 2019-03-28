// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Tests
{
    using System;
    using System.Linq;
    using Common;
    using Models;
    using Spatial;

    [SerializePropertyNamesAsCamelCase]
    public class HotelAddress
    {
        public string StreetAddress { get; set; }

        public string City { get; set; }

        public string StateProvince { get; set; }

        public string Country { get; set; }

        public string PostalCode { get; set; }

        public override bool Equals(object obj)
        {
            if (!(obj is HotelAddress other))
            {
                return false;
            }

            return
                StreetAddress == other.StreetAddress &&
                City == other.City &&
                StateProvince == other.StateProvince &&
                Country == other.Country &&
                PostalCode == other.PostalCode;
        }

        public override int GetHashCode() => StreetAddress?.GetHashCode() ?? 0;

        public override string ToString() =>
            $"StreetAddress: {StreetAddress}; City: {City}; State/Province: {StateProvince}; Country: {Country}; " +
            $"PostalCode: {PostalCode}";

        public Document AsDocument() =>
            new Document()
            {
                ["streetAddress"] = StreetAddress,
                ["city"] = City,
                ["stateProvince"] = StateProvince,
                ["country"] = Country,
                ["postalCode"] = PostalCode
            };
    }

    [SerializePropertyNamesAsCamelCase]
    public class HotelRoom
    {
        public string Description { get; set; }

        public string DescriptionFr { get; set; }

        public string Type { get; set; }

        public double? BaseRate { get; set; }

        public string BedOptions { get; set; }

        public int? SleepsCount { get; set; }

        public bool? SmokingAllowed { get; set; }

        public string[] Tags { get; set; }

        public override bool Equals(object obj)
        {
            if (!(obj is HotelRoom other))
            {
                return false;
            }

            return
                Description == other.Description &&
                DescriptionFr == other.DescriptionFr &&
                Type == other.Type &&
                BaseRate.EqualsDouble(other.BaseRate) &&
                BedOptions == other.BedOptions &&
                SleepsCount == other.SleepsCount &&
                SmokingAllowed == other.SmokingAllowed &&
                Tags.SequenceEqualsNullSafe(other.Tags);
        }

        public override int GetHashCode() => Description?.GetHashCode() ?? 0;

        public override string ToString() =>
            $"Description: {Description}; Description (French): {DescriptionFr}; Type: {Type}; BaseRate: {BaseRate}; " +
            $"Bed Options: {BedOptions}; Sleeps: {SleepsCount}; Smoking: {SmokingAllowed}; " +
            $"Tags: {Tags?.ToCommaSeparatedString() ?? "null"}";

        public Document AsDocument() =>
            new Document()
            {
                ["description"] = Description,
                ["descriptionFr"] = DescriptionFr,
                ["type"] = Type,
                ["baseRate"] = BaseRate,
                ["bedOptions"] = BedOptions,
                ["sleepsCount"] = SleepsCount,
                ["smokingAllowed"] = SmokingAllowed,
                ["tags"] = Tags ?? new string[0]   // OData always gives [] instead of null for collections.
            };
    }

    [SerializePropertyNamesAsCamelCase]
    public class Hotel
    {
        public string HotelId { get; set; }

        public string HotelName { get; set; }

        public string Description { get; set; }

        public string DescriptionFr { get; set; }

        public string Category { get; set; }

        public string[] Tags { get; set; }

        public bool? ParkingIncluded { get; set; }

        public bool? SmokingAllowed { get; set; }

        public DateTimeOffset? LastRenovationDate { get; set; }

        public int? Rating { get; set; }

        public GeographyPoint Location { get; set; }

        public HotelAddress Address { get; set; }

        public HotelRoom[] Rooms { get; set; }

        public override bool Equals(object obj)
        {
            if (!(obj is Hotel other))
            {
                return false;
            }

            return
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
                Address.EqualsNullSafe(other.Address) &&
                Rooms.SequenceEqualsNullSafe(other.Rooms);
        }

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

        public Document AsDocument() =>
            new Document()
            {
                ["hotelId"] = HotelId,
                ["hotelName"] = HotelName,
                ["description"] = Description,
                ["descriptionFr"] = DescriptionFr,
                ["category"] = Category,
                ["tags"] = Tags ?? new string[0],   // OData always gives [] instead of null for collections.
                ["parkingIncluded"] = ParkingIncluded,
                ["smokingAllowed"] = SmokingAllowed,
                ["lastRenovationDate"] = LastRenovationDate,
                ["rating"] = Rating.HasValue ? (long?)Rating.Value : null, // JSON.NET always deserializes to int64
                ["location"] = Location,
                ["address"] = Address.AsDocument(),
                ["rooms"] = Rooms?.Select(r => r.AsDocument())?.ToArray() ?? new Document[0]
            };
    }
}
