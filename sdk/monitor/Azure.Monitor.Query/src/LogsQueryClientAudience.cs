// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.Monitor.Query
{
    /// <summary>
    /// Cloud audiences available for <see cref="LogsQueryClient"/>.
    /// </summary>
    public readonly partial struct LogsQueryClientAudience : IEquatable<LogsQueryClientAudience>
    {
        private readonly string _value;

        /// <summary>
        /// Initializes a new instance of <see cref="LogsQueryClientAudience"/> with a given value.
        /// </summary>
        public LogsQueryClientAudience(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        /// <summary> Azure Public Cloud. </summary>
        public static LogsQueryClientAudience AzurePublicCloud { get; } = new("https://api.loganalytics.io");

        /// <summary> Determines if two <see cref="LogsQueryClientAudience"/> values are the same. </summary>
        public static bool operator ==(LogsQueryClientAudience left, LogsQueryClientAudience right) => left.Equals(right);
        /// <summary> Determines if two <see cref="LogsQueryClientAudience"/> values are not the same. </summary>
        public static bool operator !=(LogsQueryClientAudience left, LogsQueryClientAudience right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="LogsQueryClientAudience"/>. </summary>
        public static implicit operator LogsQueryClientAudience(string value) => new(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is LogsQueryClientAudience other && Equals(other);
        /// <inheritdoc />
        public bool Equals(LogsQueryClientAudience other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}