// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.SecurityCenter.Models
{
    // Generated code only emits extensible-enum CLR types that are still referenced by the current TypeSpec model graph; this previous GA enum name is no longer generated, but existing public signatures still reference it. Keep the enum wrapper so constants, conversions, and equality remain source-compatible.
    // The current TypeSpec no longer emits the GA strongly typed secure-score expand enum, so custom code keeps the prior OData expand value used by public method signatures.
    /// <summary> OData expand. </summary>
    public readonly partial struct SecurityScoreODataExpand : IEquatable<SecurityScoreODataExpand>
    {
        private readonly string _value;
        private const string DefinitionValue = "definition";

        /// <summary> Initializes a new instance of <see cref="SecurityScoreODataExpand"/>. </summary>
        /// <param name="value"> The value. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public SecurityScoreODataExpand(string value)
        {
            Argument.AssertNotNull(value, nameof(value));

            _value = value;
        }

        /// <summary> Add definition object for each control. </summary>
        public static SecurityScoreODataExpand Definition { get; } = new SecurityScoreODataExpand(DefinitionValue);

        /// <summary> Determines if two <see cref="SecurityScoreODataExpand"/> values are the same. </summary>
        public static bool operator ==(SecurityScoreODataExpand left, SecurityScoreODataExpand right) => left.Equals(right);

        /// <summary> Determines if two <see cref="SecurityScoreODataExpand"/> values are not the same. </summary>
        public static bool operator !=(SecurityScoreODataExpand left, SecurityScoreODataExpand right) => !left.Equals(right);

        /// <summary> Converts a string to a <see cref="SecurityScoreODataExpand"/>. </summary>
        public static implicit operator SecurityScoreODataExpand(string value) => new SecurityScoreODataExpand(value);

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is SecurityScoreODataExpand other && Equals(other);

        /// <inheritdoc/>
        public bool Equals(SecurityScoreODataExpand other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;

        /// <inheritdoc/>
        public override string ToString() => _value;
    }
}
