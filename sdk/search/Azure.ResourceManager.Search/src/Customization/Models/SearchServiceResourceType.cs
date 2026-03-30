// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.Search.Models
{
    /// <summary> The type of the resource whose name is to be validated. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public readonly partial struct SearchServiceResourceType : IEquatable<SearchServiceResourceType>
    {
        private readonly string _value;
        /// <summary> searchServices. </summary>
        private const string SearchServicesValue = "searchServices";

        /// <summary> Initializes a new instance of <see cref="SearchServiceResourceType"/>. </summary>
        /// <param name="value"> The value. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public SearchServiceResourceType(string value)
        {
            Argument.AssertNotNull(value, nameof(value));

            _value = value;
        }

        /// <summary> searchServices. </summary>
        public static SearchServiceResourceType SearchServices { get; } = new SearchServiceResourceType(SearchServicesValue);

        /// <summary> Determines if two <see cref="SearchServiceResourceType"/> values are the same. </summary>
        /// <param name="left"> The left value to compare. </param>
        /// <param name="right"> The right value to compare. </param>
        public static bool operator ==(SearchServiceResourceType left, SearchServiceResourceType right) => left.Equals(right);

        /// <summary> Determines if two <see cref="SearchServiceResourceType"/> values are not the same. </summary>
        /// <param name="left"> The left value to compare. </param>
        /// <param name="right"> The right value to compare. </param>
        public static bool operator !=(SearchServiceResourceType left, SearchServiceResourceType right) => !left.Equals(right);

        /// <summary> Converts a string to a <see cref="SearchServiceResourceType"/>. </summary>
        /// <param name="value"> The value. </param>
        public static implicit operator SearchServiceResourceType(string value) => new SearchServiceResourceType(value);

        /// <summary> Converts a string to a <see cref="SearchServiceResourceType"/>. </summary>
        /// <param name="value"> The value. </param>
        public static implicit operator SearchServiceResourceType?(string value) => value == null ? null : new SearchServiceResourceType(value);

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is SearchServiceResourceType other && Equals(other);

        /// <inheritdoc/>
        public bool Equals(SearchServiceResourceType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;

        /// <inheritdoc/>
        public override string ToString() => _value;
    }
}
