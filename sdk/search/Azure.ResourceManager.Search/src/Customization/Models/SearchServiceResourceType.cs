// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Search.Models
{
    /// <summary> The type of the resource whose name is to be validated. This value must always be 'searchServices'. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public readonly partial struct SearchServiceResourceType : IEquatable<SearchServiceResourceType>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="SearchServiceResourceType"/>. </summary>
        /// <param name="value"> The value. </param>
        public SearchServiceResourceType(string value) => _value = value;

        /// <summary> searchServices. </summary>
        public static SearchServiceResourceType SearchServices { get; } = new SearchServiceResourceType("searchServices");

        /// <summary> Converts a string to a <see cref="SearchServiceResourceType"/>. </summary>
        public static implicit operator SearchServiceResourceType(string value) => new SearchServiceResourceType(value);

        /// <inheritdoc />
        public bool Equals(SearchServiceResourceType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        public override bool Equals(object obj) => obj is SearchServiceResourceType other && Equals(other);

        /// <inheritdoc />
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;

        /// <inheritdoc />
        public override string ToString() => _value;

        /// <summary> Equality operator. </summary>
        public static bool operator ==(SearchServiceResourceType left, SearchServiceResourceType right) => left.Equals(right);

        /// <summary> Inequality operator. </summary>
        public static bool operator !=(SearchServiceResourceType left, SearchServiceResourceType right) => !left.Equals(right);
    }
}
