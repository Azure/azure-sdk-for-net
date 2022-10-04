// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

namespace Azure.Maps.Routing.Models
{
    /// <summary> A location represented as a latitude and longitude. </summary>
    [CodeGenModel("LatLongPair")]
    internal partial class LatLongPair
    {
        /// <summary> Initializes a new instance of LatLongPair. </summary>
        /// <param name="latitude"> Latitude property. </param>
        /// <param name="longitude"> Longitude property. </param>
        internal LatLongPair(double? latitude, double? longitude)
        {
            Latitude = latitude.GetValueOrDefault();
            Longitude = longitude.GetValueOrDefault();
            _Latitude = latitude;
            _Longitude = longitude;
        }

        /// <summary> Latitude property. </summary>
        [CodeGenMember("Latitude")]
        internal double? _Latitude { get; }
        /// <summary> Longitude property. </summary>
        [CodeGenMember("Longitude")]
        internal double? _Longitude { get; }

        /// <summary> Latitude property. </summary>
        public double Latitude { get; }
        /// <summary> Longitude property. </summary>
        public double Longitude { get; }
    }
}
