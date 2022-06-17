// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core.GeoJson;
using Azure.Core;

namespace Azure.Maps.Search.Models
{
    /// <summary> The entry point for the POI being returned. </summary>
    public partial class EntryPoint
    {
        /// <summary> A location represented as a latitude and longitude using short names &apos;lat&apos; &amp; &apos;lon&apos;. </summary>
        [CodeGenMember("Position")]
        internal LatLongPairAbbreviated PositionInternal { get; }

        /// <summary> A location represented as a latitude and longitude using short names &apos;lat&apos; &amp; &apos;lon&apos;. </summary>
        public GeoPosition Position {
            get { return new GeoPosition((double) PositionInternal.Lon, (double) PositionInternal.Lat); }
        }
    }
}
