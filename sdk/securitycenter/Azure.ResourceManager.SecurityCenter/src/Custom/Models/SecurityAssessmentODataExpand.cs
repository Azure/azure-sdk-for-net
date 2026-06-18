// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.SecurityCenter.Models
{
    // Generated code only emits extensible-enum CLR types that are still referenced by the current TypeSpec model graph; this previous GA enum name is no longer generated, but existing public signatures still reference it. Keep the enum wrapper so constants, conversions, and equality remain source-compatible.
    // The current TypeSpec no longer emits the GA strongly typed assessment expand enum, so custom code keeps the prior OData expand value used by public method signatures.
    /// <summary> OData expand. </summary>
    public readonly partial struct SecurityAssessmentODataExpand : IEquatable<SecurityAssessmentODataExpand>
    {
        private readonly string _value;
        private const string LinksValue = "links";
        private const string MetadataValue = "metadata";

        /// <summary> Initializes a new instance of <see cref="SecurityAssessmentODataExpand"/>. </summary>
        /// <param name="value"> The value. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public SecurityAssessmentODataExpand(string value)
        {
            Argument.AssertNotNull(value, nameof(value));

            _value = value;
        }

        /// <summary> All links associated with an assessment. </summary>
        public static SecurityAssessmentODataExpand Links { get; } = new SecurityAssessmentODataExpand(LinksValue);
        /// <summary> Assessment metadata. </summary>
        public static SecurityAssessmentODataExpand Metadata { get; } = new SecurityAssessmentODataExpand(MetadataValue);

        /// <summary> Determines if two <see cref="SecurityAssessmentODataExpand"/> values are the same. </summary>
        public static bool operator ==(SecurityAssessmentODataExpand left, SecurityAssessmentODataExpand right) => left.Equals(right);

        /// <summary> Determines if two <see cref="SecurityAssessmentODataExpand"/> values are not the same. </summary>
        public static bool operator !=(SecurityAssessmentODataExpand left, SecurityAssessmentODataExpand right) => !left.Equals(right);

        /// <summary> Converts a string to a <see cref="SecurityAssessmentODataExpand"/>. </summary>
        public static implicit operator SecurityAssessmentODataExpand(string value) => new SecurityAssessmentODataExpand(value);

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is SecurityAssessmentODataExpand other && Equals(other);

        /// <inheritdoc/>
        public bool Equals(SecurityAssessmentODataExpand other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;

        /// <inheritdoc/>
        public override string ToString() => _value;
    }
}
