// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Storage.Models
{
    /// <summary> The SAS expiration action. Can only be Log. </summary>
    public readonly partial struct ExpirationAction : IEquatable<ExpirationAction>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="ExpirationAction"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public ExpirationAction(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string LogValue = "Log";

        /// <summary> Log. </summary>
        public static ExpirationAction Log { get; } = new ExpirationAction(LogValue);
        /// <summary> Determines if two <see cref="ExpirationAction"/> values are the same. </summary>
        public static bool operator ==(ExpirationAction left, ExpirationAction right) => left.Equals(right);
        /// <summary> Determines if two <see cref="ExpirationAction"/> values are not the same. </summary>
        public static bool operator !=(ExpirationAction left, ExpirationAction right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="ExpirationAction"/>. </summary>
        public static implicit operator ExpirationAction(string value) => new ExpirationAction(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is ExpirationAction other && Equals(other);
        /// <inheritdoc />
        public bool Equals(ExpirationAction other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
