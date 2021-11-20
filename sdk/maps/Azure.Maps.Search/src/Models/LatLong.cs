// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

namespace Azure.Maps.Search.Models
{
    /// <summary> A location represented as a latitude and longitude using short names &apos;lat&apos; &amp; &apos;lon&apos;. </summary>
    [CodeGenModel("LatLongPairAbbreviated")]
    public partial class LatLong
    {
        /// <summary> Initializes a new instance of LatLong. </summary>
        /// <param name="latitude"> Latitude property. </param>
        /// <param name="longitude"> Longitude property. </param>
        public LatLong(double latitude, double longitude){
            this.Lat = latitude;
            this.Lon = longitude;
        }

        /// <summary> Latitude property. </summary>
        [CodeGenMember("Lat")]
        public double Lat { get; }

        /// <summary> Longitude property. </summary>
        [CodeGenMember("Lon")]
        public double Lon { get; }

        /// <summary> Latitude property. </summary>
        public double Latitude => this.Lat;

        /// <summary> Longitude property. </summary>
        public double Longitude => this.Lon;

        /// <summary> LatLong comma-seperated string representation: lat,lng </summary>
        public override string ToString() => $"{this.Lat},${this.Lon}";
    }
}
