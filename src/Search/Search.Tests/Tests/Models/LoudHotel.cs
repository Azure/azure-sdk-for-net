// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Tests
{
    using System;
    using System.Linq;
    using Microsoft.Spatial;

    public class LoudHotel
    {
        public string HOTELID { get; set; }

        public double BASERATE { get; set; }

        public string DESCRIPTION { get; set; }

        public string DESCRIPTIONFR { get; set; }

        public string HOTELNAME { get; set; }

        public string CATEGORY { get; set; }

        public string[] TAGS { get; set; }

        public bool PARKINGINCLUDED { get; set; }

        public bool SMOKINGALLOWED { get; set; }

        public DateTimeOffset LASTRENOVATIONDATE { get; set; }

        public int RATING { get; set; }

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
                this.DESCRIPTIONFR == other.DESCRIPTIONFR &&
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
                this.DESCRIPTIONFR,
                this.HOTELNAME,
                this.CATEGORY,
                (this.TAGS != null) ? String.Join(",", this.TAGS) : "null",
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
                DescriptionFr = DESCRIPTIONFR,
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
