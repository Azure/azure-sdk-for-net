// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;
using System.Xml;
using Azure.Core;

namespace Azure.Core
{
    /// <summary>
    /// Represents a span of time over which the query would be executed.
    /// </summary>
    public readonly struct DateTimeRange : IEquatable<DateTimeRange>
    {
        /// <summary>
        /// Represents the maximum <see cref="DateTimeRange"/>.
        /// </summary>
        public static DateTimeRange All => new DateTimeRange(TimeSpan.MaxValue);

        /// <summary>
        /// Gets the duration of the range.
        /// </summary>
        public TimeSpan Duration { get; }

        /// <summary>
        /// Gets the start time of the range.
        /// </summary>
        public DateTimeOffset? Start { get; }

        /// <summary>
        /// Gets the end time of the range.
        /// </summary>
        public DateTimeOffset? End { get; }

        /// <summary>
        /// Initializes an instance of <see cref="DateTimeRange"/> using a duration value.
        /// The exact query range would be determined by the service when executing the query.
        /// </summary>
        /// <param name="duration">The duration of the range.</param>
        public DateTimeRange(TimeSpan duration)
        {
            Duration = duration;
            Start = null;
            End = null;
        }

        /// <summary>
        /// Initializes an instance of <see cref="DateTimeRange"/> using a start time and a duration value.
        /// </summary>
        /// <param name="start">The start of the range.</param>
        /// <param name="duration">The duration of the range.</param>
        public DateTimeRange(DateTimeOffset start, TimeSpan duration)
        {
            Duration = duration;
            Start = start;
            End = null;
        }

        /// <summary>
        /// Initializes an instance of <see cref="DateTimeRange"/> using a duration and an end time.
        /// </summary>
        /// <param name="duration">The duration of the range.</param>
        /// <param name="end">The end of the range.</param>
        public DateTimeRange(TimeSpan duration, DateTimeOffset end)
        {
            Duration = duration;
            Start = null;
            End = end;
        }

        /// <summary>
        /// Initializes an instance of <see cref="DateTimeRange"/> using a start time and an end time.
        /// </summary>
        /// <param name="start">The start of the range.</param>
        /// <param name="end">The end of the range.</param>
        public DateTimeRange(DateTimeOffset start, DateTimeOffset end)
        {
            Duration = end - start;
            Start = start;
            End = end;
        }

        /// <summary>
        /// Converts a <see cref="TimeSpan"/> to a <see cref="DateTimeRange"/>.
        /// </summary>
        /// <param name="timeSpan">The <see cref="TimeSpan"/> value to convert.</param>
        public static implicit operator DateTimeRange(TimeSpan timeSpan) => new DateTimeRange(timeSpan);

        /// <inheritdoc />
        public override string ToString()
        {
            string ToString(DateTimeOffset value)
            {
                if (value.Offset == TimeSpan.Zero)
                {
                    // Some Azure service required 0-offset dates to be formatted without the
                    // -00:00 part
                    const string roundtripZFormat = "yyyy-MM-ddTHH:mm:ss.fffffffZ";
                    return value.ToString(roundtripZFormat, CultureInfo.InvariantCulture);
                }

                return value.ToString("O", CultureInfo.InvariantCulture);
            }

            var startTime = Start != null ? ToString(Start.Value) : null;
            var endTime = End != null ? ToString(End.Value) : null;
            var duration = XmlConvert.ToString(Duration);

            switch (startTime, endTime, duration)
            {
                case (string, string, _):
                    return $"{startTime}/{endTime}";
                case (string, null, string):
                    return $"{startTime}/{duration}";
                case (null, string, string):
                    return $"{duration}/{endTime}";
                default:
                    return duration;
            }
        }

        /// <inheritdoc />
        public bool Equals(DateTimeRange other)
        {
            return Duration.Equals(other.Duration) &&
                   Nullable.Equals(Start, other.Start) &&
                   Nullable.Equals(End, other.End);
        }

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            return obj is DateTimeRange other && Equals(other);
        }

        /// <summary>
        /// Determines if two <see cref="DateTimeRange"/> values are the same.
        /// </summary>
        /// <param name="left">The first <see cref="DateTimeRange"/> to compare.</param>
        /// <param name="right">The second <see cref="DateTimeRange"/> to compare.</param>
        /// <returns>True if <paramref name="left"/> and <paramref name="right"/> are the same; otherwise, false.</returns>
        public static bool operator ==(DateTimeRange left, DateTimeRange right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Determines if two <see cref="DateTimeRange"/> values are different.
        /// </summary>
        /// <param name="left">The first <see cref="DateTimeRange"/> to compare.</param>
        /// <param name="right">The second <see cref="DateTimeRange"/> to compare.</param>
        /// <returns>True if <paramref name="left"/> and <paramref name="right"/> are different; otherwise, false.</returns>
        public static bool operator !=(DateTimeRange left, DateTimeRange right)
        {
            return !left.Equals(right);
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            return HashCodeBuilder.Combine(Start, End, Duration);
        }

        /// <summary>
        /// Converts a <see cref="string"/> value to it's <see cref="DateTimeRange"/> representation.
        /// </summary>
        /// <param name="value">The string to convert.</param>
        /// <returns>A <see langword="DateTimeRange" /> equivalent of the string.</returns>
        /// <exception cref="FormatException"><paramref name="value" /> is not in correct format to represent a <see langword="DateTimeRange" /> value.</exception>
        public static DateTimeRange Parse(string value)
        {
            Argument.AssertNotNullOrWhiteSpace(value, nameof(value));

            FormatException CreateFormatException(Exception? inner = null) =>
                new("Unable to parse the DateTimeRange value. " +
                      "Expected one of the following formats:" +
                      " Duration," +
                      " Duration/EndTime," +
                      " StartTime/Duration," +
                      " StartTime/EndTime", inner);

            TimeSpan ParseTimeSpan(string s)
            {
                try
                {
                    return XmlConvert.ToTimeSpan(s);
                }
                catch (FormatException e)
                {
                    throw CreateFormatException(e);
                }
            }

            var parts = value.Split(new[] { '/' }, StringSplitOptions.None);
            switch (parts.Length)
            {
                case 1:
                    return ParseTimeSpan(parts[0]);
                case 2:
                    var firstIsDateTime = DateTimeOffset.TryParse(parts[0], out var dateTimeFirst);
                    var secondIsDateTime = DateTimeOffset.TryParse(parts[1], out var dateTimeSecond);

                    return (firstIsDateTime, secondIsDateTime) switch
                    {
                        (true, true) => new DateTimeRange(dateTimeFirst, dateTimeSecond),
                        (true, false) => new DateTimeRange(dateTimeFirst, ParseTimeSpan(parts[1])),
                        (false, true) => new DateTimeRange(ParseTimeSpan(parts[0]), dateTimeSecond),
                        _ => throw CreateFormatException()
                    };
                default:
                    throw CreateFormatException();
            }
        }
    }
}
