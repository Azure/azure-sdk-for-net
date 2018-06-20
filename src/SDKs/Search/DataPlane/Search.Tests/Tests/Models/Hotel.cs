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
    public class Hotel
    {
        public string HotelId { get; set; }

        public double? BaseRate { get; set; }

        public string Description { get; set; }

        public string DescriptionFr { get; set; }

        public string HotelName { get; set; }

        public string Category { get; set; }

        public string[] Tags { get; set; }

        public bool? ParkingIncluded { get; set; }

        public bool? SmokingAllowed { get; set; }

        public DateTimeOffset? LastRenovationDate { get; set; }

        public int? Rating { get; set; }

        public GeographyPoint Location { get; set; }

        public override bool Equals(object obj)
        {
            Hotel other = obj as Hotel;

            if (other == null)
            {
                return false;
            }

            return
                HotelId == other.HotelId &&
                DoublesEqual(BaseRate, other.BaseRate) &&
                Description == other.Description &&
                DescriptionFr == other.DescriptionFr &&
                HotelName == other.HotelName &&
                Category == other.Category &&
                ((Tags == null) ? (other.Tags == null || other.Tags.Length == 0) : Tags.SequenceEqual(other.Tags ?? new string[0])) &&
                ParkingIncluded == other.ParkingIncluded &&
                SmokingAllowed == other.SmokingAllowed &&
                DateTimeOffsetsEqual(LastRenovationDate, other.LastRenovationDate) &&
                Rating == other.Rating &&
                ((Location == null) ? other.Location == null : Location.Equals(other.Location));
        }

        public override int GetHashCode() => HotelId?.GetHashCode() ?? 0;

        public override string ToString() =>
            $"ID: {HotelId}; BaseRate: {BaseRate}; Description: {Description}; " +
            $"Description (French): {DescriptionFr}; Name: {HotelName}; Category: {Category}; " +
            $"Tags: {Tags?.ToCommaSeparatedString() ?? "null"}; Parking: {ParkingIncluded}; " +
            $"Smoking: {SmokingAllowed}; LastRenovationDate: {LastRenovationDate}; Rating: {Rating}; " +
            $"Location: [{Location?.Longitude ?? 0}, {Location?.Latitude ?? 0}]";

        public Document AsDocument() =>
            new Document()
            {
                ["baseRate"] = BaseRate,
                ["category"] = Category,
                ["description"] = Description,
                ["descriptionFr"] = DescriptionFr,
                ["hotelId"] = HotelId,
                ["hotelName"] = HotelName,
                ["lastRenovationDate"] = LastRenovationDate,
                ["location"] = Location,
                ["parkingIncluded"] = ParkingIncluded,
                ["rating"] = Rating.HasValue ? (long?)Rating.Value : null, // JSON.NET always deserializes to int64
                ["smokingAllowed"] = SmokingAllowed,
                ["tags"] = Tags ?? new string[0]   // OData always gives [] instead of null for collections.
            };

        private static bool DoublesEqual(double? x, double? y)
        {
            if (x == null)
            {
                return y == null;
            }

            if (Double.IsNaN(x.Value))
            {
                return y != null && Double.IsNaN(y.Value);
            }

            return x == y;
        }

        private static bool DateTimeOffsetsEqual(DateTimeOffset? a, DateTimeOffset? b)
        {
            if (a == null)
            {
                return b == null;
            }

            if (b == null)
            {
                return false;
            }

            if (a.Value.EqualsExact(b.Value))
            {
                return true;
            }

            // Allow for some loss of precision in the tick count.
            long aTicks = a.Value.UtcTicks;
            long bTicks = b.Value.UtcTicks;

            return (aTicks / 10000) == (bTicks / 10000);
        }
    }
}
