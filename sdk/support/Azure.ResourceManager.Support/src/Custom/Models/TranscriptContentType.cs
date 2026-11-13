// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Support.Models
{
    /// <summary> Content type for chat transcript messages. </summary>
    public readonly partial struct TranscriptContentType : IEquatable<TranscriptContentType>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="TranscriptContentType"/>. </summary>
        /// <param name="value"> The value. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public TranscriptContentType(string value)
        {
            Argument.AssertNotNull(value, nameof(value));
            _value = value;
        }

        /// <summary> Determines if two <see cref="TranscriptContentType"/> values are the same. </summary>
        public static bool operator ==(TranscriptContentType left, TranscriptContentType right) => left.Equals(right);

        /// <summary> Determines if two <see cref="TranscriptContentType"/> values are not the same. </summary>
        public static bool operator !=(TranscriptContentType left, TranscriptContentType right) => !left.Equals(right);

        /// <summary> Converts a string to a <see cref="TranscriptContentType"/>. </summary>
        public static implicit operator TranscriptContentType(string value) => new TranscriptContentType(value);

        /// <summary> Converts a string to a <see cref="TranscriptContentType"/>. </summary>
        public static implicit operator TranscriptContentType?(string value) => value == null ? null : new TranscriptContentType(value);

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is TranscriptContentType other && Equals(other);

        /// <inheritdoc/>
        public bool Equals(TranscriptContentType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;

        /// <inheritdoc/>
        public override string ToString() => _value;
    }
}
