// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Collections.Generic;

namespace Azure.AI.ContentUnderstanding
{
    /// <summary>
    /// Represents a parsed grounding source that identifies the position of a field value in the content.
    /// This is the base class for <see cref="DocumentSource"/> and <see cref="AudioVisualSource"/>.
    /// </summary>
    /// <remarks>
    /// Source strings are encoded in the format <c>PREFIX(params)</c> with multiple regions separated by <c>;</c>.
    /// Supported prefixes:
    /// <list type="bullet">
    /// <item><c>D(page,x1,y1,...,x4,y4)</c> — document region with page number and polygon coordinates</item>
    /// <item><c>AV(time[,x,y,w,h])</c> — audio/visual region with timestamp and optional bounding box</item>
    /// </list>
    /// </remarks>
    public abstract class ContentSource
    {
        /// <summary> Gets the raw source string. </summary>
        public string RawValue { get; }

        /// <summary> Initializes a new instance of <see cref="ContentSource"/>. </summary>
        /// <param name="rawValue"> The raw source string. </param>
        protected ContentSource(string rawValue)
        {
            Argument.AssertNotNullOrEmpty(rawValue, nameof(rawValue));
            RawValue = rawValue;
        }

        /// <summary>
        /// Parses a single source segment (e.g., <c>"D(1,0.5712,...)"</c> or <c>"AV(5000,100,200,50,60)"</c>).
        /// </summary>
        internal static ContentSource ParseSingle(string source)
        {
            Argument.AssertNotNullOrEmpty(source, nameof(source));

            if (source.StartsWith("D(", StringComparison.Ordinal))
            {
                return new DocumentSource(source);
            }

            if (source.StartsWith("AV(", StringComparison.Ordinal))
            {
                return new AudioVisualSource(source);
            }

            throw new FormatException($"Unrecognized content source prefix: '{source}'.");
        }

        /// <summary>
        /// Parses a source string that may contain one or more segments separated by <c>;</c>.
        /// </summary>
        /// <param name="source"> The source string to parse (may contain <c>;</c> delimiters). </param>
        /// <returns> An array of parsed <see cref="ContentSource"/> instances. </returns>
        /// <exception cref="ArgumentNullException"> <paramref name="source"/> is null. </exception>
        /// <exception cref="FormatException"> Any segment has an unrecognized prefix or is malformed. </exception>
        public static ContentSource[] Parse(string source)
        {
            Argument.AssertNotNullOrEmpty(source, nameof(source));

            string[] segments = source.Split(';');
            var results = new List<ContentSource>(segments.Length);

            foreach (string segment in segments)
            {
                string trimmed = segment.Trim();
                if (trimmed.Length > 0)
                {
                    results.Add(ParseSingle(trimmed));
                }
            }

            return results.ToArray();
        }

        /// <inheritdoc/>
        public override string ToString() => RawValue;
    }
}
