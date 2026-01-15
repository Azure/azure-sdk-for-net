// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Xml;
using Azure.Core;

namespace Azure.Monitor.Query.Metrics
{
    /// <summary>
    /// Represents a span of time over which the query would be executed.
    /// </summary>
    public readonly struct MetricsQueryTimeRange : IEquatable<MetricsQueryTimeRange>
    {
        /// <summary>
        /// Represents the maximum <see cref="MetricsQueryTimeRange"/>.
        /// </summary>
        public static MetricsQueryTimeRange All => new MetricsQueryTimeRange(TimeSpan.MaxValue);

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
        /// Initializes an instance of <see cref="MetricsQueryTimeRange"/> using a duration value.
        /// The exact query range would be determined by the service when executing the query.
        /// </summary>
        /// <param name="duration">The duration of the range.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public MetricsQueryTimeRange(TimeSpan duration)
        {
            Duration = duration;
            Start = null;
            End = null;
        }

        /// <summary>
        /// Initializes an instance of <see cref="MetricsQueryTimeRange"/> using a start time and a duration value.
        /// </summary>
        /// <param name="start">The start of the range.</param>
        /// <param name="duration">The duration of the range.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public MetricsQueryTimeRange(DateTimeOffset start, TimeSpan duration)
        {
            Duration = duration;
            Start = start;
            End = null;
        }

        /// <summary>
        /// Initializes an instance of <see cref="MetricsQueryTimeRange"/> using a duration and an end time.
        /// </summary>
        /// <param name="duration">The duration of the range.</param>
        /// <param name="end">The end of the range.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public MetricsQueryTimeRange(TimeSpan duration, DateTimeOffset end)
        {
            Duration = duration;
            Start = null;
            End = end;
        }

        /// <summary>
        /// Initializes an instance of <see cref="MetricsQueryTimeRange"/> using a start time and an end time.
        /// </summary>
        /// <param name="start">The start of the range.</param>
        /// <param name="end">The end of the range.</param>
        public MetricsQueryTimeRange(DateTimeOffset start, DateTimeOffset end)
        {
            Duration = end - start;
            Start = start;
            End = end;
        }

        internal MetricsQueryTimeRange(string start, string end)
        {
            if (!DateTimeOffset.TryParse(start, out var startTime))
            {
                throw new FormatException($"Could not parse the start time value: {start}");
            }
            if (!DateTimeOffset.TryParse(end, out var endTime))
            {
                throw new FormatException($"Could not parse the end time value: {end}");
            }
            Duration = endTime - startTime;
            Start = startTime;
            End = endTime;
        }

        /// <summary>
        /// Converts a <see cref="TimeSpan"/> to a <see cref="MetricsQueryTimeRange"/>.
        /// </summary>
        /// <param name="timeSpan">The <see cref="TimeSpan"/> value to convert.</param>
        public static implicit operator MetricsQueryTimeRange(TimeSpan timeSpan) => new MetricsQueryTimeRange(timeSpan);

        /// <inheritdoc />
        public override string ToString()
        {
            switch (Start, End, Duration)
            {
                case (DateTimeOffset, DateTimeOffset, _):
                    return $"Start: {Start} End: {End}";
                case (DateTimeOffset, null, TimeSpan):
                    return $"Start: {Start} Duration: {Duration}";
                case (null, DateTimeOffset, TimeSpan):
                    return $"Duration: {Duration} End: {End}";
                default:
                    return $"Duration: {Duration}";
            }
        }

        internal string ToIsoString()
        {
            var startTime = Start.ToIsoString();
            var endTime = End.ToIsoString();
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
        public bool Equals(MetricsQueryTimeRange other)
        {
            return Duration.Equals(other.Duration) &&
                   Nullable.Equals(Start, other.Start) &&
                   Nullable.Equals(End, other.End);
        }

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            return obj is MetricsQueryTimeRange other && Equals(other);
        }

        /// <summary>
        /// Determines if two <see cref="MetricsQueryTimeRange"/> values are the same.
        /// </summary>
        /// <param name="left">The first <see cref="MetricsQueryTimeRange"/> to compare.</param>
        /// <param name="right">The second <see cref="MetricsQueryTimeRange"/> to compare.</param>
        /// <returns>True if <paramref name="left"/> and <paramref name="right"/> are the same; otherwise, false.</returns>
        public static bool operator ==(MetricsQueryTimeRange left, MetricsQueryTimeRange right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Determines if two <see cref="MetricsQueryTimeRange"/> values are different.
        /// </summary>
        /// <param name="left">The first <see cref="MetricsQueryTimeRange"/> to compare.</param>
        /// <param name="right">The second <see cref="MetricsQueryTimeRange"/> to compare.</param>
        /// <returns>True if <paramref name="left"/> and <paramref name="right"/> are different; otherwise, false.</returns>
        public static bool operator !=(MetricsQueryTimeRange left, MetricsQueryTimeRange right)
        {
            return !left.Equals(right);
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            return HashCodeBuilder.Combine(Start, End, Duration);
        }

        /// <summary>
        /// Converts a <see cref="string"/> value to it's <see cref="MetricsQueryTimeRange"/> representation.
        /// </summary>
        /// <param name="value">The string to convert.</param>
        /// <returns>A <see cref="MetricsQueryTimeRange" /> equivalent of the string.</returns>
        /// <exception cref="FormatException"><paramref name="value" /> is not in correct format to represent a <see cref="MetricsQueryTimeRange" /> value.</exception>
        internal static MetricsQueryTimeRange Parse(string value)
        {
            Argument.AssertNotNullOrWhiteSpace(value, nameof(value));

            FormatException CreateFormatException(Exception inner = null) =>
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
                        (true, true) => new MetricsQueryTimeRange(dateTimeFirst, dateTimeSecond),
                        (true, false) => new MetricsQueryTimeRange(dateTimeFirst, ParseTimeSpan(parts[1])),
                        (false, true) => new MetricsQueryTimeRange(ParseTimeSpan(parts[0]), dateTimeSecond),
                        _ => throw CreateFormatException()
                    };
                default:
                    throw CreateFormatException();
            }
        }
    }
}
