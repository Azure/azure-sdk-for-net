// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Core
{
    /// <summary>
    /// Represents content type.
    /// </summary>
    public readonly struct ContentType : IEquatable<ContentType>, IEquatable<string>
    {
        private readonly string _contentType;

        /// <summary>
        /// application/json
        /// </summary>
        public static ContentType ApplicationJson { get; } = new ContentType("application/json");

        /// <summary>
        /// application/octet-stream
        /// </summary>
        public static ContentType ApplicationOctetStream { get; } = new ContentType("application/octet-stream");

        /// <summary>
        /// text/plain
        /// </summary>
        public static ContentType TextPlain { get; } = new ContentType("text/plain");

        /// <summary>
        /// Creates an instance of <see cref="ContentType"/>.
        /// </summary>
        /// <param name="contentType">The content type string.</param>
        public ContentType(string contentType)
        {
            Argument.AssertNotNull(contentType, nameof(contentType));

            _contentType = contentType;
        }

        /// <summary>
        /// Creates an instance of <see cref="ContentType"/>.
        /// </summary>
        /// <param name="contentType">The content type string.</param>
        public static implicit operator ContentType(string contentType) => new ContentType(contentType);

        /// <inheritdoc />
        public bool Equals(ContentType other)
        {
            return string.Equals(_contentType, other._contentType, StringComparison.Ordinal);
        }

        /// <inheritdoc />
        public bool Equals(string? other)
            => string.Equals(_contentType, other, StringComparison.Ordinal);

        /// <inheritdoc />
        public override bool Equals(object? obj)
            => (obj is ContentType other && Equals(other)) ||
               (obj is string str && str.Equals(_contentType, StringComparison.Ordinal));

        /// <inheritdoc />
        public override int GetHashCode()
            => _contentType?.GetHashCode() ?? 0;

        /// <summary>
        /// Compares equality of two <see cref="ContentType"/> instances.
        /// </summary>
        /// <param name="left">The method to compare.</param>
        /// <param name="right">The method to compare against.</param>
        /// <returns><c>true</c> if <see cref="ContentType"/> values are equal for <paramref name="left"/> and <paramref name="right"/>, otherwise <c>false</c>.</returns>
        public static bool operator ==(ContentType left, ContentType right)
            => left.Equals(right);

        /// <summary>
        /// Compares inequality of two <see cref="ContentType"/> instances.
        /// </summary>
        /// <param name="left">The method to compare.</param>
        /// <param name="right">The method to compare against.</param>
        /// <returns><c>true</c> if <see cref="ContentType"/> values are equal for <paramref name="left"/> and <paramref name="right"/>, otherwise <c>false</c>.</returns>
        public static bool operator !=(ContentType left, ContentType right)
            => !left.Equals(right);

        /// <inheritdoc />
        public override string ToString() => _contentType ?? "";
    }
}
