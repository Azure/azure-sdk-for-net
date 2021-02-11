// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;
using System.Text;
using Azure.Core;
#if EXPERIMENTAL_SPATIAL
using Azure.Core.GeoJson;
#endif

namespace Azure.Search.Documents
{
    /// <summary>
    /// Encodes geographic data from both Azure.Core and Microsoft.Spatial for use in OData filters.
    /// </summary>
    internal static class SpatialFormatter
    {
        /// <summary>
        /// Encodes the longitude and latitude of points or positions for use in OData filters.
        /// </summary>
        /// <param name="longitude">The longitude to encode, which may also be known as Y.</param>
        /// <param name="latitude">The latitude to encode, which may also be known as X.</param>
        /// <returns>The OData filter-encoded POINT string.</returns>
        public static string EncodePoint(double longitude, double latitude)
        {
            const int maxLength =
                19 +       // "geography'POINT( )'".Length
                2 *        // Lat and Long each have:
                   (15 +   //     Maximum precision for a double (without G17)
                     1 +   //     Optional decimal point
                     1);   //     Optional negative sign

            return new StringBuilder(maxLength)
                .Append("geography'POINT(")
                .Append(JsonSerialization.Double(longitude, CultureInfo.InvariantCulture))
                .Append(' ')
                .Append(JsonSerialization.Double(latitude, CultureInfo.InvariantCulture))
                .Append(")'")
                .ToString();
        }

        // Support for both Azure.Core.GeoJson and Microsoft.Spatial encoding are duplicated
        // below to avoid extraneous allocations for adapters and to consolidate them to a single
        // source file for easier maintenance.

#if EXPERIMENTAL_SPATIAL
        /// <summary>
        /// Encodes a polygon for use in OData filters.
        /// </summary>
        /// <param name="line">The <see cref="GeoLine"/> to encode.</param>
        /// <returns>The OData filter-encoded POLYGON string.</returns>
        /// <exception cref="ArgumentException">The <paramref name="line"/> has fewer than 4 points, or the first and last points do not match.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="line"/> or <see cref="GeoLine.Positions"/> is null.</exception>
        public static string EncodePolygon(GeoLine line)
        {
            Argument.AssertNotNull(line, nameof(line));
            Argument.AssertNotNull(line.Positions, $"{nameof(line)}.{nameof(line.Positions)}");

            if (line.Positions.Count < 4)
            {
                throw new ArgumentException(
                    $"A {nameof(GeoLine)} must have at least four {nameof(GeoLine.Positions)} to form a searchable polygon.",
                    $"{nameof(line)}.{nameof(line.Positions)}");
            }
            else if (line.Positions[0] != line.Positions[line.Positions.Count - 1])
            {
                throw new ArgumentException(
                    $"A {nameof(GeoLine)} must have matching first and last {nameof(GeoLine.Positions)} to form a searchable polygon.",
                    $"{nameof(line)}.{nameof(line.Positions)}");
            }

            StringBuilder odata = new StringBuilder("geography'POLYGON((");

            bool first = true;
            foreach (GeoPosition position in line.Positions)
            {
                if (!first)
                {
                    odata.Append(',');
                }
                else
                {
                    first = false;
                }

                odata.Append(JsonSerialization.Double(position.Longitude, CultureInfo.InvariantCulture))
                    .Append(' ')
                    .Append(JsonSerialization.Double(position.Latitude, CultureInfo.InvariantCulture));
            }

            return odata
                .Append("))'")
                .ToString();
        }

        /// <summary>
        /// Encodes a polygon for use in OData filters.
        /// <seealso cref="EncodePolygon(GeoLine)"/>
        /// </summary>
        /// <param name="polygon">The <see cref="GeoPolygon"/> to encode.</param>
        /// <returns>The OData filter-encoded POLYGON string.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="polygon"/> or <see cref="GeoPolygon.Rings"/> is null.</exception>
        public static string EncodePolygon(GeoPolygon polygon)
        {
            Argument.AssertNotNull(polygon, nameof(polygon));
            Argument.AssertNotNull(polygon.Rings, $"{nameof(polygon)}.{nameof(polygon.Rings)}");

            if (polygon.Rings.Count != 1)
            {
                throw new ArgumentException(
                    $"A {nameof(GeoPolygon)} must have exactly one {nameof(GeoPolygon.Rings)} to form a searchable polygon.",
                    $"{nameof(polygon)}.{nameof(polygon.Rings)}");
            }

            return EncodePolygon(polygon.Rings[0]);
        }
#endif

        /// <summary>
        /// Encodes a polygon for use in OData filters.
        /// </summary>
        /// <param name="line">The <see cref="GeographyLineStringProxy"/> to encode.</param>
        /// <returns>The OData filter-encoded POLYGON string.</returns>
        /// <exception cref="ArgumentException">The <paramref name="line"/> has fewer than 4 points, or the first and last points do not match.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="line"/> or <see cref="GeographyLineStringProxy.Points"/> is null.</exception>
        public static string EncodePolygon(GeographyLineStringProxy line)
        {
            Argument.AssertNotNull(line, nameof(line));
            Argument.AssertNotNull(line.Points, $"{nameof(line)}.{nameof(line.Points)}");

            if (line.Points.Count < 4)
            {
                throw new ArgumentException(
                    $"A GeographyLineString must have at least four Points to form a searchable polygon.",
                    $"{nameof(line)}.{nameof(line.Points)}");
            }
            else if (line.Points[0] != line.Points[line.Points.Count - 1])
            {
                throw new ArgumentException(
                    $"A GeographyLineString must have matching first and last Points to form a searchable polygon.",
                    $"{nameof(line)}.{nameof(line.Points)}");
            }

            StringBuilder odata = new StringBuilder("geography'POLYGON((");

            bool first = true;
            foreach (GeographyPointProxy point in line.Points)
            {
                if (!first)
                {
                    odata.Append(',');
                }
                else
                {
                    first = false;
                }

                odata.Append(JsonSerialization.Double(point.Longitude, CultureInfo.InvariantCulture))
                    .Append(' ')
                    .Append(JsonSerialization.Double(point.Latitude, CultureInfo.InvariantCulture));
            }

            return odata
                .Append("))'")
                .ToString();
        }

        /// <summary>
        /// Encodes a polygon for use in OData filters.
        /// <seealso cref="EncodePolygon(GeographyLineStringProxy)"/>
        /// </summary>
        /// <param name="polygon">The <see cref="GeographyPolygonProxy"/> to encode.</param>
        /// <returns>The OData filter-encoded POLYGON string.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="polygon"/> or <see cref="GeographyPolygonProxy.Rings"/> is null.</exception>
        public static string EncodePolygon(GeographyPolygonProxy polygon)
        {
            Argument.AssertNotNull(polygon, nameof(polygon));
            Argument.AssertNotNull(polygon.Rings, $"{nameof(polygon)}.{nameof(polygon.Rings)}");

            if (polygon.Rings.Count != 1)
            {
                throw new ArgumentException(
                    $"A GeographyPolygon must have exactly one Rings to form a searchable polygon.",
                    $"{nameof(polygon)}.{nameof(polygon.Rings)}");
            }

            return EncodePolygon(polygon.Rings[0]);
        }
    }
}
