// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Tests
{
    using System;
    using System.Linq;
    using Common;
    using Newtonsoft.Json;
    using Spatial;

    public class LoudHotel
    {
        [CustomField("hotelId")]
        public string HOTELID { get; set; }

        [CustomField("baseRate")]
        public double BASERATE { get; set; }

        [CustomField("description")]
        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        public string DESCRIPTION { get; set; }

        [CustomField("descriptionFr")]
        public string DESCRIPTIONFRENCH { get; set; }   // Intentionally different name, not just different case.

        [CustomField("hotelName")]
        public string HOTELNAME { get; set; }

        [CustomField("category")]
        public string CATEGORY { get; set; }

        [CustomField("tags")]
        public string[] TAGS { get; set; }

        [CustomField("parkingIncluded")]
        public bool PARKINGINCLUDED { get; set; }

        [CustomField("smokingAllowed")]
        public bool SMOKINGALLOWED { get; set; }

        [CustomField("lastRenovationDate")]
        public DateTimeOffset LASTRENOVATIONDATE { get; set; }

        [CustomField("rating")]
        public int RATING { get; set; }

        [CustomField("location")]
        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        public GeographyPoint LOCATION { get; set; }

        public override bool Equals(object obj)
        {
            LoudHotel other = obj as LoudHotel;

            if (other == null)
            {
                return false;
            }

            return
                HOTELID == other.HOTELID &&
                BASERATE == other.BASERATE &&
                DESCRIPTION == other.DESCRIPTION &&
                DESCRIPTIONFRENCH == other.DESCRIPTIONFRENCH &&
                HOTELNAME == other.HOTELNAME &&
                CATEGORY == other.CATEGORY &&
                ((TAGS == null) ? (other.TAGS == null || other.TAGS.Length == 0) : TAGS.SequenceEqual(other.TAGS ?? new string[0])) &&
                PARKINGINCLUDED == other.PARKINGINCLUDED &&
                SMOKINGALLOWED == other.SMOKINGALLOWED &&
                LASTRENOVATIONDATE == other.LASTRENOVATIONDATE &&
                RATING == other.RATING &&
                ((LOCATION == null) ? other.LOCATION == null : LOCATION.Equals(other.LOCATION));
        }

        public override int GetHashCode() => HOTELID?.GetHashCode() ?? 0;

        public override string ToString() =>
            $"ID: {HOTELID}; BaseRate: {BASERATE}; Description: {DESCRIPTION}; " +
            $"Description (French): {DESCRIPTIONFRENCH}; Name: {HOTELNAME}; Category: {CATEGORY}; " +
            $"Tags: {TAGS?.ToCommaSeparatedString() ?? "null"}; Parking: {PARKINGINCLUDED}; " +
            $"Smoking: {SMOKINGALLOWED}; LastRenovationDate: {LASTRENOVATIONDATE}; Rating: {RATING}; " +
            $"Location: [{LOCATION?.Longitude ?? 0}, {LOCATION?.Latitude ?? 0}]";

        public Hotel ToHotel() =>
            new Hotel()
            {
                BaseRate = BASERATE,
                Category = CATEGORY,
                Description = DESCRIPTION,
                DescriptionFr = DESCRIPTIONFRENCH,
                HotelId = HOTELID,
                HotelName = HOTELNAME,
                LastRenovationDate = LASTRENOVATIONDATE,
                Location = LOCATION,
                ParkingIncluded = PARKINGINCLUDED,
                Rating = RATING,
                SmokingAllowed = SMOKINGALLOWED,
                Tags = TAGS
            };
    }
}
