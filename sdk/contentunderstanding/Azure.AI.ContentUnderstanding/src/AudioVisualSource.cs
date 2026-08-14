// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;

namespace Azure.AI.ContentUnderstanding
{
    /// <summary>
    /// Represents a parsed audio/visual source in the format <c>AV(time[,x,y,w,h])</c>.
    /// </summary>
    /// <remarks>
    /// The time is in milliseconds on the wire but exposed as a <see cref="TimeSpan"/>.
    /// The bounding box (x, y, width, height) is optional and present only when spatial
    /// information is available (e.g., face detection).
    /// </remarks>
    public class AudioVisualSource : ContentSource
    {
        private const string Prefix = "AV(";

        /// <summary> Gets the timestamp. </summary>
        public TimeSpan Time { get; }

        /// <summary>
        /// Gets the bounding box (x, y, width, height) in pixel coordinates,
        /// or <c>null</c> if no spatial information is available (e.g., audio-only).
        /// </summary>
        public Rectangle? BoundingBox { get; }

        /// <summary>
        /// Initializes a new instance of <see cref="AudioVisualSource"/> by parsing a source string.
        /// </summary>
        /// <param name="source"> The raw source string in the format <c>AV(time[,x,y,w,h])</c>. </param>
        /// <exception cref="FormatException"> The source string is not in the expected format. </exception>
        internal AudioVisualSource(string source) : base(source)
        {
            ParseCore(source, out int timeMs, out Rectangle? bbox);
            Time = TimeSpan.FromMilliseconds(timeMs);
            BoundingBox = bbox;
        }

        /// <summary>
        /// Parses a source string containing one or more audio/visual source segments separated by <c>;</c>.
        /// </summary>
        /// <param name="source"> The source string (may contain <c>;</c> delimiters). </param>
        /// <returns> An array of <see cref="AudioVisualSource"/> instances. </returns>
        /// <exception cref="ArgumentNullException"> <paramref name="source"/> is null. </exception>
        /// <exception cref="FormatException"> Any segment is not in the expected format. </exception>
        public static new AudioVisualSource[] Parse(string source)
        {
            Argument.AssertNotNullOrEmpty(source, nameof(source));

            string[] segments = source.Split(';');
            var results = new List<AudioVisualSource>(segments.Length);

            foreach (string segment in segments)
            {
                string trimmed = segment.Trim();
                if (trimmed.Length > 0)
                {
                    results.Add(new AudioVisualSource(trimmed));
                }
            }

            return results.ToArray();
        }

        private static void ParseCore(string source, out int time, out Rectangle? bbox)
        {
            if (!source.StartsWith(Prefix, StringComparison.Ordinal) || !source.EndsWith(")", StringComparison.Ordinal))
            {
                throw new FormatException($"Audio/visual source must start with '{Prefix}' and end with ')': '{source}'.");
            }

            // Extract the content between "AV(" and ")"
            string inner = source.Substring(Prefix.Length, source.Length - Prefix.Length - 1);
            string[] parts = inner.Split(',');

            if (parts.Length != 1 && parts.Length != 5)
            {
                throw new FormatException($"Audio/visual source expected 1 or 5 parameters, got {parts.Length}: '{source}'.");
            }

            if (!int.TryParse(parts[0], NumberStyles.Integer, CultureInfo.InvariantCulture, out time))
            {
                throw new FormatException($"Invalid time value in audio/visual source: '{parts[0]}'.");
            }

            if (parts.Length == 5)
            {
                if (!int.TryParse(parts[1], NumberStyles.Integer, CultureInfo.InvariantCulture, out int xVal))
                    throw new FormatException($"Invalid x value in audio/visual source: '{parts[1]}'.");
                if (!int.TryParse(parts[2], NumberStyles.Integer, CultureInfo.InvariantCulture, out int yVal))
                    throw new FormatException($"Invalid y value in audio/visual source: '{parts[2]}'.");
                if (!int.TryParse(parts[3], NumberStyles.Integer, CultureInfo.InvariantCulture, out int wVal))
                    throw new FormatException($"Invalid width value in audio/visual source: '{parts[3]}'.");
                if (!int.TryParse(parts[4], NumberStyles.Integer, CultureInfo.InvariantCulture, out int hVal))
                    throw new FormatException($"Invalid height value in audio/visual source: '{parts[4]}'.");

                bbox = new Rectangle(xVal, yVal, wVal, hVal);
            }
            else
            {
                bbox = null;
            }
        }
    }
}
