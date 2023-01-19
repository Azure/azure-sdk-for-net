// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.AI.Language.Conversations
{
    /// <summary> The DateTime SubKind. </summary>
    public readonly partial struct DateTimeSubKind : IEquatable<DateTimeSubKind>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="DateTimeSubKind"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public DateTimeSubKind(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string TimeValue = "Time";
        private const string DateValue = "Date";
        private const string DateTimeValue = "DateTime";
        private const string DurationValue = "Duration";
        private const string SetValue = "Set";

        /// <summary> Time. </summary>
        public static DateTimeSubKind Time { get; } = new DateTimeSubKind(TimeValue);
        /// <summary> Date. </summary>
        public static DateTimeSubKind Date { get; } = new DateTimeSubKind(DateValue);
        /// <summary> DateTime. </summary>
        public static DateTimeSubKind DateTime { get; } = new DateTimeSubKind(DateTimeValue);
        /// <summary> Duration. </summary>
        public static DateTimeSubKind Duration { get; } = new DateTimeSubKind(DurationValue);
        /// <summary> Set. </summary>
        public static DateTimeSubKind Set { get; } = new DateTimeSubKind(SetValue);
        /// <summary> Determines if two <see cref="DateTimeSubKind"/> values are the same. </summary>
        public static bool operator ==(DateTimeSubKind left, DateTimeSubKind right) => left.Equals(right);
        /// <summary> Determines if two <see cref="DateTimeSubKind"/> values are not the same. </summary>
        public static bool operator !=(DateTimeSubKind left, DateTimeSubKind right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="DateTimeSubKind"/>. </summary>
        public static implicit operator DateTimeSubKind(string value) => new DateTimeSubKind(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is DateTimeSubKind other && Equals(other);
        /// <inheritdoc />
        public bool Equals(DateTimeSubKind other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
