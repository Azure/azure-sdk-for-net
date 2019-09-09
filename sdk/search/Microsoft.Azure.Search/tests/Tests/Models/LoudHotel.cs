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

    public class LoudHotelAddress
    {
        [CustomField("streetAddress")]
        public string STREETADDRESS { get; set; }

        [CustomField("city")]
        public string CITY { get; set; }

        [CustomField("stateProvince")]
        public string STATEPROVINCE { get; set; }

        [CustomField("country")]
        public string COUNTRY { get; set; }

        [CustomField("postalCode")]
        public string POSTALCODE { get; set; }

        public override bool Equals(object obj) =>
            obj is LoudHotelAddress other &&
            STREETADDRESS == other.STREETADDRESS &&
            CITY == other.CITY &&
            STATEPROVINCE == other.STATEPROVINCE &&
            COUNTRY == other.COUNTRY &&
            POSTALCODE == other.POSTALCODE;

        public override int GetHashCode() => STREETADDRESS?.GetHashCode() ?? 0;

        public override string ToString() =>
            $"StreetAddress: {STREETADDRESS}; City: {CITY}; State/Province: {STATEPROVINCE}; Country: {COUNTRY}; " +
            $"PostalCode: {POSTALCODE}";

        public HotelAddress ToHotelAddress() =>
            new HotelAddress()
            {
                StreetAddress = STREETADDRESS,
                City = CITY,
                StateProvince = STATEPROVINCE,
                Country = COUNTRY,
                PostalCode = POSTALCODE
            };
    }

    public class LoudHotelRoom
    {
        [CustomField("description")]
        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        public string DESCRIPTION { get; set; }

        [CustomField("descriptionFr")]
        public string DESCRIPTIONFRENCH { get; set; }   // Intentionally different name, not just different case.

        [CustomField("type")]
        public string TYPE { get; set; }

        [CustomField("baseRate")]
        public double BASERATE { get; set; }

        [CustomField("bedOptions")]
        public string BEDOPTIONS { get; set; }

        [CustomField("sleepsCount")]
        public int? SLEEPSCOUNT { get; set; }

        [CustomField("smokingAllowed")]
        public bool SMOKINGALLOWED { get; set; }

        [CustomField("tags")]
        public string[] TAGS { get; set; }

        public override bool Equals(object obj) =>
            obj is LoudHotelRoom other &&
            DESCRIPTION == other.DESCRIPTION &&
            DESCRIPTIONFRENCH == other.DESCRIPTIONFRENCH &&
            TYPE == other.TYPE &&
            BASERATE == other.BASERATE &&
            BEDOPTIONS == other.BEDOPTIONS &&
            SLEEPSCOUNT == other.SLEEPSCOUNT &&
            SMOKINGALLOWED == other.SMOKINGALLOWED &&
            TAGS.SequenceEqualsNullSafe(other.TAGS);

        public override int GetHashCode() => DESCRIPTION?.GetHashCode() ?? 0;

        public override string ToString() =>
            $"Description: {DESCRIPTION}; Description (French): {DESCRIPTIONFRENCH}; Type: {TYPE}; BaseRate: {BASERATE}; " +
            $"Bed Options: {BEDOPTIONS}; Sleeps: {SLEEPSCOUNT}; Smoking: {SMOKINGALLOWED}; " +
            $"Tags: {TAGS?.ToCommaSeparatedString() ?? "null"}";

        public HotelRoom ToHotelRoom() =>
            new HotelRoom()
            {
                Description = DESCRIPTION,
                DescriptionFr = DESCRIPTIONFRENCH,
                Type = TYPE,
                BaseRate = BASERATE,
                BedOptions = BEDOPTIONS,
                SleepsCount = SLEEPSCOUNT,
                SmokingAllowed = SMOKINGALLOWED,
                Tags = TAGS
            };
    }

    public class LoudHotel
    {
        [CustomField("hotelId")]
        public string HOTELID { get; set; }

        [CustomField("hotelName")]
        public string HOTELNAME { get; set; }

        [CustomField("description")]
        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        public string DESCRIPTION { get; set; }

        [CustomField("descriptionFr")]
        public string DESCRIPTIONFRENCH { get; set; }   // Intentionally different name, not just different case.

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

        [CustomField("address")]
        public LoudHotelAddress ADDRESS { get; set; }

        [CustomField("rooms")]
        public LoudHotelRoom[] ROOMS { get; set; }

        public override bool Equals(object obj) =>
            obj is LoudHotel other &&
            HOTELID == other.HOTELID &&
            HOTELNAME == other.HOTELNAME &&
            DESCRIPTION == other.DESCRIPTION &&
            DESCRIPTIONFRENCH == other.DESCRIPTIONFRENCH &&
            CATEGORY == other.CATEGORY &&
            TAGS.SequenceEqualsNullSafe(other.TAGS) &&
            PARKINGINCLUDED == other.PARKINGINCLUDED &&
            SMOKINGALLOWED == other.SMOKINGALLOWED &&
            LASTRENOVATIONDATE == other.LASTRENOVATIONDATE &&
            RATING == other.RATING &&
            LOCATION.EqualsNullSafe(other.LOCATION) &&
            ADDRESS.EqualsNullSafe(other.ADDRESS) &&
            ROOMS.SequenceEqualsNullSafe(other.ROOMS);

        public override int GetHashCode() => HOTELID?.GetHashCode() ?? 0;

        public override string ToString()
        {
            string FormatRoom(LoudHotelRoom room) => $"{{ {room} }}";

            return
                $"ID: {HOTELID}; Name: {HOTELNAME}; Description: {DESCRIPTION}; " +
                $"Description (French): {DESCRIPTIONFRENCH}; Category: {CATEGORY}; " +
                $"Tags: {TAGS?.ToCommaSeparatedString() ?? "null"}; Parking: {PARKINGINCLUDED}; " +
                $"Smoking: {SMOKINGALLOWED}; LastRenovationDate: {LASTRENOVATIONDATE}; Rating: {RATING}; " +
                $"Location: [{LOCATION?.Longitude ?? 0}, {LOCATION?.Latitude ?? 0}]; " +
                $"Address: {{ {ADDRESS} }}; Rooms: [{string.Join("; ", ROOMS?.Select(FormatRoom) ?? new string[0])}]";
        }

        public Hotel ToHotel() =>
            new Hotel()
            {
                HotelId = HOTELID,
                HotelName = HOTELNAME,
                Description = DESCRIPTION,
                DescriptionFr = DESCRIPTIONFRENCH,
                Category = CATEGORY,
                Tags = TAGS,
                ParkingIncluded = PARKINGINCLUDED,
                SmokingAllowed = SMOKINGALLOWED,
                LastRenovationDate = LASTRENOVATIONDATE,
                Rating = RATING,
                Location = LOCATION,
                Address = ADDRESS?.ToHotelAddress(),
                Rooms = ROOMS?.Select(r => r.ToHotelRoom())?.ToArray()
            };
    }
}
