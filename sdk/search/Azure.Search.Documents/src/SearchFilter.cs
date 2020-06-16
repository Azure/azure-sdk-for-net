// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;
using System.Text;
#if EXPERIMENTAL_SPATIAL
using Azure.Core;
using Azure.Core.Spatial;
#endif

namespace Azure.Search.Documents
{
    /// <summary>
    /// The SearchFilter class is used to help construct valid OData filter
    /// expressions, like the kind used by <see cref="SearchOptions.Filter"/>,
    /// by automatically replacing, quoting, and escaping interpolated
    /// parameters.
    /// <see href="https://docs.microsoft.com/en-us/azure/search/search-filters"/>
    /// </summary>
    public static class SearchFilter
    {
        /// <summary>
        /// Create an OData filter expression from an interpolated string.  The
        /// interpolated values will be quoted and escaped as necessary.
        /// </summary>
        /// <param name="filter">An interpolated filter string.</param>
        /// <returns>A valid OData filter expression.</returns>
        public static string Create(FormattableString filter) =>
            Create(filter, null);

        /// <summary>
        /// Create an OData filter expression from an interpolated string.  The
        /// interpolated values will be quoted and escaped as necessary.
        /// </summary>
        /// <param name="filter">An interpolated filter string.</param>
        /// <param name="formatProvider">
        /// Format provider used to convert values to strings.
        /// <see cref="CultureInfo.InvariantCulture"/> is used as a default.
        /// </param>
        /// <returns>A valid OData filter expression.</returns>
        public static string Create(FormattableString filter, IFormatProvider formatProvider)
        {
            if (filter == null) { return null; }
            formatProvider ??= CultureInfo.InvariantCulture;

            string[] args = new string[filter.ArgumentCount];
            for (int i = 0; i < filter.ArgumentCount; i++)
            {
                args[i] = filter.GetArgument(i) switch
                {
                    // Null
                    null => "null",

                    // Boolean
                    bool x => x.ToString(formatProvider).ToLowerInvariant(),

                    // Numeric
                    sbyte x => x.ToString(formatProvider),
                    byte x => x.ToString(formatProvider),
                    short x => x.ToString(formatProvider),
                    ushort x => x.ToString(formatProvider),
                    int x => x.ToString(formatProvider),
                    uint x => x.ToString(formatProvider),
                    long x => x.ToString(formatProvider),
                    ulong x => x.ToString(formatProvider),
                    decimal x => x.ToString(formatProvider),

                    // Floating point
                    float x => JsonSerialization.Float(x, formatProvider),
                    double x => JsonSerialization.Double(x, formatProvider),

                    // Dates as 8601 with a time zone
                    DateTimeOffset x => JsonSerialization.Date(x, formatProvider),
                    DateTime x => JsonSerialization.Date(x, formatProvider),

#if EXPERIMENTAL_SPATIAL
                    // Points
                    GeometryPosition x => EncodeGeometry(x),
                    PointGeometry x => EncodeGeometry(x),

                    // Polygons
                    LineGeometry x => EncodeGeometry(x),
                    PolygonGeometry x => EncodeGeometry(x),
#endif

                    // Text
                    string x => Quote(x),
                    char x => Quote(x.ToString(formatProvider)),
                    StringBuilder x => Quote(x.ToString()),

                    // Everything else
                    object x => throw new ArgumentException(
                        $"Unable to convert argument {i} from type {x.GetType()} to an OData literal.")
                };
            }
            string text = string.Format(formatProvider, filter.Format, args);
            return text;
        }

        /// <summary>
        /// Quote and escape OData strings.
        /// </summary>
        /// <param name="text">The text to quote.</param>
        /// <returns>The quoted text.</returns>
        private static string Quote(string text)
        {
            if (text == null) { return "null"; }

            // Optimistically allocate an extra 5% for escapes
            StringBuilder builder = new StringBuilder(2 + (int)(text.Length * 1.05));
            builder.Append("'");
            foreach (char ch in text)
            {
                builder.Append(ch);
                if (ch == '\'')
                {
                    builder.Append(ch);
                }
            }
            builder.Append("'");
            return builder.ToString();
        }

#if EXPERIMENTAL_SPATIAL
        /// <summary>
        /// Convert a <see cref="GeometryPosition"/> to an OData value.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <returns>The OData representation of the position.</returns>
        private static string EncodeGeometry(GeometryPosition position)
        {
            const int maxLength =
                19 +       // "geography'POINT( )'".Length
                2 *        // Lat and Long each have:
                   (15 +   //     Maximum precision for a double (without G17)
                     1 +   //     Optional decimal point
                     1);   //     Optional negative sign
            StringBuilder odata = new StringBuilder(maxLength);
            odata.Append("geography'POINT(");
            odata.Append(JsonSerialization.Double(position.Longitude, CultureInfo.InvariantCulture));
            odata.Append(" ");
            odata.Append(JsonSerialization.Double(position.Latitude, CultureInfo.InvariantCulture));
            odata.Append(")'");
            return odata.ToString();
        }

        /// <summary>
        /// Convert a <see cref="PointGeometry"/> to an OData value.
        /// </summary>
        /// <param name="point">The point.</param>
        /// <returns>The OData representation of the point.</returns>
        private static string EncodeGeometry(PointGeometry point)
        {
            Argument.AssertNotNull(point, nameof(point));
            return EncodeGeometry(point.Position);
        }

        /// <summary>
        /// Convert a <see cref="LineGeometry"/> forming a polygon to an OData
        /// value.  A LineGeometry must have at least four
        /// <see cref="LineGeometry.Positions"/> and the first and last must
        /// match to form a searchable polygon.
        /// </summary>
        /// <param name="line">The line forming a polygon.</param>
        /// <returns>The OData representation of the line.</returns>
        private static string EncodeGeometry(LineGeometry line)
        {
            Argument.AssertNotNull(line, nameof(line));
            Argument.AssertNotNull(line.Positions, $"{nameof(line)}.{nameof(line.Positions)}");
            if (line.Positions.Count < 4)
            {
                throw new ArgumentException(
                    $"A {nameof(LineGeometry)} must have at least four {nameof(LineGeometry.Positions)} to form a searchable polygon.",
                    $"{nameof(line)}.{nameof(line.Positions)}");
            }
            else if (line.Positions[0] != line.Positions[line.Positions.Count - 1])
            {
                throw new ArgumentException(
                    $"A {nameof(LineGeometry)} must have matching first and last {nameof(LineGeometry.Positions)} to form a searchable polygon.",
                    $"{nameof(line)}.{nameof(line.Positions)}");
            }

            Argument.AssertInRange(line.Positions?.Count ?? 0, 4, int.MaxValue, $"{nameof(line)}.{nameof(line.Positions)}");

            StringBuilder odata = new StringBuilder();
            odata.Append("geography'POLYGON((");
            bool first = true;
            foreach (GeometryPosition position in line.Positions)
            {
                if (!first) { odata.Append(","); }
                first = false;
                odata.Append(JsonSerialization.Double(position.Longitude, CultureInfo.InvariantCulture));
                odata.Append(" ");
                odata.Append(JsonSerialization.Double(position.Latitude, CultureInfo.InvariantCulture));
            }
            odata.Append("))'");
            return odata.ToString();
        }

        /// <summary>
        /// Convert a <see cref="PolygonGeometry"/> to an OData value.  A
        /// PolygonGeometry must have exactly one <see cref="PolygonGeometry.Rings"/>
        /// to form a searchable polygon.
        /// </summary>
        /// <param name="polygon">The polygon.</param>
        /// <returns>The OData representation of the polygon.</returns>
        private static string EncodeGeometry(PolygonGeometry polygon)
        {
            Argument.AssertNotNull(polygon, nameof(polygon));
            Argument.AssertNotNull(polygon.Rings, $"{nameof(polygon)}.{nameof(polygon.Rings)}");
            if (polygon.Rings.Count != 1)
            {
                throw new ArgumentException(
                    $"A {nameof(PolygonGeometry)} must have exactly one {nameof(PolygonGeometry.Rings)} to form a searchable polygon.",
                    $"{nameof(polygon)}.{nameof(polygon.Rings)}");
            }
            return EncodeGeometry(polygon.Rings[0]);
        }
#endif
    }
}
