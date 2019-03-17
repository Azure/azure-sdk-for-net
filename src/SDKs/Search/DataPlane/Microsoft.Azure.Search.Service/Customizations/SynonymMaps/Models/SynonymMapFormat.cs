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
    /// Defines the format of a Azure Search synonymmap.
    /// </summary>
    [JsonConverter(typeof(ExtensibleEnumConverter<SynonymMapFormat>))]
    public struct SynonymMapFormat : IEquatable<SynonymMapFormat>
    {
        private readonly string _value;

        /// <summary>
        /// Indicates Solr synonyms format
        /// </summary>
        public static readonly SynonymMapFormat Solr = new SynonymMapFormat("solr");

        private SynonymMapFormat(string formatName)
        {
            Throw.IfArgumentNull(formatName, nameof(formatName));
            _value = formatName;
        }

        /// <summary>
        /// Defines implicit conversion from string to SynonymMapFormat.
        /// </summary>
        /// <param name="formatName">string to convert.</param>
        /// <returns>The string as a SynonymMapFormat.</returns>
        public static implicit operator SynonymMapFormat(string formatName) => new SynonymMapFormat(formatName);

        /// <summary>
        /// Defines explicit conversion from SynonymMapFormat to string.
        /// </summary>
        /// <param name="formatName">SynonymMapFormat to convert.</param>
        /// <returns>The SynonymMapFormat as a string.</returns>
        public static explicit operator string(SynonymMapFormat formatName) => formatName.ToString();

        /// <summary>
        /// Compares two SynonymMapFormat values for equality.
        /// </summary>
        /// <param name="lhs">The first SynonymMapFormat to compare.</param>
        /// <param name="rhs">The second SynonymMapFormat to compare.</param>
        /// <returns>true if the SynonymMapFormat objects are equal or are both null; false otherwise.</returns>
        public static bool operator ==(SynonymMapFormat lhs, SynonymMapFormat rhs) => Equals(lhs, rhs);

        /// <summary>
        /// Compares two SynonymMapFormat values for inequality.
        /// </summary>
        /// <param name="lhs">The first SynonymMapFormat to compare.</param>
        /// <param name="rhs">The second SynonymMapFormat to compare.</param>
        /// <returns>true if the SynonymMapFormat objects are not equal; false otherwise.</returns>
        public static bool operator !=(SynonymMapFormat lhs, SynonymMapFormat rhs) => !Equals(lhs, rhs);

        /// <summary>
        /// Compares the SynonymMapFormat for equality with another SynonymMapFormat.
        /// </summary>
        /// <param name="other">The SynonymMapFormat with which to compare.</param>
        /// <returns><c>true</c> if the SynonymMapFormat objects are equal; otherwise, <c>false</c>.</returns>
        public bool Equals(SynonymMapFormat other) => _value == other._value;

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><c>true</c> if the specified object is equal to the current object; otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj) => obj is SynonymMapFormat ? Equals((SynonymMapFormat)obj) : false;

        /// <summary>
        /// Serves as the default hash function.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode() => _value.GetHashCode();

        /// <summary>
        /// Returns a string representation of the SynonymMapFormat.
        /// </summary>
        /// <returns>The SynonymMapFormat as a string.</returns>
        public override string ToString() => _value;
    }
}
