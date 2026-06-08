// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.MachineLearning.Models
{
    // Customized: the shipped API exposed both PublicNetworkAccess and MachineLearningPublicNetworkAccessType names.
    public readonly partial struct MachineLearningPublicNetworkAccessType : IEquatable<MachineLearningPublicNetworkAccessType>
    {
        private readonly PublicNetworkAccess _value;

        /// <summary> Initializes a new instance of <see cref="MachineLearningPublicNetworkAccessType"/>. </summary>
        /// <param name="value"> The value. </param>
        public MachineLearningPublicNetworkAccessType(string value)
        {
            _value = new PublicNetworkAccess(value);
        }

        /// <summary> Gets the Enabled. </summary>
        public static MachineLearningPublicNetworkAccessType Enabled { get; } = new MachineLearningPublicNetworkAccessType(PublicNetworkAccess.Enabled.ToString());

        /// <summary> Gets the Disabled. </summary>
        public static MachineLearningPublicNetworkAccessType Disabled { get; } = new MachineLearningPublicNetworkAccessType(PublicNetworkAccess.Disabled.ToString());

        /// <summary> Determines if two <see cref="MachineLearningPublicNetworkAccessType"/> values are the same. </summary>
        /// <param name="left"> The left value to compare. </param>
        /// <param name="right"> The right value to compare. </param>
        public static bool operator ==(MachineLearningPublicNetworkAccessType left, MachineLearningPublicNetworkAccessType right) => left.Equals(right);

        /// <summary> Determines if two <see cref="MachineLearningPublicNetworkAccessType"/> values are not the same. </summary>
        /// <param name="left"> The left value to compare. </param>
        /// <param name="right"> The right value to compare. </param>
        public static bool operator !=(MachineLearningPublicNetworkAccessType left, MachineLearningPublicNetworkAccessType right) => !left.Equals(right);

        /// <summary> Converts a string to a <see cref="MachineLearningPublicNetworkAccessType"/>. </summary>
        /// <param name="value"> The value. </param>
        public static implicit operator MachineLearningPublicNetworkAccessType(string value) => new MachineLearningPublicNetworkAccessType(value);

        /// <summary> Converts a string to a <see cref="MachineLearningPublicNetworkAccessType"/>. </summary>
        /// <param name="value"> The value. </param>
        public static implicit operator MachineLearningPublicNetworkAccessType?(string value) => value == null ? null : new MachineLearningPublicNetworkAccessType(value);

        /// <summary> Converts a <see cref="MachineLearningPublicNetworkAccessType"/> to a <see cref="PublicNetworkAccess"/>. </summary>
        /// <param name="value"> The value. </param>
        public static implicit operator PublicNetworkAccess(MachineLearningPublicNetworkAccessType value) => new PublicNetworkAccess(value.ToString());

        /// <summary> Converts a <see cref="MachineLearningPublicNetworkAccessType"/> to a <see cref="PublicNetworkAccess"/>. </summary>
        /// <param name="value"> The value. </param>
        public static implicit operator PublicNetworkAccess?(MachineLearningPublicNetworkAccessType? value) => value.HasValue ? new PublicNetworkAccess(value.Value.ToString()) : null;

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is MachineLearningPublicNetworkAccessType other && Equals(other);

        /// <inheritdoc/>
        public bool Equals(MachineLearningPublicNetworkAccessType other) => string.Equals(ToString(), other.ToString(), StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value.GetHashCode();

        /// <inheritdoc/>
        public override string ToString() => _value.ToString();
    }
}
