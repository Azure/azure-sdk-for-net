// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.Data.AppConfiguration
{
    /// <summary> The resource type used to filter the labels returned by <see cref="ConfigurationClient.GetLabels(SettingLabelSelector, System.Threading.CancellationToken)"/>. </summary>
    public readonly struct SettingLabelResourceType : IEquatable<SettingLabelResourceType>
    {
        private readonly string _value;
        private const string KeyValueValue = "kv";
        private const string FeatureFlagValue = "ff";

        /// <summary>
        /// Initializes a new instance of the <see cref="SettingLabelResourceType"/> object.
        /// </summary>
        /// <param name="value">The resource type value used to filter labels.</param>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        /// <remarks>Please use one of the constant members over creating a custom value unless you have special needs for doing so.</remarks>
        public SettingLabelResourceType(string value)
        {
            Argument.AssertNotNullOrEmpty(value, nameof(value));
            _value = value;
        }

        /// <summary> Filters the returned labels to those associated with key-value settings. </summary>
        public static SettingLabelResourceType KeyValue { get; } = new SettingLabelResourceType(KeyValueValue);

        /// <summary> Filters the returned labels to those associated with feature flags. </summary>
        public static SettingLabelResourceType FeatureFlag { get; } = new SettingLabelResourceType(FeatureFlagValue);

        /// <summary> Determines if two <see cref="SettingLabelResourceType"/> values are the same. </summary>
        public static bool operator ==(SettingLabelResourceType left, SettingLabelResourceType right) => left.Equals(right);
        /// <summary> Determines if two <see cref="SettingLabelResourceType"/> values are not the same. </summary>
        public static bool operator !=(SettingLabelResourceType left, SettingLabelResourceType right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="SettingLabelResourceType"/>. </summary>
        public static implicit operator SettingLabelResourceType(string value) => new SettingLabelResourceType(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is SettingLabelResourceType other && Equals(other);
        /// <inheritdoc />
        public bool Equals(SettingLabelResourceType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
