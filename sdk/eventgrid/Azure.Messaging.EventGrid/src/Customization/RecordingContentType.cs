// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.Messaging.EventGrid.Models
{
    /// <summary> The recording content type- AudioVideo, or Audio. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public readonly partial struct RecordingContentType : IEquatable<RecordingContentType>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="RecordingContentType"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public RecordingContentType(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string AudioVideoValue = "AudioVideo";
        private const string AudioValue = "Audio";

        /// <summary> AudioVideo. </summary>
        public static RecordingContentType AudioVideo { get; } = new RecordingContentType(AudioVideoValue);
        /// <summary> Audio. </summary>
        public static RecordingContentType Audio { get; } = new RecordingContentType(AudioValue);
        /// <summary> Determines if two <see cref="RecordingContentType"/> values are the same. </summary>
        public static bool operator ==(RecordingContentType left, RecordingContentType right) => left.Equals(right);
        /// <summary> Determines if two <see cref="RecordingContentType"/> values are not the same. </summary>
        public static bool operator !=(RecordingContentType left, RecordingContentType right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="RecordingContentType"/>. </summary>
        public static implicit operator RecordingContentType(string value) => new RecordingContentType(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is RecordingContentType other && Equals(other);
        /// <inheritdoc />
        public bool Equals(RecordingContentType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
