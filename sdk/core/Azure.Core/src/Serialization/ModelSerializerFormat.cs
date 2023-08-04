// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.Core.Serialization
{
    /// <summary>
    /// A format used to specify how a model should be serialized and deserialized.
    /// </summary>
    public readonly partial struct ModelSerializerFormat : IEquatable<ModelSerializerFormat>
    {
        internal const string JsonValue = "J";
        internal const string WireValue = "W";

        /// <summary>
        /// Default format which will serialize all properties including read-only and additional properties.
        /// The format will always be JSON.
        /// </summary>
        public static readonly ModelSerializerFormat Json = new ModelSerializerFormat(JsonValue);

        /// <summary>
        /// Format used to communicate with Azure services.  This format will not serialize read-only properties or additional properties.
        /// The format will vary between XML and JSON depdending on the service.
        /// </summary>
        public static readonly ModelSerializerFormat Wire = new ModelSerializerFormat(WireValue);

        private readonly string _value;

        /// <summary>
        /// Instantiate a new <see cref="ModelSerializerFormat"/>.
        /// </summary>
        public ModelSerializerFormat(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        /// <summary>
        /// Determines if two <see cref="ModelSerializerFormat"/> values are the same.
        /// </summary>
        /// <param name="left">The first <see cref="ModelSerializerFormat"/> to compare.</param>
        /// <param name="right">The second <see cref="ModelSerializerFormat"/> to compare.</param>
        /// <returns>True if <paramref name="left"/> and <paramref name="right"/> are the same; otherwise, false.</returns>
        public static bool operator ==(ModelSerializerFormat left, ModelSerializerFormat right) => left.Equals(right);

        /// <summary>
        /// Determines if two <see cref="ModelSerializerFormat"/> values are different.
        /// </summary>
        /// <param name="left">The first <see cref="ModelSerializerFormat"/> to compare.</param>
        /// <param name="right">The second <see cref="ModelSerializerFormat"/> to compare.</param>
        /// <returns>True if <paramref name="left"/> and <paramref name="right"/> are different; otherwise, false.</returns>
        public static bool operator !=(ModelSerializerFormat left, ModelSerializerFormat right) => !left.Equals(right);

        /// <summary>
        /// Converts a string to a <see cref="ModelSerializerFormat"/>.
        /// </summary>
        /// <param name="value">The string value to convert.</param>
        public static implicit operator ModelSerializerFormat(string value) => new ModelSerializerFormat(value);

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals([System.Diagnostics.CodeAnalysis.AllowNull] object obj) => obj is ModelSerializerFormat other && Equals(other);

        /// <inheritdoc/>
        public bool Equals(ModelSerializerFormat other) => string.Equals(_value, other._value, StringComparison.Ordinal);

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;

        /// <inheritdoc/>
        public override string ToString() => _value;
    }
}
