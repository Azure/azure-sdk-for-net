// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Resources.Deployments.Models
{
    // Retain the GA type removed from the service specification in API version 2026-06-01.
    /// <summary> The value type of an extension config property. </summary>
    public readonly partial struct ExtensionConfigPropertyType : IEquatable<ExtensionConfigPropertyType>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="ExtensionConfigPropertyType"/>. </summary>
        /// <param name="value"> The value. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public ExtensionConfigPropertyType(string value)
        {
            Argument.AssertNotNull(value, nameof(value));
            _value = value;
        }

        /// <summary> Property type representing a string value. </summary>
        public static ExtensionConfigPropertyType String { get; } = new ExtensionConfigPropertyType("String");

        /// <summary> Property type representing an integer value. </summary>
        public static ExtensionConfigPropertyType Int { get; } = new ExtensionConfigPropertyType("Int");

        /// <summary> Property type representing a boolean value. </summary>
        public static ExtensionConfigPropertyType Bool { get; } = new ExtensionConfigPropertyType("Bool");

        /// <summary> Property type representing an array value. </summary>
        public static ExtensionConfigPropertyType Array { get; } = new ExtensionConfigPropertyType("Array");

        /// <summary> Property type representing an object value. </summary>
        public static ExtensionConfigPropertyType Object { get; } = new ExtensionConfigPropertyType("Object");

        /// <summary> Property type representing a secure string value. </summary>
        public static ExtensionConfigPropertyType SecureString { get; } = new ExtensionConfigPropertyType("SecureString");

        /// <summary> Property type representing a secure object value. </summary>
        public static ExtensionConfigPropertyType SecureObject { get; } = new ExtensionConfigPropertyType("SecureObject");

        /// <summary> Determines if two <see cref="ExtensionConfigPropertyType"/> values are the same. </summary>
        /// <param name="left"> The left value to compare. </param>
        /// <param name="right"> The right value to compare. </param>
        public static bool operator ==(ExtensionConfigPropertyType left, ExtensionConfigPropertyType right) => left.Equals(right);

        /// <summary> Determines if two <see cref="ExtensionConfigPropertyType"/> values are not the same. </summary>
        /// <param name="left"> The left value to compare. </param>
        /// <param name="right"> The right value to compare. </param>
        public static bool operator !=(ExtensionConfigPropertyType left, ExtensionConfigPropertyType right) => !left.Equals(right);

        /// <summary> Converts a string to a <see cref="ExtensionConfigPropertyType"/>. </summary>
        /// <param name="value"> The value. </param>
        public static implicit operator ExtensionConfigPropertyType(string value) => new ExtensionConfigPropertyType(value);

        /// <summary> Converts a string to a <see cref="ExtensionConfigPropertyType"/>. </summary>
        /// <param name="value"> The value. </param>
        public static implicit operator ExtensionConfigPropertyType?(string value) => value == null ? null : new ExtensionConfigPropertyType(value);

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is ExtensionConfigPropertyType other && Equals(other);

        /// <inheritdoc/>
        public bool Equals(ExtensionConfigPropertyType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;

        /// <inheritdoc/>
        public override string ToString() => _value;
    }
}
