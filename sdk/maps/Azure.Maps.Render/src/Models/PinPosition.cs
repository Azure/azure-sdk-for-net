// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System.Text;
using Azure.Core.GeoJson;

// cspell:ignore udid
namespace Azure.Maps.Render
{
    /// <summary> Represent the geo position of a pushpin or a point for a path. </summary>
    public class PinPosition
    {
        /// <summary> Input longitude and latitude of the pushpin location. </summary>
        public PinPosition(double longitude, double latitude, string? label = null)
        {
            this.geoPosition = new GeoPosition(longitude, latitude);
            this.label = label;
        }

        /// <summary>
        /// To use the point geometry from an uploaded GeoJSON document as the pin locations,
        /// specify the UDID as the pushpin location
        /// </summary>
        public PinPosition(string dataStorageId, string? label = null)
        {
            this.udid = dataStorageId;
            this.label = label;
        }

        private GeoPosition? geoPosition { get; }
        private string? udid { get; }
        private string? label { get; }

        /// <summary> Convert PinPosition to server readable string. </summary>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(64);

            if (this.label != null)
            {
                sb.Append($"'{this.label}'");
            }

            if (this.geoPosition != null)
            {
                sb.Append($"{this.geoPosition?.Longitude} {this.geoPosition?.Latitude}");
            }
            else
            {
                sb.Append(this.udid);
            }
            return sb.ToString();
        }
    }
}
