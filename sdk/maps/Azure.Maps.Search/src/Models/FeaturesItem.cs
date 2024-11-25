// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.Core.GeoJson;
using Azure.Maps.Common;

namespace Azure.Maps.Search.Models
{
    [CodeGenSerialization(nameof(BoundingBoxInternal), "boundingBox")]
    public partial class FeaturesItem
    {
        /// <summary> Initializes a new instance of <see cref="FeaturesItem"/>. </summary>
        /// <param name="geometry"> A valid <c>GeoJSON Point</c> geometry type. Please refer to <see href="https://tools.ietf.org/html/rfc7946#section-3.1.2">RFC 7946</see> for details. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="geometry"/> is null. </exception>
        internal FeaturesItem(GeoJsonPoint geometry)
        {
            Argument.AssertNotNull(geometry, nameof(geometry));

            GeometryInternal = geometry;
            Geometry = new GeoPoint(geometry.Coordinates[0], geometry.Coordinates[1]);
        }

        /// <summary> Initializes a new instance of <see cref="FeaturesItem"/>. </summary>
        /// <param name="type"> The type of a feature must be Feature. </param>
        /// <param name="id"> ID for feature returned. </param>
        /// <param name="properties"></param>
        /// <param name="geometry"> A valid <c>GeoJSON Point</c> geometry type. Please refer to <see href="https://tools.ietf.org/html/rfc7946#section-3.1.2">RFC 7946</see> for details. </param>
        /// <param name="boundingBox"> Bounding box. Projection used - EPSG:3857. Please refer to <see href="https://datatracker.ietf.org/doc/html/rfc7946#section-5">RFC 7946</see> for details. </param>
        internal FeaturesItem(FeatureTypeEnum? type, string id, FeaturesItemProperties properties, GeoJsonPoint geometry, IReadOnlyList<double> boundingBox)
        {
            Type = type;
            Id = id;
            Properties = properties;
            GeometryInternal = geometry;
            Geometry = new GeoPoint(geometry.Coordinates[0], geometry.Coordinates[1]);

            BoundingBoxInternal = boundingBox;
            if (BoundingBoxInternal != null && BoundingBoxInternal.Count == 4)
            {
                BoundingBox = new GeoBoundingBox(
                    BoundingBoxInternal[0], // west
                    BoundingBoxInternal[1], // south
                    BoundingBoxInternal[2], // east
                    BoundingBoxInternal[3]  // north
                );
            }
        }

        /// <summary>
        /// Bounding box. Projection used - EPSG:3857. Please refer to <see href="https://datatracker.ietf.org/doc/html/rfc7946#section-5">RFC 7946</see> for details.
        /// </summary>
        public GeoBoundingBox BoundingBox { get; }

        /// <summary> A GeoJson point object for the geocoding result. </summary>
        public GeoPoint Geometry { get; }

        [CodeGenMember("Geometry")]
        internal GeoJsonPoint GeometryInternal { get; }

        [CodeGenMember("BoundingBox")]
        internal IReadOnlyList<double> BoundingBoxInternal { get; }
    }
}
