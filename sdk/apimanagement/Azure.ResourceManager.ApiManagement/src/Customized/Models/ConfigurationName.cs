// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.ApiManagement.Models
{
    // The generator only emits a minimal partial struct (nullable implicit operator) for this
    // path-parameter enum. This custom code adds the full extensible-enum body required for
    // callers to construct and compare ConfigurationName values.
    // Not spec-fixable: the generator doesn't emit a full extensible-enum for path parameter types.

    /// <summary> The identifier of the Git configuration. </summary>
    public readonly partial struct ConfigurationName : IEquatable<ConfigurationName>
    {
        private readonly string _value;
        private const string ConfigurationValue = "configuration";

        /// <summary> Initializes a new instance of <see cref="ConfigurationName"/>. </summary>
        /// <param name="value"> The value. </param>
        public ConfigurationName(string value)
        {
            Argument.AssertNotNull(value, nameof(value));
            _value = value;
        }

        /// <summary> Gets the Configuration. </summary>
        public static ConfigurationName Configuration { get; } = new ConfigurationName(ConfigurationValue);

        /// <summary> Converts a string to a <see cref="ConfigurationName"/>. </summary>
        public static implicit operator ConfigurationName(string value) => new ConfigurationName(value);

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is ConfigurationName other && Equals(other);

        /// <inheritdoc/>
        public bool Equals(ConfigurationName other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;

        /// <summary> Determines if two <see cref="ConfigurationName"/> values are the same. </summary>
        public static bool operator ==(ConfigurationName left, ConfigurationName right) => left.Equals(right);

        /// <summary> Determines if two <see cref="ConfigurationName"/> values are not the same. </summary>
        public static bool operator !=(ConfigurationName left, ConfigurationName right) => !left.Equals(right);

        /// <inheritdoc/>
        public override string ToString() => _value;
    }
}
