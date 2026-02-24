// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;

namespace Azure.AI.ContentUnderstanding
{
    /// <summary>
    /// Represents a parsed document grounding source in the format <c>D(page,x1,y1,x2,y2,x3,y3,x4,y4)</c>.
    /// </summary>
    /// <remarks>
    /// The page number is 1-based. The polygon is a quadrilateral defined by four points
    /// with coordinates in the document's coordinate space.
    /// </remarks>
    public class DocumentSource : ContentSource
    {
        private const string Prefix = "D(";
        private const int ExpectedParamCount = 9; // page + 4 coordinate pairs

        /// <summary> Gets the 1-based page number. </summary>
        public int PageNumber { get; }

        /// <summary> Gets the polygon coordinates as four points defining a quadrilateral region. </summary>
        public IReadOnlyList<PointF> Polygon { get; }

        /// <summary>
        /// Gets the axis-aligned bounding rectangle computed from the polygon coordinates.
        /// Useful for drawing highlight rectangles over extracted fields.
        /// </summary>
        public RectangleF BoundingBox { get; }

        /// <summary>
        /// Initializes a new instance of <see cref="DocumentSource"/> by parsing a source string.
        /// </summary>
        /// <param name="source"> The raw source string in the format <c>D(page,x1,y1,...,x4,y4)</c>. </param>
        /// <exception cref="FormatException"> The source string is not in the expected format. </exception>
        internal DocumentSource(string source) : base(source)
        {
            ParseCore(source, out int page, out PointF[] polygon);
            PageNumber = page;
            Polygon = polygon;
            float minX = polygon.Min(p => p.X);
            float minY = polygon.Min(p => p.Y);
            BoundingBox = new RectangleF(
                minX,
                minY,
                polygon.Max(p => p.X) - minX,
                polygon.Max(p => p.Y) - minY);
        }

        /// <summary>
        /// Parses a single document source segment.
        /// </summary>
        /// <param name="source"> The source string in the format <c>D(page,x1,y1,...,x4,y4)</c>. </param>
        /// <returns> A new <see cref="DocumentSource"/>. </returns>
        /// <exception cref="ArgumentNullException"> <paramref name="source"/> is null. </exception>
        /// <exception cref="FormatException"> The source string is not in the expected format. </exception>
        public static new DocumentSource Parse(string source)
        {
            Argument.AssertNotNullOrEmpty(source, nameof(source));
            return new DocumentSource(source);
        }

        /// <summary>
        /// Parses a source string containing one or more document source segments separated by <c>;</c>.
        /// </summary>
        /// <param name="source"> The source string (may contain <c>;</c> delimiters). </param>
        /// <returns> An array of <see cref="DocumentSource"/> instances. </returns>
        /// <exception cref="ArgumentNullException"> <paramref name="source"/> is null. </exception>
        /// <exception cref="FormatException"> Any segment is not in the expected format. </exception>
        public static new DocumentSource[] ParseAll(string source)
        {
            Argument.AssertNotNullOrEmpty(source, nameof(source));

            string[] segments = source.Split(';');
            var results = new List<DocumentSource>(segments.Length);

            foreach (string segment in segments)
            {
                string trimmed = segment.Trim();
                if (trimmed.Length > 0)
                {
                    results.Add(new DocumentSource(trimmed));
                }
            }

            return results.ToArray();
        }

        private static void ParseCore(string source, out int page, out PointF[] polygon)
        {
            if (!source.StartsWith(Prefix, StringComparison.Ordinal) || !source.EndsWith(")", StringComparison.Ordinal))
            {
                throw new FormatException($"Document source must start with '{Prefix}' and end with ')': '{source}'.");
            }

            // Extract the content between "D(" and ")"
            string inner = source.Substring(Prefix.Length, source.Length - Prefix.Length - 1);
            string[] parts = inner.Split(',');

            if (parts.Length != ExpectedParamCount)
            {
                throw new FormatException($"Document source expected {ExpectedParamCount} parameters (page + 8 coordinates), got {parts.Length}: '{source}'.");
            }

            if (!int.TryParse(parts[0], NumberStyles.Integer, CultureInfo.InvariantCulture, out page) || page < 1)
            {
                throw new FormatException($"Invalid page number in document source: '{parts[0]}'.");
            }

            polygon = new PointF[4];
            for (int i = 0; i < 4; i++)
            {
                int xIndex = 1 + (i * 2);
                int yIndex = 2 + (i * 2);

                if (!float.TryParse(parts[xIndex], NumberStyles.Float, CultureInfo.InvariantCulture, out float x))
                {
                    throw new FormatException($"Invalid x-coordinate at index {xIndex} in document source: '{parts[xIndex]}'.");
                }

                if (!float.TryParse(parts[yIndex], NumberStyles.Float, CultureInfo.InvariantCulture, out float y))
                {
                    throw new FormatException($"Invalid y-coordinate at index {yIndex} in document source: '{parts[yIndex]}'.");
                }

                polygon[i] = new PointF(x, y);
            }
        }
    }
}
