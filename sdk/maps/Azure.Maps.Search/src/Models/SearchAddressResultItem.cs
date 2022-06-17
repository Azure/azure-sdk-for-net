// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Azure.Core.GeoJson;

namespace Azure.Maps.Search.Models
{
    [CodeGenModel("SearchAddressResultItem")]
    public partial class SearchAddressResultItem
    {
        /// <summary> Information about the original data source of the Result. Used for support requests. </summary>
        [CodeGenMember("Info")]
        public string DataSourceInfo { get; }

        /// <summary> A location represented as a latitude and longitude using short names &apos;lat&apos; &amp; &apos;lon&apos;. </summary>
        [CodeGenMember("Position")]
        internal LatLongPairAbbreviated PositionInternal { get; }

        /// <summary> The viewport that covers the result represented by the top-left and bottom-right coordinates of the viewport. </summary>
        [CodeGenMember("Viewport")]
        internal BoundingBox ViewportInternal { get; }

        /// <summary> A location represented as a latitude and longitude using short names &apos;lat&apos; &amp; &apos;lon&apos;. </summary>
        public GeoPosition Position {
            get { return new GeoPosition((double) PositionInternal.Lon, (double) PositionInternal.Lat); }
        }

        /// <summary> The viewport that covers the result represented by the top-left and bottom-right coordinates of the viewport. </summary>
        public GeoBoundingBox Viewport {
            get { return new GeoBoundingBox((double) ViewportInternal.TopLeft.Lat, (double) ViewportInternal.BottomRight.Lon, (double) ViewportInternal.BottomRight.Lat, (double) ViewportInternal.TopLeft.Lon); }
        }
    }
}
