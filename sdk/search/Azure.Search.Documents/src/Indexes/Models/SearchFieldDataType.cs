// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Search.Documents.Indexes.Models
{
    public readonly partial struct SearchFieldDataType
    {
        private const string CollectionPrefix = "Collection(";

#pragma warning disable CA1720 // Identifier contains type name
        /// <summary>A <see cref="string"/> type.</summary>
        [CodeGenMember("EdmString")]
        public static SearchFieldDataType String { get; } = new SearchFieldDataType(StringValue);

        /// <summary> Indicates that a field contains a 8-bit signed integer. This is only valid when used with Collection(Edm.SByte). </summary>
        [CodeGenMember("EdmSByte")]
        public static SearchFieldDataType SByte { get; } = new SearchFieldDataType(SByteValue);

        /// <summary> Indicates that a field contains a 8-bit unsigned integer. This is only valid when used with Collection(Edm.Byte). </summary>
        [CodeGenMember("EdmByte")]
        public static SearchFieldDataType Byte { get; } = new SearchFieldDataType(ByteValue);

        /// <summary> Indicates that a field contains a 16-bit signed integer. This is only valid when used with Collection(Edm.Int16). </summary>
        [CodeGenMember("EdmInt16")]
        public static SearchFieldDataType Int16 { get; } = new SearchFieldDataType(Int16Value);

        /// <summary>An <see cref="int"/> type, or something that can convert to an <see cref="int"/>.</summary>
        [CodeGenMember("EdmInt32")]
        public static SearchFieldDataType Int32 { get; } = new SearchFieldDataType(Int32Value);

        /// <summary>An <see cref="long"/> type, or something that can convert to an <see cref="long"/>.</summary>
        [CodeGenMember("EdmInt64")]
        public static SearchFieldDataType Int64 { get; } = new SearchFieldDataType(Int64Value);

        /// <summary>A <see cref="double"/> type, or something that can convert to a <see cref="double"/>.</summary>
        [CodeGenMember("EdmDouble")]
        public static SearchFieldDataType Double { get; } = new SearchFieldDataType(DoubleValue);
#pragma warning restore CA1720 // Identifier contains type name

        /// <summary>A <see cref="bool"/> type.</summary>
        [CodeGenMember("EdmBoolean")]
        public static SearchFieldDataType Boolean { get; } = new SearchFieldDataType(BooleanValue);

        /// <summary>A <see cref="System.DateTimeOffset"/> type, or <see cref="System.DateTime"/> converted to a <see cref="System.DateTimeOffset"/>.</summary>
        [CodeGenMember("EdmDateTimeOffset")]
        public static SearchFieldDataType DateTimeOffset { get; } = new SearchFieldDataType(DateTimeOffsetValue);

        /// <summary>A geographic point type.</summary>
        [CodeGenMember("EdmGeographyPoint")]
        public static SearchFieldDataType GeographyPoint { get; } = new SearchFieldDataType(GeographyPointValue);

        /// <summary>A complex type with child fields.</summary>
        [CodeGenMember("EdmComplexType")]
        public static SearchFieldDataType Complex { get; } = new SearchFieldDataType(ComplexValue);

        /// <summary>A single type.</summary>
        [CodeGenMember("EdmSingle")]
        public static SearchFieldDataType Single { get; } = new SearchFieldDataType(SingleValue);

        /// <summary>
        /// Gets a <see cref="SearchFieldDataType"/> representing a collection of <paramref name="type"/>.
        /// </summary>
        /// <param name="type">The type of collection.</param>
        /// <returns>A <see cref="SearchFieldDataType"/> representing a collection of <paramref name="type"/>.</returns>
        public static SearchFieldDataType Collection(SearchFieldDataType type) => type.IsCollection ? type : new SearchFieldDataType(string.Concat(CollectionPrefix, type._value, ")"));

        /// <summary>
        /// Gets a value indicating whether the <see cref="SearchFieldDataType"/> represents a collection.
        /// </summary>
        public bool IsCollection => _value.StartsWith(CollectionPrefix, StringComparison.InvariantCultureIgnoreCase);
    }
}
