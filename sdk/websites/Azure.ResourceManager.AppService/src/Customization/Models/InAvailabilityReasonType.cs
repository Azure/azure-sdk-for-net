// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.AppService.Models
{
    /// <summary> &lt;code&gt;Invalid&lt;/code&gt; indicates the name provided does not match Azure App Service naming requirements. &lt;code&gt;AlreadyExists&lt;/code&gt; indicates that the name is already in use and is therefore unavailable. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public readonly partial struct InAvailabilityReasonType : IEquatable<InAvailabilityReasonType>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="InAvailabilityReasonType"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public InAvailabilityReasonType(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string InvalidValue = "Invalid";
        private const string AlreadyExistsValue = "AlreadyExists";

        /// <summary> Invalid. </summary>
        public static InAvailabilityReasonType Invalid { get; } = new InAvailabilityReasonType(InvalidValue);
        /// <summary> AlreadyExists. </summary>
        public static InAvailabilityReasonType AlreadyExists { get; } = new InAvailabilityReasonType(AlreadyExistsValue);
        /// <summary> Determines if two <see cref="InAvailabilityReasonType"/> values are the same. </summary>
        public static bool operator ==(InAvailabilityReasonType left, InAvailabilityReasonType right) => left.Equals(right);
        /// <summary> Determines if two <see cref="InAvailabilityReasonType"/> values are not the same. </summary>
        public static bool operator !=(InAvailabilityReasonType left, InAvailabilityReasonType right) => !left.Equals(right);
        /// <summary> Converts a <see cref="string"/> to a <see cref="InAvailabilityReasonType"/>. </summary>
        public static implicit operator InAvailabilityReasonType(string value) => new InAvailabilityReasonType(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is InAvailabilityReasonType other && Equals(other);
        /// <inheritdoc />
        public bool Equals(InAvailabilityReasonType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
