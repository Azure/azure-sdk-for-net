// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.Data.AppConfiguration
{
    /// <summary> Feature flag label fields to retrieve when getting feature flag labels. </summary>
    public readonly partial struct FeatureFlagLabelFields : IEquatable<FeatureFlagLabelFields>
    {
        private readonly string _value;
        /// <summary> Name field. </summary>
        private const string NameValue = "name";

        /// <summary> Initializes a new instance of <see cref="FeatureFlagLabelFields"/>. </summary>
        /// <param name="value"> The value. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public FeatureFlagLabelFields(string value)
        {
            Argument.AssertNotNull(value, nameof(value));

            _value = value;
        }

        /// <summary> Name field. </summary>
        public static FeatureFlagLabelFields Name { get; } = new FeatureFlagLabelFields(NameValue);

        /// <summary> Determines if two <see cref="FeatureFlagLabelFields"/> values are the same. </summary>
        /// <param name="left"> The left value to compare. </param>
        /// <param name="right"> The right value to compare. </param>
        public static bool operator ==(FeatureFlagLabelFields left, FeatureFlagLabelFields right) => left.Equals(right);

        /// <summary> Determines if two <see cref="FeatureFlagLabelFields"/> values are not the same. </summary>
        /// <param name="left"> The left value to compare. </param>
        /// <param name="right"> The right value to compare. </param>
        public static bool operator !=(FeatureFlagLabelFields left, FeatureFlagLabelFields right) => !left.Equals(right);

        /// <summary> Converts a string to a <see cref="FeatureFlagLabelFields"/>. </summary>
        /// <param name="value"> The value. </param>
        public static implicit operator FeatureFlagLabelFields(string value) => new FeatureFlagLabelFields(value);

        /// <summary> Converts a string to a <see cref="FeatureFlagLabelFields"/>. </summary>
        /// <param name="value"> The value. </param>
        public static implicit operator FeatureFlagLabelFields?(string value) => value == null ? null : new FeatureFlagLabelFields(value);

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is FeatureFlagLabelFields other && Equals(other);

        /// <inheritdoc/>
        public bool Equals(FeatureFlagLabelFields other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;

        /// <inheritdoc/>
        public override string ToString() => _value;
    }
}
