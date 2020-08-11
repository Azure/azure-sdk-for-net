// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Models
{
    using System;
    using Microsoft.Azure.Search.Common;
    using Newtonsoft.Json;
    using Serialization;

    /// <summary>
    /// Defines the names of all character filters supported by Azure Cognitive Search.
    /// For more information, see <see href="https://docs.microsoft.com/azure/search/index-add-custom-analyzers">Add custom analyzers to string fields in an Azure Cognitive Search index</see>.
    /// </summary>
    [JsonConverter(typeof(ExtensibleEnumConverter<CharFilterName>))]
    public struct CharFilterName : IEquatable<CharFilterName>
    {
        private readonly string _value;

        // MAINTENANCE NOTE: Keep these ordered the same as the table on this page:
        // https://docs.microsoft.com/rest/api/searchservice/Custom-analyzers-in-Azure-Search

        /// <summary>
        /// A character filter that attempts to strip out HTML constructs.
        /// <see href="https://lucene.apache.org/core/4_10_3/analyzers-common/org/apache/lucene/analysis/charfilter/HTMLStripCharFilter.html" />
        /// </summary>
        public static readonly CharFilterName HtmlStrip = new CharFilterName("html_strip");

        private CharFilterName(string name)
        {
            Throw.IfArgumentNull(name, nameof(name));
            _value = name;
        }

        /// <summary>
        /// Defines implicit conversion from string to CharFilterName.
        /// </summary>
        /// <param name="name">string to convert.</param>
        /// <returns>The string as a CharFilterName.</returns>
        public static implicit operator CharFilterName(string name) => new CharFilterName(name);

        /// <summary>
        /// Defines explicit conversion from CharFilterName to string.
        /// </summary>
        /// <param name="name">CharFilterName to convert.</param>
        /// <returns>The CharFilterName as a string.</returns>
        public static explicit operator string(CharFilterName name) => name.ToString();

        /// <summary>
        /// Compares two CharFilterName values for equality.
        /// </summary>
        /// <param name="lhs">The first CharFilterName to compare.</param>
        /// <param name="rhs">The second CharFilterName to compare.</param>
        /// <returns>true if the CharFilterName objects are equal or are both null; false otherwise.</returns>
        public static bool operator ==(CharFilterName lhs, CharFilterName rhs) => Equals(lhs, rhs);

        /// <summary>
        /// Compares two CharFilterName values for inequality.
        /// </summary>
        /// <param name="lhs">The first CharFilterName to compare.</param>
        /// <param name="rhs">The second CharFilterName to compare.</param>
        /// <returns>true if the CharFilterName objects are not equal; false otherwise.</returns>
        public static bool operator !=(CharFilterName lhs, CharFilterName rhs) => !Equals(lhs, rhs);

        /// <summary>
        /// Compares the CharFilterName for equality with another CharFilterName.
        /// </summary>
        /// <param name="other">The CharFilterName with which to compare.</param>
        /// <returns><c>true</c> if the CharFilterName objects are equal; otherwise, <c>false</c>.</returns>
        public bool Equals(CharFilterName other) => _value == other._value;

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><c>true</c> if the specified object is equal to the current object; otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj) => obj is CharFilterName ? Equals((CharFilterName)obj) : false;

        /// <summary>
        /// Serves as the default hash function.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode() => _value.GetHashCode();

        /// <summary>
        /// Returns a string representation of the CharFilterName.
        /// </summary>
        /// <returns>The CharFilterName as a string.</returns>
        public override string ToString() => _value;
    }
}
