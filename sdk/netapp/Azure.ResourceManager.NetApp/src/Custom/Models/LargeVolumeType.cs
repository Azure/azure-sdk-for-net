// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.NetApp.Models
{
    // The old SDK exposed a string-backed union for large-volume classification.
    // Keep the removed type so older callers can keep compiling.
    /// <summary> Large volume type. </summary>
    public readonly partial struct LargeVolumeType : IEquatable<LargeVolumeType>
    {
        private readonly string _value;
        private const string LargeVolumeValue = "LargeVolume";
        private const string ExtraLargeVolume7Dot2PiBValue = "ExtraLargeVolume7Dot2PiB";

        /// <summary> Initializes a new instance of <see cref="LargeVolumeType"/>. </summary>
        public LargeVolumeType(string value)
        {
            Argument.AssertNotNull(value, nameof(value));
            _value = value;
        }

        /// <summary> Large volume. </summary>
        public static LargeVolumeType LargeVolume { get; } = new LargeVolumeType(LargeVolumeValue);

        /// <summary> Extra large volume 7.2 PiB. </summary>
        public static LargeVolumeType ExtraLargeVolume7Dot2PiB { get; } = new LargeVolumeType(ExtraLargeVolume7Dot2PiBValue);

        /// <summary> Determines if two <see cref="LargeVolumeType"/> values are the same. </summary>
        public static bool operator ==(LargeVolumeType left, LargeVolumeType right) => left.Equals(right);

        /// <summary> Determines if two <see cref="LargeVolumeType"/> values are not the same. </summary>
        public static bool operator !=(LargeVolumeType left, LargeVolumeType right) => !left.Equals(right);

        /// <summary> Converts a string to a <see cref="LargeVolumeType"/>. </summary>
        public static implicit operator LargeVolumeType(string value) => new LargeVolumeType(value);

        /// <summary> Converts a string to a nullable <see cref="LargeVolumeType"/>. </summary>
        public static implicit operator LargeVolumeType?(string value) => value == null ? null : new LargeVolumeType(value);

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is LargeVolumeType other && Equals(other);

        /// <inheritdoc/>
        public bool Equals(LargeVolumeType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;

        /// <inheritdoc/>
        public override string ToString() => _value;
    }
}
