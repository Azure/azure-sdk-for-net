// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System.Globalization;
using System.Text;
using Azure.Core.GeoJson;

// cspell:ignore udid
namespace Azure.Maps.Rendering
{
    /// <summary> Represent the geo position of a pushpin or a point for a path. </summary>
    public class PushpinPosition
    {
        /// <summary> Input longitude and latitude of the pushpin location. </summary>
        public PushpinPosition(double longitude, double latitude, string? label = null)
        {
            geoPosition = new GeoPosition(longitude, latitude);
            this.label = label;
        }

        private GeoPosition? geoPosition { get; }

        private string? label { get; }

        /// <summary> Convert PushpinPosition to server readable string. </summary>
        internal string ToQueryString()
        {
            StringBuilder sb = new StringBuilder(64);

            if (label != null)
            {
                sb.AppendFormat(CultureInfo.InvariantCulture, "'{0}'", label);
            }

            if (geoPosition != null)
            {
                sb.AppendFormat(CultureInfo.InvariantCulture, "{0} {1}", geoPosition?.Longitude, geoPosition?.Latitude);
            }

            return sb.ToString();
        }
    }
}
