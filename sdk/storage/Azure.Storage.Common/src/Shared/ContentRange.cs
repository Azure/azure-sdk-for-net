// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Globalization;
using Azure.Core;

namespace Azure.Storage
{
    internal struct ContentRange
    {
        private const string WildcardMarker = "*";

        public struct RangeUnit
        {
            internal const string BytesValue = "bytes";

            private readonly string _value;

            /// <summary>
            /// Initializes a new instance of the <see cref="RangeUnit"/> structure.
            /// </summary>
            /// <param name="value">The string value of the instance.</param>
            public RangeUnit(string value)
            {
                _value = value ?? throw new ArgumentNullException(nameof(value));
            }

            /// <summary>
            /// Label for bytes as the measurement of content range.
            /// </summary>
            public static RangeUnit Bytes { get; } = new RangeUnit(BytesValue);

            /// <summary>
            /// Determines if two <see cref="Unit"/> values are the same.
            /// </summary>
            /// <param name="left">The first <see cref="Unit"/> to compare.</param>
            /// <param name="right">The second <see cref="Unit"/> to compare.</param>
            /// <returns>True if <paramref name="left"/> and <paramref name="right"/> are the same; otherwise, false.</returns>
            public static bool operator ==(RangeUnit left, RangeUnit right) => left.Equals(right);

            /// <summary>
            /// Determines if two <see cref="RangeUnit"/> values are different.
            /// </summary>
            /// <param name="left">The first <see cref="RangeUnit"/> to compare.</param>
            /// <param name="right">The second <see cref="RangeUnit"/> to compare.</param>
            /// <returns>True if <paramref name="left"/> and <paramref name="right"/> are different; otherwise, false.</returns>
            public static bool operator !=(RangeUnit left, RangeUnit right) => !left.Equals(right);

            /// <summary>
            /// Converts a string to a <see cref="RangeUnit"/>.
            /// </summary>
            /// <param name="value">The string value to convert.</param>
            public static implicit operator RangeUnit(string value) => new RangeUnit(value);

            /// <inheritdoc/>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public override bool Equals(object obj) => obj is RangeUnit other && Equals(other);

            /// <summary>
            /// Indicates whether this instance and a specified <see cref="RangeUnit"/> are equal
            /// </summary>
            public bool Equals(RangeUnit other) => string.Equals(_value, other._value, StringComparison.Ordinal);

            /// <inheritdoc/>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public override int GetHashCode() => _value?.GetHashCode() ?? 0;

            /// <inheritdoc/>
            public override string ToString() => _value;
        }

        /// <summary>
        /// Inclusive index where the range starts, measured in this instance's <see cref="Unit"/>.
        /// </summary>
        public long? Start { get; }

        /// <summary>
        /// Inclusive index where the range ends, measured in this instance's <see cref="Unit"/>.
        /// </summary>
        public long? End { get; }

        /// <summary>
        /// Size of this range, measured in this instance's <see cref="Unit"/>.
        /// </summary>
        public long? Size { get; }

        /// <summary>
        /// Unit this range is measured in. Generally "bytes".
        /// </summary>
        public RangeUnit Unit { get; }

        public ContentRange(RangeUnit unit, long? start, long? end, long? size)
        {
            Start = start;
            End = end;
            Size = size;
            Unit = unit;
        }

        public static ContentRange Parse(string headerValue)
        {
            /* Parse header value (e.g. "<unit> <start>-<end>/<blobSize>")
             * Either side of the "/" can be an asterisk, so possible results include:
             *   [<unit>, <start>, <end>, <blobSize>]
             *   [<unit>, "*", <blobSize>]
             *   [<unit>, <start>, <end>, "*"]
             *   [<unit>, "*", "*"] (unsure if possible but not hard to support)
             * "End" is the inclusive last byte; e.g. header "bytes 0-7/8" is the entire 8-byte blob
             */
            var tokens = headerValue.Split(new char[] { ' ', '-', '/' }); // ["bytes", "<start>", "<end>", "<blobSize>"]
            string unit = default;
            long? start = default;
            long? end = default;
            long? size = default;

            try
            {
                // unit always first and always present
                unit = tokens[0];

                int blobSizeIndex;
                if (tokens[1] == WildcardMarker) // [<unit>, "*", (<blobSize> | "*")]
                {
                    blobSizeIndex = 2;
                }
                else // [<unit>, <start>, <end>, (<blobSize> | "*")]
                {
                    blobSizeIndex = 3;

                    start = long.Parse(tokens[1], CultureInfo.InvariantCulture);
                    end = long.Parse(tokens[2], CultureInfo.InvariantCulture);
                }

                var rawSize = tokens[blobSizeIndex];
                if (rawSize != WildcardMarker)
                {
                    size = long.Parse(rawSize, CultureInfo.InvariantCulture);
                }

                return new ContentRange(unit, start, end, size);
            }
            catch (IndexOutOfRangeException)
            {
                throw Errors.ParsingHttpRangeFailed();
            }
        }

        public static HttpRange ToHttpRange(ContentRange contentRange)
        {
            if (contentRange.Start.HasValue)
            {
                // Because constructing HttpRange is the start value, and the length of the range
                // increment 1 on the end value, since the end value is the end index (not the length).
                long length = contentRange.End.Value - contentRange.Start.Value + 1;
                return new HttpRange(contentRange.Start.Value, length);
            }
            return default;
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is RangeUnit other && Equals(other);

        /// <summary>
        /// Indicates whether this instance and a specified <see cref="RangeUnit"/> are equal
        /// </summary>
        public bool Equals(ContentRange other) => (other.Start == Start) && (other.End == End) && (other.Unit == Unit) && (other.Size == Size);

        /// <summary>
        /// Determines if two <see cref="Unit"/> values are the same.
        /// </summary>
        /// <param name="left">The first <see cref="Unit"/> to compare.</param>
        /// <param name="right">The second <see cref="Unit"/> to compare.</param>
        /// <returns>True if <paramref name="left"/> and <paramref name="right"/> are the same; otherwise, false.</returns>
        public static bool operator ==(ContentRange left, ContentRange right) => left.Equals(right);

        /// <summary>
        /// Determines if two <see cref="ContentRange"/> values are different.
        /// </summary>
        /// <param name="left">The first <see cref="ContentRange"/> to compare.</param>
        /// <param name="right">The second <see cref="ContentRange"/> to compare.</param>
        /// <returns>True if <paramref name="left"/> and <paramref name="right"/> are different; otherwise, false.</returns>
        public static bool operator !=(ContentRange left, ContentRange right) => !left.Equals(right);

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => HashCodeBuilder.Combine(Start, End, Size, Unit.GetHashCode());
    }
}
