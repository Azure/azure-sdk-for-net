// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Monitor.Query
{
    /// <summary>
    /// Represents a span of time over which the query would be executed.
    /// </summary>
    public readonly struct DateTimeRange : IEquatable<DateTimeRange>
    {
        /// <summary>
        /// Represents the maximum <see cref="DateTimeRange"/>.
        /// </summary>
        public static DateTimeRange MaxValue => new DateTimeRange(TimeSpan.MaxValue);

        /// <summary>
        /// Gets the duration of the range.
        /// </summary>
        public TimeSpan Duration { get; }

        /// <summary>
        /// Gets the start time of the range.
        /// </summary>
        public DateTimeOffset? StartTime { get; }

        /// <summary>
        /// Gets the end time of the range.
        /// </summary>
        public DateTimeOffset? EndTime { get; }

        /// <summary>
        /// Initializes an instance of <see cref="DateTimeRange"/> using a duration value.
        /// The exact query range would be determined by the service when executing the query.
        /// </summary>
        /// <param name="duration">The duration of the range.</param>
        public DateTimeRange(TimeSpan duration)
        {
            Duration = duration;
            StartTime = null;
            EndTime = null;
        }

        /// <summary>
        /// Initializes an instance of <see cref="DateTimeRange"/> using a start time and a duration value.
        /// </summary>
        /// <param name="startTime">The start of the range.</param>
        /// <param name="duration">The duration of the range.</param>
        public DateTimeRange(DateTimeOffset startTime, TimeSpan duration)
        {
            Duration = duration;
            StartTime = startTime;
            EndTime = null;
        }

        /// <summary>
        /// Initializes an instance of <see cref="DateTimeRange"/> using a duration and an end time.
        /// </summary>
        /// <param name="duration">The duration of the range.</param>
        /// <param name="endTime">The end of the range.</param>
        public DateTimeRange(TimeSpan duration, DateTimeOffset endTime)
        {
            Duration = duration;
            StartTime = null;
            EndTime = endTime;
        }

        /// <summary>
        /// Initializes an instance of <see cref="DateTimeRange"/> using a start time and an end time.
        /// </summary>
        /// <param name="startTime">The start of the range.</param>
        /// <param name="endTime">The end of the range.</param>
        public DateTimeRange(DateTimeOffset startTime, DateTimeOffset endTime)
        {
            Duration = endTime - startTime;
            StartTime = startTime;
            EndTime = endTime;
        }

        /// <summary>
        /// Converts a <see cref="TimeSpan"/> to a <see cref="DateTimeRange"/>.
        /// </summary>
        /// <param name="timeSpan">The <see cref="TimeSpan"/> value to convert.</param>
        public static implicit operator DateTimeRange(TimeSpan timeSpan) => new DateTimeRange(timeSpan);

        /// <inheritdoc />
        public override string ToString()
        {
            var startTime = StartTime != null ? TypeFormatters.ToString(StartTime.Value, "o") : null;
            var endTime = EndTime != null ? TypeFormatters.ToString(EndTime.Value, "o") : null;
            var duration = TypeFormatters.ToString(Duration, "P");

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
                   Nullable.Equals(StartTime, other.StartTime) &&
                   Nullable.Equals(EndTime, other.EndTime);
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
            return HashCodeBuilder.Combine(StartTime, EndTime, Duration);
        }
    }
}
