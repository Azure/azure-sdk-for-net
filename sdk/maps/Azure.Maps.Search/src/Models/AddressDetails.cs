// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Azure.Core.GeoJson;
using System;
using System.Globalization;

namespace Azure.Maps.Search.Models
{
    /// <summary> The address of the result. </summary>
    [CodeGenModel("Address")]
    public partial class MapsAddress
    {
         /// <summary> ISO alpha-3 country code. </summary>
        [CodeGenMember("CountryCodeISO3")]
        public string CountryCodeIso3 { get; }

        /// <summary> The bounding box of the location. </summary>
        [CodeGenMember("BoundingBox")]
        internal BoundingBoxCompassNotation BoundingBoxInternal { get; }

        /// <summary> The bounding box of the location. </summary>
        public GeoBoundingBox BoundingBox {
            get {
                String northeast = BoundingBoxInternal.NorthEast;
                String[] northEast = northeast.Split(',');
                double north = Convert.ToDouble(northEast[0], CultureInfo.InvariantCulture.NumberFormat);
                double east = Convert.ToDouble(northEast[1], CultureInfo.InvariantCulture.NumberFormat);
                String southwest = BoundingBoxInternal.SouthWest;
                String[] southWest = southwest.Split(',');
                double south = Convert.ToDouble(northEast[0], CultureInfo.InvariantCulture.NumberFormat);
                double west = Convert.ToDouble(northEast[1], CultureInfo.InvariantCulture.NumberFormat);
                return new GeoBoundingBox(west, south, east, north);
            }
        }
    }
}
