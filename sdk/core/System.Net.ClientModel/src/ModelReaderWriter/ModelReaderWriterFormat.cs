// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;

namespace System.Net.ClientModel.Core.Content
{
    /// <summary>
    /// A format used to specify how a model should be read and written.
    /// </summary>
    public readonly partial struct ModelReaderWriterFormat : IEquatable<ModelReaderWriterFormat>
    {
        internal const string JsonValue = "J";
        internal const string WireValue = "W";

        /// <summary>
        /// Default format which will write all properties including read-only and additional properties.
        /// The format will always be JSON.
        /// </summary>
        public static readonly ModelReaderWriterFormat Json = new ModelReaderWriterFormat(JsonValue);

        /// <summary>
        /// Format used to write this model when sending as a request to a service.
        /// It may not write read-only properties or additional properties.
        /// The content-type will vary between JSON, XML, etc., depending on the service.
        ///
        /// Most use cases should prefer a more complete format like <see cref="ModelReaderWriterFormat.Json"/> that includes
        /// read-only and additional properties.
        /// </summary>
        public static readonly ModelReaderWriterFormat Wire = new ModelReaderWriterFormat(WireValue);

        private readonly string _value;

        /// <summary>
        /// Instantiate a new <see cref="ModelReaderWriterFormat"/>.
        /// </summary>
        public ModelReaderWriterFormat(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        /// <summary>
        /// Determines if two <see cref="ModelReaderWriterFormat"/> values are the same.
        /// </summary>
        /// <param name="left">The first <see cref="ModelReaderWriterFormat"/> to compare.</param>
        /// <param name="right">The second <see cref="ModelReaderWriterFormat"/> to compare.</param>
        /// <returns>True if <paramref name="left"/> and <paramref name="right"/> are the same; otherwise, false.</returns>
        public static bool operator ==(ModelReaderWriterFormat left, ModelReaderWriterFormat right) => left.Equals(right);

        /// <summary>
        /// Determines if two <see cref="ModelReaderWriterFormat"/> values are different.
        /// </summary>
        /// <param name="left">The first <see cref="ModelReaderWriterFormat"/> to compare.</param>
        /// <param name="right">The second <see cref="ModelReaderWriterFormat"/> to compare.</param>
        /// <returns>True if <paramref name="left"/> and <paramref name="right"/> are different; otherwise, false.</returns>
        public static bool operator !=(ModelReaderWriterFormat left, ModelReaderWriterFormat right) => !left.Equals(right);

        /// <summary>
        /// Converts a string to a <see cref="ModelReaderWriterFormat"/>.
        /// </summary>
        /// <param name="value">The string value to convert.</param>
        public static implicit operator ModelReaderWriterFormat(string value) => new ModelReaderWriterFormat(value);

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object? obj) => obj is ModelReaderWriterFormat other && Equals(other);

        /// <inheritdoc/>
        public bool Equals(ModelReaderWriterFormat other) => string.Equals(_value, other._value, StringComparison.Ordinal);

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;

        /// <inheritdoc/>
        public override string ToString() => _value;
    }
}
