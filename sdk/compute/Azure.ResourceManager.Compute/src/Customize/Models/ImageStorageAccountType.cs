// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Compute.Models
{
    public readonly partial struct ImageStorageAccountType : IEquatable<ImageStorageAccountType>
    {
        private readonly string _value;
        private const string StandardSsdLrsValue = "StandardSSD_LRS";

        /// <summary> Initializes a new instance of <see cref="ImageStorageAccountType"/>. </summary>
        /// <param name="value"> The value. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public ImageStorageAccountType(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        /// <summary> StandardSSD_LRS. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ImageStorageAccountType StandardSsdLrs { get; } = new ImageStorageAccountType(StandardSsdLrsValue);

        /// <summary> Determines if two <see cref="ImageStorageAccountType"/> values are the same. </summary>
        public static bool operator ==(ImageStorageAccountType left, ImageStorageAccountType right) => left.Equals(right);

        /// <summary> Determines if two <see cref="ImageStorageAccountType"/> values are not the same. </summary>
        public static bool operator !=(ImageStorageAccountType left, ImageStorageAccountType right) => !left.Equals(right);

        /// <summary> Converts a string to a <see cref="ImageStorageAccountType"/>. </summary>
        public static implicit operator ImageStorageAccountType(string value) => new ImageStorageAccountType(value);

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is ImageStorageAccountType other && Equals(other);

        /// <inheritdoc/>
        public bool Equals(ImageStorageAccountType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;

        /// <inheritdoc/>
        public override string ToString() => _value;
    }
}
