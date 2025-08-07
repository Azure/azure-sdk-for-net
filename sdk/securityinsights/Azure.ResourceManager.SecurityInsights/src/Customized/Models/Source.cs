// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.SecurityInsights.Models
{
    // Added due to api compat check in 2024-01-01-preview version
    /// <summary> The source of the watchlist. </summary>
    public readonly partial struct Source : IEquatable<Source>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="Source"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public Source(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string LocalFileValue = "Local file";
        private const string RemoteStorageValue = "Remote storage";

        /// <summary> Local file. </summary>
        public static Source LocalFile { get; } = new Source(LocalFileValue);
        /// <summary> Remote storage. </summary>
        public static Source RemoteStorage { get; } = new Source(RemoteStorageValue);
        /// <summary> Determines if two <see cref="Source"/> values are the same. </summary>
        public static bool operator ==(Source left, Source right) => left.Equals(right);
        /// <summary> Determines if two <see cref="Source"/> values are not the same. </summary>
        public static bool operator !=(Source left, Source right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="Source"/>. </summary>
        public static implicit operator Source(string value) => new Source(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is Source other && Equals(other);
        /// <inheritdoc />
        public bool Equals(Source other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
