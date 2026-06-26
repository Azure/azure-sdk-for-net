// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Describes if results should be in ascending/descending order. </summary>
    [Obsolete("Use FirewallPolicyIdpsQuerySortOrder instead.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public readonly partial struct FirewallPolicyIDPSQuerySortOrder : IEquatable<FirewallPolicyIDPSQuerySortOrder>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="FirewallPolicyIDPSQuerySortOrder"/>. </summary>
        /// <param name="value"> The value. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public FirewallPolicyIDPSQuerySortOrder(string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            _value = value;
        }

        /// <summary> Ascending. </summary>
        public static FirewallPolicyIDPSQuerySortOrder Ascending { get; } = new FirewallPolicyIDPSQuerySortOrder("Ascending");

        /// <summary> Descending. </summary>
        public static FirewallPolicyIDPSQuerySortOrder Descending { get; } = new FirewallPolicyIDPSQuerySortOrder("Descending");

        /// <summary> Determines if two <see cref="FirewallPolicyIDPSQuerySortOrder"/> values are the same. </summary>
        /// <param name="left"> The left value to compare. </param>
        /// <param name="right"> The right value to compare. </param>
        public static bool operator ==(FirewallPolicyIDPSQuerySortOrder left, FirewallPolicyIDPSQuerySortOrder right) => left.Equals(right);

        /// <summary> Determines if two <see cref="FirewallPolicyIDPSQuerySortOrder"/> values are not the same. </summary>
        /// <param name="left"> The left value to compare. </param>
        /// <param name="right"> The right value to compare. </param>
        public static bool operator !=(FirewallPolicyIDPSQuerySortOrder left, FirewallPolicyIDPSQuerySortOrder right) => !left.Equals(right);

        /// <summary> Converts a string to a <see cref="FirewallPolicyIDPSQuerySortOrder"/>. </summary>
        /// <param name="value"> The value. </param>
        public static implicit operator FirewallPolicyIDPSQuerySortOrder(string value) => new FirewallPolicyIDPSQuerySortOrder(value);

        /// <summary> Converts a string to a <see cref="FirewallPolicyIDPSQuerySortOrder"/>. </summary>
        /// <param name="value"> The value. </param>
        public static implicit operator FirewallPolicyIDPSQuerySortOrder?(string value) => value == null ? null : new FirewallPolicyIDPSQuerySortOrder(value);

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is FirewallPolicyIDPSQuerySortOrder other && Equals(other);

        /// <inheritdoc/>
        public bool Equals(FirewallPolicyIDPSQuerySortOrder other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;

        /// <inheritdoc/>
        public override string ToString() => _value;
    }
}
