// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Search.Models
{
    /// <summary> Backward-compat alias for <see cref="AccessRuleDirection"/>. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public readonly partial struct SearchServiceNetworkSecurityPerimeterAccessRuleDirection : IEquatable<SearchServiceNetworkSecurityPerimeterAccessRuleDirection>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="SearchServiceNetworkSecurityPerimeterAccessRuleDirection"/>. </summary>
        /// <param name="value"> The value. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public SearchServiceNetworkSecurityPerimeterAccessRuleDirection(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string InboundValue = "Inbound";
        private const string OutboundValue = "Outbound";

        /// <summary> Inbound. </summary>
        public static SearchServiceNetworkSecurityPerimeterAccessRuleDirection Inbound { get; } = new SearchServiceNetworkSecurityPerimeterAccessRuleDirection(InboundValue);
        /// <summary> Outbound. </summary>
        public static SearchServiceNetworkSecurityPerimeterAccessRuleDirection Outbound { get; } = new SearchServiceNetworkSecurityPerimeterAccessRuleDirection(OutboundValue);

        /// <summary> Determines if two <see cref="SearchServiceNetworkSecurityPerimeterAccessRuleDirection"/> values are the same. </summary>
        public static bool operator ==(SearchServiceNetworkSecurityPerimeterAccessRuleDirection left, SearchServiceNetworkSecurityPerimeterAccessRuleDirection right) => left.Equals(right);
        /// <summary> Determines if two <see cref="SearchServiceNetworkSecurityPerimeterAccessRuleDirection"/> values are not the same. </summary>
        public static bool operator !=(SearchServiceNetworkSecurityPerimeterAccessRuleDirection left, SearchServiceNetworkSecurityPerimeterAccessRuleDirection right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="SearchServiceNetworkSecurityPerimeterAccessRuleDirection"/>. </summary>
        public static implicit operator SearchServiceNetworkSecurityPerimeterAccessRuleDirection(string value) => new SearchServiceNetworkSecurityPerimeterAccessRuleDirection(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is SearchServiceNetworkSecurityPerimeterAccessRuleDirection other && Equals(other);
        /// <inheritdoc />
        public bool Equals(SearchServiceNetworkSecurityPerimeterAccessRuleDirection other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);
        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
