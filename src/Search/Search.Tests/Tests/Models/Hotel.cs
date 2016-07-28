// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.Azure.Search.Models;
    using Microsoft.Spatial;

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
                this.HotelId == other.HotelId &&
                this.BaseRate == other.BaseRate &&
                this.Description == other.Description &&
                this.DescriptionFr == other.DescriptionFr &&
                this.HotelName == other.HotelName &&
                this.Category == other.Category &&
                ((this.Tags == null) ? (other.Tags == null || other.Tags.Length == 0) : this.Tags.SequenceEqual(other.Tags ?? new string[0])) &&
                this.ParkingIncluded == other.ParkingIncluded &&
                this.SmokingAllowed == other.SmokingAllowed &&
                this.LastRenovationDate == other.LastRenovationDate &&
                this.Rating == other.Rating &&
                ((this.Location == null) ? other.Location == null : this.Location.Equals(other.Location));
        }

        public override int GetHashCode()
        {
            return (this.HotelId != null) ? this.HotelId.GetHashCode() : 0;
        }

        public override string ToString()
        {
            const string Format =
                "ID: {0}; BaseRate: {1}; Description: {2}; Description (French): {3}; Name: {4}; Category: {5}; " +
                "Tags: {6}; Parking: {7}; Smoking: {8}; LastRenovationDate: {9}; Rating: {10}; " +
                "Location: [{11}, {12}]";

            return String.Format(
                Format,
                this.HotelId,
                this.BaseRate,
                this.Description,
                this.DescriptionFr,
                this.HotelName,
                this.Category,
                (this.Tags != null) ? this.Tags.ToCommaSeparatedString() : "null",
                this.ParkingIncluded,
                this.SmokingAllowed,
                this.LastRenovationDate,
                this.Rating,
                this.Location != null ? this.Location.Longitude : 0,
                this.Location != null ? this.Location.Latitude : 0);
        }

        public Document AsDocument()
        {
            return new Document()
            {
                { "baseRate", this.BaseRate },
                { "category", this.Category },
                { "description", this.Description },
                { "descriptionFr", this.DescriptionFr },
                { "hotelId", this.HotelId },
                { "hotelName", this.HotelName },
                { "lastRenovationDate", this.LastRenovationDate },
                { "location", this.Location },
                { "parkingIncluded", this.ParkingIncluded },
                { "rating", this.Rating.HasValue ? (long?)this.Rating.Value : null }, // JSON.NET always deserializes to int64
                { "smokingAllowed", this.SmokingAllowed },
                { "tags", this.Tags ?? new string[0] }   // OData always gives [] instead of null for collections.
            };
        }
    }
}
