// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.AI.VoiceLive
{
    /// <summary>
    /// Defines the triggers that can activate interim responses during voice interactions.
    /// </summary>
    public readonly partial struct InterimResponseTrigger : IEquatable<InterimResponseTrigger>
    {
        private readonly string _value;

        /// <summary>
        /// Initializes a new instance of <see cref="InterimResponseTrigger"/>.
        /// </summary>
        /// <param name="value">The string value of the trigger.</param>
        /// <exception cref="ArgumentNullException"><paramref name="value"/> is null.</exception>
        public InterimResponseTrigger(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string LatencyValue = "latency";
        private const string ToolValue = "tool";

        /// <summary>
        /// Trigger interim responses based on latency thresholds.
        /// </summary>
        public static InterimResponseTrigger Latency { get; } = new InterimResponseTrigger(LatencyValue);

        /// <summary>
        /// Trigger interim responses during tool execution.
        /// </summary>
        public static InterimResponseTrigger Tool { get; } = new InterimResponseTrigger(ToolValue);

        /// <summary>
        /// Determines if two <see cref="InterimResponseTrigger"/> values are the same.
        /// </summary>
        /// <param name="left">The first <see cref="InterimResponseTrigger"/> to compare.</param>
        /// <param name="right">The second <see cref="InterimResponseTrigger"/> to compare.</param>
        /// <returns>True if <paramref name="left"/> and <paramref name="right"/> are the same; otherwise, false.</returns>
        public static bool operator ==(InterimResponseTrigger left, InterimResponseTrigger right) => left.Equals(right);

        /// <summary>
        /// Determines if two <see cref="InterimResponseTrigger"/> values are not the same.
        /// </summary>
        /// <param name="left">The first <see cref="InterimResponseTrigger"/> to compare.</param>
        /// <param name="right">The second <see cref="InterimResponseTrigger"/> to compare.</param>
        /// <returns>True if <paramref name="left"/> and <paramref name="right"/> are not the same; otherwise, false.</returns>
        public static bool operator !=(InterimResponseTrigger left, InterimResponseTrigger right) => !left.Equals(right);

        /// <summary>
        /// Converts a string to a <see cref="InterimResponseTrigger"/>.
        /// </summary>
        /// <param name="value">The string value to convert.</param>
        public static implicit operator InterimResponseTrigger(string value) => new InterimResponseTrigger(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is InterimResponseTrigger other && Equals(other);

        /// <inheritdoc />
        public bool Equals(InterimResponseTrigger other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;

        /// <inheritdoc />
        public override string ToString() => _value;
    }
}