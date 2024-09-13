// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.GeoJson;
using Azure.Maps.Search.Models.Options;

namespace Azure.Maps.Search.Models.Queries
{
    /// <summary> Options. </summary>
    public class GeocodingQuery : BaseOptions
    {
        /// <summary> Maximum number of responses that will be returned. Default: 5, minimum: 1 and maximum: 20. </summary>
        public int? Top { get; set; }

        /// <summary> id of the request which would show in corresponding batchItem. </summary>
        public string OptionalId { get; set; }
        /// <summary> Maximum number of responses that will be returned. Default: 5, minimum: 1 and maximum: 20. </summary>

        public string Query { get; set; }

        /// <summary> Signal for the geocoding result to an <see href="https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2">ISO 3166-1 Alpha-2 region/country code</see> that is specified e.g. FR./ If query is given, should not use this parameter.</summary>
        public string AddressLine { get; set; }

        /// <summary>The official street line of an address relative to the area, as specified by the locality, or postalCode, properties. Typical use of this element would be to provide a street address or any official address. If query is given, should not use this parameter.</summary>
        public string CountryRegion { get; set; }

        /// <summary>A rectangular area on the earth defined as a bounding box object. The sides of the rectangles are defined by longitude and latitude values. When you specify this parameter, the geographical area is taken into account when computing the results of a location query. Example: GeoBoundingBox(west, south, east, north). </summary>
        public GeoBoundingBox BoundingBox { get; set; }

        /// <summary>The country subdivision portion of an address, such as WA. If query is given, should not use this parameter.</summary>
        public string AdminDistrict { get; set; }

        /// <summary> The county for the structured address, such as King. If query is given, should not use this parameter.</summary>
        public string AdminDistrict2 { get; set; }

        /// <summary>The named area for the structured address. If query is given, should not use this parameter.</summary>
        public string AdminDistrict3 { get; set; }

        /// <summary>The locality portion of an address, such as Seattle. If query is given, should not use this parameter.</summary>
        public string Locality { get; set; }

        /// <summary>The postal code portion of an address. If query is given, should not use this parameter.</summary>
        public string PostalCode { get; set; }
    }
}
