// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core.GeoJson;
using Azure.Core;

namespace Azure.Maps.Search.Models
{
    /// <summary> The viewport that covers the result represented by the top-left and bottom-right coordinates of the viewport. </summary>
    internal partial class Viewport
    {
        /// <summary> A location represented as a latitude and longitude using short names &apos;lat&apos; &amp; &apos;lon&apos;. </summary>
        [CodeGenMember("TopLeftPoint")]
        internal LatLongPairAbbreviated TopLeftPointInternal { get; }
        /// <summary> A location represented as a latitude and longitude using short names &apos;lat&apos; &amp; &apos;lon&apos;. </summary>
        [CodeGenMember("BtmRightPoint")]
        internal LatLongPairAbbreviated BtmRightPointInternal { get; }

        /// <summary> A location represented as a latitude and longitude using short names &apos;lat&apos; &amp; &apos;lon&apos;. </summary>
        internal GeoPosition TopLeftPoint {
            get { return new GeoPosition((double) TopLeftPointInternal.Lon, (double) TopLeftPointInternal.Lat); }
        }

         /// <summary> A location represented as a latitude and longitude using short names &apos;lat&apos; &amp; &apos;lon&apos;. </summary>
        internal GeoPosition BtmRightPoint {
            get { return new GeoPosition((double) BtmRightPointInternal.Lon, (double) BtmRightPointInternal.Lat); }
        }
    }
}
