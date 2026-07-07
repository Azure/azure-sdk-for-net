// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable
using System;
using System.ComponentModel;
using System.Linq;

namespace Azure.AI.ContentUnderstanding
{
    /// <summary>
    /// Represents a range of content to analyze. Use this type with the
    /// <see cref="ContentUnderstandingClient.AnalyzeBinaryAsync(WaitUntil, string, BinaryData, ContentRange?, string, ProcessingLocation?, System.Threading.CancellationToken)"/>
    /// method for a self-documenting API.
    /// <para>
    /// For documents, ranges use 1-based page numbers (e.g., <c>"1-3"</c>, <c>"5"</c>, <c>"9-"</c>).
    /// For audio/video, ranges use integer milliseconds (e.g., <c>"0-5000"</c>, <c>"5000-"</c>).
    /// Multiple ranges can be combined with commas (e.g., <c>"1-3,5,9-"</c>).
    /// </para>
    /// </summary>
    /// <example>
    /// <code>
    /// // Document pages
    /// ContentRange range = ContentRange.Pages(1, 3);           // "1-3"
    /// ContentRange single = ContentRange.Page(5);              // "5"
    /// ContentRange openEnd = ContentRange.PagesFrom(9);        // "9-"
    ///
    /// // Audio/video time ranges (milliseconds)
    /// ContentRange time = ContentRange.TimeRange(
    ///     TimeSpan.Zero, TimeSpan.FromMilliseconds(5000));       // "0-5000"
    /// ContentRange timeOpen = ContentRange.TimeRangeFrom(
    ///     TimeSpan.FromMilliseconds(5000));                      // "5000-"
    ///
    /// // Combine multiple ranges
    /// ContentRange combined = ContentRange.Combine(
    ///     ContentRange.Pages(1, 3),
    ///     ContentRange.Page(5),
    ///     ContentRange.PagesFrom(9));                           // "1-3,5,9-"
    ///
    /// // Or construct from a raw string
    /// ContentRange raw = new ContentRange("1-3,5,9-");
    /// </code>
    /// </example>
    public readonly partial struct ContentRange : IEquatable<ContentRange>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="ContentRange"/>. </summary>
        /// <param name="value"> The range string value. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public ContentRange(string value)
        {
            Argument.AssertNotNull(value, nameof(value));
            _value = value;
        }

        /// <summary> Creates a <see cref="ContentRange"/> for a single document page (1-based). </summary>
        /// <param name="pageNumber"> The 1-based page number. </param>
        /// <returns> A <see cref="ContentRange"/> representing the single page, e.g. <c>"5"</c>. </returns>
        /// <exception cref="ArgumentOutOfRangeException"> <paramref name="pageNumber"/> is less than 1. </exception>
        public static ContentRange Page(int pageNumber)
        {
            if (pageNumber < 1) throw new ArgumentOutOfRangeException(nameof(pageNumber), "Page number must be >= 1.");
            return new ContentRange(pageNumber.ToString());
        }

        /// <summary> Creates a <see cref="ContentRange"/> for a contiguous range of document pages (1-based, inclusive). </summary>
        /// <param name="start"> The 1-based start page number (inclusive). </param>
        /// <param name="end"> The 1-based end page number (inclusive). </param>
        /// <returns> A <see cref="ContentRange"/> representing the page range, e.g. <c>"1-3"</c>. </returns>
        /// <exception cref="ArgumentOutOfRangeException"> <paramref name="start"/> is less than 1, or <paramref name="end"/> is less than <paramref name="start"/>. </exception>
        public static ContentRange Pages(int start, int end)
        {
            if (start < 1) throw new ArgumentOutOfRangeException(nameof(start), "Start page must be >= 1.");
            if (end < start) throw new ArgumentOutOfRangeException(nameof(end), "End page must be >= start page.");
            return new ContentRange($"{start}-{end}");
        }

        /// <summary> Creates a <see cref="ContentRange"/> for all document pages from a starting page to the end (1-based). </summary>
        /// <param name="startPage"> The 1-based start page number (inclusive). </param>
        /// <returns> A <see cref="ContentRange"/> representing the open-ended page range, e.g. <c>"9-"</c>. </returns>
        /// <exception cref="ArgumentOutOfRangeException"> <paramref name="startPage"/> is less than 1. </exception>
        public static ContentRange PagesFrom(int startPage)
        {
            if (startPage < 1) throw new ArgumentOutOfRangeException(nameof(startPage), "Start page must be >= 1.");
            return new ContentRange($"{startPage}-");
        }

        /// <summary> Creates a <see cref="ContentRange"/> for a time range in milliseconds (for audio/video content). </summary>
        /// <param name="startMs"> The start time in milliseconds (inclusive). </param>
        /// <param name="endMs"> The end time in milliseconds (inclusive). </param>
        /// <returns> A <see cref="ContentRange"/> representing the time range, e.g. <c>"0-5000"</c>. </returns>
        /// <exception cref="ArgumentOutOfRangeException"> <paramref name="startMs"/> is negative, or <paramref name="endMs"/> is less than <paramref name="startMs"/>. </exception>
        internal static ContentRange TimeRange(long startMs, long endMs)
        {
            if (startMs < 0) throw new ArgumentOutOfRangeException(nameof(startMs), "Start time must be >= 0.");
            if (endMs < startMs) throw new ArgumentOutOfRangeException(nameof(endMs), "End time must be >= start time.");
            return new ContentRange($"{startMs}-{endMs}");
        }

        /// <summary> Creates a <see cref="ContentRange"/> for all content from a starting time to the end (for audio/video content). </summary>
        /// <param name="startMs"> The start time in milliseconds (inclusive). </param>
        /// <returns> A <see cref="ContentRange"/> representing the open-ended time range, e.g. <c>"5000-"</c>. </returns>
        /// <exception cref="ArgumentOutOfRangeException"> <paramref name="startMs"/> is negative. </exception>
        internal static ContentRange TimeRangeFrom(long startMs)
        {
            if (startMs < 0) throw new ArgumentOutOfRangeException(nameof(startMs), "Start time must be >= 0.");
            return new ContentRange($"{startMs}-");
        }

        /// <summary> Creates a <see cref="ContentRange"/> for a time range using <see cref="TimeSpan"/> values (for audio/video content). </summary>
        /// <param name="start"> The start time (inclusive). </param>
        /// <param name="end"> The end time (inclusive). </param>
        /// <returns> A <see cref="ContentRange"/> representing the time range. </returns>
        /// <exception cref="ArgumentOutOfRangeException"> <paramref name="start"/> is negative, or <paramref name="end"/> is less than <paramref name="start"/>. </exception>
        public static ContentRange TimeRange(TimeSpan start, TimeSpan end)
        {
            if (start < TimeSpan.Zero) throw new ArgumentOutOfRangeException(nameof(start), "Start time must be non-negative.");
            if (end < start) throw new ArgumentOutOfRangeException(nameof(end), "End time must be >= start time.");
            return TimeRange((long)start.TotalMilliseconds, (long)end.TotalMilliseconds);
        }

        /// <summary> Creates a <see cref="ContentRange"/> for all content from a starting time to the end using a <see cref="TimeSpan"/> value (for audio/video content). </summary>
        /// <param name="start"> The start time (inclusive). </param>
        /// <returns> A <see cref="ContentRange"/> representing the open-ended time range. </returns>
        /// <exception cref="ArgumentOutOfRangeException"> <paramref name="start"/> is negative. </exception>
        public static ContentRange TimeRangeFrom(TimeSpan start)
        {
            if (start < TimeSpan.Zero) throw new ArgumentOutOfRangeException(nameof(start), "Start time must be non-negative.");
            return TimeRangeFrom((long)start.TotalMilliseconds);
        }

        /// <summary> Combines multiple <see cref="ContentRange"/> values into a single comma-separated range. </summary>
        /// <param name="ranges"> The ranges to combine. </param>
        /// <returns> A <see cref="ContentRange"/> representing the combined ranges, e.g. <c>"1-3,5,9-"</c>. </returns>
        /// <exception cref="ArgumentNullException"> <paramref name="ranges"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="ranges"/> is empty. </exception>
        public static ContentRange Combine(params ContentRange[] ranges)
        {
            Argument.AssertNotNull(ranges, nameof(ranges));
            if (ranges.Length == 0) throw new ArgumentException("At least one range must be provided.", nameof(ranges));
            return new ContentRange(string.Join(",", ranges.Select(r => r._value)));
        }

        /// <summary> Converts a <see cref="ContentRange"/> to its <see cref="string"/> representation. </summary>
        /// <param name="value"> The value to convert. </param>
        public static implicit operator string(ContentRange value) => value._value;

        /// <summary> Determines if two <see cref="ContentRange"/> values are the same. </summary>
        public static bool operator ==(ContentRange left, ContentRange right) => left.Equals(right);

        /// <summary> Determines if two <see cref="ContentRange"/> values are not the same. </summary>
        public static bool operator !=(ContentRange left, ContentRange right) => !left.Equals(right);

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object? obj) => obj is ContentRange other && Equals(other);

        /// <inheritdoc/>
        public bool Equals(ContentRange other) => string.Equals(_value, other._value, StringComparison.Ordinal);

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.Ordinal.GetHashCode(_value) : 0;

        /// <inheritdoc/>
        public override string ToString() => _value;
    }
}
