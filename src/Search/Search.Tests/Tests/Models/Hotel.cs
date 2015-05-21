// 
// Copyright (c) Microsoft.  All rights reserved. 
// 
// Licensed under the Apache License, Version 2.0 (the "License"); 
// you may not use this file except in compliance with the License. 
// You may obtain a copy of the License at 
//   http://www.apache.org/licenses/LICENSE-2.0 
// 
// Unless required by applicable law or agreed to in writing, software 
// distributed under the License is distributed on an "AS IS" BASIS, 
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. 
// See the License for the specific language governing permissions and 
// limitations under the License. 
// 

using System;
using System.Linq;
using Microsoft.Azure.Search.Models;
using Microsoft.Spatial;

namespace Microsoft.Azure.Search.Tests
{
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
                BaseRate == other.BaseRate &&
                Description == other.Description &&
                DescriptionFr == other.DescriptionFr &&
                HotelName == other.HotelName &&
                Category == other.Category &&
                ((Tags == null) ? (other.Tags == null || other.Tags.Length == 0) : Tags.SequenceEqual(other.Tags ?? new string[0])) &&
                ParkingIncluded == other.ParkingIncluded &&
                SmokingAllowed == other.SmokingAllowed &&
                LastRenovationDate == other.LastRenovationDate &&
                Rating == other.Rating &&
                ((Location == null) ? other.Location == null : Location.Equals(other.Location));
        }

        public override int GetHashCode()
        {
            return (HotelId != null) ? HotelId.GetHashCode() : 0;
        }

        public override string ToString()
        {
            const string Format =
                "ID: {0}; BaseRate: {1}; Description: {2}; Description (French): {3}; Name: {4}; Category: {5}; " +
                "Tags: {6}; Parking: {7}; Smoking: {8}; LastRenovationDate: {9}; Rating: {10}; " +
                "Location: [{11}, {12}]";

            return String.Format(
                Format,
                HotelId,
                BaseRate,
                Description,
                DescriptionFr,
                HotelName,
                Category,
                (Tags != null) ? String.Join(",", Tags) : "null",
                ParkingIncluded,
                SmokingAllowed,
                LastRenovationDate,
                Rating,
                Location != null ? Location.Longitude : 0,
                Location != null ? Location.Latitude : 0);
        }

        public Document AsDocument()
        {
            return new Document()
            {
                { "baseRate", BaseRate },
                { "category", Category },
                { "description", Description },
                { "descriptionFr", DescriptionFr },
                { "hotelId", HotelId },
                { "hotelName", HotelName },
                { "lastRenovationDate", LastRenovationDate },
                { "location", Location },
                { "parkingIncluded", ParkingIncluded },
                { "rating", Rating.HasValue ? (long?)Rating.Value : null }, // JSON.NET always deserializes to int64
                { "smokingAllowed", SmokingAllowed },
                { "tags", Tags ?? new string[0] }   // OData always gives [] instead of null for collections.
            };
        }
    }
}
