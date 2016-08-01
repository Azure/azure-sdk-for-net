// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.Spatial;
    using Newtonsoft.Json;

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
                this.HOTELID == other.HOTELID &&
                this.BASERATE == other.BASERATE &&
                this.DESCRIPTION == other.DESCRIPTION &&
                this.DESCRIPTIONFRENCH == other.DESCRIPTIONFRENCH &&
                this.HOTELNAME == other.HOTELNAME &&
                this.CATEGORY == other.CATEGORY &&
                ((this.TAGS == null) ? (other.TAGS == null || other.TAGS.Length == 0) : this.TAGS.SequenceEqual(other.TAGS ?? new string[0])) &&
                this.PARKINGINCLUDED == other.PARKINGINCLUDED &&
                this.SMOKINGALLOWED == other.SMOKINGALLOWED &&
                this.LASTRENOVATIONDATE == other.LASTRENOVATIONDATE &&
                this.RATING == other.RATING &&
                ((this.LOCATION == null) ? other.LOCATION == null : this.LOCATION.Equals(other.LOCATION));
        }

        public override int GetHashCode()
        {
            return (this.HOTELID != null) ? this.HOTELID.GetHashCode() : 0;
        }

        public override string ToString()
        {
            const string Format =
                "ID: {0}; BaseRate: {1}; Description: {2}; Description (French): {3}; Name: {4}; Category: {5}; " +
                "Tags: {6}; Parking: {7}; Smoking: {8}; LastRenovationDate: {9}; Rating: {10}; " +
                "Location: [{11}, {12}]";

            return String.Format(
                Format,
                this.HOTELID,
                this.BASERATE,
                this.DESCRIPTION,
                this.DESCRIPTIONFRENCH,
                this.HOTELNAME,
                this.CATEGORY,
                (this.TAGS != null) ? this.TAGS.ToCommaSeparatedString() : "null",
                this.PARKINGINCLUDED,
                this.SMOKINGALLOWED,
                this.LASTRENOVATIONDATE,
                this.RATING,
                this.LOCATION != null ? this.LOCATION.Longitude : 0,
                this.LOCATION != null ? this.LOCATION.Latitude : 0);
        }

        public Hotel ToHotel()
        {
            return new Hotel()
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
}
