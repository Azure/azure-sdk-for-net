// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.Core.GeoJson;
using Azure.Maps.Common;
using System.Text.Json;

namespace Azure.Maps.Search.Models
{
    /// <summary>
    /// <c>GeoJSON GeocodingFeature</c> object that describe the boundaries of a geographical area. Geometry of the feature is described with <c>GeoJSON GeometryCollection</c>.
    ///
    /// Please note, the service typically returns a GeometryCollection with Polygon or MultiPolygon sub-types.
    /// </summary>
    [CodeGenSerialization(nameof(_boundary), "boundingBox")]
    public class Boundary
    {
        internal BoundaryInternal _boundary;
        internal BoundaryProperties _properties;

        internal Boundary(BoundaryInternal boundaryInternal)
        {
            Argument.AssertNotNull(boundaryInternal, nameof(boundaryInternal));
            _boundary = boundaryInternal;
            if (((GeoJsonGeometryCollection)_boundary.Geometry).Geometries == null)
            {
                return;
            }

            // Try to deserialize boundary properties
            try
            {
                var propertiesString = JsonSerializer.Serialize(_boundary.Properties);
                using var document = JsonDocument.Parse(propertiesString);
                _properties = BoundaryProperties.DeserializeBoundaryProperties(document.RootElement);
            }
            catch
            {
                // Catch all exceptions silently
                _properties = null;
            }

            // The code below converts from Autorest-generated GeoJson classes to Azure.Core.GeoJson types.
            // The goal is to convert `Azure.Maps.Search.Model.GeoJsonGeometryCollection` to `Azure.Core.GeoJson.GeoCollection`
            // and within each geometry collection, covert `Azure.Maps.Search.Model.GeoJsonPolygon` to `Azure.Core.GeoJson.GeoPolygon`
            var geoPolygons = new List<GeoPolygon>();
            foreach (var geometry in ((GeoJsonGeometryCollection)_boundary.Geometry).Geometries)
            {
                var geoLinearRings = new List<GeoLinearRing>();
                foreach (IList<IList<double>> geoPolygon in ((GeoJsonPolygon)geometry).Coordinates)
                {
                    var coordinates = new List<GeoPosition>();
                    foreach (IList<double> coordinate in geoPolygon)
                    {
                        coordinates.Add(new GeoPosition(coordinate[0], coordinate[1]));
                    }
                    geoLinearRings.Add(new GeoLinearRing(coordinates));
                }
                geoPolygons.Add(new GeoPolygon(geoLinearRings));
            }
            Geometry = new GeoCollection(geoPolygons);
        }

        /// <summary>
        /// A valid <c>GeoJSON</c> geometry collection object. Please refer to <see href="https://tools.ietf.org/html/rfc7946#section-3.1">RFC 7946</see> for details.
        /// </summary>
        public GeoCollection Geometry { get; }

        /// <summary> Properties can contain any additional metadata about the `Feature`. Value can be any JSON object or a JSON null value. </summary>
        public BoundaryProperties Properties
        {
            get { return _properties; }
        }
    }
}
